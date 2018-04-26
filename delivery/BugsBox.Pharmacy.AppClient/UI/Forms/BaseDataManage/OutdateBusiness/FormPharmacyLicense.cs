using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.Business.Models.QueryModelExtesion;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.OutdateBusiness
{
    public partial class FormPharmacyLicense : BaseFunctionForm
    {
        public FormPharmacyLicense()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.dataGridView.AutoGenerateColumns = false;
            InitData();
            InitContorls();
            LoadDataFromServer();
            BindDataList();

        }

        private void BindDataList()
        {
            this.dataGridView.DataSource = DataList;
        }
        private QueryPharmacyLicenseModel QueryPharmacyLicenseModel { get; set; }
        private List<PharmacyLicense> DataList { get; set; }
        private PharmacyLicense SelectedPharmacyLicense { get; set; }
        private List<ListItem> LicenseTypeItems { get; set; }
        private void InitData()
        {
            try
            {
                if (LicenseTypeItems != null && LicenseTypeItems.Count > 0) return;
                LicenseTypeItems = EnumHelper<LicenseType>.GetMapKeyValues();
                LicenseTypeItems.Insert(0, new ListItem { ID = "-1", Name = "所有" });

                //查询条件
                QueryPharmacyLicenseModel = new QueryPharmacyLicenseModel(); 
            }
            catch (Exception ex)
            {
                ex = new Exception("初始化数据失败", ex);
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+ex.Message,"错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Log.Error(ex);
            }
        }
        private void InitContorls()
        {
            try
            {
                if (LicenseTypeItems != null && LicenseTypeItems.Count > 0)
                {
                    comboBoxLicenseType.DataSource = LicenseTypeItems;
                }
                //comboBoxLicenseType.DataBindings.Add(new Binding("SelectedValue", QueryPharmacyLicenseModel, "LicenseTypeValue", false, DataSourceUpdateMode.OnPropertyChanged));
                textBoxName.DataBindings.Add(new Binding("Text", QueryPharmacyLicenseModel, "Name", false, DataSourceUpdateMode.OnPropertyChanged));
                textBoxCode.DataBindings.Add(new Binding("Text", QueryPharmacyLicenseModel, "Code", false, DataSourceUpdateMode.OnPropertyChanged));
                textBoxLicenseCode.DataBindings.Add(new Binding("Text", QueryPharmacyLicenseModel, "LicenseCode", false, DataSourceUpdateMode.OnPropertyChanged));
                textBoxUnitName.DataBindings.Add(new Binding("Text", QueryPharmacyLicenseModel, "UnitName", false, DataSourceUpdateMode.OnPropertyChanged));
                textBoxRegAddress.DataBindings.Add(new Binding("Text", QueryPharmacyLicenseModel, "RegAddress", false, DataSourceUpdateMode.OnPropertyChanged));
                var OutDate = QueryPharmacyLicenseModel.OutDate;
                dateTimePickerOutDateFrom.DataBindings.Add(new Binding("Value", OutDate, "Min", false, DataSourceUpdateMode.OnPropertyChanged));
                //dateTimePickerOutDateFrom.DataBindings.Add(new Binding("IsChecked", OutDate, "QueryMin", false, DataSourceUpdateMode.OnPropertyChanged));
                dateTimePickerOutDateTo.DataBindings.Add(new Binding("Value", OutDate, "Max", false, DataSourceUpdateMode.OnPropertyChanged));
               //dateTimePickerOutDateTo.DataBindings.Add(new Binding("IsChecked", OutDate, "QueryMax", false, DataSourceUpdateMode.OnPropertyChanged));  
             }
            catch (Exception ex)
            {
                ex = new Exception("初始化控件失败", ex);
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+ex.Message,"错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Log.Error(ex);
            }
        }
        private void LoadDataFromServer()
        {
            try
            {
                string message = string.Empty;
                DataList = PharmacyDatabaseService.QueryPharmacyLicenseForOutdate(out message, QueryPharmacyLicenseModel).ToList();
            }
            catch (Exception ex)
            {
                ex = new Exception("从服务器获取数据失败", ex);
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Log.Error(ex);
                DataList = null;
            }
        }
        private void CollectQueryConditions()
        {
            try
            {
                ////处理GSP和药品经营许可证
                int type=int.Parse(this.comboBoxLicenseType.SelectedValue.ToString());
                if (type == 0)
                    QueryPharmacyLicenseModel.LicenseTypeValue = 10;
                else
                    if (type == 10)
                        QueryPharmacyLicenseModel.LicenseTypeValue = 0;
                    else
                        QueryPharmacyLicenseModel.LicenseTypeValue = type;
                var outDate = QueryPharmacyLicenseModel.OutDate;
                outDate.QueryMin = this.dateTimePickerOutDateFrom.Checked;
                outDate.QueryMax = this.dateTimePickerOutDateTo.Checked;
                outDate.Max = this.dateTimePickerOutDateFrom.Value;
                outDate.Min = this.dateTimePickerOutDateTo.Value;

            }
            catch (Exception ex)
            {
                ex = new Exception("收集用户查询条件失败", ex);
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+ex.Message,"错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Log.Error(ex);
                QueryPharmacyLicenseModel = null;
            }
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            CollectQueryConditions();
            LoadDataFromServer(); 
            BindDataList();
        }

        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                DataGridViewRow row = this.dataGridView.Rows[e.RowIndex];
                PharmacyLicense data = row.DataBoundItem as PharmacyLicense;
                if (data == null) return;
                DataGridViewTextBoxCell cell = row.Cells[colLicenseType.Name] as DataGridViewTextBoxCell;
                //处理GSP和药品经营许可证
                int  type = int.Parse(this.comboBoxLicenseType.SelectedValue.ToString());
                if (int.Parse(this.comboBoxLicenseType.SelectedValue.ToString()) == -1)
                {
                    if(data.LicenseTypeValue == 0)
                        cell.Value = "药品经营许可证";
                    else
                        if (data.LicenseTypeValue == 10)
                            cell.Value = "GSP证书";
                        else
                            cell.Value = EnumHelper<LicenseType>.GetDisplayValue(data.LicenseType);
                }
                else
                {
                    if (type == 0)
                        cell.Value = "GSP证书";
                    else
                        if (type == 10)
                            cell.Value = "药品经营许可证";
                        else
                            cell.Value = EnumHelper<LicenseType>.GetDisplayValue(data.LicenseType);
                }

                //过期显红
                if (data.OutDate.Date < DateTime.Now)
                {
                    cell = row.Cells[colIssuanceDate.Name] as DataGridViewTextBoxCell;
                    cell.Style.BackColor = Color.Red;
                    cell = row.Cells[colOutDate.Name] as DataGridViewTextBoxCell;
                    cell.Style.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                ex = new Exception("绘制列表行失败", ex);
                Log.Error(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView,"证照查询列表");
        }
    }
}
