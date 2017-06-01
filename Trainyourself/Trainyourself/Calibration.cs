using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Kinect;
using Trainyourself.Pages;

namespace Trainyourself
{
    /// <summary>
    /// Calibrates the User and gets the Lenght from Shoulder to Hand.
    /// </summary>
    class Calibration
    {private const int ARRAY_LENGTH = 101;
        /// <summary>
        /// The tollerance
        /// </summary>
        private const float TOLLERANCE = 0.4f;
        /// <summary>
        /// The array lenght half
        /// </summary>
        private const int ARRAY_LENGHT_HALF = 50;
        /// <summary>
        /// The shoulder right y
        /// </summary>
        private float[] ShoulderRightY = new float[ARRAY_LENGTH];
        /// <summary>
        /// The shoulder left y
        /// </summary>
        private float[] ShoulderLeftY = new float[ARRAY_LENGTH];
        /// <summary>
        /// The hand right y
        /// </summary>
        private float[] HandRightY = new float[ARRAY_LENGTH];
        /// <summary>
        /// The hand left y
        /// </summary>
        private float[] HandLeftY = new float[ARRAY_LENGTH];
        /// <summary>
        /// The i
        /// </summary>
        private int i;

        /// <summary>
        /// Gets the shoulder hand distance right.
        /// </summary>
        /// <value>
        /// The shoulder hand distance right.
        /// </value>
        public float ShoulderHandDistanceRight { get; private set; }
        /// <summary>
        /// Gets the shoulder hand distance left.
        /// </summary>
        /// <value>
        /// The shoulder hand distance left.
        /// </value>
        public float ShoulderHandDistanceLeft { get; private set; }
        /// <summary>
        /// Gets a value indicating whether this instance is calibrated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is calibrated; otherwise, <c>false</c>.
        /// </value>
        public bool IsCalibrated { get; private set; }



        /// <summary>
        /// Calibrates the specified skeleton.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
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

        /// <summary>
        /// Calculates the shoulder hand distance.
        /// </summary>
        private void CalculateShoulderHandDistance()
        {
            ShoulderHandDistanceRight = ShoulderRightY[ARRAY_LENGHT_HALF] - HandRightY[ARRAY_LENGHT_HALF] - 0.05f;
            ShoulderHandDistanceLeft = ShoulderLeftY[ARRAY_LENGHT_HALF] - HandLeftY[ARRAY_LENGHT_HALF] - 0.05f;
        }

        /// <summary>
        /// Checks the arrays for moves.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Fills the array.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        private void FillArray(Skeleton skeleton)
        {
                ShoulderRightY[i] = skeleton.Joints[JointType.ShoulderRight].Position.Y;
                ShoulderLeftY[i] = skeleton.Joints[JointType.ShoulderLeft].Position.Y;
                HandRightY[i] = skeleton.Joints[JointType.HandRight].Position.Y;
                HandLeftY[i] = skeleton.Joints[JointType.HandLeft].Position.Y;
                i++;
        }

        /// <summary>
        /// Clears the array.
        /// </summary>
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
