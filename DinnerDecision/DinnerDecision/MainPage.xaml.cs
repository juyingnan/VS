using DinnerDecision.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233

namespace DinnerDecision
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class MainPage : DinnerDecision.Common.LayoutAwarePage
    {
        //默认菜单字符串
        const string menu = "盖浇饭 砂锅 大排档 米线 满汉全席 西餐 麻辣烫 自助餐 炒面 快餐 水果 西北风 馄饨 火锅 烧烤 泡面 速冻水饺 日本料理 涮羊肉 味千拉面 肯德基 面包 扬州炒饭 自助餐 比萨 麦当劳 兰州拉面 沙县小吃 烤鱼 海鲜 铁板烧 韩国料理 粥";
        //是否正在运行选择
        bool isRunning = false;
        //当前跳动项
        CurrentMenuItem current = new CurrentMenuItem();
        
        //blinking function
        const int BLINKINGBLOCKCOUNT = 10;
        public FloatingTextBlock[] floatingTextBlocks;
        public TextBlock[] textBlocks;
        Binding[] binding;
        Binding decisionBinding;

        public MainPage()
        {
            this.InitializeComponent();            
            MenuInitialize();
            BindingInitialize();
        }

        async private void MenuInitialize()
        {
            await ReadFileToDiary();
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
                floatingTextBlocks[i] = new FloatingTextBlock(i*i);
                textBlocks[i] = new TextBlock();

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
                textBlocks[i].SetValue(Grid.RowSpanProperty, 2);
            }

            //跳动项绑定
            decisionBinding.Source = current;
            decisionBinding.Path = new PropertyPath("CurrentItem");
            DinnerTextBlock.SetBinding(TextBlock.TextProperty, decisionBinding);
        }

        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        protected override void SaveState(Dictionary<string, object> pageState)
        {
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage));
        }

        async private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (Menu.menu.Count == 1)
            {
                MessageDialog m = new MessageDialog("只有" + Menu.menu[0] + "，还是别选了，老老实实吃这个吧！", "免去选择恐惧症的烦恼");
                await m.ShowAsync();
            }
            else if (Menu.menu.Count == 0)
            {
                MessageDialog m = new MessageDialog("都没选项还吃什么？", "吃货的悲哀……");
                await m.ShowAsync();
            }
            else
            {
                if (isRunning)
                {
                    for (int i = 0; i < BLINKINGBLOCKCOUNT; i++)
                    {
                        floatingTextBlocks[i].Timer_Stop();
                    }
                    current.Timer_Stop();
                    isRunning = false;
                    StartButton.Content = "再来一次";
                    MenuButton.IsEnabled = true;
                }
                else
                {
                    for (int i = 0; i < BLINKINGBLOCKCOUNT; i++)
                    {
                        floatingTextBlocks[i].Timer_Start();
                    }
                    current.Timer_Start();
                    isRunning = true;
                    StartButton.Content = "停止";
                    MenuButton.IsEnabled = false;
                }
            }
        }

        #region READ FILE
        private async Task ReadFileToDiary()
        {
            try
            {
                // settings  
                var _Name = "Menu";
                var _Folder = Windows.Storage.ApplicationData.Current.RoamingFolder;

                // acquire file  
                var _File = await _Folder.GetFileAsync(_Name);

                // read content  
                var _ReadThis = await Windows.Storage.FileIO.ReadTextAsync(_File);

                //读取完设置菜单
                Menu.Set(_ReadThis);
            }
            catch (Exception)
            {
                //设置默认菜单
                Menu.Set(menu);
            }

        }
        #endregion
    }
}
