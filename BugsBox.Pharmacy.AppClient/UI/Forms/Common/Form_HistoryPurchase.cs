using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.Common;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    public partial class Form_HistoryPurchase : BaseFunctionForm
    {
        Guid _id = Guid.Empty;
        string msg = string.Empty;
        int _type = 0;
        Guid _purchaseUnitID = Guid.Empty;
        DateTimePicker dtp = new DateTimePicker();
        DateTimePicker dtpTo = new DateTimePicker();
        public Form_HistoryPurchase(Guid id,int type=0)
        {
            InitializeComponent();
            _id = id;
            _type = type;

            dtp.Value = DateTime.Now.AddMonths(-3).Date;
            dtpTo.Value = DateTime.Now.Date;
            this.toolStrip1.Items.Insert(1, new ToolStripControlHost(dtp));
            this.toolStrip1.Items.Insert(3, new ToolStripControlHost(dtpTo));

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
        }

        /// <summary>
        /// 根据购货商ID获取历史销售信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="gid"></param>
        public Form_HistoryPurchase(Guid id, int type ,Guid PurchaseUnitID)
        {
            InitializeComponent();
            _id = id;
            _type = type;
            _purchaseUnitID = PurchaseUnitID;

            dtp.Value = DateTime.Now.AddMonths(-3).Date;
            dtpTo.Value = DateTime.Now.Date;
            this.toolStrip1.Items.Insert(1, new ToolStripControlHost(dtp));
            this.toolStrip1.Items.Insert(3, new ToolStripControlHost(dtpTo));

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData==Keys.Return || keyData==Keys.Escape)
            {
                this.Dispose();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form_HistoryPurchase_Load(object sender, EventArgs e)
        {
            if (_type == 2)
            {
                Business.Models.QueryModelForDrugPath m = new Business.Models.QueryModelForDrugPath();
                m.DTT = this.dtpTo.Value.AddDays(1).Date;
                m.DTF = this.dtp.Value.Date;
                m.DrugPathQueryType = 0;
                m.Id = _id;
                var c = this.PharmacyDatabaseService.GetDrugPath(m, out msg).OrderByDescending(r=>r.saleDate).ToList();
                if (!_purchaseUnitID.Equals(Guid.Empty))
                    c = c.Where(r => r.purchaseUnitId.Equals(_purchaseUnitID)).ToList();
                foreach (DataGridViewColumn dc in this.dataGridView1.Columns)
                {
                    if (dc.Index < 7) dc.Visible = false;
                    else
                    {
                        dc.Visible = true;
                    }
                }
                this.Text = "药品批次销售记录";
                this.dataGridView1.DataSource =new BindingCollection<Business.Models.DrugPath>(c);
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "成功获取该药品批次历史销售信息");
            }
            else if (_type == 3)
            {
                Business.Models.QueryModelForDrugPath m = new Business.Models.QueryModelForDrugPath();
                m.DTT = this.dtpTo.Value.AddDays(1).Date;
                m.DTF = this.dtp.Value.Date;
                m.DrugPathQueryType = 2;
                m.Id = _id;
                var c = this.PharmacyDatabaseService.GetDrugPath(m, out msg).OrderByDescending(r => r.saleDate).ToList();
                if (!_purchaseUnitID.Equals(Guid.Empty))
                    c = c.Where(r => r.purchaseUnitId.Equals(_purchaseUnitID)).ToList();
                foreach (DataGridViewColumn dc in this.dataGridView1.Columns)
                {
                    if (dc.Index < 7) dc.Visible = false;
                    else
                    {
                        dc.Visible = true;
                    }
                }
                this.Text = "药品销售记录";
                this.dataGridView1.DataSource = new BindingCollection<Business.Models.DrugPath>(c);
                this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "成功获取历史销售信息");
            }
            else
            {
                var c = this.PharmacyDatabaseService.GetPurchaseHistoryByInInventoryPurchaseID(_id, _type, out msg).OrderByDescending(r => r.inInventoryDate).ToList();
                this.dataGridView1.DataSource = new BindingCollection<Business.Models.HistoryPurchase>(c);
            }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form_HistoryPurchase_Load(null, null);
        }
    }
}
