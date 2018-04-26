using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DeliveryBusiness
{
    public partial class FormDeliveryCenter :BaseFunctionForm
    {
        public List<Business.Models.DeliveryTrasactionModel> DeliveryList { get; set; }
        public DeliveryStatus deliveryStatus;
        private List<SalesOrder> orderList = new List<SalesOrder>();
        string msg = string.Empty;
        public FormDeliveryCenter()
        {
            InitializeComponent();
            this.dgvDelivery.AutoGenerateColumns = true;
        }

         /// <summary>
        /// 
        /// </summary>
        public FormDeliveryCenter(object status)
        {
            this.deliveryStatus = EnumHelper<DeliveryStatus>.Parse(status.ToString());
            InitializeComponent();
            this.dgvDelivery.AutoGenerateColumns = false;
            this.Text = UpdateFormTitle(deliveryStatus);
            string msg = string.Empty;
            this.dgvDelivery.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dgvDelivery.CellClick += new DataGridViewCellEventHandler(dgvDelivery_CellClick);
            this.pager.DataPaging+=new PagerControl.PagerControl.Paging(pager_DataPaging);
            this.toolStripButton1.Click += new EventHandler(toolStripButton1_Click);
        }

        void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.pager_DataPaging();
        }

        void dgvDelivery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                var currentData = this.dgvDelivery.Rows[e.RowIndex].DataBoundItem as Business.Models.DeliveryTrasactionModel;
                
                //打开出库单
                if (this.dgvDelivery.Columns[e.ColumnIndex].Name == this.Column1.Name)
                {
                    if (currentData.Status == 0)
                    {
                        FormOutInventory frm = new FormOutInventory(currentData.SalesOrderId, currentData.OutInvetoryId, true);
                        frm.ShowDialog();
                    }
                    if (currentData.Status == 1)
                    {
                        PurchaseCommonEntity pce = this.PharmacyDatabaseService.GetPurchaseOrderReturnsByPurchaseOrderId(out msg, currentData.SalesOrderId).FirstOrDefault();
                        if (pce == null) return;
                        PurchaseBusiness.FormReturnOrder frm = new PurchaseBusiness.FormReturnOrder(pce, true);
                        frm.ShowDialog();
                    }
                }

                #region 打开销售客户或者供货商信息
                if (this.dgvDelivery.Columns[e.ColumnIndex].Name == this.Column2.Name)
                {
                    if (currentData.Status == 1)//打开采购退货商基础信息
                    {
                        SupplyUnit su = this.PharmacyDatabaseService.GetSupplyUnit(out msg, currentData.ReceivingCompasnyID);
                        UserControls.ucSupplyUnit us = new UserControls.ucSupplyUnit(su, false);
                        Form f = new Form();
                        f.Text = su.Name;
                        f.AutoSize = true;
                        f.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                        Panel p = new Panel();
                        p.AutoSize = true;
                        p.Controls.Add(us);
                        f.Controls.Add(p);
                        f.ShowDialog();
                    }
                    if (currentData.Status == 0)//打开销售客户基础信息
                    {
                        PurchaseUnit pu = this.PharmacyDatabaseService.GetPurchaseUnit(out msg, currentData.ReceivingCompasnyID);
                        if (pu == null) return;
                        UserControls.ucPurchaseUnit us = new UserControls.ucPurchaseUnit(pu, false);
                        Form f = new Form();
                        f.Text = pu.Name;
                        f.AutoSize = true;
                        f.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                        f.StartPosition = FormStartPosition.CenterScreen;
                        Panel p = new Panel();
                        p.AutoSize = true;
                        p.Controls.Add(us);
                        f.Controls.Add(p);
                        f.ShowDialog();
                    }
                }
                #endregion

                //打开发货处理画面
                if (this.dgvDelivery.Columns[e.ColumnIndex].Name == this.发货处理.Name)
                {
                    Delivery Item = this.PharmacyDatabaseService.GetDelivery(out msg, currentData.Id);
                    FormDeliveryEdit editForm = new FormDeliveryEdit(Item, (int)this.deliveryStatus, false);
                    editForm.ShowDialog();
                    //刷新画面
                    if (editForm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        pager_DataPaging();
                    }
                }
                //打开订单
                if (this.dgvDelivery.Columns[e.ColumnIndex].Name == this.订单号.Name)
                {
                    string message = string.Empty;
                    if (currentData.Status==0)
                    {
                        var order = this.PharmacyDatabaseService.GetSalesOrder(out message, currentData.SalesOrderId);
                        FormSalesOrderEdit editForm = new FormSalesOrderEdit(order, false);
                        editForm.ShowDialog();
                    }
                    if (currentData.Status == 1)
                    {
                        PurchaseCommonEntity pce = this.PharmacyDatabaseService.GetPurchaseOrderReturnsByPurchaseOrderId(out msg, currentData.SalesOrderId).FirstOrDefault();
                        if (pce == null) return;
                        Forms.PurchaseBusiness.FormReturnOrder frm = new Forms.PurchaseBusiness.FormReturnOrder(pce, false);
                        frm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// 初始化数据,显示最近未处理的配送信息
        /// 配送状态 = 配送预约(DeliveryStatus.Reservation)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDeliveryCenter_Load(object sender, EventArgs e)
        {
            try
            {
                this.pager.PageIndex = 1;
                pager_DataPaging();
            }
            catch (Exception ex)
            {
                MessageBox.Show("窗体加载失败!!!");
            }
        }

        /// <summary>
        ///翻页的时候处理检索 
        /// </summary>
        private void pager_DataPaging()
        {
            PagerInfo pagerInfo = new PagerInfo();
            pagerInfo.Index = this.pager.PageIndex;
            pagerInfo.Size = this.pager.PageSize;
            string message = string.Empty;

            try
            {
                DeliveryIndexInput qsom = InitDeliveryIndexInput();
                this.DeliveryList = PharmacyDatabaseService.GetDeliveryTransactionPaged( qsom,out pagerInfo, pager.PageIndex, pager.PageSize).ToList();
                this.dgvDelivery.DataSource = this.DeliveryList;
                pager.RecordCount = pagerInfo.RecordCount;
            }
            catch (Exception e)
            {
                MessageBox.Show("数据检索失败!");
            }
        }

        //查询条件
        private DeliveryIndexInput InitDeliveryIndexInput()
        {
            DeliveryIndexInput dii = new DeliveryIndexInput();
            dii.DeliveryMethodValue = -1;
            dii.DeliveryStatusValue = (int)deliveryStatus;
            dii.TransportMethodValue = -1;
            dii.DeliveryFromDate = DateTime.Now.AddYears(-1);
            dii.DeliveryToDate = DateTime.Now.AddYears(1);
            dii.OrderNumber = this.toolStripTextBox2.Text.Trim();
            dii.ReceivingCompasnyName = this.toolStripTextBox1.Text.Trim();
            return dii;
        }


        /// <summary>
        /// 更新Form Title
        /// </summary>
        /// <param name="status"></param>
        private string UpdateFormTitle(DeliveryStatus status)
        {
            string formTitle = string.Empty;
            switch (status)
            {
                case DeliveryStatus.Reservation:
                    formTitle = "配送受理";
                    break;
                case DeliveryStatus.Accepted:
                    formTitle = "配送出库";
                    break;
                case DeliveryStatus.Outed:
                    formTitle = "配送结果";
                    break;
            }
            return formTitle;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.pager_DataPaging();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.toolStripTextBox1.Text = string.Empty;
            this.toolStripTextBox2.Text = string.Empty;
        }


    }
}
