using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.UI.Report;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class FormPurchaseOrderEdit : BaseFunctionForm
    {
        Common.GoodsTypeClass GoogsTypeClass = GoodsTypeClass.药品;

        private PurchaseOrdeEntity _order;
        private OrderStatus _orderStatus = OrderStatus.None;
        private PurchaseOrdeEntity _purchaseOrder = new PurchaseOrdeEntity();
        private List<PurchaseOrderDetailEntity> _listPurchaseOrderDetail = new List<PurchaseOrderDetailEntity>();
        public Guid SupplyUnitId = Guid.Empty;
        private string msg = String.Empty;
        private bool _onlySearch = false;
        UI.Forms.BaseForm.BasicInfoRightMenu Bcms = null;
        public FormPurchaseOrderEdit()
        {
            InitializeComponent();

            Bcms = new BaseForm.BasicInfoRightMenu(this.dataGridView1);
            Bcms.InsertDrugBasicInfo();
            Bcms.InsertSupplyUnitBasicInfo();

            this.dataGridView1.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
            this.dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            this.dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dataGridView1_DataError);
            this.dataGridView1.RowPostPaint += delegate (object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.btnAddDetail.Click += new EventHandler(btnAddDetail_Click);
            this.btnDeleteDetail.Click += new EventHandler(btnDeleteDetail_Click);
            this.dataGridView1.CellMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_CellMouseClick);

        }

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            PurchaseOrderDetailEntity pode = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as PurchaseOrderDetailEntity;
            this.Bcms.DrugId = pode.DrugInfoId;
        }

        public FormPurchaseOrderEdit(PurchaseOrdeEntity order, bool modifyPurchaseAmount = false, bool onlySearch = false)
            : this()
        {
            _order = order;
            _onlySearch = onlySearch;
            SupplyUnitId = order.SupplyUnitId;
            _orderStatus = (OrderStatus)order.OrderStatusValue;

            Bcms.Sid = SupplyUnitId;//右键查询供货商

            if (modifyPurchaseAmount == true && _orderStatus == OrderStatus.PurchaseReceinvingAmountDiff)
            {
                btnModifyPurchaseAmount.Visible = true;
            }
            //显示审批记录
            if (_order.ApprovalUserId != null && _order.ApprovalUserId != Guid.Empty)
            {
                groupBoxApprovedRecords.Visible = true;
                string status;
                if (_order.OrderStatusValue != (int)OrderStatus.Canceled && _order.OrderStatusValue != (int)OrderStatus.Rejected && _order.OrderStatusValue != (int)OrderStatus.Waitting)
                {
                    status = EnumHelper<OrderStatus>.GetDisplayValue(OrderStatus.Approved);
                }
                else
                {
                    status = EnumHelper<OrderStatus>.GetDisplayValue((OrderStatus)_order.OrderStatusValue);
                }
                this.dataGridView2.Rows.Add(this.PharmacyDatabaseService.GetEmployeeByUserId(out msg, _order.ApprovalUserId).Name, _order.ApprovaledTime, status, _order.ApprovalDecription);
            }
        }

        /// <summary>
        /// 初始化画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSalesOrderEdit_Load(object sender, EventArgs e)
        {
            switch (_orderStatus)
            {

                case OrderStatus.Waitting:   //等待审批状态
                    receivingButton.Visible = false;
                    panel3.Visible = true;
                    break;
                case OrderStatus.PurchaseReceinvingAmountDiff://收货数量不符
                    receivingButton.Visible = false;
                    btnAdd.Visible = false;
                    btnCancel.Visible = false;
                    btnSubmit.Visible = false;
                    panel3.Visible = false;
                    this.label1.Text += "(采购数量不足)";
                    //审批
                    tsbtnAccept.Visible = false;
                    break;
                case OrderStatus.PurchaseApplyReceinvingAmountDiff://采购数量修改申请
                    receivingButton.Visible = false;
                    btnAdd.Visible = false;
                    btnCancel.Visible = false;
                    btnSubmit.Visible = false;
                    panel3.Visible = false;
                    this.label1.Text += "(数量不足修改申请)";
                    break;
                case OrderStatus.Rejected:
                    btnCancel.Visible = false;
                    tsbtnAccept.Visible = false;
                    btnAdd.Visible = false;
                    btnSubmit.Visible = false;
                    this.label1.Text += "(采购定单拒绝)";
                    break;
                case OrderStatus.Approved:
                    tlbtn结算.Visible = false;
                    btnCancel.Visible = false;
                    tsbtnAccept.Visible = false;
                    btnAdd.Visible = false;
                    btnSubmit.Visible = false;
                    this.label1.Text += "(审核通过)";
                    break;
                case OrderStatus.purchaseMReceiving:
                    tlbtn结算.Visible = false;
                    btnCancel.Visible = false;
                    tsbtnAccept.Visible = false;
                    btnAdd.Visible = false;
                    btnSubmit.Visible = false;
                    this.label1.Text += "(采购记录多次收货)";
                    break;
                case OrderStatus.Canceled:
                    receivingButton.Visible = false;
                    btnAdd.Visible = false;
                    btnSubmit.Visible = false;
                    btnCancel.Visible = false;
                    tlbtn结算.Visible = false;
                    btnCancel.Visible = false;
                    tsbtnAccept.Visible = false;
                    panel3.Visible = true;
                    this.label1.Text += "(定单取消)";
                    break;
                case OrderStatus.PurchaseCheck:
                    tlbtn结算.Visible = false;
                    btnCancel.Visible = false;
                    tsbtnAccept.Visible = false;
                    btnAdd.Visible = false;
                    btnSubmit.Visible = false;
                    break;
                case OrderStatus.PurchaseInInventory://入库
                    receivingButton.Visible = false;
                    tlbtn结算.Visible = false;
                    btnCancel.Visible = false;
                    tsbtnAccept.Visible = false;
                    btnAdd.Visible = false;
                    btnSubmit.Visible = false;
                    this.label1.Text += "(定单入库)";
                    break;
                case OrderStatus.PurchaseApprovedReceinvingAmountDiff:
                    tlbtn结算.Visible = false;
                    btnCancel.Visible = false;
                    tsbtnAccept.Visible = false;
                    btnAdd.Visible = false;
                    btnSubmit.Visible = false;
                    this.label1.Text += "(数量不足审核通过)";
                    break;
                default:
                    receivingButton.Visible = false;
                    tlbtn结算.Visible = false;
                    btnCancel.Visible = false;
                    tsbtnAccept.Visible = false;
                    btnAdd.Visible = false;
                    btnSubmit.Visible = false;
                    this.label1.Text += "(定单已结算)";
                    break;
            }
            string msg = string.Empty;
            _purchaseOrder = _order;
            label5.Text = _purchaseOrder.SupplyUnitName;
            nudTotalMoney.Value = _purchaseOrder.TotalMoney;
            txtEmployeeName.Text = _purchaseOrder.EmployeeName;
            lblOrderNo.Text = _purchaseOrder.DocumentNumber;
            dtpAllReceiptedDate.Text = _purchaseOrder.AllReceiptedDate == null ? "" : _purchaseOrder.AllReceiptedDate.ToString();
            lblCreateDate.Text = _purchaseOrder.CreateTime.ToShortDateString();
            lblOrderStatus.Text = EnumHelper<OrderStatus>.GetDisplayValue((OrderStatus)_purchaseOrder.OrderStatusValue);
            label10.Text = _purchaseOrder.EmployeeName;
            label11.Text = _purchaseOrder.ReceiveUnit;
            label16.Text = _purchaseOrder.Address;
            txtDescription.Text = _purchaseOrder.Description;
            _listPurchaseOrderDetail = PharmacyDatabaseService.GetPurchaseOrderDetails(out msg, _purchaseOrder.Id).ToList();
            this.dataGridView1.AutoGenerateColumns = false;

            if (this._listPurchaseOrderDetail.Count(r => r.SupplyBusinessScope.Contains("医疗器械")) == this._listPurchaseOrderDetail.Count)
            {
                this.GoogsTypeClass = GoodsTypeClass.医疗器械;
                this.LicensePermissionNumber.HeaderText = "注册证或备案凭证编号";
            }

            this.dataGridView1.DataSource = _listPurchaseOrderDetail.ToList();
            if (_orderStatus == OrderStatus.PurchaseReceinvingAmountDiff)
            {
            }
            else
            {
                this.dataGridView1.ReadOnly = true;
            }
            if (_onlySearch)
            {
                btnAddDetail.Visible = false;
                btnDeleteDetail.Visible = false;
                receivingButton.Visible = false;
                tlbtn结算.Visible = false;
                btnCancel.Visible = false;
                tsbtnAccept.Visible = false;
                btnAdd.Visible = false;
                btnSubmit.Visible = false;
                this.dataGridView1.ReadOnly = true;
                dtpAllReceiptedDate.Enabled = false;
                txtDescription.Enabled = false;
            }
            if (btnAdd.Visible == true)
            {
                this.btnAdd.Visible = this.Authorize(ModuleKeys.EditPurchaseOrder);
                this.btnSubmit.Visible = this.Authorize(ModuleKeys.EditPurchaseOrder);
                this.btnCancel.Visible = this.Authorize(ModuleKeys.EditPurchaseOrder);
            }
            if (tsbtnAccept.Visible == true)
            {
                tsbtnAccept.Visible = this.Authorize(ModuleKeys.ApprovalPurchaseOrder);
            }
            if (btnModifyPurchaseAmount.Visible == true)
            {
                btnModifyPurchaseAmount.Visible = this.Authorize(ModuleKeys.ApprovalPurchaseOrder);
            }
            if (receivingButton.Visible == true)
            {
                receivingButton.Visible = this.Authorize(ModuleKeys.PurchaseReceiving);
            }
        }

        /// <summary>
        /// 订单详细grid的按钮操作
        /// 添加商品,删除商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDrugDetailList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //如果订单为未付款状态的话,就可以取消


            FormCancelOrderConfirm form = new FormCancelOrderConfirm();
            form.ShowDialog();

            ////确定取消
            if (form.DialogResult == DialogResult.OK)
            {
                string cancelReason = form.Reason;

                //执行取消操作
                try
                {
                    string msg = String.Empty;
                    PurchaseOrder purchaseOrder = PharmacyDatabaseService.GetPurchaseOrder(out msg, _purchaseOrder.Id);
                    purchaseOrder.OrderStatusValue = OrderStatus.Canceled.GetHashCode();
                    purchaseOrder.ApprovaledTime = DateTime.Now;
                    purchaseOrder.ApprovalUserId = AppClientContext.CurrentUser.Id;
                    purchaseOrder.ApprovalDecription = cancelReason;
                    PharmacyDatabaseService.SavePurchaseOrder(out msg, purchaseOrder);
                    _orderStatus = OrderStatus.Canceled;
                    FormSalesOrderEdit_Load(sender, e);
                    MessageBox.Show("订单取消成功!");
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行采购单取消操作成功,单号:" + purchaseOrder.DocumentNumber);
                }
                catch
                {
                    MessageBox.Show("订单取消失败,请联系管理员!");
                }
            }
        }

        /// <summary>
        /// 审核订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnAccept_Click(object sender, EventArgs e)
        {
            //执行审核操作
            OrderStatus approvalStatus = OrderStatus.Approved;
            if (_orderStatus == OrderStatus.PurchaseApplyReceinvingAmountDiff)
            {
                approvalStatus = OrderStatus.PurchaseApprovedReceinvingAmountDiff;
            }

            FormPurchaseOrderApproval form = new FormPurchaseOrderApproval(_purchaseOrder.Id, approvalStatus);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                _orderStatus = (OrderStatus)form.OrderStatusValue;
                lblOrderStatus.Text = EnumHelper<OrderStatus>.GetDisplayValue(_orderStatus);
                tsbtnAccept.Enabled = false;
                MessageBox.Show("订单审核通过!");
                this.Close();
            }
        }

        /// <summary>
        /// 订单结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlbtn结算_Click(object sender, EventArgs e)
        {
            FormPayConfirm form = new FormPayConfirm();
            form.ShowDialog(this);

            if (form.DialogResult == DialogResult.Yes)
            {
                MessageBox.Show("订单结算完毕!");
            }
        }

        /// <summary>
        /// 验收入库处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnOutInventory_Click(object sender, EventArgs e)
        {
            //FormInInventory form = new FormInInventory(_purchaseOrder, _listPurchaseOrderDetail);
            //form.ShowDialog();
            //this.Refresh();
        }

        /// <summary>
        /// 提交订单,保存修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.btnSubmit.Enabled = false;
            this.dataGridView1.EndEdit();
            try
            {
                if (this.dataGridView1.Rows.Count <= 0)
                {
                    MessageBox.Show("您至少需要增加一条采购药品信息,请选择采购药品", "错误", MessageBoxButtons.OK);
                    this.btnSubmit.Enabled = true;
                    return;
                }
                foreach (DataGridViewRow dr in this.dataGridView1.Rows)
                {
                    if (Convert.ToDecimal(dr.Cells[clmDrugNumber.Name].Value) <= 0 || Convert.ToDecimal(dr.Cells[clmPurchasePrice.Name].Value) <= 0)
                    {
                        MessageBox.Show("单价或数量为0");
                        this.btnSubmit.Enabled = true;
                        dataGridView1.CurrentCell = dr.Cells[clmDrugNumber.Name];
                        dataGridView1.BeginEdit(true);
                        return;
                    }
                }
                string msg = string.Empty;
                #region 构造主表
                PurchaseOrder order = new PurchaseOrder();
                List<PurchaseOrderDetail> orderDetails = new List<PurchaseOrderDetail>();

                order.Decription = txtDescription.Text;
                order.SupplyUnitId = _order.SupplyUnitId;
                order.Id = _order.Id;
                order.CreateUserId = _order.CreateUserId;
                order.OrderStatusValue = (int)OrderStatus.Waitting;
                order.AllReceiptedDate = dtpAllReceiptedDate.Value;
                order.UpdateUserId = AppClientContext.CurrentUser.Id;

                #endregion

                #region 构造明细表
                for (int j = 0; j < this._listPurchaseOrderDetail.Count; j++)
                {
                    PurchaseOrderDetail detail = new PurchaseOrderDetail();
                    detail.AmountOfTax = this._listPurchaseOrderDetail[j].AmountOfTax;
                    detail.DrugInfoId = this._listPurchaseOrderDetail[j].DrugInfoId;
                    detail.Amount = this._listPurchaseOrderDetail[j].Amount;
                    detail.PurchasePrice = this._listPurchaseOrderDetail[j].PurchasePrice;
                    detail.Id = _listPurchaseOrderDetail[j].Id;
                    detail.sequence = j;
                    detail.Deleted = _listPurchaseOrderDetail[j].isdeleted;
                    orderDetails.Add(detail);
                }
                #endregion

                this.PharmacyDatabaseService.CreatePurchaseOrder(out msg, order, orderDetails.ToArray());
                if (!String.IsNullOrEmpty(msg))
                {
                    MessageBox.Show(msg, "错误", MessageBoxButtons.OK);
                    return;
                }
                PurchaseOrder updateOrder = this.PharmacyDatabaseService.GetPurchaseOrder(out msg, order.Id);
                nudTotalMoney.Value = updateOrder.TotalMoney;
                lblOrderStatus.Text = EnumHelper<OrderStatus>.GetDisplayValue(OrderStatus.Waitting); ;
                btnSubmit.Enabled = false;
                MessageBox.Show("采购记录修改成功", "提示", MessageBoxButtons.OK);

                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行更新采购记录单细节操作成功，采购单号：" + updateOrder.DocumentNumber);
                this.btnSubmit.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                this.btnSubmit.Enabled = true;
                Log.Error(ex);
            }
        }



        //编辑明细表信息
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.dataGridView1.ReadOnly = false;
            btnSubmit.Enabled = true;
            btnAddDetail.Visible = false;
            btnDeleteDetail.Visible = false;
        }


        /// <summary>
        /// 只有数量、采购价、实际价3列可编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string clmName = this.dataGridView1.Columns[e.ColumnIndex].Name;
            if (clmName != "clmDrugNumber" && clmName != "clmPurchasePrice")
            {
                e.Cancel = true;
            }

        }
        /// <summary>
        /// 计算总价
        /// </summary>
        private void CalculateTotalPrice()
        {
            try
            {
                decimal totalMoney = 0;
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    decimal curPrice = decimal.Parse(row.Cells["TotalMoney"].Value.ToString());
                    totalMoney += curPrice;
                }

                this.nudTotalMoney.Value = totalMoney;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            try
            {
                FormDrugsForSupplyUnitSelector selector = new FormDrugsForSupplyUnitSelector(_purchaseOrder.SupplyUnitId);
                selector.GoogsTypeClass = this.GoogsTypeClass;

                selector.Show(this);

                selector.OnDrugSelected += (args) =>
                {

                    foreach (var drugSelected in args)
                    {
                        if (_listPurchaseOrderDetail.Find(r => r.DrugInfoId == drugSelected.Id && r.isdeleted == false) != null)
                        {
                            MessageBox.Show(drugSelected.ProductName + "已存在,不可重复增加!");
                            continue;
                        }

                        PurchaseOrderDetailEntity newDetail = new PurchaseOrderDetailEntity();
                        #region create new PurchaseOrderDetail record
                        newDetail.Id = Guid.NewGuid();
                        newDetail.PurchaseOrderId = _purchaseOrder.Id;
                        newDetail.DrugInfoId = drugSelected.Id;
                        newDetail.PurchasePrice = drugSelected.PurchasePrice;
                        newDetail.Amount = 1;
                        newDetail.AmountOfTax = 17.0m;
                        newDetail.Price = drugSelected.Price;
                        newDetail.ProductGeneralName = drugSelected.ProductGeneralName;
                        newDetail.FactoryName = drugSelected.FactoryName;
                        newDetail.DictionarySpecificationCode = drugSelected.DictionarySpecificationCode;
                        newDetail.DictionaryMeasurementUnitCode = drugSelected.DictionaryMeasurementUnitCode;
                        newDetail.DictionaryDosageCode = drugSelected.DictionaryDosageCode;
                        newDetail.LicensePermissionNumber = drugSelected.LicensePermissionNumber;
                        newDetail.sequence = this._listPurchaseOrderDetail.Count;
                        _listPurchaseOrderDetail.Add(newDetail);
                        #endregion
                    }
                    this.dataGridView1.DataSource = null;
                    var c = this._listPurchaseOrderDetail.Where(r => r.isdeleted == false).ToList();
                    this.dataGridView1.DataSource = c;
                    this.dataGridView1.ReadOnly = false;
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }


        }

        private void RefreshDataGridView()
        {
            string msg = string.Empty;
            _listPurchaseOrderDetail = PharmacyDatabaseService.GetPurchaseOrderDetails(out msg, _purchaseOrder.Id).ToList();
            this.dataGridView1.DataSource = _listPurchaseOrderDetail;
        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow != null)
            {
                if (MessageBox.Show("确定要删除此条记录吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
                var c = this.dataGridView1.CurrentRow.DataBoundItem as PurchaseOrderDetailEntity;
                this._listPurchaseOrderDetail.Remove(c);
                this.dataGridView1.DataSource = this._listPurchaseOrderDetail.ToList();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormReceivingOrder form = new FormReceivingOrder(_purchaseOrder, _listPurchaseOrderDetail);
            form.ShowDialog();
            this.Refresh();
            this.Close();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowidx = e.RowIndex;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("clmDrugNumber") || dataGridView1.Columns[e.ColumnIndex].Name.Equals("clmPurchasePrice"))
            {

                DataGridViewCell numberCell = this.dataGridView1.Rows[e.RowIndex].Cells["clmDrugNumber"];
                DataGridViewCell purchasePriceCell = this.dataGridView1.Rows[e.RowIndex].Cells["clmPurchasePrice"];
                DataGridViewCell taxCell = this.dataGridView1.Rows[e.RowIndex].Cells["AmountOfTax"];
                if (numberCell.Value != null && purchasePriceCell.Value != null)
                {
                    this.dataGridView1.Rows[e.RowIndex].Cells["TotalMoney"].Value = (Decimal.Parse(numberCell.Value.ToString())) * (Decimal.Parse(purchasePriceCell.Value.ToString()));
                }
                this.CalculateTotalPrice();
            }


        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString() == "Return")
            {
                if (this.dataGridView1.CurrentCell.RowIndex == this.dataGridView1.Rows.Count - 1 && this.dataGridView1.CurrentCell.ColumnIndex == 10)
                {
                    this.dataGridView1.EndEdit();
                    return true;
                }

                if (this.dataGridView1.CurrentCell.ColumnIndex == 9)
                    System.Windows.Forms.SendKeys.Send("{tab}");
                if (this.dataGridView1.CurrentCell.ColumnIndex == 10 && this.dataGridView1.CurrentCell.RowIndex < this.dataGridView1.Rows.Count - 1)
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex + 1].Cells[9];
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell numberCell = this.dataGridView1.Rows[e.RowIndex].Cells["clmDrugNumber"];
            DataGridViewCell purchasePriceCell = this.dataGridView1.Rows[e.RowIndex].Cells["clmPurchasePrice"];
            DataGridViewCell amountOfTax = this.dataGridView1.Rows[e.RowIndex].Cells["AmountOfTax"];
            if (numberCell.Value != null && purchasePriceCell.Value != null)
            {
                this.dataGridView1.Rows[e.RowIndex].Cells["TotalMoney"].Value = (Decimal.Parse(numberCell.Value.ToString())) * (Decimal.Parse(purchasePriceCell.Value.ToString()));
                this.dataGridView1.Rows[e.RowIndex].Cells["colmoneyofTax"].Value = (Decimal.Parse(numberCell.Value.ToString())) * (Decimal.Parse(purchasePriceCell.Value.ToString())) * (1 + (Decimal.Parse("0.01")) * (Decimal.Parse(amountOfTax.Value.ToString())));
            }
        }

        private void btnModifyPurchaseAmount_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.EndEdit();
                if (MessageBox.Show("确定已经修改了正确的采购数量吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    string msg = string.Empty;
                    #region 构造主表
                    PurchaseOrder order = new PurchaseOrder();
                    List<PurchaseOrderDetail> orderDetails = new List<PurchaseOrderDetail>();

                    order.Decription = _order.Description;

                    order.SupplyUnitId = _order.SupplyUnitId;
                    order.Id = _order.Id;
                    order.CreateUserId = AppClientContext.CurrentUser.Id;
                    order.OrderStatusValue = (int)OrderStatus.PurchaseApplyReceinvingAmountDiff;
                    order.AllReceiptedDate = _order.AllReceiptedDate;
                    #endregion

                    #region 构造明细表
                    for (int j = 0; j < this.dataGridView1.Rows.Count; j++)
                    {
                        PurchaseOrderDetail detail = new PurchaseOrderDetail();
                        detail.AmountOfTax = Decimal.Parse(this.dataGridView1.Rows[j].Cells["AmountOfTax"].Value.ToString());
                        detail.DrugInfoId = Guid.Parse(this.dataGridView1.Rows[j].Cells["clmDrugId"].Value.ToString());
                        detail.Amount = Decimal.Parse(this.dataGridView1.Rows[j].Cells["clmDrugNumber"].Value.ToString());
                        detail.PurchasePrice = decimal.Parse(this.dataGridView1.Rows[j].Cells["clmPurchasePrice"].Value.ToString());
                        detail.Id = _listPurchaseOrderDetail[j].Id;
                        detail.sequence = _listPurchaseOrderDetail[j].sequence;
                        orderDetails.Add(detail);
                    }
                    #endregion

                    this.PharmacyDatabaseService.CreatePurchaseOrder(out msg, order, orderDetails.ToArray());
                    if (!String.IsNullOrEmpty(msg))
                    {
                        MessageBox.Show(msg, "错误", MessageBoxButtons.OK);
                        return;
                    }
                    PurchaseOrder updateOrder = this.PharmacyDatabaseService.GetPurchaseOrder(out msg, order.Id);
                    nudTotalMoney.Value = updateOrder.TotalMoney;
                    lblOrderStatus.Text = EnumHelper<OrderStatus>.GetDisplayValue(OrderStatus.PurchaseApplyReceinvingAmountDiff); ;
                    btnSubmit.Enabled = false;
                    btnModifyPurchaseAmount.Enabled = true;
                    MessageBox.Show("采购定单数量修改申请成功", "提示", MessageBoxButtons.OK);
                    this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "成功提交采购定单修改申请");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            return;
            List<object> reportData = new List<object>();
            List<object> orderList = new List<object>();
            Employee emp = this.PharmacyDatabaseService.GetEmployeeByUserId(out msg, _purchaseOrder.ApprovalUserId);
            if (emp != null)
            {
                _purchaseOrder.ApprovalEmployeeName = emp.Name;
            }
            orderList.Add(_purchaseOrder);
            reportData.Add(orderList);
            reportData.Add(_listPurchaseOrderDetail);
            List<Microsoft.Reporting.WinForms.ReportParameter> ListPar = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            using (PrintHelper printHelper = new PrintHelper("BugsBox.Pharmacy.AppClient.UI.Reports.RptPurchaseCheckingOrder.rdlc", reportData, ListPar))
            {
                printHelper.Print();
            }
        }



        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("您输入的数据格式不正确，请修改！");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            string s = this._order == null ? "" : this._order.DocumentNumber;
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "采购订单" + s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FormDrugsForSupplyUnitSelector selector = new FormDrugsForSupplyUnitSelector(_purchaseOrder.SupplyUnitId);
                selector.GoogsTypeClass = this.GoogsTypeClass;

                selector.ShowDialog();

                if (selector.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    //先判断选中的药物在现在的list中是否存在
                    List<DrugInfo> drugsSelected = selector.dinfos;
                    foreach (var drugSelected in drugsSelected)
                    {
                        if (_listPurchaseOrderDetail.Find(r => r.DrugInfoId == drugSelected.Id && r.isdeleted == false) != null)
                        {
                            MessageBox.Show(drugSelected.ProductName + "已存在,不可重复增加!");
                            continue;
                        }

                        PurchaseOrderDetailEntity newDetail = new PurchaseOrderDetailEntity();
                        #region create new PurchaseOrderDetail record
                        newDetail.Id = Guid.NewGuid();
                        newDetail.PurchaseOrderId = _purchaseOrder.Id;
                        newDetail.DrugInfoId = drugSelected.Id;
                        newDetail.PurchasePrice = drugSelected.PurchasePrice;
                        newDetail.Amount = 1;
                        newDetail.AmountOfTax = 17.0m;
                        newDetail.Price = drugSelected.Price;
                        newDetail.ProductGeneralName = drugSelected.ProductGeneralName;
                        newDetail.FactoryName = drugSelected.FactoryName;
                        newDetail.DictionarySpecificationCode = drugSelected.DictionarySpecificationCode;
                        newDetail.DictionaryMeasurementUnitCode = drugSelected.DictionaryMeasurementUnitCode;
                        newDetail.DictionaryDosageCode = drugSelected.DictionaryDosageCode;
                        newDetail.LicensePermissionNumber = drugSelected.LicensePermissionNumber;
                        newDetail.sequence = this._listPurchaseOrderDetail.Count;
                        _listPurchaseOrderDetail.Add(newDetail);

                        this.dataGridView1.DataSource = null;
                        var c = this._listPurchaseOrderDetail.Where(r => r.isdeleted == false).ToList();
                        this.dataGridView1.DataSource = c;
                        this.dataGridView1.ReadOnly = false;
                        #endregion
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow != null)
            {
                if (MessageBox.Show("确定要删除此条记录吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
                var c = this.dataGridView1.CurrentRow.DataBoundItem as PurchaseOrderDetailEntity;
                {
                    string msg = string.Empty;
                    c.isdeleted = true;
                    this.dataGridView1.DataSource = this._listPurchaseOrderDetail.Where(r => r.isdeleted == false).ToList();
                }
            }
        }
    }
}
