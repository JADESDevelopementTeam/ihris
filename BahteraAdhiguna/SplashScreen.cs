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
    public partial class SplashScreen : Form
    {
        private delegate void ProgressDelegate(int progress);

        private ProgressDelegate del;
        public SplashScreen()
        {
            InitializeComponent();
            this.progressBar1.Maximum = 100;
            del = this.UpdateProgressInternal;

            this.KeyPreview = true;
        }

        private void UpdateProgressInternal(int progress)
        {
            if (this.Handle == null)
            {
                return;
            }

            this.progressBar1.Value = progress;
        }

        public void UpdateProgress(int progress)
        {
            this.Invoke(del, progress);
        }
    }
}
