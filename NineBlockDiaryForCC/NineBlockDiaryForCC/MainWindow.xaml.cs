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
using System.Xml.Serialization;
using System.IO;

namespace NineBlockDiaryForCC
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginWindow loginWindow = new LoginWindow();
        public bool IsPasswordCorrect = false;
        List<diary> myDiary = new List<diary>();
        XmlDocument myXml = new XmlDocument();
        int currentDiaryIndex = 1;
        bool isLoadSuccessful = false;

        public MainWindow()
        {
            InitializeComponent();
            Login();
            DiaryRead();
            IsTodayExist();
            ShowOneday(myDiary[currentDiaryIndex - 1]);
        }

        private void Login()
        {
            loginWindow.ShowDialog();
            if (loginWindow.IsPasswordCorrect != true)
                Application.Current.Shutdown();
        }

        private void DiaryRead()
        {
            try
            {
                XmlRead();
                isLoadSuccessful = true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message.ToString() + Environment.NewLine + Environment.NewLine + "文件读取错误，请与Bunny联系");
                Application.Current.Shutdown();
                //XmlInitialize(); 
            }
        }

        //read the whole xml file
        private void XmlRead()
        {
            //load the xml file
            myXml.Load("DData.xml");
            //get the node list
            XmlNodeList nodeList = myXml.FirstChild.ChildNodes;
            //for each node
            foreach (var item in nodeList)
            {
                XmlElement xe = (XmlElement)item;
                //read the node to myDiary
                ReadXmlNodeToDiary(xe);
            }
        }

        //Read one node to MyDiary
        private void ReadXmlNodeToDiary(XmlElement xe)
        {
            //get the element list in one node
            XmlNodeList elementList = xe.ChildNodes;
            //if the date is OK
            DateTime nodeDate;
            if (DateTime.TryParse(elementList[0].InnerText, out nodeDate))
            {
                diary nodeDiary = new diary(nodeDate);
                if(elementList.Count>1)
                nodeDiary.SetWeather(elementList[1].InnerText);
                if (elementList.Count > 2)
                nodeDiary.SetMood(elementList[2].InnerText);
                if (elementList.Count > 3)
                for (int i = 0; i < 8; i++)
                {
                    nodeDiary.SetTitle(elementList[3].ChildNodes[i].InnerText, i);
                }
                if (elementList.Count > 4)
                for (int i = 0; i < 8; i++)
                {
                    nodeDiary.SetContent(elementList[4].ChildNodes[i].InnerText, i);
                }
                if (elementList.Count > 6)
                    for (int i = 0; i < 5; i++)
                {
                    nodeDiary.checkPoint[i].Set(elementList[5].ChildNodes[i].InnerText, elementList[6].ChildNodes[i].InnerText);
                }
                myDiary.Add(nodeDiary);
            }
        }

        //if no xml file, create one.
        private void XmlInitialize()
        {
            //XmlDeclaration dec = myXml.CreateXmlDeclaration("1.0", "UTF-8", null);
            //myXml.AppendChild(dec);
            XmlElement diaryList = myXml.CreateElement("DiaryList");
            myXml.AppendChild(diaryList);

            myDiary.Add(new diary(DateTime.Today));
            AddDiaryToXml(myDiary[0]);

            //string xmlString = myXml.OuterXml;
            myXml.Save("DData.xml");
        }

        //detect if today is already exist
        //if not, create today and add it to MyDiary
        //if yes, do nothing
        //make currentDiaryIndex = myDiary.count
        //set << & >> button Isenabled
        private void IsTodayExist()
        {           
            if (myDiary[myDiary.Count - 1].DATE.Date.ToShortDateString() != DateTime.Today.Date.ToShortDateString())
                myDiary.Add(new diary(DateTime.Today));

            currentDiaryIndex = myDiary.Count;
            NextDaybutton.IsEnabled = false;
            if (currentDiaryIndex == 1) PreviousDayButton.IsEnabled = false;
        }

        //refresh oneday status
        private void ShowOneday(diary d)
        {
            CurrentDateBlock.Text = d.DATE.ToShortDateString();

            TitleBox1.Text = d.TITLE[0];
            TitleBox2.Text = d.TITLE[1];
            TitleBox3.Text = d.TITLE[2];
            TitleBox4.Text = d.TITLE[3];
            TitleBox5.Text = d.TITLE[4];
            TitleBox6.Text = d.TITLE[5];
            TitleBox7.Text = d.TITLE[6];
            TitleBox8.Text = d.TITLE[7];
            DiaryBox1.Text = d.CONTENT[0];
            DiaryBox2.Text = d.CONTENT[1];
            DiaryBox3.Text = d.CONTENT[2];
            DiaryBox4.Text = d.CONTENT[3];
            DiaryBox5.Text = d.CONTENT[4];
            DiaryBox6.Text = d.CONTENT[5];
            DiaryBox7.Text = d.CONTENT[6];
            DiaryBox8.Text = d.CONTENT[7];

            ImageBrush b = new ImageBrush();
            b.Stretch = Stretch.Uniform;
            switch (d.WEATHER)
            {
                case 1: b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Blizzard.png"));
                    break;
                case 2: b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Freezing.png"));
                    break;
                case 3: b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/HeavyRain.png"));
                    break;
                case 4: b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/LightCloud.png"));
                    break;
                case 5: b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/LightRain.png"));
                    break;
                case 6: b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/MuchCloud.png"));
                    break;
                case 7: b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Rainbow.png"));
                    break;
                case 8: b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Snow.png"));
                    break;
                case 9: b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Sun.png"));
                    break;
                case 10: b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/SunBath.png"));
                    break;
                case 11: b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/ThunderRain.png"));
                    break;
                default: b.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Sun.png"));
                    break;
            }
            WeatherBox.Fill = b;

            ImageBrush m = new ImageBrush();
            m.Stretch = Stretch.Uniform;
            switch (d.MOOD)
            {
                case 1: m.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/白日梦.png"));
                    break;
                case 2: m.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/暴怒.png"));
                    break;
                case 3: m.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/愁.png"));
                    break;
                case 4: m.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/大喜.png"));
                    break;
                case 5: m.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/发病.png"));
                    break;
                case 6: m.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/发呆.png"));
                    break;
                case 7: m.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/烦着呢别理我.png"));
                    break;
                case 8: m.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/奋斗.png"));
                    break;
                case 9: m.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/觉皇.png"));
                    break;
                case 10: m.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/漏油.png"));
                    break;
                case 11: m.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/美美.png"));
                    break;
                case 12: m.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/迷糊.png"));
                    break;
                case 13: m.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/迷茫.png"));
                    break;
                case 14: m.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/内牛满面.png"));
                    break;
                case 15: m.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/死了.png"));
                    break;
                case 16: m.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/窝火.png"));
                    break;
                default: m.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/美美.png"));
                    break;
            }
            FaceBox.Fill = m;

            checkListBox1.IsChecked = d.checkPoint[0].isChecked;
            checkListBox2.IsChecked = d.checkPoint[1].isChecked;
            checkListBox3.IsChecked = d.checkPoint[2].isChecked;
            checkListBox4.IsChecked = d.checkPoint[3].isChecked;
            checkListBox5.IsChecked = d.checkPoint[4].isChecked;

            CheckListTextBox1.Text = d.checkPoint[0].checkContent;
            CheckListTextBox2.Text = d.checkPoint[1].checkContent;
            CheckListTextBox3.Text = d.checkPoint[2].checkContent;
            CheckListTextBox4.Text = d.checkPoint[3].checkContent;
            CheckListTextBox5.Text = d.checkPoint[4].checkContent;
        }

        private void NextDaybutton_Click(object sender, RoutedEventArgs e)
        {
            currentDiaryIndex++;
            if (currentDiaryIndex == myDiary.Count)
                NextDaybutton.IsEnabled = false;
            else
                NextDaybutton.IsEnabled = true;
            if (currentDiaryIndex == 1)
                PreviousDayButton.IsEnabled = false;
            else
                PreviousDayButton.IsEnabled = true;
            ShowOneday(myDiary[currentDiaryIndex - 1]);
        }

        private void PreviousDayButton_Click(object sender, RoutedEventArgs e)
        {
            currentDiaryIndex--;
            if (currentDiaryIndex == myDiary.Count)
                NextDaybutton.IsEnabled = false;
            else
                NextDaybutton.IsEnabled = true;
            if (currentDiaryIndex == 1)
                PreviousDayButton.IsEnabled = false;
            else
                PreviousDayButton.IsEnabled = true;
            ShowOneday(myDiary[currentDiaryIndex - 1]);
        }

        private void WeatherBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WeatherSelection weatherSelection = new WeatherSelection();
            weatherSelection.ShowDialog();
            myDiary[currentDiaryIndex - 1].SetWeather(weatherSelection.weatherSelectResult);
            ShowOneday(myDiary[currentDiaryIndex - 1]);
        }

        private void FaceBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MoodSelection moodSelection = new MoodSelection();
            moodSelection.ShowDialog();
            myDiary[currentDiaryIndex - 1].SetMood(moodSelection.moodSelectResult);
            ShowOneday(myDiary[currentDiaryIndex - 1]);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isLoadSuccessful)
                SaveToFile();
            else MessageBox.Show("文件载入失败，本次结果将不会自动保存。");
        }

        //save to xml file
        private void SaveToFile()
        {
            //remove all myXml content
            myXml.RemoveAll();

            //the root
            XmlElement diaryList = myXml.CreateElement("DiaryList");
            myXml.AppendChild(diaryList);

            //add every diary to MyXml
            foreach (var item in myDiary)
            {
                AddDiaryToXml(item);
            }

            //save to xml file
            myXml.Save("DData.xml");
        }

        private void AddDiaryToXml(diary d)
        {
            //add the diary node
            XmlElement diaryElement = myXml.CreateElement("Diary");
            myXml.FirstChild.AppendChild(diaryElement);

            XmlElement Date = myXml.CreateElement("Date");
            Date.InnerText = d.DATE.ToShortDateString();
            diaryElement.AppendChild(Date);

            XmlElement Weather = myXml.CreateElement("Weather");
            Weather.InnerText = d.WEATHER.ToString();
            diaryElement.AppendChild(Weather);

            XmlElement Mood = myXml.CreateElement("Mood");
            Mood.InnerText = d.MOOD.ToString();
            diaryElement.AppendChild(Mood);

            XmlElement TitleList = myXml.CreateElement("TitleList");
            diaryElement.AppendChild(TitleList);
            for (int i = 0; i < 8; i++)
            {
                XmlElement Title = myXml.CreateElement("Title" + i.ToString());
                Title.InnerText = d.TITLE[i];
                TitleList.AppendChild(Title);
            }

            XmlElement ContentList = myXml.CreateElement("ContentList");
            diaryElement.AppendChild(ContentList);
            for (int i = 0; i < 8; i++)
            {
                XmlElement Content = myXml.CreateElement("Content" + i.ToString());
                Content.InnerText = d.CONTENT[i];
                ContentList.AppendChild(Content);
            }

            XmlElement CheckList = myXml.CreateElement("CheckList");
            diaryElement.AppendChild(CheckList);
            for (int i = 0; i < 5; i++)
            {
                XmlElement CheckPoint = myXml.CreateElement("CheckList" + i.ToString());
                CheckPoint.InnerText = d.checkPoint[i].checkContent;
                CheckList.AppendChild(CheckPoint);
            }

            XmlElement IsCheckedList = myXml.CreateElement("IsCheckedList");
            diaryElement.AppendChild(IsCheckedList);
            for (int i = 0; i < 5; i++)
            {
                XmlElement IsChecked = myXml.CreateElement("IsCheckedList" + i.ToString());
                IsChecked.InnerText = d.checkPoint[i].isChecked.ToString();
                IsCheckedList.AppendChild(IsChecked);
            }
        }

        //font size
        private void FontSizeSet(TextBox tb)
        {
            int length = tb.Text.Length;
            int lengthWeight;
            if (length <= 2) lengthWeight = 1;
            else if (length <= 4) lengthWeight = 2;
            else if (length <= 6) lengthWeight = 3;
            else if (length <= 8) lengthWeight = 4;
            else if (length <= 12) lengthWeight = 5;
            else if (length <= 16) lengthWeight = 6;
            else if (length <= 24) lengthWeight = 7;
            else lengthWeight = 8;

            switch (lengthWeight)
            {
                case 1: tb.FontSize = 48; break;
                case 2: tb.FontSize = 36; break;
                case 3: tb.FontSize = 30; break;
                case 4: tb.FontSize = 26; break;
                case 5: tb.FontSize = 22; break;
                case 6: tb.FontSize = 18; break;
                case 7: tb.FontSize = 16; break;
                default: tb.FontSize = 12; break;
            }
        }

        #region diary update
        /// <summary>
        ///  diary update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiaryBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
            myDiary[currentDiaryIndex - 1].SetContent(DiaryBox1.Text, 0);
            FontSizeSet(DiaryBox1);
        }

        private void DiaryBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].SetContent(DiaryBox2.Text, 1);
            FontSizeSet(DiaryBox2);
        }

        private void DiaryBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].SetContent(DiaryBox3.Text, 2);
            FontSizeSet(DiaryBox3);
        }

        private void DiaryBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].SetContent(DiaryBox4.Text, 3);
            FontSizeSet(DiaryBox4);
        }

        private void DiaryBox5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].SetContent(DiaryBox5.Text, 4);
            FontSizeSet(DiaryBox5);
        }

        private void DiaryBox6_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].SetContent(DiaryBox6.Text, 5);
            FontSizeSet(DiaryBox6);
        }

        private void DiaryBox7_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].SetContent(DiaryBox7.Text, 6);
            FontSizeSet(DiaryBox7);
        }

        private void DiaryBox8_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].SetContent(DiaryBox8.Text, 7);
            FontSizeSet(DiaryBox8);
        }
        #endregion

        #region title update
        /// <summary>
        ///  title update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].SetTitle(TitleBox1.Text, 0);
        }

        private void TitleBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
            myDiary[currentDiaryIndex - 1].SetTitle(TitleBox2.Text, 1);
        }

        private void TitleBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
            myDiary[currentDiaryIndex - 1].SetTitle(TitleBox3.Text, 2);
        }

        private void TitleBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
            myDiary[currentDiaryIndex - 1].SetTitle(TitleBox4.Text, 3);
        }

        private void TitleBox5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
            myDiary[currentDiaryIndex - 1].SetTitle(TitleBox5.Text, 4);
        }

        private void TitleBox6_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
            myDiary[currentDiaryIndex - 1].SetTitle(TitleBox6.Text, 5);
        }

        private void TitleBox7_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
            myDiary[currentDiaryIndex - 1].SetTitle(TitleBox7.Text, 6);
        }

        private void TitleBox8_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
            myDiary[currentDiaryIndex - 1].SetTitle(TitleBox8.Text, 7);
        }
        #endregion

        #region checkBox update
        /// <summary>
        ///  checkBox update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkListBox1_Checked(object sender, RoutedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].checkPoint[0].Set(true);
        }

        private void checkListBox2_Checked(object sender, RoutedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].checkPoint[1].Set(true);
        }

        private void checkListBox3_Checked(object sender, RoutedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].checkPoint[2].Set(true);
        }

        private void checkListBox4_Checked(object sender, RoutedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].checkPoint[3].Set(true);
        }

        private void checkListBox5_Checked(object sender, RoutedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].checkPoint[4].Set(true);
        }

        private void checkListBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].checkPoint[0].Set(false);
        }

        private void checkListBox2_Unchecked(object sender, RoutedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].checkPoint[1].Set(false);
        }

        private void checkListBox3_Unchecked(object sender, RoutedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].checkPoint[2].Set(false);
        }

        private void checkListBox4_Unchecked(object sender, RoutedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].checkPoint[3].Set(false);
        }

        private void checkListBox5_Unchecked(object sender, RoutedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
                myDiary[currentDiaryIndex - 1].checkPoint[4].Set(false);
        }
        #endregion

        #region checkTextBox update
        /// <summary>
        ///  checkTextBox update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckListTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
            {
                //update checkText to MyDiary
                myDiary[currentDiaryIndex - 1].checkPoint[0].Set(CheckListTextBox1.Text);
                //change the opacity
                if (CheckListTextBox1.Text.Length == 0)
                {
                    checkListBox1.Opacity = 0.3;
                    CheckListSeparator1.Opacity = 0.3;
                }
                else
                {
                    checkListBox1.Opacity = 1;
                    CheckListSeparator1.Opacity = 1;
                }
            }
        }

        private void CheckListTextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
            {
                myDiary[currentDiaryIndex - 1].checkPoint[1].Set(CheckListTextBox2.Text);
                if (CheckListTextBox2.Text.Length == 0)
                {
                    checkListBox2.Opacity = 0.3;
                    CheckListSeparator2.Opacity = 0.3;
                }
                else
                {
                    checkListBox2.Opacity = 1;
                    CheckListSeparator2.Opacity = 1;
                }
            }
        }

        private void CheckListTextBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
            {
                myDiary[currentDiaryIndex - 1].checkPoint[2].Set(CheckListTextBox3.Text);
                if (CheckListTextBox3.Text.Length == 0)
                {
                    checkListBox3.Opacity = 0.3;
                    CheckListSeparator3.Opacity = 0.3;
                }
                else
                {
                    checkListBox3.Opacity = 1;
                    CheckListSeparator3.Opacity = 1;
                }
            }
        }

        private void CheckListTextBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
            {
                myDiary[currentDiaryIndex - 1].checkPoint[3].Set(CheckListTextBox4.Text);
                if (CheckListTextBox4.Text.Length == 0)
                {
                    checkListBox4.Opacity = 0.3;
                    CheckListSeparator4.Opacity = 0.3;
                }
                else
                {
                    checkListBox4.Opacity = 1;
                    CheckListSeparator4.Opacity = 1;
                }
            }
        }

        private void CheckListTextBox5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (myDiary.Count >= currentDiaryIndex)
            {
                myDiary[currentDiaryIndex - 1].checkPoint[4].Set(CheckListTextBox5.Text);
                if (CheckListTextBox5.Text.Length == 0)
                {
                    checkListBox5.Opacity = 0.3;
                    CheckListSeparator5.Opacity = 0.3;
                }
                else
                {
                    checkListBox5.Opacity = 1;
                    CheckListSeparator5.Opacity = 1;
                }
            }
        }
        #endregion
    }
}
