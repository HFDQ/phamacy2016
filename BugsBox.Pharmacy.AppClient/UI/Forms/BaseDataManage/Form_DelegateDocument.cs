using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class Form_DelegateDocument : Form
    {
        public string _details = string.Empty;
        public Form_DelegateDocument(string details)
        {
            InitializeComponent();
            _details = details;
        }

        private void Form_DelegateDocument_Activated(object sender, EventArgs e)
        {
            this.richTextBox1.Text = _details;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _details = this.richTextBox1.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
