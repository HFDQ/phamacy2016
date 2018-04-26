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


    public partial class FormRetailOrderEdit : BaseFunctionForm
    {
        private RetailOrder _retailsOrder;
        private List<RetailOrderDetail> _retailOrderDetailList;
        private List<DrugInventoryRecord> _drugInventoryRecordlList;
        public FormRetailOrderEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 带零售信息的初始化
        /// </summary>
        /// <param name="orderInfo"></param>
        public FormRetailOrderEdit(RetailOrder retailOrder)
        {
            InitializeComponent();
            this._retailsOrder = retailOrder;
        }

        /// <summary>
        /// 初始化画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRetailOrderEdit_Load(object sender, EventArgs e)
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

        private void tsbtnBalance_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要提交吗？", "系统提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    GetRetailsOrderInstance();
                    _retailsOrder.RetailOrderDetails = _retailOrderDetailList.ToArray();
                    string msg = string.Empty;
                    msg = PharmacyDatabaseService.AddRetailOrderAndDetails(_retailsOrder);
                    if (msg.Length > 0)
                        MessageBox.Show(msg, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }



        /// <summary>
        ///  添加订单的明细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailAdd_Click(object sender, EventArgs e)
        {
            try
            {
                 FormDrugForSalesSelector selForm = new FormDrugForSalesSelector(Guid.Empty);
                    if (selForm.ShowDialog() == DialogResult.OK)
                    {
                        _drugInventoryRecordlList = selForm.result;
                        if (_retailOrderDetailList == null)
                            _retailOrderDetailList = new List<RetailOrderDetail>();
                        int index = _retailOrderDetailList.Count;
                        foreach (DrugInventoryRecord drugInventoryRecord in _drugInventoryRecordlList)
                        {
                            RetailOrderDetail rod = new RetailOrderDetail();

                            rod.Id = Guid.NewGuid();
                            rod.MeasurementUnit = drugInventoryRecord.DrugInfo.DictionaryMeasurementUnitCode;
                            rod.UnitPrice = drugInventoryRecord.DrugInfo.Price;
                            rod.productName = drugInventoryRecord.DrugInfo.ProductName;
                            rod.productCode = drugInventoryRecord.DrugInfo.Code;
                            rod.BatchNumber = drugInventoryRecord.BatchNumber;
                            rod.Description = drugInventoryRecord.Decription;
                            rod.DrugInventoryRecordID = drugInventoryRecord.Id;
                            rod.FactoryName = drugInventoryRecord.DrugInfo.FactoryName;
                            rod.SpecificationCode = drugInventoryRecord.DrugInfo.SpecialDrugCategoryCode;
                            rod.PruductDate = drugInventoryRecord.PruductDate;
                            rod.OutValidDate = drugInventoryRecord.OutValidDate;
                            rod.Amount = 0;
                            rod.Index = index;
                            rod.TotalMoney = Math.Round(rod.UnitPrice * rod.Amount*rod.Discount/100,2);
                            rod.Discount = 100;
                            _retailOrderDetailList.Add(rod);
                            index++;
                        }

                        this.dgvDrugDetailList.DataSource = _retailOrderDetailList;
                    }

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
            this.dgvDrugDetailList.AutoGenerateColumns = false;
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
        /// 单元格编辑完成触发 数量，金额变更
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
                        decimal price = 0;
                        if (dgvDrugDetailList.Columns[e.ColumnIndex].Name == "")
                            switch (columnName)
                            {
                                case "折扣":
                                    _retailOrderDetailList[e.RowIndex].Discount = Convert.ToInt16(cellVallue);
                                    price = Math.Round(_retailOrderDetailList[e.RowIndex].Amount * _retailOrderDetailList[e.RowIndex].ActualUnitPrice * _retailOrderDetailList[e.RowIndex].Discount/100,2);
                                    dgvDrugDetailList.Rows[e.RowIndex].Cells["金额"].Value = price;
                                    this.txtTotalMoney.Text = _retailOrderDetailList.Select(p => p.TotalMoney).Sum().ToString();
                                    break;
                                case "实际单价":
                                    _retailOrderDetailList[e.RowIndex].ActualUnitPrice = Convert.ToInt16(cellVallue);
                                    price = Math.Round(_retailOrderDetailList[e.RowIndex].Amount * _retailOrderDetailList[e.RowIndex].ActualUnitPrice * _retailOrderDetailList[e.RowIndex].Discount / 100, 2);
                                    dgvDrugDetailList.Rows[e.RowIndex].Cells["金额"].Value = price;
                                    this.txtTotalMoney.Text = _retailOrderDetailList.Select(p => p.TotalMoney).Sum().ToString();
                                    break;
                                case "数量":
                                    if (Convert.ToInt16(cellVallue) <= _drugInventoryRecordlList[e.RowIndex].CurrentInventoryCount)
                                    {
                                        _retailOrderDetailList[e.RowIndex].Amount = Convert.ToInt16(cellVallue);
                                        decimal currprice = _retailOrderDetailList[e.RowIndex].Amount * _retailOrderDetailList[e.RowIndex].ActualUnitPrice;
                                        dgvDrugDetailList.Rows[e.RowIndex].Cells["金额"].Value = currprice;
                                        this.txtTotalMoney.Text = _retailOrderDetailList.Select(p => p.TotalMoney).Sum().ToString();
                                    }
                                    else
                                    {
                                        MessageBox.Show("数量超过可用库存！！！", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    break;
                                case "说明":
                                    _retailOrderDetailList[e.RowIndex].Description = cellVallue.ToString();
                                    break;

                            }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtReduceMoney_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtReceivableMoney.Text = (Convert.ToDecimal(this.txtTotalMoney) - Convert.ToDecimal(this.txtReduceMoney.Text)).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGotMoney_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtChangeMoney.Text = Math.Round((Convert.ToDecimal(this.txtGotMoney) - Convert.ToDecimal(this.txtReceivableMoney.Text)), 2).ToString();
                this.txtRealPayMoney.Text = Math.Round((Convert.ToDecimal(this.txtGotMoney) - Convert.ToDecimal(this.txtChangeMoney.Text)), 2).ToString();

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
              FormRetailOrderReturn form = new FormRetailOrderReturn();
              form.ShowDialog();
        }

    }
}
