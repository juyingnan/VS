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
using System.Xml;

namespace AskingProjectAnswerReader
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

        private void menuItemFileOpen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openXmlFileDialog = new Microsoft.Win32.OpenFileDialog();
            openXmlFileDialog.DefaultExt = "xml";
            openXmlFileDialog.Filter = "XML(.xml)|*.xml";
            //show dialog
            Nullable<bool> result = openXmlFileDialog.ShowDialog();

            //wait the result
            if (result == true && openXmlFileDialog.FileName != "")
            {
                try
                {
                    //http://blog.csdn.net/zengjibing/archive/2009/01/16/3797837.aspx
                    XmlDocument answerXmlSource = new XmlDocument();
                    answerXmlSource.Load(openXmlFileDialog.FileName);
                    XmlDataProvider answerXmlprovider = this.FindResource("answerXmlDoc") as XmlDataProvider;
                    answerXmlprovider.Document = answerXmlSource;
                    answerXmlprovider.XPath = "/ArrayOfQuestion/Question";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void menuItemFileExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void menuItemEditCopy_Click(object sender, RoutedEventArgs e)
        {
            string copyString = (menuItemCopyID.IsChecked ? "ID\t" : "") + (menuItemCopyQstBD.IsChecked ? "Question\t" : "") + (menuItemCopyAllChoice.IsChecked ? "Choices1\tChoices2\tChoices3\tChoices4\tChoices5\t" : "") + (menuItemCopyAnswer.IsChecked ? "Answer" : "") + "\n";
            try
            {
                foreach (var item in answerLst.Items)
                {
                    XmlElement i = (XmlElement)item;
                    if (menuItemCopyID.IsChecked)
                    {
                        copyString += i["ID"].InnerText;
                        copyString += "\t";
                    }
                    if (menuItemCopyQstBD.IsChecked)
                    {
                        copyString += i["questionBody"].InnerText;
                        copyString += "\t";
                    }
                    if (menuItemCopyAllChoice.IsChecked)
                    {
                        copyString += i["allChoice"].InnerText;
                    }
                    if (menuItemCopyAnswer.IsChecked)
                    {
                        copyString += i["answer"].InnerText;
                        //copyString += "\t";
                    }
                    copyString += "\n";
                }
                Clipboard.SetDataObject(copyString);
                MessageBox.Show("Copied to ClipBoard");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail Copying!");
            }

        }
    }
}
