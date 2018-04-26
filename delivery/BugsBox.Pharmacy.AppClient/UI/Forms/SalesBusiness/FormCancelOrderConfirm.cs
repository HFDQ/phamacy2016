using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class FormCancelOrderConfirm : Form
    {
        public FormCancelOrderConfirm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 理由
        /// </summary>
        public string Reason 
        { 
            get { return this.txtReason.Text; } 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtReason.Text.Length > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else 
            {
                MessageBox.Show("取消理由必须填写！！！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
