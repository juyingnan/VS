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

namespace PictureThis
{
    /// <summary>
    /// FullScreenWhite.xaml 的交互逻辑
    /// </summary>
    public partial class FullScreenWhite : Window
    {
        public FullScreenWhite()
        {
            InitializeComponent();
            CompositionTarget.Rendering += UpdateBorder;
        }

        public int endX { get; set; }
        public int endY { get; set; }
        public int beginX { get; set; }
        public int beginY { get; set; }
        Point mouseCurrentPosition;
        bool isMousePressed = false;
        

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            endX = (int)e.GetPosition(null).X;
            endY = (int)e.GetPosition(null).Y;
            DialogResult = true;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            beginX = (int)e.GetPosition(null).X;
            beginY = (int)e.GetPosition(null).Y;
            isMousePressed = true;
            Boarder.Margin = new Thickness(100, 100, 100, 100);
        }

        protected void UpdateBorder(object sender, EventArgs e)
        {
            if (isMousePressed == true)
            {
                Boarder.Width = mouseCurrentPosition.X - beginX;
                Boarder.Height = mouseCurrentPosition.Y - beginY;
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            mouseCurrentPosition = e.GetPosition((UIElement)sender);
        }
    }
}
