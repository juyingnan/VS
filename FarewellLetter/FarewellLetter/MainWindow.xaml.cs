using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace FarewellLetter
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextMerging();
            TimerInitialize();
            programStart();
        }

        private void TimerInitialize()
        {
            textTimer.Tick += new EventHandler(textTimer_Tick);
            textTimer.Interval = TimeSpan.FromSeconds(textTimerSpan);
            dashTimer.Tick += new EventHandler(dashTimer_Tick);
            dashTimer.Interval = TimeSpan.FromSeconds(dashTimeSpan);
            waitingTimer.Tick += new EventHandler(waitingTimer_Tick);
            waitingTimer.Interval = TimeSpan.FromSeconds(waitingTimerSpan);
            selfdstrTimer.Tick += new EventHandler(selfdstrTimer_Tick);
            selfdstrTimer.Interval = TimeSpan.FromSeconds(selfdstrTimerSpan);
            countDownTimer.Tick += new EventHandler(countDownTimer_Tick);
            countDownTimer.Interval = TimeSpan.FromSeconds(countDownTimerSpan);
        }


        private void programStart()
        {
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;

            grid1.Width = SystemParameters.PrimaryScreenWidth;
            grid1.Height = SystemParameters.PrimaryScreenHeight;

            textBlock1.Width = SystemParameters.PrimaryScreenWidth;
            textBlock1.Height = SystemParameters.PrimaryScreenHeight;

            label1.Width = SystemParameters.PrimaryScreenWidth;
            label1.Height = SystemParameters.PrimaryScreenHeight;

            
            typePlayer.Stream = Properties.Resources.TYPE;
            typePlayer.LoadAsync();
           
            clickPlayer.Stream = Properties.Resources.CLICK;
            clickPlayer.LoadAsync();

            dingPlayer.Stream = Properties.Resources.CASHREG;
            dingPlayer.LoadAsync();

            countDownTimer.Start();
        }

        private void TextMerging()
        {
            letterText += "\n";
            letterText += "*********************************************************************************************************** \n";
            letterText += "\n\n";
            letterText += "2010年10月11日\t\t\t星期一 \n\n";
            letterText += "大家好!\n\n";
            letterText += "很高兴大家打开了我的邮件附件（冒着可能会感染病毒的风险），感谢你们抽出几分钟的时间阅读我的离别之信。 \n\n";
            letterText += "很遗憾，因为个人原因，我将要离开ADB了。我曾认为我会在ADB工作很久，在这里实现我的梦想，但随着时间的流逝 \n";
            letterText += "和周围环境的改变，我越来越感到我在工作中迷失了自我，直到某天我重新发现了我对于计算机编程的热爱，我开始积 \n";
            letterText += "极主动的学习所有关于编程的一切，乐此不疲。我希望我可以全身心的投入到编程——这项我所热爱的事业中去。我发 \n";
            letterText += "现很难再像过去一样将所有的精力都投入到现在的工作中。我想我无法以这种状态继续下去，所以，我只能选择离开， \n";
            letterText += "以给自己留出充足的时间去学习自己很想学习的东西，去做自己想做的事情。 \n";
            letterText += "\n";
            letterText += "我很荣幸可以在ADB开始自己的第一份工作。在ADB的一年多来，我经历了艰辛与汗水，学会了许多知识与技能，并收 \n";
            letterText += "获了许多付出的喜悦。离开，对我来说是一个艰难的决定，这是我的第一份工作，是我曾经为之奋斗过的岗位。但我知 \n";
            letterText += "道我必须如此，因为只有这样，我才能用尽全力去追求自己的梦想，才会不后悔自己的青春和人生。 \n";
            letterText += "\n";
            letterText += "将来离开ADB的日子里，我会不时回忆起在ADB工作的点点滴滴，会偶尔怀念把我们在现场折腾的够呛的各种灯光设备， \n";
            letterText += "会在坐飞机的时候看着机场地面的灯光会心一笑，但最让我想念的，是和我一起工作战斗过的你们，因为你们，工作变 \n";
            letterText += "得更加绚烂多彩，也更值得怀念。这段友谊是无法割舍的，我们风风雨雨走过了许多坎坷，为了公司的未来努力拼搏， \n";
            letterText += "我会将这份感情永远珍藏在心中。感谢大家，感谢每个人对我的支持和帮助，也祝大家在未来的日子里可以早日实现自 \n";
            letterText += "己的梦想。\n";
            letterText += "\n";
            letterText += "本月的13号（星期三）应该是我在ADB的最后一天（可能会因为去石家庄出差推迟一两天），我会更加珍惜最后和大家 \n";
            letterText += "一起的这几天，也会加倍认真完成最后的工作。以后如果大家需要编写什么程序，可以找我定制哦！当然有事没事也欢 \n";
            letterText += "迎大家和我常联系，常邮我，常电我，常踩我。 \n";
            letterText += "\n";
            letterText += "再见了，朋友们，珍重！\n\n";
            letterText += "鞠英男\n";
            letterText += "15810925451\n";
            letterText += "bunny_gg@hotmail.com";
            letterText += "\n\n\n";
            letterText += "*********************************************************************************************************** \n";
            letterText += "\n";
        }

        /// <summary>
        /// property defination
        /// </summary>
        String letterText;
        bool isFinished = false;
        double countDown = 59;
        int soundCount = 0;
        double textTimerSpan = 0.2;
        double dashTimeSpan = 0.3;
        double waitingTimerSpan = 3;
        double selfdstrTimerSpan = 0.1;
        double countDownTimerSpan = 0.1;
        DispatcherTimer textTimer = new DispatcherTimer();
        DispatcherTimer dashTimer = new DispatcherTimer();
        DispatcherTimer waitingTimer = new DispatcherTimer();
        DispatcherTimer selfdstrTimer = new DispatcherTimer();
        DispatcherTimer countDownTimer = new DispatcherTimer();
        System.Media.SoundPlayer typePlayer = new System.Media.SoundPlayer();
        System.Media.SoundPlayer clickPlayer = new System.Media.SoundPlayer();
        System.Media.SoundPlayer dingPlayer = new System.Media.SoundPlayer();
        Random r = new Random();
        int random = 1;

        void textTimer_Tick(object sender, EventArgs e)
        {
            if (textBlock1.Text.Substring(textBlock1.Text.Length - 1, 1) == "_")
            {
                textBlock1.Text = textBlock1.Text.Remove(textBlock1.Text.Length - 1);
            }
            if (textBlock1.Text.Length < letterText.Length)
            {
                if (letterText.Substring(textBlock1.Text.Length, 1) == "*")
                {
                    textTimer.Interval = TimeSpan.FromSeconds(textTimerSpan / 10);
                }
                else
                {
                    textTimer.Interval = TimeSpan.FromSeconds(textTimerSpan);
                }
                textBlock1.Text += letterText.Substring(textBlock1.Text.Length, 1);


                if (textBlock1.Text.Length - 2 >= 0)
                {
                    if (textBlock1.Text.Substring(textBlock1.Text.Length - 2, 2) == " \n")
                    {
                        dingPlayer.PlaySync();
                    }
                    else if (soundCount >= random && textTimer.Interval == TimeSpan.FromSeconds(textTimerSpan))
                    {
                        typePlayer.Play();
                        soundCount = 0;
                        random = r.Next(3);
                    }
                }

                soundCount++;
                textBlock1.Text += "_";
            }
            else
            {
                textBlock1.Text += "\n请按任意键启动自毁程序";
                isFinished = true;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                textTimer.Stop();
                dashTimer.Start();
            }
        }

        void dashTimer_Tick(object sender, EventArgs e)
        {
            if (textBlock1.Text.Substring(textBlock1.Text.Length - 1, 1) != "_")
                textBlock1.Text += "_";
            else
            {
                textBlock1.Text = textBlock1.Text.Remove(textBlock1.Text.Length - 1);
            }
        }

        void waitingTimer_Tick(object sender, EventArgs e)
        {
            waitingTimer.Stop();
            dashTimer.Stop();
            selfdstrTimer.Start();
        }

        void selfdstrTimer_Tick(object sender, EventArgs e)
        {
            if (letterText.Length > 1)
            {
                if (letterText.Substring(letterText.Length - 1, 1) == "*")
                {
                    selfdstrTimer.Interval = TimeSpan.FromSeconds(selfdstrTimerSpan / 5);
                }
                else
                {
                    selfdstrTimer.Interval = TimeSpan.FromSeconds(selfdstrTimerSpan);
                }
                letterText = letterText.Remove(letterText.Length - 1);
                textBlock1.Text = letterText;
                textBlock1.Text += "_";
            }
            else
            {
                selfdstrTimer.Interval = TimeSpan.FromSeconds(0.1);
                textBlock1.Text = "\n\n程序将在" + (countDown / 10).ToString() + "秒后退出";
                countDown--;
                if (countDown == -1)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    this.Close();
                }
            }
        }

        void countDownTimer_Tick(object sender, EventArgs e)
        {
            if (countDown > -1)
            {
                if (countDown > 0)
                {
                    if (Convert.ToInt32(countDown) % 10 < 5)
                    {
                        label1.Content = Convert.ToInt32((countDown / 10)).ToString();
                    }
                    else
                    {
                        label1.Content = "";
                    }
                    progressBar1.Value += 2;
                    countDown--;
                    if ((Convert.ToInt32(countDown) % 10 == 0))
                    {
                        clickPlayer.Play();
                    }
                }
                else
                {
                    countDownTimer.Interval = TimeSpan.FromSeconds(1);
                    label1.FontSize = 160;
                    label1.Content = "ACTION!";
                    countDown--;
                }
            }
            else
            {
                countDown = 30;
                progressBar1.Visibility = Visibility.Hidden;
                label1.Visibility = Visibility.Hidden;
                textBlock1.Visibility = Visibility.Visible;
                this.Background = null;
                textTimer.Start();
                countDownTimer.Stop();
            }
        }

        private void anyKeyUp(object sender, KeyEventArgs e)
        {
            if (isFinished == true)
            {
                isFinished = false;
                textBlock1.Text += "\n自毁程序即将启动";
                waitingTimer.Start();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyStates == Keyboard.GetKeyStates(Key.F4) && Keyboard.Modifiers == ModifierKeys.Alt)
            //{
            //    e.Handled = true;
            //}
        }
    }
}