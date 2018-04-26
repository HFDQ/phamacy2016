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
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Service.Models;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.UI.Forms.Approval;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormPurchaseUnit : BaseFunctionForm  //Form
    {
        private PurchaseUnit entity = new PurchaseUnit();
        Guid selectId = Guid.Empty;

        private PagerInfo pageInfo = new PagerInfo();
        private IList<PurchaseUnit> _listPurchaseUnit = new List<PurchaseUnit>();
        private string _serachName = string.Empty;
        private string _searchCode = string.Empty;

        private Dictionary<Guid, string> dicBussnessType = new Dictionary<Guid, string>();
        private Dictionary<Guid, string> dicDistrict = new Dictionary<Guid, string>();
        private Dictionary<string, List<ListItem>> _InitFieldValues = new Dictionary<string, List<ListItem>>();
        private OperateType _TYPE = OperateType.Browse;
        string msg = string.Empty;
        private ContextMenuStrip cms = new ContextMenuStrip();
        ContextMenuStrip cmsColHead = new ContextMenuStrip();//列头菜单对象
        List<string> ListColHeadText = new List<string>();  //记录被隐藏列头文字

        private List<User> ListUser = new List<User>();
        private List<District> ListDistrict = new List<District>();
        private int pageSize = 9999;
        public List<UnitType> _ListUnitType = new List<UnitType>();

        /// <summary>
        /// 预警数据
        /// </summary>
        int WarningDate = SerialFile.csf.o.PurchaseWarningDate;
        public FormPurchaseUnit(object operateType):this()
        {
            _TYPE = (OperateType)Convert.ToInt16(operateType);            
            this.ucPurchaseUnit1.operationType = _TYPE;
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
                    btnModify.Visible = true;
                    btnModify.Enabled = true;
                    break;
            }
        }

        public FormPurchaseUnit(OperateType operateType, PurchaseUnit pu):this()
        {
            _TYPE = operateType;
            this.ucPurchaseUnit1.operationType = _TYPE;
            this.Text = UpdateFormTitle(_TYPE);
            this.entity = pu;
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
                    btnAdd.Visible = true;
                    btnModify.Visible = true;
                    btnModify.Enabled = true;
                    break;
            }
        }

        public FormPurchaseUnit()
        {
            InitializeComponent();
            this.SetColumnDictionary();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            this.RightMenu();
            this.RightHeadMenu();
            this.ListUser = this.PharmacyDatabaseService.AllUsers(out msg).ToList();
            this.ListDistrict = this.PharmacyDatabaseService.AllDistricts(out msg).ToList();
            InitcmbUnitType();
            this.CmbStatus.SelectedIndex = 0;
            this.toolStripComboBox1.ComboBox.SelectedItem = this.WarningDate.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                _TYPE = OperateType.Browse;

                _serachName = txtSearchName.Text.Trim();
                _searchCode = txtSearchCode.Text.Trim();

                GetListPurchaseUnit(this.pagerControl1.PageIndex, pageSize);
            
                pagerControl1.RecordCount = pageInfo.RecordCount;
            }
            catch (Exception ex)
            {

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
            btnAdd.Visible = !isEdit;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();         
        }

        private void Search()
        {
            try
            {
                _TYPE = OperateType.Browse;
                GetListPurchaseUnit(1, pageSize);
                pagerControl1.RecordCount = pageInfo.RecordCount;
                pagerControl1.PageIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _TYPE = OperateType.Add;
                SetEditMode(true);
                entity = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _TYPE = OperateType.Delete;
            if (MessageBox.Show("确定要删除吗？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    //执行删除操作
                    int currRowIndex = dataGridView1.CurrentRow.Cells[0].RowIndex;
                    entity = _listPurchaseUnit[currRowIndex];
                   // selectId = (Guid)dataGridView1.CurrentRow.Cells["Id"].Value;
                    string msg = string.Empty;
                    PharmacyDatabaseService.DeletePurchaseUnit(out msg, entity.Id);
                    SetEditMode(false);
                   

                }
                else
                    MessageBox.Show("没有选择要删除的记录!");
            }

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string msg=string.Empty;
            try
            {
                _TYPE = OperateType.Edit;
                if (dataGridView1.CurrentRow != null)
                {
                    Guid CurrentGid = (dataGridView1.CurrentRow.DataBoundItem as PurchaseUnitShow).Id;
                    entity = this.PharmacyDatabaseService.GetPurchaseUnit(out msg, CurrentGid);                  
                    if (entity.ApprovalStatusValue != 2 && entity.ApprovalStatusValue!=4)
                    {
                        if (MessageBox.Show("该记录尚未审批，是否确认修改？") == DialogResult.OK)
                        {
                            this.ucPurchaseUnit1.operationType = _TYPE;
                            DisplayTabPage(true);
                            this.ucPurchaseUnit1.InitEditControl(entity);
                            SetEditMode(true);
                        }
                    }
                    else
                        if (MessageBox.Show("该记录已审批，修改后需要审批，确认") == DialogResult.OK)
                        {
                            this.ucPurchaseUnit1.operationType = _TYPE;
                            this.ucPurchaseUnit1.InitEditControl(entity);
                            SetEditMode(true);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.ucPurchaseUnit1.EndDatagridEdit();
                bool oldSupplyUnit = false;
                if (entity != null)
                {
                    oldSupplyUnit = entity.IsApproval;//判断审批是否通过
                }
                PurchaseUnit sUnit = this.ucPurchaseUnit1.InitPurchaseUnit(entity);
                if (sUnit == null)
                    return;
                string msg = string.Empty;

                if (!ValidateControls(out msg))
                    return;

                if (_TYPE == OperateType.Add)
                {
                    msg = PharmacyDatabaseService.AddPurchaseUnitApproveFlow(sUnit, this.ucPurchaseUnit1.FlowTypeID, AppClientContext.CurrentUser.Id, "新增购货商:"+sUnit.Name);          
                }
                else if (_TYPE == OperateType.Edit)
                {
                    if (oldSupplyUnit||sUnit.ApprovalStatusValue==4)//如果是审批通过或者审批已结束但审批不通过
                    {
                        sUnit.IsApproval = false;
                        sUnit.ApprovalStatusValue = 1;
                        Guid typeid = sUnit.FlowID;
                        sUnit.FlowID = Guid.NewGuid();
                        msg = PharmacyDatabaseService.ModifyPurchaseUnitApproveFlow(sUnit, ucPurchaseUnit1.FlowTypeID, AppClientContext.CurrentUser.Id, "审批后修改:"+sUnit.Name);
                    }
                    else
                    {
                        msg = PharmacyDatabaseService.ModifyPurchaseUnitApproveFlow(sUnit, ucPurchaseUnit1.FlowTypeID, AppClientContext.CurrentUser.Id, "审批前修改:"+sUnit.Name);
                    }
                }
                if (msg.Length == 0)
                {
                    MessageBox.Show("数据保存成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnRefresh_Click(sender, e);
                }
                else
                {
                    MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Search();
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
            SetEditMode(false);
        }
        
        private void SaveData(bool isAdd)
        {
            try
            {
                #region                
                //entity.Name = this.txtName.Text.Trim();
                //entity.Code = this.txtCode.Text.Trim();
                //entity.PinyinCode = this.txtPinyinCode.Text.Trim();
                //entity.ContactName = this.txtContactName.Text.Trim();
                //entity.ContactTel = this.txtContactTel.Text.Trim();
                //entity.LegalPerson = this.txtLegalPerson.Text.Trim();
                //entity.BusinessScope = this.txtBusinessScope.Text.Trim();
                //entity.SalesAmount = this.txtSalesAmount.Text.Trim();
                //entity.Fax = this.txtFax.Text.Trim();
                //entity.Email = this.txtEmail.Text.Trim();
                //entity.WebAddress = this.txtWebAddress.Text.Trim();
                //// entity.BusinessTypeId = Guid.Parse(this.cmbBusinessType.SelectedValue.ToString());

                //entity.LastAnnualDte = this.dtpLastAnnualDte.Value;

                //entity.IsApproval = false;
               // //审批状态

               // if (this.cmpApproveStatus.SelectedIndex == 1)
               //     entity.IsApproval = true;
               // else
               //     entity.IsApproval = false;


               // entity.Enabled = this.ckEnable.Checked;
               // entity.GSPGMPLicCode = this.txtGSPGMPLicCode.Text.Trim();
               // entity.GSPGMPLicOutdate = this.dtpGSPLicOutdate.Value;
               // entity.PharmaceuticalTradingLicCode = this.txtPharmaceuticalTradingLicCode.Text.Trim();
               // entity.PharmaceuticalTradingLicOutdate = this.dtpPharmaceuticalTradingLicOutdate.Value;

               // entity.BusinessLicCode = txtBusinessLicCode.Text.Trim();
               // entity.BusinessLicOutdate = this.dtpBusinessLicOutdate.Value;
               // entity.TaxRegistrationCode = this.txtTaxRegistrationCode.Text.Trim();

               // string test = this.cmbDistrict.SelectedValue.ToString();

               // entity.DistrictId = Guid.Parse(this.cmbDistrict.SelectedValue.ToString());

                entity.UpdateUserId = AppClientContext.CurrentUser.Id;
                entity.UpdateTime = DateTime.Now;                

                #endregion

                string msg = string.Empty;
                if (isAdd)
                {
                    entity.Id = Guid.NewGuid();
                    entity.CreateTime = DateTime.Now;
                    entity.CreateUserId = AppClientContext.CurrentUser.Id;
                    PharmacyDatabaseService.AddPurchaseUnit(out msg, entity);

                }
                else
                {                    
                    PharmacyDatabaseService.SavePurchaseUnit(out msg, entity);
                }
                if (string.IsNullOrEmpty(msg))
                {
                    MessageBox.Show("数据保存成功!");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("数据保存失败!", "系统错误", MessageBoxButtons.OK);
            }

        }

        private void FormPurchaseUnit_Load(object sender, EventArgs e)
        {
            try
            {
                this.KeyPreview = true;

                this.textBoxUserName.Text = AppClientContext.currentUser.Employee.Name;
                this.textBoxTime.Text = DateTime.Now.Date.ToString();
                if (!this.DesignMode)
                {
                    SetMode(_TYPE);
                    if (_TYPE == OperateType.Add)
                    {
                        SetEditMode(true);
                        this.ucPurchaseUnit1.ClearControl();
                        entity = null;
                        this.ucPurchaseUnit1.InitEditControl(entity);
                    }
                    else if (_TYPE == OperateType.Edit)
                    {
                        this.ucPurchaseUnit1.InitEditControl(entity);
                        SetEditMode(true);
                    }
                    else
                    {
                        SetEditMode(false);
                        SetMode(OperateType.Browse);
                        btnRefresh_Click(this, null);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK);
            }
        }
      
        private void SetColumnDictionary()//显示列
        {
            this.dataGridView1.Columns.Add("Name", "单位名称");
            this.dataGridView1.Columns.Add("PinyinCode", "拼音码");
            this.dataGridView1.Columns.Add("Code", "代码");
            this.dataGridView1.Columns.Add("UnitType", "企业类型");
            this.dataGridView1.Columns.Add("IsApproval", "是否审批通过");
            this.dataGridView1.Columns.Add("Valid", "是否有效");
            this.dataGridView1.Columns.Add("IsOutDate", "是否过期");
            this.dataGridView1.Columns.Add("OutDate", "过期日");            
            this.dataGridView1.Columns.Add("ContactName", "联系人");
            this.dataGridView1.Columns.Add("ContactTel", "联系电话");
            this.dataGridView1.Columns.Add("DetailedAddress", "详细地址");
            this.dataGridView1.Columns.Add("LegalPerson", "法人");
            this.dataGridView1.Columns.Add("SalesAmount", "年销售额");
            this.dataGridView1.Columns.Add("Fax", "传真");
            this.dataGridView1.Columns.Add("Email", "邮箱");
            this.dataGridView1.Columns.Add("WebAddress", "网站");
            this.dataGridView1.Columns.Add("TaxRegistrationCode", "税务登记号");
            this.dataGridView1.Columns.Add("LastAnnualDte", "最新年检日期");

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
        
        //查询
        private void GetListPurchaseUnit(int pageIndex,int pageSize)
        {
            try
            {
                string msg = string.Empty;
                var queryPurchaseUnitModel = new QueryPurchaseUnitModel();
                queryPurchaseUnitModel.ApprovalStatusValueFrom = 0;
                queryPurchaseUnitModel.ApprovalStatusValueTo = 8;
                queryPurchaseUnitModel.Name = this.txtSearchName.Text.Trim();
                queryPurchaseUnitModel.Code = this.txtSearchCode.Text.Trim();
                queryPurchaseUnitModel.PinyinCode = textBoxPinyin.Text.Trim();
                this._listPurchaseUnit=PharmacyDatabaseService
                    .SearchPagedPurchaseUnitsByQueryModel(out pageInfo,
                    queryPurchaseUnitModel,
                    pageIndex,
                    pageSize);

                if (CmbStatus.SelectedIndex > 0)
                {
                    this._listPurchaseUnit = this._listPurchaseUnit.Where(r => r.Valid == (this.CmbStatus.SelectedIndex == 1)).ToList();
                }

                var UnitTypes = this._ListUnitType;

                if (((UnitType)cmbUnitType.SelectedItem).Id !=Guid.Empty)
                {
                    Guid uid=((UnitType)cmbUnitType.SelectedItem).Id;
                    UnitTypes = UnitTypes.Where(r => r.Id == uid).ToList();
                }

                var c = from i in this._listPurchaseUnit
                        join j in UnitTypes on i.UnitTypeId equals j.Id 
                        join u in ListUser on i.CreateUserId equals u.Id into left
                        from u in left.DefaultIfEmpty()
                        join d in ListDistrict on i.DistrictId equals d.Id into leftD
                        from d in leftD.DefaultIfEmpty()
                        select new PurchaseUnitShow
                        {
                            Id=i.Id,
                            BusinessScope=i.BusinessScope,
                            Code=i.Code,
                            ContactName=i.ContactName,
                            ContactTel=i.ContactTel,
                            Email=i.Email,
                            DetailedAddress=i.DetailedAddress,
                            ReceiveAddress=i.ReceiveAddress,
                            Fax=i.Fax,
                            IsApproval=i.IsApproval?"已通过审批":"未通过审批",
                            IsOutDate=i.IsOutDate?"已过期":"未过期",
                            LastAnnualDte=i.LastAnnualDte,
                            LegalPerson=i.LegalPerson,
                            Name=i.Name,
                            OutDate=i.OutDate,
                            PinyinCode=i.PinyinCode,
                            SalesAmount=i.SalesAmount,
                            TaxRegistrationCode=i.TaxRegistrationCode,
                            UnitType=j.Name,
                            Valid=i.Valid?"有效":"无效",
                            WebAddress=i.WebAddress,
                            CreateDate=i.CreateTime.ToLongDateString(),
                            Creator=u==null?string.Empty:u.Employee.Name,
                            District=d.Name,
                            QualityAgreement=i.QualityAgreementDetail,
                            DelegateContract=i.AttorneyAattorneyDetail,

                            #region 资质
                            GSPLC = i.GSPLicenseId == Guid.Empty ? "无" : i.GSPLicenseOutDate.ToLongDateString(),
                            GSPLCID=i.GSPLicenseId,
                            GMPLC = i.GMPLicenseId == Guid.Empty ? "无" : i.GMPLicenseOutDate.ToLongDateString(),
                            GMPLCID=i.GMPLicenseId,
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
                                
                this.dataGridView1.DataSource = c.ToList();//绑定列表

                tlbUnitCount.Text = "查询结果统计：现有" + this.cmbUnitType.Text + string.Format("{0}个客户企业。", this.dataGridView1.Rows.Count.ToString());
                tlbUnqualifiedUnit.Text = string.Format("其中有{0}个已过期；", c.Where(t => t.IsOutDate == "已过期").Count().ToString());
                tlbUnqualifiedUnit.Text += string.Format("有{0}个处于无效状态。", c.Where(t => t.Valid == "无效").Count().ToString());

                #region 近效预警提示
                var n = this._listPurchaseUnit.Where (r=>r.OutDate>DateTime.Now.Date && r.OutDate <= DateTime.Now.Date.AddMonths(WarningDate));
               
                this.toolStripStatusLabel1.Text = string.Format("预警信息：有{0}个资质即将到期！双击查看详情", n.Count());

                this.toolStripStatusLabel1.Click -= delegate(object sender, EventArgs e)
                {
                    this.GetPurchaseUnitByNearExpired(n);
                };

                this.toolStripStatusLabel1.Click += delegate(object sender, EventArgs e)
                {
                    this.GetPurchaseUnitByNearExpired(n);
                };
                #endregion

                if (this.dataGridView1.Columns.Count > 1)
                {
                    this.dataGridView1.Columns[0].Frozen = true;
                    this.dataGridView1.Columns[1].Frozen = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询操作异常","系统错误",MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void GetPurchaseUnitByNearExpired(IEnumerable<Models.PurchaseUnit> n)
        {
            Form_NearExpire frm = new Form_NearExpire(n,this.dataGridView1.DataSource as List<PurchaseUnitShow>);
            frm.WarningDate = this.WarningDate;
            frm.Text = "客户单位资质近效期预警列表，预警期" + this.WarningDate.ToString() + "个月";
            frm.ShowDialog();
        }
                
        private void pagerControl1_DataPaging()
        {
            try
            {
                int pageIndex = this.pagerControl1.PageIndex;
                //int pageSize = this.pagerControl1.PageSize;
                GetListPurchaseUnit(pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;//

            if (dataGridView1.Columns[e.ColumnIndex].Name == "APPROVE")
            {
                var u = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as PurchaseUnitShow;
                PurchaseUnit pu = this.PharmacyDatabaseService.GetPurchaseUnit(out msg, u.Id);
                FormApprovalFlowCenter form = new FormApprovalFlowCenter(null, pu.FlowID, false);
                form.ShowDialog();
            }
        }

        private string UpdateFormTitle(OperateType operTyper)
        {
            string title = string.Empty;
            if (operTyper == OperateType.Add)
                title = "首营客户录入";
            else if (operTyper == OperateType.Browse || operTyper == OperateType.Search)
            {
                title = "客户查询";
            }
            else if (operTyper == OperateType.Edit)
            {
                title = "客户编辑";
            }
            return title;
        }

        private void textBoxPinyin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Search();
            }
        }

        private void ucPurchaseUnit1_Load(object sender, EventArgs e)
        {

        }

        private void ucPurchaseUnit1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        #region 列头右键处理
        private void RightHeadMenu()
        {
            this.cmsColHead.Items.Add("冻结该列", null, delegate(object sender, EventArgs e) { this.ColOp(1); });
            this.cmsColHead.Items.Add("-");
            this.cmsColHead.Items.Add("解冻该列", null, delegate(object sender, EventArgs e) { this.ColOp(2); });
            this.cmsColHead.Items.Add("-");
            this.cmsColHead.Items.Add("关闭选中列", null, delegate(object sender, EventArgs e) { this.ColOp(0); });
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
            cms.Items.Add("自动列宽", null, delegate(object sender, EventArgs e)
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            });
            cms.Items.Add("取消自动列宽", null, delegate(object sender, EventArgs e)
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            });
            cms.Items.Add("-");
            cms.Items.Add("信息操作");
            cms.Items[cms.Items.Count - 1].Enabled = false;
            cms.Items.Add("-");
            cms.Items.Add("查看审核详情", null, delegate(object sender, EventArgs e)
            {
                if (this.dataGridView1.CurrentRow.Index < 0) return;
                PurchaseUnitShow ps=this.dataGridView1.CurrentRow.DataBoundItem as PurchaseUnitShow;
                PurchaseUnit pu = this._listPurchaseUnit.Where(r => r.Id == ps.Id).FirstOrDefault();
                if (pu == null) return;
                FormApprovalFlowCenter form = new FormApprovalFlowCenter(null, pu.FlowID, false);
                form.ShowDialog();
            });
            cms.Items.Add("-");

            tsmiR = new ToolStripMenuItem("资质查看");
            tsmiR.Name = "资质查看";
            cms.Items.Add(tsmiR);
            cms.Items.Add("-");
            #region 资质查看
            tsmi = new ToolStripMenuItem("GSP证书", null, delegate(object sender, EventArgs e) { this.GetResource(0); });
            tsmiR.DropDownItems.Add(tsmi);
            tsmi = new ToolStripMenuItem("GMP证书", null, delegate(object sender, EventArgs e) { this.GetResource(1); });
            tsmiR.DropDownItems.Add(tsmi);
            tsmi = new ToolStripMenuItem("药品生产许可证", null, delegate(object sender, EventArgs e) { this.GetResource(2); });
            tsmiR.DropDownItems.Add(tsmi);
            tsmi = new ToolStripMenuItem("营业执照", null, delegate(object sender, EventArgs e) { this.GetResource(3); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("器械生产许可证", null, delegate(object sender, EventArgs e) { this.GetResource(4); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("器械经营许可证", null, delegate(object sender, EventArgs e) { this.GetResource(5); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("组织机构代码证", null, delegate(object sender, EventArgs e) { this.GetResource(6); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("卫生许可证", null, delegate(object sender, EventArgs e) { this.GetResource(7); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("事业单位法人证书", null, delegate(object sender, EventArgs e) { this.GetResource(8); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("税务登记证", null, delegate(object sender, EventArgs e) { this.GetResource(9); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("食品流通许可证", null, delegate(object sender, EventArgs e) { this.GetResource(10); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("品种许可范围", null, delegate(object sender, EventArgs e) { this.GetResource(11); });
            tsmiR.DropDownItems.Add(tsmi);

            tsmi = new ToolStripMenuItem("医疗机构执业许可证", null, delegate(object sender, EventArgs e) { this.GetResource(12); });
            tsmiR.DropDownItems.Add(tsmi);
            #endregion
            cms.Items.Add("查看购货单位信息", null, delegate(object sender, EventArgs e)
            {
                PurchaseUnitShow ps = this.dataGridView1.CurrentRow.DataBoundItem as PurchaseUnitShow;
                PurchaseUnit pu = this.PharmacyDatabaseService.GetPurchaseUnit(out msg, ps.Id);
                if (pu == null) return;
                UserControls.ucPurchaseUnit us = new UserControls.ucPurchaseUnit(pu, false);
                Form f = new Form();
                f.Text = pu.Name;
                f.AutoSize = true;
                f.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                f.StartPosition = FormStartPosition.CenterScreen;
                Panel p = new Panel();
                p.AutoSize = true;
                p.Controls.Add(us);
                f.Controls.Add(p);
                f.ShowDialog();
            });
            cms.Items.Add("-");
            cms.Items.Add("修改购货单位信息", null, this.btnModify_Click);
            cms.Items.Add("-");
            cms.Items.Add("导出EXCEL表格", null, toolStripButton1_Click);
            cms.Items.Add("-");
            cms.Items.Add("刷新列表", null, this.btnRefresh_Click);
            cms.Items.Add("-");
            cms.Items.Add("导出审批表(WORD)", null, delegate(object sender, EventArgs e) { this.ExportToWord(); });
        }
        private void GetResource(int i)
        {
            PurchaseUnitShow ps = this.dataGridView1.CurrentRow.DataBoundItem as PurchaseUnitShow;
            PurchaseUnit pu = this._listPurchaseUnit.Where(r => r.Id == ps.Id).FirstOrDefault();
            if (pu == null) return;            
            switch (i)
            {
                case 0:
                    FormMedicineBusinessLicense FormMedicineBusinessLicense = new FormMedicineBusinessLicense(pu.MedicineBusinessLicenseId, true);
                    FormMedicineBusinessLicense.ShowDialog();
                    break;
                case 1:
                    FormGMPLicense frm = new FormGMPLicense(pu.GMPLicenseId, string.Empty, string.Empty, true);
                    frm.ShowDialog();
                    break;
                case 2:
                    FormMedicineProductionLicense FormMedicineProductionLicense = new FormMedicineProductionLicense(pu.MedicineProductionLicenseId, true);
                    SetControls.SetControlReadonly(FormMedicineProductionLicense, true);
                    FormMedicineProductionLicense.ShowDialog();
                    break;
                case 3:
                    FormBusinessLicense FormBusinessLicense = new FormBusinessLicense(pu.BusinessLicenseId, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormBusinessLicense, true);
                    FormBusinessLicense.ShowDialog();
                    break;
                case 4:
                    FormInstrumentsProductionLicense FormInstrumentsProductionLicense = new FormInstrumentsProductionLicense(pu.InstrumentsProductionLicenseId, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormInstrumentsProductionLicense, true);
                    FormInstrumentsProductionLicense.ShowDialog();
                    break;
                case 5:
                    FormInstrumentsBusinessLicense FormInstrumentsBusinessLicense = new FormInstrumentsBusinessLicense(pu.InstrumentsBusinessLicenseId, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormInstrumentsBusinessLicense, true);
                    FormInstrumentsBusinessLicense.ShowDialog();
                    break;
                case 6:
                    FormOrganizationCodeLicense FormOrganizationCodeLicense = new FormOrganizationCodeLicense(pu.OrganizationCodeLicenseId, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormOrganizationCodeLicense, true);
                    FormOrganizationCodeLicense.ShowDialog();
                    break;
                case 7:
                    FormHealthLicense FormHealthLicense = new FormHealthLicense(pu.HealthLicenseId, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormHealthLicense, true);
                    FormHealthLicense.ShowDialog();
                    break;
                case 8:
                    LnstitutionLegalPersonLicense LegalPersonLicense = new LnstitutionLegalPersonLicense();
                    LegalPersonLicense.Id = pu.LnstitutionLegalPersonLicenseId;
                    FormLegalPersonLicense FormLegalPersonLicense = new FormLegalPersonLicense(LegalPersonLicense, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormLegalPersonLicense, true);
                    FormLegalPersonLicense.ShowDialog();
                    break;
                case 9:
                    FormTaxRegisterLicense FormTaxRegisterLicense = new FormTaxRegisterLicense(pu.TaxRegisterLicenseId, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormTaxRegisterLicense, true);
                    FormTaxRegisterLicense.ShowDialog();
                    break;
                case 10:
                    FormFoodCirculateLicense FormFoodCirculateLicense = new FormFoodCirculateLicense(pu.FoodCirculateLicenseId, string.Empty, string.Empty, string.Empty);
                    SetControls.SetControlReadonly(FormFoodCirculateLicense, true);
                    FormFoodCirculateLicense.ShowDialog();
                    break;
                case 11:
                    FormGSPLicense FormGSPLicense = new FormGSPLicense(pu.GSPLicenseId, string.Empty, string.Empty, string.Empty, string.Empty,string.Empty);
                    SetControls.SetControlReadonly(FormGSPLicense, true);
                    FormGSPLicense.ShowDialog();
                    break;
                case 12:
                    MmedicalInstitutionPermit InstitutionPermit = new MmedicalInstitutionPermit();
                    InstitutionPermit.Id = pu.MmedicalInstitutionPermitId;
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
                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var c = this.dataGridView1.Rows[e.RowIndex].DataBoundItem as PurchaseUnitShow;

                PurchaseUnit pu = this._listPurchaseUnit.Where(r => r.Id == c.Id).FirstOrDefault();
                if (pu == null) return;
                ToolStripMenuItem ti = cms.Items["资质查看"] as ToolStripMenuItem;
                ti.DropDownItems[0].Enabled = !Guid.Empty.Equals(pu.MedicineBusinessLicenseId);
                ti.DropDownItems[1].Enabled = !Guid.Empty.Equals(pu.GMPLicenseId);
                ti.DropDownItems[2].Enabled = !Guid.Empty.Equals(pu.MedicineProductionLicenseId);
                ti.DropDownItems[3].Enabled = !Guid.Empty.Equals(pu.BusinessLicenseId);
                ti.DropDownItems[4].Enabled = !Guid.Empty.Equals(pu.InstrumentsProductionLicenseId);
                ti.DropDownItems[5].Enabled = !Guid.Empty.Equals(pu.InstrumentsBusinessLicenseId);
                ti.DropDownItems[6].Enabled = !Guid.Empty.Equals(pu.OrganizationCodeLicenseId);
                ti.DropDownItems[7].Enabled = !Guid.Empty.Equals(pu.HealthLicenseId);
                ti.DropDownItems[8].Enabled = !Guid.Empty.Equals(pu.LnstitutionLegalPersonLicenseId);
                ti.DropDownItems[9].Enabled = !Guid.Empty.Equals(pu.TaxRegisterLicenseId);
                ti.DropDownItems[10].Enabled = !Guid.Empty.Equals(pu.FoodCirculateLicenseId);
                ti.DropDownItems[11].Enabled = !Guid.Empty.Equals(pu.GSPLicenseId);
                ti.DropDownItems[12].Enabled = !Guid.Empty.Equals(pu.MmedicalInstitutionPermitId);

                cms.Show(MousePosition.X, MousePosition.Y);
            }
            if (e.ColumnIndex >=0 && e.RowIndex<0)//列头右键菜单
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
                    tsmi.DropDownItems.Add("显示全部列", null, delegate(object o, EventArgs ex)
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
                        tsmi.DropDownItems.Add(s, null, delegate(object o, EventArgs ex)
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Columns[this.APPROVE.Name].Visible = false;
            try
            {
                MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "够或单位查询结果");
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
            var u = this.dataGridView1.SelectedRows[0].DataBoundItem as PurchaseUnitShow;
            byte[] b = this.PharmacyDatabaseService.GetUpdateFiles("ApprovalFiles\\A0EAA274-889E-4B77-8C77-CC395FD991EF").FirstOrDefault().bytes;

            using (System.IO.FileStream fs = new System.IO.FileStream("File", System.IO.FileMode.OpenOrCreate))
            {
                fs.Write(b, 0, b.Length);
                fs.Close();
                CreateWinWord cww = new CreateWinWord();
                cww.p = u;
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
            _ListUnitType.Insert(0, new UnitType {  Name="全部",Id=Guid.Empty});
            this.cmbUnitType.DataSource = _ListUnitType.OrderBy(t=>t.Code).ToList();
            this.cmbUnitType.DisplayMember = "Name";
            this.cmbUnitType.ValueMember = "Id";
            this.cmbUnitType.SelectedIndex = 0;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SerialFile.csf.o.PurchaseWarningDate = int.Parse(this.toolStripComboBox1.SelectedItem.ToString());
            SerialFile.SaveFile();
        }
    }

    //临时类（用于datagridview绑定）
    public class PurchaseUnitShow
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string PinyinCode { get; set; }
        public string ContactName { get; set; }
        public string ContactTel { get; set; }
        public string LegalPerson { get; set; }
        public string DetailedAddress { get; set; }
        public string BusinessScope { get; set; }
        public string SalesAmount { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string WebAddress { get; set; }
        public string IsOutDate { get; set; }
        public DateTime OutDate { get; set; }
        public string Valid { get; set; }
        public string TaxRegistrationCode { get; set; }
        public DateTime LastAnnualDte { get; set; }
        public string IsApproval { get; set; }
        public string UnitType { get; set; }
        public string CreateDate { get; set; }
        public string Creator { get; set; }
        public string District { get; set; }
        public string ReceiveAddress { get; set; }
        public string QualityAgreement { get; set; }
        public string DelegateContract { get; set; }

        #region 资质
        public string GSPLC { get; set; }//药品经营许可证
        public Guid GSPLCID { get; set; }
        public string GMPLC { get; set; }//GMP证书
        public Guid GMPLCID { get; set; }
        public string BusinessLC { get; set; }//营业执照
        public Guid BusinessLCID { get; set; }
        public string MedicineProductionLC { get; set; }//药品生产许可证
        public Guid MedicineProductionLCID { get; set; }
        public string MedicineBusinessLC { get; set; }//GSP证书
        public Guid MedicineBusinessLCID { get; set; }
        public string InstrumentsProductionLC { get; set; }//器械生产许可证
        public Guid InstrumentsProductionLCID { get; set; }
        public string InstrumentsBusinessLC { get; set; }//器械经营许可证
        public Guid InstrumentsBusinessLCID { get; set; }
        public string HealthLC { get; set; }//卫生许可证
        public Guid HealthLCID { get; set; }
        public string TaxRegisterLC { get; set; }//税务登记证
        public Guid TaxRegisterLCID { get; set; }
        public string OrganizationCodeLC { get; set; }//组织机构代码证
        public Guid OrganizationCodeLCID { get; set; }
        public string FoodCirculateLC { get; set; }//食品流通许可证
        public Guid FoodCirculateLCID { get; set; }
        public string MmedicalInstitutionLC { get; set; }//医疗机构执业许可证
        public Guid MmedicalInstitutionLCID { get; set; }
        public string LnstitutionLegalPersonLC { get; set; }//事业单位法人证书
        public Guid LnstitutionLegalPersonLCID { get; set; }
        #endregion
    }
}
