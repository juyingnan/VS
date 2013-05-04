using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace TimeDefination
{
    public class BinaryTime : INotifyPropertyChanged
    {

        DispatcherTimer timer = new DispatcherTimer();

        public BinaryTime(DateTime Time)
        {
            timer.Tick += timer_Tick;
            //每秒更新一次
            timer.Interval = TimeSpan.FromSeconds(1);
            //初始化设定时间
            Set(Time);
        }

        public void Timer_Start()
        {
            timer.Start();
        }

        public void Timer_Stop()
        {
            timer.Stop();
        }

        private void timer_Tick(object sender, object e)
        {
            //时间设定
            this.Set(DateTime.Now);
        }

        private void BrushCal()
        {
            //time converte to background color
            brushValue = HourHigh + "1" + HourLow + "1" + MinuteHigh + "1" + MinuteLow + "1" + SecondHigh + SecondLow;
            brushValue="#FF"+Convert.ToString(Convert.ToInt32(BrushValue,2),16);
            NotifyPropertyChanged("BrushValue");
        }

        //改变数值通知机制
        public event PropertyChangedEventHandler PropertyChanged;

        //时间变量
        private string hourHigh;
        private string hourLow;
        private string minuteHigh;
        private string minuteLow;
        private string secondHigh;
        private string secondLow;
        private string day;
        private string month;
        private string year;
        private string date;
        private string brushValue;

        //变量属性
        public string HourHigh { set { hourHigh = BinaryConvertor(value, 2); NotifyPropertyChanged("HourHigh"); } get { return hourHigh; } }
        public string HourLow { set { hourLow = BinaryConvertor(value, 4); NotifyPropertyChanged("HourLow"); } get { return hourLow; } }
        public string MinuteHigh { set { minuteHigh = BinaryConvertor(value, 3); NotifyPropertyChanged("MinuteHigh"); } get { return minuteHigh; } }
        public string MinuteLow { set { minuteLow = BinaryConvertor(value, 4); NotifyPropertyChanged("MinuteLow"); } get { return minuteLow; } }
        public string SecondHigh { set { secondHigh = BinaryConvertor(value, 3); NotifyPropertyChanged("SecondHigh"); } get { return secondHigh; } }
        public string SecondLow { set { secondLow = BinaryConvertor(value, 4); NotifyPropertyChanged("SecondLow"); } get { return secondLow; } }
        public string Day { set { day = BinaryConvertor(value, 5); NotifyPropertyChanged("Day"); } get { return day; } }
        public string Month { set { month = BinaryConvertor(value, 4); NotifyPropertyChanged("Month"); } get { return month; } }
        public string Year { set { year = BinaryConvertor(value, 11); NotifyPropertyChanged("Year"); } get { return year; } }
        public string Date { set { date = day + "/" + month + "/" + year; NotifyPropertyChanged("Date"); } get { return date; } }
        public string BrushValue { get { return brushValue; } }


        //通知方法
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        //二进制转换
        public string BinaryConvertor(string s, int length)
        {
            string result;
            try
            {
                //转换为二进制
                int i = int.Parse(s);
                result = Convert.ToString(i, 2);

                //若长度不匹配
                if (result.Length != length)
                {
                    //长度长则取后几位
                    if (result.Length > length)
                    {
                        result = result.Substring(result.Length - length);
                    }
                    //长度短则补零
                    else
                    {
                        while (result.Length < length)
                        {
                            result = "0" + result;
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {
                //若异常则全补零
                result = "";
                for (int i = 0; i < length; i++)
                {
                    result = "0" + result;
                }
                return result;
            }
        }

        //设定时间
        public void Set(DateTime Time)
        {
            //HOUR
            int hour = Time.Hour;
            HourHigh = (hour / 10).ToString();
            HourLow = (hour % 10).ToString();
            //MINUTE
            int minute = Time.Minute;
            MinuteHigh = (minute / 10).ToString();
            MinuteLow = (minute % 10).ToString();
            //Second
            int second = Time.Second;
            SecondHigh = (second / 10).ToString();
            SecondLow = (second % 10).ToString();
            //DATE
            Day = Time.Day.ToString();
            Month = Time.Month.ToString();
            Year = Time.Year.ToString();
            Date = day + "/" + month + "/" + year;
            //Brush
            BrushCal();
        }
    }
}
