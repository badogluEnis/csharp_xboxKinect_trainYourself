using System;
using System.Configuration;
using System.Windows;
using DataAccess;
using Model;

namespace Trainyourself.Pages
{
    /// <summary>
    /// Logic for Hauptmenupage.xaml.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Page" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class HauptmenuPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HauptmenuPage"/> class.
        /// </summary>
        public HauptmenuPage()
        {
            InitializeComponent();
            SetTitel();
        }

        /// <summary>
        /// Handles the OnClick event of the situp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void situp_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LiveviewSitups());
        }

        /// <summary>
        /// Handles the OnClick event of the Buttonpushups control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Buttonpushups_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LiveviewPushups());
        }

        /// <summary>
        /// Handles the OnClick event of the Profilbutton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Profilbutton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ProfilePage());
        }

        /// <summary>
        /// Handles the OnClick event of the Logoutbutton_OnClick control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Logoutbutton_OnClick_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new SigninPage());
        }

        /// <summary>
        /// Sets the titel.
        /// </summary>
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
