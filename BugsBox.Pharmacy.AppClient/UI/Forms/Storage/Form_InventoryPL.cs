using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.AppClient.Common.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Storage
{
    public partial class Form_InventoryPL : BaseFunctionForm
    {
        string msg = string.Empty;
        public Form_InventoryPL()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void Form_InventoryPL_Activated(object sender, EventArgs e)
        {
            var c = from i in this.PharmacyDatabaseService.GetDrugInventoryRecordPL(string.Empty, 1, out msg)
                    select new
                    {
                        id = i.Id,
                        productgeneralname = i.DrugInfo.ProductGeneralName,
                        DictionarySpecificationCode = i.DrugInfo.DictionarySpecificationCode,
                        DictionaryDosageCode = i.DrugInfo.DictionaryDosageCode,
                        BatchNumber = i.BatchNumber,
                        factoryname = i.DrugInfo.FactoryName,
                        cansalenum = i.CanSaleNum,
                        DismantingAmount = i.DismantingAmount,
                        afterPL = i.CanSaleNum + i.DismantingAmount
                    };
            this.dataGridView1.DataSource = c.OrderBy(r => r.DictionaryDosageCode).ThenBy(r => r.productgeneralname).ToList();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "EXCEL电子表格|*.xls";
            sfd.InitialDirectory = "c:\\";
            sfd.FileName = "库存药品损溢单" + DateTime.Now.Ticks.ToString();
            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            string fileName = sfd.FileName;

            DataTable dt = new DataTable("库存药品损溢单");
            List<DataColumn> ldc = new List<DataColumn>();
            foreach (DataGridViewColumn dc in this.dataGridView1.Columns)
            {
                if (dc.Index == 0) continue;
                ldc.Add(new DataColumn((dc.HeaderText), typeof(string)));
            }
            dt.Columns.AddRange(ldc.ToArray());

            foreach (DataGridViewRow dgvr in this.dataGridView1.Rows)
            {
                DataRow dr = dt.NewRow();
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    dr[i - 1] = dgvr.Cells[i].Value == null ? string.Empty : dgvr.Cells[i].Value.ToString();
                }
                dt.Rows.Add(dr);
            }

            if (MyExcelUtls.DataTable2Sheet(fileName, dt))
            {
                MessageBox.Show("创建成功！");
            }
            else
            {
                MessageBox.Show("创建失败,请联系管理员！");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (this.dataGridView1.CurrentCell.OwningColumn.Name == this.Column6.Name)
            {
                if (MessageBox.Show("需要提交库存损溢调整吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
                Models.DrugInventoryRecord dir = this.PharmacyDatabaseService.GetDrugInventoryRecord(out msg, Guid.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                var m = Convert.ToDecimal(this.dataGridView1.CurrentRow.Cells[Column7.Name].Value);
                dir.InInventoryCount += m;
                dir.CanSaleNum += m;
                dir.CurrentInventoryCount += m;
                dir.Valid = true;
                dir.DismantingAmount = 0;
                if (this.PharmacyDatabaseService.SaveDrugInventoryRecord(out msg, dir))
                {


                    DrugInventoryRecordHisCmd cmd = new DrugInventoryRecordHisCmd
                    {
                        Diff = m,
                        DrugInventoryRecord = dir,
                        Operator = AppClientContext.CurrentUser.Account,
                        OperatorID = AppClientContext.CurrentUser.Id
                    };

                    cmd.Execute();

                    MessageBox.Show("库存调整成功！");
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                return;
            }

            if (this.dataGridView1.CurrentCell.OwningColumn.Name == this.Column8.Name)
            {
                if (MessageBox.Show("需要取消库存损溢调整吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
                Models.DrugInventoryRecord dir = this.PharmacyDatabaseService.GetDrugInventoryRecord(out msg, Guid.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()));

                dir.DismantingAmount = 0;
                dir.Valid = true;
                if (this.PharmacyDatabaseService.SaveDrugInventoryRecord(out msg, dir))
                {
                    MessageBox.Show("库存调整取消成功！");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    return;
                }
            }
        }
    }
}
