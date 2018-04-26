using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common;
using System;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class FormSaleOrderApproval : BaseFunctionForm
    {
        public int OrderStatusValue { get; private set; }
        private SalesOrder _salesOrder = new SalesOrder();
        private OrderStatus _orderStatus;
        public FormSaleOrderApproval()
        {
            InitializeComponent();
        }

        public FormSaleOrderApproval(Guid orderId,OrderStatus orderStatus = OrderStatus.Approved)
        {
            InitializeComponent();
            _orderStatus = orderStatus;
            string msg = String.Empty;
            _salesOrder = PharmacyDatabaseService.GetSalesOrder(out msg, orderId);
            BindComboBox();
            this.txtPurchaseOrderNo.Text = _salesOrder.OrderCode;
            this.cmbApprovalStatus.SelectedValueChanged += cmbApprovalStatus_SelectedValueChanged;
            this.cmbApprovalStatus.SelectedIndex = 0;
        }

        void cmbApprovalStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            this.rtbDescription.Text = ((ListItem)(cmbApprovalStatus.SelectedItem)).Name + "，单据编号："+this._salesOrder.OrderCode;
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
                    _salesOrder.OrderStatusValue = status;
                    
                    OrderStatusValue = status;
                    if (status ==(int)OrderStatus.Approved)
                    {
                        _salesOrder.ApprovaledTime = DateTime.Now;
                        _salesOrder.ApprovalUserId = AppClientContext.CurrentUser.Id;

                        _salesOrder.OrderStatusValue = (int)BugsBox.Pharmacy.Models.OrderStatus.Banlaced;
                        _salesOrder.BalanceTime = DateTime.Now;
                        _salesOrder.BalanceUserID = AppClientContext.CurrentUser.Id;
                        _salesOrder.BalanceReason = "自动结算";
                        _salesOrder.payMentMethodID = Guid.Parse("52294fa7-d062-42de-83b6-67877040f673");
                        _salesOrder.OrderBalanceCode = userControlBillDocumentCode1.GenarateCode();

                        PharmacyDatabaseService.SaveSalesOrder(out msg, _salesOrder);
                        this.PharmacyDatabaseService.WriteLog(_salesOrder.ApprovalUserId, "销售单审核通过，单据号：" + _salesOrder.OrderCode);
                    }
                    else
                    {
                        _salesOrder.ApprovaledTime = DateTime.Now;
                        _salesOrder.ApprovalUserId = AppClientContext.CurrentUser.Id;
                        _salesOrder.CancelTime = DateTime.Now;
                        _salesOrder.CancelReason = rtbDescription.Text;
                        _salesOrder.CancelUserID = AppClientContext.CurrentUser.Id;
                        PharmacyDatabaseService.CancelSalesOrder(_salesOrder);
                        this.PharmacyDatabaseService.WriteLog(_salesOrder.ApprovalUserId, "销售单审核完毕，单据被取消，单据号：" + _salesOrder.OrderCode);
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            this.cmbApprovalStatus.Items.Add(new ListItem(_orderStatus.GetHashCode().ToString(), "审核通过"));
            this.cmbApprovalStatus.Items.Add(new ListItem(OrderStatus.Canceled.GetHashCode().ToString(), "取消"));
            this.cmbApprovalStatus.SelectedIndex = -1;
        }
    }
}
