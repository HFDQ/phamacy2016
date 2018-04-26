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
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class FormPurchaseOrderList : BaseFunctionForm
    {
        private PagerInfo pageInfo = new PagerInfo();
        private string orderNo = string.Empty;
        private int orderStatus = -1;
        private Dictionary<string, List<ListItem>> _InitFieldValues = new Dictionary<string, List<ListItem>>();

        private List<PurchaseOrdeEntity> _listPurchaseOrder = new List<PurchaseOrdeEntity>();
        private bool onlySearch = false;
        List<SupplyUnit> listSupplyer = new List<SupplyUnit>();
        string msg = string.Empty;

        public FormPurchaseOrderList()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            dtpFrom.Value = DateTime.Now.AddDays(-3);
            _InitFieldValues.Add("OrderStatusValue", EnumHelper<OrderStatus>.GetMapKeyValues());
        }

        public FormPurchaseOrderList(params object[] args)
            : this()
        {
            if (args != null && args.Length > 0)
            {
                if (args.Length == 1)
                {
                    onlySearch = true;
                    if (args[0].ToString() == "Query")
                    {
                        this.Text = "采购记录查询";
                    }
                    else
                    {
                        this.Text = "采购记录";
                    }
                }
            }
        }

        private void FormPurchaseOrderList_Load(object sender, EventArgs e)
        {
            BindComboBoxStatus();
            BindComboBoxSupply();
            btnSearch_Click(this, null);
            var all = PharmacyDatabaseService.AllSupplyUnits(out msg);
            listSupplyer = all.Where(r => r.Valid).ToList();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //进入编辑页面
            //获得当前采购单的状态
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                PurchaseOrdeEntity selectedOrder = _listPurchaseOrder[e.RowIndex];
                if (onlySearch)
                {
                    new FormPurchaseOrderEdit(selectedOrder, false, true).ShowDialog();
                }
                else
                {
                    FormPurchaseOrder form = new FormPurchaseOrder(selectedOrder);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();

        }
        private void Search()
        {
            try
            {
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
                string msg = String.Empty;
                _listPurchaseOrder = PharmacyDatabaseService.GetPurchaseOrders(out msg, this.txtOrderNo.Text.Trim(), this.dtpFrom.Value, this.dtpTo.Value, new int[] { orderStatus }, supplyIds, this.pagerControl1.PageIndex, this.pagerControl1.PageSize).ToList();
                if (_listPurchaseOrder.Count > 0)
                {
                    this.pagerControl1.RecordCount = _listPurchaseOrder[0].RecordCount;
                }
                else
                {
                    this.pagerControl1.RecordCount = 0;
                }
                this.dataGridView1.DataSource = _listPurchaseOrder;
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

        private void BindComboBoxStatus()
        {
            this.cmbOrderStatus.Items.Clear();
            this.cmbOrderStatus.Items.Add(new ListItem(OrderStatus.None.GetHashCode().ToString(), "所有"));
            this.cmbOrderStatus.Items.Add(new ListItem(OrderStatus.Waitting.GetHashCode().ToString(), "待审核"));
            this.cmbOrderStatus.Items.Add(new ListItem(OrderStatus.Approved.GetHashCode().ToString(), "已审核"));
            this.cmbOrderStatus.Items.Add(new ListItem(OrderStatus.Rejected.GetHashCode().ToString(), "拒绝"));
            this.cmbOrderStatus.Items.Add(new ListItem(OrderStatus.Canceled.GetHashCode().ToString(), "取消"));
            this.cmbOrderStatus.SelectedIndex = -1;
        }

        private void BindComboBoxSupply()
        {
            string msg = string.Empty;
            SupplyUnit []  listSupply = PharmacyDatabaseService.AllSupplyUnits(out msg);
            this.cmbSupply.DataSource = listSupply;
            this.cmbSupply.DisplayMember = "Name";
            this.cmbSupply.ValueMember = "Id";
            this.cmbSupply.SelectedIndex = -1;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = this.dataGridView1.Columns[e.ColumnIndex].DataPropertyName;
            if (_InitFieldValues.ContainsKey(columnName))
            {
                if (_InitFieldValues[columnName].Where(l => l.ID == e.Value.ToString()).FirstOrDefault() != null)
                {
                    e.Value = _InitFieldValues[columnName].Where(l => l.ID == e.Value.ToString()).FirstOrDefault().Name;
                }
            }
            if (e.RowIndex > -1)
            {
                this.dataGridView1.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();
            }
        }

        private void txtOrderNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Search();
            }
        }

        private void txtBoxPinyin_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbSupply.Text.Trim() == string.Empty) return;
            if (e.KeyCode == Keys.Return)
            {
                Search();
            }
        }

        private void txtBoxPinyin_TextChanged(object sender, EventArgs e)
        {
            if (this.txtBoxPinyin.Text.Trim().Equals(string.Empty)) return;
            string str = this.txtBoxPinyin.Text.Trim().ToUpper();
            var q = listSupplyer.Where(r => r.PinyinCode.ToUpper().Contains(str)).ToList();
            if (q == null) return;
            if (q.Count <= 0) return;
            this.cmbSupply.DataSource = q;
            this.cmbSupply.ValueMember = "id";
            this.cmbSupply.DisplayMember = "name";
            this.cmbSupply.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmbSupply.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmbSupply.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "采购记录汇总");
        }
    }
}
