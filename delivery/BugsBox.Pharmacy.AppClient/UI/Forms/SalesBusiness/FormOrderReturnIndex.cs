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
    public partial class FormOrderReturnIndex : BaseFunctionForm
    {
        string msg = string.Empty;

        IList<SalesOrderReturnModel> _SalesOrderReturnModelList;

        BaseRightMenu _brm = null;

        public FormOrderReturnIndex()
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

            this._brm = new BaseRightMenu(this.dataGridView1);

            #region 行号
            this.dataGridView1.RowPostPaint += (s, e) =>
                {
                    DataGridViewOperator.SetRowNumber(this.dataGridView1, e);
                }; 
            #endregion

            #region 按单号合并，右键
            this._brm.InsertMenuItem("按单号合并", this.GroupByROrderNumber);
            #endregion

            #region 分裂单号，右键
            this._brm.InsertMenuItem("分裂单号", delegate()
            {
                if (this._SalesOrderReturnModelList == null) return;
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = this._SalesOrderReturnModelList;
                this.HideColumns();
            });
            #endregion

            #region 右键打开退单单据和对应的销售单据
            this._brm.InsertMenuItem("打开退单",this.OpenReturnOrder);
            this._brm.InsertMenuItem("打开对应的销售单", OpenSalesOrder);
            #endregion
        }

        #region 按退货单号合并操作
        private void GroupByROrderNumber()
        {
            if (this._SalesOrderReturnModelList == null) return;
            var g = this._SalesOrderReturnModelList.GroupBy(r => r.SaleOrderReturnDocumentNumber).Select(a => new SalesOrderReturnModel
            {
                Creater = a.FirstOrDefault().Creater,
                Id = a.FirstOrDefault().Id,
                DrugNum = a.Sum(i => i.DrugNum),
                Saler = a.FirstOrDefault().Saler,
                PurchaseUnitName = a.FirstOrDefault().PurchaseUnitName,
                SaleOrderReturnDocumentNumber = a.Key,
                SaleOrderReturnInver = a.FirstOrDefault().SaleOrderReturnInver,
                SaleOrderReturnChecker = a.FirstOrDefault().SaleOrderReturnChecker,
                SaleOrderReturnCheckTime = a.FirstOrDefault().SaleOrderReturnCheckTime,
                SaleOrderReturnCheckDocumentNumber = a.FirstOrDefault().SaleOrderReturnCheckDocumentNumber,
                SaleOrderReturnINvDocumentNumber = a.FirstOrDefault().SaleOrderReturnINvDocumentNumber,
                CreateTime = a.FirstOrDefault().CreateTime,
                SaleOrderDocumentNumber = a.FirstOrDefault().SaleOrderDocumentNumber,
                PurchaseUnitPinYin = a.FirstOrDefault().PurchaseUnitPinYin,
                SaleOrderReturnInvTime = a.FirstOrDefault().SaleOrderReturnInvTime,
                TotalPrice = a.Sum(i => i.TotalPrice),
                SaleOrderReturnCancelDocumentNumber = a.FirstOrDefault().SaleOrderReturnCancelDocumentNumber,
                SaleOrderReturnCanceler = a.FirstOrDefault().SaleOrderReturnCanceler,
                SaleOrderReturnCancelReason = a.FirstOrDefault().SaleOrderReturnCancelReason,
                SaleOrderReturnCancelTime = a.FirstOrDefault().SaleOrderReturnCancelTime,
                 SalesOrderId=a.FirstOrDefault().SalesOrderId
            }).ToList();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = new BindingCollection<Business.Models.SalesOrderReturnModel>(g);
            this.HideColumns();
        } 
        #endregion

        private void HideColumns()
        {
            if (dataGridView1.ColumnCount < 1) return;
            this.dataGridView1.Columns["Id"].Visible = false;
            this.dataGridView1.Columns["SalesOrderId"].Visible = false;
            this.dataGridView1.Columns["SaleOrderReturnCheckDocumentNumber"].Visible = false;
            this.dataGridView1.Columns["SaleOrderReturnChecker"].Visible = false;
            this.dataGridView1.Columns["SaleOrderReturnCheckTime"].Visible = false;

            this.dataGridView1.Columns["SaleOrderReturnINvDocumentNumber"].Visible = false;
            this.dataGridView1.Columns["SaleOrderReturnInver"].Visible = false;
            this.dataGridView1.Columns["SaleOrderReturnInvTime"].Visible = false;

            this.dataGridView1.Columns["SaleOrderReturnCancelDocumentNumber"].Visible = false;
            this.dataGridView1.Columns["SaleOrderReturnCanceler"].Visible = false;
            this.dataGridView1.Columns["SaleOrderReturnCancelTime"].Visible = false;
            this.dataGridView1.Columns["SaleOrderReturnCancelReason"].Visible = false;

            this.dataGridView1.Columns["PurchaseUnitPinYin"].Visible = false;
        }
      
        #region 查询方法
        private void GetListSalesOrderReturn()
        {
            try
            {
                string msg = string.Empty;
                SalesCodeSearchInput scsi = InitSalesOrderSearchInput();
                this._SalesOrderReturnModelList = this.PharmacyDatabaseService.GetReturnOrderCheckCodePaged(scsi, out msg).ToList();

                this._SalesOrderReturnModelList = this._SalesOrderReturnModelList.ToList();
                this.GroupByROrderNumber();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        } 
        #endregion

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
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            this.OpenReturnOrder();
        }

        #region 打开退单方法
        private void OpenReturnOrder()
        {
            Business.Models.SalesOrderReturnModel som = (Business.Models.SalesOrderReturnModel)this.dataGridView1.CurrentRow.DataBoundItem;
            var orderReturn = PharmacyDatabaseService.GetSalesOrderReturn(out msg, som.Id);
            FormSalesOrderReturn form = new FormSalesOrderReturn(orderReturn);
            form.ShowDialog();
        } 
        #endregion

        #region 开打相应销售单
        public void OpenSalesOrder()
        {
            var c=this.dataGridView1.CurrentRow.DataBoundItem as SalesOrderReturnModel;
            SalesOrder so = this.PharmacyDatabaseService.GetSalesOrder(out msg,c.SalesOrderId);
            using (FormSalesOrderEdit frm = new FormSalesOrderEdit(so, true))
            {
                frm.ShowDialog();
            }
        }
        #endregion

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "销售退货单查询结果");
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                toolStripButton1_Click(sender, e);
        }
    }
}
