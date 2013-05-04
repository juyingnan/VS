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
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace AskingProjectAnswerGenerator
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
        List<Question> myQuestion = new List<Question>();
        public int questionCount = 0;
        Random r = new Random();


        private void outputButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Forms.FolderBrowserDialog folderSelectDialog = new FolderBrowserDialog();
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
                if (folderSelectDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    for (int i = 0; i < int.Parse(outputQuantity.Text); i++)
                    {
                        randomAnswerGenerator();
                        using (Stream fstream = new FileStream(folderSelectDialog.SelectedPath + "\\" + QuestionFilePathLabel.Content.ToString() + "Answer" + (i + 1).ToString() + ".xml", FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            xmlFormat.Serialize(fstream, myQuestion);
                        }
                    }
                    System.Windows.MessageBox.Show("已保存");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            
        }

        private void randomAnswerGenerator()
        {
            foreach (var item in myQuestion)
            {
                item.getAnswer(r.Next(1, item.choiceQuantity));
            }
        }

        private void InitializeTable(string filepath)
        {
            myQuestion.Clear();
            questionCount = 0;

            //定义临时变量
            int qstTypeTemp = 0;
            string qstIDTemp = ""; ;
            string qstBDTemp = "";
            List<string> ansTemp = new List<string>();

            //xml数据获取
            XmlDocument myXml = new XmlDocument();
            myXml.Load(filepath);
            XmlNodeList question = myXml.SelectSingleNode("body").ChildNodes;

            foreach (XmlNode node in question)
            {
                foreach (XmlNode n in node)
                {
                    switch (n.Name)
                    {
                        case "QuestionType": qstTypeTemp = Int32.Parse(n.InnerText);
                            break;
                        case "QuestionID": qstIDTemp = n.InnerText;
                            break;
                        case "QuestionBody": qstBDTemp = n.InnerText;
                            break;
                        case "Answer":
                            if (qstTypeTemp == 99)  //若为组头,type==99
                            {
                                
                            }
                            else //若为题目
                            {
                                //新增题目
                                myQuestion.Add(new Question(qstTypeTemp, qstIDTemp, qstBDTemp, ansTemp, ansTemp.Count));
                                questionCount++;
                                
                            }
                            #region 临时变量清除
                            ansTemp.Clear();
                            qstBDTemp = "";
                            qstIDTemp = "";
                            qstTypeTemp = 0;
                            #endregion
                            break;
                        default:
                            if (n.Name.Contains("Choice"))
                            {
                                ansTemp.Add(n.InnerText);
                            }
                            break;
                    }
                }
            }
        }

        private void OpenQuestionFileButton_Click(object sender, RoutedEventArgs e)
        {
            #region 打开文件窗口定义
            Microsoft.Win32.OpenFileDialog xmlOpenFileDialog = new Microsoft.Win32.OpenFileDialog();
            xmlOpenFileDialog.DefaultExt = ".xml";
            xmlOpenFileDialog.Filter = "XML(.xml)|*.xml";
            Nullable<bool> result = xmlOpenFileDialog.ShowDialog();
            #endregion
            try
            {
                if (result == true && xmlOpenFileDialog.FileName != "")
                {
                    //读取数据
                    InitializeTable(xmlOpenFileDialog.FileName);

                    //提取文件名 http://hi.baidu.com/hyyo/blog/item/49cd17ed323e052862d09f35.html 
                    System.Windows.MessageBox.Show(xmlOpenFileDialog.FileName.Substring(xmlOpenFileDialog.FileName.LastIndexOf('\\') + 1, xmlOpenFileDialog.FileName.LastIndexOf('.') - xmlOpenFileDialog.FileName.LastIndexOf('\\') - 1) + " 已读取完成,请输入输出文件数目,谢谢.");
                }
                QuestionFilePathLabel.Content = xmlOpenFileDialog.FileName.Substring(xmlOpenFileDialog.FileName.LastIndexOf('\\') + 1, xmlOpenFileDialog.FileName.LastIndexOf('.') - xmlOpenFileDialog.FileName.LastIndexOf('\\') - 1);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message + "\n该文件格式不符，请重新选择加载。");
                this.Show();
            }
        }

        private void outputQuantity_GotFocus(object sender, RoutedEventArgs e)
        {
            outputQuantity.SelectAll();
        }

        private void outputQuantity_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            outputQuantity.SelectAll();
        }
    }
}
