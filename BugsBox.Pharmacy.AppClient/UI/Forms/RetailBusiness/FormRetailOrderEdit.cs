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
using BugsBox.Pharmacy.UI.Common.Printer;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.RetailBusiness
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
            this.dgvDrugDetailList.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 带零售信息的初始化
        /// </summary>
        /// <param name="orderInfo"></param>
        public FormRetailOrderEdit(RetailOrder retailOrder)
        {
            InitializeComponent();
            this.dgvDrugDetailList.AutoGenerateColumns = false;
            this._retailsOrder = retailOrder;
            this.tsbtnBalance.Visible = false;
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
                MessageBox.Show("窗体初始化失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void tsbtnBalance_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要提交吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                  
                    if (string.IsNullOrEmpty(this.txtGotMoney.Text)) 
                    {
                        MessageBox.Show("收款值不能为空！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    GetRetailsOrderInstance();
                    //if (_retailOrderDetailList.Select(p => p.ReturnAmount).Sum() <= 0)
                    //{
                    //    MessageBox.Show("退货数量必须大于0！！！", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    _retailsOrder.RetailOrderDetails = _retailOrderDetailList.ToArray();
                   
                    string msg = string.Empty;
                    msg = PharmacyDatabaseService.AddRetailOrderAndDetails(_retailsOrder);
                    if (msg.Length > 0)
                        MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        //this.tsbtnBalance.Enabled = false;
                        this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("零售结算操作失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            int pieNum =drugInventoryRecord.DrugInfo.PiecemealNumber;
                            rod.Id = Guid.NewGuid();
                            rod.IsDismanting = false;
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
                            if (pieNum > 0)
                                rod.DismantingUnitPrice = Math.Round(drugInventoryRecord.DrugInfo.Price / pieNum, 2);
                            rod.ActualUnitPrice = 0;
                            rod.ActualDismantingUnitPrice = 0;
                            rod.DismantingAmount = 0;
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
                MessageBox.Show("添加零售单明细信息失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _retailsOrder.Code = this.ucbcRetailCode.GenarateCode();
                _retailsOrder.CreateUserId = AppClientContext.CurrentUser.Id;

            }
            _retailsOrder.ChangeMoney = Convert.ToDecimal(this.txtChangeMoney.Text.Trim());
            _retailsOrder.Description = this.txtRemark.Text.Trim();
            _retailsOrder.TotalMoney = Convert.ToDecimal(this.txtTotalMoney.Text.Trim());
            _retailsOrder.RetailPaymentMethodValue = Convert.ToInt16(this.cmbRetailPaymentMethod.SelectedValue);
            _retailsOrder.GotMoney = Convert.ToDecimal(this.txtGotMoney.Text.Trim());
            _retailsOrder.ReduceMoney = Convert.ToDecimal(this.txtReduceMoney.Text.Trim());
            _retailsOrder.RealPayMoney = Convert.ToDecimal(this.txtRealPayMoney.Text.Trim());
            _retailsOrder.ReceivableMoney = Convert.ToDecimal(this.txtReceivableMoney.Text.Trim());
            _retailsOrder.RetailCustomerTypeValue = Convert.ToInt16(this.cmbRetailCustomerType.SelectedValue);
        }


        private void InitControl()
        {
            if (_retailsOrder == null)
            {
                this.lblCreateDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
                this.lblOrderNo.Text = string.Empty;
            
            }
            else
            {
                this.lblOrderNo.Text = _retailsOrder.Code;
                this.lblCreateDate.Text = _retailsOrder.CreateTime.Date.ToString();

                this.cmbRetailCustomerType.Text = Utility.getEnumTypeDisplayName<RetailCustomerType>((RetailCustomerType)_retailsOrder.RetailCustomerTypeValue);
                this.cmbRetailPaymentMethod.Text = Utility.getEnumTypeDisplayName<RetailPaymentMethod>((RetailPaymentMethod)_retailsOrder.RetailPaymentMethodValue);
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
                        if (dgvDrugDetailList.Columns[e.ColumnIndex].Name.Length > 0)
                            switch (columnName)
                            {
                                case "是否拆零":
                                    _retailOrderDetailList[e.RowIndex].IsDismanting = Convert.ToBoolean(cellVallue);
                                    if (Convert.ToBoolean(cellVallue))
                                    {
                                        dgvDrugDetailList.Rows[e.RowIndex].Cells["实际拆零单价"].ReadOnly = false;
                                        dgvDrugDetailList.Rows[e.RowIndex].Cells["实际单价"].ReadOnly = true;

                                        dgvDrugDetailList.Rows[e.RowIndex].Cells["拆零数量"].ReadOnly = false;
                                        dgvDrugDetailList.Rows[e.RowIndex].Cells["数量"].ReadOnly = true;
                                    }
                                    else
                                    {
                                        dgvDrugDetailList.Rows[e.RowIndex].Cells["实际拆零单价"].ReadOnly = true;
                                        dgvDrugDetailList.Rows[e.RowIndex].Cells["实际单价"].ReadOnly = false;

                                        dgvDrugDetailList.Rows[e.RowIndex].Cells["拆零数量"].ReadOnly = true;
                                        dgvDrugDetailList.Rows[e.RowIndex].Cells["数量"].ReadOnly = false;
                                    }
                                    break;
                                case "折扣":
                                    _retailOrderDetailList[e.RowIndex].Discount = Convert.ToInt16(cellVallue);
                                    if (_retailOrderDetailList[e.RowIndex].IsDismanting)
                                    {
                                          price = Math.Round(_retailOrderDetailList[e.RowIndex].DismantingAmount * _retailOrderDetailList[e.RowIndex].ActualDismantingUnitPrice * _retailOrderDetailList[e.RowIndex].Discount / 100, 2);
                                    }
                                    else
                                    {
                                          price = Math.Round(_retailOrderDetailList[e.RowIndex].Amount * _retailOrderDetailList[e.RowIndex].ActualUnitPrice * _retailOrderDetailList[e.RowIndex].Discount / 100, 2);
                                    }
                                    _retailOrderDetailList[e.RowIndex].TotalMoney = price;
                                    dgvDrugDetailList.Rows[e.RowIndex].Cells["金额"].Value = price;
                                    this.txtTotalMoney.Text = _retailOrderDetailList.Select(p => p.TotalMoney).Sum().ToString();
                                    break;
                                case "实际单价":
                                    _retailOrderDetailList[e.RowIndex].ActualUnitPrice = Convert.ToInt16(cellVallue);
                                    price = Math.Round(_retailOrderDetailList[e.RowIndex].Amount * _retailOrderDetailList[e.RowIndex].ActualUnitPrice * _retailOrderDetailList[e.RowIndex].Discount / 100, 2);
                                    dgvDrugDetailList.Rows[e.RowIndex].Cells["金额"].Value = price;
                                    _retailOrderDetailList[e.RowIndex].TotalMoney = price;
                                    this.txtTotalMoney.Text = _retailOrderDetailList.Select(p => p.TotalMoney).Sum().ToString();
                                    break;
                                case "数量":
                                    if (Convert.ToInt16(cellVallue) <= _drugInventoryRecordlList[e.RowIndex].CurrentInventoryCount)
                                    {
                                        _retailOrderDetailList[e.RowIndex].Amount = Convert.ToInt16(cellVallue);
                                        price = Math.Round(_retailOrderDetailList[e.RowIndex].Amount * _retailOrderDetailList[e.RowIndex].ActualUnitPrice * _retailOrderDetailList[e.RowIndex].Discount / 100, 2);
                                        dgvDrugDetailList.Rows[e.RowIndex].Cells["金额"].Value = price;
                                        _retailOrderDetailList[e.RowIndex].TotalMoney = price;
                                        this.txtTotalMoney.Text = _retailOrderDetailList.Select(p => p.TotalMoney).Sum().ToString();
                                    }
                                    else
                                    {
                                        MessageBox.Show("数量超过可用库存！！！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    break;
                                case "实际拆零单价":
                                    _retailOrderDetailList[e.RowIndex].ActualDismantingUnitPrice = Convert.ToInt16(cellVallue);
                                    price = Math.Round(_retailOrderDetailList[e.RowIndex].DismantingAmount * _retailOrderDetailList[e.RowIndex].ActualDismantingUnitPrice * _retailOrderDetailList[e.RowIndex].Discount / 100, 2);
                                    dgvDrugDetailList.Rows[e.RowIndex].Cells["金额"].Value = price;
                                    _retailOrderDetailList[e.RowIndex].TotalMoney = price;
                                    this.txtTotalMoney.Text = _retailOrderDetailList.Select(p => p.TotalMoney).Sum().ToString();
                                    break;
                                case "拆零数量":
                                    if (Convert.ToInt16(cellVallue) <= _drugInventoryRecordlList[e.RowIndex].CurrentInventoryCount)
                                    {
                                        _retailOrderDetailList[e.RowIndex].DismantingAmount = Convert.ToInt16(cellVallue);
                                        price = Math.Round(_retailOrderDetailList[e.RowIndex].DismantingAmount * _retailOrderDetailList[e.RowIndex].ActualDismantingUnitPrice * _retailOrderDetailList[e.RowIndex].Discount / 100, 2);
                                        dgvDrugDetailList.Rows[e.RowIndex].Cells["金额"].Value = price;
                                        _retailOrderDetailList[e.RowIndex].TotalMoney = price;
                                        this.txtTotalMoney.Text = _retailOrderDetailList.Select(p => p.TotalMoney).Sum().ToString();
                                    }
                                    else
                                    {
                                        MessageBox.Show("数量超过可用库存！！！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (this.txtTotalMoney.Text.Length > 0 && this.txtReduceMoney.Text.Length > 0)
                {
                    this.txtReceivableMoney.Text = (Convert.ToDecimal(this.txtTotalMoney.Text) - Convert.ToDecimal(this.txtReduceMoney.Text)).ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (this.txtGotMoney.Text.Length > 0 && this.txtReceivableMoney.Text.Length > 0)
                {
                    this.txtChangeMoney.Text = Math.Round((Convert.ToDecimal(this.txtGotMoney.Text) - Convert.ToDecimal(this.txtReceivableMoney.Text)), 2).ToString();
                    this.txtRealPayMoney.Text = Math.Round((Convert.ToDecimal(this.txtGotMoney.Text) - Convert.ToDecimal(this.txtChangeMoney.Text)), 2).ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void dgvDrugDetailList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            if(_retailsOrder!=null)
            {
                PosPrinterModel docu = InitPosPrinterModel(_retailsOrder);
                PosPrinter pp = new PosPrinter(docu);
                pp.print();
            }
        }


        private PosPrinterModel InitPosPrinterModel(RetailOrder ro) 
        {
            PosPrinterModel posPrinterModel = new PosPrinterModel();
            posPrinterModel.Header = PharmacyClientConfig.Config.Store.Name;
            posPrinterModel.ActualCash = ro.ReceivableMoney.ToString();
            posPrinterModel.CardAvailable = "0";
            posPrinterModel.CardConsume = "0";

            posPrinterModel.GeneDate = DateTime.Now.ToString();
            posPrinterModel.MarkAvailable = "0";
            posPrinterModel.MarkIn = "";
            posPrinterModel.Nums = ro.RetailOrderDetails.Count().ToString();
            posPrinterModel.ReceiveCash = ro.GotMoney.ToString();
            posPrinterModel.RetCash = ro.ChangeMoney.ToString();
            posPrinterModel.SaildID = ro.Code;
            posPrinterModel.TotalPrice = ro.TotalMoney.ToString();
            List<List<string>> data = new List<List<string>>();
            foreach (RetailOrderDetail rod in ro.RetailOrderDetails) 
            {
                List<string> item = new List<string>();
                
                item.Add(rod.productCode);
                item.Add(rod.Amount.ToString());
                item.Add(rod.ActualUnitPrice.ToString());
                item.Add(rod.TotalMoney.ToString());
                data.Add(item);
            }
            posPrinterModel.Datas = data;
            return posPrinterModel;
        }

        private void tsbtnReturn_Click(object sender, EventArgs e)
        {
            if (_retailsOrder != null)
            {
                FormRetailOrderReturn form = new FormRetailOrderReturn(_retailsOrder);
                form.ShowDialog();
            }
        }

        private void txtTotalMoney_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtTotalMoney.Text.Length > 0 && this.txtReduceMoney.Text.Length > 0)
                {
                    this.txtReceivableMoney.Text = (Convert.ToDecimal(this.txtTotalMoney.Text) - Convert.ToDecimal(this.txtReduceMoney.Text)).ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

    }
}
