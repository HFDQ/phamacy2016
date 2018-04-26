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
using BugsBox.Pharmacy.AppClient.UI.Report;
using BugsBox.Pharmacy.UI.Common.Printer;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class FormOutInventory : BaseFunctionForm
    {
        private Guid _orderID = Guid.Empty;
        private Guid _outID = Guid.Empty;
        private SalesOrder _salesOrder = null;
        private UCOutInventory currentUCOut = null;
        private string msg = string.Empty;
        BugsBox.Pharmacy.AppClient.UI.Ele_Lab EleModel = null;
        /// <summary>
        /// 从销售画面跳转过来
        /// </summary>
        /// <param name="orderID"></param>
        public FormOutInventory(Guid orderID, bool isReadonly = false)
        {
            InitializeComponent();
            this._orderID = orderID;
            this.toolStrip1.Enabled = !isReadonly;
        }

        /// <summary>
        /// 从已知出库ID进来
        /// </summary>
        /// <param name="orderID"></param>
        public FormOutInventory(Guid orderID, Guid outID, bool isReadonly = false)
        {
            InitializeComponent();
            this._orderID = orderID;
            this._outID = outID;
            this.toolStrip1.Enabled = !isReadonly;
            this.Text = "出库复核清单";
        }

        /// <summary>
        /// 初始化画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormOutInventory_Load(object sender, EventArgs e)
        {

            //提交出库
            this.btnSubmit.Visible = this.Authorize(ModuleKeys.SubmitOutInventoryForOrder);
            //this.toolStripButton1.Visible = this.btnSubmit.Visible;

            //出库审核
            this.tsbtnAccept.Visible = this.Authorize(ModuleKeys.ApprovalOutInventoryForOrder);
            //销退申请
            this.tsbtnOrderReturn.Visible = this.Authorize(ModuleKeys.SubmitOrderReturn);
            //清空现有tab
            tabContorl.TabPages.Clear();

            #region 电子标签控制
            EleModel = SearialiserHelper<Ele_Lab>.DeSerializeFileToObj("EleSetup.bin");
            if (EleModel.IsEnabled)
            {
                this.toolStripButton1.Visible = true;//点亮按钮显示，配置标签后，可以显示
                if (elelab.unart_manage.com_manage.FirstOrDefault() == null)
                {
                    int[] ss = new int[] { int.Parse(EleModel.PortName.Substring(3)) };
                    elelab.unart_manage.init_com_sys(ss);//初始化串口
                }
            }
            #endregion

            string message = string.Empty;
            try
            {
                _salesOrder = PharmacyDatabaseService.GetSalesOrder(out message, _orderID);

                //获取现有的出库信息
                var list = PharmacyDatabaseService.GetOutInventoryByOrderID(out message, _salesOrder.Id);
                if (_outID != Guid.Empty)
                {
                    //此时应该只初始化一个
                    list = list.Where(p => p.Id == _outID).ToArray();
                }

                foreach (var item in list)
                {
                    string tabTitle = string.Empty;
                    if (item.Id != Guid.Empty)
                    {
                        string status = Utility.getEnumTypeDisplayName<OutInventoryStatus>((OutInventoryStatus)item.OutInventoryStatusValue);
                        tabTitle = string.Format("{0}[{1}]", item.CreateTime.ToString("yyyy年MM月dd日"), status);
                    }
                    else
                    {
                        tabTitle = "*新建拣货单";
                    }

                    InitTabPage(0, tabTitle, _salesOrder, item);


                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("拣货单窗体加载初始化失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tabContorl_SelectedIndexChanged(null, null);
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.currentUCOut.dgvDrugDetailList.IsCurrentCellInEditMode) this.currentUCOut.dgvDrugDetailList.EndEdit();
            foreach (DataGridViewRow a in this.currentUCOut.dgvDrugDetailList.Rows)
            {
                if (Convert.ToDecimal(a.Cells["出库数量"].Value) == 0 || a.Cells["出库数量"].Value == null)
                {
                    MessageBox.Show("请填写拣货数量！");
                    this.currentUCOut.dgvDrugDetailList.CurrentCell = a.Cells["出库数量"];
                    this.currentUCOut.dgvDrugDetailList.BeginEdit(true);
                    return;
                }
            }
            try
            {
                if (this.currentUCOut != null)
                {
                    if (MessageBox.Show("确定要提交拣货流程？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        this.currentUCOut.Submit();
                        setBtnEnabled((OutInventoryStatus)this.currentUCOut.OutInventory.OutInventoryStatusValue);
                        this.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("订单拣货提交失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnAccept_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定提交拣货复核？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
            try
            {
                if (this.currentUCOut != null)
                {
                    this.currentUCOut.Accept();
                    setBtnEnabled((OutInventoryStatus)this.currentUCOut.OutInventory.OutInventoryStatusValue);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("订单拣货审核失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Dispose();
        }

        /// <summary>
        /// tab变化的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabContorl_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.tabContorl.SelectedIndex > -1)
                {
                    this.currentUCOut = this.tabContorl.SelectedTab.Tag as UCOutInventory;
                    if (this.currentUCOut != null)
                    {
                        setBtnEnabled((OutInventoryStatus)this.currentUCOut.OutInventory.OutInventoryStatusValue);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("拣货单切换失败！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 创建一个出库单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnCreate_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 更新画面按钮状态
        /// </summary>
        /// <param name="status"></param>
        private void setBtnEnabled(OutInventoryStatus status)
        {
            if (status == OutInventoryStatus.None)//无出库状态
            {
                this.btnSubmit.Enabled = true;
                this.tsbtnAccept.Enabled = false;
            }
            else if (status == OutInventoryStatus.Outing)//出库中
            {
                this.btnSubmit.Enabled = false;
                this.tsbtnAccept.Enabled = true;
            }
            else if (status == OutInventoryStatus.important && this.Authorize(ModuleKeys.SpecialDrugApproval))//二次审核
            {
                this.btnSubmit.Enabled = false;
                this.tsbtnAccept.Enabled = true;
            }
            else
            {
                this.btnSubmit.Enabled = false;
                this.tsbtnAccept.Enabled = false;
            }
        }

        /// <summary>
        /// 添加出库信息
        /// </summary>
        /// <param name="index"></param>
        /// <param name="order"></param>
        /// <param name="outInventory"></param>
        private void InitTabPage(int index, string tabPageName, SalesOrder order, OutInventory outInventory)
        {
            var ucOutInventory = new UCOutInventory(outInventory, order);
            ucOutInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            ucOutInventory.Location = new System.Drawing.Point(0, 0);
            ucOutInventory.Name = tabPageName;
            ucOutInventory.Size = new System.Drawing.Size(861, 440);
            ucOutInventory.TabIndex = 0;

            var tabPage = new System.Windows.Forms.TabPage();
            tabPage.Controls.Add(ucOutInventory);
            tabPage.Location = new System.Drawing.Point(4, 22);
            tabPage.Name = tabPageName;
            tabPage.Padding = new System.Windows.Forms.Padding(3);
            tabPage.Size = new System.Drawing.Size(867, 446);
            tabPage.TabIndex = 1;
            tabPage.Text = tabPageName;
            tabPage.UseVisualStyleBackColor = true;
            tabPage.Tag = ucOutInventory;

            tabContorl.TabPages.Add(tabPage);
        }

        /// <summary>
        /// 销退申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnOrderReturn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定需要退货申请吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            try
            {
                if (currentUCOut.OutInventory != null)
                {
                    currentUCOut.OutInventory.SalesOutInventoryDetails = currentUCOut.OutInventory.SalesOutInventoryDetails.Where(r => r.OutAmount > 0).ToArray();
                    FormSalesOrderReturn form = new FormSalesOrderReturn(currentUCOut.OutInventory);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("打开销退画面失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开销退画面失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void tsbtnPrint_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            try
            {
                if (this.currentUCOut.OutInventory != null)
                {
                    //DsSalesOrder ds = new DsSalesOrder();
                    //ds.ExtendedProperties.Clear();
                    //ds.Tables.Clear();
                    List<object> reportData = new List<object>();
                    List<object> orderList = new List<object>();

                    foreach (Models.OutInventoryDetail detail in this.currentUCOut.OutInventory.SalesOutInventoryDetails)
                    {
                        orderList.Add(detail);
                    }

                    reportData.Add(orderList);
                    List<Microsoft.Reporting.WinForms.ReportParameter> ListPar = new List<Microsoft.Reporting.WinForms.ReportParameter>();
                    using (PrintHelper printHelper = new PrintHelper("Reports\\RptSaleOutInventory.rdlc", reportData, ListPar))
                    {
                        printHelper.Print();
                    }
                }
                else
                {
                    MessageBox.Show("没有数据可以打印！！！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var c = MessageBox.Show("确定要申请重新审核？", "提示", MessageBoxButtons.OKCancel);
            if (c == System.Windows.Forms.DialogResult.Cancel) return;

            this._salesOrder.OrderStatus = OrderStatus.Waitting;
            this.PharmacyDatabaseService.SaveSalesOrder(out msg, this._salesOrder);
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (this._orderID == Guid.Empty || this._orderID == null) return;
            var c = this.PharmacyDatabaseService.GetWarehouseZonePositionOutInventories(this._salesOrder.Id, out msg).ToList();

            if (c.Count <= 0 || c == null) return;

            byte Port = byte.Parse(EleModel.PortName.Substring(3));

            List<string> LabelId = new List<string>();
            List<string> LabelAddress = new List<string>();
            List<string> labelNumber = new List<string>();
            foreach (var r in c)
            {
                LabelId.Add(r.WareHouseZonePIndex.ToString());
                LabelAddress.Add(r.PIndex.ToString());
                labelNumber.Add(r.OutAmount.ToString());
            }
            string ordercode = c.First().OrderNumber;
            byte documentNumber = byte.Parse(ordercode.Substring(ordercode.Length - 2));

            elelab.pick.make_data(null, EleModel.PurchaseInInventoryLed, documentNumber, Port, LabelId.ToArray(), LabelAddress.ToArray(), labelNumber.ToArray());
        }
    }
}
