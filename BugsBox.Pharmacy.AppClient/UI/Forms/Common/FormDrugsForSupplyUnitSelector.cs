using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{

    public partial class FormDrugsForSupplyUnitSelector : BaseFunctionForm
    {
        public Common.GoodsTypeClass GoogsTypeClass { get; set; }

        private Guid _supplyUnitGuid;

        private string msg = string.Empty;

        private List<DrugInfo> _listDrugInfo = new List<DrugInfo>();
        public DrugInfo DrugSelected = new DrugInfo();
        public List<DrugInfo> dinfos = new List<DrugInfo>();

        public event DrugSelectedEventHandler OnDrugSelected;
        /// <summary>
        /// 药品选择构造
        /// </summary>
        /// <param name="_purchaseUnitGuid">采购商guid</param>
        public FormDrugsForSupplyUnitSelector(Guid supplyUnitGuid)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            _supplyUnitGuid = supplyUnitGuid;
            this.dataGridView1.RowPostPaint += delegate (object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };

            this.dataGridView1.CellMouseDoubleClick += (s, e) =>
            {
                if (OnDrugSelected != null)
                {
                    Guid drugId = Guid.Parse(this.dataGridView1.CurrentRow.Cells[5].Value.ToString());
                    var selectedOne = this._listDrugInfo.FirstOrDefault(r => r.Id == drugId);
                    this.dinfos.Clear();
                    this.dinfos.Add(selectedOne);
                    OnDrugSelected(this.dinfos);
                    this.txtBWM.SelectAll();
                }
            };
        }

        private void getData()
        {
            try
            {
                _listDrugInfo = this.PharmacyDatabaseService.GetDrugInfoForSupplyUnitWithQueryParas(out msg, _supplyUnitGuid, txtTYM.Text.Trim(), txtCode.Text.Trim(), txtBWM.Text.Trim()).ToList();

                if (_listDrugInfo != null)
                {
                    #region 品种类型过滤
                    if (this.GoogsTypeClass == GoodsTypeClass.医疗器械)
                        this._listDrugInfo = this._listDrugInfo.Where(r => r.BusinessScopeCode.Contains(Common.GoodsTypeClass.医疗器械.ToString())).ToList();
                    if (this.GoogsTypeClass == GoodsTypeClass.药品)
                        this._listDrugInfo = this._listDrugInfo.Where(r => !r.BusinessScopeCode.Contains(Common.GoodsTypeClass.医疗器械.ToString())).ToList();
                    #endregion

                    var rows = _listDrugInfo.OrderBy(p => p.ProductName).Select(p => new
                    {
                        selected = false,
                        ProductGeneralName = p.ProductGeneralName,
                        ProductName = p.ProductName,
                        Code = p.Code,
                        StandardCode = p.StandardCode,
                        Id = p.Id,
                        factoryName = p.FactoryName,
                        dosage = p.DictionaryDosageCode,
                        specific = p.DictionarySpecificationCode
                    });

                    dataGridView1.DataSource = rows.ToList();
                }
                else
                {
                    MessageBox.Show("没有可以销售的药品，请查询品种基础信息和该供货商经营资质！");
                }
                if (!string.IsNullOrWhiteSpace(msg))
                {
                    MessageBox.Show(msg);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow == null) return;
            dinfos.Clear();

            List<DataGridViewRow> listRows = new List<DataGridViewRow>();
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell cb = dr.Cells[0] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(cb.FormattedValue))
                {
                    dinfos.Add(_listDrugInfo.Find(r => r.Id == Guid.Parse(dr.Cells[5].Value.ToString())));
                    listRows.Add(dr);
                }

            }
            if (this.OnDrugSelected != null)
            {
                OnDrugSelected(this.dinfos);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void FormDrugsForSupplyUnitSelector_Activated(object sender, EventArgs e)
        {
            this.txtBWM.Focus();
        }

        private void txtBWM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.getData();
            }
        }
    }

    public delegate void DrugSelectedEventHandler(List<DrugInfo> arg);



}
