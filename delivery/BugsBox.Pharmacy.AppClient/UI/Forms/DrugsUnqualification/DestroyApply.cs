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
using BugsBox.Pharmacy.UI.Common.Printer;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.UI.Report;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugsUnqualification
{
    public partial class DestroyApply : BaseFunctionForm
    {
        string msg = string.Empty;
        BindingList<DrugsBreakage> bList = new BindingList<DrugsBreakage>();
        public DestroyApply()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.CellClick += dataGridView1_CellClick;

            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };

        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||e.ColumnIndex<0) return;


            if (this.dataGridView1.Columns[e.ColumnIndex].Name != this.Clm7.Name)
            {
                var c = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as DrugsBreakage;
                Guid approvalFlowId = c.flowID;
                using (FormUnqualificationApprovalDetail f = new FormUnqualificationApprovalDetail())
                {
                   
                    var af = this.PharmacyDatabaseService.GetApproveFlowsByFlowID(out msg, approvalFlowId);
                    UserControls.UcDrugBreakage ucf = new UserControls.UcDrugBreakage(c,af);
                    f.Height += ucf.Height;
                    f.Controls.Add(ucf);
                    ucf.Dock = DockStyle.Fill;
                    f.Text = "品种报损单:" + c.drugName;
                    f.ShowDialog();
                }
            }
            else
            {
                DrugsBreakage db = bList[e.RowIndex];
                FormDrugUnqualificationDestroy frm = new FormDrugUnqualificationDestroy(db);
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    toolStripButton1_Click(sender, e);
                }
            }
        }

        private void DestroyApply_Load(object sender, EventArgs e)
        {
            DrugsBreakage db = new DrugsBreakage();
            db.ApprovalStatusValue = 2;
            this.loadData(db);
            this.dataGridView1.DataSource = bList;
        }

        private void loadData( DrugsBreakage db )
        {
            bList.Clear();
            var c = PharmacyDatabaseService.GetDrugsBreakagesPassed(db, out msg);
            foreach (var i in c)
            {
                bList.Add(i);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string t = this.toolStripTextBox1.Text.Trim();
            DrugsBreakage db = new DrugsBreakage();
            db.drugName = t;
            loadData(db);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DrugsBreakage db = new DrugsBreakage();
            db.ApprovalStatusValue = 2;
            this.loadData(db);
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            this.toolStripTextBox1.Text = string.Empty;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            List<DrugsBreakage> listB = new List<DrugsBreakage>();
            foreach (DataGridViewRow dr in this.dataGridView1.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[0].Value))
                {
                    listB.Add(bList[dr.Index]);
                }
            }
            if (listB.Count <= 0)
            {
                MessageBox.Show("请勾选要批量填写的记录！");
                return;
            }
            FormDrugUnqualificationDestroy frm = new FormDrugUnqualificationDestroy(listB.ToArray());
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                toolStripButton1_Click(sender, e);
            }

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



    }
}
