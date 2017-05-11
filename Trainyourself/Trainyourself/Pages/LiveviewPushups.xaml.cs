using System;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Forms;
using KinectConnection;
using Microsoft.Kinect;
using Timer = System.Timers.Timer;

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

        private KinectProvider _kinectProvider = new KinectProvider();

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public LiveviewPushups()
        {
            InitializeComponent();
            Image.Source = _kinectProvider._colorBitmap;
            timer.Interval = 5000;
            timer.Start();
            timer.Tick += TimerOnTick;
            _kinectProvider.PositionChanged += SkeletonChanged;
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            Debug.WriteLine($"Right Shoulder x: {ShoulderRightX} y: {ShoulderRightY} | Left Shoulder x: {ShoulderLeftX} y: {ShoulderLeftY}");
        }


        private void SkeletonChanged(object sender, Skeleton skeleton)
        {
            ShoulderLeftX = skeleton.Joints[JointType.ShoulderLeft].Position.X;
            ShoulderLeftY = skeleton.Joints[JointType.ShoulderLeft].Position.Y;
            ShoulderRightX = skeleton.Joints[JointType.ShoulderRight].Position.X;
            ShoulderRightY = skeleton.Joints[JointType.ShoulderRight].Position.Y;

        }

        private void QuitButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HauptmenuPage());
            _kinectProvider.Stop();
            timer.Stop();
        }
    }
}
