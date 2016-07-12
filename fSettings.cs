using meautosd.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace meautosd
{
    public partial class fSettings : Form
    {
        public fSettings()
        {
            InitializeComponent();
        }

        private void fSettings_Load(object sender, EventArgs e)
        {
            tbLocFile.Text = Settings.Default.finishLocation;
            tbFileName.Text = Settings.Default.finishName;
            tbPbToken.Text = Settings.Default.pbToken;
            cbPbSend.Checked = Settings.Default.pbSend;
            cbDelete.Checked = Settings.Default.deleFinishFile;
        }

        private void btLocFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            Settings.Default.finishLocation = dialog.SelectedPath.ToString();
            tbLocFile.Text = dialog.SelectedPath.ToString();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Settings.Default.finishName = tbFileName.Text;
            Settings.Default.pbToken = tbPbToken.Text;
            Settings.Default.pbSend = cbPbSend.Checked;
            Settings.Default.deleFinishFile = cbDelete.Checked;
            Settings.Default.Save();
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please add to your render list in Adobe Media Encoder a project or video or what ever AT THE END of your main project(s) you want to render. The app will detect the filename of this videofile after Media Encoder started rendering out this file. This is the signat, that the computer will shut down now automaticly by the App.", "Help", MessageBoxButtons.OK);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.pushbullet.com/#settings");
        }
    }
}
