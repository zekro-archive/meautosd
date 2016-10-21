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
    public partial class fSurvey : Form
    {
        public fSurvey()
        {
            InitializeComponent();
        }

        private void fSurvey_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.dontShowSurvey = true;
            Registry.SetValue(cConst.setKey, "dontShowSurvey", "true");
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.google.com/forms/d/e/1FAIpQLSdoHNP9ptB51WhLsEqi4qU-4QQy3tjn3Nf7LbGtlM8JopsWzQ/viewform");
            this.Close();
        }

        private void fSurvey_Load(object sender, EventArgs e)
        {

        }
    }
}
