using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using Windows.UI;

namespace DinnerDecisionPhone
{
    class CurrentMenuItem : INotifyPropertyChanged
    {
        //刷新间隔
        private const int FRESHING_INTERVAL = 50;

        DispatcherTimer timer = new DispatcherTimer();
        private Random r = new Random();
        public event PropertyChangedEventHandler PropertyChanged;

        //当前选中项
        private string currentItem = "今天晚饭吃神马？";

        public string CurrentItem { get { return currentItem; } set { currentItem = value; NotifyPropertyChanged("CurrentItem"); } }

        private string currentItemContent = "";

        public string CurrentItemContent { get { return currentItemContent; } set { currentItemContent = value; NotifyPropertyChanged("CurrentItemContent"); } }

        public CurrentMenuItem()
        {
            timer.Tick += timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(FRESHING_INTERVAL);
        }

        private void timer_Tick(object sender, object e)
        {
            //随机选择一项
            currentItemContent = Menu.menu[r.Next(0, Menu.menu.Count)];
            CurrentItem = "今天晚饭吃" + currentItemContent + "？";
        }

        public void Timer_Start()
        {
            timer.Start();
        }

        public void Timer_Stop()
        {
            timer.Stop();
            //停止时，将问号换为感叹号
            CurrentItem = CurrentItem.Replace('？', '！');
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
