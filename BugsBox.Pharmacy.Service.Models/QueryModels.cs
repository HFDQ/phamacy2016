
 
 
 
 
 

 



using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text; 

namespace BugsBox.Pharmacy.Service.Models
{
	//此代码由QueryModels.tt 
	  
	/// <summary>
    /// 审批结点服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryApprovalFlowModel
    {
        [DataMember]
        public Guid FlowId { get; set; }
        [DataMember]
        public int SubFlowIdFrom { get; set; }
        [DataMember]
        public int SubFlowIdTo { get; set; }
        [DataMember]
        public int StatusFrom = 1;
        [DataMember]
        public int StatusTo = 16;
        [DataMember]
        public string ChangeNote { get; set; }
        [DataMember]
        public Guid CreateUserId { get; set; }
        [DataMember]
        public Guid UpdateUserId { get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
        public Guid ApprovalFlowTypeId { get; set; }
        [DataMember]
        public Guid NextNodeID { get; set; }
        [DataMember]
        public Guid StoreId { get; set; }

	}
     
	/// <summary>
    /// 审批结点服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryApprovalFlowNodeModel
    {
        [DataMember]
		public int OrderFrom;
        [DataMember]
		public int OrderTo;
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Decription { get; set; }
        [DataMember]
        public Guid CreateUserId { get; set; }
        [DataMember]
        public Guid UpdateUserId { get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
        public Guid StoreId { get; set; }
        [DataMember]
        public Guid RoleId { get; set; }
        [DataMember]
        public Guid ApprovalFlowTypeId { get; set; }

        [DataMember]
        public Guid approvalFlowId { get; set; }

	}
     
	/// <summary>
    /// 审批流程类型服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryApprovalFlowTypeModel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Decription { get; set; }
        [DataMember]
        public int ApprovalTypeValueFrom = 1;
        [DataMember]
        public int ApprovalTypeValueTo = 9;
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 审批流程记录服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryApprovalFlowRecordModel
    {
        [DataMember]
		public Guid FlowId{ get; set; }
        [DataMember]
		public int SubFlowIdFrom;
        [DataMember]
		public int SubFlowIdTo;
        [DataMember]
		public Guid ApproveUserId{ get; set; }
        [DataMember]
		public DateTime ApproveTimeFrom;
        [DataMember]
		public DateTime ApproveTimeTo;
        [DataMember]
		public string Comment{ get; set; }
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid ApprovalFlowNodeId{ get; set; }
        [DataMember]
		public Guid ApprovalFlowId{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 单据编号服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryBillDocumentCodeModel
    {
        [DataMember]
		public bool Locked{ get; set; }
        [DataMember]
		public bool QueryLocked=false;
        [DataMember]
		public bool Used{ get; set; }
        [DataMember]
		public bool QueryUsed=false;
        [DataMember]
		public Guid UsedId{ get; set; }
        [DataMember]
		public bool Canceled{ get; set; }
        [DataMember]
		public bool QueryCanceled=false;
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public int BillDocumentTypeValueFrom=0;
        [DataMember]
		public int BillDocumentTypeValueTo=100;
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 经营范围服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryBusinessScopeModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid BusinessScopeCategoryId{ get; set; }

	}
     
	/// <summary>
    /// 经营范围分类服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryBusinessScopeCategoryModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 经营方式服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryBusinessTypeModel
    {
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 经营方式的管理要求分类详细服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryBusinessTypeManageCategoryDetailModel
    {
        [DataMember]
		public Guid PurchaseManageCategoryDetailId{ get; set; }
        [DataMember]
		public Guid BusinessTypeId{ get; set; }

	}
     
	/// <summary>
    /// 商品附加属性服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryGoodsAdditionalPropertyModel
    {
        [DataMember]
		public string CareFunction{ get; set; }
        [DataMember]
		public string PutOnRecord{ get; set; }
        [DataMember]
		public DateTime PutOnRecordDateFrom;
        [DataMember]
		public DateTime PutOnRecordDateTo;
        [DataMember]
		public string NotSuitablePeople{ get; set; }
        [DataMember]
		public string SuitablePeople{ get; set; }
        [DataMember]
		public string LandmarkIngredient{ get; set; }
        [DataMember]
		public DateTime LicensePermissionDateFrom;
        [DataMember]
		public DateTime LicensePermissionDateTo;
        [DataMember]
		public string UsageAndDosage{ get; set; }
        [DataMember]
		public string MainIngredient{ get; set; }
        [DataMember]
		public string ProductAddress{ get; set; }
        [DataMember]
		public string ProductAddressEnglish{ get; set; }
        [DataMember]
		public string ProductCountry{ get; set; }
        [DataMember]
		public string ProductCountryEnglish{ get; set; }
        [DataMember]
		public string HealthPermit{ get; set; }
        [DataMember]
		public string RegCode{ get; set; }
        [DataMember]
		public string RegProxyCompany{ get; set; }
        [DataMember]
		public string FactoryNameEnglish{ get; set; }
        [DataMember]
		public string FactoryAddress{ get; set; }
        [DataMember]
		public string FactoryAddressEnglish{ get; set; }
        [DataMember]
		public Guid DrugInfoId{ get; set; }

	}
     
	/// <summary>
    /// 采购结算单服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseCashOrderModel
    {
        [DataMember]
		public string DocumentNumber{ get; set; }
        [DataMember]
		public DateTime OperateTimeFrom{ get; set; }
        [DataMember]
		public DateTime OperateTimeTo{ get; set; }
        [DataMember]
		public Guid OperateUserId{ get; set; }
        [DataMember]
        public int OrderStatusValueFrom = 1;
        [DataMember]
        public int OrderStatusValueTo = 110;
        [DataMember]
		public Guid ApprovalUserId{ get; set; }
        [DataMember]
		public string ApprovalDecription{ get; set; }
        [DataMember]
		public DateTime PaymentTimeFrom;
        [DataMember]
		public DateTime PaymentTimeTo;
        [DataMember]
		public Guid PaymentMethodId{ get; set; }
        [DataMember]
		public decimal PaymentedAmountFrom;
        [DataMember]
		public decimal PaymentedAmountTo;
        [DataMember]
		public decimal PaymentingAmountFrom;
        [DataMember]
		public decimal PaymentingAmountTo;
        [DataMember]
		public decimal PaymentAmountFrom;
        [DataMember]
		public decimal PaymentAmountTo;
        [DataMember]
		public int DealerMethodValueFrom;
        [DataMember]
		public int DealerMethodValueTo;
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public Guid RelatedOrderId{ get; set; }
        [DataMember]
		public string RelatedOrderDocumentNumber{ get; set; }
        [DataMember]
		public int RelatedOrderTypeValueFrom;
        [DataMember]
		public int RelatedOrderTypeValueTo;
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PurchaseOrderId{ get; set; }

	}
     
	/// <summary>
    /// 配送信息服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDeliveryModel
    {
        [DataMember]
		public DateTime DeliveryTimeFrom;
        [DataMember]
		public DateTime DeliveryTimeTo;
        [DataMember]
		public string ShippingAddress{ get; set; }
        [DataMember]
		public Guid ReceivingCompasnyID{ get; set; }
        [DataMember]
		public string DeliveryAddress{ get; set; }
        [DataMember]
		public string ManifestNumber{ get; set; }
        [DataMember]
		public int DrugsCountFrom;
        [DataMember]
		public int DrugsCountTo;
        [DataMember]
        public int DeliveryMethodValueFrom = 1;
        [DataMember]
        public int DeliveryMethodValueTo = 2;
        [DataMember]
        public int TransportMethodValueFrom = 1;
        [DataMember]
        public int TransportMethodValueTo = 3;
        [DataMember]
		public string Principal{ get; set; }
        [DataMember]
		public string PrincipalPhone{ get; set; }
        [DataMember]
		public string TransportCompany{ get; set; }
        [DataMember]
		public string VehicleInfo{ get; set; }
        [DataMember]
		public Guid VehicleID{ get; set; }
        [DataMember]
		public int DeliveryStatusValueFrom;
        [DataMember]
		public int DeliveryStatusValueTo;
        [DataMember]
		public string Memo{ get; set; }
        [DataMember]
		public bool IsOver{ get; set; }
        [DataMember]
		public bool QueryIsOver=false;
        [DataMember]
		public DateTime ReservationTimeFrom;
        [DataMember]
		public DateTime ReservationTimeTo;
        [DataMember]
		public Guid ReservationOperatorId{ get; set; }
        [DataMember]
		public string ReservationNo{ get; set; }
        [DataMember]
		public DateTime AcceptedTimeFrom;
        [DataMember]
		public DateTime AcceptedTimeTo;
        [DataMember]
		public Guid AcceptedOperatorId{ get; set; }
        [DataMember]
		public string AcceptedNo{ get; set; }
        [DataMember]
		public DateTime CanceledTimeFrom;
        [DataMember]
		public DateTime CanceledTimeTo;
        [DataMember]
		public Guid CanceledOperatorId{ get; set; }
        [DataMember]
		public string CanceledNo{ get; set; }
        [DataMember]
		public DateTime outedTimeFrom;
        [DataMember]
		public DateTime outedTimeTo;
        [DataMember]
		public Guid outedOperatorId{ get; set; }
        [DataMember]
		public string outedNo{ get; set; }
        [DataMember]
		public DateTime SignedTimeFrom;
        [DataMember]
		public DateTime SignedTimeTo;
        [DataMember]
		public Guid SignedOperatorId{ get; set; }
        [DataMember]
		public string SignedNo{ get; set; }
        [DataMember]
		public DateTime ReturnTimeFrom;
        [DataMember]
		public DateTime ReturnTimeTo;
        [DataMember]
		public Guid ReturnOperatorId{ get; set; }
        [DataMember]
		public string ReturnNo{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid OrderID{ get; set; }
        [DataMember]
		public Guid OutInventoryID{ get; set; }
        [DataMember]
		public Guid OwnVehicleID{ get; set; }

	}
     
	/// <summary>
    /// 部门服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDepartmentModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid DepartmentId{ get; set; }

	}
     
	/// <summary>
    /// 区域服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDistrictModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 疑问药品服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDoubtDrugModel
    {
        [DataMember]
		public string JsonDrugInventoryRecord{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public bool Handled{ get; set; }
        [DataMember]
		public bool QueryHandled=false;
        [DataMember]
		public string HandleDecription{ get; set; }
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid DrugInventoryRecordId{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 药品批准文号服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugApprovalNumberModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 药物分类服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugCategoryModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 药物临床分类服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugClinicalCategoryModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 剂型服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDictionaryDosageModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 药品信息服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugInfoModel
    {
        [DataMember]
		public string PermitLicenseCode{ get; set; }
        [DataMember]
		public DateTime PermitDateFrom;
        [DataMember]
		public DateTime PermitDateTo;
        [DataMember]
		public DateTime PermitOutDateFrom{ get; set; }
        [DataMember]
		public DateTime PermitOutDateTo{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public string Description{ get; set; }
        [DataMember]
		public string BarCode{ get; set; }
        [DataMember]
		public string StandardCode{ get; set; }
        [DataMember]
		public string ProductName{ get; set; }
        [DataMember]
		public string ProductEnglishName{ get; set; }
        [DataMember]
		public string ProductGeneralName{ get; set; }
        [DataMember]
		public string ProductOtherName{ get; set; }
        [DataMember]
		public string FactoryName{ get; set; }
        [DataMember]
		public string FactoryNameAbbreviation{ get; set; }
        [DataMember]
		public string PiecemealSpecification{ get; set; }
        [DataMember]
		public int PiecemealNumberFrom;
        [DataMember]
		public int PiecemealNumberTo;
        [DataMember]
		public decimal PriceFrom;
        [DataMember]
		public decimal PriceTo;
        [DataMember]
		public decimal NationalSalePriceFrom;
        [DataMember]
		public decimal NationalSalePriceTo;
        [DataMember]
		public decimal PurchasePriceFrom;
        [DataMember]
		public decimal PurchasePriceTo;
        [DataMember]
		public decimal SalePriceFrom;
        [DataMember]
		public decimal SalePriceTo;
        [DataMember]
		public decimal WholeSalePriceFrom;
        [DataMember]
		public decimal WholeSalePriceTo;
        [DataMember]
		public decimal RetailPriceFrom;
        [DataMember]
		public decimal RetailPriceTo;
        [DataMember]
		public decimal TagPriceFrom;
        [DataMember]
		public decimal TagPriceTo;
        [DataMember]
		public decimal LowSalePriceFrom;
        [DataMember]
		public decimal LowSalePriceTo;
        [DataMember]
		public decimal LimitedLowPriceFrom;
        [DataMember]
		public decimal LimitedLowPriceTo;
        [DataMember]
		public decimal LimitedUpPriceFrom;
        [DataMember]
		public decimal LimitedUpPriceTo;
        [DataMember]
		public bool IsMedicalInsurance{ get; set; }
        [DataMember]
		public bool QueryIsMedicalInsurance=false;
        [DataMember]
		public bool IsPrescription{ get; set; }
        [DataMember]
		public bool QueryIsPrescription=false;
        [DataMember]
		public bool IsImport{ get; set; }
        [DataMember]
		public bool QueryIsImport=false;
        [DataMember]
		public bool IsMainMaintenance{ get; set; }
        [DataMember]
		public bool QueryIsMainMaintenance=false;
        [DataMember]
		public bool IsSpecialDrugCategory{ get; set; }
        [DataMember]
		public bool QueryIsSpecialDrugCategory=false;
        [DataMember]
		public string SpecialDrugCategoryCode{ get; set; }
        [DataMember]
		public int ValidPeriodFrom;
        [DataMember]
		public int ValidPeriodTo;
        [DataMember]
		public string LicensePermissionNumber{ get; set; }
        [DataMember]
		public string PerformanceStandards{ get; set; }
        [DataMember]
		public string Package{ get; set; }
        [DataMember]
		public int PackageAmountFrom;
        [DataMember]
		public int PackageAmountTo;
        [DataMember]
		public bool IsApproval{ get; set; }
        [DataMember]
		public bool QueryIsApproval=false;
        [DataMember]
		public DateTime ApprovalDateFrom;
        [DataMember]
		public DateTime ApprovalDateTo;
        [DataMember]
		public int MaxInventoryCountFrom;
        [DataMember]
		public int MaxInventoryCountTo;
        [DataMember]
		public int MinInventoryCountFrom;
        [DataMember]
		public int MinInventoryCountTo;
        [DataMember]
		public string Origin{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public string ValidRemark{ get; set; }
        [DataMember]
		public bool IsLock{ get; set; }
        [DataMember]
		public bool QueryIsLock=false;
        [DataMember]
		public string LockRemark{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string BusinessScopeCode{ get; set; }
        [DataMember]
		public string PurchaseManageCategoryDetailCode{ get; set; }
        [DataMember]
		public string DrugCategoryCode{ get; set; }
        [DataMember]
		public string MedicalCategoryDetailCode{ get; set; }
        [DataMember]
		public string DrugClinicalCategoryCode{ get; set; }
        [DataMember]
		public string DictionaryUserDefinedTypeCode{ get; set; }
        [DataMember]
		public string DrugStorageTypeCode{ get; set; }
        [DataMember]
		public string DictionaryMeasurementUnitCode{ get; set; }
        [DataMember]
		public string DictionaryDosageCode{ get; set; }
        [DataMember]
		public string DictionarySpecificationCode{ get; set; }
        [DataMember]
		public string DictionaryPiecemealUnitCode{ get; set; }
        [DataMember]
		public Guid FlowID{ get; set; }
        [DataMember]
		public int GoodsTypeValueFrom=0;
        [DataMember]
		public int GoodsTypeValueTo=99999;
        [DataMember]
        public int ApprovalStatusValueFrom = 1;
        [DataMember]
        public int ApprovalStatusValueTo = 16;

	}
     
	/// <summary>
    /// 药物库存服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugInventoryRecordModel
    {
        [DataMember]
		public decimal PurchasePricceFrom;
        [DataMember]
		public decimal PurchasePricceTo;
        [DataMember]
		public string BatchNumber{ get; set; }
        [DataMember]
		public DateTime PruductDateFrom;
        [DataMember]
		public DateTime PruductDateTo;
        [DataMember]
		public DateTime OutValidDateFrom;
        [DataMember]
		public DateTime OutValidDateTo;
        [DataMember]
		public bool IsOutValidDate{ get; set; }
        [DataMember]
		public bool QueryIsOutValidDate=false;
        [DataMember]
		public int InInventoryCountFrom;
        [DataMember]
		public int InInventoryCountTo;
        [DataMember]
		public int SalesCountFrom;
        [DataMember]
		public int SalesCountTo;
        [DataMember]
		public int OnSalesOrderCountFrom;
        [DataMember]
		public int OnSalesOrderCountTo;
        [DataMember]
		public int CurrentInventoryCountFrom;
        [DataMember]
		public int CurrentInventoryCountTo;
        [DataMember]
		public int RetailCountFrom;
        [DataMember]
		public int RetailCountTo;
        [DataMember]
		public int DismantingAmountFrom;
        [DataMember]
		public int DismantingAmountTo;
        [DataMember]
		public int RetailDismantingAmountFrom;
        [DataMember]
		public int RetailDismantingAmountTo;
        [DataMember]
		public int OnRetailCountFrom;
        [DataMember]
		public int OnRetailCountTo;
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public int CanSaleNumFrom;
        [DataMember]
		public int CanSaleNumTo;
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
        public int DurgInventoryTypeValueFrom = 1;
        [DataMember]
        public int DurgInventoryTypeValueTo = 100;
        [DataMember]
		public Guid DrugInfoId{ get; set; }
        [DataMember]
		public Guid PurchaseInInventeryOrderDetailId{ get; set; }
        [DataMember]
		public Guid WarehouseZoneId{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 药品养护记录服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugMaintainRecordModel
    {
        [DataMember]
		public string BillDocumentNo{ get; set; }
        [DataMember]
		public DateTime ExpirationDateFrom{ get; set; }
        [DataMember]
        public DateTime ExpirationDateTo { get; set; }
        [DataMember]
        public int DrugMaintainTypeValueFrom = 0;
        [DataMember]
        public int DrugMaintainTypeValueTo = 1;
        [DataMember]
		public int CompleteStateFrom=0;
        [DataMember]
		public int CompleteStateTo=100;
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
        public Guid CreateUserId { get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }

	}
     
	/// <summary>
    /// 药品养护记录明细服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugMaintainRecordDetailModel
    {
        [DataMember]
		public Guid DrugInventoryRecordId{ get; set; }
        [DataMember]
		public string BillDocumentNo{ get; set; }
        [DataMember]
		public string ProductName{ get; set; }
        [DataMember]
		public string DictionaryDosageCode{ get; set; }
        [DataMember]
		public string DictionarySpecificationCode{ get; set; }
        [DataMember]
        public int CurrentInventoryCountFrom = 0;
        [DataMember]
		public int CurrentInventoryCountTo=999999;
        [DataMember]
		public int MaintainCountFrom=0;
        [DataMember]
		public int MaintainCountTo=999999;
        [DataMember]
		public decimal PriceFrom;
        [DataMember]
		public decimal PriceTo;
        [DataMember]
		public string Origin{ get; set; }
        [DataMember]
		public string LicensePermissionNumber{ get; set; }
        [DataMember]
		public string BatchNumber{ get; set; }
        [DataMember]
        public DateTime PruductDateFrom { get; set; }
        [DataMember]
        public DateTime PruductDateTo { get; set; }
        [DataMember]
        public DateTime OutValidDateFrom { get; set; }
        [DataMember]
        public DateTime OutValidDateTo { get; set; }
        [DataMember]
		public string Manufacturer{ get; set; }
        [DataMember]
		public string CheckqualifiedNumber{ get; set; }
        [DataMember]
		public string CheckResult{ get; set; }

	}
     
	/// <summary>
    /// 计量单位服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDictionaryMeasurementUnitModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 拆零单位服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDictionaryPiecemealUnitModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 药物规格服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDictionarySpecificationModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Code{ get; set; }

	}
     
	/// <summary>
    /// 储藏方式服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDictionaryStorageTypeModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 用户自定义药物类型服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDictionaryUserDefinedTypeModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 授权书服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryAuthorizationDocModel
    {
        [DataMember]
		public string DocFile{ get; set; }
        [DataMember]
		public string Description{ get; set; }
        [DataMember]
        public DateTime OutDateFrom { get; set; }
        [DataMember]
        public DateTime OutDateTo { get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public bool IsOutDate{ get; set; }
        [DataMember]
		public bool QueryIsOutDate=false;
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public int DistrictIdFrom;
        [DataMember]
		public int DistrictIdTo;

	}
     
	/// <summary>
    /// 药品养护设置服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugMaintainSetModel
    {
        [DataMember]
		public int DrugMaintainTypeValueFrom=0;
        [DataMember]
		public int DrugMaintainTypeValueTo=100;
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public int DayFrom=0;
        [DataMember]
		public int DayTo=999999;
        [DataMember]
        public DateTime StartDateFrom { get; set; }
        [DataMember]
        public DateTime StartDateTo { get; set; }
        [DataMember]
		public int RemindBeforeDayFrom=0;
        [DataMember]
		public int RemindBeforeDayTo=100;

	}
     
	/// <summary>
    /// 员工服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryEmployeeModel
    {
        [DataMember]
        public DateTime OutDateFrom { get; set; }
        [DataMember]
        public DateTime OutDateTo { get; set; }
        [DataMember]
		public string Number{ get; set; }
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Pinyin{ get; set; }
        [DataMember]
		public string Gender{ get; set; }
        [DataMember]
		public string Phone{ get; set; }
        [DataMember]
		public string Email{ get; set; }
        [DataMember]
		public string Address{ get; set; }
        [DataMember]
		public string Rank{ get; set; }
        [DataMember]
		public string Education{ get; set; }
        [DataMember]
		public string Duty{ get; set; }
        [DataMember]
		public string Specility{ get; set; }
        [DataMember]
        public int EmployStatusValueFrom = 0;
        [DataMember]
        public int EmployStatusValueTo = 1;
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
        public int PharmacistsTitleTypeValueFrom = 0;
        [DataMember]
        public int PharmacistsTitleTypeValueTo = 6;
        [DataMember]
		public string CardNo{ get; set; }
        [DataMember]
        public int PharmacistsQualificationValueFrom = 0;
        [DataMember]
        public int PharmacistsQualificationValueTo = 3;
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid DepartmentId{ get; set; }

	}
     
	/// <summary>
    /// GMSP证书规定的经营范围服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryGMSPLicenseBusinessScopeModel
    {
        [DataMember]
		public Guid LicenseId{ get; set; }
        [DataMember]
		public Guid BusinessScopeId{ get; set; }
        [DataMember]
		public Guid GSPLicenseId{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 库存服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryInventoryRecordModel
    {
        [DataMember]
		public int MaxInventoryCountFrom;
        [DataMember]
		public int MaxInventoryCountTo;
        [DataMember]
		public int MinInventoryCountFrom;
        [DataMember]
		public int MinInventoryCountTo;
        [DataMember]
		public int CurrentInventoryCountFrom;
        [DataMember]
		public int CurrentInventoryCountTo;
        [DataMember]
		public int SalesCountFrom;
        [DataMember]
		public int SalesCountTo;
        [DataMember]
		public int OnSalesOrderCountFrom;
        [DataMember]
		public int OnSalesOrderCountTo;
        [DataMember]
		public int RetailCountFrom;
        [DataMember]
		public int RetailCountTo;
        [DataMember]
		public int OnRetailCountFrom;
        [DataMember]
		public int OnRetailCountTo;
        [DataMember]
		public int DismantingAmountFrom;
        [DataMember]
		public int DismantingAmountTo;
        [DataMember]
		public int RetailDismantingAmountFrom;
        [DataMember]
		public int RetailDismantingAmountTo;
        [DataMember]
		public Guid DrugInfoId{ get; set; }
        [DataMember]
		public string DrugInfoCode{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 生产厂家 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryManufacturerModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string ShortPinYin{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string Address{ get; set; }
        [DataMember]
		public string Tel{ get; set; }
        [DataMember]
		public string Contact{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 包装材质服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPackagingMaterialModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 包装服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPackagingUnitModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 付款方式服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPaymentMethodModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// GSP证书服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryGSPLicenseModel
    {
        [DataMember]
		public string LegalPerson{ get; set; }
        [DataMember]
		public string Header{ get; set; }
        [DataMember]
		public string QualityHeader{ get; set; }
        [DataMember]
		public string WarehouseAddress{ get; set; }
        [DataMember]
		public Guid BusinessTypeId{ get; set; }
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName{ get; set; }
        [DataMember]
		public string RegAddress{ get; set; }
        [DataMember]
		public string LicenseCode{ get; set; }
        [DataMember]
        public DateTime StartDateFrom { get; set; }
        [DataMember]
        public DateTime StartDateTo { get; set; }
        [DataMember]
        public DateTime OutDateFrom { get; set; }
        [DataMember]
        public DateTime OutDateTo { get; set; }
        [DataMember]
        public DateTime IssuanceDateFrom { get; set; }
        [DataMember]
        public DateTime IssuanceDateTo { get; set; }
        [DataMember]
        public string IssuanceOrg { get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
        public int LicenseTypeValueFrom = 0;
        [DataMember]
        public int LicenseTypeValueTo = 50;
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PharmacyFileId{ get; set; }

	}
     
	/// <summary>
    /// GMP证书服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryGMPLicenseModel
    {
        [DataMember]
		public string CertificationScope{ get; set; }
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName{ get; set; }
        [DataMember]
		public string RegAddress{ get; set; }
        [DataMember]
		public string LicenseCode{ get; set; }
        [DataMember]
		public DateTime StartDateFrom{ get; set; }
        [DataMember]
		public DateTime StartDateTo{ get; set; }
        [DataMember]
		public DateTime OutDateFrom{ get; set; }
        [DataMember]
		public DateTime OutDateTo{ get; set; }
        [DataMember]
		public DateTime IssuanceDateFrom{ get; set; }
        [DataMember]
		public DateTime IssuanceDateTo{ get; set; }
        [DataMember]
		public string IssuanceOrg{ get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
        public int LicenseTypeValueFrom = 0;
        [DataMember]
        public int LicenseTypeValueTo=50;
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PharmacyFileId{ get; set; }

	}
     
	/// <summary>
    /// 营业执照服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryBusinessLicenseModel
    {
        [DataMember]
		public int RegisteredCapitalFrom;
        [DataMember]
		public int RegisteredCapitalTo;
        [DataMember]
		public int PaidinCapitalFrom;
        [DataMember]
		public int PaidinCapitalTo;
        [DataMember]
		public string CorporateNature{ get; set; }
        [DataMember]
		public string BusinessScope{ get; set; }
        [DataMember]
		public DateTime EstablishmentDateFrom;
        [DataMember]
		public DateTime EstablishmentDateTo;
        [DataMember]
		public string InspectionDate{ get; set; }
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName{ get; set; }
        [DataMember]
		public string RegAddress{ get; set; }
        [DataMember]
		public string LicenseCode{ get; set; }
        [DataMember]
		public DateTime StartDateFrom{ get; set; }
        [DataMember]
		public DateTime StartDateTo{ get; set; }
        [DataMember]
		public DateTime OutDateFrom{ get; set; }
        [DataMember]
		public DateTime OutDateTo{ get; set; }
        [DataMember]
		public DateTime IssuanceDateFrom{ get; set; }
        [DataMember]
		public DateTime IssuanceDateTo{ get; set; }
        [DataMember]
		public string IssuanceOrg{ get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom;
        [DataMember]
		public int LicenseTypeValueTo;
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PharmacyFileId{ get; set; }

	}
     
	/// <summary>
    /// 药品生产许可证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryMedicineProductionLicenseModel
    {
        [DataMember]
		public string LegalPerson{ get; set; }
        [DataMember]
		public string Header{ get; set; }
        [DataMember]
		public string ProductAddress{ get; set; }
        [DataMember]
		public string CorporateNature{ get; set; }
        [DataMember]
		public string CategoryCode{ get; set; }
        [DataMember]
		public string ProductScope{ get; set; }
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName{ get; set; }
        [DataMember]
		public string RegAddress{ get; set; }
        [DataMember]
		public string LicenseCode{ get; set; }
        [DataMember]
		public DateTime StartDateFrom{ get; set; }
        [DataMember]
		public DateTime StartDateTo{ get; set; }
        [DataMember]
		public DateTime OutDateFrom{ get; set; }
        [DataMember]
		public DateTime OutDateTo{ get; set; }
        [DataMember]
		public DateTime IssuanceDateFrom{ get; set; }
        [DataMember]
		public DateTime IssuanceDateTo{ get; set; }
        [DataMember]
		public string IssuanceOrg{ get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom=0;
        [DataMember]
		public int LicenseTypeValueTo=100;
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PharmacyFileId{ get; set; }

	}
     
	/// <summary>
    /// 药品经营许可证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryMedicineBusinessLicenseModel
    {
        [DataMember]
		public string LegalPerson{ get; set; }
        [DataMember]
		public string Header{ get; set; }
        [DataMember]
		public string QualityHeader{ get; set; }
        [DataMember]
		public string WarehouseAddress{ get; set; }
        [DataMember]
		public string BusinessScope{ get; set; }
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName{ get; set; }
        [DataMember]
		public string RegAddress{ get; set; }
        [DataMember]
		public string LicenseCode{ get; set; }
        [DataMember]
		public DateTime StartDateFrom{ get; set; }
        [DataMember]
		public DateTime StartDateTo{ get; set; }
        [DataMember]
		public DateTime OutDateFrom{ get; set; }
        [DataMember]
		public DateTime OutDateTo{ get; set; }
        [DataMember]
		public DateTime IssuanceDateFrom{ get; set; }
        [DataMember]
		public DateTime IssuanceDateTo{ get; set; }
        [DataMember]
		public string IssuanceOrg{ get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom=0;
        [DataMember]
		public int LicenseTypeValueTo=100;
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PharmacyFileId{ get; set; }

	}
     
	/// <summary>
    /// 器械经营许可证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryInstrumentsBusinessLicenseModel
    {
        [DataMember]
		public string LegalPerson{ get; set; }
        [DataMember]
		public string Header{ get; set; }
        [DataMember]
		public string QualityHeader{ get; set; }
        [DataMember]
		public string WarehouseAddress{ get; set; }
        [DataMember]
		public string BusinessScope{ get; set; }
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName{ get; set; }
        [DataMember]
		public string RegAddress{ get; set; }
        [DataMember]
		public string LicenseCode{ get; set; }
        [DataMember]
		public DateTime StartDateFrom{ get; set; }
        [DataMember]
		public DateTime StartDateTo{ get; set; }
        [DataMember]
		public DateTime OutDateFrom{ get; set; }
        [DataMember]
		public DateTime OutDateTo{ get; set; }
        [DataMember]
		public DateTime IssuanceDateFrom{ get; set; }
        [DataMember]
		public DateTime IssuanceDateTo{ get; set; }
        [DataMember]
		public string IssuanceOrg{ get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
        public int LicenseTypeValueFrom = 0;
        [DataMember]
        public int LicenseTypeValueTo = 15;
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PharmacyFileId{ get; set; }

	}
     
	/// <summary>
    /// 器械生产许可证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryInstrumentsProductionLicenseModel
    {
        [DataMember]
		public string LegalPerson{ get; set; }
        [DataMember]
		public string Header{ get; set; }
        [DataMember]
		public string ProductAddress{ get; set; }
        [DataMember]
		public string ProductScope{ get; set; }
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName{ get; set; }
        [DataMember]
		public string RegAddress{ get; set; }
        [DataMember]
		public string LicenseCode{ get; set; }
        [DataMember]
		public DateTime StartDateFrom{ get; set; }
        [DataMember]
		public DateTime StartDateTo{ get; set; }
        [DataMember]
		public DateTime OutDateFrom{ get; set; }
        [DataMember]
		public DateTime OutDateTo{ get; set; }
        [DataMember]
		public DateTime IssuanceDateFrom{ get; set; }
        [DataMember]
		public DateTime IssuanceDateTo{ get; set; }
        [DataMember]
		public string IssuanceOrg{ get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
        public int LicenseTypeValueFrom = 0;
        [DataMember]
        public int LicenseTypeValueTo = 15;
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PharmacyFileId{ get; set; }

	}
     
	/// <summary>
    /// 医疗分类服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryMedicalCategoryModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 医疗详细分类服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryMedicalCategoryDetailModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid MedicalCategoryId{ get; set; }

	}
     
	/// <summary>
    /// 功能模块服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryModuleModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Description{ get; set; }
        [DataMember]
		public string AuthKey{ get; set; }
        [DataMember]
		public int IndexFrom;
        [DataMember]
		public int IndexTo;
        [DataMember]
		public Guid ModuleCatetoryId{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 功能模块分类服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryModuleCatetoryModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Description{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public int IndexFrom;
        [DataMember]
		public int IndexTo;

	}
     
	/// <summary>
    /// 功能模块与角色的关联服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryModuleWithRoleModel
    {
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid ModuleId{ get; set; }
        [DataMember]
		public Guid RoleId{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 文件服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPharmacyFileModel
    {
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public string FileName{ get; set; }
        [DataMember]
		public string Extension{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 采购合同服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseAgreementModel
    {
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 验收记录服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseCheckingOrderModel
    {
        [DataMember]
		public string DocumentNumber{ get; set; }
        [DataMember]
		public DateTime OperateTimeFrom{ get; set; }
        [DataMember]
		public DateTime OperateTimeTo{ get; set; }
        [DataMember]
		public Guid OperateUserId{ get; set; }
        [DataMember]
        public int OrderStatusValueFrom = 0;
        [DataMember]
        public int OrderStatusValueTo = 110;
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PurchaseOrderId{ get; set; }
        [DataMember]
		public Guid RelatedOrderId{ get; set; }
        [DataMember]
		public string RelatedOrderDocumentNumber{ get; set; }
        [DataMember]
		public int RelatedOrderTypeValueFrom;
        [DataMember]
		public int RelatedOrderTypeValueTo;

	}
     
	/// <summary>
    /// 采购到货验收服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseCheckingOrderDetailModel
    {
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid DrugInfoId{ get; set; }
        [DataMember]
		public decimal PurchasePriceFrom;
        [DataMember]
		public decimal PurchasePriceTo;
        [DataMember]
		public int ArrivalAmountFrom;
        [DataMember]
		public int ArrivalAmountTo;
        [DataMember]
		public DateTime ArrivalDateTimeFrom;
        [DataMember]
		public DateTime ArrivalDateTimeTo;
        [DataMember]
		public int QualifiedAmountFrom;
        [DataMember]
		public int QualifiedAmountTo;
        [DataMember]
		public int CheckResultFrom;
        [DataMember]
		public int CheckResultTo;
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string BatchNumber{ get; set; }
        [DataMember]
		public DateTime PruductDateFrom;
        [DataMember]
		public DateTime PruductDateTo;
        [DataMember]
		public DateTime OutValidDateFrom;
        [DataMember]
		public DateTime OutValidDateTo;
        [DataMember]
		public Guid PurchaseCheckingOrderId{ get; set; }

	}
     
	/// <summary>
    /// 库存记录服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseInInventeryOrderModel
    {
        [DataMember]
		public string DocumentNumber{ get; set; }
        [DataMember]
		public DateTime OperateTimeFrom{ get; set; }
        [DataMember]
		public DateTime OperateTimeTo{ get; set; }
        [DataMember]
		public Guid OperateUserId{ get; set; }
        [DataMember]
        public int OrderStatusValueFrom = 0;
        [DataMember]
        public int OrderStatusValueTo = 110;
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PurchaseOrderId{ get; set; }
        [DataMember]
		public Guid RelatedOrderId{ get; set; }
        [DataMember]
		public string RelatedOrderDocumentNumber{ get; set; }
        [DataMember]
		public int RelatedOrderTypeValueFrom;
        [DataMember]
		public int RelatedOrderTypeValueTo;

	}
     
	/// <summary>
    /// 库存记录详细服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseInInventeryOrderDetailModel
    {
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid DrugInfoId{ get; set; }
        [DataMember]
		public decimal PurchasePriceFrom;
        [DataMember]
		public decimal PurchasePriceTo;
        [DataMember]
		public string BatchNumber{ get; set; }
        [DataMember]
		public DateTime PruductDateFrom;
        [DataMember]
		public DateTime PruductDateTo;
        [DataMember]
		public DateTime OutValidDateFrom;
        [DataMember]
		public DateTime OutValidDateTo;
        [DataMember]
		public int ArrivalAmountFrom;
        [DataMember]
		public int ArrivalAmountTo;
        [DataMember]
		public DateTime ArrivalDateTimeFrom;
        [DataMember]
		public DateTime ArrivalDateTimeTo;
        [DataMember]
		public Guid WarehouseZoneId{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public Guid PurchaseInInventeryOrderId{ get; set; }

	}
     
	/// <summary>
    /// 管理要求分类服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseManageCategoryModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 管理要求分类详细服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseManageCategoryDetailModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid PurchaseManageCategoryId{ get; set; }

	}
     
	/// <summary>
    /// 采购单服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseOrderModel
    {
        [DataMember]
		public string DocumentNumber{ get; set; }
        [DataMember]
		public decimal TotalMoneyFrom;
        [DataMember]
		public decimal TotalMoneyTo;
        [DataMember]
		public decimal PaymentForGoodsMoneyFrom;
        [DataMember]
		public decimal PaymentForGoodsMoneyTo;
        [DataMember]
		public decimal AmountOfTaxMoneyFrom;
        [DataMember]
		public decimal AmountOfTaxMoneyTo;
        [DataMember]
		public int InValidDaysFrom;
        [DataMember]
		public int InValidDaysTo;
        [DataMember]
		public DateTime PurchasedDateFrom;
        [DataMember]
		public DateTime PurchasedDateTo;
        [DataMember]
		public Guid SupplyUnitAccountExecutiveId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public Guid ApprovalUserId{ get; set; }
        [DataMember]
		public string ApprovalDecription{ get; set; }
        [DataMember]
		public Guid AmountApprovalUserId{ get; set; }
        [DataMember]
		public string AmountApprovalDecription{ get; set; }
        [DataMember]
		public int OrderStatusValueFrom;
        [DataMember]
		public int OrderStatusValueTo;
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public bool DirectMarketing{ get; set; }
        [DataMember]
		public bool QueryDirectMarketing=false;
        [DataMember]
		public string ShippingMethod{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid SupplyUnitId{ get; set; }
        [DataMember]
		public Guid ReleatedPurchaseOrderId{ get; set; }

	}
     
	/// <summary>
    /// 采购明细服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseOrderDetailModel
    {
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public int AmountFrom;
        [DataMember]
		public int AmountTo;
        [DataMember]
		public decimal PurchasePriceFrom;
        [DataMember]
		public decimal PurchasePriceTo;
        [DataMember]
		public decimal AmountOfTaxFrom;
        [DataMember]
		public decimal AmountOfTaxTo;
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid DrugInfoId{ get; set; }
        [DataMember]
		public Guid PurchaseOrderId{ get; set; }

	}
     
	/// <summary>
    /// 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseOrderReturnModel
    {
        [DataMember]
		public string DocumentNumber{ get; set; }
        [DataMember]
		public Guid CheckerUserId{ get; set; }
        [DataMember]
		public string CheckerSuggest{ get; set; }
        [DataMember]
		public Guid QualityUserId{ get; set; }
        [DataMember]
		public string QualitySuggest{ get; set; }
        [DataMember]
		public Guid GeneralManagerUserId{ get; set; }
        [DataMember]
		public string GeneralManagerSuggest{ get; set; }
        [DataMember]
		public Guid FinanceDepartmentUserId{ get; set; }
        [DataMember]
		public string FinanceDepartmentSuggest{ get; set; }
        [DataMember]
		public int OrderStatusValueFrom;
        [DataMember]
		public int OrderStatusValueTo;
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PurchaseOrderId{ get; set; }
        [DataMember]
		public Guid RelatedOrderId{ get; set; }
        [DataMember]
		public string RelatedOrderDocumentNumber{ get; set; }
        [DataMember]
		public int RelatedOrderTypeValueFrom;
        [DataMember]
		public int RelatedOrderTypeValueTo;

	}
     
	/// <summary>
    /// 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseOrderReturnDetailModel
    {
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid DrugInfoId{ get; set; }
        [DataMember]
		public string BatchNumber{ get; set; }
        [DataMember]
		public DateTime PruductDateFrom;
        [DataMember]
		public DateTime PruductDateTo;
        [DataMember]
		public DateTime OutValidDateFrom;
        [DataMember]
		public DateTime OutValidDateTo;
        [DataMember]
		public int ReturnAmountFrom;
        [DataMember]
		public int ReturnAmountTo;
        [DataMember]
		public decimal PurchasePriceFrom;
        [DataMember]
		public decimal PurchasePriceTo;
        [DataMember]
		public string ReturnReason{ get; set; }
        [DataMember]
		public bool IsReissue{ get; set; }
        [DataMember]
		public bool QueryIsReissue=false;
        [DataMember]
		public int ReissueAmountFrom;
        [DataMember]
		public int ReissueAmountTo;
        [DataMember]
		public Guid PurchaseOrderReturnId{ get; set; }
        [DataMember]
		public int PurchaseReturnSourceValueFrom;
        [DataMember]
		public int PurchaseReturnSourceValueTo;
        [DataMember]
		public Guid RelatedOrderId{ get; set; }
        [DataMember]
		public int ReturnHandledMethodValueFrom;
        [DataMember]
		public int ReturnHandledMethodValueTo;
        [DataMember]
		public string Decription{ get; set; }

	}
     
	/// <summary>
    /// 采购收货单服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseReceivingOrderModel
    {
        [DataMember]
		public string DocumentNumber{ get; set; }
        [DataMember]
		public DateTime OperateTimeFrom{ get; set; }
        [DataMember]
		public DateTime OperateTimeTo{ get; set; }
        [DataMember]
		public DateTime ShippingTimeFrom;
        [DataMember]
		public DateTime ShippingTimeTo;
        [DataMember]
		public string ShippingAdress{ get; set; }
        [DataMember]
		public string ShippingUnit{ get; set; }
        [DataMember]
		public string TransportUnit{ get; set; }
        [DataMember]
		public Guid OperateUserId{ get; set; }
        [DataMember]
		public int OrderStatusValueFrom=0;
        [DataMember]
		public int OrderStatusValueTo=100;
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PurchaseOrderId{ get; set; }
        [DataMember]
		public Guid RelatedOrderId{ get; set; }
        [DataMember]
		public string RelatedOrderDocumentNumber{ get; set; }
        [DataMember]
		public int RelatedOrderTypeValueFrom=0;
        [DataMember]
		public int RelatedOrderTypeValueTo=100;

	}
     
	/// <summary>
    /// 采购收货详细单服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseReceivingOrderDetailModel
    {
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public int AmountFrom;
        [DataMember]
		public int AmountTo;
        [DataMember]
		public decimal PurchasePriceFrom;
        [DataMember]
		public decimal PurchasePriceTo;
        [DataMember]
		public int ActualAmountFrom;
        [DataMember]
		public int ActualAmountTo;
        [DataMember]
		public int ReceiveAmountFrom;
        [DataMember]
		public int ReceiveAmountTo;
        [DataMember]
		public int RejectAmountFrom;
        [DataMember]
		public int RejectAmountTo;
        [DataMember]
		public string RejectReason{ get; set; }
        [DataMember]
		public string RejectTrace{ get; set; }
        [DataMember]
		public bool IsCompanyPurchase{ get; set; }
        [DataMember]
		public bool QueryIsCompanyPurchase=false;
        [DataMember]
		public string TransportMethod{ get; set; }
        [DataMember]
		public bool IsTransportMethod{ get; set; }
        [DataMember]
		public bool QueryIsTransportMethod=false;
        [DataMember]
		public string TransportTemperature{ get; set; }
        [DataMember]
		public string TemperatureStatus{ get; set; }
        [DataMember]
		public bool IsTransportTemperature{ get; set; }
        [DataMember]
		public bool QueryIsTransportTemperature=false;
        [DataMember]
		public int CheckResultFrom;
        [DataMember]
		public int CheckResultTo;
        [DataMember]
		public Guid DrugInfoId{ get; set; }
        [DataMember]
		public Guid PurchaseReceivingOrderId{ get; set; }
        [DataMember]
		public string Decription{ get; set; }

	}
     
	/// <summary>
    /// 购货单位服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseUnitModel
    {
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public string ValidRemark{ get; set; }
        [DataMember]
		public bool IsLock{ get; set; }
        [DataMember]
		public bool QueryIsLock=false;
        [DataMember]
		public string LockRemark{ get; set; }
        [DataMember]
		public string ReceiveAddress{ get; set; }
        [DataMember]
		public Guid FlowID{ get; set; }
        [DataMember]
		public Guid DistrictId{ get; set; }
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public string PinyinCode{ get; set; }
        [DataMember]
		public string ContactName{ get; set; }
        [DataMember]
		public string ContactTel{ get; set; }
        [DataMember]
		public string Description{ get; set; }
        [DataMember]
		public string LegalPerson{ get; set; }
        [DataMember]
		public string Header{ get; set; }
        [DataMember]
		public string BusinessScope{ get; set; }
        [DataMember]
		public string SalesAmount{ get; set; }
        [DataMember]
		public string Fax{ get; set; }
        [DataMember]
		public string Email{ get; set; }
        [DataMember]
		public string WebAddress{ get; set; }
        [DataMember]
		public bool IsOutDate{ get; set; }
        [DataMember]
		public bool QueryIsOutDate=false;
        [DataMember]
		public DateTime OutDateFrom{ get; set; }
        [DataMember]
		public DateTime OutDateTo{ get; set; }
        [DataMember]
		public Guid GSPLicenseId{ get; set; }
        [DataMember]
		public bool IsGSPLicenseOutDate{ get; set; }
        [DataMember]
		public bool QueryIsGSPLicenseOutDate=false;
        [DataMember]
		public DateTime GSPLicenseOutDateFrom{ get; set; }
        [DataMember]
		public DateTime GSPLicenseOutDateTo{ get; set; }
        [DataMember]
		public Guid GMPLicenseId{ get; set; }
        [DataMember]
		public bool IsGMPLicenseOutDate{ get; set; }
        [DataMember]
		public bool QueryIsGMPLicenseOutDate=false;
        [DataMember]
		public DateTime GMPLicenseOutDateFrom{ get; set; }
        [DataMember]
		public DateTime GMPLicenseOutDateTo{ get; set; }
        [DataMember]
		public Guid BusinessLicenseId{ get; set; }
        [DataMember]
		public bool IsBusinessLicenseOutDate{ get; set; }
        [DataMember]
		public bool QueryIsBusinessLicenseOutDate=false;
        [DataMember]
		public DateTime BusinessLicenseeOutDateFrom{ get; set; }
        [DataMember]
		public DateTime BusinessLicenseeOutDateTo{ get; set; }
        [DataMember]
		public Guid MedicineProductionLicenseId{ get; set; }
        [DataMember]
		public bool IsMedicineProductionLicenseOutDate{ get; set; }
        [DataMember]
		public bool QueryIsMedicineProductionLicenseOutDate=false;
        [DataMember]
		public DateTime MedicineProductionLicenseOutDateFrom{ get; set; }
        [DataMember]
		public DateTime MedicineProductionLicenseOutDateTo{ get; set; }
        [DataMember]
		public Guid MedicineBusinessLicenseId{ get; set; }
        [DataMember]
		public bool IsMedicineBusinessLicenseOutDate{ get; set; }
        [DataMember]
		public bool QueryIsMedicineBusinessLicenseOutDate=false;
        [DataMember]
		public DateTime MedicineBusinessLicenseOutDateFrom{ get; set; }
        [DataMember]
		public DateTime MedicineBusinessLicenseOutDateTo{ get; set; }
        [DataMember]
		public Guid InstrumentsProductionLicenseId{ get; set; }
        [DataMember]
		public bool IsInstrumentsProductionLicenseOutDate{ get; set; }
        [DataMember]
		public bool QueryIsInstrumentsProductionLicenseOutDate=false;
        [DataMember]
		public DateTime InstrumentsProductionLicenseOutDateFrom{ get; set; }
        [DataMember]
		public DateTime InstrumentsProductionLicenseOutDateTo{ get; set; }
        [DataMember]
		public Guid InstrumentsBusinessLicenseId{ get; set; }
        [DataMember]
		public bool IsInstrumentsBusinessLicenseOutDate;
        [DataMember]
		public bool QueryIsInstrumentsBusinessLicenseOutDate=false;
        [DataMember]
		public DateTime InstrumentsBusinessLicenseOutDateFrom{ get; set; }
        [DataMember]
		public DateTime InstrumentsBusinessLicenseOutDateTo{ get; set; }
        [DataMember]
		public string TaxRegistrationCode{ get; set; }
        [DataMember]
		public Guid TaxRegistrationFile{ get; set; }
        [DataMember]
		public Guid AnnualFile{ get; set; }
        [DataMember]
        public DateTime LastAnnualDteFrom { get; set; }
        [DataMember]
        public DateTime LastAnnualDteTo { get; set; }
        [DataMember]
		public bool IsApproval{ get; set; }
        [DataMember]
		public bool QueryIsApproval=false;
        [DataMember]
        public int ApprovalStatusValueFrom = 0;
        [DataMember]
        public int ApprovalStatusValueTo = 16;
        [DataMember]
		public Guid UnitTypeId{ get; set; }
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 购货单位采购人员服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseUnitBuyerModel
    {
        [DataMember]
		public DateTime OutDateFrom{ get; set; }
        [DataMember]
		public DateTime OutDateTo{ get; set; }
        [DataMember]
        public int PurchaseLimitTypeValueFrom = 0;
        [DataMember]
		public int PurchaseLimitTypeValueTo =  1;
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public Guid IDFile{ get; set; }
        [DataMember]
		public string IDNumber{ get; set; }
        [DataMember]
		public string Tel{ get; set; }
        [DataMember]
		public string Address{ get; set; }
        [DataMember]
        public DateTime BirthdayFrom { get; set; }
        [DataMember]
        public DateTime BirthdayTo { get; set; }
        [DataMember]
		public string Gender{ get; set; }
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public bool IsChecked{ get; set; }
        [DataMember]
		public bool QueryIsChecked=false;
        [DataMember]
		public string IDCheckType{ get; set; }
        [DataMember]
		public Guid IDCheckUserId{ get; set; }
        [DataMember]
		public Guid PurchaseUnitId{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 购货单位提货人员服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseUnitDelivererModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string IDFile{ get; set; }
        [DataMember]
		public string IDNumber{ get; set; }
        [DataMember]
		public string Tel{ get; set; }
        [DataMember]
		public string Address{ get; set; }
        [DataMember]
        public DateTime BirthdayFrom { get; set; }
        [DataMember]
        public DateTime BirthdayTo { get; set; }
        [DataMember]
		public string Gender{ get; set; }
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid PurchaseUnitId{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}

    /// <summary>
    /// 首营药材供货人员服务查询实体
    /// </summary>
    [DataContract]
    public partial class QuerySupplyPersonModel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string IDFile { get; set; }
        [DataMember]
        public string IDNumber { get; set; }
        [DataMember]
        public string Tel { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public DateTime BirthdayFrom { get; set; }
        [DataMember]
        public DateTime BirthdayTo { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public Guid CreateUserId { get; set; }
        [DataMember]
        public Guid UpdateUserId { get; set; }
        [DataMember]
        public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
        public DateTime CreateTimeTo{ get; set; }
        [DataMember]
        public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
        public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
        public bool Valid { get; set; }
        [DataMember]
        public bool QueryValid = false;
        [DataMember]
        public bool Enabled { get; set; }
        [DataMember]
        public bool QueryEnabled = false;
        //[DataMember]
        //public Guid PurchaseUnitId { get; set; }
        [DataMember]
        public Guid StoreId { get; set; }

    }
     
	/// <summary>
    /// 购货单位类型服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseUnitTypeModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchasingPlanModel
    {

	}
     
	/// <summary>
    /// 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchasingPlanDetailModel
    {

	}
     
	/// <summary>
    /// 不常用字(生僻字)服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryRarewordModel
    {
        [DataMember]
		public string PinYin{ get; set; }
        [DataMember]
		public string Word{ get; set; }
        [DataMember]
		public string Parts{ get; set; }
        [DataMember]
		public string Code{ get; set; }

	}
     
	/// <summary>
    /// 零售会员服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryRetailMemberModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public int RetailCustomerTypeValueFrom;
        [DataMember]
		public int RetailCustomerTypeValueTo;
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryRetailOrderModel
    {
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public string Description{ get; set; }
        [DataMember]
		public decimal TotalMoneyFrom;
        [DataMember]
		public decimal TotalMoneyTo;
        [DataMember]
		public decimal ReduceMoneyFrom;
        [DataMember]
		public decimal ReduceMoneyTo;
        [DataMember]
		public decimal ReceivableMoneyFrom;
        [DataMember]
		public decimal ReceivableMoneyTo;
        [DataMember]
		public decimal GotMoneyFrom;
        [DataMember]
		public decimal GotMoneyTo;
        [DataMember]
		public decimal ChangeMoneyFrom;
        [DataMember]
		public decimal ChangeMoneyTo;
        [DataMember]
		public decimal RealPayMoneyFrom;
        [DataMember]
		public decimal RealPayMoneyTo;
        [DataMember]
		public int RetailCustomerTypeValueFrom;
        [DataMember]
		public int RetailCustomerTypeValueTo;
        [DataMember]
		public int RetailPaymentMethodValueFrom;
        [DataMember]
		public int RetailPaymentMethodValueTo;
        [DataMember]
		public decimal TotalRefundFrom;
        [DataMember]
		public decimal TotalRefundTo;
        [DataMember]
		public decimal ReturnReduceMoneyFrom;
        [DataMember]
		public decimal ReturnReduceMoneyTo;
        [DataMember]
		public decimal ReturnReceivableMoneyFrom;
        [DataMember]
		public decimal ReturnReceivableMoneyTo;
        [DataMember]
		public decimal ReturnRealReceiveMoneyFrom;
        [DataMember]
		public decimal ReturnRealReceiveMoneyTo;
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 零售单明细服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryRetailOrderDetailModel
    {
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public int IndexFrom;
        [DataMember]
		public int IndexTo;
        [DataMember]
		public string productName{ get; set; }
        [DataMember]
		public string productCode{ get; set; }
        [DataMember]
		public string BatchNumber{ get; set; }
        [DataMember]
		public int AmountFrom;
        [DataMember]
		public int AmountTo;
        [DataMember]
		public int ReturnAmountFrom;
        [DataMember]
		public int ReturnAmountTo;
        [DataMember]
		public bool IsDismanting{ get; set; }
        [DataMember]
		public bool QueryIsDismanting=false;
        [DataMember]
		public int DismantingAmountFrom;
        [DataMember]
		public int DismantingAmountTo;
        [DataMember]
		public decimal UnitPriceFrom;
        [DataMember]
		public decimal UnitPriceTo;
        [DataMember]
		public decimal DismantingUnitPriceFrom;
        [DataMember]
		public decimal DismantingUnitPriceTo;
        [DataMember]
		public decimal ActualUnitPriceFrom;
        [DataMember]
		public decimal ActualUnitPriceTo;
        [DataMember]
		public decimal ActualDismantingUnitPriceFrom;
        [DataMember]
		public decimal ActualDismantingUnitPriceTo;
        [DataMember]
		public string MeasurementUnit{ get; set; }
        [DataMember]
		public string SpecificationCode{ get; set; }
        [DataMember]
		public DateTime PruductDateFrom;
        [DataMember]
		public DateTime PruductDateTo;
        [DataMember]
		public DateTime OutValidDateFrom;
        [DataMember]
		public DateTime OutValidDateTo;
        [DataMember]
		public string FactoryName{ get; set; }
        [DataMember]
		public string Description{ get; set; }
        [DataMember]
		public bool IsDiscount{ get; set; }
        [DataMember]
		public bool QueryIsDiscount=false;
        [DataMember]
		public int DiscountFrom;
        [DataMember]
		public int DiscountTo;
        [DataMember]
		public int DiscountPriceFrom;
        [DataMember]
		public int DiscountPriceTo;
        [DataMember]
		public decimal TotalMoneyFrom;
        [DataMember]
		public decimal TotalMoneyTo;
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid RetailOrderId{ get; set; }
        [DataMember]
		public Guid DrugInventoryRecordID{ get; set; }

	}
     
	/// <summary>
    /// 系统角色服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryRoleModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public string Description{ get; set; }
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 角色与用户的关联服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryRoleWithUserModel
    {
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid RoleId{ get; set; }
        [DataMember]
		public Guid UserId{ get; set; }

	}
     
	/// <summary>
    /// 销售单服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySalesOrderModel
    {
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public string SalerName{ get; set; }
        [DataMember]
        public DateTime SaleDateFrom { get; set; }
        [DataMember]
        public DateTime SaleDateTo { get; set; }
        [DataMember]
		public string Description{ get; set; }
        [DataMember]
		public decimal TotalMoneyFrom;
        [DataMember]
		public decimal TotalMoneyTo;
        [DataMember]
		public string OrderCode{ get; set; }
        [DataMember]
		public bool AllDelivered{ get; set; }
        [DataMember]
		public bool QueryAllDelivered=false;
        [DataMember]
        public int SalesDrugTypeValueFrom = 0;
        [DataMember]
        public int SalesDrugTypeValueTo = 3;
        [DataMember]
        public int PickUpGoodTypeValueFrom = 0;
        [DataMember]
        public int PickUpGoodTypeValueTo = 3;
        [DataMember]
		public string PickUpMan{ get; set; }
        [DataMember]
		public string PurchaseUnitMan{ get; set; }
        [DataMember]
		public Guid PurchaseUnitManID{ get; set; }
        [DataMember]
        public int OrderStatusValueFrom = 0;
        [DataMember]
        public int OrderStatusValueTo = 110;
        [DataMember]
		public Guid ApprovalUserId{ get; set; }
        [DataMember]
		public Guid CancelUserID{ get; set; }
        [DataMember]
		public string CancelReason{ get; set; }
        [DataMember]
		public string OrderCancelCode{ get; set; }
        [DataMember]
		public string OrderBalanceCode{ get; set; }
        [DataMember]
		public Guid BalanceUserID{ get; set; }
        [DataMember]
		public string BalanceReason{ get; set; }
        [DataMember]
		public Guid payMentMethodID{ get; set; }
        [DataMember]
		public string OrderOutInventoryCode{ get; set; }
        [DataMember]
		public Guid OrderOutInventoryUserID{ get; set; }
        [DataMember]
		public string OrderOutInventoryCheckCode{ get; set; }
        [DataMember]
		public Guid OrderOutInventoryCheckUserID{ get; set; }
        [DataMember]
		public string OrderReturnCode{ get; set; }
        [DataMember]
		public Guid OrderReturnUserID{ get; set; }
        [DataMember]
		public string OrderReturnReason{ get; set; }
        [DataMember]
		public string OrderReturnCancelCode{ get; set; }
        [DataMember]
		public Guid OrderReturnCancelUserID{ get; set; }
        [DataMember]
		public string OrderReturnCancelReason{ get; set; }
        [DataMember]
		public string OrderReturnCheckCode{ get; set; }
        [DataMember]
		public Guid OrderReturnCheckUserID{ get; set; }
        [DataMember]
		public string OrderReturnInInventoryCode{ get; set; }
        [DataMember]
		public Guid OrderReturnInInventoryUserID{ get; set; }
        [DataMember]
		public string OrderDirectReturnCode{ get; set; }
        [DataMember]
		public Guid OrderDirectReturnUserID{ get; set; }
        [DataMember]
		public Guid OutInventoryId{ get; set; }
        [DataMember]
		public Guid PurchaseUnitId{ get; set; }
	}
     
	/// <summary>
    /// 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySalesOrderDeliverDetailModel
    {
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid SalesOrderDeliverRecordId{ get; set; }
        [DataMember]
		public Guid SalesOrderDetailId{ get; set; }

	}
     
	/// <summary>
    /// 销售发货记录服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySalesOrderDeliverRecordModel
    {
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid ApprovalUserId{ get; set; }
        [DataMember]
		public bool HadDelivered{ get; set; }
        [DataMember]
		public bool QueryHadDelivered=false;
        [DataMember]
		public Guid OutInventoryId{ get; set; }
        [DataMember]
		public Guid SalesOrderId{ get; set; }

	}
     
	/// <summary>
    /// 销售单明细服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySalesOrderDetailModel
    {
        [DataMember]
		public int IndexFrom;
        [DataMember]
		public int IndexTo;
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public string productName{ get; set; }
        [DataMember]
		public string productCode{ get; set; }
        [DataMember]
		public string BatchNumber{ get; set; }
        [DataMember]
		public int AmountFrom;
        [DataMember]
		public int AmountTo;
        [DataMember]
		public decimal UnitPriceFrom;
        [DataMember]
		public decimal UnitPriceTo;
        [DataMember]
		public decimal ActualUnitPriceFrom;
        [DataMember]
		public decimal ActualUnitPriceTo;
        [DataMember]
		public decimal PriceFrom;
        [DataMember]
		public decimal PriceTo;
        [DataMember]
		public string MeasurementUnit{ get; set; }
        [DataMember]
		public string SpecificationCode{ get; set; }
        [DataMember]
		public string DictionaryDosageCode{ get; set; }
        [DataMember]
		public string Origin{ get; set; }
        [DataMember]
        public DateTime PruductDateFrom { get; set; }
        [DataMember]
        public DateTime PruductDateTo { get; set; }
        [DataMember]
        public DateTime OutValidDateFrom { get; set; }
        [DataMember]
        public DateTime OutValidDateTo { get; set; }
        [DataMember]
		public string FactoryName{ get; set; }
        [DataMember]
		public string Description{ get; set; }
        [DataMember]
		public int ReturnAmountFrom;
        [DataMember]
		public int ReturnAmountTo;
        [DataMember]
		public int ChangeAmountFrom;
        [DataMember]
		public int ChangeAmountTo;
        [DataMember]
		public int OutAmountFrom;
        [DataMember]
		public int OutAmountTo;
        [DataMember]
		public Guid OutInventoryDetailID{ get; set; }
        [DataMember]
		public Guid SalesOrderID{ get; set; }
        [DataMember]
		public Guid DrugInventoryRecordID{ get; set; }

	}
     
	/// <summary>
    /// 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySalesOrderReturnModel
    {
        [DataMember]
		public string OrderReturnCode{ get; set; }
        [DataMember]
		public string OrderReturnReason{ get; set; }
        [DataMember]
        public DateTime OrderReturnTimeFrom { get; set; }
        [DataMember]
        public DateTime OrderReturnTimeTo { get; set; }
        [DataMember]
		public bool IsReissue{ get; set; }
        [DataMember]
		public bool QueryIsReissue=false;
        [DataMember]
		public Guid SellerID{ get; set; }
        [DataMember]
		public string SellerMemo{ get; set; }
        [DataMember]
		public DateTime SellerUpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime SellerUpdateTimeTo{ get; set; }
        [DataMember]
		public Guid TradeUserID{ get; set; }
        [DataMember]
		public string TradeMemo{ get; set; }
        [DataMember]
		public DateTime TradeUpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime TradeUpdateTimeTo{ get; set; }
        [DataMember]
		public Guid QualityUserID{ get; set; }
        [DataMember]
		public string QualityMemo{ get; set; }
        [DataMember]
		public DateTime QualityUpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime QualityUpdateTimeTo{ get; set; }
        [DataMember]
		public int OrderReturnStatusValueFrom=0;
        [DataMember]
		public int OrderReturnStatusValueTo=100;
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public string OrderReturnInInventoryCode{ get; set; }
        [DataMember]
		public Guid OrderReturnInInventoryUserID{ get; set; }
        [DataMember]
		public string OrderReturnCancelCode{ get; set; }
        [DataMember]
		public Guid OrderReturnCancelUserID{ get; set; }
        [DataMember]
		public string OrderReturnCancelReason{ get; set; }
        [DataMember]
		public string OrderReturnCheckCode{ get; set; }
        [DataMember]
		public Guid OrderReturnCheckUserID{ get; set; }
        [DataMember]
		public Guid SalesOrderID{ get; set; }
        [DataMember]
		public Guid OutInventoryID{ get; set; }

	}
     
	/// <summary>
    /// 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySalesOrderReturnDetailModel
    {
        [DataMember]
		public int IndexFrom;
        [DataMember]
		public int IndexTo;
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public string productName{ get; set; }
        [DataMember]
		public string productCode{ get; set; }
        [DataMember]
		public string BatchNumber{ get; set; }
        [DataMember]
		public int OrderAmountFrom;
        [DataMember]
		public int OrderAmountTo;
        [DataMember]
		public decimal UnitPriceFrom;
        [DataMember]
		public decimal UnitPriceTo;
        [DataMember]
		public decimal ActualUnitPriceFrom;
        [DataMember]
		public decimal ActualUnitPriceTo;
        [DataMember]
		public decimal PriceFrom;
        [DataMember]
		public decimal PriceTo;
        [DataMember]
		public string MeasurementUnit{ get; set; }
        [DataMember]
		public string SpecificationCode{ get; set; }
        [DataMember]
        public DateTime PruductDateFrom { get; set; }
        [DataMember]
        public DateTime PruductDateTo { get; set; }
        [DataMember]
        public DateTime OutValidDateFrom { get; set; }
        [DataMember]
        public DateTime OutValidDateTo { get; set; }
        [DataMember]
		public string FactoryName{ get; set; }
        [DataMember]
		public string Description{ get; set; }
        [DataMember]
		public int ReturnAmountFrom;
        [DataMember]
		public int ReturnAmountTo;
        [DataMember]
		public int ReturnReasonValueFrom;
        [DataMember]
		public int ReturnReasonValueTo;
        [DataMember]
		public string ReturnReasonMemo{ get; set; }
        [DataMember]
		public int CanInAmountFrom;
        [DataMember]
		public int CanInAmountTo;
        [DataMember]
		public int CannotInAmountFrom;
        [DataMember]
		public int CannotInAmountTo;
        [DataMember]
		public int ReturnHandledMethodValueFrom;
        [DataMember]
		public int ReturnHandledMethodValueTo;
        [DataMember]
		public string ReturnHandledMethodMemo{ get; set; }
        [DataMember]
		public bool IsReissue{ get; set; }
        [DataMember]
		public bool QueryIsReissue=false;
        [DataMember]
		public int ReissueAmountFrom;
        [DataMember]
		public int ReissueAmountTo;
        [DataMember]
		public Guid OutInventoryDetailID{ get; set; }
        [DataMember]
		public Guid OrderReturnID{ get; set; }
        [DataMember]
		public Guid SalesOrderDetailID{ get; set; }
        [DataMember]
		public Guid DrugInventoryRecordID{ get; set; }
        [DataMember]
		public string DictionaryDosageCode{ get; set; }
        [DataMember]
		public string Origin{ get; set; }

	}
     
	/// <summary>
    /// 销售出库单服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryOutInventoryModel
    {
        [DataMember]
		public string OutInventoryNumber{ get; set; }
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid storekeeperId{ get; set; }
        [DataMember]
		public Guid ReviewerId{ get; set; }
        [DataMember]
		public DateTime OutInventoryDateFrom{ get; set; }
        [DataMember]
        public DateTime OutInventoryDateTo { get; set; }
        [DataMember]
		public string Description{ get; set; }
        [DataMember]
		public Guid OrderOutInventoryUserID{ get; set; }
        [DataMember]
		public string OrderOutInventoryCheckNumber{ get; set; }
        [DataMember]
		public Guid OrderOutInventoryCheckUserID{ get; set; }
        [DataMember]
		public decimal TotalMoneyFrom;
        [DataMember]
		public decimal TotalMoneyTo;
        [DataMember]
		public decimal TotalTaxFrom;
        [DataMember]
		public decimal TotalTaxTo;
        [DataMember]
		public int OutInventoryTypeValueFrom;
        [DataMember]
		public int OutInventoryTypeValueTo;
        [DataMember]
		public int OutInventoryStatusValueFrom;
        [DataMember]
		public int OutInventoryStatusValueTo;
        [DataMember]
		public Guid SalesOrderID{ get; set; }
        [DataMember]
		public string OrderCode{ get; set; }
        [DataMember]
		public Guid SalesOrderReturnID{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 设置重点药品记录表服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySetSpeicalDrugRecordModel
    {
        [DataMember]
		public Guid DrugInventoryId{ get; set; }
        [DataMember]
        public int MaintainDuetimeFrom { get; set; }
        [DataMember]
        public int MaintainDuetimeTo { get; set; }
        [DataMember]
		public string Reason{ get; set; }
        [DataMember]
		public string MaintainEmphasis{ get; set; }
        [DataMember]
		public string Memo{ get; set; }

	}
     
	/// <summary>
    /// 特殊管理药物类型服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySpecialDrugCategoryModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 门店服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryStoreModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string Address{ get; set; }
        [DataMember]
		public string Tel{ get; set; }
        [DataMember]
		public string Head{ get; set; }
        [DataMember]
        public int StoreTypeValueFrom = 0;
        [DataMember]
        public int StoreTypeValueTo = 5;

	}
     
	/// <summary>
    /// 供货单位服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySupplyUnitModel
    {
        [DataMember]
		public bool IsQualityAgreementOut{ get; set; }
        [DataMember]
		public bool QueryIsQualityAgreementOut=false;
        [DataMember]
		public Guid QualityAgreementFile{ get; set; }
        [DataMember]
		public DateTime QualityAgreementOutDateFrom{ get; set; }
        [DataMember]
		public DateTime QualityAgreementOutDateTo{ get; set; }
        [DataMember]
		public bool IsAttorneyAattorneyOut{ get; set; }
        [DataMember]
		public bool QueryIsAttorneyAattorneyOut=false;
        [DataMember]
		public Guid AttorneyAattorneyFile{ get; set; }
        [DataMember]
		public DateTime AttorneyAattorneyOutDateFrom{ get; set; }
        [DataMember]
		public DateTime AttorneyAattorneyOutDateTo{ get; set; }
        [DataMember]
		public string SupplyProductClass{ get; set; }
        [DataMember]
		public string QualityCharger{ get; set; }
        [DataMember]
		public Guid SealFile{ get; set; }
        [DataMember]
		public Guid SingleTicketFile{ get; set; }
        [DataMember]
		public Guid ProofFile{ get; set; }
        [DataMember]
		public string BankAccountName{ get; set; }
        [DataMember]
		public string Bank{ get; set; }
        [DataMember]
		public string BankAccount{ get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public string ValidRemark{ get; set; }
        [DataMember]
		public bool IsLock{ get; set; }
        [DataMember]
		public bool QueryIsLock=false;
        [DataMember]
		public string LockRemark{ get; set; }
        [DataMember]
		public Guid FlowID{ get; set; }
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public string PinyinCode{ get; set; }
        [DataMember]
		public string ContactName{ get; set; }
        [DataMember]
		public string ContactTel{ get; set; }
        [DataMember]
		public string Description{ get; set; }
        [DataMember]
		public string LegalPerson{ get; set; }
        [DataMember]
		public string Header{ get; set; }
        [DataMember]
		public string BusinessScope{ get; set; }
        [DataMember]
		public string SalesAmount{ get; set; }
        [DataMember]
		public string Fax{ get; set; }
        [DataMember]
		public string Email{ get; set; }
        [DataMember]
		public string WebAddress{ get; set; }
        [DataMember]
		public bool IsOutDate{ get; set; }
        [DataMember]
		public bool QueryIsOutDate=false;
        [DataMember]
		public DateTime OutDateFrom{ get; set; }
        [DataMember]
		public DateTime OutDateTo{ get; set; }
        [DataMember]
		public Guid GSPLicenseId{ get; set; }
        [DataMember]
		public bool IsGSPLicenseOutDate{ get; set; }
        [DataMember]
		public bool QueryIsGSPLicenseOutDate=false;
        [DataMember]
		public DateTime GSPLicenseOutDateFrom{ get; set; }
        [DataMember]
		public DateTime GSPLicenseOutDateTo{ get; set; }
        [DataMember]
		public Guid GMPLicenseId{ get; set; }
        [DataMember]
		public bool IsGMPLicenseOutDate{ get; set; }
        [DataMember]
		public bool QueryIsGMPLicenseOutDate=false;
        [DataMember]
		public DateTime GMPLicenseOutDateFrom{ get; set; }
        [DataMember]
		public DateTime GMPLicenseOutDateTo{ get; set; }
        [DataMember]
		public Guid BusinessLicenseId{ get; set; }
        [DataMember]
		public bool IsBusinessLicenseOutDate{ get; set; }
        [DataMember]
		public bool QueryIsBusinessLicenseOutDate=false;
        [DataMember]
		public DateTime BusinessLicenseeOutDateFrom{ get; set; }
        [DataMember]
		public DateTime BusinessLicenseeOutDateTo{ get; set; }
        [DataMember]
		public Guid MedicineProductionLicenseId{ get; set; }
        [DataMember]
		public bool IsMedicineProductionLicenseOutDate{ get; set; }
        [DataMember]
		public bool QueryIsMedicineProductionLicenseOutDate=false;
        [DataMember]
		public DateTime MedicineProductionLicenseOutDateFrom{ get; set; }
        [DataMember]
		public DateTime MedicineProductionLicenseOutDateTo{ get; set; }
        [DataMember]
		public Guid MedicineBusinessLicenseId{ get; set; }
        [DataMember]
		public bool IsMedicineBusinessLicenseOutDate{ get; set; }
        [DataMember]
		public bool QueryIsMedicineBusinessLicenseOutDate=false;
        [DataMember]
		public DateTime MedicineBusinessLicenseOutDateFrom{ get; set; }
        [DataMember]
		public DateTime MedicineBusinessLicenseOutDateTo{ get; set; }
        [DataMember]
		public Guid InstrumentsProductionLicenseId{ get; set; }
        [DataMember]
		public bool IsInstrumentsProductionLicenseOutDate{ get; set; }
        [DataMember]
		public bool QueryIsInstrumentsProductionLicenseOutDate=false;
        [DataMember]
		public DateTime InstrumentsProductionLicenseOutDateFrom{ get; set; }
        [DataMember]
		public DateTime InstrumentsProductionLicenseOutDateTo{ get; set; }
        [DataMember]
		public Guid InstrumentsBusinessLicenseId{ get; set; }
        [DataMember]
		public bool IsInstrumentsBusinessLicenseOutDate{ get; set; }
        [DataMember]
		public bool QueryIsInstrumentsBusinessLicenseOutDate=false;
        [DataMember]
		public DateTime InstrumentsBusinessLicenseOutDateFrom{ get; set; }
        [DataMember]
		public DateTime InstrumentsBusinessLicenseOutDateTo{ get; set; }
        [DataMember]
		public string TaxRegistrationCode{ get; set; }
        [DataMember]
		public Guid TaxRegistrationFile{ get; set; }
        [DataMember]
		public Guid AnnualFile{ get; set; }
        [DataMember]
		public DateTime LastAnnualDteFrom;
        [DataMember]
		public DateTime LastAnnualDteTo;
        [DataMember]
		public bool IsApproval{ get; set; }
        [DataMember]
		public bool QueryIsApproval=false;
        [DataMember]
		public int ApprovalStatusValueFrom=0;
        [DataMember]
		public int ApprovalStatusValueTo=100;
        [DataMember]
		public Guid UnitTypeId{ get; set; }
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 供货商销售人员服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySupplyUnitSalesmanModel
    {
        [DataMember]
		public DateTime OutDateFrom{ get; set; }
        [DataMember]
		public DateTime OutDateTo{ get; set; }
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public Guid IDFile{ get; set; }
        [DataMember]
		public string IDNumber{ get; set; }
        [DataMember]
		public string Tel{ get; set; }
        [DataMember]
		public string Address{ get; set; }
        [DataMember]
        public DateTime BirthdayFrom { get; set; }
        [DataMember]
        public DateTime BirthdayTo { get; set; }
        [DataMember]
		public string Gender{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public bool IsOutDate{ get; set; }
        [DataMember]
		public bool QueryIsOutDate=false;
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid AuthorizedDistrictId{ get; set; }
        [DataMember]
		public string BusinessScopes{ get; set; }
        [DataMember]
		public bool IsChecked{ get; set; }
        [DataMember]
		public bool QueryIsChecked=false;
        [DataMember]
		public string IDCheckType{ get; set; }
        [DataMember]
		public Guid IDCheckUserId{ get; set; }
        [DataMember]
		public Guid AuthorizationDocId{ get; set; }
        [DataMember]
		public Guid SupplyUnitId{ get; set; }

	}
     
	/// <summary>
    /// 税率服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryTaxRateModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 企业类型服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryUnitTypeModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }

	}
     
	/// <summary>
    /// 数据上传记录服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryUploadRecordModel
    {
        [DataMember]
		public string TableName{ get; set; }
        [DataMember]
		public int IndexFrom;
        [DataMember]
		public int IndexTo;

	}
     
	/// <summary>
    /// 系统用户服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryUserModel
    {
        [DataMember]
		public string Account{ get; set; }
        [DataMember]
		public string Pwd{ get; set; }
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid EmployeeId{ get; set; }

	}
     
	/// <summary>
    /// 用户日志服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryUserLogModel
    {
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public string Content{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 车辆服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryVehicleModel
    {
        [DataMember]
		public string Type{ get; set; }
        [DataMember]
		public int VehicleCategoryValueFrom;
        [DataMember]
		public int VehicleCategoryValueTo;
        [DataMember]
		public string Cubage{ get; set; }
        [DataMember]
		public string LicensePlate{ get; set; }
        [DataMember]
		public string Rule{ get; set; }
        [DataMember]
		public string Other{ get; set; }
        [DataMember]
		public string Driver{ get; set; }
        [DataMember]
		public bool Status{ get; set; }
        [DataMember]
		public bool QueryStatus=false;
        [DataMember]
		public bool IsOutCheck{ get; set; }
        [DataMember]
		public bool QueryIsOutCheck=false;
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 仓库服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryWarehouseModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public string MnemonicCode{ get; set; }
        [DataMember]
		public string Address{ get; set; }
        [DataMember]
		public string ManagementCompany{ get; set; }
        [DataMember]
		public string Phone{ get; set; }
        [DataMember]
		public string RentCompany{ get; set; }
        [DataMember]
		public string RentYear{ get; set; }
        [DataMember]
		public string Area{ get; set; }
        [DataMember]
		public string ShadeArea{ get; set; }
        [DataMember]
		public string NormalArea{ get; set; }
        [DataMember]
		public string ColdArea{ get; set; }
        [DataMember]
		public string YPFZArea{ get; set; }
        [DataMember]
		public string YHYSSArea{ get; set; }
        [DataMember]
		public string PHCArea{ get; set; }
        [DataMember]
		public string TYZQArea{ get; set; }
        [DataMember]
		public string DWArea{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 库区服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryWarehouseZoneModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public string MnemonicCode{ get; set; }
        [DataMember]
		public string Area{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
        public int WarehouseZoneTypeValueFrom = 0;
        [DataMember]
		public int WarehouseZoneTypeValueTo=3;
        [DataMember]
		public Guid WarehouseId{ get; set; }
        [DataMember]
		public Guid DictionaryStorageTypeId{ get; set; }
        [DataMember]
		public Guid DictionaryMeasurementUnitId{ get; set; }

	}
     
	/// <summary>
    /// 报警设置服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryWaringSetModel
    {
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string SetValue{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }

	}
     
	/// <summary>
    /// 销售出库单服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryOutInventoryDetailModel
    {
        [DataMember]
		public int IndexFrom;
        [DataMember]
		public int IndexTo;
        [DataMember]
		public Guid CreateUserId{ get; set; }
        [DataMember]
		public Guid UpdateUserId{ get; set; }
        [DataMember]
		public DateTime CreateTimeFrom{ get; set; }
        [DataMember]
		public DateTime CreateTimeTo{ get; set; }
        [DataMember]
		public DateTime UpdateTimeFrom{ get; set; }
        [DataMember]
		public DateTime UpdateTimeTo{ get; set; }
        [DataMember]
		public string productName{ get; set; }
        [DataMember]
		public string productCode{ get; set; }
        [DataMember]
		public string DictionaryDosageCode{ get; set; }
        [DataMember]
		public string Origin{ get; set; }
        [DataMember]
		public string BatchNumber{ get; set; }
        [DataMember]
		public int AmountFrom;
        [DataMember]
		public int AmountTo;
        [DataMember]
		public decimal UnitPriceFrom;
        [DataMember]
		public decimal UnitPriceTo;
        [DataMember]
		public decimal ActualUnitPriceFrom;
        [DataMember]
		public decimal ActualUnitPriceTo;
        [DataMember]
		public decimal PriceFrom;
        [DataMember]
		public decimal PriceTo;
        [DataMember]
		public string MeasurementUnit{ get; set; }
        [DataMember]
		public string SpecificationCode{ get; set; }
        [DataMember]
        public DateTime PruductDateFrom { get; set; }
        [DataMember]
        public DateTime PruductDateTo { get; set; }
        [DataMember]
        public DateTime OutValidDateFrom { get; set; }
        [DataMember]
        public DateTime OutValidDateTo { get; set; }
        [DataMember]
		public string FactoryName{ get; set; }
        [DataMember]
		public string Description{ get; set; }
        [DataMember]
		public int OutAmountFrom;
        [DataMember]
		public int OutAmountTo;
        [DataMember]
		public string WarehouseCode{ get; set; }
        [DataMember]
		public string WarehouseName{ get; set; }
        [DataMember]
		public string WarehouseZoneCode{ get; set; }
        [DataMember]
		public string WarehouseZoneName{ get; set; }
        [DataMember]
		public int CanSaleNumFrom;
        [DataMember]
		public int CanSaleNumTo;
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid SalesOrderId{ get; set; }
        [DataMember]
		public Guid SalesOrderDetailId{ get; set; }
        [DataMember]
		public Guid SalesOrderReturnId{ get; set; }
        [DataMember]
		public Guid SalesOrderDetailReturnId{ get; set; }
        [DataMember]
		public Guid DrugInventoryRecordID{ get; set; }
        [DataMember]
		public Guid SalesOutInventoryID{ get; set; }

	}

    	/// <summary>
    /// 组织机构代码证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryOrganizationCodeLicenseModel
    {
        [DataMember]
		public string OrgnizationType{ get; set; }
        [DataMember]
		public string LicenseNo{ get; set; }
        [DataMember]
		public string RegisterNo{ get; set; }
        [DataMember]
		public DateTime IssuanceDateFrom{ get; set; }
        [DataMember]
		public DateTime IssuanceDateTo{ get; set; }
        [DataMember]
		public string IssuanceOrg{ get; set; }
        [DataMember]
		public bool isCheck{ get; set; }
        [DataMember]
		public bool QueryisCheck=false;
        [DataMember]
		public DateTime YearCheckDateFrom{ get; set; }
        [DataMember]
		public DateTime YearCheckDateTo{ get; set; }
        [DataMember]
		public string DocNumber{ get; set; }
        [DataMember]
		public string memo{ get; set; }
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName{ get; set; }
        [DataMember]
		public string RegAddress{ get; set; }
        [DataMember]
		public string LicenseCode{ get; set; }
        [DataMember]
		public DateTime StartDateFrom{ get; set; }
        [DataMember]
		public DateTime StartDateTo{ get; set; }
        [DataMember]
		public DateTime OutDateFrom{ get; set; }
        [DataMember]
		public DateTime OutDateTo{ get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom{ get; set; }
        [DataMember]
		public int LicenseTypeValueTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PharmacyFileId{ get; set; }

	}
     
	/// <summary>
    /// 食品流通许可证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryFoodCirculateLicenseModel
    {
        [DataMember]
		public string OrgType{ get; set; }
        [DataMember]
		public string RegAddress{ get; set; }
        [DataMember]
		public string LicenseNo{ get; set; }
        [DataMember]
		public string Header{ get; set; }
        [DataMember]
		public DateTime LicenseRangeFrom{ get; set; }
        [DataMember]
		public DateTime LicenseRangeTo{ get; set; }
        [DataMember]
		public string IssuanceOrg{ get; set; }
        [DataMember]
		public string DocNumber{ get; set; }
        [DataMember]
		public string memo{ get; set; }
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName{ get; set; }
        [DataMember]
		public string LicenseCode{ get; set; }
        [DataMember]
		public DateTime StartDateFrom{ get; set; }
        [DataMember]
		public DateTime StartDateTo{ get; set; }
        [DataMember]
		public DateTime OutDateFrom{ get; set; }
        [DataMember]
		public DateTime OutDateTo{ get; set; }
        [DataMember]
		public DateTime IssuanceDateFrom{ get; set; }
        [DataMember]
		public DateTime IssuanceDateTo{ get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom{ get; set; }
        [DataMember]
		public int LicenseTypeValueTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PharmacyFileId{ get; set; }

	}
     
	/// <summary>
    /// 卫生许可证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryHealthLicenseModel
    {
        [DataMember]
		public string HealthLicenseType{ get; set; }
        [DataMember]
		public string Header{ get; set; }
        [DataMember]
		public DateTime IssuanceDateFrom{ get; set; }
        [DataMember]
		public DateTime IssuanceDateTo{ get; set; }
        [DataMember]
		public string IssuanceOrg{ get; set; }
        [DataMember]
		public string LicenseContent{ get; set; }
        [DataMember]
		public string DocNumber{ get; set; }
        [DataMember]
		public string memo{ get; set; }
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName{ get; set; }
        [DataMember]
		public string RegAddress{ get; set; }
        [DataMember]
		public string LicenseCode{ get; set; }
        [DataMember]
		public DateTime StartDateFrom{ get; set; }
        [DataMember]
		public DateTime StartDateTo{ get; set; }
        [DataMember]
		public DateTime OutDateFrom{ get; set; }
        [DataMember]
		public DateTime OutDateTo{ get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
        public bool QueryValid = false;
        [DataMember]
		public int LicenseTypeValueFrom{ get; set; }
        [DataMember]
		public int LicenseTypeValueTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PharmacyFileId{ get; set; }

	}
     
	/// <summary>
    /// 税务登记证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryTaxRegisterLicenseModel
    {
        [DataMember]
		public string TaxRegisterLicenseType{ get; set; }
        [DataMember]
		public string taxpayerName{ get; set; }
        [DataMember]
		public string taxpayerNumber{ get; set; }
        [DataMember]
		public string LegalPerson{ get; set; }
        [DataMember]
		public string Address{ get; set; }
        [DataMember]
		public DateTime IssuanceDateFrom{ get; set; }
        [DataMember]
		public DateTime IssuanceDateTo{ get; set; }
        [DataMember]
		public string IssuanceOrg{ get; set; }
        [DataMember]
		public string BusinessScope{ get; set; }
        [DataMember]
		public string DocNumber{ get; set; }
        [DataMember]
		public string memo{ get; set; }
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName{ get; set; }
        [DataMember]
		public string RegAddress{ get; set; }
        [DataMember]
		public string LicenseCode{ get; set; }
        [DataMember]
		public DateTime StartDateFrom{ get; set; }
        [DataMember]
		public DateTime StartDateTo{ get; set; }
        [DataMember]
		public DateTime OutDateFrom{ get; set; }
        [DataMember]
		public DateTime OutDateTo{ get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom{ get; set; }
        [DataMember]
		public int LicenseTypeValueTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PharmacyFileId{ get; set; }

	}
     
	/// <summary>
    /// 事业单位法人证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryLnstitutionLegalPersonLicenseModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string CertificateName{ get; set; }
        [DataMember]
		public string BussinessRange{ get; set; }
        [DataMember]
		public string LegalPerson{ get; set; }
        [DataMember]
		public string FundsSource{ get; set; }
        [DataMember]
		public string InitiaFund{ get; set; }
        [DataMember]
		public string Address{ get; set; }
        [DataMember]
		public DateTime IssuanceDateFrom{ get; set; }
        [DataMember]
		public DateTime IssuanceDateTo{ get; set; }
        [DataMember]
		public string IssuanceOrg{ get; set; }
        [DataMember]
		public string ManageOrg{ get; set; }
        [DataMember]
		public string UseMedicalScope{ get; set; }
        [DataMember]
		public DateTime OutDateFrom{ get; set; }
        [DataMember]
		public DateTime OutDateTo{ get; set; }
        [DataMember]
		public string DocNumber{ get; set; }
        [DataMember]
		public string memo{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName{ get; set; }
        [DataMember]
		public string RegAddress{ get; set; }
        [DataMember]
		public string LicenseCode{ get; set; }
        [DataMember]
		public DateTime StartDateFrom{ get; set; }
        [DataMember]
		public DateTime StartDateTo{ get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom{ get; set; }
        [DataMember]
		public int LicenseTypeValueTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PharmacyFileId{ get; set; }

	}
     
	/// <summary>
    /// 医疗机构执业许可证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryMmedicalInstitutionPermitModel
    {
        [DataMember]
		public string Name{ get; set; }
        [DataMember]
		public string CertificateName{ get; set; }
        [DataMember]
		public string OgnTpye{ get; set; }
        [DataMember]
		public string LegalPerson{ get; set; }
        [DataMember]
		public string RegisterAddress{ get; set; }
        [DataMember]
		public string WarehouseAddress{ get; set; }
        [DataMember]
		public DateTime IssuanceDateFrom{ get; set; }
        [DataMember]
		public DateTime IssuanceDateTo{ get; set; }
        [DataMember]
		public string IssuanceOrg{ get; set; }
        [DataMember]
		public string UseMedicalScope{ get; set; }
        [DataMember]
		public DateTime OutDateFrom{ get; set; }
        [DataMember]
		public DateTime OutDateTo{ get; set; }
        [DataMember]
		public string DocNumber{ get; set; }
        [DataMember]
		public string memo{ get; set; }
        [DataMember]
		public string Decription{ get; set; }
        [DataMember]
		public string Code{ get; set; }
        [DataMember]
		public bool Enabled{ get; set; }
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName{ get; set; }
        [DataMember]
		public string RegAddress{ get; set; }
        [DataMember]
		public string LicenseCode{ get; set; }
        [DataMember]
		public DateTime StartDateFrom{ get; set; }
        [DataMember]
		public DateTime StartDateTo{ get; set; }
        [DataMember]
		public bool Valid{ get; set; }
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom{ get; set; }
        [DataMember]
		public int LicenseTypeValueTo{ get; set; }
        [DataMember]
		public Guid StoreId{ get; set; }
        [DataMember]
		public Guid PharmacyFileId{ get; set; }

	}
   
}
 
 