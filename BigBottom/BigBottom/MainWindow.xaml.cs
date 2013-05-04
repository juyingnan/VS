using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
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

namespace BigBottom
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        const int BigBottomTime = 3000;//3000
        const int LittleBottomTime = 600;//600
        const int PostponeTime = 600;//600
        DispatcherTimer timer = new DispatcherTimer();
        enum CurrentState {wait, BigBottom, Alarm, LittleBottom, Postpone, WelcomeBack};
        CurrentState currentState;
        int timeTicks = 0;
        SoundPlayer soundPlayer = new SoundPlayer();
        

        public MainWindow()
        {
            InitializeComponent();
            TimerInitiation();
            Reset();
        }

        private void TimerInitiation()
        {
            timer.Interval = new TimeSpan(0, 0, 1);   //间隔1
            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timeTicks++;
            TimeBlock.Text = (timeTicks / 60).ToString() + ":" + (timeTicks % 60).ToString();
            switch (currentState)
            {
                case CurrentState.wait:
                    break;
                case CurrentState.BigBottom: if (timeTicks >= BigBottomTime) { Alarm(); }
                    break;
                case CurrentState.Alarm:
                    break;
                case CurrentState.LittleBottom: if (timeTicks >= LittleBottomTime) { WelcomeBack(); }
                    break;
                case CurrentState.Postpone: if (timeTicks >= PostponeTime) { Alarm(); }
                    break;
                case CurrentState.WelcomeBack:
                    break;
                default:
                    break;
            }
        }

        //wait(reset), BigBottom, Alarm, LittleBottom, Postpone(10 bigbottom), WelcomeBack
        private void BigBottom()
        {
            currentState = CurrentState.BigBottom;
            soundPlayer.Stop();
            //BigBottom状态，计时50分钟，大按钮消失，leave按钮enable，postpone和finish button unabled，GotitButton显示got it
            StartButton.Visibility = Visibility.Hidden;
            TimeBlock.Visibility = Visibility.Visible;
            GotitButton.Visibility = Visibility.Visible;
            PostponeButton.Visibility = Visibility.Visible;
            LeaveButton.Visibility = Visibility.Visible;
            GotitButton.IsEnabled = false;
            PostponeButton.IsEnabled = false;
            LeaveButton.IsEnabled = true;
            TipBlock.Text = "Your Bottom is getting bigger!";
            TipBlock.Visibility = Visibility.Visible;
            timeTicks = 0;
            TimeBlock.Text = "0:0";
            timer.Start();
        }

        private void Postpone()
        {
            currentState = CurrentState.Postpone;
            soundPlayer.Stop();
            //BigBottom状态，计时10分钟，大按钮消失，leave按钮enable，postpone和finish button unabled，GotitButton显示got it
            StartButton.Visibility = Visibility.Hidden;
            TimeBlock.Visibility = Visibility.Visible;
            GotitButton.Visibility = Visibility.Visible;
            PostponeButton.Visibility = Visibility.Visible;
            LeaveButton.Visibility = Visibility.Visible;
            GotitButton.IsEnabled = false;
            PostponeButton.IsEnabled = false;
            LeaveButton.IsEnabled = true;
            TipBlock.Text = "Postpone = bigger Bottom!!!";
            TipBlock.Visibility = Visibility.Visible;
            timeTicks = 0;
            TimeBlock.Text = "0:0";
            timer.Start();
        }

        private void LittleBottom()
        {
            currentState = CurrentState.LittleBottom;
            soundPlayer.Stop();
            //LittleBottom状态，计时10分钟，大按钮消失，leave按钮enable，postpone和Got it按钮unable
            StartButton.Visibility = Visibility.Hidden;
            TimeBlock.Visibility = Visibility.Visible;
            GotitButton.Visibility = Visibility.Visible;
            PostponeButton.Visibility = Visibility.Visible;
            LeaveButton.Visibility = Visibility.Visible;
            GotitButton.IsEnabled = false;
            PostponeButton.IsEnabled = false;
            LeaveButton.IsEnabled = true;
            TipBlock.Text = "Sport Time! DO NOT SIT DOWN!";
            TipBlock.Visibility = Visibility.Visible;
            timeTicks = 0;
            TimeBlock.Text = "0:0";
            timer.Start();
        }

        private void Reset()
        {
            timer.Stop();
            soundPlayer.Stop();
            currentState = CurrentState.wait;
            this.WindowState = WindowState.Normal;
            //等待状态，只显示大按钮
            StartButton.Visibility = Visibility.Visible;
            TimeBlock.Visibility = Visibility.Hidden;
            GotitButton.Visibility = Visibility.Hidden;
            PostponeButton.Visibility = Visibility.Hidden;
            LeaveButton.Visibility = Visibility.Hidden;
            GotitButton.IsEnabled = false;
            PostponeButton.IsEnabled = false;
            TipBlock.Visibility = Visibility.Hidden;
            TipBlock.Text = "Your Bottom is getting bigger!";
            timeTicks = 0;
            TimeBlock.Text = "0:0";
        }

        private void Alarm()
        {
            currentState = CurrentState.Alarm;
            soundPlayer.Stop();
            this.WindowState = WindowState.Normal;
            //Alarm状态，计时停止，大按钮消失，3个按钮enable,响声音
            timer.Stop();
            StartButton.Visibility = Visibility.Hidden;
            TimeBlock.Visibility = Visibility.Visible;
            GotitButton.Visibility = Visibility.Visible;
            PostponeButton.Visibility = Visibility.Visible;
            LeaveButton.Visibility = Visibility.Visible;
            GotitButton.IsEnabled = true;
            PostponeButton.IsEnabled = true;
            LeaveButton.IsEnabled = true;
            TipBlock.Visibility = Visibility.Visible;
            TipBlock.Text = "STAND UP! STAND UP!";
            //sound
            //soundPlayer.SoundLocation = "/BUZZ.wav";
            soundPlayer.Stream = Properties.Resources.BUZZ;
            soundPlayer.PlayLooping();
        }

        private void WelcomeBack()
        {
            currentState = CurrentState.WelcomeBack;
            soundPlayer.Stop();
            this.WindowState = WindowState.Normal;
            //Welcome状态，计时停止，大按钮消失，3个按钮unenable,响声音3次，然后转为wait状态
            timer.Stop();
            StartButton.Visibility = Visibility.Hidden;
            TimeBlock.Visibility = Visibility.Visible;
            GotitButton.Visibility = Visibility.Visible;
            PostponeButton.Visibility = Visibility.Visible;
            LeaveButton.Visibility = Visibility.Visible;
            GotitButton.IsEnabled = false;
            PostponeButton.IsEnabled = false;
            LeaveButton.IsEnabled = false;
            TipBlock.Visibility = Visibility.Visible;
            TipBlock.Text = "Your Bottom is getting bigger!";
            //sound
            soundPlayer.Stream = Properties.Resources.GwtWorking;
            soundPlayer.PlaySync();
            Reset();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            BigBottom();
        }

        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {            
            Reset();
        }

        private void GotitButton_Click(object sender, RoutedEventArgs e)
        {
            LittleBottom();
        }

        private void PostponeButton_Click(object sender, RoutedEventArgs e)
        {
            Postpone();
        }

    }
}
