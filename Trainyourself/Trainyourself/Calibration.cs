using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool IsNotMoving(Skeleton skeleton)
        {
            for (int i = 0; i < 400; i++)
            {
                ShoulderRightY[i] = skeleton.Joints[JointType.ShoulderRight].Position.Y;
                ShoulderLeftY[i] = skeleton.Joints[JointType.ShoulderLeft].Position.Y;
                HandRightY[i] = skeleton.Joints[JointType.HandRight].Position.Y;
                HandLeftY[i] = skeleton.Joints[JointType.HandLeft].Position.Y;
            }

            for (int i = 0; i < 400; i++)
            {
                int b = i + 1;
                if (ShoulderRightY[i] - ShoulderRightY[b] < 0.03 && ShoulderRightY[i] - ShoulderRightY[b] > -0.03)
                {
                    if (ShoulderLeftY[i] - ShoulderLeftY[b] < 0.03 && ShoulderLeftY[i] - ShoulderLeftY[b] > -0.03)
                    {
                        if (HandRightY[i] - HandRightY[b] < 0.03 && HandRightY[i] - HandRightY[b] > -0.03)
                        {
                            if (HandLeftY[i] - HandLeftY[b] < 0.03 && HandLeftY[i] - HandLeftY[b] > -0.03)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }


    }

}
