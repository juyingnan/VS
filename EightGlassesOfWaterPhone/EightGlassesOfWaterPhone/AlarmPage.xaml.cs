using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Scheduler;

namespace EightGlassesOfWaterPhone
{
    public partial class AlarmPage : PhoneApplicationPage
    {
        private IsolatedStorageSettings _appSettings = IsolatedStorageSettings.ApplicationSettings;

        List<int> AlarmThresholdPickerSource = new List<int>();

        const bool DEFAULT_ALARM_SWITCH = false;
        const int DEFAULT_ALARM_THRESHOLD = 3;
        DateTime DEFAULT_ALARM_TIME = DateTime.Now;

        public AlarmPage()
        {
            InitializeComponent();

            for (int i = 1; i <= 8; i++)
            {
                AlarmThresholdPickerSource.Add(i);
            }
            AlarmThresholdPicker.ItemsSource = AlarmThresholdPickerSource;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back && e.Uri == new Uri("/MainPage.xaml", UriKind.Relative))
            {
                SaveSetting();
                //SetAlarm((bool)AlarmSwitch.IsChecked, (int)AlarmThresholdPicker.SelectedItem, (DateTime)AlarmTimePicker.Value);
                //TestTask();
            }
        }

        private void SaveSetting()
        {
            //ALARM SWITCH
            if (_appSettings.Contains("ALARMSWITCH"))
                _appSettings["ALARMSWITCH"] = AlarmSwitch.IsChecked;
            else
                _appSettings.Add("ALARMSWITCH", AlarmSwitch.IsChecked);

            //ALARM TIME
            if (_appSettings.Contains("ALARMTIME"))
                _appSettings["ALARMTIME"] = AlarmTimePicker.Value;
            else
                _appSettings.Add("ALARMTIME", AlarmTimePicker.Value);

            //ALARM THRESHOLD
            if (_appSettings.Contains("ALARMTHRESHOLD"))
                _appSettings["ALARMTHRESHOLD"] = ((int)AlarmThresholdPicker.SelectedIndex);
            else
                _appSettings.Add("ALARMTHRESHOLD", ((int)AlarmThresholdPicker.SelectedIndex));

            _appSettings.Save();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
                LoadSetting();
        }

        private void LoadSetting()
        {
            //ALARM SWITCH
            bool tempAlarmSwitch;

            if (_appSettings.Count > 0 && _appSettings.Contains("ALARMSWITCH"))
            {
                if (_appSettings.TryGetValue<bool>("ALARMSWITCH", out tempAlarmSwitch))
                    AlarmSwitch.IsChecked = tempAlarmSwitch;
                else AlarmSwitch.IsChecked = DEFAULT_ALARM_SWITCH;
            }
            else
                AlarmSwitch.IsChecked = DEFAULT_ALARM_SWITCH;

            //ALARM TIME
            DateTime tempAlarmTime = DEFAULT_ALARM_TIME;

            if (_appSettings.Count > 0 && _appSettings.Contains("ALARMTIME"))
            {
                if (_appSettings.TryGetValue<DateTime>("ALARMTIME", out tempAlarmTime))
                    AlarmTimePicker.Value = tempAlarmTime;
                else AlarmTimePicker.Value = DEFAULT_ALARM_TIME;
            }
            else
                AlarmTimePicker.Value = DEFAULT_ALARM_TIME;

            //ALARM THRESHOLD
            int tempAlarmThreshold = DEFAULT_ALARM_THRESHOLD;

            if (_appSettings.Count > 0 && _appSettings.Contains("ALARMTHRESHOLD"))
            {
                if (_appSettings.TryGetValue<int>("ALARMTHRESHOLD", out tempAlarmThreshold))
                    AlarmThresholdPicker.SelectedIndex = tempAlarmThreshold;
                else AlarmThresholdPicker.SelectedIndex = DEFAULT_ALARM_THRESHOLD;
            }
            else
                AlarmThresholdPicker.SelectedIndex = DEFAULT_ALARM_THRESHOLD;
        }

        public static void SetAlarm(bool alarmSwitch, int alarmThreshold, DateTime alarmTime)
        {
            const string ALARMNAME = "DrinkingAlarm";

            ScheduledAction _detect = ScheduledActionService.Find(ALARMNAME);
            if (_detect != null)
            {
                ScheduledActionService.Remove(ALARMNAME);
            }
            if (alarmSwitch == true)
            {
                Alarm alarm = new Alarm(ALARMNAME);
                alarm.Content = "今天您到目前为止喝水少于" + alarmThreshold + "杯，请尽快补充水份。";
                //alarm.Sound = new Uri("/Ringtones/Ring01.wma", UriKind.Relative);
                alarm.BeginTime = DateTime.Now.Date + alarmTime.TimeOfDay;
                if (alarm.BeginTime.CompareTo(DateTime.Now) <= 0)
                    alarm.BeginTime = alarm.BeginTime.AddDays(1);
                alarm.ExpirationTime = DateTime.MaxValue;
                alarm.RecurrenceType = RecurrenceInterval.None;
                try
                {
                    ScheduledActionService.Add(alarm);
                }
                catch (Exception)
                {
                    //ScheduledActionService.Replace(alarm);
                }
            }
            //else
            //{
            //    try
            //    {
            //        ScheduledActionService.Remove("DrinkingAlarm");
            //    }
            //    catch (Exception)
            //    {

            //    }
            //}
        }
    }
}