using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace SavingTheWorldIn108Minutes
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Text == "1 1 2 3 5 8 13")
            {
                resultBox.Text = "Congratulations, the world can exist for more 108 minutes.";
            }
            else
                resultBox.Text = "Bomb!";
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            passwordBox.Focus();
        }
    }
}