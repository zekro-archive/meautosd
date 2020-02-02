using meautosd.Properties;
using Microsoft.Win32;
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
            Process.Start("https://paypal.me/zekro");
            this.Close();
        }

        private void fDonate_Load(object sender, EventArgs e)
        {

        }
    }
}
