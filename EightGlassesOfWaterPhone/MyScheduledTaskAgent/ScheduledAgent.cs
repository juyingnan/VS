using System.Windows;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.IsolatedStorage;

namespace MyScheduledTaskAgent
{
    public class ScheduledAgent : ScheduledTaskAgent
    {
        private static volatile bool _classInitialized;

        private IsolatedStorageSettings _appSettings = IsolatedStorageSettings.ApplicationSettings;

        bool ALARM_SWITCH = false;
        int ALARM_THRESHOLD = 3;
        DateTime ALARM_TIME = DateTime.Now;

        bool HASALARMED = false;

        int LEFTGLASSES = 8;

        /// <remarks>
        /// ScheduledAgent constructor, initializes the UnhandledException handler
        /// </remarks>
        public ScheduledAgent()
        {
            if (!_classInitialized)
            {
                _classInitialized = true;
                // Subscribe to the managed exception handler
                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    Application.Current.UnhandledException += ScheduledAgent_UnhandledException;
                });
            }
        }

        /// Code to execute on Unhandled Exceptions
        private void ScheduledAgent_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        /// <summary>
        /// Agent that runs a scheduled task
        /// </summary>
        /// <param name="task">
        /// The invoked task
        /// </param>
        /// <remarks>
        /// This method is called when a periodic or resource intensive task is invoked
        /// </remarks>
        protected override void OnInvoke(ScheduledTask task)
        {
            try
            {
                //TODO: Add code to perform your task in background
                // 更新应用程序磁贴
                int lastDay = task.LastScheduledTime.Day;
                int today = DateTime.Today.Day;

                if (task.LastScheduledTime.Year > 1 && today != lastDay)
                {
                    RefreshTile();
                }

                //toast
                // 弹出 Toast
                LoadSetting();
                DateTime now = DateTime.Now;
                if (now.CompareTo(ALARM_TIME) >= 0 && !HASALARMED && ALARM_SWITCH && (ALARM_THRESHOLD + LEFTGLASSES > 8))
                //if (now.CompareTo(ALARM_TIME) >= 0  && ALARM_SWITCH && (ALARM_THRESHOLD + LEFTGLASSES > 8))  //for TEST
                {
                    ShowToast();
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                NotifyComplete();
            }
        }

        private void ShowToast()
        {
            ShellToast toast = new ShellToast();
            toast.Title = "喝水提醒";
            toast.Content = "今天到目前为止喝水少于" + ALARM_THRESHOLD + "杯，请尽快补充水份。"; ;
            toast.NavigationUri = new Uri("/MainPage.xaml", UriKind.Relative);
            toast.Show();

            HASALARMED = true;
            //HASALARMED UPDATE
            if (_appSettings.Contains("HASALARMED"))
                _appSettings["HASALARMED"] = HASALARMED;
            else
                _appSettings.Add("HASALARMED", HASALARMED);

            _appSettings.Save();
        }

        private void RefreshTile()
        {
            int left = 8;
            string number = "/Assets/" + left.ToString() + ".png";

            ShellTile applicationTile = ShellTile.ActiveTiles.First();
            StandardTileData newTile = new StandardTileData
            {
                Count = left,
                BackContent = DateTime.Now.ToShortTimeString() + "\n还剩" + left + "杯",
                //BackContent = task.LastScheduledTime.ToLongTimeString(),
                BackBackgroundImage = new Uri(number, UriKind.Relative)
            };
            applicationTile.Update(newTile);

            //LEFTGLASSES UPDATE
            if (_appSettings.Contains("LEFTGLASSES"))
                _appSettings["LEFTGLASSES"] = left;
            else
                _appSettings.Add("LEFTGLASSES", left);

            //HASALARMED UPDATE
            if (_appSettings.Contains("HASALARMED"))
                _appSettings["HASALARMED"] = false;
            else
                _appSettings.Add("HASALARMED", false);

            _appSettings.Save();
        }

        private void LoadSetting()
        {
            //ALARM SWITCH
            bool tempAlarmSwitch;

            if (_appSettings.Count > 0 && _appSettings.Contains("ALARMSWITCH"))
            {
                if (_appSettings.TryGetValue<bool>("ALARMSWITCH", out tempAlarmSwitch))
                    ALARM_SWITCH = tempAlarmSwitch;
                else ALARM_SWITCH = false;
            }
            else
                ALARM_SWITCH = false;

            //ALARM TIME
            DateTime tempAlarmTime = ALARM_TIME;

            if (_appSettings.Count > 0 && _appSettings.Contains("ALARMTIME"))
            {
                if (_appSettings.TryGetValue<DateTime>("ALARMTIME", out tempAlarmTime))
                    ALARM_TIME = tempAlarmTime;
                else ALARM_TIME = DateTime.Now;
            }
            else
                ALARM_TIME = DateTime.Now;

            //ALARM THRESHOLD
            int tempAlarmThreshold = ALARM_THRESHOLD;

            if (_appSettings.Count > 0 && _appSettings.Contains("ALARMTHRESHOLD"))
            {
                if (_appSettings.TryGetValue<int>("ALARMTHRESHOLD", out tempAlarmThreshold))
                    ALARM_THRESHOLD = tempAlarmThreshold+1;//index + 1
                else ALARM_THRESHOLD = 4;
            }
            else
                ALARM_THRESHOLD = 4;

            //HAS ALARMED
            bool tempHasAlarmed = HASALARMED;

            if (_appSettings.Count > 0 && _appSettings.Contains("HASALARMED"))
            {
                if (_appSettings.TryGetValue<bool>("HASALARMED", out tempHasAlarmed))
                    HASALARMED = tempHasAlarmed;
                else HASALARMED = false;
            }
            else
                HASALARMED = false;

            //LEFTGLASSES
            int tempLeftGLasses = LEFTGLASSES;

            if (_appSettings.Count > 0 && _appSettings.Contains("LEFTGLASSES"))
            {
                if (_appSettings.TryGetValue<int>("LEFTGLASSES", out tempLeftGLasses))
                    LEFTGLASSES = tempLeftGLasses;
                else LEFTGLASSES = 8;
            }
            else
                LEFTGLASSES = 8;

        }
    }
}