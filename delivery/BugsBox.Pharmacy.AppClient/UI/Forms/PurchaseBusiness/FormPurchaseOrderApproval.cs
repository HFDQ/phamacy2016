using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.UI.Common.Helper;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class FormPurchaseOrderApproval : BaseFunctionForm
    {
        public int OrderStatusValue { get; private set; }
        private PurchaseOrder _purchaseOrder = new PurchaseOrder();
        private OrderStatus _orderStatus;
        public FormPurchaseOrderApproval()
        {
            InitializeComponent();
        }

        public FormPurchaseOrderApproval(Guid orderId,OrderStatus orderStatus = OrderStatus.Approved)
        {
            InitializeComponent();
            _orderStatus = orderStatus;
            string msg = String.Empty;
            _purchaseOrder = PharmacyDatabaseService.GetPurchaseOrder(out msg, orderId);
            BindComboBox();
            this.txtPurchaseOrderNo.Text = _purchaseOrder.DocumentNumber;
            this.cmbApprovalStatus.SelectedValueChanged += cmbApprovalStatus_SelectedValueChanged;
            this.cmbApprovalStatus.SelectedIndex = 1;
        }

        void cmbApprovalStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            this.rtbDescription.Text = ((ListItem)(cmbApprovalStatus.SelectedItem)).Name+ "：配送入库单据编号:" + this._purchaseOrder.DocumentNumber;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbApprovalStatus.SelectedIndex < 0)
                    return;
                else
                {
                    int status = Int32.Parse(((ListItem)(cmbApprovalStatus.SelectedItem)).ID.ToString());
                    if (status == (int)OrderStatus.Rejected
                      || status == (int)OrderStatus.Canceled)
                    {
                        if (rtbDescription.Text.Length < 1)
                        {
                            MessageBox.Show("请输入备注信息！");
                            return;
                        }
                    }
                    string msg = string.Empty;
                    _purchaseOrder.OrderStatusValue = status;
                    
                    OrderStatusValue = status;
                    if (_orderStatus == OrderStatus.Approved)
                    {
                        _purchaseOrder.ApprovaledTime = DateTime.Now;
                        _purchaseOrder.ApprovalUserId = AppClientContext.CurrentUser.Id;
                        _purchaseOrder.ApprovalDecription = rtbDescription.Text;
                        PharmacyDatabaseService.SavePurchaseOrder(out msg, _purchaseOrder);
                        this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行配送入库单审核操作成功，单号：" + _purchaseOrder.DocumentNumber);
                    }
                    else
                    {
                        _purchaseOrder.AmountApprovaledTime = DateTime.Now;
                        _purchaseOrder.AmountApprovalUserId = AppClientContext.CurrentUser.Id;
                        _purchaseOrder.AmountApprovalDecription = rtbDescription.Text;
                        PharmacyDatabaseService.HandlePurchaseReceinvingAmountDiff(_purchaseOrder);
                        this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行配送入库单数量修改审核操作成功，单号：" + _purchaseOrder.DocumentNumber);
                    }
                    if (!string.IsNullOrEmpty(msg))
                    {
                        MessageBox.Show(msg, "错误", MessageBoxButtons.OK);
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void BindComboBox()
        {
            this.cmbApprovalStatus.Items.Clear();
            this.cmbApprovalStatus.Items.Add(new ListItem(OrderStatus.Rejected.GetHashCode().ToString(), "拒绝"));
            this.cmbApprovalStatus.Items.Add(new ListItem(_orderStatus.GetHashCode().ToString(), "审核通过"));
            this.cmbApprovalStatus.Items.Add(new ListItem(OrderStatus.Canceled.GetHashCode().ToString(), "取消"));
            
        }
    }
}
