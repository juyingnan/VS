using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeDefination
{
    public class StaticBinaryTime
    {
        public StaticBinaryTime(DateTime Time)
        {
            Set(Time);
        }

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

        //变量属性
        public string HourHigh { set { hourHigh = BinaryConvertor(value, 2); } get { return hourHigh; } }
        public string HourLow { set { hourLow = BinaryConvertor(value, 4); } get { return hourLow; } }
        public string MinuteHigh { set { minuteHigh = BinaryConvertor(value, 3); } get { return minuteHigh; } }
        public string MinuteLow { set { minuteLow = BinaryConvertor(value, 4); } get { return minuteLow; } }
        public string SecondHigh { set { secondHigh = BinaryConvertor(value, 3);  } get { return secondHigh; } }
        public string SecondLow { set { secondLow = BinaryConvertor(value, 4); } get { return secondLow; } }
        public string Day { set { day = BinaryConvertor(value, 5);  } get { return day; } }
        public string Month { set { month = BinaryConvertor(value, 4);  } get { return month; } }
        public string Year { set { year = BinaryConvertor(value, 11);  } get { return year; } }
        public string Date { set { date = day + "/" + month + "/" + year;  } get { return date; } }

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
        }
    }
}
