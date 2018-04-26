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

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class FormPayConfirm : BaseFunctionForm
    {
        List<SalesOrderDetail> _listSalesOrderDetails=new List<SalesOrderDetail>();
        Guid _salesOrderId = Guid.Empty;
        public FormPayConfirm()
        {
            InitializeComponent();
            BindPayMent();
        }

        public FormPayConfirm(Guid saleOrderId)
        {
            InitializeComponent();
            _salesOrderId = saleOrderId;

            BindPayMent();
        }

        /// <summary>
        /// 结算方式
        /// </summary>
        public Guid PayForms
        {
            get { return (Guid)this.cmbPayMethod.SelectedValue; }
        }

        /// <summary>
        /// 结算备注
        /// </summary>
        public string PayMemo
        {
            get { return this.txtMemo.Text; }
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.cmbPayMethod.SelectedValue == null)
            {
                MessageBox.Show("请选择结算方式");
            }
            else 
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        private void BindPayMent()
        {
            IList<PaymentMethod> payList = new List<PaymentMethod>();
            string msg = string.Empty;
            payList = PharmacyDatabaseService.AllPaymentMethods(out msg);

            var drugInventorys = PharmacyDatabaseService.GetDrugInventoryRecordBySalesOrderId(_salesOrderId, out msg);
            bool IsSpecialDrug = drugInventorys.Where(r => r.DrugInfo.IsSpecialDrugCategory).Count() > 0;
            if (IsSpecialDrug)
            {
                MessageBox.Show("当前订单含有特殊药品，不能采用现金支付方式！");
                payList = payList.Where(r => !r.Name.Contains("现金")).ToList();
            }

            cmbPayMethod.DataSource = payList;
            cmbPayMethod.DisplayMember = "Name";
            cmbPayMethod.ValueMember = "ID";

            if (!IsSpecialDrug)
                cmbPayMethod.SelectedItem = payList.Where(r => r.Name.Contains("现金")).FirstOrDefault();

        }
    }
}
