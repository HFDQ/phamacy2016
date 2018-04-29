 

 
 
 
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Repository;

namespace BugsBox.Pharmacy.Repository
{
 
   public class RepositoryProvider:IDisposable
    {

	   public Db Db {get;private set;}

       public RepositoryProvider(Db db)
       {
           this.Db = db;
		  //LoggerHelper.Instance.Warning("RepositoryProvider 创建了");
       }

	  
		private IApprovalFlowRepository _ApprovalFlowRepository=null;
	    /// <summary> 
		/// 审批结点(ApprovalFlow) 仓储对象
        /// </summary>
		public IApprovalFlowRepository ApprovalFlowRepository
		{
			get
			{
				lock(this)
				{
					if( _ApprovalFlowRepository==null)
					{
						_ApprovalFlowRepository=new ApprovalFlowRepository(Db);
						_ApprovalFlowRepository.RepositoryProvider = this;
					}
					return _ApprovalFlowRepository;
				}
			}
		} 
		private IApprovalFlowNodeRepository _ApprovalFlowNodeRepository=null;
	    /// <summary> 
		/// 审批结点(ApprovalFlowNode) 仓储对象
        /// </summary>
		public IApprovalFlowNodeRepository ApprovalFlowNodeRepository
		{
			get
			{
				lock(this)
				{
					if( _ApprovalFlowNodeRepository==null)
					{
						_ApprovalFlowNodeRepository=new ApprovalFlowNodeRepository(Db);
						_ApprovalFlowNodeRepository.RepositoryProvider = this;
					}
					return _ApprovalFlowNodeRepository;
				}
			}
		} 
		private IApprovalFlowTypeRepository _ApprovalFlowTypeRepository=null;
	    /// <summary> 
		/// 审批流程类型(ApprovalFlowType) 仓储对象
        /// </summary>
		public IApprovalFlowTypeRepository ApprovalFlowTypeRepository
		{
			get
			{
				lock(this)
				{
					if( _ApprovalFlowTypeRepository==null)
					{
						_ApprovalFlowTypeRepository=new ApprovalFlowTypeRepository(Db);
						_ApprovalFlowTypeRepository.RepositoryProvider = this;
					}
					return _ApprovalFlowTypeRepository;
				}
			}
		} 
		private IApprovalFlowRecordRepository _ApprovalFlowRecordRepository=null;
	    /// <summary> 
		/// 审批流程记录(ApprovalFlowRecord) 仓储对象
        /// </summary>
		public IApprovalFlowRecordRepository ApprovalFlowRecordRepository
		{
			get
			{
				lock(this)
				{
					if( _ApprovalFlowRecordRepository==null)
					{
						_ApprovalFlowRecordRepository=new ApprovalFlowRecordRepository(Db);
						_ApprovalFlowRecordRepository.RepositoryProvider = this;
					}
					return _ApprovalFlowRecordRepository;
				}
			}
		} 
		private IBillDocumentCodeRepository _BillDocumentCodeRepository=null;
	    /// <summary> 
		/// 单据编号(BillDocumentCode) 仓储对象
        /// </summary>
		public IBillDocumentCodeRepository BillDocumentCodeRepository
		{
			get
			{
				lock(this)
				{
					if( _BillDocumentCodeRepository==null)
					{
						_BillDocumentCodeRepository=new BillDocumentCodeRepository(Db);
						_BillDocumentCodeRepository.RepositoryProvider = this;
					}
					return _BillDocumentCodeRepository;
				}
			}
		} 
		private IBusinessScopeRepository _BusinessScopeRepository=null;
	    /// <summary> 
		/// 经营范围(BusinessScope) 仓储对象
        /// </summary>
		public IBusinessScopeRepository BusinessScopeRepository
		{
			get
			{
				lock(this)
				{
					if( _BusinessScopeRepository==null)
					{
						_BusinessScopeRepository=new BusinessScopeRepository(Db);
						_BusinessScopeRepository.RepositoryProvider = this;
					}
					return _BusinessScopeRepository;
				}
			}
		} 
		private IBusinessScopeCategoryRepository _BusinessScopeCategoryRepository=null;
	    /// <summary> 
		/// 经营范围分类(BusinessScopeCategory) 仓储对象
        /// </summary>
		public IBusinessScopeCategoryRepository BusinessScopeCategoryRepository
		{
			get
			{
				lock(this)
				{
					if( _BusinessScopeCategoryRepository==null)
					{
						_BusinessScopeCategoryRepository=new BusinessScopeCategoryRepository(Db);
						_BusinessScopeCategoryRepository.RepositoryProvider = this;
					}
					return _BusinessScopeCategoryRepository;
				}
			}
		} 
		private IBusinessTypeRepository _BusinessTypeRepository=null;
	    /// <summary> 
		/// 经营方式(BusinessType) 仓储对象
        /// </summary>
		public IBusinessTypeRepository BusinessTypeRepository
		{
			get
			{
				lock(this)
				{
					if( _BusinessTypeRepository==null)
					{
						_BusinessTypeRepository=new BusinessTypeRepository(Db);
						_BusinessTypeRepository.RepositoryProvider = this;
					}
					return _BusinessTypeRepository;
				}
			}
		} 
		private IBusinessTypeManageCategoryDetailRepository _BusinessTypeManageCategoryDetailRepository=null;
	    /// <summary> 
		/// 经营方式的管理要求分类详细(BusinessTypeManageCategoryDetail) 仓储对象
        /// </summary>
		public IBusinessTypeManageCategoryDetailRepository BusinessTypeManageCategoryDetailRepository
		{
			get
			{
				lock(this)
				{
					if( _BusinessTypeManageCategoryDetailRepository==null)
					{
						_BusinessTypeManageCategoryDetailRepository=new BusinessTypeManageCategoryDetailRepository(Db);
						_BusinessTypeManageCategoryDetailRepository.RepositoryProvider = this;
					}
					return _BusinessTypeManageCategoryDetailRepository;
				}
			}
		} 
		private IChinaDistrictRepository _ChinaDistrictRepository=null;
	    /// <summary> 
		/// 行政区域划分(ChinaDistrict) 仓储对象
        /// </summary>
		public IChinaDistrictRepository ChinaDistrictRepository
		{
			get
			{
				lock(this)
				{
					if( _ChinaDistrictRepository==null)
					{
						_ChinaDistrictRepository=new ChinaDistrictRepository(Db);
						_ChinaDistrictRepository.RepositoryProvider = this;
					}
					return _ChinaDistrictRepository;
				}
			}
		} 
		private IDirectSalesOrderRepository _DirectSalesOrderRepository=null;
	    /// <summary> 
		/// (DirectSalesOrder) 仓储对象
        /// </summary>
		public IDirectSalesOrderRepository DirectSalesOrderRepository
		{
			get
			{
				lock(this)
				{
					if( _DirectSalesOrderRepository==null)
					{
						_DirectSalesOrderRepository=new DirectSalesOrderRepository(Db);
						_DirectSalesOrderRepository.RepositoryProvider = this;
					}
					return _DirectSalesOrderRepository;
				}
			}
		} 
		private IDirectSalesOrderDetailRepository _DirectSalesOrderDetailRepository=null;
	    /// <summary> 
		/// (DirectSalesOrderDetail) 仓储对象
        /// </summary>
		public IDirectSalesOrderDetailRepository DirectSalesOrderDetailRepository
		{
			get
			{
				lock(this)
				{
					if( _DirectSalesOrderDetailRepository==null)
					{
						_DirectSalesOrderDetailRepository=new DirectSalesOrderDetailRepository(Db);
						_DirectSalesOrderDetailRepository.RepositoryProvider = this;
					}
					return _DirectSalesOrderDetailRepository;
				}
			}
		} 
		private IDocumentRefuseRepository _DocumentRefuseRepository=null;
	    /// <summary> 
		/// 收货拒收单(DocumentRefuse) 仓储对象
        /// </summary>
		public IDocumentRefuseRepository DocumentRefuseRepository
		{
			get
			{
				lock(this)
				{
					if( _DocumentRefuseRepository==null)
					{
						_DocumentRefuseRepository=new DocumentRefuseRepository(Db);
						_DocumentRefuseRepository.RepositoryProvider = this;
					}
					return _DocumentRefuseRepository;
				}
			}
		} 
		private IDrugInventoryRecordHisRepository _DrugInventoryRecordHisRepository=null;
	    /// <summary> 
		/// 药物库存变动历史(DrugInventoryRecordHis) 仓储对象
        /// </summary>
		public IDrugInventoryRecordHisRepository DrugInventoryRecordHisRepository
		{
			get
			{
				lock(this)
				{
					if( _DrugInventoryRecordHisRepository==null)
					{
						_DrugInventoryRecordHisRepository=new DrugInventoryRecordHisRepository(Db);
						_DrugInventoryRecordHisRepository.RepositoryProvider = this;
					}
					return _DrugInventoryRecordHisRepository;
				}
			}
		} 
		private IDrugMaintenanceRecordRepository _DrugMaintenanceRecordRepository=null;
	    /// <summary> 
		/// 药品养护记录(DrugMaintenanceRecord) 仓储对象
        /// </summary>
		public IDrugMaintenanceRecordRepository DrugMaintenanceRecordRepository
		{
			get
			{
				lock(this)
				{
					if( _DrugMaintenanceRecordRepository==null)
					{
						_DrugMaintenanceRecordRepository=new DrugMaintenanceRecordRepository(Db);
						_DrugMaintenanceRecordRepository.RepositoryProvider = this;
					}
					return _DrugMaintenanceRecordRepository;
				}
			}
		} 
		private IDrugsBreakageRepository _DrugsBreakageRepository=null;
	    /// <summary> 
		/// 报损药品(DrugsBreakage) 仓储对象
        /// </summary>
		public IDrugsBreakageRepository DrugsBreakageRepository
		{
			get
			{
				lock(this)
				{
					if( _DrugsBreakageRepository==null)
					{
						_DrugsBreakageRepository=new DrugsBreakageRepository(Db);
						_DrugsBreakageRepository.RepositoryProvider = this;
					}
					return _DrugsBreakageRepository;
				}
			}
		} 
		private IDrugsInventoryMoveRepository _DrugsInventoryMoveRepository=null;
	    /// <summary> 
		/// 移库(DrugsInventoryMove) 仓储对象
        /// </summary>
		public IDrugsInventoryMoveRepository DrugsInventoryMoveRepository
		{
			get
			{
				lock(this)
				{
					if( _DrugsInventoryMoveRepository==null)
					{
						_DrugsInventoryMoveRepository=new DrugsInventoryMoveRepository(Db);
						_DrugsInventoryMoveRepository.RepositoryProvider = this;
					}
					return _DrugsInventoryMoveRepository;
				}
			}
		} 
		private IDrugsUndeterminateRepository _DrugsUndeterminateRepository=null;
	    /// <summary> 
		/// 待处理药品(DrugsUndeterminate) 仓储对象
        /// </summary>
		public IDrugsUndeterminateRepository DrugsUndeterminateRepository
		{
			get
			{
				lock(this)
				{
					if( _DrugsUndeterminateRepository==null)
					{
						_DrugsUndeterminateRepository=new DrugsUndeterminateRepository(Db);
						_DrugsUndeterminateRepository.RepositoryProvider = this;
					}
					return _DrugsUndeterminateRepository;
				}
			}
		} 
		private IdrugsUnqualicationRepository _drugsUnqualicationRepository=null;
	    /// <summary> 
		/// 不合格药品(drugsUnqualication) 仓储对象
        /// </summary>
		public IdrugsUnqualicationRepository drugsUnqualicationRepository
		{
			get
			{
				lock(this)
				{
					if( _drugsUnqualicationRepository==null)
					{
						_drugsUnqualicationRepository=new drugsUnqualicationRepository(Db);
						_drugsUnqualicationRepository.RepositoryProvider = this;
					}
					return _drugsUnqualicationRepository;
				}
			}
		} 
		private IDrugsUnqualificationDestroyRepository _DrugsUnqualificationDestroyRepository=null;
	    /// <summary> 
		/// 不合格药品销毁情况(DrugsUnqualificationDestroy) 仓储对象
        /// </summary>
		public IDrugsUnqualificationDestroyRepository DrugsUnqualificationDestroyRepository
		{
			get
			{
				lock(this)
				{
					if( _DrugsUnqualificationDestroyRepository==null)
					{
						_DrugsUnqualificationDestroyRepository=new DrugsUnqualificationDestroyRepository(Db);
						_DrugsUnqualificationDestroyRepository.RepositoryProvider = this;
					}
					return _DrugsUnqualificationDestroyRepository;
				}
			}
		} 
		private IEduDetailsRepository _EduDetailsRepository=null;
	    /// <summary> 
		/// 培训档案细节(EduDetails) 仓储对象
        /// </summary>
		public IEduDetailsRepository EduDetailsRepository
		{
			get
			{
				lock(this)
				{
					if( _EduDetailsRepository==null)
					{
						_EduDetailsRepository=new EduDetailsRepository(Db);
						_EduDetailsRepository.RepositoryProvider = this;
					}
					return _EduDetailsRepository;
				}
			}
		} 
		private IEduDocumentRepository _EduDocumentRepository=null;
	    /// <summary> 
		/// 培训档案(EduDocument) 仓储对象
        /// </summary>
		public IEduDocumentRepository EduDocumentRepository
		{
			get
			{
				lock(this)
				{
					if( _EduDocumentRepository==null)
					{
						_EduDocumentRepository=new EduDocumentRepository(Db);
						_EduDocumentRepository.RepositoryProvider = this;
					}
					return _EduDocumentRepository;
				}
			}
		} 
		private IGoodsAdditionalPropertyRepository _GoodsAdditionalPropertyRepository=null;
	    /// <summary> 
		/// 商品附加属性(GoodsAdditionalProperty) 仓储对象
        /// </summary>
		public IGoodsAdditionalPropertyRepository GoodsAdditionalPropertyRepository
		{
			get
			{
				lock(this)
				{
					if( _GoodsAdditionalPropertyRepository==null)
					{
						_GoodsAdditionalPropertyRepository=new GoodsAdditionalPropertyRepository(Db);
						_GoodsAdditionalPropertyRepository.RepositoryProvider = this;
					}
					return _GoodsAdditionalPropertyRepository;
				}
			}
		} 
		private IHealthCheckDetailRepository _HealthCheckDetailRepository=null;
	    /// <summary> 
		/// 体检档案细节(HealthCheckDetail) 仓储对象
        /// </summary>
		public IHealthCheckDetailRepository HealthCheckDetailRepository
		{
			get
			{
				lock(this)
				{
					if( _HealthCheckDetailRepository==null)
					{
						_HealthCheckDetailRepository=new HealthCheckDetailRepository(Db);
						_HealthCheckDetailRepository.RepositoryProvider = this;
					}
					return _HealthCheckDetailRepository;
				}
			}
		} 
		private IHealthCheckDocumentRepository _HealthCheckDocumentRepository=null;
	    /// <summary> 
		/// 体检档案(HealthCheckDocument) 仓储对象
        /// </summary>
		public IHealthCheckDocumentRepository HealthCheckDocumentRepository
		{
			get
			{
				lock(this)
				{
					if( _HealthCheckDocumentRepository==null)
					{
						_HealthCheckDocumentRepository=new HealthCheckDocumentRepository(Db);
						_HealthCheckDocumentRepository.RepositoryProvider = this;
					}
					return _HealthCheckDocumentRepository;
				}
			}
		} 
		private IPurchaseCashOrderRepository _PurchaseCashOrderRepository=null;
	    /// <summary> 
		/// 采购结算单(PurchaseCashOrder) 仓储对象
        /// </summary>
		public IPurchaseCashOrderRepository PurchaseCashOrderRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseCashOrderRepository==null)
					{
						_PurchaseCashOrderRepository=new PurchaseCashOrderRepository(Db);
						_PurchaseCashOrderRepository.RepositoryProvider = this;
					}
					return _PurchaseCashOrderRepository;
				}
			}
		} 
		private IDeliveryRepository _DeliveryRepository=null;
	    /// <summary> 
		/// 配送信息(Delivery) 仓储对象
        /// </summary>
		public IDeliveryRepository DeliveryRepository
		{
			get
			{
				lock(this)
				{
					if( _DeliveryRepository==null)
					{
						_DeliveryRepository=new DeliveryRepository(Db);
						_DeliveryRepository.RepositoryProvider = this;
					}
					return _DeliveryRepository;
				}
			}
		} 
		private IDepartmentRepository _DepartmentRepository=null;
	    /// <summary> 
		/// 部门(Department) 仓储对象
        /// </summary>
		public IDepartmentRepository DepartmentRepository
		{
			get
			{
				lock(this)
				{
					if( _DepartmentRepository==null)
					{
						_DepartmentRepository=new DepartmentRepository(Db);
						_DepartmentRepository.RepositoryProvider = this;
					}
					return _DepartmentRepository;
				}
			}
		} 
		private IDistrictRepository _DistrictRepository=null;
	    /// <summary> 
		/// 区域(District) 仓储对象
        /// </summary>
		public IDistrictRepository DistrictRepository
		{
			get
			{
				lock(this)
				{
					if( _DistrictRepository==null)
					{
						_DistrictRepository=new DistrictRepository(Db);
						_DistrictRepository.RepositoryProvider = this;
					}
					return _DistrictRepository;
				}
			}
		} 
		private IDoubtDrugRepository _DoubtDrugRepository=null;
	    /// <summary> 
		/// 疑问药品(DoubtDrug) 仓储对象
        /// </summary>
		public IDoubtDrugRepository DoubtDrugRepository
		{
			get
			{
				lock(this)
				{
					if( _DoubtDrugRepository==null)
					{
						_DoubtDrugRepository=new DoubtDrugRepository(Db);
						_DoubtDrugRepository.RepositoryProvider = this;
					}
					return _DoubtDrugRepository;
				}
			}
		} 
		private IDrugApprovalNumberRepository _DrugApprovalNumberRepository=null;
	    /// <summary> 
		/// 药品批准文号(DrugApprovalNumber) 仓储对象
        /// </summary>
		public IDrugApprovalNumberRepository DrugApprovalNumberRepository
		{
			get
			{
				lock(this)
				{
					if( _DrugApprovalNumberRepository==null)
					{
						_DrugApprovalNumberRepository=new DrugApprovalNumberRepository(Db);
						_DrugApprovalNumberRepository.RepositoryProvider = this;
					}
					return _DrugApprovalNumberRepository;
				}
			}
		} 
		private IDrugCategoryRepository _DrugCategoryRepository=null;
	    /// <summary> 
		/// 药物分类(DrugCategory) 仓储对象
        /// </summary>
		public IDrugCategoryRepository DrugCategoryRepository
		{
			get
			{
				lock(this)
				{
					if( _DrugCategoryRepository==null)
					{
						_DrugCategoryRepository=new DrugCategoryRepository(Db);
						_DrugCategoryRepository.RepositoryProvider = this;
					}
					return _DrugCategoryRepository;
				}
			}
		} 
		private IDrugClinicalCategoryRepository _DrugClinicalCategoryRepository=null;
	    /// <summary> 
		/// 药物临床分类(DrugClinicalCategory) 仓储对象
        /// </summary>
		public IDrugClinicalCategoryRepository DrugClinicalCategoryRepository
		{
			get
			{
				lock(this)
				{
					if( _DrugClinicalCategoryRepository==null)
					{
						_DrugClinicalCategoryRepository=new DrugClinicalCategoryRepository(Db);
						_DrugClinicalCategoryRepository.RepositoryProvider = this;
					}
					return _DrugClinicalCategoryRepository;
				}
			}
		} 
		private IDictionaryDosageRepository _DictionaryDosageRepository=null;
	    /// <summary> 
		/// 剂型(DictionaryDosage) 仓储对象
        /// </summary>
		public IDictionaryDosageRepository DictionaryDosageRepository
		{
			get
			{
				lock(this)
				{
					if( _DictionaryDosageRepository==null)
					{
						_DictionaryDosageRepository=new DictionaryDosageRepository(Db);
						_DictionaryDosageRepository.RepositoryProvider = this;
					}
					return _DictionaryDosageRepository;
				}
			}
		} 
		private IDrugInfoRepository _DrugInfoRepository=null;
	    /// <summary> 
		/// 药品信息(DrugInfo) 仓储对象
        /// </summary>
		public IDrugInfoRepository DrugInfoRepository
		{
			get
			{
				lock(this)
				{
					if( _DrugInfoRepository==null)
					{
						_DrugInfoRepository=new DrugInfoRepository(Db);
						_DrugInfoRepository.RepositoryProvider = this;
					}
					return _DrugInfoRepository;
				}
			}
		} 
		private IDrugInventoryRecordRepository _DrugInventoryRecordRepository=null;
	    /// <summary> 
		/// 药物库存(DrugInventoryRecord) 仓储对象
        /// </summary>
		public IDrugInventoryRecordRepository DrugInventoryRecordRepository
		{
			get
			{
				lock(this)
				{
					if( _DrugInventoryRecordRepository==null)
					{
						_DrugInventoryRecordRepository=new DrugInventoryRecordRepository(Db);
						_DrugInventoryRecordRepository.RepositoryProvider = this;
					}
					return _DrugInventoryRecordRepository;
				}
			}
		} 
		private IDrugMaintainRecordRepository _DrugMaintainRecordRepository=null;
	    /// <summary> 
		/// 药品养护记录(DrugMaintainRecord) 仓储对象
        /// </summary>
		public IDrugMaintainRecordRepository DrugMaintainRecordRepository
		{
			get
			{
				lock(this)
				{
					if( _DrugMaintainRecordRepository==null)
					{
						_DrugMaintainRecordRepository=new DrugMaintainRecordRepository(Db);
						_DrugMaintainRecordRepository.RepositoryProvider = this;
					}
					return _DrugMaintainRecordRepository;
				}
			}
		} 
		private IDrugMaintainRecordDetailRepository _DrugMaintainRecordDetailRepository=null;
	    /// <summary> 
		/// 药品养护记录明细(DrugMaintainRecordDetail) 仓储对象
        /// </summary>
		public IDrugMaintainRecordDetailRepository DrugMaintainRecordDetailRepository
		{
			get
			{
				lock(this)
				{
					if( _DrugMaintainRecordDetailRepository==null)
					{
						_DrugMaintainRecordDetailRepository=new DrugMaintainRecordDetailRepository(Db);
						_DrugMaintainRecordDetailRepository.RepositoryProvider = this;
					}
					return _DrugMaintainRecordDetailRepository;
				}
			}
		} 
		private IDictionaryMeasurementUnitRepository _DictionaryMeasurementUnitRepository=null;
	    /// <summary> 
		/// 计量单位(DictionaryMeasurementUnit) 仓储对象
        /// </summary>
		public IDictionaryMeasurementUnitRepository DictionaryMeasurementUnitRepository
		{
			get
			{
				lock(this)
				{
					if( _DictionaryMeasurementUnitRepository==null)
					{
						_DictionaryMeasurementUnitRepository=new DictionaryMeasurementUnitRepository(Db);
						_DictionaryMeasurementUnitRepository.RepositoryProvider = this;
					}
					return _DictionaryMeasurementUnitRepository;
				}
			}
		} 
		private IDictionaryPiecemealUnitRepository _DictionaryPiecemealUnitRepository=null;
	    /// <summary> 
		/// 拆零单位(DictionaryPiecemealUnit) 仓储对象
        /// </summary>
		public IDictionaryPiecemealUnitRepository DictionaryPiecemealUnitRepository
		{
			get
			{
				lock(this)
				{
					if( _DictionaryPiecemealUnitRepository==null)
					{
						_DictionaryPiecemealUnitRepository=new DictionaryPiecemealUnitRepository(Db);
						_DictionaryPiecemealUnitRepository.RepositoryProvider = this;
					}
					return _DictionaryPiecemealUnitRepository;
				}
			}
		} 
		private IDictionarySpecificationRepository _DictionarySpecificationRepository=null;
	    /// <summary> 
		/// 药物规格(DictionarySpecification) 仓储对象
        /// </summary>
		public IDictionarySpecificationRepository DictionarySpecificationRepository
		{
			get
			{
				lock(this)
				{
					if( _DictionarySpecificationRepository==null)
					{
						_DictionarySpecificationRepository=new DictionarySpecificationRepository(Db);
						_DictionarySpecificationRepository.RepositoryProvider = this;
					}
					return _DictionarySpecificationRepository;
				}
			}
		} 
		private IDictionaryStorageTypeRepository _DictionaryStorageTypeRepository=null;
	    /// <summary> 
		/// 储藏方式(DictionaryStorageType) 仓储对象
        /// </summary>
		public IDictionaryStorageTypeRepository DictionaryStorageTypeRepository
		{
			get
			{
				lock(this)
				{
					if( _DictionaryStorageTypeRepository==null)
					{
						_DictionaryStorageTypeRepository=new DictionaryStorageTypeRepository(Db);
						_DictionaryStorageTypeRepository.RepositoryProvider = this;
					}
					return _DictionaryStorageTypeRepository;
				}
			}
		} 
		private IDictionaryUserDefinedTypeRepository _DictionaryUserDefinedTypeRepository=null;
	    /// <summary> 
		/// 用户自定义药物类型(DictionaryUserDefinedType) 仓储对象
        /// </summary>
		public IDictionaryUserDefinedTypeRepository DictionaryUserDefinedTypeRepository
		{
			get
			{
				lock(this)
				{
					if( _DictionaryUserDefinedTypeRepository==null)
					{
						_DictionaryUserDefinedTypeRepository=new DictionaryUserDefinedTypeRepository(Db);
						_DictionaryUserDefinedTypeRepository.RepositoryProvider = this;
					}
					return _DictionaryUserDefinedTypeRepository;
				}
			}
		} 
		private IAuthorizationDocRepository _AuthorizationDocRepository=null;
	    /// <summary> 
		/// 授权书(AuthorizationDoc) 仓储对象
        /// </summary>
		public IAuthorizationDocRepository AuthorizationDocRepository
		{
			get
			{
				lock(this)
				{
					if( _AuthorizationDocRepository==null)
					{
						_AuthorizationDocRepository=new AuthorizationDocRepository(Db);
						_AuthorizationDocRepository.RepositoryProvider = this;
					}
					return _AuthorizationDocRepository;
				}
			}
		} 
		private IDrugMaintainSetRepository _DrugMaintainSetRepository=null;
	    /// <summary> 
		/// 药品养护设置(DrugMaintainSet) 仓储对象
        /// </summary>
		public IDrugMaintainSetRepository DrugMaintainSetRepository
		{
			get
			{
				lock(this)
				{
					if( _DrugMaintainSetRepository==null)
					{
						_DrugMaintainSetRepository=new DrugMaintainSetRepository(Db);
						_DrugMaintainSetRepository.RepositoryProvider = this;
					}
					return _DrugMaintainSetRepository;
				}
			}
		} 
		private IEmployeeRepository _EmployeeRepository=null;
	    /// <summary> 
		/// 员工(Employee) 仓储对象
        /// </summary>
		public IEmployeeRepository EmployeeRepository
		{
			get
			{
				lock(this)
				{
					if( _EmployeeRepository==null)
					{
						_EmployeeRepository=new EmployeeRepository(Db);
						_EmployeeRepository.RepositoryProvider = this;
					}
					return _EmployeeRepository;
				}
			}
		} 
		private IGMSPLicenseBusinessScopeRepository _GMSPLicenseBusinessScopeRepository=null;
	    /// <summary> 
		/// GMSP证书规定的经营范围(GMSPLicenseBusinessScope) 仓储对象
        /// </summary>
		public IGMSPLicenseBusinessScopeRepository GMSPLicenseBusinessScopeRepository
		{
			get
			{
				lock(this)
				{
					if( _GMSPLicenseBusinessScopeRepository==null)
					{
						_GMSPLicenseBusinessScopeRepository=new GMSPLicenseBusinessScopeRepository(Db);
						_GMSPLicenseBusinessScopeRepository.RepositoryProvider = this;
					}
					return _GMSPLicenseBusinessScopeRepository;
				}
			}
		} 
		private IInventoryRecordRepository _InventoryRecordRepository=null;
	    /// <summary> 
		/// 库存(InventoryRecord) 仓储对象
        /// </summary>
		public IInventoryRecordRepository InventoryRecordRepository
		{
			get
			{
				lock(this)
				{
					if( _InventoryRecordRepository==null)
					{
						_InventoryRecordRepository=new InventoryRecordRepository(Db);
						_InventoryRecordRepository.RepositoryProvider = this;
					}
					return _InventoryRecordRepository;
				}
			}
		} 
		private IManufacturerRepository _ManufacturerRepository=null;
	    /// <summary> 
		/// 生产厂家 (Manufacturer) 仓储对象
        /// </summary>
		public IManufacturerRepository ManufacturerRepository
		{
			get
			{
				lock(this)
				{
					if( _ManufacturerRepository==null)
					{
						_ManufacturerRepository=new ManufacturerRepository(Db);
						_ManufacturerRepository.RepositoryProvider = this;
					}
					return _ManufacturerRepository;
				}
			}
		} 
		private IPackagingMaterialRepository _PackagingMaterialRepository=null;
	    /// <summary> 
		/// 包装材质(PackagingMaterial) 仓储对象
        /// </summary>
		public IPackagingMaterialRepository PackagingMaterialRepository
		{
			get
			{
				lock(this)
				{
					if( _PackagingMaterialRepository==null)
					{
						_PackagingMaterialRepository=new PackagingMaterialRepository(Db);
						_PackagingMaterialRepository.RepositoryProvider = this;
					}
					return _PackagingMaterialRepository;
				}
			}
		} 
		private IPackagingUnitRepository _PackagingUnitRepository=null;
	    /// <summary> 
		/// 包装(PackagingUnit) 仓储对象
        /// </summary>
		public IPackagingUnitRepository PackagingUnitRepository
		{
			get
			{
				lock(this)
				{
					if( _PackagingUnitRepository==null)
					{
						_PackagingUnitRepository=new PackagingUnitRepository(Db);
						_PackagingUnitRepository.RepositoryProvider = this;
					}
					return _PackagingUnitRepository;
				}
			}
		} 
		private IPaymentMethodRepository _PaymentMethodRepository=null;
	    /// <summary> 
		/// 付款方式(PaymentMethod) 仓储对象
        /// </summary>
		public IPaymentMethodRepository PaymentMethodRepository
		{
			get
			{
				lock(this)
				{
					if( _PaymentMethodRepository==null)
					{
						_PaymentMethodRepository=new PaymentMethodRepository(Db);
						_PaymentMethodRepository.RepositoryProvider = this;
					}
					return _PaymentMethodRepository;
				}
			}
		} 
		private IGSPLicenseRepository _GSPLicenseRepository=null;
	    /// <summary> 
		/// 药品经营许可证(GSPLicense) 仓储对象
        /// </summary>
		public IGSPLicenseRepository GSPLicenseRepository
		{
			get
			{
				lock(this)
				{
					if( _GSPLicenseRepository==null)
					{
						_GSPLicenseRepository=new GSPLicenseRepository(Db);
						_GSPLicenseRepository.RepositoryProvider = this;
					}
					return _GSPLicenseRepository;
				}
			}
		} 
		private IGMPLicenseRepository _GMPLicenseRepository=null;
	    /// <summary> 
		/// GMP证书(GMPLicense) 仓储对象
        /// </summary>
		public IGMPLicenseRepository GMPLicenseRepository
		{
			get
			{
				lock(this)
				{
					if( _GMPLicenseRepository==null)
					{
						_GMPLicenseRepository=new GMPLicenseRepository(Db);
						_GMPLicenseRepository.RepositoryProvider = this;
					}
					return _GMPLicenseRepository;
				}
			}
		} 
		private IBusinessLicenseRepository _BusinessLicenseRepository=null;
	    /// <summary> 
		/// 营业执照(BusinessLicense) 仓储对象
        /// </summary>
		public IBusinessLicenseRepository BusinessLicenseRepository
		{
			get
			{
				lock(this)
				{
					if( _BusinessLicenseRepository==null)
					{
						_BusinessLicenseRepository=new BusinessLicenseRepository(Db);
						_BusinessLicenseRepository.RepositoryProvider = this;
					}
					return _BusinessLicenseRepository;
				}
			}
		} 
		private IMedicineProductionLicenseRepository _MedicineProductionLicenseRepository=null;
	    /// <summary> 
		/// 药品生产许可证(MedicineProductionLicense) 仓储对象
        /// </summary>
		public IMedicineProductionLicenseRepository MedicineProductionLicenseRepository
		{
			get
			{
				lock(this)
				{
					if( _MedicineProductionLicenseRepository==null)
					{
						_MedicineProductionLicenseRepository=new MedicineProductionLicenseRepository(Db);
						_MedicineProductionLicenseRepository.RepositoryProvider = this;
					}
					return _MedicineProductionLicenseRepository;
				}
			}
		} 
		private IMedicineBusinessLicenseRepository _MedicineBusinessLicenseRepository=null;
	    /// <summary> 
		/// GSP证书(MedicineBusinessLicense) 仓储对象
        /// </summary>
		public IMedicineBusinessLicenseRepository MedicineBusinessLicenseRepository
		{
			get
			{
				lock(this)
				{
					if( _MedicineBusinessLicenseRepository==null)
					{
						_MedicineBusinessLicenseRepository=new MedicineBusinessLicenseRepository(Db);
						_MedicineBusinessLicenseRepository.RepositoryProvider = this;
					}
					return _MedicineBusinessLicenseRepository;
				}
			}
		} 
		private IInstrumentsBusinessLicenseRepository _InstrumentsBusinessLicenseRepository=null;
	    /// <summary> 
		/// 器械经营许可证(InstrumentsBusinessLicense) 仓储对象
        /// </summary>
		public IInstrumentsBusinessLicenseRepository InstrumentsBusinessLicenseRepository
		{
			get
			{
				lock(this)
				{
					if( _InstrumentsBusinessLicenseRepository==null)
					{
						_InstrumentsBusinessLicenseRepository=new InstrumentsBusinessLicenseRepository(Db);
						_InstrumentsBusinessLicenseRepository.RepositoryProvider = this;
					}
					return _InstrumentsBusinessLicenseRepository;
				}
			}
		} 
		private IInstrumentsProductionLicenseRepository _InstrumentsProductionLicenseRepository=null;
	    /// <summary> 
		/// 器械生产许可证(InstrumentsProductionLicense) 仓储对象
        /// </summary>
		public IInstrumentsProductionLicenseRepository InstrumentsProductionLicenseRepository
		{
			get
			{
				lock(this)
				{
					if( _InstrumentsProductionLicenseRepository==null)
					{
						_InstrumentsProductionLicenseRepository=new InstrumentsProductionLicenseRepository(Db);
						_InstrumentsProductionLicenseRepository.RepositoryProvider = this;
					}
					return _InstrumentsProductionLicenseRepository;
				}
			}
		} 
		private IOrganizationCodeLicenseRepository _OrganizationCodeLicenseRepository=null;
	    /// <summary> 
		/// 组织机构代码证(OrganizationCodeLicense) 仓储对象
        /// </summary>
		public IOrganizationCodeLicenseRepository OrganizationCodeLicenseRepository
		{
			get
			{
				lock(this)
				{
					if( _OrganizationCodeLicenseRepository==null)
					{
						_OrganizationCodeLicenseRepository=new OrganizationCodeLicenseRepository(Db);
						_OrganizationCodeLicenseRepository.RepositoryProvider = this;
					}
					return _OrganizationCodeLicenseRepository;
				}
			}
		} 
		private IFoodCirculateLicenseRepository _FoodCirculateLicenseRepository=null;
	    /// <summary> 
		/// 食品流通许可证(FoodCirculateLicense) 仓储对象
        /// </summary>
		public IFoodCirculateLicenseRepository FoodCirculateLicenseRepository
		{
			get
			{
				lock(this)
				{
					if( _FoodCirculateLicenseRepository==null)
					{
						_FoodCirculateLicenseRepository=new FoodCirculateLicenseRepository(Db);
						_FoodCirculateLicenseRepository.RepositoryProvider = this;
					}
					return _FoodCirculateLicenseRepository;
				}
			}
		} 
		private IHealthLicenseRepository _HealthLicenseRepository=null;
	    /// <summary> 
		/// 卫生许可证(HealthLicense) 仓储对象
        /// </summary>
		public IHealthLicenseRepository HealthLicenseRepository
		{
			get
			{
				lock(this)
				{
					if( _HealthLicenseRepository==null)
					{
						_HealthLicenseRepository=new HealthLicenseRepository(Db);
						_HealthLicenseRepository.RepositoryProvider = this;
					}
					return _HealthLicenseRepository;
				}
			}
		} 
		private ITaxRegisterLicenseRepository _TaxRegisterLicenseRepository=null;
	    /// <summary> 
		/// 税务登记证(TaxRegisterLicense) 仓储对象
        /// </summary>
		public ITaxRegisterLicenseRepository TaxRegisterLicenseRepository
		{
			get
			{
				lock(this)
				{
					if( _TaxRegisterLicenseRepository==null)
					{
						_TaxRegisterLicenseRepository=new TaxRegisterLicenseRepository(Db);
						_TaxRegisterLicenseRepository.RepositoryProvider = this;
					}
					return _TaxRegisterLicenseRepository;
				}
			}
		} 
		private ILnstitutionLegalPersonLicenseRepository _LnstitutionLegalPersonLicenseRepository=null;
	    /// <summary> 
		/// 事业单位法人证(LnstitutionLegalPersonLicense) 仓储对象
        /// </summary>
		public ILnstitutionLegalPersonLicenseRepository LnstitutionLegalPersonLicenseRepository
		{
			get
			{
				lock(this)
				{
					if( _LnstitutionLegalPersonLicenseRepository==null)
					{
						_LnstitutionLegalPersonLicenseRepository=new LnstitutionLegalPersonLicenseRepository(Db);
						_LnstitutionLegalPersonLicenseRepository.RepositoryProvider = this;
					}
					return _LnstitutionLegalPersonLicenseRepository;
				}
			}
		} 
		private IMmedicalInstitutionPermitRepository _MmedicalInstitutionPermitRepository=null;
	    /// <summary> 
		/// 医疗机构执业许可证(MmedicalInstitutionPermit) 仓储对象
        /// </summary>
		public IMmedicalInstitutionPermitRepository MmedicalInstitutionPermitRepository
		{
			get
			{
				lock(this)
				{
					if( _MmedicalInstitutionPermitRepository==null)
					{
						_MmedicalInstitutionPermitRepository=new MmedicalInstitutionPermitRepository(Db);
						_MmedicalInstitutionPermitRepository.RepositoryProvider = this;
					}
					return _MmedicalInstitutionPermitRepository;
				}
			}
		} 
		private IIndustoryProductCertificateRepository _IndustoryProductCertificateRepository=null;
	    /// <summary> 
		/// 全国工业产品生产许可证(IndustoryProductCertificate) 仓储对象
        /// </summary>
		public IIndustoryProductCertificateRepository IndustoryProductCertificateRepository
		{
			get
			{
				lock(this)
				{
					if( _IndustoryProductCertificateRepository==null)
					{
						_IndustoryProductCertificateRepository=new IndustoryProductCertificateRepository(Db);
						_IndustoryProductCertificateRepository.RepositoryProvider = this;
					}
					return _IndustoryProductCertificateRepository;
				}
			}
		} 
		private IMedicalCategoryRepository _MedicalCategoryRepository=null;
	    /// <summary> 
		/// 医疗分类(MedicalCategory) 仓储对象
        /// </summary>
		public IMedicalCategoryRepository MedicalCategoryRepository
		{
			get
			{
				lock(this)
				{
					if( _MedicalCategoryRepository==null)
					{
						_MedicalCategoryRepository=new MedicalCategoryRepository(Db);
						_MedicalCategoryRepository.RepositoryProvider = this;
					}
					return _MedicalCategoryRepository;
				}
			}
		} 
		private IMedicalCategoryDetailRepository _MedicalCategoryDetailRepository=null;
	    /// <summary> 
		/// 医疗详细分类(MedicalCategoryDetail) 仓储对象
        /// </summary>
		public IMedicalCategoryDetailRepository MedicalCategoryDetailRepository
		{
			get
			{
				lock(this)
				{
					if( _MedicalCategoryDetailRepository==null)
					{
						_MedicalCategoryDetailRepository=new MedicalCategoryDetailRepository(Db);
						_MedicalCategoryDetailRepository.RepositoryProvider = this;
					}
					return _MedicalCategoryDetailRepository;
				}
			}
		} 
		private IModuleRepository _ModuleRepository=null;
	    /// <summary> 
		/// 功能模块(Module) 仓储对象
        /// </summary>
		public IModuleRepository ModuleRepository
		{
			get
			{
				lock(this)
				{
					if( _ModuleRepository==null)
					{
						_ModuleRepository=new ModuleRepository(Db);
						_ModuleRepository.RepositoryProvider = this;
					}
					return _ModuleRepository;
				}
			}
		} 
		private IModuleCatetoryRepository _ModuleCatetoryRepository=null;
	    /// <summary> 
		/// 功能模块分类(ModuleCatetory) 仓储对象
        /// </summary>
		public IModuleCatetoryRepository ModuleCatetoryRepository
		{
			get
			{
				lock(this)
				{
					if( _ModuleCatetoryRepository==null)
					{
						_ModuleCatetoryRepository=new ModuleCatetoryRepository(Db);
						_ModuleCatetoryRepository.RepositoryProvider = this;
					}
					return _ModuleCatetoryRepository;
				}
			}
		} 
		private IModuleWithRoleRepository _ModuleWithRoleRepository=null;
	    /// <summary> 
		/// 功能模块与角色的关联(ModuleWithRole) 仓储对象
        /// </summary>
		public IModuleWithRoleRepository ModuleWithRoleRepository
		{
			get
			{
				lock(this)
				{
					if( _ModuleWithRoleRepository==null)
					{
						_ModuleWithRoleRepository=new ModuleWithRoleRepository(Db);
						_ModuleWithRoleRepository.RepositoryProvider = this;
					}
					return _ModuleWithRoleRepository;
				}
			}
		} 
		private IPharmacyFileRepository _PharmacyFileRepository=null;
	    /// <summary> 
		/// 文件(PharmacyFile) 仓储对象
        /// </summary>
		public IPharmacyFileRepository PharmacyFileRepository
		{
			get
			{
				lock(this)
				{
					if( _PharmacyFileRepository==null)
					{
						_PharmacyFileRepository=new PharmacyFileRepository(Db);
						_PharmacyFileRepository.RepositoryProvider = this;
					}
					return _PharmacyFileRepository;
				}
			}
		} 
		private IPurchaseAgreementRepository _PurchaseAgreementRepository=null;
	    /// <summary> 
		/// 采购合同(PurchaseAgreement) 仓储对象
        /// </summary>
		public IPurchaseAgreementRepository PurchaseAgreementRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseAgreementRepository==null)
					{
						_PurchaseAgreementRepository=new PurchaseAgreementRepository(Db);
						_PurchaseAgreementRepository.RepositoryProvider = this;
					}
					return _PurchaseAgreementRepository;
				}
			}
		} 
		private IPurchaseCheckingOrderRepository _PurchaseCheckingOrderRepository=null;
	    /// <summary> 
		/// 验收记录(PurchaseCheckingOrder) 仓储对象
        /// </summary>
		public IPurchaseCheckingOrderRepository PurchaseCheckingOrderRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseCheckingOrderRepository==null)
					{
						_PurchaseCheckingOrderRepository=new PurchaseCheckingOrderRepository(Db);
						_PurchaseCheckingOrderRepository.RepositoryProvider = this;
					}
					return _PurchaseCheckingOrderRepository;
				}
			}
		} 
		private IPurchaseCheckingOrderDetailRepository _PurchaseCheckingOrderDetailRepository=null;
	    /// <summary> 
		/// 采购到货验收(PurchaseCheckingOrderDetail) 仓储对象
        /// </summary>
		public IPurchaseCheckingOrderDetailRepository PurchaseCheckingOrderDetailRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseCheckingOrderDetailRepository==null)
					{
						_PurchaseCheckingOrderDetailRepository=new PurchaseCheckingOrderDetailRepository(Db);
						_PurchaseCheckingOrderDetailRepository.RepositoryProvider = this;
					}
					return _PurchaseCheckingOrderDetailRepository;
				}
			}
		} 
		private IPurchaseInInventeryOrderRepository _PurchaseInInventeryOrderRepository=null;
	    /// <summary> 
		/// 库存记录(PurchaseInInventeryOrder) 仓储对象
        /// </summary>
		public IPurchaseInInventeryOrderRepository PurchaseInInventeryOrderRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseInInventeryOrderRepository==null)
					{
						_PurchaseInInventeryOrderRepository=new PurchaseInInventeryOrderRepository(Db);
						_PurchaseInInventeryOrderRepository.RepositoryProvider = this;
					}
					return _PurchaseInInventeryOrderRepository;
				}
			}
		} 
		private IPurchaseInInventeryOrderDetailRepository _PurchaseInInventeryOrderDetailRepository=null;
	    /// <summary> 
		/// 库存记录详细(PurchaseInInventeryOrderDetail) 仓储对象
        /// </summary>
		public IPurchaseInInventeryOrderDetailRepository PurchaseInInventeryOrderDetailRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseInInventeryOrderDetailRepository==null)
					{
						_PurchaseInInventeryOrderDetailRepository=new PurchaseInInventeryOrderDetailRepository(Db);
						_PurchaseInInventeryOrderDetailRepository.RepositoryProvider = this;
					}
					return _PurchaseInInventeryOrderDetailRepository;
				}
			}
		} 
		private IPurchaseManageCategoryRepository _PurchaseManageCategoryRepository=null;
	    /// <summary> 
		/// 管理要求分类(PurchaseManageCategory) 仓储对象
        /// </summary>
		public IPurchaseManageCategoryRepository PurchaseManageCategoryRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseManageCategoryRepository==null)
					{
						_PurchaseManageCategoryRepository=new PurchaseManageCategoryRepository(Db);
						_PurchaseManageCategoryRepository.RepositoryProvider = this;
					}
					return _PurchaseManageCategoryRepository;
				}
			}
		} 
		private IPurchaseManageCategoryDetailRepository _PurchaseManageCategoryDetailRepository=null;
	    /// <summary> 
		/// 管理要求分类详细(PurchaseManageCategoryDetail) 仓储对象
        /// </summary>
		public IPurchaseManageCategoryDetailRepository PurchaseManageCategoryDetailRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseManageCategoryDetailRepository==null)
					{
						_PurchaseManageCategoryDetailRepository=new PurchaseManageCategoryDetailRepository(Db);
						_PurchaseManageCategoryDetailRepository.RepositoryProvider = this;
					}
					return _PurchaseManageCategoryDetailRepository;
				}
			}
		} 
		private IPurchaseOrderRepository _PurchaseOrderRepository=null;
	    /// <summary> 
		/// 采购单(PurchaseOrder) 仓储对象
        /// </summary>
		public IPurchaseOrderRepository PurchaseOrderRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseOrderRepository==null)
					{
						_PurchaseOrderRepository=new PurchaseOrderRepository(Db);
						_PurchaseOrderRepository.RepositoryProvider = this;
					}
					return _PurchaseOrderRepository;
				}
			}
		} 
		private IPurchaseOrderDetailRepository _PurchaseOrderDetailRepository=null;
	    /// <summary> 
		/// 采购明细(PurchaseOrderDetail) 仓储对象
        /// </summary>
		public IPurchaseOrderDetailRepository PurchaseOrderDetailRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseOrderDetailRepository==null)
					{
						_PurchaseOrderDetailRepository=new PurchaseOrderDetailRepository(Db);
						_PurchaseOrderDetailRepository.RepositoryProvider = this;
					}
					return _PurchaseOrderDetailRepository;
				}
			}
		} 
		private IPurchaseOrderReturnRepository _PurchaseOrderReturnRepository=null;
	    /// <summary> 
		/// (PurchaseOrderReturn) 仓储对象
        /// </summary>
		public IPurchaseOrderReturnRepository PurchaseOrderReturnRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseOrderReturnRepository==null)
					{
						_PurchaseOrderReturnRepository=new PurchaseOrderReturnRepository(Db);
						_PurchaseOrderReturnRepository.RepositoryProvider = this;
					}
					return _PurchaseOrderReturnRepository;
				}
			}
		} 
		private IPurchaseOrderReturnDetailRepository _PurchaseOrderReturnDetailRepository=null;
	    /// <summary> 
		/// (PurchaseOrderReturnDetail) 仓储对象
        /// </summary>
		public IPurchaseOrderReturnDetailRepository PurchaseOrderReturnDetailRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseOrderReturnDetailRepository==null)
					{
						_PurchaseOrderReturnDetailRepository=new PurchaseOrderReturnDetailRepository(Db);
						_PurchaseOrderReturnDetailRepository.RepositoryProvider = this;
					}
					return _PurchaseOrderReturnDetailRepository;
				}
			}
		} 
		private IPurchaseReceivingOrderRepository _PurchaseReceivingOrderRepository=null;
	    /// <summary> 
		/// 采购收货单(PurchaseReceivingOrder) 仓储对象
        /// </summary>
		public IPurchaseReceivingOrderRepository PurchaseReceivingOrderRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseReceivingOrderRepository==null)
					{
						_PurchaseReceivingOrderRepository=new PurchaseReceivingOrderRepository(Db);
						_PurchaseReceivingOrderRepository.RepositoryProvider = this;
					}
					return _PurchaseReceivingOrderRepository;
				}
			}
		} 
		private IPurchaseReceivingOrderDetailRepository _PurchaseReceivingOrderDetailRepository=null;
	    /// <summary> 
		/// 采购收货详细单(PurchaseReceivingOrderDetail) 仓储对象
        /// </summary>
		public IPurchaseReceivingOrderDetailRepository PurchaseReceivingOrderDetailRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseReceivingOrderDetailRepository==null)
					{
						_PurchaseReceivingOrderDetailRepository=new PurchaseReceivingOrderDetailRepository(Db);
						_PurchaseReceivingOrderDetailRepository.RepositoryProvider = this;
					}
					return _PurchaseReceivingOrderDetailRepository;
				}
			}
		} 
		private IPurchaseUnitRepository _PurchaseUnitRepository=null;
	    /// <summary> 
		/// 购货单位(PurchaseUnit) 仓储对象
        /// </summary>
		public IPurchaseUnitRepository PurchaseUnitRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseUnitRepository==null)
					{
						_PurchaseUnitRepository=new PurchaseUnitRepository(Db);
						_PurchaseUnitRepository.RepositoryProvider = this;
					}
					return _PurchaseUnitRepository;
				}
			}
		} 
		private IPurchaseUnitBuyerRepository _PurchaseUnitBuyerRepository=null;
	    /// <summary> 
		/// 购货单位采购人员(PurchaseUnitBuyer) 仓储对象
        /// </summary>
		public IPurchaseUnitBuyerRepository PurchaseUnitBuyerRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseUnitBuyerRepository==null)
					{
						_PurchaseUnitBuyerRepository=new PurchaseUnitBuyerRepository(Db);
						_PurchaseUnitBuyerRepository.RepositoryProvider = this;
					}
					return _PurchaseUnitBuyerRepository;
				}
			}
		} 
		private IPurchaseUnitDelivererRepository _PurchaseUnitDelivererRepository=null;
	    /// <summary> 
		/// 购货单位提货人员(PurchaseUnitDeliverer) 仓储对象
        /// </summary>
		public IPurchaseUnitDelivererRepository PurchaseUnitDelivererRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseUnitDelivererRepository==null)
					{
						_PurchaseUnitDelivererRepository=new PurchaseUnitDelivererRepository(Db);
						_PurchaseUnitDelivererRepository.RepositoryProvider = this;
					}
					return _PurchaseUnitDelivererRepository;
				}
			}
		} 
		private IPurchaseUnitTypeRepository _PurchaseUnitTypeRepository=null;
	    /// <summary> 
		/// 购货单位类型(PurchaseUnitType) 仓储对象
        /// </summary>
		public IPurchaseUnitTypeRepository PurchaseUnitTypeRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchaseUnitTypeRepository==null)
					{
						_PurchaseUnitTypeRepository=new PurchaseUnitTypeRepository(Db);
						_PurchaseUnitTypeRepository.RepositoryProvider = this;
					}
					return _PurchaseUnitTypeRepository;
				}
			}
		} 
		private IPurchasingPlanRepository _PurchasingPlanRepository=null;
	    /// <summary> 
		/// (PurchasingPlan) 仓储对象
        /// </summary>
		public IPurchasingPlanRepository PurchasingPlanRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchasingPlanRepository==null)
					{
						_PurchasingPlanRepository=new PurchasingPlanRepository(Db);
						_PurchasingPlanRepository.RepositoryProvider = this;
					}
					return _PurchasingPlanRepository;
				}
			}
		} 
		private IPurchasingPlanDetailRepository _PurchasingPlanDetailRepository=null;
	    /// <summary> 
		/// (PurchasingPlanDetail) 仓储对象
        /// </summary>
		public IPurchasingPlanDetailRepository PurchasingPlanDetailRepository
		{
			get
			{
				lock(this)
				{
					if( _PurchasingPlanDetailRepository==null)
					{
						_PurchasingPlanDetailRepository=new PurchasingPlanDetailRepository(Db);
						_PurchasingPlanDetailRepository.RepositoryProvider = this;
					}
					return _PurchasingPlanDetailRepository;
				}
			}
		} 
		private IRarewordRepository _RarewordRepository=null;
	    /// <summary> 
		/// 不常用字(生僻字)(Rareword) 仓储对象
        /// </summary>
		public IRarewordRepository RarewordRepository
		{
			get
			{
				lock(this)
				{
					if( _RarewordRepository==null)
					{
						_RarewordRepository=new RarewordRepository(Db);
						_RarewordRepository.RepositoryProvider = this;
					}
					return _RarewordRepository;
				}
			}
		} 
		private IRetailMemberRepository _RetailMemberRepository=null;
	    /// <summary> 
		/// 零售会员(RetailMember) 仓储对象
        /// </summary>
		public IRetailMemberRepository RetailMemberRepository
		{
			get
			{
				lock(this)
				{
					if( _RetailMemberRepository==null)
					{
						_RetailMemberRepository=new RetailMemberRepository(Db);
						_RetailMemberRepository.RepositoryProvider = this;
					}
					return _RetailMemberRepository;
				}
			}
		} 
		private IRetailOrderRepository _RetailOrderRepository=null;
	    /// <summary> 
		/// (RetailOrder) 仓储对象
        /// </summary>
		public IRetailOrderRepository RetailOrderRepository
		{
			get
			{
				lock(this)
				{
					if( _RetailOrderRepository==null)
					{
						_RetailOrderRepository=new RetailOrderRepository(Db);
						_RetailOrderRepository.RepositoryProvider = this;
					}
					return _RetailOrderRepository;
				}
			}
		} 
		private IRetailOrderDetailRepository _RetailOrderDetailRepository=null;
	    /// <summary> 
		/// 零售单明细(RetailOrderDetail) 仓储对象
        /// </summary>
		public IRetailOrderDetailRepository RetailOrderDetailRepository
		{
			get
			{
				lock(this)
				{
					if( _RetailOrderDetailRepository==null)
					{
						_RetailOrderDetailRepository=new RetailOrderDetailRepository(Db);
						_RetailOrderDetailRepository.RepositoryProvider = this;
					}
					return _RetailOrderDetailRepository;
				}
			}
		} 
		private IRoleRepository _RoleRepository=null;
	    /// <summary> 
		/// 系统角色(Role) 仓储对象
        /// </summary>
		public IRoleRepository RoleRepository
		{
			get
			{
				lock(this)
				{
					if( _RoleRepository==null)
					{
						_RoleRepository=new RoleRepository(Db);
						_RoleRepository.RepositoryProvider = this;
					}
					return _RoleRepository;
				}
			}
		} 
		private IRoleWithUserRepository _RoleWithUserRepository=null;
	    /// <summary> 
		/// 角色与用户的关联(RoleWithUser) 仓储对象
        /// </summary>
		public IRoleWithUserRepository RoleWithUserRepository
		{
			get
			{
				lock(this)
				{
					if( _RoleWithUserRepository==null)
					{
						_RoleWithUserRepository=new RoleWithUserRepository(Db);
						_RoleWithUserRepository.RepositoryProvider = this;
					}
					return _RoleWithUserRepository;
				}
			}
		} 
		private ISalesOrderRepository _SalesOrderRepository=null;
	    /// <summary> 
		/// 销售单(SalesOrder) 仓储对象
        /// </summary>
		public ISalesOrderRepository SalesOrderRepository
		{
			get
			{
				lock(this)
				{
					if( _SalesOrderRepository==null)
					{
						_SalesOrderRepository=new SalesOrderRepository(Db);
						_SalesOrderRepository.RepositoryProvider = this;
					}
					return _SalesOrderRepository;
				}
			}
		} 
		private ISalesOrderDeliverDetailRepository _SalesOrderDeliverDetailRepository=null;
	    /// <summary> 
		/// (SalesOrderDeliverDetail) 仓储对象
        /// </summary>
		public ISalesOrderDeliverDetailRepository SalesOrderDeliverDetailRepository
		{
			get
			{
				lock(this)
				{
					if( _SalesOrderDeliverDetailRepository==null)
					{
						_SalesOrderDeliverDetailRepository=new SalesOrderDeliverDetailRepository(Db);
						_SalesOrderDeliverDetailRepository.RepositoryProvider = this;
					}
					return _SalesOrderDeliverDetailRepository;
				}
			}
		} 
		private ISalesOrderDeliverRecordRepository _SalesOrderDeliverRecordRepository=null;
	    /// <summary> 
		/// 销售发货记录(SalesOrderDeliverRecord) 仓储对象
        /// </summary>
		public ISalesOrderDeliverRecordRepository SalesOrderDeliverRecordRepository
		{
			get
			{
				lock(this)
				{
					if( _SalesOrderDeliverRecordRepository==null)
					{
						_SalesOrderDeliverRecordRepository=new SalesOrderDeliverRecordRepository(Db);
						_SalesOrderDeliverRecordRepository.RepositoryProvider = this;
					}
					return _SalesOrderDeliverRecordRepository;
				}
			}
		} 
		private ISalesOrderDetailRepository _SalesOrderDetailRepository=null;
	    /// <summary> 
		/// 销售单明细(SalesOrderDetail) 仓储对象
        /// </summary>
		public ISalesOrderDetailRepository SalesOrderDetailRepository
		{
			get
			{
				lock(this)
				{
					if( _SalesOrderDetailRepository==null)
					{
						_SalesOrderDetailRepository=new SalesOrderDetailRepository(Db);
						_SalesOrderDetailRepository.RepositoryProvider = this;
					}
					return _SalesOrderDetailRepository;
				}
			}
		} 
		private ISalesOrderReturnRepository _SalesOrderReturnRepository=null;
	    /// <summary> 
		/// (SalesOrderReturn) 仓储对象
        /// </summary>
		public ISalesOrderReturnRepository SalesOrderReturnRepository
		{
			get
			{
				lock(this)
				{
					if( _SalesOrderReturnRepository==null)
					{
						_SalesOrderReturnRepository=new SalesOrderReturnRepository(Db);
						_SalesOrderReturnRepository.RepositoryProvider = this;
					}
					return _SalesOrderReturnRepository;
				}
			}
		} 
		private ISalesOrderReturnDetailRepository _SalesOrderReturnDetailRepository=null;
	    /// <summary> 
		/// (SalesOrderReturnDetail) 仓储对象
        /// </summary>
		public ISalesOrderReturnDetailRepository SalesOrderReturnDetailRepository
		{
			get
			{
				lock(this)
				{
					if( _SalesOrderReturnDetailRepository==null)
					{
						_SalesOrderReturnDetailRepository=new SalesOrderReturnDetailRepository(Db);
						_SalesOrderReturnDetailRepository.RepositoryProvider = this;
					}
					return _SalesOrderReturnDetailRepository;
				}
			}
		} 
		private IOutInventoryRepository _OutInventoryRepository=null;
	    /// <summary> 
		/// 销售出库单(OutInventory) 仓储对象
        /// </summary>
		public IOutInventoryRepository OutInventoryRepository
		{
			get
			{
				lock(this)
				{
					if( _OutInventoryRepository==null)
					{
						_OutInventoryRepository=new OutInventoryRepository(Db);
						_OutInventoryRepository.RepositoryProvider = this;
					}
					return _OutInventoryRepository;
				}
			}
		} 
		private ISetSpeicalDrugRecordRepository _SetSpeicalDrugRecordRepository=null;
	    /// <summary> 
		/// 设置重点药品记录表(SetSpeicalDrugRecord) 仓储对象
        /// </summary>
		public ISetSpeicalDrugRecordRepository SetSpeicalDrugRecordRepository
		{
			get
			{
				lock(this)
				{
					if( _SetSpeicalDrugRecordRepository==null)
					{
						_SetSpeicalDrugRecordRepository=new SetSpeicalDrugRecordRepository(Db);
						_SetSpeicalDrugRecordRepository.RepositoryProvider = this;
					}
					return _SetSpeicalDrugRecordRepository;
				}
			}
		} 
		private ISpecialDrugCategoryRepository _SpecialDrugCategoryRepository=null;
	    /// <summary> 
		/// 特殊管理药物类型(SpecialDrugCategory) 仓储对象
        /// </summary>
		public ISpecialDrugCategoryRepository SpecialDrugCategoryRepository
		{
			get
			{
				lock(this)
				{
					if( _SpecialDrugCategoryRepository==null)
					{
						_SpecialDrugCategoryRepository=new SpecialDrugCategoryRepository(Db);
						_SpecialDrugCategoryRepository.RepositoryProvider = this;
					}
					return _SpecialDrugCategoryRepository;
				}
			}
		} 
		private IStoreRepository _StoreRepository=null;
	    /// <summary> 
		/// 门店(Store) 仓储对象
        /// </summary>
		public IStoreRepository StoreRepository
		{
			get
			{
				lock(this)
				{
					if( _StoreRepository==null)
					{
						_StoreRepository=new StoreRepository(Db);
						_StoreRepository.RepositoryProvider = this;
					}
					return _StoreRepository;
				}
			}
		} 
		private ISupplyPersonRepository _SupplyPersonRepository=null;
	    /// <summary> 
		/// 首营药材供货人管理(SupplyPerson) 仓储对象
        /// </summary>
		public ISupplyPersonRepository SupplyPersonRepository
		{
			get
			{
				lock(this)
				{
					if( _SupplyPersonRepository==null)
					{
						_SupplyPersonRepository=new SupplyPersonRepository(Db);
						_SupplyPersonRepository.RepositoryProvider = this;
					}
					return _SupplyPersonRepository;
				}
			}
		} 
		private ISupplyUnitRepository _SupplyUnitRepository=null;
	    /// <summary> 
		/// 供货单位(SupplyUnit) 仓储对象
        /// </summary>
		public ISupplyUnitRepository SupplyUnitRepository
		{
			get
			{
				lock(this)
				{
					if( _SupplyUnitRepository==null)
					{
						_SupplyUnitRepository=new SupplyUnitRepository(Db);
						_SupplyUnitRepository.RepositoryProvider = this;
					}
					return _SupplyUnitRepository;
				}
			}
		} 
		private ISupplyUnitSalesmanRepository _SupplyUnitSalesmanRepository=null;
	    /// <summary> 
		/// 供货商销售人员(SupplyUnitSalesman) 仓储对象
        /// </summary>
		public ISupplyUnitSalesmanRepository SupplyUnitSalesmanRepository
		{
			get
			{
				lock(this)
				{
					if( _SupplyUnitSalesmanRepository==null)
					{
						_SupplyUnitSalesmanRepository=new SupplyUnitSalesmanRepository(Db);
						_SupplyUnitSalesmanRepository.RepositoryProvider = this;
					}
					return _SupplyUnitSalesmanRepository;
				}
			}
		} 
		private ITaxRateRepository _TaxRateRepository=null;
	    /// <summary> 
		/// 税率(TaxRate) 仓储对象
        /// </summary>
		public ITaxRateRepository TaxRateRepository
		{
			get
			{
				lock(this)
				{
					if( _TaxRateRepository==null)
					{
						_TaxRateRepository=new TaxRateRepository(Db);
						_TaxRateRepository.RepositoryProvider = this;
					}
					return _TaxRateRepository;
				}
			}
		} 
		private IUnitTypeRepository _UnitTypeRepository=null;
	    /// <summary> 
		/// 企业类型(UnitType) 仓储对象
        /// </summary>
		public IUnitTypeRepository UnitTypeRepository
		{
			get
			{
				lock(this)
				{
					if( _UnitTypeRepository==null)
					{
						_UnitTypeRepository=new UnitTypeRepository(Db);
						_UnitTypeRepository.RepositoryProvider = this;
					}
					return _UnitTypeRepository;
				}
			}
		} 
		private IUploadRecordRepository _UploadRecordRepository=null;
	    /// <summary> 
		/// 数据上传记录(UploadRecord) 仓储对象
        /// </summary>
		public IUploadRecordRepository UploadRecordRepository
		{
			get
			{
				lock(this)
				{
					if( _UploadRecordRepository==null)
					{
						_UploadRecordRepository=new UploadRecordRepository(Db);
						_UploadRecordRepository.RepositoryProvider = this;
					}
					return _UploadRecordRepository;
				}
			}
		} 
		private IUserRepository _UserRepository=null;
	    /// <summary> 
		/// 系统用户(User) 仓储对象
        /// </summary>
		public IUserRepository UserRepository
		{
			get
			{
				lock(this)
				{
					if( _UserRepository==null)
					{
						_UserRepository=new UserRepository(Db);
						_UserRepository.RepositoryProvider = this;
					}
					return _UserRepository;
				}
			}
		} 
		private IUserLogRepository _UserLogRepository=null;
	    /// <summary> 
		/// 用户日志(UserLog) 仓储对象
        /// </summary>
		public IUserLogRepository UserLogRepository
		{
			get
			{
				lock(this)
				{
					if( _UserLogRepository==null)
					{
						_UserLogRepository=new UserLogRepository(Db);
						_UserLogRepository.RepositoryProvider = this;
					}
					return _UserLogRepository;
				}
			}
		} 
		private IVehicleRepository _VehicleRepository=null;
	    /// <summary> 
		/// 车辆(Vehicle) 仓储对象
        /// </summary>
		public IVehicleRepository VehicleRepository
		{
			get
			{
				lock(this)
				{
					if( _VehicleRepository==null)
					{
						_VehicleRepository=new VehicleRepository(Db);
						_VehicleRepository.RepositoryProvider = this;
					}
					return _VehicleRepository;
				}
			}
		} 
		private IWarehouseRepository _WarehouseRepository=null;
	    /// <summary> 
		/// 仓库(Warehouse) 仓储对象
        /// </summary>
		public IWarehouseRepository WarehouseRepository
		{
			get
			{
				lock(this)
				{
					if( _WarehouseRepository==null)
					{
						_WarehouseRepository=new WarehouseRepository(Db);
						_WarehouseRepository.RepositoryProvider = this;
					}
					return _WarehouseRepository;
				}
			}
		} 
		private IWarehouseZoneRepository _WarehouseZoneRepository=null;
	    /// <summary> 
		/// 库区(WarehouseZone) 仓储对象
        /// </summary>
		public IWarehouseZoneRepository WarehouseZoneRepository
		{
			get
			{
				lock(this)
				{
					if( _WarehouseZoneRepository==null)
					{
						_WarehouseZoneRepository=new WarehouseZoneRepository(Db);
						_WarehouseZoneRepository.RepositoryProvider = this;
					}
					return _WarehouseZoneRepository;
				}
			}
		} 
		private IWareHouseZonePositionRepository _WareHouseZonePositionRepository=null;
	    /// <summary> 
		/// (WareHouseZonePosition) 仓储对象
        /// </summary>
		public IWareHouseZonePositionRepository WareHouseZonePositionRepository
		{
			get
			{
				lock(this)
				{
					if( _WareHouseZonePositionRepository==null)
					{
						_WareHouseZonePositionRepository=new WareHouseZonePositionRepository(Db);
						_WareHouseZonePositionRepository.RepositoryProvider = this;
					}
					return _WareHouseZonePositionRepository;
				}
			}
		} 
		private IWaringSetRepository _WaringSetRepository=null;
	    /// <summary> 
		/// 报警设置(WaringSet) 仓储对象
        /// </summary>
		public IWaringSetRepository WaringSetRepository
		{
			get
			{
				lock(this)
				{
					if( _WaringSetRepository==null)
					{
						_WaringSetRepository=new WaringSetRepository(Db);
						_WaringSetRepository.RepositoryProvider = this;
					}
					return _WaringSetRepository;
				}
			}
		} 
		private IOutInventoryDetailRepository _OutInventoryDetailRepository=null;
	    /// <summary> 
		/// 销售出库单(OutInventoryDetail) 仓储对象
        /// </summary>
		public IOutInventoryDetailRepository OutInventoryDetailRepository
		{
			get
			{
				lock(this)
				{
					if( _OutInventoryDetailRepository==null)
					{
						_OutInventoryDetailRepository=new OutInventoryDetailRepository(Db);
						_OutInventoryDetailRepository.RepositoryProvider = this;
					}
					return _OutInventoryDetailRepository;
				}
			}
		} 
		   
		public void Dispose()
		{ 
			 
			if( _ApprovalFlowRepository!=null)
			{
				_ApprovalFlowRepository.Dispose();
			}  
			if( _ApprovalFlowNodeRepository!=null)
			{
				_ApprovalFlowNodeRepository.Dispose();
			}  
			if( _ApprovalFlowTypeRepository!=null)
			{
				_ApprovalFlowTypeRepository.Dispose();
			}  
			if( _ApprovalFlowRecordRepository!=null)
			{
				_ApprovalFlowRecordRepository.Dispose();
			}  
			if( _BillDocumentCodeRepository!=null)
			{
				_BillDocumentCodeRepository.Dispose();
			}  
			if( _BusinessScopeRepository!=null)
			{
				_BusinessScopeRepository.Dispose();
			}  
			if( _BusinessScopeCategoryRepository!=null)
			{
				_BusinessScopeCategoryRepository.Dispose();
			}  
			if( _BusinessTypeRepository!=null)
			{
				_BusinessTypeRepository.Dispose();
			}  
			if( _BusinessTypeManageCategoryDetailRepository!=null)
			{
				_BusinessTypeManageCategoryDetailRepository.Dispose();
			}  
			if( _ChinaDistrictRepository!=null)
			{
				_ChinaDistrictRepository.Dispose();
			}  
			if( _DirectSalesOrderRepository!=null)
			{
				_DirectSalesOrderRepository.Dispose();
			}  
			if( _DirectSalesOrderDetailRepository!=null)
			{
				_DirectSalesOrderDetailRepository.Dispose();
			}  
			if( _DocumentRefuseRepository!=null)
			{
				_DocumentRefuseRepository.Dispose();
			}  
			if( _DrugInventoryRecordHisRepository!=null)
			{
				_DrugInventoryRecordHisRepository.Dispose();
			}  
			if( _DrugMaintenanceRecordRepository!=null)
			{
				_DrugMaintenanceRecordRepository.Dispose();
			}  
			if( _DrugsBreakageRepository!=null)
			{
				_DrugsBreakageRepository.Dispose();
			}  
			if( _DrugsInventoryMoveRepository!=null)
			{
				_DrugsInventoryMoveRepository.Dispose();
			}  
			if( _DrugsUndeterminateRepository!=null)
			{
				_DrugsUndeterminateRepository.Dispose();
			}  
			if( _drugsUnqualicationRepository!=null)
			{
				_drugsUnqualicationRepository.Dispose();
			}  
			if( _DrugsUnqualificationDestroyRepository!=null)
			{
				_DrugsUnqualificationDestroyRepository.Dispose();
			}  
			if( _EduDetailsRepository!=null)
			{
				_EduDetailsRepository.Dispose();
			}  
			if( _EduDocumentRepository!=null)
			{
				_EduDocumentRepository.Dispose();
			}  
			if( _GoodsAdditionalPropertyRepository!=null)
			{
				_GoodsAdditionalPropertyRepository.Dispose();
			}  
			if( _HealthCheckDetailRepository!=null)
			{
				_HealthCheckDetailRepository.Dispose();
			}  
			if( _HealthCheckDocumentRepository!=null)
			{
				_HealthCheckDocumentRepository.Dispose();
			}  
			if( _PurchaseCashOrderRepository!=null)
			{
				_PurchaseCashOrderRepository.Dispose();
			}  
			if( _DeliveryRepository!=null)
			{
				_DeliveryRepository.Dispose();
			}  
			if( _DepartmentRepository!=null)
			{
				_DepartmentRepository.Dispose();
			}  
			if( _DistrictRepository!=null)
			{
				_DistrictRepository.Dispose();
			}  
			if( _DoubtDrugRepository!=null)
			{
				_DoubtDrugRepository.Dispose();
			}  
			if( _DrugApprovalNumberRepository!=null)
			{
				_DrugApprovalNumberRepository.Dispose();
			}  
			if( _DrugCategoryRepository!=null)
			{
				_DrugCategoryRepository.Dispose();
			}  
			if( _DrugClinicalCategoryRepository!=null)
			{
				_DrugClinicalCategoryRepository.Dispose();
			}  
			if( _DictionaryDosageRepository!=null)
			{
				_DictionaryDosageRepository.Dispose();
			}  
			if( _DrugInfoRepository!=null)
			{
				_DrugInfoRepository.Dispose();
			}  
			if( _DrugInventoryRecordRepository!=null)
			{
				_DrugInventoryRecordRepository.Dispose();
			}  
			if( _DrugMaintainRecordRepository!=null)
			{
				_DrugMaintainRecordRepository.Dispose();
			}  
			if( _DrugMaintainRecordDetailRepository!=null)
			{
				_DrugMaintainRecordDetailRepository.Dispose();
			}  
			if( _DictionaryMeasurementUnitRepository!=null)
			{
				_DictionaryMeasurementUnitRepository.Dispose();
			}  
			if( _DictionaryPiecemealUnitRepository!=null)
			{
				_DictionaryPiecemealUnitRepository.Dispose();
			}  
			if( _DictionarySpecificationRepository!=null)
			{
				_DictionarySpecificationRepository.Dispose();
			}  
			if( _DictionaryStorageTypeRepository!=null)
			{
				_DictionaryStorageTypeRepository.Dispose();
			}  
			if( _DictionaryUserDefinedTypeRepository!=null)
			{
				_DictionaryUserDefinedTypeRepository.Dispose();
			}  
			if( _AuthorizationDocRepository!=null)
			{
				_AuthorizationDocRepository.Dispose();
			}  
			if( _DrugMaintainSetRepository!=null)
			{
				_DrugMaintainSetRepository.Dispose();
			}  
			if( _EmployeeRepository!=null)
			{
				_EmployeeRepository.Dispose();
			}  
			if( _GMSPLicenseBusinessScopeRepository!=null)
			{
				_GMSPLicenseBusinessScopeRepository.Dispose();
			}  
			if( _InventoryRecordRepository!=null)
			{
				_InventoryRecordRepository.Dispose();
			}  
			if( _ManufacturerRepository!=null)
			{
				_ManufacturerRepository.Dispose();
			}  
			if( _PackagingMaterialRepository!=null)
			{
				_PackagingMaterialRepository.Dispose();
			}  
			if( _PackagingUnitRepository!=null)
			{
				_PackagingUnitRepository.Dispose();
			}  
			if( _PaymentMethodRepository!=null)
			{
				_PaymentMethodRepository.Dispose();
			}  
			if( _GSPLicenseRepository!=null)
			{
				_GSPLicenseRepository.Dispose();
			}  
			if( _GMPLicenseRepository!=null)
			{
				_GMPLicenseRepository.Dispose();
			}  
			if( _BusinessLicenseRepository!=null)
			{
				_BusinessLicenseRepository.Dispose();
			}  
			if( _MedicineProductionLicenseRepository!=null)
			{
				_MedicineProductionLicenseRepository.Dispose();
			}  
			if( _MedicineBusinessLicenseRepository!=null)
			{
				_MedicineBusinessLicenseRepository.Dispose();
			}  
			if( _InstrumentsBusinessLicenseRepository!=null)
			{
				_InstrumentsBusinessLicenseRepository.Dispose();
			}  
			if( _InstrumentsProductionLicenseRepository!=null)
			{
				_InstrumentsProductionLicenseRepository.Dispose();
			}  
			if( _OrganizationCodeLicenseRepository!=null)
			{
				_OrganizationCodeLicenseRepository.Dispose();
			}  
			if( _FoodCirculateLicenseRepository!=null)
			{
				_FoodCirculateLicenseRepository.Dispose();
			}  
			if( _HealthLicenseRepository!=null)
			{
				_HealthLicenseRepository.Dispose();
			}  
			if( _TaxRegisterLicenseRepository!=null)
			{
				_TaxRegisterLicenseRepository.Dispose();
			}  
			if( _LnstitutionLegalPersonLicenseRepository!=null)
			{
				_LnstitutionLegalPersonLicenseRepository.Dispose();
			}  
			if( _MmedicalInstitutionPermitRepository!=null)
			{
				_MmedicalInstitutionPermitRepository.Dispose();
			}  
			if( _IndustoryProductCertificateRepository!=null)
			{
				_IndustoryProductCertificateRepository.Dispose();
			}  
			if( _MedicalCategoryRepository!=null)
			{
				_MedicalCategoryRepository.Dispose();
			}  
			if( _MedicalCategoryDetailRepository!=null)
			{
				_MedicalCategoryDetailRepository.Dispose();
			}  
			if( _ModuleRepository!=null)
			{
				_ModuleRepository.Dispose();
			}  
			if( _ModuleCatetoryRepository!=null)
			{
				_ModuleCatetoryRepository.Dispose();
			}  
			if( _ModuleWithRoleRepository!=null)
			{
				_ModuleWithRoleRepository.Dispose();
			}  
			if( _PharmacyFileRepository!=null)
			{
				_PharmacyFileRepository.Dispose();
			}  
			if( _PurchaseAgreementRepository!=null)
			{
				_PurchaseAgreementRepository.Dispose();
			}  
			if( _PurchaseCheckingOrderRepository!=null)
			{
				_PurchaseCheckingOrderRepository.Dispose();
			}  
			if( _PurchaseCheckingOrderDetailRepository!=null)
			{
				_PurchaseCheckingOrderDetailRepository.Dispose();
			}  
			if( _PurchaseInInventeryOrderRepository!=null)
			{
				_PurchaseInInventeryOrderRepository.Dispose();
			}  
			if( _PurchaseInInventeryOrderDetailRepository!=null)
			{
				_PurchaseInInventeryOrderDetailRepository.Dispose();
			}  
			if( _PurchaseManageCategoryRepository!=null)
			{
				_PurchaseManageCategoryRepository.Dispose();
			}  
			if( _PurchaseManageCategoryDetailRepository!=null)
			{
				_PurchaseManageCategoryDetailRepository.Dispose();
			}  
			if( _PurchaseOrderRepository!=null)
			{
				_PurchaseOrderRepository.Dispose();
			}  
			if( _PurchaseOrderDetailRepository!=null)
			{
				_PurchaseOrderDetailRepository.Dispose();
			}  
			if( _PurchaseOrderReturnRepository!=null)
			{
				_PurchaseOrderReturnRepository.Dispose();
			}  
			if( _PurchaseOrderReturnDetailRepository!=null)
			{
				_PurchaseOrderReturnDetailRepository.Dispose();
			}  
			if( _PurchaseReceivingOrderRepository!=null)
			{
				_PurchaseReceivingOrderRepository.Dispose();
			}  
			if( _PurchaseReceivingOrderDetailRepository!=null)
			{
				_PurchaseReceivingOrderDetailRepository.Dispose();
			}  
			if( _PurchaseUnitRepository!=null)
			{
				_PurchaseUnitRepository.Dispose();
			}  
			if( _PurchaseUnitBuyerRepository!=null)
			{
				_PurchaseUnitBuyerRepository.Dispose();
			}  
			if( _PurchaseUnitDelivererRepository!=null)
			{
				_PurchaseUnitDelivererRepository.Dispose();
			}  
			if( _PurchaseUnitTypeRepository!=null)
			{
				_PurchaseUnitTypeRepository.Dispose();
			}  
			if( _PurchasingPlanRepository!=null)
			{
				_PurchasingPlanRepository.Dispose();
			}  
			if( _PurchasingPlanDetailRepository!=null)
			{
				_PurchasingPlanDetailRepository.Dispose();
			}  
			if( _RarewordRepository!=null)
			{
				_RarewordRepository.Dispose();
			}  
			if( _RetailMemberRepository!=null)
			{
				_RetailMemberRepository.Dispose();
			}  
			if( _RetailOrderRepository!=null)
			{
				_RetailOrderRepository.Dispose();
			}  
			if( _RetailOrderDetailRepository!=null)
			{
				_RetailOrderDetailRepository.Dispose();
			}  
			if( _RoleRepository!=null)
			{
				_RoleRepository.Dispose();
			}  
			if( _RoleWithUserRepository!=null)
			{
				_RoleWithUserRepository.Dispose();
			}  
			if( _SalesOrderRepository!=null)
			{
				_SalesOrderRepository.Dispose();
			}  
			if( _SalesOrderDeliverDetailRepository!=null)
			{
				_SalesOrderDeliverDetailRepository.Dispose();
			}  
			if( _SalesOrderDeliverRecordRepository!=null)
			{
				_SalesOrderDeliverRecordRepository.Dispose();
			}  
			if( _SalesOrderDetailRepository!=null)
			{
				_SalesOrderDetailRepository.Dispose();
			}  
			if( _SalesOrderReturnRepository!=null)
			{
				_SalesOrderReturnRepository.Dispose();
			}  
			if( _SalesOrderReturnDetailRepository!=null)
			{
				_SalesOrderReturnDetailRepository.Dispose();
			}  
			if( _OutInventoryRepository!=null)
			{
				_OutInventoryRepository.Dispose();
			}  
			if( _SetSpeicalDrugRecordRepository!=null)
			{
				_SetSpeicalDrugRecordRepository.Dispose();
			}  
			if( _SpecialDrugCategoryRepository!=null)
			{
				_SpecialDrugCategoryRepository.Dispose();
			}  
			if( _StoreRepository!=null)
			{
				_StoreRepository.Dispose();
			}  
			if( _SupplyPersonRepository!=null)
			{
				_SupplyPersonRepository.Dispose();
			}  
			if( _SupplyUnitRepository!=null)
			{
				_SupplyUnitRepository.Dispose();
			}  
			if( _SupplyUnitSalesmanRepository!=null)
			{
				_SupplyUnitSalesmanRepository.Dispose();
			}  
			if( _TaxRateRepository!=null)
			{
				_TaxRateRepository.Dispose();
			}  
			if( _UnitTypeRepository!=null)
			{
				_UnitTypeRepository.Dispose();
			}  
			if( _UploadRecordRepository!=null)
			{
				_UploadRecordRepository.Dispose();
			}  
			if( _UserRepository!=null)
			{
				_UserRepository.Dispose();
			}  
			if( _UserLogRepository!=null)
			{
				_UserLogRepository.Dispose();
			}  
			if( _VehicleRepository!=null)
			{
				_VehicleRepository.Dispose();
			}  
			if( _WarehouseRepository!=null)
			{
				_WarehouseRepository.Dispose();
			}  
			if( _WarehouseZoneRepository!=null)
			{
				_WarehouseZoneRepository.Dispose();
			}  
			if( _WareHouseZonePositionRepository!=null)
			{
				_WareHouseZonePositionRepository.Dispose();
			}  
			if( _WaringSetRepository!=null)
			{
				_WaringSetRepository.Dispose();
			}  
			if( _OutInventoryDetailRepository!=null)
			{
				_OutInventoryDetailRepository.Dispose();
			}   
			
		}
	}
}
