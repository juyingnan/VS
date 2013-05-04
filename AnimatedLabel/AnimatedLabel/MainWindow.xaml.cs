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
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace AnimatedLabel
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation dblAnim = new DoubleAnimation();
            DoubleAnimation dblAnim2 = new DoubleAnimation();
            dblAnim.From = 40;
            dblAnim.To = 60;
            dblAnim.Duration = new Duration(TimeSpan.FromSeconds(1));
            dblAnim.FillBehavior=FillBehavior.Stop;
            label1.BeginAnimation(Label.HeightProperty, dblAnim);

            //Thread.Sleep(1000);

            //dblAnim2.From = 60;
            //dblAnim2.To = 40;
            //label1.BeginAnimation(Label.HeightProperty, dblAnim2);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation dblAnim = new DoubleAnimation();
            dblAnim.From = 1.0;
            dblAnim.To = 0.0;
            dblAnim.Duration = new Duration(TimeSpan.FromSeconds(2));
            label2.BeginAnimation(Label.OpacityProperty, dblAnim);

            dblAnim.From = 0.0;
            dblAnim.To = 1.0;
            label2.BeginAnimation(Label.OpacityProperty, dblAnim);
        }
    }
}