using System;


namespace KinectConnection
{

    public class KinectNotConnectedException : Exception
    {



        /// <summary>

        /// Gets a message that describes the current exception.

        /// </summary>

        public override string Message
        {

            get
            {

                return "Sorry something went wrong with your Kinect. Probably its not connected.";

            }

        }

    }

}
