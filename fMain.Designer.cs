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
            this.label1 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.rbShutdown = new System.Windows.Forms.RadioButton();
            this.rbStandby = new System.Windows.Forms.RadioButton();
            this.rbHibernate = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbClose = new System.Windows.Forms.CheckBox();
            this.cbWriteLog = new System.Windows.Forms.CheckBox();
            this.nudDelay = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btCancelTask = new System.Windows.Forms.Button();
            this.lbTask = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudHrs = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudMin = new System.Windows.Forms.NumericUpDown();
            this.lable15 = new System.Windows.Forms.Label();
            this.btStartTimer = new System.Windows.Forms.Button();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status:";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(58, 9);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(47, 13);
            this.lbStatus.TabIndex = 1;
            this.lbStatus.Text = "<status>";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // rbShutdown
            // 
            this.rbShutdown.AutoSize = true;
            this.rbShutdown.Location = new System.Drawing.Point(12, 24);
            this.rbShutdown.Name = "rbShutdown";
            this.rbShutdown.Size = new System.Drawing.Size(73, 17);
            this.rbShutdown.TabIndex = 3;
            this.rbShutdown.TabStop = true;
            this.rbShutdown.Text = "Shutdown";
            this.rbShutdown.UseVisualStyleBackColor = true;
            this.rbShutdown.CheckedChanged += new System.EventHandler(this.rbShutdown_CheckedChanged);
            // 
            // rbStandby
            // 
            this.rbStandby.AutoSize = true;
            this.rbStandby.Location = new System.Drawing.Point(12, 47);
            this.rbStandby.Name = "rbStandby";
            this.rbStandby.Size = new System.Drawing.Size(64, 17);
            this.rbStandby.TabIndex = 4;
            this.rbStandby.TabStop = true;
            this.rbStandby.Text = "Standby";
            this.rbStandby.UseVisualStyleBackColor = true;
            this.rbStandby.CheckedChanged += new System.EventHandler(this.rbStandby_CheckedChanged);
            // 
            // rbHibernate
            // 
            this.rbHibernate.AutoSize = true;
            this.rbHibernate.Location = new System.Drawing.Point(12, 70);
            this.rbHibernate.Name = "rbHibernate";
            this.rbHibernate.Size = new System.Drawing.Size(71, 17);
            this.rbHibernate.TabIndex = 5;
            this.rbHibernate.TabStop = true;
            this.rbHibernate.Text = "Hibernate";
            this.rbHibernate.UseVisualStyleBackColor = true;
            this.rbHibernate.CheckedChanged += new System.EventHandler(this.rbHibernate_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbClose);
            this.groupBox1.Controls.Add(this.cbWriteLog);
            this.groupBox1.Controls.Add(this.nudDelay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rbShutdown);
            this.groupBox1.Controls.Add(this.rbStandby);
            this.groupBox1.Controls.Add(this.rbHibernate);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 125);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Task after encoding";
            // 
            // cbClose
            // 
            this.cbClose.AutoSize = true;
            this.cbClose.Location = new System.Drawing.Point(12, 93);
            this.cbClose.Name = "cbClose";
            this.cbClose.Size = new System.Drawing.Size(100, 17);
            this.cbClose.TabIndex = 10;
            this.cbClose.Text = "Close after enc.";
            this.cbClose.UseVisualStyleBackColor = true;
            this.cbClose.CheckedChanged += new System.EventHandler(this.cbClose_CheckedChanged);
            // 
            // cbWriteLog
            // 
            this.cbWriteLog.AutoSize = true;
            this.cbWriteLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.cbWriteLog.Location = new System.Drawing.Point(138, 93);
            this.cbWriteLog.Name = "cbWriteLog";
            this.cbWriteLog.Size = new System.Drawing.Size(84, 17);
            this.cbWriteLog.TabIndex = 9;
            this.cbWriteLog.Text = "Write log file";
            this.cbWriteLog.UseVisualStyleBackColor = false;
            this.cbWriteLog.CheckedChanged += new System.EventHandler(this.cbWriteLog_CheckedChanged);
            // 
            // nudDelay
            // 
            this.nudDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.nudDelay.ForeColor = System.Drawing.Color.White;
            this.nudDelay.Location = new System.Drawing.Point(138, 46);
            this.nudDelay.Name = "nudDelay";
            this.nudDelay.Size = new System.Drawing.Size(155, 20);
            this.nudDelay.TabIndex = 8;
            this.nudDelay.ValueChanged += new System.EventHandler(this.nudDelay_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Time delay (minutes):";
            // 
            // btCancelTask
            // 
            this.btCancelTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCancelTask.Enabled = false;
            this.btCancelTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelTask.Location = new System.Drawing.Point(12, 268);
            this.btCancelTask.Name = "btCancelTask";
            this.btCancelTask.Size = new System.Drawing.Size(103, 22);
            this.btCancelTask.TabIndex = 10;
            this.btCancelTask.Text = "Cancel task";
            this.btCancelTask.UseVisualStyleBackColor = true;
            this.btCancelTask.Click += new System.EventHandler(this.btCancelTask_Click);
            // 
            // lbTask
            // 
            this.lbTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTask.AutoSize = true;
            this.lbTask.Location = new System.Drawing.Point(126, 273);
            this.lbTask.Name = "lbTask";
            this.lbTask.Size = new System.Drawing.Size(0, 13);
            this.lbTask.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btStartTimer);
            this.groupBox2.Controls.Add(this.lable15);
            this.groupBox2.Controls.Add(this.nudMin);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.nudHrs);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 90);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shutdown after specific time";
            // 
            // nudHrs
            // 
            this.nudHrs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.nudHrs.ForeColor = System.Drawing.Color.White;
            this.nudHrs.Location = new System.Drawing.Point(12, 20);
            this.nudHrs.Name = "nudHrs";
            this.nudHrs.Size = new System.Drawing.Size(64, 20);
            this.nudHrs.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "h";
            // 
            // nudMin
            // 
            this.nudMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.nudMin.ForeColor = System.Drawing.Color.White;
            this.nudMin.Location = new System.Drawing.Point(117, 20);
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(64, 20);
            this.nudMin.TabIndex = 14;
            // 
            // lable15
            // 
            this.lable15.AutoSize = true;
            this.lable15.Location = new System.Drawing.Point(186, 22);
            this.lable15.Name = "lable15";
            this.lable15.Size = new System.Drawing.Size(15, 13);
            this.lable15.TabIndex = 15;
            this.lable15.Text = "m";
            // 
            // btStartTimer
            // 
            this.btStartTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btStartTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStartTimer.Location = new System.Drawing.Point(12, 53);
            this.btStartTimer.Name = "btStartTimer";
            this.btStartTimer.Size = new System.Drawing.Size(288, 22);
            this.btStartTimer.TabIndex = 16;
            this.btStartTimer.Text = "Start timer";
            this.btStartTimer.UseVisualStyleBackColor = true;
            this.btStartTimer.Click += new System.EventHandler(this.btStartTimer_Click_1);
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(344, 298);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbTask);
            this.Controls.Add(this.btCancelTask);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.Text = "Media Encoder Auto Shutdown";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
            this.Load += new System.EventHandler(this.fMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.RadioButton rbShutdown;
        private System.Windows.Forms.RadioButton rbStandby;
        private System.Windows.Forms.RadioButton rbHibernate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudDelay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbWriteLog;
        private System.Windows.Forms.Button btCancelTask;
        private System.Windows.Forms.Label lbTask;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cbClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown nudMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudHrs;
        private System.Windows.Forms.Button btStartTimer;
        private System.Windows.Forms.Label lable15;
        private System.Windows.Forms.Timer timer3;
    }
}

