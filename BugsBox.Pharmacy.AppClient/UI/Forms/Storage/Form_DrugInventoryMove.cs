using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;


namespace BugsBox.Pharmacy.AppClient.UI.Forms.Storage
{
    public partial class Form_DrugInventoryMove :BaseFunctionForm
    {
        string msg = string.Empty;
        [Browsable(true), Description("DataGridView 数据源类型"), Category("自定义")]
        public Form_DrugInventoryMove()
        {
            InitializeComponent();
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            this.comboBox1.SelectedIndex = 0;
            this.search();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.search();
        }

        private void search()
        {
            Models.DrugsInventoryMove dm = new DrugsInventoryMove();
            dm.createTime = this.dateTimePicker1.Value.AddHours(-DateTime.Now.Hour);
            dm.updateTime = this.dateTimePicker2.Value.AddDays(1).AddHours(-DateTime.Now.Hour);
            dm.ApprovalStatusValue = this.comboBox1.SelectedIndex == 3 ? 4 : this.comboBox1.SelectedIndex;
            var c = this.PharmacyDatabaseService.GetMoveRecords(dm, out msg).OrderBy(r=>r.CreateTime).ToList();
            
            int index = 0;
            foreach (var i in c)
            {
                index++;
                i.Index = index;
                i.StatusStr = i.Status == 1 ? "正在审批" : i.Status == 2 ? "审批通过" : i.Status == 4 ? "审批被拒" : "异常状态";
            }

            this.dataGridView1.DataSource = c;
            this.HideFields();
        }

        private void HideFields()
        {
            foreach (DataGridViewColumn dc in this.dataGridView1.Columns)
            {
                if (dc.Name == "Price" || dc.Name == "Status") this.dataGridView1.Columns[dc.Name].Visible = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.search();
        }
    }


}
