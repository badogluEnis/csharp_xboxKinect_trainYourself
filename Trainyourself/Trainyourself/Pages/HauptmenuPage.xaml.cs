using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using DataAccess;
using Model;

namespace Trainyourself.Pages
{
    /// <summary>
    /// Interaction logic for HauptmenuPage.xaml
    /// </summary>
    public partial class HauptmenuPage : Page
    {
        public HauptmenuPage()
        {
            InitializeComponent();
            SetTitel();
        }

        private void situp_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Liveview());
        }

        private void Buttonpushups_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void Profilbutton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage());
        }

        private void Logoutbutton_OnClick_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SigninPage());
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
