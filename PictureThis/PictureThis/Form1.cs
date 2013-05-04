using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;

namespace PictureThis
{
    public partial class prtScrWindow : Form
    {
        public prtScrWindow()
        {
            InitializeComponent();
            g = CreateGraphics();
            CompositionTarget.Rendering += UpdateBorder;
            //screenJudge();
        }

        private void screenJudge()
        {
            Screen[] allScreens = Screen.AllScreens;
            Screen currentScreen = Screen.FromRectangle(this.DisplayRectangle);
            bool isSecondScreen = false;
            if (allScreens.Length == 2)
            {
                foreach (Screen scr in allScreens)
                {
                    if ((scr == currentScreen) && (scr != Screen.PrimaryScreen))
                    {
                        isSecondScreen = true;
                    }
                }
            }
        }

        public int endX { get; set; }
        public int endY { get; set; }
        public int beginX { get; set; }
        public int beginY { get; set; }
        Point mouseCurrentPosition;
        public bool isMousePressed = false;
        public bool isPrtScrFinished = false;
        public int updateCounter = 0;
        Graphics g;

        private void prtScrWindow_MouseDown(object sender, MouseEventArgs e)
        {
            beginX = (int)e.Location.X;
            beginY = (int)e.Location.Y;
            isMousePressed = true;
        }

        private void prtScrWindow_MouseUp(object sender, MouseEventArgs e)
        {
            isMousePressed = false;
            endX = (int)(int)e.Location.X;
            endY = (int)e.Location.Y;
            isPrtScrFinished = true;

            GC.Collect(2);
            GC.WaitForPendingFinalizers();

            DialogResult = DialogResult.OK;
        }

        protected void UpdateBorder(object sender, EventArgs e)
        {
            if (isMousePressed == true)
            {
                if (updateCounter >= 3)
                {
                    g.Clear(BackColor);
                    g.FillRectangle(System.Drawing.Brushes.Black,
                        mouseCurrentPosition.X <= beginX ? mouseCurrentPosition.X : beginX,
                        mouseCurrentPosition.Y <= beginY ? mouseCurrentPosition.Y : beginY,
                        Math.Abs(mouseCurrentPosition.X - beginX),
                        Math.Abs(mouseCurrentPosition.Y - beginY));
                    updateCounter = 0;
                }
                updateCounter++;
            }
        }

        private void prtScrWindow_MouseMove(object sender, MouseEventArgs e)
        {
            mouseCurrentPosition = e.Location;
        }        

        private void prtScrWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

    }
}
