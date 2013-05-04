using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NineBlockDiary
{
    [DataContract]
    class diary
    {
        public diary(DateTime date)
        {
            this.date = date.Date;
            weather = 1;
            mood = 1;
            title[0] = "最开心的事";
            title[1] = "最悲剧的事";
            title[2] = "助人为乐";
            title[3] = "感悟";
            title[4] = "新闻";
            title[5] = "吃货美食";
            title[6] = "运动成果";
            title[7] = "进步";
            for (int i = 0; i < 8; i++)
            {
                content[i] = "";
            }
        }

        public diary(DateTime date, diary D)
        {
            this.date = date.Date;
            weather = 1;
            mood = 1;
            for (int i = 0; i < 8; i++)
            {
                title[i] = D.GetTitle(i); 
                content[i] = "";
            }
        }


        //GET
        public string[] GetTitle()
        { return title; }
        public string GetTitle(int index)
        {
            if (index <= title.Length)
            {
                return title[index];
            }
            else return "";
        }

        public string[] GetContent()
        { return content; }
        public string GetContent(int index)
        {
            if (index <= content.Length)
            {
                return content[index];
            }
            else return "";
        }

        public int GetMood()
        {
            return mood;
        }

        public int GetWeather()
        {
            return weather;
        }

        public DateTime GetDate()
        {
            return date;
        }

        public String GetShorDate()
        {
            return GetDate().Date.Year.ToString() + "/" + GetDate().Date.Month.ToString() + "/" + GetDate().Date.Day.ToString();
        }


        //SET
        public void SetWeather(string wt)
        {
            int temp = weather;
            if (!int.TryParse(wt, out weather)) weather = temp;
        }
        public void SetWeather(int wt)
        {
            weather = wt;
        }
        public void SetMood(string md)
        {
            int temp = mood;
            if (!int.TryParse(md, out mood)) mood = temp;
        }

        public void SetMood(int md)
        {
            mood = md;
        }
        public void SetTitle(string tt, int sn)
        {
            title[sn] = tt;
        }
        public void SetContent(string ct, int sn)
        {
            content[sn] = ct;
        }

        //other
        public bool IsToday()
        {
            if (GetDate().DayOfYear != DateTime.Today.DayOfYear)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //DEFINATION
        [DataMember]
        private string[] title = new string[8];
        [DataMember]
        private string[] content = new string[8];
        [DataMember]
        private int weather;
        //Sunny=1,Cloudy=2,Rainy=3,
        //Snow=4,other=5
        [DataMember]
        private int mood;
        //微笑=1, 大喜=2, 一般=3, 愁=4, 
        //大哭=5，other=6
        [DataMember]
        private DateTime date = new DateTime();
    }
}
