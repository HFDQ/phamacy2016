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
    public partial class Form_DrugInfoForPurchaseSelector : BaseFunctionForm
    {
        Guid _SupplyUnitId = Guid.Empty;
        PurchaseDrugTypes _PurchaseDrugTypes = PurchaseDrugTypes.药品;

        string msg = string.Empty;

        public event PurchaseOrderImptEventHandler OnPurchaseOrderImpt = null;

        public Form_DrugInfoForPurchaseSelector(Guid SupplyUnitId, PurchaseDrugTypes purchaseDrugType)
        {
            InitializeComponent();
            this._PurchaseDrugTypes = purchaseDrugType;
            this._SupplyUnitId = SupplyUnitId;
            
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.RowPostPaint += (s, e) => DataGridViewOperator.SetRowNumber(this.dataGridView1, e);
            this.dataGridView1.CellDoubleClick += (s, e) => this.Sub();
            this.dataGridView1.AllowUserToOrderColumns = true;

            this.button1.Click += (s, e) => this.getData();
            this.Activated+=(s,e)=> this.textBox1.Focus();
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void getData()
        {
            string keyword = this.textBox1.Text.Trim();
            string factoryName = this.textBox2.Text.Trim();
            if (string.IsNullOrEmpty(keyword) && string.IsNullOrEmpty(factoryName))
            {
                MessageBox.Show("查询的时候，关键字或生产厂家必须得填一个！");
                return;
            }
            Business.Models.DrugInfoForPurchaseSelectorQueryModel q = new Business.Models.DrugInfoForPurchaseSelectorQueryModel
            {
                Keyword = keyword,
                SupplyUnitId = this._SupplyUnitId,
                FactoryName = factoryName
            };

            var re = this.PharmacyDatabaseService.GetDrugInfoForpurchaseSelector(q, out msg).ToList();

            this.dataGridView1.DataSource = re;
            this.dataGridView1.Columns["DrugInfoId"].Visible = false;
            
            if (re.Count > 0)
            {
                this.dataGridView1.Focus();
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[0].Cells[1];
            }
           
        }

        /// <summary>
        /// 提交
        /// </summary>
        public void Sub()
        {
            var c = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.DrugInfoForPurchaseSelectorModel;

            if (this.OnPurchaseOrderImpt != null)
            {
                List<Business.Models.PurchaseOrderImpt> row = new List<Business.Models.PurchaseOrderImpt>();
                row.Add(new Business.Models.PurchaseOrderImpt
                {
                    DosageName = c.DosageName,
                    DrugInfoId = c.DrugInfoId,
                    FactoryName = c.FactoryName,
                    MeasurementName = c.MeasurementName,
                    Origin = c.Origin,
                    ProductGeneralName = c.ProductGeneralName,
                    SpecificName = c.SpecificName,
                    TaxRate = 17
                });

                PurchaseOrderImptEventArgs e = new PurchaseOrderImptEventArgs
                {
                    ImptList = row
                };
                this.OnPurchaseOrderImpt(e);

                this.textBox1.Focus();
                this.textBox1.Select(0, this.textBox1.Text.Length);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space && this.dataGridView1.CurrentRow != null)
            {
                this.Sub();
                return true;
            }

            if (keyData == Keys.Return )
            {
                this.getData();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
