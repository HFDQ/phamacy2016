using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.AppClient.UI.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.UserControls
{
    public partial class ucGoodsInfo : BaseFunctionUserControl
    {

        private List<DrugInfo> _listDrugInfo = new List<DrugInfo>();
        private DrugInfo drugInfo = new DrugInfo();
        public OperateType operationType;
        private PagerInfo pageInfo = new PagerInfo();
        private string _searchKeyword = string.Empty;
        public List<DateTime> _outDateList = new List<DateTime>();
        public List<WarehouseZone> WarehouseZones = new List<WarehouseZone>();
        private GoodsAdditionalProperty _goodsAdd = null;
        public Guid FlowTypeID { get; set; }
        private string msg = string.Empty;
        System.IFormatProvider format = new System.Globalization.CultureInfo("zh-CN", true);

        public ucGoodsInfo(FormRunMode runMode)
        {
            InitializeComponent();
            //BindDrugInfo();
            if (!DesignMode)
            {
                this.RunMode = runMode;
            }
            DataReady = false;
            InitRequiredControl();
            //getDrugInfoCount();

        }

        public ucGoodsInfo()
            : this(FormRunMode.Add)
        {

        }

        public ucGoodsInfo(DrugInfo di, bool isFlowCenterBrowse = false)
        {
            InitializeComponent();
            string msg = string.Empty;
            drugInfo = di;
            operationType = OperateType.Browse;
            InitEditControl(drugInfo);
            SetControlIsEdit(false);
            InitRequiredControl();

            if (isFlowCenterBrowse)
            {
                foreach (System.Windows.Forms.Control c in this.Controls)
                {
                    c.Enabled = false;
                }
            }
        }
        public ucGoodsInfo(Guid flowID)
        {
            InitializeComponent();
            string msg = string.Empty;
            drugInfo = PharmacyDatabaseService.GetDrugInfoByFlowID(out msg, flowID);
            operationType = 0;
            InitEditControl(drugInfo);
            //InitData();
            SetControlIsEdit(false);
            InitRequiredControl();
        }
        #region 属性或字段


        [Browsable(false)]
        public GoodsAdditionalProperty GoodsAdditional
        {
            get { return _goodsAdd; }
            set { _goodsAdd = value; }
        }
        [Browsable(false)]
        public bool DataReady { get; private set; }

        private FormRunMode runMode;

        /// <summary>
        /// 窗口运行模式
        /// </summary>
        [Browsable(false)]
        public FormRunMode RunMode
        {
            get
            {
                return runMode;
            }
            set
            {
                runMode = value;
                if (runMode == FormRunMode.Add)
                {
                    this.Text = string.Format("{0}药物信息", "添加");
                }
                else if (runMode == FormRunMode.Edit)
                {
                    this.Text = string.Format("{0}药物信息", "编辑");
                }
                else if (runMode == FormRunMode.Browse)
                {
                    this.Text = string.Format("{0}药物信息", "查看");
                }
                this.Enabled = (runMode != FormRunMode.Browse);
            }
        }

        //private DrugInfo drugInfo;

        /// <summary>
        /// 当前药物信息
        /// </summary>
        [Browsable(false)]
        public DrugInfo DrugInfo
        {
            get { return drugInfo; }
            set
            {
                drugInfo = value;
                if (drugInfo == null) drugInfo = new Models.DrugInfo();
                InitData();
                InitControlsStatus();
                BindDrugInfo();
            }
        }


        #region 下拉用

        /// <summary>
        /// 商品类型
        /// comboBoxGoodsType
        /// </summary> 
        private List<ListItem> GoodsTypeList = null;

        /// <summary>
        /// 包装
        /// comboBoxPackage
        /// </summary>
        private List<PackagingUnit> PackagingUnits = null;

        /// <summary>
        /// 特殊管理类型
        /// comboBoxSpecialDrugCategoryCode
        /// </summary>
        private List<SpecialDrugCategory> SpecialDrugCategories = null;

        /// <summary>
        /// 存储方式
        /// comboBoxDrugStorageTypeCode
        /// </summary>
        private List<DictionaryStorageType> DictionaryStorageTypes = null;

        /// <summary>
        /// 经营范围
        /// comboBoxBusinessScopeCode
        /// </summary>
        private List<BusinessScope> BusinessScopes = null;

        /// <summary>
        /// 管理分类
        /// comboBoxPurchaseManageCategoryDetailCode
        /// </summary>
        private List<PurchaseManageCategoryDetail> PurchaseManageCategoryDetails = null;

        /// <summary>
        /// 药品分类
        /// comboBoxDrugCategoryCode
        /// </summary>
        private List<DrugCategory> DrugCategories = null;

        /// <summary>
        /// 医疗分类
        /// MedicalCategoryDetailCode
        /// </summary>
        private List<MedicalCategoryDetail> MedicalCategoryDetails = null;

        /// <summary>
        /// 临床分类
        /// comboBoxDrugClinicalCategoryCode
        /// </summary>
        private List<DrugClinicalCategory> DrugClinicalCategories = null;

        /// <summary>
        /// 自主分类
        /// comboBoxDictionaryUserDefinedTypeCode
        /// </summary>
        private List<DictionaryUserDefinedType> DictionaryUserDefinedTypes = null;

        /// <summary>
        /// 计量单位
        /// comboBoxDictionaryMeasurementUnitCode
        /// </summary>
        private List<DictionaryMeasurementUnit> DictionaryMeasurementUnits = null;

        /// <summary>
        /// 药品剂型
        /// comboBoxDictionaryDosageCode
        /// </summary>
        private List<DictionaryDosage> DictionaryDosages = null;

        /// <summary>
        /// 药品规格
        /// comboBoxDictionarySpecificationCode
        /// </summary>
        private List<DictionarySpecification> DictionarySpecifications = null;

        /// <summary>
        /// 拆零单位
        /// comboBoxDictionaryPiecemealUnitCode
        /// </summary>
        private List<DictionaryPiecemealUnit> DictionaryPiecemealUnits = null;

        ///// <summary>
        ///// 拆零规格
        ///// comboBoxDictionaryPiecemealUnitCode
        ///// </summary>
        //private List<DictionaryPiecemealUnit> DictionaryPiecemealUnits = null;

        /// <summary>
        /// 审批流程类型
        /// comboBoxFlowID
        /// </summary>
        private List<ApprovalFlowType> ApprovalFlowTypes = null;

        /// <summary>
        /// 仓库
        /// comboBoxWH
        /// </summary>
        private List<Warehouse> Warehouse = null;

        /// <summary>
        /// 仓库库区
        /// comboBoxWHZ
        /// </summary>
        private List<WarehouseZone> WarehouseZone = null;

        #endregion 下拉用

        #endregion 属性或字段

        #region 数据到控件

        /// <summary>
        /// 绑定所有字典到下拉
        /// </summary>
        private void BindDictionaries()
        {
            string msg = string.Empty;
            //商品类型  
            if (comboBoxGoodsType != null)
            {
                comboBoxGoodsType.DataSource = GoodsTypeList;
                comboBoxGoodsType.DisplayMember = "Name";
                comboBoxGoodsType.ValueMember = "ID";
                if (comboBoxGoodsType.Items.Count > 0)
                {
                    if (operationType == OperateType.Browse)
                    {
                        if (GoodsTypeList != null)
                            comboBoxGoodsType.SelectedIndex = drugInfo.GoodsTypeValue;
                    }
                    else
                        comboBoxGoodsType.SelectedIndex = 0;
                }

            }
            //包装 
            if (comboBoxPackage != null)
            {
                comboBoxPackage.DataSource = PackagingUnits;
                comboBoxPackage.DisplayMember = "Name";
                comboBoxPackage.ValueMember = "Name";
                if (comboBoxPackage.Items.Count > 0)
                {
                    if (operationType == OperateType.Browse)
                    {
                        PackagingUnit listitem = PackagingUnits.Where(d => d.Name == drugInfo.Package).FirstOrDefault();
                        if (listitem != null)
                            comboBoxPackage.SelectedItem = listitem;
                    }
                    else
                        comboBoxPackage.SelectedIndex = 0;
                }
            }
            //特殊管理类型
            if (SpecialDrugCategories != null)
            {
                comboBoxSpecialDrugCategoryCode.DataSource = SpecialDrugCategories;
                comboBoxSpecialDrugCategoryCode.DisplayMember = "Name";
                comboBoxSpecialDrugCategoryCode.ValueMember = "Name";
                if (comboBoxSpecialDrugCategoryCode.Items.Count > 0)
                {
                    if (operationType == OperateType.Browse)
                    {
                        SpecialDrugCategory listitem = SpecialDrugCategories.Where(d => drugInfo.SpecialDrugCategoryCode != null && d.Name.Contains(drugInfo.SpecialDrugCategoryCode)).FirstOrDefault();
                        if (listitem != null)
                            comboBoxSpecialDrugCategoryCode.SelectedItem = listitem;
                    }
                    else
                        comboBoxSpecialDrugCategoryCode.SelectedIndex = 0;
                }
            }
            //存储方式
            if (DictionaryStorageTypes != null)
            {
                comboBoxDrugStorageTypeCode.DataSource = DictionaryStorageTypes;
                comboBoxDrugStorageTypeCode.DisplayMember = "Name";
                comboBoxDrugStorageTypeCode.ValueMember = "Name";
                if (comboBoxDrugStorageTypeCode.Items.Count > 0)
                {
                    if (operationType == OperateType.Browse)
                    {
                        DictionaryStorageType listitem = DictionaryStorageTypes.Where(d => drugInfo.DrugStorageTypeCode != null && d.Name.Contains(drugInfo.DrugStorageTypeCode)).FirstOrDefault();
                        if (listitem != null)
                            comboBoxDrugStorageTypeCode.SelectedItem = listitem;
                    }
                    else
                    {
                        if (comboBoxDrugStorageTypeCode.Items.Count > 0)
                        {
                            comboBoxDrugStorageTypeCode.SelectedIndex = 0;
                        }
                    }
                }
            }
            //经营范围
            if (BusinessScopes != null)
            {
                comboBoxBusinessScopeCode.DataSource = BusinessScopes.OrderBy(r => r.Code).ToList();
                comboBoxBusinessScopeCode.DisplayMember = "Name";
                comboBoxBusinessScopeCode.ValueMember = "Name";
                if (comboBoxBusinessScopeCode.Items.Count > 0)
                {
                    if (operationType == OperateType.Browse)
                    {
                        BusinessScope listitem = BusinessScopes.Where(d => d.Name == drugInfo.BusinessScopeCode).FirstOrDefault();
                        if (listitem != null)
                            comboBoxBusinessScopeCode.SelectedItem = listitem;
                    }
                    else
                        comboBoxBusinessScopeCode.SelectedIndex = 0;
                }

            }
            //管理分类
            if (PurchaseManageCategoryDetails != null)
            {
                comboBoxPurchaseManageCategoryDetailCode.DataSource = PurchaseManageCategoryDetails;
                comboBoxPurchaseManageCategoryDetailCode.DisplayMember = "Name";
                comboBoxPurchaseManageCategoryDetailCode.ValueMember = "Name";
                if (comboBoxPurchaseManageCategoryDetailCode.Items.Count > 0)
                {
                    if (operationType == OperateType.Browse)
                    {
                        PurchaseManageCategoryDetail listitem = PurchaseManageCategoryDetails.Where(d => d.Name == drugInfo.PurchaseManageCategoryDetailCode).FirstOrDefault();
                        if (listitem != null)
                            comboBoxPurchaseManageCategoryDetailCode.SelectedItem = listitem;
                    }
                    else
                        comboBoxPurchaseManageCategoryDetailCode.SelectedIndex = 0;
                }
            }
            //药品分类
            if (DrugCategories != null)
            {
                comboBoxDrugCategoryCode.DataSource = DrugCategories;
                comboBoxDrugCategoryCode.DisplayMember = "Name";
                comboBoxDrugCategoryCode.ValueMember = "Name";
                if (comboBoxDrugCategoryCode.Items.Count > 0)
                {
                    if (operationType == OperateType.Browse)
                    {
                        DrugCategory listitem = DrugCategories.Where(d => d.Name == drugInfo.DrugCategoryCode).FirstOrDefault();
                        if (listitem != null)
                            comboBoxDrugCategoryCode.SelectedItem = listitem;
                    }
                    else
                        comboBoxDrugCategoryCode.SelectedIndex = 0;
                }
            }
            //医疗分类
            if (MedicalCategoryDetails != null)
            {
                comboBoxMedicalCategoryDetailCode.DataSource = MedicalCategoryDetails;
                comboBoxMedicalCategoryDetailCode.DisplayMember = "Name";
                comboBoxMedicalCategoryDetailCode.ValueMember = "Name";
                if (comboBoxMedicalCategoryDetailCode.Items.Count > 0)
                {
                    if (operationType == OperateType.Browse)
                    {
                        MedicalCategoryDetail listitem = MedicalCategoryDetails.Where(d => d.Name == drugInfo.MedicalCategoryDetailCode).FirstOrDefault();
                        if (listitem != null)
                            comboBoxMedicalCategoryDetailCode.SelectedItem = listitem;
                    }
                    else
                        comboBoxMedicalCategoryDetailCode.SelectedIndex = 0;
                }
            }
            //临床分类//2014-2
            if (DrugClinicalCategories != null)
            {
                comboBoxDrugClinicalCategoryCode.DataSource = DrugClinicalCategories;
                comboBoxDrugClinicalCategoryCode.DisplayMember = "Name";
                comboBoxDrugClinicalCategoryCode.ValueMember = "Name";
                if (comboBoxDrugClinicalCategoryCode.Items.Count > 0)
                {
                    if (operationType == OperateType.Browse)
                    {
                        DrugClinicalCategory listitem = DrugClinicalCategories.Where(d => d.Name == drugInfo.DrugClinicalCategoryCode).FirstOrDefault();
                        if (listitem != null)
                            comboBoxDrugClinicalCategoryCode.SelectedItem = listitem;
                    }
                    else
                        comboBoxDrugClinicalCategoryCode.SelectedIndex = 0;
                }
            }
            //自主分类//2014-2
            if (DictionaryUserDefinedTypes != null)
            {
                comboBoxDictionaryUserDefinedTypeCode.DataSource = DictionaryUserDefinedTypes;
                comboBoxDictionaryUserDefinedTypeCode.DisplayMember = "Name";
                comboBoxDictionaryUserDefinedTypeCode.ValueMember = "Name";
                if (comboBoxDictionaryUserDefinedTypeCode.Items.Count > 0)
                {
                    if (operationType == OperateType.Browse)
                    {
                        DictionaryUserDefinedType listitem = DictionaryUserDefinedTypes.Where(d => d.Name == drugInfo.DictionaryUserDefinedTypeCode).FirstOrDefault();
                        if (listitem != null)
                            comboBoxDictionaryUserDefinedTypeCode.SelectedItem = listitem;
                    }
                    else
                        comboBoxDictionaryUserDefinedTypeCode.SelectedIndex = 0;
                }
            }
            //计量单位2014-2
            if (DictionaryMeasurementUnits != null)
            {
                comboBoxDictionaryMeasurementUnitCode.DataSource = DictionaryMeasurementUnits;
                comboBoxDictionaryMeasurementUnitCode.DisplayMember = "Name";
                comboBoxDictionaryMeasurementUnitCode.ValueMember = "Name";
                if (comboBoxDictionaryMeasurementUnitCode.Items.Count > 0)
                {
                    if (operationType == OperateType.Browse)
                    {
                        DictionaryMeasurementUnit listitem = DictionaryMeasurementUnits.Where(d => d.Name == drugInfo.DictionaryMeasurementUnitCode).FirstOrDefault();
                        if (listitem != null)
                            comboBoxDictionaryMeasurementUnitCode.SelectedItem = listitem;
                        //return;
                    }
                    else
                        comboBoxDictionaryMeasurementUnitCode.SelectedIndex = 0;
                }
            }
            //药品剂型2014-2
            if (DictionaryDosages != null)
            {
                comboBoxDictionaryDosageCode.DataSource = DictionaryDosages;
                comboBoxDictionaryDosageCode.DisplayMember = "Name";
                comboBoxDictionaryDosageCode.ValueMember = "Name";
                if (comboBoxDictionaryDosageCode.Items.Count > 0)
                {
                    if (operationType == OperateType.Browse)
                    {
                        DictionaryDosage listitem = DictionaryDosages.Where(d => d.Name == drugInfo.DictionaryDosageCode).FirstOrDefault();
                        if (listitem != null)
                            comboBoxDictionaryDosageCode.SelectedItem = listitem;
                    }
                    else
                        comboBoxDictionaryDosageCode.SelectedIndex = 0;
                }
            }
            ////药品规格,2014-2
            //if (DictionarySpecifications != null)
            //{
            //    comboBoxDictionarySpecificationCode1.DataSource = DictionarySpecifications;
            //    comboBoxDictionarySpecificationCode1.DisplayMember = "Name";
            //    comboBoxDictionarySpecificationCode1.ValueMember = "Name";

            //    if (comboBoxDictionarySpecificationCode1.Items.Count > 0)
            //    {
            //        if (operationType == OperateType.Browse)
            //        {
            //            DictionarySpecification listitem = DictionarySpecifications.Where(d => d.Name == drugInfo.DictionarySpecificationCode).First();

            //            comboBoxDictionarySpecificationCode1.SelectedItem = listitem;
            //        }

            //        else
            //            comboBoxDictionarySpecificationCode1.SelectedIndex = 0;
            //    }
            //}
            //拆零单位
            if (DictionaryPiecemealUnits != null)
            {
                comboBoxDictionaryPiecemealUnitCode.DataSource = DictionaryPiecemealUnits;
                comboBoxDictionaryPiecemealUnitCode.DisplayMember = "Name";
                comboBoxDictionaryPiecemealUnitCode.ValueMember = "Name";

                if (comboBoxDictionaryPiecemealUnitCode.Items.Count > 0)
                {
                    if (operationType == OperateType.Browse)
                    {
                        DictionaryPiecemealUnit listitem = DictionaryPiecemealUnits.Where(d => d.Name == drugInfo.DictionaryPiecemealUnitCode).FirstOrDefault();
                        if (listitem != null)
                            comboBoxDictionaryPiecemealUnitCode.SelectedItem = listitem;
                    }

                    else
                        comboBoxDictionaryPiecemealUnitCode.SelectedIndex = 0;
                }
            }
            //审批流程类型
            if (ApprovalFlowTypes != null)
            {
                comboBoxFlowID.DataSource = ApprovalFlowTypes;
                comboBoxFlowID.DisplayMember = "Name";
                comboBoxFlowID.ValueMember = "Id";
                if (comboBoxFlowID.Items.Count > 0)
                {
                    if (operationType == OperateType.Browse)
                    {
                        var _listAF = this.PharmacyDatabaseService.GetApproveFlowsByFlowID(out msg, drugInfo.FlowID);

                        //ApprovalFlow _listAF = PharmacyDatabaseService.AllApprovalFlows(out msg).Where(c => c.FlowId == drugInfo.FlowID).FirstOrDefault();
                        ApprovalFlowType listitem = ApprovalFlowTypes.Where(d => d.Id == _listAF.ApprovalFlowTypeId).FirstOrDefault();
                        if (listitem != null)
                            comboBoxFlowID.SelectedItem = listitem;
                    }

                    else
                        comboBoxFlowID.SelectedIndex = 0;
                }
            }
            //仓库类型
            if (Warehouse != null)
            {
                comboBoxWarehouse.DataSource = Warehouse;
                comboBoxWarehouse.DisplayMember = "Name";
                comboBoxWarehouse.ValueMember = "Id";
                if (comboBoxWarehouse.Items.Count > 0)
                {
                    if (operationType == OperateType.Browse)
                    {
                        Warehouse listitem = Warehouse.Where(d => d.Id == drugInfo.WareHouses).FirstOrDefault();
                        if (listitem != null)
                        {
                            comboBoxWarehouse.SelectedItem = listitem;
                            this.BindSelectedWarehouseZones();
                        }
                    }
                    else
                    {
                        if (Warehouse.Count > 0)
                            comboBoxWarehouse.SelectedIndex = 0;
                    }
                }

            }
            //库区类型
            if (WarehouseZone != null)
            {
                comboBoxWarehouseZone.DataSource = WarehouseZone;
                comboBoxWarehouseZone.DisplayMember = "Name";
                comboBoxWarehouseZone.ValueMember = "Id";
                if (comboBoxWarehouseZone.Items.Count > 0)
                {
                    comboBoxWarehouseZone.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// 绑定药物基本信息
        /// </summary>
        private void BindDrugInfo()
        {
            string message = string.Empty;
            if (DesignMode) return;
            if (DrugInfo == null)
            {
                return;
            }
            //商品类型 comboBoxGoodsType
            if (this.comboBoxGoodsType.Items.Count > 0)
            {
                this.comboBoxGoodsType.SelectedValue = drugInfo.GoodsTypeValue.ToString();
            }
            this.textBoxCode.Text = drugInfo.Code;
            this.ckEnable.Checked = drugInfo.Enabled;
            this.textBoxBarCode.Text = drugInfo.BarCode;
            this.comboBoxPackage.Text = drugInfo.Package;
            this.textBoxProductName.Text = drugInfo.ProductName;
            this.textBoxProductEnglishName.Text = drugInfo.ProductEnglishName;
            this.textBoxProductGeneralName.Text = drugInfo.ProductGeneralName;
            this.textBoxProductDocument.Text = drugInfo.DocCode;
            this.textBoxFactoryName.Text = drugInfo.FactoryName;
            this.Origin.Text = drugInfo.Origin;
            this.numericUpDownValidPeriod.Text = drugInfo.ValidPeriod.ToString();
            this.textBoxLicensePermissionNumber.Text = drugInfo.LicensePermissionNumber;
            this.textBoxPerformanceStandards.Text = drugInfo.PerformanceStandards;
            this.textBoxDescription.Text = drugInfo.Description;
            this.checkBoxIsMedicalInsurance.Checked = drugInfo.IsMedicalInsurance;
            this.checkBoxIsPrescription.Checked = drugInfo.IsPrescription;
            this.checkBoxIsImport.Checked = drugInfo.IsImport;
            this.checkBoxIsMainMaintenance.Checked = drugInfo.IsMainMaintenance;
            this.checkBoxIsSpecialDrugCategory.Checked = drugInfo.IsSpecialDrugCategory;
            this.comboBoxSpecialDrugCategoryCode.Text = drugInfo.SpecialDrugCategoryCode;
            this.textBoxStandardCode.Text = drugInfo.StandardCode;
            this.comboBoxDrugStorageTypeCode.Text = drugInfo.DrugStorageTypeCode;
            this.comboBoxBusinessScopeCode.Text = drugInfo.BusinessScopeCode;
            this.comboBoxPurchaseManageCategoryDetailCode.Text = drugInfo.PurchaseManageCategoryDetailCode;
            this.comboBoxDrugCategoryCode.Text = drugInfo.DrugCategoryCode;
            this.comboBoxMedicalCategoryDetailCode.Text = drugInfo.MedicalCategoryDetailCode;
            this.comboBoxDrugClinicalCategoryCode.Text = drugInfo.DrugClinicalCategoryCode;
            this.comboBoxDictionaryUserDefinedTypeCode.Text = drugInfo.DictionaryUserDefinedTypeCode;
            this.comboBoxDictionaryMeasurementUnitCode.Text = drugInfo.DictionaryMeasurementUnitCode;
            this.comboBoxDictionaryDosageCode.Text = drugInfo.DictionaryDosageCode;
            this.txtDictionarySpecificationCode.Text = drugInfo.DictionarySpecificationCode;
            this.comboBoxDictionaryPiecemealUnitCode.Text = drugInfo.DictionaryPiecemealUnitCode;
            //this.comBoxPiecemealSpecification.SelectedText = drugInfo.PiecemealSpecification;
            this.numericUpDownPiecemealNumber.Value = drugInfo.PiecemealNumber;
            this.numericUpDownPrice.Value = drugInfo.Price;
            this.numericUpDownNationalSalePrice.Value = drugInfo.NationalSalePrice;
            this.numericUpDownPurchasePrice.Value = drugInfo.PurchasePrice;
            this.numericUpDownWholeSalePrice.Value = drugInfo.WholeSalePrice;
            this.numericUpDownRetailPrice.Value = drugInfo.RetailPrice;
            this.numericUpDownTagPrice.Value = drugInfo.TagPrice;
            this.numericUpDownLowSalePrice.Value = drugInfo.LowSalePrice;
            this.numericUpDownLimitedLowPrice.Value = drugInfo.LimitedLowPrice;
            this.numericUpDownLimitedUpPrice.Value = drugInfo.LimitedUpPrice;
            this.numericUpDownMinInventoryCount.Value = drugInfo.MinInventoryCount;
            this.numericUpDownMaxInventoryCount.Value = drugInfo.MaxInventoryCount;
            this.numericUpDownPackageAmount.Value = drugInfo.PackageAmount;
            this.textBoxPermitLicenseCode.Text = drugInfo.PermitLicenseCode;
            //this.dateTimePickerPermitDate.Text = drugInfo.PermitDate.Date.ToString("yyyyMMdd");
            this.dateTimePickerPermitOutDate.Text = drugInfo.PermitOutDate.Date.ToString("yyyyMMdd");
            this.textBoxPinyinCode.Text = drugInfo.Pinyin;

            //
            this.checkBoxValid.Checked = drugInfo.Valid;
            this.labelValidRemark.Text = drugInfo.ValidRemark;
            this.checkBoxIsLock.Checked = drugInfo.IsLock;
            this.labelLockRemark.Text = drugInfo.LockRemark;

            this.comboBoxWarehouse.SelectedValue = drugInfo.WareHouses;

            this.labelCreateTime.Text = drugInfo.CreateTime.ToString();
            this.labelCreateUserId.Text = PharmacyDatabaseService.GetUser(out message, drugInfo.CreateUserId).Employee.Name;

            this.labelUpdateTime.Text = drugInfo.UpdateTime.ToString();
            this.labelUpdateUserId.Text = PharmacyDatabaseService.GetUser(out message, drugInfo.UpdateUserId).Employee.Name;
            //几个状态处理
            this.comboBoxSpecialDrugCategoryCode.Enabled = drugInfo.IsSpecialDrugCategory;

            switch (runMode)
            {
                case FormRunMode.Edit:

                case FormRunMode.Browse:
                    GoodsAdditional = this.PharmacyDatabaseService.GetGoodsAdditionalProperty(out message, drugInfo.Id);
                    break;
                case FormRunMode.Add:
                    GoodsAdditional = new GoodsAdditionalProperty();
                    GoodsAdditional.Id = drugInfo.Id;
                    // GoodsAdditional.DrugInfoId = drugInfo.Id;
                    GoodsAdditional.LicensePermissionDate = DateTime.Now;
                    GoodsAdditional.PutOnRecordDate = DateTime.Now;
                    break;
                case FormRunMode.Search:
                    break;
                case FormRunMode.Delete:
                    break;
                default:
                    break;
            }

            this.groupBox2.Visible = (drugInfo.GoodsType == GoodsType.DrugDomestic || drugInfo.GoodsType == GoodsType.DrugImport);
            this.buttonEditGoodsAdditional.Enabled = !this.groupBox2.Visible;
        }


        #endregion 数据到控件

        #region 数据初始化与从服务器获取数据

        /// <summary>
        /// 初始化所的字典数据
        /// 主要绑定下拉数据
        /// </summary>
        private void InitDictionaries()
        {
            try
            {
                string message = string.Empty;
                //商品类型
                if (GoodsTypeList == null)
                {
                    GoodsTypeList = EnumHelper<GoodsType>.GetMapKeyValues()
                        .OrderBy(l => l.ID).ToList();
                }
                //包装
                if (PackagingUnits == null)
                {
                    PackagingUnits = PharmacyDatabaseService.AllPackagingUnits(out message)
                        .OrderBy(t => t.Name)
                        .ToList();
                }
                //特殊管理类型
                if (SpecialDrugCategories == null)
                {
                    SpecialDrugCategories = PharmacyDatabaseService.AllSpecialDrugCategorys(out message)
                        .OrderBy(t => t.Name)
                        .ToList();
                }
                //存储方式
                if (DictionaryStorageTypes == null)
                {
                    DictionaryStorageTypes = PharmacyDatabaseService.AllDictionaryStorageTypes(out message)
                        .OrderBy(t => t.Name)
                        .ToList();
                }
                //经营范围
                if (BusinessScopes == null)
                {
                    BusinessScopes = PharmacyDatabaseService.AllBusinessScopes(out message)
                        .OrderBy(t => t.Name)
                        .ToList();
                }
                //管理分类
                if (PurchaseManageCategoryDetails == null)
                {
                    PurchaseManageCategoryDetails = PharmacyDatabaseService.AllPurchaseManageCategoryDetails(out message)
                        .OrderByDescending(t => t.Code)
                        .ToList();
                    PurchaseManageCategoryDetails.ForEach(a =>
                    {
                        a.Name = string.Format("{0}({1})", a.Name, a.PurchaseManageCategory.Name);

                    });
                }
                //药品分类
                if (DrugCategories == null)
                {
                    DrugCategories = PharmacyDatabaseService.AllDrugCategorys(out message)
                        .OrderBy(t => t.Name)
                        .ToList();
                }
                //医疗分类
                if (MedicalCategoryDetails == null)
                {
                    MedicalCategoryDetails = PharmacyDatabaseService.AllMedicalCategoryDetails(out message)
                        .OrderBy(t => t.Name)
                        .ToList();
                    MedicalCategoryDetails.ForEach(a =>
                    {
                        a.Name = string.Format("{0}({1})", a.Name, a.MedicalCategory.Name);

                    });
                }
                //临床分类
                if (DrugClinicalCategories == null)
                {
                    DrugClinicalCategories = PharmacyDatabaseService.AllDrugClinicalCategorys(out message)
                        .OrderBy(t => t.Name)
                        .ToList();
                }
                //自主分类
                if (DictionaryUserDefinedTypes == null)
                {
                    DictionaryUserDefinedTypes = PharmacyDatabaseService.AllDictionaryUserDefinedTypes(out message)
                        .OrderBy(t => t.Name)
                        .ToList();
                }
                //计量单位
                if (DictionaryMeasurementUnits == null)
                {
                    DictionaryMeasurementUnits = PharmacyDatabaseService.AllDictionaryMeasurementUnits(out message)
                        .OrderBy(t => t.Name)
                        .ToList();
                }
                //药品剂型
                if (DictionaryDosages == null)
                {
                    DictionaryDosages = PharmacyDatabaseService.AllDictionaryDosages(out message)
                        .OrderBy(t => t.Name)
                        .ToList();
                }

                if (DictionaryPiecemealUnits == null)
                {
                    DictionaryPiecemealUnits = PharmacyDatabaseService.AllDictionaryPiecemealUnits(out message)
                       .OrderBy(t => t.Name)
                        .ToList();
                }
                //仓库类型
                if (Warehouse == null)
                {
                    Warehouse = PharmacyDatabaseService.AllWarehouses(out message).OrderBy(t => t.Name).ToList();
                }

                //库区类型
                if (WarehouseZone == null)
                {
                    WarehouseZone = PharmacyDatabaseService.AllWarehouseZones(out message).OrderBy(t => t.Name).ToList();
                }

                //审批流程
                if (ApprovalFlowTypes == null)
                {
                    ApprovalFlowTypes = PharmacyDatabaseService.AllApprovalFlowTypes(out message).OrderBy(t => t.Name).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择栏数据初始化失败，请联系管理员！");
            }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            if (DesignMode) return;
            if (drugInfo == null)
            {
                return;
            }
            switch (runMode)
            {
                case FormRunMode.Add:
                    drugInfo.GoodsType = GoodsType.DrugDomestic;
                    drugInfo.CreateTime = DateTime.Now;
                    drugInfo.CreateUserId = AppClientContext.CurrentUser.Id;
                    drugInfo.UpdateTime = drugInfo.CreateTime;
                    drugInfo.UpdateUserId = drugInfo.CreateUserId;
                    //分类处理
                    drugInfo.DictionaryPiecemealUnitCode = "无";
                    drugInfo.DictionarySpecificationCode = "无";
                    drugInfo.DictionaryDosageCode = "无";
                    drugInfo.DictionaryMeasurementUnitCode = "无";
                    drugInfo.DrugStorageTypeCode = "无";
                    drugInfo.DictionaryUserDefinedTypeCode = "无";
                    drugInfo.DrugClinicalCategoryCode = "无";
                    drugInfo.MedicalCategoryDetailCode = "无";
                    drugInfo.DrugCategoryCode = "无";
                    drugInfo.PurchaseManageCategoryDetailCode = "无";
                    drugInfo.BusinessScopeCode = "无";
                    drugInfo.Package = "小包装";
                    drugInfo.SpecialDrugCategoryCode = "无";
                    drugInfo.SpecialDrugCategoryCode = "无";
                    drugInfo.StandardCode = "00000000000000";
                    drugInfo.PermitDate = DateTime.Now.Date;
                    drugInfo.PermitOutDate = DateTime.Now.Date.AddYears(20);
                    drugInfo.PackageAmount = 1;
                    drugInfo.SmallPackage = 0;
                    drugInfo.BigPackage = 0;
                    drugInfo.MiddlePackage = 0;
                    drugInfo.DictionarySpecificationCode = "无";
                    drugInfo.ValidPeriod = 36;
                    //动态加载审批流程类型:新增
                    ApprovalFlowTypes = this.PharmacyDatabaseService.AllApprovalFlowTypes(out msg).Where(r => r.ApprovalType == ApprovalType.DrugInfoApproval).ToList();
                    this.comboBoxFlowID.DataSource = ApprovalFlowTypes;
                    this.comboBoxFlowID.SelectedIndex = 0;
                    break;
                case FormRunMode.Edit:
                    drugInfo.UpdateTime = DateTime.Now;
                    drugInfo.UpdateUserId = AppClientContext.CurrentUser.Id;
                    //动态加载审批流程类型:修改
                    if (drugInfo.ApprovalStatus == ApprovalStatus.Approvaled || drugInfo.ApprovalStatus == ApprovalStatus.Reject)
                    {
                        //状态一:已审批通过或者拒绝
                        this.comboBoxFlowID.DataSource = this.PharmacyDatabaseService.AllApprovalFlowTypes(out msg).Where(r => r.ApprovalType == ApprovalType.DrugInfoEditApproval).ToList();
                        this.comboBoxFlowID.SelectedIndex = 0;
                    }
                    else
                    {
                        //状态二:正在审批过程中
                        ApprovalFlow af1 = this.PharmacyDatabaseService.GetApproveFlowsByFlowID(out msg, drugInfo.FlowID);
                        if (af1 != null)
                        {
                            this.comboBoxFlowID.DataSource = this.PharmacyDatabaseService.AllApprovalFlowTypes(out msg).ToList();
                            this.comboBoxFlowID.SelectedValue = af1.ApprovalFlowTypeId;
                            this.comboBoxFlowID.Enabled = false;
                        }
                    }

                    break;
                case FormRunMode.Search:
                    //查询状态
                    ApprovalFlow af2 = this.PharmacyDatabaseService.GetApproveFlowsByFlowID(out msg, drugInfo.FlowID);
                    if (af2 != null)
                    {
                        this.comboBoxFlowID.DataSource = this.PharmacyDatabaseService.AllApprovalFlowTypes(out msg).ToList();
                        this.comboBoxFlowID.SelectedValue = af2.ApprovalFlowTypeId;
                        this.comboBoxFlowID.Enabled = false;
                    }
                    break;
            }
            this.comboBoxFlowID.DisplayMember = "Name";
            this.comboBoxFlowID.ValueMember = "id";
        }

        #endregion

        #region 控件初始化

        /// <summary>
        /// 控件状态初始化
        /// </summary>
        private void InitControlsStatus()
        {
            this.comboBoxGoodsType.Enabled = RunMode == FormRunMode.Add;
            // this.buttonEditGoodsAdditional.Enabled = this.comboBoxGoodsType.Enabled;
            this.Enabled = RunMode != FormRunMode.Browse;
        }

        #endregion 控件初始化

        #region 事件处理

        private void checkBoxIsSpecialDrugCategory_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxSpecialDrugCategoryCode.Enabled = this.checkBoxIsSpecialDrugCategory.Checked;
            if (drugInfo != null)
            {
                comboBoxSpecialDrugCategoryCode.SelectedValue = drugInfo.SpecialDrugCategoryCode;
            }
        }

        private void checkBoxIsApproval_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void comboBoxGoodsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxGoodsType.SelectedValue == null) return;
            drugInfo.GoodsTypeValue = int.Parse(this.comboBoxGoodsType.SelectedValue.ToString());
            this.groupBox2.Visible = (drugInfo.GoodsType == GoodsType.DrugDomestic || drugInfo.GoodsType == GoodsType.DrugImport);
            this.buttonEditGoodsAdditional.Enabled = !this.groupBox2.Visible;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                InitDictionaries();
                //if(operationType!= OperateType.Browse)
                BindDictionaries();
                InitData();
                comboBoxGoodsType.SelectedIndexChanged += new EventHandler(comboBoxGoodsType_SelectedIndexChanged);
                comboBoxWarehouse.SelectedValueChanged += new EventHandler(comboBoxWarehouse_SelectedValueChanged);
                getDrugInfoCount();
            }
        }

        #endregion 事件处理

        #region 控件到数据

        /// <summary>
        /// 收集药物信息
        /// </summary>
        public void CellectDrugInfo()
        {
            DataReady = false;
            try
            {
                //收集数据
                drugInfo.GoodsTypeValue = int.Parse(this.comboBoxGoodsType.SelectedValue.ToString());
                drugInfo.Code = this.textBoxCode.Text.Trim();
                drugInfo.Enabled = this.ckEnable.Checked;
                drugInfo.BarCode = this.textBoxBarCode.Text;
                drugInfo.Package = this.comboBoxPackage.SelectedValue.ToString();
                drugInfo.ProductName = this.textBoxProductName.Text.Trim();
                drugInfo.ProductEnglishName = this.textBoxProductEnglishName.Text.Trim();
                drugInfo.ProductGeneralName = this.textBoxProductGeneralName.Text.Trim();
                drugInfo.DocCode = this.textBoxProductDocument.Text.Trim();
                drugInfo.FactoryName = this.textBoxFactoryName.Text.Trim();
                drugInfo.Origin = this.Origin.Text.Trim();
                drugInfo.ValidPeriod = int.Parse(this.numericUpDownValidPeriod.Text.Trim());
                drugInfo.LicensePermissionNumber = this.textBoxLicensePermissionNumber.Text.Trim();
                drugInfo.PerformanceStandards = this.textBoxPerformanceStandards.Text.Trim();
                drugInfo.Description = this.textBoxDescription.Text;
                drugInfo.IsMedicalInsurance = this.checkBoxIsMedicalInsurance.Checked;
                drugInfo.IsPrescription = this.checkBoxIsPrescription.Checked;
                drugInfo.IsImport = this.checkBoxIsImport.Checked;
                drugInfo.IsMainMaintenance = this.checkBoxIsMainMaintenance.Checked;
                drugInfo.IsSpecialDrugCategory = this.checkBoxIsSpecialDrugCategory.Checked;
                drugInfo.SpecialDrugCategoryCode = this.comboBoxSpecialDrugCategoryCode.SelectedValue.ToString();
                drugInfo.StandardCode = this.textBoxStandardCode.Text.Trim();
                drugInfo.DrugStorageTypeCode = this.comboBoxDrugStorageTypeCode.SelectedValue.ToString();
                drugInfo.BusinessScopeCode = this.comboBoxBusinessScopeCode.SelectedValue.ToString();
                drugInfo.PurchaseManageCategoryDetailCode = this.comboBoxPurchaseManageCategoryDetailCode.SelectedValue.ToString();
                drugInfo.DrugCategoryCode = this.comboBoxDrugCategoryCode.SelectedValue.ToString();
                drugInfo.MedicalCategoryDetailCode = this.comboBoxMedicalCategoryDetailCode.SelectedValue.ToString();
                drugInfo.DrugClinicalCategoryCode = this.comboBoxDrugClinicalCategoryCode.SelectedValue.ToString();
                drugInfo.DictionaryUserDefinedTypeCode = this.comboBoxDictionaryUserDefinedTypeCode.SelectedValue.ToString();
                drugInfo.DictionaryMeasurementUnitCode = this.comboBoxDictionaryMeasurementUnitCode.SelectedValue.ToString();
                drugInfo.DictionaryDosageCode = this.comboBoxDictionaryDosageCode.SelectedValue.ToString();
                drugInfo.DictionarySpecificationCode = this.txtDictionarySpecificationCode.Text;
                drugInfo.DictionaryPiecemealUnitCode = this.comboBoxDictionaryPiecemealUnitCode.SelectedValue.ToString();

                //drugInfo.PiecemealSpecification = this.comBoxPiecemealSpecification.SelectedValue.ToString();
                drugInfo.PiecemealNumber = (int)this.numericUpDownPiecemealNumber.Value;
                drugInfo.Price = this.numericUpDownPrice.Value;
                drugInfo.NationalSalePrice = this.numericUpDownNationalSalePrice.Value;
                drugInfo.PurchasePrice = this.numericUpDownPurchasePrice.Value;
                drugInfo.WholeSalePrice = this.numericUpDownWholeSalePrice.Value;
                drugInfo.RetailPrice = this.numericUpDownRetailPrice.Value;
                drugInfo.TagPrice = this.numericUpDownTagPrice.Value;
                drugInfo.LowSalePrice = this.numericUpDownLowSalePrice.Value;
                drugInfo.LimitedLowPrice = this.numericUpDownLimitedLowPrice.Value;
                drugInfo.LimitedUpPrice = this.numericUpDownLimitedUpPrice.Value;
                drugInfo.MaxInventoryCount = (int)this.numericUpDownMaxInventoryCount.Value;
                drugInfo.MinInventoryCount = (int)this.numericUpDownMinInventoryCount.Value;
                drugInfo.IsLock = checkBoxIsLock.Checked;
                drugInfo.LockRemark = labelLockRemark.Text;
                drugInfo.PackageAmount = (int)numericUpDownPackageAmount.Value;
                drugInfo.PermitLicenseCode = this.textBoxPermitLicenseCode.Text.Trim();
                drugInfo.Pinyin = this.textBoxPinyinCode.Text.Trim();

                DateTime inputPermitOutDate = DateTime.ParseExact(this.dateTimePickerPermitOutDate.Text, "yyyyMMdd", format);

                drugInfo.PermitOutDate = inputPermitOutDate;
                drugInfo.WareHouses = (Guid)this.comboBoxWarehouse.SelectedValue;
                string msg = "";

                var whzEntity = this.PharmacyDatabaseService.AllWarehouseZones(out msg).ToList().FirstOrDefault(r => r.WarehouseId == drugInfo.WareHouses);
                if (whzEntity == null)
                {
                    MessageBox.Show("当前仓库没有设置库区，请通知管理员为选定库区建立相应库区！"); return;
                }


                drugInfo.WareHouseZones = whzEntity.Id.ToString();
                drugInfo.BigPackage = int.Parse(textBox1.Text.Trim());
                drugInfo.MiddlePackage = int.Parse(textBox2.Text.Trim());
                drugInfo.SmallPackage = int.Parse(textBox3.Text.Trim());

                if (false)
                {
                    //已经审批通过不要选流程了
                    drugInfo.IsApproval = true;
                    drugInfo.FlowID = Guid.Empty;
                }
                else
                {
                    //没有审批通过应该选择流程 
                    if (this.comboBoxFlowID.SelectedValue == null)
                    {
                        DataReady = false;
                        MessageBox.Show(this.Text + "请选择审批流程!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
                DataReady = true;
            }
            catch (Exception ex)
            {
                ex = new Exception("收集药物信息失败", ex);
                DataReady = false;
                MessageBox.Show(this.Text + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        #endregion 控件到数据



        private void buttonEditGoodsAdditional_Click(object sender, EventArgs e)
        {
            try
            {

                FormGoodsAdditionalProperty form = new FormGoodsAdditionalProperty(this.runMode, this.DrugInfo, this.GoodsAdditional);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.GoodsAdditional = form.GoodsAdditional;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(this.Text + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


        }

        /// <summary>
        /// 初始化Required控件
        /// </summary>
        public void InitRequiredControl()
        {
            if (!DesignMode)
            {
                AddRequiredValidate(label9, textBoxProductGeneralName);
                AddRequiredValidate(label39, txtDictionarySpecificationCode);
                AddRequiredValidate(label38, comboBoxDictionaryDosageCode);
                AddRequiredValidate(label37, comboBoxDictionaryMeasurementUnitCode);
                AddRequiredValidate(label7, textBoxFactoryName);
                AddRequiredValidate(label11, textBoxLicensePermissionNumber);
                AddRequiredValidate(label59, dateTimePickerPermitOutDate);
                AddRequiredValidate(labelPermitLicenseCode, textBoxPermitLicenseCode);
                AddRequiredValidate(label13, numericUpDownValidPeriod);
                AddRequiredValidate(label12, textBoxPerformanceStandards);
                AddRequiredValidate(label42, comboBoxBusinessScopeCode);
                AddRequiredValidate(label46, comboBoxDrugStorageTypeCode);
                AddRequiredValidate(label57, comboBoxWarehouse);
                //AddRequiredValidate(label6, textBoxProductDocument);
                AddRequiredValidate(label52, comboBoxFlowID);
            }
        }

        public void InitEditControl(DrugInfo drugInfo)
        {
            string message = string.Empty;
            if (DesignMode) return;
            if (drugInfo == null)
            {
                return;
            }
            //商品类型 comboBoxGoodsType
            if (this.comboBoxGoodsType.Items.Count > 0)
            {
                this.comboBoxGoodsType.SelectedValue = drugInfo.GoodsTypeValue.ToString();
            }
            this.textBoxCode.Text = drugInfo.Code;
            this.ckEnable.Checked = drugInfo.Enabled;
            this.textBoxBarCode.Text = drugInfo.BarCode;
            this.comboBoxPackage.Text = drugInfo.Package;
            this.textBoxProductName.Text = drugInfo.ProductName;
            this.textBoxProductEnglishName.Text = drugInfo.ProductEnglishName;
            this.textBoxProductGeneralName.Text = drugInfo.ProductGeneralName;
            this.textBoxProductDocument.Text = drugInfo.DocCode;
            this.textBoxFactoryName.Text = drugInfo.FactoryName;
            this.Origin.Text = drugInfo.Origin;
            this.numericUpDownValidPeriod.Text = drugInfo.ValidPeriod.ToString();
            this.textBoxLicensePermissionNumber.Text = drugInfo.LicensePermissionNumber;
            this.textBoxPerformanceStandards.Text = drugInfo.PerformanceStandards;
            this.textBoxDescription.Text = drugInfo.Description;
            this.checkBoxIsMedicalInsurance.Checked = drugInfo.IsMedicalInsurance;
            this.checkBoxIsPrescription.Checked = drugInfo.IsPrescription;
            this.checkBoxIsImport.Checked = drugInfo.IsImport;
            this.checkBoxIsMainMaintenance.Checked = drugInfo.IsMainMaintenance;
            this.checkBoxIsSpecialDrugCategory.Checked = drugInfo.IsSpecialDrugCategory;
            this.comboBoxSpecialDrugCategoryCode.Text = drugInfo.SpecialDrugCategoryCode;
            this.textBoxStandardCode.Text = drugInfo.StandardCode;
            this.comboBoxDrugStorageTypeCode.SelectedItem = drugInfo.DrugStorageTypeCode;
            this.comboBoxBusinessScopeCode.Text = drugInfo.BusinessScopeCode;
            this.comboBoxPurchaseManageCategoryDetailCode.Text = drugInfo.PurchaseManageCategoryDetailCode;
            this.comboBoxDrugCategoryCode.SelectedText = drugInfo.DrugCategoryCode;
            this.comboBoxMedicalCategoryDetailCode.Text = drugInfo.MedicalCategoryDetailCode;
            this.comboBoxDrugClinicalCategoryCode.Text = drugInfo.DrugClinicalCategoryCode;
            this.comboBoxDictionaryUserDefinedTypeCode.Text = drugInfo.DictionaryUserDefinedTypeCode;
            this.comboBoxDictionaryMeasurementUnitCode.Text = drugInfo.DictionaryMeasurementUnitCode;
            this.comboBoxDictionaryDosageCode.Text = drugInfo.DictionaryDosageCode;
            this.txtDictionarySpecificationCode.Text = drugInfo.DictionarySpecificationCode;
            this.comboBoxDictionaryPiecemealUnitCode.Text = drugInfo.DictionaryPiecemealUnitCode;
            //this.comBoxPiecemealSpecification.SelectedText = drugInfo.PiecemealSpecification;
            this.numericUpDownPiecemealNumber.Value = drugInfo.PiecemealNumber;
            this.numericUpDownPrice.Value = drugInfo.Price;
            this.numericUpDownNationalSalePrice.Value = drugInfo.NationalSalePrice;
            this.numericUpDownPurchasePrice.Value = drugInfo.PurchasePrice;
            this.numericUpDownWholeSalePrice.Value = drugInfo.WholeSalePrice;
            this.numericUpDownRetailPrice.Value = drugInfo.RetailPrice;
            this.numericUpDownTagPrice.Value = drugInfo.TagPrice;
            this.numericUpDownLowSalePrice.Value = drugInfo.LowSalePrice;
            this.numericUpDownLimitedLowPrice.Value = drugInfo.LimitedLowPrice;
            this.numericUpDownLimitedUpPrice.Value = drugInfo.LimitedUpPrice;
            this.numericUpDownMinInventoryCount.Value = drugInfo.MinInventoryCount;
            this.numericUpDownMaxInventoryCount.Value = drugInfo.MaxInventoryCount;
            this.numericUpDownPackageAmount.Value = drugInfo.PackageAmount;
            this.textBoxPinyinCode.Text = drugInfo.Pinyin;

            this.textBoxPermitLicenseCode.Text = drugInfo.PermitLicenseCode;

            this.dateTimePickerPermitOutDate.Text = drugInfo.PermitOutDate.Date.ToString("yyyyMMdd");
            this.comboBoxWarehouse.DataSource = this.PharmacyDatabaseService.AllWarehouses(out msg);
            this.comboBoxWarehouse.DisplayMember = "Name";
            this.comboBoxWarehouse.ValueMember = "Id";
            this.comboBoxWarehouse.SelectedValue = drugInfo.WareHouses;
            this.selectedWarehouseZones = drugInfo.WareHouseZones;
            this.textBox1.Text = drugInfo.BigPackage.ToString();
            this.textBox2.Text = drugInfo.MiddlePackage.ToString();
            this.textBox3.Text = drugInfo.SmallPackage.ToString();
            //
            this.checkBoxValid.Checked = drugInfo.Valid;
            this.labelValidRemark.Text = drugInfo.ValidRemark;
            this.checkBoxIsLock.Checked = drugInfo.IsLock;
            this.labelLockRemark.Text = drugInfo.LockRemark;

            this.comboBoxFlowID.SelectedValue = drugInfo.FlowID;
            this.comboBoxFlowID.Enabled = true;


            this.labelCreateTime.Text = drugInfo.CreateTime.ToString();
            this.labelCreateUserId.Text = PharmacyDatabaseService.GetUser(out message, drugInfo.CreateUserId).Employee.Name;

            this.labelUpdateTime.Text = drugInfo.UpdateTime.ToString();
            var usr = PharmacyDatabaseService.GetUser(out message, drugInfo.UpdateUserId);
            this.labelUpdateUserId.Text = usr == null ? string.Empty : usr.Employee.Name;
            //几个状态处理
            this.comboBoxSpecialDrugCategoryCode.Enabled = drugInfo.IsSpecialDrugCategory;
            //this.comboBoxFlowID.Enabled = !drugInfo.IsApproval;

            switch (runMode)
            {
                case FormRunMode.Edit:
                    GoodsAdditional = new GoodsAdditionalProperty();
                    GoodsAdditional.Id = drugInfo.Id;
                    // GoodsAdditional.DrugInfoId = drugInfo.Id;
                    GoodsAdditional.LicensePermissionDate = DateTime.Now;
                    GoodsAdditional.PutOnRecordDate = DateTime.Now;
                    break;

                case FormRunMode.Browse:
                    GoodsAdditional = this.PharmacyDatabaseService.GetGoodsAdditionalProperty(out message, drugInfo.Id);
                    break;
                case FormRunMode.Add:
                    GoodsAdditional = new GoodsAdditionalProperty();
                    GoodsAdditional.Id = drugInfo.Id;
                    // GoodsAdditional.DrugInfoId = drugInfo.Id;
                    GoodsAdditional.LicensePermissionDate = DateTime.Now;
                    GoodsAdditional.PutOnRecordDate = DateTime.Now;
                    break;
                case FormRunMode.Search:
                    break;
                case FormRunMode.Delete:
                    break;
                default:
                    break;
            }

            this.groupBox2.Visible = (drugInfo.GoodsType == GoodsType.DrugDomestic || drugInfo.GoodsType == GoodsType.DrugImport);
            this.buttonEditGoodsAdditional.Enabled = !this.groupBox2.Visible;

            if (this.operationType == OperateType.Browse)
            {
                SetControls.SetControlReadonly(this.buttonEditGoodsAdditional, true);
            }
        }

        public void getDrugInfoCount()
        {
            //string msg = string.Empty;
            //_listDrugInfo = null;
            //_listDrugInfo = PharmacyDatabaseService.SearchPagedDrugInfosByAllStrings(out pageInfo,
            //    out msg, _searchKeyword, 1, 10000).ToList();
            //_listDrugInfo = PharmacyDatabaseService.AllDrugInfos(out msg).ToList();
            //int _count = _listDrugInfo.Count + 1;
            //textBoxCode.Text = "SPBH00" + _count.ToString();
        }

        public void setEnableState()
        {
            ckEnable.Checked = true;
            //this.textBoxCode.Enabled = false;
            this.buttonEditGoodsAdditional.Enabled = false;
        }

        public void SetControlIsEdit(bool isEdit)
        {
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox)
                {
                    foreach (Control ct in control.Controls)
                    {
                        if (ct is TextBox)
                            ((TextBox)ct).ReadOnly = !isEdit;
                        else if (ct is RichTextBox)
                            ((RichTextBox)ct).ReadOnly = !isEdit;
                        else if (ct is ComboBox)
                        {
                            ((ComboBox)ct).Enabled = isEdit;
                        }
                        else if (ct is DateTimePicker)
                            ((DateTimePicker)ct).Enabled = isEdit;
                        else if (ct is CheckBox)
                            ((CheckBox)ct).Enabled = isEdit;

                    }
                }
            }
        }

        private void comboBoxWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var d = from i in WarehouseZone where i.WarehouseId == (Guid)(comboBoxWarehouse.SelectedValue) select i.WarehouseId;
            //this.comboBoxWarehouseZone.DataSource = d.ToArray();
            //this.comboBoxWarehouseZone.ValueMember = "id";
            //this.comboBoxWarehouseZone.DisplayMember = "name";
            //MessageBox.Show(comboBoxWarehouse.SelectedValue.ToString());
        }

        private void comboBoxWarehouse_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxWarehouse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBoxWarehouse.SelectedIndex >= 0)
            {
                var d = from i in WarehouseZone where i.WarehouseId == (Guid)(comboBoxWarehouse.SelectedValue) select i;
                this.comboBoxWarehouseZone.DataSource = d.ToArray();
                this.comboBoxWarehouseZone.ValueMember = "id";
                this.comboBoxWarehouseZone.DisplayMember = "name";
                try
                {
                    string message = null;
                    WarehouseZones = d.ToList();
                    if (WarehouseZones != null && string.IsNullOrWhiteSpace(message))
                    {
                        foreach (WarehouseZone warehousezone in WarehouseZones)
                        {
                            warehousezone.Name = string.Format("{0}", warehousezone.Name);
                        }
                    }
                    else
                    {
                        throw new Exception(message);
                    }
                    if (WarehouseZones != null)
                    {
                        this.checkedListBox1.Items.Clear();
                        this.checkedListBox1.DisplayMember = "Name";
                        this.checkedListBox1.ValueMember = "Id";
                        this.checkedListBox1.Items.AddRange(WarehouseZones.Cast<object>().ToArray());
                        for (int i = 0; i <= WarehouseZones.Count - 1; i++)
                        {
                            this.checkedListBox1.SetItemChecked(i, true);
                        }
                    }
                    this.checkedListBox1.Enabled = true;
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    //if (showMessage)
                    //    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //return false;
                }
            }
        }

        private string selectedWarehouseZones = string.Empty;

        [Browsable(false)]
        public string SelectedWarehouseZones
        {
            set
            {
                selectedWarehouseZones = value;
                BindSelectedWarehouseZones();
            }
            get
            {
                CollectCheckedWarehouseZones();
                return selectedWarehouseZones;
            }
        }


        private void BindSelectedWarehouseZones()
        {
            if (DesignMode) return;
            if (OperateType.Browse != operationType)
                this.checkedListBox1.ClearSelected();
            else
            {
                this.checkedListBox1.Items.Clear();
                if (!string.IsNullOrWhiteSpace(selectedWarehouseZones))
                {
                    selectedWarehouseZones = selectedWarehouseZones.Trim();
                    var warehouseZones = selectedWarehouseZones.Split(',');
                    foreach (var i in warehouseZones)
                    {
                        this.checkedListBox1.Items.Add(i);
                        this.checkedListBox1.SetItemChecked(this.checkedListBox1.Items.Count - 1, true);
                    }
                    this.checkedListBox1.Enabled = false;

                }
            }
        }

        private void CollectCheckedWarehouseZones()
        {
            if (DesignMode) return;
            var items = checkedListBox1.Items;
            List<string> warehouseZones = new List<string>();
            for (int i = 0; i < items.Count; i++)
            {
                var warehouseZone = items[i] as WarehouseZone;
                if (warehouseZone == null)
                    continue;
                if (!checkedListBox1.GetItemChecked(i))
                {
                    continue;
                }
                warehouseZones.Add(warehouseZone.Name);
            }
            if (warehouseZones.Count > 0)
            {
                selectedWarehouseZones = string.Join(",", warehouseZones);
            }
            else
            {
                selectedWarehouseZones = string.Empty;
            }


        }

        private void dateTimePickerPermitDate_Enter(object sender, EventArgs e)
        {
            //this.dateTimePickerPermitDate.SelectAll();
            //this.dateTimePickerPermitDate.Text = null;
        }

        private void dateTimePickerPermitDate_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (this.dateTimePickerPermitDate.Text.Length != 8)
            //    {
            //        //MessageBox.Show("请输入正确的8位日期，如：20000101");
            //        this.dateTimePickerPermitDate.Focus();
            //        this.dateTimePickerPermitDate.Text = null;
            //        return;
            //    }
            //    DateTime.ParseExact(this.dateTimePickerPermitDate.Text, "yyyyMMdd", format);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("请输入正确日期");
            //    this.dateTimePickerPermitDate.Focus();
            //    this.dateTimePickerPermitDate.Text = null;
            //}
        }

        private void dateTimePickerPermitOutDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this.dateTimePickerPermitOutDate.Text.Length != 8)
                {
                    MessageBox.Show("请输入正确的8位日期，如：20000101");
                    this.dateTimePickerPermitOutDate.Focus();
                    this.dateTimePickerPermitOutDate.Text = null;
                    return;
                }
                DateTime dt1 = DateTime.ParseExact(this.dateTimePickerPermitOutDate.Text, "yyyyMMdd", format);
                this.dateTimePickerPermitOutDate.Text = dt1.ToString("yyyyMMdd");
            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入正确日期", "提示");
                this.dateTimePickerPermitOutDate.Focus();
                this.dateTimePickerPermitOutDate.Text = null;
            }
        }

        private void dateTimePickerPermitOutDate_Enter(object sender, EventArgs e)
        {
            //this.dateTimePickerPermitOutDate.SelectAll();
            //this.dateTimePickerPermitOutDate.Text = null;
        }

        private void textBoxCode_Enter(object sender, EventArgs e)
        {
            //string msg = string.Empty;
            //_listDrugInfo = null;
            //_listDrugInfo = PharmacyDatabaseService.SearchPagedDrugInfosByAllStrings(out pageInfo,
            //    out msg, _searchKeyword, 1, 10000).ToList();
            //_listDrugInfo = PharmacyDatabaseService.AllDrugInfos(out msg).ToList();
            //int _count = _listDrugInfo.Count + 1;
            //textBoxCode.Text = "SPBH00" + _count.ToString();
        }


        private void textBoxProductGeneralName_Leave(object sender, EventArgs e)
        {
            string chineseSpell = CreateChineseSpell.CreatePY(this.textBoxProductGeneralName.Text);
            this.textBoxPinyinCode.Text = chineseSpell;
            if (runMode == FormRunMode.Add)
            {
                string msg = string.Empty;

                int _count = PharmacyDatabaseService.GetDrugInfoCount(string.Empty);
                textBoxCode.Text = "SPBH" + _count.ToString().PadLeft(6, '0');
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Forms.BaseDataManage.Form_Photo frm = new Forms.BaseDataManage.Form_Photo(16, drugInfo.Id))
            {
                if (runMode == FormRunMode.Edit)
                {
                    SetControls.SetControlReadonly(frm, false);
                    frm.ShowDialog();
                }
                else if (runMode == FormRunMode.Add)
                {
                    MessageBox.Show("请在\"品种质量档案维护\"版块内进行上传图片");
                    return;
                }
                else
                {
                    SetControls.SetControlReadonly(frm, true);
                    frm.ShowDialog();
                }
            }
        }
    }
}
