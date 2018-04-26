using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public delegate void GetBatchEventHandler(object sender, BatchQueryEventArgs ex);
    
    public partial class Form_FormPurchaseHistoryBySupplyer_Batch : Form
    {
        public event GetBatchEventHandler GetBatch;
        public Form_FormPurchaseHistoryBySupplyer_Batch(string s)
        {
            InitializeComponent();
            this.textBox1.Text = s;
            this.FormClosed += (sender, e) =>
            {
                this.Dispose();
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BatchQueryEventArgs be = new BatchQueryEventArgs();
            be.Batch = this.textBox1.Text.Trim();
            be.IsPrecise = this.checkBox1.Checked;
            if (GetBatch != null)
            {
                GetBatch(this, be);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }

    public class BatchQueryEventArgs:EventArgs
    {
        public string Batch { get; set; }
        public bool IsPrecise { get; set; }
    }
}
