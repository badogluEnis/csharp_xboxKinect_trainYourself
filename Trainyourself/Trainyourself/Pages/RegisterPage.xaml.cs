using System.Windows;
using System.Windows.Controls;
using DataAccess;
using Model;

namespace Trainyourself.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage
    {
        public TextBox Vornameinput1
        {
            get { return Vornameinput; }
            set { Vornameinput = value; }
        }
        public TextBox Nachnameinput1
        {
            get { return Nachnameinput; }
            set { Nachnameinput = value; }
        }
        public TextBox Email1
        {
            get { return Email; }
            set { Email = value; }
        }
        public TextBox Passwort1
        {
            get { return Passwort; }
            set { Passwort = value; }
        }
        public TextBox Passwortrep1
        {
            get { return Passwortrep; }
            set { Passwortrep = value; }
        }
        public RegisterPage()
        {
            InitializeComponent();
        }
        private bool ValidateInputfields(string input)
        {
            if (string.IsNullOrEmpty(input.Trim()))
            {
                ErrorMessage.Content = "One or more Inputfields are empty";
                return false;
            }
            return true;

        }
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
