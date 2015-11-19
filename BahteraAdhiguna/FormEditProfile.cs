using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BahteraAdhiguna
{
    public partial class FormEditProfile : Form
    {
        string dataPassing;
        public FormEditProfile(string data)
        {
            InitializeComponent(); 
            this.dataPassing = data;

            timer1.Enabled = true;
            timer1.Interval = 1000;

            this.KeyPreview = true;
        }

        private void FormEditProfile_Load(object sender, EventArgs e)
        {
            lblUser.Text = dataPassing;
            lblUsername.Text = dataPassing;
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            FormMainMenuMaster MM = new FormMainMenuMaster(lblUser.Text.Trim());
            this.Hide();
            this.Close();
            MM.Show();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("MAKE SURE YOUR PASSWORD IS EASY TO REMEMBER", "UPDATE PASSWORD?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (tbPassword.Text == "" || tbRepeat.Text == "")
                    {
                        MessageBox.Show("PLEASE INPUT PASSWORD AND/OR REPEAT THE PASSWORD", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbPassword.Clear();
                        tbRepeat.Clear();
                    }
                    else
                    {
                        if (tbPassword.Text == tbRepeat.Text)
                        {
                            Admin A = new Admin();
                            A.UpdatePassword(tbRepeat.Text, lblUsername.Text);
                            MessageBox.Show("PASSWORD UPDATED", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tbPassword.Clear();
                            tbRepeat.Clear();
                        }
                        else
                        {
                            tbPassword.Clear();
                            tbRepeat.Clear();
                            MessageBox.Show("PASSWORD MISSMATCH", "FAILED TO UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbPassword.Focus();
                        }
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("MICROSOFT SQL SERVER DATABASE ERROR!", "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("INVALID OPERATION!", "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. PASSWORD MAXIMUM 10 CHARACTERS" +
                            "\n2. THIS FORM IS CASE SENSITIVE" +
                            "\n3. SELECT MAIN MENU BUTTON TO BACK TO MAIN MENU" +
                            "\n4. USE EXIT BUTTON TO QUIT THE APPLICATION" +
                            "\n5. IF ERROR OCCURS PLEASE CONTACT US AT:" +
                            "\n    rezakisman@gmail.com / 0811 940 90 65"
                            , "HELP", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void FormEditProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("MAKE SURE YOUR PASSWORD IS EASY TO REMEMBER", "UPDATE PASSWORD?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (tbPassword.Text == "" || tbRepeat.Text == "")
                        {
                            MessageBox.Show("PLEASE INPUT PASSWORD AND/OR REPEAT THE PASSWORD", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tbPassword.Clear();
                            tbRepeat.Clear();
                        }
                        else
                        {
                            if (tbPassword.Text == tbRepeat.Text)
                            {
                                Admin A = new Admin();
                                A.UpdatePassword(tbRepeat.Text, lblUsername.Text);
                                MessageBox.Show("PASSWORD UPDATED", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tbPassword.Clear();
                                tbRepeat.Clear();
                            }
                            else
                            {
                                tbPassword.Clear();
                                tbRepeat.Clear();
                                MessageBox.Show("PASSWORD MISSMATCH", "FAILED TO UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbPassword.Focus();
                            }
                        }
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("MICROSOFT SQL SERVER DATABASE ERROR!", "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("INVALID OPERATION!", "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
