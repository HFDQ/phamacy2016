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
    public partial class FormSalesOrderCreateIndex : BaseFunctionForm
    {
        private List<Business.Models.SaleOrderModel> _salesOrderList = new List<SaleOrderModel>();
        private PagerInfo pageInfo = new PagerInfo();
        private IList<User> userList = new List<User>();
        private IList<PaymentMethod> paymentList = new List<PaymentMethod>();
        private List<string> formatField = new List<string>();
        private List<PurchaseUnit> _ParchaseUnitList = new List<PurchaseUnit>();
        string msg = string.Empty;
        public FormSalesOrderCreateIndex()
        {
            try
            {
                InitializeComponent();
                this.dgvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            try
            {
                if (_salesOrderList != null && _salesOrderList.Count > 0)
                {
                    var c = (Business.Models.SaleOrderModel)this.dgvMain.Rows[e.RowIndex].DataBoundItem;
                    SalesOrder so = this.PharmacyDatabaseService.GetSalesOrder(out msg, c.Id);

                    FormSalesOrderEdit form = new FormSalesOrderEdit(so, true);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void GetSalesOrderList()
        {
            try
            {
                _salesOrderList = null;
                string msg = string.Empty;
                SalesCodeSearchInput scsi = InitSalesOrderSearchInput();
                var c = PharmacyDatabaseService.GetSalesOrderCodePaged(scsi, out msg);

                _salesOrderList = c.ToList();
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
            scsi.salerName = string.Empty;
            return scsi;
        }

        private void FormSalesOrderCreateIndex_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvMain.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void tsbtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetSalesOrderList();
                dgvMain.DataSource = new BindingCollection<Business.Models.SaleOrderModel>(_salesOrderList);
                this.HideColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void cmbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HideColumns()
        {
            this.dgvMain.Columns["id"].Visible = false;
            this.dgvMain.Columns["SaleOrderCancelDocumentNumber"].Visible = false;
            this.dgvMain.Columns["PurchaseUnitPinYin"].Visible = false;
            this.dgvMain.Columns["CancelTime"].Visible = false;
            this.dgvMain.Columns["CancelUserName"].Visible = false;
            this.dgvMain.Columns["CancelReason"].Visible = false;

            this.dgvMain.Columns["Saler"].Visible = false;
            this.dgvMain.Columns["SaleOrderBalanceDocumentNumber"].Visible = false;
            this.dgvMain.Columns["BalanceTime"].Visible = false;
            this.dgvMain.Columns["BalanceUserName"].Visible = false;
            this.dgvMain.Columns["PaymentMethod"].Visible = false;
            this.dgvMain.Columns["TotalPrice"].Visible = false;
            //this.dgvMain.Columns["ReturnOrderCol"].Visible = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dgvMain, "配送出库单查询结果");
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                tsbtnSearch_Click(sender, e);
            }
        }


    }
}
