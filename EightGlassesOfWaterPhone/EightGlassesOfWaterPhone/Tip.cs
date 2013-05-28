using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using Microsoft.WindowsAzure.MobileServices;

namespace EightGlassesOfWaterPhone
{
    [DataContract]
    public class Tip : INotifyPropertyChanged
    {
        MobileServiceCollection<Tip, Tip> items;
        IMobileServiceTable<Tip> todoTable;

        const int LEASTTIPID = 2; 
        const int BIGGESTTIPID = 45;

        public Tip()
        {
            Content = "正在获取小贴士";
            //GetContent();
        }

        public async void GetContent()
        {
            todoTable = App.MobileService.GetTable<Tip>();

            Random r = new Random();
            int x = r.Next(LEASTTIPID, BIGGESTTIPID);

            items = await todoTable.Where(Tip => Tip.id == x).ToCollectionAsync();

            if (items.Count > 0)
                this.Content = items[0].Content;
            else
                this.Content = "获取小贴士失败……";
            //return "请连接网络以获取小贴士";
        }

        [DataMember]
        public int id { get; set; }

        private string content;
        [DataMember]
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                if (value != content)
                {
                    content = value;
                    NotifyPropertyChanged("Content");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
