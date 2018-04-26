using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.PS;
using CustomValidatorsLibrary;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Service.Models;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class FormSalesOrderIndex : BaseFunctionForm
    {
        string msg = string.Empty;

        List<Business.Models.SaleOrderModel> so = null;
        private IList<User> userList = new List<User>();
        private IList<PaymentMethod> paymentList = new List<PaymentMethod>();
        private List<User> alluser = null;        
        /// <summary>
        /// 购货单位list，格式化数据时使用
        /// </summary>
        private List<PurchaseUnit> _ParchaseUnitList = new List<PurchaseUnit>();
        private List<string> formatField = new List<string>();
        Pharmacy.UI.Common.BaseRightMenu cms = null;

        private decimal d1;
        private decimal d2;

        public FormSalesOrderIndex()
        {
            try
            {
                InitializeComponent();
                this.dgvMain.AutoGenerateColumns = false;
                this.dgvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                this.dgvMain.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
                cms = new BaseRightMenu(this.dgvMain);
                cms.InsertMenuItem("打开销售单据", this.OpenSaleOrderDetail);
                cms.InsertMenuItem("只看该购货单位", this.GetSalesOrderByPurchaseUnit);
                cms.InsertMenuItem("只看该销售员", this.GetSalesOrderBySalerName);
                cms.InsertMenuItem("只看该开票员", this.GetSalesOrderByCreator);
                cms.InsertMenuItem("查看全部", this.GetAllSalesOrderInfo);
                cms.InsertMenuItem("查看复核单", this.GetSalesOrderCheckInfo);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void GetSalesOrderByPurchaseUnit()
        {
            Business.Models.SaleOrderModel som= this.dgvMain.CurrentRow.DataBoundItem as Business.Models.SaleOrderModel;
            var c = so.Where(r => r.PurchaseUnitName == som.PurchaseUnitName);
            this.dgvMain.DataSource = c.OrderBy(r=>r.BalanceTime).ToList();
        }
        private void GetSalesOrderBySalerName()
        {
            Business.Models.SaleOrderModel som = this.dgvMain.CurrentRow.DataBoundItem as Business.Models.SaleOrderModel;
            var c = so.Where(r => r.Saler == som.Saler);
            this.dgvMain.DataSource = c.OrderBy(r => r.BalanceTime).ToList();
        }
        private void GetSalesOrderByCreator()
        {
            Business.Models.SaleOrderModel som = this.dgvMain.CurrentRow.DataBoundItem as Business.Models.SaleOrderModel;
            var c = so.Where(r => r.Creater == som.Creater);
            this.dgvMain.DataSource = c.OrderBy(r => r.BalanceTime).ToList();
        }
        private void GetAllSalesOrderInfo()
        {            
            this.dgvMain.DataSource = this.so;
        }
        private void GetSalesOrderCheckInfo()
        {
            Business.Models.SaleOrderModel som = this.dgvMain.CurrentRow.DataBoundItem as Business.Models.SaleOrderModel;
            if (string.IsNullOrEmpty(som.CheckUserName))
            {
                MessageBox.Show("该单据暂未出库复核，无出库复核单据！");
                return;
            }
            
            FormOutInventory form = new FormOutInventory(som.Id,  true);
            form.ShowDialog();
        }

        
        private void FormSalesOrderIndex_Load(object sender, EventArgs e)
        {
            string msg = "";
            try
            {
                var list = Utility.CreateComboboxList<BugsBox.Pharmacy.Models.OrderStatus>();
                list.Insert(0,new ListItem() { Name = "全部", ID = null });
                this.cmbOrderType.DisplayMember = "Name";
                this.cmbOrderType.ValueMember = "ID";
                this.cmbOrderType.DataSource = list;
                this.cmbOrderType.SelectedIndex = 0;
                userList = PharmacyDatabaseService.AllUsers(out msg).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("窗体加载失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var ListUser = from i in userList
                        select new
                        {
                            py=i.Account,
                            name=i.Employee.Name
                        };
            
            var c=ListUser.ToList();
            c.Insert(0, new { py = "全部", name = string.Empty });
        
        }
        
        private void tsbtSearch_Click(object sender, EventArgs e)
        {
            this.GetListSalesOrder();
        }

        void linkLabel1_Click(object sender, EventArgs e)
        {
            FormSalesIndex frm = new FormSalesIndex((SalesOrderReturn[])(linkLabel1.Tag));
            frm.ShowDialog();
        }
        /// <summary>
        /// 获取搜索结果list
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        private void GetListSalesOrder()
        {
            try
            {
                Business.Models.SalesCodeSearchInput scsi = new SalesCodeSearchInput();
                scsi.FromDate = this.dtFrom.Value.Date;
                scsi.ToDate = this.dtTo.Value.AddDays(1).Date;
                scsi.Code = txtOrders.Text.Trim();
                scsi.purchaseKeyword = this.textBox2.Text.Trim();
                scsi.OrderStatusValue = Convert.ToInt16(this.cmbOrderType.SelectedValue);
                scsi.IsPreciselySearch = this.checkBox1.Checked;

                so = PharmacyDatabaseService.GetSalesOrderCodePaged(scsi, out msg).ToList();
                this.dgvMain.DataSource = new BindingCollection<Business.Models.SaleOrderModel>(so);
                decimal salePrice = (decimal)so.Sum(r => r.TotalPrice);
                d1 = salePrice;
                label4.Text += "销售单数量：" + so.Count.ToString("F4");

                SalesOrderReturn[] sors = this.PharmacyDatabaseService.GetSalesOrderReturnByCreateTime((DateTime)scsi.FromDate, (DateTime)scsi.ToDate, out msg).ToArray();
                
                if (sors.Length > 0)
                {
                    decimal returnPrice = sors.Sum(r => r.SalesOrderReturnDetails.Where(u => u.Deleted == false).Sum(u => u.ActualUnitPrice * u.ReturnAmount));
                    d2 = returnPrice;
                    label4.Text += "；退单数量：" + sors.Length.ToString("F0");

                    linkLabel1.Visible = true;
                    linkLabel1.Tag = sors;
                    linkLabel1.Left = label4.Left + label4.Width + 10;
                    linkLabel1.Click += new EventHandler(linkLabel1_Click);
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "成功提交查询统计操作");
                }
                else
                {
                    label4.Text += "；退单数量：" + (0).ToString("F0");
                    linkLabel1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据检索失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void txtOrders_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.GetListSalesOrder();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dgvMain, "配送出库单列表");
        }

        //private void dgvMain_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (this.dgvMain.SelectedCells.Count <= 0) return;
        //    if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
        //    this.cms.Show(MousePosition.X, MousePosition.Y);
        //}

        private void cmbSeller_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvMain.Columns[e.ColumnIndex].Name == this.Column1.Name)
            {
                OpenSaleOrderDetail();
            }            
        }

        private void OpenSaleOrderDetail()
        {
            var c = this.dgvMain.CurrentRow.DataBoundItem as Business.Models.SaleOrderModel;
            Guid sid = c.Id;
            SalesOrder so=this.PharmacyDatabaseService.GetSalesOrder(out msg,sid);
            FormSalesOrderEdit frm = new FormSalesOrderEdit(so, true);
            frm.ShowDialog();
        }

        private void gbSearch_Enter(object sender, EventArgs e)
        {

        }
    }
}
