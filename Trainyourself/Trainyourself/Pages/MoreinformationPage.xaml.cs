using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using DataAccess;
using Model;

namespace Trainyourself.Pages
{
    /// <summary>
    /// Interaction logic for MoreinformationPage.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Page" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class MoreinformationPage
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the weight from the textbox.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public TextBox Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        /// <summary>
        /// Gets or sets the height1 from the textbox.
        /// </summary>
        /// <value>
        /// The height1.
        /// </value>
        public TextBox Height1
        {
            get { return height; }
            set { height = value; }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MoreinformationPage"/> class.
        /// </summary>
        /// <param name="user">The user.</param>
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

            double weight1;
            double height1;

            if (string.IsNullOrEmpty(doubleInput.Trim()))
            {
                moreinformationserror.Content = "Input fields can't be empty";
                return false;
            }

            bool isValidWeight = Double.TryParse(Weight.Text, out weight1);
            if (!isValidWeight)
            {
                moreinformationserror.Content = "Please type your stats like this in: \"140\" (cm for Height) or \"87.23\" (kg for Wheight)";
                return false;
            }

            bool isValidHeight = Double.TryParse(Weight.Text, out height1);
            if (!isValidHeight)
            {
                moreinformationserror.Content = "Please type your stats like this in: \"140\" (cm for Height) or \"87.23\" (kg for Wheight)";
                return false;
            }

            string weight2 = Convert.ToString(weight1);
            string height2 = Convert.ToString(height1);

            
            return true;
        }

        public bool ContainsComma(string String)
        {
            return String.Contains(",");
        }

        /// <summary>
        /// Handles the Click event of the Button control and updates the weight and height in the database.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //double weight = Convert.ToDouble(Weight.Text);
            //double height = Convert.ToDouble(Height1.Text);

           

            if (ValidateDoubleInput(Weight.Text) && ValidateDoubleInput(Height1.Text))
            {
                using (TrainContext context = new TrainContext())
                {
                    

                    if (!ContainsComma(Weight.Text) && !ContainsComma(Height1.Text))
                    {
                        UserRepository repository = new UserRepository(context);
                        User.Weight = Convert.ToDouble(Weight.Text);
                        User.Height = Convert.ToDouble(Height1.Text);
                        repository.Update(User);
                        if (NavigationService != null) NavigationService.Navigate(new SigninPage());
                    }

                    else
                    {
                        moreinformationserror.Content = "Use a point(.) instead of a comma(,)";
                    }

                   
                }

            }

        }
    }
}
