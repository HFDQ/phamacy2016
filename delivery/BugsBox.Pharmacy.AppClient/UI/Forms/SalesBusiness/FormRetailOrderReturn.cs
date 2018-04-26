using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.AppClient.Common;


namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    using RetailPaymentMethod = BugsBox.Pharmacy.Models.RetailPaymentMethod;
    using RetailCustomerType = BugsBox.Pharmacy.Models.RetailCustomerType;


    public partial class FormRetailOrderReturn : BaseFunctionForm
    {
        private RetailOrder _retailsOrder;
        private List<RetailOrderDetail> _retailOrderDetailList;
        private List<DrugInventoryRecord> _drugInventoryRecordlList;
        public FormRetailOrderReturn()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 带零售信息的初始化
        /// </summary>
        /// <param name="orderInfo"></param>
        public FormRetailOrderReturn(RetailOrder retailOrder)
        {
            try
            {
                InitializeComponent();
                InitControl();
                this._retailsOrder = retailOrder;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        /// <summary>
        /// 初始化画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRetailOrderReturn_Load(object sender, EventArgs e)
        {
            try
            {
                //客户类型初始化
                this.cmbRetailCustomerType.DataSource = Utility.CreateComboboxList<RetailCustomerType>();
                this.cmbRetailCustomerType.DisplayMember = "Name";
                this.cmbRetailCustomerType.ValueMember = "ID";

                //付款方式初始化
                this.cmbRetailPaymentMethod.DataSource = Utility.CreateComboboxList<RetailPaymentMethod>();
                this.cmbRetailPaymentMethod.DisplayMember = "Name";
                this.cmbRetailPaymentMethod.ValueMember = "ID";


                InitControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }


        /// <summary>
        /// 获取零售对象的实例
        /// </summary>
        private void GetRetailsOrderInstance()
        {
            if (_retailsOrder == null)
            {
                _retailsOrder = new RetailOrder();
                _retailsOrder.Id = Guid.NewGuid();
                _retailsOrder.Code = lblOrderNo.Text;
          

                _retailsOrder.CreateUserId = AppClientContext.CurrentUser.Id;

            }
            _retailsOrder.ChangeMoney = Convert.ToDecimal(this.txtChangeMoney.Text.Trim());
            _retailsOrder.Description = this.txtRemark.Text.Trim();
            _retailsOrder.TotalMoney = Convert.ToDecimal(this.txtTotalMoney.Text.Trim());
            _retailsOrder.RetailPaymentMethodValue = (int)this.cmbRetailPaymentMethod.SelectedValue;
            _retailsOrder.GotMoney = Convert.ToDecimal(this.txtGotMoney.Text.Trim());
            _retailsOrder.ReduceMoney = Convert.ToDecimal(this.txtReduceMoney.Text.Trim());
            _retailsOrder.RealPayMoney = Convert.ToDecimal(this.txtRealPayMoney.Text.Trim());
            _retailsOrder.ReceivableMoney = Convert.ToDecimal(this.txtReceivableMoney.Text.Trim());
            _retailsOrder.RetailCustomerTypeValue = (int)this.cmbRetailCustomerType.SelectedValue;
        }


        private void InitControl()
        {
            if (_retailsOrder == null)
            {
                this.lblCreateDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                this.lblOrderNo.Text = "XX-" + DateTime.Now.Date.ToString("yyyyMMdd") + "XXXX";
            
            }
            else
            {
                this.lblOrderNo.Text = _retailsOrder.Code;
                this.lblCreateDate.Text = _retailsOrder.CreateTime.Date.ToString();

                this.cmbRetailCustomerType.SelectedValue = _retailsOrder.RetailCustomerTypeValue;
                this.cmbRetailPaymentMethod.SelectedValue = _retailsOrder.RetailPaymentMethodValue;
                this.txtReceivableMoney.Text = _retailsOrder.ReceivableMoney.ToString();
                this.txtReduceMoney.Text = _retailsOrder.ReduceMoney.ToString();  
                this.txtRealPayMoney.Text= _retailsOrder.RealPayMoney.ToString();
                this.txtGotMoney.Text = _retailsOrder.GotMoney.ToString();
                this.txtChangeMoney.Text = _retailsOrder.ChangeMoney.ToString();
                this.txtTotalMoney.Text = _retailsOrder.TotalMoney.ToString();
                this.txtRemark.Text = _retailsOrder.Description;

                this.dgvDrugDetailList.DataSource = _retailsOrder.RetailOrderDetails.ToList();
            }
        }

        /// <summary>
        /// 单元格退货数量触发退货金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDrugDetailList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > 0)
                {
                    string columnName = dgvDrugDetailList.Columns[e.ColumnIndex].Name;
                    var cellVallue = dgvDrugDetailList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (cellVallue != null)
                    {
                        decimal returnPrice = 0;
                        if (dgvDrugDetailList.Columns[e.ColumnIndex].Name == "退货数量")
                        {
                            _retailOrderDetailList[e.RowIndex].ReturnAmount = Convert.ToInt16(cellVallue);
                            returnPrice = Math.Round(_retailOrderDetailList[e.RowIndex].ReturnAmount * _retailOrderDetailList[e.RowIndex].ActualUnitPrice, 2);
                            this.txtTotalMoney.Text = _retailOrderDetailList.Select(p => p.ReturnAmount * p.ActualUnitPrice).Sum().ToString();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }


        /// <summary>
        /// 零售退货(直接更新库存表数量信息和零售明细信息)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = PharmacyDatabaseService.SaveRetailOrderAndDetails(_retailsOrder);
                if (msg.Length > 0)
                    MessageBox.Show(msg, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 Log.Error(ex);
            }

        }

        private void txtReduceMoneyReturn_TextChanged(object sender, EventArgs e)
        {

            try
            {
                this.txtTheoryRefund.Text = (Convert.ToDecimal(this.txtRefund.Text) - Convert.ToDecimal(this.txtReduceMoneyReturn.Text)).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }
    }
}
