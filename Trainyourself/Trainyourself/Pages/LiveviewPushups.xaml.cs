using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Media;
using KinectConnection;
using Microsoft.Kinect;

namespace Trainyourself.Pages
{
    /// <summary>
    /// Interaction logic for LiveviewPushups.xaml
    /// </summary>
    public partial class LiveviewPushups
    {
        public float ShoulderLeftX;
        public float ShoulderLeftY;
        public float ShoulderRightX;
        public float ShoulderRightY;
        public float ShoulderRightZ;
        public float ShoulderLeftZ;

        private const float CRITERIUM = 0.15f;

        public float CalibrateLeftShoulderTopY;
        public float CalibrateRightShoulderTopY;
        public float CalibrateRightShoulderBottomY;
        public float CalibrateLeftShoulderBottomY;
        Calibration cal = new Calibration();

        public int counter;
        public bool WarUnten;

        private KinectProvider _kinectProvider = new KinectProvider();

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public LiveviewPushups()
        {
            InitializeComponent();
            Image.Source = _kinectProvider._colorBitmap;
            timer.Interval = 1000;
            //timer.Tick += TimerOnTick;
            timer.Start();
            _kinectProvider.PositionChanged += SkeletonChanged;

        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            Debug.WriteLine($"Right Shoulder x: {ShoulderRightX} y: {ShoulderRightY} | Left Shoulder x: {ShoulderLeftX} y: {ShoulderLeftY}");
            Debug.WriteLine($"Entfernung rechte Schulter: {ShoulderRightZ} | Entfernung linke Schulter: {ShoulderLeftZ}");
        }


        private void SkeletonChanged(object sender, Skeleton skeleton)
        {
            ShoulderLeftX = skeleton.Joints[JointType.ShoulderLeft].Position.X;
            ShoulderLeftY = skeleton.Joints[JointType.ShoulderLeft].Position.Y;
            ShoulderLeftZ = skeleton.Joints[JointType.ShoulderLeft].Position.Z;
            ShoulderRightX = skeleton.Joints[JointType.ShoulderRight].Position.X;
            ShoulderRightY = skeleton.Joints[JointType.ShoulderRight].Position.Y;
            ShoulderRightZ = skeleton.Joints[JointType.ShoulderRight].Position.Z;

            Debug.WriteLine($"Right Shoulder x: {ShoulderRightX} y: {ShoulderRightY} | Left Shoulder x: {ShoulderLeftX} y: {ShoulderLeftY}");
            Debug.WriteLine($"Entfernung rechte Schulter: {ShoulderRightZ} | Entfernung linke Schulter: {ShoulderLeftZ}");

            if (cal.IsCalibrated)
            {
                CalLabel.Visibility = Visibility.Hidden;
                CheckCount(skeleton);
                CheckUp(skeleton);
            }
            else
            {
                cal.Calibrate(skeleton);
                CalLabel.Content = "CALIBRATING";
                CalLabel.Foreground = new SolidColorBrush(Colors.Orange);
                CalLabel.Background = new SolidColorBrush(Colors.Black);
            }
        }

        private void QuitButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HauptmenuPage());
            _kinectProvider.Stop();
            timer.Stop();
        }

        public void CheckCount(Skeleton skeleton)
        {
            if (ShoulderRightY < skeleton.Joints[JointType.HandRight].Position.Y + CRITERIUM && ShoulderLeftY < skeleton.Joints[JointType.HandLeft].Position.Y + CRITERIUM && !WarUnten && skeleton.Joints[JointType.HandRight].Position.Y < ShoulderRightX && skeleton.Joints[JointType.HandLeft].Position.Y < ShoulderLeftY)
            {
                counter = counter + 1;
                Currentrun.Content = $"Current Run: {counter}";
                WarUnten = true;
                Debug.WriteLine("DOWN");
            }
        }

        public void CheckUp(Skeleton skeleton)
        {
            if (ShoulderRightY > cal.ShoulderHandDistanceRight - CRITERIUM && ShoulderLeftY > cal.ShoulderHandDistanceLeft - CRITERIUM)
            {
                WarUnten = false;
                Debug.WriteLine("UP");
            }
          
        }      
               
/*        public void CalibrateTop(Skeleton skeleton)
        {
            CalibrateLeftShoulderTopY = skeleton.Joints[JointType.ShoulderLeft].Position.Y;
            CalibrateRightShoulderTopY = skeleton.Joints[JointType.ShoulderRight].Position.Y;
        }

        public void CalibrateBottom(Skeleton skeleton)
        {
            CalibrateLeftShoulderBottomY = skeleton.Joints[JointType.ShoulderLeft].Position.Y;
            CalibrateRightShoulderBottomY = skeleton.Joints[JointType.ShoulderRight].Position.Y;
        }
*/
    }
}
