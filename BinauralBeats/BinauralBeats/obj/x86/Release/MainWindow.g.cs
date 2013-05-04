﻿#pragma checksum "..\..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D1013C5A6794A80D42CEA72DD5E747BF"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.1
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using BinauralBeats;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace BinauralBeats {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Canvas waveGraphCanvas;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\MainWindow.xaml"
        internal System.Windows.Shapes.Polyline waveGraph1;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\MainWindow.xaml"
        internal System.Windows.Shapes.Polyline waveGraph2;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.TextBlock waveTip;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Button playButton;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Button stopButton;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Slider amplitudeSlider;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Slider frequencySlider;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.TextBox frequencyInputTextBox;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Primitives.ToggleButton sineWaveButton;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Primitives.ToggleButton triangleWaveButton;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Primitives.ToggleButton rectangleWaveButton;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Primitives.ToggleButton pinkNoiseButton;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Button helpButton;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Expander sweepFrequencyModeExpander;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.CheckBox sweepFrequencyModeCheckBox;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.TextBox minSweepFrequencyTextBox;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.TextBox maxSweepFrequencyTextBox;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Slider sweepFrequencySpeedSlider;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WaveGenerator;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 5 "..\..\..\MainWindow.xaml"
            ((BinauralBeats.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.waveGraphCanvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 30 "..\..\..\MainWindow.xaml"
            this.waveGraphCanvas.SizeChanged += new System.Windows.SizeChangedEventHandler(this.waveGraphCanvas_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.waveGraph1 = ((System.Windows.Shapes.Polyline)(target));
            return;
            case 4:
            this.waveGraph2 = ((System.Windows.Shapes.Polyline)(target));
            return;
            case 5:
            this.waveTip = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.playButton = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\MainWindow.xaml"
            this.playButton.Click += new System.Windows.RoutedEventHandler(this.playButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.stopButton = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\MainWindow.xaml"
            this.stopButton.Click += new System.Windows.RoutedEventHandler(this.stopButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.amplitudeSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 75 "..\..\..\MainWindow.xaml"
            this.amplitudeSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.amplitudeSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.frequencySlider = ((System.Windows.Controls.Slider)(target));
            
            #line 82 "..\..\..\MainWindow.xaml"
            this.frequencySlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.frequencySlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.frequencyInputTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.sineWaveButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 101 "..\..\..\MainWindow.xaml"
            this.sineWaveButton.Click += new System.Windows.RoutedEventHandler(this.sineWaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.triangleWaveButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 102 "..\..\..\MainWindow.xaml"
            this.triangleWaveButton.Click += new System.Windows.RoutedEventHandler(this.triangleWaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.rectangleWaveButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 103 "..\..\..\MainWindow.xaml"
            this.rectangleWaveButton.Click += new System.Windows.RoutedEventHandler(this.rectangleWaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.pinkNoiseButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 104 "..\..\..\MainWindow.xaml"
            this.pinkNoiseButton.Click += new System.Windows.RoutedEventHandler(this.pinkNoiseButton_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.helpButton = ((System.Windows.Controls.Button)(target));
            
            #line 108 "..\..\..\MainWindow.xaml"
            this.helpButton.Click += new System.Windows.RoutedEventHandler(this.helpButton_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.sweepFrequencyModeExpander = ((System.Windows.Controls.Expander)(target));
            return;
            case 17:
            this.sweepFrequencyModeCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 115 "..\..\..\MainWindow.xaml"
            this.sweepFrequencyModeCheckBox.Checked += new System.Windows.RoutedEventHandler(this.sweepFrequencyModeCheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 115 "..\..\..\MainWindow.xaml"
            this.sweepFrequencyModeCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.sweepFrequencyModeCheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 18:
            this.minSweepFrequencyTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 117 "..\..\..\MainWindow.xaml"
            this.minSweepFrequencyTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.minSweepFrequencyTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 19:
            this.maxSweepFrequencyTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 119 "..\..\..\MainWindow.xaml"
            this.maxSweepFrequencyTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.maxSweepFrequencyTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 20:
            this.sweepFrequencySpeedSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 123 "..\..\..\MainWindow.xaml"
            this.sweepFrequencySpeedSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.sweepFrequencySpeedSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
