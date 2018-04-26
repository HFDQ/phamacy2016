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

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormDrugInfo :BaseFunctionForm  //Form 
    {
        private DrugInfo entity = new DrugInfo();
        private List<DrugInfo> _listDrugInfo = new List<DrugInfo>();

        private PagerInfo pageInfo = new PagerInfo();
        private OperateType _TYPE = OperateType.Browse;
        private List<BaseValidator> _allValidator = new List<BaseValidator>();

        #region parameters :to bind combox datasource
        private List<DrugCategory> _ListDrugCategory = new List<DrugCategory>();
       
        private List<DictionaryUserDefinedType> _ListDictionaryUserDefinedType = new List<DictionaryUserDefinedType>();
        private List<DictionaryDosage> _ListDictionaryDosage = new List<DictionaryDosage>();
        private List<DictionarySpecification> _ListDictionarySpecification = new List<DictionarySpecification>();
        private List<DictionaryMeasurementUnit> _ListDictionaryMeasurementUnit = new List<DictionaryMeasurementUnit>();
        private List<DictionaryPiecemealUnit> _ListDictionaryPiecemealUnit = new List<DictionaryPiecemealUnit>();
        private List<DictionaryStorageType> _ListDictionaryStorageType = new List<DictionaryStorageType>();
        private List<DrugClinicalCategory> _ListDrugClinicalCategory = new List<DrugClinicalCategory>();
        private List<MedicalCategoryDetail> _ListMedicalCategoryDetail = new List<MedicalCategoryDetail>();
        private List<PurchaseManageCategoryDetail> _ListPurchaseManageCategoryDetail = new List<PurchaseManageCategoryDetail>();
        private List<SpecialDrugCategory> _ListSpecialDrugCategory = new List<SpecialDrugCategory>();
        private List<BusinessScope> _ListBusinessScope = new List<BusinessScope>();
        #endregion

        #region parameters: to search
        private string _searchBarCode = string.Empty;
        private string _searchProductName = string.Empty;
        private string _searchProductGeneralName = string.Empty;
        #endregion

        #region parameters : to show gridview format: code->name
        private Dictionary<string, string> dicDrugCategory = new Dictionary<string, string>();
        //private Dictionary<string, string> dicDrugType = new Dictionary<string, string>();
        private Dictionary<string, string> dicDictionaryUserDefinedType = new Dictionary<string, string>();
        //private Dictionary<string, string> dicDictionaryDosage = new Dictionary<string, string>();
        //private Dictionary<string, string> dicDictionarySpecification = new Dictionary<string, string>();
        //private Dictionary<string, string> dicDictionaryMeasurementUnit = new Dictionary<string, string>();
        //private Dictionary<string, string> dicDictionaryPiecemealUnit = new Dictionary<string, string>();
        private Dictionary<string, string> dicDrugStorageType = new Dictionary<string, string>();
        private Dictionary<string, string> dicMedicalCategoryDetail = new Dictionary<string, string>();
        private Dictionary<string, string> dicDrugClinicalCategory = new Dictionary<string, string>();
        private Dictionary<string, string> dicPurchaseManageCategoryDetail = new Dictionary<string, string>();
        private Dictionary<string, string> dicSpecialDrugCategory = new Dictionary<string, string>();
        private Dictionary<string, string> dicBusinessScope = new Dictionary<string, string>();
        #endregion



        public FormDrugInfo()
        {
            InitializeComponent();
        }

        private enum OperateType
        {
            Add,
            Edit,
            Browse,
            Search,
            Delete
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

        private void GenerateValidators()
        {
            //HandelValidation(this.txtBarCode);
            //HandelValidation(this.txtProductName);
            //HandelValidation(this.txtGeneralName);            
            //HandelValidation(this.txtFactoryName);
            //HandelValidation(this.txtFactoryNameAbbre);
            
            //HandelValidation(this.cmbMeasureUnitCode);
            //HandelValidation(this.cmbDrugSpecificationCode);
            //HandelValidation(this.cmbDrugDosageCode);
            //HandelValidation(this.cmbDrugCategoryCode);
            
            //HandelValidation(this.cmbDictionaryUserDefinedTypeCode);
            //HandelValidation(this.cmbDictionaryPiecemealUnitCode);
            //HandelValidation(this.cmbDrugStorageTypeCode);
            //HandelValidation(this.cmbBusinessScopeCode);
           

        }

        //private void GetComponentDatas()
        //{
        //    try
        //    {
        //        string msg = string.Empty;

        //        _ListDictionaryMeasurementUnit = PharmacyDatabaseService.AllDictionaryMeasurementUnits(out msg).ToList();

        //        _ListDrugCategory = PharmacyDatabaseService.AllDrugCategorys(out msg).ToList();
        //        foreach (DrugCategory category in _ListDrugCategory)
        //        {
        //            //dicDrugCategory.Add(category.Code, category.Name);
        //        }

        //        _ListDictionaryUserDefinedType = PharmacyDatabaseService.AllDictionaryUserDefinedTypes(out msg).ToList();
        //        foreach (DictionaryUserDefinedType userDefinedType in _ListDictionaryUserDefinedType)
        //        {
        //            dicDictionaryUserDefinedType.Add(userDefinedType.Code, userDefinedType.Name);
        //        }

        //        _ListDictionaryDosage = PharmacyDatabaseService.AllDictionaryDosages(out msg).ToList();
               

        //        _ListDictionarySpecification = PharmacyDatabaseService.AllDictionarySpecifications(out msg).ToList();
                

        //        _ListDictionaryPiecemealUnit = PharmacyDatabaseService.AllDictionaryPiecemealUnits(out msg).ToList();
               

        //        _ListMedicalCategoryDetail = PharmacyDatabaseService.AllMedicalCategoryDetails(out msg).ToList();
        //        foreach (MedicalCategoryDetail unit in _ListMedicalCategoryDetail)
        //        {
        //            dicMedicalCategoryDetail.Add(unit.Code, unit.Name);                    //to do 
        //        }

        //        _ListDrugClinicalCategory = PharmacyDatabaseService.AllDrugClinicalCategorys(out msg).ToList();
        //        foreach (DrugClinicalCategory unit in _ListDrugClinicalCategory)
        //        {
        //            dicDrugClinicalCategory.Add(unit.Code, unit.Name);
        //        }

        //        _ListDictionaryStorageType = PharmacyDatabaseService.AllDictionaryStorageTypes(out msg).ToList();
        //        foreach (DictionaryStorageType unit in _ListDictionaryStorageType)
        //        {
        //            dicDrugStorageType.Add(unit.Code, unit.Name);
        //        }

        //        _ListPurchaseManageCategoryDetail = PharmacyDatabaseService.AllPurchaseManageCategoryDetails(out msg).ToList();
        //        foreach (PurchaseManageCategoryDetail unit in _ListPurchaseManageCategoryDetail)
        //        {
        //            dicPurchaseManageCategoryDetail.Add(unit.Code, unit.Name);
        //        }

        //        _ListSpecialDrugCategory = PharmacyDatabaseService.AllSpecialDrugCategorys(out msg).ToList();
        //        foreach (SpecialDrugCategory unit in _ListSpecialDrugCategory)
        //        {
        //            dicSpecialDrugCategory.Add(unit.Code, unit.Name);
        //        }

        //        _ListBusinessScope = PharmacyDatabaseService.AllBusinessScopes(out msg).ToList();
        //        foreach (BusinessScope unit in _ListBusinessScope)
        //        {
        //            dicBusinessScope.Add(unit.Code, unit.Name);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK);
        //        Log.Error(ex);
        //    }
        //}

        //private void InitialComponentData()
        //{
        //    #region clear combobox
        //    this.cmbDrugCategoryCode.Items.Clear();
        //    this.cmbDictionaryPiecemealUnitCode.Items.Clear();
        //    this.cmbDictionaryUserDefinedTypeCode.Items.Clear();
        //    this.cmbDrugDosageCode.Items.Clear();
        //    this.cmbDrugSpecificationCode.Items.Clear();            
        //    this.cmbMeasureUnitCode.Items.Clear();
        //    this.cmbBusinessScopeCode.Items.Clear();
        //    this.cmbMedicalCategoryDetailCode.Items.Clear();
        //    this.cmbPurchaseManageCategoryDetailCode.Items.Clear();
        //    this.cmbSpecialDrugCategoryCode.Items.Clear();
        //    this.cmbDrugClinicalCategoryCode.Items.Clear();


        //    #endregion

        //    #region bind combobox
        //    this.cmbDrugCategoryCode.DataSource = _ListDrugCategory;
        //    this.cmbDrugCategoryCode.DisplayMember = "Name";
        //    this.cmbDrugCategoryCode.ValueMember = "Name";


        //    this.cmbDictionaryUserDefinedTypeCode.DataSource = _ListDictionaryUserDefinedType;
        //    this.cmbDictionaryUserDefinedTypeCode.DisplayMember = "Name";
        //    this.cmbDictionaryUserDefinedTypeCode.ValueMember = "Code";

        //    this.cmbMeasureUnitCode.DataSource = _ListDictionaryMeasurementUnit;
        //    this.cmbMeasureUnitCode.DisplayMember = "Name";
        //    this.cmbMeasureUnitCode.ValueMember = "Name";

        //    this.cmbDrugDosageCode.DataSource = _ListDictionaryDosage;
        //    this.cmbDrugDosageCode.DisplayMember = "Name";
        //    this.cmbDrugDosageCode.ValueMember = "Name";

        //    this.cmbDrugSpecificationCode.DataSource = _ListDictionarySpecification;
        //    this.cmbDrugSpecificationCode.DisplayMember = "Name";
        //    this.cmbDrugSpecificationCode.ValueMember = "Name";

        //    this.cmbDictionaryPiecemealUnitCode.DataSource = _ListDictionaryPiecemealUnit;
        //    this.cmbDictionaryPiecemealUnitCode.DisplayMember = "Name";
        //    this.cmbDictionaryPiecemealUnitCode.ValueMember = "Name";


         // this.cmbBusinessScopeCode.DataSource = _ListBusinessScope;
        //    this.cmbBusinessScopeCode.DisplayMember = "Name";
        //    this.cmbBusinessScopeCode.ValueMember = "Code";

        //    this.cmbMedicalCategoryDetailCode.DataSource = _ListMedicalCategoryDetail;
        //    this.cmbMedicalCategoryDetailCode.DisplayMember = "Name";
        //    this.cmbMedicalCategoryDetailCode.ValueMember = "Code";

        //    this.cmbDrugClinicalCategoryCode.DataSource = _ListDrugClinicalCategory;
        //    this.cmbDrugClinicalCategoryCode.DisplayMember = "Name";
        //    this.cmbDrugClinicalCategoryCode.ValueMember = "Code";

        //    this.cmbPurchaseManageCategoryDetailCode.DataSource = _ListPurchaseManageCategoryDetail;
        //    this.cmbPurchaseManageCategoryDetailCode.DisplayMember = "Name";
        //    this.cmbPurchaseManageCategoryDetailCode.ValueMember = "Code";

        //    this.cmbSpecialDrugCategoryCode.DataSource = _ListSpecialDrugCategory;
        //    this.cmbSpecialDrugCategoryCode.DisplayMember = "Name";
        //    this.cmbSpecialDrugCategoryCode.ValueMember = "Code";

        //    this.cmbDrugStorageTypeCode.DataSource = _ListDictionaryStorageType;
        //    this.cmbDrugStorageTypeCode.DisplayMember = "Name";
        //    this.cmbDrugStorageTypeCode.ValueMember = "Code";
        //    #endregion

        //}

        private void InitialEditTab()
        {
            if (_TYPE == OperateType.Edit)
            {                
                BindEntityToControls();
            }
            else if (_TYPE == OperateType.Add)
            {
                ClearControls(this.tabPageEdit);
                //this.chkIsMainMaintenance.Checked = true;
            }
        }

 

        private void ClearControls(Control con)
        {
            if (con.HasChildren)
            {
                    foreach (Control child in con.Controls)
                    {
                        ClearControls(child);
                    }
             }
            else
            {
                if (con is TextBox || con is RichTextBox)
                    con.Text = string.Empty;
                else if (con is CheckBox)
                    ((CheckBox)con).Checked = false;
                else if (con is NumericUpDown)
                    ((NumericUpDown)con).Value = 1;
                else if (con is ComboBox)
                    ((ComboBox)con).SelectedIndex = -1;
                //else if (con is MaskedTextBox)//Add By SHEN 2013.08.04
                //{
                //    ((MaskedTextBox)txtStandardCode).Text = string.Empty;
                //}
            }
            
        }

        //when modify data,initial controls 
        private void BindEntityToControls()
        {
            try
            {
                //#region bind control data to entity
                //this.txtProductName.Text = entity.ProductName;
                //this.txtBarCode.Text = entity.BarCode;
                //this.txtFactoryName.Text = entity.FactoryName;
                //this.txtFactoryNameAbbre.Text = entity.FactoryNameAbbreviation;
                //this.txtGeneralName.Text = entity.ProductGeneralName;
                //this.txtProductOtherName.Text = entity.ProductOtherName;

                //this.ckEnable.Checked = entity.Enabled;
                //this.txtLicensePermissionNumber.Text = entity.LicensePermissionNumber;
                //this.txtPerformanceStandards.Text = entity.PerformanceStandards;
       
                //this.cmbMeasureUnitCode.Text = entity.DictionaryMeasurementUnitCode;
                //this.cmbDrugDosageCode.Text = entity.DictionaryDosageCode;
                //this.cmbDrugSpecificationCode.Text = entity.DictionarySpecificationCode;

                //this.cmbDrugCategoryCode.Text = entity.DrugCategoryCode;

                //this.cmbDictionaryUserDefinedTypeCode.SelectedValue = entity.DictionaryUserDefinedTypeCode;
                //this.cmbDictionaryPiecemealUnitCode.Text = entity.DictionaryPiecemealUnitCode;
                //this.txtPiecemealSpecification.Text = entity.PiecemealSpecification;
                //if (!string.IsNullOrEmpty(entity.BusinessScopeCode))
                //{
                //    this.cmbBusinessScopeCode.SelectedValue = entity.BusinessScopeCode;
                //}
                //else
                //{
                //    this.cmbBusinessScopeCode.SelectedIndex = -1;
                //}
                //if (!string.IsNullOrEmpty(entity.MedicalCategoryDetailCode))
                //{
                //    this.cmbMedicalCategoryDetailCode.SelectedValue = entity.MedicalCategoryDetailCode;
                //}
                //else
                //{
                //    this.cmbMedicalCategoryDetailCode.SelectedIndex = -1;
                //}
                //if (!string.IsNullOrEmpty(entity.DrugClinicalCategoryCode))
                //{
                //    this.cmbDrugClinicalCategoryCode.SelectedValue = entity.DrugClinicalCategoryCode;
                //}
                //else
                //{
                //    this.cmbDrugClinicalCategoryCode.SelectedIndex = -1;
                //}
                //if (!string.IsNullOrEmpty(entity.PurchaseManageCategoryDetailCode))
                //{
                //    this.cmbPurchaseManageCategoryDetailCode.SelectedValue = entity.PurchaseManageCategoryDetailCode;
                //}
                //else
                //{
                //    this.cmbPurchaseManageCategoryDetailCode.SelectedIndex = -1;
                //}
                //if (!string.IsNullOrEmpty(entity.SpecialDrugCategoryCode))
                //{
                //    this.cmbSpecialDrugCategoryCode.SelectedValue = entity.SpecialDrugCategoryCode;
                //}
                //else
                //{
                //    this.cmbSpecialDrugCategoryCode.SelectedIndex = -1;
                //}
                //if (!string.IsNullOrEmpty(entity.DrugStorageTypeCode))
                //{
                //    this.cmbDrugStorageTypeCode.SelectedValue = entity.DrugStorageTypeCode;
                //}
                //else
                //{
                //    this.cmbDrugStorageTypeCode.SelectedIndex = -1;
                //}
             

                //this.chkIsSpecialDrugCategory.Checked = entity.IsSpecialDrugCategory;

                //this.txtPackage.Text = entity.Package;
                //this.nudValidPeriod.Value = entity.ValidPeriod;

                //this.nudPiecemealNumber.Value = entity.PiecemealNumber;
                //this.nudNationalSalePrice.Value = entity.NationalSalePrice;
                //this.nudPurchasePrice.Value = entity.PurchasePrice;
                //this.nudPrice.Value = entity.Price;
                //this.nudLimitedLowPrice.Value = entity.LimitedLowPrice;
                //this.nudLimitedUpPrice.Value = entity.LimitedUpPrice;
                //this.nudRetailPrice.Value = entity.RetailPrice;
                //this.nudWholeSalePrice.Value = entity.WholeSalePrice;
                //this.nudTagPrice.Value = entity.TagPrice;

                ////this.nudSalePrice.Value = entity.SalePrice ;  

                //this.chkIsMedicalInsurance.Checked = entity.IsMedicalInsurance;
                //this.chkIsPrescription.Checked = entity.IsPrescription;
                //this.chkIsImport.Checked = entity.IsImport;
                //this.chkIsMainMaintenance.Checked = entity.IsMainMaintenance;

                //this.txtCode.Text = entity.Code;
                //this.rtbDescription.Text = entity.Description;

                //this.chkApproval.Checked = entity.IsApproval;
                //this.dtpApprovalDate.Value = entity.ApprovalDate;

                //this.txtStandardCode.Text = entity.StandardCode;//Add By SHEN 2013.08.04

                //this.nudMaxInventory.Value = entity.MaxInventoryCount;
                //this.nudMinInventory.Value = entity.MinInventoryCount;
                //#endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }

        }

        private void SaveData(bool isAdd)
        {
            try
            {
                string msg = string.Empty;

                //#region bind control data to entity
                //entity.ProductName = this.txtProductName.Text.Trim();
                //entity.BarCode = this.txtBarCode.Text.Trim().ToUpper();
                //entity.FactoryName = this.txtFactoryName.Text.Trim();
                //entity.FactoryNameAbbreviation = this.txtFactoryNameAbbre.Text.Trim();
                //entity.ProductGeneralName = this.txtGeneralName.Text.Trim();
                //entity.ProductOtherName = this.txtProductOtherName.Text.Trim();
                //entity.Code = this.txtCode.Text.Trim();
                //entity.Description = this.rtbDescription.Text.Trim();

                //entity.Enabled = this.ckEnable.Checked;
                //entity.LicensePermissionNumber = this.txtLicensePermissionNumber.Text.Trim().ToUpper();
                //entity.DictionaryMeasurementUnitCode = this.cmbMeasureUnitCode.Text;
                //entity.DictionaryDosageCode = this.cmbDrugDosageCode.Text;
                //entity.DictionarySpecificationCode = this.cmbDrugSpecificationCode.Text;

                //entity.DrugCategoryCode = this.cmbDrugCategoryCode.Text.Trim();
                //entity.DictionaryUserDefinedTypeCode = this.cmbDictionaryUserDefinedTypeCode.SelectedValue.ToString();
                //entity.DictionaryPiecemealUnitCode = this.cmbDictionaryPiecemealUnitCode.SelectedValue.ToString();
                //entity.PiecemealSpecification = this.txtPiecemealSpecification.Text.Trim();
                //entity.BusinessScopeCode = this.cmbBusinessScopeCode.SelectedValue.ToString();
                //entity.DrugStorageTypeCode = this.cmbDrugStorageTypeCode.SelectedValue.ToString();
                //if (this.cmbMedicalCategoryDetailCode.SelectedIndex > -1)
                //{
                //    entity.MedicalCategoryDetailCode = this.cmbMedicalCategoryDetailCode.SelectedValue.ToString();
                //}
                //else
                //{
                //    entity.MedicalCategoryDetailCode = string.Empty;
                //}
                //if (this.cmbDrugClinicalCategoryCode.SelectedIndex > -1)
                //{
                //    entity.DrugClinicalCategoryCode = this.cmbDrugClinicalCategoryCode.SelectedValue.ToString();
                //}
                //else
                //{
                //    entity.DrugClinicalCategoryCode = string.Empty;
                //}
                //if (this.cmbPurchaseManageCategoryDetailCode.SelectedIndex > -1)
                //{
                //    entity.PurchaseManageCategoryDetailCode = this.cmbPurchaseManageCategoryDetailCode.SelectedValue.ToString();
                //}
                //else
                //{
                //    entity.PurchaseManageCategoryDetailCode = string.Empty;
                //}
                //if (this.cmbSpecialDrugCategoryCode.SelectedIndex > -1)
                //{
                //    entity.SpecialDrugCategoryCode = this.cmbSpecialDrugCategoryCode.SelectedValue.ToString();
                //}
                //else
                //{
                //    entity.PurchaseManageCategoryDetailCode = string.Empty;
                //}

                //entity.PiecemealNumber = (int)this.nudPiecemealNumber.Value;

                //entity.Package = this.txtPackage.Text.Trim();

                //entity.NationalSalePrice = this.nudNationalSalePrice.Value;
                //entity.TagPrice = this.nudTagPrice.Value;
                //entity.PurchasePrice = this.nudPurchasePrice.Value;
                //entity.WholeSalePrice = this.nudWholeSalePrice.Value;
                //entity.RetailPrice = this.nudRetailPrice.Value;
                
                //entity.LimitedLowPrice = this.nudLimitedLowPrice.Value;
                //entity.LimitedUpPrice = this.nudLimitedUpPrice.Value;
                //entity.LowSalePrice = this.nudLowSalePrice.Value;
                //entity.Price = this.nudPrice.Value;
                //entity.SalePrice = this.nudPrice.Value;   //弃用？

                //entity.IsMainMaintenance = this.chkIsMainMaintenance.Checked;
                //entity.IsMedicalInsurance = this.chkIsMedicalInsurance.Checked;
                //entity.IsPrescription = this.chkIsPrescription.Checked;
                //entity.IsImport = this.chkIsImport.Checked;
                //entity.StandardCode = this.txtStandardCode.Text;

                //entity.MinInventoryCount = (int)this.nudMinInventory.Value;
                //entity.MaxInventoryCount = (int)this.nudMaxInventory.Value;
                //#endregion

                if (isAdd)
                {
                    entity.Id = Guid.NewGuid();
                    entity.CreateTime = DateTime.Now;
                    entity.CreateUserId = AppClientContext.CurrentUser.Id;

                    entity.IsApproval = false;
                    
                    
                    PharmacyDatabaseService.AddDrugInfo(out msg, entity);

                    #region insert to InventoryRecord table
                    InventoryRecord record = new InventoryRecord();
                    record.Id = Guid.NewGuid();
                    record.DrugInfoId = entity.Id;
                    //record.MaxInventoryCount = (int)this.nudMaxInventory.Value;
                    //record.MinInventoryCount = (int)this.nudMinInventory.Value;
                   
                    PharmacyDatabaseService.AddInventoryRecord(out msg, record);

                    #endregion


                }
                else
                {
                    entity.IsApproval = false;
                    
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUserId = AppClientContext.CurrentUser.Id;

                    PharmacyDatabaseService.SaveDrugInfo(out msg, entity);

                    #region update InventoryRecord table
                    InventoryRecord record = PharmacyDatabaseService.GetInventoryRecordByDrugInfoID(out msg, entity.Id);
                    //record.MaxInventoryCount = (int)this.nudMaxInventory.Value;
                    //record.MinInventoryCount = (int)this.nudMinInventory.Value;

                    PharmacyDatabaseService.SaveInventoryRecord(out msg, record);
                    #endregion

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

        private bool ValidateControls(out string msg)
        {
            msg = String.Empty;
            foreach (BaseValidator v in _allValidator)
            {
                v.Validate();
                if (!v.IsValid)
                {
                    msg = v.ErrorMessage;
                    return false;
                }
            }
            return true;
        }

        //字段验证处理
        private void HandelValidation(Control control)
        {
            if (control is ComboBox)
            {
                RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();
                requiredFieldValidator.ErrorMessage = "必填项！";
                requiredFieldValidator.ControlToValidate = control;
                _allValidator.Add(requiredFieldValidator);
            }
            switch (control.Name)
            {
                //Required 验证
                #region Required 验证
                case "txtProductName":
                case "txtGeneralName":
                case "txtBarCode":
                case "txtFactoryName":
                case "txtStandardCode"://Add By SHEN
                case "txtFactoryNameAbbre":            

                
                    RequiredFieldValidator requiredFieldValidator = new RequiredFieldValidator();
                    requiredFieldValidator.ErrorMessage = "必填项！";
                    requiredFieldValidator.ControlToValidate = control;
                    _allValidator.Add(requiredFieldValidator);
                    break;
                case "nudSalePrice":
                    CompareValidator compareValidator = new CompareValidator();
                    //compareValidator.ControlToCompare = this.nudNationalSalePrice;
                    //compareValidator.ControlToValidate = this.nudRetailPrice;
                    compareValidator.Type = ValidationDataType.Double;
                    compareValidator.Operator = ValidationCompareOperator.LessThanEqual;
                    compareValidator.ErrorMessage = "销售价高于国家零售价!";
                    _allValidator.Add(compareValidator);
                    break;



                #endregion
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
            _searchBarCode = txtSearchBarCode.Text.Trim();
            _searchProductGeneralName = txtSearchProductGeneralName.Text.Trim();
            _searchProductName = txtSearchProductName.Text.Trim();

            int pageIndex = this.pagerControl1.PageIndex;
            int pageSize = this.pagerControl1.PageSize;
            GetListDrugInfo(pageIndex,pageSize);
            
            this.dataGridView1.DataSource = _listDrugInfo;
            ProcessGridViewAppearance();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _searchBarCode = txtSearchBarCode.Text.Trim();
            _searchProductGeneralName = txtSearchProductGeneralName.Text.Trim();
            _searchProductName = txtSearchProductName.Text.Trim();

            int pageIndex = 1;
            int pageSize = this.pagerControl1.PageSize;
            GetListDrugInfo(pageIndex, pageSize);

            this.dataGridView1.DataSource = _listDrugInfo;
            this.pagerControl1.RecordCount = pageInfo.RecordCount;
            this.pagerControl1.PageIndex = 1;
            ProcessGridViewAppearance();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _TYPE = OperateType.Add;
                SetEditMode(true);
                InitialEditTab();
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                _TYPE = OperateType.Edit;
                if (dataGridView1.CurrentRow != null)
                {
                    int curRowIndex = dataGridView1.CurrentRow.Index;
                    entity = _listDrugInfo[curRowIndex];
                    InitialEditTab();

                    SetEditMode(true);
                    //编辑操作

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
                DrugInfo oldDrugInfo = entity;
                DrugInfo sUnit = this.ucDrugInfo1.InitDrugInfo(entity);
                string msg = string.Empty;

                 

                if (!ValidateControls(out msg))
                    return;

                if (_TYPE == OperateType.Add)
                {  
                  msg = PharmacyDatabaseService.AddDrugInfoApproveFlow(sUnit, this.ucDrugInfo1.FlowTypeID, AppClientContext.CurrentUser.Id, "新增药品");
          
                    //SaveData(true);
                }
                else if (_TYPE == OperateType.Edit)
                {

                    msg = PharmacyDatabaseService.ModifyDrugInfoApproveFlow(sUnit, this.ucDrugInfo1.FlowTypeID, AppClientContext.CurrentUser.Id, "修改药品");
          
                   // SaveData(false);

                }
                if (msg.Length == 0)
                    MessageBox.Show("数据保存成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Refresh();
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

        private void FormDrugInfo_Load(object sender, EventArgs e)
        {            
          // GetComponentDatas();
            //InitialComponentData();
            GenerateValidators();

            SetMode(OperateType.Browse);

            GetListDrugInfo(1, this.pagerControl1.PageSize);
            this.pagerControl1.RecordCount = pageInfo.RecordCount;
            this.pagerControl1.PageIndex = 1;
            this.dataGridView1.DataSource = _listDrugInfo;
            ProcessGridViewAppearance();
        }

        private void GetListDrugInfo(int pageIndex, int pageSize)
        {
            try
            {
                string msg = string.Empty;
                _listDrugInfo = null;

                QueryDrugInfoModel qModel = new QueryDrugInfoModel();
                qModel.ProductName = _searchProductName;
                qModel.ProductGeneralName = _searchProductGeneralName;
                qModel.BarCode = _searchBarCode;
                qModel.CreateTimeFrom = DateTime.Now.AddYears(3);
                qModel.CreateTimeTo = DateTime.Now.AddYears(-3);
                qModel.UpdateTimeFrom = DateTime.Now.AddYears(3);
                qModel.UpdateTimeTo = DateTime.Now.AddYears(-3);
                qModel.ApprovalDateFrom = DateTime.Now.AddYears(3);
                qModel.ApprovalDateTo = DateTime.Now.AddYears(-3);

                qModel.PiecemealNumberFrom = 0;
                qModel.PiecemealNumberTo = 999999;
                qModel.LimitedLowPriceFrom = 0;
                qModel.LimitedLowPriceTo = (decimal)999999.99;
                qModel.LimitedUpPriceFrom = 0;
                qModel.LimitedUpPriceTo = (decimal)999999.99;
                qModel.LowSalePriceFrom = 0;
                qModel.LowSalePriceTo = (decimal)999999.99;
                qModel.NationalSalePriceFrom = 0;
                qModel.NationalSalePriceTo = (decimal)999999.99;
                qModel.PriceFrom = 0;
                qModel.PriceTo = (decimal)999999.99;
                qModel.PurchasePriceFrom = 0;
                qModel.PurchasePriceTo = (decimal)999999.99;
                qModel.WholeSalePriceFrom = 0;
                qModel.WholeSalePriceTo = (decimal)999999.99;
                qModel.RetailPriceFrom = 0;
                qModel.RetailPriceTo = (decimal)999999.99;
                qModel.SalePriceFrom = 0;
                qModel.SalePriceTo = (decimal)999999.99;
                qModel.TagPriceFrom = 0;
                qModel.TagPriceTo = (decimal)999999.99;
                qModel.MinInventoryCountFrom = 0;
                qModel.MinInventoryCountTo = 99999;
                qModel.MaxInventoryCountFrom = 0;
                qModel.MaxInventoryCountTo = 99999;

                _listDrugInfo = PharmacyDatabaseService.SearchPagedDrugInfosByQueryModel(out pageInfo, qModel, pageIndex, pageSize).ToList();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                string msg = string.Empty;
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("DrugCategoryCode"))
                {
                    //string code = e.Value.ToString();
                    //if (dicDrugCategory.ContainsKey(code))
                    //{
                    //    e.Value = dicDrugCategory[code];
                    //}
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("DictionaryUserDefinedTypeCode"))
                {
                    if (e.Value != null)
                    {
                        string code = e.Value.ToString();
                        if (dicDictionaryUserDefinedType.ContainsKey(code))
                            e.Value = dicDictionaryUserDefinedType[code];
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("DrugStorageTypeCode"))
                {
                    if (e.Value != null)
                    {
                        string code = e.Value.ToString();
                        if (dicDrugStorageType.ContainsKey(code))
                            e.Value = dicDrugStorageType[code];
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("SpecialDrugCategoryCode"))
                {
                    if (e.Value != null)
                    {
                        string code = e.Value.ToString();
                        if (dicSpecialDrugCategory.ContainsKey(code))
                            e.Value = dicSpecialDrugCategory[code];
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("PurchaseManageCategoryDetailCode"))
                {
                    if (e.Value != null)
                    {
                        string code = e.Value.ToString();
                        if (dicPurchaseManageCategoryDetail.ContainsKey(code))
                            e.Value = dicPurchaseManageCategoryDetail[code];
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("MedicalCategoryDetailCode"))
                {
                    if (e.Value != null)
                    {
                        string code = e.Value.ToString();
                        if (dicMedicalCategoryDetail.ContainsKey(code))
                            e.Value = dicMedicalCategoryDetail[code];
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("DrugClinicalCategoryCode"))
                {
                    if (e.Value != null)
                    {
                        string code = e.Value.ToString();
                        if (dicDrugClinicalCategory.ContainsKey(code))
                            e.Value = dicDrugClinicalCategory[code];
                    }
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("BusinessScopeCode"))
                {
                    if (e.Value != null)
                    {
                        string code = e.Value.ToString();
                        if (dicBusinessScope.ContainsKey(code))
                            e.Value = dicBusinessScope[code];
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
         
        
         

        }

        private void ProcessGridViewAppearance()
        {
            try
            {
                foreach (DataGridViewColumn clm in this.dataGridView1.Columns)
                {
                    switch (clm.Name)
                    {
                        case "ProductName":
                            clm.HeaderText = "药品名称";
                            clm.Visible = true;
                            break;
                        case "Code":
                            clm.HeaderText = "编码";
                            clm.Visible = true;
                            break;
                        case "StandardCode":
                            clm.HeaderText = "本位码";
                            clm.Visible = true;
                            break;
                        case "Description":
                            clm.HeaderText = "备注";
                            clm.Visible = true;
                            break;
                        case "BarCode":
                            clm.HeaderText = "条形码";
                            clm.Visible = true;
                            break;
                        case "LicensePermissionNumber":
                            clm.HeaderText = "批准文号";
                            clm.Visible = true;
                            break;
                        case "PerformanceStandards":
                            clm.HeaderText = "执行标准";
                            clm.Visible = true;
                            break;
                        case "ProductGeneralName":
                            clm.HeaderText = "药品通用名";
                            clm.Visible = true;
                            break;
                        case "FactoryName":
                            clm.HeaderText = "厂家名称";
                            clm.Visible = true;
                            break;
                        case "PiecemealSpecification":
                            clm.HeaderText = "拆零规格";
                            clm.Visible = true;
                            break;
                        case "PiecemealNumber":
                            clm.HeaderText = "拆零数量";
                            clm.Visible = true;
                            break;
                        case "NationalSalePrice":
                            clm.HeaderText = "指导售价";
                            clm.Visible = true;
                            break;
                        case "PurchasePrice":
                            clm.HeaderText = "采购价";
                            clm.Visible = true;
                            break;
                        case "WholeSalePrice":
                            clm.HeaderText = "批发价";
                            clm.Visible = true;
                            break;
                        case "RetailPrice":
                            clm.HeaderText = "零售价";
                            clm.Visible = true;
                            break;
                        case "IsMedicalInsurance":
                            clm.HeaderText = "医保";
                            clm.Visible = true;
                            break;
                        case "IsPrescription":
                            clm.HeaderText = "处方";
                            clm.Visible = true;
                            break;
                        case "IsImport":
                            clm.HeaderText = "进口";
                            clm.Visible = true;
                            break;
                        case "Enabled":
                            clm.HeaderText = "启用";
                            clm.Visible = true;
                            break;
                        case "DrugCategoryCode":
                            clm.HeaderText = "商品分类";
                            clm.Visible = true;
                            break;                        
                        case "DictionaryUserDefinedTypeId":
                            clm.HeaderText = "自定义类型";
                            clm.Visible = true;
                            break;
                        case "IsSpecialDrugCategory":
                            clm.HeaderText = "特殊管理药品";
                            clm.Visible = true;
                            break;   
                        case "SpecialDrugCategoryCode":
                            clm.HeaderText = "特殊管理药品类型";
                            clm.Visible = true;
                            break;
                        case "MedicalCategoryDetailCode":
                            clm.HeaderText = "医疗分类";
                            clm.Visible = true;
                            break;
                        case "DrugClinicalCategoryCode":
                            clm.HeaderText = "临床分类";
                            clm.Visible = true;
                            break;
                        case "DrugStorageTypeCode":
                            clm.HeaderText = "存储方式";
                            clm.Visible = true;
                            break; 
                        case "DictionaryMeasurementUnitCode":
                            clm.HeaderText = "单位";
                            clm.Visible = true;
                            break;
                        case "DictionaryDosageCode":
                            clm.HeaderText = "剂型";
                            clm.Visible = true;
                            break;                       
                        case "DictionarySpecificationCode":
                            clm.HeaderText = "规格";
                            clm.Visible = true;
                            break;
                        case "DictionaryPiecemealUnitCode":
                            clm.HeaderText = "拆零单位";
                            clm.Visible = true;
                            break;

                            
                        default:
                            clm.Visible = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        private void pagerControl1_DataPaging()
        {
            _searchBarCode = txtSearchBarCode.Text.Trim();
            _searchProductGeneralName = txtSearchProductGeneralName.Text.Trim();
            _searchProductName = txtSearchProductName.Text.Trim();

            int pageIndex = this.pagerControl1.PageIndex;
            int pageSize = this.pagerControl1.PageSize;
            GetListDrugInfo(pageIndex, pageSize);

            this.dataGridView1.DataSource = _listDrugInfo;
            ProcessGridViewAppearance();
        }

        private void chkIsSpecialDrugCategory_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkIsSpecialDrugCategory.Checked)
            //{
            //    this.cmbSpecialDrugCategoryCode.Enabled = true;
            //}
            //else
            //{
            //    this.cmbSpecialDrugCategoryCode.Enabled = false;
            //    this.cmbSpecialDrugCategoryCode.SelectedIndex = -1;
            //}
        }

        private void btnSearchFactory_Click(object sender, EventArgs e)
        {
            try
            {
                ManufacturerSelector selector = new ManufacturerSelector();
                selector.ShowDialog();
                //if (selector.Result == System.Windows.Forms.DialogResult.OK)
                //{
                //    this.txtFactoryName.Text = selector.ManufactureName;
                //    this.txtFactoryNameAbbre.Text = selector.ManufacturePinYin;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }
    }
}
