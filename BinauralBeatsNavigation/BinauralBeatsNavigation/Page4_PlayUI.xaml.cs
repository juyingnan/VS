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
using NAudio.Wave;

namespace BinauralBeatsNavigation
{
    /// <summary>
    /// Page3_PlayUI.xaml 的交互逻辑
    /// </summary>
    public partial class Page3_PlayUI : Page
    {
        public Page3_PlayUI()
        {
            InitializeComponent();
            binauralBeatsWaveOut.Init(binauralBeatsWave);
            //temp
            binauralBeatsWave.LeftFrequency = 100;
            binauralBeatsWave.RightFrequency = 120;
        }


        bool isPlaying = false;
        static int standardSampleRate = 44100;
        WaveOut binauralBeatsWaveOut = new WaveOut();
        BinauralBeatsWaveOscillator binauralBeatsWave = new BinauralBeatsWaveOscillator(standardSampleRate);

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying == false)
            {
                isPlaying = true;
                SoundPlay();
            }
        }

        private void SoundPlay()
        {
            double volumeGainFactor = 0.01;
            binauralBeatsWaveOut.Volume = (float)(amplitudeSlider.Value * volumeGainFactor);
            binauralBeatsWave.Amplitude = 4096;
            binauralBeatsWaveOut.Play();
            waveGraphDrawing();
        }

        private void waveGraphDrawing()
        {
            leftWaveGraphLine.Points.Clear();
            rightWaveGraphLine.Points.Clear();
            double halfCanvasActualHeight = waveGraphCanvas.ActualHeight / 2;
            double minusHalfCanvasActualHeight = halfCanvasActualHeight * (-1);
            for (int i = 0; i < waveGraphCanvas.ActualWidth; i++)
            {
                leftWaveGraphLine.Points.Add(new Point(i, (double)binauralBeatsWave.drawBuffer[i * 2] / (double)binauralBeatsWave.Amplitude * minusHalfCanvasActualHeight * binauralBeatsWaveOut.Volume + halfCanvasActualHeight));
                rightWaveGraphLine.Points.Add(new Point(i, (double)binauralBeatsWave.drawBuffer[i * 2 + 1] / (double)binauralBeatsWave.Amplitude * minusHalfCanvasActualHeight * binauralBeatsWaveOut.Volume + halfCanvasActualHeight));
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            isPlaying = false;
            binauralBeatsWaveOut.Stop();
            binauralBeatsWaveOut.Dispose();
        }
    }
}
