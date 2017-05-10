using System;
using System.Configuration;
using System.Windows;
using System.Windows.Media;
using DataAccess;
using Model;

namespace Trainyourself.Pages
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage
    {
        public ProfilePage()
        {
            InitializeComponent();
            Setemptylabels();
        }

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
                double Round = Math.Round(bmi, 2);
                BMIOutput.Text = Convert.ToString(Round);
                BMIOutput.FontSize = 23;

            }
        }

        private void Backbutton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HauptmenuPage());
        }

        private void YourHeightEdit_OnClick(object sender, RoutedEventArgs e)
        {
            YourHeightLabel.IsReadOnly = false;
            YourHeightLabel.BorderBrush = Brushes.Blue;
        }

        private void YourWeightEdit_OnClicknClick(object sender, RoutedEventArgs e)
        {
            YourWeightLabel.IsReadOnly = false;
            YourWeightLabel.BorderBrush = Brushes.Blue;
        }

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
                            double Round = Math.Round(bmi, 2);
                            BMIOutput.Text = Convert.ToString(Round);
                            BMIOutput.FontSize = 23;
                            YourHeightLabel.IsReadOnly = true;
                            YourHeightLabel.BorderBrush = Brushes.ForestGreen;

                        }
                    }
                }
            }
        }

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
                            double Round = Math.Round(bmi, 2);
                            BMIOutput.Text = Convert.ToString(Round);
                            BMIOutput.FontSize = 23;
                        }
                    }
                    YourWeightLabel.IsReadOnly = true;
                    YourWeightLabel.BorderBrush = Brushes.ForestGreen;

                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(new HauptmenuPage());
        }
    }
}
