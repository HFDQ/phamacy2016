
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Reflection;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class FormOrderReturnDetailIndex : BaseFunctionForm
    {
        private  string msg;

        public FormOrderReturnDetailIndex()
        {
            InitializeComponent();

            BugsBox.Pharmacy.UI.Common.BaseRightMenu brm = new BugsBox.Pharmacy.UI.Common.BaseRightMenu(this.dataGridView1);

            brm.InsertMenuItem("导出查询结果", delegate () 
            {
                MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "销售品种退货记录");
            });
            brm.InsertMenuItem("查看销退详情", delegate ()
             {
                 if (this.dataGridView1.CurrentRow == null) return;
                 var m = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.SalesOrderReturnDetailModel;
                 var orderReturn = PharmacyDatabaseService.GetSalesOrderReturn(out msg, m.SalesOrderReturnId);
                 using (FormSalesOrderReturn frm = new FormSalesOrderReturn(orderReturn))
                 {
                     frm.ShowDialog();
                 }
             });
            brm.InsertMenuItem("查看销售单", delegate ()
            {
                if (this.dataGridView1.CurrentRow == null) return;
                var m = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.SalesOrderReturnDetailModel;
                SalesOrder so = this.PharmacyDatabaseService.GetSalesOrder(out msg, m.SalesOrderId);
                using (FormSalesOrderEdit frm = new FormSalesOrderEdit(so, true))
                {
                    frm.ShowDialog();
                }
            });

            Business.Models.SalesOrderReturnDetailQueryModel q = null;

            //初始化查询条件
            Action InitQuery = () =>
            {
                this.dateTimePicker1.Value = DateTime.Now.Date.AddDays(-3);
                this.dateTimePicker2.Value = DateTime.Now.Date;

                q = new Business.Models.SalesOrderReturnDetailQueryModel
                {
                    DTF = this.dateTimePicker1.Value,
                    DTT = this.dateTimePicker2.Value.AddDays(1)
                };
                this.salesOrderReturnDetailQueryModelBindingSource.Clear();
                this.salesOrderReturnDetailQueryModelBindingSource.Add(q);
            };
            InitQuery();

            #region 初始化表格控件
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.RowPostPaint += (s, e) => DataGridViewOperator.SetRowNumber(this.dataGridView1, e);
            this.dataGridView1.AllowUserToOrderColumns = true;
            #endregion

            #region 按钮事件
            this.toolStripButton1.Click += (s, e) =>
                {
                    this.Validate();
                    q.DTT = this.dateTimePicker2.Value.AddDays(1);
                    q.DTF = this.dateTimePicker1.Value;

                    var re = this.PharmacyDatabaseService.GetSalesOrderReturnDetailModels(q, out msg).ToList();
                    re.Add(new Business.Models.SalesOrderReturnDetailModel
                    {
                        ProductGeneralName = "合计",
                        ReturnAmount = re.Sum(r => r.ReturnAmount),
                        Price = re.Sum(r => decimal.Round(r.ReturnAmount * r.UnitPrice, 4))
                    });
                    this.dataGridView1.DataSource = re;

                    this.dataGridView1.Columns["DrugInfoId"].Visible = false;
                    this.dataGridView1.Columns["CreateTime"].Visible = false;
                    this.dataGridView1.Columns["ReturnEmName"].Visible = false;
                    this.dataGridView1.Columns["Id"].Visible = false;
                    this.dataGridView1.Columns["SalesOrderId"].Visible = false;
                    this.dataGridView1.Columns["SalesOrderReturnId"].Visible = false;

                    Business.Models.SalesOrderReturnDetailModel m = new Business.Models.SalesOrderReturnDetailModel();
                    PropertyInfo[] pis = m.GetType().GetProperties();
                    foreach (PropertyInfo pi in pis)
                    {
                        int a = (pi.GetCustomAttributes(typeof(DataMemberAttribute), false)[0] as DataMemberAttribute).Order;
                        if (a < 0) continue;
                        this.dataGridView1.Columns[pi.Name].DisplayIndex = a;
                    }
                };

            this.toolStripButton2.Click += (s, e) =>
            {
                InitQuery();
            };

            this.toolStripButton3.Click += (s, e) =>
            {
                MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "销售品种退货记录");
            }; 
            #endregion
        }


    }
}
