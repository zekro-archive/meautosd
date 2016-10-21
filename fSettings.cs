using meautosd.Properties;
using Microsoft.Win32;
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

using static meautosd.cConst;

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
            tbAMELoc.Text = Settings.Default.AMEPath;
            cbAMEStartup.Checked = Settings.Default.openAMEOnStartup;
            cbUseSound.Checked = Settings.Default.useSound;
            tbLogLoc.Text = Settings.Default.logFileLoc;

            Registry.SetValue(setKey, "finishLocation", Settings.Default.finishLocation);
            Registry.SetValue(setKey, "finishName", Settings.Default.finishName);
            Registry.SetValue(setKey, "pbToken", Settings.Default.pbToken);
            Registry.SetValue(setKey, "pbSend", Settings.Default.pbSend);
            Registry.SetValue(setKey, "deleFinishFile", Settings.Default.deleFinishFile);
            Registry.SetValue(setKey, "AMEPath", Settings.Default.AMEPath);
            Registry.SetValue(setKey, "openAMEOnStartup", Settings.Default.openAMEOnStartup);
            Registry.SetValue(setKey, "useSound", Settings.Default.useSound);
            Registry.SetValue(setKey, "logFileLoc", Settings.Default.logFileLoc);

            if (Settings.Default.AMEPath == "")
            {
                timer1.Start();
                tbAMELoc.Text = "Please open the AME that the Tool is able to catch the Path.";
            }

            if (cbUseSound.Checked)
            {
                tbLocFile.Enabled = false;
                tbFileName.Enabled = false;
                btLocFile.Enabled = false;
                label1.Enabled = false;
                label2.Enabled = false;
                linkLabel1.Enabled = false;
                cbDelete.Enabled = false;
            }
            else
            {
                tbLocFile.Enabled = true;
                tbFileName.Enabled = true;
                btLocFile.Enabled = true;
                label1.Enabled = true;
                label2.Enabled = true;
                linkLabel1.Enabled = true;
                cbDelete.Enabled = true;
            }

        }

        public string GetProcessPath(string name)
        {
            Process[] processes = Process.GetProcessesByName(name);

            if (processes.Length > 0)
            {
                try { return processes[0].MainModule.FileName; }
                catch { return string.Empty; }
            }
            else
            {
                return string.Empty;
            }
        }

        #region TIMERS & ELEMENTS
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
            Settings.Default.useSound = cbUseSound.Checked;
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

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cPush.send(tbPbToken.Text, "AME Auto Shutdown", "Test message.");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Process[] process = Process.GetProcessesByName("Adobe Media Encoder");

            if (process.Length > 0)
            {
                Settings.Default.AMEPath = GetProcessPath("Adobe Media Encoder");
                tbAMELoc.Text = Settings.Default.AMEPath;
            }
        }

        private void cbAMEStartup_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.openAMEOnStartup = cbAMEStartup.Checked;
        }

        private void cbUseSound_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUseSound.Checked)
            {
                tbLocFile.Enabled = false;
                tbFileName.Enabled = false;
                btLocFile.Enabled = false;
                label1.Enabled = false;
                label2.Enabled = false;
                linkLabel1.Enabled = false;
                cbDelete.Enabled = false;
            }
            else
            {
                tbLocFile.Enabled = true;
                tbFileName.Enabled = true;
                btLocFile.Enabled = true;
                label1.Enabled = true;
                label2.Enabled = true;
                linkLabel1.Enabled = true;
                cbDelete.Enabled = true;
            }
        }

        private void cbDelete_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fSoundInfo info = new fSoundInfo();
            info.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            Settings.Default.logFileLoc = dialog.SelectedPath.ToString() + @"\ameautosd_logfile.txt";
            tbLogLoc.Text = dialog.SelectedPath.ToString() + @"\ameautosd_logfile.txt";
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
            var msgbox = MessageBox.Show("Do you really want to reset ALL settings for this tool?", "Reset Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (msgbox == DialogResult.Yes)
            {
                if (key.OpenSubKey("AMEAutoShutdown") != null)
                {
                    key.DeleteSubKeyTree("AMEAutoShutdown");
                }

                Settings.Default.Reset();

                Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                Application.Exit();
            }
        }
    }
}
