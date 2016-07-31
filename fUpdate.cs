using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace meautosd
{
    public partial class fUpdate : Form
    {
        public fUpdate()
        {
            InitializeComponent();
        }

        private void fUpdate_Load(object sender, EventArgs e)
        {
            lbClientVersion.Text = cConst.VERSION;
            lbLatestVersion.Text = cUpdate.getOnelineFile(cConst.versionFileURL);
            rtbChangelog.Text = cUpdate.getOnelineFile(cConst.changelogsFileURL);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(dlProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(dlComplete);
                client.DownloadFileAsync(new Uri(cUpdate.getOnelineFile(cConst.updateFileURL)), "ameautosd_update.exe");
                pbUpdate.Visible = true;
                lbDlStatus.Visible = true;
            } catch (Exception exc)
            {
                MessageBox.Show("Can not download update file. Perhaps, there is a problem with your net connection or the update file url is invalid. \n\n Exceprion: \n\n" + exc, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dlComplete(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed. Update file location: \n\n" + AppDomain.CurrentDomain.BaseDirectory + "ameautosd_update.exe", "Update complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void dlProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            lbDlStatus.Text = e.BytesReceived / 1024 + " kB / " + e.TotalBytesToReceive / 1024 + " kB";
            pbUpdate.Value = e.ProgressPercentage;
        }
    }
}
