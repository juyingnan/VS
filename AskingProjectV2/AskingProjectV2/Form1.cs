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
using System.Threading;

namespace AskingProjectV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            questionFileOpen();
        }

        #region 定义
        //问题对象
        List<Question> myQuestion = new List<Question>();
        public int questionCount = 0;
        //问题组头
        List<string> groupLeaderList = new List<string>();
        List<Label> groupLeaderLabelList = new List<Label>();
        //选项radiobutton
        List<List<RadioButton>> radioButtonList = new List<List<RadioButton>>();
        //问题题干
        List<Label> labelList = new List<Label>();
        //选项区
        List<FlowLayoutPanel> flowLayoutPanelList = new List<FlowLayoutPanel>();
        //拖动条
        List<TrackBar> trackBarList = new List<TrackBar>();
        //拖动条标签
        List<List<Label>> trackBarLabelList = new List<List<Label>>();
        //fakeID
        List<Label> fakeIDLabelList = new List<Label>();
        //标签页
        List<TabPage> tabPageList = new List<TabPage>();
        #endregion

        private void questionFileOpen()
        {
            #region 打开文件窗口定义
            OpenFileDialog xmlOpenFileDialog = new OpenFileDialog();
            xmlOpenFileDialog.DefaultExt = ".xml";
            xmlOpenFileDialog.Filter = "XML(.xml)|*.xml";
            #endregion
            try
            {
                if (xmlOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //读取数据
                    InitializeTable(xmlOpenFileDialog.FileName);
                    //定义控件
                    InitializeForm();

                    //提取文件名 http://hi.baidu.com/hyyo/blog/item/49cd17ed323e052862d09f35.html 
                    MessageBox.Show(xmlOpenFileDialog.FileName.Substring(xmlOpenFileDialog.FileName.LastIndexOf('\\') + 1, xmlOpenFileDialog.FileName.LastIndexOf('.') - xmlOpenFileDialog.FileName.LastIndexOf('\\') - 1)+" 已读取完成,请开始答题,谢谢.");
                    
                }
            }
            catch (Exception ex)
            {
                this.Show();
                this.Activate();
                MessageBox.Show(ex.Message + "\n该文件格式不符，请重新选择加载。");
            }
        }

        /// <summary>
        /// 窗口初始化
        /// </summary>
        private void InitializeForm()
        {
            //隐藏主窗口,显示进度条  
            this.Hide();
            loadProgressWindow loadingWindow = new loadProgressWindow();
            loadingWindow.loadProgressBar.Maximum = questionCount;
            loadingWindow.Show();
            loadingWindow.Activate();

            //默认组数为0
            int groupCount = 0;

            //对所有问题进行控件设置
            for (int j = 0; j < questionCount; j++)
            {
                if (groupLeaderList[j] != null) //若某题前有组头标示
                {
                    //建立新组头
                    groupLeaderLabelList.Add(new Label());
                    #region 组头控件设置
                    groupLeaderLabelList[groupCount].Text = groupLeaderList[j];
                    groupLeaderLabelList[groupCount].AutoSize = true;
                    groupLeaderLabelList[groupCount].Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    groupLeaderLabelList[groupCount].Location = new Point(0, 0);
                    #endregion
                    //建立新标签页
                    tabPageList.Add(new TabPage());
                    #region 标签页控件设置
                    tabPageList[groupCount].AutoScroll = true;
                    tabPageList[groupCount].BackColor = Color.White;
                    tabPageList[groupCount].Controls.Add(groupLeaderLabelList[groupCount]);
                    tabPageList[groupCount].Text = "Part " + (groupCount + 1).ToString();
                    #endregion
                    //添加标签页
                    mainTabControl.Controls.Add(tabPageList[groupCount]);
                    groupCount++;
                }

                if (tabPageList.Count == 0)   //若不分组
                {
                    //建立新标签页
                    tabPageList.Add(new TabPage());
                    #region 标签页控件设置
                    tabPageList[0].AutoScroll = true;
                    tabPageList[0].BackColor = Color.White;
                    tabPageList[groupCount].Text = "Part " + (groupCount + 1).ToString();
                    #endregion
                    //添加标签页
                    mainTabControl.Controls.Add(tabPageList[0]);
                    groupCount++;
                    groupLeaderLabelList.Add(null);
                }

                #region 题干label
                labelList.Add(new Label());
                #region 题干控件设置
                labelList[j].AutoEllipsis = true;
                labelList[j].Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelList[j].Location = new System.Drawing.Point(0, (tabPageList[groupCount - 1].Controls.Count > 0 ? tabPageList[groupCount - 1].Controls[tabPageList[groupCount - 1].Controls.Count - 1].Bounds.Bottom + 15 : 0));
                labelList[j].AutoSize = true;
                #endregion

                //fakeID label
                fakeIDLabelList.Add(new Label());
                #region fakeID控件设置
                fakeIDLabelList[j].Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                fakeIDLabelList[j].AutoSize = true;
                #endregion

                #region 若题干为空,显示fakeID
                if (myQuestion[j].questionBody != "")   //若题干不为空
                {
                    //显示题号+题目
                    labelList[j].Text = myQuestion[j].ID + ". " + myQuestion[j].questionBody;
                    //不在选项区显示fakeID
                    myQuestion[j].isIDWithChoice = false;
                    //fakeID占位
                    fakeIDLabelList[j].Text = "   ";
                }
                else  //题干为空
                {
                    //不显示题干
                    labelList[j] = null;
                    //在选项区显示fakeID
                    myQuestion[j].isIDWithChoice = true;
                    fakeIDLabelList[j].Text = myQuestion[j].ID + ". ";
                }
                #endregion
                //添加题干
                tabPageList[groupCount - 1].Controls.Add(labelList[j]);
                #endregion

                #region 选项区
                flowLayoutPanelList.Add(new FlowLayoutPanel());
                #region 选项区控件设置
                flowLayoutPanelList[j].Location = new System.Drawing.Point(0, (tabPageList[groupCount - 1].Controls.Count > 0 ? tabPageList[groupCount - 1].Controls[tabPageList[groupCount - 1].Controls.Count - 1].Bounds.Bottom : 0));
                flowLayoutPanelList[j].AutoSize = true;
                flowLayoutPanelList[j].AutoSizeMode = AutoSizeMode.GrowAndShrink;
                flowLayoutPanelList[j].FlowDirection = FlowDirection.LeftToRight;
                flowLayoutPanelList[j].WrapContents = true;
                #endregion
                //添加fakeID
                flowLayoutPanelList[j].Controls.Add(fakeIDLabelList[j]);
                //添加选项区
                tabPageList[groupCount - 1].Controls.Add(flowLayoutPanelList[j]);
                #endregion

                #region 选项内容
                //2种选项内容
                radioButtonList.Add(new List<RadioButton>());
                trackBarLabelList.Add(new List<Label>());
                trackBarList.Add(new TrackBar());

                if (myQuestion[j].questionType == 0)    //若为普通选项式问题,type==0
                {
                    for (int i = 0; i < myQuestion[j].choiceQuantity; i++)
                    {
                        //生成新选项
                        radioButtonList[j].Add(new RadioButton());
                        //添加新选项
                        flowLayoutPanelList[j].Controls.Add(radioButtonList[j][i]);
                        #region 选项控件设置
                        radioButtonList[j][i].AutoSize = true;
                        radioButtonList[j][i].Cursor = System.Windows.Forms.Cursors.Hand;
                        radioButtonList[j][i].Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        radioButtonList[j][i].Text = myQuestion[j].choice[i];
                        radioButtonList[j][i].UseVisualStyleBackColor = true;
                        #endregion
                    }
                    //trackbar占位
                    trackBarList[j] = null;
                    trackBarLabelList[j] = null;
                }
                else         //若不是普通选项问题
                {
                    //trackbar 标签定义
                    trackBarLabelList[j].Add(new Label());
                    trackBarLabelList[j].Add(new Label());
                    trackBarLabelList[j].Add(new Label());
                    trackBarLabelList[j].Add(new Label());
                    #region trackbar标签控件设置
                    foreach (var item in trackBarLabelList[j])
                    {
                        item.AutoSize = true;
                        item.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                    trackBarLabelList[j][0].Text = myQuestion[j].choice[0];
                    trackBarLabelList[j][3].Text = myQuestion[j].choice[1];
                    trackBarLabelList[j][1].Text = "1";
                    trackBarLabelList[j][2].Text = myQuestion[j].choiceQuantity.ToString();
                    #endregion

                    #region trackbar控件设置
                    trackBarList[j].Minimum = 1;
                    trackBarList[j].Maximum = myQuestion[j].choiceQuantity;
                    trackBarList[j].BackColor = Color.White;
                    trackBarList[j].Size = new System.Drawing.Size(400, 20);
                    trackBarList[j].TickStyle = TickStyle.BottomRight;
                    trackBarList[j].LargeChange = 1;
                    #endregion

                    //将trackbar及标签添加至选项区
                    flowLayoutPanelList[j].Controls.Add(trackBarLabelList[j][0]);
                    flowLayoutPanelList[j].Controls.Add(trackBarLabelList[j][1]);
                    flowLayoutPanelList[j].Controls.Add(trackBarList[j]);
                    flowLayoutPanelList[j].Controls.Add(trackBarLabelList[j][2]);
                    flowLayoutPanelList[j].Controls.Add(trackBarLabelList[j][3]);
                    //选项占位
                    radioButtonList[j] = null;
                }
                #endregion

                //更新进度
                loadingWindow.loadProgressBar.Value++;
            }
            //关闭进度条窗口,主窗口显示
            loadingWindow.Close();
            this.Show();
            this.Activate();
        }

        private void InitializeTable(string filepath)
        {
            //各定义重置
            parametersReset();

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
                                groupLeaderList.Add(qstBDTemp); //增加组头
                            }
                            else //若为题目
                            {
                                //新增题目
                                myQuestion.Add(new Question(qstTypeTemp, qstIDTemp, qstBDTemp, ansTemp, ansTemp.Count));
                                questionCount++;
                                //组头占位
                                if (groupLeaderList.Count < myQuestion.Count) //若此题无组头,占位
                                {
                                    groupLeaderList.Add(null);
                                }
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

        private void parametersReset()
        {
            //问题对象清除
            myQuestion.Clear();
            questionCount = 0;
            #region 选项清除
            foreach (var item in radioButtonList)
            {
                if (item != null)
                {
                    foreach (var i in item)
                    {
                        if (i!= null)
                        i.Dispose();
                    }
                    item.Clear();
                }
            }
            radioButtonList.Clear();
            #endregion
            #region 题干清除
            foreach (var item in labelList)
            {
                if (item != null)
                item.Dispose();
            }
            labelList.Clear();
            #endregion
            #region 选项区清除
            foreach (var item in flowLayoutPanelList)
            {
                if (item != null)
                item.Dispose();
            }
            flowLayoutPanelList.Clear();
            #endregion
            #region 组头清除
            foreach (var item in groupLeaderLabelList)
            {
                if (item != null)
                item.Dispose();
            }
            groupLeaderLabelList.Clear();
            groupLeaderList.Clear();
            #endregion
            #region trackbar清除
            foreach (var item in trackBarList)
            {
                if (item != null)
                item.Dispose();
            }
            trackBarList.Clear();
            #endregion
            #region trackbar标签清除
            foreach (var item in trackBarLabelList)
            {
                if (item != null)
                {
                    foreach (var i in item)
                    {
                        if (i != null)
                        i.Dispose();
                    }
                    item.Clear();
                }
            }
            trackBarLabelList.Clear();
            #endregion
            #region fakeID清除
            foreach (var item in fakeIDLabelList)
            {
                if (item != null)
                item.Dispose();
            }
            fakeIDLabelList.Clear();
            #endregion
            #region 标签页清除
            foreach (var item in tabPageList)
            {
                if (item != null)
                item.Dispose();
            }
            tabPageList.Clear();
            #endregion
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            questionFileOpen();
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            if (answerAssign())
            {
                questionFileSave();
            }
            else
            {
                string unFinishedID="";
                foreach (var item in myQuestion)
                {
                    if (!item.isDone)
                    {
                        unFinishedID += item.ID + ",";
                    }
                }
                unFinishedID = unFinishedID.Remove(unFinishedID.Length - 1);
                MessageBox.Show("请先完成第"+ unFinishedID+"题后再保存");
            }
        }

        private void questionFileSave()
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

        private bool answerAssign()
        {
            bool assignResult = true;
            for (int i = 0; i < questionCount; i++)
            {
                if (myQuestion[i].questionType == 1)
                {                    
                    myQuestion[i].getAnswer(trackBarList[i].Value);
                    myQuestion[i].isDone = true;
                }
                else if (myQuestion[i].questionType == 0)
                {
                    foreach (var item in radioButtonList[i])
                    {
                        if (item.Checked)
                        {
                            myQuestion[i].getAnswer(radioButtonList[i].IndexOf(item)+1);
                            myQuestion[i].isDone = true;
                            break;
                        }
                    }
                }
                else
                {
                    myQuestion[i].isDone = true;
                }
                if (myQuestion[i].isDone == false)
                {
                    assignResult = false;
                }
            }
            return assignResult;
        }
    }
}
