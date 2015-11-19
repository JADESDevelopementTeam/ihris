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
    public partial class frmSelectTables : Form
    {
        public frmSelectTables(string[] strTableStrings)
        {
            InitializeComponent();
            
        }

        public frmSelectTables(DataTable dt)
        {
            InitializeComponent();
            dtTable = dt;
            DataTables = true;
        }
        DataTable dtTable = new DataTable();
        private void SelectTable_Load(object sender, EventArgs e)
        {

        }
    }
}
