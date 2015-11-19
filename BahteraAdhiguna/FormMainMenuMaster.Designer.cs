namespace BahteraAdhiguna
{
    partial class FormMainMenuMaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainMenuMaster));
            this.btnPayroll = new System.Windows.Forms.Button();
            this.btnContract = new System.Windows.Forms.Button();
            this.btnCash = new System.Windows.Forms.Button();
            this.gbInformation = new System.Windows.Forms.GroupBox();
            this.lblUser = new System.Windows.Forms.LinkLabel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDates = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTimes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnAttendance = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnWeb = new System.Windows.Forms.Button();
            this.notifyContract = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnEmployeeMenu = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPayroll
            // 
            this.btnPayroll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPayroll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayroll.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayroll.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnPayroll.Image = ((System.Drawing.Image)(resources.GetObject("btnPayroll.Image")));
            this.btnPayroll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayroll.Location = new System.Drawing.Point(405, 91);
            this.btnPayroll.Name = "btnPayroll";
            this.btnPayroll.Size = new System.Drawing.Size(176, 108);
            this.btnPayroll.TabIndex = 0;
            this.btnPayroll.Text = "Payroll Management";
            this.btnPayroll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPayroll.UseVisualStyleBackColor = false;
            this.btnPayroll.Click += new System.EventHandler(this.btnPayroll_Click);
            // 
            // btnContract
            // 
            this.btnContract.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnContract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContract.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContract.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnContract.Image = ((System.Drawing.Image)(resources.GetObject("btnContract.Image")));
            this.btnContract.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContract.Location = new System.Drawing.Point(223, 204);
            this.btnContract.Name = "btnContract";
            this.btnContract.Size = new System.Drawing.Size(540, 51);
            this.btnContract.TabIndex = 1;
            this.btnContract.Text = "Contract Management";
            this.btnContract.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnContract.UseVisualStyleBackColor = false;
            this.btnContract.Click += new System.EventHandler(this.btnContract_Click);
            // 
            // btnCash
            // 
            this.btnCash.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCash.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCash.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnCash.Image = ((System.Drawing.Image)(resources.GetObject("btnCash.Image")));
            this.btnCash.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCash.Location = new System.Drawing.Point(223, 318);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(540, 51);
            this.btnCash.TabIndex = 2;
            this.btnCash.Text = "Petty Cash Management";
            this.btnCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCash.UseVisualStyleBackColor = false;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // gbInformation
            // 
            this.gbInformation.BackColor = System.Drawing.Color.Transparent;
            this.gbInformation.Controls.Add(this.lblUser);
            this.gbInformation.Controls.Add(this.lblDate);
            this.gbInformation.Controls.Add(this.lblDates);
            this.gbInformation.Controls.Add(this.lblTime);
            this.gbInformation.Controls.Add(this.lblTimes);
            this.gbInformation.Controls.Add(this.label1);
            this.gbInformation.ForeColor = System.Drawing.Color.White;
            this.gbInformation.Location = new System.Drawing.Point(769, 91);
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.Size = new System.Drawing.Size(201, 145);
            this.gbInformation.TabIndex = 4;
            this.gbInformation.TabStop = false;
            this.gbInformation.Text = "Information";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(107, 31);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(64, 20);
            this.lblUser.TabIndex = 9;
            this.lblUser.TabStop = true;
            this.lblUser.Text = "XXXXX";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblUser_LinkClicked);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(107, 91);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(64, 20);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "XXXXX";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDates
            // 
            this.lblDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDates.Location = new System.Drawing.Point(49, 91);
            this.lblDates.Name = "lblDates";
            this.lblDates.Size = new System.Drawing.Size(52, 20);
            this.lblDates.TabIndex = 7;
            this.lblDates.Text = "Date :";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(107, 60);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(64, 20);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "XXXXX";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTimes
            // 
            this.lblTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimes.Location = new System.Drawing.Point(50, 60);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.Size = new System.Drawing.Size(51, 20);
            this.lblTimes.TabIndex = 5;
            this.lblTimes.Text = "Time :";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Logged As :";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnAttendance
            // 
            this.btnAttendance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttendance.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttendance.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnAttendance.Image = ((System.Drawing.Image)(resources.GetObject("btnAttendance.Image")));
            this.btnAttendance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttendance.Location = new System.Drawing.Point(587, 91);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(176, 108);
            this.btnAttendance.TabIndex = 3;
            this.btnAttendance.Text = "Attendance Management";
            this.btnAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAttendance.UseVisualStyleBackColor = false;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.SteelBlue;
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.Location = new System.Drawing.Point(769, 242);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(201, 61);
            this.btnHelp.TabIndex = 10;
            this.btnHelp.Text = "HELP";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Firebrick;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(769, 309);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(201, 61);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "EXIT";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(12, 90);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(200, 200);
            this.pbLogo.TabIndex = 14;
            this.pbLogo.TabStop = false;
            // 
            // btnWeb
            // 
            this.btnWeb.BackColor = System.Drawing.Color.CadetBlue;
            this.btnWeb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWeb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeb.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeb.ForeColor = System.Drawing.Color.White;
            this.btnWeb.Image = ((System.Drawing.Image)(resources.GetObject("btnWeb.Image")));
            this.btnWeb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWeb.Location = new System.Drawing.Point(12, 296);
            this.btnWeb.Name = "btnWeb";
            this.btnWeb.Size = new System.Drawing.Size(200, 73);
            this.btnWeb.TabIndex = 16;
            this.btnWeb.Text = "WEBSITE";
            this.btnWeb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWeb.UseVisualStyleBackColor = false;
            this.btnWeb.Click += new System.EventHandler(this.btnWeb_Click);
            // 
            // notifyContract
            // 
            this.notifyContract.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.notifyContract.BalloonTipText = "PLEASE CHECK CONTRACT MANAGAMENT FOR MORE INFORMATION";
            this.notifyContract.BalloonTipTitle = "CONTRACT NEAR EXPIRED";
            this.notifyContract.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyContract.Icon")));
            this.notifyContract.Text = "IHRIS (CONTRACT EXPIRED)";
            this.notifyContract.BalloonTipClicked += new System.EventHandler(this.notifyContract_BalloonTipClicked);
            this.notifyContract.BalloonTipClosed += new System.EventHandler(this.notifyContract_BalloonTipClosed);
            this.notifyContract.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyContract_MouseClick);
            this.notifyContract.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyContract_MouseDoubleClick);
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventory.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnInventory.Image = ((System.Drawing.Image)(resources.GetObject("btnInventory.Image")));
            this.btnInventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventory.Location = new System.Drawing.Point(223, 261);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(540, 51);
            this.btnInventory.TabIndex = 47;
            this.btnInventory.Text = "Inventory Management";
            this.btnInventory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnEmployeeMenu
            // 
            this.btnEmployeeMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEmployeeMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployeeMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployeeMenu.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnEmployeeMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployeeMenu.Image")));
            this.btnEmployeeMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployeeMenu.Location = new System.Drawing.Point(223, 91);
            this.btnEmployeeMenu.Name = "btnEmployeeMenu";
            this.btnEmployeeMenu.Size = new System.Drawing.Size(540, 108);
            this.btnEmployeeMenu.TabIndex = 48;
            this.btnEmployeeMenu.Text = "Employee Management";
            this.btnEmployeeMenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEmployeeMenu.UseVisualStyleBackColor = false;
            this.btnEmployeeMenu.Click += new System.EventHandler(this.btnEmployeeMenu_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployee.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnEmployee.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployee.Image")));
            this.btnEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployee.Location = new System.Drawing.Point(223, 91);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(176, 108);
            this.btnEmployee.TabIndex = 49;
            this.btnEmployee.Text = "Employee Management";
            this.btnEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(368, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 65);
            this.label2.TabIndex = 50;
            this.label2.Text = "IHRIS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(512, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 25);
            this.label4.TabIndex = 51;
            this.label4.Text = "V. 1.0.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(230, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(523, 25);
            this.label5.TabIndex = 52;
            this.label5.Text = "INTEGRATED HUMAN RESOURCE INFORMATION SYSTEM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(305, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(373, 15);
            this.label3.TabIndex = 53;
            this.label3.Text = "©2015. PT PELAYARAN BAHTERA ADHIGUNA. ALL RIGHTS RESERVED";
            // 
            // FormMainMenuMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BahteraAdhiguna.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(983, 409);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEmployeeMenu);
            this.Controls.Add(this.btnEmployee);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnWeb);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnAttendance);
            this.Controls.Add(this.gbInformation);
            this.Controls.Add(this.btnCash);
            this.Controls.Add(this.btnContract);
            this.Controls.Add(this.btnPayroll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMainMenuMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu - PT Pelayaran Bahtera Adhiguna";
            this.Load += new System.EventHandler(this.FormMainMenuMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMainMenuMaster_KeyDown);
            this.gbInformation.ResumeLayout(false);
            this.gbInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPayroll;
        private System.Windows.Forms.Button btnContract;
        private System.Windows.Forms.Button btnCash;
        private System.Windows.Forms.GroupBox gbInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTimes;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDates;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnWeb;
        private System.Windows.Forms.NotifyIcon notifyContract;
        private System.Windows.Forms.LinkLabel lblUser;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnEmployeeMenu;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}