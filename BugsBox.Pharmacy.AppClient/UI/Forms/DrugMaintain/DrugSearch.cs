using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugMaintain
{
    public partial class DrugSearch : BaseFunctionForm
    {
        public DrugSearch()
        {
            InitializeComponent();
        }

        //查询
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string msg;
             
            //药品库存信息
           List<DrugInventoryRecord> record = PharmacyDatabaseService.GetDrugInventoryRecordByCondition(out msg, txtName.Text.Trim(), txtBatchNumber.Text.Trim() ).ToList();
          

            dataGridView1.DataSource = record; 
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string Id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                AddSpecial.DrugInventoryId = Guid.Parse(Id);
                this.Close();
            }
        }

        private void DrugSearch_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
