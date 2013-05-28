using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace EightGlassesOfWaterPhone
{
    [DataContract]
    public class Day : INotifyPropertyChanged
    {
        const int QUANTITY = 8;

        private IsolatedStorageSettings _appSettings = IsolatedStorageSettings.ApplicationSettings;

        public Day()
        {            
            glasses = new Glass[QUANTITY];
            for (int i = 0; i < glasses.Length; i++)
            {
                glasses[i] = new Glass();
                glasses[i].PropertyChanged += Day_PropertyChanged;
            }

            createTime = DateTime.Today.ToShortDateString();
            tips = new Tip();
            leftGlasses = QUANTITY;
        }

        void Day_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SaveStates();
        }

        public void SaveStates()
        {
            CalculateLeftGlasses();
            string temp = XMLSerialize(this);
            SaveToSetting(temp);
        }

        public bool LoadStates()
        {
            try
            {
                string info = "";
                DuplicateFromDay(XMLDeserialize<Day>(ReadFromSetting(info)));
                Refresh();
                CalculateLeftGlasses();
                tips.GetContent();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void DuplicateFromDay(Day day)
        {
            for (int i = 0; i < QUANTITY; i++)
            {
                this.Glasses[i].DuplicateFromGlass(day.glasses[i]);
            }
            this.CreateTime = day.CreateTime;
            this.LeftGlasses = day.LeftGlasses;
            this.Tips.Content = day.Tips.Content;
        }

        private void CalculateLeftGlasses()
        {
            int temp = 0;
            foreach (var item in glasses)
            {
                if (item.IsDrunk == false)
                    temp++;
            }
            LeftGlasses = temp;
        }

        private void Refresh()
        {
            string today = DateTime.Today.ToShortDateString();
            if (!createTime.Equals(today))
                Initiate();
        }

        private void Initiate()
        {
            for (int i = 0; i < glasses.Length; i++)
            {
                this.Glasses[i].SetToDefault();
            }
            createTime = DateTime.Today.ToShortDateString();
        }

        /// <summary>
        /// 需要序列化XML数据对象
        /// </summary>
        /// <param name="objectToSerialize"><returns></returns>
        private string XMLSerialize<T>(T objectToSerialize)
        {
            string result = "";
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(objectToSerialize.GetType());
                serializer.WriteObject(ms, objectToSerialize);
                ms.Position = 0;

                using (StreamReader reader = new StreamReader(ms))
                {
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }

        /// <summary>
        /// XML数据反序列化
        /// </summary>
        /// <typeparam name="T">反序列化对象</typeparam>
        /// <param name="xmlstr"><returns></returns>
        private T XMLDeserialize<T>(string xmlstr)
        {
            byte[] newBuffer = System.Text.Encoding.UTF8.GetBytes(xmlstr);

            if (newBuffer.Length == 0)
            {
                return default(T);
            }
            using (MemoryStream ms = new MemoryStream(newBuffer))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                return (T)serializer.ReadObject(ms);
            }
        }

        private bool SaveToSetting(String info)
        {
            if (_appSettings.Contains("DAY"))
                _appSettings["DAY"] = info;
            else
                _appSettings.Add("DAY", info);
            _appSettings.Save();
            return true;
        }


        private string ReadFromSetting(string info)
        {
            if (_appSettings.Count>0 && _appSettings.Contains("DAY"))
            {
                if (_appSettings.TryGetValue<String>("DAY", out info))
                    return info;
                else return XMLSerialize(new Day());
            }
            else
                return XMLSerialize(new Day());
        }
        
        private Glass[] glasses;
        [DataMember]
        public Glass[] Glasses
        {
            get
            {
                return glasses;
            }
            set
            {
                if (value != glasses)
                {
                    glasses = value;
                }
            }
        }

        private string createTime;
        [DataMember]
        public string CreateTime
        {
            get
            {
                return createTime;
            }
            set
            {
                if (value != createTime)
                {
                    createTime = value;
                }
            }
        }

        private int leftGlasses;
        [DataMember]
        public int LeftGlasses
        {
            get
            {
                return leftGlasses;
            }
            set
            {
                if (value != leftGlasses)
                {
                    leftGlasses = value;
                    NotifyPropertyChanged("LeftGlasses");
                }
            }
        }

        private Tip tips;
        [DataMember]
        public Tip Tips
        {
            get
            {
                return tips;
            }
            set
            {
                if (value != tips)
                {
                    tips = value;
                    NotifyPropertyChanged("Tips");
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
