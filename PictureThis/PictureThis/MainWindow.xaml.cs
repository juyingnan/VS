using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows.Media.Animation;

#region remark 
/*缩放
双屏
垃圾
框，移，尺，确
*/
#endregion

namespace PictureThis
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AnimationInitialize();
        }

        int defaultImageSizeX = 0;
        int defaultImageSizeY = 0;

        private void AnimationInitialize()
        {
            DoubleAnimation backgroundAnimation = new DoubleAnimation();
            backgroundAnimation.From = 0;
            backgroundAnimation.To = 1;
            backgroundAnimation.Duration = TimeSpan.FromSeconds(2);
            backgroundAnimation.AutoReverse = true;
            backgroundAnimation.RepeatBehavior = RepeatBehavior.Forever;
            reference1.BeginAnimation(GradientStop.OffsetProperty, backgroundAnimation);
        }

        private void prtScrButton_Click(object sender, RoutedEventArgs e)
        {
            int leftTopX = 0;
            int leftTopY = 0;
            int rightBottomX = 0;
            int rightBottomY = 0;

            this.Hide();
            prtScrWindow fullScreenWhite = new prtScrWindow();
            fullScreenWhite.ShowDialog();


            if (fullScreenWhite.isPrtScrFinished == true)
            {
                leftTopX = fullScreenWhite.beginX <= fullScreenWhite.endX ? fullScreenWhite.beginX : fullScreenWhite.endX;
                leftTopY = fullScreenWhite.beginY <= fullScreenWhite.endY ? fullScreenWhite.beginY : fullScreenWhite.endY;
                rightBottomX = fullScreenWhite.beginX <= fullScreenWhite.endX ? fullScreenWhite.endX : fullScreenWhite.beginX;
                rightBottomY = fullScreenWhite.beginY <= fullScreenWhite.endY ? fullScreenWhite.endY : fullScreenWhite.beginY;
                fullScreenWhite.Close();
                GC.Collect(2);
                GC.WaitForPendingFinalizers();

                if (leftTopX == rightBottomX && leftTopY == rightBottomY)
                {
                    leftTopX = 0;
                    leftTopY = 0;
                    rightBottomX = (int)SystemParameters.PrimaryScreenWidth;
                    rightBottomY = (int)SystemParameters.PrimaryScreenHeight;
                }
                statusText.Text = leftTopX.ToString() + "," + leftTopY.ToString() + "  " + rightBottomX.ToString() + "," + rightBottomY.ToString();
                printScreen(leftTopX, leftTopY, rightBottomX, rightBottomY);
                SetWindowSize(rightBottomX - leftTopX, rightBottomY - leftTopY);
            }

            this.Show();
        }

        private void SetWindowSize(int p, int p_2)
        {
            defaultImageSizeX = p;
            defaultImageSizeY = p_2;
            int defaultHeightBlank = 104;
            int defaultWidthBlank = 18;
            this.Width = p + defaultWidthBlank;
            this.Height = p_2 + defaultHeightBlank;
        }

        private void printScreen(int leftTopX, int leftTopY, int rightBottomX, int rightBottomY)
        {
            Bitmap bitmap = new Bitmap(rightBottomX - leftTopX, rightBottomY - leftTopY, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(leftTopX, leftTopY, 0, 0,
                    new System.Drawing.Rectangle(leftTopX, leftTopY, rightBottomX - leftTopX, rightBottomY - leftTopY).Size,
                    CopyPixelOperation.SourceCopy);
            }

            prtScrImage.Source = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            prtScrImage.Source = null;
            SetWindowSize(0, 0);
            statusText.Text = "Ready";
            GC.Collect(2);
            GC.WaitForPendingFinalizers();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (prtScrImage.Source != null)
            {
                Microsoft.Win32.SaveFileDialog pictureSaveDialog = new Microsoft.Win32.SaveFileDialog();
                pictureSaveDialog.DefaultExt = ".png";
                pictureSaveDialog.Filter = "PNG (.png)|*.png";

                //show saveDialog
                Nullable<bool> result = pictureSaveDialog.ShowDialog();

                //wait the result
                if (result == true && pictureSaveDialog.FileName != "")
                {
                    using (FileStream stream = new FileStream(pictureSaveDialog.FileName, FileMode.Create))
                    {
                        PngBitmapEncoder encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create((BitmapSource)prtScrImage.Source));
                        encoder.Save(stream);
                    }
                }
            }
            else
            {
                MessageBox.Show("No picture can be saved.", "Error");
            }
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            if (prtScrImage.Source != null)
            {
                Clipboard.SetImage((BitmapSource)prtScrImage.Source);
            }
            else
            {
                MessageBox.Show("No picture can be copied.", "Error");
            }
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (onTopButton.IsChecked != null)
            {
                this.Topmost = (bool)onTopButton.IsChecked;
            }
        }

        private void returnOptimalSizeButton_Click(object sender, RoutedEventArgs e)
        {
            SetWindowSize(defaultImageSizeX, defaultImageSizeY);
        }
    }
}
