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
    public partial class FormPettyCash : Form
    {
        string dataPassing;
        public FormPettyCash(string data)
        {
            InitializeComponent();
            this.dataPassing = data;

            timer1.Enabled = true;
            timer1.Interval = 1000;

            this.KeyPreview = true;
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            FormMainMenuMaster MM = new FormMainMenuMaster(lblUser.Text.Trim());
            this.Hide();
            this.Close();
            MM.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE WANT TO QUIT?", "QUIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void FormPettyCash_Load(object sender, EventArgs e)
        {
            lblUser.Text = dataPassing;
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void btnFullscreen_Click(object sender, EventArgs e)
        {

        }
    }
}
