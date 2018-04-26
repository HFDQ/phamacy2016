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
    public partial class FormSalesOrderBalanceIndex :BaseFunctionForm
    {
        private List<Business.Models.SaleOrderModel> _salesOrderList = new List<Business.Models.SaleOrderModel>();
        ContextMenuStrip cms = new ContextMenuStrip();
        string msg = string.Empty;

        public FormSalesOrderBalanceIndex()
        {
            InitializeComponent();

            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            var allUser = this.PharmacyDatabaseService.AllUsers(out msg).OrderBy(r=>r.Account).ToList();
            allUser.Insert(0, new User() { Account = "全部" });            
            this.cmbOperator.ValueMember = "Id";
            this.cmbOperator.DisplayMember = "Account";
            this.cmbOperator.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmbOperator.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmbOperator.DataSource = allUser;
            this.cmbOperator.SelectedIndex = 0;

            ToolStripMenuItem tsmi = new ToolStripMenuItem("手工统计");
            tsmi.DropDownItems.Add("求和", null, delegate(object sender, EventArgs e) { this.GetResult(0); });
            tsmi.DropDownItems.Add("平均", null, delegate(object sender, EventArgs e) { this.GetResult(1); });
            tsmi.DropDownItems.Add("记数", null, delegate(object sender, EventArgs e) { this.GetResult(2); });
            cms.Items.Add(tsmi);
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

        private void GetSalesOrderList()
        {
            try
            {
                _salesOrderList = null;
                string msg = string.Empty;
                SalesCodeSearchInput scsi = InitSalesOrderSearchInput();
                _salesOrderList = PharmacyDatabaseService.GetSalesOrderCodePaged(scsi,out msg ).ToList();
                this.dataGridView1.DataSource = new BindingCollection<Business.Models.SaleOrderModel>(_salesOrderList);
                this.HideColums();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private SalesCodeSearchInput InitSalesOrderSearchInput() 
        {
            SalesCodeSearchInput scsi = new SalesCodeSearchInput();
            scsi.FromDate = dtFrom.Value.Date;
            scsi.ToDate = dtTo.Value.AddDays(1).Date;
            scsi.Code = this.txtCode.Text.Trim();
            scsi.salerName = this.label2.Text.Trim();
            return scsi;
        }

        private void FormSalesOrderBalanceIndex_Load(object sender, EventArgs e)
        {
            
        }

        private void cmbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {            
            label2.Text =cmbOperator.SelectedIndex<=0?string.Empty: ((User)cmbOperator.SelectedItem).Employee.Name;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                GetSalesOrderList();
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "成功查询销售取消单");
                this.dataGridView1.DataSource = _salesOrderList;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (this.dataGridView1.Columns[e.ColumnIndex].Name != this.Column1.Name) return;

            Business.Models.SaleOrderModel som = (Business.Models.SaleOrderModel)this.dataGridView1.Rows[e.RowIndex].DataBoundItem;
            SalesOrder so = this.PharmacyDatabaseService.GetSalesOrder(out msg, som.Id);
            FormSalesOrderEdit frm = new FormSalesOrderEdit(so, true);
            frm.Show(this);
        }

        private void HideColums()
        {
            this.dataGridView1.Columns["SaleOrderCancelDocumentNumber"].Visible = false;
            this.dataGridView1.Columns["PurchaseUnitPinYin"].Visible = false;
            this.dataGridView1.Columns["CancelTime"].Visible = false;
            this.dataGridView1.Columns["CancelUserName"].Visible = false;
            this.dataGridView1.Columns["CancelReason"].Visible = false;
            this.dataGridView1.Columns["PickCode"].Visible = false;
            this.dataGridView1.Columns["PickUserName"].Visible = false;
            this.dataGridView1.Columns["PickTime"].Visible = false;
            this.dataGridView1.Columns["CheckCode"].Visible = false;
            this.dataGridView1.Columns["CheckUserName"].Visible = false;
            this.dataGridView1.Columns["CheckUserName2"].Visible = false;
            this.dataGridView1.Columns["CheckTime"].Visible = false;
            this.dataGridView1.Columns["ReturnOrderCol"].Visible = false;
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            cms.Show(MousePosition.X, MousePosition.Y);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "销售结算查询结果");
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                toolStripButton1_Click(sender, e);
        }

    }
}
