using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.AppClient.UI.UserControls;
using BugsBox.Pharmacy.Models;


namespace BugsBox.Pharmacy.AppClient.UI.Forms.ApprovalFlow
{
    public partial class FormDrugsUnqualificationApprovalSelector :BaseFunctionForm
    {
        
        public string unqualificationRsn{get;set;}
        
        public bool ok;
        public FormDrugsUnqualificationApprovalSelector(string title)
        {
            InitializeComponent();
            label1.Text += title;
        }

        private void FormDrugsUnqualificationApprovalSelector_Load(object sender, EventArgs e)
        {                        
            this.textBox1.Text = this.unqualificationRsn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            unqualificationRsn = this.textBox1.Text.Trim();
            
            ok = true;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
