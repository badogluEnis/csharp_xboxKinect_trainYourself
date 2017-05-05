using System;
using System.Configuration;
using System.Windows;
using DataAccess;
using Model;

namespace Trainyourself.Pages
{
    /// <summary>
    /// Interaction logic for HauptmenuPage.xaml
    /// </summary>
    public partial class HauptmenuPage
    {
        public HauptmenuPage()
        {
            InitializeComponent();
            SetTitel();
        }

        private void situp_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LiveviewSitups());
        }

        private void Buttonpushups_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LiveviewPushups());
        }

        private void Profilbutton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ProfilePage());
        }

        private void Logoutbutton_OnClick_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new SigninPage());
        }

        public void SetTitel()
        {
            using (TrainContext context = new TrainContext())
            {
                UserRepository userr = new UserRepository(context);

                User us = userr.GetById(Int32.Parse(ConfigurationManager.AppSettings["LoggedUserId"]));

                TitelName.Content = "Hey " + us.Name;
            }
        }
    }
}
