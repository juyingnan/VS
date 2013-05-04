using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NineBlockDiaryForCC
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public bool IsPasswordCorrect = false;

        public LoginWindow()
        {
            InitializeComponent();
            passwordInputBox.Focus();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //if (passwordInputBox.Password == "princesscc")
            if (passwordInputBox.Password == "princesscc")
            {
                IsPasswordCorrect = true;
                this.Close();
            }
            else
            {
                passwordInputTip.Text = "Password incorrect, Please input again.";
                passwordInputTip.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
