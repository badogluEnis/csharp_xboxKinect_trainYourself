using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KinectConnection;
using Microsoft.Kinect;

namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public float ShoulderLeftX;
        public float ShoulderLeftY;
        public float ShoulderRightX;
        public float ShoulderRightY;
        public float ShoulderRightZ;
        public float ShoulderLeftZ;

        private KinectProvider _kinectProvider = new KinectProvider();
        public MainWindow()
        {
            InitializeComponent();
            _kinectProvider.PositionChanged += SkeletonChanged;
        }

        private void SkeletonChanged(object sender, Skeleton skeleton)
        {
            ShoulderLeftX = skeleton.Joints[JointType.ShoulderLeft].Position.X;
            ShoulderLeftY = skeleton.Joints[JointType.ShoulderLeft].Position.Y;
            ShoulderLeftZ = skeleton.Joints[JointType.ShoulderLeft].Position.Z;
            ShoulderRightX = skeleton.Joints[JointType.ShoulderRight].Position.X;
            ShoulderRightY = skeleton.Joints[JointType.ShoulderRight].Position.Y;
            ShoulderRightZ = skeleton.Joints[JointType.ShoulderRight].Position.Z;
            
            Debug.WriteLine($"Schoulder Left:");
            Debug.WriteLine($"X: {ShoulderLeftX}");
            Debug.WriteLine($"Y: {ShoulderLeftY}");
            Debug.WriteLine($"Z: {ShoulderLeftZ}");

            Debug.WriteLine($"Schoulder Right:");
            Debug.WriteLine($"X: {ShoulderRightX}");
            Debug.WriteLine($"Y: {ShoulderRightY}");
            Debug.WriteLine($"Z: {ShoulderRightZ}");

            LabelRightX.Content = $"Right X: {ShoulderRightX}";
            LabelRightY.Content = $"Right Y: {ShoulderRightY}";
            LabelRightZ.Content = $"Right Z: {ShoulderRightZ}";

            LabelLeftX.Content = $"Left X: {ShoulderLeftX}";
            LabelLeftY.Content = $"Left Y: {ShoulderLeftY}";
            LabelLeftZ.Content = $"Left Z: {ShoulderLeftZ}";
        }
    }
}
