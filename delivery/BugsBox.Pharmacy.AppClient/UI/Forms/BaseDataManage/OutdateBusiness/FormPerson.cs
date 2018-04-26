using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.OutdateBusiness
{
    public partial class FormPerson : BaseFunctionForm
    {
        public FormPerson()
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
        private QueryBusinessPersonModel QueryBusinessPersonModel { get; set; }
        private List<BusinessPersonModel> DataList { get; set; }
        private BusinessPersonModel SelectedBusinessPersonModel { get; set; }
        private List<ListItem> PersonTypeItems { get; set; }
        private void InitData()
        {
            try
            {
                if (PersonTypeItems != null && PersonTypeItems.Count > 0) return;
                PersonTypeItems = EnumHelper<PersonType>.GetMapKeyValues();
                PersonTypeItems.Insert(0, new ListItem { ID = "-1", Name = "所有" });

                //查询条件
                QueryBusinessPersonModel = new QueryBusinessPersonModel();
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
                if (PersonTypeItems != null && PersonTypeItems.Count > 0)
                {
                    comboBoxPersonType.DataSource = PersonTypeItems;
                } 
                textBoxName.DataBindings.Add(new Binding("Text", QueryBusinessPersonModel, "Name", false, DataSourceUpdateMode.OnPropertyChanged));
                textBoxIDNumber.DataBindings.Add(new Binding("Text", QueryBusinessPersonModel, "IDNumber", false, DataSourceUpdateMode.OnPropertyChanged));
                textBoxTel.DataBindings.Add(new Binding("Text", QueryBusinessPersonModel, "Tel", false, DataSourceUpdateMode.OnPropertyChanged)); 
                var OutDate = QueryBusinessPersonModel.OutDate;
                dateTimePickerOutDateFrom.DataBindings.Add(new Binding("Value", OutDate, "Min", false, DataSourceUpdateMode.OnPropertyChanged)); 
                dateTimePickerOutDateTo.DataBindings.Add(new Binding("Value", OutDate, "Max", false, DataSourceUpdateMode.OnPropertyChanged));
              
            }
            catch (Exception ex)
            {
                ex = new Exception("初始化控件失败", ex);
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Log.Error(ex);
            }
        }
        private void LoadDataFromServer()
        {
            try
            {
                string message = string.Empty;
                DataList = PharmacyDatabaseService.QueryBusinessPerson(out message, QueryBusinessPersonModel)
                    .ToList();
            }
            catch (Exception ex)
            {
                ex = new Exception("从服务器获取数据失败", ex);
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(this.Text+ex.Message,"错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Log.Error(ex);
                DataList = null;
            }
        }
        private void CollectQueryConditions()
        {
            try
            {
                QueryBusinessPersonModel.PersonTypeValue = int.Parse(this.comboBoxPersonType.SelectedValue.ToString());
                var outDate = QueryBusinessPersonModel.OutDate;
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
                QueryBusinessPersonModel = null;
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
                BusinessPersonModel data = row.DataBoundItem as BusinessPersonModel;
                if (data == null) return;
                DataGridViewTextBoxCell cell = row.Cells[colPersonType.Name] as DataGridViewTextBoxCell;
                cell.Value = EnumHelper<PersonType>.GetDisplayValue(data.PersonType);
                //过期显红
                if (data.OutDate.Date < DateTime.Now)
                {
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
    }
}
