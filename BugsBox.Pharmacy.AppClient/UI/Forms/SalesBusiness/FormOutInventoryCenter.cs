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
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class FormOutInventoryCenter : BaseFunctionForm
    {
        public OutInventoryStatus Status { get; set; }
        private List<SalesOrderOutInventoryModel> list = new List<SalesOrderOutInventoryModel>();
        List<Business.Models.PurchaseCommonEntity> pceList = null;
        List<User> user = new List<User>();
        string msg = string.Empty;

        BaseRightMenu brm = null;
        public FormOutInventoryCenter(object iStatus)
        {
            InitializeComponent();

            #region 初始化Gridview和右键
            this.dgvOutInventory.RowPostPaint += delegate (object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dgvOutInventory.AutoGenerateColumns = false;
            this.dgvOutInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOutInventory.RowHeadersVisible = true;
            this.brm = new BaseRightMenu(this.dgvOutInventory);            
            #endregion
           
            User CurrentUsr = AppClientContext.CurrentUser;
            this.Status = EnumHelper<OutInventoryStatus>.Parse(iStatus.ToString());
            this.Text = UpdateFormTitle(EnumHelper<OutInventoryStatus>.Parse(iStatus.ToString()));
            string name = CurrentUsr.Employee.Name;
                       
            this.toolStripComboBox1.SelectedIndex = 0;

            user = this.PharmacyDatabaseService.GetAllUsers(out msg).ToList();
        }
        
        private void dgvOutInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var entity = dgvOutInventory.Rows[e.RowIndex].DataBoundItem as Business.Models.SalesOrderOutInventoryModel;

            if (dgvOutInventory.Columns[e.ColumnIndex].Name == "查看详细")
            {
                if (this.toolStripComboBox1.SelectedIndex == 0)
                {
                    FormOutInventory form = new FormOutInventory(entity.SalesOrderId, entity.Id);
                    form.ShowDialog();
                }
                else
                {
                    Forms.PurchaseBusiness.FormReturnOrder frm = new Forms.PurchaseBusiness.FormReturnOrder(pceList[e.RowIndex], false);
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.ReadPurchaseReturnOrderList();
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            try
            {
                //this.list = PharmacyDatabaseService.GetOutInventoryByStatus(out message, (int)this.Status).OrderBy(r => r.CreateTime).ToList();

                Business.Models.SalesOrderOutInventoryQueryModel q = new Business.Models.SalesOrderOutInventoryQueryModel
                {
                    OutInventoryStatusValue = (int)this.Status,
                    FirstCheckerUserId=base.CurrentUser.Id,
                    SecondCheckerUserInd=base.CurrentUser.Id
                };
                this.list = PharmacyDatabaseService.GetWaitingOutInventoryList(q, out msg).ToList();
                dgvOutInventory.DataSource = list;                
            }
            catch (Exception)
            {
                MessageBox.Show("检索出库单失败!" + message);
            }
        }

        private string UpdateFormTitle(OutInventoryStatus status)
        {
            string formTitle = string.Empty;
            switch (status)
            {
                case OutInventoryStatus.None:
                    formTitle = "拣货单新建";
                    break;
                case OutInventoryStatus.Outing:
                    formTitle = "出库复核";
                    break;
                case OutInventoryStatus.Returning:
                    formTitle = "销退申请处理";
                    break;
                case OutInventoryStatus.important:
                    formTitle = "特殊药品二次复核";
                    break;
            }
            return formTitle;
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (list.Count <= 0) return;
            var q = this.list.Where(r => r.OrderCode.Contains(this.toolStripTextBox1.Text.Trim()));
            this.dgvOutInventory.DataSource = null;
            this.dgvOutInventory.DataSource = q.ToList();
            this.dgvOutInventory.Refresh();            
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            制单人.Visible = this.toolStripComboBox1.SelectedIndex == 0 ? false : true;
            保管员.Visible = this.toolStripComboBox1.SelectedIndex == 1 ? false : true;
            出库单号.Visible = this.toolStripComboBox1.SelectedIndex == 1 ? false : true;
            if (this.toolStripComboBox1.SelectedIndex == 0)
            {
                this.btnRefresh_Click(sender, e);
            }
            else
            {
                this.ReadPurchaseReturnOrderList();
            }
        }

        private void ReadPurchaseReturnOrderList()
        {
            DateTime dtf = DateTime.Now.AddDays(-10000);
            DateTime dtt = DateTime.Now.AddDays(10000);
            pceList = this.PharmacyDatabaseService.GetPurchaseOrderReturns(out msg, string.Empty, dtf, dtt, new int[] { (int)OrderReturnStatus.ReturnPickupChecked }, new Guid[] { }, 1, 1000000).ToList();

            var a = from i in pceList
                    select new purchaseOrderReturnModel
                    {
                        id = i.Id,
                        orderCode = i.DocumentNumber,
                        createTime = i.OperateTime,
                        OrderStatusValue = "采退已拣货",
                        Supplyer = i.SupplyUnitName,
                        saler = i.EmployeeName
                    };
            this.dgvOutInventory.DataSource = a.ToList();
        }
    }
}
