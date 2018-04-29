
 
 
 
  

 



using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
 
namespace BugsBox.Pharmacy.Repository
{
	//此代码Db.DataSets.tt自动生成 
    partial class Db
    {
	 
		/// <summary>
        /// 审批结点s
        /// </summary>
		public DbSet<ApprovalFlow> ApprovalFlows { get; set; }
	 
		/// <summary>
        /// 审批结点s
        /// </summary>
		public DbSet<ApprovalFlowNode> ApprovalFlowNodes { get; set; }
	 
		/// <summary>
        /// 审批流程类型s
        /// </summary>
		public DbSet<ApprovalFlowType> ApprovalFlowTypes { get; set; }
	 
		/// <summary>
        /// 审批流程记录s
        /// </summary>
		public DbSet<ApprovalFlowRecord> ApprovalFlowRecords { get; set; }
	 
		/// <summary>
        /// 单据编号s
        /// </summary>
		public DbSet<BillDocumentCode> BillDocumentCodes { get; set; }
	 
		/// <summary>
        /// 经营范围s
        /// </summary>
		public DbSet<BusinessScope> BusinessScopes { get; set; }
	 
		/// <summary>
        /// 经营范围分类s
        /// </summary>
		public DbSet<BusinessScopeCategory> BusinessScopeCategorys { get; set; }
	 
		/// <summary>
        /// 经营方式s
        /// </summary>
		public DbSet<BusinessType> BusinessTypes { get; set; }
	 
		/// <summary>
        /// 经营方式的管理要求分类详细s
        /// </summary>
		public DbSet<BusinessTypeManageCategoryDetail> BusinessTypeManageCategoryDetails { get; set; }
	 
		/// <summary>
        /// 行政区域划分s
        /// </summary>
		public DbSet<ChinaDistrict> ChinaDistricts { get; set; }
	 
		/// <summary>
        /// s
        /// </summary>
		public DbSet<DirectSalesOrder> DirectSalesOrders { get; set; }
	 
		/// <summary>
        /// s
        /// </summary>
		public DbSet<DirectSalesOrderDetail> DirectSalesOrderDetails { get; set; }
	 
		/// <summary>
        /// 收货拒收单s
        /// </summary>
		public DbSet<DocumentRefuse> DocumentRefuses { get; set; }
	 
		/// <summary>
        /// 药物库存变动历史s
        /// </summary>
		public DbSet<DrugInventoryRecordHis> DrugInventoryRecordHiss { get; set; }
	 
		/// <summary>
        /// 药品养护记录s
        /// </summary>
		public DbSet<DrugMaintenanceRecord> DrugMaintenanceRecords { get; set; }
	 
		/// <summary>
        /// 报损药品s
        /// </summary>
		public DbSet<DrugsBreakage> DrugsBreakages { get; set; }
	 
		/// <summary>
        /// 移库s
        /// </summary>
		public DbSet<DrugsInventoryMove> DrugsInventoryMoves { get; set; }
	 
		/// <summary>
        /// 待处理药品s
        /// </summary>
		public DbSet<DrugsUndeterminate> DrugsUndeterminates { get; set; }
	 
		/// <summary>
        /// 不合格药品s
        /// </summary>
		public DbSet<drugsUnqualication> drugsUnqualications { get; set; }
	 
		/// <summary>
        /// 不合格药品销毁情况s
        /// </summary>
		public DbSet<DrugsUnqualificationDestroy> DrugsUnqualificationDestroys { get; set; }
	 
		/// <summary>
        /// 培训档案细节s
        /// </summary>
		public DbSet<EduDetails> EduDetailss { get; set; }
	 
		/// <summary>
        /// 培训档案s
        /// </summary>
		public DbSet<EduDocument> EduDocuments { get; set; }
	 
		/// <summary>
        /// 商品附加属性s
        /// </summary>
		public DbSet<GoodsAdditionalProperty> GoodsAdditionalPropertys { get; set; }
	 
		/// <summary>
        /// 体检档案细节s
        /// </summary>
		public DbSet<HealthCheckDetail> HealthCheckDetails { get; set; }
	 
		/// <summary>
        /// 体检档案s
        /// </summary>
		public DbSet<HealthCheckDocument> HealthCheckDocuments { get; set; }
	 
		/// <summary>
        /// 采购结算单s
        /// </summary>
		public DbSet<PurchaseCashOrder> PurchaseCashOrders { get; set; }
	 
		/// <summary>
        /// 配送信息s
        /// </summary>
		public DbSet<Delivery> Deliverys { get; set; }
	 
		/// <summary>
        /// 部门s
        /// </summary>
		public DbSet<Department> Departments { get; set; }
	 
		/// <summary>
        /// 区域s
        /// </summary>
		public DbSet<District> Districts { get; set; }
	 
		/// <summary>
        /// 疑问药品s
        /// </summary>
		public DbSet<DoubtDrug> DoubtDrugs { get; set; }
	 
		/// <summary>
        /// 药品批准文号s
        /// </summary>
		public DbSet<DrugApprovalNumber> DrugApprovalNumbers { get; set; }
	 
		/// <summary>
        /// 药物分类s
        /// </summary>
		public DbSet<DrugCategory> DrugCategorys { get; set; }
	 
		/// <summary>
        /// 药物临床分类s
        /// </summary>
		public DbSet<DrugClinicalCategory> DrugClinicalCategorys { get; set; }
	 
		/// <summary>
        /// 剂型s
        /// </summary>
		public DbSet<DictionaryDosage> DictionaryDosages { get; set; }
	 
		/// <summary>
        /// 药品信息s
        /// </summary>
		public DbSet<DrugInfo> DrugInfos { get; set; }
	 
		/// <summary>
        /// 药物库存s
        /// </summary>
		public DbSet<DrugInventoryRecord> DrugInventoryRecords { get; set; }
	 
		/// <summary>
        /// 药品养护记录s
        /// </summary>
		public DbSet<DrugMaintainRecord> DrugMaintainRecords { get; set; }
	 
		/// <summary>
        /// 药品养护记录明细s
        /// </summary>
		public DbSet<DrugMaintainRecordDetail> DrugMaintainRecordDetails { get; set; }
	 
		/// <summary>
        /// 计量单位s
        /// </summary>
		public DbSet<DictionaryMeasurementUnit> DictionaryMeasurementUnits { get; set; }
	 
		/// <summary>
        /// 拆零单位s
        /// </summary>
		public DbSet<DictionaryPiecemealUnit> DictionaryPiecemealUnits { get; set; }
	 
		/// <summary>
        /// 药物规格s
        /// </summary>
		public DbSet<DictionarySpecification> DictionarySpecifications { get; set; }
	 
		/// <summary>
        /// 储藏方式s
        /// </summary>
		public DbSet<DictionaryStorageType> DictionaryStorageTypes { get; set; }
	 
		/// <summary>
        /// 用户自定义药物类型s
        /// </summary>
		public DbSet<DictionaryUserDefinedType> DictionaryUserDefinedTypes { get; set; }
	 
		/// <summary>
        /// 授权书s
        /// </summary>
		public DbSet<AuthorizationDoc> AuthorizationDocs { get; set; }
	 
		/// <summary>
        /// 药品养护设置s
        /// </summary>
		public DbSet<DrugMaintainSet> DrugMaintainSets { get; set; }
	 
		/// <summary>
        /// 员工s
        /// </summary>
		public DbSet<Employee> Employees { get; set; }
	 
		/// <summary>
        /// GMSP证书规定的经营范围s
        /// </summary>
		public DbSet<GMSPLicenseBusinessScope> GMSPLicenseBusinessScopes { get; set; }
	 
		/// <summary>
        /// 库存s
        /// </summary>
		public DbSet<InventoryRecord> InventoryRecords { get; set; }
	 
		/// <summary>
        /// 生产厂家 s
        /// </summary>
		public DbSet<Manufacturer> Manufacturers { get; set; }
	 
		/// <summary>
        /// 包装材质s
        /// </summary>
		public DbSet<PackagingMaterial> PackagingMaterials { get; set; }
	 
		/// <summary>
        /// 包装s
        /// </summary>
		public DbSet<PackagingUnit> PackagingUnits { get; set; }
	 
		/// <summary>
        /// 付款方式s
        /// </summary>
		public DbSet<PaymentMethod> PaymentMethods { get; set; }
	 
		/// <summary>
        /// 药品经营许可证s
        /// </summary>
		public DbSet<GSPLicense> GSPLicenses { get; set; }
	 
		/// <summary>
        /// GMP证书s
        /// </summary>
		public DbSet<GMPLicense> GMPLicenses { get; set; }
	 
		/// <summary>
        /// 营业执照s
        /// </summary>
		public DbSet<BusinessLicense> BusinessLicenses { get; set; }
	 
		/// <summary>
        /// 药品生产许可证s
        /// </summary>
		public DbSet<MedicineProductionLicense> MedicineProductionLicenses { get; set; }
	 
		/// <summary>
        /// GSP证书s
        /// </summary>
		public DbSet<MedicineBusinessLicense> MedicineBusinessLicenses { get; set; }
	 
		/// <summary>
        /// 器械经营许可证s
        /// </summary>
		public DbSet<InstrumentsBusinessLicense> InstrumentsBusinessLicenses { get; set; }
	 
		/// <summary>
        /// 器械生产许可证s
        /// </summary>
		public DbSet<InstrumentsProductionLicense> InstrumentsProductionLicenses { get; set; }
	 
		/// <summary>
        /// 组织机构代码证s
        /// </summary>
		public DbSet<OrganizationCodeLicense> OrganizationCodeLicenses { get; set; }
	 
		/// <summary>
        /// 食品流通许可证s
        /// </summary>
		public DbSet<FoodCirculateLicense> FoodCirculateLicenses { get; set; }
	 
		/// <summary>
        /// 卫生许可证s
        /// </summary>
		public DbSet<HealthLicense> HealthLicenses { get; set; }
	 
		/// <summary>
        /// 税务登记证s
        /// </summary>
		public DbSet<TaxRegisterLicense> TaxRegisterLicenses { get; set; }
	 
		/// <summary>
        /// 事业单位法人证s
        /// </summary>
		public DbSet<LnstitutionLegalPersonLicense> LnstitutionLegalPersonLicenses { get; set; }
	 
		/// <summary>
        /// 医疗机构执业许可证s
        /// </summary>
		public DbSet<MmedicalInstitutionPermit> MmedicalInstitutionPermits { get; set; }
	 
		/// <summary>
        /// 全国工业产品生产许可证s
        /// </summary>
		public DbSet<IndustoryProductCertificate> IndustoryProductCertificates { get; set; }
	 
		/// <summary>
        /// 医疗分类s
        /// </summary>
		public DbSet<MedicalCategory> MedicalCategorys { get; set; }
	 
		/// <summary>
        /// 医疗详细分类s
        /// </summary>
		public DbSet<MedicalCategoryDetail> MedicalCategoryDetails { get; set; }
	 
		/// <summary>
        /// 功能模块s
        /// </summary>
		public DbSet<Module> Modules { get; set; }
	 
		/// <summary>
        /// 功能模块分类s
        /// </summary>
		public DbSet<ModuleCatetory> ModuleCatetorys { get; set; }
	 
		/// <summary>
        /// 功能模块与角色的关联s
        /// </summary>
		public DbSet<ModuleWithRole> ModuleWithRoles { get; set; }
	 
		/// <summary>
        /// 文件s
        /// </summary>
		public DbSet<PharmacyFile> PharmacyFiles { get; set; }
	 
		/// <summary>
        /// 采购合同s
        /// </summary>
		public DbSet<PurchaseAgreement> PurchaseAgreements { get; set; }
	 
		/// <summary>
        /// 验收记录s
        /// </summary>
		public DbSet<PurchaseCheckingOrder> PurchaseCheckingOrders { get; set; }
	 
		/// <summary>
        /// 采购到货验收s
        /// </summary>
		public DbSet<PurchaseCheckingOrderDetail> PurchaseCheckingOrderDetails { get; set; }
	 
		/// <summary>
        /// 库存记录s
        /// </summary>
		public DbSet<PurchaseInInventeryOrder> PurchaseInInventeryOrders { get; set; }
	 
		/// <summary>
        /// 库存记录详细s
        /// </summary>
		public DbSet<PurchaseInInventeryOrderDetail> PurchaseInInventeryOrderDetails { get; set; }
	 
		/// <summary>
        /// 管理要求分类s
        /// </summary>
		public DbSet<PurchaseManageCategory> PurchaseManageCategorys { get; set; }
	 
		/// <summary>
        /// 管理要求分类详细s
        /// </summary>
		public DbSet<PurchaseManageCategoryDetail> PurchaseManageCategoryDetails { get; set; }
	 
		/// <summary>
        /// 采购单s
        /// </summary>
		public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
	 
		/// <summary>
        /// 采购明细s
        /// </summary>
		public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
	 
		/// <summary>
        /// s
        /// </summary>
		public DbSet<PurchaseOrderReturn> PurchaseOrderReturns { get; set; }
	 
		/// <summary>
        /// s
        /// </summary>
		public DbSet<PurchaseOrderReturnDetail> PurchaseOrderReturnDetails { get; set; }
	 
		/// <summary>
        /// 采购收货单s
        /// </summary>
		public DbSet<PurchaseReceivingOrder> PurchaseReceivingOrders { get; set; }
	 
		/// <summary>
        /// 采购收货详细单s
        /// </summary>
		public DbSet<PurchaseReceivingOrderDetail> PurchaseReceivingOrderDetails { get; set; }
	 
		/// <summary>
        /// 购货单位s
        /// </summary>
		public DbSet<PurchaseUnit> PurchaseUnits { get; set; }
	 
		/// <summary>
        /// 购货单位采购人员s
        /// </summary>
		public DbSet<PurchaseUnitBuyer> PurchaseUnitBuyers { get; set; }
	 
		/// <summary>
        /// 购货单位提货人员s
        /// </summary>
		public DbSet<PurchaseUnitDeliverer> PurchaseUnitDeliverers { get; set; }
	 
		/// <summary>
        /// 购货单位类型s
        /// </summary>
		public DbSet<PurchaseUnitType> PurchaseUnitTypes { get; set; }
	 
		/// <summary>
        /// s
        /// </summary>
		public DbSet<PurchasingPlan> PurchasingPlans { get; set; }
	 
		/// <summary>
        /// s
        /// </summary>
		public DbSet<PurchasingPlanDetail> PurchasingPlanDetails { get; set; }
	 
		/// <summary>
        /// 不常用字(生僻字)s
        /// </summary>
		public DbSet<Rareword> Rarewords { get; set; }
	 
		/// <summary>
        /// 零售会员s
        /// </summary>
		public DbSet<RetailMember> RetailMembers { get; set; }
	 
		/// <summary>
        /// s
        /// </summary>
		public DbSet<RetailOrder> RetailOrders { get; set; }
	 
		/// <summary>
        /// 零售单明细s
        /// </summary>
		public DbSet<RetailOrderDetail> RetailOrderDetails { get; set; }
	 
		/// <summary>
        /// 系统角色s
        /// </summary>
		public DbSet<Role> Roles { get; set; }
	 
		/// <summary>
        /// 角色与用户的关联s
        /// </summary>
		public DbSet<RoleWithUser> RoleWithUsers { get; set; }
	 
		/// <summary>
        /// 销售单s
        /// </summary>
		public DbSet<SalesOrder> SalesOrders { get; set; }
	 
		/// <summary>
        /// s
        /// </summary>
		public DbSet<SalesOrderDeliverDetail> SalesOrderDeliverDetails { get; set; }
	 
		/// <summary>
        /// 销售发货记录s
        /// </summary>
		public DbSet<SalesOrderDeliverRecord> SalesOrderDeliverRecords { get; set; }
	 
		/// <summary>
        /// 销售单明细s
        /// </summary>
		public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
	 
		/// <summary>
        /// s
        /// </summary>
		public DbSet<SalesOrderReturn> SalesOrderReturns { get; set; }
	 
		/// <summary>
        /// s
        /// </summary>
		public DbSet<SalesOrderReturnDetail> SalesOrderReturnDetails { get; set; }
	 
		/// <summary>
        /// 销售出库单s
        /// </summary>
		public DbSet<OutInventory> OutInventorys { get; set; }
	 
		/// <summary>
        /// 设置重点药品记录表s
        /// </summary>
		public DbSet<SetSpeicalDrugRecord> SetSpeicalDrugRecords { get; set; }
	 
		/// <summary>
        /// 特殊管理药物类型s
        /// </summary>
		public DbSet<SpecialDrugCategory> SpecialDrugCategorys { get; set; }
	 
		/// <summary>
        /// 门店s
        /// </summary>
		public DbSet<Store> Stores { get; set; }
	 
		/// <summary>
        /// 首营药材供货人管理s
        /// </summary>
		public DbSet<SupplyPerson> SupplyPersons { get; set; }
	 
		/// <summary>
        /// 供货单位s
        /// </summary>
		public DbSet<SupplyUnit> SupplyUnits { get; set; }
	 
		/// <summary>
        /// 供货商销售人员s
        /// </summary>
		public DbSet<SupplyUnitSalesman> SupplyUnitSalesmans { get; set; }
	 
		/// <summary>
        /// 税率s
        /// </summary>
		public DbSet<TaxRate> TaxRates { get; set; }
	 
		/// <summary>
        /// 企业类型s
        /// </summary>
		public DbSet<UnitType> UnitTypes { get; set; }
	 
		/// <summary>
        /// 数据上传记录s
        /// </summary>
		public DbSet<UploadRecord> UploadRecords { get; set; }
	 
		/// <summary>
        /// 系统用户s
        /// </summary>
		public DbSet<User> Users { get; set; }
	 
		/// <summary>
        /// 用户日志s
        /// </summary>
		public DbSet<UserLog> UserLogs { get; set; }
	 
		/// <summary>
        /// 车辆s
        /// </summary>
		public DbSet<Vehicle> Vehicles { get; set; }
	 
		/// <summary>
        /// 仓库s
        /// </summary>
		public DbSet<Warehouse> Warehouses { get; set; }
	 
		/// <summary>
        /// 库区s
        /// </summary>
		public DbSet<WarehouseZone> WarehouseZones { get; set; }
	 
		/// <summary>
        /// s
        /// </summary>
		public DbSet<WareHouseZonePosition> WarehouseZonePositions { get; set; }
	 
		/// <summary>
        /// 报警设置s
        /// </summary>
		public DbSet<WaringSet> WaringSets { get; set; }
	 
		/// <summary>
        /// 销售出库单s
        /// </summary>
		public DbSet<OutInventoryDetail> OutInventoryDetails { get; set; }
	
	}
}
