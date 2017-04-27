using Model;

namespace Trainyourself.Pages
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        public string Name { get; set; }
        public string Lastname { get; set; }

        public string GetName(User user)
        {
            return Name = user.Name;
        }

        public string GetLastname(User user)
        {
            return Lastname = user.Lastname;
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
