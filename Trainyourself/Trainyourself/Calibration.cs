using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Kinect;
using Trainyourself.Pages;

namespace Trainyourself
{
    class Calibration
    {private const int ARRAY_LENGTH = 101;
        private const float TOLLERANCE = 0.4f;
        private const int ARRAY_LENGHT_HALF = 50;
        private float[] ShoulderRightY = new float[ARRAY_LENGTH];
        private float[] ShoulderLeftY = new float[ARRAY_LENGTH];
        private float[] HandRightY = new float[ARRAY_LENGTH];
        private float[] HandLeftY = new float[ARRAY_LENGTH];
        private int i;

        public float ShoulderHandDistanceRight { get; private set; }
        public float ShoulderHandDistanceLeft { get; private set; }
        public bool IsCalibrated { get; private set; }

        

        public void Calibrate(Skeleton skeleton)
        {
            if (!IsCalibrated)
            {
                if (i < ARRAY_LENGTH)
                {
                    FillArray(skeleton);
                }
                else
                {
                    if (CheckArraysForMoves() != true)
                    {
                        CalculateShoulderHandDistance();
                        IsCalibrated = true;
                    }

                    ClearArray();
                }
            }
            
        }

        private void CalculateShoulderHandDistance()
        {
            ShoulderHandDistanceRight = ShoulderRightY[ARRAY_LENGHT_HALF] - HandRightY[ARRAY_LENGHT_HALF];
            ShoulderHandDistanceLeft = ShoulderLeftY[ARRAY_LENGHT_HALF] - HandLeftY[ARRAY_LENGHT_HALF];
        }

        private bool CheckArraysForMoves()
        {

            float referenceShoulderRight = ShoulderRightY[ARRAY_LENGHT_HALF];
            float referenceShoulderLeft = ShoulderLeftY[ARRAY_LENGHT_HALF];
            float referenceHandRight = HandRightY[ARRAY_LENGHT_HALF];
            float referenceHandLeft = HandLeftY[ARRAY_LENGHT_HALF];
            for (int j = 0; j < ARRAY_LENGTH; j++)
            {
                if (!(ShoulderRightY[j] < referenceShoulderRight + TOLLERANCE && ShoulderRightY[j] > referenceShoulderRight - TOLLERANCE))
                {
                    return true;
                }
                if (!(ShoulderLeftY[j] < referenceShoulderLeft + TOLLERANCE && ShoulderRightY[j] > referenceShoulderLeft - TOLLERANCE))
                {
                    return true;
                }
                if (!(HandRightY[j] < referenceHandRight + TOLLERANCE && ShoulderRightY[j] > referenceHandRight - TOLLERANCE))
                {
                    return true;
                }
                if (!(HandRightY[j] < referenceHandLeft + TOLLERANCE && ShoulderRightY[j] > referenceHandLeft - TOLLERANCE))
                {
                    return true;
                }
            }
            return false;
        }

        private void FillArray(Skeleton skeleton)
        {
                ShoulderRightY[i] = skeleton.Joints[JointType.ShoulderRight].Position.Y;
                ShoulderLeftY[i] = skeleton.Joints[JointType.ShoulderLeft].Position.Y;
                HandRightY[i] = skeleton.Joints[JointType.HandRight].Position.Y;
                HandLeftY[i] = skeleton.Joints[JointType.HandLeft].Position.Y;
                i++;
        }

        private void ClearArray()
        {
            ShoulderRightY = new float[ARRAY_LENGTH];
            ShoulderLeftY = new float[ARRAY_LENGTH];
            HandRightY = new float[ARRAY_LENGTH];
            HandLeftY = new float[ARRAY_LENGTH];
            i = 0;
        }
    }
}
