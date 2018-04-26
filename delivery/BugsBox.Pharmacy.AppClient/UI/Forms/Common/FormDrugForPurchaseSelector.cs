﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    public partial class FormDrugForPurchaseSelector : BaseFunctionForm
    {

        public Dictionary<Guid, DrugInfo> ListDrugsSelected = new Dictionary<Guid, DrugInfo>();
        private List<DrugInfo> _listDrugsRecords = new List<DrugInfo>();
        private List<LackDrugModel> _listLackDrugRecords=new List<LackDrugModel>();

        public FormDrugForPurchaseSelector()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            Search();
        }

        public FormDrugForPurchaseSelector(string type):this()
        {
            //InitializeComponent();
            BindComboBoxWarehouseZones();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void btnQueryLack_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnQueryAll_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            try
            {
                string msg = string.Empty;
                Guid[] warehouseZonesIds = new Guid[] { };
                if (this.cmbWareHouse.SelectedIndex != -1)
                {
                    warehouseZonesIds = new Guid[] { Guid.Parse(cmbWareHouse.SelectedValue.ToString()) };
                }

                if (this.txtGeneralName.Text != "")
                    _listLackDrugRecords = _listLackDrugRecords.Where(p => p.pinyin != null && p.pinyin.ToUpper().Contains(this.txtGeneralName.Text.Trim().ToUpper())).ToList();
                else
                    _listLackDrugRecords = PharmacyDatabaseService.GetDrugInfoForOutofStock(
   out msg).OrderBy(r => r.ProductGeneralName).ToList();

                if (this.cmbWareHouse.SelectedIndex != -1)
                {
                    _listLackDrugRecords = _listLackDrugRecords.Where(w => w.wareHouse.Equals(cmbWareHouse.Text)).ToList();
                }

                dataGridView1.DataSource = new BindingCollection<LackDrugModel>(_listLackDrugRecords);
                this.label1.Text = "当前缺货品种共计：" + _listLackDrugRecords.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("缺货查询失败，请联系管理员！");
            }
        }

        private void txtGeneralName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.btnQueryLack_Click(this, new EventArgs());
            }
        }

        private void toolStripbtnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void toolStripbtnOutput_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "库存缺货单");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                _listLackDrugRecords.GroupBy(c => c.ProductGeneralName).Select(c => new LackDrugModel
                {
                    BusinessScopeCode = c.FirstOrDefault().BusinessScopeCode,
                    Code = c.FirstOrDefault().Code,
                    DictionaryDosageCode = c.FirstOrDefault().DictionaryDosageCode,
                    DictionaryMeasurementUnitCode = c.FirstOrDefault().DictionaryMeasurementUnitCode,
                    DictionarySpecificationCode = c.FirstOrDefault().DictionarySpecificationCode,
                    FactoryName = c.FirstOrDefault().FactoryName,
                    MinInventoryCount = c.FirstOrDefault().MinInventoryCount,
                    pinyin = c.FirstOrDefault().pinyin,
                    LicensePermissionNumber = c.FirstOrDefault().LicensePermissionNumber,
                    ProductGeneralName =c.Key,
                    ProductName = c.FirstOrDefault().ProductName,
                    StandardCode = c.FirstOrDefault().StandardCode,
                    CurrentCanSaleCount = c.Sum(t => t.CurrentCanSaleCount),
                    CurrentInventoryCount = c.Sum(t => t.CurrentInventoryCount),
                    PurchasePrice = c.FirstOrDefault().PurchasePrice,
                    dtime = c.FirstOrDefault().dtime,
                    wareHouse=c.FirstOrDefault().wareHouse
                });
                this.dataGridView1.DataSource = new BindingCollection<LackDrugModel>(_listLackDrugRecords);
            }
        }

        private void BindComboBoxWarehouseZones()
        {
            string msg = string.Empty;
            Warehouse[] listWarehouseZone = PharmacyDatabaseService.AllWarehouses(out msg).OrderBy(o=>o.Name).ToArray();
            this.cmbWareHouse.DataSource = listWarehouseZone;
            this.cmbWareHouse.DisplayMember = "Name";
            this.cmbWareHouse.ValueMember = "Id";
            this.cmbWareHouse.SelectedIndex = 0;
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0) return;
            if(button1.Text=="全部选择")
                foreach (DataGridViewRow dgvr in this.dataGridView1.Rows)
                {
                    dgvr.Cells[0].Value = true;
                    button1.Text = "取消全选";
                }
            else
                foreach (DataGridViewRow dgvr in this.dataGridView1.Rows)
                {
                    dgvr.Cells[0].Value = false;
                    button1.Text = "全部选择";
                }
        }
    }
}
