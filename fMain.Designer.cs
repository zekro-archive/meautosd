namespace meautosd
{
    partial class fMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.lbStatus = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btCancelTask = new System.Windows.Forms.Button();
            this.lbTask = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btStartTimer = new System.Windows.Forms.Button();
            this.lable15 = new System.Windows.Forms.Label();
            this.nudMin = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudHrs = new System.Windows.Forms.NumericUpDown();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.cbTask = new System.Windows.Forms.ComboBox();
            this.cbClose = new System.Windows.Forms.CheckBox();
            this.cbWriteLog = new System.Windows.Forms.CheckBox();
            this.nudDelay = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.pbDonate = new System.Windows.Forms.PictureBox();
            this.perfTimer = new System.Windows.Forms.Timer(this.components);
            this.llLogFile = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDonate)).BeginInit();
            this.SuspendLayout();
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(19, 18);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(79, 24);
            this.lbStatus.TabIndex = 1;
            this.lbStatus.Text = "<status>";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btCancelTask
            // 
            this.btCancelTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelTask.Enabled = false;
            this.btCancelTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelTask.Location = new System.Drawing.Point(23, 222);
            this.btCancelTask.Name = "btCancelTask";
            this.btCancelTask.Size = new System.Drawing.Size(103, 22);
            this.btCancelTask.TabIndex = 10;
            this.btCancelTask.Text = "Cancel task";
            this.btCancelTask.UseVisualStyleBackColor = true;
            this.btCancelTask.Click += new System.EventHandler(this.btCancelTask_Click);
            // 
            // lbTask
            // 
            this.lbTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTask.AutoSize = true;
            this.lbTask.Location = new System.Drawing.Point(148, 195);
            this.lbTask.Name = "lbTask";
            this.lbTask.Size = new System.Drawing.Size(0, 13);
            this.lbTask.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btStartTimer
            // 
            this.btStartTimer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btStartTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStartTimer.Location = new System.Drawing.Point(292, 158);
            this.btStartTimer.Name = "btStartTimer";
            this.btStartTimer.Size = new System.Drawing.Size(83, 22);
            this.btStartTimer.TabIndex = 16;
            this.btStartTimer.Text = "Start timer";
            this.btStartTimer.UseVisualStyleBackColor = true;
            this.btStartTimer.Click += new System.EventHandler(this.btStartTimer_Click_1);
            // 
            // lable15
            // 
            this.lable15.AutoSize = true;
            this.lable15.Location = new System.Drawing.Point(362, 101);
            this.lable15.Name = "lable15";
            this.lable15.Size = new System.Drawing.Size(15, 13);
            this.lable15.TabIndex = 15;
            this.lable15.Text = "m";
            // 
            // nudMin
            // 
            this.nudMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.nudMin.ForeColor = System.Drawing.Color.White;
            this.nudMin.Location = new System.Drawing.Point(292, 99);
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(64, 20);
            this.nudMin.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "h";
            // 
            // nudHrs
            // 
            this.nudHrs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.nudHrs.ForeColor = System.Drawing.Color.White;
            this.nudHrs.Location = new System.Drawing.Point(292, 66);
            this.nudHrs.Name = "nudHrs";
            this.nudHrs.Size = new System.Drawing.Size(64, 20);
            this.nudHrs.TabIndex = 13;
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // cbTask
            // 
            this.cbTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.cbTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTask.ForeColor = System.Drawing.Color.White;
            this.cbTask.FormattingEnabled = true;
            this.cbTask.Items.AddRange(new object[] {
            "Shutdown",
            "Hibernate",
            "Standby",
            "Do Nothing"});
            this.cbTask.Location = new System.Drawing.Point(51, 66);
            this.cbTask.Name = "cbTask";
            this.cbTask.Size = new System.Drawing.Size(156, 21);
            this.cbTask.TabIndex = 21;
            this.cbTask.Text = "Shutdown";
            this.cbTask.SelectedIndexChanged += new System.EventHandler(this.cbTask_SelectedIndexChanged_1);
            // 
            // cbClose
            // 
            this.cbClose.AutoSize = true;
            this.cbClose.Location = new System.Drawing.Point(50, 187);
            this.cbClose.Name = "cbClose";
            this.cbClose.Size = new System.Drawing.Size(100, 17);
            this.cbClose.TabIndex = 20;
            this.cbClose.Text = "Close after enc.";
            this.cbClose.UseVisualStyleBackColor = true;
            // 
            // cbWriteLog
            // 
            this.cbWriteLog.AutoSize = true;
            this.cbWriteLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.cbWriteLog.Location = new System.Drawing.Point(49, 164);
            this.cbWriteLog.Name = "cbWriteLog";
            this.cbWriteLog.Size = new System.Drawing.Size(84, 17);
            this.cbWriteLog.TabIndex = 19;
            this.cbWriteLog.Text = "Write log file";
            this.cbWriteLog.UseVisualStyleBackColor = false;
            this.cbWriteLog.CheckedChanged += new System.EventHandler(this.cbWriteLog_CheckedChanged_1);
            // 
            // nudDelay
            // 
            this.nudDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.nudDelay.ForeColor = System.Drawing.Color.White;
            this.nudDelay.Location = new System.Drawing.Point(51, 128);
            this.nudDelay.Name = "nudDelay";
            this.nudDelay.Size = new System.Drawing.Size(156, 20);
            this.nudDelay.TabIndex = 18;
            this.nudDelay.ValueChanged += new System.EventHandler(this.nudDelay_ValueChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Time delay (minutes):";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(13, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(268, 66);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(13, 134);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // pbStatus
            // 
            this.pbStatus.Image = ((System.Drawing.Image)(resources.GetObject("pbStatus.Image")));
            this.pbStatus.Location = new System.Drawing.Point(-2, -1);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(8, 520);
            this.pbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbStatus.TabIndex = 24;
            this.pbStatus.TabStop = false;
            // 
            // pbDonate
            // 
            this.pbDonate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDonate.Image = ((System.Drawing.Image)(resources.GetObject("pbDonate.Image")));
            this.pbDonate.Location = new System.Drawing.Point(399, 221);
            this.pbDonate.Name = "pbDonate";
            this.pbDonate.Size = new System.Drawing.Size(23, 23);
            this.pbDonate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDonate.TabIndex = 25;
            this.pbDonate.TabStop = false;
            this.pbDonate.Click += new System.EventHandler(this.pbDonate_Click);
            // 
            // perfTimer
            // 
            this.perfTimer.Interval = 1000;
            this.perfTimer.Tick += new System.EventHandler(this.perfTimer_Tick);
            // 
            // llLogFile
            // 
            this.llLogFile.AutoSize = true;
            this.llLogFile.LinkColor = System.Drawing.Color.Cyan;
            this.llLogFile.Location = new System.Drawing.Point(129, 165);
            this.llLogFile.Name = "llLogFile";
            this.llLogFile.Size = new System.Drawing.Size(39, 13);
            this.llLogFile.TabIndex = 29;
            this.llLogFile.TabStop = true;
            this.llLogFile.Text = "[Open]";
            this.llLogFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llLogFile_LinkClicked);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(434, 256);
            this.Controls.Add(this.llLogFile);
            this.Controls.Add(this.pbDonate);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btStartTimer);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lable15);
            this.Controls.Add(this.cbTask);
            this.Controls.Add(this.nudMin);
            this.Controls.Add(this.cbClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudHrs);
            this.Controls.Add(this.cbWriteLog);
            this.Controls.Add(this.lbTask);
            this.Controls.Add(this.nudDelay);
            this.Controls.Add(this.btCancelTask);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbStatus);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.Text = "Media Encoder Auto Shutdown";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
            this.Load += new System.EventHandler(this.fMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDonate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btCancelTask;
        private System.Windows.Forms.Label lbTask;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown nudMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudHrs;
        private System.Windows.Forms.Button btStartTimer;
        private System.Windows.Forms.Label lable15;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.ComboBox cbTask;
        private System.Windows.Forms.CheckBox cbClose;
        private System.Windows.Forms.CheckBox cbWriteLog;
        private System.Windows.Forms.NumericUpDown nudDelay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pbStatus;
        private System.Windows.Forms.PictureBox pbDonate;
        private System.Windows.Forms.Timer perfTimer;
        private System.Windows.Forms.LinkLabel llLogFile;
    }
}

