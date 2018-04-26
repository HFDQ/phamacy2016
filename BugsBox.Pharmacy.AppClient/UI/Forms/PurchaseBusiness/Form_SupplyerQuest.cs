using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class Form_SupplyerQuest : BaseFunctionForm
    {
        string msg = string.Empty;
        string _keyword = string.Empty;
        public event SupplyUnitSelectedEventHandler OnSupplyUnitSelect;
        public Form_SupplyerQuest(string keyword)
        {
            InitializeComponent();
            this._keyword = keyword;
            this.toolStripTextBox1.Text = keyword;

            this.dataGridView1.RowPostPaint += (s, e) => DataGridViewOperator.SetRowNumber(this.dataGridView1, e);
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ReadOnly = true;

            this.getData();


            this.toolStripButton1.Click += (s, e) => getData();
            this.dataGridView1.CellDoubleClick += (s, e) => this.onSelectSupplyUnit();
        }
        private void getData()
        {
            string kw = this.toolStripTextBox1.Text.Trim();
            Business.Models.BaseQueryModel q = new Business.Models.BaseQueryModel { Keyword = kw };
            var allSupplyUnits = this.PharmacyDatabaseService.GetSuplyUnitIdNamesByQueryModel(q, out msg).ToList();

            this.dataGridView1.DataSource = allSupplyUnits;

            this.dataGridView1.Columns["Id"].Visible = false;
            this.dataGridView1.Columns["PinYin"].Visible = false;
            this.dataGridView1.Columns["IsValid"].Visible = false;

            if (allSupplyUnits.Count>0)
                this.dataGridView1.Focus();
        }

        private void onSelectSupplyUnit()
        {
            if (this.dataGridView1.CurrentRow == null) return;
            Business.Models.Model_IdName m = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.Model_IdName;

            if (m.IsValid == false)
            {
                MessageBox.Show("对不起，您选择的供货单位已经失效了，失效原因可能是资质过期，或者人工锁定等，请通知质管部检查该单位资质信息！");
                return;
            }
            if (this.OnSupplyUnitSelect != null)
            {
                this.OnSupplyUnitSelect(m);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Return)
            {
                if (this.dataGridView1.Focused)
                {
                    toolStripTextBox1.Focus();return true;
                }
                getData();
                return true;
            }

            if (keyData == Keys.Space)
            {
                this.onSelectSupplyUnit();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }

    public delegate void SupplyUnitSelectedEventHandler(Business.Models.Model_IdName m);


}
