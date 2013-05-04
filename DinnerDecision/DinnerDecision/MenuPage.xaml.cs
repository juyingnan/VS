using DinnerDecision.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Split Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234234

namespace DinnerDecision
{
    public sealed partial class MenuPage : DinnerDecision.Common.LayoutAwarePage
    {
        const string menu = "盖浇饭 砂锅 大排档 米线 满汉全席 西餐 麻辣烫 自助餐 炒面 快餐 水果 西北风 馄饨 火锅 烧烤 泡面 速冻水饺 日本料理 涮羊肉 味千拉面 肯德基 面包 扬州炒饭 自助餐 比萨 麦当劳 兰州拉面 沙县小吃 烤鱼 海鲜 铁板烧 韩国料理 粥";

        //GPS
        Geolocator myGeoLocator;

        //geo info
        double latitude = -1;
        double longitude = -1;
        double radius = 1000;

        public MenuPage()
        {
            this.InitializeComponent();
        }

        #region Page state management

        protected override async void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            await ReadFileToDiary();
        }

        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        #endregion

        #region Logical page navigation

        private bool UsingLogicalPageNavigation(ApplicationViewState? viewState = null)
        {
            if (viewState == null) viewState = ApplicationView.Value;
            return viewState == ApplicationViewState.FullScreenPortrait ||
                viewState == ApplicationViewState.Snapped;
        }

        protected override async void GoBack(object sender, RoutedEventArgs e)
        {
            base.GoBack(sender, e);
            await SaveDiaryToFile();
        }

        protected override string DetermineVisualState(ApplicationViewState viewState)
        {
            // Update the back button's enabled state when the view state changes
            var logicalPageBack = this.UsingLogicalPageNavigation(viewState);
            var physicalPageBack = this.Frame != null && this.Frame.CanGoBack;
            this.DefaultViewModel["CanGoBack"] = logicalPageBack || physicalPageBack;

            // Determine visual states for landscape layouts based not on the view state, but
            // on the width of the window.  This page has one layout that is appropriate for
            // 1366 virtual pixels or wider, and another for narrower displays or when a snapped
            // application reduces the horizontal space available to less than 1366.
            if (viewState == ApplicationViewState.Filled ||
                viewState == ApplicationViewState.FullScreenLandscape)
            {
                var windowWidth = Window.Current.Bounds.Width;
                if (windowWidth >= 1366) return "FullScreenLandscapeOrWide";
                return "FilledOrNarrow";
            }

            // When in portrait or snapped start with the default visual state name, then add a
            // suffix when viewing details instead of the list
            var defaultStateName = base.DetermineVisualState(viewState);
            return logicalPageBack ? defaultStateName + "_Detail" : defaultStateName;
        }

        #endregion

        #region FILE READ AND WRITE
        private async Task ReadFileToDiary()
        {
            try
            {
                // settings  
                var _Name = "Menu";
                var _Folder = Windows.Storage.ApplicationData.Current.RoamingFolder;

                // acquire file  
                var _File = await _Folder.GetFileAsync(_Name);

                // read content  
                var _ReadThis = await Windows.Storage.FileIO.ReadTextAsync(_File);

                //菜单显示
                MenuTextBox.Text = _ReadThis;
            }
            catch (Exception)
            {
                //菜单显示默认
                MenuTextBox.Text = menu;
            }
        }


        private async Task SaveDiaryToFile()
        {
            // settings  
            var _Name = "Menu";
            var _Folder = Windows.Storage.ApplicationData.Current.RoamingFolder;
            var _Option = Windows.Storage.CreationCollisionOption.ReplaceExisting;

            try
            {
                // create file   
                var _File = await _Folder.CreateFileAsync(_Name, _Option);

                // write content  
                await Windows.Storage.FileIO.WriteTextAsync(_File, MenuTextBox.Text);
                //菜单设置
                Menu.Set(MenuTextBox.Text);
            }
            catch (Exception)
            {
                //菜单设置默认
                Menu.Set(MenuTextBox.Text);
            }
        }
        #endregion

        private async void GPSGetButton_Click(object sender, RoutedEventArgs e)
        {
            myGeoLocator = new Geolocator();
            myGeoLocator.DesiredAccuracy = PositionAccuracy.High;
            myGeoLocator.MovementThreshold = 500;

            GPSWaitingProgressRing.IsActive = true;

            try
            {
                Geoposition position = await myGeoLocator.GetGeopositionAsync(maximumAge: TimeSpan.FromMinutes(1), timeout: TimeSpan.FromSeconds(30));
                locationTextBlock.Text = "Location: ";
                locationTextBlock.Text += this.GetCoordinateString(position.Coordinate);
            }
            catch (UnauthorizedAccessException)
            {
                locationTextBlock.Text = "定位功能在Windows设置中被禁用";
                longitude = -1;
                latitude = -1;
            }
            catch (Exception ex)
            {
                locationTextBlock.Text = ex.Message;
                longitude = -1;
                latitude = -1;
            }
            finally
            {            
                myGeoLocator = null;
                GetRestaurant(latitude, longitude, radius);
            }
        }

        private void GetRestaurant(double lat, double lon, double r)
        {
            try
            {
                if (lat != -1 && lon != -1)
                {
                    AzureService.TestSoapClient proxy = new AzureService.TestSoapClient();
                    Task<AzureService.GetRestaurantResponse> response = proxy.GetRestaurantAsync(lat, lon, r);
                    String result = response.Result.Body.GetRestaurantResult;
                    if (result.Trim() != "-1" && result.Trim() != "")
                        MenuTextBox.Text = result;
                    else
                        MenuTextBox.Text = "西北风";
                }
            }
            catch (Exception ex)
            {
                locationTextBlock.Text = ex.Message;
            }
            finally { GPSWaitingProgressRing.IsActive = false; }
        }


        private string GetCoordinateString(Geocoordinate geocoordinate)
        {
            string positionString = string.Format("纬度: {0:0.0000}, 经度: {1:0.0000}, 误差: {2}m",
                 geocoordinate.Latitude, geocoordinate.Longitude, geocoordinate.Accuracy);
            latitude = geocoordinate.Latitude;
            longitude = geocoordinate.Longitude;
            return positionString;
        }
    }
}
