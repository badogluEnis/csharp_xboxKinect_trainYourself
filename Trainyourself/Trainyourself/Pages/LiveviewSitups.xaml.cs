using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Kinect;

namespace Trainyourself.Pages
{
    /// <summary>
    /// Interaction logic for Liveview.xaml
    /// </summary>
    public partial class LiveviewSitups
    {
        private KinectSensor _sensor;
        private byte[] _colorPixels;
        private WriteableBitmap _colorBitmap;

        public LiveviewSitups()
        {
            InitializeComponent();
            WindowLoaded();

        }
        private void WindowLoaded()
        {
            // Look through all sensors and start the first connected one.
            // This requires that a Kinect is connected at the time of app startup.
            // To make your app robust against plug/unplug, 
            // it is recommended to use KinectSensorChooser provided in Microsoft.Kinect.Toolkit (See components in Toolkit Browser).
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    _sensor = potentialSensor;
                    break;
                }
            }

            if (null != _sensor)
            {
                // Turn on the color stream to receive color frames
                _sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);

                // Allocate space to put the pixels we'll receive
                _colorPixels = new byte[_sensor.ColorStream.FramePixelDataLength];

                // This is the bitmap we'll display on-screen
                _colorBitmap = new WriteableBitmap(_sensor.ColorStream.FrameWidth, _sensor.ColorStream.FrameHeight, 96.0, 96.0, PixelFormats.Bgr32, null);

                // Set the image we display to point to the bitmap where we'll put the image data
                Image.Source = _colorBitmap;

                // Add an event handler to be called whenever there is new color frame data
                _sensor.ColorFrameReady += SensorColorFrameReady;

                // Start the sensor!
                try
                {
                    _sensor.Start();
                }
                catch (IOException)
                {
                    _sensor = null;
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
                    colorFrame.CopyPixelDataTo(_colorPixels);

                    // Write the pixel data into our bitmap
                    _colorBitmap.WritePixels(
                        new Int32Rect(0, 0, _colorBitmap.PixelWidth, _colorBitmap.PixelHeight),
                        _colorPixels,
                        _colorBitmap.PixelWidth * sizeof(int),
                        0);
                }
            }
        }
    }
}
