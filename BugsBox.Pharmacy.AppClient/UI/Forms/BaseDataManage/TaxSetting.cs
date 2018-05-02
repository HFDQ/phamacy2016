using BugsBox.Pharmacy.Business.Models;
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
    public partial class TaxSetting : BaseFunctionForm
    {
        string message = string.Empty;

        SalePriceControlRulesModel sets;
        public TaxSetting()
        {
            InitializeComponent();

            sets = this.PharmacyDatabaseService.GetSalePriceControlRules(out message);
            if (sets.PurchaseOrderDefaultTaxRate != null)
            {
                textBox1.Text = sets.PurchaseOrderDefaultTaxRate.DefaultTaxRate.ToString();
            }

            if (sets.SalesOrderDefaultTaxRate != null)
            {

                textBox2.Text = sets.SalesOrderDefaultTaxRate.DefaultTaxRate.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sets.PurchaseOrderDefaultTaxRate == null)
                {
                    sets.PurchaseOrderDefaultTaxRate = new PurchaseOrderTaxRate();
                }
                sets.PurchaseOrderDefaultTaxRate.DefaultTaxRate = decimal.Parse(textBox1.Text);
                if (sets.SalesOrderDefaultTaxRate == null)
                {
                    sets.SalesOrderDefaultTaxRate = new SalesOrderTaxRate();
                }
                sets.SalesOrderDefaultTaxRate.DefaultTaxRate = decimal.Parse(textBox2.Text);
                var b = this.PharmacyDatabaseService.SaveSalePriceControlRules(sets, out message);
                if (b)
                {
                    MessageBox.Show("保存成功！");
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("保存出错！");
            }
        }
    }
}
