namespace BahteraAdhiguna
{
    partial class FormAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAttendance));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.panelControl = new System.Windows.Forms.Panel();
            this.label32 = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnFullscreen = new System.Windows.Forms.Button();
            this.gbInformation = new System.Windows.Forms.GroupBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDates = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTimes = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.ContractTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.importBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgExcel = new System.Windows.Forms.DataGridView();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.niMinimized = new System.Windows.Forms.NotifyIcon(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.gbInformation.SuspendLayout();
            this.ContractTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(461, 729);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(373, 15);
            this.label3.TabIndex = 39;
            this.label3.Text = "©2015. PT PELAYARAN BAHTERA ADHIGUNA. ALL RIGHTS RESERVED";
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.Color.Black;
            this.panelControl.Controls.Add(this.label32);
            this.panelControl.Controls.Add(this.btnMinimize);
            this.panelControl.Controls.Add(this.btnReport);
            this.panelControl.Controls.Add(this.pbLogo);
            this.panelControl.Controls.Add(this.btnFullscreen);
            this.panelControl.Controls.Add(this.gbInformation);
            this.panelControl.Controls.Add(this.btnHelp);
            this.panelControl.Controls.Add(this.btnLogout);
            this.panelControl.Controls.Add(this.btnMainMenu);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl.Location = new System.Drawing.Point(1077, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(218, 750);
            this.panelControl.TabIndex = 40;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Dock = System.Windows.Forms.DockStyle.Top;
            this.label32.Font = new System.Drawing.Font("Segoe UI Black", 50.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(0, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(222, 89);
            this.label32.TabIndex = 90;
            this.label32.Text = "IHRIS";
            this.label32.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.White;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.Black;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(79, 434);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(61, 61);
            this.btnMinimize.TabIndex = 40;
            this.btnMinimize.UseVisualStyleBackColor = false;
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.White;
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.Black;
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.Location = new System.Drawing.Point(9, 434);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(61, 61);
            this.btnReport.TabIndex = 39;
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(34, 104);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(150, 150);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 38;
            this.pbLogo.TabStop = false;
            // 
            // btnFullscreen
            // 
            this.btnFullscreen.BackColor = System.Drawing.Color.White;
            this.btnFullscreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFullscreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFullscreen.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFullscreen.ForeColor = System.Drawing.Color.Black;
            this.btnFullscreen.Image = ((System.Drawing.Image)(resources.GetObject("btnFullscreen.Image")));
            this.btnFullscreen.Location = new System.Drawing.Point(149, 434);
            this.btnFullscreen.Name = "btnFullscreen";
            this.btnFullscreen.Size = new System.Drawing.Size(61, 61);
            this.btnFullscreen.TabIndex = 34;
            this.btnFullscreen.UseVisualStyleBackColor = false;
            this.btnFullscreen.Click += new System.EventHandler(this.btnFullscreen_Click);
            // 
            // gbInformation
            // 
            this.gbInformation.BackColor = System.Drawing.Color.Transparent;
            this.gbInformation.Controls.Add(this.lblDate);
            this.gbInformation.Controls.Add(this.lblDates);
            this.gbInformation.Controls.Add(this.lblTime);
            this.gbInformation.Controls.Add(this.lblTimes);
            this.gbInformation.Controls.Add(this.label7);
            this.gbInformation.Controls.Add(this.lblUser);
            this.gbInformation.ForeColor = System.Drawing.Color.White;
            this.gbInformation.Location = new System.Drawing.Point(9, 275);
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.Size = new System.Drawing.Size(201, 127);
            this.gbInformation.TabIndex = 33;
            this.gbInformation.TabStop = false;
            this.gbInformation.Text = "Information";
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
            this.lblTimes.BackColor = System.Drawing.Color.Transparent;
            this.lblTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimes.Location = new System.Drawing.Point(50, 60);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.Size = new System.Drawing.Size(51, 20);
            this.lblTimes.TabIndex = 5;
            this.lblTimes.Text = "Time :";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Logged As :";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(107, 31);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(64, 20);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "XXXXX";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.SteelBlue;
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.Color.Black;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.Location = new System.Drawing.Point(9, 501);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(201, 61);
            this.btnHelp.TabIndex = 31;
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
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(9, 635);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(201, 61);
            this.btnLogout.TabIndex = 30;
            this.btnLogout.Text = "EXIT";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.Color.Gold;
            this.btnMainMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.ForeColor = System.Drawing.Color.Black;
            this.btnMainMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMainMenu.Image")));
            this.btnMainMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMainMenu.Location = new System.Drawing.Point(10, 568);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(201, 61);
            this.btnMainMenu.TabIndex = 32;
            this.btnMainMenu.Text = "MENU";
            this.btnMainMenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // ContractTabControl
            // 
            this.ContractTabControl.Controls.Add(this.tabPage1);
            this.ContractTabControl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ContractTabControl.Location = new System.Drawing.Point(12, 58);
            this.ContractTabControl.Name = "ContractTabControl";
            this.ContractTabControl.SelectedIndex = 0;
            this.ContractTabControl.Size = new System.Drawing.Size(1053, 670);
            this.ContractTabControl.TabIndex = 92;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.importBtn);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dgExcel);
            this.tabPage1.Controls.Add(this.tbName);
            this.tabPage1.Controls.Add(this.tbPath);
            this.tabPage1.Controls.Add(this.btnLoad);
            this.tabPage1.Controls.Add(this.btnBrowse);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1045, 640);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "ATTENDANCE DATA IMPORT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(20, 577);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(300, 34);
            this.label5.TabIndex = 16;
            this.label5.Text = "Note: After loading the Excel file, to add the files\r\nto database press import to" +
    " database button.";
            // 
            // importBtn
            // 
            this.importBtn.BackColor = System.Drawing.Color.SpringGreen;
            this.importBtn.Font = new System.Drawing.Font("Segoe UI Black", 35.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.importBtn.Location = new System.Drawing.Point(6, 488);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(326, 75);
            this.importBtn.TabIndex = 15;
            this.importBtn.Text = "IMPORT";
            this.importBtn.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.importBtn.UseVisualStyleBackColor = false;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(151, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Sheet To Open (e.g. : Sheet1)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(151, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Excel File Name";
            // 
            // dgExcel
            // 
            this.dgExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExcel.Location = new System.Drawing.Point(338, 6);
            this.dgExcel.Name = "dgExcel";
            this.dgExcel.ReadOnly = true;
            this.dgExcel.Size = new System.Drawing.Size(701, 628);
            this.dgExcel.TabIndex = 12;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(154, 119);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(175, 25);
            this.tbName.TabIndex = 11;
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(154, 38);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(175, 25);
            this.tbPath.TabIndex = 10;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.DarkOrange;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI Black", 18.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnLoad.Location = new System.Drawing.Point(6, 88);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(139, 78);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "LOAD \r\nEXCEL";
            this.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.Violet;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI Black", 18.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnBrowse.Location = new System.Drawing.Point(6, 6);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(139, 76);
            this.btnBrowse.TabIndex = 8;
            this.btnBrowse.Text = "BROWSE";
            this.btnBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // niMinimized
            // 
            this.niMinimized.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.niMinimized.BalloonTipText = "APPLICATION RUNNING IN BACKGROUND";
            this.niMinimized.BalloonTipTitle = "PT PELAYARAN BAHTERA ADHIGUNA";
            this.niMinimized.Icon = ((System.Drawing.Icon)(resources.GetObject("niMinimized.Icon")));
            this.niMinimized.Text = "IHRIS v.1.0.0";
            this.niMinimized.Visible = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(322, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(591, 50);
            this.label2.TabIndex = 27;
            this.label2.Text = "       ATTENDANCE MANAGEMENT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1295, 750);
            this.Controls.Add(this.ContractTabControl);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendance Management Form - PT Pelayaran Bahtera Adhiguna";
            this.Load += new System.EventHandler(this.FormAttendance_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormAttendance_KeyDown);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.gbInformation.ResumeLayout(false);
            this.gbInformation.PerformLayout();
            this.ContractTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnFullscreen;
        private System.Windows.Forms.GroupBox gbInformation;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDates;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTimes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.TabControl ContractTabControl;
        private System.Windows.Forms.NotifyIcon niMinimized;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgExcel;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnBrowse;
    }
}