using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.UI.Common.Helper;
using Omu.ValueInjecter;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.AppClient.UI.Report;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    using OrderStatus = BugsBox.Pharmacy.Models.OrderStatus;
    using BugsBox.Pharmacy.AppClient.Common;
    using BugsBox.Pharmacy.Models;
    public partial class FormSalesOrderReturn : BaseFunctionForm
    {
        string msg = string.Empty;
        /// <summary>
        /// 订单实体
        /// </summary>
        /// 
        private SalesOrder OrderInfo { get; set; }
        /// <summary>
        /// 出库记录,包含明细
        /// </summary>
        private OutInventory OutInfo { get; set; }

        private SalesOrderReturn _SalesOrderReturn = null;
        private List<SalesOrderReturnDetail> listSalesOrderReturnDetail = new List<SalesOrderReturnDetail>();

        private bool _ReadOnly = false;

        private bool isBalance = false;
        /// <summary>
        /// 根据出库单生成销退单(允许退货一次)
        /// </summary>
        /// <param name="orderInfo"></param>
        public FormSalesOrderReturn(OutInventory outInventory)
        {
           
            InitializeComponent();
            
            this.OutInfo = outInventory;
            this.dgvDrugDetailList.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dgvDrugDetailList.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 根据出库单生成销退单(允许退货一次)
        /// </summary>
        /// <param name="orderInfo"></param>
        public FormSalesOrderReturn(SalesOrderReturn salesOrderReturn)
        {
            InitializeComponent();
            this.Text = UpdateFormTitle(salesOrderReturn.OrderReturnStatus);
            this._SalesOrderReturn = salesOrderReturn;
            this.dgvDrugDetailList.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dgvDrugDetailList.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 根据出库单生成销退单(允许退货一次)
        /// </summary>
        /// <param name="orderInfo"></param>
        public FormSalesOrderReturn(SalesOrderReturn salesOrderReturn,bool isReadOnly)
        {
            InitializeComponent();
            this.Text = UpdateFormTitle(salesOrderReturn.OrderReturnStatus);
            this._SalesOrderReturn = salesOrderReturn;
            this.dgvDrugDetailList.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dgvDrugDetailList.AutoGenerateColumns = false;
            _ReadOnly = isReadOnly;
            UpdateBtnEnabled(OrderReturnStatus.None);
        }

        public FormSalesOrderReturn(SalesOrderReturn salesOrderReturn,bool isReadOnly,bool b)
        {
            InitializeComponent();
            isBalance = b;
            this.Text = UpdateFormTitle(salesOrderReturn.OrderReturnStatus);
            this._SalesOrderReturn = salesOrderReturn;
            this.dgvDrugDetailList.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dgvDrugDetailList.AutoGenerateColumns = false;
            _ReadOnly = isReadOnly;
            UpdateBtnEnabled(OrderReturnStatus.None);
        }

        /// <summary>
        /// 初始化画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSalesOrderReturn_Load(object sender, EventArgs e)
        {
            try
            {
               
                
                //提交销退申请
                this.tsbtnSubmit.Visible = this.Authorize(ModuleKeys.SubmitOrderReturn);
                //取消销退申请
                if (_SalesOrderReturn != null)
                    this.tsbtnCancel.Visible = this.Authorize(ModuleKeys.SubmitOrderReturn) && _SalesOrderReturn.OrderReturnStatusValue == OrderReturnStatus.Waitting.GetHashCode();
                //销售员审核
                this.tsbtnSellerApproved.Visible = this.Authorize(ModuleKeys.SellerApprovedOrderReturn);
                //营业部审核
                this.tsbtnTradeApproved.Visible = this.Authorize(ModuleKeys.TradeApprovedOrderReturn);
                //质量管理部审核
                this.tsbtnQualityApproved.Visible = this.Authorize(ModuleKeys.QualityApprovedOrderReturn);
                
                //结算
                this.toolStripButton1.Visible = this.Authorize(ModuleKeys.BalanceSalesOrderReturn) && isBalance;
                //结算打印
                this.tsbtnPrint.Visible = this.Authorize(ModuleKeys.BalanceSalesOrderReturn);

                string msg = string.Empty;
                InitGridViewCombox();
                if (this.OutInfo != null)
                {                   
                    _SalesOrderReturn = this.PharmacyDatabaseService.GetLastOrderReturnByReturnOrder(out msg, OutInfo.Id);
                    OrderInfo = this.PharmacyDatabaseService.GetSalesOrder(out msg, OutInfo.SalesOrderID);
                }

                //创建一个销退信息
                if (this.OutInfo != null )
                {
                    _SalesOrderReturn = new SalesOrderReturn();
                    _SalesOrderReturn.OrderReturnStatusValue = (int)OrderReturnStatus.None;
                    this.tsbtnCancel.Enabled = false;
                    this.tsbtnSubmit.Enabled = true;
                    _SalesOrderReturn.SalesOrderID = OrderInfo.Id;
                    listSalesOrderReturnDetail = CreateReturnDetailByOrderDetail(OutInfo.SalesOutInventoryDetails);

                    this.lblReturnNo.Text = string.Empty;
                    this.lblOrderNo.Text = OrderInfo.OrderCode;
                    this.lblCreateDate.Text = OrderInfo.SaleDate.Date.ToString("yyyy-MM-dd");
                    this.lblOutStatus.Text = Utility.getEnumTypeDisplayName<OrderStatus>((OrderStatus)this.OrderInfo.OrderStatusValue);
                    this.dgvDrugDetailList.DataSource = listSalesOrderReturnDetail;
                }
                else
                {
                    OrderInfo = this.PharmacyDatabaseService.GetSalesOrder(out msg, _SalesOrderReturn.SalesOrderID);
                    listSalesOrderReturnDetail = _SalesOrderReturn.SalesOrderReturnDetails.ToList();
                    this.tsbtnCancel.Enabled = true;
                    this.tsbtnSubmit.Enabled = false;
                    this.txtTotalMoney.Text = listSalesOrderReturnDetail.Select(s => s.ReturnAmount * s.ActualUnitPrice).Sum().ToString();
                    this.txtReason.Text = _SalesOrderReturn.OrderReturnReason;

                    this.lblReturnNo.Text = _SalesOrderReturn.OrderReturnCode;
                    this.lblOrderNo.Text = OrderInfo.OrderCode;
                    this.lblCreateDate.Text = OrderInfo.SaleDate.Date.ToString("yyyy-MM-dd");
                    this.lblOutStatus.Text = Utility.getEnumTypeDisplayName<OrderStatus>((OrderStatus)this.OrderInfo.OrderStatusValue);

                    if (isBalance)
                    {
                        this.dgvDrugDetailList.DataSource = listSalesOrderReturnDetail.Where(r=>r.ReturnAmount>0).ToList();
                    }
                    else
                    {
                        this.dgvDrugDetailList.DataSource = listSalesOrderReturnDetail;
                    }
                    this.dgvDrugDetailList.ReadOnly = true;
                }
                UpdateBtnEnabled((OrderReturnStatus)_SalesOrderReturn.OrderReturnStatusValue);

                dgvDrugDetailList.ClearSelection();

                if (_SalesOrderReturn.OrderReturnStatus == OrderReturnStatus.ReturnChecked)
                {
                    toolStripButton2.Enabled = false;
                    this.tsbtnInVentory.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
           
        }

        /// <summary>
        /// 提交销退申请信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnSubmit_Click(object sender, EventArgs e)
        {
            this.dgvDrugDetailList.EndEdit();
            bool flag=false;
            foreach (DataGridViewRow dr in this.dgvDrugDetailList.Rows)
            {
                if (Convert.ToDecimal(dr.Cells["退货数量"].Value) > 0)
                {
                    flag = true;
                    if (Convert.ToInt32(dr.Cells["dgvcmbReturnReason"].Value) == 0)
                    {
                        MessageBox.Show("您编辑的（" + dr.Cells["商品名称"].Value.ToString() + "）退货理由没有填写。");
                        dgvDrugDetailList.ClearSelection();
                        dgvDrugDetailList.CurrentCell = dr.Cells["dgvcmbReturnReason"];
                        dgvDrugDetailList.BeginEdit(false);
                        return;
                    }
                    if (Convert.ToDecimal(dr.Cells["不可入库数量"].Value)>0 && Convert.ToInt32(dr.Cells["不可入库处理办法"].Value) == 0)
                    {
                        MessageBox.Show("您编辑的（" + dr.Cells["商品名称"].Value.ToString() + "）不可入库处理办法没有填写。");
                        dgvDrugDetailList.ClearSelection();
                        dgvDrugDetailList.CurrentCell = dr.Cells["不可入库处理办法"];
                        dgvDrugDetailList.BeginEdit(false);
                        return;
                    }
                }

                if (Convert.ToDecimal(dr.Cells["退货数量"].Value) != Convert.ToDecimal(dr.Cells["可入库数量"].Value) + Convert.ToDecimal(dr.Cells["不可入库数量"].Value))
                {
                    MessageBox.Show("您填写的（"+dr.Cells["商品名称"].Value.ToString()+"）数量有误！\n"+"其退货数量为："+dr.Cells[退货数量.Name].Value +"不等于可入库数量和可入库数量之和。");
                    dgvDrugDetailList.ClearSelection();
                    dr.Selected = true;
                    return;
                }

                if (Convert.ToDecimal(dr.Cells["退货数量"].Value) < 0 || Convert.ToDecimal(dr.Cells["可入库数量"].Value) < 0 || Convert.ToDecimal(dr.Cells["不可入库数量"].Value)<0)
                {
                    MessageBox.Show("您填写的（" + dr.Cells["商品名称"].Value.ToString() + "）数量有负值！\n" );
                    dgvDrugDetailList.ClearSelection();
                    dr.Selected = true;
                    return;
                }

                Models.SalesOrderReturnDetail sord = (SalesOrderReturnDetail)dr.DataBoundItem;
                if (sord.IsReissue)
                {
                    decimal cansaleNum=this.PharmacyDatabaseService.GetDrugInventoryRecordByCondition(out msg,sord.productName,sord.BatchNumber).Sum(r=>r.CanSaleNum);
                    if (cansaleNum < sord.ReturnAmount)
                    {
                        MessageBox.Show("当前库存中该药品(名称："+sord.productName+",批次号："+sord.BatchNumber+")可销售数量小于补发数量，不能执行补发操作！");
                        return;
                    }
                }
                
            }
            if (!flag)
            {
                MessageBox.Show("列表中没有填写需要退货的数量，无法执行退货流程，您至少需要填写一个品种的退货数量。");
                return;
            }
            try
            {
                string message;
                SalesOrderReturn orderReturn = new SalesOrderReturn();
                orderReturn.Id = Guid.NewGuid();
                orderReturn.IsReissue = this.ckbIsReissue.Checked;
                orderReturn.SalesOrderID = OrderInfo.Id;
                orderReturn.CreateUserId = AppClientContext.CurrentUser.Id;
                //orderReturn.OrderReturnCode = this.ucbcSalesReturn.GenarateCode();
                orderReturn.OrderReturnReason = this.txtReason.Text;
                orderReturn.OrderReturnStatusValue = (int)OrderReturnStatus.Waitting;
                orderReturn.OutInventoryID = OutInfo.Id;
                //没办法，只能这么写了，获取用户ID
                Employee[] emp=this.PharmacyDatabaseService.AllEmployees(out msg);
                var em = emp.FirstOrDefault(r => r.Name.Equals(this.OrderInfo.SalerName));
                if (em == null)
                {
                    MessageBox.Show("该单据异常，销售员：" + this.OrderInfo.SalerName + "被人为删除。此单据为该销售员所定制，系统当前无该销售员信息，所以暂时无法退货，解决办法是恢复该销售员信息，并且锁定该销售员，如果系统中确实无法找到该销售员信息，则可按照姓名新增员工信息和用户信息。"); return;
                }
                Guid uid = em.Users.First().Id;                
                orderReturn.SellerID = uid;

                listSalesOrderReturnDetail = listSalesOrderReturnDetail.Where(r => r.ReturnAmount > 0).ToList();
                orderReturn.SalesOrderReturnDetails = listSalesOrderReturnDetail.ToArray();

                //调用服务器端
                message = PharmacyDatabaseService.AddSalesOrderReturnAndDetail(orderReturn);
                if (message.Length > 0)
                    MessageBox.Show(message);
                else
                {
                    orderReturn = this.PharmacyDatabaseService.GetSalesOrderReturn(out msg, orderReturn.Id);
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "成功提交销售退货操作："+orderReturn.OrderReturnCode);
                    MessageBox.Show("成功提交退货申请，单号："+orderReturn.OrderReturnCode+"，请销售员登陆，执行审核！");
                    this.tsbtnSubmit.Enabled = false;
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary
        /// 提交销退取消申请信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要执行(退货)取消操作吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) return;
            string message = "";
            try
            {
                if (_SalesOrderReturn != null)
                {
                    //_SalesOrderReturn.OrderReturnCancelCode = ucbcOrderReturnCancel.GenarateCode();
                    _SalesOrderReturn.OrderReturnStatusValue = (int)BugsBox.Pharmacy.Models.OrderReturnStatus.Canceled;
                    _SalesOrderReturn.OrderReturnCancelReason = "退货操作取消";
                    _SalesOrderReturn.OrderReturnCancelUserID = BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id;

                    message = PharmacyDatabaseService.CancelSalesOrderReturn(_SalesOrderReturn);
                    if (message.Length > 0)
                    {
                        this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, " 销退取消操作提交数据库失败！"+message);
                        MessageBox.Show(message + message);
                    }
                    else
                    {
                        this.tsbtnCancel.Enabled = false;
                        this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, " 销退取消操作提交数据库成功！单号：" + _SalesOrderReturn.OrderReturnCode);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("提交销退取消申请信息失败!" + message);
            }
        }

        /// <summary>
        ///  格式化数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDrugDetailList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region
                DataGridView grid = sender as DataGridView;
                if (e.RowIndex < 0)
                {
                    return;
                }


                if (dgvDrugDetailList.Columns[e.ColumnIndex].Name == "是否补发")
                {
                    var isDetailReissue = grid.Rows[e.RowIndex].Cells["是否补发"].Value;
                    if (isDetailReissue != null)
                    {
                        listSalesOrderReturnDetail[e.RowIndex].IsReissue = Convert.ToBoolean(isDetailReissue);
                        if (listSalesOrderReturnDetail.Where(w => w.IsReissue == true).ToList().Count > 0)
                            this.ckbIsReissue.Checked = true;
                        else
                            this.ckbIsReissue.Checked = false;
                    }
                }
                if (dgvDrugDetailList.Columns[e.ColumnIndex].Name == "退货数量")
                {
                    var returnQty = grid.Rows[e.RowIndex].Cells["退货数量"].Value;
                    if (returnQty != null)
                    {
                        if (decimal.Parse(returnQty.ToString()) > decimal.Parse(grid.Rows[e.RowIndex].Cells["出库数量"].Value.ToString()))
                        {
                            MessageBox.Show("退货数量不能大于订单数量!");
                            grid.Rows[e.RowIndex].Cells["退货数量"].Value = decimal.Parse(grid.Rows[e.RowIndex].Cells["出库数量"].Value.ToString());
                        }
                        else
                        {
                            listSalesOrderReturnDetail[e.RowIndex].ReturnAmount = decimal.Parse(returnQty.ToString());
                            this.txtTotalMoney.Text = listSalesOrderReturnDetail.Select(p => p.ActualUnitPrice * p.ReturnAmount).Sum().ToString();
                        }
                    }
                }

                if (dgvDrugDetailList.Columns[e.ColumnIndex].Name == "退货理由")
                {
                    var returnReason = grid.Rows[e.RowIndex].Cells["退货理由"].Value;
                    if (returnReason != null)
                    {
                        listSalesOrderReturnDetail[e.RowIndex].ReturnReasonValue = Convert.ToInt16(returnReason);
                    }
                }
                if (dgvDrugDetailList.Columns[e.ColumnIndex].Name == "退货理由补足")
                {
                    var returnReasondescription = grid.Rows[e.RowIndex].Cells["退货理由补足"].Value;
                    if (returnReasondescription != null)
                    {
                        listSalesOrderReturnDetail[e.RowIndex].ReturnReasonMemo = returnReasondescription.ToString();
                    }
                }
                if (dgvDrugDetailList.Columns[e.ColumnIndex].Name == "可入库数量")
                {
                    var canInAmount = grid.Rows[e.RowIndex].Cells["可入库数量"].Value;
                    if (canInAmount != null)
                    {
                        listSalesOrderReturnDetail[e.RowIndex].CanInAmount = Convert.ToDecimal(canInAmount);
                    }
                }
                if (dgvDrugDetailList.Columns[e.ColumnIndex].Name == "不可入库数量")
                {
                    var cannotInAmount = grid.Rows[e.RowIndex].Cells["不可入库数量"].Value;
                    if (cannotInAmount != null)
                    {
                        listSalesOrderReturnDetail[e.RowIndex].CannotInAmount = Convert.ToDecimal(cannotInAmount);
                    }
                }
                if (dgvDrugDetailList.Columns[e.ColumnIndex].Name == "不可入库处理办法")
                {
                    var returnHandledMethodValue = grid.Rows[e.RowIndex].Cells["不可入库处理办法"].Value;
                    if (returnHandledMethodValue != null)
                    {
                        listSalesOrderReturnDetail[e.RowIndex].ReturnHandledMethodValue = Convert.ToInt16(returnHandledMethodValue);
                    }
                }
                if (dgvDrugDetailList.Columns[e.ColumnIndex].Name == "不可入库处理办法补足")
                {
                    var cannotInAmountMemo = grid.Rows[e.RowIndex].Cells["不可入库处理办法补足"].Value;
                    if (cannotInAmountMemo != null)
                    {
                        listSalesOrderReturnDetail[e.RowIndex].ReturnHandledMethodMemo = cannotInAmountMemo.ToString();
                    }
                }
                if (dgvDrugDetailList.Columns[e.ColumnIndex].Name == "说明")
                {
                    var description = grid.Rows[e.RowIndex].Cells["说明"].Value;
                    if (description != null)
                    {
                        listSalesOrderReturnDetail[e.RowIndex].Description = description.ToString();
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
               Log.Error(ex);
            }

        }

        /// <summary>
        /// 获取销售单明细
        /// </summary>
        /// <returns></returns>
        private List<SalesOrderReturnDetail> CreateReturnDetailByOrderDetail(ICollection<OutInventoryDetail> from)
        {
            var result = new List<SalesOrderReturnDetail>();
            foreach (var f in from)
            {
                var item = new SalesOrderReturnDetail();
                item.InjectFrom(f);
                item.Id = Guid.NewGuid();
                item.SalesOrderDetailID = f.SalesOrderDetailId;
                item.OutInventoryDetailID = f.Id;
                item.OrderAmount = f.Amount;
                item.IsReissue = false;
                item.productCode = f.productCode;
                item.productName = f.productName;
                item.OrderAmount = f.OutAmount;
                item.ActualUnitPrice = f.ActualUnitPrice;
                item.DictionaryDosageCode = f.DictionaryDosageCode;
                result.Add(item);
            }
            return result;
        }

        /// <summary>
        /// 业务员审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnSellerApproved_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SalesOrderReturn != null)
                {
                    string msg = string.Empty;
                    _SalesOrderReturn.SellerUpdateTime = DateTime.Now;
                    _SalesOrderReturn.SellerMemo = txtSellerUpdateMemo.Text;
                    _SalesOrderReturn.OrderReturnStatusValue = (int)BugsBox.Pharmacy.Models.OrderReturnStatus.SellerApproved;
                    _SalesOrderReturn.OrderReturnCheckCode = string.Empty;
                    _SalesOrderReturn.OrderReturnCheckTime = DateTime.Now;
                    _SalesOrderReturn.OrderReturnCheckUserID = AppClientContext.currentUser.Id;
                    if (PharmacyDatabaseService.SaveSalesOrderReturn(out msg, _SalesOrderReturn))
                        this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, " 销退销售员审核通过操作提交数据库成功！单号："+_SalesOrderReturn.OrderReturnCode);
                    else
                    {
                        this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, " 销退销售员审核通过操作提交数据库失败！单号：" + _SalesOrderReturn.OrderReturnCode);
                    }
                    if (msg.Length > 0)
                        MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        this.tsbtnSellerApproved.Enabled = false;
                }
                else
                {
                    MessageBox.Show("没有可取消的销退单！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("业务员审核提交出错！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 营业部审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnTradeApproved_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SalesOrderReturn != null)
                {
                    string msg = string.Empty;
                    _SalesOrderReturn.TradeUpdateTime = DateTime.Now;
                    _SalesOrderReturn.TradeMemo = this.txtTradeMemo.Text;
                    _SalesOrderReturn.OrderReturnStatusValue = (int)BugsBox.Pharmacy.Models.OrderReturnStatus.TradeApproved;
                    PharmacyDatabaseService.SaveSalesOrderReturn(out msg, _SalesOrderReturn);

                    if (msg.Length > 0)
                    {
                        this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, " 销退销售科审核通过操作提交数据库失败！单号：" + _SalesOrderReturn.OrderReturnCode);
                        MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, " 销退销售科审核通过操作提交数据库成功！单号：" + _SalesOrderReturn.OrderReturnCode);
                        this.tsbtnTradeApproved.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("没有可取消的销退单！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("营业部审核提交出错！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 质量审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnQualityApproved_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SalesOrderReturn != null)
                {
                    string msg = string.Empty;
                    _SalesOrderReturn.QualityUpdateTime = DateTime.Now;
                    _SalesOrderReturn.QualityMemo = this.txtQualityMemo.Text;
                    _SalesOrderReturn.OrderReturnStatusValue = (int)BugsBox.Pharmacy.Models.OrderReturnStatus.QualityApproved;
                    //PharmacyDatabaseService.SaveSalesOrderReturn(out msg, _SalesOrderReturn);
                    msg = PharmacyDatabaseService.SaveReturnOrderOutventory(_SalesOrderReturn);

                    if (msg.Length > 0)
                    {
                        this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, " 销退质量管理部审核通过操作提交数据库失败！单号：" + _SalesOrderReturn.OrderReturnCode);
                        MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, " 销退销售科审核通过操作提交数据库成功！单号：" + _SalesOrderReturn.OrderReturnCode);
                        this.tsbtnQualityApproved.Enabled = false;
                    }

                }
                else
                {
                    MessageBox.Show("没有可审核的销退单！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("质量审核提交出错！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 入库操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnInVentory_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SalesOrderReturn != null)
                {
                    string msg = string.Empty;
                    _SalesOrderReturn.OrderReturnStatusValue = (int)BugsBox.Pharmacy.Models.OrderReturnStatus.Over;

                    var billcode = this.PharmacyDatabaseService.GenerateBillDocumentCodeByTypeValue(out msg, (int)BillDocumentType.OrderReturnInInventory);

                    _SalesOrderReturn.OrderReturnInInventoryCode = billcode.Code;
                    _SalesOrderReturn.OrderReturnInInventoryUserID = AppClientContext.currentUser.Id;

                    this.PharmacyDatabaseService.AddBillDocumentCode(out msg, billcode);
                    msg = PharmacyDatabaseService.SaveReturnOrderInventory(_SalesOrderReturn);
                    if (msg.Length > 0)
                        MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.tsbtnInVentory.Enabled = false;
                        this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, "销退入库处理完毕，单号：" + this._SalesOrderReturn.OrderReturnCode);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("没有可入库的销退单！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("入库操作出错！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        /// 绑定Gridview 中的combox
        /// </summary>
        private void InitGridViewCombox()
        {
            //退货理由初始化
            List<ListEnumItem> ReasonList = Utility.CreateComboboxEnumList<OrderReturnReason>();

            //增加一个空Option
            ListEnumItem emptyListItem = new ListEnumItem();
            emptyListItem.ID = 0;
            emptyListItem.Name = string.Empty;
            ReasonList.Insert(0, emptyListItem);

            this.returnReasonBindingSource.DataSource = ReasonList;
            this.dgvcmbReturnReason.DisplayMember = "Name";
            this.dgvcmbReturnReason.ValueMember = "ID";

            //不可入库方法初始化
            List<ListEnumItem> handledMethodList = Utility.CreateComboboxEnumList<ReturnHandledMethod>();

            //增加一个空Option
            ListEnumItem emptyHandledMethodList = new ListEnumItem();
            emptyHandledMethodList.ID = 0;
            emptyHandledMethodList.Name = string.Empty;
            handledMethodList.Insert(0, emptyHandledMethodList);

            this.ReturnHandledMethodbindingSource.DataSource = handledMethodList;
            this.不可入库处理办法.DisplayMember = "Name";
            this.不可入库处理办法.ValueMember = "ID";
        }


        /// <summary>
        /// 更新画面按钮状态
        /// </summary>
        /// <param name="status"></param>
        private void UpdateBtnEnabled(OrderReturnStatus status)
        {
            this.checkBox1.Visible = _SalesOrderReturn.OrderReturnStatus == OrderReturnStatus.None ? true : false;
            if (_ReadOnly)
            {
                this.tsbtnSubmit.Visible = false;
                this.tsbtnInVentory.Visible = false;
                this.tsbtnQualityApproved.Visible = false;
                this.tsbtnSellerApproved.Visible = false;
                this.tsbtnTradeApproved.Visible = false;
                this.tsbtnSubmit.Visible = false;
            }
            else
            {
                this.tsbtnSubmit.Enabled = false;
                this.tsbtnInVentory.Enabled = false;
                this.tsbtnQualityApproved.Enabled = false;
                this.tsbtnSellerApproved.Enabled = false;
                this.tsbtnTradeApproved.Enabled = false;
                this.tsbtnSubmit.Enabled = false;

                switch (status)
                {
                    case OrderReturnStatus.None:
                        this.tsbtnSubmit.Enabled = true;
                        tabControl1.SelectedIndex = 0;
                        break;
                    case OrderReturnStatus.Waitting:
                        this.tsbtnCancel.Enabled = true;
                        this.tsbtnSellerApproved.Enabled = true;
                        tabControl1.SelectedIndex = 1;
                        break;
                    case OrderReturnStatus.SellerApproved:
                        this.tsbtnTradeApproved.Enabled = true;
                        tabControl1.SelectedIndex = 2;
                        break;
                    case OrderReturnStatus.TradeApproved:
                        this.tsbtnQualityApproved.Enabled = true;
                        tabControl1.SelectedIndex = 3;
                        break;
                    case OrderReturnStatus.QualityApproved:
                        this.tsbtnInVentory.Enabled = true;
                        tabControl1.SelectedIndex = 0;
                        break;
                    case OrderReturnStatus.Balanced:
                        this.toolStripButton3.Visible = true;
                        break;
                    case OrderReturnStatus.ReturnReceived:
                        this.toolStripButton2.Visible = true;
                        break;
                    case OrderReturnStatus.ReturnChecked:
                        this.tsbtnInVentory.Visible = true;
                        break;
                }
            }
        }

        /// <summary>
        /// to do
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SalesOrderReturn != null)
                {
                    DsSalesOrder ds = new DsSalesOrder();
                    ds.ExtendedProperties.Clear();
                    ds.Tables.Clear();

                    ds.ExtendedProperties.Add("ReportTitle", PharmacyClientConfig.Config.Store.Name);
                    ds.ExtendedProperties.Add("Addr", PharmacyClientConfig.Config.Store.Address);

                    string[] tel=PharmacyClientConfig.Config.Store.Tel.Split(',');

                    ds.ExtendedProperties.Add("Tel", tel[0]);
                    Guid purchaseId = this.PharmacyDatabaseService.GetSalesOrder(out msg, _SalesOrderReturn.SalesOrderID).PurchaseUnitId;
                    string purchaseName = this.PharmacyDatabaseService.GetPurchaseUnit(out msg, purchaseId).Name;
                    ds.ExtendedProperties.Add("PurchaseUnit", purchaseName); //购买单位
                    ds.ExtendedProperties.Add("OrderCode", this.lblReturnNo.Text); //退单号
                    ds.ExtendedProperties.Add("SaleOrderNum",this.lblOrderNo.Text);//销售订单号
                    string saleMan = this.PharmacyDatabaseService.GetEmployeeByUserId(out msg, this._SalesOrderReturn.SellerID).Name;
                    ds.ExtendedProperties.Add("Saler", saleMan);//业务员
                    ds.ExtendedProperties.Add("Date", this._SalesOrderReturn.CreateTime.ToString("yyyy-MM-dd")); //记录建立日期

                    

                    Guid createrUid = _SalesOrderReturn.CreateUserId;
                    string creater = this.PharmacyDatabaseService.GetUser(out msg, createrUid).Employee.Name;
                    ds.ExtendedProperties.Add("creater", creater);//开票员

                    Guid CheckerUid = _SalesOrderReturn.OrderReturnCheckUserID;
                    var Ch = this.PharmacyDatabaseService.GetUser(out msg, CheckerUid);
                    string Checker = " ";
                    if (Ch != null)
                    {
                        Checker = Ch.Employee.Name;
                    }
                    else
                    {
                        var rs=MessageBox.Show("该销售退货单据暂未验收，验收员为空！需要继续打印吗？","提示",MessageBoxButtons.OKCancel);
                        if (rs != System.Windows.Forms.DialogResult.OK) return;
                    }
                    ds.ExtendedProperties.Add("Checker", Checker);//开票员



                    DsSalesOrder.tableDataTable OrderDetailTable = new DsSalesOrder.tableDataTable();
                    foreach (SalesOrderReturnDetail detail in listSalesOrderReturnDetail.Where(r=>r.ReturnAmount>0).ToList())
                    {
                        //string 
                        string part = detail.productName;
                        string _partType = detail.DictionaryDosageCode;
                        string specialCode = detail.SpecificationCode;
                        string productUnit = detail.FactoryName;
                        string Origin = detail.Origin;
                        string batchNumber = detail.BatchNumber;
                        string ValidDate = detail.OutValidDate.ToString();
                        string unit = detail.MeasurementUnit;
                        decimal qty = detail.ReturnAmount;
                        decimal unitPrice = detail.ActualUnitPrice;
                        decimal price = detail.ReturnAmount * detail.ActualUnitPrice;
                        string Quanlity = "合格";

                        OrderDetailTable.Rows.Add(new object[] { part, _partType, specialCode, productUnit,Origin, batchNumber, ValidDate, unit, qty, unitPrice, price, Quanlity });

                        OrderDetailTable.AcceptChanges();
                    }

                    ds.Tables.Add(OrderDetailTable);

                    using (PrintHelper printHelper = new PrintHelper("Reports\\RptSalesReturnList.rdlc", ds))
                    {
                        printHelper.Print();
                    }
                }
                else
                {
                    MessageBox.Show("没有数据可以打印！！！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }
        
        /// <summary>
        /// 更新Form Title
        /// </summary>
        /// <param name="status"></param>
        private string UpdateFormTitle(OrderReturnStatus status)
        {
            string formTitle = string.Empty;
            switch (status)
            {
                case OrderReturnStatus.None:
                    formTitle = "销退单新建";
                    break;
                case OrderReturnStatus.Waitting:
                    formTitle = "销退销售员审核";
                    break;
                case OrderReturnStatus.SellerApproved:
                    formTitle = "销退营业部审核";
                    break;
                case OrderReturnStatus.TradeApproved:
                    formTitle = "销退质管部审核通过";
                    break;
                case OrderReturnStatus.QualityApproved:
                    formTitle = "销退出入库处理";
                    break;
            }
            return formTitle;
        }

        private void dgvDrugDetailList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("您输入的数据格式不正确，请修改！");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this._SalesOrderReturn.OrderReturnStatus = OrderReturnStatus.Balanced;
            this._SalesOrderReturn.OrderReturnStatusValue = OrderReturnStatus.Balanced.GetHashCode();
            this._SalesOrderReturn.OrderReturnCheckTime = DateTime.Now;
            if (MessageBox.Show("销退结算提示", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (this.PharmacyDatabaseService.SaveSalesOrderReturn(out msg, this._SalesOrderReturn))
                {
                    this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, "销退结算处理成功，单号：" + this._SalesOrderReturn.OrderReturnCode);
                    if (MessageBox.Show("销退结算成功，需要打印吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        this.tsbtnPrint_Click(sender, e);
                    }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            this.toolStripButton1.Enabled = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this._SalesOrderReturn.OrderReturnStatus = OrderReturnStatus.ReturnChecked;
            this._SalesOrderReturn.OrderReturnStatusValue = OrderReturnStatus.ReturnChecked.GetHashCode();
            this._SalesOrderReturn.OrderReturnCheckUserID = BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id;

            var billcode=this.PharmacyDatabaseService.GenerateBillDocumentCodeByTypeValue(out msg, (int)BillDocumentType.OrderReturnCheck);
            this._SalesOrderReturn.OrderReturnCheckCode =billcode.Code;
            this._SalesOrderReturn.OrderReturnCheckTime = DateTime.Now;

            this.PharmacyDatabaseService.AddBillDocumentCode(out msg, billcode);
            bool f=this.PharmacyDatabaseService.SaveSalesOrderReturn(out msg,_SalesOrderReturn);
            if (f)
            {
                this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, "销退收货验收处理成功，单号：" + this._SalesOrderReturn.OrderReturnCode);
                MessageBox.Show("验收成功！请执行入库操作！");
                this.toolStripButton2.Enabled = false;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this._SalesOrderReturn.OrderReturnStatus = OrderReturnStatus.ReturnReceived;
            this._SalesOrderReturn.OrderReturnStatusValue = (int)OrderReturnStatus.ReturnReceived;
            bool f = this.PharmacyDatabaseService.SaveSalesOrderReturn(out msg, _SalesOrderReturn);
            if (f)
            {
                MessageBox.Show("收货成功！请执行验收操作！");
                this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, "销退收货处理成功，单号：" + this._SalesOrderReturn.OrderReturnCode);
                this.toolStripButton3.Enabled = false;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dgvDrugDetailList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool b = this.checkBox1.Checked;
                this.listSalesOrderReturnDetail.ForEach(r =>
                {
                    r.ReturnAmount =b? r.OrderAmount:0m;
                    r.CanInAmount = b?r.OrderAmount:0m;
                    r.CannotInAmount = 0m;
                    r.ReturnReason = OrderReturnReason.Return;
                });
                this.dgvDrugDetailList.DataSource = this.listSalesOrderReturnDetail;
                this.dgvDrugDetailList.Refresh();
        }

    }
}
