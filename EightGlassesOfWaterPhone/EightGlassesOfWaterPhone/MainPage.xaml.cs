//#define DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Data;
using System.Windows.Navigation;

using Microsoft.WindowsAzure.MobileServices;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Scheduler;

namespace EightGlassesOfWaterPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        Day day = new Day();

        //BINDING
        const int GLASSQUANTITY=8;
        public Image[] images;
        Binding[] binding;
        Binding NumBinding;
        Binding TipsBinding;

        //Azure
        //MobileServiceCollectionView<Tip> tips;

        private IMobileServiceTable<Tip> TipsTable = App.MobileService.GetTable<Tip>();


        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

            BindingInitialize();

            BackgroundTileRefresh();
        }

        //// Handle selection changed on ListBox
        //private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    // If selected index is -1 (no selection) do nothing
        //    if (MainListBox.SelectedIndex == -1)
        //        return;

        //    // Navigate to the new page
        //    NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + MainListBox.SelectedIndex, UriKind.Relative));

        //    // Reset selected index to -1 (no selection)
        //    MainListBox.SelectedIndex = -1;
        //}

        private void BindingInitialize()
        {
            images = new Image[GLASSQUANTITY];
            binding = new Binding[GLASSQUANTITY];
            NumBinding = new Binding();
            TipsBinding = new Binding();

            for (int i = 0; i < GLASSQUANTITY; i++)
            {
                //初始化binding
                binding[i] = new Binding();
            }

            images[0] = Glass0;
            images[1] = Glass1;
            images[2] = Glass2;
            images[3] = Glass3;
            images[4] = Glass4;
            images[5] = Glass5;
            images[6] = Glass6;
            images[7] = Glass7;

            for (int i = 0; i < GLASSQUANTITY; i++)
            {
                //绑定ISDRUNK
                binding[i].Source = day.Glasses[i];
                binding[i].Path = new PropertyPath("Opacity");
                images[i].SetBinding(Image.OpacityProperty, binding[i]);
            }

            //跳动项绑定
            NumBinding.Source = day;
            NumBinding.Path = new PropertyPath("LeftGlasses");
            BackgroundStatTextBlock.SetBinding(TextBlock.TextProperty, NumBinding);

            TipsBinding.Source = day.Tips;
            TipsBinding.Path = new PropertyPath("Content");
            TipsTextBlock.SetBinding(TextBlock.TextProperty, TipsBinding);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //if (!App.ViewModel.IsDataLoaded)
            //{
            //    App.ViewModel.LoadData();
            //}

            //day.LoadStates();
        }

        private void Glass_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Image image = (Image)sender;
            int No = int.Parse(image.Name.Substring(5, 1));

            if (!day.Glasses[No].IsDrunk)
            {
                day.Glasses[No].IsDrunk = true;

                //play the sound
                //TapSound.Play();

                //update live tile
                int left = day.LeftGlasses;
                if (left >= 0 && left <= GLASSQUANTITY)
                {
                    try
                    {
                        UpdateTile(left);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        public static void UpdateTile(int left)
        {            
                // 更新应用程序磁贴的 Badge   
                string imageAddress = "/Assets/" + left.ToString() + ".png";

                ShellTile applicationTile = ShellTile.ActiveTiles.First();
                StandardTileData newTile = new StandardTileData
                {
                    Count = left,
                    BackContent = DateTime.Now.ToShortTimeString() + "\n还剩" + left + "杯",
                    BackBackgroundImage = new Uri(imageAddress, UriKind.Relative)
                };
                applicationTile.Update(newTile);           
        }

        private void AppBarHistoryButton_Click(object sender, EventArgs e)
        {
            //UploadTips();
            MessageBox.Show(day.GetHistory(), "今日喝水记录", MessageBoxButton.OK);
        }

        private void AppBarAlarmButton_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/AlarmPage.xaml", UriKind.Relative));
        }

        private void AppBarSettingButton_Click(object sender, EventArgs e)
        {

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            day.SaveStates();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            day.LoadStates();

            //update live tile
            int left = day.LeftGlasses;
            if (left >= 0 && left <= GLASSQUANTITY)
            {
                try
                {
                    UpdateTile(left);
                }
                catch (Exception)
                {
                }
            }
        }

        public void UploadTips()
        {
            //Test
            String[] TipsLib = {"口渴表示人体水分已失去平衡，是人体细胞脱水已到一定程度，中枢神经发出要求补充水分的信号",
                    "人体每天平均消耗的水分（经过呼吸道、大小便、皮肤等）约为2500毫升",
                    "人体每天至少应从饮食中补充2200毫升水，才能达到平衡",
                    "餐前空腹喝水，餐时有汤有水",
                    "早、中、晚三餐之前约一小时，应该喝一定数量的水",
                    "饭前空腹喝水，水在胃内只停留2至3分钟，便迅速进入小肠并被吸收，供应体内对水的需要",
                    "饭前补充水分很重要。尤其是早餐前",
                    "空腹喝水宜用温开水，也可以用清淡的饮料如果汁、淡茶、菜汁等",
                    "天热多汗，应酌量增加喝水量；大量出汗后应补充一些极淡的盐水",
                    "浓茶不能代替空腹喝水，因为浓茶有利尿作用，影响人体水的平衡",
                    "进餐时喝一定数量的汤水，有助于溶解食物，并供应更多的水分，以有利于食物的消化和吸收",
                    "人体中约70%是水分",
                    "脱水可能引起指甲没有光泽，头发细软，皮肤皲裂和干燥等",
                    "开水久置以后，其中含氮的有机物会不断被分解成亚硝酸盐，亚硝酸盐与血红蛋白结合会影响血液的运氧功能",
                    "早上起来的第一杯水最好不要喝市售的果汁、可乐、汽水、咖啡、牛奶等饮料",
                    "食物也含水，比如米饭，其中含水量达到60%",
                    "蔬菜水果的含水量一般超过70%，即便一天只吃500克果蔬，也能获得300~400毫升水分",
                    "充分利用三餐进食的机会来补水，多选果蔬和不咸的汤粥，补水效果都不错",
                    "身体缺少水分，皮肤看上去会干燥没有光泽",
                    "剧烈运动前后不能补白水，也不能补高浓度的果汁，而应补运动饮料",
                    "在夏季不宜过多饮用添加有机酸的酸味饮料",
                    "淡盐水是指相当于生理浓度的盐水，每百毫升中含1克左右的盐分",
                    "不能渴时才补水，因为感到口渴时，丢失的水分已达体重的2%",
                    "早晨起床后适量多饮些水，可补偿夜间水分的消耗，对预防高血压、脑溢血、脑血栓的形成也有一定的作用",
                    "工作期间喝水，可以补充由于工作流汗及经尿排出的水分",
                    "冰水对胃脏功能不利，饮暖开水更为有益",
                    "起床之际先喝250CC的水，可帮助肾脏及肝脏解毒",
                    "所以到了办公室后，先别急着泡咖啡，给自己一杯至少250CC的水",
                    "用完午餐半小时后，喝一些水，可以加强身体的消化功能",
                    "以一杯健康矿泉水代替午茶与咖啡等提神饮料吧",
                    "下班离开办公室前喝一杯水，增加饱足感，待会吃晚餐时，自然不会暴饮暴食",
                    "睡前1至半小时再喝上一杯水",
                    "地球拥有的水量非常巨大，总量为13.86亿立方千米，其中，96.5%在海洋里",
                    "脑髓含水75%，血液含水83%，肌肉含水76%，连坚硬的骨胳里也含水22%",
                    "缺水1%—2%，感到渴；缺水5%，口干舌燥，皮肤起皱，意识不清，甚至幻视；缺水15%，往往致命",
                    "1809年，法国化学家盖吕萨克测定，1体积氧与2体积氢化合，生成2体积水蒸气",
                    "1784年英国科学家卡文迪许用实验才证明水不是元素，是由两种气体化合而成的产物",
                    "过烫的水进入食道，会破坏食道黏膜和刺激黏膜增生，诱发食道癌",
                    "饮用水的温度不能太热也不能太冷。最适宜的温度是10-30摄氏度",
                    "少量、多次、慢饮是喝水的3条基本准则",
                    "一次性快速大量喝水，会迅速稀释血液，加大心脏的负担",
                    "喝水太快太急，会把大量空气一起吞咽，容易引起打嗝或是腹胀",
                    "合理的喝水方法是把一口水含在嘴里，分几次徐徐往下咽，这样才能充分滋润口腔和喉咙，有效缓解口渴的感觉"
                                         };

            for (int i = 0; i < TipsLib.Length; i++)
            {
                Tip tip = new Tip { Content = TipsLib[i] };
                //InsertComment(tip);
            }
        }

        private async void InsertComment(Tip tip)
        {
            // This code inserts a new TodoItem into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            try
            {
                TipsTextBlock.Text = "";
                await App.MobileService.GetTable<Tip>().InsertAsync(tip);
                TipsTextBlock.Text = "上传成功";
            }
            catch (Exception e)
            {
                TipsTextBlock.Text = e.Message;
            }
        }

        private void BackgroundTileRefresh()
        {
            PeriodicTask _periodicTask;
            string _periodicTaskName = "PeriodicTask";

            // 实例化一个新的 PeriodicTask
            _periodicTask = ScheduledActionService.Find(_periodicTaskName) as PeriodicTask;
            if (_periodicTask != null)
                ScheduledActionService.Remove(_periodicTaskName);
            _periodicTask = new PeriodicTask(_periodicTaskName);

            _periodicTask.Description = "后台任务";

            try
            {
                // 每次都注册一个新的 PeriodicTask，以最大限度避免两周后无法执行的问题
                ScheduledActionService.Add(_periodicTask);
#if DEBUG
                // 1 秒后执行任务
                ScheduledActionService.LaunchForTest(_periodicTaskName, TimeSpan.FromSeconds(1));
#endif
            }
            catch (InvalidOperationException exception)
            {
                if (exception.Message.Contains("BNS Error: The action is disabled"))
                {
                    // 代理已被禁用
                    MessageBox.Show("后台代理已被禁用，瓷贴和提醒功能可能不能正常执行。如想获得完整体验，请开启后台任务或关闭节电模式");
                }
                if (exception.Message.Contains("BNS Error: The maximum number of ScheduledActions of this type have already been added."))
                {
                    // 代理的数量超过了设备的限制（设备的最大代理数是由设备进行硬性限制的，最低值是 6）
                    MessageBox.Show("后台代理的数量超过了设备的限制，瓷贴和提醒功能可能不能正常执行。如想获得完整体验，请选择开启本应用后台任务");
                }
            }
            catch (Exception)
            {

            }
        }

    }
}