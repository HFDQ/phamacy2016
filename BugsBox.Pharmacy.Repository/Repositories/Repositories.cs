
 
 
 
  

 


 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Application.Core.CF;
using BugsBox.Common;
using BugsBox.Pharmacy.Models; 
namespace BugsBox.Pharmacy.Repository
{
	//此代码IRepositories.tt 
	 
	/// <summary>
    /// 审批结点仓储实现
    /// </summary>
    public partial class ApprovalFlowRepository :CFRepository<ApprovalFlow>,IApprovalFlowRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public ApprovalFlowRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 审批结点仓储实现
    /// </summary>
    public partial class ApprovalFlowNodeRepository :CFRepository<ApprovalFlowNode>,IApprovalFlowNodeRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public ApprovalFlowNodeRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 审批流程类型仓储实现
    /// </summary>
    public partial class ApprovalFlowTypeRepository :CFRepository<ApprovalFlowType>,IApprovalFlowTypeRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public ApprovalFlowTypeRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 审批流程记录仓储实现
    /// </summary>
    public partial class ApprovalFlowRecordRepository :CFRepository<ApprovalFlowRecord>,IApprovalFlowRecordRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public ApprovalFlowRecordRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 单据编号仓储实现
    /// </summary>
    public partial class BillDocumentCodeRepository :CFRepository<BillDocumentCode>,IBillDocumentCodeRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public BillDocumentCodeRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 经营范围仓储实现
    /// </summary>
    public partial class BusinessScopeRepository :CFRepository<BusinessScope>,IBusinessScopeRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public BusinessScopeRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 经营范围分类仓储实现
    /// </summary>
    public partial class BusinessScopeCategoryRepository :CFRepository<BusinessScopeCategory>,IBusinessScopeCategoryRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public BusinessScopeCategoryRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 经营方式仓储实现
    /// </summary>
    public partial class BusinessTypeRepository :CFRepository<BusinessType>,IBusinessTypeRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public BusinessTypeRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 经营方式的管理要求分类详细仓储实现
    /// </summary>
    public partial class BusinessTypeManageCategoryDetailRepository :CFRepository<BusinessTypeManageCategoryDetail>,IBusinessTypeManageCategoryDetailRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public BusinessTypeManageCategoryDetailRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 仓储实现
    /// </summary>
    public partial class DirectSalesOrderRepository :CFRepository<DirectSalesOrder>,IDirectSalesOrderRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DirectSalesOrderRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 仓储实现
    /// </summary>
    public partial class DirectSalesOrderDetailRepository :CFRepository<DirectSalesOrderDetail>,IDirectSalesOrderDetailRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DirectSalesOrderDetailRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 收货拒收单仓储实现
    /// </summary>
    public partial class DocumentRefuseRepository :CFRepository<DocumentRefuse>,IDocumentRefuseRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DocumentRefuseRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 报损药品仓储实现
    /// </summary>
    public partial class DrugsBreakageRepository :CFRepository<DrugsBreakage>,IDrugsBreakageRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DrugsBreakageRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 移库仓储实现
    /// </summary>
    public partial class DrugsInventoryMoveRepository :CFRepository<DrugsInventoryMove>,IDrugsInventoryMoveRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DrugsInventoryMoveRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 待处理药品仓储实现
    /// </summary>
    public partial class DrugsUndeterminateRepository :CFRepository<DrugsUndeterminate>,IDrugsUndeterminateRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DrugsUndeterminateRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 不合格药品仓储实现
    /// </summary>
    public partial class drugsUnqualicationRepository :CFRepository<drugsUnqualication>,IdrugsUnqualicationRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public drugsUnqualicationRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 不合格药品销毁情况仓储实现
    /// </summary>
    public partial class DrugsUnqualificationDestroyRepository :CFRepository<DrugsUnqualificationDestroy>,IDrugsUnqualificationDestroyRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DrugsUnqualificationDestroyRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 培训档案细节仓储实现
    /// </summary>
    public partial class EduDetailsRepository :CFRepository<EduDetails>,IEduDetailsRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public EduDetailsRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 培训档案仓储实现
    /// </summary>
    public partial class EduDocumentRepository :CFRepository<EduDocument>,IEduDocumentRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public EduDocumentRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 商品附加属性仓储实现
    /// </summary>
    public partial class GoodsAdditionalPropertyRepository :CFRepository<GoodsAdditionalProperty>,IGoodsAdditionalPropertyRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public GoodsAdditionalPropertyRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 体检档案细节仓储实现
    /// </summary>
    public partial class HealthCheckDetailRepository :CFRepository<HealthCheckDetail>,IHealthCheckDetailRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public HealthCheckDetailRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 体检档案仓储实现
    /// </summary>
    public partial class HealthCheckDocumentRepository :CFRepository<HealthCheckDocument>,IHealthCheckDocumentRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public HealthCheckDocumentRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 采购结算单仓储实现
    /// </summary>
    public partial class PurchaseCashOrderRepository :CFRepository<PurchaseCashOrder>,IPurchaseCashOrderRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseCashOrderRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 配送信息仓储实现
    /// </summary>
    public partial class DeliveryRepository :CFRepository<Delivery>,IDeliveryRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DeliveryRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 部门仓储实现
    /// </summary>
    public partial class DepartmentRepository :CFRepository<Department>,IDepartmentRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DepartmentRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 区域仓储实现
    /// </summary>
    public partial class DistrictRepository :CFRepository<District>,IDistrictRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DistrictRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 疑问药品仓储实现
    /// </summary>
    public partial class DoubtDrugRepository :CFRepository<DoubtDrug>,IDoubtDrugRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DoubtDrugRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 药品批准文号仓储实现
    /// </summary>
    public partial class DrugApprovalNumberRepository :CFRepository<DrugApprovalNumber>,IDrugApprovalNumberRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DrugApprovalNumberRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 药物分类仓储实现
    /// </summary>
    public partial class DrugCategoryRepository :CFRepository<DrugCategory>,IDrugCategoryRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DrugCategoryRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 药物临床分类仓储实现
    /// </summary>
    public partial class DrugClinicalCategoryRepository :CFRepository<DrugClinicalCategory>,IDrugClinicalCategoryRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DrugClinicalCategoryRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 剂型仓储实现
    /// </summary>
    public partial class DictionaryDosageRepository :CFRepository<DictionaryDosage>,IDictionaryDosageRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DictionaryDosageRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 药品信息仓储实现
    /// </summary>
    public partial class DrugInfoRepository :CFRepository<DrugInfo>,IDrugInfoRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DrugInfoRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 药物库存仓储实现
    /// </summary>
    public partial class DrugInventoryRecordRepository :CFRepository<DrugInventoryRecord>,IDrugInventoryRecordRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DrugInventoryRecordRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 药品养护记录仓储实现
    /// </summary>
    public partial class DrugMaintainRecordRepository :CFRepository<DrugMaintainRecord>,IDrugMaintainRecordRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DrugMaintainRecordRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 药品养护记录明细仓储实现
    /// </summary>
    public partial class DrugMaintainRecordDetailRepository :CFRepository<DrugMaintainRecordDetail>,IDrugMaintainRecordDetailRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DrugMaintainRecordDetailRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 计量单位仓储实现
    /// </summary>
    public partial class DictionaryMeasurementUnitRepository :CFRepository<DictionaryMeasurementUnit>,IDictionaryMeasurementUnitRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DictionaryMeasurementUnitRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 拆零单位仓储实现
    /// </summary>
    public partial class DictionaryPiecemealUnitRepository :CFRepository<DictionaryPiecemealUnit>,IDictionaryPiecemealUnitRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DictionaryPiecemealUnitRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 药物规格仓储实现
    /// </summary>
    public partial class DictionarySpecificationRepository :CFRepository<DictionarySpecification>,IDictionarySpecificationRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DictionarySpecificationRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 储藏方式仓储实现
    /// </summary>
    public partial class DictionaryStorageTypeRepository :CFRepository<DictionaryStorageType>,IDictionaryStorageTypeRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DictionaryStorageTypeRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 用户自定义药物类型仓储实现
    /// </summary>
    public partial class DictionaryUserDefinedTypeRepository :CFRepository<DictionaryUserDefinedType>,IDictionaryUserDefinedTypeRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DictionaryUserDefinedTypeRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 授权书仓储实现
    /// </summary>
    public partial class AuthorizationDocRepository :CFRepository<AuthorizationDoc>,IAuthorizationDocRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public AuthorizationDocRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 药品养护设置仓储实现
    /// </summary>
    public partial class DrugMaintainSetRepository :CFRepository<DrugMaintainSet>,IDrugMaintainSetRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public DrugMaintainSetRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 员工仓储实现
    /// </summary>
    public partial class EmployeeRepository :CFRepository<Employee>,IEmployeeRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public EmployeeRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// GMSP证书规定的经营范围仓储实现
    /// </summary>
    public partial class GMSPLicenseBusinessScopeRepository :CFRepository<GMSPLicenseBusinessScope>,IGMSPLicenseBusinessScopeRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public GMSPLicenseBusinessScopeRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 库存仓储实现
    /// </summary>
    public partial class InventoryRecordRepository :CFRepository<InventoryRecord>,IInventoryRecordRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public InventoryRecordRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 生产厂家 仓储实现
    /// </summary>
    public partial class ManufacturerRepository :CFRepository<Manufacturer>,IManufacturerRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public ManufacturerRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 包装材质仓储实现
    /// </summary>
    public partial class PackagingMaterialRepository :CFRepository<PackagingMaterial>,IPackagingMaterialRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PackagingMaterialRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 包装仓储实现
    /// </summary>
    public partial class PackagingUnitRepository :CFRepository<PackagingUnit>,IPackagingUnitRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PackagingUnitRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 付款方式仓储实现
    /// </summary>
    public partial class PaymentMethodRepository :CFRepository<PaymentMethod>,IPaymentMethodRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PaymentMethodRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 药品经营许可证仓储实现
    /// </summary>
    public partial class GSPLicenseRepository :CFRepository<GSPLicense>,IGSPLicenseRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public GSPLicenseRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// GMP证书仓储实现
    /// </summary>
    public partial class GMPLicenseRepository :CFRepository<GMPLicense>,IGMPLicenseRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public GMPLicenseRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 营业执照仓储实现
    /// </summary>
    public partial class BusinessLicenseRepository :CFRepository<BusinessLicense>,IBusinessLicenseRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public BusinessLicenseRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 药品生产许可证仓储实现
    /// </summary>
    public partial class MedicineProductionLicenseRepository :CFRepository<MedicineProductionLicense>,IMedicineProductionLicenseRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public MedicineProductionLicenseRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// GSP证书仓储实现
    /// </summary>
    public partial class MedicineBusinessLicenseRepository :CFRepository<MedicineBusinessLicense>,IMedicineBusinessLicenseRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public MedicineBusinessLicenseRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 器械经营许可证仓储实现
    /// </summary>
    public partial class InstrumentsBusinessLicenseRepository :CFRepository<InstrumentsBusinessLicense>,IInstrumentsBusinessLicenseRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public InstrumentsBusinessLicenseRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 器械生产许可证仓储实现
    /// </summary>
    public partial class InstrumentsProductionLicenseRepository :CFRepository<InstrumentsProductionLicense>,IInstrumentsProductionLicenseRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public InstrumentsProductionLicenseRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 组织机构代码证仓储实现
    /// </summary>
    public partial class OrganizationCodeLicenseRepository :CFRepository<OrganizationCodeLicense>,IOrganizationCodeLicenseRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public OrganizationCodeLicenseRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 食品流通许可证仓储实现
    /// </summary>
    public partial class FoodCirculateLicenseRepository :CFRepository<FoodCirculateLicense>,IFoodCirculateLicenseRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public FoodCirculateLicenseRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 卫生许可证仓储实现
    /// </summary>
    public partial class HealthLicenseRepository :CFRepository<HealthLicense>,IHealthLicenseRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public HealthLicenseRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 税务登记证仓储实现
    /// </summary>
    public partial class TaxRegisterLicenseRepository :CFRepository<TaxRegisterLicense>,ITaxRegisterLicenseRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public TaxRegisterLicenseRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 事业单位法人证仓储实现
    /// </summary>
    public partial class LnstitutionLegalPersonLicenseRepository :CFRepository<LnstitutionLegalPersonLicense>,ILnstitutionLegalPersonLicenseRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public LnstitutionLegalPersonLicenseRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 医疗机构执业许可证仓储实现
    /// </summary>
    public partial class MmedicalInstitutionPermitRepository :CFRepository<MmedicalInstitutionPermit>,IMmedicalInstitutionPermitRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public MmedicalInstitutionPermitRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 医疗分类仓储实现
    /// </summary>
    public partial class MedicalCategoryRepository :CFRepository<MedicalCategory>,IMedicalCategoryRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public MedicalCategoryRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 医疗详细分类仓储实现
    /// </summary>
    public partial class MedicalCategoryDetailRepository :CFRepository<MedicalCategoryDetail>,IMedicalCategoryDetailRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public MedicalCategoryDetailRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 功能模块仓储实现
    /// </summary>
    public partial class ModuleRepository :CFRepository<Module>,IModuleRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public ModuleRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 功能模块分类仓储实现
    /// </summary>
    public partial class ModuleCatetoryRepository :CFRepository<ModuleCatetory>,IModuleCatetoryRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public ModuleCatetoryRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 功能模块与角色的关联仓储实现
    /// </summary>
    public partial class ModuleWithRoleRepository :CFRepository<ModuleWithRole>,IModuleWithRoleRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public ModuleWithRoleRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 文件仓储实现
    /// </summary>
    public partial class PharmacyFileRepository :CFRepository<PharmacyFile>,IPharmacyFileRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PharmacyFileRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 采购合同仓储实现
    /// </summary>
    public partial class PurchaseAgreementRepository :CFRepository<PurchaseAgreement>,IPurchaseAgreementRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseAgreementRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 验收记录仓储实现
    /// </summary>
    public partial class PurchaseCheckingOrderRepository :CFRepository<PurchaseCheckingOrder>,IPurchaseCheckingOrderRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseCheckingOrderRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 采购到货验收仓储实现
    /// </summary>
    public partial class PurchaseCheckingOrderDetailRepository :CFRepository<PurchaseCheckingOrderDetail>,IPurchaseCheckingOrderDetailRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseCheckingOrderDetailRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 库存记录仓储实现
    /// </summary>
    public partial class PurchaseInInventeryOrderRepository :CFRepository<PurchaseInInventeryOrder>,IPurchaseInInventeryOrderRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseInInventeryOrderRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 库存记录详细仓储实现
    /// </summary>
    public partial class PurchaseInInventeryOrderDetailRepository :CFRepository<PurchaseInInventeryOrderDetail>,IPurchaseInInventeryOrderDetailRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseInInventeryOrderDetailRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 管理要求分类仓储实现
    /// </summary>
    public partial class PurchaseManageCategoryRepository :CFRepository<PurchaseManageCategory>,IPurchaseManageCategoryRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseManageCategoryRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 管理要求分类详细仓储实现
    /// </summary>
    public partial class PurchaseManageCategoryDetailRepository :CFRepository<PurchaseManageCategoryDetail>,IPurchaseManageCategoryDetailRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseManageCategoryDetailRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 采购单仓储实现
    /// </summary>
    public partial class PurchaseOrderRepository :CFRepository<PurchaseOrder>,IPurchaseOrderRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseOrderRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 采购明细仓储实现
    /// </summary>
    public partial class PurchaseOrderDetailRepository :CFRepository<PurchaseOrderDetail>,IPurchaseOrderDetailRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseOrderDetailRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 仓储实现
    /// </summary>
    public partial class PurchaseOrderReturnRepository :CFRepository<PurchaseOrderReturn>,IPurchaseOrderReturnRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseOrderReturnRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 仓储实现
    /// </summary>
    public partial class PurchaseOrderReturnDetailRepository :CFRepository<PurchaseOrderReturnDetail>,IPurchaseOrderReturnDetailRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseOrderReturnDetailRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 采购收货单仓储实现
    /// </summary>
    public partial class PurchaseReceivingOrderRepository :CFRepository<PurchaseReceivingOrder>,IPurchaseReceivingOrderRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseReceivingOrderRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 采购收货详细单仓储实现
    /// </summary>
    public partial class PurchaseReceivingOrderDetailRepository :CFRepository<PurchaseReceivingOrderDetail>,IPurchaseReceivingOrderDetailRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseReceivingOrderDetailRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 购货单位仓储实现
    /// </summary>
    public partial class PurchaseUnitRepository :CFRepository<PurchaseUnit>,IPurchaseUnitRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseUnitRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 购货单位采购人员仓储实现
    /// </summary>
    public partial class PurchaseUnitBuyerRepository :CFRepository<PurchaseUnitBuyer>,IPurchaseUnitBuyerRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseUnitBuyerRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 购货单位提货人员仓储实现
    /// </summary>
    public partial class PurchaseUnitDelivererRepository :CFRepository<PurchaseUnitDeliverer>,IPurchaseUnitDelivererRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseUnitDelivererRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 购货单位类型仓储实现
    /// </summary>
    public partial class PurchaseUnitTypeRepository :CFRepository<PurchaseUnitType>,IPurchaseUnitTypeRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchaseUnitTypeRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 仓储实现
    /// </summary>
    public partial class PurchasingPlanRepository :CFRepository<PurchasingPlan>,IPurchasingPlanRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchasingPlanRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 仓储实现
    /// </summary>
    public partial class PurchasingPlanDetailRepository :CFRepository<PurchasingPlanDetail>,IPurchasingPlanDetailRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public PurchasingPlanDetailRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 不常用字(生僻字)仓储实现
    /// </summary>
    public partial class RarewordRepository :CFRepository<Rareword>,IRarewordRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public RarewordRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 零售会员仓储实现
    /// </summary>
    public partial class RetailMemberRepository :CFRepository<RetailMember>,IRetailMemberRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public RetailMemberRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 仓储实现
    /// </summary>
    public partial class RetailOrderRepository :CFRepository<RetailOrder>,IRetailOrderRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public RetailOrderRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 零售单明细仓储实现
    /// </summary>
    public partial class RetailOrderDetailRepository :CFRepository<RetailOrderDetail>,IRetailOrderDetailRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public RetailOrderDetailRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 系统角色仓储实现
    /// </summary>
    public partial class RoleRepository :CFRepository<Role>,IRoleRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public RoleRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 角色与用户的关联仓储实现
    /// </summary>
    public partial class RoleWithUserRepository :CFRepository<RoleWithUser>,IRoleWithUserRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public RoleWithUserRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 销售单仓储实现
    /// </summary>
    public partial class SalesOrderRepository :CFRepository<SalesOrder>,ISalesOrderRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public SalesOrderRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 仓储实现
    /// </summary>
    public partial class SalesOrderDeliverDetailRepository :CFRepository<SalesOrderDeliverDetail>,ISalesOrderDeliverDetailRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public SalesOrderDeliverDetailRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 销售发货记录仓储实现
    /// </summary>
    public partial class SalesOrderDeliverRecordRepository :CFRepository<SalesOrderDeliverRecord>,ISalesOrderDeliverRecordRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public SalesOrderDeliverRecordRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 销售单明细仓储实现
    /// </summary>
    public partial class SalesOrderDetailRepository :CFRepository<SalesOrderDetail>,ISalesOrderDetailRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public SalesOrderDetailRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 仓储实现
    /// </summary>
    public partial class SalesOrderReturnRepository :CFRepository<SalesOrderReturn>,ISalesOrderReturnRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public SalesOrderReturnRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 仓储实现
    /// </summary>
    public partial class SalesOrderReturnDetailRepository :CFRepository<SalesOrderReturnDetail>,ISalesOrderReturnDetailRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public SalesOrderReturnDetailRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 销售出库单仓储实现
    /// </summary>
    public partial class OutInventoryRepository :CFRepository<OutInventory>,IOutInventoryRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public OutInventoryRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 设置重点药品记录表仓储实现
    /// </summary>
    public partial class SetSpeicalDrugRecordRepository :CFRepository<SetSpeicalDrugRecord>,ISetSpeicalDrugRecordRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public SetSpeicalDrugRecordRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 特殊管理药物类型仓储实现
    /// </summary>
    public partial class SpecialDrugCategoryRepository :CFRepository<SpecialDrugCategory>,ISpecialDrugCategoryRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public SpecialDrugCategoryRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 门店仓储实现
    /// </summary>
    public partial class StoreRepository :CFRepository<Store>,IStoreRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public StoreRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 首营药材供货人管理仓储实现
    /// </summary>
    public partial class SupplyPersonRepository :CFRepository<SupplyPerson>,ISupplyPersonRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public SupplyPersonRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 供货单位仓储实现
    /// </summary>
    public partial class SupplyUnitRepository :CFRepository<SupplyUnit>,ISupplyUnitRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public SupplyUnitRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 供货商销售人员仓储实现
    /// </summary>
    public partial class SupplyUnitSalesmanRepository :CFRepository<SupplyUnitSalesman>,ISupplyUnitSalesmanRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public SupplyUnitSalesmanRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 税率仓储实现
    /// </summary>
    public partial class TaxRateRepository :CFRepository<TaxRate>,ITaxRateRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public TaxRateRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 企业类型仓储实现
    /// </summary>
    public partial class UnitTypeRepository :CFRepository<UnitType>,IUnitTypeRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public UnitTypeRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 数据上传记录仓储实现
    /// </summary>
    public partial class UploadRecordRepository :CFRepository<UploadRecord>,IUploadRecordRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public UploadRecordRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 系统用户仓储实现
    /// </summary>
    public partial class UserRepository :CFRepository<User>,IUserRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public UserRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 用户日志仓储实现
    /// </summary>
    public partial class UserLogRepository :CFRepository<UserLog>,IUserLogRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public UserLogRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 车辆仓储实现
    /// </summary>
    public partial class VehicleRepository :CFRepository<Vehicle>,IVehicleRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public VehicleRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 仓库仓储实现
    /// </summary>
    public partial class WarehouseRepository :CFRepository<Warehouse>,IWarehouseRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public WarehouseRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 库区仓储实现
    /// </summary>
    public partial class WarehouseZoneRepository :CFRepository<WarehouseZone>,IWarehouseZoneRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public WarehouseZoneRepository(Db db)
            : base(db)
        { 
        }
	}

    /// <summary>
    /// 库位仓储实现
    /// </summary>
    public partial class WarehouseZonePositionRepository : CFRepository<WareHouseZonePosition>, IWarehouseZonePositionRepository
    {
        public RepositoryProvider RepositoryProvider { get; set; }
        public WarehouseZonePositionRepository(Db db)
            : base(db)
        {
        }
    }
    
	/// <summary>
    /// 报警设置仓储实现
    /// </summary>
    public partial class WaringSetRepository :CFRepository<WaringSet>,IWaringSetRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public WaringSetRepository(Db db)
            : base(db)
        { 
        }
	}
    
	/// <summary>
    /// 销售出库单仓储实现
    /// </summary>
    public partial class OutInventoryDetailRepository :CFRepository<OutInventoryDetail>,IOutInventoryDetailRepository
    { 
		 public RepositoryProvider RepositoryProvider { get; set; }
		 public OutInventoryDetailRepository(Db db)
            : base(db)
        { 
        }
	}


    public partial class IndustoryProductCertificateRepository : CFRepository<IndustoryProductCertificate>, IIndustoryProductCertificateRepository
    {
        public RepositoryProvider RepositoryProvider { get; set; }
        public IndustoryProductCertificateRepository(Db db)
            : base(db)
        {
        }
    }
}
 
 