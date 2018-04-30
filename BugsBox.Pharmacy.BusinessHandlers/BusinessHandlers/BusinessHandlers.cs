
 
 
 
   

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;
using System.ComponentModel;
using BugsBox.Pharmacy.Repository;
 
namespace BugsBox.Pharmacy.BusinessHandlers
{
	
			
	/// <summary>
	/// 审批结点的业务逻辑处理 
	/// </summary>
	[Description("审批结点的业务逻辑处理")]
	public partial class ApprovalFlowBusinessHandler : BaseBusinessHandler<ApprovalFlow>
    {   
        public ApprovalFlowBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.ApprovalFlowRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 审批结点的业务逻辑处理 
	/// </summary>
	[Description("审批结点的业务逻辑处理")]
	public partial class ApprovalFlowNodeBusinessHandler : BaseBusinessHandler<ApprovalFlowNode>
    {   
        public ApprovalFlowNodeBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.ApprovalFlowNodeRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 审批流程类型的业务逻辑处理 
	/// </summary>
	[Description("审批流程类型的业务逻辑处理")]
	public partial class ApprovalFlowTypeBusinessHandler : BaseBusinessHandler<ApprovalFlowType>
    {   
        public ApprovalFlowTypeBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.ApprovalFlowTypeRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 审批流程记录的业务逻辑处理 
	/// </summary>
	[Description("审批流程记录的业务逻辑处理")]
	public partial class ApprovalFlowRecordBusinessHandler : BaseBusinessHandler<ApprovalFlowRecord>
    {   
        public ApprovalFlowRecordBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.ApprovalFlowRecordRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 单据编号的业务逻辑处理 
	/// </summary>
	[Description("单据编号的业务逻辑处理")]
	public partial class BillDocumentCodeBusinessHandler : BaseBusinessHandler<BillDocumentCode>
    {   
        public BillDocumentCodeBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.BillDocumentCodeRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 经营范围的业务逻辑处理 
	/// </summary>
	[Description("经营范围的业务逻辑处理")]
	public partial class BusinessScopeBusinessHandler : BaseBusinessHandler<BusinessScope>
    {   
        public BusinessScopeBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.BusinessScopeRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 经营范围分类的业务逻辑处理 
	/// </summary>
	[Description("经营范围分类的业务逻辑处理")]
	public partial class BusinessScopeCategoryBusinessHandler : BaseBusinessHandler<BusinessScopeCategory>
    {   
        public BusinessScopeCategoryBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.BusinessScopeCategoryRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 经营方式的业务逻辑处理 
	/// </summary>
	[Description("经营方式的业务逻辑处理")]
	public partial class BusinessTypeBusinessHandler : BaseBusinessHandler<BusinessType>
    {   
        public BusinessTypeBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.BusinessTypeRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 经营方式的管理要求分类详细的业务逻辑处理 
	/// </summary>
	[Description("经营方式的管理要求分类详细的业务逻辑处理")]
	public partial class BusinessTypeManageCategoryDetailBusinessHandler : BaseBusinessHandler<BusinessTypeManageCategoryDetail>
    {   
        public BusinessTypeManageCategoryDetailBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.BusinessTypeManageCategoryDetailRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 行政区域划分的业务逻辑处理 
	/// </summary>
	[Description("行政区域划分的业务逻辑处理")]
	public partial class ChinaDistrictBusinessHandler : BaseBusinessHandler<ChinaDistrict>
    {   
        public ChinaDistrictBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.ChinaDistrictRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 的业务逻辑处理 
	/// </summary>
	[Description("的业务逻辑处理")]
	public partial class DirectSalesOrderBusinessHandler : BaseBusinessHandler<DirectSalesOrder>
    {   
        public DirectSalesOrderBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DirectSalesOrderRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 的业务逻辑处理 
	/// </summary>
	[Description("的业务逻辑处理")]
	public partial class DirectSalesOrderDetailBusinessHandler : BaseBusinessHandler<DirectSalesOrderDetail>
    {   
        public DirectSalesOrderDetailBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DirectSalesOrderDetailRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 收货拒收单的业务逻辑处理 
	/// </summary>
	[Description("收货拒收单的业务逻辑处理")]
	public partial class DocumentRefuseBusinessHandler : BaseBusinessHandler<DocumentRefuse>
    {   
        public DocumentRefuseBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DocumentRefuseRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 药物库存变动历史的业务逻辑处理 
	/// </summary>
	[Description("药物库存变动历史的业务逻辑处理")]
	public partial class DrugInventoryRecordHisBusinessHandler : BaseBusinessHandler<DrugInventoryRecordHis>
    {   
        public DrugInventoryRecordHisBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DrugInventoryRecordHisRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 药品养护记录的业务逻辑处理 
	/// </summary>
	[Description("药品养护记录的业务逻辑处理")]
	public partial class DrugMaintenanceRecordBusinessHandler : BaseBusinessHandler<DrugMaintenanceRecord>
    {   
        public DrugMaintenanceRecordBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DrugMaintenanceRecordRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 报损药品的业务逻辑处理 
	/// </summary>
	[Description("报损药品的业务逻辑处理")]
	public partial class DrugsBreakageBusinessHandler : BaseBusinessHandler<DrugsBreakage>
    {   
        public DrugsBreakageBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DrugsBreakageRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 移库的业务逻辑处理 
	/// </summary>
	[Description("移库的业务逻辑处理")]
	public partial class DrugsInventoryMoveBusinessHandler : BaseBusinessHandler<DrugsInventoryMove>
    {   
        public DrugsInventoryMoveBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DrugsInventoryMoveRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 待处理药品的业务逻辑处理 
	/// </summary>
	[Description("待处理药品的业务逻辑处理")]
	public partial class DrugsUndeterminateBusinessHandler : BaseBusinessHandler<DrugsUndeterminate>
    {   
        public DrugsUndeterminateBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DrugsUndeterminateRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 不合格药品的业务逻辑处理 
	/// </summary>
	[Description("不合格药品的业务逻辑处理")]
	public partial class DrugsUnqualicationBusinessHandler : BaseBusinessHandler<DrugsUnqualication>
    {   
        public DrugsUnqualicationBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DrugsUnqualicationRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 不合格药品销毁情况的业务逻辑处理 
	/// </summary>
	[Description("不合格药品销毁情况的业务逻辑处理")]
	public partial class DrugsUnqualificationDestroyBusinessHandler : BaseBusinessHandler<DrugsUnqualificationDestroy>
    {   
        public DrugsUnqualificationDestroyBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DrugsUnqualificationDestroyRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 培训档案细节的业务逻辑处理 
	/// </summary>
	[Description("培训档案细节的业务逻辑处理")]
	public partial class EduDetailsBusinessHandler : BaseBusinessHandler<EduDetails>
    {   
        public EduDetailsBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.EduDetailsRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 培训档案的业务逻辑处理 
	/// </summary>
	[Description("培训档案的业务逻辑处理")]
	public partial class EduDocumentBusinessHandler : BaseBusinessHandler<EduDocument>
    {   
        public EduDocumentBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.EduDocumentRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 商品附加属性的业务逻辑处理 
	/// </summary>
	[Description("商品附加属性的业务逻辑处理")]
	public partial class GoodsAdditionalPropertyBusinessHandler : BaseBusinessHandler<GoodsAdditionalProperty>
    {   
        public GoodsAdditionalPropertyBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.GoodsAdditionalPropertyRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 体检档案细节的业务逻辑处理 
	/// </summary>
	[Description("体检档案细节的业务逻辑处理")]
	public partial class HealthCheckDetailBusinessHandler : BaseBusinessHandler<HealthCheckDetail>
    {   
        public HealthCheckDetailBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.HealthCheckDetailRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 体检档案的业务逻辑处理 
	/// </summary>
	[Description("体检档案的业务逻辑处理")]
	public partial class HealthCheckDocumentBusinessHandler : BaseBusinessHandler<HealthCheckDocument>
    {   
        public HealthCheckDocumentBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.HealthCheckDocumentRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 采购结算单的业务逻辑处理 
	/// </summary>
	[Description("采购结算单的业务逻辑处理")]
	public partial class PurchaseCashOrderBusinessHandler : BaseBusinessHandler<PurchaseCashOrder>
    {   
        public PurchaseCashOrderBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseCashOrderRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 配送信息的业务逻辑处理 
	/// </summary>
	[Description("配送信息的业务逻辑处理")]
	public partial class DeliveryBusinessHandler : BaseBusinessHandler<Delivery>
    {   
        public DeliveryBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DeliveryRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 部门的业务逻辑处理 
	/// </summary>
	[Description("部门的业务逻辑处理")]
	public partial class DepartmentBusinessHandler : BaseBusinessHandler<Department>
    {   
        public DepartmentBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DepartmentRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 区域的业务逻辑处理 
	/// </summary>
	[Description("区域的业务逻辑处理")]
	public partial class DistrictBusinessHandler : BaseBusinessHandler<District>
    {   
        public DistrictBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DistrictRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 疑问药品的业务逻辑处理 
	/// </summary>
	[Description("疑问药品的业务逻辑处理")]
	public partial class DoubtDrugBusinessHandler : BaseBusinessHandler<DoubtDrug>
    {   
        public DoubtDrugBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DoubtDrugRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 药品批准文号的业务逻辑处理 
	/// </summary>
	[Description("药品批准文号的业务逻辑处理")]
	public partial class DrugApprovalNumberBusinessHandler : BaseBusinessHandler<DrugApprovalNumber>
    {   
        public DrugApprovalNumberBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DrugApprovalNumberRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 药物分类的业务逻辑处理 
	/// </summary>
	[Description("药物分类的业务逻辑处理")]
	public partial class DrugCategoryBusinessHandler : BaseBusinessHandler<DrugCategory>
    {   
        public DrugCategoryBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DrugCategoryRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 药物临床分类的业务逻辑处理 
	/// </summary>
	[Description("药物临床分类的业务逻辑处理")]
	public partial class DrugClinicalCategoryBusinessHandler : BaseBusinessHandler<DrugClinicalCategory>
    {   
        public DrugClinicalCategoryBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DrugClinicalCategoryRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 剂型的业务逻辑处理 
	/// </summary>
	[Description("剂型的业务逻辑处理")]
	public partial class DictionaryDosageBusinessHandler : BaseBusinessHandler<DictionaryDosage>
    {   
        public DictionaryDosageBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DictionaryDosageRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 药品信息的业务逻辑处理 
	/// </summary>
	[Description("药品信息的业务逻辑处理")]
	public partial class DrugInfoBusinessHandler : BaseBusinessHandler<DrugInfo>
    {   
        public DrugInfoBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DrugInfoRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 药物库存的业务逻辑处理 
	/// </summary>
	[Description("药物库存的业务逻辑处理")]
	public partial class DrugInventoryRecordBusinessHandler : BaseBusinessHandler<DrugInventoryRecord>
    {   
        public DrugInventoryRecordBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DrugInventoryRecordRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 药品养护记录的业务逻辑处理 
	/// </summary>
	[Description("药品养护记录的业务逻辑处理")]
	public partial class DrugMaintainRecordBusinessHandler : BaseBusinessHandler<DrugMaintainRecord>
    {   
        public DrugMaintainRecordBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DrugMaintainRecordRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 药品养护记录明细的业务逻辑处理 
	/// </summary>
	[Description("药品养护记录明细的业务逻辑处理")]
	public partial class DrugMaintainRecordDetailBusinessHandler : BaseBusinessHandler<DrugMaintainRecordDetail>
    {   
        public DrugMaintainRecordDetailBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DrugMaintainRecordDetailRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 计量单位的业务逻辑处理 
	/// </summary>
	[Description("计量单位的业务逻辑处理")]
	public partial class DictionaryMeasurementUnitBusinessHandler : BaseBusinessHandler<DictionaryMeasurementUnit>
    {   
        public DictionaryMeasurementUnitBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DictionaryMeasurementUnitRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 拆零单位的业务逻辑处理 
	/// </summary>
	[Description("拆零单位的业务逻辑处理")]
	public partial class DictionaryPiecemealUnitBusinessHandler : BaseBusinessHandler<DictionaryPiecemealUnit>
    {   
        public DictionaryPiecemealUnitBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DictionaryPiecemealUnitRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 药物规格的业务逻辑处理 
	/// </summary>
	[Description("药物规格的业务逻辑处理")]
	public partial class DictionarySpecificationBusinessHandler : BaseBusinessHandler<DictionarySpecification>
    {   
        public DictionarySpecificationBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DictionarySpecificationRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 储藏方式的业务逻辑处理 
	/// </summary>
	[Description("储藏方式的业务逻辑处理")]
	public partial class DictionaryStorageTypeBusinessHandler : BaseBusinessHandler<DictionaryStorageType>
    {   
        public DictionaryStorageTypeBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DictionaryStorageTypeRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 用户自定义药物类型的业务逻辑处理 
	/// </summary>
	[Description("用户自定义药物类型的业务逻辑处理")]
	public partial class DictionaryUserDefinedTypeBusinessHandler : BaseBusinessHandler<DictionaryUserDefinedType>
    {   
        public DictionaryUserDefinedTypeBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DictionaryUserDefinedTypeRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 授权书的业务逻辑处理 
	/// </summary>
	[Description("授权书的业务逻辑处理")]
	public partial class AuthorizationDocBusinessHandler : BaseBusinessHandler<AuthorizationDoc>
    {   
        public AuthorizationDocBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.AuthorizationDocRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 药品养护设置的业务逻辑处理 
	/// </summary>
	[Description("药品养护设置的业务逻辑处理")]
	public partial class DrugMaintainSetBusinessHandler : BaseBusinessHandler<DrugMaintainSet>
    {   
        public DrugMaintainSetBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.DrugMaintainSetRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 员工的业务逻辑处理 
	/// </summary>
	[Description("员工的业务逻辑处理")]
	public partial class EmployeeBusinessHandler : BaseBusinessHandler<Employee>
    {   
        public EmployeeBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.EmployeeRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// GMSP证书规定的经营范围的业务逻辑处理 
	/// </summary>
	[Description("GMSP证书规定的经营范围的业务逻辑处理")]
	public partial class GMSPLicenseBusinessScopeBusinessHandler : BaseBusinessHandler<GMSPLicenseBusinessScope>
    {   
        public GMSPLicenseBusinessScopeBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.GMSPLicenseBusinessScopeRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 库存的业务逻辑处理 
	/// </summary>
	[Description("库存的业务逻辑处理")]
	public partial class InventoryRecordBusinessHandler : BaseBusinessHandler<InventoryRecord>
    {   
        public InventoryRecordBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.InventoryRecordRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 生产厂家 的业务逻辑处理 
	/// </summary>
	[Description("生产厂家 的业务逻辑处理")]
	public partial class ManufacturerBusinessHandler : BaseBusinessHandler<Manufacturer>
    {   
        public ManufacturerBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.ManufacturerRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 包装材质的业务逻辑处理 
	/// </summary>
	[Description("包装材质的业务逻辑处理")]
	public partial class PackagingMaterialBusinessHandler : BaseBusinessHandler<PackagingMaterial>
    {   
        public PackagingMaterialBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PackagingMaterialRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 包装的业务逻辑处理 
	/// </summary>
	[Description("包装的业务逻辑处理")]
	public partial class PackagingUnitBusinessHandler : BaseBusinessHandler<PackagingUnit>
    {   
        public PackagingUnitBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PackagingUnitRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 付款方式的业务逻辑处理 
	/// </summary>
	[Description("付款方式的业务逻辑处理")]
	public partial class PaymentMethodBusinessHandler : BaseBusinessHandler<PaymentMethod>
    {   
        public PaymentMethodBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PaymentMethodRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 药品经营许可证的业务逻辑处理 
	/// </summary>
	[Description("药品经营许可证的业务逻辑处理")]
	public partial class GSPLicenseBusinessHandler : BaseBusinessHandler<GSPLicense>
    {   
        public GSPLicenseBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.GSPLicenseRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// GMP证书的业务逻辑处理 
	/// </summary>
	[Description("GMP证书的业务逻辑处理")]
	public partial class GMPLicenseBusinessHandler : BaseBusinessHandler<GMPLicense>
    {   
        public GMPLicenseBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.GMPLicenseRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 营业执照的业务逻辑处理 
	/// </summary>
	[Description("营业执照的业务逻辑处理")]
	public partial class BusinessLicenseBusinessHandler : BaseBusinessHandler<BusinessLicense>
    {   
        public BusinessLicenseBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.BusinessLicenseRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 药品生产许可证的业务逻辑处理 
	/// </summary>
	[Description("药品生产许可证的业务逻辑处理")]
	public partial class MedicineProductionLicenseBusinessHandler : BaseBusinessHandler<MedicineProductionLicense>
    {   
        public MedicineProductionLicenseBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.MedicineProductionLicenseRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// GSP证书的业务逻辑处理 
	/// </summary>
	[Description("GSP证书的业务逻辑处理")]
	public partial class MedicineBusinessLicenseBusinessHandler : BaseBusinessHandler<MedicineBusinessLicense>
    {   
        public MedicineBusinessLicenseBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.MedicineBusinessLicenseRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 器械经营许可证的业务逻辑处理 
	/// </summary>
	[Description("器械经营许可证的业务逻辑处理")]
	public partial class InstrumentsBusinessLicenseBusinessHandler : BaseBusinessHandler<InstrumentsBusinessLicense>
    {   
        public InstrumentsBusinessLicenseBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.InstrumentsBusinessLicenseRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 器械生产许可证的业务逻辑处理 
	/// </summary>
	[Description("器械生产许可证的业务逻辑处理")]
	public partial class InstrumentsProductionLicenseBusinessHandler : BaseBusinessHandler<InstrumentsProductionLicense>
    {   
        public InstrumentsProductionLicenseBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.InstrumentsProductionLicenseRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 组织机构代码证的业务逻辑处理 
	/// </summary>
	[Description("组织机构代码证的业务逻辑处理")]
	public partial class OrganizationCodeLicenseBusinessHandler : BaseBusinessHandler<OrganizationCodeLicense>
    {   
        public OrganizationCodeLicenseBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.OrganizationCodeLicenseRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 食品流通许可证的业务逻辑处理 
	/// </summary>
	[Description("食品流通许可证的业务逻辑处理")]
	public partial class FoodCirculateLicenseBusinessHandler : BaseBusinessHandler<FoodCirculateLicense>
    {   
        public FoodCirculateLicenseBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.FoodCirculateLicenseRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 卫生许可证的业务逻辑处理 
	/// </summary>
	[Description("卫生许可证的业务逻辑处理")]
	public partial class HealthLicenseBusinessHandler : BaseBusinessHandler<HealthLicense>
    {   
        public HealthLicenseBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.HealthLicenseRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 税务登记证的业务逻辑处理 
	/// </summary>
	[Description("税务登记证的业务逻辑处理")]
	public partial class TaxRegisterLicenseBusinessHandler : BaseBusinessHandler<TaxRegisterLicense>
    {   
        public TaxRegisterLicenseBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.TaxRegisterLicenseRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 事业单位法人证的业务逻辑处理 
	/// </summary>
	[Description("事业单位法人证的业务逻辑处理")]
	public partial class LnstitutionLegalPersonLicenseBusinessHandler : BaseBusinessHandler<LnstitutionLegalPersonLicense>
    {   
        public LnstitutionLegalPersonLicenseBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.LnstitutionLegalPersonLicenseRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 医疗机构执业许可证的业务逻辑处理 
	/// </summary>
	[Description("医疗机构执业许可证的业务逻辑处理")]
	public partial class MmedicalInstitutionPermitBusinessHandler : BaseBusinessHandler<MmedicalInstitutionPermit>
    {   
        public MmedicalInstitutionPermitBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.MmedicalInstitutionPermitRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 全国工业产品生产许可证的业务逻辑处理 
	/// </summary>
	[Description("全国工业产品生产许可证的业务逻辑处理")]
	public partial class IndustoryProductCertificateBusinessHandler : BaseBusinessHandler<IndustoryProductCertificate>
    {   
        public IndustoryProductCertificateBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.IndustoryProductCertificateRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 医疗分类的业务逻辑处理 
	/// </summary>
	[Description("医疗分类的业务逻辑处理")]
	public partial class MedicalCategoryBusinessHandler : BaseBusinessHandler<MedicalCategory>
    {   
        public MedicalCategoryBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.MedicalCategoryRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 医疗详细分类的业务逻辑处理 
	/// </summary>
	[Description("医疗详细分类的业务逻辑处理")]
	public partial class MedicalCategoryDetailBusinessHandler : BaseBusinessHandler<MedicalCategoryDetail>
    {   
        public MedicalCategoryDetailBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.MedicalCategoryDetailRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 功能模块的业务逻辑处理 
	/// </summary>
	[Description("功能模块的业务逻辑处理")]
	public partial class ModuleBusinessHandler : BaseBusinessHandler<Module>
    {   
        public ModuleBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.ModuleRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 功能模块分类的业务逻辑处理 
	/// </summary>
	[Description("功能模块分类的业务逻辑处理")]
	public partial class ModuleCatetoryBusinessHandler : BaseBusinessHandler<ModuleCatetory>
    {   
        public ModuleCatetoryBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.ModuleCatetoryRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 功能模块与角色的关联的业务逻辑处理 
	/// </summary>
	[Description("功能模块与角色的关联的业务逻辑处理")]
	public partial class ModuleWithRoleBusinessHandler : BaseBusinessHandler<ModuleWithRole>
    {   
        public ModuleWithRoleBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.ModuleWithRoleRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 文件的业务逻辑处理 
	/// </summary>
	[Description("文件的业务逻辑处理")]
	public partial class PharmacyFileBusinessHandler : BaseBusinessHandler<PharmacyFile>
    {   
        public PharmacyFileBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PharmacyFileRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 采购合同的业务逻辑处理 
	/// </summary>
	[Description("采购合同的业务逻辑处理")]
	public partial class PurchaseAgreementBusinessHandler : BaseBusinessHandler<PurchaseAgreement>
    {   
        public PurchaseAgreementBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseAgreementRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 验收记录的业务逻辑处理 
	/// </summary>
	[Description("验收记录的业务逻辑处理")]
	public partial class PurchaseCheckingOrderBusinessHandler : BaseBusinessHandler<PurchaseCheckingOrder>
    {   
        public PurchaseCheckingOrderBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseCheckingOrderRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 采购到货验收的业务逻辑处理 
	/// </summary>
	[Description("采购到货验收的业务逻辑处理")]
	public partial class PurchaseCheckingOrderDetailBusinessHandler : BaseBusinessHandler<PurchaseCheckingOrderDetail>
    {   
        public PurchaseCheckingOrderDetailBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseCheckingOrderDetailRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 库存记录的业务逻辑处理 
	/// </summary>
	[Description("库存记录的业务逻辑处理")]
	public partial class PurchaseInInventeryOrderBusinessHandler : BaseBusinessHandler<PurchaseInInventeryOrder>
    {   
        public PurchaseInInventeryOrderBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseInInventeryOrderRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 库存记录详细的业务逻辑处理 
	/// </summary>
	[Description("库存记录详细的业务逻辑处理")]
	public partial class PurchaseInInventeryOrderDetailBusinessHandler : BaseBusinessHandler<PurchaseInInventeryOrderDetail>
    {   
        public PurchaseInInventeryOrderDetailBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseInInventeryOrderDetailRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 管理要求分类的业务逻辑处理 
	/// </summary>
	[Description("管理要求分类的业务逻辑处理")]
	public partial class PurchaseManageCategoryBusinessHandler : BaseBusinessHandler<PurchaseManageCategory>
    {   
        public PurchaseManageCategoryBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseManageCategoryRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 管理要求分类详细的业务逻辑处理 
	/// </summary>
	[Description("管理要求分类详细的业务逻辑处理")]
	public partial class PurchaseManageCategoryDetailBusinessHandler : BaseBusinessHandler<PurchaseManageCategoryDetail>
    {   
        public PurchaseManageCategoryDetailBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseManageCategoryDetailRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 采购单的业务逻辑处理 
	/// </summary>
	[Description("采购单的业务逻辑处理")]
	public partial class PurchaseOrderBusinessHandler : BaseBusinessHandler<PurchaseOrder>
    {   
        public PurchaseOrderBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseOrderRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 采购明细的业务逻辑处理 
	/// </summary>
	[Description("采购明细的业务逻辑处理")]
	public partial class PurchaseOrderDetailBusinessHandler : BaseBusinessHandler<PurchaseOrderDetail>
    {   
        public PurchaseOrderDetailBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseOrderDetailRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 的业务逻辑处理 
	/// </summary>
	[Description("的业务逻辑处理")]
	public partial class PurchaseOrderReturnBusinessHandler : BaseBusinessHandler<PurchaseOrderReturn>
    {   
        public PurchaseOrderReturnBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseOrderReturnRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 的业务逻辑处理 
	/// </summary>
	[Description("的业务逻辑处理")]
	public partial class PurchaseOrderReturnDetailBusinessHandler : BaseBusinessHandler<PurchaseOrderReturnDetail>
    {   
        public PurchaseOrderReturnDetailBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseOrderReturnDetailRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 采购收货单的业务逻辑处理 
	/// </summary>
	[Description("采购收货单的业务逻辑处理")]
	public partial class PurchaseReceivingOrderBusinessHandler : BaseBusinessHandler<PurchaseReceivingOrder>
    {   
        public PurchaseReceivingOrderBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseReceivingOrderRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 采购收货详细单的业务逻辑处理 
	/// </summary>
	[Description("采购收货详细单的业务逻辑处理")]
	public partial class PurchaseReceivingOrderDetailBusinessHandler : BaseBusinessHandler<PurchaseReceivingOrderDetail>
    {   
        public PurchaseReceivingOrderDetailBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseReceivingOrderDetailRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 购货单位的业务逻辑处理 
	/// </summary>
	[Description("购货单位的业务逻辑处理")]
	public partial class PurchaseUnitBusinessHandler : BaseBusinessHandler<PurchaseUnit>
    {   
        public PurchaseUnitBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseUnitRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 购货单位采购人员的业务逻辑处理 
	/// </summary>
	[Description("购货单位采购人员的业务逻辑处理")]
	public partial class PurchaseUnitBuyerBusinessHandler : BaseBusinessHandler<PurchaseUnitBuyer>
    {   
        public PurchaseUnitBuyerBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseUnitBuyerRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 购货单位提货人员的业务逻辑处理 
	/// </summary>
	[Description("购货单位提货人员的业务逻辑处理")]
	public partial class PurchaseUnitDelivererBusinessHandler : BaseBusinessHandler<PurchaseUnitDeliverer>
    {   
        public PurchaseUnitDelivererBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseUnitDelivererRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 购货单位类型的业务逻辑处理 
	/// </summary>
	[Description("购货单位类型的业务逻辑处理")]
	public partial class PurchaseUnitTypeBusinessHandler : BaseBusinessHandler<PurchaseUnitType>
    {   
        public PurchaseUnitTypeBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchaseUnitTypeRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 的业务逻辑处理 
	/// </summary>
	[Description("的业务逻辑处理")]
	public partial class PurchasingPlanBusinessHandler : BaseBusinessHandler<PurchasingPlan>
    {   
        public PurchasingPlanBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchasingPlanRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 的业务逻辑处理 
	/// </summary>
	[Description("的业务逻辑处理")]
	public partial class PurchasingPlanDetailBusinessHandler : BaseBusinessHandler<PurchasingPlanDetail>
    {   
        public PurchasingPlanDetailBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.PurchasingPlanDetailRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 不常用字(生僻字)的业务逻辑处理 
	/// </summary>
	[Description("不常用字(生僻字)的业务逻辑处理")]
	public partial class RarewordBusinessHandler : BaseBusinessHandler<Rareword>
    {   
        public RarewordBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.RarewordRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 零售会员的业务逻辑处理 
	/// </summary>
	[Description("零售会员的业务逻辑处理")]
	public partial class RetailMemberBusinessHandler : BaseBusinessHandler<RetailMember>
    {   
        public RetailMemberBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.RetailMemberRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 的业务逻辑处理 
	/// </summary>
	[Description("的业务逻辑处理")]
	public partial class RetailOrderBusinessHandler : BaseBusinessHandler<RetailOrder>
    {   
        public RetailOrderBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.RetailOrderRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 零售单明细的业务逻辑处理 
	/// </summary>
	[Description("零售单明细的业务逻辑处理")]
	public partial class RetailOrderDetailBusinessHandler : BaseBusinessHandler<RetailOrderDetail>
    {   
        public RetailOrderDetailBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.RetailOrderDetailRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 系统角色的业务逻辑处理 
	/// </summary>
	[Description("系统角色的业务逻辑处理")]
	public partial class RoleBusinessHandler : BaseBusinessHandler<Role>
    {   
        public RoleBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.RoleRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 角色与用户的关联的业务逻辑处理 
	/// </summary>
	[Description("角色与用户的关联的业务逻辑处理")]
	public partial class RoleWithUserBusinessHandler : BaseBusinessHandler<RoleWithUser>
    {   
        public RoleWithUserBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.RoleWithUserRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 销售单的业务逻辑处理 
	/// </summary>
	[Description("销售单的业务逻辑处理")]
	public partial class SalesOrderBusinessHandler : BaseBusinessHandler<SalesOrder>
    {   
        public SalesOrderBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.SalesOrderRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 的业务逻辑处理 
	/// </summary>
	[Description("的业务逻辑处理")]
	public partial class SalesOrderDeliverDetailBusinessHandler : BaseBusinessHandler<SalesOrderDeliverDetail>
    {   
        public SalesOrderDeliverDetailBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.SalesOrderDeliverDetailRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 销售发货记录的业务逻辑处理 
	/// </summary>
	[Description("销售发货记录的业务逻辑处理")]
	public partial class SalesOrderDeliverRecordBusinessHandler : BaseBusinessHandler<SalesOrderDeliverRecord>
    {   
        public SalesOrderDeliverRecordBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.SalesOrderDeliverRecordRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 销售单明细的业务逻辑处理 
	/// </summary>
	[Description("销售单明细的业务逻辑处理")]
	public partial class SalesOrderDetailBusinessHandler : BaseBusinessHandler<SalesOrderDetail>
    {   
        public SalesOrderDetailBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.SalesOrderDetailRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 的业务逻辑处理 
	/// </summary>
	[Description("的业务逻辑处理")]
	public partial class SalesOrderReturnBusinessHandler : BaseBusinessHandler<SalesOrderReturn>
    {   
        public SalesOrderReturnBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.SalesOrderReturnRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 的业务逻辑处理 
	/// </summary>
	[Description("的业务逻辑处理")]
	public partial class SalesOrderReturnDetailBusinessHandler : BaseBusinessHandler<SalesOrderReturnDetail>
    {   
        public SalesOrderReturnDetailBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.SalesOrderReturnDetailRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 销售出库单的业务逻辑处理 
	/// </summary>
	[Description("销售出库单的业务逻辑处理")]
	public partial class OutInventoryBusinessHandler : BaseBusinessHandler<OutInventory>
    {   
        public OutInventoryBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.OutInventoryRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 设置重点药品记录表的业务逻辑处理 
	/// </summary>
	[Description("设置重点药品记录表的业务逻辑处理")]
	public partial class SetSpeicalDrugRecordBusinessHandler : BaseBusinessHandler<SetSpeicalDrugRecord>
    {   
        public SetSpeicalDrugRecordBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.SetSpeicalDrugRecordRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 特殊管理药物类型的业务逻辑处理 
	/// </summary>
	[Description("特殊管理药物类型的业务逻辑处理")]
	public partial class SpecialDrugCategoryBusinessHandler : BaseBusinessHandler<SpecialDrugCategory>
    {   
        public SpecialDrugCategoryBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.SpecialDrugCategoryRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 门店的业务逻辑处理 
	/// </summary>
	[Description("门店的业务逻辑处理")]
	public partial class StoreBusinessHandler : BaseBusinessHandler<Store>
    {   
        public StoreBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.StoreRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 首营药材供货人管理的业务逻辑处理 
	/// </summary>
	[Description("首营药材供货人管理的业务逻辑处理")]
	public partial class SupplyPersonBusinessHandler : BaseBusinessHandler<SupplyPerson>
    {   
        public SupplyPersonBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.SupplyPersonRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 供货单位的业务逻辑处理 
	/// </summary>
	[Description("供货单位的业务逻辑处理")]
	public partial class SupplyUnitBusinessHandler : BaseBusinessHandler<SupplyUnit>
    {   
        public SupplyUnitBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.SupplyUnitRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 供货商销售人员的业务逻辑处理 
	/// </summary>
	[Description("供货商销售人员的业务逻辑处理")]
	public partial class SupplyUnitSalesmanBusinessHandler : BaseBusinessHandler<SupplyUnitSalesman>
    {   
        public SupplyUnitSalesmanBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.SupplyUnitSalesmanRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 税率的业务逻辑处理 
	/// </summary>
	[Description("税率的业务逻辑处理")]
	public partial class TaxRateBusinessHandler : BaseBusinessHandler<TaxRate>
    {   
        public TaxRateBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.TaxRateRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 企业类型的业务逻辑处理 
	/// </summary>
	[Description("企业类型的业务逻辑处理")]
	public partial class UnitTypeBusinessHandler : BaseBusinessHandler<UnitType>
    {   
        public UnitTypeBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.UnitTypeRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 数据上传记录的业务逻辑处理 
	/// </summary>
	[Description("数据上传记录的业务逻辑处理")]
	public partial class UploadRecordBusinessHandler : BaseBusinessHandler<UploadRecord>
    {   
        public UploadRecordBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.UploadRecordRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 系统用户的业务逻辑处理 
	/// </summary>
	[Description("系统用户的业务逻辑处理")]
	public partial class UserBusinessHandler : BaseBusinessHandler<User>
    {   
        public UserBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.UserRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 用户日志的业务逻辑处理 
	/// </summary>
	[Description("用户日志的业务逻辑处理")]
	public partial class UserLogBusinessHandler : BaseBusinessHandler<UserLog>
    {   
        public UserLogBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.UserLogRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 车辆的业务逻辑处理 
	/// </summary>
	[Description("车辆的业务逻辑处理")]
	public partial class VehicleBusinessHandler : BaseBusinessHandler<Vehicle>
    {   
        public VehicleBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.VehicleRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 仓库的业务逻辑处理 
	/// </summary>
	[Description("仓库的业务逻辑处理")]
	public partial class WarehouseBusinessHandler : BaseBusinessHandler<Warehouse>
    {   
        public WarehouseBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.WarehouseRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 库区的业务逻辑处理 
	/// </summary>
	[Description("库区的业务逻辑处理")]
	public partial class WarehouseZoneBusinessHandler : BaseBusinessHandler<WarehouseZone>
    {   
        public WarehouseZoneBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.WarehouseZoneRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 的业务逻辑处理 
	/// </summary>
	[Description("的业务逻辑处理")]
	public partial class WarehouseZonePositionBusinessHandler : BaseBusinessHandler<WarehouseZonePosition>
    {   
        public WarehouseZonePositionBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.WarehouseZonePositionRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 报警设置的业务逻辑处理 
	/// </summary>
	[Description("报警设置的业务逻辑处理")]
	public partial class WaringSetBusinessHandler : BaseBusinessHandler<WaringSet>
    {   
        public WaringSetBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.WaringSetRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    		
	/// <summary>
	/// 销售出库单的业务逻辑处理 
	/// </summary>
	[Description("销售出库单的业务逻辑处理")]
	public partial class OutInventoryDetailBusinessHandler : BaseBusinessHandler<OutInventoryDetail>
    {   
        public OutInventoryDetailBusinessHandler(RepositoryProvider repositoryProvider,IConnectedInfoProvider connectedInfoProvider)
            : base(repositoryProvider.OutInventoryDetailRepository,repositoryProvider,connectedInfoProvider)
        {
		    
        }
    }
	
    }
