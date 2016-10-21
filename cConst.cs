using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace meautosd
{
    static class cConst
    {
        public static string VERSION = Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                                versionFileURL = "https://dl.dropboxusercontent.com/s/ey3lsy8orxt5ttr/meautosd_version.txt",
                                changelogsFileURL = "http://pastebin.com/raw/vWCKaf4t",
                                universalToken = "https://dl.dropboxusercontent.com/s/95iqks01oag7luk/UNIVERSAL%20PUSHBULLET%20TOKEN.txt",
                                updateFileURL = "https://dl.dropboxusercontent.com/s/dj8p1g66lilyg4o/meautosd_updateURL.txt",

                                setKey = "HKEY_CURRENT_USER\\SOFTWARE\\AMEAutoShutdown";

    }
}
