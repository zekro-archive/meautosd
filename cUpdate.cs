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
                var msgbox = MessageBox.Show("An update is available! \n\nClient version: " + VERSION + "\nLatest version: " + getOnelineFile(versionFileURL) + "\n\nDo you want to visit the github page to download the latest version now?",
                                             "Update available",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                if (msgbox == DialogResult.Yes)
                {
                    Process.Start("https://github.com/zekroTJA/meautosd/releases");
                }
            }
        }
    }
}