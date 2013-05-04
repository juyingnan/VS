using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;

namespace AskingProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            questionFileOpen();
        }

        List<Question> myQuestion = new List<Question>();
        List<List<RadioButton>> radioButtonList = new List<List<RadioButton>>();
        //List<RadioButton> radioButtonList = new List<RadioButton>();
        List<Label> labelList = new List<Label>();
        List<FlowLayoutPanel> flowLayoutPanelList = new List<FlowLayoutPanel>();
        public int questionCount = 0;
        public int currentQuestionID = 1;
        public bool isCurrentQuestionChecked = false;
        public bool isAutoNextQuestion = true;
        public bool isManualChecked = true;
        public bool canSaved = false;

        private void InitializeForm()
        {
            qstProgressBar.Maximum = questionCount;
            qstProgressBar.Value = currentQuestionID;
            tabControl.Visible = true;
            for (int j = 0; j < questionCount; j++)
            {
                labelList.Add(new Label());
                tabPage1.Controls.Add(labelList[j]);
                labelList[j].AutoEllipsis = true;
                labelList[j].Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelList[j].Location = new System.Drawing.Point(7, 7 + 50 * j);
                labelList[j].Size = new System.Drawing.Size(530, 15);
                labelList[j].Text = "QuestionBody";
                labelList[j].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                labelList[j].Text = myQuestion[j].ID.ToString() + ". " + myQuestion[j].questionBody;

                flowLayoutPanelList.Add(new FlowLayoutPanel());
                tabPage1.Controls.Add(flowLayoutPanelList[j]);
                flowLayoutPanelList[j].Parent = tabPage1;
                flowLayoutPanelList[j].Location = new System.Drawing.Point(9, 23 + 50 * j);
                flowLayoutPanelList[j].Size = new System.Drawing.Size(640, 26);
                flowLayoutPanelList[j].FlowDirection = FlowDirection.LeftToRight;

                for (int i = 0; i < maxChoice(); i++)
                {
                    radioButtonList.Add(new List<RadioButton>());
                    radioButtonList[j].Add(new RadioButton());
                    flowLayoutPanelList[j].Controls.Add(radioButtonList[j][i]);
                    radioButtonList[j][i].AutoSize = true;
                    radioButtonList[j][i].Cursor = System.Windows.Forms.Cursors.Hand;
                    radioButtonList[j][i].Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    radioButtonList[j][i].Size = new System.Drawing.Size(100, 21);
                    radioButtonList[j][i].Text = "test";
                    radioButtonList[j][i].UseVisualStyleBackColor = true;
                    radioButtonList[j][i].CheckedChanged += new System.EventHandler(this.answerRadioButton_CheckedChanged);
                }
            }
        }

        private int maxChoice()
        {
            int maxNumber = 0;
            foreach (var item in myQuestion)
            {
                if (item.choiceQuantity > maxNumber)
                { maxNumber = item.choiceQuantity; }
            }
            return maxNumber;
        }

        //private int CurrentCheckedJudge()
        //{
        //    for (int i = 0; i < myQuestion[currentQuestionID - 1].choiceQuantity; i++)
        //    {
        //        if (radioButtonList[i].Checked)
        //            return i;
        //    }
        //    return -1;
        //}

        private void InitializeTable(string filepath)
        {
            parametersReset();

            int qstType = 0;
            int qstIDTemp = 0; ;
            string qstBDTemp = "";
            List<string> ansTemp = new List<string>();
            int grpID = 0;

            XmlDocument myXml = new XmlDocument();
            myXml.Load(filepath);
            XmlNodeList question = myXml.SelectSingleNode("body").ChildNodes;
            foreach (XmlNode node in question)
            {
                foreach (XmlNode n in node)
                {
                    switch (n.Name)
                    {
                        case "QuestionID": qstIDTemp = Int32.Parse(n.InnerText);
                            break;
                        case "QuestionBody": qstBDTemp = n.InnerText;
                            break;
                        case "Answer": myQuestion.Add(new Question(qstType, qstIDTemp, qstBDTemp, ansTemp, ansTemp.Count, grpID));
                            ansTemp.Clear();
                            questionCount++;
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

        private void parametersReset()
        {
            myQuestion.Clear();
            foreach (var item in radioButtonList)
            {
                foreach (var i in item)
                {
                    i.Dispose();
                }
            }
            radioButtonList.Clear();
            questionCount = 0;
            currentQuestionID = 1;
            isCurrentQuestionChecked = false;
            isAutoNextQuestion = true;
            isManualChecked = true;
            canSaved = false;
            tabControl.Enabled = true;
            AutoNextCheckBox.Enabled = true;
        }

        private void UpdateQuestionArea()
        {
            //QuestionBodyLabel.Text = myQuestion[currentQuestionID - 1].questionBody;

            //answerRadioButton1.Text = myQuestion[currentQuestionID - 1].choice[0];
            //answerRadioButton2.Text = myQuestion[currentQuestionID - 1].choice[1];
            //answerRadioButton3.Text = myQuestion[currentQuestionID - 1].choice[2];
            //answerRadioButton4.Text = myQuestion[currentQuestionID - 1].choice[3];
            //answerRadioButton5.Text = myQuestion[currentQuestionID - 1].choice[4];
            progressUpdate();
            #region BUTTON ENABLE?
            if (currentQuestionID >= questionCount)
            {
                nextQuestionButton.Enabled = false;
            }
            else
            {
                nextQuestionButton.Enabled = true;
            }
            //if (currentQuestionID == 1)
            //{
            //    PreviousQuestionButton.Enabled = false;
            //}
            //else
            //{
            //    PreviousQuestionButton.Enabled = true;
            //}
            #endregion
            #region DISPLAY CHOSEN
            //isManualChecked = false;
            //switch (myQuestion[currentQuestionID - 1].answerChosen)
            //{
            //    case 1: answerRadioButton1.Checked = true; break;
            //    case 2: answerRadioButton2.Checked = true; break;
            //    case 3: answerRadioButton3.Checked = true; break;
            //    case 4: answerRadioButton4.Checked = true; break;
            //    case 5: answerRadioButton5.Checked = true; break;
            //    default:
            //        answerRadioButton1.Checked = false;
            //        answerRadioButton2.Checked = false;
            //        answerRadioButton3.Checked = false;
            //        answerRadioButton4.Checked = false;
            //        answerRadioButton5.Checked = false;
            //        break;
            //}
            //isManualChecked = true;
            #endregion
            //answerRadioButton1.Checked = false;
            //answerRadioButton2.Checked = false;
            //answerRadioButton3.Checked = false;
            //answerRadioButton4.Checked = false;
            //answerRadioButton5.Checked = false;
            for (int j = 0; j < questionCount; j++)
            {
                for (int i = 0; i < radioButtonList[j].Count; i++)
                {
                    if (i < myQuestion[currentQuestionID - 1].choiceQuantity)
                    {
                        radioButtonList[j][i].Text = myQuestion[currentQuestionID - 1].choice[i];
                    }
                    else
                    {
                        radioButtonList[j][i].Text = null;
                        radioButtonList[j][i].Enabled = false;
                    }
                    radioButtonList[j][i].Checked = false;
                }
            }
        }

        private void progressUpdate()
        {            
            if (isCurrentQuestionChecked == true)
            {
                qstProgressBar.Value = currentQuestionID;
                AutoNextCheckBox.Enabled = false;
            }
            else
            {
                qstProgressBar.Value = currentQuestionID - 1;
            }
            if (currentQuestionID == questionCount && isCurrentQuestionChecked)
            {
                if (MessageBox.Show("您已答完所有问题，现在保存答案文件么？", "保存？", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    answerSave();
                }
                tabControl.Enabled = false;
            }
        }


        private void NextQuestionButton_Click(object sender, EventArgs e)
        {
            if (isCurrentQuestionChecked)
            {
                NextQuestion();
            }
            else
            {
                MessageBox.Show("请先完成本题。");
            }
        }

        private void NextQuestion()
        {
            if (currentQuestionID < questionCount)
            {
                currentQuestionID++;
                isCurrentQuestionChecked = false;
                UpdateQuestionArea();
                AutoNextCheckBox.Enabled = true;
            }
            else
            {
                qstProgressBar.Value = questionCount;
                AutoNextCheckBox.Enabled = false;
                if (MessageBox.Show("您已答完所有问题，现在保存答案文件么？", "保存？", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    answerSave();
                }
                tabControl.Enabled = false;
            }
        }

        #region PRVIOUS FUNCTION
        private void PreviousQuestionButton_Click(object sender, EventArgs e)
        {
            PreviousQuestion();
        }

        private void PreviousQuestion()
        {
            if (currentQuestionID > 1)
            {
                currentQuestionID--;
            }
            UpdateQuestionArea();
        }
        #endregion

        private void AutoNextCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isAutoNextQuestion = AutoNextCheckBox.Checked;
            //NextQuestionButton.Enabled = !AutoNextCheckBox.Checked;
        }

        private void answerRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            //isCurrentQuestionChecked = (CurrentCheckedJudge()!=-1);
            if (isManualChecked)
            {
                if (isAutoNextQuestion && isCurrentQuestionChecked)
                {
                    //myQuestion[currentQuestionID - 1].getAnswer(CurrentCheckedJudge());
                    NextQuestion();
                }
                else
                {
                    //myQuestion[currentQuestionID - 1].getAnswer(CurrentCheckedJudge());
                    progressUpdate();
                }
            }
        }

        private void saveAnswersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canSaved = true;
            for (int i = 1; i < questionCount; i++)
            {
                if (myQuestion[i].answer == 0)
                {
                    canSaved = false;
                    break;
                }
            }

            if (canSaved)
            {
                answerSave();
            }
            else
            {
                MessageBox.Show("请答完剩余题目再保存");
            }
        }

        private void answerSave()
        {
            SaveFileDialog xmlSaveDialog = new SaveFileDialog();
            xmlSaveDialog.DefaultExt = ".xml";
            xmlSaveDialog.Filter = "XML(.xml)|*.xml";
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            if (xmlSaveDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream fstream = new FileStream(xmlSaveDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xmlFormat.Serialize(fstream, myQuestion);
                }
                MessageBox.Show("已保存");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要退出么？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void openQuestionsFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            questionFileOpen();
        }

        private void questionFileOpen()
        {
            OpenFileDialog xmlOpenFileDialog = new OpenFileDialog();
            xmlOpenFileDialog.DefaultExt = ".xml";
            xmlOpenFileDialog.Filter = "XML(.xml)|*.xml";
            try
            {
                if (xmlOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    InitializeTable(xmlOpenFileDialog.FileName);                    

                    InitializeForm();

                    UpdateQuestionArea();

                    //提取文件名 http://hi.baidu.com/hyyo/blog/item/49cd17ed323e052862d09f35.html
                    HeadingLabel.Text = xmlOpenFileDialog.FileName.Substring(xmlOpenFileDialog.FileName.LastIndexOf('\\') + 1, xmlOpenFileDialog.FileName.LastIndexOf('.') - xmlOpenFileDialog.FileName.LastIndexOf('\\') - 1);

                    MessageBox.Show("共有" + questionCount.ToString() + "道题目");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("该文件格式不符，请重新选择加载。");
            }
            finally
            {

            }
        }
    }
}
