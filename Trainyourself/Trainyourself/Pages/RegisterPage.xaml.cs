using System.Windows;
using System.Windows.Controls;
using DataAccess;
using Model;

namespace Trainyourself.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Page" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class RegisterPage
    {
        /// <summary>
        /// Gets or sets the vornameinput1.
        /// </summary>
        /// <value>
        /// The vornameinput1.
        /// </value>
        public TextBox Vornameinput1
        {
            get { return Vornameinput; }
            set { Vornameinput = value; }
        }
        /// <summary>
        /// Gets or sets the nachnameinput1.
        /// </summary>
        /// <value>
        /// The nachnameinput1.
        /// </value>
        public TextBox Nachnameinput1
        {
            get { return Nachnameinput; }
            set { Nachnameinput = value; }
        }
        /// <summary>
        /// Gets or sets the email1.
        /// </summary>
        /// <value>
        /// The email1.
        /// </value>
        public TextBox Email1
        {
            get { return Email; }
            set { Email = value; }
        }
        /// <summary>
        /// Gets or sets the passwort1.
        /// </summary>
        /// <value>
        /// The passwort1.
        /// </value>
        public TextBox Passwort1
        {
            get { return Passwort; }
            set { Passwort = value; }
        }
        /// <summary>
        /// Gets or sets the passwortrep1.
        /// </summary>
        /// <value>
        /// The passwortrep1.
        /// </value>
        public TextBox Passwortrep1
        {
            get { return Passwortrep; }
            set { Passwortrep = value; }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterPage"/> class.
        /// </summary>
        public RegisterPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Validates the inputfields if the are empty or null.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        private bool ValidateInputfields(string input)
        {
            if (string.IsNullOrEmpty(input.Trim()))
            {
                ErrorMessage.Content = "One or more Inputfields are empty";
                return false;
            }
            return true;

        }
        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = Vornameinput1.Text;
            string lastname = Nachnameinput1.Text;
            string email = Email1.Text;
            string password = Passwort1.Text;
            User user;
            using (TrainContext context = new TrainContext())
            {
                if (ValidateInputfields(Vornameinput1.Text) && ValidateInputfields(Nachnameinput1.Text) && ValidateInputfields(Passwort1.Text) && ValidateInputfields(Passwortrep1.Text))
                {
                    if (Passwortrep1.Text == Passwort1.Text)
                    {
                        UserRepository repository = new UserRepository(context);
                        user = new User
                        {
                            Name = name,
                            Lastname = lastname,
                            Email = email,
                            Password = password
                        };
                        repository.Add(user);
                        if (NavigationService != null) NavigationService.Navigate(new MoreinformationPage(user));
                    }
                    else
                    {
                        ErrorMessage.Content = "Passwords are not the same ones";
                    }
                }
                else
                {
                    ErrorMessage.Content = "One or more Inputfields are empty";
                }
            }
        }
    }
}
