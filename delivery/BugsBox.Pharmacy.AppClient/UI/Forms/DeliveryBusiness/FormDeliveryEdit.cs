using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.AppClient.PS;
using Microsoft.VisualBasic.Logging;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DeliveryBusiness
{
    /// <summary>
    /// 只有运输类型为自有车辆的时候才能选择车辆
    /// 不是自有车辆的情况下车辆信息为手动输入
    /// </summary>
    //
    public partial class FormDeliveryEdit : BaseFunctionForm
    {
        private Delivery Delivery { get; set; }

        private List<Vehicle> ListVehicle = new List<Vehicle>();
        private string msg = string.Empty;

        public FormDeliveryEdit(Delivery entity, int DeliveryStatusValue, bool isReadonly = false)
        {
            InitializeComponent();
            this.Delivery = entity;
            this.toolStrip1.Enabled = !isReadonly;
            ListVehicle = this.PharmacyDatabaseService.AllVehicles(out msg).Where(r => !r.Deleted).ToList();

            if (DeliveryStatusValue > 1)
            {
                this.gbEntrust.Enabled = this.groupBox1.Enabled = false;
                cmbDeliveryMethod.Enabled = false;
                txtShippingAddress.Enabled = false;
                txtDeliveryAddress.Enabled = false;
                txtMemo.Enabled = false;
                dtDeliveryDate.Enabled = false;
                signdateTimePicker1.Visible = false;
                lblsign.Visible = false;
            }
        }

        /// <summary>
        /// 画面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDeliveryEdit_Load(object sender, EventArgs e)
        {
            string message = string.Empty;

            //提交配送情报
            this.tsbtnSubmit.Visible = this.Authorize(ModuleKeys.EditDeliveryInfo);
            //取消配送情报
            this.tsbtnCancel.Visible = this.Authorize(ModuleKeys.EditDeliveryInfo);
            //配送出库
            this.tsbtnCancel.Visible = this.Authorize(ModuleKeys.OutInventoryForDelivery);
            //签收
            this.tsbtnSigned.Visible = this.Authorize(ModuleKeys.SignedForDelivery);

            lblsign.Visible = this.tsbtnSigned.Visible;
            signdateTimePicker1.Visible = this.tsbtnSigned.Visible;
            //签退申请
            this.tsbtnOrderReturn.Visible = this.Authorize(ModuleKeys.OrderReturnForDelivery);

            this.cmbDeliveryMethod.SelectedIndex = this.Delivery.DeliveryMethodValue;

            //运输方式
            this.cmbTransportMethod.DataSource = Utility.CreateComboboxList<TransportMethod>();
            this.cmbTransportMethod.DisplayMember = "Name";
            this.cmbTransportMethod.ValueMember = "ID";

            //车辆信息初始化
            initVehicleCombobox();

            //初始化委托输入部分
            //cmbDeliveryMethod_SelectedIndexChanged(null, null);

            //通过this.Delivery给各个控件赋值
            this.lblManifestNumber.Text = this.Delivery.ManifestNumber;
            this.lblStatus.Text = Utility.getEnumTypeDisplayName<DeliveryStatus>((DeliveryStatus)this.Delivery.DeliveryStatusValue);
            this.lblOrderID.Text = Delivery.SalesOrder;
            this.lblDrugCount.Text = this.Delivery.DrugsCount.ToString();
            this.lblCompanyName.Text = this.Delivery.ReceivingCompasnyName;

            this.dtDeliveryDate.Value = this.Delivery.DeliveryTime;
            this.cmbDeliveryMethod.SelectedValue = this.Delivery.DeliveryMethodValue.ToString();
            this.txtShippingAddress.Text = this.Delivery.ShippingAddress;
            this.txtDeliveryAddress.Text = this.Delivery.DeliveryAddress;
            this.txtMemo.Text = this.Delivery.Memo;
            this.cmbTransportMethod.SelectedValue = this.Delivery.TransportMethodValue.ToString();
            this.txtPrincipal.Text = this.Delivery.Principal;
            this.txtPrincipalPhone.Text = this.Delivery.PrincipalPhone;
            this.txtTransportCompany.Text = this.Delivery.TransportCompany;
            this.comboBox1.SelectedValue = this.Delivery.VehicleID.ToString();
            this.comboBox1.SelectedIndex = this.comboBox1.SelectedIndex == -1 ? 0 : this.comboBox1.SelectedIndex;
            this.UpdateBtnEnabled((DeliveryStatus)this.Delivery.DeliveryStatusValue);


            signdateTimePicker1.Enabled = this.tsbtnSigned.Visible;
        }

        /// <summary>
        /// 更新配送信息(预约完成)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //车辆信息使用combobox的text属性
                string msg = string.Empty;
                Delivery newDelivery = PharmacyDatabaseService.GetDelivery(out msg, Delivery.Id);

                newDelivery.DeliveryStatusValue = (int)DeliveryStatus.Accepted;
                newDelivery.DeliveryTime = dtDeliveryDate.Value;
                newDelivery.DeliveryMethodValue = cmbDeliveryMethod.SelectedIndex;
                newDelivery.ShippingAddress = txtShippingAddress.Text;
                newDelivery.DeliveryAddress = txtDeliveryAddress.Text;
                newDelivery.TransportMethodValue = cmbDeliveryMethod.SelectedIndex;

                if (cmbDeliveryMethod.SelectedIndex == 0)
                {
                    newDelivery.VehicleID = Guid.Empty;
                }

                if (cmbDeliveryMethod.SelectedIndex == 2)
                {
                    newDelivery.Principal = txtPrincipal.Text;
                    newDelivery.PrincipalPhone = txtPrincipalPhone.Text;
                    newDelivery.TransportCompany = txtTransportCompany.Text;
                    newDelivery.VehicleInfo = cmbVehicle.Text;
                    newDelivery.VehicleID = Guid.Parse(cmbVehicle.SelectedValue.ToString());
                }
                if (cmbDeliveryMethod.SelectedIndex == 1)
                {

                    newDelivery.VehicleInfo = this.comboBox1.Text;
                    if (this.comboBox1.SelectedValue == null)
                    {
                        MessageBox.Show("请选择运输工具！"); return;
                    }
                    newDelivery.VehicleID = Guid.Parse(this.comboBox1.SelectedValue.ToString());
                }


                newDelivery.AcceptedTime = DateTime.Now;
                newDelivery.AcceptedOperatorId = AppClientContext.CurrentUser.Id;
                var billcode = this.PharmacyDatabaseService.GenerateBillDocumentCodeByTypeValue(out msg, (int)BillDocumentType.Test);
                newDelivery.AcceptedNo = billcode.Code;
                newDelivery.Memo = txtMemo.Text;


                PharmacyDatabaseService.SubmitDelivery(newDelivery);
                this.PharmacyDatabaseService.AddBillDocumentCode(out msg, billcode);
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行配送记录提交操作成功！");

                this.UpdateBtnEnabled(DeliveryStatus.Accepted);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行配送记录提交操作失败！");
            }
        }


        /// <summary>
        /// 自有车辆的情况下需要载入自有车辆信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTransportMethod_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 只有运输类型为自有车辆的时候才能选择车辆
        /// 不是自有车辆的情况下车辆信息为手动输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void initVehicleCombobox()
        {
            var vlist = this.ListVehicle.Where(r => (int)r.VehicleCategoryValue == 0)
                            .Select(p => new ListItem
                            {
                                ID = p.Id.ToString(),
                                Name = string.Format("车辆类型:{0},容积:{1},车牌号:{2},其他参数:{3}",
                                                    p.Type, p.Cubage, p.LicensePlate, p.Other)
                            }).ToList();
            this.comboBox1.DataSource = vlist;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "ID";
            this.comboBox1.SelectedIndex = 0;


            var vlistD = this.ListVehicle.Where(r => r.FlowID != null && r.ApprovalStatusValue == 2 && r.EndDate > DateTime.Now.Date).ToList();
            if (vlistD.Count <= 0) return;
            var ListE = vlistD.Select(p => new ListItem
                            {
                                ID = p.Id.ToString(),
                                Name = string.Format("车辆类型:{0},容积:{1},车牌号:{2},其他参数:{3}",
                                                    p.Type, p.Cubage, p.LicensePlate, p.Other)
                            }).ToList();

            if (ListE.Count <= 0) return;
            this.cmbVehicle.DisplayMember = "Name";
            this.cmbVehicle.ValueMember = "ID";
            this.cmbVehicle.DataSource = ListE;
            this.cmbVehicle.SelectedIndex = 0;
        }

        /// <summary>
        /// 配送方式为委托的时候,委托信息可以输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDeliveryMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var item = this.cmbDeliveryMethod.SelectedItem as ListItem;
            //不是自有车辆的情况下车辆信息为手动输入
            int deliveryMethodIndex = this.cmbDeliveryMethod.SelectedIndex;
            if (deliveryMethodIndex == 0)
            {
                this.gbEntrust.Visible = false;
                this.groupBox1.Visible = false;
                this.Height = 250;
            }
            if (deliveryMethodIndex == 1)
            {
                this.gbEntrust.Visible = false;
                this.groupBox1.Visible = true;

                this.Height = 380;
            }
            if (deliveryMethodIndex == 2)
            {
                this.gbEntrust.Visible = true;
                this.groupBox1.Visible = false;
                this.Height = 410;
            }
            if (this.cmbTransportMethod.Items.Count > 0)
                this.cmbTransportMethod.SelectedIndex = this.cmbDeliveryMethod.SelectedIndex;
        }
        /// <summary>
        /// 取消配送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要取消该配送单据吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) return;
            try
            {
                string msg = string.Empty;
                Delivery newDelivery = PharmacyDatabaseService.GetDelivery(out msg, Delivery.Id);

                newDelivery.DeliveryStatusValue = (int)DeliveryStatus.Canceled;
                newDelivery.CanceledTime = DateTime.Now;
                newDelivery.CanceledOperatorId = AppClientContext.CurrentUser.Id;
                var billcode = this.PharmacyDatabaseService.GenerateBillDocumentCodeByTypeValue(out msg, (int)BillDocumentType.Test);
                newDelivery.CanceledNo = billcode.Code;

                this.PharmacyDatabaseService.AddBillDocumentCode(out msg, billcode);
                PharmacyDatabaseService.UpdateDelivery(newDelivery);
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行取消配送记录成功");
                this.UpdateBtnEnabled(DeliveryStatus.Canceled);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnOuted_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Empty;
                Delivery newDelivery = PharmacyDatabaseService.GetDelivery(out msg, Delivery.Id);
                newDelivery.DeliveryStatusValue = (int)DeliveryStatus.Outed;
                newDelivery.outedTime = DateTime.Now;
                newDelivery.outedOperatorId = AppClientContext.CurrentUser.Id;
                var billcode = this.PharmacyDatabaseService.GenerateBillDocumentCodeByTypeValue(out msg, (int)BillDocumentType.Test);
                newDelivery.outedNo = billcode.Code;

                if (string.IsNullOrEmpty(PharmacyDatabaseService.UpdateDelivery(newDelivery)))
                {
                    this.PharmacyDatabaseService.AddBillDocumentCode(out msg, billcode);

                    MessageBox.Show("成功出库！");
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "提交配送记录出库操作成功");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("出库失败！请联系管理员！");
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "提交配送记录出库操作失败");
                }
                this.UpdateBtnEnabled(DeliveryStatus.Outed);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 签收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnSigned_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = string.Empty;
                Delivery newDelivery = PharmacyDatabaseService.GetDelivery(out msg, Delivery.Id);

                if (newDelivery.IsOver || newDelivery.DeliveryStatusValue == (int)DeliveryStatus.Signed)
                {
                    MessageBox.Show("该单据已被其他操作员执行过签收操作，请关闭，刷新！");
                    return;
                }

                newDelivery.DeliveryStatusValue = (int)DeliveryStatus.Signed;
                newDelivery.SignedTime = signdateTimePicker1.Value;
                newDelivery.SignedOperatorId = AppClientContext.CurrentUser.Id;
                var billcode = this.PharmacyDatabaseService.GenerateBillDocumentCodeByTypeValue(out msg, (int)BillDocumentType.Test);
                newDelivery.SignedNo = billcode.Code;
                newDelivery.IsOver = true;
                if (string.IsNullOrEmpty(PharmacyDatabaseService.UpdateDelivery(newDelivery)))
                {
                    this.PharmacyDatabaseService.AddBillDocumentCode(out msg, billcode);
                    MessageBox.Show("客户签收成功！销售单处理完毕！");
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "提交配送签收记录操作成功");
                }
                else
                {
                    MessageBox.Show("签收失败！请联系管理员！");
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "提交配送签收记录操作失败");
                }
                this.UpdateBtnEnabled(DeliveryStatus.Signed);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 销退申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnOrderReturn_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string msg = string.Empty;
            //    Delivery newDelivery = PharmacyDatabaseService.GetDelivery(out msg, Delivery.Id);

            //    newDelivery.DeliveryStatusValue = (int)DeliveryStatus.Return;
            //    newDelivery.ReturnTime = DateTime.Now;
            //    newDelivery.ReturnOperatorId = AppClientContext.CurrentUser.Id;
            //    var billcode = this.PharmacyDatabaseService.GenerateBillDocumentCodeByTypeValue(out msg, (int)BillDocumentType.Test);
            //    newDelivery.ReturnNo = billcode.Code;
            //    newDelivery.IsOver = true;
            //    PharmacyDatabaseService.UpdateDelivery(newDelivery);
            //    this.PharmacyDatabaseService.AddBillDocumentCode(out msg, billcode);
            //    this.UpdateBtnEnabled(DeliveryStatus.Return);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        /// <summary>
        /// 更新画面的按钮状态
        /// </summary>
        /// <param name="status"></param>
        private void UpdateBtnEnabled(DeliveryStatus status)
        {
            this.tsbtnSubmit.Enabled = false;
            this.tsbtnCancel.Enabled = false;
            this.tsbtnOuted.Enabled = false;
            this.tsbtnSigned.Enabled = false;

            this.tsbtnOrderReturn.Enabled = true;

            if (DeliveryStatus.Reservation == status)
            {
                this.tsbtnSubmit.Enabled = true;
            }
            else if (DeliveryStatus.Accepted == status)
            {
                this.tsbtnCancel.Enabled = true;
                this.tsbtnOuted.Enabled = true;
            }
            else if (DeliveryStatus.Outed == status)
            {
                this.tsbtnSigned.Enabled = true;
            }
        }

        private void tsbtnPrint_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.cmbVehicle.Items.Count <= 0) return;
            string q = this.textBox1.Text.Trim();
            if (string.IsNullOrEmpty(q)) return;

            foreach (var c in this.cmbVehicle.Items)
            {
                var u = c as ListItem;
                if (u.Name.Contains(q))
                {
                    this.cmbVehicle.SelectedItem = c;
                    break;
                }
            }
        }

        private void cmbVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid gid = Guid.Parse(this.cmbVehicle.SelectedValue.ToString());
            var c = this.ListVehicle.Where(r => r.Id == gid).FirstOrDefault();
            if (c == null) return;
            this.txtPrincipal.Text = c.DelegateMan;
            this.txtTransportCompany.Text = c.DelegateCompany;
            this.txtPrincipalPhone.Text = c.DelegateTel;
        }
    }
}
