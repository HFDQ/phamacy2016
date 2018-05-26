using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class Form_PurchaseOrder_Set : BaseFunctionForm
    {
        public PurchaseOrderTaxRate CurrentTaxRateModel { get; private set; }
        string message = string.Empty;
        public Form_PurchaseOrder_Set()
        {
            InitializeComponent();

            var sets = this.PharmacyDatabaseService.GetSalePriceControlRules(out message);
            this.CurrentTaxRateModel = sets.PurchaseOrderDefaultTaxRate ?? new PurchaseOrderTaxRate
            {
                DefaultTaxRate = decimal.Parse("0.16")
            };

            this.purchaseOrderTaxRateBindingSource.Add(this.CurrentTaxRateModel);

            this.button1.Click += (s, e) =>
            {
                var re = MessageBox.Show("确定要保存设置吗？", "提示", MessageBoxButtons.OKCancel);
                if (re == System.Windows.Forms.DialogResult.Cancel) return;
                sets.PurchaseOrderDefaultTaxRate = this.CurrentTaxRateModel;
                var b = this.PharmacyDatabaseService.SaveSalePriceControlRules(sets, out message);
                if (b)
                {
                    MessageBox.Show("保存成功！");
                    this.DialogResult = DialogResult.OK;
                }
            };

            this.button2.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
