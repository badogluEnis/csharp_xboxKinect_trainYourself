using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows;
using DataAccess;
using KinectConnection;
using Microsoft.Kinect;
using Model;

namespace Trainyourself.Pages
{
    /// <summary>
    /// Interaction logic for Liveview.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Page" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class LiveviewSitups
    {
        /// <summary>
        /// The shoulder left x
        /// </summary>
        private float ShoulderLeftX;
        /// <summary>
        /// The shoulder left y
        /// </summary>
        private float ShoulderLeftY;
        /// <summary>
        /// The shoulder right x
        /// </summary>
        private float ShoulderRightX;
        /// <summary>
        /// The shoulder right y
        /// </summary>
        private float ShoulderRightY;

        /// <summary>
        /// The counter
        /// </summary>
        public int counter;
        /// <summary>
        /// The war unten
        /// </summary>
        private bool WarUnten;

        /// <summary>
        /// The cal
        /// </summary>
        private Calibration cal = new Calibration();

        /// <summary>
        /// The kinect provider
        /// </summary>
        private KinectProvider _kinectProvider = new KinectProvider();

        /// <summary>
        /// Initializes a new instance of the <see cref="LiveviewSitups"/> class.
        /// </summary>
        public LiveviewSitups()
        {
            InitializeComponent();
            Image.Source = _kinectProvider._colorBitmap;
            _kinectProvider.PositionChanged += SkeletonChanged;
            SetHighscore();
        }

        /// <summary>
        /// Skeletons the changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="skeleton">The skeleton.</param>
        private void SkeletonChanged(object sender, Skeleton skeleton)
        {
            float ShoulderLeftX = skeleton.Joints[JointType.ShoulderLeft].Position.X;
            float ShoulderLeftY = skeleton.Joints[JointType.ShoulderLeft].Position.Y;
            float ShoulderRightX = skeleton.Joints[JointType.ShoulderRight].Position.X;
            float ShoulderRightY = skeleton.Joints[JointType.ShoulderRight].Position.Y;

            Debug.WriteLine($"Right: {ShoulderRightY}");
            Debug.WriteLine($"Left: {ShoulderLeftY}");

            CheckIfDown();
            CheckIfUp();
        }

        /// <summary>
        /// Handles the OnClick event of the QuitButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void QuitButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(new HauptmenuPage());
            _kinectProvider.Dispose();

            Score score = new Score();
            using (TrainContext context = new TrainContext())
            {
                UserRepository userRepository = new UserRepository(context);
                score.UserID = userRepository.GetById(Int32.Parse(ConfigurationManager.AppSettings["LoggedUserId"])).Id;
                score.Date = DateTime.Now.Date;
                score.Exercise_Id = 2;
                score.Score1 = counter;
                context.Scores.Add(score);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Checks if up.
        /// </summary>
        private void CheckIfUp()
        {
            if (ShoulderRightY > 0.50)
            {
                WarUnten = false;
                Debug.WriteLine("UP");
            }
        }

        /// <summary>
        /// Checks if down.
        /// </summary>
        private void CheckIfDown()
        {
            if (ShoulderRightY < 0.40)
            {
                counter += 1;

                Currentrun.Content = Currentrun.Content = $"Current Run: {counter}";

                using (TrainContext context = new TrainContext())
                {
                    UserRepository userRepository = new UserRepository(context);
                    User user = userRepository.GetById(Int32.Parse(ConfigurationManager.AppSettings["LoggedUserId"]));
                    if (user.RecordSitups == null)
                    {
                        user.RecordSitups = counter;
                        Record.Content = $"Record: {user.RecordSitups}";
                    }
                    if (counter > user.RecordSitups)
                    {
                        user.RecordSitups = counter;
                        Record.Content = $"Record: {user.RecordSitups}";
                    }

                }
                WarUnten = true;
                Debug.WriteLine("Down");
            }

        }

        /// <summary>
        /// Sets the highscore.
        /// </summary>
        public void SetHighscore()
        {
            using (TrainContext context = new TrainContext())
            {
                UserRepository userRepository = new UserRepository(context);
                User user = userRepository.GetById(Int32.Parse(ConfigurationManager.AppSettings["LoggedUserId"]));
                Record.Content = $"Record: {user.RecordSitups}" ;
            }

        }

    }

}