using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace BahteraAdhiguna
{
    public partial class FormAttendance : Form
    {
        private string dataPassing;

        public FormAttendance(string data)
        {
            InitializeComponent();
            this.dataPassing = data;

            timer1.Enabled = true;
            timer1.Interval = 1000;

            this.KeyPreview = true;
        }

        public static int CountStringOccurrences(string rawText, string pattern)
        {
            int count = 0;
            int i = 0;
            while ((i = rawText.IndexOf(pattern, i)) != 1)
            {
                i += pattern.Length;
                count++;

            }
            return count;
        }

        public void CountAttendance()
        {
            DateTime In = new DateTime(0, 0, 0, 8, 15, 10);
            DateTime Out = new DateTime(0, 0, 0, 17, 19, 10);

            TimeSpan rawTotalHoursWorked = Out.Subtract(In);

            string TotalHoursWorked = rawTotalHoursWorked.ToString();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            FormMainMenuMaster MM = new FormMainMenuMaster(lblUser.Text.Trim());
            this.Hide();
            this.Close();
            MM.Show();
        }

        private void FormAttendance_Load(object sender, EventArgs e)
        {
            lblUser.Text = dataPassing;
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE WANT TO QUIT?", "QUIT", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Pastikan semua format dalam tabel excel sesuai dengan" +
                            "\n    ketentuan berikut: " +
                            "\n\ta. Tambahkan kolom 'NIP' pada file excel yang dimaksud." +
                            "\n\tb. Pastikan TIDAK terdapat judul pada file excel." +
                            "\n\tc. Pastikan SEMUA kolom pada file excel terisi dengan BENAR." +
                            "\n\td. Pastikan TIDAK ada DUPLIKASI data atau KOSONG." +
                            "\n\td. Pastikan TIDAK ada DUPLIKASI data atau KOSONG." +

                            "\n2. Klik tombol EXIT untuk keluar dari aplikasi." +
                            "\n3. Klik tombol FULSCREEN untuk melihat form secara" +
                            "\n    FULLSCREEN" +
                            "\n4. Klik tombol MENU untuk kembali ke MAIN MENU" +
                            "\n5. Klik tombol ESCAPE(ESC) untuk keluar dari" +
                            "\n    FULLSCREEN" +
                            "\n6. Form ini CASE SENSITIVE"
                , "HELP", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            TopMost = true;
            MessageBox.Show("PRESS EXIT(ESC) BUTTON TO EXIT FULLSCREEN", "GOING FULLSCREEN", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void FormAttendance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                WindowState = FormWindowState.Normal;
                TopMost = false;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();

            OFD.Title = "Select Excel Files";
            OFD.InitialDirectory = @"C:\";
            OFD.Filter = "Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            OFD.FilterIndex = 1;
            OFD.RestoreDirectory = true;

            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.tbPath.Text = OFD.FileName;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string PathConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + tbPath.Text +
                                  "; Extended Properties=\"Excel 12.0 XML;HDR=YES;IMEX=1\";";

                OleDbConnection con = new OleDbConnection(PathConn);

                OleDbDataAdapter oledbda = new OleDbDataAdapter("SELECT * FROM [" + tbName.Text + "$]", con);
                DataTable dt = new DataTable();

                oledbda.Fill(dt);

                dgExcel.DataSource = dt;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private List<string> StatusKerja()
        {
            Admin A = new Admin();
            ArrayList data_att = A.GetAttendanceTime();
            List<string> statusKerjaList = null;
            for (int ar = 0; ar <= data_att.Count; ar = ar + 2)
            {
                string statusKerja;
                DateTime AttIn = (DateTime)data_att[ar];
                DateTime AttOut = (DateTime)data_att[ar + 1];

                TimeSpan rawTotalHoursWorked = AttOut - AttIn;

                var masuk = TimeSpan.Parse("08:00:00");
                var lembur = TimeSpan.Parse("09:00:00");

                if (rawTotalHoursWorked >= lembur)
                {
                    statusKerja = "Lembur";
                }
                else if (rawTotalHoursWorked >= masuk && rawTotalHoursWorked < lembur)
                {
                    statusKerja = "Masuk";
                }
                else
                {
                    statusKerja = "Setengah Hari";
                }

                statusKerjaList.Add(statusKerja);
            }
            return statusKerjaList;
        }


        private void InsertStatus()
        {
            //buat list baru yang akan dimasukkan status yang ada
            List<string> status = StatusKerja();

            for (int i = 0; i < status.Count; i++)
            {
                Admin A = new Admin();
                A.UpdateStatusAttendance(status);
            }
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("IMPORT DATA? \nMAKE SURE ALL THE FORM FIELDS FILLED CORRECTLY", "DATA ENTRY", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    if (tbName.Text == "" || tbPath.Text == "" || dgExcel.Rows.Count == 0)
                    {
                        MessageBox.Show("FORM FIELD(S) CAN NOT BE LEFT EMPTY. PLEASE COMPLETE THE FORM TO IMPORT DATA", "DATA ENTRY ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbName.Focus();
                    }
                    else
                    {
                        Config con = new Config();
                        SqlConnection SQLcon = con.ConnectSQL();
                        using (SqlCommand SQLcom = new SqlCommand())
                        {
                            SQLcom.Connection = SQLcon;
                            SQLcon.Open();

                            for (int i = 1; i <= dgExcel.Rows.Count - 2; i++)
                            {
                                string CompleteDateTime;
                                string year, month, date, FinalDate;
                                string hh, mm, ss, FinalTime;

                                string FuncKey, EmpNIP, AttDateTime;
                                CompleteDateTime = dgExcel.Rows[i].Cells["Event Time"].Value.ToString();

                                date = CompleteDateTime.Substring(0, 2);
                                month = CompleteDateTime.Substring(3, 2);
                                year = CompleteDateTime.Substring(6, 4);
                                FinalDate = year + "-" + month + "-" + date;

                                hh = CompleteDateTime.Substring(11, 2);
                                mm = CompleteDateTime.Substring(14, 2);
                                ss = CompleteDateTime.Substring(17, 2);
                                FinalTime = hh + ":" + mm + ":" + ss;

                                AttDateTime = "'" + FinalDate + " " + FinalTime + "'";

                                FuncKey = dgExcel.Rows[i].Cells["Function Key"].Value.ToString();


                                EmpNIP = dgExcel.Rows[i].Cells["NIP"].Value.ToString();
                                EmpNIP = "'" + EmpNIP + "'";



                                string SuperQuery;
                                string QueryCheck = "SELECT TOP 1 AttendanceDate, EmployeeNIP FROM Employees.Attendance WHERE AttendanceDate = " + "'" + FinalDate + "'" + " AND EmployeeNIP = " + EmpNIP + "";
                                SqlCommand sqlcom = new SqlCommand(QueryCheck, SQLcon);
                                SqlDataReader dr = sqlcom.ExecuteReader();
                                if (dr.HasRows)
                                {
                                    SQLcon.Close();
                                    SQLcon.Open();
                                    if (FuncKey == "F1")
                                    {
                                        SuperQuery = "UPDATE Employees.Attendance SET AttendanceIn=" + AttDateTime + " WHERE AttendanceDate=" + "'" + FinalDate + "'" + " AND EmployeeNIP=" + EmpNIP + "";
                                    }
                                    else
                                    {
                                        SuperQuery = "UPDATE Employees.Attendance SET AttendanceOut=" + AttDateTime + " WHERE AttendanceDate=" + "'" + FinalDate + "'" + " AND EmployeeNIP=" + EmpNIP + "";
                                    }

                                    SqlCommand SQLcomm = new SqlCommand(SuperQuery, SQLcon);
                                    SQLcomm.ExecuteNonQuery();
                                }
                                else
                                {
                                    SQLcon.Close();
                                    SQLcon.Open();
                                    if (FuncKey == "F1")
                                    {
                                        SuperQuery = "INSERT INTO Employees.Attendance(AttendanceDate, AttendanceIn, EmployeeNIP) VALUES (" + "'" + FinalDate + "'" + ", " + AttDateTime + ", " + EmpNIP + ")";
                                    }
                                    else
                                    {
                                        SuperQuery = "INSERT INTO Employees.Attendance(AttendanceDate, AttendanceOut, EmployeeNIP) VALUES (" + "'" + FinalDate + "'" + ", " + AttDateTime + ", " + EmpNIP + ")";
                                    }

                                    SqlCommand sqlComm = new SqlCommand(SuperQuery, SQLcon);
                                    sqlComm.ExecuteNonQuery();
                                }
                            }
                            SQLcon.Close();

                            InsertStatus();
                        }
                        MessageBox.Show("SUCCESSFULLY IMPORTED", "DATA SAVED TO DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbName.Clear();
                        tbPath.Clear();
                    }
                }
            }
            catch (SqlException ed)
            {
                MessageBox.Show(ed.ToString(), "ERROR OCCURS", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
