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
    public partial class FormSalesIndex : BaseFunctionForm
    {
        string msg = string.Empty;
        ContextMenuStrip cms = new ContextMenuStrip();

        public FormSalesIndex()
        {
            InitializeComponent();

            cms.Items.Add("统计方式");
            cms.Items.Add("-");
            cms.Items.Add("显示合计", null, delegate(object sender, EventArgs e)
            {
                this.GetResult(0);
            });
            cms.Items.Add("计算平均值", null, delegate(object sender, EventArgs e)
            {
                this.GetResult(1);
            });
            cms.Items.Add("计数", null, delegate(object sender, EventArgs e)
            {
                this.GetResult(2);
            });
        }

        private void GetResult(int i)
        {
            DataGridViewSelectedCellCollection sc = this.dataGridView1.SelectedCells;

            List<decimal> ListD = new List<decimal>();

            foreach (  DataGridViewCell r in sc)
            {
                decimal d=0m;
                bool b = Decimal.TryParse(r.Value.ToString(), out d);
                if (!b)
                {
                    MessageBox.Show("您所选择的单元格含有非数字，请取消其选择，谢谢！");
                    return;
                }
                ListD.Add(d);
            }                     
            
            decimal result =i==0? ListD.Sum():i==1?ListD.Average():ListD.Count;
            MessageBox.Show("统计结果是："+result.ToString("F4"));
        }

        BindingList<SaleOrderReturnDetailList> bList = new BindingList<SaleOrderReturnDetailList>(); 
        public FormSalesIndex(SalesOrderReturn[] sos):this()
        {
            bList.Clear();

            foreach (var c in sos)
            {
                SaleOrderReturnDetailList sordl = new SaleOrderReturnDetailList();
                var saleorder=this.PharmacyDatabaseService.GetSalesOrder(out msg,c.SalesOrderID);
                var purchaseUnitName=this.PharmacyDatabaseService.GetPurchaseUnit(out msg,saleorder.PurchaseUnitId);

                sordl.PurchaseName = purchaseUnitName.Name;
                sordl.Num = c.SalesOrderReturnDetails.Sum(r => r.ReturnAmount);
                sordl.PriceCount = c.SalesOrderReturnDetails.Where(r=>r.Deleted==false).Sum(r => r.ActualUnitPrice * r.ReturnAmount);
                sordl.Saler = saleorder.SalerName;
                sordl.ReturnCode=c.OrderReturnCode;
                sordl.SalesOrederCode = saleorder.OrderCode;
                bList.Add(sordl);
            }

            this.dataGridView1.DataSource =new BindingCollection<SaleOrderReturnDetailList> (bList.OrderBy(r=>r.Saler).ThenBy(r=>r.ReturnCode).ToList());

            this.toolStripLabel2.Text = bList.Sum(r => r.PriceCount).ToString() + "；退单数量：" + bList.Count.ToString();
        }
        class SaleOrderReturnDetailList
        {
            public string PurchaseName { get; set; }
            public decimal Num { get; set; }
            public decimal PriceCount { get; set; }
            public string Saler { get; set; }
            public string ReturnCode { get; set; }
            public string SalesOrederCode{get;set;}
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count <= 0) return;
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
            this.cms.Show(MousePosition.X, MousePosition.Y);
        }
    }
}
