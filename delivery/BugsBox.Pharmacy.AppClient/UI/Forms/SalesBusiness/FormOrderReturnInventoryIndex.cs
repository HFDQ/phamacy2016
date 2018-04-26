using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.PS;
using CustomValidatorsLibrary;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Service.Models;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class FormOrderReturnInventoryIndex : BaseFunctionForm
    {
        private List<SalesOrderReturn> _salesOrderReturnList = new List<SalesOrderReturn>();
        ContextMenuStrip cms = new ContextMenuStrip();
        string msg = string.Empty;
        public FormOrderReturnInventoryIndex()
        {
            InitializeComponent();
            this.dataGridView1.ReadOnly = true;

            var c = this.PharmacyDatabaseService.AllUsers(out msg);
            this.cmbOperator.ValueMember = "Id";
            this.cmbOperator.DisplayMember = "Account";
            this.cmbOperator.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmbOperator.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmbOperator.DataSource = c.ToList();
            if (this.cmbOperator.Items.Count <= 0) return;
            this.cmbOperator.SelectedIndex = 0;

            ToolStripMenuItem tsmi = new ToolStripMenuItem("手工统计");
            tsmi.DropDownItems.Add("求和", null, delegate(object sender, EventArgs e) { this.GetResult(0); });
            tsmi.DropDownItems.Add("平均", null, delegate(object sender, EventArgs e) { this.GetResult(1); });
            tsmi.DropDownItems.Add("记数", null, delegate(object sender, EventArgs e) { this.GetResult(2); });
            cms.Items.Add(tsmi);
        }

        private void HideColumn()
        {
            if (dataGridView1.ColumnCount < 1) return;
            this.dataGridView1.Columns["SalesOrderId"].Visible = false;
            this.dataGridView1.Columns["SaleOrderReturnCheckDocumentNumber"].Visible = false;
            this.dataGridView1.Columns["SaleOrderReturnChecker"].Visible = false;
            this.dataGridView1.Columns["SaleOrderReturnCheckTime"].Visible = false;

            this.dataGridView1.Columns["SaleOrderReturnCancelDocumentNumber"].Visible = false;
            this.dataGridView1.Columns["SaleOrderReturnCanceler"].Visible = false;
            this.dataGridView1.Columns["SaleOrderReturnCancelTime"].Visible = false;
            this.dataGridView1.Columns["SaleOrderReturnCancelReason"].Visible = false;

            this.dataGridView1.Columns["PurchaseUnitPinYin"].Visible = false;
        }

        private void GetResult(int i)
        {
            DataGridViewSelectedCellCollection sc = this.dataGridView1.SelectedCells;

            List<decimal> ListD = new List<decimal>();

            foreach (DataGridViewCell r in sc)
            {
                decimal d = 0m;
                if (r.Value == null) r.Value = 0.0m;
                bool b = Decimal.TryParse(r.Value.ToString(), out d);
                if (!b)
                {
                    MessageBox.Show("您所选择的单元格含有非数字，请取消其选择，谢谢！");
                    return;
                }
                ListD.Add(d);
            }

            decimal result = i == 0 ? ListD.Sum() : i == 1 ? ListD.Average() : ListD.Count;
            MessageBox.Show("统计结果是：" + result.ToString("F4"));
        }

        private void GetListSalesOrderReturn()
        {
            try
            {
                _salesOrderReturnList = null;
                string msg = string.Empty;
                SalesCodeSearchInput scsi = InitSalesOrderSearchInput();
                var c = this.PharmacyDatabaseService.GetReturnOrderCheckCodePaged(scsi, out msg);
                this.dataGridView1.DataSource = new BindingCollection<Business.Models.SalesOrderReturnModel>(c.ToList());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private SalesCodeSearchInput InitSalesOrderSearchInput()
        {
            SalesCodeSearchInput scsi = new SalesCodeSearchInput();
            scsi.FromDate = dtFrom.Value.Date;
            scsi.ToDate = dtTo.Value.AddDays(1).Date;
            scsi.Code = this.txtCode.Text.Trim();
            if (this.cmbOperator.SelectedValue != null)
                scsi.OperatorID = (Guid)cmbOperator.SelectedValue;
            else
                scsi.OperatorID = Guid.Empty;
            return scsi;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.GetListSalesOrderReturn();
            this.HideColumn();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            cms.Show(MousePosition.X, MousePosition.Y);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (this.dataGridView1.Columns[e.ColumnIndex].Name != this.Column1.Name) return;

            Business.Models.SalesOrderReturnModel som = (Business.Models.SalesOrderReturnModel)this.dataGridView1.Rows[e.RowIndex].DataBoundItem;
            var orderReturn = PharmacyDatabaseService.GetSalesOrderReturn(out msg, som.Id);
            FormSalesOrderReturn form = new FormSalesOrderReturn(orderReturn);
            form.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "销售退货入库单");
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                toolStripButton1_Click(sender, e);
        }
    }
}
