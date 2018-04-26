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
    public partial class FormRewardVATSet : BaseFunctionForm
    {
        string msg;
        public FormRewardVATSet(Business.Models.SalesOrderForVATModel m)
        {
            InitializeComponent();

            this.label4.Text = m.PurchaseUnitName;
            this.label6.Text = m.SaleOrderDocumentNumber;
            this.textBox1.Text = m.VATCode;
            this.textBox2.Text = m.VATNumber;
            this.textBox3.Text = m.VATRate.ToString();

            this.button1.Click += (s, e) =>
            {
                string code = this.textBox1.Text.Trim();
                if (string.IsNullOrEmpty(code))
                {
                    MessageBox.Show("请输入发票代码");return;
                }
                string number = this.textBox2.Text.Trim();
                if (string.IsNullOrEmpty(number))
                {
                    MessageBox.Show("请输入发票号码"); return;
                }

                decimal VATRate;
                var d=decimal.TryParse(this.textBox3.Text.Trim(), out VATRate);
                if (!d)
                {
                    MessageBox.Show("对不起，填写税率时，请输入数字！");return;
                }                

                bool b=this.PharmacyDatabaseService.SaveVATCode(m.Id, code, number,VATRate,string.Empty,out msg);
                if (b)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            };

            this.button2.Click += (s, e) =>
            {
                this.Close();
            };
        }
    }
}
