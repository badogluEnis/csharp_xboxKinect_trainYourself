using System.Diagnostics;
using System.Windows;
using KinectConnection;
using Microsoft.Kinect;

namespace Trainyourself.Pages
{
    /// <summary>
    /// Interaction logic for Liveview.xaml
    /// </summary>
    public partial class LiveviewSitups
    {
        private float ShoulderLeftX;
        private float ShoulderLeftY;
        private float ShoulderRightX;
        private float ShoulderRightY;

        private bool WarUnten;

        private Calibration cal =  new Calibration();

        private KinectProvider _kinectProvider = new KinectProvider();

        public LiveviewSitups()
        {
            InitializeComponent();
            Image.Source = _kinectProvider._colorBitmap;
           _kinectProvider.PositionChanged += SkeletonChanged;
        }

        private void SkeletonChanged(object sender, Skeleton skeleton)
        {
            float ShoulderLeftX = skeleton.Joints[JointType.ShoulderLeft].Position.X;
            float ShoulderLeftY = skeleton.Joints[JointType.ShoulderLeft].Position.Y;
            float ShoulderRightX = skeleton.Joints[JointType.ShoulderRight].Position.X;
            float ShoulderRightY = skeleton.Joints[JointType.ShoulderRight].Position.Y;


        }

        private void QuitButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HauptmenuPage());
            _kinectProvider.Stop();
        }

        private void CheckIfUp()
        {
            
        }

        private void CheckIfDown()
        {
            
        }

    }
}