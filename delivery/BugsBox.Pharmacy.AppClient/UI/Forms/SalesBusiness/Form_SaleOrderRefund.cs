using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class Form_SaleOrderRefund : BaseFunctionForm
    {
        string msg = string.Empty;
        Business.Models.SalesCodeSearchInput scsi = new Business.Models.SalesCodeSearchInput();
        bool Editable = false;
        public Form_SaleOrderRefund()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;

            User usr = BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser;

            var allRoles = this.PharmacyDatabaseService.AllRoles(out msg).Where(r => r.Name.Contains("SystemRole") || r.Name.Contains("adminRole"));
            var allrolew = from m in this.PharmacyDatabaseService.AllRoleWithUsers(out msg)
                           join a in allRoles on
                               m.RoleId equals a.Id
                           where m.UserId == usr.Id
                           select m;

            if (allrolew.ToList().Count <= 0)
            {
                this.toolStripButton2.Visible = false;
            }
            else
            {
                Editable = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            scsi.Code = this.textBox1.Text.Trim();
            scsi.FromDate = this.dateTimePicker1.Value.Date;
            scsi.ToDate = this.dateTimePicker2.Value.AddDays(1).Date;
            var c=this.PharmacyDatabaseService.GetSalesOrderBalanceCodePaged(scsi,out msg);
            this.dataGridView1.DataSource=new BindingList<Business.Models.SaleOrderModel>(c.ToList());
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var c = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Business.Models.SaleOrderModel;
            if (c == null) return;
            Guid id = c.Id;
            SalesOrder so = this.PharmacyDatabaseService.GetSalesOrder(out msg, id);
            if (so == null) return;
            FormSalesOrderEdit frm = new FormSalesOrderEdit(so,true,true,Editable);
            frm.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            scsi.Code = this.textBox1.Text.Trim();
            scsi.FromDate = this.dateTimePicker1.Value.Date;
            scsi.ToDate = this.dateTimePicker2.Value.AddDays(1).Date;
            var c = this.PharmacyDatabaseService.GetSaleRefundHistory(scsi, out msg);
            this.dataGridView1.DataSource = new BindingList<Business.Models.SaleOrderModel>(c.ToList());
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
                toolStripButton1_Click(sender, e);
        }
    }
}
