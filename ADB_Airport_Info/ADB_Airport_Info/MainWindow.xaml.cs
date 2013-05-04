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

namespace ADB_Airport_Info
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            airportListRead("");
        }

        string airportFolder = System.Environment.CurrentDirectory + "\\Airport";
        ListBox backup = new ListBox();
        

        private void airportListRead(string p)
        {
            if (Directory.Exists(airportFolder) == true)
            {
                string[] stringList = System.IO.Directory.GetFiles(airportFolder,"*"+p+"*.xml");

                AirportList.Items.Clear();
                foreach (string str in stringList)
                {
                    string fileName;
                    fileName = System.IO.Path.GetFileNameWithoutExtension(str);
                    ListBoxItem next = new ListBoxItem();
                    //next.Name = fileName;
                    next.Content = fileName;
                    AirportList.Items.Add(next);
                }
            }
            else
            { MessageBox.Show("No airport info files"); }
        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            if (AirportList.SelectedIndex != -1)
            {
                ListBoxItem current = (ListBoxItem)AirportList.SelectedItem;
                InfoWindow currentInfoWindow = new InfoWindow(airportFolder , current.Content.ToString(), false);
                currentInfoWindow.ShowDialog();
            }
            else
                openButton.IsEnabled = false;
            //refresh the list
            airportListRead("");
        }

        private void AirportList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AirportList.SelectedIndex != -1)
            {
                openButton.IsEnabled = true;
                deleteButton.IsEnabled = true;
            }
            else
            {
                openButton.IsEnabled = false;
                deleteButton.IsEnabled = false;
            }
        }

        private void inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            airportListRead(inputBox.Text);
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AirportNameInputWindow inputWindow = new AirportNameInputWindow(airportFolder);
            inputWindow.ShowDialog();
            airportListRead(inputBox.Text);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteTipWindow deleteTipWindow = new DeleteTipWindow();
            if ((bool)deleteTipWindow.ShowDialog())
            {
                if (AirportList.SelectedIndex != -1)
                {
                    ListBoxItem current = (ListBoxItem)AirportList.SelectedItem;

                    if (File.Exists(airportFolder + "\\" + current.Content.ToString() + ".xml"))
                    {
                        File.Delete(airportFolder + "\\" + current.Content.ToString() + ".xml");
                    }
                }
                else
                    deleteButton.IsEnabled = false;
                //refresh the list
                airportListRead(inputBox.Text);
            }
        }
    }
}
