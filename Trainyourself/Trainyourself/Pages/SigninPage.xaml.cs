﻿using System;
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

namespace Trainyourself.Pages
{
    /// <summary>
    /// Interaction logic for SigninPage.xaml
    /// </summary>
    public partial class SigninPage : Page
    {
        public SigninPage()
        {
            InitializeComponent();
        }

        private void SignIn_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void NotRegistered_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }
    }
}
