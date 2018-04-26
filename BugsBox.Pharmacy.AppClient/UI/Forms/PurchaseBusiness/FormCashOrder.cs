using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class FormCashOrder : BaseFunctionForm
    {
        private PurchaseCommonEntity _order = new PurchaseCommonEntity();
        string msg=string.Empty;
        public FormCashOrder()
        {
            InitializeComponent();
            InitData();
        }
        //查询/创建 结算单
        public FormCashOrder(PurchaseCommonEntity order, DealerMethod dealerMethod = DealerMethod.PurchaseInInventory, decimal paymentingAmount = 0, bool isCreate = false, OrderType orderType = OrderType.PurchaseOrder)
            : this()
        {
            if (isCreate)
            {
                _order.TotalAmount = this.PharmacyDatabaseService.GetPurchaseOrder(out msg, order.PurchaseOrderId).TotalMoney;
                _order.DealerMethodValue = (int)dealerMethod;
                _order.PaymentingAmount = paymentingAmount;
                _order.PaymentAmount = 0;
                _order.Description = "";
                _order.PurchaseOrderId = order.PurchaseOrderId;
                _order.PurchaseOrderDocumentNumber = order.PurchaseOrderDocumentNumber;
                _order.OperateUserId = AppClientContext.CurrentUser.Id;
                _order.RelatedOrderDocumentNumber = order.DocumentNumber;
                _order.RelatedOrderId = order.Id;
                _order.RelatedOrderTypeValue = (int)orderType;
                //DataGridViewRow dr = new DataGridViewRow();
                //dr.Cells["PurchaseOrderDocumentNumber"].Value = model.BargainNO; 

            }
            else
            {
                _order = order;
            }
            Initial(isCreate);
            label5.Text = order.SupplyUnitName;
        }

        public void Initial(bool isCreate)
        {
            string msg = String.Empty;
            if (isCreate)
            {
                lblOrderNo.Text = "新建";
                lblCreateDate.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分");

                string employeeName = AppClientContext.CurrentUser.Employee.Name;
                dateTimePickerPayment.Enabled = true;
                //txt复核员名.Text = employeeName;
            }
            else
            {
                lblCreateDate.Text = _order.OperateTime.ToString("yyyy年MM月dd日 HH时mm分");
                //txt复核员名.Text = _order.EmployeeName;
                lblOrderNo.Text = _order.DocumentNumber;
                //lblOrderStatus.Text = EnumHelper<OrderStatus>.GetDisplayValue((OrderStatus)_order.OrderStatus);
                tsbtnCash.Visible = false;
                this.dataGridView1.ReadOnly = true;
                dateTimePickerPayment.Value = _order.PaymentTime;
            }

            this.dataGridView1.AutoGenerateColumns = false;
            //this.dataGridView1.DataSource = _order;
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[PurchaseOrderDocumentNumber.Name].Value = _order.PurchaseOrderDocumentNumber;
            this.dataGridView1.Rows[index].Cells[DealerMethodValue.Name].Value = _order.DealerMethodValue;
            this.dataGridView1.Rows[index].Cells[TotalAmount.Name].Value = _order.TotalAmount;
            this.dataGridView1.Rows[index].Cells[PaymentAmount.Name].Value = _order.PaymentAmount;
            this.dataGridView1.Rows[index].Cells[PaymentedAmount.Name].Value = _order.PaymentedAmount;
            this.dataGridView1.Rows[index].Cells[PaymentingAmount.Name].Value = _order.PaymentingAmount;
        }

        private void tsbtnAccept_Click_1(object sender, EventArgs e)
        {
            try
            {
                string msg = String.Empty;
                _order.OrderStatus = OrderStatus.BillAccount.GetHashCode();
                _order.Description = textBoxDescription.Text;
                _order.PaymentAmount = Decimal.Parse(this.dataGridView1.Rows[0].Cells["PaymentAmount"].Value.ToString());
                _order.PaymentTime = dateTimePickerPayment.Value;
                tsbtnCash.Enabled = false;
                PurchaseCashOrder purchaseOrder = new PurchaseCashOrder();
                purchaseOrder.OperateUserId = _order.OperateUserId;
                purchaseOrder.OrderStatusValue = _order.OrderStatus;
                purchaseOrder.PurchaseOrderId = _order.PurchaseOrderId;
                purchaseOrder.Decription = _order.Description;
                purchaseOrder.PaymentTime = _order.PaymentTime;
                purchaseOrder.DealerMethodValue = _order.DealerMethodValue;
                purchaseOrder.PaymentAmount = _order.PaymentAmount;
                purchaseOrder.PaymentedAmount = _order.PaymentedAmount;
                purchaseOrder.PaymentingAmount = _order.PaymentingAmount;
                purchaseOrder.PaymentMethodId = new Guid(comboBox1.SelectedValue.ToString());
                purchaseOrder.RelatedOrderDocumentNumber = _order.RelatedOrderDocumentNumber;
                purchaseOrder.RelatedOrderId = _order.RelatedOrderId;
                purchaseOrder.RelatedOrderTypeValue = _order.RelatedOrderTypeValue;
                string orderNumber = this.PharmacyDatabaseService.CreatePurchaseCashOrder(out msg, purchaseOrder);
                if (String.IsNullOrEmpty(msg))
                {
                    //lblOrderStatus.Text = EnumHelper<OrderStatus>.GetDisplayValue((OrderStatus)_order.OrderStatus);
                    lblOrderNo.Text = orderNumber;

                    MessageBox.Show("结算完成");
                    this.Close();
                }
                else
                {
                    tsbtnCash.Enabled = true;
                    MessageBox.Show("结算失败,请联系管理员");
                }
            }
            catch
            {
                MessageBox.Show("结算失败,请联系管理员");
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void InitData()
        {
            string msg = string.Empty;
            PaymentMethod[] list = PharmacyDatabaseService.AllPaymentMethods(out msg);
            this.comboBox1.DataSource = list;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.SelectedIndex = 0;

            List<ComboxItem> returnItems = new List<ComboxItem>();
            returnItems.Add(new ComboxItem(EnumHelper<DealerMethod>.GetDisplayValue(DealerMethod.PurchaseInInventory), (int)DealerMethod.PurchaseInInventory));
            returnItems.Add(new ComboxItem(EnumHelper<DealerMethod>.GetDisplayValue(DealerMethod.PurchaseReturn), (int)DealerMethod.PurchaseReturn));

            DealerMethodValue.DataSource = returnItems;
            DealerMethodValue.DisplayMember = "Name";
            DealerMethodValue.ValueMember = "Value";
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = String.Empty;
                _order.OrderStatus = OrderStatus.BillAccount.GetHashCode();
                _order.Description = textBoxDescription.Text;
                _order.PaymentAmount = Decimal.Parse(this.dataGridView1.Rows[0].Cells["PaymentAmount"].Value.ToString());
                _order.PaymentTime = dateTimePickerPayment.Value;
                tsbtnCash.Enabled = false;
                PurchaseCashOrder purchaseOrder = new PurchaseCashOrder();
                purchaseOrder.OperateUserId = _order.OperateUserId;
                purchaseOrder.OrderStatusValue = _order.OrderStatus;
                purchaseOrder.PurchaseOrderId = _order.PurchaseOrderId;
                purchaseOrder.Decription = _order.Description;
                purchaseOrder.PaymentTime = _order.PaymentTime;
                purchaseOrder.DealerMethodValue = _order.DealerMethodValue;
                purchaseOrder.PaymentAmount = _order.PaymentAmount;
                purchaseOrder.PaymentedAmount = _order.PaymentedAmount;
                purchaseOrder.PaymentingAmount = _order.PaymentingAmount;
                purchaseOrder.PaymentMethodId = new Guid(comboBox1.SelectedValue.ToString());
                purchaseOrder.RelatedOrderDocumentNumber = _order.RelatedOrderDocumentNumber;
                purchaseOrder.RelatedOrderId = _order.RelatedOrderId;
                purchaseOrder.RelatedOrderTypeValue = _order.RelatedOrderTypeValue;
                string orderNumber = this.PharmacyDatabaseService.CreatePurchaseCashOrder(out msg, purchaseOrder);
                if (String.IsNullOrEmpty(msg))
                {
                    //lblOrderStatus.Text = EnumHelper<OrderStatus>.GetDisplayValue((OrderStatus)_order.OrderStatus);
                    lblOrderNo.Text = orderNumber;

                    MessageBox.Show("结算完成");
                }
                else
                {
                    tsbtnCash.Enabled = true;
                    MessageBox.Show("结算失败,请联系管理员");
                }
            }
            catch
            {
                MessageBox.Show("结算失败,请联系管理员");
            }
        }
    }
}
