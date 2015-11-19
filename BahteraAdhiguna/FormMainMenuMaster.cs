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

namespace BahteraAdhiguna
{
    public partial class FormMainMenuMaster : Form
    {
        string dataPassing;
        public FormMainMenuMaster(string data)
        {
            InitializeComponent();
            this.dataPassing = data;

            btnAttendance.Visible = false;
            btnPayroll.Visible = false;
            btnEmployee.Visible = false;
            btnEmployeeMenu.Visible = true;

            timer1.Enabled = true;
            timer1.Interval = 1000;

            this.KeyPreview = true;
        }

        private void FormMainMenuMaster_Load(object sender, EventArgs e)
        {
            lblUser.Text = dataPassing;
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();

            Admin CheckContract = new Admin();

            ArrayList data_contract = CheckContract.CheckContractExpiration();

            for (int i = 0; i < data_contract.Count; i = i + 2)
            {
                string ContractNumber = (string)data_contract[i];
                string ContractEndDate = (string)data_contract[i + 1];

                string TodayDate = DateTime.Today.ToShortDateString();
                string Date1 = DateTime.Today.AddDays(-1).ToShortDateString();
                string Date2 = DateTime.Today.AddDays(-2).ToShortDateString();
                string Date3 = DateTime.Today.AddDays(-3).ToShortDateString();
                string Date4 = DateTime.Today.AddDays(-4).ToShortDateString();
                string Date5 = DateTime.Today.AddDays(-5).ToShortDateString();
                string Date6 = DateTime.Today.AddDays(-6).ToShortDateString();
                string Date7 = DateTime.Today.AddDays(-7).ToShortDateString();
                string Date8 = DateTime.Today.AddDays(-8).ToShortDateString();
                string Date9 = DateTime.Today.AddDays(-9).ToShortDateString();
                string Date10 = DateTime.Today.AddDays(-10).ToShortDateString();
                string Date11 = DateTime.Today.AddDays(-11).ToShortDateString();
                string Date12 = DateTime.Today.AddDays(-12).ToShortDateString();
                string Date13 = DateTime.Today.AddDays(-13).ToShortDateString();
                string Date14 = DateTime.Today.AddDays(-14).ToShortDateString();
                string Date15 = DateTime.Today.AddDays(-15).ToShortDateString();
                string Date16 = DateTime.Today.AddDays(-16).ToShortDateString();
                string Date17 = DateTime.Today.AddDays(-17).ToShortDateString();
                string Date18 = DateTime.Today.AddDays(-18).ToShortDateString();
                string Date19 = DateTime.Today.AddDays(-19).ToShortDateString();
                string Date20 = DateTime.Today.AddDays(-20).ToShortDateString();
                string Date21 = DateTime.Today.AddDays(-21).ToShortDateString();
                string Date22 = DateTime.Today.AddDays(-22).ToShortDateString();
                string Date23 = DateTime.Today.AddDays(-23).ToShortDateString();
                string Date24 = DateTime.Today.AddDays(-24).ToShortDateString();
                string Date25 = DateTime.Today.AddDays(-25).ToShortDateString();
                string Date26 = DateTime.Today.AddDays(-26).ToShortDateString();
                string Date27 = DateTime.Today.AddDays(-27).ToShortDateString();
                string Date28 = DateTime.Today.AddDays(-28).ToShortDateString();
                string Date29 = DateTime.Today.AddDays(-29).ToShortDateString();
                string Date30 = DateTime.Today.AddDays(-30).ToShortDateString();
                string Date31 = DateTime.Today.AddDays(-31).ToShortDateString();


                if (ContractEndDate == TodayDate || ContractEndDate == Date1 || ContractEndDate == Date2 || ContractEndDate == Date3 || ContractEndDate == Date4 || ContractEndDate == Date5 || ContractEndDate == Date6 || ContractEndDate == Date7 || ContractEndDate == Date8 || ContractEndDate == Date9 || ContractEndDate == Date10 || ContractEndDate == Date11 || ContractEndDate == Date12 || ContractEndDate == Date13 || ContractEndDate == Date14 || ContractEndDate == Date15 || ContractEndDate == Date16 || ContractEndDate == Date17 || ContractEndDate == Date18 || ContractEndDate == Date19 || ContractEndDate == Date20 || ContractEndDate == Date21 || ContractEndDate == Date22 || ContractEndDate == Date23 || ContractEndDate == Date24 || ContractEndDate == Date25 || ContractEndDate == Date26 || ContractEndDate == Date27 || ContractEndDate == Date28 || ContractEndDate == Date29 || ContractEndDate == Date30 || ContractEndDate == Date31)
                {
                    Console.Beep();
                    Console.Beep();
                    Console.Beep();
                    Console.Beep();

                    notifyContract.Text = "Contract Expired";
                    notifyContract.Visible = true;
                    notifyContract.BalloonTipTitle = "Contract Expired";
                    notifyContract.BalloonTipText = "Click Here to see details";
                    notifyContract.ShowBalloonTip(300000000);
                }
            }
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
    
        private void btnPayroll_Click(object sender, EventArgs e)
        {
            FormPayroll P = new FormPayroll(lblUser.Text.Trim());
            this.Hide();
            this.Close();
            P.Show();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            FormAttendance A = new FormAttendance(lblUser.Text.Trim());
            this.Hide();
            this.Close();
            A.Show();
        }

        private void btnContract_Click(object sender, EventArgs e)
        {
            FormContract C = new FormContract(lblUser.Text.Trim());
            this.Hide();
            this.Close();
            C.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. PILIH PAYROLL MANAGEMENT MENU UNTUK"+
                            "\n    MANAJEMEN PENGGAJIAN" +
                            "\n2. PILIH CONTRACT MANAGEMENT MENU UNTUK" +
                            "\n    MANAJEMEN KONTRAK" + 
                            "\n3. PILIH INVENTORY MANAGEMENT MENU UNTUK" +
                            "\n    MANAJEMEN PERSEDIAAN" +
                            "\n4. PILIH PETTYCASH MANAGEMENT MENU UNTUK" +
                            "\n    MANAJEMEN DANA KAS" +
                            "\n5. PILIH ATTENDANCE MANAGEMENT MENU UNTUK" +
                            "\n    MANAJEMEN KEHADIRAN" + 
                            "\n6. GUNAKAN WEBSITE BUTTON UNTUK MENUJU" +
                            "\n    HOMEPAGE PT PELAYARAN BAHTERA ADHIGUNA" +
                            "\n7. GUNAKAN EXIT BUTTON UNTUK KELUAR APLIKASI" +
                            "\n8. JIKA ERROR TERJADI, HUBUNGI KAMI DI:" +
                            "\n    rezakisman@gmail.com / 0811 940 90 65"
                            , "HELP", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnWeb_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("GO TO WEBSITE?", "VISIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("http://www.bahteradhiguna.co.id/");
            }
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            FormPettyCash P = new FormPettyCash(lblUser.Text.Trim());
            this.Hide();
            this.Close();
            P.Show();
        }

        private void lblUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("EDIT YOUR PROFILE?", "EDIT PROFILE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                FormEditProfile E = new FormEditProfile(lblUser.Text.Trim());
                this.Hide();
                this.Close();
                E.Show();
            }
        }

        private void notifyContract_BalloonTipClicked(object sender, EventArgs e)
        {
            FormContract C = new FormContract(lblUser.Text.Trim());
            this.Hide();
            this.Close();
            C.Show();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            FormInventory I = new FormInventory(lblUser.Text.Trim());
            this.Hide();
            this.Close();
            I.Show();
        }

        private void notifyContract_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormContract C = new FormContract(lblUser.Text.Trim());
            this.Hide();
            this.Close();
            C.Show();       
        }

        private void notifyContract_MouseClick(object sender, MouseEventArgs e)
        {
            FormContract C = new FormContract(lblUser.Text.Trim());
            this.Hide();
            this.Close();
            C.Show();  
        }

        private void notifyContract_BalloonTipClosed(object sender, EventArgs e)
        {
            FormContract C = new FormContract(lblUser.Text.Trim());
            this.Hide();
            this.Close();
            C.Show();  
        }

        private void FormMainMenuMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("1. PILIH PAYROLL MANAGEMENT MENU UNTUK" +
                            "\n    MANAJEMEN PENGGAJIAN" +
                            "\n2. PILIH CONTRACT MANAGEMENT MENU UNTUK" +
                            "\n    MANAJEMEN KONTRAK" +
                            "\n3. PILIH INVENTORY MANAGEMENT MENU UNTUK" +
                            "\n    MANAJEMEN PERSEDIAAN" +
                            "\n4. PILIH PETTYCASH MANAGEMENT MENU UNTUK" +
                            "\n    MANAJEMEN DANA KAS" +
                            "\n5. PILIH ATTENDANCE MANAGEMENT MENU UNTUK" +
                            "\n    MANAJEMEN KEHADIRAN" +
                            "\n6. GUNAKAN WEBSITE BUTTON UNTUK MENUJU" +
                            "\n    HOMEPAGE PT PELAYARAN BAHTERA ADHIGUNA" +
                            "\n7. GUNAKAN EXIT BUTTON UNTUK KELUAR APLIKASI" +
                            "\n8. JIKA ERROR TERJADI, HUBUNGI KAMI DI:" +
                            "\n    rezakisman@gmail.com / 0811 940 90 65"
                            , "HELP", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            FormEmployee E = new FormEmployee(lblUser.Text.Trim());
            this.Hide();
            this.Close();
            E.Show();
        }

        private void btnEmployeeMenu_Click(object sender, EventArgs e)
        {
            btnEmployeeMenu.Visible = false;

            btnEmployee.Visible = true;
            btnAttendance.Visible = true;
            btnPayroll.Visible = true;
        }
    }
}
