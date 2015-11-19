using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

namespace BahteraAdhiguna
{
    public partial class FormUserMainMenu : Form
    {
        string dataPassing;
        public FormUserMainMenu(string data)
        {
            InitializeComponent();
            this.dataPassing = data;

            timer1.Enabled = true;
            timer1.Interval = 1000;

            this.KeyPreview = true;
        }

        public void BindDetails()
        {
            try
            {
                string str = lblUser.Text;

                Admin Bind = new Admin();
                ArrayList data_emp = Bind.UserBindEmpDetails(str);

                if (data_emp.Count == 0)
                {
                    MessageBox.Show("NO DATA MATCH WITH DATABASE RECORDS", "NO DATA FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    for (int i = 0; i < data_emp.Count; i = i + 9)
                    {
                        string EmpNIP = (string)data_emp[i];
                        string EmpName = (string)data_emp[i + 1];
                        string EmpGender = (string)data_emp[i + 2];
                        string EmpDOB = (string)data_emp[i + 3];
                        string EmpEmail = (string)data_emp[i + 4];
                        string EmpPhone = (string)data_emp[i + 5];
                        string EmpPhoto = (string)data_emp[i + 6];
                        string DivID = (string)data_emp[i + 7];
                        string PosID = (string)data_emp[i + 8];

                        lblEmpNIP.Text = EmpNIP;
                        lblEmpName.Text = EmpName;
                        lblEmpGender.Text = EmpGender;
                        lblEmpDOB.Text = EmpDOB;
                        lblEmpEmail.Text = EmpEmail;
                        lblEmpPhone.Text = EmpPhone;

                        pbEmpPhoto.Image = Image.FromFile(@"D:\Important\Clients\PT Bahtera Adhiguna\Misc\Employee Photo\"+EmpPhoto+"");
                        pbEmpPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                        pbEmpPhoto.BorderStyle = BorderStyle.Fixed3D;

                        Admin BindSingleDiv = new Admin();
                        ArrayList data_singleDiv = BindSingleDiv.BindCBDivisionForEditAndSearchEmployeeForm(DivID);
                        for (int iD = 0; iD < data_singleDiv.Count; iD = iD + 2)
                        {
                            string CompletedDivID = (string)data_singleDiv[iD];
                            string CompletedDivName = (string)data_singleDiv[iD + 1];

                            lblEmpDivision.Text = CompletedDivID + ". " + CompletedDivName;
                        }

                        Admin BindSinglePos = new Admin();
                        ArrayList data_singlePos = BindSingleDiv.BindCBPositionForEditAndSearchEmployeeForm(PosID);
                        for (int iP = 0; iP < data_singlePos.Count; iP = iP + 2)
                        {
                            string CompletedPosID = (string)data_singlePos[iP];
                            string CompletedPosName = (string)data_singlePos[iP + 1];

                            lblEmpPosition.Text = CompletedPosID + ". " + CompletedPosName;
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


        private void FormUserMainMenu_Load(object sender, EventArgs e)
        {
            lblUser.Text = dataPassing;
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();

            BindDetails();
        }

        private void btnWeb_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("GO TO WEBSITE?", "VISIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("http://www.bahteradhiguna.co.id/");
            }
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

        private void btnReport_Click(object sender, EventArgs e)
        {
            About A = new About();
            A.ShowDialog();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("MINIMIZE THE FORM?", "MINIMIZE APPLICATION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                WindowState = FormWindowState.Minimized;

                niMinimized.BalloonTipText = "IHRIS RUNNING IN BACKGROUND";
                niMinimized.ShowBalloonTip(1000);
            }
        }

        private void niMinimized_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            MessageBox.Show("PRESS EXIT(ESC) BUTTON TO EXIT FULLSCREEN", "GOING FULLSCREEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormUserMainMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }

            if (e.KeyCode == Keys.F1)
            {
                //btnHelp
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

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
                        tbPassword.Focus();
                    }
                    else
                    {
                        if (tbPassword.Text == tbRepeat.Text)
                        {
                            Admin A = new Admin();
                            A.UpdatePassword(tbRepeat.Text, lblUser.Text);
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

        private void btnChangePhoto_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("UPDATE YOUR PROFILE PHOTO?", "UPDATE PROFILE PICTURE?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (tbEmpPhoto.Text == "")
                    {
                        MessageBox.Show("PLEASE SELECT THE PHOTO FIRST", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnBrowse.Focus();
                    }
                    else
                    {
                        Admin A = new Admin();
                        A.UserUpdatePhoto(tbEmpPhoto.Text, lblUser.Text);

                        MessageBox.Show("PROFILE PHOTO UPDATED", "UPDATE PHOTO SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindDetails();
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.InitialDirectory = "D:\\Important\\Clients\\PT Bahtera Adhiguna\\Misc\\";
                open.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|All Files (*.*)|*.*";
                open.Title = "SELECT EMPLOYEE PHOTOS";
                open.FilterIndex = 1;

                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (open.CheckFileExists)
                    {
                        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                        var random = new Random();
                        var result = new String(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());

                        string fileName = result + ".jpg";
                        System.IO.File.Copy(open.FileName, "D:\\Important\\Clients\\PT Bahtera Adhiguna\\Misc\\Employee Photo\\" + fileName);
                        tbEmpPhoto.Text = fileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
