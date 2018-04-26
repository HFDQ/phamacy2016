using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class Form_SaleTaxStatics :BaseFunctionForm
    {
        public List<object> sList { get; set; }
        public List<object> pList { get; set; }
        public int type { get; set; }
        public decimal result { get; set; }

        public Form_SaleTaxStatics(DateTime dtF,DateTime dtT)
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.toolStripLabel2.Text = dtF.ToLongDateString() + " 至 " + dtT.ToLongDateString();
            this.toolStripComboBox1.SelectedIndex = 0;
        }

        private void bindData( int type)
        {
            this.dataGridView1.Columns[this.Column10.Name].Visible = type==1? true:false;
            this.dataGridView1.Columns[this.Column1.Name].Visible =type==1? false:true;
            this.Text = type == 1 ? "管理、税票费费统计(按购货商统计)" : "管理、税票费费统计(按销售员统计)";
            this.dataGridView1.DataSource =type==1?pList: sList;
            this.toolStripComboBox1.SelectedIndex = type;
            
            this.toolStripStatusLabel1.Text = "应收款汇总结果："+result;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form_SaleTaxStatics_Load(object sender, EventArgs e)
        {
            this.bindData(type);
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = this.toolStripComboBox1.SelectedIndex;
            this.bindData(type);
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1,"销售管理、税票费统计情况");
        }
    }
}
