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
    public partial class fDonate : Form
    {
        public fDonate()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=X9RVAPQR5KCLY&lc=DE&item_name=zekro%20Development&no_note=1&no_shipping=1&currency_code=EUR&bn=PP%2dDonationsBF%3abtn_donateCC_LG%2egif%3aNonHosted");
            this.Close();
        }

        private void cbDontShowAgain_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.dontShowDonate = cbDontShowAgain.Checked;
        }
    }
}
