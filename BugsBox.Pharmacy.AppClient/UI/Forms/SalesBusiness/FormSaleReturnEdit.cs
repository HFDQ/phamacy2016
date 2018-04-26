using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.UI.Common.Helper;
using Omu.ValueInjecter;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.AppClient.UI.Report;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class FormSaleReturnEdit : BaseFunctionForm
    {
        string msg;

        BindingList<Models.SalesOrder> BList = new BindingList<Models.SalesOrder>();
        DateTimePicker DTPF = null;
        DateTimePicker DTPT = null;
        public FormSaleReturnEdit()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.RowPostPaint += delegate (object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };

            DTPF = new DateTimePicker();
            DTPF.Value = DateTime.Now.AddMonths(-1).Date;
            DTPT = new DateTimePicker();
            DTPT.Value = DateTime.Now.Date;

            this.toolStrip1.Items.Insert(this.toolStrip1.Items.Count - 1, new ToolStripControlHost(DTPT));
            this.toolStrip1.Items.Insert(this.toolStrip1.Items.Count - 3, new ToolStripControlHost(DTPF));
        }

        private void getSaleOutInventoryData()
        {
            Business.Models.SalesOrderQueryModel soqm = new Business.Models.SalesOrderQueryModel();
            soqm.PurchaseUnitKeyword = this.toolStripTextBox1.Text.Trim();
            soqm.DrugInfoKeyword = this.toolStripTextBox2.Text.Trim();
            soqm.DTF = this.DTPF.Value.Date;
            soqm.DTT = this.DTPT.Value.AddDays(1).Date;
            soqm.Batch = this.toolStripTextBox3.Text.Trim();
            soqm.PinyinCode = toolStripTextBox4.Text.Trim();
            //if (string.IsNullOrEmpty(soqm.PurchaseUnitKeyword))
            //{
            //    MessageBox.Show("请输入购货单位助记码或者购货单位名称！"); return;
            //}

            var all = this.PharmacyDatabaseService.GetSalesOrderByOrderModel(soqm, out msg);
            this.dataGridView1.DataSource = new BindingCollection<Business.Models.SalesOrderModelForSalesOrderReturn>(all.OrderBy(r => r.BalanceDate).ToList());
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                this.toolStripButton1_Click(null, null);
            }
        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.dataGridView1.CurrentCell.OwningColumn.Name != Column5.Name) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            Business.Models.SalesOrderModelForSalesOrderReturn r = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Business.Models.SalesOrderModelForSalesOrderReturn;
            Models.OutInventory[] outin = this.PharmacyDatabaseService.GetOutInventoryByOrderID(out msg, r.Id);
            Models.OutInventory outInv = outin.First();
            if (outin.Count() > 1)
            {
                outInv.SalesOutInventoryDetails.Clear();
                foreach (var c in outin)
                    foreach (var d in c.SalesOutInventoryDetails)
                        outInv.SalesOutInventoryDetails.Add(d);
            }
            FormSalesOrderReturn form = new FormSalesOrderReturn(outInv);
            form.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.getSaleOutInventoryData();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
