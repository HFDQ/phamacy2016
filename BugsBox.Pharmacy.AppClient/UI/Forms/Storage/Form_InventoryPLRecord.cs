using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.AppClient.Common.Commands;
using BugsBox.Pharmacy.Business.Models;
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
    public partial class Form_InventoryPLRecord : BaseFunctionForm
    {
        string msg = string.Empty;
        public Form_InventoryPLRecord()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            dateTimePicker1.Value = DateTime.Now.AddDays(-7);

            GetDrugInventoryRecordHisCmd cmd = new GetDrugInventoryRecordHisCmd
            {
                BeginDate = dateTimePicker1.Value,
                EndDate = dateTimePicker2.Value,
                Keyword = textBox1.Text
            };

            var arr = (InventeryChangeModel[])cmd.Execute();

            this.dataGridView1.DataSource = arr;

        }

        private void Form_InventoryPL_Activated(object sender, EventArgs e)
        {


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "EXCEL电子表格|*.xls";
            sfd.InitialDirectory = "c:\\";
            sfd.FileName = "库存药品损溢记录单" + DateTime.Now.Ticks.ToString();
            if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            string fileName = sfd.FileName;

            DataTable dt = new DataTable("库存药品损溢记录单");
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

        }
    }
}
