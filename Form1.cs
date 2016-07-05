using meautosd.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static meautosd.cConst;

namespace meautosd
{
    public partial class fMain : Form
    {
        #region Vars

        public int status = 0, //0 - AME not started, 1 - Waiting for End of renderlist, 2 - Shutdown
                   time; 
        public bool enabled_btCancelTask = false, finished = false;
        public string taskType;

        Timer timer2 = new Timer();

        #endregion

        public fMain()
        {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Settings", new EventHandler(openSetings));
            cm.MenuItems.Add("Info", new EventHandler(openInfo));
            this.ContextMenu = cm;

            if (Settings.Default.afterEncoding == 0)
                rbShutdown.Checked = true;
            else if (Settings.Default.afterEncoding == 1)
                rbStandby.Checked = true;
            else if (Settings.Default.afterEncoding == 2)
                rbHibernate.Checked = true;
            else if (Settings.Default.afterEncoding == 3)
                rbClose.Checked = true;

            nudDelay.Value = Settings.Default.delayTime;
            cbWriteLog.Checked = Settings.Default.writeLog;

            timer.Start();
        }

        private void openInfo(object sender, EventArgs e)
        {
            fInfo info = new fInfo();
            info.ShowDialog();
        }

        private void openSetings(object sender, EventArgs e)
        {
            fSettings settings = new fSettings();
            settings.ShowDialog();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Process[] process = Process.GetProcessesByName("Adobe Media Encoder");

            if (Settings.Default.finishLocation != "" && Settings.Default.finishName != "" && process.Length != 0)
            {
                status = 1;
                lbStatus.Text = "Waiting for finishing the render lsit.";
                lbStatus.ForeColor = Color.Cyan;
            } else if (Settings.Default.finishLocation != "" && Settings.Default.finishName != "")
            {
                status = 0;
                lbStatus.Text = "Adobe Media Encoder is not started.";
                lbStatus.ForeColor = Color.Gray;
            } else if (Settings.Default.finishLocation == "")
            {
                lbStatus.Text = "Finish file location is not set!";
                lbStatus.ForeColor = Color.Red;
            } else if (Settings.Default.finishName == "")
            {
                lbStatus.Text = "Finish file name is not set!";
                lbStatus.ForeColor = Color.Red;
            }

            if (File.Exists(Settings.Default.finishLocation + "//" + Settings.Default.finishName) && status == 1)
            {
                status = 2;
                lbStatus.Text = "Rendering Finished.";
                lbStatus.ForeColor = Color.LimeGreen;


                //SHUTDOWN
                if (Settings.Default.afterEncoding == 0 && !finished) 
                {
                    Process.Start("shutdown", "/s /t " + Settings.Default.delayTime*60);
                    btCancelTask.Enabled = true;
                    enabled_btCancelTask = true;
                    timer1.Start();
                    taskType = "Der PC wird heruntergefahren in: ";
                    finished = true;
                    time = Settings.Default.delayTime * 60;

                    if (Settings.Default.writeLog)
                    {
                        StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +  "//Documents//ameautosd_logfile.txt");
                        writer.WriteLine("SYSTEM SHUTDOWN:");
                        writer.WriteLine(DateTime.Now);
                        writer.Close();
                    }
                }

                //STANDBY
                else if (Settings.Default.afterEncoding == 1 && !finished)
                {
                    btCancelTask.Enabled = true;
                    enabled_btCancelTask = true;
                    timer1.Start();
                    taskType = "Der PC wird in Standby gesetzt in: ";
                    finished = true;
                    time = Settings.Default.delayTime * 60;
                    MessageBox.Show("Der PC wird in " + Settings.Default.delayTime * 60 + " Sekunden in den Standby gesetzt!", "Standby", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //HYBERNATE
                else if (Settings.Default.afterEncoding == 2 && !finished)
                {
                    btCancelTask.Enabled = true;
                    enabled_btCancelTask = true;
                    timer1.Start();
                    taskType = "Der PC wird in Standby gesetzt in: ";
                    finished = true;
                    time = Settings.Default.delayTime * 60;
                    MessageBox.Show("Der PC wird in " + Settings.Default.delayTime * 60 + " Sekunden in den Ruhezustand (Hibernate) gesetzt!", "Standby", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #region Settings for Variables
        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        private void rbShutdown_CheckedChanged(object sender, EventArgs e)
        {
            if (rbShutdown.Checked == true)
                Settings.Default.afterEncoding = 0;
        }

        private void rbStandby_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStandby.Checked == true)
                Settings.Default.afterEncoding = 1;
        }

        private void rbHibernate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHibernate.Checked == true)
                Settings.Default.afterEncoding = 2;
        }

        private void rbClose_CheckedChanged(object sender, EventArgs e)
        {
            if (rbClose.Checked == true)
                Settings.Default.afterEncoding = 3;
        }

        private void nudDelay_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.delayTime = (int)nudDelay.Value;
        }

        private void cbWriteLog_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.writeLog = cbWriteLog.Checked;
        }
        #endregion

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            time = time-1;
            lbTask.Text = taskType + time + " Sek.";

            if (Settings.Default.afterEncoding == 1 && time == 0)
            {
                Application.SetSuspendState(PowerState.Suspend, true, true);

                if (Settings.Default.writeLog)
                {
                    StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "//Documents//ameautosd_logfile.txt");
                    writer.WriteLine("SYSTEM STANDBY:");
                    writer.WriteLine(DateTime.Now);
                    writer.Close();
                }

                Application.Exit();
            }
                
            else if (Settings.Default.afterEncoding == 2 && time == 0)
            {
                Process.Start(Environment.GetEnvironmentVariable("windir") + "//system32//rundll32.exe", "powrprof.dll, SetSuspendState");

                if (Settings.Default.writeLog)
                {
                    StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "//Documents//ameautosd_logfile.txt");
                    writer.WriteLine("SYSTEM HIBERNATE:");
                    writer.WriteLine(DateTime.Now);
                    writer.Close();
                }

                Application.Exit();
            }

        }

        private void btCancelTask_Click(object sender, EventArgs e)
        {
            if (enabled_btCancelTask)
            {
                Process.Start("shutdown", "/a");
                enabled_btCancelTask = false;
                btCancelTask.Enabled = false;
                timer1.Stop();
                lbTask.Text = "";
            }
        }
    }
}
