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
    public partial class ToolsTicTacToe : Form
    {

        //MUSIC
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();


        bool turn = true;
        int turn_count = 0;

        public ToolsTicTacToe()
        {
            InitializeComponent();


            player.SoundLocation = "Artemis.wav";
            player.Play();
            
            this.KeyPreview = true;
        }

        private void newGame()
        {
            turn = true;
            turn_count = 0;

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch
                {
                }
            }
        }

        private void ToolsTicTacToe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode==Keys.F5)
            {
                newGame();
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }

            turn = !turn;
            b.Enabled = false;
            turn_count ++;

            checkWinner();
        }

        private void checkWinner()
        {
            bool winner = false;
                // horizontal
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                winner = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                winner = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                winner = true;
            }

                // vertical
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                winner = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                winner = true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                winner = true;
            }

                // diagonal
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                winner = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
            {
                winner = true;
            }

            if (winner == true)
            {
                disableButtons();

                String winners = "";
                if (turn)
                {
                    winners = "O";
                    lblO.Text = (Int32.Parse(lblO.Text) + 1).ToString();
                }
                else
                {
                    winners = "X";
                    lblX.Text = (Int32.Parse(lblX.Text) + 1).ToString();
                }

                DialogResult dialogResult = MessageBox.Show(winners + " WINS! \n\n\n RESTART?", "GAME OVER!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.OK)
                {
                    newGame();
                }
            }
            else
            {
                if (turn_count == 9)
                {
                    lblDraw.Text = (Int32.Parse(lblDraw.Text) + 1).ToString();
                    DialogResult dialogResult = MessageBox.Show("DRAW! \n\n\n RESTART?", "GAME OVER!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.OK)
                    {
                        newGame();
                    }
                }
            }
           
        }

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                string Error = ex.ToString();
            }
        }

        private void btn_Enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
        }

        private void btn_Leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }
    }
}
