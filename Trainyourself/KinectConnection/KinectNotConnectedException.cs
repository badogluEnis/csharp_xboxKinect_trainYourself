using System;


namespace KinectConnection
{

    /// <summary>
    /// This is a Exception Class. It will be thrown when the Connection to the Kineckt is faild.
    /// </summary>
    /// <seealso cref="System.Exception" />
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
