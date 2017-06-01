using System;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using DataAccess;
using Model;

namespace Trainyourself.Pages
{
    /// <summary>
    /// Logic for RegisterPage.xaml. Validate Inputfields. Create User in Database.
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
        public PasswordBox Passwort1
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
        public PasswordBox Passwortrep1
        {
            get { return Passwortrep; }
            set { Passwortrep = value; }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterPage" /> class.
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
        /// Determines whether the email is valid.
        /// </summary>
        /// <param name="emailaddress">The emailaddress.</param>
        /// <returns>
        ///   <c>true</c> if [is email valid] [the specified emailaddress]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsEmailValid(string emailaddress)
        {
            try
            {
                new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException )
            {
                return false;
            }
        }


        /// <summary>
        /// Handles the Click event of the Button control if every input is Valid then it creates an user. 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = Vornameinput1.Text;
            string lastname = Nachnameinput1.Text;
            string email = Email1.Text;
            string password = Passwort1.Password;
            using (TrainContext context = new TrainContext())
            {
                if (ValidateInputfields(Vornameinput1.Text) && ValidateInputfields(Nachnameinput1.Text) && ValidateInputfields(Passwort1.Password) && ValidateInputfields(Passwortrep1.Password))
                {
                    if (Passwortrep1.Password == Passwort1.Password)
                    {
                        UserRepository repository = new UserRepository(context);
                        if (repository.CheckIfEmailexist(Email1.Text))
                        {
                            ErrorMessage.Content = "This E-Mail already exists. Take another";
                        }
                        else
                        {
                            if (IsEmailValid(Email1.Text))
                            {
                                var user = new User
                                {
                                    Name = name,
                                    Lastname = lastname,
                                    Email = email,
                                    Password = password,
                                    RecordPushups = 0,
                                    RecordSitups =  0
                                };
                                repository.Add(user);
                                NavigationService?.Navigate(new MoreinformationPage(user));
                            }
                            else
                            {
                                ErrorMessage.Content = "This isn't an Email adress";
                            }
                        }
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

        /// <summary>
        /// Handles the OnClick event of the QuitButton control Navigate to Sign in Page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void QuitButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null) NavigationService.Navigate(new SigninPage());
        }
    }
}
