using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using CustomValidatorsLibrary;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Service.Models;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.UI.Forms.Approval;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormDrugInfo : BaseFunctionForm  //Form 
    {
        private DrugInfo entity = new DrugInfo();
        private List<DrugInfo> _listDrugInfo = new List<DrugInfo>();

        private PagerInfo pageInfo = new PagerInfo();
        private OperateType _TYPE = OperateType.Browse;
        private string _searchKeyword = string.Empty;
        private BindingSource _source = new BindingSource();
        DrugInfo drug = null;
        string msg = string.Empty;
        ContextMenuStrip cms = new ContextMenuStrip();
        ContextMenuStrip cmsColHead = new ContextMenuStrip();
        List<string> ListColHeadText = new List<string>();

        public FormDrugInfo()
        {
            InitializeComponent();
            this.dataGridView1.RowPostPaint += delegate (object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };

            this.RighMenu();
            this.ColumnHeadRightMenu();
        }
        //列头右键
        private void ColumnHeadRightMenu()
        {
            this.cmsColHead.Items.Add("冻结该列", null, delegate (object sender, EventArgs e) { this.ColOp(1); });
            this.cmsColHead.Items.Add("-");
            this.cmsColHead.Items.Add("解冻该列", null, delegate (object sender, EventArgs e) { this.ColOp(2); });
            this.cmsColHead.Items.Add("-");
            this.cmsColHead.Items.Add("关闭选中列", null, delegate (object sender, EventArgs e) { this.ColOp(0); });
            this.cmsColHead.Items.Add("-");
            ToolStripMenuItem tsmi = new ToolStripMenuItem("显示被关闭列");
            tsmi.Name = "显示被关闭列";
            this.cmsColHead.Items.Add(tsmi);
            tsmi.Enabled = false;
        }
        private void ColOp(int op)
        {
            if (op == 0)//关闭列
            {
                if (this.dataGridView1.SelectedColumns.Count <= 0) return;
                foreach (DataGridViewColumn dc in this.dataGridView1.SelectedColumns)
                {
                    dc.Visible = false;
                    if (!ListColHeadText.Contains(dc.HeaderText))
                        this.ListColHeadText.Add(dc.HeaderText);
                }
            }
            if (op == 1)
            {
                DataGridViewColumn dc = this.dataGridView1.SelectedColumns[this.dataGridView1.SelectedColumns.Count - 1];
                dc.Frozen = true;
            }
            if (op == 2)
            {
                DataGridViewColumn dc = this.dataGridView1.SelectedColumns[this.dataGridView1.SelectedColumns.Count - 1];
                dc.Frozen = false;
            }
        }

        private void RighMenu()
        {
            cms.Items.Add("表格操作");
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("自动列宽", null, delegate (object sender, EventArgs e)
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            });
            cms.Items.Add("取消自动列宽", null, delegate (object sender, EventArgs e)
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            });
            cms.Items.Add("-");
            cms.Items.Add("信息操作");
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");

            cms.Items.Add("查看品种信息", null, delegate (object sender, EventArgs e) { this.GetDrugInfo(0); });
            cms.Items.Add("-");
            cms.Items.Add("查看审批情况", null, delegate (object sender, EventArgs e) { this.GetDrugInfo(1); });
            cms.Items.Add("-");
            cms.Items.Add("修改品种信息", null, this.btnModify_Click);
            cms.Items.Add("-");
            cms.Items.Add("导出品种信息", null, delegate (object sender, EventArgs e) { this.GetDrugInfo(2); });
            cms.Items.Add("-");
            cms.Items.Add("生成品种信息审批表(WORD)", null, delegate (object sender, EventArgs e) { this.GetDrugInfo(3); });
            cms.Items.Add("-");
            cms.Items.Add("质量问题追溯", null, delegate (object sender, EventArgs e) { this.GetDrugInfo(4); });
        }
        //右键菜单事件
        private void GetDrugInfo(int Method)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0) return;
            var c = this.dataGridView1.SelectedRows[0].DataBoundItem as Business.Models.DrugInfoModel;
            DrugInfo di = this.PharmacyDatabaseService.GetDrugInfo(out msg, c.id);
            if (di == null) return;
            if (Method == 0)
            {
                UI.UserControls.ucGoodsInfo ucControl = new UserControls.ucGoodsInfo(di);
                Form f = new Form();
                f.WindowState = FormWindowState.Normal;
                f.StartPosition = FormStartPosition.CenterScreen;
                f.Text = di.ProductGeneralName;
                f.AutoSize = true;
                f.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                Panel p = new Panel();
                p.AutoSize = true;
                p.Controls.Add(ucControl);
                f.Controls.Add(p);
                SetControls.SetControlReadonly(f, true);
                f.ShowDialog();
            }

            if (Method == 1)
            {
                FormApprovalFlowCenter form = new FormApprovalFlowCenter(di, di.FlowID, false);
                form.ShowDialog();
            }

            if (Method == 2)
            {
                MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "品种信息查询结果");
            }

            if (Method == 3)
            {
                var u = this.dataGridView1.SelectedRows[0].DataBoundItem as Business.Models.DrugInfoModel;

                byte[] b = this.PharmacyDatabaseService.GetUpdateFiles("ApprovalFiles\\药品.doc").FirstOrDefault().bytes;

                if (u.BusinessScopeCode == "中药材" || u.BusinessScopeCode == "中药饮片")
                {
                    b = this.PharmacyDatabaseService.GetUpdateFiles("ApprovalFiles\\中药材.doc").FirstOrDefault().bytes;
                }


                using (System.IO.FileStream fs = new System.IO.FileStream("File", System.IO.FileMode.OpenOrCreate))
                {
                    fs.Write(b, 0, b.Length);
                    fs.Close();
                    CreateWinWord cww = new CreateWinWord();
                    cww.d = u;
                    if (cww.CreateWord(fs.Name, u.ProductGeneralName, 2))
                    {
                        MessageBox.Show(u.ProductGeneralName + "：审批信息表导出成功！");
                        this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "导出首营信息审批表成功！品种名称：" + di.ProductGeneralName);
                    }
                    else
                    {
                        this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "导出首营信息审批表失败！品种名称：" + di.ProductGeneralName);
                    }
                    fs.Dispose();
                }
            }

            if (Method == 4)
            {
                var u = this.dataGridView1.SelectedRows[0].DataBoundItem as Business.Models.DrugInfoModel;

                Form_DrugQualityTrace frm = new Form_DrugQualityTrace(u.id, u.ProductGeneralName);
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        public FormDrugInfo(object operateType) : this()
        {
            _TYPE = (OperateType)Convert.ToInt16(operateType);

            this.Text = UpdateFormTitle(_TYPE);
            switch (_TYPE)
            {
                case OperateType.Add:
                    btnSearch.Visible = false;
                    btnModify.Visible = false;
                    btnAdd.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    try
                    {
                        SetEditMode(true);
                        InitialEditTab();
                        entity = new DrugInfo();
                        this.ucGoodsInfo1.RunMode = Pharmacy.UI.Common.FormRunMode.Add;
                        this.ucGoodsInfo1.DrugInfo = entity;
                        this.ucGoodsInfo1.GoodsAdditional = new GoodsAdditionalProperty();
                        this.ucGoodsInfo1.GoodsAdditional.Id = entity.Id;
                        // this.ucGoodsInfo1.GoodsAdditional.DrugInfoId = entity.Id;
                        this.ucGoodsInfo1.GoodsAdditional.PutOnRecordDate = DateTime.Now;
                        this.ucGoodsInfo1.GoodsAdditional.LicensePermissionDate = DateTime.Now;
                        this.ucGoodsInfo1.getDrugInfoCount();
                        this.ucGoodsInfo1.setEnableState();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Log.Error(ex);
                    }

                    break;
                case OperateType.Browse:
                    btnAdd.Visible = true;
                    btnDelete.Visible = false;
                    btnModify.Visible = true;
                    btnModify.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    break;
            }
        }

        public FormDrugInfo(OperateType operateType, DrugInfo di) : this()
        {
            _TYPE = operateType;

            this.Text = UpdateFormTitle(_TYPE);
            this.entity = di;
            EditItem("");
            switch (_TYPE)
            {
                case OperateType.Add:
                    btnSearch.Visible = false;
                    btnModify.Visible = false;
                    btnAdd.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    break;
                case OperateType.Browse:
                    btnSearch.Visible = true;
                    btnAdd.Visible = true;
                    btnModify.Enabled = true;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    break;
            }
        }

        private void SetMode(OperateType mode)
        {
            switch (mode)
            {
                case OperateType.Browse:
                    DisplayTabPage(false);
                    break;
                case OperateType.Add:

                    DisplayTabPage(true);
                    break;
                case OperateType.Edit:
                    DisplayTabPage(true);
                    break;
                case OperateType.Search:
                    DisplayTabPage(false);
                    break;
                case OperateType.Delete:
                    DisplayTabPage(false);
                    break;
                default:
                    break;
            }
        }

        private void SetEditMode(bool isEdit)
        {
            tabPageEdit.Show();
            btnAdd.Enabled = !isEdit;
            //btnDelete.Enabled = !isEdit;
            btnModify.Enabled = !isEdit;
            btnSearch.Enabled = !isEdit;
            btnSave.Enabled = isEdit;
            btnCancel.Enabled = isEdit;
            DisplayTabPage(isEdit);
            if (isEdit)
            {
                tabControl1.SelectedIndex = 1;
            }
            else
            {
                tabControl1.SelectedIndex = 0;
            }
        }

        private void InitialEditTab()
        {
            if (_TYPE == OperateType.Edit)
            {

            }
            else if (_TYPE == OperateType.Add)
            {

            }
        }

        //隐藏或显示TabPage控件
        private void DisplayTabPage(bool displayEditPage)
        {
            tabControl1.TabPages.Clear();
            if (displayEditPage)
            {
                tabControl1.TabPages.Insert(0, tabPageEdit);
            }
            else
            {
                tabControl1.TabPages.Insert(0, tabPageSearch);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _searchKeyword = txtSearchKeyword.Text.Trim();
            int pageIndex = this.pagerControl1.PageIndex;
            int pageSize = this.pagerControl1.PageSize;
            GetListDrugInfo(pageIndex, pageSize);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _searchKeyword = txtSearchKeyword.Text.Trim();
            int pageIndex = 1;
            int pageSize = this.pagerControl1.PageSize;
            GetListDrugInfo(pageIndex, pageSize);

            this.pagerControl1.RecordCount = pageInfo.RecordCount;
            this.pagerControl1.PageIndex = 1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = false;
            btnAdd.Visible = false;
            btnDelete.Visible = false;
            btnModify.Visible = false;
            try
            {
                _TYPE = OperateType.Add;
                SetEditMode(true);
                InitialEditTab();
                entity = new DrugInfo();
                this.ucGoodsInfo1.RunMode = Pharmacy.UI.Common.FormRunMode.Add;
                this.ucGoodsInfo1.DrugInfo = entity;
                this.ucGoodsInfo1.GoodsAdditional = new GoodsAdditionalProperty();
                this.ucGoodsInfo1.GoodsAdditional.Id = entity.Id;
                // this.ucGoodsInfo1.GoodsAdditional.DrugInfoId = entity.Id;
                this.ucGoodsInfo1.GoodsAdditional.PutOnRecordDate = DateTime.Now;
                this.ucGoodsInfo1.GoodsAdditional.LicensePermissionDate = DateTime.Now;
                this.ucGoodsInfo1.getDrugInfoCount();
                this.ucGoodsInfo1.setEnableState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                _TYPE = OperateType.Delete;
                if (MessageBox.Show("确定要删除吗？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dataGridView1.CurrentRow != null)
                    {
                        //执行删除操作
                        int currRowIndex = dataGridView1.CurrentRow.Cells[0].RowIndex;
                        entity = _listDrugInfo[currRowIndex];

                        string msg = string.Empty;
                        PharmacyDatabaseService.DeleteDrugInfo(out msg, entity.Id);
                        SetEditMode(false);

                        btnRefresh_Click(this, null);
                    }
                    else
                        MessageBox.Show("没有选择要删除的记录!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                string message = string.Empty;
                _TYPE = OperateType.Edit;
                this.ucGoodsInfo1.RunMode = Pharmacy.UI.Common.FormRunMode.Edit;
                if (dataGridView1.CurrentRow != null)
                {
                    Business.Models.DrugInfoModel di = this.dataGridView1.CurrentRow.DataBoundItem as Business.Models.DrugInfoModel;
                    entity = this.PharmacyDatabaseService.GetDrugInfo(out msg, di.id);
                    if (entity.BusinessScopeCode.Contains("医疗器械"))
                    {
                        FormInstrument frm = new FormInstrument
                        {
                            entity = entity,
                            FSE = FormStatusEnum.Edit
                        };
                        frm.ShowDialog();
                    }
                    else
                    {
                        message = EditItem(message);
                    }
                }
                else
                    MessageBox.Show("没有选择要修改的记录!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private string EditItem(string message)
        {
            InitialEditTab();

            SetEditMode(true);
            //编辑操作
            this.ucGoodsInfo1.RunMode = Pharmacy.UI.Common.FormRunMode.Edit;
            this.ucGoodsInfo1.DrugInfo = entity;
            GoodsAdditionalProperty goodsAdditional = new GoodsAdditionalProperty();
            goodsAdditional = PharmacyDatabaseService.GetGoodsAdditionalProperty(out message, entity.Id);
            if (goodsAdditional == null)
            {
                goodsAdditional = new GoodsAdditionalProperty();
                this.ucGoodsInfo1.GoodsAdditional = new GoodsAdditionalProperty();
                this.ucGoodsInfo1.GoodsAdditional.Id = entity.Id;
                // this.ucGoodsInfo1.GoodsAdditional.DrugInfoId = entity.Id;
                this.ucGoodsInfo1.GoodsAdditional.PutOnRecordDate = DateTime.Now;
                this.ucGoodsInfo1.GoodsAdditional.LicensePermissionDate = DateTime.Now;
            }
            this.ucGoodsInfo1.GoodsAdditional = goodsAdditional;
            return message;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = String.Empty;
                if (!this.ucGoodsInfo1.ValidateControls(out msg))
                {
                    MessageBox.Show(msg);
                    return;
                }

                this.ucGoodsInfo1.CellectDrugInfo();
                if (!this.ucGoodsInfo1.DataReady)
                {
                    return;
                }
                entity = this.ucGoodsInfo1.DrugInfo;

                if (entity.GoodsType != GoodsType.DrugDomestic && entity.GoodsType != GoodsType.DrugImport)
                {
                    string b = UI.RequiredFieldsCheck<GoodsAdditionalProperty>.CheckRequiredFields(this.ucGoodsInfo1.GoodsAdditional);
                    if (!string.IsNullOrEmpty(b))
                    {
                        MessageBox.Show("您选择的商品类型为非国产药品和进口药品，字段：" + b + ",为必填项，请点击“附属信息”按钮填写完整信息!");
                        return;
                    }
                }

                entity.GoodsAdditionalProperty = this.ucGoodsInfo1.GoodsAdditional;

                if (_TYPE == OperateType.Add)
                {
                    entity.ApprovalStatus = ApprovalStatus.Waitting;
                    entity.IsApproval = false;
                    Guid typeid = (Guid)this.ucGoodsInfo1.comboBoxFlowID.SelectedValue;
                    entity.FlowID = Guid.NewGuid();
                    msg = PharmacyDatabaseService.AddDrugInfoApproveFlow(entity, typeid, AppClientContext.CurrentUser.Id, "新增品种信息:" + entity.ProductGeneralName);
                }
                else if (_TYPE == OperateType.Edit)
                {
                    Guid typeid = (Guid)this.ucGoodsInfo1.comboBoxFlowID.SelectedValue;
                    if (entity.IsApproval || entity.ApprovalStatusValue == (int)ApprovalStatus.Reject)
                    {
                        entity.ApprovalStatus = ApprovalStatus.Waitting;
                        entity.IsApproval = false;
                        entity.FlowID = Guid.NewGuid();
                        msg = PharmacyDatabaseService.ModifyDrugInfoApproveFlow(entity, typeid, AppClientContext.CurrentUser.Id, "审核后修改品种信息:" + entity.ProductGeneralName);
                    }
                    else
                    {
                        entity.ApprovalStatus = ApprovalStatus.Waitting;
                        msg = PharmacyDatabaseService.ModifyDrugInfoApproveFlow(entity, typeid, AppClientContext.CurrentUser.Id, "审核前修改品种信息" + entity.ProductGeneralName);
                    }
                }

                if (msg.Length == 0)
                    MessageBox.Show("数据保存成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                SetEditMode(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            btnAdd.Visible = true;
            btnModify.Visible = true;
            SetEditMode(false);
        }

        private void FormDrugInfo_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            SetMode(_TYPE);
            this.textBoxUserName.Text = AppClientContext.currentUser.Employee.Name;
            this.textBoxTime.Text = DateTime.Now.Date.ToString();
            GetListDrugInfo(1, this.pagerControl1.PageSize);
            this.pagerControl1.RecordCount = pageInfo.RecordCount;
            this.pagerControl1.PageIndex = 1;
        }

        //查找
        private void GetListDrugInfo(int pageIndex, int pageSize)
        {
            try
            {
                _listDrugInfo = null;
                string kw = this.txtSearchKeyword.Text.Trim();
                _searchKeyword = txtSearchKeyword.Text.Trim();
                var c = this.PharmacyDatabaseService.GetDrugInfoByCondition(kw, pageIndex, pageSize, out pageInfo, false, out msg);
                this.dataGridView1.DataSource = c.ToList();
                ///隐藏采购员意见列
                //this.dataGridView1.Columns["Description"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void pagerControl1_DataPaging()
        {
            int pageIndex = this.pagerControl1.PageIndex;
            int pageSize = this.pagerControl1.PageSize;
            GetListDrugInfo(pageIndex, pageSize);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private string UpdateFormTitle(OperateType operTyper)
        {
            string title = string.Empty;
            if (operTyper == OperateType.Add)
                title = "首营药品录入";
            else if (operTyper == OperateType.Browse || operTyper == OperateType.Search)
            {
                title = "药品信息查询";
            }
            else if (operTyper == OperateType.Edit)
            {
                title = "首营药品编辑";
            }
            return title;
        }

        private void btnApprovalDetails_Click(object sender, EventArgs e)
        {
            FormApprovalFlowCenter form = new FormApprovalFlowCenter(drug, drug.FlowID, false);
            form.ShowDialog();
        }

        private void txtSearchKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return) return;
            this.GetListDrugInfo(1, this.pagerControl1.PageSize);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                this.dataGridView1.ClearSelection();
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cms.Show(MousePosition.X, MousePosition.Y);
            }
            else if (e.RowIndex < 0 && e.ColumnIndex >= 0)
            {
                foreach (DataGridViewColumn dc in this.dataGridView1.Columns)
                    dc.SortMode = DataGridViewColumnSortMode.NotSortable;
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
                this.dataGridView1.Columns[e.ColumnIndex].Selected = true;
                if (e.Button != System.Windows.Forms.MouseButtons.Right) return;

                ToolStripMenuItem tsmi = (ToolStripMenuItem)cmsColHead.Items["显示被关闭列"];
                tsmi.Enabled = ListColHeadText.Count > 0;

                if (tsmi.Enabled)
                {
                    tsmi.DropDownItems.Clear();
                    tsmi.DropDownItems.Add("显示全部列", null, delegate (object o, EventArgs ex)
                    {
                        foreach (DataGridViewColumn dc in this.dataGridView1.Columns)
                        {
                            dc.Visible = true;
                            ListColHeadText.Clear();
                        }
                    });
                    tsmi.DropDownItems.Add("-");
                    foreach (string s in ListColHeadText)
                    {
                        tsmi.DropDownItems.Add(s, null, delegate (object o, EventArgs ex)
                        {
                            foreach (DataGridViewColumn dc in this.dataGridView1.Columns)
                            {
                                if (dc.HeaderText == s)
                                {
                                    dc.Visible = true;
                                    ListColHeadText.Remove(s);
                                }
                            }
                        });
                    }
                }

                this.cmsColHead.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.GetDrugInfo(0);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "品种信息查询结果");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            btnModify_Click(null, null);
        }
    }
}
