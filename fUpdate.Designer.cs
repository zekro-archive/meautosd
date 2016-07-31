namespace meautosd
{
    partial class fUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.lbClientVersion = new System.Windows.Forms.Label();
            this.lbLatestVersion = new System.Windows.Forms.Label();
            this.rtbChangelog = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btOK = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.pbUpdate = new System.Windows.Forms.ProgressBar();
            this.lbDlStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "An update for Adobe Media Encoder Auto Shutdown is available!";
            // 
            // lbClientVersion
            // 
            this.lbClientVersion.AutoSize = true;
            this.lbClientVersion.Location = new System.Drawing.Point(13, 39);
            this.lbClientVersion.Name = "lbClientVersion";
            this.lbClientVersion.Size = new System.Drawing.Size(73, 13);
            this.lbClientVersion.TabIndex = 1;
            this.lbClientVersion.Text = "Client version:";
            // 
            // lbLatestVersion
            // 
            this.lbLatestVersion.AutoSize = true;
            this.lbLatestVersion.Location = new System.Drawing.Point(13, 58);
            this.lbLatestVersion.Name = "lbLatestVersion";
            this.lbLatestVersion.Size = new System.Drawing.Size(76, 13);
            this.lbLatestVersion.TabIndex = 2;
            this.lbLatestVersion.Text = "Latest version:";
            // 
            // rtbChangelog
            // 
            this.rtbChangelog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.rtbChangelog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChangelog.ForeColor = System.Drawing.Color.White;
            this.rtbChangelog.Location = new System.Drawing.Point(8, 19);
            this.rtbChangelog.Name = "rtbChangelog";
            this.rtbChangelog.Size = new System.Drawing.Size(397, 124);
            this.rtbChangelog.TabIndex = 4;
            this.rtbChangelog.Text = "";
            this.rtbChangelog.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbChangelog);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 149);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Changelogs";
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOK.Location = new System.Drawing.Point(341, 254);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(82, 22);
            this.btOK.TabIndex = 5;
            this.btOK.Text = "Update Later";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btUpdate
            // 
            this.btUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUpdate.Location = new System.Drawing.Point(253, 254);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(82, 22);
            this.btUpdate.TabIndex = 6;
            this.btUpdate.Text = "Update Now";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbUpdate
            // 
            this.pbUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbUpdate.Location = new System.Drawing.Point(12, 265);
            this.pbUpdate.Name = "pbUpdate";
            this.pbUpdate.Size = new System.Drawing.Size(230, 11);
            this.pbUpdate.TabIndex = 7;
            this.pbUpdate.Visible = false;
            // 
            // lbDlStatus
            // 
            this.lbDlStatus.AutoSize = true;
            this.lbDlStatus.Location = new System.Drawing.Point(12, 246);
            this.lbDlStatus.Name = "lbDlStatus";
            this.lbDlStatus.Size = new System.Drawing.Size(0, 13);
            this.lbDlStatus.TabIndex = 8;
            this.lbDlStatus.Visible = false;
            // 
            // fUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(435, 288);
            this.Controls.Add(this.lbDlStatus);
            this.Controls.Add(this.pbUpdate);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbLatestVersion);
            this.Controls.Add(this.lbClientVersion);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fUpdate";
            this.ShowInTaskbar = false;
            this.Text = "AME AS Update Manager";
            this.Load += new System.EventHandler(this.fUpdate_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbClientVersion;
        private System.Windows.Forms.Label lbLatestVersion;
        private System.Windows.Forms.RichTextBox rtbChangelog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.ProgressBar pbUpdate;
        private System.Windows.Forms.Label lbDlStatus;
    }
}