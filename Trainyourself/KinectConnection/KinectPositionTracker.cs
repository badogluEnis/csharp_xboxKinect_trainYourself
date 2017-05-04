using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Kinect;

namespace KinectConnection
{
    public class KinectProvider
    {
        private KinectSensor _sensor;
        private const int SKELETON_COUNT = 6;
        private readonly Skeleton[] _allSkeletons = new Skeleton[SKELETON_COUNT];
        private bool _isInitialized;
        public delegate void PositionChangedEventHandler(object sender, Skeleton s);
        public event PositionChangedEventHandler PositionChanged;



        /// <summary>
        /// Initializes a new instance of the <see cref="KinectPositionTracker"/> class.
        /// </summary>
        public KinectProvider()
        {
            Init();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <exception cref="KinectNotConnectedException"></exception>
        public void Init()
        {
            DiscoverSensor();

            if (_sensor == null)
            {

            }

            //Smooth parameters
            //var parameters = new TransformSmoothParameters {
            //    Smoothing = 0.3f,
            //    Correction = 0.0f,
            //    Prediction = 0.0f,
            //    JitterRadius = 1.0f,
            //    MaxDeviationRadius = 0.5f
            //};

            _sensor.SkeletonStream.Enable(); // optional smooth parameters could be passed
            _sensor.ColorStream.Enable();
            _sensor.AllFramesReady += KinectAllFramesReady;
            _sensor.Start();
        }

        public void Stop()
        {
            _sensor.Stop();
        }


        /// <summary>
        /// Discovers the kinect sensor.
        /// </summary>
        private void DiscoverSensor()
        {
            // Find first sensor that is connected.
            foreach (KinectSensor sensor in KinectSensor.KinectSensors)
            {
                if (sensor.Status == KinectStatus.Connected)
                {
                    _sensor = sensor;
                    break;
                }
            }
        }

        /// <summary>
        /// Kinects all frames ready event listener.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="AllFramesReadyEventArgs"/> instance containing the event data.</param>
        private void KinectAllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            Skeleton skeleton = GetFirstSkeleton(e);



            if (skeleton == null)
            {
                return;
            }

            if (!_isInitialized)
            {
                _isInitialized = true;
                // Here you can add start reference points
            }


            PositionChanged?.Invoke(this, skeleton);
        }



        /// <summary>
        /// Gets the first skeleton detected by the Kinect.
        /// </summary>
        /// <param name="e">The <see cref="AllFramesReadyEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        private Skeleton GetFirstSkeleton(AllFramesReadyEventArgs e)
        {
            using (SkeletonFrame skeletonFrameData = e.OpenSkeletonFrame())
            {
                if (skeletonFrameData == null)
                {
                    return null;
                }

                skeletonFrameData.CopySkeletonDataTo(_allSkeletons);
                Skeleton first = _allSkeletons.FirstOrDefault(s => s.TrackingState == SkeletonTrackingState.Tracked);


                return first;
            }
        }
    }
}

