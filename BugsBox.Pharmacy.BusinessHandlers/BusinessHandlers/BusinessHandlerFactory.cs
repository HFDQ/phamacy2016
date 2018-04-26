
 
 
 
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Repository;
namespace BugsBox.Pharmacy.BusinessHandlers
{
	//此代码由ServiceContext.Handlers.tt自动生成 
   public class BusinessHandlerFactory:IDisposable
    {
		public RepositoryProvider RepositoryProvider {get;private set;}
        public IConnectedInfoProvider ConnectedInfoProvider {get;private set;}

		  protected static readonly HashSet<BusinessHandlerFactory>  BusinessHandlerFactoryCache=
            new HashSet<BusinessHandlerFactory>();

        /// <summary>
        /// 此方法由用户退出后调用
        /// </summary>
        /// <param name="businessHandlerFactory"></param>
        public static void DisposeBusinessHandlerFactory(BusinessHandlerFactory businessHandlerFactory)
        {
            try
            {
                lock (BusinessHandlerFactoryCache)
                {
                    if (businessHandlerFactory != null)
                    {
                        if (BusinessHandlerFactoryCache.Contains(businessHandlerFactory))
                        {
                            BusinessHandlerFactoryCache.Remove(businessHandlerFactory);
                        }
                        businessHandlerFactory.Dispose();
                    }
                    else
                    {
                        LoggerHelper.Instance.Warning("DisposeBusinessHandlerFactory BusinessHandlerFactory 不可为null");
                    }
                }
               
            }
            catch (Exception ex)
            {
                ex = new Exception("销毁businessHandlerFactory失败", ex);
                LoggerHelper.Instance.Error(ex);
            }
            
        }
        
        /// <summary>
        /// 此方法由程序退出之前或服务停止后调用
        /// </summary>
        public static void DisposeBusinessHandlerFactories()
        {
            try
            {
               // LoggerHelper.Instance.Information("开始销毁所有BusinessHandlerFactories");
                foreach (var businessHandlerFactory in BusinessHandlerFactoryCache)
                {
                    DisposeBusinessHandlerFactory(businessHandlerFactory);
                }
               // LoggerHelper.Instance.Information("结束销毁所有BusinessHandlerFactories");
            }
            catch (Exception ex)
            {
                ex = new Exception("DisposeBusinessHandlerFactories失败", ex);
                LoggerHelper.Instance.Error(ex);
                LoggerHelper.Instance.Information("销毁所有BusinessHandlerFactories出错");
            }
        }

		public BusinessHandlerFactory(Db db,IConnectedInfoProvider connectedInfoProvider)
	    {
            this.RepositoryProvider = new RepositoryProvider(db);
            this.ConnectedInfoProvider = connectedInfoProvider;
			//LoggerHelper.Instance.Warning("BusinessHandlerFactory 创建了");
	    }
	  
	    private ApprovalFlowBusinessHandler _ApprovalFlowBusinessHandler=null;
		/// <summary> 
		/// 审批结点(ApprovalFlow)对象
        /// </summary>
		public ApprovalFlowBusinessHandler ApprovalFlowBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_ApprovalFlowBusinessHandler==null)
					{
						_ApprovalFlowBusinessHandler=new ApprovalFlowBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_ApprovalFlowBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _ApprovalFlowBusinessHandler;
			}
		}
      
	    private ApprovalFlowNodeBusinessHandler _ApprovalFlowNodeBusinessHandler=null;
		/// <summary> 
		/// 审批结点(ApprovalFlowNode)对象
        /// </summary>
		public ApprovalFlowNodeBusinessHandler ApprovalFlowNodeBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_ApprovalFlowNodeBusinessHandler==null)
					{
						_ApprovalFlowNodeBusinessHandler=new ApprovalFlowNodeBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_ApprovalFlowNodeBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _ApprovalFlowNodeBusinessHandler;
			}
		}
      
	    private ApprovalFlowTypeBusinessHandler _ApprovalFlowTypeBusinessHandler=null;
		/// <summary> 
		/// 审批流程类型(ApprovalFlowType)对象
        /// </summary>
		public ApprovalFlowTypeBusinessHandler ApprovalFlowTypeBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_ApprovalFlowTypeBusinessHandler==null)
					{
						_ApprovalFlowTypeBusinessHandler=new ApprovalFlowTypeBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_ApprovalFlowTypeBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _ApprovalFlowTypeBusinessHandler;
			}
		}
      
	    private ApprovalFlowRecordBusinessHandler _ApprovalFlowRecordBusinessHandler=null;
		/// <summary> 
		/// 审批流程记录(ApprovalFlowRecord)对象
        /// </summary>
		public ApprovalFlowRecordBusinessHandler ApprovalFlowRecordBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_ApprovalFlowRecordBusinessHandler==null)
					{
						_ApprovalFlowRecordBusinessHandler=new ApprovalFlowRecordBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_ApprovalFlowRecordBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _ApprovalFlowRecordBusinessHandler;
			}
		}
      
	    private BillDocumentCodeBusinessHandler _BillDocumentCodeBusinessHandler=null;
		/// <summary> 
		/// 单据编号(BillDocumentCode)对象
        /// </summary>
		public BillDocumentCodeBusinessHandler BillDocumentCodeBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_BillDocumentCodeBusinessHandler==null)
					{
						_BillDocumentCodeBusinessHandler=new BillDocumentCodeBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_BillDocumentCodeBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _BillDocumentCodeBusinessHandler;
			}
		}
      
	    private BusinessScopeBusinessHandler _BusinessScopeBusinessHandler=null;
		/// <summary> 
		/// 经营范围(BusinessScope)对象
        /// </summary>
		public BusinessScopeBusinessHandler BusinessScopeBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_BusinessScopeBusinessHandler==null)
					{
						_BusinessScopeBusinessHandler=new BusinessScopeBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_BusinessScopeBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _BusinessScopeBusinessHandler;
			}
		}
      
	    private BusinessScopeCategoryBusinessHandler _BusinessScopeCategoryBusinessHandler=null;
		/// <summary> 
		/// 经营范围分类(BusinessScopeCategory)对象
        /// </summary>
		public BusinessScopeCategoryBusinessHandler BusinessScopeCategoryBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_BusinessScopeCategoryBusinessHandler==null)
					{
						_BusinessScopeCategoryBusinessHandler=new BusinessScopeCategoryBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_BusinessScopeCategoryBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _BusinessScopeCategoryBusinessHandler;
			}
		}
      
	    private BusinessTypeBusinessHandler _BusinessTypeBusinessHandler=null;
		/// <summary> 
		/// 经营方式(BusinessType)对象
        /// </summary>
		public BusinessTypeBusinessHandler BusinessTypeBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_BusinessTypeBusinessHandler==null)
					{
						_BusinessTypeBusinessHandler=new BusinessTypeBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_BusinessTypeBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _BusinessTypeBusinessHandler;
			}
		}
      
	    private BusinessTypeManageCategoryDetailBusinessHandler _BusinessTypeManageCategoryDetailBusinessHandler=null;
		/// <summary> 
		/// 经营方式的管理要求分类详细(BusinessTypeManageCategoryDetail)对象
        /// </summary>
		public BusinessTypeManageCategoryDetailBusinessHandler BusinessTypeManageCategoryDetailBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_BusinessTypeManageCategoryDetailBusinessHandler==null)
					{
						_BusinessTypeManageCategoryDetailBusinessHandler=new BusinessTypeManageCategoryDetailBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_BusinessTypeManageCategoryDetailBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _BusinessTypeManageCategoryDetailBusinessHandler;
			}
		}
      
	    private GoodsAdditionalPropertyBusinessHandler _GoodsAdditionalPropertyBusinessHandler=null;
		/// <summary> 
		/// 商品附加属性(GoodsAdditionalProperty)对象
        /// </summary>
		public GoodsAdditionalPropertyBusinessHandler GoodsAdditionalPropertyBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_GoodsAdditionalPropertyBusinessHandler==null)
					{
						_GoodsAdditionalPropertyBusinessHandler=new GoodsAdditionalPropertyBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_GoodsAdditionalPropertyBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _GoodsAdditionalPropertyBusinessHandler;
			}
		}
      
	    private PurchaseCashOrderBusinessHandler _PurchaseCashOrderBusinessHandler=null;
		/// <summary> 
		/// 采购结算单(PurchaseCashOrder)对象
        /// </summary>
		public PurchaseCashOrderBusinessHandler PurchaseCashOrderBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseCashOrderBusinessHandler==null)
					{
						_PurchaseCashOrderBusinessHandler=new PurchaseCashOrderBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseCashOrderBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseCashOrderBusinessHandler;
			}
		}
      
	    private DeliveryBusinessHandler _DeliveryBusinessHandler=null;
		/// <summary> 
		/// 配送信息(Delivery)对象
        /// </summary>
		public DeliveryBusinessHandler DeliveryBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DeliveryBusinessHandler==null)
					{
						_DeliveryBusinessHandler=new DeliveryBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DeliveryBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DeliveryBusinessHandler;
			}
		}
      
	    private DepartmentBusinessHandler _DepartmentBusinessHandler=null;
		/// <summary> 
		/// 部门(Department)对象
        /// </summary>
		public DepartmentBusinessHandler DepartmentBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DepartmentBusinessHandler==null)
					{
						_DepartmentBusinessHandler=new DepartmentBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DepartmentBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DepartmentBusinessHandler;
			}
		}
      
	    private DistrictBusinessHandler _DistrictBusinessHandler=null;
		/// <summary> 
		/// 区域(District)对象
        /// </summary>
		public DistrictBusinessHandler DistrictBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DistrictBusinessHandler==null)
					{
						_DistrictBusinessHandler=new DistrictBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DistrictBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DistrictBusinessHandler;
			}
		}
      
	    private DoubtDrugBusinessHandler _DoubtDrugBusinessHandler=null;
		/// <summary> 
		/// 疑问药品(DoubtDrug)对象
        /// </summary>
		public DoubtDrugBusinessHandler DoubtDrugBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DoubtDrugBusinessHandler==null)
					{
						_DoubtDrugBusinessHandler=new DoubtDrugBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DoubtDrugBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DoubtDrugBusinessHandler;
			}
		}
      
	    private DrugApprovalNumberBusinessHandler _DrugApprovalNumberBusinessHandler=null;
		/// <summary> 
		/// 药品批准文号(DrugApprovalNumber)对象
        /// </summary>
		public DrugApprovalNumberBusinessHandler DrugApprovalNumberBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DrugApprovalNumberBusinessHandler==null)
					{
						_DrugApprovalNumberBusinessHandler=new DrugApprovalNumberBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DrugApprovalNumberBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DrugApprovalNumberBusinessHandler;
			}
		}
      
	    private DrugCategoryBusinessHandler _DrugCategoryBusinessHandler=null;
		/// <summary> 
		/// 药物分类(DrugCategory)对象
        /// </summary>
		public DrugCategoryBusinessHandler DrugCategoryBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DrugCategoryBusinessHandler==null)
					{
						_DrugCategoryBusinessHandler=new DrugCategoryBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DrugCategoryBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DrugCategoryBusinessHandler;
			}
		}
      
	    private DrugClinicalCategoryBusinessHandler _DrugClinicalCategoryBusinessHandler=null;
		/// <summary> 
		/// 药物临床分类(DrugClinicalCategory)对象
        /// </summary>
		public DrugClinicalCategoryBusinessHandler DrugClinicalCategoryBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DrugClinicalCategoryBusinessHandler==null)
					{
						_DrugClinicalCategoryBusinessHandler=new DrugClinicalCategoryBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DrugClinicalCategoryBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DrugClinicalCategoryBusinessHandler;
			}
		}
      
	    private DictionaryDosageBusinessHandler _DictionaryDosageBusinessHandler=null;
		/// <summary> 
		/// 剂型(DictionaryDosage)对象
        /// </summary>
		public DictionaryDosageBusinessHandler DictionaryDosageBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DictionaryDosageBusinessHandler==null)
					{
						_DictionaryDosageBusinessHandler=new DictionaryDosageBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DictionaryDosageBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DictionaryDosageBusinessHandler;
			}
		}
      
	    private DrugInfoBusinessHandler _DrugInfoBusinessHandler=null;
		/// <summary> 
		/// 药品信息(DrugInfo)对象
        /// </summary>
		public DrugInfoBusinessHandler DrugInfoBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DrugInfoBusinessHandler==null)
					{
						_DrugInfoBusinessHandler=new DrugInfoBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DrugInfoBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DrugInfoBusinessHandler;
			}
		}
      
	    private DrugInventoryRecordBusinessHandler _DrugInventoryRecordBusinessHandler=null;
		/// <summary> 
		/// 药物库存(DrugInventoryRecord)对象
        /// </summary>
		public DrugInventoryRecordBusinessHandler DrugInventoryRecordBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DrugInventoryRecordBusinessHandler==null)
					{
						_DrugInventoryRecordBusinessHandler=new DrugInventoryRecordBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DrugInventoryRecordBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DrugInventoryRecordBusinessHandler;
			}
		}
      
	    private DrugMaintainRecordBusinessHandler _DrugMaintainRecordBusinessHandler=null;
		/// <summary> 
		/// 药品养护记录(DrugMaintainRecord)对象
        /// </summary>
		public DrugMaintainRecordBusinessHandler DrugMaintainRecordBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DrugMaintainRecordBusinessHandler==null)
					{
						_DrugMaintainRecordBusinessHandler=new DrugMaintainRecordBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DrugMaintainRecordBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DrugMaintainRecordBusinessHandler;
			}
		}
      
	    private DrugMaintainRecordDetailBusinessHandler _DrugMaintainRecordDetailBusinessHandler=null;
		/// <summary> 
		/// 药品养护记录明细(DrugMaintainRecordDetail)对象
        /// </summary>
		public DrugMaintainRecordDetailBusinessHandler DrugMaintainRecordDetailBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DrugMaintainRecordDetailBusinessHandler==null)
					{
						_DrugMaintainRecordDetailBusinessHandler=new DrugMaintainRecordDetailBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DrugMaintainRecordDetailBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DrugMaintainRecordDetailBusinessHandler;
			}
		}
      
	    private DictionaryMeasurementUnitBusinessHandler _DictionaryMeasurementUnitBusinessHandler=null;
		/// <summary> 
		/// 计量单位(DictionaryMeasurementUnit)对象
        /// </summary>
		public DictionaryMeasurementUnitBusinessHandler DictionaryMeasurementUnitBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DictionaryMeasurementUnitBusinessHandler==null)
					{
						_DictionaryMeasurementUnitBusinessHandler=new DictionaryMeasurementUnitBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DictionaryMeasurementUnitBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DictionaryMeasurementUnitBusinessHandler;
			}
		}
      
	    private DictionaryPiecemealUnitBusinessHandler _DictionaryPiecemealUnitBusinessHandler=null;
		/// <summary> 
		/// 拆零单位(DictionaryPiecemealUnit)对象
        /// </summary>
		public DictionaryPiecemealUnitBusinessHandler DictionaryPiecemealUnitBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DictionaryPiecemealUnitBusinessHandler==null)
					{
						_DictionaryPiecemealUnitBusinessHandler=new DictionaryPiecemealUnitBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DictionaryPiecemealUnitBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DictionaryPiecemealUnitBusinessHandler;
			}
		}
      
	    private DictionarySpecificationBusinessHandler _DictionarySpecificationBusinessHandler=null;
		/// <summary> 
		/// 药物规格(DictionarySpecification)对象
        /// </summary>
		public DictionarySpecificationBusinessHandler DictionarySpecificationBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DictionarySpecificationBusinessHandler==null)
					{
						_DictionarySpecificationBusinessHandler=new DictionarySpecificationBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DictionarySpecificationBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DictionarySpecificationBusinessHandler;
			}
		}
      
	    private DictionaryStorageTypeBusinessHandler _DictionaryStorageTypeBusinessHandler=null;
		/// <summary> 
		/// 储藏方式(DictionaryStorageType)对象
        /// </summary>
		public DictionaryStorageTypeBusinessHandler DictionaryStorageTypeBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DictionaryStorageTypeBusinessHandler==null)
					{
						_DictionaryStorageTypeBusinessHandler=new DictionaryStorageTypeBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DictionaryStorageTypeBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DictionaryStorageTypeBusinessHandler;
			}
		}
      
	    private DictionaryUserDefinedTypeBusinessHandler _DictionaryUserDefinedTypeBusinessHandler=null;
		/// <summary> 
		/// 用户自定义药物类型(DictionaryUserDefinedType)对象
        /// </summary>
		public DictionaryUserDefinedTypeBusinessHandler DictionaryUserDefinedTypeBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DictionaryUserDefinedTypeBusinessHandler==null)
					{
						_DictionaryUserDefinedTypeBusinessHandler=new DictionaryUserDefinedTypeBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DictionaryUserDefinedTypeBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DictionaryUserDefinedTypeBusinessHandler;
			}
		}
      
	    private AuthorizationDocBusinessHandler _AuthorizationDocBusinessHandler=null;
		/// <summary> 
		/// 授权书(AuthorizationDoc)对象
        /// </summary>
		public AuthorizationDocBusinessHandler AuthorizationDocBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_AuthorizationDocBusinessHandler==null)
					{
						_AuthorizationDocBusinessHandler=new AuthorizationDocBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_AuthorizationDocBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _AuthorizationDocBusinessHandler;
			}
		}
      
	    private DrugMaintainSetBusinessHandler _DrugMaintainSetBusinessHandler=null;
		/// <summary> 
		/// 药品养护设置(DrugMaintainSet)对象
        /// </summary>
		public DrugMaintainSetBusinessHandler DrugMaintainSetBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_DrugMaintainSetBusinessHandler==null)
					{
						_DrugMaintainSetBusinessHandler=new DrugMaintainSetBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_DrugMaintainSetBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _DrugMaintainSetBusinessHandler;
			}
		}
      
	    private EmployeeBusinessHandler _EmployeeBusinessHandler=null;
		/// <summary> 
		/// 员工(Employee)对象
        /// </summary>
		public EmployeeBusinessHandler EmployeeBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_EmployeeBusinessHandler==null)
					{
						_EmployeeBusinessHandler=new EmployeeBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_EmployeeBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _EmployeeBusinessHandler;
			}
		}
      
	    private GMSPLicenseBusinessScopeBusinessHandler _GMSPLicenseBusinessScopeBusinessHandler=null;
		/// <summary> 
		/// GMSP证书规定的经营范围(GMSPLicenseBusinessScope)对象
        /// </summary>
		public GMSPLicenseBusinessScopeBusinessHandler GMSPLicenseBusinessScopeBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_GMSPLicenseBusinessScopeBusinessHandler==null)
					{
						_GMSPLicenseBusinessScopeBusinessHandler=new GMSPLicenseBusinessScopeBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_GMSPLicenseBusinessScopeBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _GMSPLicenseBusinessScopeBusinessHandler;
			}
		}
      
	    private InventoryRecordBusinessHandler _InventoryRecordBusinessHandler=null;
		/// <summary> 
		/// 库存(InventoryRecord)对象
        /// </summary>
		public InventoryRecordBusinessHandler InventoryRecordBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_InventoryRecordBusinessHandler==null)
					{
						_InventoryRecordBusinessHandler=new InventoryRecordBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_InventoryRecordBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _InventoryRecordBusinessHandler;
			}
		}
      
	    private ManufacturerBusinessHandler _ManufacturerBusinessHandler=null;
		/// <summary> 
		/// 生产厂家 (Manufacturer)对象
        /// </summary>
		public ManufacturerBusinessHandler ManufacturerBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_ManufacturerBusinessHandler==null)
					{
						_ManufacturerBusinessHandler=new ManufacturerBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_ManufacturerBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _ManufacturerBusinessHandler;
			}
		}
      
	    private PackagingMaterialBusinessHandler _PackagingMaterialBusinessHandler=null;
		/// <summary> 
		/// 包装材质(PackagingMaterial)对象
        /// </summary>
		public PackagingMaterialBusinessHandler PackagingMaterialBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PackagingMaterialBusinessHandler==null)
					{
						_PackagingMaterialBusinessHandler=new PackagingMaterialBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PackagingMaterialBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PackagingMaterialBusinessHandler;
			}
		}
      
	    private PackagingUnitBusinessHandler _PackagingUnitBusinessHandler=null;
		/// <summary> 
		/// 包装(PackagingUnit)对象
        /// </summary>
		public PackagingUnitBusinessHandler PackagingUnitBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PackagingUnitBusinessHandler==null)
					{
						_PackagingUnitBusinessHandler=new PackagingUnitBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PackagingUnitBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PackagingUnitBusinessHandler;
			}
		}
      
	    private PaymentMethodBusinessHandler _PaymentMethodBusinessHandler=null;
		/// <summary> 
		/// 付款方式(PaymentMethod)对象
        /// </summary>
		public PaymentMethodBusinessHandler PaymentMethodBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PaymentMethodBusinessHandler==null)
					{
						_PaymentMethodBusinessHandler=new PaymentMethodBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PaymentMethodBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PaymentMethodBusinessHandler;
			}
		}
      
	    private GSPLicenseBusinessHandler _GSPLicenseBusinessHandler=null;
		/// <summary> 
		/// GSP证书(GSPLicense)对象
        /// </summary>
		public GSPLicenseBusinessHandler GSPLicenseBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_GSPLicenseBusinessHandler==null)
					{
						_GSPLicenseBusinessHandler=new GSPLicenseBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_GSPLicenseBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _GSPLicenseBusinessHandler;
			}
		}
      
	    private GMPLicenseBusinessHandler _GMPLicenseBusinessHandler=null;
		/// <summary> 
		/// GMP证书(GMPLicense)对象
        /// </summary>
		public GMPLicenseBusinessHandler GMPLicenseBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_GMPLicenseBusinessHandler==null)
					{
						_GMPLicenseBusinessHandler=new GMPLicenseBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_GMPLicenseBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _GMPLicenseBusinessHandler;
			}
		}
      
	    private BusinessLicenseBusinessHandler _BusinessLicenseBusinessHandler=null;
		/// <summary> 
		/// 营业执照(BusinessLicense)对象
        /// </summary>
		public BusinessLicenseBusinessHandler BusinessLicenseBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_BusinessLicenseBusinessHandler==null)
					{
						_BusinessLicenseBusinessHandler=new BusinessLicenseBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_BusinessLicenseBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _BusinessLicenseBusinessHandler;
			}
		}
      
	    private MedicineProductionLicenseBusinessHandler _MedicineProductionLicenseBusinessHandler=null;
		/// <summary> 
		/// 药品生产许可证(MedicineProductionLicense)对象
        /// </summary>
		public MedicineProductionLicenseBusinessHandler MedicineProductionLicenseBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_MedicineProductionLicenseBusinessHandler==null)
					{
						_MedicineProductionLicenseBusinessHandler=new MedicineProductionLicenseBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_MedicineProductionLicenseBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _MedicineProductionLicenseBusinessHandler;
			}
		}
      
	    private MedicineBusinessLicenseBusinessHandler _MedicineBusinessLicenseBusinessHandler=null;
		/// <summary> 
		/// 药品经营许可证(MedicineBusinessLicense)对象
        /// </summary>
		public MedicineBusinessLicenseBusinessHandler MedicineBusinessLicenseBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_MedicineBusinessLicenseBusinessHandler==null)
					{
						_MedicineBusinessLicenseBusinessHandler=new MedicineBusinessLicenseBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_MedicineBusinessLicenseBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _MedicineBusinessLicenseBusinessHandler;
			}
		}
      
	    private InstrumentsBusinessLicenseBusinessHandler _InstrumentsBusinessLicenseBusinessHandler=null;
		/// <summary> 
		/// 器械经营许可证(InstrumentsBusinessLicense)对象
        /// </summary>
		public InstrumentsBusinessLicenseBusinessHandler InstrumentsBusinessLicenseBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_InstrumentsBusinessLicenseBusinessHandler==null)
					{
						_InstrumentsBusinessLicenseBusinessHandler=new InstrumentsBusinessLicenseBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_InstrumentsBusinessLicenseBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _InstrumentsBusinessLicenseBusinessHandler;
			}
		}
      
	    private InstrumentsProductionLicenseBusinessHandler _InstrumentsProductionLicenseBusinessHandler=null;
		/// <summary> 
		/// 器械生产许可证(InstrumentsProductionLicense)对象
        /// </summary>
		public InstrumentsProductionLicenseBusinessHandler InstrumentsProductionLicenseBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_InstrumentsProductionLicenseBusinessHandler==null)
					{
						_InstrumentsProductionLicenseBusinessHandler=new InstrumentsProductionLicenseBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_InstrumentsProductionLicenseBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _InstrumentsProductionLicenseBusinessHandler;
			}
		}
      
	    private MedicalCategoryBusinessHandler _MedicalCategoryBusinessHandler=null;
		/// <summary> 
		/// 医疗分类(MedicalCategory)对象
        /// </summary>
		public MedicalCategoryBusinessHandler MedicalCategoryBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_MedicalCategoryBusinessHandler==null)
					{
						_MedicalCategoryBusinessHandler=new MedicalCategoryBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_MedicalCategoryBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _MedicalCategoryBusinessHandler;
			}
		}
      
	    private MedicalCategoryDetailBusinessHandler _MedicalCategoryDetailBusinessHandler=null;
		/// <summary> 
		/// 医疗详细分类(MedicalCategoryDetail)对象
        /// </summary>
		public MedicalCategoryDetailBusinessHandler MedicalCategoryDetailBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_MedicalCategoryDetailBusinessHandler==null)
					{
						_MedicalCategoryDetailBusinessHandler=new MedicalCategoryDetailBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_MedicalCategoryDetailBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _MedicalCategoryDetailBusinessHandler;
			}
		}
      
	    private ModuleBusinessHandler _ModuleBusinessHandler=null;
		/// <summary> 
		/// 功能模块(Module)对象
        /// </summary>
		public ModuleBusinessHandler ModuleBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_ModuleBusinessHandler==null)
					{
						_ModuleBusinessHandler=new ModuleBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_ModuleBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _ModuleBusinessHandler;
			}
		}
      
	    private ModuleCatetoryBusinessHandler _ModuleCatetoryBusinessHandler=null;
		/// <summary> 
		/// 功能模块分类(ModuleCatetory)对象
        /// </summary>
		public ModuleCatetoryBusinessHandler ModuleCatetoryBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_ModuleCatetoryBusinessHandler==null)
					{
						_ModuleCatetoryBusinessHandler=new ModuleCatetoryBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_ModuleCatetoryBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _ModuleCatetoryBusinessHandler;
			}
		}
      
	    private ModuleWithRoleBusinessHandler _ModuleWithRoleBusinessHandler=null;
		/// <summary> 
		/// 功能模块与角色的关联(ModuleWithRole)对象
        /// </summary>
		public ModuleWithRoleBusinessHandler ModuleWithRoleBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_ModuleWithRoleBusinessHandler==null)
					{
						_ModuleWithRoleBusinessHandler=new ModuleWithRoleBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_ModuleWithRoleBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _ModuleWithRoleBusinessHandler;
			}
		}
      
	    private PharmacyFileBusinessHandler _PharmacyFileBusinessHandler=null;
		/// <summary> 
		/// 文件(PharmacyFile)对象
        /// </summary>
		public PharmacyFileBusinessHandler PharmacyFileBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PharmacyFileBusinessHandler==null)
					{
						_PharmacyFileBusinessHandler=new PharmacyFileBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PharmacyFileBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PharmacyFileBusinessHandler;
			}
		}
      
	    private PurchaseAgreementBusinessHandler _PurchaseAgreementBusinessHandler=null;
		/// <summary> 
		/// 采购合同(PurchaseAgreement)对象
        /// </summary>
		public PurchaseAgreementBusinessHandler PurchaseAgreementBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseAgreementBusinessHandler==null)
					{
						_PurchaseAgreementBusinessHandler=new PurchaseAgreementBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseAgreementBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseAgreementBusinessHandler;
			}
		}
      
	    private PurchaseCheckingOrderBusinessHandler _PurchaseCheckingOrderBusinessHandler=null;
		/// <summary> 
		/// 验收记录(PurchaseCheckingOrder)对象
        /// </summary>
		public PurchaseCheckingOrderBusinessHandler PurchaseCheckingOrderBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseCheckingOrderBusinessHandler==null)
					{
						_PurchaseCheckingOrderBusinessHandler=new PurchaseCheckingOrderBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseCheckingOrderBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseCheckingOrderBusinessHandler;
			}
		}
      
	    private PurchaseCheckingOrderDetailBusinessHandler _PurchaseCheckingOrderDetailBusinessHandler=null;
		/// <summary> 
		/// 采购到货验收(PurchaseCheckingOrderDetail)对象
        /// </summary>
		public PurchaseCheckingOrderDetailBusinessHandler PurchaseCheckingOrderDetailBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseCheckingOrderDetailBusinessHandler==null)
					{
						_PurchaseCheckingOrderDetailBusinessHandler=new PurchaseCheckingOrderDetailBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseCheckingOrderDetailBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseCheckingOrderDetailBusinessHandler;
			}
		}
      
	    private PurchaseInInventeryOrderBusinessHandler _PurchaseInInventeryOrderBusinessHandler=null;
		/// <summary> 
		/// 库存记录(PurchaseInInventeryOrder)对象
        /// </summary>
		public PurchaseInInventeryOrderBusinessHandler PurchaseInInventeryOrderBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseInInventeryOrderBusinessHandler==null)
					{
						_PurchaseInInventeryOrderBusinessHandler=new PurchaseInInventeryOrderBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseInInventeryOrderBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseInInventeryOrderBusinessHandler;
			}
		}
      
	    private PurchaseInInventeryOrderDetailBusinessHandler _PurchaseInInventeryOrderDetailBusinessHandler=null;
		/// <summary> 
		/// 库存记录详细(PurchaseInInventeryOrderDetail)对象
        /// </summary>
		public PurchaseInInventeryOrderDetailBusinessHandler PurchaseInInventeryOrderDetailBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseInInventeryOrderDetailBusinessHandler==null)
					{
						_PurchaseInInventeryOrderDetailBusinessHandler=new PurchaseInInventeryOrderDetailBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseInInventeryOrderDetailBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseInInventeryOrderDetailBusinessHandler;
			}
		}
      
	    private PurchaseManageCategoryBusinessHandler _PurchaseManageCategoryBusinessHandler=null;
		/// <summary> 
		/// 管理要求分类(PurchaseManageCategory)对象
        /// </summary>
		public PurchaseManageCategoryBusinessHandler PurchaseManageCategoryBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseManageCategoryBusinessHandler==null)
					{
						_PurchaseManageCategoryBusinessHandler=new PurchaseManageCategoryBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseManageCategoryBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseManageCategoryBusinessHandler;
			}
		}
      
	    private PurchaseManageCategoryDetailBusinessHandler _PurchaseManageCategoryDetailBusinessHandler=null;
		/// <summary> 
		/// 管理要求分类详细(PurchaseManageCategoryDetail)对象
        /// </summary>
		public PurchaseManageCategoryDetailBusinessHandler PurchaseManageCategoryDetailBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseManageCategoryDetailBusinessHandler==null)
					{
						_PurchaseManageCategoryDetailBusinessHandler=new PurchaseManageCategoryDetailBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseManageCategoryDetailBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseManageCategoryDetailBusinessHandler;
			}
		}
      
	    private PurchaseOrderBusinessHandler _PurchaseOrderBusinessHandler=null;
		/// <summary> 
		/// 采购单(PurchaseOrder)对象
        /// </summary>
		public PurchaseOrderBusinessHandler PurchaseOrderBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseOrderBusinessHandler==null)
					{
						_PurchaseOrderBusinessHandler=new PurchaseOrderBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseOrderBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseOrderBusinessHandler;
			}
		}
      
	    private PurchaseOrderDetailBusinessHandler _PurchaseOrderDetailBusinessHandler=null;
		/// <summary> 
		/// 采购明细(PurchaseOrderDetail)对象
        /// </summary>
		public PurchaseOrderDetailBusinessHandler PurchaseOrderDetailBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseOrderDetailBusinessHandler==null)
					{
						_PurchaseOrderDetailBusinessHandler=new PurchaseOrderDetailBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseOrderDetailBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseOrderDetailBusinessHandler;
			}
		}
      
	    private PurchaseOrderReturnBusinessHandler _PurchaseOrderReturnBusinessHandler=null;
		/// <summary> 
		/// (PurchaseOrderReturn)对象
        /// </summary>
		public PurchaseOrderReturnBusinessHandler PurchaseOrderReturnBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseOrderReturnBusinessHandler==null)
					{
						_PurchaseOrderReturnBusinessHandler=new PurchaseOrderReturnBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseOrderReturnBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseOrderReturnBusinessHandler;
			}
		}
      
	    private PurchaseOrderReturnDetailBusinessHandler _PurchaseOrderReturnDetailBusinessHandler=null;
		/// <summary> 
		/// (PurchaseOrderReturnDetail)对象
        /// </summary>
		public PurchaseOrderReturnDetailBusinessHandler PurchaseOrderReturnDetailBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseOrderReturnDetailBusinessHandler==null)
					{
						_PurchaseOrderReturnDetailBusinessHandler=new PurchaseOrderReturnDetailBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseOrderReturnDetailBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseOrderReturnDetailBusinessHandler;
			}
		}
      
	    private PurchaseReceivingOrderBusinessHandler _PurchaseReceivingOrderBusinessHandler=null;
		/// <summary> 
		/// 采购收货单(PurchaseReceivingOrder)对象
        /// </summary>
		public PurchaseReceivingOrderBusinessHandler PurchaseReceivingOrderBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseReceivingOrderBusinessHandler==null)
					{
						_PurchaseReceivingOrderBusinessHandler=new PurchaseReceivingOrderBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseReceivingOrderBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseReceivingOrderBusinessHandler;
			}
		}
      
	    private PurchaseReceivingOrderDetailBusinessHandler _PurchaseReceivingOrderDetailBusinessHandler=null;
		/// <summary> 
		/// 采购收货详细单(PurchaseReceivingOrderDetail)对象
        /// </summary>
		public PurchaseReceivingOrderDetailBusinessHandler PurchaseReceivingOrderDetailBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseReceivingOrderDetailBusinessHandler==null)
					{
						_PurchaseReceivingOrderDetailBusinessHandler=new PurchaseReceivingOrderDetailBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseReceivingOrderDetailBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseReceivingOrderDetailBusinessHandler;
			}
		}
      
	    private PurchaseUnitBusinessHandler _PurchaseUnitBusinessHandler=null;
		/// <summary> 
		/// 购货单位(PurchaseUnit)对象
        /// </summary>
		public PurchaseUnitBusinessHandler PurchaseUnitBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseUnitBusinessHandler==null)
					{
						_PurchaseUnitBusinessHandler=new PurchaseUnitBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseUnitBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseUnitBusinessHandler;
			}
		}
      
	    private PurchaseUnitBuyerBusinessHandler _PurchaseUnitBuyerBusinessHandler=null;
		/// <summary> 
		/// 购货单位采购人员(PurchaseUnitBuyer)对象
        /// </summary>
		public PurchaseUnitBuyerBusinessHandler PurchaseUnitBuyerBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseUnitBuyerBusinessHandler==null)
					{
						_PurchaseUnitBuyerBusinessHandler=new PurchaseUnitBuyerBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseUnitBuyerBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseUnitBuyerBusinessHandler;
			}
		}
      
	    private PurchaseUnitDelivererBusinessHandler _PurchaseUnitDelivererBusinessHandler=null;
		/// <summary> 
		/// 购货单位提货人员(PurchaseUnitDeliverer)对象
        /// </summary>
		public PurchaseUnitDelivererBusinessHandler PurchaseUnitDelivererBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseUnitDelivererBusinessHandler==null)
					{
						_PurchaseUnitDelivererBusinessHandler=new PurchaseUnitDelivererBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseUnitDelivererBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseUnitDelivererBusinessHandler;
			}
		}
      
	    private PurchaseUnitTypeBusinessHandler _PurchaseUnitTypeBusinessHandler=null;
		/// <summary> 
		/// 购货单位类型(PurchaseUnitType)对象
        /// </summary>
		public PurchaseUnitTypeBusinessHandler PurchaseUnitTypeBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchaseUnitTypeBusinessHandler==null)
					{
						_PurchaseUnitTypeBusinessHandler=new PurchaseUnitTypeBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchaseUnitTypeBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchaseUnitTypeBusinessHandler;
			}
		}
      
	    private PurchasingPlanBusinessHandler _PurchasingPlanBusinessHandler=null;
		/// <summary> 
		/// (PurchasingPlan)对象
        /// </summary>
		public PurchasingPlanBusinessHandler PurchasingPlanBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchasingPlanBusinessHandler==null)
					{
						_PurchasingPlanBusinessHandler=new PurchasingPlanBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchasingPlanBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchasingPlanBusinessHandler;
			}
		}
      
	    private PurchasingPlanDetailBusinessHandler _PurchasingPlanDetailBusinessHandler=null;
		/// <summary> 
		/// (PurchasingPlanDetail)对象
        /// </summary>
		public PurchasingPlanDetailBusinessHandler PurchasingPlanDetailBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_PurchasingPlanDetailBusinessHandler==null)
					{
						_PurchasingPlanDetailBusinessHandler=new PurchasingPlanDetailBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_PurchasingPlanDetailBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _PurchasingPlanDetailBusinessHandler;
			}
		}
      
	    private RarewordBusinessHandler _RarewordBusinessHandler=null;
		/// <summary> 
		/// 不常用字(生僻字)(Rareword)对象
        /// </summary>
		public RarewordBusinessHandler RarewordBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_RarewordBusinessHandler==null)
					{
						_RarewordBusinessHandler=new RarewordBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_RarewordBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _RarewordBusinessHandler;
			}
		}
      
	    private RetailMemberBusinessHandler _RetailMemberBusinessHandler=null;
		/// <summary> 
		/// 零售会员(RetailMember)对象
        /// </summary>
		public RetailMemberBusinessHandler RetailMemberBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_RetailMemberBusinessHandler==null)
					{
						_RetailMemberBusinessHandler=new RetailMemberBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_RetailMemberBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _RetailMemberBusinessHandler;
			}
		}
      
	    private RetailOrderBusinessHandler _RetailOrderBusinessHandler=null;
		/// <summary> 
		/// (RetailOrder)对象
        /// </summary>
		public RetailOrderBusinessHandler RetailOrderBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_RetailOrderBusinessHandler==null)
					{
						_RetailOrderBusinessHandler=new RetailOrderBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_RetailOrderBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _RetailOrderBusinessHandler;
			}
		}
      
	    private RetailOrderDetailBusinessHandler _RetailOrderDetailBusinessHandler=null;
		/// <summary> 
		/// 零售单明细(RetailOrderDetail)对象
        /// </summary>
		public RetailOrderDetailBusinessHandler RetailOrderDetailBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_RetailOrderDetailBusinessHandler==null)
					{
						_RetailOrderDetailBusinessHandler=new RetailOrderDetailBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_RetailOrderDetailBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _RetailOrderDetailBusinessHandler;
			}
		}
      
	    private RoleBusinessHandler _RoleBusinessHandler=null;
		/// <summary> 
		/// 系统角色(Role)对象
        /// </summary>
		public RoleBusinessHandler RoleBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_RoleBusinessHandler==null)
					{
						_RoleBusinessHandler=new RoleBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_RoleBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _RoleBusinessHandler;
			}
		}
      
	    private RoleWithUserBusinessHandler _RoleWithUserBusinessHandler=null;
		/// <summary> 
		/// 角色与用户的关联(RoleWithUser)对象
        /// </summary>
		public RoleWithUserBusinessHandler RoleWithUserBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_RoleWithUserBusinessHandler==null)
					{
						_RoleWithUserBusinessHandler=new RoleWithUserBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_RoleWithUserBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _RoleWithUserBusinessHandler;
			}
		}
      
	    private SalesOrderBusinessHandler _SalesOrderBusinessHandler=null;
		/// <summary> 
		/// 销售单(SalesOrder)对象
        /// </summary>
		public SalesOrderBusinessHandler SalesOrderBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_SalesOrderBusinessHandler==null)
					{
						_SalesOrderBusinessHandler=new SalesOrderBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_SalesOrderBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _SalesOrderBusinessHandler;
			}
		}
      
	    private SalesOrderDeliverDetailBusinessHandler _SalesOrderDeliverDetailBusinessHandler=null;
		/// <summary> 
		/// (SalesOrderDeliverDetail)对象
        /// </summary>
		public SalesOrderDeliverDetailBusinessHandler SalesOrderDeliverDetailBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_SalesOrderDeliverDetailBusinessHandler==null)
					{
						_SalesOrderDeliverDetailBusinessHandler=new SalesOrderDeliverDetailBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_SalesOrderDeliverDetailBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _SalesOrderDeliverDetailBusinessHandler;
			}
		}
      
	    private SalesOrderDeliverRecordBusinessHandler _SalesOrderDeliverRecordBusinessHandler=null;
		/// <summary> 
		/// 销售发货记录(SalesOrderDeliverRecord)对象
        /// </summary>
		public SalesOrderDeliverRecordBusinessHandler SalesOrderDeliverRecordBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_SalesOrderDeliverRecordBusinessHandler==null)
					{
						_SalesOrderDeliverRecordBusinessHandler=new SalesOrderDeliverRecordBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_SalesOrderDeliverRecordBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _SalesOrderDeliverRecordBusinessHandler;
			}
		}
      
	    private SalesOrderDetailBusinessHandler _SalesOrderDetailBusinessHandler=null;
		/// <summary> 
		/// 销售单明细(SalesOrderDetail)对象
        /// </summary>
		public SalesOrderDetailBusinessHandler SalesOrderDetailBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_SalesOrderDetailBusinessHandler==null)
					{
						_SalesOrderDetailBusinessHandler=new SalesOrderDetailBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_SalesOrderDetailBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _SalesOrderDetailBusinessHandler;
			}
		}
      
	    private SalesOrderReturnBusinessHandler _SalesOrderReturnBusinessHandler=null;
		/// <summary> 
		/// (SalesOrderReturn)对象
        /// </summary>
		public SalesOrderReturnBusinessHandler SalesOrderReturnBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_SalesOrderReturnBusinessHandler==null)
					{
						_SalesOrderReturnBusinessHandler=new SalesOrderReturnBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_SalesOrderReturnBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _SalesOrderReturnBusinessHandler;
			}
		}
      
	    private SalesOrderReturnDetailBusinessHandler _SalesOrderReturnDetailBusinessHandler=null;
		/// <summary> 
		/// (SalesOrderReturnDetail)对象
        /// </summary>
		public SalesOrderReturnDetailBusinessHandler SalesOrderReturnDetailBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_SalesOrderReturnDetailBusinessHandler==null)
					{
						_SalesOrderReturnDetailBusinessHandler=new SalesOrderReturnDetailBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_SalesOrderReturnDetailBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _SalesOrderReturnDetailBusinessHandler;
			}
		}
      
	    private OutInventoryBusinessHandler _OutInventoryBusinessHandler=null;
		/// <summary> 
		/// 销售出库单(OutInventory)对象
        /// </summary>
		public OutInventoryBusinessHandler OutInventoryBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_OutInventoryBusinessHandler==null)
					{
						_OutInventoryBusinessHandler=new OutInventoryBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_OutInventoryBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _OutInventoryBusinessHandler;
			}
		}
      
	    private SetSpeicalDrugRecordBusinessHandler _SetSpeicalDrugRecordBusinessHandler=null;
		/// <summary> 
		/// 设置重点药品记录表(SetSpeicalDrugRecord)对象
        /// </summary>
		public SetSpeicalDrugRecordBusinessHandler SetSpeicalDrugRecordBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_SetSpeicalDrugRecordBusinessHandler==null)
					{
						_SetSpeicalDrugRecordBusinessHandler=new SetSpeicalDrugRecordBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_SetSpeicalDrugRecordBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _SetSpeicalDrugRecordBusinessHandler;
			}
		}
      
	    private SpecialDrugCategoryBusinessHandler _SpecialDrugCategoryBusinessHandler=null;
		/// <summary> 
		/// 特殊管理药物类型(SpecialDrugCategory)对象
        /// </summary>
		public SpecialDrugCategoryBusinessHandler SpecialDrugCategoryBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_SpecialDrugCategoryBusinessHandler==null)
					{
						_SpecialDrugCategoryBusinessHandler=new SpecialDrugCategoryBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_SpecialDrugCategoryBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _SpecialDrugCategoryBusinessHandler;
			}
		}
      
	    private StoreBusinessHandler _StoreBusinessHandler=null;
		/// <summary> 
		/// 门店(Store)对象
        /// </summary>
		public StoreBusinessHandler StoreBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_StoreBusinessHandler==null)
					{
						_StoreBusinessHandler=new StoreBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_StoreBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _StoreBusinessHandler;
			}
		}
      
	    private SupplyUnitBusinessHandler _SupplyUnitBusinessHandler=null;
		/// <summary> 
		/// 供货单位(SupplyUnit)对象
        /// </summary>
		public SupplyUnitBusinessHandler SupplyUnitBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_SupplyUnitBusinessHandler==null)
					{
						_SupplyUnitBusinessHandler=new SupplyUnitBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_SupplyUnitBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _SupplyUnitBusinessHandler;
			}
		}
      
	    private SupplyUnitSalesmanBusinessHandler _SupplyUnitSalesmanBusinessHandler=null;
		/// <summary> 
		/// 供货商销售人员(SupplyUnitSalesman)对象
        /// </summary>
		public SupplyUnitSalesmanBusinessHandler SupplyUnitSalesmanBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_SupplyUnitSalesmanBusinessHandler==null)
					{
						_SupplyUnitSalesmanBusinessHandler=new SupplyUnitSalesmanBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_SupplyUnitSalesmanBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _SupplyUnitSalesmanBusinessHandler;
			}
		}
      
	    private TaxRateBusinessHandler _TaxRateBusinessHandler=null;
		/// <summary> 
		/// 税率(TaxRate)对象
        /// </summary>
		public TaxRateBusinessHandler TaxRateBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_TaxRateBusinessHandler==null)
					{
						_TaxRateBusinessHandler=new TaxRateBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_TaxRateBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _TaxRateBusinessHandler;
			}
		}
      
	    private UnitTypeBusinessHandler _UnitTypeBusinessHandler=null;
		/// <summary> 
		/// 企业类型(UnitType)对象
        /// </summary>
		public UnitTypeBusinessHandler UnitTypeBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_UnitTypeBusinessHandler==null)
					{
						_UnitTypeBusinessHandler=new UnitTypeBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_UnitTypeBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _UnitTypeBusinessHandler;
			}
		}
      
	    private UploadRecordBusinessHandler _UploadRecordBusinessHandler=null;
		/// <summary> 
		/// 数据上传记录(UploadRecord)对象
        /// </summary>
		public UploadRecordBusinessHandler UploadRecordBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_UploadRecordBusinessHandler==null)
					{
						_UploadRecordBusinessHandler=new UploadRecordBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_UploadRecordBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _UploadRecordBusinessHandler;
			}
		}
      
	    private UserBusinessHandler _UserBusinessHandler=null;
		/// <summary> 
		/// 系统用户(User)对象
        /// </summary>
		public UserBusinessHandler UserBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_UserBusinessHandler==null)
					{
						_UserBusinessHandler=new UserBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_UserBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _UserBusinessHandler;
			}
		}
      
	    private UserLogBusinessHandler _UserLogBusinessHandler=null;
		/// <summary> 
		/// 用户日志(UserLog)对象
        /// </summary>
		public UserLogBusinessHandler UserLogBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_UserLogBusinessHandler==null)
					{
						_UserLogBusinessHandler=new UserLogBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_UserLogBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _UserLogBusinessHandler;
			}
		}
      
	    private VehicleBusinessHandler _VehicleBusinessHandler=null;
		/// <summary> 
		/// 车辆(Vehicle)对象
        /// </summary>
		public VehicleBusinessHandler VehicleBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_VehicleBusinessHandler==null)
					{
						_VehicleBusinessHandler=new VehicleBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_VehicleBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _VehicleBusinessHandler;
			}
		}
      
	    private WarehouseBusinessHandler _WarehouseBusinessHandler=null;
		/// <summary> 
		/// 仓库(Warehouse)对象
        /// </summary>
		public WarehouseBusinessHandler WarehouseBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_WarehouseBusinessHandler==null)
					{
						_WarehouseBusinessHandler=new WarehouseBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_WarehouseBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _WarehouseBusinessHandler;
			}
		}
      
	    private WarehouseZoneBusinessHandler _WarehouseZoneBusinessHandler=null;
		/// <summary> 
		/// 库区(WarehouseZone)对象
        /// </summary>
		public WarehouseZoneBusinessHandler WarehouseZoneBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_WarehouseZoneBusinessHandler==null)
					{
						_WarehouseZoneBusinessHandler=new WarehouseZoneBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_WarehouseZoneBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _WarehouseZoneBusinessHandler;
			}
		}
      
	    private WaringSetBusinessHandler _WaringSetBusinessHandler=null;
		/// <summary> 
		/// 报警设置(WaringSet)对象
        /// </summary>
		public WaringSetBusinessHandler WaringSetBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_WaringSetBusinessHandler==null)
					{
						_WaringSetBusinessHandler=new WaringSetBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_WaringSetBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _WaringSetBusinessHandler;
			}
		}
      
	    private OutInventoryDetailBusinessHandler _OutInventoryDetailBusinessHandler=null;
		/// <summary> 
		/// 销售出库单(OutInventoryDetail)对象
        /// </summary>
		public OutInventoryDetailBusinessHandler OutInventoryDetailBusinessHandler 
		{
			get
			{
				lock(this)
				{
				    if(_OutInventoryDetailBusinessHandler==null)
					{
						_OutInventoryDetailBusinessHandler=new OutInventoryDetailBusinessHandler(RepositoryProvider,ConnectedInfoProvider);
						_OutInventoryDetailBusinessHandler.SetBusinessHandlerFactory(this);
					}
				}
				return _OutInventoryDetailBusinessHandler;
			}
		}

       //wfz
        private SupplyPersonBusinessHandler _SupplyPersonBusinessHandler = null;
        /// <summary> 
        /// 购货单位提货人员(SupplyPerson)对象
        /// </summary>
        public SupplyPersonBusinessHandler SupplyPersonBusinessHandler
        {
            get
            {
                lock (this)
                {
                    if (_SupplyPersonBusinessHandler == null)
                    {
                        _SupplyPersonBusinessHandler = new SupplyPersonBusinessHandler(RepositoryProvider, ConnectedInfoProvider);
                        _SupplyPersonBusinessHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _SupplyPersonBusinessHandler;
            }
        }
       //end wfz

        //modi 20131226
        private DrugsUnqualificationHandler _DrugsUnqualificationHandler = null;
        /// <summary> 
        /// 不合格药品对象
        /// </summary>
        public DrugsUnqualificationHandler DrugsUnqualificationHandler
        {
            get
            {
                lock (this)
                {
                    if (_DrugsUnqualificationHandler == null)
                    {
                        _DrugsUnqualificationHandler = new DrugsUnqualificationHandler(RepositoryProvider, ConnectedInfoProvider);
                        _DrugsUnqualificationHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _DrugsUnqualificationHandler;
            }
        }
        //end

        private OrganizationCodeLicenseHandler _OrganizationCodeLicenseHandler = null;
        /// <summary> 
        /// 组织机构代码证对象
        /// </summary>
        public OrganizationCodeLicenseHandler OrganizationCodeLicenseHandler
        {
            get
            {
                lock (this)
                {
                    if (_OrganizationCodeLicenseHandler == null)
                    {
                        _OrganizationCodeLicenseHandler = new OrganizationCodeLicenseHandler(RepositoryProvider, ConnectedInfoProvider);
                        _OrganizationCodeLicenseHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _OrganizationCodeLicenseHandler;
            }
        }

        private HealthLicenseHandler _HealthLicenseHandler = null;
        /// <summary> 
        /// 卫生许可证对象
        /// </summary>
        public HealthLicenseHandler HealthLicenseHandler
        {
            get
            {
                lock (this)
                {
                    if (_HealthLicenseHandler == null)
                    {
                        _HealthLicenseHandler = new HealthLicenseHandler(RepositoryProvider, ConnectedInfoProvider);
                        _HealthLicenseHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _HealthLicenseHandler;
            }
        }

        private FoodCirculateLicenseHandler _FoodCirculateLicenseHandler = null;
        /// <summary> 
        /// 食品流通许可证对象
        /// </summary>
        public FoodCirculateLicenseHandler FoodCirculateLicenseHandler
        {
            get
            {
                lock (this)
                {
                    if (_FoodCirculateLicenseHandler == null)
                    {
                        _FoodCirculateLicenseHandler = new FoodCirculateLicenseHandler(RepositoryProvider, ConnectedInfoProvider);
                        _FoodCirculateLicenseHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _FoodCirculateLicenseHandler;
            }
        }

        private TaxRegisterLicenseHandler _TaxRegisterLicenseHandler = null;
        /// <summary> 
        /// 税务登记证对象
        /// </summary>
        public TaxRegisterLicenseHandler TaxRegisterLicenseHandler
        {
            get
            {
                lock (this)
                {
                    if (_TaxRegisterLicenseHandler == null)
                    {
                        _TaxRegisterLicenseHandler = new TaxRegisterLicenseHandler(RepositoryProvider, ConnectedInfoProvider);
                        _TaxRegisterLicenseHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _TaxRegisterLicenseHandler;
            }
        }
      
        #region 不合格药品销毁bussinessHandler注册 20140-2-11
        private DrugsUnqualificationDestroyHandler _DrugsUnqualificationDestroyHandler = null;
        public DrugsUnqualificationDestroyHandler DrugsUnqualificationDestroyHandler
        {
            get
            {
                lock (this)
                {
                    if (_DrugsUnqualificationDestroyHandler == null)
                    {
                        _DrugsUnqualificationDestroyHandler = new DrugsUnqualificationDestroyHandler(RepositoryProvider, ConnectedInfoProvider);
                        _DrugsUnqualificationDestroyHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _DrugsUnqualificationDestroyHandler;
            }
        }
        #endregion

        #region 待处理药品bussinessHandler注册 2014-3-9
        private DrugsUndeterminateHandler _DrugsUndeterminateHandler = null;
        public DrugsUndeterminateHandler DrugsUndeterminateHandler
        {
            get
            {
                lock (this)
                {
                    if (_DrugsUndeterminateHandler == null)
                    {
                        _DrugsUndeterminateHandler = new DrugsUndeterminateHandler(RepositoryProvider, ConnectedInfoProvider);
                        _DrugsUndeterminateHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _DrugsUndeterminateHandler;
            }
        }
        #endregion

        #region 拒收单bussinessHandler注册 2014-3-9
        private DocumentRefuseHandler _DocumentRefuseHandler = null;
        public DocumentRefuseHandler DocumentRefuseHandler
        {
            get
            {
                lock (this)
                {
                    if (_DocumentRefuseHandler == null)
                    {
                        _DocumentRefuseHandler = new DocumentRefuseHandler(RepositoryProvider, ConnectedInfoProvider);
                        _DocumentRefuseHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _DocumentRefuseHandler;
            }
        }
        #endregion

        #region EduDocumentbusinessHandler注册 2014-3-12
       
        private EduDocumentHandler _EduDocumentHandler = null;
        public EduDocumentHandler EduDocumentHandler
        {
            get
            {
                lock (this)
                {
                    if (_EduDocumentHandler == null)
                    {
                        _EduDocumentHandler = new EduDocumentHandler(RepositoryProvider, ConnectedInfoProvider);
                        _EduDocumentHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _EduDocumentHandler;
            }
        }
        #endregion

        #region EduDetailsbussinessHandler注册 2014-3-9
        private EduDetailslHandler _EduDetailslHandler = null;
        public EduDetailslHandler EduDetailslHandler
        {
            get
            {
                lock (this)
                {
                    if (_EduDetailslHandler == null)
                    {
                        _EduDetailslHandler = new EduDetailslHandler(RepositoryProvider, ConnectedInfoProvider);
                        _EduDetailslHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _EduDetailslHandler;
            }
        }
        #endregion

        #region 体检档案bussinessHandler注册 2014-3-9
        private HealthCheckDocumentHandler _HealthCheckDocumentHandler = null;
        public HealthCheckDocumentHandler HealthCheckDocumentHandler
        {
            get
            {
                lock (this)
                {
                    if (_HealthCheckDocumentHandler == null)
                    {
                        _HealthCheckDocumentHandler = new HealthCheckDocumentHandler(RepositoryProvider, ConnectedInfoProvider);
                        _HealthCheckDocumentHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _HealthCheckDocumentHandler;
            }
        }
        #endregion

        #region 体检档案细节bussinessHandler注册 2014-3-9
        private HealthCheckDetailHandler _HealthCheckDetailHandler = null;
        public HealthCheckDetailHandler HealthCheckDetailHandler
        {
            get
            {
                lock (this)
                {
                    if (_HealthCheckDetailHandler == null)
                    {
                        _HealthCheckDetailHandler = new HealthCheckDetailHandler(RepositoryProvider, ConnectedInfoProvider);
                        _HealthCheckDetailHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _HealthCheckDetailHandler;
            }
        }
        #endregion

       

        private DrugsBreakageBusinessHandler _DrugsBreakageBusinessHandler = null;
        /// <summary> 
        /// 报损(DrugsBreakage)对象
        /// </summary>
        public DrugsBreakageBusinessHandler DrugsBreakageBusinessHandler
        {
            get
            {
                lock (this)
                {
                    if (_DrugsBreakageBusinessHandler == null)
                    {
                        _DrugsBreakageBusinessHandler = new DrugsBreakageBusinessHandler(RepositoryProvider, ConnectedInfoProvider);
                        _DrugsBreakageBusinessHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _DrugsBreakageBusinessHandler;
            }
        }

        private DrugsInventoryMoveBusinessHandler _DrugsInventoryMoveBusinessHandler = null;
        /// <summary> 
        /// 报损(DrugsBreakage)对象
        /// </summary>
        public DrugsInventoryMoveBusinessHandler DrugsInventoryMoveBusinessHandler
        {
            get
            {
                lock (this)
                {
                    if (_DrugsInventoryMoveBusinessHandler == null)
                    {
                        _DrugsInventoryMoveBusinessHandler = new DrugsInventoryMoveBusinessHandler(RepositoryProvider, ConnectedInfoProvider);
                        _DrugsInventoryMoveBusinessHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _DrugsInventoryMoveBusinessHandler;
            }
        }
       
        private LnstitutionLegalPersonLicenseBusinessHandler _LnstitutionLegalPersonLicenseBusinessHandler = null;
        /// <summary> 
        /// 报损(DrugsBreakage)对象
        /// </summary>
        public LnstitutionLegalPersonLicenseBusinessHandler LnstitutionLegalPersonLicenseBusinessHandler
        {
            get
            {
                lock (this)
                {
                    if (_LnstitutionLegalPersonLicenseBusinessHandler == null)
                    {
                        _LnstitutionLegalPersonLicenseBusinessHandler = new LnstitutionLegalPersonLicenseBusinessHandler(RepositoryProvider, ConnectedInfoProvider);
                        _LnstitutionLegalPersonLicenseBusinessHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _LnstitutionLegalPersonLicenseBusinessHandler;
            }
        }

        private MmedicalInstitutionPermitBusinessHandler _MmedicalInstitutionPermitBusinessHandler = null;
        /// <summary> 
        /// 报损(DrugsBreakage)对象
        /// </summary>
        public MmedicalInstitutionPermitBusinessHandler MmedicalInstitutionPermitBusinessHandler
        {
            get
            {
                lock (this)
                {
                    if (_MmedicalInstitutionPermitBusinessHandler == null)
                    {
                        _MmedicalInstitutionPermitBusinessHandler = new MmedicalInstitutionPermitBusinessHandler(RepositoryProvider, ConnectedInfoProvider);
                        _MmedicalInstitutionPermitBusinessHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _MmedicalInstitutionPermitBusinessHandler;
            }
        }

        private DirectSalesOrderBusinessHandler _DirectSalesOrderBusinessHandler = null;
        public DirectSalesOrderBusinessHandler DirectSalesOrderBusinessHandler
        {
            get
            {
                lock (this)
                {
                    if (_DirectSalesOrderBusinessHandler == null)
                    {
                        _DirectSalesOrderBusinessHandler = new DirectSalesOrderBusinessHandler(RepositoryProvider, ConnectedInfoProvider);
                        _DirectSalesOrderBusinessHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _DirectSalesOrderBusinessHandler;
            }
        }

        private DirectSalesOrderDetailBusinessHandler _DirectSalesOrderDetailBusinessHandler = null;
        public DirectSalesOrderDetailBusinessHandler DirectSalesOrderDetailBusinessHandler
        {
            get
            {
                lock (this)
                {
                    if (_DirectSalesOrderDetailBusinessHandler == null)
                    {
                        _DirectSalesOrderDetailBusinessHandler = new DirectSalesOrderDetailBusinessHandler(RepositoryProvider, ConnectedInfoProvider);
                        _DirectSalesOrderDetailBusinessHandler.SetBusinessHandlerFactory(this);
                    }
                }
                return _DirectSalesOrderDetailBusinessHandler;
            }
        }

        private WareHouseZonePostionBusinessHandler _WareHouseZonePostionBusinessHandler = null;
        public WareHouseZonePostionBusinessHandler WareHouseZonePostionBusinessHandler
        {
            get
            {
                lock (this)
                {
                    if (_WareHouseZonePostionBusinessHandler == null)
                    {
                        _WareHouseZonePostionBusinessHandler = new WareHouseZonePostionBusinessHandler(RepositoryProvider, ConnectedInfoProvider);
                        _WareHouseZonePostionBusinessHandler.SetBusinessHandlerFactory(this);
                    }
                    return _WareHouseZonePostionBusinessHandler;
                }
            }
        }

        private IndustoryProductCertificateBusinessHandler _IndustoryProductCertificateBusinessHandler = null;
        public IndustoryProductCertificateBusinessHandler IndustoryProductCertificateBusinessHandler
        {
            get
            {
                lock (this)
                {
                    if (_IndustoryProductCertificateBusinessHandler == null)
                    {
                        _IndustoryProductCertificateBusinessHandler = new IndustoryProductCertificateBusinessHandler(RepositoryProvider, ConnectedInfoProvider);
                        _IndustoryProductCertificateBusinessHandler.SetBusinessHandlerFactory(this);
                    }
                    return _IndustoryProductCertificateBusinessHandler;
                }
            }
        }

        public void Dispose()
		{
			
			 
			if(_ApprovalFlowBusinessHandler!=null)
			{
				_ApprovalFlowBusinessHandler.Dispose();
			} 
			 
			if(_ApprovalFlowNodeBusinessHandler!=null)
			{
				_ApprovalFlowNodeBusinessHandler.Dispose();
			} 
			 
			if(_ApprovalFlowTypeBusinessHandler!=null)
			{
				_ApprovalFlowTypeBusinessHandler.Dispose();
			} 
			 
			if(_ApprovalFlowRecordBusinessHandler!=null)
			{
				_ApprovalFlowRecordBusinessHandler.Dispose();
			} 
			 
			if(_BillDocumentCodeBusinessHandler!=null)
			{
				_BillDocumentCodeBusinessHandler.Dispose();
			} 
			 
			if(_BusinessScopeBusinessHandler!=null)
			{
				_BusinessScopeBusinessHandler.Dispose();
			} 
			 
			if(_BusinessScopeCategoryBusinessHandler!=null)
			{
				_BusinessScopeCategoryBusinessHandler.Dispose();
			} 
			 
			if(_BusinessTypeBusinessHandler!=null)
			{
				_BusinessTypeBusinessHandler.Dispose();
			} 
			 
			if(_BusinessTypeManageCategoryDetailBusinessHandler!=null)
			{
				_BusinessTypeManageCategoryDetailBusinessHandler.Dispose();
			} 
			 
			if(_GoodsAdditionalPropertyBusinessHandler!=null)
			{
				_GoodsAdditionalPropertyBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseCashOrderBusinessHandler!=null)
			{
				_PurchaseCashOrderBusinessHandler.Dispose();
			} 
			 
			if(_DeliveryBusinessHandler!=null)
			{
				_DeliveryBusinessHandler.Dispose();
			} 
			 
			if(_DepartmentBusinessHandler!=null)
			{
				_DepartmentBusinessHandler.Dispose();
			} 
			 
			if(_DistrictBusinessHandler!=null)
			{
				_DistrictBusinessHandler.Dispose();
			} 
			 
			if(_DoubtDrugBusinessHandler!=null)
			{
				_DoubtDrugBusinessHandler.Dispose();
			} 
			 
			if(_DrugApprovalNumberBusinessHandler!=null)
			{
				_DrugApprovalNumberBusinessHandler.Dispose();
			} 
			 
			if(_DrugCategoryBusinessHandler!=null)
			{
				_DrugCategoryBusinessHandler.Dispose();
			} 
			 
			if(_DrugClinicalCategoryBusinessHandler!=null)
			{
				_DrugClinicalCategoryBusinessHandler.Dispose();
			} 
			 
			if(_DictionaryDosageBusinessHandler!=null)
			{
				_DictionaryDosageBusinessHandler.Dispose();
			} 
			 
			if(_DrugInfoBusinessHandler!=null)
			{
				_DrugInfoBusinessHandler.Dispose();
			} 
			 
			if(_DrugInventoryRecordBusinessHandler!=null)
			{
				_DrugInventoryRecordBusinessHandler.Dispose();
			} 
			 
			if(_DrugMaintainRecordBusinessHandler!=null)
			{
				_DrugMaintainRecordBusinessHandler.Dispose();
			} 
			 
			if(_DrugMaintainRecordDetailBusinessHandler!=null)
			{
				_DrugMaintainRecordDetailBusinessHandler.Dispose();
			} 
			 
			if(_DictionaryMeasurementUnitBusinessHandler!=null)
			{
				_DictionaryMeasurementUnitBusinessHandler.Dispose();
			} 
			 
			if(_DictionaryPiecemealUnitBusinessHandler!=null)
			{
				_DictionaryPiecemealUnitBusinessHandler.Dispose();
			} 
			 
			if(_DictionarySpecificationBusinessHandler!=null)
			{
				_DictionarySpecificationBusinessHandler.Dispose();
			} 
			 
			if(_DictionaryStorageTypeBusinessHandler!=null)
			{
				_DictionaryStorageTypeBusinessHandler.Dispose();
			} 
			 
			if(_DictionaryUserDefinedTypeBusinessHandler!=null)
			{
				_DictionaryUserDefinedTypeBusinessHandler.Dispose();
			} 
			 
			if(_AuthorizationDocBusinessHandler!=null)
			{
				_AuthorizationDocBusinessHandler.Dispose();
			} 
			 
			if(_DrugMaintainSetBusinessHandler!=null)
			{
				_DrugMaintainSetBusinessHandler.Dispose();
			} 
			 
			if(_EmployeeBusinessHandler!=null)
			{
				_EmployeeBusinessHandler.Dispose();
			} 
			 
			if(_GMSPLicenseBusinessScopeBusinessHandler!=null)
			{
				_GMSPLicenseBusinessScopeBusinessHandler.Dispose();
			} 
			 
			if(_InventoryRecordBusinessHandler!=null)
			{
				_InventoryRecordBusinessHandler.Dispose();
			} 
			 
			if(_ManufacturerBusinessHandler!=null)
			{
				_ManufacturerBusinessHandler.Dispose();
			} 
			 
			if(_PackagingMaterialBusinessHandler!=null)
			{
				_PackagingMaterialBusinessHandler.Dispose();
			} 
			 
			if(_PackagingUnitBusinessHandler!=null)
			{
				_PackagingUnitBusinessHandler.Dispose();
			} 
			 
			if(_PaymentMethodBusinessHandler!=null)
			{
				_PaymentMethodBusinessHandler.Dispose();
			} 
			 
			if(_GSPLicenseBusinessHandler!=null)
			{
				_GSPLicenseBusinessHandler.Dispose();
			} 
			 
			if(_GMPLicenseBusinessHandler!=null)
			{
				_GMPLicenseBusinessHandler.Dispose();
			} 
			 
			if(_BusinessLicenseBusinessHandler!=null)
			{
				_BusinessLicenseBusinessHandler.Dispose();
			} 
			 
			if(_MedicineProductionLicenseBusinessHandler!=null)
			{
				_MedicineProductionLicenseBusinessHandler.Dispose();
			} 
			 
			if(_MedicineBusinessLicenseBusinessHandler!=null)
			{
				_MedicineBusinessLicenseBusinessHandler.Dispose();
			} 
			 
			if(_InstrumentsBusinessLicenseBusinessHandler!=null)
			{
				_InstrumentsBusinessLicenseBusinessHandler.Dispose();
			} 
			 
			if(_InstrumentsProductionLicenseBusinessHandler!=null)
			{
				_InstrumentsProductionLicenseBusinessHandler.Dispose();
			} 
			 
			if(_MedicalCategoryBusinessHandler!=null)
			{
				_MedicalCategoryBusinessHandler.Dispose();
			} 
			 
			if(_MedicalCategoryDetailBusinessHandler!=null)
			{
				_MedicalCategoryDetailBusinessHandler.Dispose();
			} 
			 
			if(_ModuleBusinessHandler!=null)
			{
				_ModuleBusinessHandler.Dispose();
			} 
			 
			if(_ModuleCatetoryBusinessHandler!=null)
			{
				_ModuleCatetoryBusinessHandler.Dispose();
			} 
			 
			if(_ModuleWithRoleBusinessHandler!=null)
			{
				_ModuleWithRoleBusinessHandler.Dispose();
			} 
			 
			if(_PharmacyFileBusinessHandler!=null)
			{
				_PharmacyFileBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseAgreementBusinessHandler!=null)
			{
				_PurchaseAgreementBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseCheckingOrderBusinessHandler!=null)
			{
				_PurchaseCheckingOrderBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseCheckingOrderDetailBusinessHandler!=null)
			{
				_PurchaseCheckingOrderDetailBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseInInventeryOrderBusinessHandler!=null)
			{
				_PurchaseInInventeryOrderBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseInInventeryOrderDetailBusinessHandler!=null)
			{
				_PurchaseInInventeryOrderDetailBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseManageCategoryBusinessHandler!=null)
			{
				_PurchaseManageCategoryBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseManageCategoryDetailBusinessHandler!=null)
			{
				_PurchaseManageCategoryDetailBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseOrderBusinessHandler!=null)
			{
				_PurchaseOrderBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseOrderDetailBusinessHandler!=null)
			{
				_PurchaseOrderDetailBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseOrderReturnBusinessHandler!=null)
			{
				_PurchaseOrderReturnBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseOrderReturnDetailBusinessHandler!=null)
			{
				_PurchaseOrderReturnDetailBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseReceivingOrderBusinessHandler!=null)
			{
				_PurchaseReceivingOrderBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseReceivingOrderDetailBusinessHandler!=null)
			{
				_PurchaseReceivingOrderDetailBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseUnitBusinessHandler!=null)
			{
				_PurchaseUnitBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseUnitBuyerBusinessHandler!=null)
			{
				_PurchaseUnitBuyerBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseUnitDelivererBusinessHandler!=null)
			{
				_PurchaseUnitDelivererBusinessHandler.Dispose();
			} 
			 
			if(_PurchaseUnitTypeBusinessHandler!=null)
			{
				_PurchaseUnitTypeBusinessHandler.Dispose();
			} 
			 
			if(_PurchasingPlanBusinessHandler!=null)
			{
				_PurchasingPlanBusinessHandler.Dispose();
			} 
			 
			if(_PurchasingPlanDetailBusinessHandler!=null)
			{
				_PurchasingPlanDetailBusinessHandler.Dispose();
			} 
			 
			if(_RarewordBusinessHandler!=null)
			{
				_RarewordBusinessHandler.Dispose();
			} 
			 
			if(_RetailMemberBusinessHandler!=null)
			{
				_RetailMemberBusinessHandler.Dispose();
			} 
			 
			if(_RetailOrderBusinessHandler!=null)
			{
				_RetailOrderBusinessHandler.Dispose();
			} 
			 
			if(_RetailOrderDetailBusinessHandler!=null)
			{
				_RetailOrderDetailBusinessHandler.Dispose();
			} 
			 
			if(_RoleBusinessHandler!=null)
			{
				_RoleBusinessHandler.Dispose();
			} 
			 
			if(_RoleWithUserBusinessHandler!=null)
			{
				_RoleWithUserBusinessHandler.Dispose();
			} 
			 
			if(_SalesOrderBusinessHandler!=null)
			{
				_SalesOrderBusinessHandler.Dispose();
			} 
			 
			if(_SalesOrderDeliverDetailBusinessHandler!=null)
			{
				_SalesOrderDeliverDetailBusinessHandler.Dispose();
			} 
			 
			if(_SalesOrderDeliverRecordBusinessHandler!=null)
			{
				_SalesOrderDeliverRecordBusinessHandler.Dispose();
			} 
			 
			if(_SalesOrderDetailBusinessHandler!=null)
			{
				_SalesOrderDetailBusinessHandler.Dispose();
			} 
			 
			if(_SalesOrderReturnBusinessHandler!=null)
			{
				_SalesOrderReturnBusinessHandler.Dispose();
			} 
			 
			if(_SalesOrderReturnDetailBusinessHandler!=null)
			{
				_SalesOrderReturnDetailBusinessHandler.Dispose();
			} 
			 
			if(_OutInventoryBusinessHandler!=null)
			{
				_OutInventoryBusinessHandler.Dispose();
			} 
			 
			if(_SetSpeicalDrugRecordBusinessHandler!=null)
			{
				_SetSpeicalDrugRecordBusinessHandler.Dispose();
			} 
			 
			if(_SpecialDrugCategoryBusinessHandler!=null)
			{
				_SpecialDrugCategoryBusinessHandler.Dispose();
			} 
			 
			if(_StoreBusinessHandler!=null)
			{
				_StoreBusinessHandler.Dispose();
			} 
			 
			if(_SupplyUnitBusinessHandler!=null)
			{
				_SupplyUnitBusinessHandler.Dispose();
			} 
			 
			if(_SupplyUnitSalesmanBusinessHandler!=null)
			{
				_SupplyUnitSalesmanBusinessHandler.Dispose();
			} 
			 
			if(_TaxRateBusinessHandler!=null)
			{
				_TaxRateBusinessHandler.Dispose();
			} 
			 
			if(_UnitTypeBusinessHandler!=null)
			{
				_UnitTypeBusinessHandler.Dispose();
			} 
			 
			if(_UploadRecordBusinessHandler!=null)
			{
				_UploadRecordBusinessHandler.Dispose();
			} 
			 
			if(_UserBusinessHandler!=null)
			{
				_UserBusinessHandler.Dispose();
			} 
			 
			if(_UserLogBusinessHandler!=null)
			{
				_UserLogBusinessHandler.Dispose();
			} 
			 
			if(_VehicleBusinessHandler!=null)
			{
				_VehicleBusinessHandler.Dispose();
			} 
			 
			if(_WarehouseBusinessHandler!=null)
			{
				_WarehouseBusinessHandler.Dispose();
			} 
			 
			if(_WarehouseZoneBusinessHandler!=null)
			{
				_WarehouseZoneBusinessHandler.Dispose();
			} 
			 
			if(_WaringSetBusinessHandler!=null)
			{
				_WaringSetBusinessHandler.Dispose();
			} 
			 
			if(_OutInventoryDetailBusinessHandler!=null)
			{
				_OutInventoryDetailBusinessHandler.Dispose();
			} 

			if(_DrugsUnqualificationHandler!=null)
			{
                _DrugsUnqualificationHandler.Dispose();
			}

            if (_DrugsUnqualificationDestroyHandler != null)
            {
                _DrugsUnqualificationDestroyHandler.Dispose();
            }

            if (_DrugsUndeterminateHandler != null)
            {
                _DrugsUndeterminateHandler.Dispose();
            }
            if (_DocumentRefuseHandler != null)
            {
                _DocumentRefuseHandler.Dispose();
            }
            if (_EduDetailslHandler != null)
            {
                _EduDetailslHandler.Dispose();
            }

            if (_EduDocumentHandler != null)
            {
                _EduDocumentHandler.Dispose();
            }
            if (_HealthCheckDetailHandler != null)
            {
                _HealthCheckDetailHandler.Dispose();
            }
            if (_HealthCheckDocumentHandler != null)
            {
                _HealthCheckDocumentHandler.Dispose();
            }

            
            if (_LnstitutionLegalPersonLicenseBusinessHandler != null)
            {
                _LnstitutionLegalPersonLicenseBusinessHandler.Dispose();
            }
            if (_MmedicalInstitutionPermitBusinessHandler != null)
            {
                _MmedicalInstitutionPermitBusinessHandler.Dispose();
            }
            if (_DirectSalesOrderBusinessHandler != null)
            {
                _DirectSalesOrderBusinessHandler.Dispose();
            }
            if (_DirectSalesOrderDetailBusinessHandler != null)
            {
                _DirectSalesOrderDetailBusinessHandler.Dispose();
            }
            if (_WareHouseZonePostionBusinessHandler != null)
            {
                _WareHouseZonePostionBusinessHandler.Dispose();
            }
            if (_IndustoryProductCertificateBusinessHandler != null)
            {
                _IndustoryProductCertificateBusinessHandler.Dispose();
            }
		}

	}
}
