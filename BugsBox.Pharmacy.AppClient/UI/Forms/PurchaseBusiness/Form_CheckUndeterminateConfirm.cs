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
        private decimal _UndeterminateDrugNumber = 0m;
        private string _DrugName = string.Empty;
        private string _EMName=string.Empty;

        public string DrugName { get { return _DrugName; } set { _DrugName = value; this.label5.Text = value; } }

        public string EMName { get { return _EMName; } set { _EMName = value; this.label3.Text = value; } }

        public decimal UndeterminateDrugNumber { get { return _UndeterminateDrugNumber; } set { _UndeterminateDrugNumber = value; this.label7.Text = value.ToString(); } }


        public string UndeterminateCheckMemo { get; set; }

        public Form_CheckUndeterminateConfirm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UndeterminateCheckMemo = this.textBox1.Text.Trim();
            this.Dispose();
        }
    }
}
