using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class FormSalesOrderStatistics : BaseFunctionForm
    {
        private List<SalesOrderStatisticOutput> Result { set; get; }
        private List<SalesOrderReturn> ListReturns = new List<SalesOrderReturn>();
        BugsBox.Pharmacy.UI.Common.BaseRightMenu cms = null;
        string msg = string.Empty;

        public FormSalesOrderStatistics()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.RowPostPaint += delegate (object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            cms = new Pharmacy.UI.Common.BaseRightMenu(this.dataGridView1);
        }

        private void FormSalesOrderStatistics_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn dc in this.dataGridView1.Columns)
            {
                dc.Name = dc.DataPropertyName;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void Search()
        {
            SalesOrderStatisticInput sosi = new SalesOrderStatisticInput();
            sosi.FromDate = this.dtFrom.Value.Date;
            sosi.ToDate = this.dtTo.Value.AddDays(1).Date;
            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() != typeof(RadioButton)) continue;
                RadioButton r = (RadioButton)c;
                if (r.Checked)
                {
                    sosi.StatisticObject = r.TabIndex - 95;
                    this.HideColumn(r.TabIndex - 95);
                    break;
                }
            }
            var result = this.PharmacyDatabaseService.AddupSalesOrder(out msg, sosi);
            var d = result.OrderBy(o => o.DrugName).ToList();

            Business.Models.SalesOrderStatisticOutput SumRow = new Business.Models.SalesOrderStatisticOutput();
            SumRow.StatisticObject = "合计";
            SumRow.Sum = result.Sum(r => r.Sum);
            SumRow.CostSum = result.Sum(r => r.CostSum);
            SumRow.GrossProfit = result.Sum(r => r.GrossProfit);
            SumRow.ReturnSaleNum = result.Sum(r => r.ReturnSaleNum);
            SumRow.ReturnSum = result.Sum(r => r.ReturnSum);
            SumRow.ReturnCostSum = result.Sum(r => r.ReturnCostSum);
            SumRow.Count = result.Sum(r => r.Count);
            SumRow.SaleNum = result.Sum(r => r.SaleNum);
            SumRow.SaleNumSum = result.Sum(r => r.SaleNumSum);
            d.Insert(d.Count, SumRow);

            label5.Text = Decimal.Round(SumRow.Sum, 2).ToString() + "元";
            label9.Text = Decimal.Round(SumRow.CostSum, 2).ToString() + "元";
            label11.Text = Decimal.Round(SumRow.GrossProfit, 2).ToString() + "元";

            this.dataGridView1.DataSource = new BindingCollection<Business.Models.SalesOrderStatisticOutput>(d.ToList());

        }

        private void HideColumn(int RadioIndex)
        {
            foreach (DataGridViewColumn dc in this.dataGridView1.Columns)
            {
                dc.Visible = true;
            }
            switch (RadioIndex)
            {
                case 0:
                    this.dataGridView1.Columns["PurchaseUnitName"].Visible = false;
                    this.dataGridView1.Columns["SalerName"].Visible = false;

                    break;
                case 1:
                    this.dataGridView1.Columns["SalerName"].Visible = false;
                    this.dataGridView1.Columns["DrugName"].Visible = false;
                    this.dataGridView1.Columns["Dosage"].Visible = false;
                    this.dataGridView1.Columns["Specific"].Visible = false;
                    this.dataGridView1.Columns["FactoryName"].Visible = false;
                    this.dataGridView1.Columns["Origin"].Visible = false;
                    this.dataGridView1.Columns["PermitNumber"].Visible = false;
                    this.dataGridView1.Columns["BusinessType"].Visible = false;
                    this.dataGridView1.Columns["WareHouseZone"].Visible = false;
                    break;
                case 2:
                    this.dataGridView1.Columns["PurchaseUnitName"].Visible = false;
                    this.dataGridView1.Columns["DrugName"].Visible = false;
                    this.dataGridView1.Columns["Dosage"].Visible = false;
                    this.dataGridView1.Columns["Specific"].Visible = false;
                    this.dataGridView1.Columns["FactoryName"].Visible = false;
                    this.dataGridView1.Columns["Origin"].Visible = false;
                    this.dataGridView1.Columns["PermitNumber"].Visible = false;
                    this.dataGridView1.Columns["BusinessType"].Visible = false;
                    this.dataGridView1.Columns["WareHouseZone"].Visible = false;
                    break;
                case 3:
                    this.dataGridView1.Columns["SalerName"].Visible = false;
                    this.dataGridView1.Columns["PurchaseUnitName"].Visible = false;
                    this.dataGridView1.Columns["DrugName"].Visible = false;
                    this.dataGridView1.Columns["Dosage"].Visible = false;
                    this.dataGridView1.Columns["Specific"].Visible = false;
                    this.dataGridView1.Columns["FactoryName"].Visible = false;
                    this.dataGridView1.Columns["Origin"].Visible = false;
                    this.dataGridView1.Columns["PermitNumber"].Visible = false;
                    this.dataGridView1.Columns["BusinessType"].Visible = false;
                    break;
                case 4:
                    this.dataGridView1.Columns["SalerName"].Visible = false;
                    this.dataGridView1.Columns["PurchaseUnitName"].Visible = false;
                    this.dataGridView1.Columns["DrugName"].Visible = false;
                    this.dataGridView1.Columns["WareHouseZone"].Visible = false;
                    this.dataGridView1.Columns["Specific"].Visible = false;
                    this.dataGridView1.Columns["FactoryName"].Visible = false;
                    this.dataGridView1.Columns["Origin"].Visible = false;
                    this.dataGridView1.Columns["PermitNumber"].Visible = false;
                    this.dataGridView1.Columns["BusinessType"].Visible = false;
                    break;
                case 5:
                    this.dataGridView1.Columns["WareHouseZone"].Visible = false;
                    this.dataGridView1.Columns["SalerName"].Visible = false;
                    this.dataGridView1.Columns["PurchaseUnitName"].Visible = false;
                    this.dataGridView1.Columns["DrugName"].Visible = false;
                    this.dataGridView1.Columns["Dosage"].Visible = false;
                    this.dataGridView1.Columns["Specific"].Visible = false;
                    this.dataGridView1.Columns["FactoryName"].Visible = false;
                    this.dataGridView1.Columns["Origin"].Visible = false;
                    this.dataGridView1.Columns["PermitNumber"].Visible = false;
                    break;
                case 6:
                    this.dataGridView1.Columns["WareHouseZone"].Visible = false;
                    this.dataGridView1.Columns["SalerName"].Visible = false;
                    this.dataGridView1.Columns["PurchaseUnitName"].Visible = false;
                    this.dataGridView1.Columns["DrugName"].Visible = false;
                    this.dataGridView1.Columns["Dosage"].Visible = false;
                    this.dataGridView1.Columns["Specific"].Visible = false;
                    this.dataGridView1.Columns["FactoryName"].Visible = false;
                    this.dataGridView1.Columns["Origin"].Visible = false;
                    this.dataGridView1.Columns["PermitNumber"].Visible = false;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "销售统计（" + dtFrom.Value.ToLongDateString() + "至：" + dtTo.Value.ToLongDateString() + "）");
        }

    }
}
