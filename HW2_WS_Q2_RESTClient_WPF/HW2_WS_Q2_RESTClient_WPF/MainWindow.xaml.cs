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


namespace HW2_WS_Q2_RESTClient_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GET_TAB_GET_Button_Click(object sender, RoutedEventArgs e)
        {
            HttpWebOperation httpGet = new HttpWebOperation();
            List<String> result = httpGet.getStudentInfoByGet(URL_TEXTBOX.Text,GET_TAB_ID_No_TEXTBOX.Text);
            string outputString = "";

            CheckBox[] cb = new CheckBox[4];
            cb[0] = GET_TAB_CheckBox_Name;
            cb[1] = GET_TAB_CheckBox_Gender;
            cb[2] = GET_TAB_CheckBox_Major;
            cb[3] = GET_TAB_CheckBox_Email_Address;

            for (int i = 0; i < cb.Length; i++)
            {
                if (cb[i].IsChecked == true)
                    outputString += result[i] + "\t";
            }

            GET_TAB_RESULT_TEXTBOX.Text += outputString + "\n";
        }

        private void POST_TAB_GET_Button_Click(object sender, RoutedEventArgs e)
        {
            HttpWebOperation httpPost = new HttpWebOperation();
            string info = POST_TAB_ID_No_TEXTBOX.Text + ";" + POST_TAB_Name_TEXTBOX.Text + ";" + POST_TAB_Gender_TEXTBOX.Text + ";" + POST_TAB_Major_TEXTBOX.Text + ";" + POST_TAB_EmailAddress_TEXTBOX.Text;
            string result = httpPost.InsertStudentInfoByPost(URL_TEXTBOX.Text, info);

            POST_TAB_RESULT_TEXTBOX.Text += result + "\n";
        }

        private void DELETE_TAB_GET_Button_Click(object sender, RoutedEventArgs e)
        {
            HttpWebOperation httpPost = new HttpWebOperation();
            string ID_No = DELETE_TAB_ID_No_TEXTBOX.Text;
            string result = httpPost.DeleteStudentInfoByDelete(URL_TEXTBOX.Text, ID_No);

            DELETE_TAB_RESULT_TEXTBOX.Text += result + "\n";
        }

        private void PUT_TAB_GET_Button_Click(object sender, RoutedEventArgs e)
        {
            HttpWebOperation httpPost = new HttpWebOperation();
            string info = PUT_TAB_ID_No_TEXTBOX.Text + ";" + PUT_TAB_Name_TEXTBOX.Text + ";" + PUT_TAB_Gender_TEXTBOX.Text + ";" + PUT_TAB_Major_TEXTBOX.Text + ";" + PUT_TAB_EmailAddress_TEXTBOX.Text;
            string result = httpPost.UpdateStudentInfoByPut(URL_TEXTBOX.Text, info);

            PUT_TAB_RESULT_TEXTBOX.Text += result + "\n";
        }
    }
}
