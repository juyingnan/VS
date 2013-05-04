using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using Windows.ApplicationModel.Background;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using TimeDefination;
using BackgroundTask;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BinaryClock
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public BinaryTime BTime = new BinaryTime(DateTime.Now);

        //后台任务参数
        private const string TASKNAMEUSERPRESENT = "TileSchedulerTaskUserPresent";
        private const string TASKNAMETIMER = "TileSchedulerTaskTimer";
        private const string TASKENTRYPOINT = "BackgroundTask.TileSchedulerTask";
        
        public MainPage()
        {
            this.InitializeComponent();
            
            //上下文设定，绑定数据用
            DataContext = BTime;
            //VisualState
            Window.Current.SizeChanged += WindowSizeChanged;
            Loaded += LayoutAwarePage_Loaded;
        }       
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                BTime.Timer_Start();
                CreateClockTask();
            }
            catch (Exception)
            {
                //do nothing
            }
        }        

        private static async void CreateClockTask()
        {
            var result = await BackgroundExecutionManager.RequestAccessAsync();
            if (result == BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity || result == BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity)
            {
                BackgroundTask.ClockTileScheduler.CreateSchedule();
                EnsureUserPresentTask();
                EnsureTimerTask();
            }
        }

        private static void EnsureTimerTask()
        {
            foreach (var task in BackgroundTaskRegistration.AllTasks)
                if (task.Value.Name == TASKNAMETIMER)
                {
                    return;
                }

            BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
            builder.Name = TASKNAMETIMER;
            builder.TaskEntryPoint = TASKENTRYPOINT;
            //builder.SetTrigger(new TimeTrigger(180, false));
            builder.SetTrigger(new TimeTrigger(15, false));
            builder.Register();
        }

        private static void EnsureUserPresentTask()
        {
            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                if (task.Value.Name == TASKNAMEUSERPRESENT)
                {
                    return;
                }
            }

            BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
            builder.Name = TASKNAMEUSERPRESENT;
            builder.TaskEntryPoint = TASKENTRYPOINT;
            builder.SetTrigger(new SystemTrigger(SystemTriggerType.UserPresent, false));
            builder.Register();
        }

        private void LayoutAwarePage_Loaded(object sender, RoutedEventArgs e)
        {
            SetVisualState();
        }

        private void WindowSizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            SetVisualState();
        }

        //界面状态管理
        private void SetVisualState()
        {
            string viewValue = ApplicationView.Value.ToString();
            VisualStateManager.GoToState(this, viewValue, false);
        }
    }
}
