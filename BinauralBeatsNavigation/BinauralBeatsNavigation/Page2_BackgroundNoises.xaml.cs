using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BinauralBeatsNavigation
{
    /// <summary>
    /// Page2_BackgroundNoises.xaml 的交互逻辑
    /// </summary>
    public partial class Page2_BackgroundNoises : Page
    {
        public Page2_BackgroundNoises()
        {
            InitializeComponent();
        }
        private void BackgroundNoiseTypeSetting(BinauralBeatsParameters.backgroundNoiseType currentBackgroundNoiseType)
        {
            Application.Current.Properties["currentBackgroundNoiseType"] = currentBackgroundNoiseType;
            this.NavigationService.Navigate(new Uri("Page4_PlayUI.xaml", UriKind.Relative));
        }
        private void noneBackgroundNoiseButton_Click(object sender, RoutedEventArgs e)
        {
            BackgroundNoiseTypeSetting(BinauralBeatsParameters.backgroundNoiseType.none);
        }

        private void autumnWindBackgroundNoisesButton_Click(object sender, RoutedEventArgs e)
        {
            BackgroundNoiseTypeSetting(BinauralBeatsParameters.backgroundNoiseType.autumnWind);

        }

        private void calmSeaBackgroundNoisesButton_Click(object sender, RoutedEventArgs e)
        {
            BackgroundNoiseTypeSetting(BinauralBeatsParameters.backgroundNoiseType.calmSea);

        }

        private void heavyRainBackgroundNoisesButton_Click(object sender, RoutedEventArgs e)
        {
            BackgroundNoiseTypeSetting(BinauralBeatsParameters.backgroundNoiseType.heavyRain);

        }

        private void hurricaneBackgroundNoisesButton_Click(object sender, RoutedEventArgs e)
        {
            BackgroundNoiseTypeSetting(BinauralBeatsParameters.backgroundNoiseType.hurricane);

        }

        private void rainForestBackgroundNoisesButton_Click(object sender, RoutedEventArgs e)
        {
            BackgroundNoiseTypeSetting(BinauralBeatsParameters.backgroundNoiseType.rainForest);

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
