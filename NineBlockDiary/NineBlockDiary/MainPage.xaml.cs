using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NineBlockDiary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Initialize();

        }

        List<diary> myDiary = new List<diary>();
        TextBox[] contentTextBox = new TextBox[9];
        TextBox[] titleTextBox = new TextBox[9];
        int currentDiaryIndex = 1;
        bool isManualChanged = true;

        async private void Initialize()
        {
            //读取文件
            await ReadFileToDiary();
            //UI展现
            contentTextBox[0] = ContentTextBox1;
            contentTextBox[1] = ContentTextBox2;
            contentTextBox[2] = ContentTextBox3;
            contentTextBox[3] = ContentTextBox4;
            contentTextBox[4] = ContentTextBox5;
            contentTextBox[5] = ContentTextBox6;
            contentTextBox[6] = ContentTextBox7;
            contentTextBox[7] = ContentTextBox8;

            titleTextBox[0] = TitleTextBox1;
            titleTextBox[1] = TitleTextBox2;
            titleTextBox[2] = TitleTextBox3;
            titleTextBox[3] = TitleTextBox4;
            titleTextBox[4] = TitleTextBox5;
            titleTextBox[5] = TitleTextBox6;
            titleTextBox[6] = TitleTextBox7;
            titleTextBox[7] = TitleTextBox8;

            //add today
            AddToday();

            //calendar DateBar
            foreach (var item in myDiary)
            {
                DateBar.Items.Add(item.GetShorDate());
            }

            //show today
            currentDiaryIndex = myDiary.Count - 1;
            ShowOneDay(myDiary[currentDiaryIndex]);
        }

        private void AddToday()
        {
            if (myDiary.Count == 0)
            {
                myDiary.Add(new diary(DateTime.Today));
            }
            else if (!myDiary[myDiary.Count - 1].IsToday())
            {
                myDiary.Add(new diary(DateTime.Today, myDiary[myDiary.Count - 1]));
            }
        }

        private void ShowOneDay(diary diary)
        {
            for (int i = 0; i < 8; i++)
            {
                titleTextBox[i].Text = diary.GetTitle(i);
                contentTextBox[i].Text = diary.GetContent(i);
                FontSizeSet(contentTextBox[i]);
            }
            ShowMood(diary.GetMood());
            //button enabled/disabled
            ButtonJudge();
            //calendar
            isManualChanged = false;
            DateBar.SelectedItem = DateBar.Items[currentDiaryIndex];
        }


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void NextDiaryButton_Click(object sender, RoutedEventArgs e)
        {
            currentDiaryIndex++;
            ShowOneDay(myDiary[currentDiaryIndex]);
        }

        private void PreviousDiaryButton_Click(object sender, RoutedEventArgs e)
        {
            currentDiaryIndex--;
            ShowOneDay(myDiary[currentDiaryIndex]);
        }

        //judge next and previous buttons enable/disable?
        private void ButtonJudge()
        {
            if (currentDiaryIndex <= 0)
            {
                PreviousDiaryButton.IsEnabled = false;
                PreviousDiaryButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                PreviousDiaryButton.IsEnabled = true;
                PreviousDiaryButton.Visibility = Visibility.Visible;
            }
            if (currentDiaryIndex >= myDiary.Count - 1)
            {
                NextDiaryButton.IsEnabled = false;
                NextDiaryButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                NextDiaryButton.IsEnabled = true;
                NextDiaryButton.Visibility = Visibility.Visible;
            }
        }

        private async Task ReadFileToDiary()
        {
            try
            {
                // settings  
                var _Name = "MyDiary";
                var _Folder = Windows.Storage.ApplicationData.Current.RoamingFolder;

                // acquire file  
                var _File = await _Folder.GetFileAsync(_Name);

                // read content  
                var _ReadThis = await Windows.Storage.FileIO.ReadTextAsync(_File);

                var a = XMLDeserialize<List<diary>>(_ReadThis);

                foreach (var item in a)
                {
                    bool isEmpty = true;
                    for (int i = 0; i < 8; i++)
                    {
                        if (item.GetContent(i).Trim() != "")
                        {
                            isEmpty = false;
                            break;
                        }
                    }
                    if (!isEmpty)
                    {
                        myDiary.Add(item);
                    }
                }
            }
            catch (Exception)
            {
            }

        }

        private async Task SaveDiaryToFile()
        {
            // settings  
            var _Name = "MyDiary";
            var _Folder = Windows.Storage.ApplicationData.Current.RoamingFolder;
            var _Option = Windows.Storage.CreationCollisionOption.ReplaceExisting;

            try
            {
                // create file   
                var _File = await _Folder.CreateFileAsync(_Name, _Option);

                // write content  
                await Windows.Storage.FileIO.WriteTextAsync(_File, XMLSerialize(myDiary));
            }
            catch (Exception)
            {
                // do nothing
            }

        }

        //public async void IsolatedStorage()
        //{
        //    // settings  
        //    var _Name = "MyFileName";
        //    var _Folder = Windows.Storage.ApplicationData.Current.LocalSettings;
        //    var _Option = Windows.Storage.CreationCollisionOption.ReplaceExisting;

        //    // create file   
        //    var _File = await _Folder.CreateFileAsync(_Name, _Option);

        //    // write content  
        //    var _WriteThis = "Hello world!";
        //    await Windows.Storage.FileIO.WriteTextAsync(_File, _WriteThis);

        //    // acquire file  
        //    _File = await _Folder.GetFileAsync(_Name);

        //    // read content  
        //    var _ReadThis = await Windows.Storage.FileIO.ReadTextAsync(_File);
        //}

        /// <summary>
        /// 需要序列化XML数据对象
        /// </summary>
        /// <param name="objectToSerialize"><returns></returns>
        public static string XMLSerialize<T>(T objectToSerialize)
        {
            string result = "";
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(objectToSerialize.GetType());
                serializer.WriteObject(ms, objectToSerialize);
                ms.Position = 0;

                using (StreamReader reader = new StreamReader(ms))
                {
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        /// <summary>
        /// XML数据反序列化
        /// </summary>
        /// <typeparam name="T">反序列化对象</typeparam>
        /// <param name="xmlstr"><returns></returns>
        public static T XMLDeserialize<T>(string xmlstr)
        {
            byte[] newBuffer = System.Text.Encoding.UTF8.GetBytes(xmlstr);

            if (newBuffer.Length == 0)
            {
                return default(T);
            }
            using (MemoryStream ms = new MemoryStream(newBuffer))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                return (T)serializer.ReadObject(ms);
            }
        }

        private void FontSizeSet(TextBox tb)
        {
            int length = tb.Text.Length;
            int lengthWeight;

            if (length <= 4) lengthWeight = 1;
            else if (length <= 8) lengthWeight = 2;
            else if (length <= 16) lengthWeight = 3;
            else if (length <= 24) lengthWeight = 4;
            else lengthWeight = 8;

            switch (lengthWeight)
            {
                case 1: tb.FontSize = 48; break;
                case 2: tb.FontSize = 36; break;
                case 3: tb.FontSize = 30; break;
                case 4: tb.FontSize = 26; break;
                default: tb.FontSize = 22; break;
            }
        }

        private void ENTER_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key.ToString() == "Enter")
            {
                this.Focus(Windows.UI.Xaml.FocusState.Pointer);
            }
            //MessageDialog m = new MessageDialog(e.Key.ToString());
            //m.ShowAsync();
        }

        private void ContentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            int index = t.TabIndex - 1;
            if (myDiary.Count >= currentDiaryIndex)
            {
                myDiary[currentDiaryIndex].SetContent(t.Text, index);
            }
            FontSizeSet(t);
        }

        private void TitleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            int index = t.TabIndex - 8 - 1;
            if (myDiary.Count >= currentDiaryIndex)
            {
                myDiary[currentDiaryIndex].SetTitle(t.Text, index);
            }
        }

        async private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            await SaveDiaryToFile();
        }

        async private void Mood_Image_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            //Image image = (Image)sender;

            int mood = myDiary[currentDiaryIndex].GetMood() + 1;
            if (mood > 5) { mood = 1; }
            ShowMood(mood);
            myDiary[currentDiaryIndex].SetMood(mood);

            await SaveDiaryToFile();
        }

        private void ShowMood(int mood)
        {
            string address = String.Format("ms-appx:/pictures/Mood_{0}.png", mood.ToString());
            Mood_Image.Source = new BitmapImage(new Uri(address));
        }

        private void DateBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isManualChanged == true)
            {
                currentDiaryIndex = DateBar.SelectedIndex;
                ShowOneDay(myDiary[currentDiaryIndex]);
            }
            isManualChanged = true;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox c = sender as CheckBox;
            c.Content = DateTime.Today.ToString();
        }
    }
}
