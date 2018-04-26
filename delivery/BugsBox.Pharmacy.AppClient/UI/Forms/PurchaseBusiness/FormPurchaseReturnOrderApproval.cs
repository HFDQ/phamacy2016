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

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class FormPurchaseReturnOrderApproval : BaseFunctionForm
    {
        public int OrderStatusValue { get; private set; }
        public string Description { get; private set; }
        private PurchaseOrderReturn _orderReturn;
        private OrderReturnStatus _role;
        public FormPurchaseReturnOrderApproval()
        {
            InitializeComponent();
        }

        public FormPurchaseReturnOrderApproval(Guid orderId, OrderReturnStatus role)
        {
            InitializeComponent();
            string msg=String.Empty;
            _role = role;
            BindComboBox(role);
            _orderReturn = this.PharmacyDatabaseService.GetPurchaseOrderReturn(out msg, orderId);
            this.txtPurchaseOrderNo.Text = _orderReturn.DocumentNumber;
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
                    if (status == (int)OrderReturnStatus.Rejected
                      || status == (int)OrderReturnStatus.Canceled)
                    {
                        if (rtbDescription.Text.Length < 1)
                        {
                            MessageBox.Show("请输入备注信息！");
                            return;
                        }
                    }
                    string msg = string.Empty;
                    switch (_role)
                    {
                        case OrderReturnStatus.QualityApproved:
                            _orderReturn.QualityUpdateTime = DateTime.Now;
                            _orderReturn.QualitySuggest = rtbDescription.Text;
                            Description = rtbDescription.Text;
                            _orderReturn.QualityUserId = AppClientContext.CurrentUser.Id;
                            break;
                        case OrderReturnStatus.GeneralManagerApproved:
                            _orderReturn.GeneralManagerUpdateTime = DateTime.Now;
                            _orderReturn.GeneralManagerSuggest = rtbDescription.Text;
                            Description = rtbDescription.Text;
                            _orderReturn.GeneralManagerUserId = AppClientContext.CurrentUser.Id;
                            break;
                        case OrderReturnStatus.FinanceDepartmentApproved:
                            _orderReturn.FinanceDepartmentUpdateTime = DateTime.Now;
                            _orderReturn.FinanceDepartmentSuggest = rtbDescription.Text;
                            Description = rtbDescription.Text;
                            _orderReturn.FinanceDepartmentUserId = AppClientContext.CurrentUser.Id;
                            break;
                    }
                    _orderReturn.OrderStatusValue = status;
                    OrderStatusValue = status;
                    PharmacyDatabaseService.SavePurchaseOrderReturn(out msg, _orderReturn);
                    
                    if (!string.IsNullOrEmpty(msg))
                    {
                        this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行配送入库退货单审核操作失败,单号：" + this._orderReturn.DocumentNumber);
                        MessageBox.Show(msg, "错误", MessageBoxButtons.OK);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行配送入库退货单审核操作成功,单号：" + this._orderReturn.DocumentNumber);
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

        private void BindComboBox(OrderReturnStatus role)
        {
            this.cmbApprovalStatus.Items.Clear();
            this.cmbApprovalStatus.Items.Add(new ListItem(OrderReturnStatus.Rejected.GetHashCode().ToString(), "拒绝"));
            switch (role)
            {
                case OrderReturnStatus.QualityApproved:
                    this.cmbApprovalStatus.Items.Add(new ListItem(OrderReturnStatus.QualityApproved.GetHashCode().ToString(), "审核通过"));
                    break;
                case OrderReturnStatus.GeneralManagerApproved:
                    this.cmbApprovalStatus.Items.Add(new ListItem(OrderReturnStatus.GeneralManagerApproved.GetHashCode().ToString(), "审核通过"));
                    break;
                case OrderReturnStatus.FinanceDepartmentApproved:
                    this.cmbApprovalStatus.Items.Add(new ListItem(OrderReturnStatus.FinanceDepartmentApproved.GetHashCode().ToString(), "审核通过"));
                    break;
            }
            this.cmbApprovalStatus.Items.Add(new ListItem(OrderReturnStatus.Canceled.GetHashCode().ToString(), "取消"));
            this.cmbApprovalStatus.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
