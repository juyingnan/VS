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
    /// Page1_TypeSelection.xaml 的交互逻辑
    /// </summary>
    public partial class Page1_TypeSelection : Page
    {
        public Page1_TypeSelection()
        {
            InitializeComponent();
        }

        private void WaveTypeSetting(BinauralBeatsParameters.waveType currentWaveType)
        {
            Application.Current.Properties["currentWaveType"] = currentWaveType;
            this.NavigationService.Navigate(new Uri("Page2_BackgroundNoises.xaml", UriKind.Relative));
        }

        private void betaWaveButton_Click(object sender, RoutedEventArgs e)
        {
            WaveTypeSetting(BinauralBeatsParameters.waveType.betaWave);
        }


        private void alphaWaveButton_Click(object sender, RoutedEventArgs e)
        {
            WaveTypeSetting(BinauralBeatsParameters.waveType.alphaWave);
        }

        private void thetaWaveButton_Click(object sender, RoutedEventArgs e)
        {
            WaveTypeSetting(BinauralBeatsParameters.waveType.thetaWave);
        }

        private void deltaWaveButton_Click(object sender, RoutedEventArgs e)
        {
            WaveTypeSetting(BinauralBeatsParameters.waveType.deltaWave);
        }
    }
}
