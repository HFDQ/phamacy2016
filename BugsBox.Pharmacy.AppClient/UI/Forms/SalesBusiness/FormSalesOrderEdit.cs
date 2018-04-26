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
using BugsBox.Pharmacy.UI.Common.Printer;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.UI.Report;
namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class FormSalesOrderEdit : BaseFunctionForm
    {
        private Common.GoodsTypeClass GoodsType { get; set; }

        private SalesOrder _salesOrder;
        private List<SalesOrderDetail> newList;
        private List<DrugInventoryRecord> _drugInventoryRecordlList = new List<DrugInventoryRecord>();
        private PurchaseUnit _purchaseUnit;
        private FormOperation _operation;
        private bool _IsReadOnly = false;
        private List<User> userList = new List<User>();
        private List<PurchaseUnitBuyer> purchaseUnitBuyerList;
        private string msg = string.Empty;
        private bool isprivilege;
        List<compareCount> _listsod = new List<compareCount>();
        private int _PriceType = 0;
        private string _salerRoleName = string.Empty;
        private bool _IsInvoice = false;
        private bool _isRefund = false;
        public bool IsBalanced = false;
        private bool _IsChinese = false;
        private bool IsSpecial = false;
        //右键支持
        UI.Forms.BaseForm.BasicInfoRightMenu Bcms = null;

        //销售价格控制规则模型
        Business.Models.SalePriceControlRulesModel SalePriceControlRuleModel = null;

        /// <summary>
        /// 药品销售类型
        /// </summary>
        private SalesDrugType salesDrugType;
        public SalesDrugType _salesDrugType
        {
            get
            {
                return salesDrugType;
            }
            set
            {
                salesDrugType = value;
                this.lblSalesType.Visible = false;
                this.cmbSalesType.Visible = false;
            }
        }
        public FormSalesOrderEdit(object salesDrugType)
        {
            _salesDrugType = EnumHelper<SalesDrugType>.Parse(salesDrugType.ToString());
            InitializeComponent();
            _operation = FormOperation.Add;
        }

        public FormSalesOrderEdit()
        {
            InitializeComponent();
            _operation = FormOperation.Add;
            this.dgvDrugDetailList.Columns[0].Visible = true;
            this.checkBox2.Visible = true;
            this.checkBox2.ForeColor = Color.Red;
        }

        class compareCount
        {
            public Guid id { get; set; }
            public decimal amount { get; set; }
        }

        /// <summary>
        /// 编辑界面
        /// </summary>
        /// <param name="salesOrder"></param>
        public FormSalesOrderEdit(SalesOrder salesOrder)
        {
            InitializeComponent();
            this._salesOrder = salesOrder;
            _operation = FormOperation.Empty;
            newList = new List<SalesOrderDetail>();
            newList.AddRange(salesOrder.SalesOrderDetails.Where(r => r.Deleted == false));
            var listsod = salesOrder.SalesOrderDetails.Where(r => r.Deleted == false && r.Amount > 0).OrderBy(r => r.Index).ToList();

            var listsodCom = from i in listsod
                             select new compareCount
                             {
                                 id = i.Id,
                                 amount = i.Amount
                             };
            _listsod = listsodCom.ToList();

            string emstr = string.Empty;
            List<Employee> em = this.PharmacyDatabaseService.AllEmployees(out emstr).ToList();
            try
            {
                isprivilege = em.Where(r => r.Name.Equals(salesOrder.SalerName)).First().Users.First().IsSpecialPriceAuth;
            }
            catch (Exception ex)
            {
                MessageBox.Show("销售员账号出现问题，请联系管理员！");
            }
            invoicer.Text = this.PharmacyDatabaseService.GetUser(out emstr, salesOrder.CreateUserId).Employee.Name;
        }

        public FormSalesOrderEdit(SalesOrder salesOrder, bool isReasOnly)
        {
            InitializeComponent();
            this._salesOrder = salesOrder;
            _operation = FormOperation.Empty;
            _IsReadOnly = isReasOnly;
            this.dgvDrugDetailList.Columns[0].Visible = false;
            this.dgvDrugDetailList.ReadOnly = isReasOnly;
        }

        /// <summary>
        /// 冲差
        /// </summary>
        /// <param name="salesOrder"></param>
        /// <param name="isReasOnly"></param>
        /// <param name="isRefund"></param>
        /// <param name="isAdmin"></param>
        public FormSalesOrderEdit(SalesOrder salesOrder, bool isReasOnly, Boolean isRefund, bool isAdmin = false)
        {
            InitializeComponent();
            this._salesOrder = salesOrder;
            _operation = FormOperation.Empty;
            _IsReadOnly = isReasOnly;
            this.dgvDrugDetailList.Columns[0].Visible = false;
            if (isRefund)
            {
                this._isRefund = isRefund;
                bool isRefunded = salesOrder.ReceivedMoney != null && Math.Abs(Convert.ToDecimal(salesOrder.ReceivedMoney) - salesOrder.TotalMoney) > 0m;   //如果是ReceivedMoney不为null，并且差额不等于0，则表示已冲差了。

                this.toolStripButton1.Visible = this._isRefund;
                this.toolStripButton2.Visible = true;
                this.toolStripButton3.Visible = true;
                this.Column1.Visible = true;
                this.Column2.Visible = true;
                this.Column3.Visible = true;

                //if (isRefunded)
                //{
                //    this.Column1.ReadOnly = true;
                //    this.toolStripButton1.Visible = false;
                //}

                this.dgvDrugDetailList.Columns[Column1.Name].DisplayIndex = 1;
                this.dgvDrugDetailList.Columns[Column3.Name].DisplayIndex = 2;
                this.dgvDrugDetailList.Columns[Column2.Name].DisplayIndex = 3;
            }
        }


        /// Load事件        
        private void FormSalesOrderEdit_Load(object sender, EventArgs e)
        {
            //加入行号
            this.dgvDrugDetailList.RowPostPaint += delegate (object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };

            #region 右键控制
            Bcms = new BaseForm.BasicInfoRightMenu(this.dgvDrugDetailList);
            Bcms.InsertDrugBasicInfo();
            Bcms.InsertPurchaseUnitBasicInfo();
            if (this._salesOrder != null)
            {
                Bcms.Pid = this._salesOrder.PurchaseUnitId;//查购货商基础信息
            }
            this.dgvDrugDetailList.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvDrugDetailList_CellMouseClick);
            #endregion

            //获取销售价格控制规则模型
            this.SalePriceControlRuleModel = this.PharmacyDatabaseService.GetSalePriceControlRules(out msg);

            try
            {
                //编辑订单
                this.tsbtnSubmit.Visible = this.Authorize(ModuleKeys.AddSalesOrder);
                //保存订单
                this.tsbtnSave.Visible = this.Authorize(ModuleKeys.EditSalesOrder);
                //保存订单
                this.tsbtnCancel.Visible = this.Authorize(ModuleKeys.EditSalesOrder);
                //审核订单
                this.tsbtnAccept.Visible = this.Authorize(ModuleKeys.ApprovalSalesOrder);
                //结算订单
                this.tsbtnBalance.Visible = this.Authorize(ModuleKeys.BalanceSalesOrder);
                this.toolStripButton5.Visible = this.tsbtnBalance.Visible;
                //出库订单
                this.tsbtnOutInventory.Visible = this.Authorize(ModuleKeys.SubmitOutInventoryForOrder);

                System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
                xmlDocument.Load(AppDomain.CurrentDomain.BaseDirectory + "BugsBox.Pharmacy.AppClient.SalePriceType.xml");
                System.Xml.XmlNodeList xmlNode = xmlDocument.SelectNodes("/SalePriceType/priceType");
                _PriceType = Convert.ToInt16(xmlNode[0].Attributes[0].Value);
                xmlNode = xmlDocument.SelectNodes("/SalePriceType/salerRoleName");
                _salerRoleName = xmlNode[0].Attributes[0].Value.ToString();

                if (_PriceType == 2)
                {
                    this.采购单价.HeaderText = "最高限价";
                }
                xmlNode = xmlDocument.SelectNodes("/SalePriceType/TaxReturn");
                _IsInvoice = Convert.ToInt16(xmlNode[0].Attributes[0].Value) == 1 ? true : false;
                InitControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("窗体加载失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }

            if (!_isRefund) return;
            foreach (DataGridViewRow dr in this.dgvDrugDetailList.Rows)
            {
                var s = ((SalesOrderDetail)dr.DataBoundItem);
                dr.Cells[Column1.Name].Value = s.ActualUnitPrice + s.ChangeAmount;
                dr.Cells[Column2.Name].Value = s.Amount * (s.ActualUnitPrice + s.ChangeAmount);
            }
        }

        void dgvDrugDetailList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            SalesOrderDetail sod = this.dgvDrugDetailList.Rows[e.RowIndex].DataBoundItem as SalesOrderDetail;
            Bcms.DrugInventoryId = sod.DrugInventoryRecordID;
        }

        /// <summary>
        /// 订单详细grid的按钮操作
        /// 添加商品,删除商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDrugDetailList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if ("删除".Equals(this.dgvDrugDetailList.Columns[e.ColumnIndex].Name))
                {
                    newList.RemoveAt(e.RowIndex);
                    _drugInventoryRecordlList.RemoveAt(e.RowIndex);
                    this.dgvDrugDetailList.DataSource = null;
                    this.dgvDrugDetailList.DataSource = newList;
                    decimal m = newList.Where(r => r.Deleted == false).Sum(r => r.ActualUnitPrice * r.Amount);
                    txtTotalMoney.Text = m.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除订单明细信息失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }


        //List的Except比较器，需实现接口方法：Equals和GetHashCode
        class compareD : IEqualityComparer<DrugInventoryRecord>
        {
            public bool Equals(DrugInventoryRecord x, DrugInventoryRecord y)
            {
                if (y == null) return true;
                return x.Id == y.Id;
            }
            public int GetHashCode(DrugInventoryRecord obj)
            {
                unchecked
                {
                    if (obj == null)
                        return 0;
                    int hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.Id.GetHashCode();
                    return hashCode;
                }
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
                if (cmbPurchase.SelectedValue != null)
                {
                    Guid purchaseGuid = Guid.Parse(cmbPurchase.SelectedValue.ToString());
                    FormDrugForSalesSelector selForm = new FormDrugForSalesSelector(purchaseGuid);
                    selForm.GoodsType = this.GoodsType;

                    if (selForm.ShowDialog() == DialogResult.OK)
                    {
                        var d = selForm.result.Except(_drugInventoryRecordlList, new compareD()).ToList();

                        _drugInventoryRecordlList.AddRange(d);//先存储druginventoryrecord列表

                        if (newList == null)
                            newList = new List<SalesOrderDetail>();

                        foreach (DrugInventoryRecord drugInventoryRecord in d)//再生成SaleOrderDetail列表
                        {
                            SalesOrderDetail sod = new SalesOrderDetail();
                            sod.Id = Guid.NewGuid();
                            sod.MeasurementUnit = drugInventoryRecord.DrugInfo.DictionaryMeasurementUnitCode;

                            if (this.SalePriceControlRuleModel.RuleType == (int)Models.SalePriceControlEnum.可低于采购价)
                            {
                                sod.UnitPrice = drugInventoryRecord.PurchasePricce;    //销售定价
                                sod.ActualUnitPrice = drugInventoryRecord.OnRetailCount;  //实际价格，从formdrugforsalesselector获取
                                sod.PurchasePrice = drugInventoryRecord.PurchasePricce;    //采购价
                                if (sod.ActualUnitPrice == 0m) sod.ActualUnitPrice = drugInventoryRecord.PurchasePricce;
                            }
                            if (this.SalePriceControlRuleModel.RuleType == (int)Models.SalePriceControlEnum.不低于采购价)
                            {
                                sod.UnitPrice = drugInventoryRecord.DrugInfo.SalePrice;    //基础信息中的销售定价
                                sod.ActualUnitPrice = drugInventoryRecord.PurchasePricce;  //库存进货实际价格
                                sod.PurchasePrice = drugInventoryRecord.PurchasePricce;    //采购价
                                if (sod.UnitPrice <= 0m) sod.UnitPrice = drugInventoryRecord.PurchasePricce;
                            }

                            if (this.SalePriceControlRuleModel.RuleType == (int)Models.SalePriceControlEnum.不高于最高定价)
                            {

                                sod.UnitPrice = drugInventoryRecord.DrugInfo.SalePrice; //显示最高价
                                sod.ActualUnitPrice = drugInventoryRecord.PurchasePricce * this.SalePriceControlRuleModel.RuleRate;  //实际价格
                                sod.PurchasePrice = drugInventoryRecord.PurchasePricce * this.SalePriceControlRuleModel.RuleRate;    //采购价
                            }

                            sod.productName = drugInventoryRecord.DrugInfo.ProductGeneralName;
                            sod.productCode = drugInventoryRecord.DrugInfo.Code;
                            sod.BatchNumber = drugInventoryRecord.BatchNumber;
                            sod.Description = drugInventoryRecord.Decription;
                            sod.DrugInventoryRecordID = drugInventoryRecord.Id;
                            sod.FactoryName = drugInventoryRecord.DrugInfo.FactoryName;
                            sod.SpecificationCode = drugInventoryRecord.DrugInfo.DictionarySpecificationCode;
                            sod.PruductDate = drugInventoryRecord.PruductDate;
                            sod.OutValidDate = drugInventoryRecord.OutValidDate;
                            sod.Origin = drugInventoryRecord.Decription;//获取库存的产地信息
                            sod.DictionaryDosageCode = drugInventoryRecord.DrugInfo.DictionaryDosageCode;
                            sod.Amount = drugInventoryRecord.SalesCount;

                            sod.Price = sod.ActualUnitPrice * sod.Amount;

                            newList.Add(sod);
                        }
                        this.dgvDrugDetailList.DataSource = null;
                        this.dgvDrugDetailList.DataSource = newList;

                        txtTotalMoney.Text = newList.Where(r => r.Deleted == false).Sum(r => r.ActualUnitPrice * r.Amount).ToString();
                    }

                    this.dgvDrugDetailList.Focus();
                    _salesDrugType = selForm.salesDrugType;
                    SetGridColumnVisible();
                }
                else
                {
                    MessageBox.Show("请选择采购商的信息！！！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加订单明细信息失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        /// <summary>
        /// /// 打开选择采购商的画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPurchase_DropDown(object sender, EventArgs e)
        {
            try
            {
                FormPurchaseSelector form = new FormPurchaseSelector();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _purchaseUnit = form.Result;
                    this.cmbPurchase.DataSource = new List<PurchaseUnit> { _purchaseUnit };
                    this.cmbPurchase.DisplayMember = "Code";
                    this.cmbPurchase.ValueMember = "ID";
                    if (this.txtPurchaseName.Text != form.Result.Name)
                    {
                        _drugInventoryRecordlList.Clear();
                        this.dgvDrugDetailList.DataSource = null;
                        this.newList = null;
                    }
                    this.txtPurchaseName.Text = form.Result.Name;
                    this.btnDetailAdd_Click(sender, e);
                    this.Bcms.Pid = this._purchaseUnit.Id; //变更购货商后，右键查询该购货商基础信息
                }
                this.dgvDrugDetailList.Focus();


            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("打开采购商选择框失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///  构造订单实例
        /// </summary>
        private void GetSalesOrderInstance()
        {
            if (_operation == FormOperation.Add)
            {
                if (_salesOrder == null)
                    _salesOrder = new SalesOrder();

                _salesOrder.Id = Guid.NewGuid();

                _salesOrder.OrderStatusValue = (int)BugsBox.Pharmacy.Models.OrderStatus.Waitting;
                _salesOrder.CreateTime = DateTime.Now;
                _salesOrder.CreateUserId = AppClientContext.CurrentUser.Id;
                _salesOrder.IsInvoice = this.checkBox1.Checked;
            }
            _salesOrder.Description = txtRemark.Text;
            _salesOrder.PurchaseUnitId = (Guid)this.cmbPurchase.SelectedValue;
            _salesOrder.PickUpGoodTypeValue = this.cmbPickUpGoods.SelectedIndex;
            if (_operation == FormOperation.Add)
            {
                _salesOrder.PurchaseUnitMan = cmbPurchaser.Text;

                if (cmbPurchaser.SelectedValue != null)
                    _salesOrder.PurchaseUnitManID = (Guid)cmbPurchaser.SelectedValue;

                _salesOrder.SaleDate = this.dtSalesDate.Value;
                _salesOrder.SalerName = this.txtSalesManName.Text;
            }
            _salesOrder.TotalMoney = decimal.Parse(this.txtTotalMoney.Text);
        }

        /// <summary>
        ///  初始化页面控件
        /// </summary>
        private void InitControl()
        {
            this.dgvDrugDetailList.AutoGenerateColumns = false;
            SetGridColumnVisible();
            string msg = string.Empty;
            userList = PharmacyDatabaseService.GetAllUsers(out msg).ToList();
            Guid roleGuid = this.PharmacyDatabaseService.AllRoles(out msg).Where(r => r.Name.Contains(_salerRoleName)).FirstOrDefault().Id;
            List<RoleWithUser> RoleWList = PharmacyDatabaseService.AllRoleWithUsers(out msg).Where(r => r.RoleId.Equals(roleGuid)).ToList();
            var u = from i in RoleWList join k in userList on i.UserId equals k.Id select k;
            userList = u.ToList();

            //客户采购员初始化
            purchaseUnitBuyerList = new List<PurchaseUnitBuyer>();
            purchaseUnitBuyerList.Insert(0, new PurchaseUnitBuyer());
            purchaseUnitBuyerList = PharmacyDatabaseService.AllPurchaseUnitBuyers(out msg).ToList();

            if (_salesOrder != null)
            {
                this.Text = this._salesOrder.OrderStatusValue >= (int)OrderStatus.Approved ? "订单销售记录" : "销售订单编辑";

                var o = PharmacyDatabaseService.GetOutInventoryByOrderID(out msg, this._salesOrder.Id);
                if (o != null)
                {
                    if (o.Count() > 0)
                    {
                        this.tsbtnOutInventory.Enabled = false;
                    }
                }
            }
            //提货方式初始化
            this.cmbPickUpGoods.DataSource = Utility.CreateComboboxList<PickUpGoodType>(true);
            this.cmbPickUpGoods.DisplayMember = "Name";
            this.cmbPickUpGoods.ValueMember = "ID";

            if (_operation == FormOperation.Add)
            {
                //销售员初始化
                User userNull = new User();
                userList.Insert(0, userNull);
                this.cmbSalesMan.DataSource = userList;
                this.cmbSalesMan.DisplayMember = "Account";
                this.cmbSalesMan.ValueMember = "ID";
                this.cmbSalesMan.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbSalesMan.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmbSalesMan.SelectedValue = (User)userList.FirstOrDefault();
                //销售药品类型初始化
                this.cmbSalesType.DataSource = Utility.CreateComboboxList<SalesDrugType>(true);
                this.cmbSalesType.DisplayMember = "Name";
                this.cmbSalesType.ValueMember = "ID";

                this.btnDetailAdd.Enabled = true;

                this.lblReceiver.Visible = false;
                this.txtReceiverMan.Visible = false;

                string employeeName = string.Empty;

                this.lblCreateDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

                this.lblOrderNo.Text = string.Empty;
                this.lblOrderStatus.Text = "新订单";
                this.lblCreater.Text = AppClientContext.CurrentUser.Employee.Name;
                this.UpdateBtnEnabled(OrderStatus.None);
                cmbPickUpGoods.SelectedItem = PickUpGoodType.Delivered;
                #region 显示是否开具发票
                if (_IsInvoice)
                    this.checkBox1.Visible = true;
                #endregion
            }
            else
            {
                this.btnDetailAdd.Visible = true;
                this.tsbtnSubmit.Enabled = false;
                if (_salesOrder.OrderStatusValue != (int)OrderStatus.Waitting)
                    this.tsbtnSave.Enabled = true;
                else
                    this.tsbtnSave.Enabled = false;

                _purchaseUnit = PharmacyDatabaseService.GetPurchaseUnit(out msg, _salesOrder.PurchaseUnitId);

                this.lblOrderNo.Text = _salesOrder.OrderCode;
                this.lblCreateDate.Text = _salesOrder.CreateTime.Date.ToString("yyyy-MM-dd");
                this.lblOrderStatus.Text = Utility.getEnumTypeDisplayName<BugsBox.Pharmacy.Models.OrderStatus>((BugsBox.Pharmacy.Models.OrderStatus)(_salesOrder.OrderStatusValue));
                this.cmbSalesMan.Text = _salesOrder.SalerName;
                this.txtSalesManName.Text = _salesOrder.SalerName;
                List<PurchaseUnit> pu = new List<PurchaseUnit>();
                pu.Add(_purchaseUnit);
                this.cmbPurchase.DataSource = pu;
                this.cmbPurchase.ValueMember = "id";
                this.cmbPurchase.DisplayMember = "code";
                this.cmbPurchase.SelectedText = _purchaseUnit.Code;
                this.cmbPurchase.SelectedIndex = 0;
                this.txtPurchaseName.Text = _purchaseUnit.Name;
                this.txtTotalMoney.Text = _salesOrder.SalesOrderDetails.Where(r => r.Deleted == false).Sum(r => r.Amount * r.ActualUnitPrice).ToString();
                this.dtSalesDate.Value = _salesOrder.SaleDate;
                this.txtRemark.Text = _salesOrder.Description;
                this.cmbPurchaser.Text = _salesOrder.PurchaseUnitMan;
                this.cmbSalesType.Text = Utility.getEnumTypeDisplayName<SalesDrugType>((SalesDrugType)(_salesOrder.SalesDrugTypeValue));
                this.cmbPickUpGoods.SelectedIndex = _salesOrder.PickUpGoodTypeValue;
                SetReceiverVisible(_salesOrder.PickUpGoodType);

                User user = userList.Where(p => p.Id == _salesOrder.CreateUserId).FirstOrDefault();
                if (user != null)
                    this.lblCreater.Text = user.Employee.Name;

                var listSD = _salesOrder.SalesOrderDetails;
                listSD = listSD.Where(r => r.Deleted == false && r.Amount > 0).OrderBy(r => r.Index).ToList();
                if (listSD.Count == 0) this.dgvDrugDetailList.DataSource = null;
                else
                {
                    this.dgvDrugDetailList.DataSource = listSD.ToList();
                    _drugInventoryRecordlList = PharmacyDatabaseService.GetDrugInventoryRecordBySalesOrderId(_salesOrder.Id, out msg).ToList();

                    if (this._drugInventoryRecordlList.Count(r => r.DrugInfo.BusinessScopeCode.Contains("医疗器械")) == this._drugInventoryRecordlList.Count)
                    {
                        this.GoodsType = GoodsTypeClass.医疗器械;
                    }

                    if (_drugInventoryRecordlList != null)
                    {
                        _IsChinese = _drugInventoryRecordlList.Any(r => r.DrugInfo.BusinessScopeCode.Contains("中药材") || r.DrugInfo.BusinessScopeCode.Contains("中药饮片"));
                        _salesDrugType = _IsChinese ? SalesDrugType.ChineseDrug : SalesDrugType.Drug;
                        SetGridColumnVisible();
                        toolStripButton4.Visible = _IsChinese;
                        tsbtnPrint.Visible = !_IsChinese;
                    }
                }

                this.UpdateBtnEnabled((OrderStatus)_salesOrder.OrderStatusValue);
                this.cmbPurchase.DropDown -= this.cmbPurchase_DropDown;
            }
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (_salesOrder != null)
                {
                    FormCancelOrderConfirm form = new FormCancelOrderConfirm();
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        string msg = string.Empty;
                        _salesOrder.CancelTime = DateTime.Now;
                        _salesOrder.CancelUserID = AppClientContext.CurrentUser.Id;
                        _salesOrder.CancelReason = form.Reason;
                        _salesOrder.OrderCancelCode = ucbcSalesOrderCancel.GenarateCode();
                        _salesOrder.OrderStatusValue = (int)BugsBox.Pharmacy.Models.OrderStatus.Canceled;
                        msg = PharmacyDatabaseService.CancelSalesOrder(_salesOrder);
                        if (msg.Length > 0)
                            MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            this.Close();

                        this.UpdateBtnEnabled((OrderStatus)_salesOrder.OrderStatusValue);
                        this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "取消销售单：" + _salesOrder.OrderCode);
                    }
                }
                else
                {
                    MessageBox.Show("没有可取消的订单！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("销售订单取消操作失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnSubmit_Click(object sender, EventArgs e)
        {
            this.submit();
        }

        public void submit()
        {
            this.dgvDrugDetailList.EndEdit();
            if (this.dgvDrugDetailList.Rows.Count <= 0) return;

            foreach (DataGridViewRow r in this.dgvDrugDetailList.Rows)
            {
                if (Convert.ToDecimal(r.Cells["数量"].Value) <= 0m || r.Cells["数量"].Value == null)
                {
                    MessageBox.Show("销售数量填写有误，请检查！");
                    r.Cells["数量"].Selected = true;
                    this.dgvDrugDetailList.CurrentCell = r.Cells["数量"];
                    this.dgvDrugDetailList.BeginEdit(true);
                    return;
                }
                if (Convert.ToDecimal(r.Cells["销售单价"].Value) <= 0m || r.Cells["销售单价"].Value == null)
                {
                    MessageBox.Show("销售单价填写有误，请检查！");
                    r.Cells["销售单价"].Selected = true;
                    this.dgvDrugDetailList.CurrentCell = r.Cells["销售单价"];
                    this.dgvDrugDetailList.BeginEdit(true);
                    return;
                }
            }

            if (cmbSalesMan.SelectedValue == null)
            {
                MessageBox.Show("请选择销售员！");
                cmbSalesMan.Focus();
                return;
            }

            if (this.cmbPickUpGoods.SelectedValue == null)
            {
                MessageBox.Show("请选择提货方式！");
                cmbPickUpGoods.Focus();
                return;
            }


            try
            {
                if (MessageBox.Show("确定要提交吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (this.dgvDrugDetailList.CurrentCell.IsInEditMode)
                        dgvDrugDetailList.EndEdit();
                    GetSalesOrderInstance();

                    _salesOrder.SalesOrderDetails = (dgvDrugDetailList.DataSource as List<SalesOrderDetail>).ToArray();
                    foreach (SalesOrderDetail sod in _salesOrder.SalesOrderDetails)
                    {
                        sod.SalesOrderID = _salesOrder.Id;
                        sod.CreateUserId = AppClientContext.CurrentUser.Id;
                    }

                    this.msg = PharmacyDatabaseService.AddSalesOrderAndDetails(_salesOrder);
                    if (msg.Length > 0)
                        MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        _salesOrder = this.PharmacyDatabaseService.GetSalesOrder(out msg, _salesOrder.Id);
                        MessageBox.Show("订单号：" + _salesOrder.OrderCode);
                        this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "成功新建销售记录成功：" + _salesOrder.OrderCode);
                        this.Close();
                    }

                    this.UpdateBtnEnabled(OrderStatus.Waitting);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("销售订单提交操作失败！！！" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "成功新建销售记录失败");
                Log.Error(ex);
            }
        }
        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnBalance_Click(object sender, EventArgs e)
        {
            try
            {
                if (_salesOrder != null)
                {
                    try
                    {
                        FormPayConfirm form = new FormPayConfirm(_salesOrder.Id);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            string msg = string.Empty;
                            _salesOrder.OrderStatusValue = (int)BugsBox.Pharmacy.Models.OrderStatus.Banlaced;

                            _salesOrder.BalanceTime = DateTime.Now;

                            if (((DateTime)_salesOrder.BalanceTime).Date < _salesOrder.CreateTime.Date)
                            {
                                MessageBox.Show("您的结算时间小于销售单创建日期，请检查并修改您的电脑系统时间！");
                                return;
                            }

                            _salesOrder.BalanceUserID = AppClientContext.CurrentUser.Id;
                            _salesOrder.BalanceReason = form.PayMemo;
                            _salesOrder.payMentMethodID = form.PayForms;
                            _salesOrder.OrderBalanceCode = ucbcSalesOrderBalance.GenarateCode();
                            PharmacyDatabaseService.SaveSalesOrder(out msg, _salesOrder);
                            if (msg.Length > 0)
                                MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                            {
                                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "成功结算销售记录成功：" + _salesOrder.OrderCode);

                                if (this.SalePriceControlRuleModel.SalesOrderPrintRuleValue == EnumSalesOrderPrintRule.销售单结算后打印)
                                {
                                    var prt = MessageBox.Show("结算成功！需要打印本单据吗？", "提示", MessageBoxButtons.OKCancel);
                                    if (prt == System.Windows.Forms.DialogResult.OK)
                                    {
                                        if (this._IsChinese)
                                            this.tsbtnPrint_Click(this.toolStripButton4, e);
                                        else
                                        {
                                            this.tsbtnPrint_Click(this.tsbtnPrint, e);
                                        }
                                    }

                                }
                                this.Close();
                            }
                            this.UpdateBtnEnabled(OrderStatus.Banlaced);
                            this.IsBalanced = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("没有可以结算的订单！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("结算操作失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        /// <summary>
        /// 出库处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnOutInventory_Click(object sender, EventArgs e)
        {
            try
            {
                if (_salesOrder != null)
                {
                    FormOutInventory form = new FormOutInventory(_salesOrder.Id);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("没有可出库的订单！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("拣货操作失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        /// <summary>
        /// 单元格编辑完成触发 数量，金额变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDrugDetailList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = dgvDrugDetailList.Columns[e.ColumnIndex].Name;
            var cellVallue = dgvDrugDetailList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            if (cellVallue == null) { MessageBox.Show("请填写信息！"); return; }

            List<SalesOrderDetail> newList = dgvDrugDetailList.DataSource as List<SalesOrderDetail>;

            switch (columnName)
            {
                case "销售单价":
                    SalesOrderDetail sod = this.dgvDrugDetailList.CurrentRow.DataBoundItem as SalesOrderDetail;
                    decimal unitPrice = sod.UnitPrice;
                    decimal purchasePrice = sod.PurchasePrice;

                    //定价控制，不得低于最低销售价
                    var druginv = this._drugInventoryRecordlList.Single(r => r.Id == sod.DrugInventoryRecordID);
                    if (sod.ActualUnitPrice < druginv.DrugInfo.LowSalePrice)
                    {
                        MessageBox.Show("您定义的销售价格小于公司所定制的最低销售价格：" + druginv.DrugInfo.LowSalePrice + "，请修改");
                        sod.ActualUnitPrice = druginv.DrugInfo.LowSalePrice;
                        return;
                    }

                    if (this.SalePriceControlRuleModel.RuleType == (int)Models.SalePriceControlEnum.可低于采购价)//庄子药业定价方式
                    {
                        if (sod.ActualUnitPrice > sod.UnitPrice * 3)
                        {
                            MessageBox.Show("您订的价格超过采购价三倍，是否填错了？");
                        }
                        if (sod.ActualUnitPrice < sod.UnitPrice)
                        {
                            MessageBox.Show("您订的价格低于进价，是否填错了？");
                            if (sod.ActualUnitPrice == 0m)
                            {
                                MessageBox.Show("您订的价格为0，是否填错了？");
                            }
                        }
                    }
                    if (this.SalePriceControlRuleModel.RuleType == (int)Models.SalePriceControlEnum.不低于采购价)//蒙城药材公司定价方式
                    {
                        if (sod.ActualUnitPrice > sod.PurchasePrice * 3)
                        {
                            MessageBox.Show("您定义的价格超过采购价三倍，是否填错了？");
                            sod.ActualUnitPrice = sod.UnitPrice;
                        }

                        if (sod.UnitPrice > sod.ActualUnitPrice)
                        {
                            MessageBox.Show("您定义的价格低于采购价，是否填错了？");
                            sod.ActualUnitPrice = sod.UnitPrice;
                        }
                    }
                    if (this.SalePriceControlRuleModel.RuleType == (int)Models.SalePriceControlEnum.不高于最高定价)//合肥富申定价方式
                    {
                        if (sod.UnitPrice < sod.ActualUnitPrice)
                        {
                            MessageBox.Show("您所设定的销售价格超过了限价标准，是否填错了？");
                            sod.ActualUnitPrice = sod.PurchasePrice;
                        }
                        if (sod.ActualUnitPrice < sod.PurchasePrice)
                        {
                            MessageBox.Show("您所设订的价格低于采购价了");
                        }
                    }

                    //decimal price = newList[e.RowIndex].Amount * newList[e.RowIndex].ActualUnitPrice;
                    //dgvDrugDetailList.Rows[e.RowIndex].Cells["金额"].Value = price;
                    sod.Price = sod.ActualUnitPrice * sod.Amount;

                    this.txtTotalMoney.Text = newList.Select(p => p.Price).Sum().ToString();

                    break;

                case "数量":
                    var c = this.dgvDrugDetailList.Rows[e.RowIndex].DataBoundItem as Models.SalesOrderDetail;
                    decimal canSaleNum = _drugInventoryRecordlList.Single(r => r.Id == c.DrugInventoryRecordID).CanSaleNum;

                    if (_operation == FormOperation.Empty)
                    {
                        var u = _listsod.Where(r => r.id == c.Id).FirstOrDefault();
                        if (u != null)
                        {
                            decimal saledNum = u.amount;
                            canSaleNum = canSaleNum + saledNum;
                        }
                    }
                    if (Convert.ToDecimal(cellVallue) <= canSaleNum)
                    {
                        newList[e.RowIndex].Amount = Convert.ToDecimal(cellVallue);
                        decimal currprice = newList[e.RowIndex].Amount * newList[e.RowIndex].ActualUnitPrice;
                        dgvDrugDetailList.Rows[e.RowIndex].Cells["金额"].Value = currprice;
                        this.txtTotalMoney.Text = newList.Select(p => p.Price).Sum().ToString();
                    }
                    else
                    {
                        MessageBox.Show("数量超过可用库存！！！\n该药品现可销售数量为：" + canSaleNum, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvDrugDetailList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0m;
                    }
                    break;

                case "说明":
                    newList[e.RowIndex].Description = cellVallue.ToString();
                    break;


            }

            #region 冲差价
            if (_isRefund)
            {
                var d = (SalesOrderDetail)this.dgvDrugDetailList.Rows[e.RowIndex].DataBoundItem;
                decimal p = 0m;
                if (!decimal.TryParse(this.dgvDrugDetailList.Rows[e.RowIndex].Cells[Column1.Name].Value.ToString(), out p))
                {
                    MessageBox.Show("请输入数字！");
                    this.dgvDrugDetailList.Rows[e.RowIndex].Cells[Column1.Name].Value = d.ActualUnitPrice;
                }
                if (this.Column1.Name == this.dgvDrugDetailList.CurrentCell.OwningColumn.Name)
                {
                    d.ChangeAmount = p - d.ActualUnitPrice;
                    this.dgvDrugDetailList.Rows[e.RowIndex].Cells[Column2.Name].Value = d.Amount * p;
                }
                this.dgvDrugDetailList.Refresh();
            }
            #endregion

        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnAccept_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow sd in this.dgvDrugDetailList.Rows)
            {
                SalesOrderDetail sod = sd.DataBoundItem as SalesOrderDetail;
                if (sod.ActualUnitPrice < 0)
                {
                    MessageBox.Show("修改的销售价格不能低于0，请检查！");
                    this.dgvDrugDetailList.CurrentCell = sd.Cells[销售单价.Name];
                    this.dgvDrugDetailList.BeginEdit(true);
                    return;
                }
            }

            try
            {
                if (_salesOrder != null)
                {

                    if (MessageBox.Show("确定要审核提交吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            string msg = string.Empty;

                            FormSaleOrderApproval f = new FormSaleOrderApproval(_salesOrder.Id);
                            f.ShowDialog();

                            if (msg.Length > 0)
                                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                                {
                                    if (this.SalePriceControlRuleModel.SalesOrderPrintRuleValue == EnumSalesOrderPrintRule.销售单审核后打印)
                                    {
                                        if (MessageBox.Show("需要打印单据吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                                        {
                                            _salesOrder.OrderStatus = OrderStatus.Approved;
                                            if (this._IsChinese)
                                            {
                                                this.tsbtnPrint_Click(this.toolStripButton4, e);
                                            }
                                            else
                                            {
                                                this.tsbtnPrint_Click(this.tsbtnPrint, e);
                                            }
                                        }
                                    }
                                }

                                this.Close();
                                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行销售审批记录成功");
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex);
                            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        this.UpdateBtnEnabled(OrderStatus.Approved);
                    }
                }
                else
                {
                    MessageBox.Show("没有可以提交的订单！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("订单审核失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        /// <summary>
        /// 保存订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            this.dgvDrugDetailList.EndEdit();
            if (this.dgvDrugDetailList.Rows.Count <= 0)
            {
                MessageBox.Show("药品记录已被全部删除，不能保存！");
                return;
            }
            this.dgvDrugDetailList.EndEdit();
            foreach (DataGridViewRow r in this.dgvDrugDetailList.Rows)
            {
                if (Convert.ToDecimal(r.Cells["数量"].Value) == 0m || r.Cells["数量"].Value == null)
                {
                    MessageBox.Show("销售数量填写有误，请检查！");
                    r.Cells["数量"].Selected = true;
                    this.dgvDrugDetailList.CurrentCell = r.Cells["数量"];
                    this.dgvDrugDetailList.BeginEdit(true);
                    return;
                }
                if (Convert.ToDecimal(r.Cells["销售单价"].Value) == 0m || r.Cells["销售单价"].Value == null)
                {
                    MessageBox.Show("销售单价填写有误，请检查！");
                    r.Cells["销售单价"].Selected = true;
                    this.dgvDrugDetailList.CurrentCell = r.Cells["销售单价"];
                    this.dgvDrugDetailList.BeginEdit(true);
                    return;
                }
            }

            try
            {
                if (MessageBox.Show("确定要保存吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    GetSalesOrderInstance();
                    _salesOrder.SalesOrderDetails = (this.dgvDrugDetailList.DataSource as List<SalesOrderDetail>).ToArray();
                    _salesOrder.TotalMoney = _salesOrder.SalesOrderDetails.Sum(r => r.ActualUnitPrice * r.Amount);
                    foreach (SalesOrderDetail sod in _salesOrder.SalesOrderDetails)
                    {
                        sod.SalesOrderID = _salesOrder.Id;

                    }

                    msg = PharmacyDatabaseService.ModifySalesOrderAndDetails(_salesOrder);
                    if (msg.Length > 0)
                        MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "成功更新一条销售记录成功：" + _salesOrder.OrderCode);
                        this.Close();
                    }

                    this.UpdateBtnEnabled(OrderStatus.Waitting);
                    MessageBox.Show("修改已保存");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("订单保存操作失败！！！" + msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        /// <summary>
        /// 更新画面按钮状态
        /// </summary>
        /// <param name="status"></param>
        private void UpdateBtnEnabled(OrderStatus status)
        {
            if (_IsReadOnly)
            {
                this.tsbtnSubmit.Visible = false;
                this.tsbtnSave.Visible = false;
                this.tsbtnCancel.Visible = false;
                this.tsbtnAccept.Visible = false;
                this.tsbtnBalance.Visible = false;
                this.toolStripButton5.Visible = false;
                this.tsbtnOutInventory.Visible = false;
            }
            else
            {
                this.tsbtnSubmit.Enabled = false;
                this.tsbtnSave.Enabled = false;
                this.tsbtnCancel.Enabled = false;
                this.tsbtnAccept.Enabled = false;
                this.tsbtnBalance.Enabled = false;
                this.toolStripButton5.Enabled = false;
                this.tsbtnOutInventory.Enabled = false;

                switch (status)
                {
                    case OrderStatus.None:
                        this.tsbtnSubmit.Enabled = true;
                        this.label1.Visible = true;
                        this.label1.Left = this.invoicer.Left + this.invoicer.Width + 20;
                        this.label1.Top = dtSalesDate.Top;
                        break;
                    case OrderStatus.Waitting:
                        this.tsbtnSave.Enabled = true;
                        this.tsbtnCancel.Enabled = true;
                        this.tsbtnAccept.Enabled = true;
                        break;
                    case OrderStatus.Approved:
                        this.tsbtnBalance.Enabled = true;
                        this.toolStripButton5.Enabled = true;
                        this.label1.Visible = false;
                        this.btnDetailAdd.Visible = false;
                        break;
                    case OrderStatus.Banlaced:
                    case OrderStatus.Outing:
                        this.tsbtnOutInventory.Enabled = true;
                        this.label1.Visible = false;

                        this.btnDetailAdd.Visible = false;
                        break;
                }
            }
        }

        private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            this.IsSpecial = this._drugInventoryRecordlList.Any(r => r.DrugInfo.IsSpecialDrugCategory);

            try
            {
                if (_salesOrder != null)
                {
                    DsSalesOrder ds = new DsSalesOrder();

                    ds.ExtendedProperties.Clear();
                    ds.Tables.Clear();
                    if (_salesOrder.OrderStatus < OrderStatus.Approved)
                    {
                        MessageBox.Show("该定单未审核，暂无法打印！");
                        return;
                    }
                    //结算前打印的结算方式id为空00000,所以默认为现金方式结算,否则按结算员结算时选择结算方式提交.
                    var payment = this.PharmacyDatabaseService.GetPaymentMethod(out msg, _salesOrder.payMentMethodID);
                    string pay = payment == null ? "现金" : payment.Name;
                    string addr = _purchaseUnit.ReceiveAddress;
                    ds.ExtendedProperties.Add("ReportTitle", PharmacyClientConfig.Config.Store.Name);
                    ds.ExtendedProperties.Add("PurchaseUnit", txtPurchaseName.Text); //购货单位
                    ds.ExtendedProperties.Add("OrderCode", _salesOrder.OrderCode); //单据号
                    ds.ExtendedProperties.Add("Date", _salesOrder.CreateTime.ToString("yyyy-MM-dd HH:mm")); //记录建立日期
                    ds.ExtendedProperties.Add("Addr", addr);
                    ds.ExtendedProperties.Add("Pay", pay);
                    ds.ExtendedProperties.Add("ComAddr", PharmacyClientConfig.Config.Store.Address);//公司地址                    
                    string[] tel = PharmacyClientConfig.Config.Store.Tel.Split(',');//服务器端需要设置两个电话,用英文半角符号‘,’隔开
                    string tel1 = "";
                    string tel2 = " ";
                    tel1 = tel[0];
                    if (tel.Length > 1)
                    {
                        tel2 = tel[1];
                    }
                    ds.ExtendedProperties.Add("ComTel", tel1);//公司电话
                    ds.ExtendedProperties.Add("CusTel", tel2);//投诉电话
                    string invoicer = this.PharmacyDatabaseService.GetEmployeeByUserId(out msg, _salesOrder.CreateUserId).Name;

                    ds.ExtendedProperties.Add("Invoicer", invoicer);
                    ds.ExtendedProperties.Add("Saler", _salesOrder.SalerName);

                    //string FirstChecker = BugsBoxApplication.Instance.FirstChecker;
                    //string SecondChecker = BugsBoxApplication.Instance.SecondChecker;


                    string Checker = " ";
                    if (BugsBoxApplication.Instance.Config.ReportConfig.DisplayChecker)
                    {
                        if (this.IsSpecial)
                        {
                            Checker = this.SalePriceControlRuleModel.SaleChecker.SpecialDrugFirstCheckerName + " " + this.SalePriceControlRuleModel.SaleChecker.SpacialDrugSecondCheckerName;
                        }
                        else
                        {
                            Checker = this.SalePriceControlRuleModel.SaleChecker.OrdinaryCheckerName;
                        }

                    }
                    ds.ExtendedProperties.Add("Checker", Checker);
                    string InventoryKeeper = this.SalePriceControlRuleModel.InventoryKeeperName;
                    if (string.IsNullOrEmpty(InventoryKeeper))
                    {
                        MessageBox.Show("库管员没有配置，请在salepriceType.xml文件中配置。");
                        return;
                    }
                    if (!BugsBoxApplication.Instance.Config.ReportConfig.DisplayKeeper)
                    {
                        InventoryKeeper = " ";
                    }
                    ds.ExtendedProperties.Add("inventoryKeeper", InventoryKeeper);

                    string TransportMethod = cmbPickUpGoods.SelectedItem.ToString();
                    ds.ExtendedProperties.Add("TransportMethod", TransportMethod);

                    DsSalesOrder.tableDataTable OrderDetailTable = new DsSalesOrder.tableDataTable();
                    List<SalesOrderDetail> prtDetail = _salesOrder.SalesOrderDetails.Where(r => r.Deleted == false).OrderBy(r => r.DictionaryDosageCode).ToList();
                    if (this.SalePriceControlRuleModel.EnumSalesOrderSortWhenPrintValue == EnumSalesOrderSortWhenPrint.按照品名首字母排序)
                    {
                        prtDetail = prtDetail.OrderBy(r => r.productName).ToList();
                    }
                    if (this.SalePriceControlRuleModel.EnumSalesOrderSortWhenPrintValue == EnumSalesOrderSortWhenPrint.按开单时排序)
                    {
                        prtDetail = prtDetail.OrderBy(r => r.Index).ToList();
                    }

                    var inr = this._drugInventoryRecordlList;

                    #region 多批次合并打印
                    //如果含有“（”多批次标记
                    if (prtDetail.Where(r => r.BatchNumber.LastIndexOf("(") > 1).Count() > 0)
                    {
                        foreach (var i in prtDetail)
                        {
                            int idx = i.BatchNumber.LastIndexOf("(");
                            i.BatchNumber = idx > 1 ? i.BatchNumber.Substring(0, idx) : i.BatchNumber;
                        }
                        var re = from i in prtDetail
                                 group i by new { i.productName, i.ActualUnitPrice, i.PurchasePrice, i.DictionaryDosageCode, i.BatchNumber, i.FactoryName, i.MeasurementUnit, i.SpecificationCode } into g
                                 select new SalesOrderDetail
                                 {
                                     ActualUnitPrice = g.FirstOrDefault().ActualUnitPrice,
                                     SpecificationCode = g.FirstOrDefault().SpecificationCode,
                                     MeasurementUnit = g.FirstOrDefault().MeasurementUnit,
                                     FactoryName = g.FirstOrDefault().FactoryName,
                                     DictionaryDosageCode = g.FirstOrDefault().DictionaryDosageCode,
                                     PurchasePrice = g.FirstOrDefault().PurchasePrice,
                                     Price = g.Sum(r => r.Price),
                                     productName = g.FirstOrDefault().productName,
                                     Amount = g.Sum(r => r.Amount),
                                     BatchNumber = g.FirstOrDefault().BatchNumber,
                                     ChangeAmount = g.FirstOrDefault().ChangeAmount,
                                     CreateTime = g.FirstOrDefault().CreateTime,
                                     CreateUserId = g.FirstOrDefault().CreateUserId,
                                     Deleted = g.FirstOrDefault().Deleted,
                                     Description = g.FirstOrDefault().Description,
                                     DrugInventoryRecordID = g.FirstOrDefault().DrugInventoryRecordID,
                                     Id = g.FirstOrDefault().Id,
                                     Index = g.FirstOrDefault().Index,
                                     Origin = g.FirstOrDefault().Origin,
                                     OutAmount = g.FirstOrDefault().OutAmount,
                                     OutValidDate = g.FirstOrDefault().OutValidDate,
                                     productCode = g.FirstOrDefault().productCode,
                                     PruductDate = g.FirstOrDefault().PruductDate,
                                     ReturnAmount = g.FirstOrDefault().ReturnAmount,
                                     UnitPrice = g.FirstOrDefault().UnitPrice,
                                     UpdateTime = g.FirstOrDefault().UpdateTime
                                 };

                        prtDetail = re.ToList();
                    }

                    #endregion


                    foreach (SalesOrderDetail detail in prtDetail.Where(r => r.Deleted == false && r.Amount > 0))
                    {
                        string part = detail.productName;
                        string _partType = detail.DictionaryDosageCode;
                        string specialCode = detail.SpecificationCode;
                        string productUnit = detail.FactoryName;
                        string Origin = detail.Origin;//产地
                        //detail.PruductDate
                        string batchNumber = detail.BatchNumber;

                        string ValidDate = detail.OutValidDate.ToString();
                        string unit = detail.MeasurementUnit;
                        decimal qty = detail.Amount;
                        decimal unitPrice = detail.ActualUnitPrice;
                        decimal price = qty * unitPrice;
                        string Quanlity = detail.Description;
                       
                        string PermitNumber = inr.Where(r => r.Id == detail.DrugInventoryRecordID).FirstOrDefault().DrugInfo.LicensePermissionNumber;

                        if (this.GoodsType == GoodsTypeClass.医疗器械)
                        {
                            PermitNumber += "^" + inr.Where(r => r.Id == detail.DrugInventoryRecordID).FirstOrDefault().DrugInfo.InstEntProductLiscencePermitNumber;

                            PermitNumber += "^" + inr.Where(r => r.Id == detail.DrugInventoryRecordID).FirstOrDefault().DrugInfo.DrugStorageTypeCode;
                        }

                        OrderDetailTable.Rows.Add(new object[] { part, _partType, specialCode, productUnit, Origin, batchNumber, ValidDate, unit, qty, unitPrice, price, Quanlity, PermitNumber,detail.PruductDate });
                        OrderDetailTable.AcceptChanges();
                    }
                    ds.Tables.Add(OrderDetailTable);

                    if (((ToolStripButton)sender).Name == this.tsbtnPrint.Name)
                    {
                        if (this.GoodsType == GoodsTypeClass.药品)
                            using (PrintHelper printHelper = new PrintHelper("Reports\\RptSalesOrderList.rdlc", ds))
                            {
                                printHelper.Print();
                            }
                        if (this.GoodsType == GoodsTypeClass.医疗器械)
                            using (PrintHelper printHelper = new PrintHelper("Reports\\RptSalesOrderListYLQX.rdlc", ds))
                            {
                                printHelper.Print();
                            }
                    }
                    else
                    {
                        using (PrintHelper printHelper = new PrintHelper("Reports\\RptSalesOrderListCS.rdlc", ds))
                        {
                            printHelper.Print();
                        }
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "成功打印销售记录：" + _salesOrder.OrderCode);
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
        //打印5行空白单据模板
        private void PrintEmpty()
        {
            DsSalesOrder ds = new DsSalesOrder();

            ds.ExtendedProperties.Clear();
            ds.Tables.Clear();
            ds.ExtendedProperties.Add("ReportTitle", PharmacyClientConfig.Config.Store.Name);
            ds.ExtendedProperties.Add("PurchaseUnit", " "); //购货单位
            ds.ExtendedProperties.Add("OrderCode", " "); //单据号
            ds.ExtendedProperties.Add("Date", " "); //记录建立日期
            ds.ExtendedProperties.Add("Addr", " ");
            ds.ExtendedProperties.Add("Pay", " ");
            ds.ExtendedProperties.Add("ComAddr", " ");//公司地址 

            ds.ExtendedProperties.Add("ComTel", " ");//公司电话
            ds.ExtendedProperties.Add("CusTel", " ");//投诉电话
            ds.ExtendedProperties.Add("Invoicer", " ");
            ds.ExtendedProperties.Add("Saler", " ");
            ds.ExtendedProperties.Add("Checker", " ");
            ds.ExtendedProperties.Add("inventoryKeeper", " ");
            ds.ExtendedProperties.Add("TransportMethod", " ");
            DsSalesOrder.tableDataTable OrderDetailTable = new DsSalesOrder.tableDataTable();
            for (int i = 0; i < 5; i++)
            {
                string part = "";
                string _partType = "";
                string specialCode = "";
                string productUnit = "";
                string Origin = "";//产地

                string batchNumber = "";

                string ValidDate = "";
                string unit = "";
                decimal qty = 0;
                decimal unitPrice = 0;
                decimal price = 0;
                decimal Quanlity = 0;

                string PermitNumber = "";

                OrderDetailTable.Rows.Add(new object[] { part, _partType, specialCode, productUnit, Origin, batchNumber, ValidDate, unit, qty, unitPrice, price, Quanlity, PermitNumber });
                OrderDetailTable.AcceptChanges();
            }
            ds.Tables.Add(OrderDetailTable);

            using (PrintHelper printHelper = new PrintHelper("Reports\\RptSalesOrderListEmpty.rdlc", ds))
            {
                printHelper.Print();
            }
        }
        private void txtTotalMoney_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbSalesMan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbSalesMan.SelectedValue != null)
                {
                    Guid userId = (Guid)this.cmbSalesMan.SelectedValue;
                    User user = userList.Where(p => p.Id == userId).FirstOrDefault();
                    if (user != null)
                        this.txtSalesManName.Text = user.Employee.Name;
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void cmbPickUpGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbPickUpGoods.SelectedValue != null)
                {
                    SetReceiverVisible(EnumHelper<PickUpGoodType>.Parse(cmbPickUpGoods.SelectedValue.ToString()));
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void SetReceiverVisible(PickUpGoodType pickUpGoodType)
        {
            if (pickUpGoodType == PickUpGoodType.GetBySelf)
            {
                this.lblReceiver.Visible = true;
                this.txtReceiverMan.Visible = true;
            }
            else
            {
                this.lblReceiver.Visible = false;
                this.txtReceiverMan.Visible = false;
            }
        }

        private void cmbSalesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _salesDrugType = EnumHelper<SalesDrugType>.Parse(cmbSalesType.SelectedValue.ToString());
                SetGridColumnVisible();
                this.lblSalesType.Visible = false;
                this.cmbSalesType.Visible = false;
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// 定义GridView的显示列
        /// </summary>
        private void SetGridColumnVisible()
        {
            switch (salesDrugType)
            {
                case SalesDrugType.Drug:
                    dgvDrugDetailList.Columns["商品名称"].Visible = true;
                    dgvDrugDetailList.Columns["规格"].Visible = true;
                    dgvDrugDetailList.Columns["剂型"].Visible = true;
                    dgvDrugDetailList.Columns["批号"].Visible = true;
                    dgvDrugDetailList.Columns["有效期至"].Visible = true;
                    dgvDrugDetailList.Columns["生产厂商"].Visible = true;
                    dgvDrugDetailList.Columns["数量"].Visible = true;
                    dgvDrugDetailList.Columns["采购单价"].Visible = true;
                    dgvDrugDetailList.Columns["销售单价"].Visible = true;
                    dgvDrugDetailList.Columns["单位"].Visible = true;
                    dgvDrugDetailList.Columns["金额"].Visible = true;
                    dgvDrugDetailList.Columns["说明"].Visible = false;
                    dgvDrugDetailList.Columns["生产日期"].Visible = false;
                    break;
                case SalesDrugType.ChineseDrug:
                    dgvDrugDetailList.Columns["商品名称"].Visible = true;
                    dgvDrugDetailList.Columns["规格"].Visible = true;
                    dgvDrugDetailList.Columns["批号"].Visible = true;
                    dgvDrugDetailList.Columns["产地"].Visible = true;
                    dgvDrugDetailList.Columns["生产厂商"].Visible = true;
                    dgvDrugDetailList.Columns["数量"].Visible = true;
                    dgvDrugDetailList.Columns["采购单价"].Visible = true;
                    dgvDrugDetailList.Columns["销售单价"].Visible = true;
                    dgvDrugDetailList.Columns["单位"].Visible = true;
                    dgvDrugDetailList.Columns["金额"].Visible = true;
                    dgvDrugDetailList.Columns["说明"].Visible = false;
                    dgvDrugDetailList.Columns["生产日期"].Visible = false;
                    dgvDrugDetailList.Columns["有效期至"].Visible = false;
                    break;
                case SalesDrugType.ChineseDrugDrink:
                    dgvDrugDetailList.Columns["商品名称"].Visible = true;
                    dgvDrugDetailList.Columns["规格"].Visible = true;
                    dgvDrugDetailList.Columns["产地"].Visible = true;
                    dgvDrugDetailList.Columns["批号"].Visible = true;
                    dgvDrugDetailList.Columns["生产厂商"].Visible = true;
                    dgvDrugDetailList.Columns["数量"].Visible = true;
                    dgvDrugDetailList.Columns["采购单价"].Visible = true;
                    dgvDrugDetailList.Columns["销售单价"].Visible = true;
                    dgvDrugDetailList.Columns["单位"].Visible = true;
                    dgvDrugDetailList.Columns["金额"].Visible = true;
                    dgvDrugDetailList.Columns["说明"].Visible = true;
                    break;
            }
        }

        private void cmbPurchase_TextChanged(object sender, EventArgs e)
        {
            if (cmbPurchase.Items.Count <= 0 || cmbPurchase.SelectedValue == null) return;
            if (purchaseUnitBuyerList == null) return;
            if (cmbPurchase.SelectedValue.GetType() == typeof(PurchaseUnit)) return;
            var p = from i in purchaseUnitBuyerList where i.PurchaseUnitId == (Guid)cmbPurchase.SelectedValue select i;
            this.cmbPurchaser.DataSource = p.ToList();
            this.cmbPurchaser.DisplayMember = "Name";
            this.cmbPurchaser.ValueMember = "ID";
        }

        private void cmbPurchase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPurchaseName_TextChanged(object sender, EventArgs e)
        {
            this.dgvDrugDetailList.DataSource = null;
        }

        private void dgvDrugDetailList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDrugDetailList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void dgvDrugDetailList_Validating(object sender, CancelEventArgs e)
        {

        }

        private void dgvDrugDetailList_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgvDrugDetailList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            string message = string.Empty;
            if (keyData == Keys.F6)
            {
                if (this.dgvDrugDetailList.SelectedCells.Count > 0)
                {
                    Guid InvID = newList[this.dgvDrugDetailList.SelectedCells[0].RowIndex].DrugInventoryRecordID;
                    DrugInventoryRecord diir = this.PharmacyDatabaseService.GetDrugInventoryRecord(out message, InvID);
                    Guid pinId = diir.PurchaseInInventeryOrderDetailId;

                    if (pinId != Guid.Empty)
                    {
                        Form_HistoryPurchase frm = new Form_HistoryPurchase(pinId);
                        frm.ShowDialog();
                        this.dgvDrugDetailList.Focus();
                    }
                }
                return true;
            }

            if (keyData == Keys.F5)
            {
                if (this.dgvDrugDetailList.SelectedCells.Count > 0)
                {
                    Guid InvID = newList[this.dgvDrugDetailList.SelectedCells[0].RowIndex].DrugInventoryRecordID;
                    DrugInventoryRecord diir = this.PharmacyDatabaseService.GetDrugInventoryRecord(out message, InvID);
                    Guid druginfoID = diir.DrugInfoId;

                    if (druginfoID != Guid.Empty)
                    {
                        Form_HistoryPurchase frm = new Form_HistoryPurchase(druginfoID, 1);
                        frm.ShowDialog();
                        this.dgvDrugDetailList.Focus();
                    }
                }
                return true;
            }

            if (keyData == (Keys.Shift | Keys.S))
            {
                this.submit();
                return true;
            }

            if (keyData == Keys.F2)
            {
                this.cmbSalesMan.Focus();
                return true;
            }

            if (keyData == (Keys.Alt | Keys.F))
            {
                if (this.dgvDrugDetailList.SelectedCells.Count > 0)
                {
                    Guid InvID = newList[this.dgvDrugDetailList.SelectedCells[0].RowIndex].DrugInventoryRecordID;
                    DrugInventoryRecord diir = this.PharmacyDatabaseService.GetDrugInventoryRecord(out message, InvID);
                    Guid druginfoID = diir.DrugInfoId;
                    if (diir.Id != Guid.Empty)
                    {
                        Form_HistoryPurchase frm = new Form_HistoryPurchase(druginfoID, 3);
                        frm.ShowDialog();
                        this.dgvDrugDetailList.Focus();
                    }
                }
                return true;
            }
            if (keyData == (Keys.Alt | Keys.D))
            {
                if (this.dgvDrugDetailList.SelectedCells.Count > 0)
                {
                    Guid InvID = newList[this.dgvDrugDetailList.SelectedCells[0].RowIndex].DrugInventoryRecordID;
                    DrugInventoryRecord diir = this.PharmacyDatabaseService.GetDrugInventoryRecord(out message, InvID);

                    if (diir.Id != Guid.Empty)
                    {
                        Form_HistoryPurchase frm = new Form_HistoryPurchase(diir.Id, 2);
                        frm.ShowDialog();
                        this.dgvDrugDetailList.Focus();
                    }
                }
                return true;
            }
            if (keyData == (Keys.Alt | Keys.E))
            {
                if (this.dgvDrugDetailList.SelectedCells.Count > 0)
                {
                    Guid InvID = newList[this.dgvDrugDetailList.SelectedCells[0].RowIndex].DrugInventoryRecordID;
                    DrugInventoryRecord diir = this.PharmacyDatabaseService.GetDrugInventoryRecord(out message, InvID);
                    if (diir.Id != Guid.Empty)
                    {
                        Form_HistoryPurchase frm = new Form_HistoryPurchase(diir.Id, 2, _purchaseUnit.Id);
                        frm.ShowDialog();
                        this.dgvDrugDetailList.Focus();
                    }
                }
                return true;
            }

            if (keyData == (Keys.Alt | Keys.S))
            {
                if (this.dgvDrugDetailList.SelectedCells.Count > 0)
                {
                    Guid InvID = newList[this.dgvDrugDetailList.SelectedCells[0].RowIndex].DrugInventoryRecordID;
                    DrugInventoryRecord diir = this.PharmacyDatabaseService.GetDrugInventoryRecord(out message, InvID);
                    Guid druginfoID = diir.DrugInfoId;
                    if (diir.Id != Guid.Empty)
                    {
                        Form_HistoryPurchase frm = new Form_HistoryPurchase(druginfoID, 3, _purchaseUnit.Id);
                        frm.ShowDialog();
                        this.dgvDrugDetailList.Focus();
                    }
                }
                return true;
            }

            if (keyData == (Keys.F12))
            {
                this.cmbPurchase.DroppedDown = false;
                this.cmbSalesMan.Focus();
                this.cmbSalesMan.SelectedText = "zhw";
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvDrugDetailList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("您输入的数据格式有误，请检查！");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要保存冲差价单吗？保存后不可更改，如需更改，报请管理员执行！", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;

            this.dgvDrugDetailList.EndEdit();

            _salesOrder.ReceivedMoney = _salesOrder.SalesOrderDetails.Where(r => r.Deleted == false).Sum(r => (r.ActualUnitPrice + r.ChangeAmount) * r.Amount);
            if (this.PharmacyDatabaseService.SaveSaleRefund(_salesOrder, out msg))
            {
                MessageBox.Show("冲差保存成功！");
            }
            else
            {
                MessageBox.Show("保存失败，请稍后再试！");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dgvDrugDetailList, "销售冲差价单(" + this._salesOrder.OrderCode + ")");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            try
            {
                if (_salesOrder != null)
                {
                    AppClient.UI.Reports.SaleOrderRefund ds = new Reports.SaleOrderRefund();
                    ds.ExtendedProperties.Clear();
                    ds.Tables.Clear();
                    if (_salesOrder.OrderStatus < OrderStatus.Approved)
                    {
                        MessageBox.Show("该定单未审核，暂无法打印！");
                        return;
                    }
                    string pay = this.PharmacyDatabaseService.GetPaymentMethod(out msg, _salesOrder.payMentMethodID).Name;
                    decimal RefundMoney = (_salesOrder.ReceivedMoney ?? 0m) - _salesOrder.TotalMoney;
                    string addr = PharmacyClientConfig.Config.Store.Address;
                    string tel = PharmacyClientConfig.Config.Store.Tel;
                    string Creater = BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Employee.Name;

                    ds.ExtendedProperties.Add("ReportTitle", PharmacyClientConfig.Config.Store.Name);
                    ds.ExtendedProperties.Add("PurchaseUnit", txtPurchaseName.Text); //购货单位
                    ds.ExtendedProperties.Add("OrderCode", _salesOrder.OrderCode); //单号
                    ds.ExtendedProperties.Add("Date", _salesOrder.CreateTime.ToString("yyyy-MM-dd hh:mm")); //记录建立日期                    
                    ds.ExtendedProperties.Add("RefundMoney", RefundMoney);
                    ds.ExtendedProperties.Add("Addr", addr);
                    ds.ExtendedProperties.Add("Tel", tel);
                    ds.ExtendedProperties.Add("Creator", Creater);
                    ds.ExtendedProperties.Add("Saler", _salesOrder.SalerName);

                    AppClient.UI.Reports.SaleOrderRefund.RefundTableDataTable OrderDetailTable = new Reports.SaleOrderRefund.RefundTableDataTable();

                    List<SalesOrderDetail> prtDetail = _salesOrder.SalesOrderDetails.OrderBy(r => r.DictionaryDosageCode).ToList();
                    foreach (SalesOrderDetail detail in prtDetail.Where(r => r.Deleted == false))
                    {
                        if (detail.ChangeAmount == 0) continue;
                        string part = detail.productName;
                        string _partType = detail.DictionaryDosageCode;
                        string specialCode = detail.SpecificationCode;
                        string productUnit = detail.FactoryName;
                        string Origin = detail.Origin;//产地
                        string batchNumber = detail.BatchNumber;
                        string PermitCode = detail.productCode;
                        string unit = detail.MeasurementUnit;
                        decimal qty = detail.Amount;
                        decimal unitPrice = detail.ActualUnitPrice;
                        decimal actualUnitPrice = detail.ActualUnitPrice + detail.ChangeAmount;
                        decimal OriginPrice = qty * unitPrice;
                        decimal actualPrice = qty * actualUnitPrice;
                        decimal diff = actualPrice - OriginPrice;
                        OrderDetailTable.Rows.Add(new object[] { part, _partType, specialCode, productUnit, batchNumber, PermitCode, unit, qty, unitPrice, actualUnitPrice, OriginPrice, actualPrice, diff });
                        OrderDetailTable.AcceptChanges();
                    }
                    ds.Tables.Add(OrderDetailTable);
                    using (PrintHelper printHelper = new PrintHelper("Reports\\RptSalesOrderRefundList.rdlc", ds))
                    {
                        printHelper.Print();
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "成功打印销售冲差记录：" + _salesOrder.OrderCode);
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

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.tsbtnPrint_Click(sender, e);
        }

        private DsSalesOrder printSet()
        {
            string msg = string.Empty;
            DsSalesOrder ds = new DsSalesOrder();
            ds.ExtendedProperties.Clear();
            ds.Tables.Clear();
            if (_salesOrder.OrderStatus < OrderStatus.Approved)
            {
                MessageBox.Show("该定单未审核，暂无法打印！");
                return null;
            }
            string pay = string.Empty;
            string addr = _purchaseUnit.ReceiveAddress;
            var payMethod = this.PharmacyDatabaseService.GetPaymentMethod(out msg, _salesOrder.payMentMethodID);
            if (payMethod == null)
            {
                MessageBox.Show("尚未结算，请结算后再打印！");
                return null;
            }
            else
            {
                pay = payMethod.Name;
            }

            ds.ExtendedProperties.Add("ReportTitle", PharmacyClientConfig.Config.Store.Name);
            ds.ExtendedProperties.Add("PurchaseUnit", txtPurchaseName.Text); //入库单单号
            ds.ExtendedProperties.Add("OrderCode", _salesOrder.OrderCode); //班次
            ds.ExtendedProperties.Add("Date", _salesOrder.CreateTime.ToString("yyyy-MM-dd hh:mm")); //记录建立日期
            ds.ExtendedProperties.Add("Addr", addr);
            ds.ExtendedProperties.Add("Pay", pay);
            string invoicer = this.PharmacyDatabaseService.GetEmployeeByUserId(out msg, _salesOrder.CreateUserId).Name;
            ds.ExtendedProperties.Add("Invoicer", invoicer);
            ds.ExtendedProperties.Add("Saler", _salesOrder.SalerName);
            DsSalesOrder.tableDataTable OrderDetailTable = new DsSalesOrder.tableDataTable();
            List<SalesOrderDetail> prtDetail = _salesOrder.SalesOrderDetails.OrderBy(r => r.DictionaryDosageCode).ToList();
            foreach (SalesOrderDetail detail in prtDetail.Where(r => r.Deleted == false))
            {
                string part = detail.productName;
                string _partType = detail.DictionaryDosageCode;
                string specialCode = detail.SpecificationCode;
                string productUnit = detail.FactoryName;
                string Origin = detail.Origin;
                string batchNumber = detail.BatchNumber;
                string ValidDate = detail.OutValidDate.ToString();
                string unit = detail.MeasurementUnit;
                decimal qty = detail.Amount;
                decimal unitPrice = detail.ActualUnitPrice;
                decimal price = qty * unitPrice;
                string Quanlity = detail.Description;

                OrderDetailTable.Rows.Add(new object[] { part, _partType, specialCode, productUnit, Origin, batchNumber, ValidDate, unit, qty, unitPrice, price, Quanlity });
                OrderDetailTable.AcceptChanges();
            }
            ds.Tables.Add(OrderDetailTable);
            return ds;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var c = MessageBox.Show("确定要申请重新审核？", "提示", MessageBoxButtons.OKCancel);
            if (c == System.Windows.Forms.DialogResult.Cancel) return;

            this._salesOrder.OrderStatus = OrderStatus.Waitting;
            if (this.PharmacyDatabaseService.SaveSalesOrder(out msg, this._salesOrder))
            {
                MessageBox.Show("申请成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("申请失败，请稍后再试！");
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (_salesOrder == null) return;
            if (_salesOrder.OrderStatus < OrderStatus.Approved)
            {
                MessageBox.Show("单据未审核，请审核后导出！");
                return;
            }
            MyExcelUtls.DataGridview2Sheet(this.dgvDrugDetailList, "销售单" + this._salesOrder.OrderCode);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dgvDrugDetailList.Rows.Count <= 0)
            {
                this.GoodsType = this.checkBox2.Checked ? Common.GoodsTypeClass.医疗器械 : Common.GoodsTypeClass.药品;
                return;
            }

            if (this.GoodsType == Common.GoodsTypeClass.药品)
            {
                if (this.checkBox2.Checked)
                {
                    var re = MessageBox.Show("列表已经选择了非医疗器械商品，如果您选择销售医疗器械，则销售列表将被清空，需要确定吗？", "提示", MessageBoxButtons.OKCancel);
                    if (re == System.Windows.Forms.DialogResult.OK)
                    {
                        this.GoodsType = Common.GoodsTypeClass.医疗器械;
                        this.dgvDrugDetailList.DataSource = null;
                        this.newList.Clear();
                        //this.LicensePermissionNumber.HeaderText = "注册证或备案凭证编号";
                    }
                    else
                    {
                        this.checkBox2.Checked = !this.checkBox2.Checked;
                    }
                }
            }
            if (this.GoodsType == Common.GoodsTypeClass.医疗器械)
            {
                if (!this.checkBox2.Checked)
                {
                    var re = MessageBox.Show("列表已经选择了医疗器械商品，如果您选择销售其他商品，则销售列表将被清空，需要确定吗？", "提示", MessageBoxButtons.OKCancel);
                    if (re == System.Windows.Forms.DialogResult.OK)
                    {
                        this.GoodsType = Common.GoodsTypeClass.药品;
                        this.newList.Clear();
                        this.dgvDrugDetailList.DataSource = null;
                        //this.LicensePermissionNumber.HeaderText = "批准文号";
                    }
                    else
                    {
                        this.checkBox2.Checked = !this.checkBox2.Checked;
                    }
                }
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.PrintEmpty();
        }
    }
}
