using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common.Helper;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class FormSalesOrderReturnBalance :BaseFunctionForm
    {
        string message = string.Empty;
        private int _returnStatus;
        BindingList<orderReturnSummary> bList = new BindingList<orderReturnSummary>();
        List<SalesOrderReturn> list = new List<SalesOrderReturn>();
        public FormSalesOrderReturnBalance()
        {
            InitializeComponent();

            this.dataGridView1.DataSource = bList;
        }

        private void FormSalesOrderReturnBalance_Load(object sender, EventArgs e)
        {
            this._returnStatus = OrderReturnStatus.QualityApproved.GetHashCode();
            this.getData();
        }

        private void getData()
        {
            list = PharmacyDatabaseService.GetSalesOrderReturnByStatus(out message, new int[] { _returnStatus }).ToList();
            bList.Clear();            
            foreach (var l in list)
            {
                orderReturnSummary ors=new orderReturnSummary();
                ors.id=l.Id;
                ors.returnDocumentNumber=l.OrderReturnCode;
                ors.returnApplyDate=l.CreateTime;
                ors.saleOrderDocumentNumber=PharmacyDatabaseService.GetSalesOrder(out message,l.SalesOrderID).OrderCode;
                ors.saleMan=this.PharmacyDatabaseService.GetEmployeeByUserId(out message,l.SellerID).Name;
                bList.Add(ors);
            }
        }

        class orderReturnSummary
        {
            public Guid id { get; set; }
            public string returnDocumentNumber { get; set; }
            public DateTime returnApplyDate { get; set; }
            public string saleOrderDocumentNumber { get; set; }
            public string saleMan { get; set; }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == 1)
            {
                Guid id = bList[e.RowIndex].id;
                SalesOrderReturn sor = list.First(r => r.Id == id);
                FormSalesOrderReturn frm = new FormSalesOrderReturn(sor, true, true);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    getData();
                    return;
                }
            }
            if (this.dataGridView1.CurrentCell.OwningColumn.Name.Equals(Column6.Name))
            {
                Guid id = bList[e.RowIndex].id;
                SalesOrderReturn sor = list.First(r => r.Id == id);
                FormSalesOrderReturn frm = new FormSalesOrderReturn(sor, true, false);
                frm.ShowDialog();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            list = PharmacyDatabaseService.GetSalesOrderReturnByStatus(out message, new int[] { _returnStatus,OrderReturnStatus.Balanced.GetHashCode(),OrderReturnStatus.ReturnReceived.GetHashCode(),OrderReturnStatus.ReturnChecked.GetHashCode(),OrderReturnStatus.Over.GetHashCode()}).ToList();
            if (list.Count <= 0)
            {
                MessageBox.Show("查询结果为0");
                return;
            }

            this.Column5.Visible = false;
            this.Column6.Visible = true;
            bList.Clear();
            foreach (var l in list)
            {
                orderReturnSummary ors = new orderReturnSummary();
                ors.id = l.Id;
                ors.returnDocumentNumber = l.OrderReturnCode;
                ors.returnApplyDate = l.CreateTime;
                ors.saleOrderDocumentNumber = PharmacyDatabaseService.GetSalesOrder(out message, l.SalesOrderID).OrderCode;
                ors.saleMan = this.PharmacyDatabaseService.GetEmployeeByUserId(out message, l.SellerID).Name;
                bList.Add(ors);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Column5.Visible = true;
            this.Column6.Visible = false;
            this.getData();
        }
    }
}
