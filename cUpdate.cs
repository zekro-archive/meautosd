using meautosd.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static meautosd.cConst;

namespace meautosd
{
    class cUpdate
    {
        public static string getOnelineFile(string URL)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(URL);
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static bool getUpdateStatus(string clientVersion, string latestVersion)
        {
            if (clientVersion == latestVersion)
                return false;
            else
                return true;
        }

        public static void update()
        {
            if (getUpdateStatus(VERSION, getOnelineFile(versionFileURL)))
            {
                var msgbox = MessageBox.Show("A update is available! \n\nClient version: " + VERSION + "\nLatest version: " + getOnelineFile(versionFileURL) + "\n\nDo you want to downlaod the lates version now?",
                                             "Update available",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                if (msgbox == DialogResult.Yes)
                {

                    WebClient client = new WebClient();
                    client.DownloadFile(getOnelineFile(downloadFileURL), "mouseCounterUpdate.exe");

                    StreamWriter w = new StreamWriter("updatescript.bat");
                    w.WriteLine("@echo off");
                    w.WriteLine("if exist mouseCounter.exe (");
                    w.WriteLine("	del mouseCounter.exe");
                    w.WriteLine("	ren mouseCounterUpdate.exe mouseCounter.exe");
                    w.WriteLine("   start mouseCounter.exe");
                    w.WriteLine(") else (");
                    w.WriteLine("	echo You have probably renamed the file mouseCounter.exe so the update script can not find the file. Pelase rename it to the ortiginal name to continue!");
                    w.WriteLine("	pause )");
                    w.WriteLine("del updatescript.bat");
                    w.Close();

                    Process.Start("updatescript.bat");
                    Application.Exit();
                }
            }
        }
    }
}