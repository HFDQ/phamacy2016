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
    public partial class Form_SupplyUnits : BaseFunctionForm
    {
        string message = string.Empty;
        public Models.SupplyUnit _SU = null;
        public Form_SupplyUnits(string Keyword)
        {
            InitializeComponent();
            this.toolStripTextBox1.Text = Keyword;
            this.toolStripTextBox1.Focus();

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;

            if (!string.IsNullOrEmpty(Keyword))
            {
                this.Search(false);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _SU = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as Models.SupplyUnit;
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
            var c = this.PharmacyDatabaseService.GetSupplyUnitsByKeywords(this.toolStripTextBox1.Text.Trim(), IsAccurate, out message).ToList();
            if (c.Count <= 0)
            {
                MessageBox.Show("无查询结果");
            }
            this.dataGridView1.DataSource = new BindingCollection<Models.SupplyUnit>(c);            
        }
    }
}
