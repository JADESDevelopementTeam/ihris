namespace BahteraAdhiguna
{
    partial class ToolsPingPong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolsPingPong));
            this.playground = new System.Windows.Forms.Panel();
            this.lblGameOver = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.pbBall = new System.Windows.Forms.PictureBox();
            this.pbRacket = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.playground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRacket)).BeginInit();
            this.SuspendLayout();
            // 
            // playground
            // 
            this.playground.BackColor = System.Drawing.Color.White;
            this.playground.Controls.Add(this.lblGameOver);
            this.playground.Controls.Add(this.lblPoints);
            this.playground.Controls.Add(this.lblScore);
            this.playground.Controls.Add(this.pbBall);
            this.playground.Controls.Add(this.pbRacket);
            this.playground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playground.Location = new System.Drawing.Point(0, 0);
            this.playground.Name = "playground";
            this.playground.Size = new System.Drawing.Size(792, 451);
            this.playground.TabIndex = 0;
            // 
            // lblGameOver
            // 
            this.lblGameOver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver.Location = new System.Drawing.Point(254, 152);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(205, 100);
            this.lblGameOver.TabIndex = 4;
            this.lblGameOver.Text = "GAME OVER\r\n\r\nF1 - Restart Game\r\nEsc - Exit Game";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.Location = new System.Drawing.Point(178, 13);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(25, 25);
            this.lblPoints.TabIndex = 3;
            this.lblPoints.Text = "0";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(13, 13);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(112, 25);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "SCORE : ";
            // 
            // pbBall
            // 
            this.pbBall.BackColor = System.Drawing.Color.Red;
            this.pbBall.Location = new System.Drawing.Point(27, 50);
            this.pbBall.Name = "pbBall";
            this.pbBall.Size = new System.Drawing.Size(20, 20);
            this.pbBall.TabIndex = 1;
            this.pbBall.TabStop = false;
            // 
            // pbRacket
            // 
            this.pbRacket.BackColor = System.Drawing.Color.Black;
            this.pbRacket.Location = new System.Drawing.Point(324, 399);
            this.pbRacket.Name = "pbRacket";
            this.pbRacket.Size = new System.Drawing.Size(100, 25);
            this.pbRacket.TabIndex = 0;
            this.pbRacket.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ToolsPingPong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 451);
            this.Controls.Add(this.playground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ToolsPingPong";
            this.Text = "ToolsPingPong";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolsPingPong_KeyDown);
            this.playground.ResumeLayout(false);
            this.playground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRacket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel playground;
        private System.Windows.Forms.PictureBox pbRacket;
        private System.Windows.Forms.PictureBox pbBall;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblGameOver;
    }
}