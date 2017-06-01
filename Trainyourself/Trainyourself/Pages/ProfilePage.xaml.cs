using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using DataAccess;
using Model;

namespace Trainyourself.Pages
{
    /// <summary>
    /// Logic for ProfilePage.xaml. Get many Values from the Database and sets the text of inputfields.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Page" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class ProfilePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilePage"/> class.
        /// </summary>
        public ProfilePage()
        {
            InitializeComponent();
            Setemptylabels();
        }

        /// <summary>
        /// Setemptylabelses gets Values from Database.
        /// </summary>
        public void Setemptylabels()
        {
            using (TrainContext context = new TrainContext())
            {
                UserRepository userRepository = new UserRepository(context);
                User us = userRepository.GetById(Int16.Parse(ConfigurationManager.AppSettings["LoggedUserId"]));
                Name.Text = us.Name + " " + us.Lastname;
                YourHeightLabel.Text = Convert.ToString(us.Height);
                YourHeightLabel.FontSize = 23;
                YourWeightLabel.Text = Convert.ToString(us.Weight);
                YourWeightLabel.FontSize = 23;
                double bmi = double.Parse(us.Weight.ToString()) / (double.Parse(us.Height.ToString()) * double.Parse(us.Height.ToString()));
                double round = Math.Round(bmi, 2);
                BMIOutput.Text = Convert.ToString(round, CultureInfo.InvariantCulture);
                BMIOutput.FontSize = 23;
                RecordPushups.Text = us.RecordPushups.ToString();
                RecordSitUps.Text = us.RecordSitups.ToString();
                AveragePushUps.Text = userRepository.GetAVGForPushUps(Int16.Parse(ConfigurationManager.AppSettings["LoggedUserId"])).Average().ToString(CultureInfo.InvariantCulture);
                AverageSitUps.Text =  userRepository.GetAVGForSitUps(Int16.Parse(ConfigurationManager.AppSettings["LoggedUserId"])).Average().ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Handles the OnClick event of the Backbutton control Navigate to Hauptmenu.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Backbutton_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(new HauptmenuPage());
        }

        /// <summary>
        /// Handles the OnClick event of the YourHeightEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void YourHeightEdit_OnClick(object sender, RoutedEventArgs e)
        {
            YourHeightLabel.IsReadOnly = false;
            YourHeightLabel.BorderBrush = Brushes.Blue;
        }

        /// <summary>
        /// Handles the OnClicknClick event of the YourWeightEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void YourWeightEdit_OnClicknClick(object sender, RoutedEventArgs e)
        {
            YourWeightLabel.IsReadOnly = false;
            YourWeightLabel.BorderBrush = Brushes.Blue;
        }

        /// <summary>
        /// Handles the OnClick event of the SavebuttonHeight control Check if the new Values are Valid and then Updates the User.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SavebuttonHeight_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(YourHeightLabel.Text.Trim()))
            {
                errorHeight.Content = "Field can't be empty";
            }
            else
            {
                if (YourHeightLabel.Text.Contains(","))
                {
                    var replace = YourHeightLabel.Text.Replace(",", ".");
                    YourHeightLabel.Text = replace;
                }
                double height1;
                bool isValidHeight = double.TryParse(YourHeightLabel.Text, out height1);

                if (!isValidHeight)
                {
                    errorHeight.Content = "Use only nummbers";
                }
                else
                {
                    using (TrainContext context = new TrainContext())
                    {

                        UserRepository userRepository = new UserRepository(context);
                        User us = userRepository.GetById(Int16.Parse(ConfigurationManager.AppSettings["LoggedUserId"]));

                        {
                            us.Height = Convert.ToDouble(YourHeightLabel.Text);
                            userRepository.Update(us);

                            double bmi = double.Parse(us.Weight.ToString()) /
                                         (double.Parse(us.Height.ToString()) * double.Parse(us.Height.ToString()));
                            double round = Math.Round(bmi, 2);
                            BMIOutput.Text = round.ToString(CultureInfo.InvariantCulture);
                            BMIOutput.FontSize = 23;
                            YourHeightLabel.IsReadOnly = true;
                            YourHeightLabel.BorderBrush = Brushes.ForestGreen;

                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the OnClick event of the SavebuttonWeight_OnClickttonWeight control Check if the new Values are Valid and then Updates the User.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SavebuttonWeight_OnClickttonWeight_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(YourWeightLabel.Text.Trim()))
            {
                errorWeight.Content = "Field can't be empty";
            }
            else
            {
                if (YourWeightLabel.Text.Contains(","))
                {
                    var replace = YourWeightLabel.Text.Replace(",", ".");
                    YourWeightLabel.Text = replace;
                }
                double weight1;
                bool isValidWeight = double.TryParse(YourWeightLabel.Text, out weight1);

                if (!isValidWeight)
                {
                    errorWeight.Content = "Use only numbers";
                }
                else
                {
                    using (TrainContext context = new TrainContext())
                    {
                        UserRepository userRepository = new UserRepository(context);
                        User us = userRepository.GetById(Int16.Parse(ConfigurationManager.AppSettings["LoggedUserId"]));

                        if (us != null)
                        {
                            us.Weight = Convert.ToDouble(YourWeightLabel.Text);
                            userRepository.Update(us);
                            double bmi = double.Parse(us.Weight.ToString()) / (double.Parse(us.Height.ToString()) * double.Parse(us.Height.ToString()));
                            double round = Math.Round(bmi, 2);
                            BMIOutput.Text = Convert.ToString(round, CultureInfo.InvariantCulture);
                            BMIOutput.FontSize = 23;
                        }
                    }
                    YourWeightLabel.IsReadOnly = true;
                    YourWeightLabel.BorderBrush = Brushes.ForestGreen;

                }
            }
        }

        /// <summary>
        /// Handles the Click event of the Button control Navigate to Hauptmenupage.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(new HauptmenuPage());
        }

        /// <summary>
        /// Handles the OnClick event of the Pushupsbutton control Navigate to Highscore Table of Pushups.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Pushupsbutton_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(new Highscore());
        }

        /// <summary>
        /// Handles the OnClick event of the Situpsbutton_OnClicksbutton control Navigate to Highscore Table of Situps.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Situpsbutton_OnClicksbutton_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(new HighScoreTableSitUpsPage());
        }
    }
}
