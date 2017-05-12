using System;
using System.Diagnostics;
using System.Windows;
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

        public float CalibrateLeftShoulderTopY;
        public float CalibrateRightShoulderTopY;
        public float CalibrateRightShoulderBottomY;
        public float CalibrateLeftShoulderBottomY;
        Calibration cal = new Calibration();

        public int counter;
        public bool WarUnten = false;

        private KinectProvider _kinectProvider = new KinectProvider();

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public LiveviewPushups()
        {
            InitializeComponent();
            Image.Source = _kinectProvider._colorBitmap;
            timer.Interval = 3000;
            timer.Start();
            timer.Tick += TimerOnTick;
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

            cal.Calibrate(skeleton);

           

            CheckCount();
            CheckUp();
        }

        private void QuitButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HauptmenuPage());
            _kinectProvider.Stop();
            timer.Stop();
        }

        public void CheckCount()
        {
            if (ShoulderRightY < 0.3 && ShoulderLeftY < 0.3 && !WarUnten)
            {
                Debug.WriteLine("Peer");
                counter = counter + 1;
                Currentrun.Content = $"Current Run: {counter}";
                WarUnten = true;
            }
        }

        public void CheckUp()
        {
            Debug.WriteLine("Meer");
            if (ShoulderRightY > 0.4 && ShoulderLeftY > 0.4)
            {
                WarUnten = false;
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
