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
    public partial class FormPayroll : Form
    {
        string dataPassing;
        public FormPayroll(string data)
        {
            InitializeComponent();
            this.dataPassing = data;

            timer1.Enabled = true;
            timer1.Interval = 1000;

            this.KeyPreview = true;
        }

        public void RefreshDGV()
        {
            Admin Show = new Admin();
            dgDivision.DataSource = Show.DivisionDGV();
            dgDivision.DataMember = "Division";

            dgPosition.DataSource = Show.PositionDGV();
            dgPosition.DataMember = "Position";
            
            dgSearchEmpPayroll.DataSource = Show.PayrollEmpDGV();
            dgSearchEmpPayroll.DataMember = "Employee";
            
            dgAddPayroll.DataSource = Show.PayrollEmpDGV();
            dgAddPayroll.DataMember = "Employee";
        }

        public void BindCBDivision()
        {
            Admin A = new Admin();
            ArrayList data_division = A.BindCBDivision();

            if (data_division.Count == 0)
            {
                MessageBox.Show("NO DATA MATCH WITH DATABASE RECORDS", "NO DATA FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                for (int i = 0; i < data_division.Count; i = i + 2)
                {
                    string DivID = (string)data_division[i];
                    string DivName = (string)data_division[i+1];

                    cbPositionDivision.Items.Add(DivID+". "+DivName);
                }
            }
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

        private void FormPayroll_Load(object sender, EventArgs e)
        {
            BindCBDivision();
            RefreshDGV();

            lblUser.Text = dataPassing;
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Harap lengkapi data DIVISION AND POSITION PREFERENCES" +
                           "\n    untuk kebutuhan pengisian data pada form PAYROLL" 
                           , "HELP", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            MessageBox.Show("PRESS EXIT(ESC) BUTTON TO EXIT FULLSCREEN", "GOING FULLSCREEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormPayroll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }

            if (e.KeyCode == Keys.F1)
            {
                //btn_Help
            }
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

        private void btnSaveDivision_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("SAVE DATA? \nMAKE SURE ALL THE FORM FIELDS FILLED CORRECTLY", "DATA ENTRY", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    if (tbDivisionDescription.Text == "" || tbDivisionName.Text == "")
                    {
                        MessageBox.Show("FORM FIELD(S) CAN NOT BE LEFT EMPTY. PLEASE COMPLETE THE FORM TO SAVE DATA", "DATA ENTRY ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbDivisionName.Focus();
                    }
                    else
                    {
                        Admin A = new Admin();
                        A.AddDivision(tbDivisionName.Text, tbDivisionDescription.Text);

                        tbDivisionName.Clear();
                        tbDivisionDescription.Clear();

                        MessageBox.Show("DATA SAVED", "ENTRY DATA SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshDGV();

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

        private void btnSavePosition_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("SAVE DATA? \nMAKE SURE ALL THE FORM FIELDS FILLED CORRECTLY", "DATA ENTRY", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    if (cbPositionDivision.Text == "-----SELECT DIVISION-----" || tbPositionName.Text == "" || tbPayrollBase.Text == "")
                    {
                        MessageBox.Show("FORM FIELD(S) CAN NOT BE LEFT EMPTY. PLEASE COMPLETE THE FORM TO SAVE DATA", "DATA ENTRY ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbDivisionName.Focus();
                    }
                    else
                    {
                        string PositionName = tbPositionName.Text.Trim();
                        string DivisionID = cbPositionDivision.Text.Substring(0, 1).Trim(); ;
                        string PayrollBase = tbPayrollBase.Text.Trim();

                        Admin A = new Admin();
                        A.AddPosition(PositionName, PayrollBase, DivisionID);

                        tbPositionName.Clear();
                        cbPositionDivision.Text = "-----SELECT DIVISION-----";
                        tbPayrollBase.Clear();

                        MessageBox.Show("DATA SAVED", "ENTRY DATA SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshDGV();

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
        
        private void dgSearchEmpPayroll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = dgSearchEmpPayroll.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                Admin Bind = new Admin();
                ArrayList data_payroll = Bind.BindPayrollDetails(str);

                if (data_payroll.Count == 0)
                {
                    MessageBox.Show("NO DATA MATCH WITH DATABASE RECORDS", "NO DATA FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    for (int i = 0; i < data_payroll.Count; i = i + 8)
                    {
                        string EmpNIP = (string)data_payroll[i];
                        string PayrollBase = (string)data_payroll[i + 1];
                        string PayrollPositionAllowanceTotal = (string)data_payroll[i + 2];
                        string PayrollTransportationAllowanceTotal = (string)data_payroll[i + 3];
                        string PayrollHouseAllowanceTotal = (string)data_payroll[i + 4];
                        string PayrollAnotherAllowanceTotal = (string)data_payroll[i + 5];
                        string PayrollReductionTotal = (string)data_payroll[i + 6];
                        string PayrollTotal = (string)data_payroll[i + 7];

                        tbSearchPayrollEmpNIP.Text = EmpNIP;
                        tbSearchPayrollBase.Text = PayrollBase;
                        tbSearchPayrollPosition.Text = PayrollPositionAllowanceTotal;
                        tbSearchPayrollTransportation.Text = PayrollTransportationAllowanceTotal;
                        tbSearchPayrollHouse.Text = PayrollHouseAllowanceTotal;
                        tbSearchPayrollAnother.Text = PayrollAnotherAllowanceTotal;
                        tbSearchPayrollReduction.Text = PayrollReductionTotal;
                        tbSearchTotalPayroll.Text = PayrollReductionTotal;
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

        private void dgAddPayroll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = dgAddPayroll.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                Admin Bind = new Admin();
                ArrayList data_payroll = Bind.BindAddPayrollDetails(str);

                if (data_payroll.Count == 0)
                {
                    MessageBox.Show("NO DATA MATCH WITH DATABASE RECORDS", "NO DATA FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    for (int i = 0; i < data_payroll.Count; i = i + 2)
                    {
                        string EmpNIP = (string)data_payroll[i];
                        string PayrollBase = (string)data_payroll[i + 1];

                        tbSaveEmpNIP.Text = EmpNIP;
                        tbSaveEmpPayrollBase.Text = PayrollBase;
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

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (tbSaveEmpPayrollBase.Text == "" || tbSavePayrollTA.Text == "" || tbSavePayrollAA.Text == "" || tbSavePayrollHA.Text == "" || tbSavePayrollPA.Text == "" || tbSavePayrollReduction.Text == "")
            {
                MessageBox.Show("CANT CALCULATE TOTAL. PLEASE COMPLETE THE FORM TO CALCULATE", "CALCULATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbSavePayrollPA.Focus();
            }
            else
            {
                double Base = Convert.ToDouble(tbSaveEmpPayrollBase.Text);
                double TA = Convert.ToDouble(tbSavePayrollTA.Text);
                double AA = Convert.ToDouble(tbSavePayrollAA.Text);
                double HA = Convert.ToDouble(tbSavePayrollHA.Text);
                double PA = Convert.ToDouble(tbSavePayrollPA.Text);
                double Reduction = Convert.ToDouble(tbSavePayrollReduction.Text);

                double Total = (Base + TA + AA + HA + PA) - Reduction;
                if (Total < 0)
                {
                    btnCalculate.Visible = true;
                    MessageBox.Show("GRAND TOTAL CAN NOT BE NEGATIVE. PLEASE CHECK FORM TO DO RECALCULATE", "NEGATIVE NUMBER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbSavePayrollPA.Focus();
                }
                else
                {
                    tbSavePayrollTotal.Text = Total.ToString();
                    btnCalculate.Visible = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
