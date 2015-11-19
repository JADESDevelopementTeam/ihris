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
    public partial class FormEmployee : Form
    {
        string dataPassing;
        public FormEmployee(string data)
        {
            InitializeComponent();
            this.dataPassing = data;

            timer1.Enabled = true;
            timer1.Interval = 1000;

            this.KeyPreview = true;
        }

        public void BindDivisionComboBox()
        {
            Admin AD = new Admin();
            ArrayList data_division = AD.BindCBDivision();

            if (data_division.Count == 0)
            {
                MessageBox.Show("NO DATA MATCH WITH DATABASE RECORDS", "NO DATA FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                for (int i = 0; i < data_division.Count; i = i + 2)
                {
                    string DivID = (string)data_division[i];
                    string DivName = (string)data_division[i + 1];

                    cbEmpDivision.Items.Add(DivID + ". " + DivName);
                    cbEditEmpDivision.Items.Add(DivID + ". " + DivName);
                }
            }
        }

        public void BindPositionComboBoxAddForm()
        {
            Admin AP = new Admin();
            ArrayList data_position = AP.BindCBPosition(cbEmpDivision.Text.Substring(0, 1));

            if (data_position.Count == 0)
            {
                MessageBox.Show("NO DATA MATCH WITH DATABASE RECORDS", "NO DATA FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                for (int i = 0; i < data_position.Count; i = i + 2)
                {
                    string PosID = (string)data_position[i];
                    string PosName = (string)data_position[i + 1];

                    cbEmpPosition.Items.Add(PosID + ". " + PosName);
                }
            }
        }

        public void BindPositionComboBoxEditForm()
        {
            Admin AP = new Admin();
            ArrayList data_position = AP.BindCBPosition(cbEditEmpDivision.Text.Substring(0, 1));

            if (data_position.Count == 0)
            {
                MessageBox.Show("NO DATA MATCH WITH DATABASE RECORDS", "NO DATA FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                for (int i = 0; i < data_position.Count; i = i + 2)
                {
                    string PosID = (string)data_position[i];
                    string PosName = (string)data_position[i + 1];
                    
                    cbEditEmpPosition.Items.Add(PosID + ". " + PosName);
                }
            }
        }

        public void RefreshFormEmployee()
        {
            dtpEmpDOB.Text = DateTime.Today.ToShortDateString();
            dtpEditEmpDOB.Text = DateTime.Today.ToShortDateString();
            
            Admin Show = new Admin();
            dgAllEmployee.DataSource = Show.EmployeeDGV();
            dgAllEmployee.DataMember = "Employee";

            dgEditEmp.DataSource = Show.EmployeeDGV();
            dgEditEmp.DataMember = "Employee";

            dgSearchEmp.DataSource = Show.EmployeeDGV();
            dgSearchEmp.DataMember = "Employee";

            if (tbEditEmpNIP.Text == "" || tbEditEmpName.Text == "")
            {
                btnEdit.Visible = false;
                btnCancelEdit.Visible = false;
            }

            if (tbEmpNIP.Text == "" || tbEditEmpName.Text == "")
            {
                btnSave.Visible = false;
                btnCancel.Visible = false;
            }
        }


        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            MessageBox.Show("PRESS EXIT(ESC) BUTTON TO EXIT FULLSCREEN", "GOING FULLSCREEN", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnReport_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("SAVE DATA? \nMAKE SURE ALL THE FORM FIELDS FILLED CORRECTLY", "DATA ENTRY", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    if (tbEmpPassword.Text != tbEmpRepeatPassword.Text)
                    {
                        MessageBox.Show("PASSWORD MISSMATCH", "INCORECT PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbEmpPassword.Clear();
                        tbEmpRepeatPassword.Clear();
                        tbEmpPassword.Focus();
                    }
                    else
                    {
                        if (tbEmpNIP.Text == "" || tbEmpName.Text == "" || tbEmpEmail.Text == "" || tbEmpPhone.Text == "" || tbEmpPhoto.Text == "" || dtpEmpDOB.Text == DateTime.Today.ToShortDateString() || cbEmpGender.Text == "-----SELECT GENDER-----" || cbEmpDivision.Text == "-----SELECT DIVISION-----" || cbEmpPosition.Text == "-----SELECT POSITION-----")
                        {
                            MessageBox.Show("FORM FIELD(S) CAN NOT BE LEFT EMPTY. PLEASE COMPLETE THE FORM TO SAVE DATA", "DATA ENTRY ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tbEmpNIP.Focus();
                        }
                        else
                        {
                            string EmployeeNIP = tbEmpNIP.Text;
                            string EmployeePassword = tbEmpRepeatPassword.Text;
                            string EmployeeName = tbEmpName.Text;
                            string EmployeeGender = cbEmpGender.Text;
                            string EmployeeDOB = dtpEmpDOB.Text;
                            string EmployeeEmail = tbEmpEmail.Text;
                            string EmployeePhone = tbEmpPhone.Text;
                            string EmployeePhoto = tbEmpPhoto.Text;
                            string DivisionID = cbEmpDivision.Text.Substring(0, 1);
                            string PositionID = cbEmpPosition.Text.Substring(0, 1);


                            Admin A = new Admin();
                            A.AddEmployee(EmployeeNIP, EmployeePassword, EmployeeName, EmployeeGender, EmployeeDOB, EmployeeEmail, EmployeePhone, EmployeePhoto, DivisionID, PositionID);

                            tbEmpNIP.Clear();
                            tbEmpName.Clear();
                            cbEmpGender.Text = "-----SELECT GENDER-----";
                            dtpEmpDOB.Text = DateTime.Today.ToShortDateString();
                            tbEmpEmail.Clear();
                            tbEmpPhone.Clear();
                            tbEmpPhoto.Clear();
                            cbEmpDivision.Text = "-----SELECT DIVISION-----";
                            cbEmpPosition.Text = "-----SELECT POSITION-----";
                            tbEmpPassword.Clear();
                            tbEmpRepeatPassword.Clear();

                            MessageBox.Show("DATA SAVED", "ENTRY DATA SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                            RefreshFormEmployee();
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

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            BindDivisionComboBox();

            RefreshFormEmployee();

            lblUser.Text = dataPassing;
            lblDate.Text = DateTime.Now.ToShortDateString();
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

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. HARAP MELENGKAPI DIVISION AND POSITION PREFERENCES" +
                           "\n    PADA PAYROLL MANAGEMENT, APABILA MENGALAMI ERROR" +
                           "\n    'NO DATA MATCH WITH DATABASE RECORDS'" +
                           "\n2. PADA FORM EDIT PEGAWAI, DIHARAPKAN MEMILIH KODE PEGAWAI" +
                           "\n    TERLEBIH DAHULU KEMUDIAN BARU MELAKUKAN PENGEDITAN" +
                           "\n3. PADA FORM ADD PEGAWAI, DIHARAPKAN MENGISI KODE PEGAWAI" +
                           "\n    TERLEBIH DAHULU LALU TOMBOL SAVE DAN RESET AKAN MUNCUL"
                           , "HELP", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void cbEmpDivision_SelectedValueChanged(object sender, EventArgs e)
        {
            cbEmpPosition.Items.Clear();
            BindPositionComboBoxAddForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE WANT TO RESET THIS FORM? \nRESETTING THIS FORM WILL LEAVE FORM BLANK", "ERASE ALL FIELDS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    tbEmpNIP.Clear();
                    tbEmpName.Clear();
                    cbEmpGender.Text = "-----SELECT GENDER-----";
                    dtpEmpDOB.Text = DateTime.Today.ToShortDateString();
                    tbEmpEmail.Clear();
                    tbEmpPhone.Clear();
                    cbEmpDivision.Text = "-----SELECT DIVISION-----";
                    cbEmpPosition.Text = "-----SELECT POSITION-----";
                    tbEmpPassword.Clear();
                    tbEmpRepeatPassword.Clear();

                    RefreshFormEmployee();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgEditEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = dgEditEmp.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                Admin Bind = new Admin();
                ArrayList data_emp = Bind.BindEmpDetails(str);

                if (data_emp.Count == 0)
                {
                    MessageBox.Show("NO DATA MATCH WITH DATABASE RECORDS", "NO DATA FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    for (int i = 0; i < data_emp.Count; i = i + 8)
                    {
                        string EmpNIP = (string)data_emp[i];
                        string EmpName = (string)data_emp[i + 1];
                        string EmpGender = (string)data_emp[i + 2];
                        string EmpDOB = (string)data_emp[i + 3];
                        string EmpEmail = (string)data_emp[i + 4];
                        string EmpPhone = (string)data_emp[i + 5];
                        string DivID = (string)data_emp[i + 6];
                        string PosID = (string)data_emp[i + 7];

                        tbEditEmpNIP.Text = EmpNIP;
                        tbEditEmpName.Text = EmpName;
                        cbEditEmpGender.Text = EmpGender;
                        dtpEditEmpDOB.Text = EmpDOB;
                        tbEditEmpEmail.Text = EmpEmail;
                        tbEditEmpPhone.Text = EmpPhone;

                        Admin BindSingleDiv = new Admin();
                        ArrayList data_singleDiv = BindSingleDiv.BindCBDivisionForEditAndSearchEmployeeForm(DivID);
                        for (int iD = 0; iD < data_singleDiv.Count; iD = iD + 2)
                        {
                            string CompletedDivID = (string)data_singleDiv[iD];
                            string CompletedDivName = (string)data_singleDiv[iD + 1];

                            cbEditEmpDivision.Text = CompletedDivID + ". " + CompletedDivName;
                        }

                        Admin BindSinglePos = new Admin();
                        ArrayList data_singlePos = BindSingleDiv.BindCBPositionForEditAndSearchEmployeeForm(PosID);
                        for (int iP = 0; iP < data_singlePos.Count; iP = iP + 2)
                        {
                            string CompletedPosID = (string)data_singlePos[iP];
                            string CompletedPosName = (string)data_singlePos[iP + 1];

                            cbEditEmpPosition.Text = CompletedPosID + ". " + CompletedPosName;
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

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("ARE YOU SURE WANT TO RESET THIS FORM? \nRESETTING THIS FORM WILL LEAVE FORM BLANK", "ERASE ALL FIELDS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    tbEditEmpNIP.Clear();
                    tbEditEmpName.Clear();
                    cbEditEmpGender.Text = "-----SELECT GENDER-----";
                    dtpEditEmpDOB.Text = DateTime.Today.ToShortDateString();
                    tbEditEmpEmail.Clear();
                    tbEditEmpPhone.Clear();
                    cbEditEmpDivision.Text = "-----SELECT DIVISION-----";
                    cbEditEmpPosition.Text = "-----SELECT POSITION-----";

                    RefreshFormEmployee();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("DO YOU WANT TO EDIT THIS EMPLOYEE DATA?", "EDIT EMPLOYEE DETAILS", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (tbEditEmpNIP.Text == "" || tbEditEmpName.Text == "" || tbEditEmpEmail.Text == "" || tbEditEmpPhone.Text == "" || dtpEditEmpDOB.Text == DateTime.Today.ToShortDateString() || cbEditEmpGender.Text == "-----SELECT GENDER-----" || cbEditEmpDivision.Text == "-----SELECT DIVISION-----" || cbEditEmpPosition.Text == "-----SELECT POSITION-----")
                    {
                        MessageBox.Show("FORM FIELD(S) CAN NOT BE LEFT EMPTY. PLEASE COMPLETE THE FORM TO EDIT DATA", "DATA UPDATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbEditEmpEmail.Focus();
                    }
                    else
                    {
                        string EmployeeNIP = tbEditEmpNIP.Text;
                        string EmployeeName = tbEditEmpName.Text;
                        string EmployeeGender = cbEditEmpGender.Text;
                        string EmployeeDOB = dtpEditEmpDOB.Text;
                        string EmployeeEmail = tbEditEmpEmail.Text;
                        string EmployeePhone = tbEditEmpPhone.Text;
                        string DivisionID = cbEditEmpDivision.Text.Substring(0, 1);
                        string PositionID = cbEditEmpPosition.Text.Substring(0, 1);


                        Admin A = new Admin();
                        A.EditEmployee(EmployeeNIP, EmployeeName, EmployeeGender, EmployeeDOB, EmployeeEmail, EmployeePhone, DivisionID, PositionID);

                        tbEditEmpNIP.Clear();
                        tbEditEmpName.Clear();
                        cbEditEmpGender.Text = "-----SELECT GENDER-----";
                        dtpEditEmpDOB.Text = DateTime.Today.ToShortDateString();
                        tbEditEmpEmail.Clear();
                        tbEditEmpPhone.Clear();
                        cbEditEmpDivision.Text = "-----SELECT DIVISION-----";
                        cbEditEmpPosition.Text = "-----SELECT POSITION-----";

                        MessageBox.Show("DATA UPDATED", "UPDATE DATA SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshFormEmployee();
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

        private void cbEditEmpDivision_SelectedValueChanged(object sender, EventArgs e)
        {
            cbEditEmpPosition.Items.Clear();
            BindPositionComboBoxEditForm();
        }

        private void tbEmpNIP_TextChanged(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            btnCancel.Visible = true;
        }

        private void tbEditEmpNIP_TextChanged(object sender, EventArgs e)
        {
            btnEdit.Visible = true;
            btnCancelEdit.Visible = true;
        }

        private void dgSearchEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string str = dgSearchEmp.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                Admin Bind = new Admin();
                ArrayList data_emp = Bind.BindEmpDetails(str);

                if (data_emp.Count == 0)
                {
                    MessageBox.Show("NO DATA MATCH WITH DATABASE RECORDS", "NO DATA FOUND", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    for (int i = 0; i < data_emp.Count; i = i + 8)
                    {
                        string EmpNIP = (string)data_emp[i];
                        string EmpName = (string)data_emp[i + 1];
                        string EmpGender = (string)data_emp[i + 2];
                        string EmpDOB = (string)data_emp[i + 3];
                        string EmpEmail = (string)data_emp[i + 4];
                        string EmpPhone = (string)data_emp[i + 5];
                        string DivID = (string)data_emp[i + 6];
                        string PosID = (string)data_emp[i + 7];

                        tbSearchEmpNIP.Text = EmpNIP;
                        tbSearchEmpName.Text = EmpName;
                        tbSearchEmpGender.Text = EmpGender;
                        tbSearchEmpDOB.Text = EmpDOB;
                        tbSearchEmpEmail.Text = EmpEmail;
                        tbSearchEmpPhone.Text = EmpPhone;

                        Admin BindSingleDiv = new Admin();
                        ArrayList data_singleDiv = BindSingleDiv.BindCBDivisionForEditAndSearchEmployeeForm(DivID);
                        for (int iD = 0; iD < data_singleDiv.Count; iD = iD + 2)
                        {
                            string CompletedDivID = (string)data_singleDiv[iD];
                            string CompletedDivName = (string)data_singleDiv[iD + 1];

                            tbSearchEmpDivision.Text = CompletedDivID + ". " + CompletedDivName;
                        }

                        Admin BindSinglePos = new Admin();
                        ArrayList data_singlePos = BindSingleDiv.BindCBPositionForEditAndSearchEmployeeForm(PosID);
                        for (int iP = 0; iP < data_singlePos.Count; iP = iP + 2)
                        {
                            string CompletedPosID = (string)data_singlePos[iP];
                            string CompletedPosName = (string)data_singlePos[iP + 1];

                            tbSearchEmpPosition.Text = CompletedPosID + ". " + CompletedPosName;
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

        private void btnEditBrowse_Click(object sender, EventArgs e)
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
