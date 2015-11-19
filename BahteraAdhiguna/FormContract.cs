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
using System.Collections;

namespace BahteraAdhiguna
{
    public partial class FormContract : Form
    {
        string dataPassing;
        public FormContract(string data)
        {
            InitializeComponent(); 
            this.dataPassing = data;

            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        public void RefreshDG()
        {
            Admin Show = new Admin();
            dgvAllContract.DataSource = Show.ContractDGV();
            dgvAllContract.DataMember = "Contracts";

            dgOngoing.DataSource = Show.GetOngoingContractDGV();
            dgOngoing.DataMember = "OngoingContracts";

            dgCompleted.DataSource = Show.GetCompletedContractDGV();
            dgCompleted.DataMember = "CompletedContracts";

            dgExtended.DataSource = Show.GetExtendedContractDGV();
            dgExtended.DataMember = "ExtendedContracts";

            dgSearchContract.DataSource = Show.GetSearchContractDGV();
            dgSearchContract.DataMember = "SearchContracts";

            dgEditContract.DataSource = Show.GetEditContractDGV();
            dgEditContract.DataMember = "EditContracts";
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            FormMainMenuMaster MM = new FormMainMenuMaster(lblUser.Text.Trim());
            this.Hide();
            this.Close();
            MM.Show();
        }

        private void FormContract_Load(object sender, EventArgs e)
        {
            dtpStartDate.Text = DateTime.Today.ToShortDateString();
            dtpEndDate.Text = DateTime.Today.ToShortDateString();
            dtpUpdateContractStartDate.Text = DateTime.Today.ToShortDateString();
            dtpUpdateContractEndDate.Text = DateTime.Today.ToShortDateString();

            lblUser.Text = dataPassing;
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();

            RefreshDG();
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

        private void cbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTime.SelectedIndex == 0)
            {
                dtpEndDate.Text = dtpStartDate.Value.AddDays(7).ToString();
            }
            else if (cbTime.SelectedIndex == 1)
            {
                dtpEndDate.Text = dtpStartDate.Value.AddDays(15).ToString();
            }
            else if (cbTime.SelectedIndex == 2)
            {
                dtpEndDate.Text = dtpStartDate.Value.AddDays(30).ToString();
            }
            else if (cbTime.SelectedIndex == 3)
            {
                dtpEndDate.Text = dtpStartDate.Value.AddDays(45).ToString();
            }
            else if (cbTime.SelectedIndex == 4)
            {
                dtpEndDate.Text = dtpStartDate.Value.AddDays(14).ToString();
            }
            else if (cbTime.SelectedIndex == 5)
            {
                dtpEndDate.Text = dtpStartDate.Value.AddDays(21).ToString();
            }
            else if (cbTime.SelectedIndex == 6)
            {
                dtpEndDate.Text = dtpStartDate.Value.AddMonths(3).ToString();
            }
            else if (cbTime.SelectedIndex == 7)
            {
                dtpEndDate.Text = dtpStartDate.Value.AddMonths(6).ToString();
            }
            else if (cbTime.SelectedIndex == 8)
            {
                dtpEndDate.Text = dtpStartDate.Value.AddYears(1).ToString();
            }
            else if (cbTime.SelectedIndex == 9)
            {
                dtpEndDate.Text = dtpStartDate.Value.AddYears(2).ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("SAVE DATA? \nMAKE SURE ALL THE FORM FIELDS FILLED CORRECTLY", "DATA ENTRY", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    if (tbContractNumber.Text == "" || tbContractName.Text == "" || tbContractDescription.Text == "" || cbTime.SelectedIndex == -1 || tbContractInfo.Text == "")
                    {
                        MessageBox.Show("FORM FIELD(S) CAN NOT BE LEFT EMPTY. PLEASE COMPLETE THE FORM TO SAVE DATA", "DATA ENTRY ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbContractNumber.Focus();
                    }
                    else
                    {
                        string ContractNumber = tbContractNumber.Text;
                        string ContractName = tbContractName.Text;
                        string ContractDescription = tbContractDescription.Text;
                        string ContractTimePeriod = cbTime.Text;
                        string ContractStartDate = dtpStartDate.Text;
                        string ContractEndDate = dtpEndDate.Text;
                        string ContractInfo = tbContractInfo.Text;
                        string EmployeeNIP = lblUser.Text;

                        Admin Save = new Admin();
                        Save.AddContract(ContractNumber, ContractName, ContractDescription, ContractTimePeriod, ContractStartDate, ContractEndDate, ContractInfo, EmployeeNIP);

                        MessageBox.Show("DATA SAVED", "ENTRY DATA SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        RefreshDG();
                 
                        tbContractNumber.Clear();
                        tbContractName.Clear();
                        tbContractDescription.Clear();
                        cbTime.Text = "-----SELECT TIME-----"; 
                        dtpStartDate.Text = DateTime.Today.ToShortDateString();
                        dtpEndDate.Text = DateTime.Today.ToShortDateString();
                        dtpUpdateContractStartDate.Text = DateTime.Today.ToShortDateString();
                        dtpUpdateContractEndDate.Text = DateTime.Today.ToShortDateString();
                        tbContractInfo.Clear();
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
 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE WANT TO RESET THIS FORM? \nRESETTING THIS FORM WILL LEAVE FORM BLANK", "ERASE ALL FIELDS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    tbContractNumber.Clear();
                    tbContractName.Clear();
                    tbContractDescription.Clear();
                    cbTime.Text = "-----SELECT TIME-----";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            MessageBox.Show("PRESS EXIT(ESC) BUTTON TO EXIT FULLSCREEN", "GOING FULLSCREEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormContract_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }

            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("1. KETIKA DATA SUDAH DI SIMPAN, DATA TIDAK BISA DIKEMBALIKAN" +
                           "\n2. PENCARIAN DATA KONTRAK DENGAN CARA KLIK NOMOR" +
                           "\n    KONTRAK PADA DATAGRID VIEW" +
                           "\n3. UNTUK UPDATE STATUS KONTRAK,PERTAMA KLIK" +
                           "\n    NOMOR KONTRAK PADA DATA GRID VIEW. LALU" +
                           "\n    KLIK TOMBOL UPDATE UNTUK MENYELESAIKAN KONTRAK" +
                           "\n4. GUNAKAN TOMBOL EXIT UNTUK KELUAR DARI APLIKASI" +
                           "\n5. GUNAKAN TOMBOL FULSCREEN UNTUK MELIHAT FORM SECARA" +
                           "\n    FULLSCREEN" +
                           "\n6. GUNAKAN TOMBOL MENU UNTUK KEMBALI MAIN MENU" +
                           "\n7. GUNAKAN TOMBOL ESCAPE(ESC) UNTUK KELUAR DARI" +
                           "\n    FULLSCREEN" +
                           "\n8. FORM INI MENGGUNAKAN CASE SENSITIVE" +
                           "\n9. UNTUK MELIHAT DETAIL KONTRAK SECARA LENGKAP, HARAP" +
                           "\n    PERGI KE TAB SEARCH CONTRACT"
                           , "HELP", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. KETIKA DATA SUDAH DI SIMPAN, DATA TIDAK BISA DIKEMBALIKAN" +
                           "\n2. PENCARIAN DATA KONTRAK DENGAN CARA KLIK NOMOR" +
                           "\n    KONTRAK PADA DATAGRID VIEW" + 
                           "\n3. UNTUK UPDATE STATUS KONTRAK,PERTAMA KLIK" +
                           "\n    NOMOR KONTRAK PADA DATA GRID VIEW. LALU" + 
                           "\n    KLIK TOMBOL UPDATE UNTUK MENYELESAIKAN KONTRAK" +
                           "\n4. GUNAKAN TOMBOL EXIT UNTUK KELUAR DARI APLIKASI" +
                           "\n5. GUNAKAN TOMBOL FULSCREEN UNTUK MELIHAT FORM SECARA" +
                           "\n    FULLSCREEN" +
                           "\n6. GUNAKAN TOMBOL MENU UNTUK KEMBALI MAIN MENU" +
                           "\n7. GUNAKAN TOMBOL ESCAPE(ESC) UNTUK KELUAR DARI" +
                           "\n    FULLSCREEN" +
                           "\n8. FORM INI MENGGUNAKAN CASE SENSITIVE" +
                           "\n9. UNTUK MELIHAT DETAIL KONTRAK SECARA LENGKAP, HARAP" +
                           "\n    PERGI KE TAB SEARCH CONTRACT"
                           , "HELP", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
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

        private void dgOngoing_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = dgOngoing.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                Admin Bind = new Admin();
                ArrayList data_contract = Bind.BindOngoingContract(str);

                if (data_contract.Count == 0)
                {
                    MessageBox.Show("NO DATA MATCH WITH DATABASE RECORDS", "NO DATA FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    for (int i = 0; i < data_contract.Count; i = i + 5)
                    {
                        string ContractNumber = (string)data_contract[i];
                        string ContractName = (string)data_contract[i + 1];
                        string ContractTimePeriod = (string)data_contract[i + 2];
                        string ContractEndDate = (string)data_contract[i + 3];
                        string ContractStatus = (string)data_contract[i + 4];

                        tbEditContractNumber.Text = ContractNumber;
                        tbEditContractName.Text = ContractName;
                        tbEditContractTimePeriod.Text = ContractTimePeriod;
                        tbEditContractEndDate.Text = ContractEndDate;
                        tbEditContractStatus.Text = ContractStatus;
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

        private void btnUpdateContract_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("UPDATE CONTRACT STATUS TO COMPLETED?", "UPDATE CONTRACT STATUS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (tbEditContractNumber.Text == "" || tbEditContractName.Text == "" || tbEditContractTimePeriod.Text == "" || tbEditContractEndDate.Text == "" || tbEditContractStatus.Text == "")
                    {
                        MessageBox.Show("PLEASE SELECT CONTRACT TO COMPLETE FIRST", "ERROR UPDATING CONTRACT STATUS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                
                        string TodayDate = DateTime.Today.ToShortDateString();
                        string OneDayAfter = DateTime.Today.AddDays(-1).ToShortDateString();
                        string TwoDayAfter = DateTime.Today.AddDays(-2).ToShortDateString();
                        string ThreeDayAfter = DateTime.Today.AddDays(-3).ToShortDateString();
                        string FourDayAfter = DateTime.Today.AddDays(-4).ToShortDateString();
                        string FiveDayAfter = DateTime.Today.AddDays(-5).ToShortDateString();
                        string SixDayAfter = DateTime.Today.AddDays(-6).ToShortDateString();
                        string SevenDayAfter = DateTime.Today.AddDays(-7).ToShortDateString();

                        if(tbEditContractEndDate.Text == TodayDate || tbEditContractEndDate.Text == OneDayAfter || tbEditContractEndDate.Text == TwoDayAfter || tbEditContractEndDate.Text == ThreeDayAfter || tbEditContractEndDate.Text == FourDayAfter || tbEditContractEndDate.Text == FiveDayAfter || tbEditContractEndDate.Text == SixDayAfter || tbEditContractEndDate.Text == SevenDayAfter)
                        {
                            string ContractNumber = tbEditContractNumber.Text;
                            Admin A = new Admin();
                            A.UpdateContractStatus(ContractNumber);

                            MessageBox.Show("CONTRACT STATUS UPDATED", "CONTRACT DONE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            tbEditContractNumber.Clear();
                            tbEditContractName.Clear();
                            tbEditContractTimePeriod.Clear();
                            tbEditContractEndDate.Clear();
                            tbEditContractStatus.Clear();

                            RefreshDG();
                        }
                        else
                        {
                            MessageBox.Show("CONTRACT IS NOT DONE YET, CAN'T UPDATE CONTRACT STATUS", "CONTRACT STILL ONGOING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void dgSearchContract_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = dgSearchContract.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                Admin Bind = new Admin();
                ArrayList data_contract = Bind.BindAllContractDetails(str);

                if (data_contract.Count == 0)
                {
                    MessageBox.Show("NO DATA MATCH WITH DATABASE RECORDS", "NO DATA FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    for (int i = 0; i < data_contract.Count; i = i + 8)
                    {
                        string ContractNumber = (string)data_contract[i];
                        string ContractName = (string)data_contract[i + 1];
                        string ContractDescription = (string)data_contract[i + 2];
                        string ContractTimePeriod = (string)data_contract[i + 3];
                        DateTime ContractStartDate = (DateTime)data_contract[i + 4];
                        DateTime ContractEndDate = (DateTime)data_contract[i + 5];
                        string ContractStatus = (string)data_contract[i + 6];
                        string ContractInfo = (string)data_contract[i + 7];

                        tbSearchContractNumber.Text = ContractNumber;
                        tbSearchContractName.Text = ContractName;
                        tbSearchContractDescription.Text = ContractDescription;
                        tbSearchContractTime.Text = ContractTimePeriod;
                        tbSearchContractStartDate.Text = ContractStartDate.ToShortDateString();
                        tbSearchContractEndDate.Text = ContractEndDate.ToShortDateString();
                        tbSearchContractStatus.Text = ContractStatus;
                        tbSearchContractInfo.Text = ContractInfo;
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

        private void dgEditContract_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = dgEditContract.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                Admin Bind = new Admin();
                ArrayList data_contract = Bind.BindAllContractDetails(str);

                if (data_contract.Count == 0)
                {
                    MessageBox.Show("NO DATA MATCH WITH DATABASE RECORDS", "NO DATA FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    for (int i = 0; i < data_contract.Count; i = i + 8)
                    {
                        string ContractNumber = (string)data_contract[i];
                        string ContractName = (string)data_contract[i + 1];
                        string ContractDescription = (string)data_contract[i + 2];
                        string ContractTimePeriod = (string)data_contract[i + 3];
                        DateTime ContractStartDate = (DateTime)data_contract[i + 4];
                        DateTime ContractEndDate = (DateTime)data_contract[i + 5];
                        string ContractStatus = (string)data_contract[i + 6];
                        string ContractInfo = (string)data_contract[i + 7];

                        tbUpdateContractNumber.Text = ContractNumber;
                        tbUpdateContractName.Text = ContractName;
                        rtbUpdateContractDescription.Text = ContractDescription;
                        lblStartDate.Text = ContractTimePeriod;
                        cbUpdateContractTime.Text = ContractTimePeriod;
                        dtpUpdateContractStartDate.Value = ContractStartDate;
                        dtpUpdateContractEndDate.Value = ContractEndDate;
                        tbUpdateContractStatus.Text = ContractStatus;
                        tbUpdateContractInfo.Text = ContractInfo;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("DO YOU WANT TO EDIT THIS DATA CONTRACT?", "EDIT CONTRACT DETAILS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (tbUpdateContractNumber.Text == "" || tbUpdateContractName.Text == "" || rtbUpdateContractDescription.Text == "" || dtpUpdateContractStartDate.Text == "" || dtpUpdateContractEndDate.Text == "" || cbUpdateContractTime.SelectedIndex == -1 || tbUpdateContractStatus.Text == "" || tbUpdateContractInfo.Text == "")
                    {
                        MessageBox.Show("FORM FIELD(S) CAN NOT BE LEFT EMPTY. PLEASE COMPLETE THE FORM TO EDIT DATA", "DATA UPDATE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        string ContractNumber = tbUpdateContractNumber.Text;
                        string ContractName = tbUpdateContractName.Text;
                        string ContractDescription = rtbUpdateContractDescription.Text;
                        string ContractStartDate = dtpUpdateContractStartDate.Text;
                        string ContractPeriod = lblStartDate.Text + " EXTENDED " + cbUpdateContractTime.Text;
                        string ContractEndDate = dtpUpdateContractEndDate.Text;
                        string ContractInfo = tbUpdateContractInfo.Text;

                        Admin A = new Admin();
                        A.EditContractDetails(ContractNumber, ContractName, ContractDescription, ContractPeriod, ContractStartDate, ContractEndDate, ContractInfo);

                        MessageBox.Show("CONTRACT DETAILS UPDATED", "CONTRACT UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        tbUpdateContractNumber.Clear();
                        tbUpdateContractName.Clear();
                        rtbUpdateContractDescription.Clear();
                        tbUpdateContractStatus.Clear();
                        cbUpdateContractTime.Text = "-----SELECT TIME-----";
                        tbUpdateContractInfo.Clear();

                        dtpStartDate.Text = DateTime.Today.ToShortDateString();
                        dtpEndDate.Text = DateTime.Today.ToShortDateString();
                        dtpUpdateContractStartDate.Text = DateTime.Today.ToShortDateString();
                        dtpUpdateContractEndDate.Text = DateTime.Today.ToShortDateString();


                        RefreshDG();
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

        private void cbUpdateContractTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUpdateContractTime.SelectedIndex == 0)
            {
                dtpUpdateContractEndDate.Text = dtpUpdateContractStartDate.Value.AddDays(7).ToString();
            }
            else if (cbUpdateContractTime.SelectedIndex == 1)
            {
                dtpUpdateContractEndDate.Text = dtpUpdateContractStartDate.Value.AddDays(15).ToString();
            }
            else if (cbUpdateContractTime.SelectedIndex == 2)
            {
                dtpUpdateContractEndDate.Text = dtpUpdateContractStartDate.Value.AddDays(30).ToString();
            }
            else if (cbUpdateContractTime.SelectedIndex == 3)
            {
                dtpUpdateContractEndDate.Text = dtpUpdateContractStartDate.Value.AddDays(45).ToString();
            }
            else if (cbUpdateContractTime.SelectedIndex == 4)
            {
                dtpUpdateContractEndDate.Text = dtpUpdateContractStartDate.Value.AddDays(14).ToString();
            }
            else if (cbUpdateContractTime.SelectedIndex == 5)
            {
                dtpUpdateContractEndDate.Text = dtpUpdateContractStartDate.Value.AddDays(21).ToString();
            }
            else if (cbUpdateContractTime.SelectedIndex == 6)
            {
                dtpUpdateContractEndDate.Text = dtpUpdateContractStartDate.Value.AddMonths(3).ToString();
            }
            else if (cbUpdateContractTime.SelectedIndex == 7)
            {
                dtpUpdateContractEndDate.Text = dtpUpdateContractStartDate.Value.AddMonths(6).ToString();
            }
            else if (cbUpdateContractTime.SelectedIndex == 8)
            {
                dtpUpdateContractEndDate.Text = dtpUpdateContractStartDate.Value.AddYears(1).ToString();
            }
            else if (cbUpdateContractTime.SelectedIndex == 9)
            {
                dtpUpdateContractEndDate.Text = dtpUpdateContractStartDate.Value.AddYears(2).ToString();
            }
        }

        private void btnUpdateReset_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE WANT TO RESET THIS FORM? \nRESETTING THIS FORM WILL LEAVE FORM BLANK", "ERASE ALL FIELDS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    tbUpdateContractNumber.Clear();
                    tbUpdateContractName.Clear();
                    rtbUpdateContractDescription.Clear();
                    cbUpdateContractTime.Text = "-----SELECT TIME-----";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgExtended_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = dgExtended.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                Admin Bind = new Admin();
                ArrayList data_contract = Bind.BindOngoingContract(str);

                if (data_contract.Count == 0)
                {
                    MessageBox.Show("NO DATA MATCH WITH DATABASE RECORDS", "NO DATA FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    for (int i = 0; i < data_contract.Count; i = i + 5)
                    {
                        string ContractNumber = (string)data_contract[i];
                        string ContractName = (string)data_contract[i + 1];
                        string ContractTimePeriod = (string)data_contract[i + 2];
                        string ContractEndDate = (string)data_contract[i + 3];
                        string ContractStatus = (string)data_contract[i + 4];

                        tbEditContractNumber.Text = ContractNumber;
                        tbEditContractName.Text = ContractName;
                        tbEditContractTimePeriod.Text = ContractTimePeriod;
                        tbEditContractEndDate.Text = ContractEndDate;
                        tbEditContractStatus.Text = ContractStatus;
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
