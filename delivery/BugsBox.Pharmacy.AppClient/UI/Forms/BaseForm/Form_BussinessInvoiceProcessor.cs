using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseForm
{
    public partial class Form_BussinessInvoiceProcessor : BaseFunctionForm
    {
        string msg = string.Empty;

        public Form_BussinessInvoiceProcessor()
        {
            InitializeComponent();
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1).AddHours(-DateTime.Now.Hour).AddMinutes(-DateTime.Now.Minute);
            this.dateTimePicker2.Value = DateTime.Now.AddDays(1).AddHours(-DateTime.Now.Hour - 1).AddMinutes(-DateTime.Now.Minute);

            Models.User usr = BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser;

            var allRoles = this.PharmacyDatabaseService.AllRoles(out msg).Where(r => r.Name.Contains("SystemRole") || r.Name.Contains("adminRole"));
            var allrolew = from m in this.PharmacyDatabaseService.AllRoleWithUsers(out msg)
                           join a in allRoles on
                               m.RoleId equals a.Id
                           where m.UserId == usr.Id
                           select m;


            if (allrolew.ToList().Count <= 0)
            {
                this.toolStripDropDownButton1.Visible = false;
            }
        }

        private void 采购税点管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.PurchaseBusiness.Form_SalerTaxRate frm = new PurchaseBusiness.Form_SalerTaxRate();
            frm.Show();
        }

        private void 销售税点管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.SalesBusiness.Form_SalerTaxRateManage frm = new SalesBusiness.Form_SalerTaxRateManage();
            frm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Forms.PurchaseBusiness.Form_PurchaseInvoiceProc frm = new PurchaseBusiness.Form_PurchaseInvoiceProc();
            frm.Show(this);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Forms.SalesBusiness.Form_SalesInvoiceProc frm = new SalesBusiness.Form_SalesInvoiceProc();
            frm.Show(this);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            List<Business.Models.AllTax> result = this.PharmacyDatabaseService.GetAllTax(this.dateTimePicker1.Value.Date, this.dateTimePicker2.Value.AddDays(1).Date, Guid.Empty, out msg).ToList();
            Business.Models.AllTax newR = new Business.Models.AllTax();

            newR.salerName = "合计";
            newR.Diff = result.Sum(r => r.Diff);
            newR.PInvoiceMoney = result.Sum(r => r.PInvoiceMoney);
            newR.PMoney = result.Sum(r => r.PMoney);
            newR.PPayedMoney = result.Sum(r => r.PPayedMoney);
            
            newR.PNum = result.Sum(r => r.PNum);
            newR.PTax = result.Sum(r => r.PTax);
            newR.ReceivedMoney = result.Sum(r => r.ReceivedMoney);
            newR.SaleMoney = result.Sum(r => r.SaleMoney);
            newR.SNum = result.Sum(r => r.SNum);
            newR.STax = result.Sum(r => r.STax);
            newR.MRateMoney = result.Sum(r => r.MRateMoney);
            newR.IRateMoney = result.Sum(r => r.IRateMoney);
            newR.tax = result.Sum(r => r.tax);
            result.Add(newR);

            this.dataGridView1.DataSource = new BindingCollection<Business.Models.AllTax>(result);


            this.dataGridView1.Columns["PIRate"].Visible = false;
            DataGridViewCellStyle dcs = new DataGridViewCellStyle();
            dcs.BackColor = Color.Aqua;
            for (int i = 2; i <= 6; i++)
            {                
                this.dataGridView1.Columns[i].DefaultCellStyle = dcs;
            }
            dcs = new DataGridViewCellStyle();
            dcs.BackColor = Color.LightYellow;
            for (int i = 7; i <= 13; i++)
            {
                this.dataGridView1.Columns[i].DefaultCellStyle = dcs;
            }
            dcs = new DataGridViewCellStyle();
            dcs.BackColor = Color.LightBlue;
            this.dataGridView1.Columns[12].DefaultCellStyle = dcs;

            DataGridViewCellStyle dgvcs1=new DataGridViewCellStyle();
            dgvcs1.ForeColor=Color.Red;
            DataGridViewCellStyle dgvcs2=new DataGridViewCellStyle();
            dgvcs2.ForeColor=Color.Blue;

            foreach (DataGridViewRow r in this.dataGridView1.Rows)
            {
                if (r.Cells[14].Value == null) continue;
                if (Convert.ToDecimal(r.Cells[14].Value) <= 0)
                {
                    r.Cells[14].Style = dgvcs1;
                }
                else
                {
                    r.Cells[14].Style = dgvcs2;
                }
            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "采购、销售管理、税票统计结果");
        }
    }
}
