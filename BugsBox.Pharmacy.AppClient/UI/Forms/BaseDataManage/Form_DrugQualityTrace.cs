using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class Form_DrugQualityTrace : BaseFunctionForm
    {
        string msg = string.Empty;
        bool IsEmpty = false;
        public Form_DrugQualityTrace()
        {
            InitializeComponent();
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
        }

        public Form_DrugQualityTrace(Guid DrugInfoId,string DrugName):this()
        {
            if (DrugInfoId == null) return;
            this.toolStripLabel1.Text = DrugName;

            var c = this.PharmacyDatabaseService.GetAllDrugUnqualityTrace(DrugInfoId, out msg);
            
            if (c==null)
            {
                MessageBox.Show("无不合格现象,查询列表为空！");
                this.IsEmpty = true;
                this.toolStripButton1.Enabled = false;
                return;
            }

            this.dataGridView1.DataSource =new BindingCollection<Business.Models.DrugQualityTraceModel>( c.OrderBy(r => r.InInventoryDate).ToList());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, this.toolStripLabel1.Text);
        }
    }
}
