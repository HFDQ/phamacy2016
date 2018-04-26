using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.UserControls
{
    public partial class UCDirectSales :UserControl
    {
        string msg = string.Empty;

        public UCDirectSales(Models.DirectSalesOrder dso)
        {
            InitializeComponent();
            #region 初始化控件
            this.dataGridView1.AutoGenerateColumns = false;
            #endregion

            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            using (BaseFunctionForm bf = new BaseFunctionForm())
            {
                var dsod = bf.PharmacyDatabaseService.GetDirectSalesOrderDetailModelByDirectSalesModel(dso.Id, out msg).OrderBy(r => r.ProducGeneralName);
                this.dataGridView1.DataSource = new BindingCollection<Business.Models.DirectSalesOrderDetailModel>(dsod.ToList());

                #region 直调企业信息
                var SupplyUnit = bf.PharmacyDatabaseService.GetSupplyUnit(out msg, dso.SupplyUnitId);
                var PurchaseUnit = bf.PharmacyDatabaseService.GetPurchaseUnit(out msg, dso.PurchaseUnitId);
                
                G1.Text += SupplyUnit.Name;
                G2.Text += SupplyUnit.DetailedAddress;
                G3.Text += dso.CheckUserName;
                G4.Text += SupplyUnit.Header;
                G5.Text += SupplyUnit.ContactTel;

                S1.Text += PurchaseUnit.Name;
                S2.Text += PurchaseUnit.DetailedAddress;
                S3.Text += dso.CheckUserName;
                S4.Text += PurchaseUnit.Header;
                S5.Text += PurchaseUnit.ContactTel;
                #endregion

                #region 直调基本信息
                this.label1.Text += dso.DocumentNumber;
                var CreateUser=bf.PharmacyDatabaseService.GetUser(out msg, dso.CreateUserId);
                this.label2.Text += CreateUser ==null?"无":CreateUser.Employee.Name;
                this.label4.Text += dso.UpdateTime.ToShortDateString();
                this.label5.Text += dso.DirectSalesOrderDetails.Sum(r => r.SupplyPrice * r.Amount);
                this.label6.Text += dso.DirectSalesOrderDetails.Sum(r => r.SalePrice * r.Amount);
                this.label7.Text += dso.DirectSalesOrderDetails.Sum(r => r.DirectSaleDiff);
                this.richTextBox1.Text = dso.Memo;
                #endregion
            }

        }


    }
}
