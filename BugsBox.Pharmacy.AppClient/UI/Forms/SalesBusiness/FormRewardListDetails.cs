using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Business.Models;
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
    public partial class FormRewardListDetails : BaseFunctionForm
    {
        string msg = string.Empty;

        #region Tooltip一个
        //ToolTip tooltip = new ToolTip
        //{
        //    AutoPopDelay = 3000,
        //    UseAnimation = true,
        //    UseFading = true,
        //    InitialDelay = 500,
        //    IsBalloon = true,
        //    ReshowDelay = 500,
        //    ToolTipTitle = "使用提示",
        //    ToolTipIcon = ToolTipIcon.Info,

        //}; 
        #endregion

        public FormRewardListDetails(SalesOrderForVATModel m)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            var purchaseunit = this.PharmacyDatabaseService.GetPurchaseUnit(out msg, m.PurchaseUnitId);

            this.textBox2.Text = purchaseunit.Bank;

            var setting = AppClientContext.GetCurrentSalePriceControlRulesModel();
            if (setting != null)
            {
                textBox1.Text = setting.SalesOrderDefaultTaxRate.DefaultTaxRate.ToString();
            }


            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowPostPaint += (s, e) => DataGridViewOperator.SetRowNumber(this.dataGridView1, e);
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.toolStripButton3.Enabled = false;

            var cellstyle = new DataGridViewCellStyle
            {
                BackColor = Color.Yellow,
            };
            Action RefreshData = () =>
            {
                var u = this.PharmacyDatabaseService.GetSalesOrderDetailForVATModels(m.Id, out msg);
                this.dataGridView1.DataSource = u.ToList();

                this.dataGridView1.Columns["SalesOrderId"].Visible = false;
                this.dataGridView1.Columns["SalesOrderDetailId"].Visible = false;
                this.dataGridView1.Columns["VAT"].Visible = false;

                this.dataGridView1.Columns["Discount"].DefaultCellStyle = cellstyle;
            };

            RefreshData();

            this.toolStripButton1.Click += (s, e) => RefreshData();

            this.button1.Click += (s, e) =>
            {
                decimal vatrate;
                if (!decimal.TryParse(this.textBox1.Text.Trim(), out vatrate))
                {
                    MessageBox.Show("清单税率请填写数字");
                    textBox1.Focus();
                    return;
                }
                string bank = this.textBox2.Text.Trim();


                var b = this.PharmacyDatabaseService.SaveVATCode(m.Id, string.Empty, string.Empty, vatrate, bank, out msg);
                MessageBox.Show(b ? "保存成功！" : msg);
                if (b)
                {
                    RefreshData();
                    this.toolStripButton3.Enabled = true;
                }
            };

            this.toolStripButton3.Click += (s, e) =>
            {
                this.dataGridView1.EndEdit();
                this.Validate();

                var list = this.dataGridView1.DataSource as List<Business.Models.SalesOrderDetailForVATModel>;

                this.PharmacyDatabaseService.SaveVATForSalesOrderDetails(list.ToArray(), out msg);
                if (string.IsNullOrEmpty(msg))
                {
                    MessageBox.Show("保存成功！");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(msg);
                }
            };

            this.toolStripButton4.Click += (s, e) =>
            {
                MyExcelUtls.DataGridview2Sheet(this.dataGridView1, m.SaleOrderDocumentNumber + "劳务清单");
            };

            this.dataGridView1.CellEnter += (s, e) =>
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Discount")
                {
                    this.dataGridView1.ReadOnly = false;
                }
                else
                {
                    this.dataGridView1.ReadOnly = true;
                }
            };

            this.Shown += (s, e) =>
            {

            };
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
