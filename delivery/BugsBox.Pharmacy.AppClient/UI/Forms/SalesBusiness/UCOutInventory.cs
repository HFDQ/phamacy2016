using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.Common;
using Microsoft.VisualBasic.Logging;
using BugsBox.Pharmacy.UI.Common;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class UCOutInventory : BaseFunctionUserControl
    {
        public OutInventory OutInventory { get; set; }
        public SalesOrder SalesOrder { get; set; }
        public UCOutInventory(OutInventory entity, SalesOrder order)
        {
            InitializeComponent();
            this.dgvDrugDetailList.AutoGenerateColumns = false;

            this.cmbOutType.DataSource = new List<ListItem>
            {
                new ListItem(){
                    ID = ((int)OutInventoryType.SalesNormal).ToString(),
                    Name = Utility.getEnumTypeDisplayName<OutInventoryType>(OutInventoryType.SalesNormal)
                },
                new ListItem(){
                    ID = ((int)OutInventoryType.SalesReissue).ToString(),
                    Name = Utility.getEnumTypeDisplayName<OutInventoryType>(OutInventoryType.SalesReissue)
                }
            };
            this.cmbOutType.ValueMember = "ID";
            this.cmbOutType.DisplayMember = "Name";

            this.OutInventory = entity;
            this.SalesOrder = order;

            if (OutInventory.Id == Guid.Empty || OutInventory.OutInventoryStatusValue == (int)OutInventoryStatus.None)
            {
                OutInventory.SalesOrderID = SalesOrder.Id;
                OutInventory.OutInventoryStatusValue = (int)OutInventoryStatus.None;
                OutInventory.StoreId = SalesOrder.StoreId;
                OutInventory.OutInventoryNumber = userControlBillDocumentCode1.GenarateCode();
            }

            lblOrderNo.Text = order.OrderCode;
            lblCreateDate.Text = order.CreateTime.ToString("yyyy年MM月dd日");
            lblOutStatus.Text="出库";
            string msg = string.Empty;
            var strPName = this.PharmacyDatabaseService.GetPurchaseUnit(out msg, order.PurchaseUnitId);
            label3.Text = strPName.Name;
            var FHY = this.PharmacyDatabaseService.GetUser(out msg, order.OrderOutInventoryCheckUserID);
            
            txt备注.Text = entity.Description;
            this.lblTitle.Text = "配送出库拣货复核";
        }

        /// <summary>
        /// 设计时使用
        /// </summary>
        public UCOutInventory()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 画面加载后显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCOutInventory_Load(object sender, EventArgs e)
        {
            if (OutInventory != null)
            {
                if (OutInventory.OutInventoryStatus == OutInventoryStatus.None)
                {
                    foreach (var c in OutInventory.SalesOutInventoryDetails)
                    {
                        c.OutAmount = c.Amount;
                    }
                }

                this.dgvDrugDetailList.DataSource = OutInventory.SalesOutInventoryDetails.OrderBy(r=>r.DictionaryDosageCode).ToList();

                foreach (var c in OutInventory.SalesOutInventoryDetails)
                {
                    if (c.WarehouseName.Contains("中药") || c.WarehouseName.Contains("中药饮片"))
                    {
                        dgvDrugDetailList.Columns["生产日期"].Visible = false;
                        dgvDrugDetailList.Columns["有效期至"].Visible = false;
                    }
                    else
                    {
                        dgvDrugDetailList.Columns["产地"].Visible = false;
                        dgvDrugDetailList.Columns["生产日期"].Visible = false;
                    }
                }

            }
        }

        /// <summary>
        /// 提交
        /// </summary>
        public void Submit()
        {
            OutInventory.OutInventoryNumber = userControlBillDocumentCode1.GenarateCode();
            OutInventory.CreateUserId = AppClientContext.CurrentUser.Id;
            OutInventory.UpdateUserId = AppClientContext.CurrentUser.Id;
            OutInventory.CreateTime = DateTime.Now;
            OutInventory.UpdateTime = DateTime.Now;
            OutInventory.StoreId = SalesOrder.StoreId;
            //保管员ID
            OutInventory.storekeeperId = AppClientContext.CurrentUser.Id;
            OutInventory.OutInventoryDate = DateTime.Now;
            OutInventory.Description = txt备注.Text;
            OutInventory.Description = this.txt备注.Text;
            OutInventory.OutInventoryStatusValue = (int)OutInventoryStatus.Outing;
            OutInventory.OrderOutInventoryTime = DateTime.Now;
            OutInventory.OrderOutInventoryUserID = AppClientContext.CurrentUser.CreateUserId;
            OutInventory.OutInventoryTypeValue = (int)OutInventoryType.SalesNormal;
            var list = new List<OutInventoryDetail>();
            foreach (OutInventoryDetail outInventoryDetail in OutInventory.SalesOutInventoryDetails)
            {
                if (outInventoryDetail.OutAmount > 0)
                {
                    outInventoryDetail.CreateUserId = AppClientContext.CurrentUser.Id;
                    outInventoryDetail.UpdateUserId = AppClientContext.CurrentUser.Id;
                    outInventoryDetail.CreateTime = DateTime.Now;
                    outInventoryDetail.UpdateTime = DateTime.Now;
                    outInventoryDetail.SalesOrderId = SalesOrder.Id;
                    list.Add(outInventoryDetail);
                }
            }
            OutInventory.SalesOutInventoryDetails = list;

            PharmacyDatabaseService.SubmitOutInventory(OutInventory);
            this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "成功提交销售拣货操作" );
            this.lblOutNo.Text = OutInventory.OutInventoryNumber;
            this.lblOutStatus.Text = Utility.getEnumTypeDisplayName<OrderStatus>((OrderStatus)OutInventory.OutInventoryStatusValue);
        }

        /// <summary>
        /// 审核
        /// </summary>
        public void Accept()
        {            
            if (OutInventory.Id != Guid.Empty)
            {
                string msg = string.Empty;
                try
                {
                    //更新订单表
                    var tmpOrder = PharmacyDatabaseService.GetSalesOrder(out msg, SalesOrder.Id);
                    //更新出库表
                    var tmpOutInventory = PharmacyDatabaseService.GetOutInventory(out msg, OutInventory.Id);

                    tmpOutInventory.UpdateUserId = AppClientContext.CurrentUser.Id;
                    tmpOutInventory.Description = this.txt备注.Text;

                    int SpecialDrugsCount = 0;
                    bool isSecond=false;
                    if (tmpOutInventory.OutInventoryStatusValue == (int)OutInventoryStatus.Outing)//首次复核
                    {
                        tmpOutInventory.ReviewerId = AppClientContext.CurrentUser.Id;
                        tmpOutInventory.OrderOutInventoryCheckNumber = userControlBillDocumentCode1.GenarateCode();
                        tmpOutInventory.OrderOutInventoryCheckUserID = AppClientContext.CurrentUser.Id;

                        var c = this.PharmacyDatabaseService.GetOutInventorySpecialDrugs(OutInventory, out msg);
                        SpecialDrugsCount = c.Count();
                        if (SpecialDrugsCount > 0)//需二次审核
                        {
                            MessageBox.Show("请注意，该销售单含有特殊管理药品，需经特殊管理药品二次复核过程方可执行配送申请！");
                            tmpOutInventory.OutInventoryStatusValue = (int)OutInventoryStatus.important;
                        }
                        else
                        {
                            tmpOutInventory.OutInventoryStatusValue = (int)OutInventoryStatus.Outed;                            
                        }
                    }
                    else//特殊药品复核
                    {
                        tmpOutInventory.OutInventoryStatusValue = (int)OutInventoryStatus.Outed;
                        tmpOutInventory.OrderOutInventoryCheckUserID = AppClientContext.CurrentUser.Id;
                        isSecond = true;
                    }
                    
                    PharmacyDatabaseService.AcceptOutInverntory(tmpOutInventory);
                    #region 写入日志
                    if (isSecond)
                    {
                        this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "成功提交销售质量特殊药品第二次复核操作：" + SalesOrder.OrderCode);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "成功提交销售质量复核操作：" + SalesOrder.OrderCode);
                    }
                    #endregion
                    //更新画面信息
                    this.lblOutStatus.Text = Utility.getEnumTypeDisplayName<OutInventoryStatus>((OutInventoryStatus)tmpOutInventory.OutInventoryStatusValue);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出库审核失败，请联系管理员！" + msg + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("订单信息和出库信息不能为空!");
            }
        }

        /// <summary>
        /// 出库数量编辑完成后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDrugDetailList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvDrugDetailList.Columns["出库数量"].Index)
            {
                return;
            }

            var detail = dgvDrugDetailList.Rows[e.RowIndex].DataBoundItem as OutInventoryDetail;
            if (detail != null)
            {
                if (detail.OutAmount > detail.Amount)
                {
                    detail.OutAmount = detail.Amount;
                }
           
            }
        }

        private void dgvDrugDetailList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDrugDetailList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            


        }

        private void dgvDrugDetailList_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dgvDrugDetailList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dgvDrugDetailList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("您输入的数据格式不正确，请修改！");
        }
    }
}
