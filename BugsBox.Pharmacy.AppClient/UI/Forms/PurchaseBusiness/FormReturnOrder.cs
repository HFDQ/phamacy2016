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

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    using OrderStatus = BugsBox.Pharmacy.Models.OrderStatus;
    using BugsBox.Pharmacy.AppClient.Common;
    using BugsBox.Pharmacy.Models;
    using BugsBox.Pharmacy.Business.Models;
    using BugsBox.Pharmacy.AppClient.UI.Report;
    using BugsBox.Application.Core.Configuration;

    public partial class FormReturnOrder : BaseFunctionForm
    {
        /// <summary>
        /// 订单详细
        /// </summary>
        private PurchaseCommonEntity _order = new PurchaseCommonEntity();
        private List<PurchaseOrderReturnDetailEntity> _orderDetails = new List<PurchaseOrderReturnDetailEntity>();
        string msg = string.Empty;
        List<User> Listuser = new List<User>();

        public FormReturnOrder()
        {
            InitializeComponent();

            var returnOrderPageConfig = BugsBoxApplication.Instance.Config.ReturnOrderPageConfig;
            if (!string.IsNullOrEmpty(returnOrderPageConfig.qualityTabPage))
            {
                this.qualityTabPage.Text = returnOrderPageConfig.qualityTabPage;
            }
            if (!string.IsNullOrEmpty(returnOrderPageConfig.generalMangerTabPage))
            {
                this.generalMangerTabPage.Text = returnOrderPageConfig.generalMangerTabPage;
            }
            if (!string.IsNullOrEmpty(returnOrderPageConfig.tabPage1))
            {
                this.tabPage1.Text = returnOrderPageConfig.tabPage1;
            }
            if (!string.IsNullOrEmpty(returnOrderPageConfig.Field1))
            {
                this.label12.Text = returnOrderPageConfig.Field1;
                tsbtnQualityrApproved.Text = returnOrderPageConfig.Field1 + "审核";
            }

            if (!string.IsNullOrEmpty(returnOrderPageConfig.Field2))
            {
                this.label19.Text = returnOrderPageConfig.Field2;
                tsbtnGeneralManagerApproved.Text = returnOrderPageConfig.Field2 + "审核";
            }
            if (!string.IsNullOrEmpty(returnOrderPageConfig.Field3))
            {
                this.label23.Text = returnOrderPageConfig.Field3;
                tsbtnFinanceDepartmentApproved.Text = returnOrderPageConfig.Field3 + "审核";
            }

            CellDataValidBackColor = colProductGeneralName.DefaultCellStyle.BackColor;

            List<ComboxItem> returnItems = new List<ComboxItem>();

            returnItems.Add(new ComboxItem(EnumHelper<PurchaseReturnSource>.GetDisplayValue(PurchaseReturnSource.ReturnFromInInventery), (int)PurchaseReturnSource.ReturnFromInInventery));
            returnItems.Add(new ComboxItem(EnumHelper<PurchaseReturnSource>.GetDisplayValue(PurchaseReturnSource.Other), (int)PurchaseReturnSource.Other));
            PurchaseReturnSourceValue.DataSource = returnItems;
            PurchaseReturnSourceValue.DisplayMember = "Name";
            PurchaseReturnSourceValue.ValueMember = "Value";

            List<ComboxItem> methodItems = new List<ComboxItem>();
            methodItems.Add(new ComboxItem(EnumHelper<ReturnHandledMethod>.GetDisplayValue(ReturnHandledMethod.Damage), (int)ReturnHandledMethod.Damage));
            methodItems.Add(new ComboxItem(EnumHelper<ReturnHandledMethod>.GetDisplayValue(ReturnHandledMethod.LocalDestroy), (int)ReturnHandledMethod.LocalDestroy));
            methodItems.Add(new ComboxItem(EnumHelper<ReturnHandledMethod>.GetDisplayValue(ReturnHandledMethod.ReturnDestroy), (int)ReturnHandledMethod.ReturnDestroy));
            methodItems.Add(new ComboxItem(EnumHelper<ReturnHandledMethod>.GetDisplayValue(ReturnHandledMethod.Other), (int)ReturnHandledMethod.Other));
            ReturnHandledMethodValue.DataSource = methodItems;
            ReturnHandledMethodValue.DisplayMember = "Name";
            ReturnHandledMethodValue.ValueMember = "Value";
            this.dataGridView1.RowPostPaint += delegate (object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.Listuser = this.PharmacyDatabaseService.AllUsers(out msg).ToList();
        }
        //查询收货单


        public FormReturnOrder(PurchaseCommonEntity order, bool onlySearch = false)
            : this()
        {
            _order = order;
            _orderDetails = this.PharmacyDatabaseService.GetPurchaseOrderReturnDetails(out msg, order.Id).ToList();
            if (_orderDetails != null && _orderDetails.Count > 0)
            {
                if (_orderDetails[0].PurchaseReturnSourceValue == (int)PurchaseReturnSource.ReturnFromInInventery)
                {
                    //退货申请成功，在入库阶段，有退货出库过程
                    tsbtnOut.Visible = true;
                }
                foreach (var o in _orderDetails)
                {
                    //需要重新发货
                    if (o.IsReissue && _order.OrderStatus == (int)OrderReturnStatus.FinanceDepartmentApproved)
                    {
                        toolStripButton1.Visible = true;
                        break;
                    }
                }
            }
            Initial(false);
            this.Column2.Visible = false;
            switch (_order.OrderStatus)
            {
                case (int)OrderReturnStatus.Waitting:
                    tsbtnFinanceDepartmentApproved.Visible = false;
                    tsbtnGeneralManagerApproved.Visible = false;
                    tsbtnQualityrApproved.Visible = true;
                    tsbtnSubmit.Visible = false;
                    tsbtnCancel.Visible = true;
                    tsbtnOut.Visible = false;
                    break;
                case (int)OrderReturnStatus.Rejected:
                    tsbtnFinanceDepartmentApproved.Visible = false;
                    tsbtnGeneralManagerApproved.Visible = false;
                    tsbtnQualityrApproved.Visible = false;
                    tsbtnSubmit.Visible = false;
                    tsbtnCancel.Visible = true;
                    tsbtnOut.Visible = false;
                    break;
                case (int)OrderReturnStatus.QualityApproved:
                    tsbtnFinanceDepartmentApproved.Visible = false;
                    tsbtnQualityrApproved.Visible = false;
                    tsbtnGeneralManagerApproved.Visible = true;
                    tsbtnSubmit.Visible = false;
                    tsbtnCancel.Visible = true;
                    tsbtnOut.Visible = false;
                    break;
                case (int)OrderReturnStatus.GeneralManagerApproved:
                    tsbtnGeneralManagerApproved.Visible = false;
                    tsbtnQualityrApproved.Visible = false;
                    tsbtnFinanceDepartmentApproved.Visible = true;
                    tsbtnSubmit.Visible = false;
                    tsbtnCancel.Visible = true;
                    tsbtnOut.Visible = false;
                    break;
                case (int)OrderReturnStatus.FinanceDepartmentApproved:
                    tsbtnGeneralManagerApproved.Visible = false;
                    tsbtnQualityrApproved.Visible = false;
                    tsbtnFinanceDepartmentApproved.Visible = false;
                    tsbtnSubmit.Visible = false;
                    tsbtnCancel.Visible = true;
                    toolStripButton1.Visible = false;
                    tsbtnOut.Visible = true;
                    break;
                case (int)OrderReturnStatus.Over:
                    tsbtnGeneralManagerApproved.Visible = false;
                    tsbtnQualityrApproved.Visible = false;
                    tsbtnFinanceDepartmentApproved.Visible = false;
                    tsbtnSubmit.Visible = false;
                    tsbtnCancel.Visible = false;
                    toolStripButton1.Visible = false;
                    tsbtnOut.Visible = false;
                    break;
                case (int)OrderReturnStatus.ReturnPickup:
                    tsbtnGeneralManagerApproved.Visible = false;
                    tsbtnQualityrApproved.Visible = false;
                    tsbtnFinanceDepartmentApproved.Visible = false;
                    tsbtnSubmit.Visible = false;
                    tsbtnCancel.Visible = false;
                    toolStripButton1.Visible = false;
                    tsbtnOut.Visible = false;
                    toolStripButton3.Visible = true;
                    break;
                case (int)OrderReturnStatus.ReturnPickupChecked:
                    tsbtnGeneralManagerApproved.Visible = false;
                    tsbtnQualityrApproved.Visible = false;
                    tsbtnFinanceDepartmentApproved.Visible = false;
                    tsbtnSubmit.Visible = false;
                    tsbtnCancel.Visible = false;
                    toolStripButton1.Visible = false;
                    tsbtnOut.Visible = false;
                    toolStripButton4.Visible = true;
                    break;
            }

            this.dataGridView1.ReadOnly = true;
            label13.Text = order.SupplyUnitName;

            label10.Text = order.QualityEmployeeName;
            dateTimePicker1.Text = order.QualityUpdateTime != null ? order.QualityUpdateTime.ToString() : null;
            txtQualityMemo.Text = order.QualitySuggest;

            label18.Text = order.GeneralManagerEmployeeName;
            dateTimePickerManger.Text = order.GeneralManagerUpdateTime != null ? order.GeneralManagerUpdateTime.ToString() : null;
            txtMangerMemo.Text = order.GeneralManagerSuggest;

            label21.Text = order.FinanceDepartmentEmployeeName;
            dateTimePickerMoney.Text = order.FinanceDepartmentUpdateTime != null ? order.FinanceDepartmentUpdateTime.ToString() : null;
            textBoxMoney.Text = order.FinanceDepartmentSuggest;
            txt备注.Text = order.Description;
            if (onlySearch)
            {
                tsbtnGeneralManagerApproved.Visible = false;
                tsbtnQualityrApproved.Visible = false;
                tsbtnFinanceDepartmentApproved.Visible = false;
                tsbtnSubmit.Visible = false;
                tsbtnCancel.Visible = false;
                toolStripButton1.Visible = false;
                tsbtnOut.Visible = false;
            }
            //显示审批记录
            if (_order.QualityUserId != null && _order.QualityUserId != Guid.Empty)
            {
                groupBoxApprovedRecords.Visible = true;
                this.dataGridView2.Rows.Add(_order.QualityEmployeeName, _order.QualityUpdateTime, TransferName(_order.OrderStatus), _order.QualitySuggest);
            }
            if (_order.GeneralManagerUserId != null && _order.GeneralManagerUserId != Guid.Empty)
            {
                this.dataGridView2.Rows.Add(_order.GeneralManagerEmployeeName, _order.GeneralManagerUpdateTime, TransferName(_order.OrderStatus), _order.GeneralManagerSuggest);
            }
            if (_order.FinanceDepartmentUserId != null && _order.FinanceDepartmentUserId != Guid.Empty)
            {
                groupBoxApprovedRecords.Visible = true;
                this.dataGridView2.Rows.Add(_order.FinanceDepartmentEmployeeName, _order.FinanceDepartmentUpdateTime, TransferName(_order.OrderStatus), _order.FinanceDepartmentSuggest);
            }
            if (tsbtnQualityrApproved.Visible == true)
            {
                tsbtnQualityrApproved.Visible = this.Authorize(ModuleKeys.ApprovalPurchaseReturnQuality);
            }
            if (tsbtnGeneralManagerApproved.Visible == true)
            {
                tsbtnGeneralManagerApproved.Visible = this.Authorize(ModuleKeys.ApprovalPurchaseReturnManager);
            }
            if (tsbtnFinanceDepartmentApproved.Visible == true)
            {
                tsbtnFinanceDepartmentApproved.Visible = this.Authorize(ModuleKeys.ApprovalPurchaseReturnFinance);
            }
            if (toolStripButton1.Visible == true)
            {
                toolStripButton1.Visible = this.Authorize(ModuleKeys.PurchaseReceiving);
            }
        }

        ReturnOrderPageName returnOrderPageConfig = BugsBoxApplication.Instance.Config.ReturnOrderPageConfig;

        private string TransferName(int orderstatus)
        {
            var item = EnumHelper<OrderReturnStatus>.GetDisplayValue((OrderReturnStatus)orderstatus);
            if (!string.IsNullOrEmpty(returnOrderPageConfig.Field1) && item == "质管部审核通过")
            {
                item = returnOrderPageConfig.Field1 + "审核通过";
            }
            if (!string.IsNullOrEmpty(returnOrderPageConfig.Field2) && item == "总经理审核通过")
            {
                item = returnOrderPageConfig.Field2 + "审核通过";
            }
            if (!string.IsNullOrEmpty(returnOrderPageConfig.Field3) && item == "财务部审核通过")
            {
                item = returnOrderPageConfig.Field3 + "审核通过";
            }
            return item;
        }

        //创建退货单
        public FormReturnOrder(PurchaseCommonEntity order, List<PurchaseOrderReturnDetailEntity> orderDetails)
            : this()
        {
            _order.Description = "";
            _order.PurchaseOrderId = order.PurchaseOrderId;
            _order.OperateUserId = AppClientContext.CurrentUser.Id;
            _order.CheckerEmployeeName = AppClientContext.CurrentUser.Employee.Name;
            _order.CheckerEmployeeNumber = AppClientContext.CurrentUser.Employee.Number;
            _order.SupplyUnitId = order.SupplyUnitId;
            _order.SupplyUnitName = order.SupplyUnitName;
            _order.OrderStatus = (int)OrderReturnStatus.Waitting;

            foreach (var r in orderDetails)
            {
                r.ReturnAmount = 0;
                r.ReturnHandledMethodValue = (int)ReturnHandledMethod.Other;
                r.PurchaseReturnSourceValue = (int)PurchaseReturnSource.ReturnFromInInventery;
            }

            this._orderDetails = orderDetails;



            Initial(true);
            tsbtnFinanceDepartmentApproved.Visible = false;
            tsbtnGeneralManagerApproved.Visible = false;
            tsbtnQualityrApproved.Visible = false;
            label13.Text = order.SupplyUnitName;
            txt备注.Enabled = true;
        }


        public FormReturnOrder(PurchaseCommonEntity order, Guid purchaseOrderID)
            : this()
        {
            _order.Description = "";
            _order.PurchaseOrderId = order.PurchaseOrderId;
            _order.OperateUserId = AppClientContext.CurrentUser.Id;
            _order.CheckerEmployeeName = AppClientContext.CurrentUser.Employee.Name;
            _order.CheckerEmployeeNumber = AppClientContext.CurrentUser.Employee.Number;
            _order.SupplyUnitId = order.SupplyUnitId;
            _order.SupplyUnitName = order.SupplyUnitName;
            _order.OrderStatus = (int)OrderReturnStatus.Waitting;
            List<PurchaseCommonEntity> orderDetails = this.PharmacyDatabaseService.GetPurchaseInInventeryOrdersByPurchaseOrderId(out msg, purchaseOrderID).ToList();

            foreach (PurchaseCommonEntity d in orderDetails)
            {
                //PurchaseOrderReturnDetailEntity c = new PurchaseOrderReturnDetailEntity();
                //c.DictionaryDosageCode = d.DictionaryDosageCode;
                //c.FactoryName = d.FactoryName;
                //c.IsReissue = true;
                //c.PurchaseReturnSourceValue = 0;
                //c.ReissueAmount = 0;
                //c.RelatedOrderId = order.Id;
                //c.ReturnAmount = d.Amount;
                //c.ReturnHandledMethodValue = (int)ReturnHandledMethod.ReturnDestroy;
                //c.ReturnReason = string.Empty;
                //c.Decription = "";
                //c.ProductGeneralName = d.ProductGeneralName;
                //c.DictionarySpecificationCode = d.DictionarySpecificationCode;
                //c.DictionaryMeasurementUnitCode = d.DictionaryMeasurementUnitCode;
                //c.LicensePermissionNumber = d.LicensePermissionNumber;
                //c.OutValidDate = d;
                //c.PruductDate = d.PruductDate;
                //c.DrugInfoId = d.DrugInfoId;
                //c.BatchNumber = d.BatchNumber;
                //c.PurchasePrice = d.PurchasePrice;
                //_orderDetails.Add(c);
            }
            Initial(true);
            tsbtnFinanceDepartmentApproved.Visible = false;
            tsbtnGeneralManagerApproved.Visible = false;
            tsbtnQualityrApproved.Visible = false;
            toolStripButton1.Visible = false;
            tsbtnOut.Visible = false;
            label13.Text = order.SupplyUnitName;
            txt备注.Enabled = true;
        }


        public void Initial(bool isCreate)
        {
            if (isCreate)
            {
                lblOrderNo.Text = "新建";
                lblCreateDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");

                string employeeName = AppClientContext.CurrentUser.Employee.Name;
                txtEmployee.Text = employeeName;
            }
            else
            {
                lblCreateDate.Text = _order.OperateTime.ToString("yyyy年MM月dd日");
                txtEmployee.Text = _order.EmployeeName;
                lblOrderNo.Text = _order.DocumentNumber;
                lblOrderStatus.Text = TransferName(_order.OrderStatus);
                tsbtnSubmit.Visible = false;
                this.dataGridView1.ReadOnly = true;
            }

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = _orderDetails;
        }

        /// <summary>
        /// 提交销退申请信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnSubmit_Click(object sender, EventArgs e)
        {
            this.dataGridView1.EndEdit();
            try
            {
                if (validInputInDataGridView())
                {
                    _order.Description = txt备注.Text;

                    decimal returnAmount = _orderDetails.Sum(r => r.ReturnAmount);

                    if (returnAmount <= 0m)
                    {
                        MessageBox.Show("您没有填写退货数量！");
                        return;
                    }


                    if (MessageBox.Show("确定要提交采购退货流程吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.OK) return;
                    var subList = this._orderDetails.Where(r => r.ReturnAmount > 0);

                    string orderNumber = this.PharmacyDatabaseService.CreatePurchaseOrderReturnByEnity(out msg, _order, subList.ToArray());
                    if (String.IsNullOrEmpty(msg))
                    {
                        lblOrderStatus.Text = EnumHelper<OrderReturnStatus>.GetDisplayValue((OrderReturnStatus)_order.OrderStatus);
                        lblOrderNo.Text = orderNumber;
                        MessageBox.Show("退货申请完成");
                        this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行采购退货申请操作成功,单号：" + orderNumber);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Dispose();
                    }
                    else
                    {
                        tsbtnSubmit.Enabled = true;
                        MessageBox.Show("退货失败,请联系管理员");
                    }
                }
            }
            catch
            {
                MessageBox.Show("退货失败,请联系管理员");
            }
        }

        /// <summary
        /// 提交销退取消申请信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要取消该采购退货单据吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.OK) return;
            string message = "";
            try
            {
                this.PharmacyDatabaseService.CancelPurchaseReturnOrder(this._order.Id, out message);
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行采购退货取消操作成功");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("提交销退取消申请信息失败!" + message);
            }
        }

        /// <summary>
        /// 销退申请审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnAccept_Click(object sender, EventArgs e)
        {
            string message = "";

            try
            {
                //SalesOrder order = PharmacyDatabaseService.GetSalesOrder(out message, this.OrderInfo.Id);
                //order.UpdateTime = DateTime.Now;
                ////order.OrderReturnCheckCode = this.ucbcReturnCheck.GenarateCode();
                //order.OrderReturnCheckTime = DateTime.Now;
                //order.OrderReturnCheckUserID = AppClientContext.CurrentUser.Id;
                //order.OrderStatusValue = (int)OrderStatus.Banlaced;//状态为结算

                ////PharmacyDatabaseService.UpdateDelivery(order);
                //if (message.Length > 0)
                //    MessageBox.Show(message + message);
                ////else
                ////    this.tsBtnAccept.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("提交销退申请审核息失败!" + message);
            }
        }

        private bool validInputInDataGridView()
        {
            foreach (DataGridViewRow r in this.dataGridView1.Rows)
            {
                if (Decimal.Parse(r.Cells[ReturnAmount.Name].Value.ToString()) < Decimal.Parse(r.Cells[ReissueAmount.Name].Value.ToString()))
                {
                    r.Cells[ReissueAmount.Name].Style.BackColor = CellDataErrorBackColor;
                    MessageBox.Show("补发数量不能大于退货数量", "提示", MessageBoxButtons.OK);
                    return false;
                }
                else
                {
                    r.Cells[ReissueAmount.Name].Style.BackColor = CellDataValidBackColor;
                }

            }

            return true;
        }

        private void tsbtnQualityrApproved_Click(object sender, EventArgs e)
        {
            FormPurchaseReturnOrderApproval form = new FormPurchaseReturnOrderApproval(_order.Id, OrderReturnStatus.QualityApproved);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                lblOrderStatus.Text = EnumHelper<OrderReturnStatus>.GetDisplayValue((OrderReturnStatus)form.OrderStatusValue);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void tsbtnGeneralManagerApproved_Click(object sender, EventArgs e)
        {
            FormPurchaseReturnOrderApproval form = new FormPurchaseReturnOrderApproval(_order.Id, OrderReturnStatus.GeneralManagerApproved);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                lblOrderStatus.Text = EnumHelper<OrderReturnStatus>.GetDisplayValue((OrderReturnStatus)form.OrderStatusValue);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void tsbtnFinanceDepartmentApproved_Click(object sender, EventArgs e)
        {
            FormPurchaseReturnOrderApproval form = new FormPurchaseReturnOrderApproval(_order.Id, OrderReturnStatus.FinanceDepartmentApproved);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                lblOrderStatus.Text = EnumHelper<OrderReturnStatus>.GetDisplayValue((OrderReturnStatus)form.OrderStatusValue);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        //退货出库
        private void tsbtnOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要提交采购退货出库拣货流程吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) return;

            PurchaseOrderReturn por = this.PharmacyDatabaseService.GetPurchaseOrderReturn(out msg, _order.Id);
            por.OrderStatus = OrderReturnStatus.ReturnPickup;
            if (this.PharmacyDatabaseService.SavePurchaseOrderReturn(out msg, por))
            {
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行采购退货单通知出库操作成功,单号：" + por.DocumentNumber);
                MessageBox.Show("提交采购退货出库拣货流程成功！");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                //if (MessageBox.Show("需要打印该采购退货单吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                //{
                //    this.toolStripButton2_Click(sender, e);                    
                //}
                this.Dispose();
            }
            else
            {
                MessageBox.Show("提交采购退货出库拣货流程失败！");
            }
        }

        //收货
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FormReceivingOrder form = new FormReceivingOrder(_order, _orderDetails);
            form.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            List<object> reportData = new List<object>();
            List<object> orderList = new List<object>();
            orderList.Add(_order);
            reportData.Add(orderList);
            reportData.Add(_orderDetails);
            List<Microsoft.Reporting.WinForms.ReportParameter> ListPar = new List<Microsoft.Reporting.WinForms.ReportParameter>();

            Guid Pid = _order.PurchaseOrderId;
            var po = this.PharmacyDatabaseService.GetPurchaseOrder(out msg, Pid);
            var piio = this.PharmacyDatabaseService.GetPurchaseInInventeryOrdersByPurchaseOrderId(out msg, Pid).FirstOrDefault();
            string Purchaser = this.Listuser.Where(r => r.Id == po.CreateUserId).FirstOrDefault().Employee.Name;
            string Invoicer = _order.EmployeeName;
            string Keeper = piio.EmployeeName;
            var Check = this.Listuser.Where(r => r.Id == _order.CheckerUserId).FirstOrDefault();
            if (Check == null)
            {
                MessageBox.Show("该采购退货单暂未复核，请复核后再打印"); return;
            }
            string Checker = Check.Employee.Name;
            string Addr = PharmacyClientConfig.Config.Store.Address;
            string Tel = PharmacyClientConfig.Config.Store.Tel;
            ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("Purchaser", Purchaser));
            ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("Invoicer", Invoicer));
            ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("Keeper", Keeper));
            ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("Checker", Checker));
            ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("Addr", Addr));
            ListPar.Add(new Microsoft.Reporting.WinForms.ReportParameter("Tel", Tel));
            using (PrintHelper printHelper = new PrintHelper("Reports\\RptPurchaseReturnList.rdlc", reportData, ListPar))
            {
                printHelper.Print();
            }
            this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "成功打印采购退货单，单号：" + _order.DocumentNumber);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.CurrentCell.OwningColumn.Name == this.clmReturnNum.Name)
            {
                if (Convert.ToDecimal(this.dataGridView1.CurrentCell.EditedFormattedValue) > _orderDetails[e.RowIndex].inInventoryNum)
                {
                    MessageBox.Show("您的定单数量是:" + _orderDetails[e.RowIndex].inInventoryNum.ToString() + "，您输入的数量为已超过，请返回修改！");
                    this.dataGridView1.CurrentCell.Value = _orderDetails[e.RowIndex].ReturnAmount = 0m;
                    return;
                }
                if (_orderDetails[e.RowIndex].CanReturnNum < Convert.ToDecimal(this.dataGridView1.CurrentCell.EditedFormattedValue))
                {
                    MessageBox.Show("可退货数量为" + _orderDetails[e.RowIndex].CanReturnNum.ToString() + "，您输入的数量超出了现有库存数量，请返回修改！");
                    this.dataGridView1.CurrentCell.Value = _orderDetails[e.RowIndex].ReturnAmount = 0m;
                    return;
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        //采退拣货
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认退单质量复查，并将该退单提交至配送流程？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) return;

            try
            {
                PurchaseOrderReturn por = this.PharmacyDatabaseService.GetPurchaseOrderReturn(out msg, _order.Id);
                if (this.PharmacyDatabaseService.SaveDeliveryByPurchaseReturn(por, AppClientContext.CurrentUser.Id, out msg))
                {
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行采购退货单出库质量复核操作成功,单号：" + por.DocumentNumber);
                    MessageBox.Show("配送单成功生成，请至配送申请中查询该退单信息！");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;

                    if (MessageBox.Show("需要打印该采购退货单吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.toolStripButton2_Click(sender, e);
                    }

                    this.Dispose();
                }
                else
                {
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行采购退货单出库质量复核操作失败,单号：" + por.DocumentNumber);
                    MessageBox.Show("配送单成功失败，请稍候再试！");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认拣货，并将该退单提交至采购退货出库质量复查流程吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) return;

            PurchaseOrderReturn por = this.PharmacyDatabaseService.GetPurchaseOrderReturn(out msg, _order.Id);
            por.OrderStatus = OrderReturnStatus.ReturnPickupChecked;
            if (this.PharmacyDatabaseService.SavePurchaseOrderReturn(out msg, por))
            {
                MessageBox.Show("提交采购退货出库质量复查流程成功！");
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行采购退货单出库拣货操作成功,单号：" + por.DocumentNumber);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Dispose();
            }
            else
            {
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行采购退货单出库拣货操作失败,单号：" + por.DocumentNumber);
                MessageBox.Show("提交采购退货出库质量复查流程失败！");
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Dispose();
            }

        }
    }
}
