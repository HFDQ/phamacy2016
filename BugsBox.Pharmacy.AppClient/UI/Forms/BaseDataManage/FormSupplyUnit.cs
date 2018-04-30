using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.PS;
using CustomValidatorsLibrary;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.AppClient.UI.Forms.Approval;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Service.Models;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormSupplyUnit : BaseFunctionForm
    {
        private SupplyUnit _supplyUnit = new SupplyUnit();
        private PagerInfo pageInfo = new PagerInfo();
        private IList<SupplyUnit> _listSupplyUnit = null;
        private IList<UnitType> _UnitType = null;
        private string _serachName = string.Empty;
        private string _searchCode = string.Empty;
        private OperateType _TYPE;
        private string msg = string.Empty;

        private ContextMenuStrip cms = new ContextMenuStrip();
        ContextMenuStrip cmsColHead = new ContextMenuStrip();//列头菜单对象
        List<string> ListColHeadText = new List<string>();  //记录被隐藏列头文字

        private List<User> ListUser = null;
        private int pageSize = 9999;
        public Dictionary<Guid, string> dicUnitType = new Dictionary<Guid, string>();
        public List<UnitType> _ListUnitType = new List<UnitType>();

        int WarningDate = SerialFile.csf.o.WarningDate;

        public FormSupplyUnit()
        {
            InitializeComponent();

            this.RightMenu();
            this.RightHeadMenu();
            this.SetColumns();
            dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.RowPostPaint += delegate (object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };

            _UnitType = this.PharmacyDatabaseService.AllUnitTypes(out msg);
            this.ListUser = this.PharmacyDatabaseService.AllUsers(out msg).ToList();
            InitcmbUnitType();
            this.CmbStatus.SelectedIndex = 0;

            this.toolStripComboBox1.ComboBox.SelectedItem = this.WarningDate.ToString();
        }
        public FormSupplyUnit(object operateType) : this()
        {
            _TYPE = (OperateType)Convert.ToInt16(operateType);
            this.ucSupplyUnit.operationType = _TYPE;
            this.Text = UpdateFormTitle(_TYPE);
            switch (_TYPE)
            {
                case OperateType.Add:
                    btnSearch.Visible = false;
                    btnModify.Visible = true;
                    btnAdd.Visible = true;
                    btnDelete.Visible = false;
                    break;
                case OperateType.Browse:
                case OperateType.Edit:
                    btnAdd.Visible = true;
                    btnModify.Enabled = true;
                    btnModify.Visible = true;
                    break;
            }
        }

        public FormSupplyUnit(OperateType operateType, SupplyUnit su) : this()
        {
            _TYPE = operateType;
            this.ucSupplyUnit.operationType = _TYPE;
            this.Text = UpdateFormTitle(_TYPE);
            this._supplyUnit = su;
            switch (_TYPE)
            {
                case OperateType.Add:
                    btnSearch.Visible = false;
                    btnModify.Visible = false;
                    btnAdd.Visible = false;
                    btnDelete.Visible = false;
                    break;
                case OperateType.Browse:
                case OperateType.Edit:
                    btnModify.Enabled = true;
                    btnModify.Visible = true;
                    break;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                _TYPE = OperateType.Browse;
                _serachName = txtSearchName.Text.Trim();
                _searchCode = txtSearchCode.Text.Trim();
                GetListSupplyUnit(this.pagerControl1.PageIndex, pageSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        /// <summary>
        /// 操作模式
        /// </summary>
        /// <param name="mode"></param>
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

        /// <summary>
        /// tab 按钮显示模式
        /// </summary>
        /// <param name="isEdit"></param>
        private void SetEditMode(bool isEdit)
        {
            tabPageEdit.Show();
            btnAdd.Enabled = !isEdit;
            btnDelete.Enabled = !isEdit;
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

        /// <summary>
        /// //隐藏或显示TabPage控件
        /// </summary>
        /// <param name="displayEditPage"></param>
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

        /// <summary>
        /// search 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        /// <summary>
        /// 新增事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _TYPE = OperateType.Add;
                SetEditMode(true);
                this.ucSupplyUnit.ClearControl();
                _supplyUnit = null;
                this.ucSupplyUnit.InitEditControl(_supplyUnit);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }

        }

        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                _TYPE = OperateType.Delete;
                if (dataGridView1.CurrentRow != null)
                {
                    int currRowIndex = dataGridView1.CurrentRow.Cells[0].RowIndex;
                    _supplyUnit = _listSupplyUnit[currRowIndex];
                    string msg = string.Empty;
                    PharmacyDatabaseService.DeleteSupplyUnit(out msg, _supplyUnit.Id);
                    if (msg.Length == 0)
                    {
                        Refresh();
                        MessageBox.Show("数据保存成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetEditMode(false);

                }
                else
                    MessageBox.Show("没有选择要删除的记录!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }

        }

        /// <summary>
        /// 修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            try
            {
                _TYPE = OperateType.Edit;
                if (dataGridView1.CurrentRow != null)
                {
                    Guid CurrentId = (dataGridView1.CurrentRow.DataBoundItem as bool2String).id;
                    _supplyUnit = this.PharmacyDatabaseService.GetSupplyUnit(out msg, CurrentId);
                    if (_supplyUnit.ApprovalStatusValue == 1)
                    {
                        if (MessageBox.Show("该记录尚未审批，是否确认修改？") == DialogResult.OK)
                        {
                            this.ucSupplyUnit.operationType = _TYPE;
                            this.ucSupplyUnit.InitEditControl(_supplyUnit);
                            SetEditMode(true);
                        }
                    }
                    else
                        if (MessageBox.Show("该记录已审批，修改后需要审批，确认") == DialogResult.OK)
                    {
                        this.ucSupplyUnit.operationType = _TYPE;
                        this.ucSupplyUnit.InitEditControl(_supplyUnit);
                        SetEditMode(true);
                    }
                }
                else
                    MessageBox.Show("没有选择要修改的记录!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }

        }

        /// <summary>
        ///  新增或修改处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //this.ucSupplyUnit.checkcontrol();
                this.ucSupplyUnit.EndDatagridEdit();
                bool oldSupplyUnit = false;
                if (_supplyUnit != null)
                {
                    oldSupplyUnit = _supplyUnit.IsApproval;
                }
                SupplyUnit sUnit = this.ucSupplyUnit.InitSupplyUnit(_supplyUnit);
                if (sUnit == null)
                    return;
                string msg = string.Empty;
                if (_TYPE == OperateType.Add)
                {
                    msg = PharmacyDatabaseService.AddSupplyUnitApproveFlow(sUnit, this.ucSupplyUnit.FlowTypeID, AppClientContext.CurrentUser.Id, "新增供货商:" + sUnit.Name);
                    this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, "新增供货商:" + sUnit.Name);
                }
                else if (_TYPE == OperateType.Edit)
                {
                    if (oldSupplyUnit || sUnit.ApprovalStatusValue == 4) //审批通过或者审批被拒
                    {
                        sUnit.IsApproval = false;
                        sUnit.ApprovalStatus = ApprovalStatus.Waitting;
                        Guid typeid = sUnit.FlowID;
                        sUnit.FlowID = Guid.NewGuid();
                        msg = PharmacyDatabaseService.ModifySupplyUnitApproveFlow(sUnit, ucSupplyUnit.FlowTypeID, AppClientContext.CurrentUser.Id, "审批后修改:" + sUnit.Name);
                        this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, "审批后修改:" + sUnit.Name);
                    }
                    else//审批未结束,属于审批前修改,已经审批的节点不定,暂不做判断审核到哪一个节点.
                    {
                        msg = PharmacyDatabaseService.ModifySupplyUnitApproveFlow(sUnit, ucSupplyUnit.FlowTypeID, AppClientContext.CurrentUser.Id, "审批前修改:" + sUnit.Name);
                        this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, "审批前修改:" + sUnit.Name);
                    }
                }
                if (msg.Length == 0)
                    MessageBox.Show("数据保存成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Search();
                SetEditMode(false);
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetEditMode(false);
            //this.Close();
        }

        //设置列
        private void SetColumns()
        {
            this.dataGridView1.Columns.Add("Name", "单位名称");
            this.dataGridView1.Columns.Add("Code", "代码");
            this.dataGridView1.Columns.Add("PinyinCode", "拼音码");
            this.dataGridView1.Columns.Add("ContactName", "联系人");
            this.dataGridView1.Columns.Add("ContactTel", "联系电话");
            this.dataGridView1.Columns.Add("LegalPerson", "法人");
            this.dataGridView1.Columns.Add("BusinessScope", "生产经营范围");
            this.dataGridView1.Columns.Add("SalesAmount", "年销售额");
            this.dataGridView1.Columns.Add("Fax", "传真");
            this.dataGridView1.Columns.Add("Email", "邮箱");
            this.dataGridView1.Columns.Add("WebAddress", "网站");
            this.dataGridView1.Columns.Add("DetailedAddress", "详细地址");

            this.dataGridView1.Columns.Add("IsOutDate", "是否过期");
            this.dataGridView1.Columns.Add("OutDate", "过期日");
            this.dataGridView1.Columns.Add("SupplyProductClass", "拟供品种");
            this.dataGridView1.Columns.Add("QualityCharger", "质量负责人");
            this.dataGridView1.Columns.Add("BankAccount", "银行帐号");
            this.dataGridView1.Columns.Add("Valid", "是否有效");
            this.dataGridView1.Columns.Add("IsApproval", "是否审批通过");
            this.dataGridView1.Columns.Add("IsLock", "人为锁定");

            this.dataGridView1.Columns.Add("UnitType", "企业类型");

            this.dataGridView1.Columns.Add("LastAnnualDte", "最新年检日期");
            this.dataGridView1.Columns.Add("IsQualityAgreementOut", "质量协议书是否过期");
            this.dataGridView1.Columns.Add("QualityAgreementOutdate", "质量协议书有效期止");
            this.dataGridView1.Columns.Add("IsAttorneyAattorneyOut", "法人委托书是否过期");
            this.dataGridView1.Columns.Add("AttorneyAattorneyOutdate", "法人委托书有效期止");
            #region 资质
            this.dataGridView1.Columns.Add("GSPLC", "药品经营许可证");
            this.dataGridView1.Columns.Add("GMPLC", "GMP证书");
            this.dataGridView1.Columns.Add("BusinessLC", "营业执照");
            this.dataGridView1.Columns.Add("MedicineProductionLC", "药品生产许可证");
            this.dataGridView1.Columns.Add("MedicineBusinessLC", "GSP证书");
            this.dataGridView1.Columns.Add("InstrumentsProductionLC", "器械生产许可证");
            this.dataGridView1.Columns.Add("InstrumentsBusinessLC", "器械经营许可证");
            this.dataGridView1.Columns.Add("HealthLC", "卫生许可证");
            this.dataGridView1.Columns.Add("TaxRegisterLC", "税务登记证");
            this.dataGridView1.Columns.Add("OrganizationCodeLC", "组织机构代码证");
            this.dataGridView1.Columns.Add("FoodCirculateLC", "食品流通许可证");
            this.dataGridView1.Columns.Add("MmedicalInstitutionLC", "医疗机构执业许可证");
            this.dataGridView1.Columns.Add("LnstitutionLegalPersonLC", "事业单位法人证书");

            #endregion
            this.dataGridView1.Columns.Add("CreateDate", "创建日期");
            this.dataGridView1.Columns.Add("Creator", "创建人");

            foreach (DataGridViewColumn dc in this.dataGridView1.Columns)
            {
                dc.DataPropertyName = dc.Name;
            }
        }

        //查找
        private void GetListSupplyUnit(int pageIndex, int pageSize)
        {
            string msg = string.Empty;
            #region 查询实体
            QuerySupplyUnitModel qSupplyUnit = new QuerySupplyUnitModel();
            qSupplyUnit.ApprovalStatusValueFrom = 0;
            qSupplyUnit.ApprovalStatusValueTo = 9999;
            qSupplyUnit.AttorneyAattorneyOutdateFrom = DateTime.Now;
            qSupplyUnit.AttorneyAattorneyOutdateTo = DateTime.Now.AddDays(-1);
            qSupplyUnit.CreateTimeFrom = DateTime.Now;
            qSupplyUnit.CreateTimeTo = DateTime.Now.AddDays(-1);
            qSupplyUnit.OutDateFrom = DateTime.Now;
            qSupplyUnit.OutDateTo = DateTime.Now.AddDays(-1);
            qSupplyUnit.QualityAgreementOutdateFrom = DateTime.Now;
            qSupplyUnit.QualityAgreementOutdateTo = DateTime.Now.AddDays(-1);
            qSupplyUnit.UpdateTimeFrom = DateTime.Now;
            qSupplyUnit.UpdateTimeTo = DateTime.Now.AddDays(-1);
            qSupplyUnit.PinyinCode = textBoxPinyin.Text.Trim();
            qSupplyUnit.Name = txtSearchName.Text.Trim();
            qSupplyUnit.Code = txtSearchCode.Text.Trim();
            #endregion

            _listSupplyUnit = PharmacyDatabaseService.SearchPagedSupplyUnitsByQueryModel(out pageInfo, qSupplyUnit, this.pagerControl1.PageIndex, pageSize);
            var CmbItemId = ((UnitType)this.cmbUnitType.SelectedItem).Id;
            _listSupplyUnit = CmbItemId == Guid.Empty ? this._listSupplyUnit : this._listSupplyUnit.Where(r => r.UnitTypeId == (CmbItemId)).OrderBy(r => r.Name).ToList();

            if (CmbStatus.SelectedIndex > 0)
            {
                this._listSupplyUnit = this._listSupplyUnit.Where(r => r.Valid == (this.CmbStatus.SelectedIndex == 1)).ToList();
            }

            var c = from i in _listSupplyUnit
                    join j in _UnitType on i.UnitTypeId equals j.Id
                    join usr in this.ListUser on i.CreateUserId equals usr.Id into left
                    from l in left.DefaultIfEmpty()
                    select new bool2String
                    {
                        id = i.Id,
                        Name = i.Name,
                        Code = i.Code,
                        PinyinCode = i.PinyinCode,
                        ContactName = i.ContactName,
                        ContactTel = i.ContactTel,
                        LegalPerson = i.LegalPerson,
                        BusinessScope = i.BusinessScope,
                        SalesAmount = i.SalesAmount,
                        Fax = i.Fax,
                        Email = i.Email,
                        WebAddress = i.WebAddress,
                        DetailedAddress = i.DetailedAddress,
                        IsOutDate = i.IsOutDate ? "已过期" : "未过期",
                        SupplyProductClass = i.SupplyProductClass,
                        QualityCharger = i.QualityCharger,
                        BankAccount = i.Bank,
                        Valid = i.Valid ? "有效" : "无效",
                        IsApproval = i.IsApproval ? "通过审核" : "未通过审核",
                        IsLock = i.IsLock ? "被锁定" : "未锁定",
                        UnitType = j.Name,
                        LastAnnualDte = i.LastAnnualDte.Date,
                        IsQualityAgreementOut = i.IsQualityAgreementOut ? "已过期" : "未过期",
                        QualityAgreementOutdate = i.QualityAgreementOutdate.Date,
                        IsAttorneyAattorneyOut = i.IsAttorneyAattorneyOut ? "已过期" : "未过期",
                        AttorneyAattorneyOutdate = i.AttorneyAattorneyOutdate,
                        CreateDate = i.CreateTime.ToLongDateString(),
                        Creator = l == null ? "无创建信息" : l.Employee.Name,
                        ApprovalFlowId = i.FlowID,
                        SupplyCateGory = i.SupplyProductClass,
                        DelegateContent = i.AttorneyAattorneyDetail,
                        QualityAgreement = i.QualityAgreementDetail,
                        #region 资质
                        GSPLC = i.GSPLicenseId == Guid.Empty ? "无" : i.GSPLicenseOutDate.ToLongDateString(),
                        GSPLCID = i.GSPLicenseId,
                        GMPLC = i.GMPLicenseId == Guid.Empty ? "无" : i.GMPLicenseOutDate.ToLongDateString(),
                        GMPLCID = i.GMPLicenseId,
                        BusinessLC = i.BusinessLicenseId == Guid.Empty ? "无" : i.BusinessLicenseeOutDate.ToLongDateString(),
                        BusinessLCID = i.BusinessLicenseId,
                        MedicineProductionLC = i.MedicineProductionLicenseId == Guid.Empty ? "无" : i.MedicineProductionLicenseOutDate.ToLongDateString(),
                        MedicineProductionLCID = i.MedicineProductionLicenseId,
                        MedicineBusinessLC = i.MedicineBusinessLicenseId == Guid.Empty ? "无" : i.MedicineBusinessLicenseOutDate.ToLongDateString(),
                        MedicineBusinessLCID = i.MedicineBusinessLicenseId,
                        InstrumentsProductionLC = i.InstrumentsProductionLicenseId == Guid.Empty ? "无" : i.InstrumentsProductionLicenseOutDate.ToLongDateString(),
                        InstrumentsProductionLCID = i.InstrumentsProductionLicenseId,
                        InstrumentsBusinessLC = i.InstrumentsBusinessLicenseId == Guid.Empty ? "无" : i.InstrumentsBusinessLicenseOutDate.ToLongDateString(),
                        InstrumentsBusinessLCID = i.InstrumentsBusinessLicenseId,
                        HealthLC = i.HealthLicenseId == Guid.Empty ? "无" : i.HealthLicenseOutDate.ToLongDateString(),
                        HealthLCID = i.HealthLicenseId,
                        TaxRegisterLC = i.TaxRegisterLicenseId == Guid.Empty ? "无" : i.TaxRegisterLicenseOutDate.ToLongDateString(),
                        TaxRegisterLCID = i.TaxRegisterLicenseId,
                        OrganizationCodeLC = i.OrganizationCodeLicenseId == Guid.Empty ? "无" : i.OrganizationCodeLicenseOutDate.ToLongDateString(),
                        OrganizationCodeLCID = i.OrganizationCodeLicenseId,
                        FoodCirculateLC = i.FoodCirculateLicenseId == Guid.Empty ? "无" : i.FoodCirculateLicenseOutDate.ToLongDateString(),
                        FoodCirculateLCID = i.FoodCirculateLicenseId,
                        MmedicalInstitutionLC = i.MmedicalInstitutionPermitId == Guid.Empty ? "无" : i.MmedicalInstitutionPermitOutDate.ToLongDateString(),
                        MmedicalInstitutionLCID = i.MmedicalInstitutionPermitId,
                        LnstitutionLegalPersonLC = i.LnstitutionLegalPersonLicenseId == Guid.Empty ? "无" : i.LnstitutionLegalPersonLicenseOutDate.ToLongDateString(),
                        LnstitutionLegalPersonLCID = i.LnstitutionLegalPersonLicenseId
                        #endregion
                    };

            this.dataGridView1.DataSource = new BindingCollection<bool2String>(c.ToList());
            tlbUnitCount.Text = "查询结果统计：现有" + this.cmbUnitType.Text + string.Format("{0}个供货商企业。", c.Count());
            tlbUnqualifiedUnit.Text = string.Format("其中有{0}个已过期；", this._listSupplyUnit.Where(r => r.IsOutDate).Count());
            tlbUnqualifiedUnit.Text += string.Format("有{0}个处于无效状态。", this._listSupplyUnit.Where(r => !r.Valid).Count());

            var n = this._listSupplyUnit.Where(r => r.OutDate > DateTime.Now.Date && r.OutDate <= DateTime.Now.Date.AddMonths(WarningDate));

            this.toolStripStatusLabel1.Text = string.Format("预警信息：有{0}个资质即将到期！双击查看详情", n.Count());

            this.toolStripStatusLabel1.Click -= delegate (object sender, EventArgs e)
            {
                this.GetSupplyUnitByNearExpired(n);
            };

            this.toolStripStatusLabel1.Click += delegate (object sender, EventArgs e)
            {
                this.GetSupplyUnitByNearExpired(n);
            };

            if (this.dataGridView1.Columns.Count > 1)
            {
                this.dataGridView1.Columns[0].Frozen = true;
                this.dataGridView1.Columns[1].Frozen = true;
            }
        }

        private void GetSupplyUnitByNearExpired(IEnumerable<SupplyUnit> NExpiredList)
        {
            Form_NearExpire frm = new Form_NearExpire(NExpiredList);
            frm.Text = "供货单位资质近效期预警列表，预警期" + this.WarningDate.ToString() + "个月";
            frm.WarningDate = this.WarningDate;
            frm.ShowDialog();
        }

        private void pagerControl1_DataPaging()
        {
            //Search();
            try
            {
                GetListSupplyUnit(1, pageSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "获取供应商信息失败！", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }
        private void Search()
        {
            try
            {
                _TYPE = OperateType.Browse;
                //SetEditMode(false);
                GetListSupplyUnit(1, pageSize);
                pagerControl1.RecordCount = pageInfo.RecordCount;
                pagerControl1.PageIndex = 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }
        private void FormSupplyUnit_Load(object sender, EventArgs e)
        {
            try
            {
                this.KeyPreview = true;

                SetMode(_TYPE);
                if (_TYPE == OperateType.Add)
                {
                    SetEditMode(true);
                    this.ucSupplyUnit.ClearControl();
                    _supplyUnit = null;
                    this.ucSupplyUnit.InitEditControl(_supplyUnit);
                }
                else if (_TYPE == OperateType.Edit)
                {
                    this.ucSupplyUnit.InitEditControl(_supplyUnit);
                    SetEditMode(true);
                }
                else
                {
                    //SetEditMode(false);
                    //_serachName = txtSearchName.Text.Trim();
                    //_searchCode = txtSearchCode.Text.Trim();
                    //GetListSupplyUnit(1, pageSize);
                    //pagerControl1.RecordCount = pageInfo.RecordCount;
                    //pagerControl1.PageIndex = 1;  
                    SetEditMode(false);
                    SetMode(OperateType.Browse);
                    btnRefresh_Click(this, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "APPROVE")
            {
                var u = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as bool2String;
                SupplyUnit su = this.PharmacyDatabaseService.GetSupplyUnit(out msg, u.id);
                FormApprovalFlowCenter form = new FormApprovalFlowCenter(null, su.FlowID, false);
                form.ShowDialog();
            }
        }

        private string UpdateFormTitle(OperateType operTyper)
        {
            string title = string.Empty;
            if (operTyper == OperateType.Add)
                title = "首营企业录入";
            else if (operTyper == OperateType.Browse || operTyper == OperateType.Search)
            {
                title = "供货商查询";
            }
            else if (operTyper == OperateType.Edit)
            {
                title = "供货商编辑";
            }
            return title;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucSupplyUnit_Load(object sender, EventArgs e)
        {
            this.textBoxUserName.Text = AppClientContext.currentUser.Employee.Name;
            this.textBoxTime.Text = DateTime.Now.Date.ToString();
        }

        private void textBoxPinyin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Search();
            }
        }

        #region 列头右键处理
        private void RightHeadMenu()
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
            if (this.dataGridView1.SelectedColumns.Count <= 0) return;
            if (op == 0)//关闭列
            {
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
        #endregion

        private void RightMenu()
        {
            ToolStripMenuItem tsmiR;
            ToolStripMenuItem tsmi;

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
            cms.Items.Add("查看审核详情", null, delegate (object sender, EventArgs e)
            {
                if (this.dataGridView1.CurrentRow.Index < 0) return;
                if (this.dataGridView1.SelectedRows.Count <= 0) return;
                var u = this.dataGridView1.SelectedRows[0].DataBoundItem as bool2String;
                SupplyUnit su = this.PharmacyDatabaseService.GetSupplyUnit(out msg, u.id);
                FormApprovalFlowCenter form = new FormApprovalFlowCenter(null, su.FlowID, false);
                form.ShowDialog();
            });
            cms.Items.Add("-");

            tsmiR = new ToolStripMenuItem("资质查看");
            tsmiR.Name = "资质查看";
            cms.Items.Add(tsmiR);
            cms.Items.Add("-");
            #region 资质查看
            tsmi = new ToolStripMenuItem("GSP证书", null, delegate (object sender, EventArgs e) { this.GetResource(0); });
            tsmiR.DropDownItems.Add(tsmi);
            tsmi = new ToolStripMenuItem("GMP证书", null, delegate (object sender, EventArgs e) { this.GetResource(1); });
            tsmiR.DropDownItems.Add(tsmi);
            tsmi = new ToolStripMenuItem("药品生产许可证", null, delegate (object sender, EventArgs e) { this.GetResource(2); });
            tsmiR.DropDownItems.Add(tsmi);
            tsmi = new ToolStripMenuItem("营业执照", null, delegate (object sender, EventArgs e) { this.GetResource(3); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("器械生产许可证", null, delegate (object sender, EventArgs e) { this.GetResource(4); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("器械经营许可证", null, delegate (object sender, EventArgs e) { this.GetResource(5); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("组织机构代码证", null, delegate (object sender, EventArgs e) { this.GetResource(6); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("卫生许可证", null, delegate (object sender, EventArgs e) { this.GetResource(7); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("事业单位法人证书", null, delegate (object sender, EventArgs e) { this.GetResource(8); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("税务登记证", null, delegate (object sender, EventArgs e) { this.GetResource(9); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("食品流通许可证", null, delegate (object sender, EventArgs e) { this.GetResource(10); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("品种许可范围", null, delegate (object sender, EventArgs e) { this.GetResource(11); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("医疗机构执业许可证", null, delegate (object sender, EventArgs e) { this.GetResource(12); });
            tsmiR.DropDownItems.Add(tsmi);
            #endregion
            cms.Items.Add("查看供货单位信息", null, delegate (object sender, EventArgs e)
            {
                if (this.dataGridView1.SelectedRows.Count <= 0) return;
                var u = this.dataGridView1.SelectedRows[0].DataBoundItem as bool2String;
                SupplyUnit su = this.PharmacyDatabaseService.GetSupplyUnit(out msg, u.id);
                UserControls.ucSupplyUnit us = new UserControls.ucSupplyUnit(su, false);
                Form f = new Form();
                f.Text = su.Name;
                f.AutoSize = true;
                f.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                Panel p = new Panel();
                p.AutoSize = true;
                p.Controls.Add(us);
                f.Controls.Add(p);
                f.ShowDialog();
            });
            cms.Items.Add("-");
            cms.Items.Add("修改本供货单位信息", null, this.btnModify_Click);
            cms.Items.Add("-");
            cms.Items.Add("导出EXCEL表格", null, toolStripButton2_Click);
            cms.Items.Add("-");
            cms.Items.Add("刷新列表", null, this.btnRefresh_Click);
            cms.Items.Add("-");
            cms.Items.Add("导出审批表(WORD)", null, delegate (object sender, EventArgs e) { this.ExportToWord(); });
        }
        private void GetResource(int i)
        {
            bool2String b = this.dataGridView1.SelectedRows[0].DataBoundItem as bool2String;
            SupplyUnit su = _listSupplyUnit.Where(r => r.Id == b.id).FirstOrDefault();
            switch (i)
            {
                case 0:
                    FormMedicineBusinessLicense FormMedicineBusinessLicense = new FormMedicineBusinessLicense(su.MedicineBusinessLicenseId, true);
                    SetControls.SetControlReadonly(FormMedicineBusinessLicense, true);
                    FormMedicineBusinessLicense.ShowDialog();
                    break;
                case 1:
                    FormGMPLicense FormGMPLiscense = new FormGMPLicense(su.GMPLicenseId, string.Empty, string.Empty, true);
                    SetControls.SetControlReadonly(FormGMPLiscense, true);
                    FormGMPLiscense.ShowDialog();
                    break;
                case 2:
                    FormMedicineProductionLicense FormMedicineProductionLicense = new FormMedicineProductionLicense(su.MedicineProductionLicenseId, true);
                    SetControls.SetControlReadonly(FormMedicineProductionLicense, true);
                    FormMedicineProductionLicense.ShowDialog();
                    break;
                case 3:
                    FormBusinessLicense FormBusinessLicense = new FormBusinessLicense(su.BusinessLicenseId, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormBusinessLicense, true);
                    FormBusinessLicense.ShowDialog();
                    break;
                case 4:
                    FormInstrumentsProductionLicense FormInstrumentsProductionLicense = new FormInstrumentsProductionLicense(su.InstrumentsProductionLicenseId, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormInstrumentsProductionLicense, true);
                    FormInstrumentsProductionLicense.ShowDialog();
                    break;
                case 5:
                    FormInstrumentsBusinessLicense FormInstrumentsBusinessLicense = new FormInstrumentsBusinessLicense(su.InstrumentsBusinessLicenseId, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormInstrumentsBusinessLicense, true);
                    FormInstrumentsBusinessLicense.ShowDialog();
                    break;
                case 6:
                    FormOrganizationCodeLicense FormOrganizationCodeLicense = new FormOrganizationCodeLicense(su.OrganizationCodeLicenseId, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormOrganizationCodeLicense, true);
                    FormOrganizationCodeLicense.ShowDialog();
                    break;
                case 7:
                    FormHealthLicense FormHealthLicense = new FormHealthLicense(su.HealthLicenseId, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormHealthLicense, true);
                    FormHealthLicense.ShowDialog();
                    break;
                case 8:
                    LnstitutionLegalPersonLicense LegalPersonLicense = new LnstitutionLegalPersonLicense();
                    LegalPersonLicense.Id = su.LnstitutionLegalPersonLicenseId;
                    FormLegalPersonLicense FormLegalPersonLicense = new FormLegalPersonLicense(LegalPersonLicense, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormLegalPersonLicense, true);
                    FormLegalPersonLicense.ShowDialog();
                    break;
                case 9:
                    FormTaxRegisterLicense FormTaxRegisterLicense = new FormTaxRegisterLicense(su.TaxRegisterLicenseId, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormTaxRegisterLicense, true);
                    FormTaxRegisterLicense.ShowDialog();
                    break;
                case 10:
                    FormFoodCirculateLicense FormFoodCirculateLicense = new FormFoodCirculateLicense(su.FoodCirculateLicenseId, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormFoodCirculateLicense, true);
                    FormFoodCirculateLicense.ShowDialog();
                    break;
                case 11:
                    FormGSPLicense FormGSPLicense = new FormGSPLicense(su.GSPLicenseId, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormGSPLicense, true);
                    FormGSPLicense.ShowDialog();
                    break;
                case 12:
                    MmedicalInstitutionPermit InstitutionPermit = new MmedicalInstitutionPermit();
                    InstitutionPermit.Id = su.MmedicalInstitutionPermitId;
                    FormMmedicalInstitutionPermit FormMmedicalInstitutionPermit = new FormMmedicalInstitutionPermit(InstitutionPermit, string.Empty, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormMmedicalInstitutionPermit, true);
                    FormMmedicalInstitutionPermit.ShowDialog();
                    break;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
            if (e.RowIndex >= 0)//非列头右键菜单
            {
                dataGridView1.ClearSelection();
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (e.RowIndex < 0) return;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                var c = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as bool2String;
                dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                SupplyUnit su = this._listSupplyUnit.Where(r => r.Id == c.id).FirstOrDefault();
                if (su == null) return;
                ToolStripMenuItem ti = cms.Items["资质查看"] as ToolStripMenuItem;
                ti.DropDownItems[0].Enabled = !Guid.Empty.Equals(su.MedicineBusinessLicenseId);
                ti.DropDownItems[1].Enabled = !Guid.Empty.Equals(su.GMPLicenseId);
                ti.DropDownItems[2].Enabled = !Guid.Empty.Equals(su.MedicineProductionLicenseId);
                ti.DropDownItems[3].Enabled = !Guid.Empty.Equals(su.BusinessLicenseId);
                ti.DropDownItems[4].Enabled = !Guid.Empty.Equals(su.InstrumentsProductionLicenseId);
                ti.DropDownItems[5].Enabled = !Guid.Empty.Equals(su.InstrumentsBusinessLicenseId);
                ti.DropDownItems[6].Enabled = !Guid.Empty.Equals(su.OrganizationCodeLicenseId);
                ti.DropDownItems[7].Enabled = !Guid.Empty.Equals(su.HealthLicenseId);
                ti.DropDownItems[8].Enabled = !Guid.Empty.Equals(su.LnstitutionLegalPersonLicenseId);
                ti.DropDownItems[9].Enabled = !Guid.Empty.Equals(su.TaxRegisterLicenseId);
                ti.DropDownItems[10].Enabled = !Guid.Empty.Equals(su.FoodCirculateLicenseId);
                ti.DropDownItems[11].Enabled = !Guid.Empty.Equals(su.GSPLicenseId);
                ti.DropDownItems[12].Enabled = !Guid.Empty.Equals(su.MmedicalInstitutionPermitId);

                cms.Show(MousePosition.X, MousePosition.Y);
            }
            if (e.ColumnIndex >= 0 && e.RowIndex < 0)//列头右键菜单
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Columns[this.APPROVE.Name].Visible = false;
            try
            {
                MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "供货商查询结果");
            }
            catch (Exception ex)
            {
                this.dataGridView1.Columns[this.APPROVE.Name].Visible = true;
            }
            finally
            {
                this.dataGridView1.Columns[this.APPROVE.Name].Visible = true;
            }
        }

        private void ExportToWord()
        {
            var u = this.dataGridView1.SelectedRows[0].DataBoundItem as bool2String;
            byte[] b = this.PharmacyDatabaseService.GetUpdateFiles("ApprovalFiles\\供货单位.doc").FirstOrDefault().bytes;

            using (System.IO.FileStream fs = new System.IO.FileStream("File", System.IO.FileMode.OpenOrCreate))
            {
                fs.Write(b, 0, b.Length);
                fs.Close();
                CreateWinWord cww = new CreateWinWord();
                cww.b = u;

                cww.ListUsers = this.ListUser;
                if (cww.CreateWord(fs.Name, u.Name, 0))
                {
                    MessageBox.Show(u.Name + "：审批信息表导出成功！");
                    this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "导出首营供货企业信息审批表成功！品种名称：" + u.Name);
                }
                else
                {
                    this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "导出首营供货企业信息审批表失败！品种名称：" + u.Name);
                }
                fs.Dispose();
            }
        }

        private void InitcmbUnitType()
        {
            string msg = string.Empty;
            _ListUnitType = PharmacyDatabaseService.AllUnitTypes(out msg).ToList();
            _ListUnitType = _ListUnitType.Where(d => d.Name == "经营企业" || d.Name == "生产企业").ToList();
            this._ListUnitType.Insert(0, new UnitType { Name = "全部", Id = Guid.Empty });
            this.cmbUnitType.DataSource = _ListUnitType;
            this.cmbUnitType.DisplayMember = "Name";
            this.cmbUnitType.ValueMember = "Id";
            this.cmbUnitType.SelectedIndex = 0;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var c = SerialFile.csf;
            c.o.WarningDate = int.Parse(this.toolStripComboBox1.ComboBox.SelectedItem.ToString());
            SerialFile.SaveFile();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            btnModify_Click(null, null);
        }
    }

    public class bool2String
    {
        #region 基础信息
        public Guid id { get; set; }
        public string Name { get; set; }
        public string PinyinCode { get; set; }
        public string Code { get; set; }
        public string ContactName { get; set; }
        public string ContactTel { get; set; }
        public string LegalPerson { get; set; }
        public string BusinessScope { get; set; }

        public string SalesAmount { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string WebAddress { get; set; }
        public string DetailedAddress { get; set; }

        public string IsOutDate { get; set; }

        public string SupplyProductClass { get; set; }
        public string QualityCharger { get; set; }
        public string BankAccount { get; set; }
        public string Valid { get; set; }
        public string IsApproval { get; set; }

        public Guid ApprovalFlowId { get; set; }

        public string UnitType { get; set; }
        public string IsQualityAgreementOut { get; set; }
        public DateTime QualityAgreementOutdate { get; set; }
        public string IsAttorneyAattorneyOut { get; set; }
        public DateTime AttorneyAattorneyOutdate { get; set; }
        public DateTime LastAnnualDte { get; set; }
        public string IsLock { get; set; }
        public string CreateDate { get; set; }
        public string Creator { get; set; }

        public string SupplyCateGory { get; set; }

        public string DelegateContent { get; set; }
        public string QualityAgreement { get; set; }

        #endregion

        #region 资质
        public string GSPLC { get; set; }//药品经营许可证
        public Guid GSPLCID;

        public string GMPLC { get; set; }//GMP证书
        public Guid GMPLCID;

        public string BusinessLC { get; set; }//营业执照
        public Guid BusinessLCID;

        public string MedicineProductionLC { get; set; }//药品生产许可证
        public Guid MedicineProductionLCID;

        public string MedicineBusinessLC { get; set; }//GSP证书
        public Guid MedicineBusinessLCID;

        public string InstrumentsProductionLC { get; set; }//器械生产许可证
        public Guid InstrumentsProductionLCID;

        public string InstrumentsBusinessLC { get; set; }//器械经营许可证
        public Guid InstrumentsBusinessLCID;

        public string HealthLC { get; set; }//卫生许可证
        public Guid HealthLCID;

        public string TaxRegisterLC { get; set; }//税务登记证
        public Guid TaxRegisterLCID;

        public string OrganizationCodeLC { get; set; }//组织机构代码证
        public Guid OrganizationCodeLCID;

        public string FoodCirculateLC { get; set; }//食品流通许可证
        public Guid FoodCirculateLCID;

        public string MmedicalInstitutionLC { get; set; }//医疗机构执业许可证
        public Guid MmedicalInstitutionLCID;

        public string LnstitutionLegalPersonLC { get; set; }//事业单位法人证书
        public Guid LnstitutionLegalPersonLCID;
        #endregion
    }
}
