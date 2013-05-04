using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace DinnerDecisionPlus
{
    class FloatingTextBlock : INotifyPropertyChanged
    {
        public FloatingTextBlock(int i)
        {
            //随机数设置种子
            r = new Random(i);
            timer.Tick += timer_Tick;
        }

        private const int MIN_FRESHING_INTERVAL = 40;
        private const int MAX_FRESHING_INTERVAL = 100;
        private const int MIN_FONT_SIZE = 16;
        private const int MAX_FONT_SIZE = 40;
        private const double OPACITY_INTERVAL = 0.1;
        private const int INITIAL_OPACITY = 50;
        private const int MARGIN_OFFSET = 50;
        
        private int PAGE_HEIGHT = (int)System.Windows.Application.Current.Host.Content.ActualHeight;
        private int PAGE_WIDTH = (int)System.Windows.Application.Current.Host.Content.ActualWidth;

        public event PropertyChangedEventHandler PropertyChanged;
        private DispatcherTimer timer = new DispatcherTimer();
        Random r;
        long tick = DateTime.Now.Ticks;

        //边距，左，上
        private int leftMargin = 0;
        private int upMargin = 0;
        private Thickness margin = new Thickness(0, 0, 0, 0);
        //透明度
        private double opacity = 0;
        //字号
        private double fontSize = MIN_FONT_SIZE;
        //文字内容
        private string text = "";


        //当前项是否可见
        public bool isVisible = false;
        //是否已做出选择
        public bool isDecided = false;
        //是否透明度递增
        public int isUp = 1;
        //是否仅展示用
        public bool isDisplay = false;

        public string Text { get { return text; } set { text = value; NotifyPropertyChanged("Text"); } }
        public int LeftMargin { get { return leftMargin; } set { leftMargin = value; NotifyPropertyChanged("LeftMargin"); } }
        public int UpMargin { get { return upMargin; } set { upMargin = value; NotifyPropertyChanged("UpMargin"); } }
        public double Opacity { get { return opacity; } set { opacity = value; NotifyPropertyChanged("Opacity"); } }
        public Thickness Margin { get { return margin; } set { margin = value; NotifyPropertyChanged("Margin"); } }
        public double FontSize { get { return fontSize; } set { fontSize = value; NotifyPropertyChanged("FontSize"); } }

        public void Timer_Start()
        {
            //计时开始，此时未作出决定
            isDecided = false;
            //刷新间隔，随机变化
            timer.Interval = TimeSpan.FromMilliseconds(r.Next(MIN_FRESHING_INTERVAL, MAX_FRESHING_INTERVAL));
            timer.Start();
        }

        public void Timer_Pause()
        {
            isDecided = true;
        }

        public void Timer_Stop()
        {
            timer.Stop();
        }

        private void timer_Tick(object sender, object e)
        {
            //如果处于可见状态
            if (isVisible)
            {
                //设置可见度
                SetOpacity(Opacity + OPACITY_INTERVAL * isUp);
                //可见度为0时
                if (Opacity <= 0)
                {
                    //可见度为0时
                    //可见度增长趋势
                    isUp = 1;
                    //当前为不可见状态
                    if(!isDisplay)
                    isVisible = false;
                }
                //可见度为1时
                if (Opacity >= 1)
                {
                    //可见度降低趋势
                    isUp = -1;
                    if (isDisplay)
                        timer.Stop();
                }
            }
            //不可见状态
            else
            {
                //如果已经做出决定
                if (isDecided)
                {
                    //停止变化
                    timer.Stop();
                }
                //还未决定
                else
                {
                    //开始新一轮变化
                    //时间间隔随机
                    timer.Interval = TimeSpan.FromMilliseconds(r.Next(MIN_FRESHING_INTERVAL, MAX_FRESHING_INTERVAL));
                    //设置内容
                    SetText(Menu.menu[r.Next(0, Menu.menu.Count)]);
                    //设置位置
                    SetPosition();
                    //起始透明度
                    SetOpacity(INITIAL_OPACITY);
                    isUp = 1;
                    isVisible = true;
                }
            }
        }

        private void SetText(string p)
        {
            this.Text = p;
            //字体大小随机选择
            this.FontSize = r.Next(MIN_FONT_SIZE, MAX_FONT_SIZE);
        }

        private void SetOpacity(double targetOpacity)
        {
            if (targetOpacity > 1)
            {
                Opacity = 1;
            }
            else if (targetOpacity < 0)
            {
                Opacity = 0;
            }
            else
            {
                Opacity = targetOpacity;
            }
        }

        private void SetPosition()
        {
            UpMargin = r.Next(0, PAGE_HEIGHT - MARGIN_OFFSET);
            LeftMargin = r.Next(0, (int)PAGE_WIDTH - MARGIN_OFFSET);
            Margin = new Thickness(LeftMargin, UpMargin, 0, 0);
        }

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
