using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Kinect;

namespace Trainyourself.Pages
{
    /// <summary>
    /// Interaction logic for LiveviewPushups.xaml
    /// </summary>
    public partial class LiveviewPushups : Page
    {
        private KinectSensor sensor;
        private byte[] colorPixels;
        private WriteableBitmap colorBitmap;

        public LiveviewPushups()
        {
            InitializeComponent();
            WindowLoaded(sensor, null);
        }
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // Look through all sensors and start the first connected one.
            // This requires that a Kinect is connected at the time of app startup.
            // To make your app robust against plug/unplug, 
            // it is recommended to use KinectSensorChooser provided in Microsoft.Kinect.Toolkit (See components in Toolkit Browser).
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    sensor = potentialSensor;
                    break;
                }
            }

            if (null != sensor)
            {
                // Turn on the color stream to receive color frames
                sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);

                // Allocate space to put the pixels we'll receive
                colorPixels = new byte[sensor.ColorStream.FramePixelDataLength];

                // This is the bitmap we'll display on-screen
                colorBitmap = new WriteableBitmap(sensor.ColorStream.FrameWidth, sensor.ColorStream.FrameHeight, 96.0, 96.0, PixelFormats.Bgr32, null);

                // Set the image we display to point to the bitmap where we'll put the image data
                Image.Source = colorBitmap;

                // Add an event handler to be called whenever there is new color frame data
                sensor.ColorFrameReady += SensorColorFrameReady;

                // Start the sensor!
                try
                {
                    sensor.Start();
                }
                catch (IOException)
                {
                    sensor = null;
                }
            }
        }
        private void SensorColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
            {
                if (colorFrame != null)
                {
                    // Copy the pixel data from the image to a temporary array
                    colorFrame.CopyPixelDataTo(colorPixels);

                    // Write the pixel data into our bitmap
                    colorBitmap.WritePixels(
                        new Int32Rect(0, 0, colorBitmap.PixelWidth, colorBitmap.PixelHeight),
                        colorPixels,
                        colorBitmap.PixelWidth * sizeof(int),
                        0);
                }
            }
        }
    }
}
