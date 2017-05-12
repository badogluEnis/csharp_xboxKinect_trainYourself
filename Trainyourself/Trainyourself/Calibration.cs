using Microsoft.Kinect;

namespace Trainyourself
{
    class Calibration
    {
        private const int ARRAY_LENGTH = 101;
        private const float TOLLERANCE = 0.2f;
        private const int ARRAY_LENGHT_HALF = 75;
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
            if (IsCalibrated == false)
            {
                if (i < ARRAY_LENGTH - 1)
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

            float referenceShoulderRight = ShoulderRightY[0];
            float referenceShoulderLeft = ShoulderLeftY[0];
            float referenceHandRight = HandRightY[0];
            float referenceHandLeft = HandLeftY[0];
            for (int i = 0; i < ARRAY_LENGTH; i++)
            {
                if (!(ShoulderRightY[i] < referenceShoulderRight + TOLLERANCE && ShoulderRightY[i] > referenceShoulderRight - TOLLERANCE))
                {
                    return true;
                }
                if (!(ShoulderLeftY[i] < referenceShoulderLeft + TOLLERANCE && ShoulderRightY[i] > referenceShoulderLeft - TOLLERANCE))
                {
                    return true;
                }
                if (!(HandRightY[i] < referenceHandRight + TOLLERANCE && ShoulderRightY[i] > referenceHandRight - TOLLERANCE))
                {
                    return true;
                }
                if (!(HandRightY[i] < referenceHandLeft + TOLLERANCE && ShoulderRightY[i] > referenceHandLeft - TOLLERANCE))
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
