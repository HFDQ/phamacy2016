using BugsBox.Pharmacy.AppClient.UI.Report;
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
    public partial class FormRewardList : BaseFunctionForm
    {
        string msg = string.Empty;
        public FormRewardList()
        {
            InitializeComponent();

            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowPostPaint += (s, e) => DataGridViewOperator.SetRowNumber(this.dataGridView1, e);
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.toolStripButton1.Click += (s, e) => this.GetData();
            this.button1.Click += (s, e) => this.GetData();

            //设置
            Action SetVAT = () =>
            {
                var m = this.dataGridView1.CurrentRow.DataBoundItem as SalesOrderForVATModel;
                if (m == null) return;

                using (FormRewardListDetails frm = new FormRewardListDetails(m))
                {
                    frm.ShowDialog();
                }
            };

            this.toolStripButton3.Click += (s, e) => SetVAT();
            this.dataGridView1.CellDoubleClick +=(s,e)=> SetVAT();

            this.textBox1.Text = "20171214";//测试数据

        }

        private void GetData()
        {
            var keyword = this.textBox1.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("请输入销售单号后再执行查询！"); return;
            }

            Business.Models.SalesOrderForVATQueryModel q = new Business.Models.SalesOrderForVATQueryModel
            {
                Keyword = keyword,
                PurchaseUnitName = this.textBox2.Text.Trim()
            };
            var re = this.PharmacyDatabaseService.GetVATModelsbyQueryModel(q, out msg).OrderBy(r => r.PurchaseUnitName);

            this.dataGridView1.DataSource = re.ToList();
            this.dataGridView1.Columns["Id"].Visible = false;
            this.dataGridView1.Columns["PurchaseUnitId"].Visible = false;
            this.dataGridView1.Columns["VATCode"].Visible = false;
            this.dataGridView1.Columns["VATNumber"].Visible = false;
            this.dataGridView1.Columns["VATRate"].Visible = false;
        }

        private void VATSet()
        {
            Business.Models.SalesOrderForVATModel m = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.SalesOrderForVATModel;
            FormRewardVATSet frm = new FormRewardVATSet(m);
            frm.StartPosition = FormStartPosition.CenterParent;
            var re = frm.ShowDialog();
            if (re == DialogResult.OK)
            {
                this.GetData();
            }
        }

        private void Print()
        {
            if (this.dataGridView1.CurrentRow == null) return;
            var m = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.SalesOrderForVATModel;

            var list = this.PharmacyDatabaseService.GetSalesOrderDetailForVATModels(m.Id, out msg);

            Reports.VATList ds = new Reports.VATList();
            ds.ExtendedProperties.Clear();
            ds.Tables.Clear();
            ds.ExtendedProperties.Add("title", "销售货物或者提供劳务应税清单");
            ds.ExtendedProperties.Add("PurchaseUnitName", m.PurchaseUnitName);
            ds.ExtendedProperties.Add("StoreName", m.StoreName);
            ds.ExtendedProperties.Add("VATCode", m.VATCode);
            ds.ExtendedProperties.Add("VATNumber", m.VATNumber);
            ds.ExtendedProperties.Add("SaleDate", DateTime.Now.ToString("yyyy/MM/dd"));

            Reports.VATList.VATDataTableDataTable dt = new Reports.VATList.VATDataTableDataTable();

            foreach (var i in list)
            {               
                dt.Rows.Add(new object[] {i.ProductGeneralName,i.SpecificName,i.MeasurementName,i.Amount,i.UnitPrice,i.Price,i.VATRate.ToString()+"%",i.VAT });
            }

            ds.Tables.Add(dt);
            PrintHelperExtention printHelper = new PrintHelperExtention("Reports\\ReportVATList.rdlc", ds);
            printHelper.Print();

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
