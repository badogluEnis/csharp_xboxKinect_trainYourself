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
    /// Interaction logic for MoreinformationPage.xaml
    /// </summary>
    public partial class MoreinformationPage : Page
    {
        public User User { get; set; }

        public TextBox Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public TextBox Height1
        {
            get { return height; }
            set { height = value; }
        }
        public MoreinformationPage(User user)
        {
            InitializeComponent();
            User = user;
        }

        /// <summary>
        /// Validates the double input and shows the error messages on GUI.
        /// </summary>
        /// <param name="doubleInput">The double input.</param>
        /// <returns></returns>
        private bool ValidateDoubleInput(string doubleInput)
        {
            double weight;
            double height;

            if (string.IsNullOrEmpty(doubleInput.Trim()))
            {
                moreinformationserror.Content = "Input fields can't be empty";
                return false;
            }

            bool isValidWeight = Double.TryParse(Weight.Text, out weight);
            if (!isValidWeight)
            {
                moreinformationserror.Content = "Please type your stats like this in: \"140\" (cm for Height) or \"87,23\" (kg for Wheight)";
                return false;
            }

            bool isValidHeight = Double.TryParse(Weight.Text, out height);
            if (!isValidHeight)
            {
                moreinformationserror.Content = "Please type your stats like this in: \"140\" (cm for Height) or \"87,23\" (kg for Wheight)";
                return false;
            }

            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //double weight = Convert.ToDouble(Weight.Text);
            //double height = Convert.ToDouble(Height1.Text);

           

            if (ValidateDoubleInput(Weight.Text) && ValidateDoubleInput(Height1.Text))
            {
                using (TrainContext context = new TrainContext())
                {
                    UserRepository repository = new UserRepository(context);
                    User.Weight = Convert.ToDouble(Weight.Text);
                    User.Height = Convert.ToDouble(Height1.Text);


                    repository.Update(User);
                    NavigationService.Navigate(new SigninPage());
                }

            }

            


           

        }
    }
}
