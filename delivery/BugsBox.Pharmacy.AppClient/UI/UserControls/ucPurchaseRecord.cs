using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.UI.Common;

namespace BugsBox.Pharmacy.AppClient.UI.UserControls
{
    public partial class ucPurchaseRecord : BaseFunctionUserControl
    {
        private string msg = String.Empty;
        List<SupplyUnit> listSupplyer = new List<SupplyUnit>();

        public ucPurchaseRecord()
        {
            InitializeComponent();
            dtpFrom.Value = DateTime.Now.AddDays(-3);
            dtpTo.Value = DateTime.Now;
            BindComboBoxSupply();
            var all = PharmacyDatabaseService.AllSupplyUnits(out msg);
            listSupplyer = all.Where(r => r.Valid).ToList();
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void cmbSupply_Click(object sender, EventArgs e)
        {
         
        }
        private void BindComboBoxSupply()
        {
            string msg = string.Empty;
            SupplyUnit[] listSupply = PharmacyDatabaseService.AllSupplyUnits(out msg);
            this.cmbSupply.DataSource = listSupply;
            this.cmbSupply.DisplayMember = "Name";
            this.cmbSupply.ValueMember = "Id";
            this.cmbSupply.SelectedIndex = -1;
        }

        //绑定数据源
        private void BindDataSource()
        {
            try
            {
                DateTime startTime = dtpFrom.Value;
                DateTime endTime = dtpTo.Value;

                string drugName = txtDrugName.Text.Trim();
                drugName += "|&|" + textBox1.Text.Trim();
                drugName += "|&|" + textBox2.Text.Trim();
                drugName += "|&|" + textBox3.Text.Trim();


                Guid[] supplyIds = new Guid[] { };
                Object data = new Object();
                if (cmbSupply.SelectedIndex != -1)
                {
                    supplyIds = new Guid[] { new Guid(cmbSupply.SelectedValue.ToString()) };
                }
                if ((int)GridPurchaseRecordType < 4)
                {
                    List<PurchaseRecord> purchaseRecord = this.PharmacyDatabaseService.GetPurchaseRecords(out msg, (int)GridPurchaseRecordType, drugName, startTime, endTime, supplyIds, this.pagerControl1.PageIndex, this.pagerControl1.PageSize).ToList();
                    if (purchaseRecord.Count > 0)
                    {
                        this.pagerControl1.RecordCount = purchaseRecord[0].RecordCount;
                    }
                    else
                    {
                        this.pagerControl1.RecordCount = 0;
                    }
                    data = purchaseRecord;
                }
                else
                {
                    List<Business.Models.PurchaseRCRecord> purchaseRCRecord = this.PharmacyDatabaseService.GetPurchaseRCRecords(out msg, (int)GridPurchaseRecordType, drugName, startTime, endTime, supplyIds, this.pagerControl1.PageIndex, this.pagerControl1.PageSize).ToList();
                    if (purchaseRCRecord.Count > 0)
                    {
                        this.pagerControl1.RecordCount = purchaseRCRecord[0].RecordCount;
                    }
                    else
                    {
                        this.pagerControl1.RecordCount = 0;
                    }
                    purchaseRCRecord.ForEach(r => r.OutValidDateStr = r.OutValidDate.Year == 2050 ? "无" : r.OutValidDate.ToLongDateString());

                    data = purchaseRCRecord;
                }
                if (!string.IsNullOrEmpty(msg))
                {
                    MessageBox.Show(msg);
                    return;
                }
               
                

                this.dataGridView1.DataSource = data;
                HiddenFields();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private PurchaseRecordType _PurchaseRecordType = PurchaseRecordType.CGJL;
        [Browsable(true), Description("DataGridView 数据源类型"), Category("自定义")]
        
        public PurchaseRecordType GridPurchaseRecordType
        {
            get
            {
                return _PurchaseRecordType;
            }
            set
            {
                _PurchaseRecordType = value;
                BindDataSource();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            BindDataSource();
        }
        private void pagerControl1_DataPaging()
        {
            Search();
        }
        private void HiddenFields()
        {
            HiddenField("DrugInfoId");
            HiddenField("RecordCount");
            HiddenField("SpecialChecker");
            HiddenField("SpecialCheckMemo");
            HiddenField("OutValidDate");
            
            switch (GridPurchaseRecordType)
            {
                case PurchaseRecordType.YLQXCGJL:
                    HiddenField("Origin");
                    HiddenField("BatchNumber");
                    HiddenField("ReceiveAddress");
                    HiddenField("ShippingTime");
                    this.dataGridView1.Columns["LicensePermissionNumber"].HeaderText = "注册证或备案凭证编号";
                    break;
                case PurchaseRecordType.YLQXYSJL:
                    HiddenField("Decription");
                    this.dataGridView1.Columns["LicensePermissionNumber"].HeaderText = "注册证或备案凭证编号";
                    break;
                //采购记录
                case PurchaseRecordType.CGJL:
                    //HiddenField("Origin");
                    HiddenField("BatchNumber");
                    //HiddenField("FactoryName");
                    HiddenField("ReceiveAddress");
                    HiddenField("ShippingTime");
                    break;
                //中药材采购记录
                case PurchaseRecordType.ZYCCGJL:
                    HiddenField("ReceiveUnit");
                    HiddenField("BatchNumber");
                    HiddenField("FactoryName");
                    HiddenField("ReceiveAddress");
                    HiddenField("ShippingTime");
                    HiddenField("DictionaryDosageCode");
                    break;
                //中药饮片采购记录
                case PurchaseRecordType.ZYYPCGJL:
                    HiddenField("ReceiveUnit");
                    HiddenField("BatchNumber");
                    //HiddenField("FactoryName");
                    HiddenField("ReceiveAddress");
                    HiddenField("ShippingTime");
                    HiddenField("DictionaryDosageCode");
                    break;
                //随货同行单(票)
                case PurchaseRecordType.SHTXD:
                    HiddenField("Price");
                    HiddenField("Origin");
                    break;
                //收货记录
                case PurchaseRecordType.SHJL:
                    HiddenField("PruductDate");
                    HiddenField("OutValidDate");
                    HiddenField("QualifiedAmount");
                    HiddenField("CheckResult");
                    HiddenField("CheckMan");
                    HiddenField("CheckDate");
                    HiddenField("BatchNumber");
                    break;
                //拒收记录
                case PurchaseRecordType.JSJL:
                    HiddenField("PruductDate");
                    HiddenField("OutValidDate");
                    HiddenField("QualifiedAmount");
                    HiddenField("CheckResult");
                    HiddenField("CheckMan");
                    HiddenField("CheckDate");
                    HiddenField("BatchNumber");
                    break;
                //中药材验收记录
                case PurchaseRecordType.ZYCYSJL:
                    HiddenField("DictionaryDosageCode");
                    if (this.dataGridView1.Columns["SpecialChecker"] != null)
                        this.dataGridView1.Columns["SpecialChecker"].Visible = true;
                    if (this.dataGridView1.Columns["SpecialCheckMemo"] != null)
                        this.dataGridView1.Columns["SpecialCheckMemo"].Visible = true;
                    break;
                //中药饮片验收记录
                case PurchaseRecordType.ZYYPYSJL:
                    HiddenField("DictionaryDosageCode");
                    if (this.dataGridView1.Columns["SpecialChecker"] != null)
                        this.dataGridView1.Columns["SpecialChecker"].Visible = true;
                    if (this.dataGridView1.Columns["SpecialCheckMemo"] != null)
                        this.dataGridView1.Columns["SpecialCheckMemo"].Visible = true;
                    break;
                case PurchaseRecordType.YSJL:
                    if (this.dataGridView1.Columns["SpecialChecker"] != null)
                        this.dataGridView1.Columns["SpecialChecker"].Visible = true;
                    if (this.dataGridView1.Columns["SpecialCheckMemo"] != null)
                        this.dataGridView1.Columns["SpecialCheckMemo"].Visible = true;
                    break;
                
            }
        }
        private void HiddenField(string fieldName)
        {

            if (this.dataGridView1.Columns[fieldName] != null)
                this.dataGridView1.Columns[fieldName].Visible = false;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = this.dataGridView1.Columns[e.ColumnIndex].Name;
            if (columnName == "ShippingTime")
            {
                if ((DateTime)e.Value == DateTime.MaxValue)
                    e.Value = "";
            }
            else if (columnName == "CheckResult")
            {
                if ((int)e.Value == 0)
                {
                    e.Value = "合格";
                }
                else
                {
                    e.Value = "不合格";
                }
            }
        }

        private void txtBoxPinyin_TextChanged(object sender, EventArgs e)
        {
            if (this.txtBoxPinyin.Text.Trim().Equals(string.Empty)) return;
            string str = this.txtBoxPinyin.Text.Trim().ToUpper();
            var q = listSupplyer.Where(r => r.PinyinCode.ToUpper().Contains(str)).ToList();
            if (q == null) return;
            if (q.Count <= 0) return;
            this.cmbSupply.DataSource = q;
            this.cmbSupply.ValueMember = "id";
            this.cmbSupply.DisplayMember = "name";
            this.cmbSupply.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmbSupply.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmbSupply.SelectedIndex = 0;
        }

        private void txtBoxPinyin_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbSupply.Text.Trim() == string.Empty) return;
            if (e.KeyCode == Keys.Return)
            {
                Search();
            }
        }

        private void txtDrugName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Search();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Search();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Search();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Search();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UI.Forms.MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "采购记录查询");
        }
    }
}
