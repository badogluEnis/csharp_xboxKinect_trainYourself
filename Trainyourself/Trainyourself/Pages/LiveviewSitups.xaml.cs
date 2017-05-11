﻿using System.Diagnostics;
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

            Debug.WriteLine($"Right Shoulder x: {ShoulderRightX} y: {ShoulderRightY} \n Left Shoulder x: {ShoulderLeftX} y: {ShoulderLeftY}");
        }

        private void QuitButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HauptmenuPage());
            _kinectProvider.Stop();
        }

    }
}