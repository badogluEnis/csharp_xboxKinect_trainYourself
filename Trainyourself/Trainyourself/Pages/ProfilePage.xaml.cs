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
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        public string name { get; set; }
        public string lastname { get; set; }

        public string GetName(User user)
        {
            return name = user.Name;
        }

        public string GetLastname(User user)
        {
            return lastname = user.Lastname;
        }

        public void GetHeight(User user)
        {
            YourHeightLabel.Content = user.Height.ToString();
        }

        public void GetWeight(User user)
        {
            YourWeightLabel.Content = user.Weight.ToString();
        }
       

    }
}
