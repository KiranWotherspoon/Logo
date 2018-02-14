using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Logo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //make sound effect play
            SoundPlayer player = new SoundPlayer(Properties.Resources.startSound);
            player.Play();
            Thread.Sleep(500); //sync up sound and visual

            //make button disappear
            playButton.Visible = false;

            //countdown starts
            countdownLabel.Visible = true;
            Refresh();
            Thread.Sleep(1000);
            countdownLabel.Text = "Game will start in: 2";
            Refresh();
            Thread.Sleep(1000);
            countdownLabel.Text = "Game will start in: 1";
            Refresh();
            Thread.Sleep(1000);

            //graphics set up
            countdownLabel.Visible = false;
            Refresh();
            Graphics fg = this.CreateGraphics();
            fg.Clear(Color.Green);

            //draw elipise in red
            SolidBrush drawBrush = new SolidBrush(Color.Red);
            fg.FillEllipse(drawBrush, 100, 90, 225, 150);

            //draw "Rams" in white in elipise
            drawBrush.Color = Color.White;
            Font ramsFont = new Font("Copperplate Gothic Bold", 22, FontStyle.Bold);
            fg.DrawString("RAMS", ramsFont, drawBrush, 175, 150);

            //draw C in front of Rams
            Pen drawPen = new Pen(Color.White, 10);
            fg.DrawArc(drawPen, 155, 130, 90, 70, 30, 300);

            //draw rotated string to right of elipise
            Font rotatedFont = new Font("DejaVu Serif", 8, FontStyle.Regular);
            fg.TranslateTransform(325, 210);
            fg.RotateTransform(270);
            fg.DrawString("RAMS Arcade", rotatedFont, drawBrush, new Rectangle());
        }
    }
}
