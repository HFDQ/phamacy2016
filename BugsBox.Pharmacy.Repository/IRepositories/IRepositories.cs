
 
 
 
  

 



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.Repository
{
	//此代码IRepositories.tt
	 
	/// <summary>
    /// 审批结点仓储接口
    /// </summary>
    public partial interface IApprovalFlowRepository : IRepository<ApprovalFlow> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 审批结点仓储接口
    /// </summary>
    public partial interface IApprovalFlowNodeRepository : IRepository<ApprovalFlowNode> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 审批流程类型仓储接口
    /// </summary>
    public partial interface IApprovalFlowTypeRepository : IRepository<ApprovalFlowType> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 审批流程记录仓储接口
    /// </summary>
    public partial interface IApprovalFlowRecordRepository : IRepository<ApprovalFlowRecord> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 单据编号仓储接口
    /// </summary>
    public partial interface IBillDocumentCodeRepository : IRepository<BillDocumentCode> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 经营范围仓储接口
    /// </summary>
    public partial interface IBusinessScopeRepository : IRepository<BusinessScope> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 经营范围分类仓储接口
    /// </summary>
    public partial interface IBusinessScopeCategoryRepository : IRepository<BusinessScopeCategory> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 经营方式仓储接口
    /// </summary>
    public partial interface IBusinessTypeRepository : IRepository<BusinessType> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 经营方式的管理要求分类详细仓储接口
    /// </summary>
    public partial interface IBusinessTypeManageCategoryDetailRepository : IRepository<BusinessTypeManageCategoryDetail> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 仓储接口
    /// </summary>
    public partial interface IDirectSalesOrderRepository : IRepository<DirectSalesOrder> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 仓储接口
    /// </summary>
    public partial interface IDirectSalesOrderDetailRepository : IRepository<DirectSalesOrderDetail> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 收货拒收单仓储接口
    /// </summary>
    public partial interface IDocumentRefuseRepository : IRepository<DocumentRefuse> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 报损药品仓储接口
    /// </summary>
    public partial interface IDrugsBreakageRepository : IRepository<DrugsBreakage> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 移库仓储接口
    /// </summary>
    public partial interface IDrugsInventoryMoveRepository : IRepository<DrugsInventoryMove> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 待处理药品仓储接口
    /// </summary>
    public partial interface IDrugsUndeterminateRepository : IRepository<DrugsUndeterminate> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 不合格药品仓储接口
    /// </summary>
    public partial interface IdrugsUnqualicationRepository : IRepository<drugsUnqualication> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 不合格药品销毁情况仓储接口
    /// </summary>
    public partial interface IDrugsUnqualificationDestroyRepository : IRepository<DrugsUnqualificationDestroy> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 培训档案细节仓储接口
    /// </summary>
    public partial interface IEduDetailsRepository : IRepository<EduDetails> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 培训档案仓储接口
    /// </summary>
    public partial interface IEduDocumentRepository : IRepository<EduDocument> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 商品附加属性仓储接口
    /// </summary>
    public partial interface IGoodsAdditionalPropertyRepository : IRepository<GoodsAdditionalProperty> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 体检档案细节仓储接口
    /// </summary>
    public partial interface IHealthCheckDetailRepository : IRepository<HealthCheckDetail> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 体检档案仓储接口
    /// </summary>
    public partial interface IHealthCheckDocumentRepository : IRepository<HealthCheckDocument> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 采购结算单仓储接口
    /// </summary>
    public partial interface IPurchaseCashOrderRepository : IRepository<PurchaseCashOrder> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 配送信息仓储接口
    /// </summary>
    public partial interface IDeliveryRepository : IRepository<Delivery> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 部门仓储接口
    /// </summary>
    public partial interface IDepartmentRepository : IRepository<Department> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 区域仓储接口
    /// </summary>
    public partial interface IDistrictRepository : IRepository<District> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 疑问药品仓储接口
    /// </summary>
    public partial interface IDoubtDrugRepository : IRepository<DoubtDrug> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 药品批准文号仓储接口
    /// </summary>
    public partial interface IDrugApprovalNumberRepository : IRepository<DrugApprovalNumber> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 药物分类仓储接口
    /// </summary>
    public partial interface IDrugCategoryRepository : IRepository<DrugCategory> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 药物临床分类仓储接口
    /// </summary>
    public partial interface IDrugClinicalCategoryRepository : IRepository<DrugClinicalCategory> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 剂型仓储接口
    /// </summary>
    public partial interface IDictionaryDosageRepository : IRepository<DictionaryDosage> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 药品信息仓储接口
    /// </summary>
    public partial interface IDrugInfoRepository : IRepository<DrugInfo> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 药物库存仓储接口
    /// </summary>
    public partial interface IDrugInventoryRecordRepository : IRepository<DrugInventoryRecord> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 药品养护记录仓储接口
    /// </summary>
    public partial interface IDrugMaintainRecordRepository : IRepository<DrugMaintainRecord> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 药品养护记录明细仓储接口
    /// </summary>
    public partial interface IDrugMaintainRecordDetailRepository : IRepository<DrugMaintainRecordDetail> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 计量单位仓储接口
    /// </summary>
    public partial interface IDictionaryMeasurementUnitRepository : IRepository<DictionaryMeasurementUnit> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 拆零单位仓储接口
    /// </summary>
    public partial interface IDictionaryPiecemealUnitRepository : IRepository<DictionaryPiecemealUnit> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 药物规格仓储接口
    /// </summary>
    public partial interface IDictionarySpecificationRepository : IRepository<DictionarySpecification> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 储藏方式仓储接口
    /// </summary>
    public partial interface IDictionaryStorageTypeRepository : IRepository<DictionaryStorageType> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 用户自定义药物类型仓储接口
    /// </summary>
    public partial interface IDictionaryUserDefinedTypeRepository : IRepository<DictionaryUserDefinedType> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 授权书仓储接口
    /// </summary>
    public partial interface IAuthorizationDocRepository : IRepository<AuthorizationDoc> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 药品养护设置仓储接口
    /// </summary>
    public partial interface IDrugMaintainSetRepository : IRepository<DrugMaintainSet> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 员工仓储接口
    /// </summary>
    public partial interface IEmployeeRepository : IRepository<Employee> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// GMSP证书规定的经营范围仓储接口
    /// </summary>
    public partial interface IGMSPLicenseBusinessScopeRepository : IRepository<GMSPLicenseBusinessScope> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 库存仓储接口
    /// </summary>
    public partial interface IInventoryRecordRepository : IRepository<InventoryRecord> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 生产厂家 仓储接口
    /// </summary>
    public partial interface IManufacturerRepository : IRepository<Manufacturer> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 包装材质仓储接口
    /// </summary>
    public partial interface IPackagingMaterialRepository : IRepository<PackagingMaterial> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 包装仓储接口
    /// </summary>
    public partial interface IPackagingUnitRepository : IRepository<PackagingUnit> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 付款方式仓储接口
    /// </summary>
    public partial interface IPaymentMethodRepository : IRepository<PaymentMethod> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 药品经营许可证仓储接口
    /// </summary>
    public partial interface IGSPLicenseRepository : IRepository<GSPLicense> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// GMP证书仓储接口
    /// </summary>
    public partial interface IGMPLicenseRepository : IRepository<GMPLicense> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 营业执照仓储接口
    /// </summary>
    public partial interface IBusinessLicenseRepository : IRepository<BusinessLicense> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 药品生产许可证仓储接口
    /// </summary>
    public partial interface IMedicineProductionLicenseRepository : IRepository<MedicineProductionLicense> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// GSP证书仓储接口
    /// </summary>
    public partial interface IMedicineBusinessLicenseRepository : IRepository<MedicineBusinessLicense> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 器械经营许可证仓储接口
    /// </summary>
    public partial interface IInstrumentsBusinessLicenseRepository : IRepository<InstrumentsBusinessLicense> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 器械生产许可证仓储接口
    /// </summary>
    public partial interface IInstrumentsProductionLicenseRepository : IRepository<InstrumentsProductionLicense> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 组织机构代码证仓储接口
    /// </summary>
    public partial interface IOrganizationCodeLicenseRepository : IRepository<OrganizationCodeLicense> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 食品流通许可证仓储接口
    /// </summary>
    public partial interface IFoodCirculateLicenseRepository : IRepository<FoodCirculateLicense> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 卫生许可证仓储接口
    /// </summary>
    public partial interface IHealthLicenseRepository : IRepository<HealthLicense> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 税务登记证仓储接口
    /// </summary>
    public partial interface ITaxRegisterLicenseRepository : IRepository<TaxRegisterLicense> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 事业单位法人证仓储接口
    /// </summary>
    public partial interface ILnstitutionLegalPersonLicenseRepository : IRepository<LnstitutionLegalPersonLicense> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 医疗机构执业许可证仓储接口
    /// </summary>
    public partial interface IMmedicalInstitutionPermitRepository : IRepository<MmedicalInstitutionPermit> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 医疗分类仓储接口
    /// </summary>
    public partial interface IMedicalCategoryRepository : IRepository<MedicalCategory> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 医疗详细分类仓储接口
    /// </summary>
    public partial interface IMedicalCategoryDetailRepository : IRepository<MedicalCategoryDetail> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 功能模块仓储接口
    /// </summary>
    public partial interface IModuleRepository : IRepository<Module> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 功能模块分类仓储接口
    /// </summary>
    public partial interface IModuleCatetoryRepository : IRepository<ModuleCatetory> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 功能模块与角色的关联仓储接口
    /// </summary>
    public partial interface IModuleWithRoleRepository : IRepository<ModuleWithRole> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 文件仓储接口
    /// </summary>
    public partial interface IPharmacyFileRepository : IRepository<PharmacyFile> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 采购合同仓储接口
    /// </summary>
    public partial interface IPurchaseAgreementRepository : IRepository<PurchaseAgreement> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 验收记录仓储接口
    /// </summary>
    public partial interface IPurchaseCheckingOrderRepository : IRepository<PurchaseCheckingOrder> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 采购到货验收仓储接口
    /// </summary>
    public partial interface IPurchaseCheckingOrderDetailRepository : IRepository<PurchaseCheckingOrderDetail> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 库存记录仓储接口
    /// </summary>
    public partial interface IPurchaseInInventeryOrderRepository : IRepository<PurchaseInInventeryOrder> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 库存记录详细仓储接口
    /// </summary>
    public partial interface IPurchaseInInventeryOrderDetailRepository : IRepository<PurchaseInInventeryOrderDetail> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 管理要求分类仓储接口
    /// </summary>
    public partial interface IPurchaseManageCategoryRepository : IRepository<PurchaseManageCategory> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 管理要求分类详细仓储接口
    /// </summary>
    public partial interface IPurchaseManageCategoryDetailRepository : IRepository<PurchaseManageCategoryDetail> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 采购单仓储接口
    /// </summary>
    public partial interface IPurchaseOrderRepository : IRepository<PurchaseOrder> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 采购明细仓储接口
    /// </summary>
    public partial interface IPurchaseOrderDetailRepository : IRepository<PurchaseOrderDetail> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 仓储接口
    /// </summary>
    public partial interface IPurchaseOrderReturnRepository : IRepository<PurchaseOrderReturn> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 仓储接口
    /// </summary>
    public partial interface IPurchaseOrderReturnDetailRepository : IRepository<PurchaseOrderReturnDetail> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 采购收货单仓储接口
    /// </summary>
    public partial interface IPurchaseReceivingOrderRepository : IRepository<PurchaseReceivingOrder> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 采购收货详细单仓储接口
    /// </summary>
    public partial interface IPurchaseReceivingOrderDetailRepository : IRepository<PurchaseReceivingOrderDetail> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 购货单位仓储接口
    /// </summary>
    public partial interface IPurchaseUnitRepository : IRepository<PurchaseUnit> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 购货单位采购人员仓储接口
    /// </summary>
    public partial interface IPurchaseUnitBuyerRepository : IRepository<PurchaseUnitBuyer> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 购货单位提货人员仓储接口
    /// </summary>
    public partial interface IPurchaseUnitDelivererRepository : IRepository<PurchaseUnitDeliverer> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 购货单位类型仓储接口
    /// </summary>
    public partial interface IPurchaseUnitTypeRepository : IRepository<PurchaseUnitType> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 仓储接口
    /// </summary>
    public partial interface IPurchasingPlanRepository : IRepository<PurchasingPlan> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 仓储接口
    /// </summary>
    public partial interface IPurchasingPlanDetailRepository : IRepository<PurchasingPlanDetail> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 不常用字(生僻字)仓储接口
    /// </summary>
    public partial interface IRarewordRepository : IRepository<Rareword> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 零售会员仓储接口
    /// </summary>
    public partial interface IRetailMemberRepository : IRepository<RetailMember> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 仓储接口
    /// </summary>
    public partial interface IRetailOrderRepository : IRepository<RetailOrder> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 零售单明细仓储接口
    /// </summary>
    public partial interface IRetailOrderDetailRepository : IRepository<RetailOrderDetail> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 系统角色仓储接口
    /// </summary>
    public partial interface IRoleRepository : IRepository<Role> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 角色与用户的关联仓储接口
    /// </summary>
    public partial interface IRoleWithUserRepository : IRepository<RoleWithUser> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 销售单仓储接口
    /// </summary>
    public partial interface ISalesOrderRepository : IRepository<SalesOrder> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 仓储接口
    /// </summary>
    public partial interface ISalesOrderDeliverDetailRepository : IRepository<SalesOrderDeliverDetail> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 销售发货记录仓储接口
    /// </summary>
    public partial interface ISalesOrderDeliverRecordRepository : IRepository<SalesOrderDeliverRecord> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 销售单明细仓储接口
    /// </summary>
    public partial interface ISalesOrderDetailRepository : IRepository<SalesOrderDetail> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 仓储接口
    /// </summary>
    public partial interface ISalesOrderReturnRepository : IRepository<SalesOrderReturn> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 仓储接口
    /// </summary>
    public partial interface ISalesOrderReturnDetailRepository : IRepository<SalesOrderReturnDetail> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 销售出库单仓储接口
    /// </summary>
    public partial interface IOutInventoryRepository : IRepository<OutInventory> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 设置重点药品记录表仓储接口
    /// </summary>
    public partial interface ISetSpeicalDrugRecordRepository : IRepository<SetSpeicalDrugRecord> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 特殊管理药物类型仓储接口
    /// </summary>
    public partial interface ISpecialDrugCategoryRepository : IRepository<SpecialDrugCategory> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 门店仓储接口
    /// </summary>
    public partial interface IStoreRepository : IRepository<Store> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 首营药材供货人管理仓储接口
    /// </summary>
    public partial interface ISupplyPersonRepository : IRepository<SupplyPerson> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 供货单位仓储接口
    /// </summary>
    public partial interface ISupplyUnitRepository : IRepository<SupplyUnit> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 供货商销售人员仓储接口
    /// </summary>
    public partial interface ISupplyUnitSalesmanRepository : IRepository<SupplyUnitSalesman> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 税率仓储接口
    /// </summary>
    public partial interface ITaxRateRepository : IRepository<TaxRate> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 企业类型仓储接口
    /// </summary>
    public partial interface IUnitTypeRepository : IRepository<UnitType> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 数据上传记录仓储接口
    /// </summary>
    public partial interface IUploadRecordRepository : IRepository<UploadRecord> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 系统用户仓储接口
    /// </summary>
    public partial interface IUserRepository : IRepository<User> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 用户日志仓储接口
    /// </summary>
    public partial interface IUserLogRepository : IRepository<UserLog> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 车辆仓储接口
    /// </summary>
    public partial interface IVehicleRepository : IRepository<Vehicle> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 仓库仓储接口
    /// </summary>
    public partial interface IWarehouseRepository : IRepository<Warehouse> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 库区仓储接口
    /// </summary>
    public partial interface IWarehouseZoneRepository : IRepository<WarehouseZone> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}

    /// <summary>
    /// 库位仓储接口
    /// </summary>
    public partial interface IWarehouseZonePositionRepository : IRepository<WareHouseZonePosition>
    {
        RepositoryProvider RepositoryProvider { get; set; }
    }
    
	/// <summary>
    /// 报警设置仓储接口
    /// </summary>
    public partial interface IWaringSetRepository : IRepository<WaringSet> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}
    
	/// <summary>
    /// 销售出库单仓储接口
    /// </summary>
    public partial interface IOutInventoryDetailRepository : IRepository<OutInventoryDetail> 
    { 
		 RepositoryProvider RepositoryProvider { get; set; }
	}

    /// <summary>
    /// 全国工业产品生产许可证
    /// </summary>
    public partial interface IIndustoryProductCertificateRepository : IRepository<IndustoryProductCertificate>
    {
        RepositoryProvider RepositoryProvider { get; set; }
    }
   
}
 
 