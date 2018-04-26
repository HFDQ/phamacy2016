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

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class FormOrderReturnIndex : BaseFunctionForm
    {
        private List<SalesOrderReturn> _salesOrderReturnList = new List<SalesOrderReturn>();
        ContextMenuStrip cms = new ContextMenuStrip();
        string msg = string.Empty;
        public FormOrderReturnIndex()
        {
            InitializeComponent();
            this.dataGridView1.ReadOnly = true;

            this.dataGridView1.RowPostPaint += (s, e) => DataGridViewOperator.SetRowNumber(this.dataGridView1, e);

            var c = this.PharmacyDatabaseService.AllUsers(out msg);
            this.cmbOperator.ValueMember = "Id";
            this.cmbOperator.DisplayMember = "Account";
            this.cmbOperator.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmbOperator.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmbOperator.DataSource = c.ToList();
            if (this.cmbOperator.Items.Count <= 0) return;
            this.cmbOperator.SelectedIndex = -1;

            ToolStripMenuItem tsmi = new ToolStripMenuItem("手工统计");
            tsmi.DropDownItems.Add("求和", null, delegate(object sender, EventArgs e) { this.GetResult(0); });
            tsmi.DropDownItems.Add("平均", null, delegate(object sender, EventArgs e) { this.GetResult(1); });
            tsmi.DropDownItems.Add("记数", null, delegate(object sender, EventArgs e) { this.GetResult(2); });
            cms.Items.Add(tsmi);

            cms.Items.Add("-");
            cms.Items.Add("查看单据");
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("查看退货单详细", null, delegate(object sender, EventArgs e) { this.queryDetails(0); });
            cms.Items.Add("查看采购单详细", null, delegate(object sender, EventArgs e) { this.queryDetails(1); });

        }

        private void queryDetails(int type)
        {
            if (this.dataGridView1.SelectedCells.Count <= 0) return;
            Business.Models.PurchaseOrderReturnModel m = this.dataGridView1.Rows[this.dataGridView1.SelectedCells[this.dataGridView1.SelectedCells.Count - 1].RowIndex].DataBoundItem as Business.Models.PurchaseOrderReturnModel;



            if (type == 0)
            {
                PurchaseCommonEntity pce = this.PharmacyDatabaseService.GetPurchaseOrderReturnsByPurchaseOrderId(out msg, m.Pid).FirstOrDefault();

                if (pce == null) return;
                pce.Id = m.id;
                FormReturnOrder frm = new FormReturnOrder(pce, true);
                frm.ShowDialog();
            }
            if (type == 1)
            {
                PurchaseOrdeEntity poe = this.PharmacyDatabaseService.GetPurchaseOrderEntity(out msg, m.Pid);
                if (poe == null) return;
                FormPurchaseOrderEdit frm = new FormPurchaseOrderEdit(poe, false, true);
                frm.ShowDialog();
            }
        }

        private void HideColumn()
        {
            if (dataGridView1.ColumnCount < 1) return;
            this.dataGridView1.Columns["Column1"].Visible = false;
            this.dataGridView1.Columns["Pid"].Visible = false;
        }
        private void GetResult(int i)
        {
            DataGridViewSelectedCellCollection sc = this.dataGridView1.SelectedCells;

            List<decimal> ListD = new List<decimal>();

            foreach (DataGridViewCell r in sc)
            {
                decimal d = 0m;
                if (r.Value == null) r.Value = 0.0m;
                bool b = Decimal.TryParse(r.Value.ToString(), out d);
                if (!b)
                {
                    MessageBox.Show("您所选择的单元格含有非数字，请取消其选择，谢谢！");
                    return;
                }
                ListD.Add(d);
            }

            decimal result = i == 0 ? ListD.Sum() : i == 1 ? ListD.Average() : ListD.Count;
            MessageBox.Show("统计结果是：" + result.ToString("F4"));
        }

        private void GetListPurchaseOrderReturn()
        {
            try
            {
                _salesOrderReturnList = null;
                string msg = string.Empty;
                Business.Models.PurchaseOrderReturnQueryModel scsi = this.InitPurchaseOrderReturnSearchInput();
                var c = this.PharmacyDatabaseService.GetPReturnOrderByQureyModel(scsi, out msg);
                var re = from i in c
                         group i by i.id into g
                         select new Business.Models.PurchaseOrderReturnModel
                         {
                             id = g.FirstOrDefault().id,
                             Pid = g.FirstOrDefault().Pid,
                             POrderCreater = g.FirstOrDefault().POrderCreater,
                             POrderCreateTime = g.FirstOrDefault().POrderCreateTime,
                             POrderDocumentNumber = g.FirstOrDefault().POrderDocumentNumber,
                             POrderFSuggest = g.FirstOrDefault().POrderFSuggest,
                             POrderFTime = g.FirstOrDefault().POrderFTime,
                             POrderMSuggest = g.FirstOrDefault().POrderMSuggest,
                             POrderMTime = g.FirstOrDefault().POrderMTime,
                             POrderQSuggest = g.FirstOrDefault().POrderQSuggest,
                             POrderQTime = g.FirstOrDefault().POrderQTime,
                             POrderReturnDocumentNumber = g.FirstOrDefault().POrderReturnDocumentNumber,
                             POrderReturnTotalMoney = g.Sum(r => r.POrderReturnTotalMoney),
                             POrderReturnTotalNum = g.Sum(r => r.POrderReturnTotalNum),
                             POrderTotalMoney = g.Sum(r => r.POrderTotalMoney),
                             POrderTotalNum = g.Sum(r => r.POrderTotalNum),
                             QualityChecker = g.FirstOrDefault().QualityChecker,
                             QualityStatus = g.FirstOrDefault().QualityStatus,
                             SupplyUnitName = g.FirstOrDefault().SupplyUnitName,
                         };

                this.dataGridView1.DataSource = new BindingCollection<Business.Models.PurchaseOrderReturnModel>(re.ToList());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private Business.Models.PurchaseOrderReturnQueryModel InitPurchaseOrderReturnSearchInput()
        {
            Business.Models.PurchaseOrderReturnQueryModel scsi = new PurchaseOrderReturnQueryModel();
            scsi.dtF = dtFrom.Value.Date;
            scsi.dtT = dtTo.Value.AddDays(1).Date;
            scsi.Keyword = this.txtCode.Text.Trim();
            scsi.DrugName = this.drugTxt.Text.Trim();
            scsi.SupplyUnitName = this.textBox1.Text.ToString();

            if (this.cmbOperator.SelectedValue != null)
                scsi.CreaterID = (Guid)cmbOperator.SelectedValue;
            else
                scsi.CreaterID = Guid.Empty;
            return scsi;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.GetListPurchaseOrderReturn();
            this.HideColumn();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
            cms.Show(MousePosition.X, MousePosition.Y);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (this.dataGridView1.Columns[e.ColumnIndex].Name != this.Column1.Name) return;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "配送入库退货单查询结果");
        }
    }
}
