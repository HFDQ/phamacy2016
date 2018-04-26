using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class FormPurchaseOrder : BaseFunctionForm
    {
        string msg = String.Empty;
        private Dictionary<string, List<ListItem>> _InitFieldValues = new Dictionary<string, List<ListItem>>();
        private Guid _purchaseOrderId;
        private bool _isReceving = false;
        private bool _isChecking = false;
        private bool _isInInventory = false;
        private bool _isReturn = false;
        private bool _isCash = false;
        public FormPurchaseOrder()
        {
            InitializeComponent();
        }
        public FormPurchaseOrder(PurchaseOrdeEntity purchaseOrder)
            : this()
        {
            InitData(purchaseOrder);
        }
        public void InitData(PurchaseOrdeEntity purchaseOrder)
        {
            _InitFieldValues.Add("OrderStatus", EnumHelper<OrderStatus>.GetMapKeyValues());
            _InitFieldValues.Add("RelatedOrderTypeValue", EnumHelper<OrderType>.GetMapKeyValues());
           
            //采购单
            txtDocumentNumber.Text = purchaseOrder.DocumentNumber;
            txtStatus.Text = EnumHelper<OrderStatus>.GetDisplayValue((OrderStatus)purchaseOrder.OrderStatusValue);
            txtSuplyUnit.Text = purchaseOrder.SupplyUnitName;
            txtAllReceiptedDate.Text = purchaseOrder.AllReceiptedDate == null ? "" : purchaseOrder.AllReceiptedDate.ToString();
            txtPurchaseAddress.Text = purchaseOrder.Address;
            txtPurchaseUnit.Text = purchaseOrder.ReceiveUnit;
            txtReceivingDate.Text = "";
            txtSuplyUnit.Text = purchaseOrder.SupplyUnitName;
            txtSuplyUnitContact.Text = purchaseOrder.ContactName;
            txtSuplyUnitPhone.Text = purchaseOrder.ContactTel;
            txtCreateTime.Text = purchaseOrder.CreateTime.ToShortDateString();
            txtPurchaseEmployee.Text = purchaseOrder.EmployeeName;
            txtTotalMount.Text = purchaseOrder.TotalMoney.ToString();
            txtPurchaseDescription.Text = purchaseOrder.Description;
            //Employee e=this.PharmacyDatabaseService.GetEmployee(out msg,purchaseOrder.ApprovalUserId);
            //if (e != null) txtApproveEmployee.Text = e.Name;
            txtApprovedDescription.Text = purchaseOrder.ApprovalDecription;
            txtApprovedTime.Text = purchaseOrder.ApprovaledTime==null?"":purchaseOrder.ApprovaledTime.ToString();
            if (purchaseOrder.OrderStatusValue != (int)OrderStatus.Canceled && purchaseOrder.OrderStatusValue != (int)OrderStatus.Rejected && purchaseOrder.OrderStatusValue != (int)OrderStatus.Waitting)
            {
                txtApprovedStatus.Text = EnumHelper<OrderStatus>.GetDisplayValue(OrderStatus.Approved);
            }
            else
            {
                txtApprovedStatus.Text = EnumHelper<OrderStatus>.GetDisplayValue((OrderStatus)purchaseOrder.OrderStatusValue);
            }
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = PharmacyDatabaseService.GetPurchaseOrderDetails(out msg, purchaseOrder.Id).ToList();
            this.dataGridView1.ReadOnly = true;
             _purchaseOrderId = purchaseOrder.Id;
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = this.dataGridView2.Columns[e.ColumnIndex].DataPropertyName;
            if (_InitFieldValues.ContainsKey(columnName))
            {
                if (_InitFieldValues[columnName].Where(l => l.ID == e.Value.ToString()).FirstOrDefault() != null)
                {
                    e.Value = _InitFieldValues[columnName].Where(l => l.ID == e.Value.ToString()).FirstOrDefault().Name;
                }
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
             new FormReceivingOrder((PurchaseCommonEntity)this.dataGridView2.Rows[e.RowIndex].DataBoundItem).ShowDialog();
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new FormCheckOrder((PurchaseCommonEntity)this.dataGridView3.Rows[e.RowIndex].DataBoundItem).ShowDialog();
        }

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = this.dataGridView3.Columns[e.ColumnIndex].DataPropertyName;
            if (_InitFieldValues.ContainsKey(columnName))
            {
                if (_InitFieldValues[columnName].Where(l => l.ID == e.Value.ToString()).FirstOrDefault() != null)
                {
                    e.Value = _InitFieldValues[columnName].Where(l => l.ID == e.Value.ToString()).FirstOrDefault().Name;
                }
            }
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new FormInInventory((PurchaseCommonEntity)this.dataGridView4.Rows[e.RowIndex].DataBoundItem).ShowDialog();
        }

        private void dataGridView4_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = this.dataGridView4.Columns[e.ColumnIndex].DataPropertyName;
            if (_InitFieldValues.ContainsKey(columnName))
            {
                if (_InitFieldValues[columnName].Where(l => l.ID == e.Value.ToString()).FirstOrDefault() != null)
                {
                    e.Value = _InitFieldValues[columnName].Where(l => l.ID == e.Value.ToString()).FirstOrDefault().Name;
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = this.dataGridView1.Columns[e.ColumnIndex].DataPropertyName;
            if (_InitFieldValues.ContainsKey(columnName))
            {
                if (_InitFieldValues[columnName].Where(l => l.ID == e.Value.ToString()).FirstOrDefault() != null)
                {
                    e.Value = _InitFieldValues[columnName].Where(l => l.ID == e.Value.ToString()).FirstOrDefault().Name;
                }
            }
            DataGridViewCell numberCell = this.dataGridView1.Rows[e.RowIndex].Cells["clmDrugNumber"];
            DataGridViewCell purchasePriceCell = this.dataGridView1.Rows[e.RowIndex].Cells["clmPurchasePrice"];
            if (numberCell.Value != null && purchasePriceCell.Value != null)
            {
                this.dataGridView1.Rows[e.RowIndex].Cells["TotalMoney"].Value = (Int32.Parse(numberCell.Value.ToString())) * (Decimal.Parse(purchasePriceCell.Value.ToString()));
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("clmDrugNumber") || dataGridView1.Columns[e.ColumnIndex].Name.Equals("clmPurchasePrice"))
            {

                DataGridViewCell numberCell = this.dataGridView1.Rows[e.RowIndex].Cells["clmDrugNumber"];
                DataGridViewCell purchasePriceCell = this.dataGridView1.Rows[e.RowIndex].Cells["clmPurchasePrice"];
                if (numberCell.Value != null && purchasePriceCell.Value != null)
                {
                    this.dataGridView1.Rows[e.RowIndex].Cells["TotalMoney"].Value = (Int32.Parse(numberCell.Value.ToString())) * (Decimal.Parse(purchasePriceCell.Value.ToString()));
                }
            }
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new FormReturnOrder((PurchaseCommonEntity)this.dataGridView5.Rows[e.RowIndex].DataBoundItem).ShowDialog();
        }

        private void dataGridView5_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = this.dataGridView5.Columns[e.ColumnIndex].DataPropertyName;
            if (_InitFieldValues.ContainsKey(columnName))
            {
                if (_InitFieldValues[columnName].Where(l => l.ID == e.Value.ToString()).FirstOrDefault() != null)
                {
                    e.Value = _InitFieldValues[columnName].Where(l => l.ID == e.Value.ToString()).FirstOrDefault().Name;
                }
            }
        }

        //private void dataGridView6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    new FormCashOrder((PurchaseCommonEntity)this.dataGridView6.Rows[e.RowIndex].DataBoundItem).ShowDialog();
        //}

        //private void dataGridView6_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    string columnName = this.dataGridView6.Columns[e.ColumnIndex].DataPropertyName;
        //    if (_InitFieldValues.ContainsKey(columnName))
        //    {
        //        if (_InitFieldValues[columnName].Where(l => l.ID == e.Value.ToString()).FirstOrDefault() != null)
        //        {
        //            e.Value = _InitFieldValues[columnName].Where(l => l.ID == e.Value.ToString()).FirstOrDefault().Name;
        //        }
        //    }
        //}

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            List<PurchaseCommonEntity> order = new List<PurchaseCommonEntity>();
            List<string> man = new List<string>();
            if (e.TabPage == tabPage1)
            {
            }
            else if (e.TabPage == tabPage2)
            {
                if (!_isReceving)
                {
                    //收货单
                    this.dataGridView2.AutoGenerateColumns = false;
                    this.dataGridView2.DataSource = this.PharmacyDatabaseService.GetPurchaseReceivingOrdersByPurchaseOrderId(out msg, _purchaseOrderId).ToList();
                    this.dataGridView2.ReadOnly = true;
                    _isReceving = true;
                }
            }
            else if (e.TabPage == tabPage3)
            {
                if (!_isChecking)
                {
                    //验货单
                    order = this.PharmacyDatabaseService.GetPurchaseCheckingOrdersByPurchaseOrderId(out msg, _purchaseOrderId).ToList();
                    this.dataGridView3.AutoGenerateColumns = false;
                    this.dataGridView3.DataSource = order;
                    this.dataGridView3.ReadOnly = true;
                    man.Clear();
                    foreach (PurchaseCommonEntity p in order)
                    {
                        if (!man.Contains(p.EmployeeName))
                        {
                            txtCheckEmployee.Text = txtCheckEmployee.Text + p.EmployeeName + " ";
                        }
                    }
                    _isChecking = true;
                }
            }
            else if (e.TabPage == tabPage4)
            {
                if (!_isInInventory)
                {
                    //入库单
                    order = this.PharmacyDatabaseService.GetPurchaseInInventeryOrdersByPurchaseOrderId(out msg, _purchaseOrderId).ToList();
                    this.dataGridView4.AutoGenerateColumns = false;
                    this.dataGridView4.DataSource = order;
                    this.dataGridView4.ReadOnly = true;
                    man.Clear();
                    foreach (PurchaseCommonEntity p in order)
                    {
                        if (!man.Contains(p.EmployeeName))
                        {
                            txtStoremanEmployee.Text = txtStoremanEmployee.Text + p.EmployeeName + " ";
                        }
                    }
                    _isInInventory = true;
                }
            }
            else if (e.TabPage == tabPage5)
            {
                if (!_isReturn)
                {
                    //退货单
                    order = this.PharmacyDatabaseService.GetPurchaseOrderReturnsByPurchaseOrderId(out msg, _purchaseOrderId).ToList();
                    this.dataGridView5.AutoGenerateColumns = false;
                    this.dataGridView5.DataSource = order;
                    this.dataGridView5.ReadOnly = true;
                    //man.Clear();
                    //foreach (PurchaseCommonEntity p in order)
                    //{
                    //    if (!man.Contains(p.EmployeeName))
                    //    {
                    //        txtStoremanEmployee.Text = txtStoremanEmployee.Text + p.EmployeeName + " ";
                    //    }
                    //}
                    _isReturn = true;
                }
            }
            //else if (e.TabPage == tabPage6)
            //{
            //    if (!_isCash)
            //    {
            //        //结算单
            //        order = this.PharmacyDatabaseService.GetPurchaseCashOrdersByPurchaseOrderId(out msg, _purchaseOrderId).ToList();
            //        this.dataGridView6.AutoGenerateColumns = false;
            //        this.dataGridView6.DataSource = order;
            //        this.dataGridView6.ReadOnly = true;
            //        _isCash = true;
            //    }
            //}
        }
    }
}
