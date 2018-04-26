using BugsBox.Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugMaintainView
{
    public partial class DrugMaintainRecordPlan :BaseFunctionForm
    {
        public DrugMaintainRecordPlan()
        {
            InitializeComponent();
        }

        private void DrugMaintenanceRecord_Load(object sender, EventArgs e)
        {
            StartDate.Value = DateTime.Now.AddMonths(-1);
            EndDate.Value = DateTime.Now;


            dataGridView1.AutoGenerateColumns = false;
        }

        //保存
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        //查询
        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            LoadData();  
        }

        private void LoadData()
        {
            string msg;
           

            List<BugsBox.Pharmacy.Models.DrugMaintainRecord> item = PharmacyDatabaseService.GetDrugMaintainRecordByCondition(out msg, 
                StartDate.Value, EndDate.Value, 0, null).ToList();

            
            dataGridView1.DataSource = item;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DrugMaintainRecordPlanDetails detail = new DrugMaintainRecordPlanDetails();
                DrugMaintainRecordPlanDetails.BillDocumentNo = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                detail.ShowDialog();


                LoadData();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToInt16(e.Value) == 0)
                {
                    e.Value = "普通药品";
                }
                else if (Convert.ToInt16(e.Value) == 1)
                {
                    e.Value = "重点药品";
                }
            }
            else if (e.ColumnIndex == 2)
            {
                e.Value = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd");
            }
            else if (e.ColumnIndex == 3)
            {
                if (Convert.ToInt16(e.Value) == 0)
                {
                    e.Value = "未完成";
                }
                else
                {
                    e.Value = "已完成";
                }
            }
            else if (e.ColumnIndex == 4)
            {
                e.Value = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd");
            }
        }
         
    }
}
