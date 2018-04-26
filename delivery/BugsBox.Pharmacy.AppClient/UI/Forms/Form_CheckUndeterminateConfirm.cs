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
    public partial class Form_CheckUndeterminateConfirm : Form
    {

        public string DrugName { get; set; }
        public string EMName { get; set; }
        public string UndeterminateCheckMemo { get; set; }
        public Decimal UndeterminateDrugNumber { get; set; }

        public Form_CheckUndeterminateConfirm()
        {
            InitializeComponent();

            label3.Text = EMName;
            label5.Text = DrugName;
            label7.Text = UndeterminateDrugNumber.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UndeterminateCheckMemo = this.textBox1.Text.Trim();
            this.Dispose();
        }
    }
}
