using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseForm
{
    public partial class FormOrderList : BaseFunctionForm
    {
        private List<PurchaseCommonEntity> _listPurchaseCommonEntity = new List<PurchaseCommonEntity>();
        Dictionary<string, string> HeaderTexts = new Dictionary<string, string>();
        private Dictionary<string, List<ListItem>> _InitFieldValues = new Dictionary<string, List<ListItem>>();
        private OrderType _orderType = OrderType.PurchaseReceivingOrder;
        private bool onlySearch = false;
        private int returnState = -1;
        ContextMenuStrip cms = new ContextMenuStrip();
        string msg = string.Empty;

        public FormOrderList()
        {
            InitializeComponent();
            Initial();
        }

        public FormOrderList(params object[] args)
        {
            InitializeComponent();
            Initial(args);
        }

        private void Initial(object[] args = null)
        {
            if (!DesignMode)
            {
                try
                {
                   
                    this.dataGridView1.AutoGenerateColumns = false;
                    
                    if (args != null && args.Length > 0)
                    {
                        string msg = string.Empty;
                        this.Text = EnumHelper<OrderType>.GetDisplayValue(EnumHelper<OrderType>.Parse(args[0].ToString()));
                        _orderType = EnumHelper<OrderType>.Parse(args[0].ToString());
                        BindComboBoxStatus();
                        if (args.Length == 2)
                        {
                            switch (_orderType)
                            {
                                case OrderType.PurchaseReceivingOrder:
                                    label1.Text = "采购记录号";
                                    this.Text = "收货记录查询";
                                    break;
                                case OrderType.PurchaseCheckingOrder:
                                    this.Text = "验收记录查询";
                                    break;
                                case OrderType.PurchaseInInventeryOrder:
                                    this.Text = "入库记录查询";
                                    break;
                                case OrderType.PurchaseOrder:
                                    this.Text = "采购记录查询";
                                    break;
                                case OrderType.PurchaseOrderReturn:
                                    this.Text = "退货记录查询";
                                    returnState = Convert.ToInt16(args[1]);
                                    break;
                            }
                            
                            onlySearch = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("请联系管理员,配置正确的菜单项");
                    }
                    if (_orderType == OrderType.PurchaseOrderReturn)
                    {
                        _InitFieldValues.Add("OrderStatus", EnumHelper<OrderReturnStatus>.GetMapKeyValues());
                    }
                    else
                    {
                        _InitFieldValues.Add("OrderStatus", EnumHelper<OrderStatus>.GetMapKeyValues());
                    }
                    _InitFieldValues.Add("RelatedOrderTypeValue", EnumHelper<OrderType>.GetMapKeyValues());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            dtpFrom.Value = DateTime.Now.AddDays(-3);
        }

        private void RightMenu()
        {            
            cms.Items.Add("单元格操作");
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("复制 Ctrl+C", null, delegate(object sender, EventArgs e) { this.RightMenuClick(0); });
            cms.Items.Add("-");
            cms.Items.Add("单据操作");
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("打开验收单据", null, delegate(object sender, EventArgs e) { this.RightMenuClick(1); });
            cms.Items.Add("刷新列表", null, delegate(object sender, EventArgs e) { this.RightMenuClick(2); });
            cms.Items.Add("-");
            cms.Items.Add("查看操作");
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("查询历史采购单", null, delegate(object sender, EventArgs e) { this.RightMenuClick(3); });
            cms.Items.Add("-");
            cms.Items.Add("打开采购订单", null, delegate(object sender, EventArgs e) { this.RightMenuClick(4); });
            cms.Items.Add("-");
            cms.Items.Add("打开采购收货单", null, delegate(object sender, EventArgs e) { this.RightMenuClick(5); });
            cms.Items.Add("-");
            cms.Items.Add("打开采购入库单", null, delegate(object sender, EventArgs e) { this.RightMenuClick(6); });

        }
        private void RightMenuClick(int type)
        {
            if (type == 0)
            {
                Clipboard.SetData(DataFormats.Text,this.dataGridView1.CurrentCell.Value.ToString());
            }
            if (type == 1)
            {
                this.Open();
            }
            if (type == 2)
            {
                this.Search();
            }
            if (type == 3)
            {
                Guid sid=(this.dataGridView1.CurrentRow.DataBoundItem as PurchaseCommonEntity).SupplyUnitId;
                FormPurchaseHistoryBySupplyer frm = new FormPurchaseHistoryBySupplyer(string.Empty, sid, DateTime.Now.AddYears(-3).Date, DateTime.Now.AddDays(1).Date);
                frm.Show(this);
            }
            if (type == 4)
            {
                Guid pid=(this.dataGridView1.CurrentRow.DataBoundItem as PurchaseCommonEntity).PurchaseOrderId;
                var po=this.PharmacyDatabaseService.GetPurchaseOrderEntity(out msg,pid);
                PurchaseBusiness.FormPurchaseOrderEdit frm = new FormPurchaseOrderEdit(po, false, true);
                frm.Show(this);
            }
            if (type == 5)
            {
                Guid pid = (this.dataGridView1.CurrentRow.DataBoundItem as PurchaseCommonEntity).PurchaseOrderId;
                PurchaseCommonEntity pcod = this.PharmacyDatabaseService.GetPurchaseReceivingOrdersByPurchaseOrderId(out msg, pid).FirstOrDefault();
                if (pcod == null)
                {
                    MessageBox.Show("该单据无收货单信息，请联系管理员！"); return;
                }
                FormReceivingOrder frm = new FormReceivingOrder(pcod, true);
                frm.Show(this);
            }
            if (type == 6)
            {
                Guid Pid = (this.dataGridView1.CurrentRow.DataBoundItem as PurchaseCommonEntity).PurchaseOrderId;
                PurchaseCommonEntity pcod = this.PharmacyDatabaseService.GetPurchaseInInventeryOrdersByPurchaseOrderId(out msg, Pid).FirstOrDefault();
                if (pcod == null)
                {
                    MessageBox.Show("该单据暂无入库信息！"); return;
                }
                FormInInventory frm = new FormInInventory(pcod, true);
                frm.Show(this);
            }

        }

        private void FormOrderList_Load(object sender, EventArgs e)
        {
            this.RightMenu();
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            btnSearch_Click(this, null);
        }

        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            try
            {
                BindDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void pagerControl1_DataPaging()
        {
            Search();
        }
                

        //绑定数据源
        private void BindDataSource()
        {
            try
            {
                string msg = String.Empty;
                string orderNumber = txtOrderNo.Text.Trim();
                DateTime startTime = this.dtpFrom.Value;
                DateTime endTime = this.dtpTo.Value;
                int orderStatus = -1;

                if (cmbOrderStatus.SelectedIndex != -1)
                {
                    orderStatus = Int32.Parse(((ListItem)(cmbOrderStatus.SelectedItem)).ID.ToString());
                }
                else
                {
                    orderStatus = -1;
                }

                Guid[] supplyIds = new Guid[] { };
                if (cmbSupply.SelectedIndex != -1)
                {
                    supplyIds = new Guid[] { new Guid(cmbSupply.SelectedValue.ToString()) };
                }
                switch (_orderType)
                {
                    case OrderType.PurchaseReceivingOrder:
                        _listPurchaseCommonEntity = this.PharmacyDatabaseService.GetPurchaseReceivingOrders(out msg, orderNumber, startTime, endTime, new int[] { orderStatus}, supplyIds, this.pagerControl1.PageIndex, this.pagerControl1.PageSize).ToList();
                        break;
                    case OrderType.PurchaseCheckingOrder:
                        EmployeeName.HeaderText = "质检员";
                        _listPurchaseCommonEntity = this.PharmacyDatabaseService.GetPurchaseCheckingOrders(out msg, orderNumber, startTime, endTime, new int[] { orderStatus }, supplyIds, this.pagerControl1.PageIndex, this.pagerControl1.PageSize).ToList();
                        break;
                    case OrderType.PurchaseInInventeryOrder:
                        EmployeeName.HeaderText = "库管员";
                        _listPurchaseCommonEntity = this.PharmacyDatabaseService.GetPurchaseInInventeryOrders(out msg, orderNumber, startTime, endTime, new int[] { orderStatus }, supplyIds, this.pagerControl1.PageIndex, this.pagerControl1.PageSize).ToList();
                        break;
                    case OrderType.PurchaseBillingOrder:
                        EmployeeName.HeaderText = "财务员";
                        _listPurchaseCommonEntity = this.PharmacyDatabaseService.GetPurchaseCashOrders(out msg, orderNumber, startTime, endTime, new int[] { orderStatus }, supplyIds, this.pagerControl1.PageIndex, this.pagerControl1.PageSize).ToList();
                        break;
                    case OrderType.PurchaseOrderReturn:
                        EmployeeName.HeaderText = "制单人";
                        _listPurchaseCommonEntity = this.PharmacyDatabaseService.GetPurchaseOrderReturns(out msg, orderNumber, startTime, endTime, new int[] { returnState }, supplyIds, this.pagerControl1.PageIndex, this.pagerControl1.PageSize).ToList();
                        break;

                }

                if (!string.IsNullOrEmpty(msg))
                {
                    MessageBox.Show(msg);
                    Log.Error(msg);
                    return;
                }

                if (_listPurchaseCommonEntity.Count > 0)
                {
                    this.pagerControl1.RecordCount = _listPurchaseCommonEntity[0].RecordCount;
                }
                else
                {
                    this.pagerControl1.RecordCount = 0;
                }
                this.dataGridView1.DataSource = _listPurchaseCommonEntity;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void BindComboBoxStatus()
        {
            this.cmbOrderStatus.Items.Clear();
            switch (_orderType)
            {
                case OrderType.PurchaseReceivingOrder:
                    this.cmbOrderStatus.Items.Add(new ListItem(BugsBox.Pharmacy.Models.OrderStatus.None.GetHashCode().ToString(), "所有"));
                    this.cmbOrderStatus.Items.Add(new ListItem(BugsBox.Pharmacy.Models.OrderStatus.PurchaseReceiving.GetHashCode().ToString(), "收货"));
                    this.cmbOrderStatus.Items.Add(new ListItem(BugsBox.Pharmacy.Models.OrderStatus.PurchaseCheck.GetHashCode().ToString(), "验收"));
                    this.cmbOrderStatus.SelectedIndex = 1;
                    break;
                case OrderType.PurchaseCheckingOrder:
                    this.cmbOrderStatus.Items.Add(new ListItem(BugsBox.Pharmacy.Models.OrderStatus.None.GetHashCode().ToString(), "所有"));
                    this.cmbOrderStatus.Items.Add(new ListItem(BugsBox.Pharmacy.Models.OrderStatus.PurchaseCheck.GetHashCode().ToString(), "验收"));
                    this.cmbOrderStatus.Items.Add(new ListItem(BugsBox.Pharmacy.Models.OrderStatus.PurchaseInInventory.GetHashCode().ToString(), "入库"));
                    this.cmbOrderStatus.SelectedIndex = 1;
                    break;
                case OrderType.PurchaseInInventeryOrder:
                    this.cmbOrderStatus.Items.Add(new ListItem(BugsBox.Pharmacy.Models.OrderStatus.None.GetHashCode().ToString(), "所有"));
                    this.cmbOrderStatus.Items.Add(new ListItem(BugsBox.Pharmacy.Models.OrderStatus.PurchaseInInventory.GetHashCode().ToString(), "入库"));
                    this.cmbOrderStatus.Items.Add(new ListItem(BugsBox.Pharmacy.Models.OrderStatus.BillAccount.GetHashCode().ToString(), "结算"));
                    this.cmbOrderStatus.SelectedIndex = -1;
                    break;
                case OrderType.PurchaseBillingOrder:
                    break;
                case OrderType.PurchaseOrderReturn:
                    this.cmbOrderStatus.Items.Add(new ListItem(BugsBox.Pharmacy.Models.OrderReturnStatus.None.GetHashCode().ToString(), "所有"));
                    this.cmbOrderStatus.Items.Add(new ListItem(BugsBox.Pharmacy.Models.OrderReturnStatus.Canceled.GetHashCode().ToString(), EnumHelper<OrderReturnStatus>.GetDisplayValue(OrderReturnStatus.Canceled)));
                    this.cmbOrderStatus.Items.Add(new ListItem(BugsBox.Pharmacy.Models.OrderReturnStatus.Rejected.GetHashCode().ToString(), EnumHelper<OrderReturnStatus>.GetDisplayValue(OrderReturnStatus.Rejected)));
                    this.cmbOrderStatus.Items.Add(new ListItem(BugsBox.Pharmacy.Models.OrderReturnStatus.QualityApproved.GetHashCode().ToString(), EnumHelper<OrderReturnStatus>.GetDisplayValue(OrderReturnStatus.QualityApproved)));
                    this.cmbOrderStatus.Items.Add(new ListItem(BugsBox.Pharmacy.Models.OrderReturnStatus.GeneralManagerApproved.GetHashCode().ToString(), EnumHelper<OrderReturnStatus>.GetDisplayValue(OrderReturnStatus.GeneralManagerApproved)));
                    this.cmbOrderStatus.Items.Add(new ListItem(BugsBox.Pharmacy.Models.OrderReturnStatus.FinanceDepartmentApproved.GetHashCode().ToString(), EnumHelper<OrderReturnStatus>.GetDisplayValue(OrderReturnStatus.FinanceDepartmentApproved)));
                    this.cmbOrderStatus.Items.Add(new ListItem(BugsBox.Pharmacy.Models.OrderReturnStatus.Over.GetHashCode().ToString(), EnumHelper<OrderReturnStatus>.GetDisplayValue(OrderReturnStatus.Over)));
                        this.cmbOrderStatus.SelectedIndex = -1;
                    break;
            }

            
        }

        private void BindComboBoxSupply()
        {
            string msg = string.Empty;
            SupplyUnit[] listSupply = PharmacyDatabaseService.AllSupplyUnits(out msg);
            this.cmbSupply.DataSource = listSupply;
            this.cmbSupply.DisplayMember = "Name";
            this.cmbSupply.ValueMember = "Id";

            this.cmbSupply.SelectedIndex = -1;
        }

        private void dataGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = this.dataGridView1.Columns[e.ColumnIndex].DataPropertyName;
            if (_InitFieldValues.ContainsKey(columnName))
            {
                if (_InitFieldValues[columnName].Where(l =>e.Value!=null && l.ID == e.Value.ToString()).FirstOrDefault() != null)
                {
                    e.Value = _InitFieldValues[columnName].Where(l => l.ID == e.Value.ToString()).FirstOrDefault().Name;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Open();
        }

        private void Open()
        {
            try
            {
                if (this.dataGridView1.CurrentRow.Index< 0)
                {
                    return;
                }
                int RowIndex = this.dataGridView1.CurrentRow.Index;
                switch (_orderType)
                {
                    case OrderType.PurchaseReceivingOrder:
                        PurchaseCommonEntity selectedOrder = (PurchaseCommonEntity)_listPurchaseCommonEntity[RowIndex];
                        FormReceivingOrder form = new FormReceivingOrder(selectedOrder, onlySearch);
                        form.ShowDialog();

                        btnSearch_Click(this, null);

                        break;
                    case OrderType.PurchaseCheckingOrder:
                        FormCheckOrder formCheckingOrder = new FormCheckOrder((PurchaseCommonEntity)_listPurchaseCommonEntity[RowIndex], onlySearch);
                        formCheckingOrder.ShowDialog();
                        btnSearch_Click(this, null);
                        break;
                    case OrderType.PurchaseInInventeryOrder:
                        FormInInventory formInInventory = new FormInInventory((PurchaseCommonEntity)_listPurchaseCommonEntity[RowIndex], onlySearch);
                        formInInventory.ShowDialog();

                        btnSearch_Click(this, null);

                        break;
                    case OrderType.PurchaseBillingOrder:
                        FormCashOrder formCashOrder = new FormCashOrder((PurchaseCommonEntity)_listPurchaseCommonEntity[RowIndex]);
                        formCashOrder.ShowDialog();
                        btnSearch_Click(this, null);
                        break;

                    case OrderType.PurchaseOrderReturn:
                        FormReturnOrder frm = new FormReturnOrder((PurchaseCommonEntity)_listPurchaseCommonEntity[RowIndex], false);
                        frm.ShowDialog();
                        if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                        {
                            btnSearch_Click(this, null);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
            if (e.RowIndex < 0 || e.RowIndex < 0) return;
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            this.dataGridView1.CurrentCell.Selected = true;
            this.cms.Show(MousePosition.X, MousePosition.Y);
        }
    }
}
