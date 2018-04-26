using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Business.Models;


namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class FormSalesOrderInfo : BaseFunctionForm
    {
        private SalesOrder _salesOrder = new SalesOrder();
        public FormSalesOrderInfo()
        {
            InitializeComponent();
        }


        public FormSalesOrderInfo(SalesOrder SalesOrder)
        {
            InitializeComponent();
            _salesOrder = SalesOrder;

        }


        /// <summary>
        /// form load 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSalesOrderInfo_Load(object sender, EventArgs e)
        {
            try
            {
                this.usSOInfo.InitEditControl(_salesOrder);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
