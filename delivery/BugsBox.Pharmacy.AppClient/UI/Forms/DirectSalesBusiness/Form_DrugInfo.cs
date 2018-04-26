using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DirectSalesBusiness
{
    public partial class Form_DrugInfo : BaseFunctionForm
    {
        string message = string.Empty;
        public Models.DrugInfo _DI = null;
        private Business.Models.DirectSalesQueryModel _DruginfoModel;
        public Form_DrugInfo(Business.Models.DirectSalesQueryModel qm)
        {
            InitializeComponent();
            this.toolStripTextBox1.Text = qm.Keyword;
            this.toolStripTextBox1.Focus();
            this._DruginfoModel = qm;

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;

            if (!string.IsNullOrEmpty(qm.Keyword))
            {
                this.Search(false);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this._DI = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Models.DrugInfo;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Return)
            {
                this.Search(false);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void 模糊查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Search(false);
        }

        private void 精确查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Search(true);
        }

        private void Search(bool IsAccurate)
        {
            this._DruginfoModel.Keyword = this.toolStripTextBox1.Text.Trim();
            var c = this.PharmacyDatabaseService.GetDrugInfoByKeyword(this._DruginfoModel,out message).ToList();
            if (c.Count <= 0)
            {
                MessageBox.Show("无查询结果");
            }
            this.dataGridView1.DataSource = new BindingCollection<Models.DrugInfo>(c);    
        }
    }
}
