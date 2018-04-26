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
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.UI.Report;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class FormInInventory : BaseFunctionForm
    {
        Common.GoodsTypeClass GoogsTypeClass { get; set; }

        private PurchaseCommonEntity _order = new PurchaseCommonEntity();
        private List<PurchaseInInventeryOrderDetailEntity> _orderDetails = new List<PurchaseInInventeryOrderDetailEntity>();
        string msg=string.Empty;
        private decimal paymentingAmount=0;
        
        BaseForm.BasicInfoRightMenu Bcms = null;

        BugsBox.Pharmacy.AppClient.UI.Ele_Lab EleModel = null;

        public FormInInventory()
        {
            InitializeComponent();

            #region 电子标签控制
            this.EleModel = SearialiserHelper<Ele_Lab>.DeSerializeFileToObj("EleSetup.bin");
            if (this.EleModel.IsEnabled)
            {
                this.toolStripButton1.Visible = true;//点亮按钮显示，配置标签后，可以显示
                if (elelab.unart_manage.com_manage.FirstOrDefault()==null)
                {
                    int[] ss = new int[] { int.Parse(this.EleModel.PortName.Substring(3)) };
                    elelab.unart_manage.init_com_sys(ss);//初始化串口
                }
            }
            #endregion

            this.Bcms = new BaseForm.BasicInfoRightMenu(this.dataGridView1);
            this.Bcms.InsertDrugBasicInfo();
            this.Bcms.InsertSupplyUnitBasicInfo();
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dataGridView1.CellMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_CellMouseClick);
        }

        void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            PurchaseInInventeryOrderDetailEntity piode = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as PurchaseInInventeryOrderDetailEntity;
            this.Bcms.DrugId = piode.DrugInfoId;
        }
        //查询入库单
        public FormInInventory(PurchaseCommonEntity order, bool onlySearch = false)
            : this()
        {
            string msg = String.Empty;
            _order = order;
            _orderDetails = this.PharmacyDatabaseService.GetPurchaseInInventeryOrderDetails(out msg, order.Id).ToList();
            this.PositionSelector.Visible = false;
            DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();
            dc.Name = "warehousezone";
            dc.HeaderText = "库区";
            dc.DataPropertyName = "WarehouseZoneName";
            dc.ReadOnly = true;
            this.dataGridView1.Columns.Add(dc);
            foreach (var o in _orderDetails)
            {
                paymentingAmount += o.ArrivalAmount * o.PurchasePrice;
            }

            this.Bcms.Sid = order.SupplyUnitId;//右键菜单查询供货商

            Initial(false);
            tsbtnInInventory.Visible = false;
            this.dataGridView1.ReadOnly = true;
            label5.Text = order.SupplyUnitName;
            textBoxDescription.Text = order.Description;
            if (onlySearch)
            {
                toolStripButtonCash.Visible = false;
                tsbtnInInventory.Visible = false;
            }
            if (tsbtnInInventory.Visible == true)
            {
                tsbtnInInventory.Visible = this.Authorize(ModuleKeys.PurchaseInInventory);
            }
        }

        //创建入库单
        public FormInInventory(PurchaseCommonEntity order, List<PurchaseCheckingOrderDetailEntity> orderDetails)
            : this()
        {
            _order.Description = "";
            _order.PurchaseOrderId = order.PurchaseOrderId;
            _order.OperateUserId = AppClientContext.CurrentUser.Id;
            _order.RelatedOrderDocumentNumber = order.DocumentNumber;
            _order.RelatedOrderId = order.Id;
            _order.RelatedOrderTypeValue = (int)OrderType.PurchaseCheckingOrder;
            _order.PurchaseOrderDocumentNumber = order.PurchaseOrderDocumentNumber;

            this.Bcms.Sid = order.SupplyUnitId;//右键菜单查询供货商

            foreach (PurchaseCheckingOrderDetailEntity d in orderDetails)
            {
                PurchaseInInventeryOrderDetailEntity c = new PurchaseInInventeryOrderDetailEntity();
                c.ArrivalAmount = d.QualifiedAmount;
                c.ArrivalDateTime = d.ArrivalDateTime;
                c.Decription = d.Decription;
                c.BatchNumber = d.BatchNumber;
                c.FactoryName = d.FactoryName;
                c.OutValidDate = d.OutValidDate;
                c.PruductDate = d.PruductDate;
                c.ProductGeneralName = d.ProductGeneralName;
                c.DictionarySpecificationCode = d.DictionarySpecificationCode;
                c.DictionaryMeasurementUnitCode = d.DictionaryMeasurementUnitCode;
                c.DrugInfoId = d.DrugInfoId;
                c.PurchasePrice = d.PurchasePrice;
                c.DictionaryDosageCode = d.DictionaryDosageCode;
                c.LicensePermissionNumber = d.LicensePermissionNumber;
                c.DictionaryStorageType = d.StorageType;
                c.DictionaryMeasurementUnitCode = d.DictionaryMeasurementUnitCode;
                c.sequence = d.sequence;
                c.BussinessScopeCode = d.BusinessScopeCode;
                c.WarehouseZoneId = Guid.Empty;
                c.WarehouseZonePositionId = Guid.Empty;
                _orderDetails.Add(c);
            }
            toolStripButtonCash.Visible = false;
            Initial(true);
            label5.Text = order.SupplyUnitName;
            if (tsbtnInInventory.Visible == true)
            {
                tsbtnInInventory.Visible = this.Authorize(ModuleKeys.PurchaseInInventory);
            }

            //选择货位
            this.dataGridView1.CellClick += (sender, e) =>
            {
                if (e.RowIndex < 0||e.ColumnIndex<0) return;
                if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name != this.PositionSelector.Name) return;
                var c = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as PurchaseInInventeryOrderDetailEntity;
                Form_WareHouseZonePositionSelector frm = new Form_WareHouseZonePositionSelector(c.DrugInfoId);
                frm.Show(this);
                frm.PositionSelected += (s, ex) =>
                {
                    var PositionModel = ex.PositionModel;
                    c.WarehouseName = ex.PositionModel.WareHouseName;
                    c.WarehouseZoneId = ex.PositionModel.WareHouseZoneId;
                    c.WarehouseZoneName=ex.PositionModel.WareHouseZoneName;
                    c.WarehouseZonePositionName = ex.PositionModel.Name;
                    c.WarehouseZonePositionId = ex.PositionModel.Id;
                    c.WarehouseZonePIndex = ex.PositionModel.WareHouseZonePIndex;
                    c.WarehouseZonePositionPIndex = ex.PositionModel.PIndex;
                    this.dataGridView1.Refresh();
                    this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                };                
            };
        }

        public void Initial(bool isCreate)
        {
            string msg = String.Empty;
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
                tsbtnInInventory.Visible = false;
                this.dataGridView1.ReadOnly = true;
            }

            if (this._orderDetails.Count(r => r.BussinessScopeCode.Contains("医疗器械")) == this._orderDetails.Count)
            {
                this.GoogsTypeClass = GoodsTypeClass.医疗器械;
                this.LicensePermissionNumber.HeaderText = "注册证或备案凭证编号";
                this.Decription.Visible = false;
            }
          
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = _orderDetails;//绑定列表

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                string bs = PharmacyDatabaseService.GetDrugInfo(out msg, _orderDetails[r.Index].DrugInfoId).BusinessScopeCode;
                if (bs.Contains("中药材") || bs.Contains("中药饮片"))
                {
                    if (bs.Contains("中药材"))
                    {
                        this.dataGridView1.Columns[this.FactoryName.Name].Visible = false;
                    }
                    this.tsbtnPrint.Visible = false;
                    break;
                }
                else
                {
                    this.dataGridView1.Columns[this.Decription.Name].Visible = false;
                    break;
                }
            }
        }

        private void tsbtnAccept_Click_1(object sender, EventArgs e)
        {
            this.tsbtnInInventory.Enabled = false;
            if (this.EleModel.IsEnabled)
            {
                int count = this._orderDetails.Where(r => r.WarehouseZonePositionId == Guid.Empty).Count();
                if (count > 0)
                {
                    var re = MessageBox.Show("您还有"+count+"条入库药品没有设定货位，仍然需要继续提交吗？","提示",MessageBoxButtons.OKCancel);
                    if (re == System.Windows.Forms.DialogResult.Cancel)
                    {
                        this.tsbtnInInventory.Enabled = true;
                        return;
                    }
                }
            }
            try
            {
                string msg = String.Empty;
                PurchaseInInventeryOrderDetailEntity[] ds = new PurchaseInInventeryOrderDetailEntity[this.dataGridView1.Rows.Count];
               
                _order.OrderStatus = OrderStatus.PurchaseInInventory.GetHashCode();
                _order.Description = textBoxDescription.Text;
                tsbtnInInventory.Enabled = false;
                string orderNumber = this.PharmacyDatabaseService.CreatePurchaseInInventeryOrderByEnity(out msg, _order, _orderDetails.ToArray());

                MessageBox.Show(orderNumber);

                if (String.IsNullOrEmpty(msg))
                {
                    lblOrderStatus.Text = EnumHelper<OrderStatus>.GetDisplayValue((OrderStatus)_order.OrderStatus);
                    lblOrderNo.Text = orderNumber;
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行采购单入库操作成功，采购单号：" + _order.PurchaseOrderDocumentNumber);
                    MessageBox.Show("入库完成");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("入库失败,请联系管理员");
                }
            }
            catch
            {
                MessageBox.Show("入库失败,请联系管理员");
            }
        }
        
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("WarehouseZoneName"))
                {
                    FormWarehouseZoneSelector selector = new FormWarehouseZoneSelector();
                    selector.ShowDialog();
                    if (selector.Result != null)
                    {
                        this.dataGridView1.Rows[e.RowIndex].Cells["WarehouseZoneName"].Value = selector.Result.Name;
                        this.dataGridView1.Rows[e.RowIndex].Cells["WarehouseZoneId"].Value = selector.Result.Id;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormCashOrder form = new FormCashOrder(_order, DealerMethod.PurchaseInInventory, paymentingAmount, true,OrderType.PurchaseInInventeryOrder);
            toolStripButtonCash.Enabled = (form.ShowDialog() != DialogResult.OK);
        }

        private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            List<object> reportData = new List<object>();
            List<object> orderList = new List<object>();
         
            orderList.Add(_order);
            reportData.Add(orderList);
            reportData.Add(_orderDetails);
            List<Microsoft.Reporting.WinForms.ReportParameter> ListPar = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            using (PrintHelper printHelper = new PrintHelper("BugsBox.Pharmacy.AppClient.UI.Reports.RptPurchaseInInventoryOrder.rdlc", reportData,ListPar))
            {
                printHelper.Print();
            }
        }

        private void dataGridView1_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            List<object> reportData = new List<object>();
            List<object> orderList = new List<object>();

            orderList.Add(_order);
            reportData.Add(orderList);
            reportData.Add(_orderDetails);
            List<Microsoft.Reporting.WinForms.ReportParameter> ListPar = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            using (PrintHelper printHelper = new PrintHelper("BugsBox.Pharmacy.AppClient.UI.Reports.Report1.rdlc", reportData,ListPar))
            {
                printHelper.Print();
            }
        }

        //点亮事件
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;

            byte Port = byte.Parse(this.EleModel.PortName.Substring(3));
            var c = this._orderDetails.Where(r=>r.WarehouseZonePositionId!=Guid.Empty).ToList();

            List<string> LabelId = new List<string>();
            List<string> LabelAddress = new List<string>();
            List<string> labelNumber = new List<string>();
            foreach (var r in c)
            {
                LabelId.Add(r.WarehouseZonePIndex.ToString());
                LabelAddress.Add(r.WarehouseZonePositionPIndex.ToString());
                labelNumber.Add(r.ArrivalAmount.ToString());
            }
            byte documentNumber =byte.Parse( this._order.RelatedOrderDocumentNumber.Substring(this._order.RelatedOrderDocumentNumber.Length - 2));
            elelab.pick.make_data(null, this.EleModel.PurchaseInInventoryLed, documentNumber, Port, LabelId.ToArray(), LabelAddress.ToArray(), labelNumber.ToArray());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "采购入库单");
        }
    }
}
