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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
