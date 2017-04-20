using System;
using System.Collections.Generic;
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
using DataAccess;
using Model;

namespace Trainyourself.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            string name = Vornameinput1.Text;
            string lastname = Nachnameinput1.Text;
            string email = Email1.Text;
            string password = Passwort1.Text;

      
            using (TrainContext context = new TrainContext())
            {
               UserRepository  repository = new UserRepository(context);
                User user = new User
                {
                    Name = name,
                    Lastname = lastname,
                    Email = email,
                    Password = password
                };

               
                repository.Add(user);
            }
            



            NavigationService.Navigate(new MoreinformationPage());

        }
    }
}
