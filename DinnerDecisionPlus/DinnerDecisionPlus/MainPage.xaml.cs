using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DinnerDecisionPlus.Resources;
using System.Windows.Data;
using Windows.Devices.Geolocation;
using System.IO.IsolatedStorage;

using Microsoft.WindowsAzure.MobileServices;

using System.Runtime.Serialization;
using System.Windows.Threading;

namespace DinnerDecisionPlus
{
    //public class DinnerDecisionComments
    //{
    //    public int Id { get; set; }

    //    [DataMember(Name = "location")]
    //    public string Location { get; set; }

    //    [DataMember(Name = "comment")]
    //    public string Comments { get; set; }

    //    [DataMember(Name = "isGood")]
    //    public bool IsGood { get; set; }

    //    [DataMember(Name = "isBad")]
    //    public bool IsBad { get; set; }
    //}

    public partial class MainPage : PhoneApplicationPage
    {
        //默认菜单字符串
        const string defaultMenu = "盖浇饭 砂锅 大排档 米线 满汉全席 西餐 麻辣烫 自助餐 炒面 快餐 水果 西北风 馄饨 火锅 烧烤 泡面 速冻水饺 日本料理 涮羊肉 味千拉面 肯德基 面包 扬州炒饭 自助餐 比萨 麦当劳 兰州拉面 沙县小吃 烤鱼 海鲜 铁板烧 韩国料理 粥";
        private IsolatedStorageSettings _appSettings;
        //是否正在运行选择
        bool isRunning = false;
        //当前跳动项
        CurrentMenuItem current = new CurrentMenuItem();
        //GPS
        Geolocator myGeoLocator;

        //blinking function
        const int BLINKINGBLOCKCOUNT = 10;
        FloatingTextBlock[] floatingTextBlocks;
        public TextBlock[] textBlocks;
        Binding[] binding;
        Binding decisionBinding;

        //geo info
        double latitude = -1;
        double longitude = -1;
        double radius = 1000;

        ////Azure
        //MobileServiceCollectionView<DinnerDecisionComments> items;

        //private IMobileServiceTable<DinnerDecisionComments> commentTable = App.MobileService.GetTable<DinnerDecisionComments>();

        //timer
        DispatcherTimer timer1 = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();
        DispatcherTimer timer3 = new DispatcherTimer();
        const int TIMEOUT = 10000;
        const int MONITOR_INTERVAL = 1000;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            _appSettings = IsolatedStorageSettings.ApplicationSettings;

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            MenuInitialize();
            BindingInitialize();
            //TimerInitialize();
        }

        //private void TimerInitialize()
        //{
        //    timer1.Interval = TimeSpan.FromMilliseconds(TIMEOUT);
        //    timer1.Tick += timer_Tick;
        //    timer2.Interval = TimeSpan.FromMilliseconds(MONITOR_INTERVAL);
        //    timer2.Tick += timer2_Tick;
        //}


        private void MenuInitialize()
        {
            try
            {
                string text = "";
                text = ReadSetting(text);
                Menu.Set(text.Trim());
                MenuTextBox.Text = Menu.ToString();
            }
            catch (Exception)
            {
                Menu.Set(defaultMenu);
                MenuTextBox.Text = Menu.ToString();
            }
        }

        private void BindingInitialize()
        {
            floatingTextBlocks = new FloatingTextBlock[BLINKINGBLOCKCOUNT];
            textBlocks = new TextBlock[BLINKINGBLOCKCOUNT];
            binding = new Binding[BLINKINGBLOCKCOUNT * 4];
            decisionBinding = new Binding();

            for (int i = 0; i < BLINKINGBLOCKCOUNT * 4; i++)
            {
                //初始化binding
                binding[i] = new Binding();
            }
            for (int i = 0; i < BLINKINGBLOCKCOUNT; i++)
            {
                //初始化
                floatingTextBlocks[i] = new FloatingTextBlock(i * i);
                textBlocks[i] = new TextBlock();

                //颜色
                textBlocks[i].Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.LightGray);

                //绑定text
                binding[i].Source = floatingTextBlocks[i];
                binding[i].Path = new PropertyPath("Text");
                textBlocks[i].SetBinding(TextBlock.TextProperty, binding[i]);

                //绑定字体大小
                binding[i + BLINKINGBLOCKCOUNT].Source = floatingTextBlocks[i];
                binding[i + BLINKINGBLOCKCOUNT].Path = new PropertyPath("FontSize");
                textBlocks[i].SetBinding(TextBlock.FontSizeProperty, binding[i + BLINKINGBLOCKCOUNT]);

                //绑定透明度
                binding[i + BLINKINGBLOCKCOUNT * 2].Source = floatingTextBlocks[i];
                binding[i + BLINKINGBLOCKCOUNT * 2].Path = new PropertyPath("Opacity");
                textBlocks[i].SetBinding(TextBlock.OpacityProperty, binding[i + BLINKINGBLOCKCOUNT * 2]);

                //绑定位置
                binding[i + BLINKINGBLOCKCOUNT * 3].Source = floatingTextBlocks[i];
                binding[i + BLINKINGBLOCKCOUNT * 3].Path = new PropertyPath("Margin");
                textBlocks[i].SetBinding(TextBlock.MarginProperty, binding[i + BLINKINGBLOCKCOUNT * 3]);

                ParentGrid.Children.Add(textBlocks[i]);
                textBlocks[i].SetValue(Grid.RowSpanProperty, 4);
            }

            //跳动项绑定
            decisionBinding.Source = current;
            decisionBinding.Path = new PropertyPath("CurrentItem");
            DinnerTextBlock.SetBinding(TextBlock.TextProperty, decisionBinding);
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (Menu.menu.Count == 1)
            {
                MessageBox.Show("只有" + Menu.menu[0] + "，还是别选了，老老实实吃这个吧！", "免去选择恐惧症的烦恼", MessageBoxButton.OK);
                //DinnerTextBlock.Text = " 只有" + Menu.menu[0];
                //CommentsFunctionOn(Menu.menu[0]);
                //await m.ShowAsync();
            }
            else if (Menu.menu.Count == 0)
            {
                MessageBox.Show("都没选项还吃什么？", "吃货的悲哀……", MessageBoxButton.OK);
                //DinnerTextBlock.Text = "都没选项还吃什么？";
                //CommentRestaurantTextBlock.Text = "";
            }
            else
            {
                if (isRunning)
                {
                    for (int i = 0; i < BLINKINGBLOCKCOUNT; i++)
                    {
                        floatingTextBlocks[i].Timer_Pause();
                    }
                    current.Timer_Stop();
                    isRunning = false;
                    StartButton.Content = "再来一次";
                    menuPivotPage.IsEnabled = true;
                    //CommentsFunctionOn(current.CurrentItemContent);
                }
                else
                {
                    for (int i = 0; i < BLINKINGBLOCKCOUNT; i++)
                    {
                        floatingTextBlocks[i].Timer_Start();
                        floatingTextBlocks[i].isDisplay = false;
                    }
                    current.Timer_Start();
                    isRunning = true;
                    StartButton.Content = "停止";
                    menuPivotPage.IsEnabled = false;
                }
            }
        }

        //private void CommentsFunctionOn(string currentRestaurant)
        //{
        //    //上传数据餐厅选择
        //    CommentRestaurantTextBlock.Text = "对\" " + currentRestaurant + "\"的评价：";
        //    //获取评价
        //    try
        //    {
        //        items = commentTable
        //        .Where(dinnerdecisioncomments => dinnerdecisioncomments.Location.Trim() == currentRestaurant.Trim())
        //        .ToCollectionView();

        //        timer1.Start();
        //        timer2.Start();
        //    }
        //    catch (Exception)
        //    {
        //        timer1.Stop();
        //        timer2.Stop();
        //    }     
        //}

        //private void timer_Tick(object sender, EventArgs e)
        //{
        //    timer1.Stop();
        //    timer2.Stop();
        //}

        //void timer2_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {

        //    if (items.Count != 0)
        //    {
        //        timer2.Stop();
        //        timer1.Stop();
        //        List<string> comments = new List<string>();
        //        foreach (var item in items)
        //        {
        //            comments.Add(item.Comments);
        //        }
        //        //显示评价
        //        Random r = new Random();
        //        for (int i = 0; i < BLINKINGBLOCKCOUNT; i++)
        //        {
        //            floatingTextBlocks[i].Text = comments[r.Next(comments.Count)];
        //            floatingTextBlocks[i].isVisible = true;
        //            floatingTextBlocks[i].isDisplay = true;
        //            floatingTextBlocks[i].Timer_Start();
        //        }
        //    }
        //    }
        //    catch (Exception)
        //    {
        //        timer1.Stop();
        //        timer2.Stop();
        //    }
        //}

        private void Save_Button_Clicked(object sender, RoutedEventArgs e)
        {
            MenuSave();
        }

        private void MenuSave()
        {
            try
            {
                Menu.Set(MenuTextBox.Text);
                WriteSetting(Menu.ToString());
            }
            catch (Exception)
            {
                Menu.Set(defaultMenu);
                MenuTextBox.Text = defaultMenu;
            }
        }

        private async void GPS_Button_Clicked(object sender, RoutedEventArgs e)
        {
            myGeoLocator = new Geolocator();
            myGeoLocator.DesiredAccuracy = PositionAccuracy.High;
            myGeoLocator.MovementThreshold = 50;
            GPSStatusTextBlock.Text = "GPS状态: ON";

            GPS_Button.Visibility = Visibility.Collapsed;
            GPSProgressBar.Visibility = Visibility.Visible;
            GPSProgressBar.IsIndeterminate = true;

            try
            {
                Geoposition position = await myGeoLocator.GetGeopositionAsync(maximumAge: TimeSpan.FromMinutes(1), timeout: TimeSpan.FromSeconds(30));
                locationTextBlock.Text = "GPS定位: ";
                locationTextBlock.Text += this.GetCoordinateString(position.Coordinate);
            }
            catch (UnauthorizedAccessException)
            {
                locationTextBlock.Text = "定位功能被禁用";
                longitude = -1;
                latitude = -1;
            }
            catch (Exception)
            {
                locationTextBlock.Text = "定位功能关闭或其他错误，定位失败";
                longitude = -1;
                latitude = -1;
            }
            finally
            {
                myGeoLocator = null;
                GPSStatusTextBlock.Text = "GPS状态: OFF";
                GetRestaurant(latitude, longitude, radius);
            }
        }

        private void GetRestaurant(double lat, double lon, double r)
        {
            try
            {
                if (lat != -1 && lon != -1)
                {
                    AzureService.TestSoapClient proxy = new AzureService.TestSoapClient();
                    proxy.GetRestaurantCompleted += proxy_GetRestaurantCompleted;
                    proxy.GetRestaurantAsync(latitude, longitude, radius);
                }
                else
                {
                    GPS_Button.Visibility = Visibility.Visible;
                    GPSProgressBar.Visibility = Visibility.Collapsed;
                    GPSProgressBar.IsIndeterminate = false;
                }
            }
            catch (Exception ex)
            {
                locationTextBlock.Text = ex.Message;
                GPS_Button.Visibility = Visibility.Visible;
                GPSProgressBar.Visibility = Visibility.Collapsed;
                GPSProgressBar.IsIndeterminate = false;
            }
        }

        private string GetCoordinateString(Geocoordinate geocoordinate)
        {
            string positionString = string.Format("纬度: {0:0.0000}, 经度: {1:0.0000}, 误差: {2}m",
                 geocoordinate.Latitude, geocoordinate.Longitude, geocoordinate.Accuracy);
            latitude = geocoordinate.Latitude;
            longitude = geocoordinate.Longitude;
            return positionString;
        }

        private void proxy_GetRestaurantCompleted(object sender, AzureService.GetRestaurantCompletedEventArgs e)
        {
            //GPSProgressBar.Value = 90;
            try
            {
                if (e.Error == null)
                {
                    if (e.Result.Trim() != "-1" && e.Result.Trim() != "")
                        MenuTextBox.Text = e.Result;
                    else
                        MenuTextBox.Text = "西北风";
                    MenuSave();
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                GPS_Button.Visibility = Visibility.Visible;
                GPSProgressBar.Visibility = Visibility.Collapsed;
                GPSProgressBar.IsIndeterminate = false;
            }
        }

        private bool WriteSetting(string menu)
        {
            if (_appSettings.Contains("MENU"))
                _appSettings["MENU"] = menu;
            else
                _appSettings.Add("MENU", menu);
            _appSettings.Save();
            return true;
        }

        private string ReadSetting(string menu)
        {
            if (_appSettings.Contains("MENU"))
            {
                if (_appSettings.TryGetValue<String>("MENU", out menu))
                    return menu;
                else return defaultMenu;
            }
            else
                return defaultMenu;
        }

        private void menuPivotPage_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Menu.Set(MenuTextBox.Text);
                WriteSetting(Menu.ToString());
            }
            catch (Exception)
            {
                Menu.Set(defaultMenu);
                MenuTextBox.Text = defaultMenu;
            }
        }

        //private void CommentSaveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var comment = new DinnerDecisionComments { Location = current.CurrentItemContent, Comments = CommentTextBox.Text, IsBad = false, IsGood = false };
        //    InsertComment(comment);

        //    ////Test
        //    //String[] commentsLib = {"量真叫一个小呀",
        //    //                            "量很大",
        //    //                            "价格不错",
        //    //                            "价格便宜",
        //    //                            "价格好贵",
        //    //                            "吃不饱",
        //    //                            "胖子很喜欢吃",
        //    //                            "每周都要去吃",
        //    //                            "吃了一次就不想吃了",
        //    //                            "肉太少了",
        //    //                            "很地道！",
        //    //                            "味道一般",
        //    //                            "还不如大排档",
        //    //                            "人不是很多",
        //    //                            "感觉很舒服",
        //    //                            "伙计很有礼貌",
        //    //                            "服务不错",
        //    //                            "服务一般",
        //    //                            "随便吃吃而已",
        //    //                            "小吃不错",
        //    //                            "口味较多",
        //    //                            "味道不错",
        //    //                            "生意超级好",
        //    //                            "我爱吃",
        //    //                            "排队太久了",
        //    //                            "名家口味",
        //    //                            "大厨很赞",
        //    //                            "就喜欢这口",
        //    //                            "平均每人50元",
        //    //                            "平均每人60元",
        //    //                            "服务不太好",
        //    //                            "餐厅有点脏",
        //    //                            "价格便宜味道贴心",
        //    //                            "果汁和小食很爽口",
        //    //                            "逛街时吃饭的好选择",
        //    //                            "慕名而去，没有失望",
        //    //                            "非常的美味",
        //    //                            "今晚吃神马是个好应用",
        //    //                            "今晚吃神马是个好应用",
        //    //                            "今晚吃神马是个好应用",
        //    //                            "今晚吃神马是个好应用",
        //    //                            "今晚吃神马是个好应用",
        //    //                            "今晚吃神马是个好应用",
        //    //                            "今晚吃神马是个好应用",
        //    //                            "今晚吃神马是个好应用",
        //    //                            "今晚吃神马是个好应用",
        //    //                            "餐后还有西瓜送，太难吃，还是不送的好",
        //    //                            "菜有些少",
        //    //                            "口感中上级别",
        //    //                            "东西很多，每道菜都很精致"
        //    //                             };
        //    //Random r = new Random();
        //    //foreach (var item in Menu.menu)
        //    //{
        //    //    for (int i = 0; i < 10; i++)
        //    //    {
        //    //        var comment = new DinnerDecisionComments { Location = item, Comments = commentsLib[r.Next(commentsLib.Length)], IsBad = false, IsGood = false };
        //    //        InsertComment(comment);
        //    //    }
        //    //}
        //}

        //private async void InsertComment(DinnerDecisionComments comment)
        //{
        //    // This code inserts a new TodoItem into the database. When the operation completes
        //    // and Mobile Services has assigned an Id, the item is added to the CollectionView
        //    try
        //    {
        //        CommentUploadStatus.Text = "";
        //        await App.MobileService.GetTable<DinnerDecisionComments>().InsertAsync(comment);
        //        CommentUploadStatus.Text = "上传成功";
        //    }
        //    catch (Exception)
        //    {
        //        CommentUploadStatus.Text = "上传失败";
        //        throw;
        //    }
        //}

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}