using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.UI.Common.Helper;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    public partial class FormAllDrugInventoryRecordSelector : BaseFunctionForm
    {
        public FormAllDrugInventoryRecordSelector()
        {
            InitializeComponent();
        }

        #region 属性和字段


        private SelectMode selectMode;

        /// <summary>
        /// 选择模式
        /// </summary>
        public SelectMode SelectMode
        {
            get
            {
                return selectMode;
            }
            set
            {
                if (selectMode == value) return;
                selectMode = value;
                if (!DesignMode
                    && !ControlValidator.IsDisposed(this.dataGridView1))
                {
                    this.dataGridView1.MultiSelect = (selectMode == Common.SelectMode.Multiple);
                    if (SelectedDrugInventoryRecords != null)
                    {
                        var first = SelectedDrugInventoryRecords.FirstOrDefault();
                        SelectedDrugInventoryRecords.Clear();
                        SelectedDrugInventoryRecords.Add(first);
                    }
                }
            }
        }

        public List<DrugInventoryRecord> SelectedDrugInventoryRecords { get; set; }

        /// <summary>
        /// 当前页数据
        /// </summary>
        private List<DrugInventoryRecord> CurrentPageData { get; set; }

        /// <summary>
        /// 所有库区用于绑定给库区下接控件
        /// </summary>
        private List<WarehouseZone> AllWarehouseZones { get; set; }

        #region 查询条件相关

        private QueryDrugInventoryRecordBusinessModel QueryModel { get; set; }
        private PagerInfo pager;

        #endregion 查询条件相关

        #endregion

        #region 从服务器获取数据

        /// <summary>
        /// 获取分页查询数据
        /// </summary>
        private void LoadQueryPagedDataFromServer()
        {
            try
            {
                int index = this.pagerControl1.PageIndex;
                int size = this.pagerControl1.PageSize;
                string message;
                CurrentPageData = PharmacyDatabaseService.QueryPagedAllDrugInventoryRecordSelector(
                    out pager, out message,
                   QueryModel,
                    index, size
                    ).ToList();
            }
            catch (Exception ex)
            {
                ex = new Exception("获取分页查询数据失败" + ex.Message);
                Log.Error(ex);
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// 从服务器获取所有库区
        /// </summary>
        private void LoadAllWarehouseZonesFromServer()
        {
            try
            {
                string message;
                AllWarehouseZones = PharmacyDatabaseService.AllWarehouseZones(out message)
                    .ToList();
            }
            catch (Exception ex)
            {
                AllWarehouseZones = null;
                ex = new Exception("从服务器获取所有库区失败" + ex.Message);
                Log.Error(ex);
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        #endregion

        #region 控件到数据

        /// <summary>
        /// 收集已经选择的记录
        /// </summary>
        private void CellectSelectedDatas()
        {
            try
            {
                this.SelectedDrugInventoryRecords.Clear();
                foreach (DataGridViewRow item in this.dataGridView1.Rows)
                {
                    var cellCheckBox = item.Cells[colCheckBoxSelect.Name] as DataGridViewCheckBoxCell;
                    bool selected = cellCheckBox.EditedFormattedValue.ToString().ToLower() == "true";
                    if (selected)
                    {
                        this.SelectedDrugInventoryRecords.Add(item.DataBoundItem as DrugInventoryRecord);
                        if (selectMode == Common.SelectMode.Single)
                        {
                            return;
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                ex = new Exception("收集已经选择的记录" + ex.Message);
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Log.Error(ex);
            }
        }

        /// <summary>
        /// 收集查询信息
        /// </summary>
        private void CellectQueryInfo()
        {
            try
            {

            }
            catch (Exception ex)
            {
                ex = new Exception("收集查询信息失败" + ex.Message);
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Log.Error(ex);
            }
        }

        #endregion

        #region 数据到控件

        /// <summary>
        /// 绑定所有库区到库区下拉条件
        /// </summary>
        private void BindAllWarehouseZones()
        {
            try
            {
                if (AllWarehouseZones != null)
                {
                    var tempZones = AllWarehouseZones
                        .ToList();
                    foreach (var zone in tempZones)
                    {
                        zone.Name = zone.Warehouse.Name + ">>" + zone.Name;
                    }
                    tempZones.Insert(0, new WarehouseZone { Id = Guid.NewGuid(), Name = "请选择..." });
                    this.comboBoxWarehouseZones.DisplayMember = "Name";
                    this.comboBoxWarehouseZones.ValueMember = "Id";
                    this.comboBoxWarehouseZones.DataSource = tempZones;

                }
            }
            catch (Exception ex)
            {
                ex = new Exception("绑定所有库区到库区下拉条件失败" + ex.Message);
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Log.Error(ex);
            }
        }

        /// <summary>
        /// 绑定当前页数据到列表控件 
        /// </summary>
        private void BindCurrentPageData()
        {
            try
            {
                if (CurrentPageData == null)
                {
                    this.dataGridView1.DataSource = null;
                    InitControls();
                    pager = null;
                }
                else
                {
                    this.pagerControl1.PageIndex = pager.Index;
                    this.pagerControl1.RecordCount = pager.RecordCount;
                    this.dataGridView1.DataSource = CurrentPageData;
                }
            }
            catch (Exception ex)
            {
                ex = new Exception("绑定当前页数据到列表控件失败" + ex.Message);
                //MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Log.Error(ex);
            }
        }

        #endregion

        #region 数据初始化

        private void InitData()
        {
            if (this.SelectedDrugInventoryRecords == null)
            {
                this.SelectedDrugInventoryRecords = new List<DrugInventoryRecord>();
            }
            this.SelectedDrugInventoryRecords.Clear();
            QueryModel = new QueryDrugInventoryRecordBusinessModel();
        }

        #endregion

        #region 控件初始化

        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControls()
        {
            //分页控件处理
            this.pagerControl1.PageSize = AppConfig.Config.PageSize;
            this.pagerControl1.PageIndex = 1;
            DateTime nowTime = DateTime.Now;
            this.dateTimePickerInInventoryDateFrom.Value = nowTime.Date.AddDays(-1);
            this.dateTimePickerInInventoryDateTo.Value = nowTime.Date.AddDays(1);
            this.dateTimePickerPruductDateFrom.Value = nowTime.Date.AddDays(-1);
            this.dateTimePickerPruductDateTo.Value = nowTime.Date.AddDays(1);
            this.dateTimePickerOutValidDateFrom.Value = nowTime.Date.AddDays(-1);
            this.dateTimePickerOutValidDateTo.Value = nowTime.Date.AddDays(1);
            this.dataGridView1.AutoGenerateColumns = false;
        }

        #endregion

        #region 事件处理

        #region 日期控件事件

        private void dateTimePickerInInventoryDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerInInventoryDateFrom.Value > dateTimePickerInInventoryDateTo.Value)
            {
                var tempDate = dateTimePickerInInventoryDateTo.Value;
                dateTimePickerInInventoryDateTo.Value = dateTimePickerInInventoryDateFrom.Value;
                dateTimePickerInInventoryDateFrom.Value = tempDate;
            }
        }

        private void dateTimePickerPruductDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerPruductDateFrom.Value > dateTimePickerPruductDateTo.Value)
            {
                var tempDate = dateTimePickerPruductDateTo.Value;
                dateTimePickerPruductDateTo.Value = dateTimePickerPruductDateFrom.Value;
                dateTimePickerPruductDateFrom.Value = tempDate;
            }
        }


        private void dateTimePickerOutValidDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerOutValidDateFrom.Value > dateTimePickerOutValidDateTo.Value)
            {
                var tempDate = dateTimePickerOutValidDateTo.Value;
                dateTimePickerOutValidDateTo.Value = dateTimePickerOutValidDateFrom.Value;
                dateTimePickerOutValidDateFrom.Value = tempDate;
            }
        }



        #endregion

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                //收集选择的药物库存
                CellectSelectedDatas();
                if (this.SelectedDrugInventoryRecords.Count < 1)
                {
                    //MessageBox.Show("请您选择记录", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                    MessageBox.Show("请您选择记录", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                    return;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                buttonCancel_Click(sender, e);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            LoadQueryPagedDataFromServer();
            BindCurrentPageData();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;
            InitData();
            InitControls();
            LoadAllWarehouseZonesFromServer();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                var column = this.dataGridView1.Columns[e.ColumnIndex];
                var row = this.dataGridView1.Rows[e.RowIndex];
                if (column.Name == colCheckBoxSelect.Name)
                {
                    //处理选择CheckBox,只有单选时要处理
                    if (selectMode == Common.SelectMode.Single)
                    {
                        var cellCheckBox = row.Cells[colCheckBoxSelect.Name] as DataGridViewCheckBoxCell;
                        bool selected = cellCheckBox.EditedFormattedValue.ToString().ToLower() == "true";
                        if (selected)
                        {
                            //取消其他的已经选择的
                            var allRows = this.dataGridView1.Rows;
                            foreach (DataGridViewRow item in allRows)
                            {
                                if (item == row)
                                {
                                    continue;
                                }
                                cellCheckBox = item.Cells[colCheckBoxSelect.Name] as DataGridViewCheckBoxCell;
                                cellCheckBox.Value = false;
                            }
                        }

                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                AllWarehouseZones = null;
                ex = new Exception("单元格点击处理失败" + ex.Message);
                Log.Error(ex);
            }
        }
        private void pagerControl1_DataPaging()
        {
            LoadQueryPagedDataFromServer();
            BindCurrentPageData();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                var row = this.dataGridView1.Rows[e.RowIndex];
                if (row == null) return;
                var data = row.DataBoundItem as DrugInventoryRecord;
                if (data == null) return;

                //药物信息处理
                var cellDrugInfo = row.Cells[colDrugInfo.Name];
                cellDrugInfo.Value = string.Format("{3}-{0}:{1},{2}"
                    , data.DrugInfo.ProductName
                    , data.DrugInfo.FactoryName
                    , data.DrugInfo.Valid ? "通过" : "禁止"
                    , EnumHelper<GoodsType>.GetDisplayValue(data.DrugInfo.GoodsType)); 
                //库存处理
                var cellWareHouse = row.Cells[colWareHouseInfo.Name];
                cellWareHouse.Value = string.Format("{0}@{1}"
                   , data.WarehouseZone.Warehouse.Name
                   , data.WarehouseZone.Name
                  );
                //入库类型处理
                var cellDurgInventory = row.Cells[colDurgInventoryType.Name];
                cellDurgInventory.Value = EnumHelper<DurgInventoryType>.GetDisplayValue(data.DurgInventoryType);

            }
            catch (Exception ex)
            {
                AllWarehouseZones = null;
                ex = new Exception("绘制行失败" + ex.Message);
                Log.Error(ex);
            }
        }


        #endregion 事件处理

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }


    }
}
