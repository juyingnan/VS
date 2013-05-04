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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Markup;

namespace SimpleXamlPad
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnViewXaml_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("YourXaml.xaml", txtXamlData.Text);

            Window myWindow = null;

            try
            {
                using (Stream sr=File.Open("YourXaml.xaml",FileMode.Open))
                {
                    //link xaml to window
                    myWindow = (Window)XamlReader.Load(sr);
                    myWindow.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(System.Environment.CurrentDirectory + "\\YourXaml.xaml"))
            {
                txtXamlData.Text = File.ReadAllText("YourXaml.xaml");
            }
            else
            {
                txtXamlData.Text =
                    "<Window xmlns=\"http://schemas.microsoft.com"
                    + "/winfx/2006/xaml/presentation\"\n"
                    + "xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\""
                    + " Height =\"400\" Width =\"500\" WindowStartupLocation=\"CenterScreen\">\n"
                    + "<StackPanel>\n"
                    + "</StackPanel>\n"
                    + "</Window>";
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            File.WriteAllText("YourXaml.xaml", txtXamlData.Text);
        }

        private void defaultCode_Click(object sender, RoutedEventArgs e)
        {
            txtXamlData.Text =
                    "<Window xmlns=\"http://schemas.microsoft.com"
                    + "/winfx/2006/xaml/presentation\"\n"
                    + "xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\""
                    + " Height =\"400\" Width =\"500\" WindowStartupLocation=\"CenterScreen\">\n"
                    + "<StackPanel>\n"
                    + "</StackPanel>\n"
                    + "</Window>";
        }
    }
}
