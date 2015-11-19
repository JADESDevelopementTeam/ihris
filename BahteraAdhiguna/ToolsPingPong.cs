using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BahteraAdhiguna
{
    public partial class ToolsPingPong : Form
    {
        //MUSIC
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();


        //GAME
        public int speed_left = 2;
        public int speed_top = 2;
        public int points = 0;

        public ToolsPingPong()
        {
            InitializeComponent();

            this.KeyPreview = true;

            player.SoundLocation = "Artemis.wav";
            player.Play();


            timer1.Enabled = true;

            Cursor.Hide();

            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            pbRacket.Top = playground.Bottom - (playground.Bottom / 10);

            lblGameOver.Left = (playground.Width / 2) - (lblGameOver.Width / 2);
            lblGameOver.Top = (playground.Height / 2) - (lblGameOver.Height / 2);
            lblGameOver.Visible = false;
        }

        private void ToolsPingPong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                Cursor.Show();
            }
            if (e.KeyCode == Keys.F1)
            {
                pbBall.Top = 50;
                pbBall.Left = 50;
                speed_left = 2;
                speed_top = 2;
                points = 0;
                lblPoints.Text = "0";
                timer1.Enabled = true;
                lblGameOver.Visible = false;
                playground.BackColor = Color.White;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pbRacket.Left = Cursor.Position.X - (pbRacket.Width / 2);

            pbBall.Left += speed_left;
            pbBall.Top += speed_top;

            if (pbBall.Bottom >= pbRacket.Top && pbBall.Bottom <= pbRacket.Bottom && pbBall.Left >= pbRacket.Left && pbBall.Right <= pbRacket.Right)
            {
                speed_top += 1;
                speed_left += 1;
                speed_top = -speed_top;
                points += 10;
                lblPoints.Text = points.ToString();

                Random r = new Random();
                playground.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255));
            }

            if (pbBall.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }
            if (pbBall.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }
            if (pbBall.Top <= playground.Top)
            {
                speed_top = -speed_top;
            }
            if (pbBall.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false;
                lblGameOver.Visible = true;
            }
        }
    }
}
