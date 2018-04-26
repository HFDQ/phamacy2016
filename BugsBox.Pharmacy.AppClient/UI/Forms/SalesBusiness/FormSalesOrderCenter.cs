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
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class FormSalesOrderCenter : BaseFunctionForm
    {
        private int _Status;
        private List<string> formatField = new List<string>();
        BindingList<SalesOrder> bList = new BindingList<SalesOrder>();
        List<SalesOrder> listp = new List<SalesOrder>();
        string msg = string.Empty;
        List<Business.Models.PurchaseCommonEntity> pceList = null;

        public FormSalesOrderCenter()
        {
            InitializeComponent();
            this.dgvSalesOrderList.AutoGenerateColumns = false;
            this.Text = "销售单新建";
        }

        public FormSalesOrderCenter(object status)
        {
            InitializeComponent();
            this.Text = UpdateFormTitle(EnumHelper<OrderStatus>.Parse(status.ToString()));
            this._Status = (int)EnumHelper<OrderStatus>.Parse(status.ToString()); 
            this.dgvSalesOrderList.AutoGenerateColumns = false;

            if (EnumHelper<OrderStatus>.Parse(status.ToString())== OrderStatus.Banlaced)
            {
                toolStripLabel2.Visible = true;
                toolStripComboBox1.Visible = true;
            }
        }
        /// <summary>
        /// 初始化画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSalesOrderCenter_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
            formatField.Add("序号");
            formatField.Add("订单状态");


            this.toolStripComboBox1.SelectedIndex = 0;
        }

        private void dgvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.toolStripComboBox1.SelectedIndex == 1) return;
            if (e.RowIndex > -1)
            {
                if (formatField.Contains(dgvSalesOrderList.Columns[e.ColumnIndex].Name))
                {
                    var cellValue = dgvSalesOrderList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    string cellFormatValue = string.Empty;
                    switch (dgvSalesOrderList.Columns[e.ColumnIndex].Name)
                    {
                        case "序号":
                            cellFormatValue = (e.RowIndex + 1).ToString();
                            break;
                        case "订单状态":
                            if (cellValue != null)
                                cellFormatValue = Utility.getEnumTypeDisplayName<OrderStatus>((OrderStatus)cellValue);
                            break;                      
                    }
                    e.Value = cellFormatValue;
                }
            }
        }



        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSalesOrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex < 0)
            {
                return;
            }

            

            if (dgvSalesOrderList.Columns[e.ColumnIndex].Name == "查看详细")
            {
                if (this.toolStripComboBox1.SelectedIndex == 0)
                {
                    var entity = dgvSalesOrderList.Rows[e.RowIndex].DataBoundItem as SalesOrder;
                    FormSalesOrderEdit form = new FormSalesOrderEdit(entity);
                    form.ShowDialog();
                    btnRefresh_Click(sender, e);
                }
                else
                {

                    Forms.PurchaseBusiness.FormReturnOrder frm = new Forms.PurchaseBusiness.FormReturnOrder(pceList[e.RowIndex], false);
                    frm.ShowDialog();
                    if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        this.ReadPurchaseReturnOrderList();
                    }
                }
                //刷新画面
                
            }
        }

        /// <summary>
        /// 刷新画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            try
            {
                List<SalesOrder> list = null;
                if (_Status == (int)OrderStatus.Banlaced)
                {
                    list = PharmacyDatabaseService.GetOrderStatusList(out message, new int[] { _Status }).ToList();
                }
                else
                {
                    list = PharmacyDatabaseService.GetOrderStatusList(out message, new int[] { _Status }).ToList();
                }

                listp.Clear();
                bList.Clear();
                listp = list.OrderBy(r => r.CreateTime).ToList();
                
                foreach (var c in listp)
                {
                    bList.Add(c);
                }
                dgvSalesOrderList.DataSource = bList;
            }
            catch (Exception)
            {
                MessageBox.Show("订单检索失败!" + message);
            }
        }

        /// <summary>
        /// 更新Form Title
        /// </summary>
        /// <param name="status"></param>
        private string UpdateFormTitle(OrderStatus status)
        {
            string formTitle = string.Empty;
            switch (status)
            {
                case OrderStatus.None:
                    formTitle = "销退单新建";
                    break;
                case OrderStatus.Waitting:
                    formTitle = "销售审核";
                    break;
                case OrderStatus.Approved:
                    formTitle = "销售结算";
                    break;
                case OrderStatus.Banlaced:
                    formTitle = "销售出库";
                    break;
            }
            return formTitle;
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (listp.Count <= 0) return;
            var q = this.listp.Where(r => r.OrderCode.Contains(this.toolStripTextBox1.Text.Trim()));
            bList.Clear();
            foreach (var i in q)
            {
                bList.Add(i);
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clmSupplyer.Visible = this.toolStripComboBox1.SelectedIndex == 0 ? false : true;
            销售员.Visible = this.toolStripComboBox1.SelectedIndex == 0 ? true : false;
            switch (this.toolStripComboBox1.SelectedIndex)
            {
                case 0:
                    this.btnRefresh_Click(sender, e);
                    break;
                case 1:
                    this.ReadPurchaseReturnOrderList();
                    break;
            }
        }
        //采购退货列表
        private void ReadPurchaseReturnOrderList()
        {
            DateTime dtf = DateTime.Now.AddDays(-10000);
            DateTime dtt = DateTime.Now.AddDays(10000);
            pceList=this.PharmacyDatabaseService.GetPurchaseOrderReturns(out msg, string.Empty, dtf, dtt, new int[] { (int)OrderReturnStatus.ReturnPickup }, new Guid[]{}, 1, 1000000).ToList();
            
            var a = from i in pceList
                    select new purchaseOrderReturnModel
                    {
                        id = i.Id,
                        orderCode = i.DocumentNumber,
                        createTime = i.OperateTime,
                        OrderStatusValue="采退已审",
                        Supplyer = i.SupplyUnitName
                    };
            this.dgvSalesOrderList.DataSource = a.ToList();
        }
      
    }

    public class purchaseOrderReturnModel
    {
        public Guid id { get; set; }
        public string orderCode { get; set; }
        public DateTime createTime { get; set; }
        public string OrderStatusValue { get; set; }
        public string Supplyer { get; set; }
        public string saler { get; set; }
    }
}
