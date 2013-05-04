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

        List<answerGroup> allAnswer = new List<answerGroup>();
        List<string> questions = new List<string>();

        private void menuItemFileExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void openQuestionFileButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openXmlFileDialog = new Microsoft.Win32.OpenFileDialog();
            openXmlFileDialog.DefaultExt = "xml";
            openXmlFileDialog.Filter = "XML(.xml)|*.xml";
            //show dialog
            Nullable<bool> result = openXmlFileDialog.ShowDialog();

            if (result == true && openXmlFileDialog.FileName != "")
            {
                questions.Clear();
                try
                {
                    XmlDocument myXml = new XmlDocument();
                    myXml.Load(openXmlFileDialog.FileName);
                    XmlNodeList question = myXml.SelectSingleNode("body").ChildNodes;

                    foreach (XmlNode node in question)
                    {
                        if (node.SelectSingleNode("QuestionType").InnerText != "99")
                        {
                            if (node.SelectSingleNode("QuestionBody") != null)
                            {
                                questions.Add(node.SelectSingleNode("QuestionID").InnerText + "." + node.SelectSingleNode("QuestionBody").InnerText);
                            }
                            else
                            {
                                questions.Add(node.SelectSingleNode("QuestionID").InnerText);
                            }
                        }
                    }
                    questionFilePathLabel.Content = openXmlFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    questionFilePathLabel.Content = "Please reload.";
                }
            }
        }

        private void openAnswerFolderButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openXmlFileDialog = new Microsoft.Win32.OpenFileDialog();
            openXmlFileDialog.Multiselect = true;
            openXmlFileDialog.DefaultExt = "xml";
            openXmlFileDialog.Filter = "XML(.xml)|*.xml";
            //show dialog
            Nullable<bool> result = openXmlFileDialog.ShowDialog();

            if (result == true && openXmlFileDialog.FileNames != null)
            {
                try
                {
                    allAnswer.Clear();
                    foreach (var filename in openXmlFileDialog.FileNames)
                    {
                        XmlDocument myXml = new XmlDocument();
                        myXml.Load(filename);
                        XmlNodeList answers = myXml.SelectSingleNode("ArrayOfQuestion").ChildNodes;

                        allAnswer.Add(new answerGroup());

                        foreach (XmlNode node in answers)
                        {
                            allAnswer.Last().answer.Add(int.Parse(node.SelectSingleNode("answer").InnerText));
                        }
                    }

                    answerFilesPathLabel.Content = "";
                    foreach (var item in openXmlFileDialog.FileNames)
                    {                        
                        answerFilesPathLabel.Content += item.Substring(item.LastIndexOf('\\') + 1, item.LastIndexOf('.') - item.LastIndexOf('\\') - 1) + "; ";
                    }
                    

                    //answerLst.ItemsSource = allAnswer;
                    //answerLst.DisplayMemberPath = "answer";
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    answerFilesPathLabel.Content = "Please reload.";
                }
            }
        }

        private void copyToClipboardButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string questionBodyTemp = "ID";
                string allAnswerTemp = "";
                foreach (var item in questions)
                {
                    questionBodyTemp += "\t" + item;
                }
                foreach (var item in allAnswer)
                {
                    string singleAnswerTemp = (allAnswer.IndexOf(item) + 1).ToString();
                    foreach (var i in item.answer)
                    {
                        singleAnswerTemp += "\t" + i.ToString();
                    }
                    singleAnswerTemp += "\n";
                    allAnswerTemp += singleAnswerTemp;
                }
                Clipboard.SetDataObject(questionBodyTemp + "\n" + allAnswerTemp,true);
                MessageBox.Show("Copied to ClipBoard");
                copiedAnswerListLabel.Content = allAnswer.Count.ToString() +" groups of answer copies.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail Copying!");
                copiedAnswerListLabel.Content = "Fail Copying. Please try again.";
            }
        }
    }
}
