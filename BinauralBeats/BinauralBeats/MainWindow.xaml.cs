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
using System.Windows.Interop;

namespace BinauralBeats
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            leftWave.currentType = BinauralBeatsWaveOscillator.waveType.SineWave;
            leftWaveOut.Init(leftWave);
        }

        bool isPlaying = false;
        static int standardSampleRate = 44100;
        WaveOut leftWaveOut = new WaveOut();
        BinauralBeatsWaveOscillator leftWave = new BinauralBeatsWaveOscillator(standardSampleRate);

        private void SoundPlay(WaveOut waveOut, BinauralBeatsWaveOscillator wave, Polyline line, int leftFrequency, int rightFrequency, short amplitude)
        {
            double volumeGainFactor = 0.01;
            waveOut.Volume = (float)(amplitudeSlider.Value * volumeGainFactor);
            wave.LeftFrequency = leftFrequency;
            wave.RightFrequency = rightFrequency;
            wave.Amplitude = amplitude;
            waveOut.Play();
            waveGraphDrawing(line, wave, waveOut);
        }

        private void waveGraphDrawing(Polyline line, BinauralBeatsWaveOscillator wave, WaveOut waveOut)
        {
            line.Points.Clear();
            double halfCanvasActualHeight = waveGraphCanvas.ActualHeight / 2;
            double minusHalfCanvasActualHeight = halfCanvasActualHeight * (-1);
            for (int i = 0; i < waveGraphCanvas.ActualWidth; i++)
            {
                line.Points.Add(new Point(i, (double)wave.drawBuffer[2*i] / (double)wave.Amplitude * minusHalfCanvasActualHeight * waveOut.Volume + halfCanvasActualHeight));
            }
            waveTip.Text = string.Format("Current Wave: {0}\t Frequency: {1}\t Amplitude: {2}\t", wave.currentType, wave.LeftFrequency, (int)(wave.Amplitude * waveOut.Volume));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            isPlaying = false;
            leftWaveOut.Dispose();
        }

        private void amplitudeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double volumeGainFactor = 0.01;
            leftWaveOut.Volume = (float)(amplitudeSlider.Value * volumeGainFactor);
            waveGraphDrawing(waveGraph1, leftWave, leftWaveOut);
        }

        #region BUTTON ACTION
        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying == false)
            {
                int amplitudeGainFactor = 100;
                isPlaying = true;
                SoundPlay(leftWaveOut, leftWave, waveGraph1, 117,100, (short)(amplitudeSlider.Value * amplitudeGainFactor));
                playButton.IsEnabled = false;
                stopButton.IsEnabled = true;
            }
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                leftWaveOut.Stop();
                isPlaying = false;
                leftWave.reset();
                waveGraphDrawing(waveGraph1, leftWave, leftWaveOut);
                stopButton.IsEnabled = false;
                playButton.IsEnabled = true;
            }
        }


        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            helpWindow helpWindow1 = new helpWindow();
            helpWindow1.ShowDialog();
        }
        #endregion

        #region AEROGRASS
        //AEROGLASS
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            int windowsVistaVersion = 6;

            if (System.Environment.OSVersion.Version.Major >= windowsVistaVersion)
            {
                // This can't be done any earlier than the SourceInitialized event:
                GlassHelper.ExtendGlassFrame(this, new Thickness(-1));

                // Attach a window procedure in order to detect later enabling of desktop composition
                IntPtr hwnd = new WindowInteropHelper(this).Handle;
                HwndSource.FromHwnd(hwnd).AddHook(new HwndSourceHook(WndProc));
            }
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_DWMCOMPOSITIONCHANGED)
            {
                // Reenable glass:
                GlassHelper.ExtendGlassFrame(this, new Thickness(-1));
                handled = true;
            }
            return IntPtr.Zero;
        }
        private const int WM_DWMCOMPOSITIONCHANGED = 0x031E;
        #endregion

        private void waveGraphCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            waveGraphDrawing(waveGraph1, leftWave, leftWaveOut);
        }
    }
}
