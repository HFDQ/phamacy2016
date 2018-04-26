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
    public partial class FormSalesOrderCancelIndex : BaseFunctionForm
    {
        private List<Business.Models.SaleOrderModel> _salesOrderList = new List<Business.Models.SaleOrderModel>();        
        string msg = string.Empty;

        public FormSalesOrderCancelIndex()
        {
            
            InitializeComponent();

            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dataGridView1.ReadOnly = true;

            var c = this.PharmacyDatabaseService.AllUsers(out msg).ToList();
            c.Insert(0, new User() { Account = "全部" });
            this.cmbOperator.ValueMember = "Id";
            this.cmbOperator.DisplayMember = "Account";
            this.cmbOperator.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmbOperator.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmbOperator.DataSource = c;
            if (this.cmbOperator.Items.Count <= 0) return;
            this.cmbOperator.SelectedIndex = 0;
        }

        private void GetSalesOrderList()
        {
            try
            {
                _salesOrderList = null;
                string msg = string.Empty;
                SalesCodeSearchInput scsi = InitSalesOrderSearchInput();
                _salesOrderList = PharmacyDatabaseService.GetSalesOrderCancelCodePaged(out msg, scsi).ToList();
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
            if (e.RowIndex < 0||e.ColumnIndex<0) return;
            if (this.dataGridView1.Columns[e.ColumnIndex].Name != this.Column1.Name) return;

            Business.Models.SaleOrderModel som = (Business.Models.SaleOrderModel)this.dataGridView1.Rows[e.RowIndex].DataBoundItem;
            SalesOrder so = this.PharmacyDatabaseService.GetSalesOrder(out msg, som.Id);
            FormSalesOrderEdit frm = new FormSalesOrderEdit(so, true);
            frm.Show(this);
        }

        private void cmbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {            
            label2.Text =this.cmbOperator.SelectedIndex<=0?string.Empty: ((User)cmbOperator.SelectedItem).Employee.Name;
        }

        private void HideColums()
        {
            this.dataGridView1.Columns["SaleOrderBalanceDocumentNumber"].Visible = false;
            this.dataGridView1.Columns["PurchaseUnitPinYin"].Visible = false;
            this.dataGridView1.Columns["BalanceTime"].Visible = false;
            this.dataGridView1.Columns["BalanceUserName"].Visible = false;

            this.dataGridView1.Columns["PaymentMethod"].Visible = false;

            this.dataGridView1.Columns["PickCode"].Visible = false;
            this.dataGridView1.Columns["PickUserName"].Visible = false;
            this.dataGridView1.Columns["PickTime"].Visible = false;

            this.dataGridView1.Columns["CheckCode"].Visible = false;
            this.dataGridView1.Columns["CheckUserName"].Visible = false;
            this.dataGridView1.Columns["CheckUserName2"].Visible = false;
            this.dataGridView1.Columns["CheckTime"].Visible = false;
            this.dataGridView1.Columns["ReturnOrderCol"].Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "销售取消单查询结果");
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                toolStripButton1_Click(sender, e);
        }

    }
}
