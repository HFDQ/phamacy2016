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
using BugsBox.Pharmacy.Models; 

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Sys
{
    public partial class FormUserLogQuery :BaseFunctionForm
    {
        string msg = string.Empty;
        PagerInfo pageInfo = new PagerInfo();
        List<User> ListUser = new List<User>();
        List<Employee> ListEmployee = new List<Employee>();

        public FormUserLogQuery()
        {
            InitializeComponent();
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FormUserLogQuery_Load(object sender, EventArgs e)
        {
            this.toolStripComboBox1.SelectedIndex = 0;
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            this.dataGridView1.AutoGenerateColumns = false;
            ListUser = this.PharmacyDatabaseService.AllUsers(out msg).ToList();
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.search(this.toolStripComboBox1.SelectedIndex);
        }

        private void search(int type)
        {
            switch (type)
            {
                case 0:
                    this.SalesOrderLog();
                    break;
                case 1:
                    this.purchaseOrderLog();
                    break;
            }
        }

        private void SalesOrderLog()
        {
            try
            {
                PagerInfo pi = new PagerInfo();
                Business.Models.SalesCodeSearchInput scsi = new Business.Models.SalesCodeSearchInput();
                DateTime dtF = this.dateTimePicker1.Value;
                DateTime dtT = this.dateTimePicker2.Value;
                var salesOrderList = PharmacyDatabaseService.AllSalesOrders(out msg).Where(r => r.BalanceTime > dtF && r.BalanceTime < dtT);

                var c = from i in salesOrderList
                        select new LogContext
                        {
                            dt = i.CreateTime,
                            name = i.SalerName,
                            context = "开销售单" + i.OrderCode,
                            type = "销售操作日志"
                        };
                this.dataGridView1.DataSource = c.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("日志查询失败！请联系统管理员！");
            }
        }

        private void purchaseOrderLog()
        {
            try
            {
                DateTime dtF = this.dateTimePicker1.Value;
                DateTime dtT = this.dateTimePicker2.Value;
                var all = this.PharmacyDatabaseService.AllPurchaseOrders(out msg).Where(r => r.CreateTime > dtF && r.CreateTime < dtT); ;
            
                var c = from i in all
                        join j in ListUser on i.CreateUserId equals j.Id
                        select new LogContext
                        {
                            dt=i.CreateTime,
                            name=j.Employee.Name,
                            context="开票采购单"+i.DocumentNumber,
                            type="采购开票日志"
                        };
                this.dataGridView1.DataSource = c.OrderBy(r=>r.dt).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("日志查询失败！请联系统管理员！");
            }
        }

        private void saleReturnOrderLog()
        {
            try
            {
                DateTime dtF = this.dateTimePicker1.Value;
                DateTime dtT = this.dateTimePicker2.Value;
                var all = this.PharmacyDatabaseService.AllSalesOrderReturns(out msg).Where(r => r.CreateTime > dtF && r.CreateTime < dtT); ;

                var c = from i in all
                        join j in ListUser on i.CreateUserId equals j.Id
                        select new LogContext
                        {
                            dt = i.CreateTime,
                            name = j.Employee.Name,
                            context = "销售退单" + i.OrderReturnCode,
                            type = "销售退单日志"
                        };
                this.dataGridView1.DataSource = c.OrderBy(r => r.dt).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("日志查询失败！请联系统管理员！");
            }
        }

        private void pagerControl1_DataPaging()
        {            
           
            
        }

    }
    public class LogContext
    {
        public DateTime dt { get; set; }
        public string name { get; set; }
        public string context { get; set; }
        public string type { get; set; }
    }
}
