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
    public partial class fFirstStartup : Form
    {
        public fFirstStartup()
        {
            InitializeComponent();
            btOK.Enabled = false;
        }

        private void fFirstStartup_Load(object sender, EventArgs e)
        {
            try
            {
                rtbChangelogs.Text = cUpdate.getOnelineFile(cConst.changelogsFileURL);
            }
            catch {}
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.reddit.com/r/PushBullet/comments/2m2pui/c_implementation_for_those_that_find_it_handy/");
        }

        private void fFirstStartup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cbAccept.Checked)
                Application.Exit();
            else
                Settings.Default.firstStartup = true;
        }

        private void cbAccept_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAccept.Checked)
                btOK.Enabled = true;
            else
                btOK.Enabled = false;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://cscore.codeplex.com/");
        }
    }
}

class CustomTabControl : TabControl
{
    private const int TCM_ADJUSTRECT = 0x1328;

    protected override void WndProc(ref Message m)
    {
        // Hide the tab headers at run-time
        if (m.Msg == TCM_ADJUSTRECT)
        {
            m.Result = (IntPtr)1;
            return;
        }

        // call the base class implementation
        base.WndProc(ref m);
    }
}