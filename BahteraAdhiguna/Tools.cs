using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;
using System.Data.SqlClient;

namespace BahteraAdhiguna
{
    public partial class Tools : Form
    {
        
        public Tools()
        {
            InitializeComponent();

            this.KeyPreview = true;
        }

        

        //CALCULATOR
        int sign_Indicator = 0;
        double variable1;
        double variable2;
        int additionPart = 0;
        int subbtractionPart = 0;
        int multiplicationPart = 0;
        int divisionPart = 0;
        int modBit = 0;
        Boolean fl = false;
        String s, x;

        private void button1_Click(object sender, EventArgs e)
        {
            if (sign_Indicator == 0)
            {
                txtInput.Text = txtInput.Text + Convert.ToString(1);
            }
            else if (sign_Indicator == 1)
            {
                txtInput.Text = Convert.ToString(1);
                sign_Indicator = 0;
            }
            fl = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sign_Indicator == 0)
            {
                txtInput.Text = txtInput.Text + Convert.ToString(2);
            }
            else if (sign_Indicator == 1)
            {
                txtInput.Text = Convert.ToString(2);
                sign_Indicator = 0;
            }
            fl = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sign_Indicator == 0)
            {
                txtInput.Text = txtInput.Text + Convert.ToString(3);
            }
            else if (sign_Indicator == 1)
            {
                txtInput.Text = Convert.ToString(3);
                sign_Indicator = 0;
            }
            fl = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (sign_Indicator == 0)
            {
                txtInput.Text = txtInput.Text + Convert.ToString(4);
            }
            else if (sign_Indicator == 1)
            {
                txtInput.Text = Convert.ToString(4);
                sign_Indicator = 0;
            }
            fl = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (sign_Indicator == 0)
            {
                txtInput.Text = txtInput.Text + Convert.ToString(5);
            }
            else if (sign_Indicator == 1)
            {
                txtInput.Text = Convert.ToString(5);
                sign_Indicator = 0;
            }
            fl = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (sign_Indicator == 0)
            {
                txtInput.Text = txtInput.Text + Convert.ToString(6);
            }
            else if (sign_Indicator == 1)
            {
                txtInput.Text = Convert.ToString(6);
                sign_Indicator = 0;
            }
            fl = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (sign_Indicator == 0)
            {
                txtInput.Text = txtInput.Text + Convert.ToString(7);
            }
            else if (sign_Indicator == 1)
            {
                txtInput.Text = Convert.ToString(7);
                sign_Indicator = 0;
            }
            fl = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (sign_Indicator == 0)
            {
                txtInput.Text = txtInput.Text + Convert.ToString(8);
            }
            else if (sign_Indicator == 1)
            {
                txtInput.Text = Convert.ToString(8);
                sign_Indicator = 0;
            }
            fl = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (sign_Indicator == 0)
            {
                txtInput.Text = txtInput.Text + Convert.ToString(9);
            }
            else if (sign_Indicator == 1)
            {
                txtInput.Text = Convert.ToString(9);
                sign_Indicator = 0;
            }
            fl = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (sign_Indicator == 0)
            {
                txtInput.Text = txtInput.Text + Convert.ToString(0);
            }
            else if (sign_Indicator == 1)
            {
                txtInput.Text = Convert.ToString(0);
                sign_Indicator = 0;
            }
            fl = true;
        }
        private void reset_SignBits()
        {
            additionPart = 0;
            subbtractionPart = 0;
            multiplicationPart = 0;
            divisionPart = 0;
            modBit = 0;
            fl = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length != 0)
            {
                calculate();
                reset_SignBits();
                additionPart = 1;
                sign_Indicator = 1;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            sign_Indicator = 0;
            variable1 = 0;
            variable2 = 0;
            reset_SignBits();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length != 0)
            {
                variable2 = Convert.ToDouble(txtInput.Text);
                calculate();
                reset_SignBits();
                subbtractionPart = 1;
                sign_Indicator = 1;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length != 0)
            {
                calculate();
                reset_SignBits();
                multiplicationPart = 1;
                sign_Indicator = 1;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length != 0)
            {
                calculate();
                reset_SignBits();
                divisionPart = 1;
                sign_Indicator = 1;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length != 0)
            {
                calculate();
                reset_SignBits();
            }
            sign_Indicator = 1;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            int i = 0;
            char chr = '\0';
            int decimal_Indicator = 0;
            int l = txtInput.Text.Length - 1;
            if (sign_Indicator != 1)
            {
                for (i = 0; i <= l; i++)
                {
                    chr = txtInput.Text[i];
                    if (chr == '.')
                    {
                        decimal_Indicator = 1;
                    }
                }

                if (decimal_Indicator != 1)
                {
                    txtInput.Text = txtInput.Text + Convert.ToString(".");
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            double s, l;
            l = Convert.ToDouble(txtInput.Text);
            s = Math.Sqrt(l);
            txtInput.Text = Convert.ToString(s);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            txtInput.Text = (1 / Convert.ToDouble(txtInput.Text)).ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                long fact = 1;
                for (int i = 1; i <= Convert.ToInt32(txtInput.Text); i++)
                {
                    fact = fact * i;
                }
                txtInput.Text = Convert.ToString(fact);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInput.Text.Length != 0)
                {
                    double l;
                    l = Math.Log(Convert.ToDouble(txtInput.Text));
                    txtInput.Text = Convert.ToString(l);
                }
                sign_Indicator = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInput.Text.Length != 0)
                {
                    double l;
                    l = Math.Log10(Convert.ToDouble(txtInput.Text));
                    txtInput.Text = Convert.ToString(l);
                }
                sign_Indicator = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInput.Text.Length != 0)
                {
                    double l;
                    l = Math.Sin(Convert.ToDouble(txtInput.Text));
                    txtInput.Text = Convert.ToString(l);
                }
                sign_Indicator = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInput.Text.Length != 0)
                {
                    double l;
                    l = Math.Cos(Convert.ToDouble(txtInput.Text));
                    txtInput.Text = Convert.ToString(l);
                }
                sign_Indicator = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInput.Text.Length != 0)
                {
                    double l;
                    l = Math.Tan(Convert.ToDouble(txtInput.Text));
                    txtInput.Text = Convert.ToString(l);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRound_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInput.Text.Length != 0)
                {
                    double l;
                    l = Math.Round(Convert.ToDouble(txtInput.Text));
                    txtInput.Text = Convert.ToString(l);
                }
                sign_Indicator = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFloor_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInput.Text.Length != 0)
                {
                    double l;
                    l = Math.Floor(Convert.ToDouble(txtInput.Text));
                    txtInput.Text = Convert.ToString(l);
                }
                sign_Indicator = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTruncate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInput.Text.Length != 0)
                {
                    double l;
                    l = Math.Truncate(Convert.ToDouble(txtInput.Text));
                    txtInput.Text = Convert.ToString(l);
                }
                sign_Indicator = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCeil_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInput.Text.Length != 0)
                {
                    double l;
                    l = Math.Ceiling(Convert.ToDouble(txtInput.Text));
                    txtInput.Text = Convert.ToString(l);
                }
                sign_Indicator = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInvSin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInput.Text.Length != 0)
                {
                    double l;
                    l = Math.Asin(Convert.ToDouble(txtInput.Text));
                    txtInput.Text = Convert.ToString(l);
                }
                sign_Indicator = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInput.Text.Length != 0)
                {
                    double l;
                    l = Math.Sinh(Convert.ToDouble(txtInput.Text));
                    txtInput.Text = Convert.ToString(l);
                }
                sign_Indicator = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCosh_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInput.Text.Length != 0)
                {
                    double l;
                    l = Math.Cosh(Convert.ToDouble(txtInput.Text));
                    txtInput.Text = Convert.ToString(l);
                }
                sign_Indicator = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInput.Text.Length != 0)
                {
                    double l;
                    l = Math.Tanh(Convert.ToDouble(txtInput.Text));
                    txtInput.Text = Convert.ToString(l);
                }
                sign_Indicator = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInvCos_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInput.Text.Length != 0)
                {
                    double l;
                    l = Math.Acos(Convert.ToDouble(txtInput.Text));
                    txtInput.Text = Convert.ToString(l);
                }
                sign_Indicator = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInvTan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInput.Text.Length != 0)
                {
                    double l;
                    l = Math.Atan(Convert.ToDouble(txtInput.Text));
                    txtInput.Text = Convert.ToString(l);
                }
                sign_Indicator = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calculate()
        {
            if (txtInput.Text != ".")
            {
                variable2 = Convert.ToDouble(txtInput.Text);
                if (fl == false)
                {
                    variable1 = variable2;
                }
                else if (additionPart == 1)
                {
                    variable1 = variable1 + variable2;
                }
                else if (subbtractionPart == 1)
                {
                    variable1 = variable1 - variable2;
                }
                else if (multiplicationPart == 1)
                {
                    variable1 = variable1 * variable2;
                }
                else if (divisionPart == 1)
                {
                    variable1 = variable1 / variable2;
                }
                else if (modBit == 1)
                {

                    variable2 = Convert.ToInt32(txtInput.Text);
                    variable1 = Convert.ToInt32(variable1 % variable2);
                }

                else
                {
                    variable1 = variable2;
                }
                txtInput.Text = Convert.ToString(variable1);

            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length != 0)
            {
                calculate();
                reset_SignBits();
                modBit = 1;
                sign_Indicator = 1;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            txtInput.Text = Math.PI.ToString();
            sign_Indicator = 1;
        }

        private void button27_Click(object sender, EventArgs e)
        {

            s = txtInput.Text;
            int l = s.Length;
            for (int i = 0; i < l - 1; i++)
            {
                x += s[i];
            }
            txtInput.Text = x;
            x = "";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            //OFD.Filter = "Excel Files (*.xlsx)|*.xlsx|Excel Files (*.xls)|*.xls";

            OFD.Title = "Select Excel Files";
            OFD.InitialDirectory = @"c:\";
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
                //string PathConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + tbPath.Text + "; Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;\";";
                string PathConn = @"Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + tbPath.Text + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=1\";";
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

        private void btnSnake_Click(object sender, EventArgs e)
        {
            ToolsSnake S = new ToolsSnake();
            S.ShowDialog();
        }

        private void btnPingPong_Click(object sender, EventArgs e)
        {
            ToolsPingPong P = new ToolsPingPong();
            P.ShowDialog();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            string strQuery;
            try
            {
                
                Config con = new Config();
                var conn = con.ConnectSQL();
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    conn.Open();

                    //make for biar sesuai ama jumlah row yang ada di datatable
                    for (int i = 1; i < dgExcel.Rows.Count; i++)
                    {
                        //bikin variable yang mau dimasukin ke database
                        string a, b, c, d, ee, f, g, h;
                        a = dgExcel.Rows[i].Cells["Event Time"].Value.ToString();
                        a = "'" + a + "'";
                        b = dgExcel.Rows[i].Cells["User Name"].Value.ToString();
                        b = "'" + b + "'";
                        h = dgExcel.Rows[i].Cells["Function Key"].Value.ToString();
                        h = "'" + h + "'";

                        strQuery = @"INSERT INTO Employees.Attendance values ("
                                   + a + ", "
                                   + b + ", "
                                   + h + ");";
                        comm.CommandText = strQuery;
                        comm.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception)
            {
                //SIAL WKWKWKWKW
                MessageBox.Show("SUCCESS!");
                //throw;
            }
        }

        private void btnTicTacToe_Click(object sender, EventArgs e)
        {
            ToolsTicTacToe T = new ToolsTicTacToe();
            T.ShowDialog();
        }
    }
}
