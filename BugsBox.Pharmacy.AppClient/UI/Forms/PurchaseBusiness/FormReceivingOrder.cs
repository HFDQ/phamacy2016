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
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.UI.Report;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class FormReceivingOrder : BaseFunctionForm
    {
        public Common.GoodsTypeClass GoogsTypeClass { get; set; }

        private PurchaseCommonEntity _order = new PurchaseCommonEntity();
        private List<PurchaseReceivingOrderDetailEntity> _orderDetails = new List<PurchaseReceivingOrderDetailEntity>();
        string msg=string.Empty;
        //是否为退货后重新收货
        
        private UI.Forms.BaseForm.BasicInfoRightMenu Bcms = null;

        public FormReceivingOrder()
        {
            InitializeComponent();
            CellDataValidBackColor = clmDrugName.DefaultCellStyle.BackColor;
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };

            Bcms = new BaseForm.BasicInfoRightMenu(this.dataGridView1);
            Bcms.InsertDrugBasicInfo();
            Bcms.InsertSupplyUnitBasicInfo();
            this.dataGridView1.CellMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_CellMouseClick);
        }

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            PurchaseReceivingOrderDetailEntity prode = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as PurchaseReceivingOrderDetailEntity;
            this.Bcms.DrugId = prode.DrugInfoId;   //右键查品种信息
        }
        //查询收货单
        public FormReceivingOrder(PurchaseCommonEntity order, bool onlySearch=false)
            : this()
        {
             string msg = String.Empty;
            _order = order;
            
            _orderDetails = this.PharmacyDatabaseService.GetPurchaseReceivingOrderDetails(out msg, order.Id).Where(r=>r.ActualAmount>0).ToList();
            Initial(false);
            if (_order.OrderStatus != OrderStatus.PurchaseReceiving.GetHashCode() && _order.OrderStatus != OrderStatus.purchaseMReceiving.GetHashCode())
            {
                tsbtnChecking.Visible = false;
            }
            PurchaseOrder purchaseOrder=this.PharmacyDatabaseService.GetPurchaseOrder(out msg, _order.PurchaseOrderId);
            if (purchaseOrder != null && purchaseOrder.OrderStatusValue == OrderStatus.PurchaseReceinvingAmountDiff.GetHashCode())
            {
                btnModifyPurchaseAmount.Visible = true;
            }

            this.dataGridView1.ReadOnly = true;
            label5.Text = order.SupplyUnitName;
            ShippingTime.Enabled = false;
            ShippingTime.Text = order.ShippingTime.ToString("yyyy年MM月dd日 HH时mm分");
            textBoxShippingAdress.Enabled = false;
            textBoxShippingAdress.Text = order.ShippingAdress;
            textBoxShippingUnit.Enabled = false;
            textBoxShippingUnit.Text = order.ShippingUnit;
            textBoxTransportUnit.Enabled = false;
            textBoxTransportUnit.Text = order.TransportUnit;
            textBoxDescription.Text = order.Description;
            if (onlySearch)
            {
                tsbtnReceiving.Visible = false;
                btnReceiving.Visible = false;
                btnModifyPurchaseAmount.Visible = false;
                tsbtnChecking.Visible = false;
            }
            if (tsbtnReceiving.Visible == true )
            {
                tsbtnReceiving.Visible = this.Authorize(ModuleKeys.PurchaseReceiving);                
            }
            if (btnModifyPurchaseAmount.Visible == true )
            {
                btnModifyPurchaseAmount.Visible = this.Authorize(ModuleKeys.PurchaseReceiving);
            }
            if (tsbtnChecking.Visible == true )
            {
                tsbtnChecking.Visible = this.Authorize(ModuleKeys.PurchaseChecking);                
            }
        }

        //创建收货单 开始收货
        public FormReceivingOrder(PurchaseOrdeEntity order, List<PurchaseOrderDetailEntity> orderDetails)
            : this()
        {
            _order.Description = "";
            _order.PurchaseOrderId = order.Id;
            _order.OperateUserId = AppClientContext.CurrentUser.Id;
            _order.RelatedOrderDocumentNumber = order.DocumentNumber;
            _order.RelatedOrderId = order.Id;
            _order.RelatedOrderTypeValue = (int)OrderType.PurchaseOrder;
            _order.SupplyUnitId = order.SupplyUnitId;
            _order.SupplyUnitName = order.SupplyUnitName;
            _order.OrderStatus = order.OrderStatusValue;

            if (order.OrderStatusValue == (int)OrderStatus.purchaseMReceiving)
            {
                PurchaseCommonEntity[] orderEntity = this.PharmacyDatabaseService.GetPurchaseReceivingOrdersByPurchaseOrderId(out msg, order.Id);
                if (orderEntity.Count() > 0)
                {
                    this.Column2.Visible = true;
                    ShippingTime.Text = orderEntity[0].ShippingTime.ToString("yyyy年MM月dd日 HH时mm分");
                    textBoxShippingAdress.Text = orderEntity[0].ShippingAdress;
                    textBoxShippingUnit.Text = orderEntity[0].ShippingUnit;
                    textBoxTransportUnit.Text = orderEntity[0].TransportUnit;
                    textBoxDescription.Text = orderEntity[0].Description;

                    #region 如果是多次收货状态，则读入已收货单
                    if (order.OrderStatusValue == (int)OrderStatus.purchaseMReceiving)
                    {
                        this.clmDrugNumber.HeaderText = "前次已到货数量";
                        this.clmDrugNumber.ReadOnly = true;
                        this.ReceiveAmount.HeaderText = "前次已收货数量";
                        this.ReceiveAmount.ReadOnly = true;                        
                        var c = this.PharmacyDatabaseService.GetPurchaseReceivingOrderDetails(out msg, orderEntity[0].Id);
                        this._orderDetails = (from i in c group i by i.DrugInfoId into g
                                              select new PurchaseReceivingOrderDetailEntity
                                              {
                                                  ActualAmount = g.Sum(r=>r.ActualAmount),
                                                  Amount = g.FirstOrDefault().Amount,
                                                  ProductGeneralName = g.FirstOrDefault().ProductGeneralName,
                                                  ReceiveAmount = g.Sum(r=>r.ReceiveAmount),
                                                  RejectAmount = g.Sum(r=>r.RejectAmount),
                                                  BusinessScopeCode = g.FirstOrDefault().BusinessScopeCode,
                                                  CheckResult = g.FirstOrDefault().CheckResult,
                                                  CheckResultString = g.FirstOrDefault().CheckResultString,
                                                  Decription = g.FirstOrDefault().Decription,
                                                  DictionaryDosageCode = g.FirstOrDefault().DictionaryDosageCode,
                                                  DictionaryMeasurementUnitCode = g.FirstOrDefault().DictionaryMeasurementUnitCode,
                                                  DictionarySpecificationCode = g.FirstOrDefault().DictionarySpecificationCode,
                                                  DrugInfoId = g.FirstOrDefault().DrugInfoId,
                                                  FactoryName = g.FirstOrDefault().FactoryName,
                                                  Id = g.FirstOrDefault().Id,
                                                  IsCompanyPurchase = g.FirstOrDefault().IsCompanyPurchase,
                                                  IsTransportMethod = g.FirstOrDefault().IsTransportMethod,
                                                  IsTransportTemperature = g.FirstOrDefault().IsTransportTemperature,
                                                  LicensePermissionNumber = g.FirstOrDefault().LicensePermissionNumber,
                                                  Origin = g.FirstOrDefault().Origin,
                                                  PurchasePrice = g.FirstOrDefault().PurchasePrice,
                                                  PurchaseReceivingOrderId = g.FirstOrDefault().PurchaseReceivingOrderId,
                                                  RejectReason = g.FirstOrDefault().RejectReason,
                                                  RejectTrace = g.FirstOrDefault().RejectTrace,
                                                  sequence = g.FirstOrDefault().sequence,
                                                  TemperatureStatus = g.FirstOrDefault().TemperatureStatus,
                                                  TransportMethod = g.FirstOrDefault().TransportMethod,
                                                  TransportTemperature = g.FirstOrDefault().TransportTemperature,
                                                  MReceiveNumber = g.FirstOrDefault().MReceiveNumber,
                                                  
                                              }).ToList();
                    }
                    
                    #endregion
                }
            }
            else
            {
                foreach (PurchaseOrderDetailEntity d in orderDetails)
                {
                    PurchaseReceivingOrderDetailEntity c = new PurchaseReceivingOrderDetailEntity();
                    c.Amount = d.Amount;
                    c.ActualAmount = d.Amount;
                    c.Decription = "";
                    c.CheckResult = 0;
                    c.ReceiveAmount = d.Amount;
                    c.RejectAmount = 0;
                    c.ProductGeneralName = d.ProductGeneralName;
                    c.DictionarySpecificationCode = d.DictionarySpecificationCode;
                    c.DictionaryMeasurementUnitCode = d.DictionaryMeasurementUnitCode;
                    c.DictionaryDosageCode = d.DictionaryDosageCode;
                    c.LicensePermissionNumber = d.LicensePermissionNumber;
                    c.DrugInfoId = d.DrugInfoId;
                    c.FactoryName = d.FactoryName;
                    c.PurchasePrice = d.PurchasePrice;
                    c.IsCompanyPurchase = true;
                    c.IsTransportMethod = true;
                    c.IsTransportTemperature = true;
                    c.Origin = d.Origin;
                    c.sequence = d.sequence;
                    c.BusinessScopeCode = d.SupplyBusinessScope;
                    _orderDetails.Add(c);
                }
            }
            Initial(true);
            tsbtnChecking.Visible = false;
            label5.Text = order.SupplyUnitName;
            if (tsbtnReceiving.Visible == true )
            {
                tsbtnReceiving.Visible = this.Authorize(ModuleKeys.PurchaseReceiving);
            }
            if (btnModifyPurchaseAmount.Visible == true)
            {
                btnModifyPurchaseAmount.Visible = this.Authorize(ModuleKeys.PurchaseReceiving);
            }
            if (tsbtnChecking.Visible == true)
            {
                tsbtnChecking.Visible = this.Authorize(ModuleKeys.PurchaseChecking);
            }
        }

        public FormReceivingOrder(PurchaseCommonEntity order, List<PurchaseOrderReturnDetailEntity> orderDetails)
            : this()
        {
            _order.Description = "";
            _order.PurchaseOrderId = order.PurchaseOrderId;
            _order.OperateUserId = AppClientContext.CurrentUser.Id;
            _order.RelatedOrderDocumentNumber = order.DocumentNumber;
            _order.RelatedOrderId = order.Id;
            _order.RelatedOrderTypeValue = (int)OrderType.PurchaseOrderReturn;
            _order.SupplyUnitId = order.SupplyUnitId;
            _order.SupplyUnitName = order.SupplyUnitName;
            foreach (PurchaseOrderReturnDetailEntity d in orderDetails)
            {
                if (d.IsReissue)
                {
                    PurchaseReceivingOrderDetailEntity c = new PurchaseReceivingOrderDetailEntity();
                    c.Amount = d.ReissueAmount;
                    c.ActualAmount = 0;
                    c.Decription = "";
                    c.CheckResult = 0;
                    c.ReceiveAmount = 0;
                    c.RejectAmount = 0;
                    c.ProductGeneralName = d.ProductGeneralName;
                    c.DictionarySpecificationCode = d.DictionarySpecificationCode;
                    c.DictionaryMeasurementUnitCode = d.DictionaryMeasurementUnitCode;
                    c.DictionaryDosageCode = d.DictionaryDosageCode;
                    c.LicensePermissionNumber = d.LicensePermissionNumber;
                    c.DrugInfoId = d.DrugInfoId;
                    c.FactoryName = d.FactoryName;
                    c.PurchasePrice = d.PurchasePrice;
                    c.Origin = d.Origin;
                    _orderDetails.Add(c);
                }
            }
            Initial(true);
            tsbtnChecking.Visible = false;
            
            label5.Text = order.SupplyUnitName;
            if (tsbtnReceiving.Visible == true )
            {
                tsbtnReceiving.Visible = this.Authorize(ModuleKeys.PurchaseReceiving);
            }
            if (btnModifyPurchaseAmount.Visible == true)
            {
                btnModifyPurchaseAmount.Visible = this.Authorize(ModuleKeys.PurchaseReceiving);
            }
            if (tsbtnChecking.Visible == true )
            {
                tsbtnChecking.Visible = this.Authorize(ModuleKeys.PurchaseChecking);
            }
        }

        public void Initial(bool isCreate)
        {
            string msg = String.Empty;

            this.Bcms.Sid = this._order.SupplyUnitId;//右键查供货商信息

            if (isCreate)
            {
                lblOrderNo.Text = "新建";
                lblCreateDate.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分");
                string employeeName = AppClientContext.CurrentUser.Employee.Name;
                txt复核员名.Text = employeeName;
            }
            else
            {
                lblCreateDate.Text = _order.OperateTime.ToString("yyyy年MM月dd日 HH时mm分");
                txt复核员名.Text = _order.EmployeeName;
                lblOrderNo.Text = _order.DocumentNumber;
                lblOrderStatus.Text = EnumHelper<OrderStatus>.GetDisplayValue((OrderStatus)_order.OrderStatus);

                if (_order.OrderStatus == OrderStatus.PurchaseApprovedReceinvingAmountDiff.GetHashCode())
                {
                    tsbtnReceiving.Visible = true;
                    btnReceiving.Visible = true;
                    this.dataGridView1.ReadOnly = false;
                }
                else
                {
                    this.dataGridView1.ReadOnly = true;
                    tsbtnReceiving.Visible = false;
                    btnReceiving.Visible = false;
                }
            }
          
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = _orderDetails;
        }

        //返回收货状态值:0-填写错误，返回修改,1-正常收货，2-执行修改采购数量审批流程,3-分批收货。
        private int validInputInDataGridView()
        {
            var b = this._orderDetails.Where(r => r.Amount < r.ActualAmount+r.MReceiveNumber);//到货数量大于采购数量
            if (b.Count() > 0)
            {
                var u = b.Select(r => r.ProductGeneralName).ToArray();
                string names = string.Join(",", u);
                var re = MessageBox.Show("品名：(" + names + ")，到货数量超出采购单数量，请修改！");
                return 0;
            }

            if (_order.OrderStatus != (int)Models.OrderStatus.purchaseMReceiving)
            {
                var c = this._orderDetails.Where(r => r.ActualAmount + r.MReceiveNumber != r.RejectAmount + r.ReceiveAmount);
                if (c.Count() > 0)
                {
                    var u = c.Select(r => r.ProductGeneralName).ToArray();
                    string names = string.Join(",", u);
                    MessageBox.Show("品名:(" + names + ")" + "，到货数量应与（实收数量＋拒收数量）一致，请修改！");
                    return 0;
                }
            }

            var d = this._orderDetails.Where(r => r.Amount > r.ActualAmount+r.MReceiveNumber);
            if (d.Count() > 0)
            {
                var u = d.Select(r => r.ProductGeneralName).ToArray();
                string names = string.Join(",", u);

                if (this._order.OrderStatus != (int)OrderStatus.purchaseMReceiving)
                {
                    var re = MessageBox.Show("品名：(" + names + ")，到货数量不足，需要执行修改采购数量流程吗？", "提示", MessageBoxButtons.OKCancel);
                    if (re == System.Windows.Forms.DialogResult.OK) return 2;
                }
                
                var res = MessageBox.Show("品名：(" +names+ ")，到货数量不足，可继续收货，如果继续收货，则该单据处于未完全收货状态，如果下次到货，可以继续执行收货操作，需要继续收货吗？", "提示", MessageBoxButtons.OKCancel);
                if (res == System.Windows.Forms.DialogResult.Cancel) return 0;
                return 3;
            }

            return 1;
        }

        //执行收货操作
        private void tsbtnAccept_Click_1(object sender, EventArgs e)
        {
            tsbtnReceiving.Enabled = btnReceiving.Enabled = false;
            this.dataGridView1.EndEdit();

            var de=this._orderDetails.Where(r => string.IsNullOrEmpty(r.TransportTemperature)).FirstOrDefault();
            
            if ( de!= null)
            {
                if (MessageBox.Show(de.ProductGeneralName+",温控状态(温度记录)没有填写，继续收货吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) 
                    return;
            }

            try
            {
                int ReceivingStatus=validInputInDataGridView();
                if (ReceivingStatus == 0)
                {
                    tsbtnReceiving.Enabled = btnReceiving.Enabled = true;
                    return;
                }
                
                string msg = String.Empty;
                    
                if (ReceivingStatus==2)
                {
                    _order.OrderStatus = OrderStatus.PurchaseReceinvingAmountDiff.GetHashCode();
                }
                    
                if (ReceivingStatus==1)
                {
                    _order.OrderStatus = OrderStatus.PurchaseReceiving.GetHashCode();
                }
                if(ReceivingStatus==3)
                {
                    _order.OrderStatus = OrderStatus.purchaseMReceiving.GetHashCode();
                }
                    
                _order.Description = textBoxDescription.Text;
                tsbtnReceiving.Enabled = false;
                btnReceiving.Enabled = false;

                _order.ShippingTime = ShippingTime.Value;
                _order.ShippingAdress = textBoxShippingAdress.Text;
                _order.ShippingUnit = textBoxShippingUnit.Text;
                _order.TransportUnit = textBoxTransportUnit.Text;
                string orderNumber = this.PharmacyDatabaseService.CreatePurchaseReceivingOrderByEnity(out msg, _order, _orderDetails.ToArray());
                if (String.IsNullOrEmpty(msg))
                {
                    lblOrderStatus.Text = EnumHelper<OrderStatus>.GetDisplayValue((OrderStatus)_order.OrderStatus);
                    lblOrderNo.Text = orderNumber;
                    if (_order.OrderStatus == OrderStatus.PurchaseReceivingReject.GetHashCode())
                    {
                        MessageBox.Show("拒收");
                    }
                    if (_order.OrderStatus == OrderStatus.PurchaseReceinvingAmountDiff.GetHashCode())
                    {
                        MessageBox.Show("采购数量与到货数量不同，需经过审批修改采购数量");
                    }
                    else
                    {
                        MessageBox.Show("收货完成");
                        this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行采购单收货操作成功,采购单号："+_order.RelatedOrderDocumentNumber);
                        this.Close();
                    }
                }
                else
                {
                    tsbtnReceiving.Enabled = true;
                    btnReceiving.Enabled = true;
                    MessageBox.Show("收货失败,请联系管理员");
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行采购单收货操作失败,采购单号：" + _order.RelatedOrderDocumentNumber);
                }
            }
            catch
            {
                MessageBox.Show("收货失败,请联系管理员");
            }
        }

        private void TempCheckPromot()
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void tsbtnChecking_Click(object sender, EventArgs e)
        {
            try
            {
                PurchaseCommonEntity order = _order;
                List<PurchaseReceivingOrderDetailEntity> receivingOrderDetails = _orderDetails;

                List<PurchaseReceivingOrderDetailEntity> ListAddedCheckDetail = new List<PurchaseReceivingOrderDetailEntity>();

                #region 检验是否已经验货，由多次收货产生
                var pco = this.PharmacyDatabaseService.GetPurchaseCheckingOrdersByPurchaseOrderId(out msg,order.PurchaseOrderId).FirstOrDefault();
                if (pco != null)
                {

                    var pcd = from row in this.PharmacyDatabaseService.GetPurchaseCheckingOrderDetails(out msg, pco.Id)
                              group row by row.DrugInfoId into g
                              select new PurchaseCheckingOrderDetailEntity
                              {
                                  DrugInfoId = g.FirstOrDefault().DrugInfoId,
                                  ReceiveAmount = g.Sum(r => r.ReceiveAmount),
                              };

                    var receiveDetailDistinct = receivingOrderDetails.GroupBy(r => r.DrugInfoId);

                    foreach (var i in receiveDetailDistinct)
                    {
                        var FirstDetail = i.First();
                        var druginfoid = FirstDetail.DrugInfoId;

                        var pcde = pcd.Where(r => r.DrugInfoId == druginfoid).FirstOrDefault();
                        if (pcde != null)
                        {
                            FirstDetail.ActualAmount = receivingOrderDetails.Where(r => r.DrugInfoId == FirstDetail.DrugInfoId).Sum(r => r.ActualAmount) - pcde.ReceiveAmount;
                            FirstDetail.ReceiveAmount = FirstDetail.ActualAmount;
                        }

                        ListAddedCheckDetail.Add(FirstDetail);
                    }

                }
                else
                {
                    ListAddedCheckDetail.AddRange(receivingOrderDetails);
                }
                #endregion

                FormCheckOrder FormCheckOrder = new FormCheckOrder(order, ListAddedCheckDetail.Where(r => r.ActualAmount > 0).ToList());
                tsbtnChecking.Enabled = (FormCheckOrder.ShowDialog() != DialogResult.OK);
                this.Dispose();
            }
            catch(Exception ex)
            {
                ex = new Exception("打开验收窗体失败" + ex.Message);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnModifyPurchaseAmount_Click(object sender, EventArgs e)
        {
            //临时处理
            PurchaseOrder purchaseOrder=this.PharmacyDatabaseService.GetPurchaseOrder(out msg, _order.PurchaseOrderId);
            PurchaseOrdeEntity[] orderEntity=this.PharmacyDatabaseService.GetPurchaseOrders(out msg, purchaseOrder.DocumentNumber, DateTime.Now.AddYears(-100), DateTime.Now.AddYears(100), new int[] { }, new Guid[] { }, 1, 1);
            if (orderEntity.Count() > 0)
            {
                FormPurchaseOrderEdit form = new FormPurchaseOrderEdit(orderEntity[0], true);
                form.ShowDialog();
            }
            //_order.PurchaseOrderId;
            //FormPurchaseOrderEdit form = new FormPurchaseOrderEdit(selectedOrder);
            //form.ShowDialog();
        }

        private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            List<object> reportData = new List<object>();
            List<object> orderList = new List<object>();
            List<PurchaseReceivingOrderDetailEntity> orderDetails = new List<PurchaseReceivingOrderDetailEntity>();
            orderList.Add(_order);
            reportData.Add(orderList);
            foreach (var o in _orderDetails)
            {
                if (o.CheckResult == 0)
                {
                    o.CheckResultString = "确认收货";
                }
                else
                {
                    o.CheckResultString = "拒收";
                }
                orderDetails.Add(o);
            }
            reportData.Add(orderDetails);
            List<Microsoft.Reporting.WinForms.ReportParameter> ListPar = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            using (PrintHelper printHelper = new PrintHelper("Reports\\RptPurchaseReceivingOrder.rdlc", reportData, ListPar))
            {
                printHelper.Print();
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void 查看印模印章ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guid sid = _order.SupplyUnitId;
            BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(1, sid,true);
            Forms.Common.SetControls.SetControlReadonly(frm, true);
            frm.ShowDialog();
        }

        private void 查看票据样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guid sid = _order.SupplyUnitId;
            BaseDataManage.Form_Photo frm = new BaseDataManage.Form_Photo(2, sid,true);
            Forms.Common.SetControls.SetControlReadonly(frm, true);
            frm.ShowDialog();
        }

        private void FormReceivingOrder_Load(object sender, EventArgs e)
        {
            if (this._orderDetails.Count(r => r.BusinessScopeCode == Common.GoodsTypeClass.医疗器械.ToString()) == this._orderDetails.Count())
            {
                this.GoogsTypeClass = Common.GoodsTypeClass.医疗器械;
                this.Column1.Visible = false;
                this.LicensePermissionNumber.HeaderText = "注册证或备案凭证编号";
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1,"采购收货单");
        }
    }
}
