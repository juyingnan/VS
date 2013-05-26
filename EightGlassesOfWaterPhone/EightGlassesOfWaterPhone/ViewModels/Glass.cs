using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Runtime.Serialization;

namespace EightGlassesOfWaterPhone
{
    [DataContract]
    public class Glass : INotifyPropertyChanged
    {
        const double OPACITY_DEFAULT = 1;
        const double OPACITY_LOW = 0.3;

        public Glass()
        {
            isDrunk = false;
            Time = "";
            opacity = OPACITY_DEFAULT;
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

        private bool isDrunk;
        [DataMember]
        public bool IsDrunk
        {
            get
            {
                return isDrunk;
            }
            set
            {
                if (value != isDrunk)
                {
                    isDrunk = value;
                    SetTime(DateTime.Now);
                    Opacity = OPACITY_LOW;
                    NotifyPropertyChanged("IsDrunk");
                }
            }
        }

        public void SetToDefault()
        {
            this.IsDrunk = false;
            this.Opacity = OPACITY_DEFAULT;
            this.Time = "";
        }

        public void DuplicateFromGlass(Glass glass)
        {
            this.IsDrunk = glass.IsDrunk;
            this.Opacity = glass.Opacity;
            this.Time = glass.Time;
        }

        private string time;
        [DataMember]
        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                if (value != time)
                {
                    time = value;
                }
            }
        }

        private double opacity;
        [DataMember]
        public double Opacity
        {
            get
            {
                return opacity;
            }
            set
            {
                    opacity = value;
                    NotifyPropertyChanged("Opacity");
            }
        }


        public void SetTime(DateTime d)
        {
            time = d.ToShortTimeString();
        }
    }
}