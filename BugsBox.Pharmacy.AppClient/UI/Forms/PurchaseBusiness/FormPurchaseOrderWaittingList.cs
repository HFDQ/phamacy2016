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
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class FormPurchaseOrderWaittingList : BaseFunctionForm
    {
        private PagerInfo pageInfo = new PagerInfo();
        private string orderNo = string.Empty;
        private int orderStatus = -1;
        private Dictionary<string, List<ListItem>> _InitFieldValues = new Dictionary<string, List<ListItem>>();

        private List<PurchaseOrdeEntity> _listPurchaseOrder = new List<PurchaseOrdeEntity>();

        public FormPurchaseOrderWaittingList()
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
            string msg = string.Empty;
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }
                PurchaseOrdeEntity selectedOrder = _listPurchaseOrder[e.RowIndex];
                PurchaseOrderDetail[] purchaseOrderList = PharmacyDatabaseService.GetPurchaseOrderDetailByOrderId(out msg, (Guid)selectedOrder.Id);
                var p=from i in purchaseOrderList where i.Deleted==false select i;
                //var q = from k in purchaseOrderList where k.Deleted select k;
                //foreach(var j in p)
                {
                    if (selectedOrder.OrderStatusValue == OrderStatus.PurchaseReceinvingAmountDiff.GetHashCode())
                    {
                        FormPurchaseOrderEdit form = new FormPurchaseOrderEdit(selectedOrder,true);
                        form.ShowDialog();
                    }
                    else
                    {
                        FormPurchaseOrderEdit form = new FormPurchaseOrderEdit(selectedOrder);
                        form.ShowDialog();
                    }
                    this.Search();
                }
                //foreach (var m in q)
                //{
                //    _listPurchaseOrder[e.RowIndex].OrderStatusValue = 120;
                //    MessageBox.Show("已删除");
                //    this.Search();
                //}
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
                orderStatus = OrderStatus.Waitting.GetHashCode();

                Guid[] supplyIds = new Guid[] { };
                if (cmbSupply.SelectedIndex != -1)
                {
                    supplyIds = new Guid[] { new Guid(cmbSupply.SelectedValue.ToString()) };
                }
                string msg = String.Empty;
                _listPurchaseOrder = PharmacyDatabaseService.GetPurchaseOrders(out msg, this.txtOrderNo.Text.Trim(), this.dtpFrom.Value, this.dtpTo.Value, new int[] { orderStatus,OrderStatus.PurchaseReceinvingAmountDiff.GetHashCode() }, supplyIds, this.pagerControl1.PageIndex, this.pagerControl1.PageSize).ToList();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
