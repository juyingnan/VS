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
using System.Windows.Threading;

namespace WaveGenerator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            timerInitialize();
        }

        private void timerInitialize()
        {
            sweepFrequencyModeTimer.Tick += new EventHandler(sweepFrequencyModeTimer_Tick);
            sweepFrequencyModeTimer.Interval = TimeSpan.FromMilliseconds(sweepFrequencyModeTimeSpan);
            sweepFrequencyModeLastTimer.Tick+=new EventHandler(sweepFrequencyModeLastTimer_Tick);
            sweepFrequencyModeLastTimer.Interval = TimeSpan.FromHours(sweepFrequencyModeLastTimeSpan);
            sweepFrequencyModePauseTimer.Tick+=new EventHandler(sweepFrequencyModePauseTimer_Tick);
            sweepFrequencyModePauseTimer.Interval = TimeSpan.FromMinutes(sweepFrequencyModePauseTimeSpan);
            sweepFrequencyModePauseTimer.IsEnabled = false;
            sweepFrequencyModeLastTimer.IsEnabled = false;
        }

        bool isPlaying = false;
        static int standardSampleRate = 44100;
        WaveOut defaultWaveOut = new WaveOut();
        WaveOscillator defaultWave = new WaveOscillator(standardSampleRate);
        sweepFrequencyModeParameters SweepFrequency = new sweepFrequencyModeParameters();
        DispatcherTimer sweepFrequencyModeTimer = new DispatcherTimer();
        int sweepFrequencyModeTimeSpan = 100;
        DispatcherTimer sweepFrequencyModeLastTimer = new DispatcherTimer();
        int sweepFrequencyModeLastTimeSpan = 2; 
        DispatcherTimer sweepFrequencyModePauseTimer = new DispatcherTimer();
        int sweepFrequencyModePauseTimeSpan = 10;



        private int frequencyValidate(string p)
        {
            int returnValue = 0;
            int defaultReturnValue = 1000;
            if (int.TryParse(p, out returnValue))
            {
                frequencyInputTextBox.Text = returnValue.ToString();
                return returnValue;
            }
            else
            {
                frequencyInputTextBox.Text = defaultReturnValue.ToString();
                return defaultReturnValue;
            }
        }

        private void SoundPlay(int frequency, short amplitude)
        {
            double volumeGainFactor = 0.01;
            defaultWaveOut.Volume = (float)(amplitudeSlider.Value * volumeGainFactor);
            defaultWave.Frequency = frequency;
            defaultWave.Amplitude = amplitude;
            defaultWaveOut.Init(defaultWave);
            defaultWaveOut.Play();
            waveGraphDrawing(waveGraph1,defaultWave,defaultWaveOut);
        }

        private void waveGraphDrawing(Polyline line, WaveOscillator wave, WaveOut waveOut)
        {
            line.Points.Clear();
            double halfCanvasActualHeight = waveGraphCanvas.ActualHeight / 2;
            double minusHalfCanvasActualHeight = halfCanvasActualHeight * (-1);
            for (int i = 0; i < waveGraphCanvas.ActualWidth; i++)
            {
                line.Points.Add(new Point(i, (double)wave.drawBuffer[i] / (double)wave.Amplitude * minusHalfCanvasActualHeight * waveOut.Volume + halfCanvasActualHeight));
            }
            waveTip.Text = string.Format("Current Wave: {0}\t Frequency: {1}\t Amplitude: {2}\t", wave.currentType, wave.Frequency, (int)(wave.Amplitude * waveOut.Volume));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            isPlaying = false;
            defaultWaveOut.Dispose();
        }

        private void frequencySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            defaultWave.Frequency = (int)Math.Pow(10, frequencySlider.Value);
            waveGraphDrawing(waveGraph1, defaultWave, defaultWaveOut);
        }

        private void amplitudeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double volumeGainFactor = 0.01;
            defaultWaveOut.Volume = (float)(amplitudeSlider.Value * volumeGainFactor);
            waveGraphDrawing(waveGraph1, defaultWave, defaultWaveOut);
        }

        #region BUTTON ACTION
        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying == false)
            {
                int amplitudeGainFactor = 100;
                isPlaying = true;
                SoundPlay(frequencyValidate(frequencyInputTextBox.Text), (short)(amplitudeSlider.Value * amplitudeGainFactor));
                playButton.IsEnabled = false;
                stopButton.IsEnabled = true;
            }
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                defaultWaveOut.Stop();
                isPlaying = false;
                defaultWave.reset();
                waveGraphDrawing(waveGraph1, defaultWave, defaultWaveOut);
                stopButton.IsEnabled = false;
                playButton.IsEnabled = true;
            }
        }

        private void sineWaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (sineWaveButton.IsChecked == true)
            {
                defaultWave.currentType = WaveOscillator.waveType.SineWave;
                triangleWaveButton.IsChecked = false;
                rectangleWaveButton.IsChecked = false;
                pinkNoiseButton.IsChecked = false;
            }
            else
            {
                defaultWave.currentType = WaveOscillator.waveType.zero;
            }
        }

        private void triangleWaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (triangleWaveButton.IsChecked == true)
            {
                defaultWave.currentType = WaveOscillator.waveType.triangleWave;
                sineWaveButton.IsChecked = false;
                rectangleWaveButton.IsChecked = false;
                pinkNoiseButton.IsChecked = false;
            }
            else
            {
                defaultWave.currentType = WaveOscillator.waveType.zero;
            }
        }

        private void rectangleWaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (rectangleWaveButton.IsChecked == true)
            {
                defaultWave.currentType = WaveOscillator.waveType.rectangleWave;
                sineWaveButton.IsChecked = false;
                triangleWaveButton.IsChecked = false;
                pinkNoiseButton.IsChecked = false;
            }
            else
            {
                defaultWave.currentType = WaveOscillator.waveType.zero;
            }
        }

        private void pinkNoiseButton_Click(object sender, RoutedEventArgs e)
        {
            if (pinkNoiseButton.IsChecked == true)
            {
                defaultWave.currentType = WaveOscillator.waveType.whiteNoiseWave;
                sineWaveButton.IsChecked = false;
                triangleWaveButton.IsChecked = false;
                rectangleWaveButton.IsChecked = false;
            }
            else
            {
                defaultWave.currentType = WaveOscillator.waveType.zero;
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
            waveGraphDrawing(waveGraph1, defaultWave, defaultWaveOut);
        }

        private void sweepFrequencyModeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SweepFrequency.isSweepFrequencyModeOn = true;
            sweepFrequencyModeTimer.IsEnabled = SweepFrequency.isSweepFrequencyModeOn;
            sweepFrequencyModeLastTimer.IsEnabled=SweepFrequency.isSweepFrequencyModeOn;
        }

        private void sweepFrequencyModeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            SweepFrequency.isSweepFrequencyModeOn = false;
            sweepFrequencyModeTimer.IsEnabled = SweepFrequency.isSweepFrequencyModeOn;
            sweepFrequencyModeLastTimer.IsEnabled = SweepFrequency.isSweepFrequencyModeOn;
            sweepFrequencyModePauseTimer.IsEnabled = SweepFrequency.isSweepFrequencyModeOn;
        }

        void sweepFrequencyModeTimer_Tick(object sender, EventArgs e)
        {
            if (SweepFrequency.isSweepFrequencyModeOn && isPlaying)
            {
                minSweepFrequencyTextBox.Text = SweepFrequency.MinFrequency.ToString();
                maxSweepFrequencyTextBox.Text = SweepFrequency.MaxFrequency.ToString();
                SweepFrequency.CurrentFrequency = defaultWave.Frequency;
                SweepFrequency.CurrentFrequency += Math.Ceiling(Math.Abs(SweepFrequency.MaxFrequency - SweepFrequency.MinFrequency) * (double)SweepFrequency.SweepFrequencySpeed / 18000) * (SweepFrequency.isSweepFrequencyPlus ? 1 : -1);
                defaultWave.Frequency = SweepFrequency.CurrentFrequency;
                frequencyInputTextBox.Text = defaultWave.Frequency.ToString();
                waveGraphDrawing(waveGraph1, defaultWave, defaultWaveOut);
            }
        }

        void sweepFrequencyModeLastTimer_Tick(object sender, EventArgs e)
        {
            defaultWaveOut.Pause();
            sweepFrequencyModePauseTimer.IsEnabled = true;
            sweepFrequencyModeLastTimer.IsEnabled = false;
        }

        void sweepFrequencyModePauseTimer_Tick(object sender, EventArgs e)
        {
            defaultWaveOut.Play();
            sweepFrequencyModeLastTimer.IsEnabled = true;
            sweepFrequencyModePauseTimer.IsEnabled = false;
        }



        private void minSweepFrequencyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int minFrequency;
            if (!int.TryParse(minSweepFrequencyTextBox.Text, out minFrequency))
            {
                minFrequency = 20;
            }
            SweepFrequency.MinFrequency = minFrequency;
        }

        private void maxSweepFrequencyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int maxFrequency;
            if (!int.TryParse(maxSweepFrequencyTextBox.Text, out maxFrequency))
            {
                maxFrequency = 20000;
            }
            SweepFrequency.MaxFrequency = maxFrequency;
        }

        private void sweepFrequencySpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SweepFrequency.SweepFrequencySpeed = (int)sweepFrequencySpeedSlider.Value;
        }
    }
}
