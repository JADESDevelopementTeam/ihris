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
using System.Data.SqlClient;

namespace BahteraAdhiguna
{
    public partial class FormLogin : Form
    {
        private SplashScreen splashScreen;
        private bool done = false;

        public FormLogin()
        {
            InitializeComponent(); 
            this.Load += new EventHandler(HandleFormLoad);
            this.splashScreen = new SplashScreen();
            this.KeyPreview = true;
        }

        private void HandleFormLoad(object sender, EventArgs e)
        {
            this.Hide();

            Thread thread = new Thread(new ThreadStart(this.ShowSplashScreen));
            thread.Start();

            Hardworker worker = new Hardworker();
            worker.ProgressChanged += (o, ex) =>
            {
                this.splashScreen.UpdateProgress(ex.Progress);
            };

            worker.HardWorkDone += (o, ex) =>
            {
                done = true;
                this.Show();
            };

            worker.DoHardWork();
        }

        private void ShowSplashScreen()
        {
            splashScreen.Show();
            while (!done)
            {
                Application.DoEvents();
            }
            splashScreen.Close();
            this.splashScreen.Dispose();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string uname = tbUsername.Text.Trim();
                string passwd = tbPassword.Text.Trim();

                if (uname == "" || passwd == "")
                {
                    MessageBox.Show("PLEASE INPUT USERNAME AND/OR PASSWORD", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbPassword.Clear();
                    tbUsername.Focus();
                }
                else
                {
                    Admin A = new Admin();
                    string[] values = A.Authentication(uname, passwd);

                    string dbUname = values[0];
                    string dbPsswd = values[1];
                    string dbLevel = values[2];

                    if (uname == dbUname && passwd == dbPsswd)
                    {
                        if (dbLevel == "Yes")
                        {
                            MessageBox.Show("WELCOME, " + uname + "", "WELCOME TO IHRIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FormMainMenuMaster MMM = new FormMainMenuMaster(uname);
                            this.Hide();
                            MMM.Show();
                        }
                        else
                        {
                            MessageBox.Show("WELCOME, " + uname + "", "WELCOME TO IHRIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FormUserMainMenu MM = new FormUserMainMenu(uname);
                            this.Hide();
                            MM.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("INCORRECT USERNAME AND/OR PASSWORD", "INCORRECT LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbPassword.Clear();
                        tbUsername.Focus();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE WANT TO QUIT?", "QUIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. MASUKAN USERNAME DAN PASSWORD ANDA"+
                            "\n    SESUAI DENGAN DATA DI DATABASE"+
                            "\n2. USERNAME MAKSIMAL 10 KARAKTER" +
                            "\n3. PASSWORD MAKSIMAL 10 KARAKTER" +
                            "\n4. FORM INI CASE-SENSITIVE"+
                            "\n5. JIKA ERROR TERJADI, HARAP LAPORKAN KE:" +
                            "\n    rezakisman@gmail.com / 0811 940 90 65"
                            , "HELP", MessageBoxButtons.OK, MessageBoxIcon.Question);

        }
        
        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("1. MASUKAN USERNAME DAN PASSWORD ANDA" +
                                            "\n    SESUAI DENGAN DATA DI DATABASE" +
                                            "\n2. USERNAME MAKSIMAL 10 KARAKTER" +
                                            "\n3. PASSWORD MAKSIMAL 10 KARAKTER" +
                                            "\n4. FORM INI CASE-SENSITIVE" +
                                            "\n5. JIKA ERROR TERJADI, HARAP LAPORKAN KE:" +
                                            "\n    rezakisman@gmail.com / 0811 940 90 65"
                                            , "HELP", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string uname = tbUsername.Text.Trim();
                    string passwd = tbPassword.Text.Trim();

                    if (uname == "" || passwd == "")
                    {
                        MessageBox.Show("PLEASE INPUT USERNAME AND/OR PASSWORD", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbPassword.Clear();
                        tbUsername.Focus();
                    }
                    else
                    {
                        Admin A = new Admin();
                        string[] values = A.Authentication(uname, passwd);

                        string dbUname = values[0];
                        string dbPsswd = values[1];
                        string dbLevel = values[2];

                        if (uname == dbUname && passwd == dbPsswd)
                        {
                            if (dbLevel == "Yes")
                            {
                                MessageBox.Show("WELCOME, " + uname + "", "WELCOME TO IHRIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                FormMainMenuMaster MMM = new FormMainMenuMaster(uname);
                                this.Hide();
                                MMM.Show();
                            }
                            else
                            {
                                MessageBox.Show("WELCOME, " + uname + "", "WELCOME TO IHRIS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                FormUserMainMenu MM = new FormUserMainMenu(uname);
                                this.Hide();
                                MM.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("INCORRECT USERNAME AND/OR PASSWORD", "INCORRECT LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tbPassword.Clear();
                            tbUsername.Focus();
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

                if (e.KeyCode == Keys.Escape)
                {
                    DialogResult dialogResult = MessageBox.Show("ARE YOU SURE WANT TO QUIT?", "QUIT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                        Application.Exit();
                    }
                }
            }
        }
    }
}
