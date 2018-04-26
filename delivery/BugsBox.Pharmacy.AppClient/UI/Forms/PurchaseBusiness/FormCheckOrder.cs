using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Windows.Forms;
using Omu.ValueInjecter;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.UI.Report;


namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    /// <summary>
    /// 验收记录
    /// By Shen
    /// PurchaseCheckingOrder order, List<PurchaseCheckingOrderDetail> receivingOrderDetails
    /// </summary>
    public partial class FormCheckOrder : BaseFunctionForm
    {
        Common.GoodsTypeClass GoogsTypeClass { get; set; }

        #region 私有属性定义

        /// <summary>
        /// 收货单信息
        /// 由其他窗体给值
        /// </summary>
        PurchaseCommonEntity PurchaseCommonEntity { get; set; }
        /// <summary>
        /// 收货单明细
        /// 由其他窗体给值
        /// </summary>
        List<PurchaseReceivingOrderDetailEntity> PurchaseReceivingOrderDetailEntitys { get; set; }

        BindingList<PurchaseReceivingOrderDetailEntity> bList = null;
        /// <summary>
        /// 验收记录明细
        /// 由本窗创建并收集
        /// </summary>
        List<PurchaseCheckingOrderDetailEntity> PurchaseCheckingOrderDetails { get; set; }

        List<DrugsUndeterminate> ListUndeterminate = new List<DrugsUndeterminate>();

        private List<ComboxItem> ItemsForDataGridViewComboBoxColumn { get; set; }

        private PurchaseCommonEntity _receivingOrder;
        string msg = string.Empty;
        bool isCreate = true;       
        List<User> Listuser = new List<User>();
        BaseForm.BasicInfoRightMenu Bcms = null;

        bool isChineseDrug = false;
        bool isSpecialDrug = false;

        bool IsUploadPic = false;
        
        #endregion  私有属性定义

        #region 数据初始化

        /// <summary>
        /// 初始化控件数据
        /// </summary>
        private void InitControlData()
        {
            try
            {
                ItemsForDataGridViewComboBoxColumn = new List<ComboxItem>();
                ItemsForDataGridViewComboBoxColumn.Add(new ComboxItem("合  格", 0));
                ItemsForDataGridViewComboBoxColumn.Add(new ComboxItem("不合格", 1));
            }
            catch (Exception ex)
            {
                ex = new Exception("初始化控件数据出错" + ex.Message, ex);
                Log.Error(ex);
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+ex.Message,"错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// 初始化控件 
        /// </summary>
        private void InitControl()
        {
                this.dataGridView1.AutoGenerateColumns = false;
        }

        #endregion

        #region 构造函数

        public FormCheckOrder()
        {
            InitializeComponent();

            CellDataValidBackColor = Decription.DefaultCellStyle.BackColor;
            InitControlData();
            InitControl();
            this.Listuser = this.PharmacyDatabaseService.AllUsers(out msg).ToList();

            this.Bcms = new BaseForm.BasicInfoRightMenu(this.dataGridView1);
            this.Bcms.InsertDrugBasicInfo();
            this.Bcms.InsertSupplyUnitBasicInfo();
            this.dataGridView1.CellMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_CellMouseClick);
            this.dataGridView1.CellEndEdit+=dataGridView1_CellEndEdit;
            
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
        }

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var c=this.dataGridView1.Rows[e.RowIndex].DataBoundItem;
            if (c is PurchaseCheckingOrderDetailEntity)
            {
                PurchaseCheckingOrderDetailEntity pcod = c as PurchaseCheckingOrderDetailEntity;
                this.Bcms.DrugId = pcod.DrugInfoId;
            }
            else if(c is PurchaseReceivingOrderDetailEntity)
            {
                PurchaseReceivingOrderDetailEntity prod = c as PurchaseReceivingOrderDetailEntity;
                this.Bcms.DrugId = prod.DrugInfoId;
            }
        }

        private void RecordOperation(int type)
        {
            
        }

        //查询验收单
        public FormCheckOrder(PurchaseCommonEntity order, bool onlySearch = false)
            : this()
        {
            isCreate = false;
             PurchaseCommonEntity = order;
             PurchaseCheckingOrderDetails = this.PharmacyDatabaseService.GetPurchaseCheckingOrderDetails(out msg, order.Id).ToList();

             if (this.PurchaseCheckingOrderDetails.Count(r => r.BusinessScopeCode.Contains("医疗器械")) == this.PurchaseCheckingOrderDetails.Count)
             {
                 this.GoogsTypeClass = Common.GoodsTypeClass.医疗器械;
                 this.LicensePermissionNumber.HeaderText = "注册证或备案凭证编号";
                 this.Decription.Visible = false;
             }

             tsbtnInInventory.Visible = this.Authorize(ModuleKeys.PurchaseInInventory);
            if (PurchaseCommonEntity.OrderStatus != OrderStatus.PurchaseCheck.GetHashCode())
            {
                tsbtnInInventory.Visible = false;
            }

            this.Bcms.Sid = order.SupplyUnitId;//右键供货商信息查询

            txtCheckUserName.Text = order.EmployeeName;
            lblOrderCode.Text = order.DocumentNumber;
            lblOrderStatus.Text = EnumHelper<OrderStatus>.GetDisplayValue((OrderStatus)PurchaseCommonEntity.OrderStatus);
            tsbtnAccept.Visible = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AllowUserToAddRows = false;
            
            colAmount.DataPropertyName = "ArrivalAmount";
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.DataSource = PurchaseCheckingOrderDetails.ToList();
            lblCreateDate.Text = order.OperateTime.ToString("yyyy年MM月dd日");
            label5.Text = order.SupplyUnitName;
            textBoxPurchaseCheckingOrderDescription.Text = order.Description;

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                var c = r.DataBoundItem as Business.Models.PurchaseCheckingOrderDetailEntity;

                if (!this.isSpecialDrug)
                {
                    this.isSpecialDrug = c.IsSpecialCategory;
                }

                string bs = c.BusinessScopeCode;
                if (bs.Contains("中药材") || bs.Contains("中药饮片"))
                {
                    if (bs.Contains("中药材"))
                    {
                        this.dataGridView1.Columns[this.colOutValidDate.Name].Visible = false;
                        this.dataGridView1.Columns[this.colPruductDate.Name].Visible = true;
                        this.dataGridView1.Columns[this.FactoryName.Name].Visible = false;
                        this.tsbtnPrint.Visible = false;
                        break;
                    }
                    else
                    {
                        this.dataGridView1.Columns[this.colOutValidDate.Name].Visible = false;
                        this.dataGridView1.Columns[this.colPruductDate.Name].Visible = true;
                        this.tsbtnPrint.Visible = false;
                        break;
                    }
                }
                else
                {
                    this.dataGridView1.Columns[this.Decription.Name].Visible = false;
                    this.toolStripButton1.Visible = false;
                    break;
                }
            }

            label7.Visible = label8.Visible = this.textBox1.Visible = this.textBox2.Visible = true;
            this.textBox1.ReadOnly = this.textBox2.ReadOnly = true;
            this.textBox1.Text = order.SecondCheckerName;
            this.textBox2.Text = order.SecondCheckMemo;

            if (onlySearch)
            {
                tsbtnAccept.Visible = false;
                tsbtnReturn.Visible = false;
                tsbtnInInventory.Visible = false;
            }
            if (tsbtnAccept.Visible == true)
            {
                tsbtnAccept.Visible = this.Authorize(ModuleKeys.PurchaseChecking);                
                button2.Visible = this.Authorize(ModuleKeys.PurchaseChecking);
            }
            if (tsbtnInInventory.Visible == true)
            {
                tsbtnInInventory.Visible = this.Authorize(ModuleKeys.PurchaseInInventory);                
                button2.Visible = false;
            }
            
            button2.Visible = false;
            btnAccept.Visible = false;
        }

        /// <summary>
        /// 收货单
        /// 收货单详细
        /// </summary>
        /// <param name="order">收货单</param>
        /// <param name="receivingOrderDetails">收货单详细</param>
        public FormCheckOrder(PurchaseCommonEntity order, List<PurchaseReceivingOrderDetailEntity> receivingOrderDetails)
            : this()
        { 
            if (order == null)
            {
                var ex = new ArgumentNullException("采购单对象不为空");
                Log.Error(ex);
                throw ex;
            }
            if (receivingOrderDetails == null)
            {
                var ex = new ArgumentNullException("采购单明细对象不为空");
                Log.Error(ex);
                throw ex;
            }

            this.Bcms.Sid = order.SupplyUnitId;//右键供货商信息查询

            _receivingOrder = order;
            order.RelatedOrderDocumentNumber = order.DocumentNumber;
            order.RelatedOrderId = order.Id;
            order.RelatedOrderTypeValue = (int)OrderType.PurchaseReceivingOrder;
            this.PurchaseCommonEntity = new PurchaseCommonEntity();
            this.PurchaseCommonEntity.InjectFrom(order);
            this.PurchaseReceivingOrderDetailEntitys = receivingOrderDetails;

            this.ChineseDrug();
            this.SpecialManagementDrug();

            this.txtCheckUserName.Text = AppClientContext.CurrentUser.Employee.Name;
            tsbtnInInventory.Visible = false;
            label5.Text = order.SupplyUnitName;
            if (tsbtnAccept.Visible == true)
            {
                tsbtnAccept.Visible = this.Authorize(ModuleKeys.PurchaseChecking);
            }
            if (tsbtnInInventory.Visible == true)
            {
                tsbtnInInventory.Visible = this.Authorize(ModuleKeys.PurchaseInInventory);
            }
        }

        #endregion 构造函数

        #region 数据到控件

        /// <summary>
        /// 绑定订单信息以及订单明细
        /// </summary>
        public void BindDataInfoes()
        {
            //订单信息绑定
            this.dateTimePickerCheckOrderDate.Value = Now;
            this.lblCreateDate.Text = this.PurchaseCommonEntity.OperateTime.ToString("yyyy年MM月dd日 HH时mm分");
            this.lblOrderCode.Text = this.PurchaseCommonEntity.DocumentNumber;
            //订单明细绑定
            bList = new BindingList<PurchaseReceivingOrderDetailEntity>(PurchaseReceivingOrderDetailEntitys);
            bList.ForEach(r => { r.QualifiedAmount = r.ReceiveAmount;});

            if (this.bList.Count(r => r.BusinessScopeCode.Contains("医疗器械")) == this.bList.Count)
            {
                this.GoogsTypeClass = Common.GoodsTypeClass.医疗器械;
                this.LicensePermissionNumber.HeaderText = "注册证或备案凭证编号";
                this.Decription.Visible = false;
            }

            this.dataGridView1.DataSource = bList;

            
                
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                r.Cells[colQualifiedAmount.Name].Value = r.Cells[ReceiveAmount.Name].Value;
                if (this.isChineseDrug)
                {
                    r.Cells[this.colOutValidDate.Name].Value = "20501231";
                    r.Cells[this.colOutValidDate.Name].Style.BackColor = Color.White;
                    r.Cells[this.colOutValidDate.Name].Style.ForeColor = Color.White;
                    r.Cells[this.colOutValidDate.Name].Style.SelectionBackColor = Color.White;
                    r.Cells[this.colOutValidDate.Name].ReadOnly = true;
                    if (bList[r.Index].BusinessScopeCode.Contains("中药材"))
                    {
                        this.dataGridView1.Columns[this.FactoryName.Name].Visible = false;
                    }
                    tsbtnPrint.Visible = false;
                    this.toolStripButton1.Visible = true;
                }
                else
                {
                    this.dataGridView1.Columns[this.Decription.Name].Visible = false;
                    this.dataGridView1.Columns[this.colPruductDate.Name].Visible = true;
                    tsbtnPrint.Visible = true;
                    this.toolStripButton1.Visible = false;
                }
                r.Cells[this.colArrivalDateTime.Name].Value = this._receivingOrder.OperateTime;
            }
        }
            
        

        
        /// <summary>
        /// 收集控件数据与构建数据
        /// </summary>
        private bool CellectAndBuildData()
        {
            try
            {
                bool validResult = true;
                
                PurchaseCommonEntity.Description = this.textBoxPurchaseCheckingOrderDescription.Text;
                PurchaseCommonEntity.OperateUserId = AppClientContext.CurrentUser.Id;
                PurchaseCommonEntity.OperateTime = DateTime.Now;
                //检查单明细
                PurchaseCheckingOrderDetails = new List<PurchaseCheckingOrderDetailEntity>();
                var rows = this.dataGridView1.Rows;
                PurchaseCheckingOrderDetailEntity purchaseCheckingOrderDetail = null;
                PurchaseReceivingOrderDetailEntity purchaseOrderDetailEntity = null;

                if (rows.Count > 0)
                {                   
                    foreach (DataGridViewRow row in rows)
                    {
                        DateTime inputOutValidDate;
                        DateTime inputPruductDate;

                        var cellPruductDate = row.Cells[colPruductDate.Name] as DataGridViewTextBoxCell;
                        var cellOutValidDate = row.Cells[colOutValidDate.Name] as DataGridViewTextBoxCell;                                                
                        cellOutValidDate.Value =this.isChineseDrug? "20501231":cellOutValidDate.Value;

                        if (cellOutValidDate.Value == null)
                        {
                            MessageBox.Show("非中药材、中药饮片需要填写效期，请填写完整八位码效期，如：20140101");
                            return false;
                        }
                        
                        bool bOutValidDate = DateTime.TryParseExact(cellOutValidDate.Value.ToString(), "yyyyMMdd", null,System.Globalization.DateTimeStyles.None,out inputOutValidDate);

                        if (!bOutValidDate)
                        {
                            MessageBox.Show("请填写完整八位码效期，如：20140101"); return false;
                        }

                        Guid drugInfoID=bList[row.Index].DrugInfoId;
                        int validMonth = bList[row.Index].ValidMonth;

                        inputPruductDate =this.isChineseDrug?DateTime.Now.Date.AddMonths(-1): inputOutValidDate.AddMonths(-validMonth);



                        if (inputPruductDate > DateTime.Now.Date)
                        {
                            if (MessageBox.Show(bList[row.Index].ProductGeneralName + "：药品有效期为" + validMonth.ToString() + "月,您输入的效期截至为：" + inputOutValidDate.Date + "生产日期超出当前日期，需要修改效期截至日吗？", "提示", MessageBoxButtons.OKCancel)==System.Windows.Forms.DialogResult.OK)
                            {
                                return false;
                            }
                        }

                        if (string.IsNullOrEmpty(cellPruductDate.FormattedValue.ToString()))
                        {
                            cellPruductDate.Value = inputPruductDate.ToString("yyyyMMdd");
                        }
                        else
                        {
                            bool b = DateTime.TryParseExact(cellPruductDate.Value.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out inputPruductDate);
                            if (!b)
                            {
                                MessageBox.Show("请录入八位日期码，如：20140101");
                                return false;
                            }

                            if (inputPruductDate > DateTime.Now.Date)
                            {
                                MessageBox.Show("生产日期大于当前日期，填写的生产日期有误，请检查！");
                                return false;
                            }
                        }




                        purchaseOrderDetailEntity = row.DataBoundItem as PurchaseReceivingOrderDetailEntity;
                        if (purchaseOrderDetailEntity != null)
                        {
                            purchaseCheckingOrderDetail = new PurchaseCheckingOrderDetailEntity();
                            purchaseCheckingOrderDetail.sequence = row.Index;
                            purchaseCheckingOrderDetail.DictionaryDosageCode = purchaseOrderDetailEntity.DictionaryDosageCode;
                            purchaseCheckingOrderDetail.DictionaryMeasurementUnitCode = purchaseOrderDetailEntity.DictionaryMeasurementUnitCode;
                            purchaseCheckingOrderDetail.DictionarySpecificationCode = purchaseOrderDetailEntity.DictionarySpecificationCode;
                            purchaseCheckingOrderDetail.DrugInfoId = purchaseOrderDetailEntity.DrugInfoId;
                            purchaseCheckingOrderDetail.FactoryName = purchaseOrderDetailEntity.FactoryName;
                            purchaseCheckingOrderDetail.PurchasePrice = purchaseOrderDetailEntity.PurchasePrice;
                            //取得到货数量
                            var cellAmount = row.Cells[colAmount.Name];
                            decimal inputAmount = Decimal.Parse(cellAmount.Value.ToString());
                            purchaseCheckingOrderDetail.ArrivalAmount = inputAmount;
                            purchaseCheckingOrderDetail.ReceiveAmount=Convert.ToDecimal(row.Cells[ReceiveAmount.Name].Value);
                            purchaseCheckingOrderDetail.UnQualifiedAmount = Convert.ToDecimal(row.Cells[ UnqualificationNum.Name ].Value);
                            // 批号 
                            var cellBatchNumber = row.Cells[colBatchNumber.Name] as DataGridViewTextBoxCell;
                            string inputBacthNumber = cellBatchNumber.Value == null
                                ? string.Empty
                                : cellBatchNumber.Value.ToString();

                            if (string.IsNullOrWhiteSpace(inputBacthNumber))
                            {
                                cellBatchNumber.Style.BackColor = CellDataErrorBackColor;
                                validResult = validResult & false;
                            }
                            else if (inputBacthNumber.LastIndexOf("(") > 0 || inputBacthNumber.LastIndexOf(")") > 0)//限制批号输入“（”括号。
                            {
                                cellBatchNumber.Style.BackColor = CellDataErrorBackColor;
                                MessageBox.Show("批号中有英文非法符号，请将英文‘()’改写为中文‘（）’符号或者其他符号！");
                                validResult = validResult & false;
                            }
                            else
                            {
                                purchaseCheckingOrderDetail.BatchNumber = inputBacthNumber;
                                cellBatchNumber.Style.BackColor = CellDataValidBackColor;
                                validResult = validResult & true;
                            }
                           
                            // 描述
                            var cellDescription = row.Cells[Decription.Name] as DataGridViewTextBoxCell;
                            string inputDescription = cellDescription.Value == null
                                ? string.Empty
                                : cellDescription.Value.ToString(); 
                            purchaseCheckingOrderDetail.Decription = string.IsNullOrWhiteSpace(inputDescription)
                                ? ""
                                : inputDescription;

                            //药物编号
                            purchaseCheckingOrderDetail.DrugInfoId = purchaseOrderDetailEntity.DrugInfoId;

                            //生产日期与过期日期必须小于过期日期
                            
                            if ( cellOutValidDate == null)
                            {
                                cellOutValidDate.Style.BackColor = CellDataErrorBackColor;
                                validResult = validResult & false;
                            }
                            else
                            {
                                if ( inputOutValidDate <= Now)//过期日期小于不嫌
                                {                                    
                                    cellOutValidDate.Style.BackColor = CellDataErrorBackColor;
                                    validResult = validResult & false;
                                }
                                else
                                {                                    
                                    cellOutValidDate.Style.BackColor = CellDataValidBackColor;
                                    purchaseCheckingOrderDetail.PruductDate = inputPruductDate;
                                    purchaseCheckingOrderDetail.OutValidDate = inputOutValidDate;
                                    validResult = validResult & true;
                                }
                            }
                             
                            //验收合格数量处理
                            var cellQualifiedAmount = row.Cells[colQualifiedAmount.Name] as DataGridViewTextBoxCell;
                            
                            decimal inputQualifiedAmount = Decimal.Parse(cellQualifiedAmount.FormattedValue.ToString());
                            
                            purchaseCheckingOrderDetail.QualifiedAmount = inputQualifiedAmount;
                            cellQualifiedAmount.Style.BackColor = CellDataValidBackColor;
                            validResult = validResult & true;

                            PurchaseCheckingOrderDetails.Add(purchaseCheckingOrderDetail);
                            validResult = validResult & true;
                            
                            if (inputQualifiedAmount == 0)
                            {
                                var cellUnqualificationAmount = row.Cells[UnqualificationNum.Name] as DataGridViewTextBoxCell;
                                decimal inputCellUnqualificationAmount = Decimal.Parse(cellUnqualificationAmount.FormattedValue.ToString());
                                DrugsUndeterminate drugUn = new DrugsUndeterminate();
                                drugUn.BatchNumber = row.Cells[colBatchNumber.Name].FormattedValue.ToString();
                                drugUn.drugName = row.Cells[colProductGeneralName.Name].FormattedValue.ToString();
                                drugUn.Source = "质量验收";
                                drugUn.quantity = inputCellUnqualificationAmount;
                                drugUn.rsn = row.Cells[unqualificationRsn.Name].FormattedValue.ToString();
                                drugUn.createTime = DateTime.Now;
                                drugUn.updateTime = DateTime.Now;
                                drugUn.staSignDate = DateTime.Now;
                                drugUn.conclusionDate = DateTime.Now;
                                drugUn.Id = Guid.NewGuid();
                                drugUn.creater =PharmacyDatabaseService.GetEmployeeByUserId(out msg, AppClientContext.CurrentUser.Id).Name;
                                drugUn.proc = 0;
                                drugUn.DocumentNumber = PharmacyDatabaseService.GenerateBillDocumentCodeByTypeValue(out msg, (int)BillDocumentType.DrugUndeterminate).Code;
                                drugUn.OrderDocumentID = _receivingOrder.PurchaseOrderDocumentNumber;
                                drugUn.DrugInfoID=bList[row.Index].DrugInfoId;
                                drugUn.produceDate = inputPruductDate;
                                drugUn.ExpireDate = inputOutValidDate;
                                drugUn.supplyer = _receivingOrder.SupplyUnitName;
                                drugUn.wareHouse = "待处理药品库";
                                drugUn.PurchasePrice=bList[row.Index].PurchasePrice;
                                drugUn.UnqualificationApprovalID = new Guid();
                                drugUn.InventoryID = new Guid();
                                drugUn.DosageType = bList[row.Index].DictionaryDosageCode;
                                drugUn.Specific = bList[row.Index].DictionarySpecificationCode;
                                drugUn.Origin = row.Cells[Decription.Name].Value == null ? string.Empty : row.Cells[Decription.Name].Value.ToString();
                                drugUn.DrugInfoID = drugInfoID;
                                ListUndeterminate.Add(drugUn);
                            }
                        }
                    }    
                
                    PurchaseCommonEntity.OrderStatus =_receivingOrder.OrderStatus==(int)Models.OrderStatus.purchaseMReceiving? _receivingOrder.OrderStatus:OrderStatus.PurchaseCheck.GetHashCode();
                }
                return validResult;
            }
            catch (Exception ex)
            {
                ex = new Exception("收集控件数据与构建数据出错" + ex.Message, ex);
                Log.Error(ex);
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        #endregion

        #region 事件处理

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;
            try
            {
                if (isCreate)
                {
                    BindDataInfoes();
                }
            }
            catch (Exception ex)
            {
                ex = new Exception("窗体加载出错" + ex.Message, ex);
                Log.Error(ex);
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        /// <summary>
        /// SupplyDrugType不存在或者为0，则不检测图片是否上传
        /// </summary>
        /// <returns></returns>
        private bool IsUpLoadPicCheck()
        {
            System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
            xmlDocument.Load(AppDomain.CurrentDomain.BaseDirectory + "BugsBox.Pharmacy.AppClient.SalePriceType.xml");
            System.Xml.XmlNodeList xmlNode = xmlDocument.SelectNodes("/SalePriceType/SupplyDrugType");
            int SupplyDrugType =xmlNode.Count<=0?0:  Convert.ToInt16(xmlNode[0].Attributes[0].Value);
            if (SupplyDrugType == 0) return true; //节点不存在或者为0，则不检测，否则需要检测图片是否上传

            if (!this.IsUploadPic)
            {
                MessageBox.Show("收货单扫描图片还没有上传，请上传完毕后再执行验收！");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void tsbtnAccept_Click(object sender, EventArgs e)
        {
            //检测收货单图片是否上传
            if (!this.IsUpLoadPicCheck()) return;

            btnAccept.Enabled=tsbtnAccept.Enabled = false;
            this.dataGridView1.EndEdit();
            this.ListUndeterminate.Clear();
            
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("记录数量为0，无法提交验货单！请关闭本界面后再次进入！");
                this.Dispose();
                return;
            }

            if (!this.checkNum())
            {
                btnAccept.Enabled = tsbtnAccept.Enabled = true;
                return;
            }
            try
            {
                if (CellectAndBuildData())
                {
                    msg = string.Empty;
                    
                    if (this.isSpecialDrug)
                    {
                        MessageBox.Show("本验收单包含特殊管理药品，需要双人验收，请第二验收人登陆验收！");
                        FormOrderCheckingSecondCheckerLogIn frm = new FormOrderCheckingSecondCheckerLogIn(PurchaseCommonEntity);
                        frm.ShowDialog();

                        if (frm.DialogResult != System.Windows.Forms.DialogResult.OK)
                        {
                            return;
                        }
                    }
                    string resultCode = PharmacyDatabaseService.CreatePurchaseCheckingOrderByEnity(out msg, PurchaseCommonEntity,PurchaseCheckingOrderDetails.ToArray(),ListUndeterminate);

                    if (!string.IsNullOrWhiteSpace(resultCode) && string.IsNullOrEmpty(msg))
                    {
                        lblOrderCode.Text = resultCode;
                        lblOrderStatus.Text = EnumHelper<OrderStatus>.GetDisplayValue((OrderStatus)PurchaseCommonEntity.OrderStatus);                        
                        MessageBox.Show(this.Text+"验收完成","提示" , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行采购单入库前质量复核操作成功，采购单号："+ PurchaseCommonEntity.PurchaseOrderDocumentNumber);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this.Text+string.Format("验收失败{0}", msg),"错误" , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行采购单入库前质量复核操作失败，采购单号：" + PurchaseCommonEntity.PurchaseOrderDocumentNumber);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(this.Text+"您填的数据有误,你更正红色单元格内的数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    btnAccept.Enabled=tsbtnAccept.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                ex = new Exception("验收失败,请联系管理员" + ex.Message, ex);
                Log.Error(ex);
                MessageBox.Show(this.Text+ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        #endregion 事件处理

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            
        }

        private void tsbtnInInventory_Click(object sender, EventArgs e)
        {
            try
            {
                PurchaseCommonEntity order = PurchaseCommonEntity;
                List<PurchaseCheckingOrderDetailEntity> receivingOrderDetails = PurchaseCheckingOrderDetails;
                var c = this.PharmacyDatabaseService.GetPurchaseInInventeryOrdersByPurchaseOrderId(out msg, order.PurchaseOrderId).FirstOrDefault();
                if (c != null)
                {
                    var pid = this.PharmacyDatabaseService.GetPurchaseInInventeryOrderDetails(out msg, c.Id);
                    foreach (var i in pid)
                    {
                        var u=receivingOrderDetails.Where(r => r.DrugInfoId == i.DrugInfoId && r.ArrivalAmount == i.ArrivalAmount && r.BatchNumber==i.BatchNumber && r.ArrivalDateTime==i.ArrivalDateTime).FirstOrDefault();
                        if (u != null)
                        {
                            receivingOrderDetails.Remove(u);
                        }
                    }
                }
                FormInInventory form = new FormInInventory(order, receivingOrderDetails.Where(r=>r.QualifiedAmount>0).ToList());
                tsbtnInInventory.Enabled = (form.ShowDialog() != DialogResult.OK);

            }
            catch (Exception ex)
            {
                ex = new Exception("打开验收窗体失败" + ex.Message);
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+ex.Message,"错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void tsbtnReturn_Click(object sender, EventArgs e)
        {
            //存在验收不合格的药品产生退货单   
            List<PurchaseCheckingOrderDetailEntity> defects = new List<PurchaseCheckingOrderDetailEntity>();
            if (PurchaseCheckingOrderDetails == null)
            {
                MessageBox.Show("请在验收后处理退货");
            }
            else
            {
                foreach (PurchaseCheckingOrderDetailEntity p in PurchaseCheckingOrderDetails)
                {
                    if (p.ArrivalAmount > p.QualifiedAmount)
                    {
                        defects.Add(p);
                    }
                }
                if (defects.Count > 0)
                {
                    try
                    {
                        PurchaseCommonEntity order = PurchaseCommonEntity;
                        List<PurchaseOrderReturnDetailEntity> orderDetails = new List<PurchaseOrderReturnDetailEntity>();
                        foreach (PurchaseCheckingOrderDetailEntity d in defects)
                        {
                            PurchaseOrderReturnDetailEntity c = new PurchaseOrderReturnDetailEntity();
                            c.DictionaryDosageCode = d.DictionaryDosageCode;
                            c.FactoryName = d.FactoryName;
                            c.IsReissue = true;
                            c.ReissueAmount = 0;
                            c.RelatedOrderId = order.Id;
                            c.ReturnAmount = d.ArrivalAmount - d.QualifiedAmount;
                            c.ReturnHandledMethodValue = 0;
                            c.ReturnReason = "";
                            c.Decription = "";
                            c.ProductGeneralName = d.ProductGeneralName;
                            c.DictionarySpecificationCode = d.DictionarySpecificationCode;
                            c.DictionaryMeasurementUnitCode = d.DictionaryMeasurementUnitCode;
                            c.LicensePermissionNumber = d.LicensePermissionNumber;
                            c.OutValidDate = d.OutValidDate;
                            c.PruductDate = d.PruductDate;
                            c.DrugInfoId = d.DrugInfoId;
                            c.BatchNumber = d.BatchNumber;
                            c.PurchasePrice = d.PurchasePrice;
                            c.PurchaseReturnSourceValue = (int)PurchaseReturnSource.ReturnFromChecking;
                            orderDetails.Add(c);
                        }
                        FormReturnOrder form = new FormReturnOrder(order, orderDetails);
                        tsbtnInInventory.Enabled = (form.ShowDialog() != DialogResult.OK);
                    }
                    catch (Exception ex)
                    {
                        ex = new Exception("打开退货窗体失败" + ex.Message);
                        MessageBox.Show(this.Text+ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("不存在不合格的产品");
                }
            }
        }

        private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            string rName = string.Empty;
            string bgyName = string.Empty;
            string checkman = string.Empty;
            string Invoicer = string.Empty;
            string ApprovalUser = string.Empty;
            if (PurchaseCommonEntity != null)
            {
                Guid purchaseOrderid = PurchaseCommonEntity.PurchaseOrderId;
                PurchaseOrder po = this.PharmacyDatabaseService.GetPurchaseOrder(out msg, purchaseOrderid);
                Invoicer = Listuser.Where(r => r.Id == po.CreateUserId).FirstOrDefault().Employee.Name;
                ApprovalUser = Listuser.Where(r => r.Id == po.ApprovalUserId).FirstOrDefault().Employee.Name;
                PurchaseCommonEntity pro = this.PharmacyDatabaseService.GetPurchaseReceivingOrdersByPurchaseOrderId(out msg, purchaseOrderid).FirstOrDefault();
                if (pro == null)
                {
                    MessageBox.Show("该单据尚未收货，无法打印验收入库单"); return;
                }
                rName = pro.EmployeeName;

                PurchaseCommonEntity pco = this.PharmacyDatabaseService.GetPurchaseCheckingOrdersByPurchaseOrderId(out msg, purchaseOrderid).FirstOrDefault();
                if (pco == null)
                {
                    MessageBox.Show("该单据尚未验收，无法打印验收入库单"); return;
                }
                checkman = pco.EmployeeName;

                PurchaseCommonEntity piio = this.PharmacyDatabaseService.GetPurchaseInInventeryOrdersByPurchaseOrderId(out msg, purchaseOrderid).FirstOrDefault();
                if (piio == null)
                {
                    MessageBox.Show("该单据尚未入库，无法打印验收入库单"); return;
                }

                bgyName = piio.EmployeeName;
            }
            List<Microsoft.Reporting.WinForms.ReportParameter> ListPar = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("rName", rName));
            ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("checkman", checkman));
            ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("bgyName", bgyName));
            ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("Invoicer", Invoicer));
            ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("ApprovalUser", ApprovalUser));

            List<object> reportData = new List<object>();
            List<object> orderList = new List<object>();
            List<PurchaseReceivingOrderDetailEntity> orderDetails = new List<PurchaseReceivingOrderDetailEntity>();
            orderList.Add(PurchaseCommonEntity);
            reportData.Add(orderList);

            reportData.Add(PurchaseCheckingOrderDetails);

            if (this.GoogsTypeClass == Common.GoodsTypeClass.药品)
            {

                using (PrintHelper printHelper = new PrintHelper("Reports\\RptPurchaseCheckingOrder.rdlc", ListPar, reportData))
                {
                    printHelper.Print();
                }
            }
            else
            {
                using (PrintHelper printHelper = new PrintHelper("Reports\\RptPurchaseCheckingOrderYLQX.rdlc", ListPar, reportData))
                {
                    printHelper.Print();
                }
            }
        }
                
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (bList == null) return;            
            PurchaseReceivingOrderDetailEntity pd = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as PurchaseReceivingOrderDetailEntity;
            #region 合格数量填写
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == this.colQualifiedAmount.Name)
            {
                if (pd.UnQualifiedAmount!=0)
                {
                    MessageBox.Show("验收合格品种应与疑问品种需分行设定！");
                    pd.QualifiedAmount = 0;
                    return;
                }
                if (pd.QualifiedAmount < 0)
                {
                    MessageBox.Show("合格数量小于零！"); return;
                }
                if (pd.QualifiedAmount < pd.ReceiveAmount && pd.QualifiedAmount>=0)
                {
                    if (MessageBox.Show("收货数量大于该验收数量，是否需要分行设定？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        PurchaseReceivingOrderDetailEntity p = new PurchaseReceivingOrderDetailEntity();
                        p.ProductGeneralName = pd.ProductGeneralName;
                        p.Origin = pd.Origin;
                        p.FactoryName = pd.FactoryName;
                        p.DictionaryDosageCode = pd.DictionaryDosageCode;
                        p.DictionaryMeasurementUnitCode = pd.DictionaryMeasurementUnitCode;
                        p.DictionarySpecificationCode = pd.DictionarySpecificationCode;
                        p.LicensePermissionNumber = pd.LicensePermissionNumber;
                        p.ActualAmount = pd.ActualAmount - pd.QualifiedAmount;
                        p.ReceiveAmount = pd.ReceiveAmount - pd.QualifiedAmount;
                        p.sequence = bList.Count - 1;
                        p.DrugInfoId = pd.DrugInfoId;
                        p.PurchasePrice = pd.PurchasePrice;
                        p.BusinessScopeCode = pd.BusinessScopeCode;
                        p.ValidMonth = pd.ValidMonth;
                        bList.Add(p);
                        pd.ReceiveAmount = pd.QualifiedAmount;
                        pd.ActualAmount = pd.QualifiedAmount;

                        foreach (DataGridViewRow row in this.dataGridView1.Rows)
                        {
                            row.Cells[this.colArrivalDateTime.Name].Value = this._receivingOrder.OperateTime;
                        }
                    }
                    else
                    {
                        pd.QualifiedAmount = pd.ReceiveAmount;
                    }
                }
            }
            #endregion
            #region 不合格数量填写
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == this.UnqualificationNum.Name)
            {
                if (pd.QualifiedAmount != 0)
                {
                    MessageBox.Show("验收疑问品种应与验收合格品种需分行设定！");
                    pd.UnQualifiedAmount = 0;
                    return;
                }
                if (pd.UnQualifiedAmount>0)
                {
                    if(pd.UnQualifiedAmount < pd.ReceiveAmount){
                        MessageBox.Show("收货数量大于该疑问品种数量，是否需要分行设定？", "提示");
                        PurchaseReceivingOrderDetailEntity p = new PurchaseReceivingOrderDetailEntity();
                        p.ProductGeneralName = pd.ProductGeneralName;
                        p.Origin = pd.Origin;
                        p.FactoryName = pd.FactoryName;
                        p.DictionaryDosageCode = pd.DictionaryDosageCode;
                        p.DictionaryMeasurementUnitCode = pd.DictionaryMeasurementUnitCode;
                        p.DictionarySpecificationCode = pd.DictionarySpecificationCode;
                        p.LicensePermissionNumber = pd.LicensePermissionNumber;
                        p.ActualAmount = pd.ActualAmount - pd.UnQualifiedAmount;
                        p.ReceiveAmount = pd.ReceiveAmount - pd.UnQualifiedAmount;
                        p.sequence = bList.Count - 1;
                        p.DrugInfoId = pd.DrugInfoId;
                        bList.Add(p);
                        pd.ReceiveAmount = pd.UnQualifiedAmount;
                        pd.ActualAmount = pd.UnQualifiedAmount;
                    }
                    else
                    {
                        pd.UnQualifiedAmount = pd.ReceiveAmount;
                    }

                    Form_CheckUndeterminateConfirm frm = new Form_CheckUndeterminateConfirm();
                    frm.EMName = BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Employee.Name;
                    frm.UndeterminateDrugNumber = pd.UnQualifiedAmount;
                    frm.DrugName = pd.ProductGeneralName;

                    frm.ShowDialog();

                    this.dataGridView1.CurrentRow.Cells[this.apprvl.Name].Value = "质量复查流程";
                    this.dataGridView1.CurrentRow.Cells[this.UnqualificationType.Name].Value = "质量验收";
                    this.dataGridView1.CurrentRow.Cells[this.unqualificationRsn.Name].Value = frm.UndeterminateCheckMemo;
                    
                }
            }
            #endregion
                       
            #region 效期、生产日期格式填写
            DataGridViewCell dtCell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            this.CheckDate(dtCell);
            #endregion
        }
        #region 日期检查
        private void CheckDate(DataGridViewCell dtCell)
        {
            string dtstr = dtCell.Value==null?string.Empty:dtCell.Value.ToString().Trim();
            DateTime dt;

            if (dtCell.OwningColumn.Name == colOutValidDate.Name||dtCell.OwningColumn.Name==colPruductDate.Name)
            {
                if (!string.IsNullOrEmpty(dtstr))
                {
                    bool b = DateTime.TryParseExact(dtstr, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dt);
                    if (!b)
                    {
                        MessageBox.Show("请录入八位码日期，如：20140101");
                        dtCell.Value = "20140101";
                        return;
                    }
                }
            }
        }
        #endregion

        //检查合格数量和不合格数量是否等于到货总数
        private bool checkNum()
        {
            if (PurchaseReceivingOrderDetailEntitys == null) return false;
            foreach (var i in PurchaseReceivingOrderDetailEntitys)
            {
                if (i.UnQualifiedAmount +i.QualifiedAmount!=i.ReceiveAmount)
                {
                    MessageBox.Show("("+i.ProductGeneralName + ")验收合格＋疑问品种数量之和与收货数量不一致，请修改！");
                    return false;
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rdx=this.dataGridView1.CurrentRow.Index;
            
            this.bList.Add(PurchaseReceivingOrderDetailEntitys[rdx]);            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow == null) return;
            if(MessageBox.Show("确定要删除选当前行的记录吗？","提示",MessageBoxButtons.OKCancel)==System.Windows.Forms.DialogResult.OK)
            {
                int idx = this.dataGridView1.CurrentRow.Index;
                if (idx < 0) return;
                Guid drugID = bList[idx].DrugInfoId;
                
                var c = bList.Where(r=>r.DrugInfoId==drugID);
                if (c.Count() <= 1)
                {
                    MessageBox.Show("该行无法删除！"); return;
                }
                var u = c.First();
                u.ActualAmount += bList[idx].ActualAmount;
                u.ReceiveAmount += bList[idx].ReceiveAmount;
                if (u.QualifiedAmount > 0)
                {
                    u.QualifiedAmount += bList[idx].ReceiveAmount;
                }
                if (u.UnQualifiedAmount > 0)
                {
                    u.UnQualifiedAmount += bList[idx].ReceiveAmount;
                }
                bList.RemoveAt(idx);
            }
            
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string rName = string.Empty;
                string bgyName = string.Empty;
                string checkman = string.Empty;
                string Invoicer = string.Empty;
                string ApprovalUser = string.Empty;
                if (PurchaseCommonEntity != null)
                {
                    Guid purchaseOrderid = PurchaseCommonEntity.PurchaseOrderId;
                    PurchaseOrder po = this.PharmacyDatabaseService.GetPurchaseOrder(out msg, purchaseOrderid);
                    Invoicer = Listuser.Where(r => r.Id == po.CreateUserId).FirstOrDefault().Employee.Name;
                    ApprovalUser = Listuser.Where(r => r.Id == po.ApprovalUserId).FirstOrDefault().Employee.Name;
                    PurchaseCommonEntity pro = this.PharmacyDatabaseService.GetPurchaseReceivingOrdersByPurchaseOrderId(out msg, purchaseOrderid).FirstOrDefault();
                    if (pro == null)
                    {
                        MessageBox.Show("该单据尚未收货，无法打印验收入库单"); return;
                    }
                    rName = pro.EmployeeName;

                    PurchaseCommonEntity pco = this.PharmacyDatabaseService.GetPurchaseCheckingOrdersByPurchaseOrderId(out msg, purchaseOrderid).FirstOrDefault();
                    if (pro == null)
                    {
                        MessageBox.Show("该单据尚未验收，无法打印验收入库单"); return;
                    }
                    checkman = pco.EmployeeName;

                    PurchaseCommonEntity piio = this.PharmacyDatabaseService.GetPurchaseInInventeryOrdersByPurchaseOrderId(out msg, purchaseOrderid).FirstOrDefault();
                    if (pro == null)
                    {
                        MessageBox.Show("该单据尚未入库，无法打印验收入库单"); return;
                    }

                    bgyName = piio.EmployeeName;
                }
                List<Microsoft.Reporting.WinForms.ReportParameter> ListPar = new List<Microsoft.Reporting.WinForms.ReportParameter>();
                ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("rName", rName));
                ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("checkman", checkman));
                ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("bgyName", bgyName));
                ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("Invoicer", Invoicer));
                ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("ApprovalUser", ApprovalUser));

                foreach (var c in PurchaseCheckingOrderDetails)
                {
                    if (c.LicensePermissionNumber.IndexOf("国药准字") > -1)
                    {
                        int index = c.LicensePermissionNumber.IndexOf("国药准字")+4;
                        c.LicensePermissionNumber = c.LicensePermissionNumber.Substring(index, c.LicensePermissionNumber.Length - 4);
                    }
                    if (string.IsNullOrEmpty(c.LicensePermissionNumber)) c.LicensePermissionNumber = "无";
                }

                List<object> reportData = new List<object>();
                List<object> orderList = new List<object>();
                List<PurchaseReceivingOrderDetailEntity> orderDetails = new List<PurchaseReceivingOrderDetailEntity>();
                orderList.Add(PurchaseCommonEntity);
                reportData.Add(orderList);
                reportData.Add(PurchaseCheckingOrderDetails);

                using (PrintHelper printHelper = new PrintHelper("Reports\\Report1.rdlc", ListPar, reportData))
                {
                    printHelper.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印参数传递有误，请联系系统管理员！");
            }
        }

        //判断是否中药材或中药饮片
        private void ChineseDrug()
        {
            bool b = this.PurchaseReceivingOrderDetailEntitys.Where(r => r.BusinessScopeCode.Contains("中药")).Count() > 0;            
            this.isChineseDrug =b;
            this.colOutValidDate.Visible = !b;
            this.LicensePermissionNumber.Visible = !b;
            this.colPruductDate.Visible = true;
            this.Decription.Visible=true;
        }

        //判断是否特殊管理药品
        private void SpecialManagementDrug()
        {
            if (this.PurchaseReceivingOrderDetailEntitys.Where(r => r.IsSpecial).Count() > 0)
            {
                this.isSpecialDrug = true;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            UI.Forms.BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(32, this.PurchaseCommonEntity.PurchaseOrderId);
            
            User usr = BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser;
            
            //检查当前登录角色是否为管理员，管理员可以在任何时间内修改和上传图片
            var allRoles = this.PharmacyDatabaseService.AllRoles(out msg).Where(r => r.Name.Contains("SystemRole") || r.Name.Contains("adminRole"));
            var allrolew = from m in this.PharmacyDatabaseService.AllRoleWithUsers(out msg)
                           join a in allRoles on
                               m.RoleId equals a.Id
                           where m.UserId == usr.Id
                           select m;

            if (this.tsbtnAccept.Enabled || allrolew.ToList().Count <= 0)
            {
                UI.Forms.Common.SetControls.SetControlReadonly(frm, false);
            }
            else
            {
                UI.Forms.Common.SetControls.SetControlReadonly(frm, true);
            }
            frm.ShowDialog();

            this.IsUploadPic = frm.DialogResult == System.Windows.Forms.DialogResult.OK;

            if (this.IsUploadPic)
            {
                this.PharmacyDatabaseService.WriteLog(usr.Id, "上传采购收货单图片成功！");
            }

            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string rName = string.Empty;
            string bgyName = string.Empty;
            string checkman = string.Empty;
            string Invoicer = string.Empty;
            string ApprovalUser = string.Empty;
            if (PurchaseCommonEntity != null)
            {
                Guid purchaseOrderid = PurchaseCommonEntity.PurchaseOrderId;
                PurchaseOrder po = this.PharmacyDatabaseService.GetPurchaseOrder(out msg, purchaseOrderid);
                Invoicer = Listuser.Where(r => r.Id == po.CreateUserId).FirstOrDefault().Employee.Name;
                ApprovalUser = Listuser.Where(r => r.Id == po.ApprovalUserId).FirstOrDefault().Employee.Name;
                PurchaseCommonEntity pro = this.PharmacyDatabaseService.GetPurchaseReceivingOrdersByPurchaseOrderId(out msg, purchaseOrderid).FirstOrDefault();
                if (pro == null)
                {
                    MessageBox.Show("该单据尚未收货，无法打印验收入库单"); return;
                }
                rName = pro.EmployeeName;

                PurchaseCommonEntity pco = this.PharmacyDatabaseService.GetPurchaseCheckingOrdersByPurchaseOrderId(out msg, purchaseOrderid).FirstOrDefault();
                if (pco == null)
                {
                    MessageBox.Show("该单据尚未验收，无法打印验收入库单"); return;
                }
                checkman = pco.EmployeeName;

                //PurchaseCommonEntity piio = this.PharmacyDatabaseService.GetPurchaseInInventeryOrdersByPurchaseOrderId(out msg, purchaseOrderid).FirstOrDefault();
                //if (piio == null)
                //{
                //    MessageBox.Show("该单据尚未入库，无法打印验收入库单"); return;
                //}

                bgyName = " ";
            }
            List<Microsoft.Reporting.WinForms.ReportParameter> ListPar = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("rName", rName));
            ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("checkman", checkman));
            ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("bgyName", bgyName));
            ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("Invoicer", Invoicer));
            ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("ApprovalUser", ApprovalUser));

            List<object> reportData = new List<object>();
            List<object> orderList = new List<object>();
            List<PurchaseReceivingOrderDetailEntity> orderDetails = new List<PurchaseReceivingOrderDetailEntity>();
            orderList.Add(PurchaseCommonEntity);
            reportData.Add(orderList);

            //foreach (var c in PurchaseCheckingOrderDetails)
            //{
            //    if (c.LicensePermissionNumber.IndexOf("国药准字") > -1)
            //    {
            //        int index = c.LicensePermissionNumber.IndexOf("国药准字");
            //        int startIndex = index + "国药准字".Length;
            //        int SubLength = c.LicensePermissionNumber.Length - startIndex;
            //        c.LicensePermissionNumber = c.LicensePermissionNumber.Substring(startIndex, SubLength);
            //    }
            //    if (string.IsNullOrEmpty(c.LicensePermissionNumber)) c.LicensePermissionNumber = "无";
            //}
            reportData.Add(PurchaseCheckingOrderDetails);
            using (PrintHelper printHelper = new PrintHelper("Reports\\RptPurchaseCheckingOrderNoHeader.rdlc", ListPar, reportData))
            {
                printHelper.Print();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "采购验收单");
        }
    }


    public class ComboxItem
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public ComboxItem(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
