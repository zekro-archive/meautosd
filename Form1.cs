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
        public decimal tTime, countDown;

        Timer timer2 = new Timer();

        #endregion

        public fMain()
        {
            InitializeComponent();

            fFirstStartup fsu = new fFirstStartup();
            if (!Settings.Default.firstStartup)
                fsu.ShowDialog();

        }

        private void fMain_Load(object sender, EventArgs e)
        {
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Settings", new EventHandler(openSetings));
            cm.MenuItems.Add("Info", new EventHandler(openInfo));
            cm.MenuItems.Add("Close", new EventHandler(app_close));
            this.ContextMenu = cm;

            if (Settings.Default.afterEncoding == 0)
                rbShutdown.Checked = true;
            else if (Settings.Default.afterEncoding == 1)
                rbStandby.Checked = true;
            else if (Settings.Default.afterEncoding == 2)
                rbHibernate.Checked = true;

            cbClose.Checked = Settings.Default.closeAfterEncoding;

            nudDelay.Value = Settings.Default.delayTime;
            cbWriteLog.Checked = Settings.Default.writeLog;

            timer.Start();

            try
            {
                cUpdate.update();
            }  
            catch(Exception exception)
            {
                MessageBox.Show("A problem occured while checking for updates.\n\nIf your PC is in offline mode, pelase go online to check for updates.\n\nHere you can see the cause of the error: \n" + exception, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void app_close(object sender, EventArgs e)
        {
            Application.Exit();
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
                    shutDown();
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

                //HIBERNATE
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

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            time = time-1;
            lbTask.Text = taskType + time + " Sek.";

            //STANDBY
            if (Settings.Default.afterEncoding == 1 && time == 0)
            {
                standBy();
            }

            //HIBERNATE    
            else if (Settings.Default.afterEncoding == 2 && time == 0)
            {
                hibernate();
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

        public void shutDown()
        {
            Process.Start("shutdown", "/s /t " + Settings.Default.delayTime * 60);
            btCancelTask.Enabled = true;
            enabled_btCancelTask = true;
            timer1.Start();
            taskType = "Der PC wird heruntergefahren in: ";
            finished = true;
            time = Settings.Default.delayTime * 60;

            if (Settings.Default.pbSend && Settings.Default.pbToken != "")
            {
                cPush.send(Settings.Default.pbToken, "AME Auto Shutdown", "Your PC will shut down now.");
            }

            if (Settings.Default.writeLog)
            {
                StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "//Documents//ameautosd_logfile.txt");
                writer.WriteLine("SYSTEM SHUTDOWN:");
                writer.WriteLine(System.DateTime.Now);
                writer.Close();
            }
        }

        public void standBy()
        {
            Application.SetSuspendState(PowerState.Suspend, true, true);

            if (Settings.Default.writeLog)
            {
                StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "//Documents//ameautosd_logfile.txt");
                writer.WriteLine("SYSTEM STANDBY:");
                writer.WriteLine(System.DateTime.Now);
                writer.Close();
            }

            if (Settings.Default.pbSend && Settings.Default.pbToken != "")
            {
                cPush.send(Settings.Default.pbToken, "AME Auto Shutdown", "Your PC will set to standby now.");
            }

            if (Settings.Default.closeAfterEncoding)
                Application.Exit();
        }

        public void hibernate()
        {
            Process.Start(Environment.GetEnvironmentVariable("windir") + "//system32//rundll32.exe", "powrprof.dll, SetSuspendState");

            if (Settings.Default.writeLog)
            {
                StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "//Documents//ameautosd_logfile.txt");
                writer.WriteLine("SYSTEM HIBERNATE:");
                writer.WriteLine(System.DateTime.Now);
                writer.Close();
            }

            if (Settings.Default.pbSend && Settings.Default.pbToken != "")
            {
                cPush.send(Settings.Default.pbToken, "AME Auto Shutdown", "Your PC will set to hibernate now.");
            }

            if (Settings.Default.closeAfterEncoding)
                Application.Exit();
        }

        public void deleteFinishFile()
        {
            string filepath = Settings.Default.finishLocation + "//" + Settings.Default.finishName;
            if (Settings.Default.deleFinishFile && File.Exists(filepath))
            {
                File.Delete(filepath);
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

        private void cbClose_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.closeAfterEncoding = cbClose.Checked;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btStartTimer_Click(object sender, EventArgs e)
        {
        }

        private void btStartTimer_Click_1(object sender, EventArgs e)
        {
            

            if (btStartTimer.Text == "Start timer")
            {
                tTime = nudHrs.Value * 3600 + nudMin.Value * 60;
                countDown = tTime;
                btStartTimer.Text = "Stop timer";
                timer3.Start();
            }

            else
            {
                lbTask.Text = "";
                btStartTimer.Text = "Start timer";
                timer3.Stop();
            }
                
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            countDown = countDown - 1;

            if (countDown < 60)
                lbTask.Text = countDown + " sec";
            else
                lbTask.Text = Convert.ToInt32(countDown /60) + " min";

            if (countDown == 0)
            {
                if (rbShutdown.Checked)
                    shutDown();
                else if (rbStandby.Checked)
                    standBy();
                else if (rbHibernate.Checked)
                    hibernate();
            }

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
    }
}
