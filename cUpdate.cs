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
                Form fUpdate = new fUpdate();
                fUpdate.ShowDialog();
            }
        }
    }
}