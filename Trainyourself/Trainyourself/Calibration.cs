using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using Microsoft.Kinect;
using KinectConnection;

namespace Trainyourself
{
    class Calibration
    {
        private float[] ShoulderRightY = new float[401];
        private float[] ShoulderLeftY = new float[401];
        private float[] HandRightY = new float[401];
        private float[] HandLeftY = new float[401];
        private int i;
        private int j;
        public bool IsNotMoving(Skeleton skeleton)
        {
            int b = j + 1;
            if (ShoulderRightY[j] - ShoulderRightY[b] < 0.03 && ShoulderRightY[i] - ShoulderRightY[b] > -0.03)
            {
                if (ShoulderLeftY[j] - ShoulderLeftY[b] < 0.03 && ShoulderLeftY[i] - ShoulderLeftY[b] > -0.03)
                {
                    if (HandRightY[j] - HandRightY[b] < 0.03 && HandRightY[i] - HandRightY[b] > -0.03)
                    {
                        if (HandLeftY[j] - HandLeftY[b] < 0.03 && HandLeftY[i] - HandLeftY[b] > -0.03)
                        {
                            j++;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void FillArray(Skeleton skeleton)
        {
            if (i < 400)
            {
                ShoulderRightY[i] = skeleton.Joints[JointType.ShoulderRight].Position.Y;
                ShoulderLeftY[i] = skeleton.Joints[JointType.ShoulderLeft].Position.Y;
                HandRightY[i] = skeleton.Joints[JointType.HandRight].Position.Y;
                HandLeftY[i] = skeleton.Joints[JointType.HandLeft].Position.Y;
                i++;
            }
        }
    }
}
