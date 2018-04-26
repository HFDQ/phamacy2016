using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Application.Core;
using BugsBox.Common.Config;
 

namespace BugsBox.Pharmacy.ServiceHost.UserControls
{
    public partial class IndexUserControl : UserControl
    {
        public IndexUserControl()
        {
            InitializeComponent();
        }

        private void buttonModifyCreateDataAuto_Click(object sender, EventArgs e)
        {
            AppConfig.Config.AutoCreateAndInitDatabase = true;
            ConfigHelper<AppConfig>.SaveConfig();
        }

        private void IndexUserControl_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void IndexUserControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                this.buttonModifyCreateDataAuto.Visible = !this.buttonModifyCreateDataAuto.Visible;
            }
        }
    }
}
