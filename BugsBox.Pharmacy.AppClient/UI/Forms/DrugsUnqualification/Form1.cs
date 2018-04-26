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
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugsUnqualification
{
    public partial class Form1 : BaseFunctionForm
    {
        List<InventeryModel> im = null;
        string msg = string.Empty;
        private string _py;
        public InventeryModel iml = null;
        public string py
        {
            get { return _py; }
            set { _py = value; this.toolStripTextBox1.Text = _py; }
        }
        public Form1(  )
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.toolStripComboBox1.SelectedIndex = 0;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text.Trim().Equals(string.Empty) && toolStripTextBox2.Text.Trim().Equals(string.Empty)) return;
            this.getData(toolStripTextBox1.Text.Trim(), toolStripTextBox2.Text.Trim());
        }

        private void getData(string py,string batch)
        {
            bool IsOutDate = this.toolStripComboBox1.SelectedIndex != 0;
            im = this.PharmacyDatabaseService.GetDrugsInventoryRecordToUnqualification(IsOutDate,py,batch,out msg).ToList();
            if (im == null)
            {
                MessageBox.Show("查询为空");
                return;
            }
            this.dataGridView1.DataSource = new BindingCollection<Business.Models.InventeryModel>(im);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            this.DialogResult = DialogResult.OK;
            int idx = e.RowIndex;
            iml = im[idx];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.getData(py, string.Empty);
        }
    }
}
