using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Business.Models.QueryModelExtesion;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.UI.Common.Helper;
 

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugBusiness
{
    public partial class FormDoubtDrugManage : BaseFunctionForm
    {
        string msg = string.Empty;

        public FormDoubtDrugManage()
        {
            InitializeComponent();
            this.BindComboBoxWarehouseZones();
            this.dataGridView1.AutoGenerateColumns = false;
        }
        private void BindComboBoxWarehouseZones()
        {
            string msg = string.Empty;
            WarehouseZone[] listWarehouseZone = PharmacyDatabaseService.AllWarehouseZones(out msg);
            this.comboBox1.DataSource = listWarehouseZone;
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.SelectedIndex = 0;
        }
        private void Search()
        {
            try
            {
                Guid[] warehouseZonesIds = new Guid[] { };
                if (this.comboBox1.SelectedIndex != -1)
                {
                    warehouseZonesIds = new Guid[] { Guid.Parse(comboBox1.SelectedValue.ToString()) };
                }
                string msg = String.Empty;

                bool combine = false;
                bool valid = this.checkBox1.Checked;
                var storage = PharmacyDatabaseService.StorageQuery(out msg, this.textBox1.Text.Trim(), string.Empty, this.textBox3.Text.Trim(), warehouseZonesIds, this.pagerControl1.PageIndex, this.pagerControl1.PageSize, new object[] { combine, valid }).ToList();
                if (storage == null)
                {
                    MessageBox.Show("查询结果为空！");
                    return;
                }
                if (storage.Count > 0)
                {
                    this.pagerControl1.RecordCount = storage[0].RecordCount;
                }
                else
                {
                    this.pagerControl1.RecordCount = 0;
                }
                foreach (var c in storage)
                {
                    c.isValid = !c.isValid;
                }

                this.dataGridView1.DataSource = storage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误,请联系管理员"+ex.Message,"错误" , MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }
        private void pagerControl1_DataPaging()
        {
            Search();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("需要修改该药品锁定状态吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) return;
                var Row = dataGridView1.Rows[e.RowIndex];
                Guid id = Guid.Parse(Row.Cells[0].Value.ToString());
                DrugInventoryRecord dir = this.PharmacyDatabaseService.GetDrugInventoryRecord(out msg, id);
                if (dir == null) return;
                bool isLock = Convert.ToBoolean(Row.Cells[1].EditedFormattedValue);
                dir.Valid = !isLock;
                if (this.PharmacyDatabaseService.SaveDrugInventoryRecord(out msg, dir))
                {
                    string isLockStr = !isLock ? "解锁" : "锁定";
                    string prompt = Row.Cells[2].Value.ToString() + "药品，批次号为：" + dir.BatchNumber + ",被" + isLockStr;
                    MessageBox.Show(prompt+"\n设置成功！");
                }
                else
                {
                    MessageBox.Show("设置失败！");
                    Row.Cells[1].Value = !isLock;
                }
            }
        }
    }
}
