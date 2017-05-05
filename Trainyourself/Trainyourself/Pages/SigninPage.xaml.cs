using System.Configuration;
using System.Windows;
using System.Windows.Media;
using DataAccess;
using Model;

namespace Trainyourself.Pages
{
    /// <summary>
    /// Interaction logic for SigninPage.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Page" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class SigninPage 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SigninPage"/> class.
        /// </summary>
        public SigninPage()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Handles the OnClick event of the SignIn control and shows the error.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SignIn_OnClick(object sender, RoutedEventArgs e)
        {
            using (TrainContext context = new TrainContext())
            { 
                UserRepository ur = new UserRepository(context);

                if (string.IsNullOrEmpty(Emailsignin.Text) || string.IsNullOrEmpty(Passwordsignin.Password)) 
                {
                    Signinerror.Content = "Fields cant't be empty";
                }
                else
                {
                    if (ur.CheckLogin(Emailsignin.Text, Passwordsignin.Password))
                    {
                        int userId = ur.GetUserIdByMail(Emailsignin.Text);

                        ConfigurationManager.AppSettings["LoggedUserId"] = userId.ToString();
                      
                        Signinerror.Content = "Login erfolgreich";
                        Signinerror.Foreground = Brushes.Green;
                        NavigationService?.Navigate(new HauptmenuPage());
                    }
                    else
                    {
                        Signinerror.Content = "Password or Email false.";
                    }
                }
            }
          
        }
        /// <summary>
        /// Handles the OnClick event of the NotRegistered control and navigate to the register page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void NotRegistered_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(new RegisterPage());
        }

        private void QuitButton_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
