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
    public delegate void PositionSelectedEventHandler(object sender,PositionEventArgs e);
    public partial class Form_WareHouseZonePositionSelector : BaseFunctionForm
    {
        string msg=string.Empty;
        public event PositionSelectedEventHandler PositionSelected;
        public Form_WareHouseZonePositionSelector(Guid drugInfoId)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;

            Models.DrugInfo d = this.PharmacyDatabaseService.GetDrugInfo(out msg,drugInfoId);

            #region combo数据绑定
            var w = this.PharmacyDatabaseService.AllWarehouses(out msg).Where(r => r.Deleted == false).OrderBy(r => r.Name).ToList();
            this.toolStripComboBox1.ComboBox.DisplayMember = "Name";
            this.toolStripComboBox1.ComboBox.ValueMember = "Id";
            this.toolStripComboBox1.ComboBox.DataSource = w;
            this.toolStripComboBox1.ComboBox.SelectedValue = d.WareHouses;

            var wz = this.PharmacyDatabaseService.AllWarehouseZones(out msg).Where(r => r.Deleted == false).OrderBy(r => r.Name);

            this.toolStripComboBox1.ComboBox.SelectedIndexChanged += (sender, ex) =>
            {
                var wzs = wz.Where(r => r.WarehouseId == (Guid)this.toolStripComboBox1.ComboBox.SelectedValue).ToList();
                this.toolStripComboBox2.ComboBox.DisplayMember = "Name";
                this.toolStripComboBox2.ComboBox.ValueMember = "Id";
                this.toolStripComboBox2.ComboBox.DataSource = wzs;
                if (wzs.Count <= 0) return;
                this.toolStripComboBox2.ComboBox.SelectedIndex = 0;

                this.GetWareHousePositions();
            };

            this.toolStripComboBox2.ComboBox.SelectedIndexChanged += (s, e) =>
            {
                this.GetWareHousePositions();
            };

            this.toolStripButton1.Click += (s, e) => this.GetWareHousePositions();

            this.toolStripComboBox2.ComboBox.DisplayMember = "Name";
            this.toolStripComboBox2.ComboBox.ValueMember = "Id";
            this.toolStripComboBox2.ComboBox.DataSource = wz.Where(r => r.WarehouseId == d.WareHouses).ToList();
            this.toolStripComboBox2.ComboBox.SelectedValue = Guid.Parse(d.WareHouseZones);

            
            #endregion

            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dataGridView1.ReadOnly = true;

            this.dataGridView1.Columns["Id"].Visible = false;
            this.dataGridView1.Columns["WareHouseId"].Visible = false;
            this.dataGridView1.Columns["WareHouseZoneId"].Visible = false;

            this.dataGridView1.CellDoubleClick += (sender, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                PositionEventArgs args = new PositionEventArgs
                {
                     PositionModel=(Business.Models.WareHouseZonePositionModel)this.dataGridView1.Rows[e.RowIndex].DataBoundItem
                };
                if (this.PositionSelected != null)
                {
                    this.PositionSelected(this, args);
                    this.Close();
                }
            };
        }

        private void GetWareHousePositions()
        {
            var result = this.PharmacyDatabaseService.GetWareHouseZonePositionById(new Business.Models.WareHouseZonePositionQueryModel
            {
                WareHouseId = (Guid)this.toolStripComboBox1.ComboBox.SelectedValue,
                WareHouseZoneId = (Guid)this.toolStripComboBox2.ComboBox.SelectedValue
            }, out msg).ToList();

            this.dataGridView1.DataSource = result;
        }
    }

    public class PositionEventArgs:EventArgs
    {
        public Business.Models.WareHouseZonePositionModel PositionModel { get; set; }
    }
}
