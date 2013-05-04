using Clock.WinRT;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.Globalization.DateTimeFormatting;
using Windows.System.UserProfile;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace Clock.UIParts.HomeScreen
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    public sealed partial class HomePageView : Clock.Common.LayoutAwarePage
    {
        private const string TASKNAMEUSERPRESENT = "TileSchedulerTaskUserPresent_";
        private const string TASKNAMETIMER = "TileSchedulerTaskTimer_";
        private const string TASKENTRYPOINT = "Clock.WinRT.TileSchedulerTask";
        private readonly CultureInfo cultureInfo;

        private DispatcherTimer _timer;

        public HomePageView()
        {
            this.InitializeComponent();

            string language = GlobalizationPreferences.Languages.First();
            cultureInfo = new CultureInfo(language);

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(500);
            _timer.Tick += _timer_Tick;
        }



        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            try
            {
                _timer.Start();
                UpdateClockText();
                CreateClockTask();
            }
            catch (Exception e)
            {

            }
        }

        protected override void SaveState(Dictionary<string, object> pageState)
        {
            _timer.Stop();
            base.SaveState(pageState);
        }

        private void _timer_Tick(object sender, object e)
        {
            UpdateClockText();
        }

        private void UpdateClockText()
        {
            Clock.Text = DateTime.Now.ToString(cultureInfo.DateTimeFormat.FullDateTimePattern);
        }

        private static async void CreateClockTask()
        {
            var result = await BackgroundExecutionManager.RequestAccessAsync();
            if (result == BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity ||
                result == BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity)
            {
                ClockTileScheduler.CreateSchedule();

                EnsureUserPresentTask();
                EnsureTimerTask();
            }
        }

        private static void EnsureUserPresentTask()
        {
            foreach (var task in BackgroundTaskRegistration.AllTasks)
                if (task.Value.Name == TASKNAMEUSERPRESENT)
                    return;

            BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
            builder.Name = TASKNAMEUSERPRESENT;
            builder.TaskEntryPoint = TASKENTRYPOINT;
            builder.SetTrigger(new SystemTrigger(SystemTriggerType.UserPresent, false));
            builder.Register();
        }

        private static void EnsureTimerTask()
        {
            foreach (var task in BackgroundTaskRegistration.AllTasks)
                if (task.Value.Name == TASKNAMETIMER)
                    return;

            BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
            builder.Name = TASKNAMETIMER;
            builder.TaskEntryPoint = TASKENTRYPOINT;
            builder.SetTrigger(new TimeTrigger(180, false));
            builder.Register();
        }
    }
}
