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
    public partial class FormPurchaseOrderCanceledList : BaseFunctionForm
    {
        private PagerInfo pageInfo = new PagerInfo();
        private string orderNo = string.Empty;
        private int orderStatus = -1;
        private Dictionary<string, List<ListItem>> _InitFieldValues = new Dictionary<string, List<ListItem>>();

        private List<PurchaseOrdeEntity> _listPurchaseOrder = new List<PurchaseOrdeEntity>();

        public FormPurchaseOrderCanceledList()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            dtpFrom.Value = DateTime.Now.AddDays(-3);
            _InitFieldValues.Add("OrderStatusValue", EnumHelper<OrderStatus>.GetMapKeyValues());
        }

        private void FormPurchaseOrderList_Load(object sender, EventArgs e)
        {
            BindComboBoxSupply();
            btnSearch_Click(this, null);
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
                FormPurchaseOrderEdit form = new FormPurchaseOrderEdit(selectedOrder);
                form.ShowDialog();
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
                orderStatus = OrderStatus.Canceled.GetHashCode();
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
        }

        
    }
}
