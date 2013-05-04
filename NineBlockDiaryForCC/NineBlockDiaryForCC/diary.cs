using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NineBlockDiaryForCC
{
    class diary
    {
        public diary(DateTime today)
        {
            date = today.Date;
            weather = 9;
            mood = 4;
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
            for (int i = 0; i < 5; i++)
            {
                checkPoint[i] = new CheckPoint();
            }
        }

        public DateTime DATE
        { get { return date; } }

        public int WEATHER
        { get { return weather; } }

        public int MOOD
        { get { return mood; } }

        public string[] TITLE
        { get { return title; } }

        public string[] CONTENT
        { get { return content; } }

        public void SetWeather(string wt) 
        {
            int temp=weather;
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
        
        private DateTime date = new DateTime();

        private int mood;
        //白日梦=1, 暴怒=2, 愁=3, 大喜=4, 
        //发病=5, 发呆=6, 烦着呢别理我=7, 奋斗=8, 
        //觉皇=9, 漏油=10, 美美=11, 迷糊=12, 
        //迷茫=13, 内牛满面=14, 死了=15, 窝火=16,other

        private int weather;
        //Blizzard=1,Freezing=2,HeavyRain=3,
        //LightCloud=4,LightRain=5,MuchCloud=6,
        //Rainbow=7,Snow=8,Sun=9,
        //SunBath=10,ThunderRain=11,other


        private string[] title = new string[8];
        private string[] content = new string[8];
        public CheckPoint[] checkPoint = new CheckPoint[5];        
        
        //string[] color = new string[8];

        public class CheckPoint
        {
            public CheckPoint(string ct,bool ic)
            {
                checkContent = ct;
                isChecked = ic;
            }

            public CheckPoint()
            {
                checkContent = "";
                isChecked = false;
            }

            public string checkContent = "";
            public bool isChecked = false;

            public void Set(string ct)
            {
                checkContent = ct;
            }

            public void Set(bool ic)
            {
                isChecked = ic;
            }

            public void Set(string ct, bool ic)
            {
                checkContent = ct;
                isChecked = ic;
            }

            public void Set(string ct, string ic)
            {
                checkContent = ct;
                if (ic == "True") isChecked = true;
                else isChecked = false;
            }
        }
    }
}
