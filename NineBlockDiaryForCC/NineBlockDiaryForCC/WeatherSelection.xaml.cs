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
using System.Windows.Shapes;

namespace NineBlockDiaryForCC
{
    /// <summary>
    /// WeatherSelection.xaml 的交互逻辑
    /// </summary>
    public partial class WeatherSelection : Window
    {
        public WeatherSelection()
        {
            InitializeComponent();
        }

        public int weatherSelectResult = 0;

        private void rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Rectangle r = (Rectangle)sender;
            weatherSelectResult = int.Parse(r.Uid);
            this.Close();
        }
    }
}
