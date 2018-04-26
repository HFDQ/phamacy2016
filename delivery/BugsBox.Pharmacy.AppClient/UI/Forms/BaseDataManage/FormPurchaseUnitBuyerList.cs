using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Service.Models;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common.Helper;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormPurchaseUnitBuyerList : BaseFunctionForm
    {
       public FormPurchaseUnitBuyerList(FormRunMode mode)
        {
            Mode = mode;
            switch (Mode)
            {
                case FormRunMode.Check:
                    this.Text = "客户采购员审核";
                    break;
            }
            InitializeComponent();
          
        }

        public FormPurchaseUnitBuyerList(params object[] args)
            : this((FormRunMode)int.Parse(args[0].ToString()))
        {
            
        }

        public FormRunMode Mode { get; set; }

        public FormPurchaseUnitBuyerList()
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
                PurchaseUnits = PharmacyDatabaseService.AllPurchaseUnits(out message)
                    .ToList();
                PurchaseUnits.Insert(0, new PurchaseUnit { Id = Guid.Empty, Name = "请您选择..." });
                queryModel = new QueryPurchaseUnitBuyerModel();
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
                if (PurchaseUnits != null)
                    this.comboBoxSupplyUnitId.DataSource = PurchaseUnits;
                this.dataGridView.AutoGenerateColumns = false;
                //按钮显隐
                this.colButtonCheck.Visible = Mode == FormRunMode.Check & this.Authorize(ModuleKeys.KHYWY_Check);
                this.colButtonEdit.Visible = Mode == FormRunMode.Edit & this.Authorize(ModuleKeys.KHYWY_EDIT);
            }
            catch (Exception ex)
            {
                ex = new Exception("初始化控件失败", ex);
                Log.Error(ex);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<PurchaseUnit> PurchaseUnits { get; set; }
        private List<PurchaseUnitBuyer> DataList { get; set; }
        private QueryPurchaseUnitBuyerModel queryModel { get; set; }
        BugsBox.Application.Core.PagerInfo pager = new Application.Core.PagerInfo();

        private void CollectConditions()
        {
            Guid PurchaseUnitId = Guid.Empty;
            if (comboBoxSupplyUnitId.SelectedValue != null)
            {
                PurchaseUnitId = Guid.Parse(comboBoxSupplyUnitId.SelectedValue.ToString());
            }
            queryModel.PurchaseUnitId = PurchaseUnitId;
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
                    .SearchPagedPurchaseUnitBuyersByQueryModel(out pager
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
                    PurchaseUnitBuyer originalEntity = row.DataBoundItem as PurchaseUnitBuyer;
                    Check(originalEntity);
                }
                else if (currentColumn.Name == colButtonEdit.Name)
                {
                    //编辑
                    PurchaseUnitBuyer originalEntity = row.DataBoundItem as PurchaseUnitBuyer;
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


        private bool Check(PurchaseUnitBuyer originalEntity)
        {
            try
            {
                FormPurchaseUnitBuyerEdit editor = new FormPurchaseUnitBuyerEdit(FormRunMode.Check, originalEntity);
                PurchaseUnitBuyer entity;
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
                    bool result = PharmacyDatabaseService.SavePurchaseUnitBuyer(out message, entity);
                    if (result && string.IsNullOrWhiteSpace(message))
                    {
                        MessageBox.Show(string.Format("审核客户采购员:{0}", "成功"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        buttonQuery_Click(null, null);
                        return false;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("审核客户采购员:{0}", "失败" + message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                this.Log.Error(ex);
                MessageBox.Show(string.Format("审核客户采购员:{0}", "失败" + ex.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private bool Edit(PurchaseUnitBuyer originalEntity)
        {
            try
            {
                FormPurchaseUnitBuyerEdit editor = new FormPurchaseUnitBuyerEdit(FormRunMode.Edit, originalEntity);
                PurchaseUnitBuyer entity;
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
                    bool result = PharmacyDatabaseService.SavePurchaseUnitBuyer(out message, entity);
                    if (result && string.IsNullOrWhiteSpace(message))
                    {
                        MessageBox.Show(string.Format("编辑客户采购员:{0}", "成功"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        buttonQuery_Click(null, null);
                        return false;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("编辑客户采购员:{0}", "失败" + message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                this.Log.Error(ex);
                MessageBox.Show(string.Format("编辑客户采购员:{0}", "失败" + ex.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var entity = row.DataBoundItem as PurchaseUnitBuyer;
                if (entity != null)
                {
                    var cellSuplyUint = row.Cells[colSupplyUnitInfo.Name];
                    cellSuplyUint.Value = entity.PurchaseUnit.Name;
                    var cellName = row.Cells[colName.Name];
                    cellName.Value = string.Format("{0}({1},{2})", entity.Name, entity.Gender, entity.Birthday.ToString("yyyy年MM月dd日"));
                    //期限
                    var cellLimitType = row.Cells[colLimitType.Name];
                    cellLimitType.Value = EnumHelper<PurchaseLimitType>.GetDisplayValue(entity.PurchaseLimitType);
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
                FormPurchaseUnitBuyerEdit editor = new FormPurchaseUnitBuyerEdit();
                PurchaseUnitBuyer entity;
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
                    bool result = PharmacyDatabaseService.AddPurchaseUnitBuyer(out message, entity);
                    if (result && string.IsNullOrWhiteSpace(message))
                    {
                        MessageBox.Show(string.Format("添加客户采购员:{0}", "成功"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        buttonQuery_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("添加客户采购员:{0}", "失败" + message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                this.Log.Error(ex);
                MessageBox.Show(string.Format("添加客户采购员:{0}", "失败" + ex.Message), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
