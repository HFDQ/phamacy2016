using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Service.Models;
using BugsBox.Pharmacy.UI.Common;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormSupplyUnitSalesmanList : BaseFunctionForm
    {
        public FormSupplyUnitSalesmanList(FormRunMode mode)
        {
            Mode = mode;
            switch (Mode)
            {
                case FormRunMode.Check:
                    this.Text = "供货商业务人员审核";
                    break;
            }
            InitializeComponent();
          
        }

        public FormSupplyUnitSalesmanList(params object[] args)
            : this((FormRunMode)int.Parse(args[0].ToString()))
        {
            
        }

        public FormRunMode Mode { get; set; }

        public FormSupplyUnitSalesmanList()
            : this(FormRunMode.Edit)
        {
        }

        private bool CheckForm { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitData();
            InitControls();
            this.pagerControl.PageIndex = 1;
            CollectConditions();
            LoadDataFromServer();
            BindDataList();
        }

        private void InitData()
        {
            try
            {
                string message;
                SupplyUnits = PharmacyDatabaseService.AllSupplyUnits(out message)
                    .ToList();
                SupplyUnits.Insert(0, new SupplyUnit { Id = Guid.Empty, Name = "请您选择..." });
                queryModel = new QuerySupplyUnitSalesmanModel();
                queryModel.OutDateFrom = TypesDefaultValues.MaxDateTime;
                queryModel.OutDateTo = TypesDefaultValues.MinDateTime;
                queryModel.BirthdayFrom = TypesDefaultValues.MaxDateTime;
                queryModel.BirthdayTo = TypesDefaultValues.MinDateTime;
                queryModel.CreateTimeFrom = TypesDefaultValues.MaxDateTime;
                queryModel.CreateTimeTo = TypesDefaultValues.MinDateTime;
                queryModel.UpdateTimeFrom = TypesDefaultValues.MaxDateTime;
                queryModel.UpdateTimeTo = TypesDefaultValues.MinDateTime;
            }
            catch (Exception ex)
            {
                ex = new Exception("初始化数据失败", ex);
                Log.Error(ex);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitControls()
        {
            try
            {
                if (SupplyUnits != null)
                    this.comboBoxSupplyUnitId.DataSource = SupplyUnits;
                this.dataGridView.AutoGenerateColumns = false;
                //按钮显隐
                this.colButtonCheck.Visible = Mode == FormRunMode.Check & this.Authorize(ModuleKeys.GFYWY_Check);
                this.colButtonEdit.Visible = Mode == FormRunMode.Edit & this.Authorize(ModuleKeys.GFYWY_EDIT);
            }
            catch (Exception ex)
            {
                ex = new Exception("初始化控件失败", ex);
                Log.Error(ex);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<SupplyUnit> SupplyUnits { get; set; }
        private List<SupplyUnitSalesman> DataList { get; set; }
        private QuerySupplyUnitSalesmanModel queryModel { get; set; }
        BugsBox.Application.Core.PagerInfo pager = new Application.Core.PagerInfo();

        private void CollectConditions()
        {
            Guid SupplyUnitId = Guid.Empty;
            if (comboBoxSupplyUnitId.SelectedValue != null)
            {
                SupplyUnitId = Guid.Parse(comboBoxSupplyUnitId.SelectedValue.ToString());
            }
            queryModel.SupplyUnitId = SupplyUnitId;
            queryModel.Name = this.textBoxName.Text;
            queryModel.IDNumber = this.textBoxIdNumber.Text;
            queryModel.Address = this.textBoxAddress.Text;
            if (dateTimePickerOutDateFrom.Checked)
            {
                queryModel.OutDateFrom = dateTimePickerOutDateFrom.Value;
            }
            if (dateTimePickerOutDateTo.Checked)
            {
                queryModel.OutDateTo = dateTimePickerOutDateTo.Value;
            }
        }

        private void LoadDataFromServer()
        {
            try
            {
                DataList = PharmacyDatabaseService
                    .SearchPagedSupplyUnitSalesmansByQueryModel(out pager
                    , queryModel
                    , this.pagerControl.PageIndex,
                    pagerControl.PageSize)
                    .ToList();
            }
            catch (Exception ex)
            {
                ex = new Exception("从服务器获取数据失败", ex);
                Log.Error(ex);
                DataList = null;
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataList()
        {
            try
            {
                this.dataGridView.DataSource = DataList;
                this.pagerControl.RecordCount = pager.RecordCount;
            }
            catch (Exception ex)
            {
                ex = new Exception("绑定数据失败 ", ex);
                Log.Error(ex);
                DataList = null;
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            try
            {
                var currentColumn = this.dataGridView.Columns[e.ColumnIndex];
                var row = this.dataGridView.Rows[e.RowIndex];
                if (currentColumn == null) return;
                if (currentColumn.Name == colButtonCheck.Name)
                {
                    //审核
                    SupplyUnitSalesman originalEntity = row.DataBoundItem as SupplyUnitSalesman;
                    Check(originalEntity);
                }
                else if (currentColumn.Name == colButtonEdit.Name)
                {
                    //编辑
                    SupplyUnitSalesman originalEntity = row.DataBoundItem as SupplyUnitSalesman;
                    if (originalEntity.IsChecked == true)
                    {
                        if (MessageBox.Show("本记录已审核通过，是否进入编辑修改（注：修改后需要重新审核）?", "确认信息", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            Edit(originalEntity);
                    }
                    else
                        Edit(originalEntity);
                }
            }
            catch (Exception ex)
            {
                ex = new Exception("列表单元格单击处理失败 ", ex);
                Log.Error(ex);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool Check(SupplyUnitSalesman originalEntity)
        {
            try
            {
                FormSupplyUnitSalesmanEdit editor = new FormSupplyUnitSalesmanEdit(FormRunMode.Check, originalEntity);
                SupplyUnitSalesman entity;
                if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    entity = editor.Entity;
                    string message = string.Empty;
                    //加入核实信息
                    if (string.IsNullOrWhiteSpace(entity.IDCheckType))
                    {
                        entity.IDCheckType = "当面核实";
                    }
                    entity.IDCheckUserId = AppClientContext.CurrentUser.Id;
                    entity.IsChecked = true;
                    //加入核实信息
                    bool result = PharmacyDatabaseService.SaveSupplyUnitSalesman(out message, entity);
                    if (result && string.IsNullOrWhiteSpace(message))
                    {
                        MessageBox.Show(string.Format("审核供货商业务人员:{0}", "成功"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        buttonQuery_Click(null, null);
                        return false;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("审核供货商业务人员:{0}", "失败" + message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                this.Log.Error(ex);
                MessageBox.Show(string.Format("审核供货商业务人员:{0}", "失败" + ex.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private bool Edit(SupplyUnitSalesman originalEntity)
        {
            try
            {
                FormSupplyUnitSalesmanEdit editor = new FormSupplyUnitSalesmanEdit(FormRunMode.Edit, originalEntity);
                SupplyUnitSalesman entity;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    entity = editor.Entity;
                    string message = string.Empty;
                    //加入核实信息
                    if (string.IsNullOrWhiteSpace(entity.IDCheckType))
                    {
                        entity.IDCheckType = "当面核实";
                    }
                    entity.IDCheckUserId = Guid.Empty;
                    entity.IsChecked = false;
                    //加入核实信息
                    bool result = PharmacyDatabaseService.SaveSupplyUnitSalesman(out message, entity);
                    if (result && string.IsNullOrWhiteSpace(message))
                    {
                        MessageBox.Show(string.Format("编辑供货商业务人员:{0}", "成功"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        buttonQuery_Click(null, null);
                        return false;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("编辑供货商业务人员:{0}", "失败" + message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                this.Log.Error(ex);
                MessageBox.Show(string.Format("编辑供货商业务人员:{0}", "失败" + ex.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void pagerControl_DataPaging()
        {
            CollectConditions();
            LoadDataFromServer();
            BindDataList();
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            this.pagerControl.PageIndex = 1;
            CollectConditions();
            LoadDataFromServer();
            BindDataList();
        }

        private void dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                var row = this.dataGridView.Rows[e.RowIndex];
                var entity = row.DataBoundItem as SupplyUnitSalesman;
                if (entity != null)
                {
                    var cellSuplyUint = row.Cells[colSupplyUnitInfo.Name];
                    cellSuplyUint.Value = entity.SupplyUnit.Name;
                    var cellName = row.Cells[colName.Name];
                    cellName.Value = string.Format("{0}({1},{2})", entity.Name, entity.Gender, entity.Birthday.ToString("yyyy年MM月dd日"));
                }
            }
            catch (Exception ex)
            {
                ex = new Exception("准备行绘制失败");
                Log.Error(ex);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FormSupplyUnitSalesmanEdit editor = new FormSupplyUnitSalesmanEdit();
                SupplyUnitSalesman entity;
                if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    entity = editor.Entity;
                    string message = string.Empty;
                    //加入核实信息
                    if (string.IsNullOrWhiteSpace(entity.IDCheckType))
                    {
                        entity.IDCheckType = "当面核实";
                    }
                    entity.IDCheckUserId = Guid.Empty;
                    entity.IsChecked = false;
                    //加入核实信息
                    bool result = PharmacyDatabaseService.AddSupplyUnitSalesman(out message, entity);
                    if (result && string.IsNullOrWhiteSpace(message))
                    {
                        MessageBox.Show(string.Format("添加供货商业务人员:{0}", "成功"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        buttonQuery_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("添加供货商业务人员:{0}", "失败" + message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                this.Log.Error(ex);
                MessageBox.Show(string.Format("添加供货商业务人员:{0}", "失败" + ex.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}
