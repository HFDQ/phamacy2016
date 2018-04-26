using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.UI.Common.Helper
{
    public static class ResourceStrings
    {
        #region 公共资源名称
        public const string Common_UnKnown = "未知";
        public const string Common_Male = "男";
        public const string Common_Female = "女";
        public const string Common_All = "所有";

        public const string Common_CreateUserId = "创建用户";
        public const string Common_CreateTime = "创建日期";
        public const string Common_StoreId = "门店";
        public const string Common_StartTime = "CreateTimeFrom";
        public const string Common_EndTime = "CreateTimeTo";

        public const string Common_Name = "名称";
        public const string Common_Description = "描述";
        public const string Common_Decription = "描述";
        public const string Common_Code = "编号";
        public const string Common_Address = "地址";
        public const string Common_Enabled = "启用";
        public const string Common_UnEnabled = "禁用";
        public const string Common_Tel = "电话";
        public const string Common_Phone = "电话";
        public const string Common_Area = "总面积";
        public const string Common_MnemonicCode = "助记码";
        public const string Common_IDFile = "身份证复印件";
        public const string Common_IDNumber = "身份证";
        public const string Common_Birthday = "出生年月";
        public const string Common_Gender = "性别";
        public const string Common_PinyinCode = "拼音码";
        public const string Common_ContactName = "联系人";
        public const string Common_ContactTel = "联系电话";
        public const string Common_LegalPerson = "法人";
        public const string Common_BusinessScope = "生产经营范围";
        public const string Common_BusinessTypeId = "经营方式";
        public const string Common_SalesAmount = "年销售额";
        public const string Common_Fax = "传真";
        public const string Common_Email = "邮箱";
        public const string Common_WebAddress = "网站";
        public const string Common_OutDate = "过期日";
        public const string Common_GSPGMPLicCode = "GSMP证书号";
        public const string Common_GSPGMPLicOutdate = "GSP/GMP证书有效期止";
        public const string Common_BusinessLicCode = "营业执照编号";
        public const string Common_BusinessLicOutdate = "营业执照有效期止";
        public const string Common_PharmaceuticalTradingLicCode = "药品经营许可证号";
        public const string Common_PharmaceuticalTradingLicOutdate = "药品经营许可证有效期止";
        public const string Common_TaxRegistrationCode = "税务登记号";
        public const string Common_LastAnnualDte = "最新年检日期";
        #endregion

        #region Store
        public const string Store_Head = "负责人";
        public const string Store_StoreTypeValue = "门店类型";
        #endregion

        #region Vehicle
        public const string Vehicle_Type = "车类型";
        public const string Vehicle_Cubage = "容积";
        public const string Vehicle_LicensePlate = "车牌号";
        public const string Vehicle_Rule = "规则";
        public const string Vehicle_Other = "其他参数";
        public const string Vehicle_Driver = "驾驶员";
        public const string Vehicle_Status = "状态";
        public const string Vehicle_VehicleCategoryValue = "类别";
        public const string Vehicle_IsOutCheck = "是否外审";
        #endregion

        #region Rareword
        public const string Rareword_PinYin = "拼音";
        public const string Rareword_Word = "汉字";
        public const string Rareword_Parts = "汉字拆分 ";
        #endregion

        #region WarehouseZone
        public const string WarehouseZone_WarehouseZoneTypeValue = "库区类型";
        public const string WarehouseZone_WarehouseId = "所属仓库";
        public const string WarehouseZone_DictionaryStorageTypeId = "储藏方式";
        public const string WarehouseZone_DictionaryMeasurementUnitId = "专属存储单位";
        #endregion

        #region Warehouse
        public const string Warehouse_ManagementCompany = "管理单位";
        public const string Warehouse_RentCompany = "租赁单位";
        public const string Warehouse_RentYear = "租赁年限";
        public const string Warehouse_RentStartTime = "租赁开始时间";
        public const string Warehouse_RentEndTime = "租赁结束时间";
        public const string Warehouse_ShadeArea = "阴凉面积";
        public const string Warehouse_NormalArea = "常温面积";
        public const string Warehouse_ColdArea = "冷库面积";
        public const string Warehouse_YPFZArea = "饮片分装室面积";
        public const string Warehouse_YHYSSArea = "养护验收室面积";
        public const string Warehouse_PHCArea = "配货场面积";
        public const string Warehouse_TYZQArea = "特药专区面积";
        public const string Warehouse_DWArea = "低温面积";
        #endregion

        #region Module
        public const string Module_AuthKey = "授权密钥";
        public const string Module_ModuleCatetoryId = "模块类型";
        #endregion

        #region DrugType
        public const string DrugType_DrugCategoryId = "药物分类";
        #endregion


        #region SupplyUnitSalesman
        public const string SupplyUnitSalesman_Enabled = "锁定";
        public const string SupplyUnitSalesman_OutDate = "授权过期时间";
        public const string SupplyUnitSalesman_SupplyUnitId = "供货单位";
        public const string SupplyUnitSalesman_AuthorizedDistrictId = "授权区域";
         
        #endregion


        #region SupplyUnit
        public const string SupplyUnit_IsQualityAgreementOut = "质量协议书是否过期";
        public const string SupplyUnit_QualityAgreementOutdate = "质量协议书有效期止";
        public const string SupplyUnit_IsAttorneyAattorneyOut = "法人委托书是否过期";
        public const string SupplyUnit_AttorneyAattorneyOutdate = "法人委托书有效期止";
        public const string SupplyUnit_SupplyProductClass = "拟供品种";
        public const string SupplyUnit_QualityCharger = "质量负责人";
        public const string SupplyUnit_BankAccountName = "开户户名";
        public const string SupplyUnit_Bank = "银行";
        public const string SupplyUnit_BankAccount = "银行帐号";
       
        #endregion

        #region PurchaseUnit
        public const string PurchaseUnit_DistrictId = "地区";
        public const string PurchaseUnit_District = "地区";
        #endregion

        #region PurchaseUnitBuyer
        public const string PurchaseUnitBuyer_Name = "姓名";
        public const string PurchaseUnitBuyer_PurchaseUnitId = "客户单位";        
        #endregion  

        #region PurchaseUnitDeliverer
        public const string PurchaseUnitDeliverer_PurchaseUnitId = "客户单位";
        #endregion


        #region Employee
        public const string Employee_Number = "员工号";
        public const string Employee_IdentityNo = "身份证";
        public const string Employee_Phone = "电话";
        public const string Employee_Email = "邮箱";
        public const string Employee_Address = "联系地址";
        public const string Employee_Rank = "级别";
        public const string Employee_Education = "学历";
        public const string Employee_Duty = "岗位";
        public const string Employee_BirthDay = "生日";
        public const string Employee_WorkTime = "开始工作日";
        public const string Employee_OutDate = "合同到期日";
        public const string Employee_Specility = "专业";
        public const string Employee_EmployStatusValue = "在职状态";
        public const string Employee_PharmacistsTitleTypeValue = "药师职称";
        public const string Employee_CardNo = "证书编号";
        public const string Employee_CardDate = "证书日期";
        public const string Employee_PharmacistsQualificationValue = "从业资格";
        public const string Employee_DepartmentId = "部门";
        public const string Employee_Pinyin = "姓名拼音";
        public const string Employee_Year_exam = "是否年度体检";
        public const string Employee_Pro_work_exam = "是否岗前体检";
        public const string Employee_Pro_work_exam_Date = "岗前体检日期";
        public const string Employee_old_DepartId = "调动前部门";
        public const string Employee_IsYear_examPassed = "体检是否合格";
        public const string Employee_HealthCheckDocumentId = "体检年度";

        
        #endregion

        #region User
        public const string User_Account = "账户";
        public const string User_EmployeeId = "员工";
        public const string User_IsSpecialPriceAuth = "是否有特价权限";
        public const string User_SpecialPriceAuth = "特价权限";
        public const string User_Pwd = "密码";
        #endregion

        #region UserLog
        public const string UserLog_Content = "日志内容";
        #endregion

        #region BusinessType
        public const string BusinessType_UnitTypeId = "企业类型";
        #endregion

        #region ApprovalFlow
        public const string ApprovalFlowType_ApprovalTypeValue = "审批类型";
        #endregion

        #region BusinessScope
        public const string BusinessScope_BusinessScopeCategoryId = "经营范围类型";
        #endregion
    } 
}
