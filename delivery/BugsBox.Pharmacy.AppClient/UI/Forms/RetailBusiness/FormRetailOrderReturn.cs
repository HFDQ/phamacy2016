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


namespace BugsBox.Pharmacy.AppClient.UI.Forms.RetailBusiness
{
    using RetailPaymentMethod = BugsBox.Pharmacy.Models.RetailPaymentMethod;
    using RetailCustomerType = BugsBox.Pharmacy.Models.RetailCustomerType;


    public partial class FormRetailOrderReturn : BaseFunctionForm
    {
        private RetailOrder _retailsOrder;
        private List<RetailOrderDetail> _retailOrderDetailList;
        public FormRetailOrderReturn()
        {
            InitializeComponent();
            this.dgvDrugDetailList.AutoGenerateColumns = false;
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
                this.dgvDrugDetailList.AutoGenerateColumns = false;
                this._retailsOrder = retailOrder;
                this.tsbtnReturn.Enabled = true;


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("窗体加载失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }


        /// <summary>
        /// 获取零售对象的实例
        /// </summary>
        private void GetRetailsOrderInstance()
        {
            _retailsOrder.Description = this.txtRemark.Text.Trim();
            _retailsOrder.TotalRefund = Convert.ToDecimal(this.txtRefund.Text.Trim());
            _retailsOrder.ReturnReduceMoney = Convert.ToDecimal(this.txtReduceMoneyReturn.Text.Trim());
            _retailsOrder.ReturnReceivableMoney = Convert.ToDecimal(this.txtReceivableMoney.Text.Trim());
            _retailsOrder.ReturnRealReceiveMoney = Convert.ToDecimal(this.txtActualRefund.Text.Trim());
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

                this.cmbRetailCustomerType.Text = Utility.getEnumTypeDisplayName<RetailCustomerType>((RetailCustomerType)_retailsOrder.RetailCustomerTypeValue);
                this.cmbRetailPaymentMethod.Text = Utility.getEnumTypeDisplayName<RetailPaymentMethod>((RetailPaymentMethod)_retailsOrder.RetailPaymentMethodValue);
                this.txtReceivableMoney.Text = _retailsOrder.ReceivableMoney.ToString();
                this.txtReduceMoney.Text = _retailsOrder.ReduceMoney.ToString();
                this.txtRealPayMoney.Text = _retailsOrder.RealPayMoney.ToString();
                this.txtGotMoney.Text = _retailsOrder.GotMoney.ToString();
                this.txtChangeMoney.Text = _retailsOrder.ChangeMoney.ToString();
                this.txtTotalMoney.Text = _retailsOrder.TotalMoney.ToString();
                this.txtRemark.Text = _retailsOrder.Description;
                _retailOrderDetailList = _retailsOrder.RetailOrderDetails.ToList();
                this.dgvDrugDetailList.DataSource = _retailOrderDetailList;
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
                        if (dgvDrugDetailList.Columns[e.ColumnIndex].Name == "退货数量")
                        {
                            int orderQty = 0;
                            if (Convert.ToBoolean(dgvDrugDetailList.Rows[e.RowIndex].Cells["是否拆零"].Value))

                                orderQty = int.Parse(dgvDrugDetailList.Rows[e.RowIndex].Cells["拆零数量"].Value.ToString());
                            else
                                orderQty = int.Parse(dgvDrugDetailList.Rows[e.RowIndex].Cells["数量"].Value.ToString());

                            if (int.Parse(cellVallue.ToString()) > orderQty)
                            {
                                MessageBox.Show("退货数量不能大于订单数量!");
                                return;
                            }
                            else
                            {
                                decimal dismantingPrice = 0;
                                decimal price = 0;
                                _retailOrderDetailList[e.RowIndex].ReturnAmount = Convert.ToInt16(cellVallue);
                                price = _retailOrderDetailList.Where(w => w.IsDismanting == false).Select(p => p.ReturnAmount * p.ActualUnitPrice).Sum();
                                dismantingPrice = _retailOrderDetailList.Where(w => w.IsDismanting == true).Select(p => p.ReturnAmount * p.ActualDismantingUnitPrice).Sum();
                                this.txtRefund.Text = Math.Round(price + dismantingPrice, 2).ToString();
                                this.txtTheoryRefund.Text = txtRefund.Text;
                                this.txtActualRefund.Text = txtRefund.Text;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                GetRetailsOrderInstance();
                _retailsOrder.RetailOrderDetails = _retailOrderDetailList.ToArray();
                string msg = PharmacyDatabaseService.SaveRetailOrderAndDetails(_retailsOrder);
                if (msg.Length > 0)
                    MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    this.tsbtnReturn.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("零售退货操作失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }

        }

        private void txtReduceMoneyReturn_TextChanged(object sender, EventArgs e)
        {

            try
            {
                this.txtTheoryRefund.Text = (Convert.ToDecimal(this.txtRefund.Text) - Convert.ToDecimal(this.txtReduceMoneyReturn.Text)).ToString();
                txtActualRefund.Text = txtTheoryRefund.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void dgvDrugDetailList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTotalMoney_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
