using CSCore.CoreAudioAPI;
using meautosd.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
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
        public bool enabled_btCancelTask = false, finished = false, sound = false;
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
            loadRegSettings();

            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Settings", new EventHandler(openSetings));
            cm.MenuItems.Add("Info and Changelogs", new EventHandler(openInfo));
            cm.MenuItems.Add("Close", new EventHandler(app_close));
            this.ContextMenu = cm;

            //if (Settings.Default.afterEncoding == 0)
            //    rbShutdown.Checked = true;
            //else if (Settings.Default.afterEncoding == 1)
            //    rbStandby.Checked = true;
            //else if (Settings.Default.afterEncoding == 2)
            //    rbHibernate.Checked = true;

            cbClose.Checked = Settings.Default.closeAfterEncoding;

            nudDelay.Value = Settings.Default.delayTime;
            cbWriteLog.Checked = Settings.Default.writeLog;

            AMEWatcher.Start();

            try
            {
                cUpdate.update();
            }  
            catch(Exception exception)
            {
                MessageBox.Show("A problem occured while checking for updates.\n\nIf your PC is in offline mode, pelase go online to check for updates.\n\nHere you can see the cause of the error: \n" + exception, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            testForCSCore();

            if (Settings.Default.logFileLoc == "")
                Settings.Default.logFileLoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\ameautosd_logfile.txt";

            if (Settings.Default.writeLog)
                File.AppendAllText(Settings.Default.logFileLoc, "[" + System.DateTime.Now + "] " + "STARTED SESSION" + Environment.NewLine);

            openToolsOnStartup();
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

        private void AMEWatcher_Tick(object sender, EventArgs e)
        {
            Process[] process = Process.GetProcessesByName("Adobe Media Encoder");

            if (!Settings.Default.useSound)
            {
                if (Settings.Default.finishLocation != "" && Settings.Default.finishName != "" && process.Length != 0)
                {
                    status = 1;
                    lbStatus.Text = "Waiting for finishing the render lsit.";
                    lbStatus.ForeColor = Color.Cyan;
                    pbStatus.Image = Properties.Resources.status_ready;
                }
                else if (Settings.Default.finishLocation != "" && Settings.Default.finishName != "")
                {
                    status = 0;
                    lbStatus.Text = "Adobe Media Encoder is not started.";
                    lbStatus.ForeColor = Color.Gray;
                    pbStatus.Image = Properties.Resources.status_notready;
                }
                else if (Settings.Default.finishLocation == "")
                {
                    lbStatus.Text = "Finish file location is not set!";
                    lbStatus.ForeColor = Color.Red;
                    pbStatus.Image = Properties.Resources.status_error;
                }
                else if (Settings.Default.finishName == "")
                {
                    lbStatus.Text = "Finish file name is not set!";
                    lbStatus.ForeColor = Color.Red;
                    pbStatus.Image = Properties.Resources.status_error;
                }
            } else
            {
                if (process.Length != 0)
                {
                    status = 1;
                    lbStatus.Text = "Waiting for finishing the render lsit.";
                    lbStatus.ForeColor = Color.Cyan;
                    pbStatus.Image = Properties.Resources.status_ready;
                }
                else
                {
                    status = 0;
                    lbStatus.Text = "Adobe Media Encoder is not started.";
                    lbStatus.ForeColor = Color.Gray;
                    pbStatus.Image = Properties.Resources.status_notready;
                }
            }

            if (File.Exists(Settings.Default.finishLocation + "//" + Settings.Default.finishName) && status == 1 && !finished && !Settings.Default.useSound)
            {
                taskAfterFinish();
            }

            if (Settings.Default.useSound)
            {
                detectSoundVolume();
                if (sound)
                {
                    taskAfterFinish();
                    sound = false;
                }
            }
        }

        private void taskAfterFinish()
        {
            status = 2;
            lbStatus.Text = "Rendering Finished.";
            lbStatus.ForeColor = Color.LimeGreen;
            pbStatus.Image = Properties.Resources.status_finish;
            AMEWatcher.Stop();

            switch (Settings.Default.afterEncoding)
            {
                //SHUTDOWN
                case 0:
                    deleteFinishFile();
                    shutDown();
                    break;

                //STANDBY
                case 1:
                    btCancelTask.Enabled = true;
                    enabled_btCancelTask = true;
                    TimeDiplayUpdater.Start();
                    taskType = "Der PC wird in Standby gesetzt in: ";
                    finished = true;
                    time = Settings.Default.delayTime * 60;
                    deleteFinishFile();
                    break;

                //HIBERNATE
                case 2:
                    btCancelTask.Enabled = true;
                    enabled_btCancelTask = true;
                    TimeDiplayUpdater.Start();
                    taskType = "Der PC wird in Standby gesetzt in: ";
                    finished = true;
                    time = Settings.Default.delayTime * 60;
                    deleteFinishFile();
                    break;

                //DO NOTHING
                case 3:
                    btCancelTask.Enabled = true;
                    enabled_btCancelTask = true;
                    taskType = "";
                    finished = true;
                    time = Settings.Default.delayTime * 60;
                    deleteFinishFile();

                    if (Settings.Default.pbSend && Settings.Default.pbToken != "")
                    {
                        cPush.send(Settings.Default.pbToken, "AME Auto Shutdown", "Rendering completed.");
                    }

                    break;
            }
        }

        
        private void TimeDisplayUpdater_Tick(object sender, EventArgs e)
        {
            time = time - 1;
            lbTask.Text = taskType + time + " Sek.";

            if (time == 0)
                switch (Settings.Default.afterEncoding)
                {
                    //STANDBY
                    case 1:
                        standBy();
                        break;

                    //HIBERNATE
                    case 2:
                        hibernate();
                        break;
                }
        }

        private void btCancelTask_Click(object sender, EventArgs e)
        {
            if (enabled_btCancelTask)
            {
                Process.Start("shutdown", "/a");
                enabled_btCancelTask = false;
                btCancelTask.Enabled = false;
                TimeDiplayUpdater.Stop();
                lbTask.Text = "";
            }
            AMEWatcher.Start();
        }

        public void shutDown()
        {
            Process.Start("shutdown", "/s /t " + Settings.Default.delayTime * 60);
            btCancelTask.Enabled = true;
            enabled_btCancelTask = true;
            TimeDiplayUpdater.Start();
            taskType = "Der PC wird heruntergefahren in: ";
            finished = true;
            time = Settings.Default.delayTime * 60;

            if (Settings.Default.pbSend && Settings.Default.pbToken != "")
            {
                cPush.send(Settings.Default.pbToken, "AME Auto Shutdown", "Your PC will shut down now.");
            }

            if (Settings.Default.writeLog)
                File.AppendAllText(Settings.Default.logFileLoc, "[" + System.DateTime.Now + "] " + "SYSTEM SHUTDOWN" + Environment.NewLine);
        }

        public void standBy()
        {
            Application.SetSuspendState(PowerState.Suspend, true, true);

            if (Settings.Default.writeLog)
                File.AppendAllText(Settings.Default.logFileLoc, "[" + System.DateTime.Now + "] " + "SYSTEM STANDBY" + Environment.NewLine);

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
                File.AppendAllText(Settings.Default.logFileLoc, "[" + System.DateTime.Now + "] " + "SYSTEM HIBERNATE" + Environment.NewLine);

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
            if (Settings.Default.deleFinishFile && File.Exists(filepath) && !Settings.Default.useSound)
            {
                File.Delete(filepath);
            }
        }


        private void openToolsOnStartup()
        {
            if (Settings.Default.AMEPath == "")
                Settings.Default.AMEPath = GetProcessPath("Adobe Media Encoder");
            else if (Settings.Default.openAMEOnStartup)
                Process.Start(Settings.Default.AMEPath);

            Settings.Default.TVRPath = GetProcessPath("TeamViewer");
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


        private void detectSoundVolume()
        {
            //AllocConsole();
            try
            {
                float audio;

                AudioSessionManager2 sessionManager = GetDefaultAudioSessionManager2(DataFlow.Render);
                AudioSessionEnumerator sessionEnumerator = sessionManager.GetSessionEnumerator();

                AudioSessionControl2 sessionControl;

                foreach (AudioSessionControl session in sessionEnumerator)
                {
                    sessionControl = session.QueryInterface<AudioSessionControl2>();
                    //Console.WriteLine(sessionControl.Process.MainWindowTitle);
                    if (sessionControl.Process.MainWindowTitle.Contains("Adobe Media Encoder"))
                    {
                        audio = session.QueryInterface<AudioMeterInformation>().PeakValue;
                        Console.WriteLine(audio.ToString());
                        if (audio > 0.1)
                            sound = true;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR " + exc);
            }
        }

        private void testForCSCore()
        {
            if (!File.Exists("CSCore.dll"))
            {
                var msgbx = MessageBox.Show("ATTENTION: There is no CSCore.dll installed in the same path of the tool's exe-file! If you want to use the sound based finish method, please download the dll file! \n\n Do you want to download it now?", "ATTENTION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msgbx == DialogResult.Yes)
                {
                    try
                    {
                        WebClient client = new WebClient();
                        client.DownloadFile("https://github.com/zekroTJA/meautosd/releases/download/1.4.1.0/CSCore.dll", "CSCore.dll");
                        MessageBox.Show("Download successfully done! Its very important, that the dll is ALWAYS in the same path like the exe, or it will not work!", "Download done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch
                    {
                        MessageBox.Show("Download Error: Either your internet connection got some problems while downloading the file or the file mgot deleted or moved. Please contact the developer of this tool or retry it later.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private static AudioSessionManager2 GetDefaultAudioSessionManager2(DataFlow dataFlow)
        {
            using (var enumerator = new MMDeviceEnumerator())
            {
                using (var device = enumerator.GetDefaultAudioEndpoint(dataFlow, Role.Multimedia))
                {
                    Debug.WriteLine("DefaultDevice: " + device.FriendlyName);
                    var sessionManager = AudioSessionManager2.FromMMDevice(device);
                    return sessionManager;
                }
            }
        }

        private void loadRegSettings()
        {
            if ((string)Registry.GetValue(setKey, "AMEPath", "") != "")
                Settings.Default.AMEPath = (string)Registry.GetValue(setKey, "AMEPath", "");

            if ((string)Registry.GetValue(setKey, "deleFinishFile", "") != "")
                Settings.Default.deleFinishFile = Convert.ToBoolean(Registry.GetValue(setKey, "deleFinishFile", ""));

            if ((string)Registry.GetValue(setKey, "finishLocation", "") != "")
                Settings.Default.finishLocation = (string)Registry.GetValue(setKey, "finishLocation", "");

            if ((string)Registry.GetValue(setKey, "finishName", "") != "")
                Settings.Default.finishName = (string)Registry.GetValue(setKey, "finishName", "");

            if ((string)Registry.GetValue(setKey, "openAMEOnStartup", "") != "")
                Settings.Default.openAMEOnStartup = Convert.ToBoolean(Registry.GetValue(setKey, "openAMEOnStartup", ""));

            if ((string)Registry.GetValue(setKey, "pbSend", "") != "")
                Settings.Default.pbSend = Convert.ToBoolean(Registry.GetValue(setKey, "pbSend", ""));

            if ((string)Registry.GetValue(setKey, "pbToken", "") != "")
                Settings.Default.pbToken = (string)Registry.GetValue(setKey, "pbToken", "");

            if ((string)Registry.GetValue(setKey, "useSound", "") != "")
                Settings.Default.useSound = Convert.ToBoolean(Registry.GetValue(setKey, "useSound", ""));

            if ((string)Registry.GetValue(setKey, "writeLog", "") != "")
                Settings.Default.writeLog = Convert.ToBoolean(Registry.GetValue(setKey, "writeLog", ""));
        }

        #region Settings for Variables
        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
            Registry.SetValue(setKey, "writeLog", Settings.Default.writeLog);
        }

        private void rbShutdown_CheckedChanged(object sender, EventArgs e)
        {
           // if (rbShutdown.Checked == true)
           //     Settings.Default.afterEncoding = 0;
        }      
               
        private void rbStandby_CheckedChanged(object sender, EventArgs e)
        {
           // if (rbStandby.Checked == true)
           //     Settings.Default.afterEncoding = 1;
        }

        private void rbHibernate_CheckedChanged(object sender, EventArgs e)
        {
           // if (rbHibernate.Checked == true)
           //     Settings.Default.afterEncoding = 2;
        }

        private void cbClose_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.closeAfterEncoding = cbClose.Checked;
        }

        private void btStartTimer_Click_1(object sender, EventArgs e)
        {
            

            if (btStartTimer.Text == "Start timer")
            {
                tTime = nudHrs.Value * 3600 + nudMin.Value * 60;
                countDown = tTime;
                btStartTimer.Text = "Stop timer";
                TimerUpdater.Start();
            }

            else
            {
                lbTask.Text = "";
                btStartTimer.Text = "Start timer";
                TimerUpdater.Stop();
            }
                
        }

        private void nudDelay_ValueChanged_1(object sender, EventArgs e)
        {
            Settings.Default.delayTime = (int)nudDelay.Value;
        }

        private void pbDonate_Click(object sender, EventArgs e)
        {
            fDonate fDonate = new fDonate();
            fDonate.ShowDialog();
        }

        private void cbWriteLog_CheckedChanged_1(object sender, EventArgs e)
        {
            Settings.Default.writeLog = cbWriteLog.Checked;
        }

        private void llLogFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Settings.Default.logFileLoc);
        }

        private void cbTask_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbTask.Text == "Shutdown")
                Settings.Default.afterEncoding = 0;
            else if (cbTask.Text == "Hibernate")
                Settings.Default.afterEncoding = 2;
            else if (cbTask.Text == "Standby")
                Settings.Default.afterEncoding = 1;
            else if (cbTask.Text == "Do Nothing")
                Settings.Default.afterEncoding = 3;
        }

        private void TimerUpdater_Tick(object sender, EventArgs e)
        {
            countDown = countDown - 1;

            if (countDown < 60)
                lbTask.Text = countDown + " sec";
            else
                lbTask.Text = Convert.ToInt32(countDown /60) + " min";

            if (countDown == 0)
            {
                switch (Settings.Default.afterEncoding)
                {
                    case 0:
                        shutDown();
                        break;

                    case 1:
                        standBy();
                        break;

                    case 2:
                        hibernate();
                        break;
                }
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

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
