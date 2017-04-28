using System;
using System.Configuration;
using System.Windows;
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

               User us =  userRepository.GetById(Int16.Parse(ConfigurationManager.AppSettings["LoggedUserId"]));
               
               Name.Text = us.Name + " "+ us.Lastname;
               YourHeightLabel.Content = us.Height;
               YourHeightLabel.FontSize = 23;
               YourWeightLabel.Content = us.Weight;
               YourWeightLabel.FontSize  = 23;
               float bmi =  float.Parse(us.Weight.ToString()) / (float.Parse(us.Height.ToString()) * float.Parse(us.Height.ToString())) ;
               BMIOutput.Content = bmi;
               BMIOutput.FontSize = 23;

            }
        }

        private void Backbutton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HauptmenuPage());
        }
    }
}
