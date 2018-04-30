
 
 
 
 
 

 



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
		public Guid FlowId;
        [DataMember]
		public int SubFlowIdFrom;
        [DataMember]
		public int SubFlowIdTo;
        [DataMember]
		public int StatusFrom;
        [DataMember]
		public int StatusTo;
        [DataMember]
		public string ChangeNote;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid ApprovalFlowTypeId;
        [DataMember]
		public Guid NextNodeID;
        [DataMember]
		public Guid StoreId;

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
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid RoleId;
        [DataMember]
		public Guid ApprovalFlowTypeId;

	}
     
	/// <summary>
    /// 审批流程类型服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryApprovalFlowTypeModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public int ApprovalTypeValueFrom;
        [DataMember]
		public int ApprovalTypeValueTo;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 审批流程记录服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryApprovalFlowRecordModel
    {
        [DataMember]
		public Guid FlowId;
        [DataMember]
		public int SubFlowIdFrom;
        [DataMember]
		public int SubFlowIdTo;
        [DataMember]
		public Guid ApproveUserId;
        [DataMember]
		public DateTime ApproveTimeFrom;
        [DataMember]
		public DateTime ApproveTimeTo;
        [DataMember]
		public string Comment;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid ApprovalFlowNodeId;
        [DataMember]
		public Guid ApprovalFlowId;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 单据编号服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryBillDocumentCodeModel
    {
        [DataMember]
		public bool Locked;
        [DataMember]
		public bool QueryLocked=false;
        [DataMember]
		public bool Used;
        [DataMember]
		public bool QueryUsed=false;
        [DataMember]
		public Guid UsedId;
        [DataMember]
		public bool Canceled;
        [DataMember]
		public bool QueryCanceled=false;
        [DataMember]
		public string Code;
        [DataMember]
		public int BillDocumentTypeValueFrom;
        [DataMember]
		public int BillDocumentTypeValueTo;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 经营范围服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryBusinessScopeModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid BusinessScopeCategoryId;

	}
     
	/// <summary>
    /// 经营范围分类服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryBusinessScopeCategoryModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
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
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public string Name;
        [DataMember]
		public bool Enabled;
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
		public Guid PurchaseManageCategoryDetailId;
        [DataMember]
		public Guid BusinessTypeId;

	}
     
	/// <summary>
    /// 行政区域划分服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryChinaDistrictModel
    {
        [DataMember]
		public string Name;

	}
     
	/// <summary>
    /// 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDirectSalesOrderModel
    {
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public string DocumentNumber;
        [DataMember]
		public Guid SupplyUnitId;
        [DataMember]
		public Guid PurchaseUnitId;
        [DataMember]
		public int ApprovalStatusValueFrom;
        [DataMember]
		public int ApprovalStatusValueTo;
        [DataMember]
		public Guid FlowId;
        [DataMember]
		public DateTime ApprovalDateTimeFrom;
        [DataMember]
		public DateTime ApprovalDateTimeTo;
        [DataMember]
		public Guid ApprovalUserId;
        [DataMember]
		public Guid CheckUserId;
        [DataMember]
		public string CheckUserName;
        [DataMember]
		public DateTime CheckTimeFrom;
        [DataMember]
		public DateTime CheckTimeTo;
        [DataMember]
		public string CheckAddress;
        [DataMember]
		public string CheckResulty;
        [DataMember]
		public int CheckStatusValueFrom;
        [DataMember]
		public int CheckStatusValueTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public string Memo;

	}
     
	/// <summary>
    /// 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDirectSalesOrderDetailModel
    {
        [DataMember]
		public Guid DrugInfoId;
        [DataMember]
		public decimal AmountFrom;
        [DataMember]
		public decimal AmountTo;
        [DataMember]
		public string BatchNumber;
        [DataMember]
		public string Origin;
        [DataMember]
		public DateTime ProductDateFrom;
        [DataMember]
		public DateTime ProductDateTo;
        [DataMember]
		public DateTime OutValidDateFrom;
        [DataMember]
		public DateTime OutValidDateTo;
        [DataMember]
		public decimal QualityAmountFrom;
        [DataMember]
		public decimal QualityAmountTo;
        [DataMember]
		public string QualityMemo;
        [DataMember]
		public decimal UnQualityAmountFrom;
        [DataMember]
		public decimal UnQualityAmountTo;
        [DataMember]
		public string UnqualityMemo;
        [DataMember]
		public string CheckMethod;
        [DataMember]
		public Guid DirectSalesOrderId;
        [DataMember]
		public decimal SupplyPriceFrom;
        [DataMember]
		public decimal SupplyPriceTo;
        [DataMember]
		public decimal SalePriceFrom;
        [DataMember]
		public decimal SalePriceTo;
        [DataMember]
		public decimal DirectSaleDiffFrom;
        [DataMember]
		public decimal DirectSaleDiffTo;
        [DataMember]
		public int SquenceFrom;
        [DataMember]
		public int SquenceTo;

	}
     
	/// <summary>
    /// 收货拒收单服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDocumentRefuseModel
    {
        [DataMember]
		public string OrderDocumentID;
        [DataMember]
		public DateTime createTimeFrom;
        [DataMember]
		public DateTime createTimeTo;
        [DataMember]
		public string Creator;
        [DataMember]
		public DateTime updateTimeFrom;
        [DataMember]
		public DateTime updateTimeTo;
        [DataMember]
		public Guid DrugInfoID;
        [DataMember]
		public string Source;
        [DataMember]
		public string drugName;
        [DataMember]
		public string DocumentNumber;
        [DataMember]
		public decimal quantityFrom;
        [DataMember]
		public decimal quantityTo;
        [DataMember]
		public string BatchNumber;
        [DataMember]
		public string rsn;
        [DataMember]
		public string conclusion;
        [DataMember]
		public DateTime conclusionSignDateFrom;
        [DataMember]
		public DateTime conclusionSignDateTo;
        [DataMember]
		public string conclusionSigner;
        [DataMember]
		public int procFrom;
        [DataMember]
		public int procTo;
        [DataMember]
		public decimal RefuseQuantityFrom;
        [DataMember]
		public decimal RefuseQuantityTo;
        [DataMember]
		public decimal ReceiveQuantityFrom;
        [DataMember]
		public decimal ReceiveQuantityTo;
        [DataMember]
		public decimal PurchasePriceFrom;
        [DataMember]
		public decimal PurchasePriceTo;
        [DataMember]
		public string PurchaseUnitName;
        [DataMember]
		public Guid PurchaseOrderId;
        [DataMember]
		public string Specific;
        [DataMember]
		public string DosageType;

	}
     
	/// <summary>
    /// 药物库存变动历史服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugInventoryRecordHisModel
    {
        [DataMember]
		public Guid DrugInventoryRecordId;
        [DataMember]
		public Guid OperatorId;
        [DataMember]
		public string OperatorName;
        [DataMember]
		public DateTime CreateDateFrom;
        [DataMember]
		public DateTime CreateDateTo;
        [DataMember]
		public decimal PurchasePricceFrom;
        [DataMember]
		public decimal PurchasePricceTo;
        [DataMember]
		public string BatchNumber;
        [DataMember]
		public DateTime PruductDateFrom;
        [DataMember]
		public DateTime PruductDateTo;
        [DataMember]
		public DateTime OutValidDateFrom;
        [DataMember]
		public DateTime OutValidDateTo;
        [DataMember]
		public bool IsOutValidDate;
        [DataMember]
		public bool QueryIsOutValidDate=false;
        [DataMember]
		public decimal InInventoryCountFrom;
        [DataMember]
		public decimal InInventoryCountTo;
        [DataMember]
		public decimal SalesCountFrom;
        [DataMember]
		public decimal SalesCountTo;
        [DataMember]
		public decimal OnSalesOrderCountFrom;
        [DataMember]
		public decimal OnSalesOrderCountTo;
        [DataMember]
		public decimal CurrentInventoryCountFrom;
        [DataMember]
		public decimal CurrentInventoryCountTo;
        [DataMember]
		public decimal RetailCountFrom;
        [DataMember]
		public decimal RetailCountTo;
        [DataMember]
		public decimal DismantingAmountFrom;
        [DataMember]
		public decimal DismantingAmountTo;
        [DataMember]
		public decimal ChangeAmountFrom;
        [DataMember]
		public decimal ChangeAmountTo;
        [DataMember]
		public decimal RetailDismantingAmountFrom;
        [DataMember]
		public decimal RetailDismantingAmountTo;
        [DataMember]
		public decimal OnRetailCountFrom;
        [DataMember]
		public decimal OnRetailCountTo;
        [DataMember]
		public string Decription;
        [DataMember]
		public decimal CanSaleNumFrom;
        [DataMember]
		public decimal CanSaleNumTo;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public decimal DurgInventoryTypeValueFrom;
        [DataMember]
		public decimal DurgInventoryTypeValueTo;
        [DataMember]
		public Guid DrugInfoId;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public decimal PurchaseReturnNumberFrom;
        [DataMember]
		public decimal PurchaseReturnNumberTo;

	}
     
	/// <summary>
    /// 药品养护记录服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugMaintenanceRecordModel
    {
        [DataMember]
		public Guid DrugInventoryRecordId;
        [DataMember]
		public Guid UserId;
        [DataMember]
		public DateTime MaintenanceTimeFrom;
        [DataMember]
		public DateTime MaintenanceTimeTo;
        [DataMember]
		public Guid LastUserId;
        [DataMember]
		public DateTime LastMaintenanceTimeFrom;
        [DataMember]
		public DateTime LastMaintenanceTimeTo;
        [DataMember]
		public string Memo;

	}
     
	/// <summary>
    /// 报损药品服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugsBreakageModel
    {
        [DataMember]
		public Guid createUID;
        [DataMember]
		public DateTime createTimeFrom;
        [DataMember]
		public DateTime createTimeTo;
        [DataMember]
		public DateTime updateTimeFrom;
        [DataMember]
		public DateTime updateTimeTo;
        [DataMember]
		public int ApprovalStatusValueFrom;
        [DataMember]
		public int ApprovalStatusValueTo;
        [DataMember]
		public Guid flowID;
        [DataMember]
		public string Description;
        [DataMember]
		public int unqualificationTypeFrom;
        [DataMember]
		public int unqualificationTypeTo;
        [DataMember]
		public decimal quantityFrom;
        [DataMember]
		public decimal quantityTo;
        [DataMember]
		public string drugName;
        [DataMember]
		public string batchNo;
        [DataMember]
		public Guid DrugInventoryRecordID;
        [DataMember]
		public string DocumentNumber;
        [DataMember]
		public string UnqualificationDocumentNumber;
        [DataMember]
		public string source;
        [DataMember]
		public string Specific;
        [DataMember]
		public string DosageType;
        [DataMember]
		public DateTime produceDateFrom;
        [DataMember]
		public DateTime produceDateTo;
        [DataMember]
		public DateTime ExpireDateFrom;
        [DataMember]
		public DateTime ExpireDateTo;
        [DataMember]
		public Guid DrugInfoId;
        [DataMember]
		public string Origin;
        [DataMember]
		public decimal PurchasePriceFrom;
        [DataMember]
		public decimal PurchasePriceTo;
        [DataMember]
		public Guid DrugUnqualityId;
        [DataMember]
		public string FactoryName;
        [DataMember]
		public string Supplyer;
        [DataMember]
		public string PurchaseOrderDocumentNumber;
        [DataMember]
		public Guid PurchaseOrderId;

	}
     
	/// <summary>
    /// 移库服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugsInventoryMoveModel
    {
        [DataMember]
		public Guid createUID;
        [DataMember]
		public DateTime createTimeFrom;
        [DataMember]
		public DateTime createTimeTo;
        [DataMember]
		public DateTime updateTimeFrom;
        [DataMember]
		public DateTime updateTimeTo;
        [DataMember]
		public int ApprovalStatusValueFrom;
        [DataMember]
		public int ApprovalStatusValueTo;
        [DataMember]
		public Guid flowID;
        [DataMember]
		public string Description;
        [DataMember]
		public Guid OriginWareHouseID;
        [DataMember]
		public Guid WareHouseID;
        [DataMember]
		public decimal quantityFrom;
        [DataMember]
		public decimal quantityTo;
        [DataMember]
		public string drugName;
        [DataMember]
		public string batchNo;
        [DataMember]
		public Guid inventoryRecordID;

	}
     
	/// <summary>
    /// 待处理药品服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugsUndeterminateModel
    {
        [DataMember]
		public string OrderDocumentID;
        [DataMember]
		public DateTime createTimeFrom;
        [DataMember]
		public DateTime createTimeTo;
        [DataMember]
		public string creater;
        [DataMember]
		public DateTime updateTimeFrom;
        [DataMember]
		public DateTime updateTimeTo;
        [DataMember]
		public Guid DrugInfoID;
        [DataMember]
		public string Source;
        [DataMember]
		public string DocumentNumber;
        [DataMember]
		public decimal quantityFrom;
        [DataMember]
		public decimal quantityTo;
        [DataMember]
		public string drugName;
        [DataMember]
		public string BatchNumber;
        [DataMember]
		public string wareHouse;
        [DataMember]
		public string rsn;
        [DataMember]
		public string sta;
        [DataMember]
		public string staSigner;
        [DataMember]
		public DateTime staSignDateFrom;
        [DataMember]
		public DateTime staSignDateTo;
        [DataMember]
		public string conclusion;
        [DataMember]
		public string conclusionSigner;
        [DataMember]
		public DateTime conclusionDateFrom;
        [DataMember]
		public DateTime conclusionDateTo;
        [DataMember]
		public int procFrom;
        [DataMember]
		public int procTo;
        [DataMember]
		public decimal QualificationQuantityFrom;
        [DataMember]
		public decimal QualificationQuantityTo;
        [DataMember]
		public decimal UnqualificationQuantityFrom;
        [DataMember]
		public decimal UnqualificationQuantityTo;
        [DataMember]
		public DateTime produceDateFrom;
        [DataMember]
		public DateTime produceDateTo;
        [DataMember]
		public DateTime ExpireDateFrom;
        [DataMember]
		public DateTime ExpireDateTo;
        [DataMember]
		public string supplyer;
        [DataMember]
		public decimal PurchasePriceFrom;
        [DataMember]
		public decimal PurchasePriceTo;
        [DataMember]
		public Guid InventoryID;
        [DataMember]
		public Guid UnqualificationApprovalID;
        [DataMember]
		public Guid storeID;
        [DataMember]
		public string Specific;
        [DataMember]
		public string DosageType;
        [DataMember]
		public string Origin;

	}
     
	/// <summary>
    /// 不合格药品服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugsUnqualicationModel
    {
        [DataMember]
		public Guid createUID;
        [DataMember]
		public DateTime createTimeFrom;
        [DataMember]
		public DateTime createTimeTo;
        [DataMember]
		public DateTime updateTimeFrom;
        [DataMember]
		public DateTime updateTimeTo;
        [DataMember]
		public int ApprovalStatusValueFrom;
        [DataMember]
		public int ApprovalStatusValueTo;
        [DataMember]
		public Guid flowID;
        [DataMember]
		public string Description;
        [DataMember]
		public int unqualificationTypeFrom;
        [DataMember]
		public int unqualificationTypeTo;
        [DataMember]
		public decimal quantityFrom;
        [DataMember]
		public decimal quantityTo;
        [DataMember]
		public string drugName;
        [DataMember]
		public string batchNo;
        [DataMember]
		public Guid DrugInventoryRecordID;
        [DataMember]
		public string DocumentNumber;
        [DataMember]
		public string CheckDocumentNumber;
        [DataMember]
		public string source;
        [DataMember]
		public string Specific;
        [DataMember]
		public string DosageType;
        [DataMember]
		public DateTime produceDateFrom;
        [DataMember]
		public DateTime produceDateTo;
        [DataMember]
		public DateTime ExpireDateFrom;
        [DataMember]
		public DateTime ExpireDateTo;
        [DataMember]
		public decimal PurchasePriceFrom;
        [DataMember]
		public decimal PurchasePriceTo;
        [DataMember]
		public string factoryName;
        [DataMember]
		public string Origin;
        [DataMember]
		public Guid DrugInfo;
        [DataMember]
		public string Supplyer;
        [DataMember]
		public string PurchaseOrderDocumentNumber;
        [DataMember]
		public Guid PurchaseOrderId;

	}
     
	/// <summary>
    /// 不合格药品销毁情况服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugsUnqualificationDestroyModel
    {
        [DataMember]
		public Guid createUID;
        [DataMember]
		public DateTime createTimeFrom;
        [DataMember]
		public DateTime createTimeTo;
        [DataMember]
		public DateTime updateTimeFrom;
        [DataMember]
		public DateTime updateTimeTo;
        [DataMember]
		public string drugName;
        [DataMember]
		public string batchNo;
        [DataMember]
		public string FactoryName;
        [DataMember]
		public decimal priceFrom;
        [DataMember]
		public decimal priceTo;
        [DataMember]
		public string wareHouseZone;
        [DataMember]
		public string DestroyMethod;
        [DataMember]
		public string DestroyReason;
        [DataMember]
		public string DestroyPlace;
        [DataMember]
		public DateTime DestroyTimeFrom;
        [DataMember]
		public DateTime DestroyTimeTo;
        [DataMember]
		public string DestroyCargo;
        [DataMember]
		public string DestroyMan;
        [DataMember]
		public string Destroyer;
        [DataMember]
		public string DestroyState;
        [DataMember]
		public string SupervisorOpinion;
        [DataMember]
		public Guid DrugsUnqualicationID;
        [DataMember]
		public string Specific;
        [DataMember]
		public string DosageType;
        [DataMember]
		public DateTime produceDateFrom;
        [DataMember]
		public DateTime produceDateTo;
        [DataMember]
		public DateTime ExpireDateFrom;
        [DataMember]
		public DateTime ExpireDateTo;
        [DataMember]
		public Guid DrugInfoId;
        [DataMember]
		public string Origin;
        [DataMember]
		public decimal PurchasePriceFrom;
        [DataMember]
		public decimal PurchasePriceTo;

	}
     
	/// <summary>
    /// 培训档案细节服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryEduDetailsModel
    {
        [DataMember]
		public Guid DocumentId;
        [DataMember]
		public bool IsEduPass;
        [DataMember]
		public bool QueryIsEduPass=false;
        [DataMember]
		public string Memo;
        [DataMember]
		public DateTime createTimeFrom;
        [DataMember]
		public DateTime createTimeTo;
        [DataMember]
		public DateTime updateTimeFrom;
        [DataMember]
		public DateTime updateTimeTo;
        [DataMember]
		public DateTime f1From;
        [DataMember]
		public DateTime f1To;
        [DataMember]
		public decimal f2From;
        [DataMember]
		public decimal f2To;
        [DataMember]
		public decimal f3From;
        [DataMember]
		public decimal f3To;
        [DataMember]
		public string f4;
        [DataMember]
		public string f5;
        [DataMember]
		public Guid EmployeeId;

	}
     
	/// <summary>
    /// 培训档案服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryEduDocumentModel
    {
        [DataMember]
		public string eduDocumentNumber;
        [DataMember]
		public string eduDocumentName;
        [DataMember]
		public DateTime eduTimeStartFrom;
        [DataMember]
		public DateTime eduTimeStartTo;
        [DataMember]
		public DateTime eduTimeEndFrom;
        [DataMember]
		public DateTime eduTimeEndTo;
        [DataMember]
		public string eduContext;
        [DataMember]
		public string eduOrganize;
        [DataMember]
		public string eduTeacher;
        [DataMember]
		public string eduAdress;
        [DataMember]
		public string eduEployees;
        [DataMember]
		public decimal eduEployeesSumFrom;
        [DataMember]
		public decimal eduEployeesSumTo;
        [DataMember]
		public decimal eduEployeesPassNumberFrom;
        [DataMember]
		public decimal eduEployeesPassNumberTo;
        [DataMember]
		public string Memo;
        [DataMember]
		public DateTime createTimeFrom;
        [DataMember]
		public DateTime createTimeTo;
        [DataMember]
		public DateTime updateTimeFrom;
        [DataMember]
		public DateTime updateTimeTo;
        [DataMember]
		public DateTime f1From;
        [DataMember]
		public DateTime f1To;
        [DataMember]
		public decimal f2From;
        [DataMember]
		public decimal f2To;
        [DataMember]
		public decimal f3From;
        [DataMember]
		public decimal f3To;
        [DataMember]
		public string f4;
        [DataMember]
		public string f5;

	}
     
	/// <summary>
    /// 商品附加属性服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryGoodsAdditionalPropertyModel
    {
        [DataMember]
		public string CareFunction;
        [DataMember]
		public string PutOnRecord;
        [DataMember]
		public DateTime PutOnRecordDateFrom;
        [DataMember]
		public DateTime PutOnRecordDateTo;
        [DataMember]
		public string NotSuitablePeople;
        [DataMember]
		public string SuitablePeople;
        [DataMember]
		public string LandmarkIngredient;
        [DataMember]
		public DateTime LicensePermissionDateFrom;
        [DataMember]
		public DateTime LicensePermissionDateTo;
        [DataMember]
		public string UsageAndDosage;
        [DataMember]
		public string MainIngredient;
        [DataMember]
		public string ProductAddress;
        [DataMember]
		public string ProductAddressEnglish;
        [DataMember]
		public string ProductCountry;
        [DataMember]
		public string ProductCountryEnglish;
        [DataMember]
		public string HealthPermit;
        [DataMember]
		public string RegCode;
        [DataMember]
		public string RegProxyCompany;
        [DataMember]
		public string FactoryNameEnglish;
        [DataMember]
		public string FactoryAddress;
        [DataMember]
		public string FactoryAddressEnglish;
        [DataMember]
		public Guid DrugInfoId;

	}
     
	/// <summary>
    /// 体检档案细节服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryHealthCheckDetailModel
    {
        [DataMember]
		public Guid DocumentId;
        [DataMember]
		public string CheckYear;
        [DataMember]
		public string Medicine;
        [DataMember]
		public string Skin;
        [DataMember]
		public string XCheck;
        [DataMember]
		public string Hepatitis;
        [DataMember]
		public string Optometry;
        [DataMember]
		public string CheckResult;
        [DataMember]
		public string Memo;
        [DataMember]
		public bool IsCheckPass;
        [DataMember]
		public bool QueryIsCheckPass=false;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public DateTime createTimeFrom;
        [DataMember]
		public DateTime createTimeTo;
        [DataMember]
		public DateTime updateTimeFrom;
        [DataMember]
		public DateTime updateTimeTo;
        [DataMember]
		public DateTime f1From;
        [DataMember]
		public DateTime f1To;
        [DataMember]
		public decimal f2From;
        [DataMember]
		public decimal f2To;
        [DataMember]
		public decimal f3From;
        [DataMember]
		public decimal f3To;
        [DataMember]
		public string f4;
        [DataMember]
		public string f5;
        [DataMember]
		public Guid EmployeeId;

	}
     
	/// <summary>
    /// 体检档案服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryHealthCheckDocumentModel
    {
        [DataMember]
		public string DocumentNumber;
        [DataMember]
		public string DocumentName;
        [DataMember]
		public DateTime CheckTimeFrom;
        [DataMember]
		public DateTime CheckTimeTo;
        [DataMember]
		public string CheckContext;
        [DataMember]
		public string CheckOrganize;
        [DataMember]
		public string CheckAdress;
        [DataMember]
		public string MedicineDoctor;
        [DataMember]
		public string SkinDoctor;
        [DataMember]
		public string XCheckDoctor;
        [DataMember]
		public string HepatitisDoctor;
        [DataMember]
		public string OptometryDoctor;
        [DataMember]
		public string ChargeDoctor;
        [DataMember]
		public string IssuanceOrg;
        [DataMember]
		public string CheckEployees;
        [DataMember]
		public decimal CheckEployeesSumFrom;
        [DataMember]
		public decimal CheckEployeesSumTo;
        [DataMember]
		public decimal CheckPassNumberFrom;
        [DataMember]
		public decimal CheckPassNumberTo;
        [DataMember]
		public string Memo;
        [DataMember]
		public DateTime createTimeFrom;
        [DataMember]
		public DateTime createTimeTo;
        [DataMember]
		public DateTime updateTimeFrom;
        [DataMember]
		public DateTime updateTimeTo;
        [DataMember]
		public DateTime f1From;
        [DataMember]
		public DateTime f1To;
        [DataMember]
		public decimal f2From;
        [DataMember]
		public decimal f2To;
        [DataMember]
		public decimal f3From;
        [DataMember]
		public decimal f3To;
        [DataMember]
		public string f4;
        [DataMember]
		public string f5;

	}
     
	/// <summary>
    /// 采购结算单服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseCashOrderModel
    {
        [DataMember]
		public string DocumentNumber;
        [DataMember]
		public DateTime OperateTimeFrom;
        [DataMember]
		public DateTime OperateTimeTo;
        [DataMember]
		public Guid OperateUserId;
        [DataMember]
		public int OrderStatusValueFrom;
        [DataMember]
		public int OrderStatusValueTo;
        [DataMember]
		public Guid ApprovalUserId;
        [DataMember]
		public string ApprovalDecription;
        [DataMember]
		public DateTime PaymentTimeFrom;
        [DataMember]
		public DateTime PaymentTimeTo;
        [DataMember]
		public Guid PaymentMethodId;
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
		public string Decription;
        [DataMember]
		public Guid RelatedOrderId;
        [DataMember]
		public string RelatedOrderDocumentNumber;
        [DataMember]
		public int RelatedOrderTypeValueFrom;
        [DataMember]
		public int RelatedOrderTypeValueTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PurchaseOrderId;

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
		public string ShippingAddress;
        [DataMember]
		public Guid ReceivingCompasnyID;
        [DataMember]
		public string DeliveryAddress;
        [DataMember]
		public string ManifestNumber;
        [DataMember]
		public decimal DrugsCountFrom;
        [DataMember]
		public decimal DrugsCountTo;
        [DataMember]
		public int DeliveryMethodValueFrom;
        [DataMember]
		public int DeliveryMethodValueTo;
        [DataMember]
		public int TransportMethodValueFrom;
        [DataMember]
		public int TransportMethodValueTo;
        [DataMember]
		public string Principal;
        [DataMember]
		public string PrincipalPhone;
        [DataMember]
		public string TransportCompany;
        [DataMember]
		public string VehicleInfo;
        [DataMember]
		public Guid VehicleID;
        [DataMember]
		public int DeliveryStatusValueFrom;
        [DataMember]
		public int DeliveryStatusValueTo;
        [DataMember]
		public string Memo;
        [DataMember]
		public bool IsOver;
        [DataMember]
		public bool QueryIsOver=false;
        [DataMember]
		public DateTime ReservationTimeFrom;
        [DataMember]
		public DateTime ReservationTimeTo;
        [DataMember]
		public Guid ReservationOperatorId;
        [DataMember]
		public string ReservationNo;
        [DataMember]
		public DateTime AcceptedTimeFrom;
        [DataMember]
		public DateTime AcceptedTimeTo;
        [DataMember]
		public Guid AcceptedOperatorId;
        [DataMember]
		public string AcceptedNo;
        [DataMember]
		public DateTime CanceledTimeFrom;
        [DataMember]
		public DateTime CanceledTimeTo;
        [DataMember]
		public Guid CanceledOperatorId;
        [DataMember]
		public string CanceledNo;
        [DataMember]
		public DateTime outedTimeFrom;
        [DataMember]
		public DateTime outedTimeTo;
        [DataMember]
		public Guid outedOperatorId;
        [DataMember]
		public string outedNo;
        [DataMember]
		public DateTime SignedTimeFrom;
        [DataMember]
		public DateTime SignedTimeTo;
        [DataMember]
		public Guid SignedOperatorId;
        [DataMember]
		public string SignedNo;
        [DataMember]
		public DateTime ReturnTimeFrom;
        [DataMember]
		public DateTime ReturnTimeTo;
        [DataMember]
		public Guid ReturnOperatorId;
        [DataMember]
		public string ReturnNo;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid OrderID;
        [DataMember]
		public Guid OutInventoryID;
        [DataMember]
		public Guid OwnVehicleID;

	}
     
	/// <summary>
    /// 部门服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDepartmentModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid DepartmentId;

	}
     
	/// <summary>
    /// 区域服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDistrictModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 疑问药品服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDoubtDrugModel
    {
        [DataMember]
		public string JsonDrugInventoryRecord;
        [DataMember]
		public string Decription;
        [DataMember]
		public bool Handled;
        [DataMember]
		public bool QueryHandled=false;
        [DataMember]
		public string HandleDecription;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid DrugInventoryRecordId;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 药品批准文号服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugApprovalNumberModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 药物分类服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugCategoryModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 药物临床分类服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugClinicalCategoryModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
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
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
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
		public string PermitLicenseCode;
        [DataMember]
		public string Code;
        [DataMember]
		public string DocCode;
        [DataMember]
		public string Pinyin;
        [DataMember]
		public string Description;
        [DataMember]
		public string BarCode;
        [DataMember]
		public string StandardCode;
        [DataMember]
		public string ProductName;
        [DataMember]
		public string ProductEnglishName;
        [DataMember]
		public string ProductGeneralName;
        [DataMember]
		public string ProductOtherName;
        [DataMember]
		public string FactoryName;
        [DataMember]
		public string FactoryNameAbbreviation;
        [DataMember]
		public string PiecemealSpecification;
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
		public bool IsMedicalInsurance;
        [DataMember]
		public bool QueryIsMedicalInsurance=false;
        [DataMember]
		public bool IsPrescription;
        [DataMember]
		public bool QueryIsPrescription=false;
        [DataMember]
		public bool IsImport;
        [DataMember]
		public bool QueryIsImport=false;
        [DataMember]
		public bool IsMainMaintenance;
        [DataMember]
		public bool QueryIsMainMaintenance=false;
        [DataMember]
		public bool IsSpecialDrugCategory;
        [DataMember]
		public bool QueryIsSpecialDrugCategory=false;
        [DataMember]
		public string SpecialDrugCategoryCode;
        [DataMember]
		public int ValidPeriodFrom;
        [DataMember]
		public int ValidPeriodTo;
        [DataMember]
		public string LicensePermissionNumber;
        [DataMember]
		public string PerformanceStandards;
        [DataMember]
		public string Package;
        [DataMember]
		public int PackageAmountFrom;
        [DataMember]
		public int PackageAmountTo;
        [DataMember]
		public Guid WareHouses;
        [DataMember]
		public string WareHouseZones;
        [DataMember]
		public decimal BigPackageFrom;
        [DataMember]
		public decimal BigPackageTo;
        [DataMember]
		public decimal MiddlePackageFrom;
        [DataMember]
		public decimal MiddlePackageTo;
        [DataMember]
		public int SmallPackageFrom;
        [DataMember]
		public int SmallPackageTo;
        [DataMember]
		public bool IsApproval;
        [DataMember]
		public bool QueryIsApproval=false;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public string ValidRemark;
        [DataMember]
		public bool IsLock;
        [DataMember]
		public bool QueryIsLock=false;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string LockRemark;
        [DataMember]
		public DateTime PermitDateFrom;
        [DataMember]
		public DateTime PermitDateTo;
        [DataMember]
		public DateTime PermitOutDateFrom;
        [DataMember]
		public DateTime PermitOutDateTo;
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
		public string Origin;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public string BusinessScopeCode;
        [DataMember]
		public string PurchaseManageCategoryDetailCode;
        [DataMember]
		public string DrugCategoryCode;
        [DataMember]
		public string MedicalCategoryDetailCode;
        [DataMember]
		public string DrugClinicalCategoryCode;
        [DataMember]
		public string DictionaryUserDefinedTypeCode;
        [DataMember]
		public string DrugStorageTypeCode;
        [DataMember]
		public string DictionaryMeasurementUnitCode;
        [DataMember]
		public string DictionaryDosageCode;
        [DataMember]
		public string DictionarySpecificationCode;
        [DataMember]
		public string DictionaryPiecemealUnitCode;
        [DataMember]
		public Guid FlowID;
        [DataMember]
		public int GoodsTypeValueFrom;
        [DataMember]
		public int GoodsTypeValueTo;
        [DataMember]
		public int ApprovalStatusValueFrom;
        [DataMember]
		public int ApprovalStatusValueTo;
        [DataMember]
		public string Function;
        [DataMember]
		public string Ingredient;
        [DataMember]
		public string CommendedUser;
        [DataMember]
		public string InstEntProductLiscencePermitNumber;

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
		public string BatchNumber;
        [DataMember]
		public DateTime PruductDateFrom;
        [DataMember]
		public DateTime PruductDateTo;
        [DataMember]
		public DateTime OutValidDateFrom;
        [DataMember]
		public DateTime OutValidDateTo;
        [DataMember]
		public bool IsOutValidDate;
        [DataMember]
		public bool QueryIsOutValidDate=false;
        [DataMember]
		public decimal InInventoryCountFrom;
        [DataMember]
		public decimal InInventoryCountTo;
        [DataMember]
		public decimal SalesCountFrom;
        [DataMember]
		public decimal SalesCountTo;
        [DataMember]
		public decimal OnSalesOrderCountFrom;
        [DataMember]
		public decimal OnSalesOrderCountTo;
        [DataMember]
		public decimal CurrentInventoryCountFrom;
        [DataMember]
		public decimal CurrentInventoryCountTo;
        [DataMember]
		public decimal RetailCountFrom;
        [DataMember]
		public decimal RetailCountTo;
        [DataMember]
		public decimal DismantingAmountFrom;
        [DataMember]
		public decimal DismantingAmountTo;
        [DataMember]
		public decimal RetailDismantingAmountFrom;
        [DataMember]
		public decimal RetailDismantingAmountTo;
        [DataMember]
		public decimal OnRetailCountFrom;
        [DataMember]
		public decimal OnRetailCountTo;
        [DataMember]
		public string Decription;
        [DataMember]
		public decimal CanSaleNumFrom;
        [DataMember]
		public decimal CanSaleNumTo;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public decimal DurgInventoryTypeValueFrom;
        [DataMember]
		public decimal DurgInventoryTypeValueTo;
        [DataMember]
		public Guid DrugInfoId;
        [DataMember]
		public Guid PurchaseInInventeryOrderDetailId;
        [DataMember]
		public Guid WarehouseZoneId;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid drugsUnqualicationID;
        [DataMember]
		public decimal drugsUnqualicationNumFrom;
        [DataMember]
		public decimal drugsUnqualicationNumTo;
        [DataMember]
		public decimal PurchaseReturnNumberFrom;
        [DataMember]
		public decimal PurchaseReturnNumberTo;
        [DataMember]
		public Guid WareHouseZonePositionId;

	}
     
	/// <summary>
    /// 药品养护记录服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugMaintainRecordModel
    {
        [DataMember]
		public string BillDocumentNo;
        [DataMember]
		public DateTime ExpirationDateFrom;
        [DataMember]
		public DateTime ExpirationDateTo;
        [DataMember]
		public int DrugMaintainTypeValueFrom;
        [DataMember]
		public int DrugMaintainTypeValueTo;
        [DataMember]
		public int CompleteStateFrom;
        [DataMember]
		public int CompleteStateTo;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid UpdateUserId;

	}
     
	/// <summary>
    /// 药品养护记录明细服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDrugMaintainRecordDetailModel
    {
        [DataMember]
		public Guid DrugInventoryRecordId;
        [DataMember]
		public string BillDocumentNo;
        [DataMember]
		public string ProductName;
        [DataMember]
		public string DictionaryDosageCode;
        [DataMember]
		public string DictionarySpecificationCode;
        [DataMember]
		public decimal CurrentInventoryCountFrom;
        [DataMember]
		public decimal CurrentInventoryCountTo;
        [DataMember]
		public decimal MaintainCountFrom;
        [DataMember]
		public decimal MaintainCountTo;
        [DataMember]
		public decimal PriceFrom;
        [DataMember]
		public decimal PriceTo;
        [DataMember]
		public string Origin;
        [DataMember]
		public string LicensePermissionNumber;
        [DataMember]
		public string BatchNumber;
        [DataMember]
		public DateTime PruductDateFrom;
        [DataMember]
		public DateTime PruductDateTo;
        [DataMember]
		public DateTime OutValidDateFrom;
        [DataMember]
		public DateTime OutValidDateTo;
        [DataMember]
		public string Manufacturer;
        [DataMember]
		public string DictionaryMeasurementUnitCode;
        [DataMember]
		public string QualitySituation;
        [DataMember]
		public string MaintainResult;
        [DataMember]
		public string CheckqualifiedNumber;
        [DataMember]
		public string CheckResult;

	}
     
	/// <summary>
    /// 计量单位服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDictionaryMeasurementUnitModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
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
		public string Name;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
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
		public string Name;
        [DataMember]
		public string Code;

	}
     
	/// <summary>
    /// 储藏方式服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryDictionaryStorageTypeModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
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
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 授权书服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryAuthorizationDocModel
    {
        [DataMember]
		public string DocFile;
        [DataMember]
		public string Description;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public bool IsOutDate;
        [DataMember]
		public bool QueryIsOutDate=false;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid StoreId;
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
		public int DrugMaintainTypeValueFrom;
        [DataMember]
		public int DrugMaintainTypeValueTo;
        [DataMember]
		public string Name;
        [DataMember]
		public int DayFrom;
        [DataMember]
		public int DayTo;
        [DataMember]
		public DateTime StartDateFrom;
        [DataMember]
		public DateTime StartDateTo;
        [DataMember]
		public int RemindBeforeDayFrom;
        [DataMember]
		public int RemindBeforeDayTo;

	}
     
	/// <summary>
    /// 员工服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryEmployeeModel
    {
        [DataMember]
		public string Number;
        [DataMember]
		public string Name;
        [DataMember]
		public string Pinyin;
        [DataMember]
		public string Gender;
        [DataMember]
		public string Phone;
        [DataMember]
		public string Email;
        [DataMember]
		public string Address;
        [DataMember]
		public string Rank;
        [DataMember]
		public string Education;
        [DataMember]
		public string Specility;
        [DataMember]
		public string Duty;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public int EmployStatusValueFrom;
        [DataMember]
		public int EmployStatusValueTo;
        [DataMember]
		public int PharmacistsTitleTypeValueFrom;
        [DataMember]
		public int PharmacistsTitleTypeValueTo;
        [DataMember]
		public string CardNo;
        [DataMember]
		public DateTime CardDateFrom;
        [DataMember]
		public DateTime CardDateTo;
        [DataMember]
		public int PharmacistsQualificationValueFrom;
        [DataMember]
		public int PharmacistsQualificationValueTo;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid DepartmentId;
        [DataMember]
		public bool Pro_work_exam;
        [DataMember]
		public bool QueryPro_work_exam=false;
        [DataMember]
		public DateTime Pro_work_exam_DateFrom;
        [DataMember]
		public DateTime Pro_work_exam_DateTo;

	}
     
	/// <summary>
    /// GMSP证书规定的经营范围服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryGMSPLicenseBusinessScopeModel
    {
        [DataMember]
		public Guid LicenseId;
        [DataMember]
		public Guid BusinessScopeId;
        [DataMember]
		public Guid GSPLicenseId;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 库存服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryInventoryRecordModel
    {
        [DataMember]
		public decimal MaxInventoryCountFrom;
        [DataMember]
		public decimal MaxInventoryCountTo;
        [DataMember]
		public decimal MinInventoryCountFrom;
        [DataMember]
		public decimal MinInventoryCountTo;
        [DataMember]
		public decimal CurrentInventoryCountFrom;
        [DataMember]
		public decimal CurrentInventoryCountTo;
        [DataMember]
		public decimal SalesCountFrom;
        [DataMember]
		public decimal SalesCountTo;
        [DataMember]
		public decimal OnSalesOrderCountFrom;
        [DataMember]
		public decimal OnSalesOrderCountTo;
        [DataMember]
		public decimal RetailCountFrom;
        [DataMember]
		public decimal RetailCountTo;
        [DataMember]
		public decimal OnRetailCountFrom;
        [DataMember]
		public decimal OnRetailCountTo;
        [DataMember]
		public decimal DismantingAmountFrom;
        [DataMember]
		public decimal DismantingAmountTo;
        [DataMember]
		public decimal RetailDismantingAmountFrom;
        [DataMember]
		public decimal RetailDismantingAmountTo;
        [DataMember]
		public Guid DrugInfoId;
        [DataMember]
		public string DrugInfoCode;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 生产厂家 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryManufacturerModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string ShortPinYin;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string Address;
        [DataMember]
		public string Tel;
        [DataMember]
		public string Contact;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 包装材质服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPackagingMaterialModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
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
		public string Name;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
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
		public string Name;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 药品经营许可证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryGSPLicenseModel
    {
        [DataMember]
		public string LegalPerson;
        [DataMember]
		public string Header;
        [DataMember]
		public string QualityHeader;
        [DataMember]
		public string WarehouseAddress;
        [DataMember]
		public string ChangeRecord;
        [DataMember]
		public Guid BusinessTypeId;
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName;
        [DataMember]
		public string RegAddress;
        [DataMember]
		public string LicenseCode;
        [DataMember]
		public DateTime StartDateFrom;
        [DataMember]
		public DateTime StartDateTo;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public DateTime IssuanceDateFrom;
        [DataMember]
		public DateTime IssuanceDateTo;
        [DataMember]
		public string IssuanceOrg;
        [DataMember]
		public string DocNumber;
        [DataMember]
		public string memo;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom;
        [DataMember]
		public int LicenseTypeValueTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PharmacyFileId;

	}
     
	/// <summary>
    /// GMP证书服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryGMPLicenseModel
    {
        [DataMember]
		public string CertificationScope;
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName;
        [DataMember]
		public string RegAddress;
        [DataMember]
		public string LicenseCode;
        [DataMember]
		public DateTime StartDateFrom;
        [DataMember]
		public DateTime StartDateTo;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public DateTime IssuanceDateFrom;
        [DataMember]
		public DateTime IssuanceDateTo;
        [DataMember]
		public string IssuanceOrg;
        [DataMember]
		public string DocNumber;
        [DataMember]
		public string memo;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom;
        [DataMember]
		public int LicenseTypeValueTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PharmacyFileId;

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
		public string CorporateNature;
        [DataMember]
		public string BusinessScope;
        [DataMember]
		public DateTime EstablishmentDateFrom;
        [DataMember]
		public DateTime EstablishmentDateTo;
        [DataMember]
		public string InspectionDate;
        [DataMember]
		public string DocNumber;
        [DataMember]
		public string memo;
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName;
        [DataMember]
		public string RegAddress;
        [DataMember]
		public string LicenseCode;
        [DataMember]
		public DateTime StartDateFrom;
        [DataMember]
		public DateTime StartDateTo;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public DateTime IssuanceDateFrom;
        [DataMember]
		public DateTime IssuanceDateTo;
        [DataMember]
		public string IssuanceOrg;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom;
        [DataMember]
		public int LicenseTypeValueTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PharmacyFileId;

	}
     
	/// <summary>
    /// 药品生产许可证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryMedicineProductionLicenseModel
    {
        [DataMember]
		public string LegalPerson;
        [DataMember]
		public string Header;
        [DataMember]
		public string ProductAddress;
        [DataMember]
		public string CorporateNature;
        [DataMember]
		public string CategoryCode;
        [DataMember]
		public string ProductScope;
        [DataMember]
		public string DocNumber;
        [DataMember]
		public string memo;
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName;
        [DataMember]
		public string RegAddress;
        [DataMember]
		public string LicenseCode;
        [DataMember]
		public DateTime StartDateFrom;
        [DataMember]
		public DateTime StartDateTo;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public DateTime IssuanceDateFrom;
        [DataMember]
		public DateTime IssuanceDateTo;
        [DataMember]
		public string IssuanceOrg;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom;
        [DataMember]
		public int LicenseTypeValueTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PharmacyFileId;

	}
     
	/// <summary>
    /// GSP证书服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryMedicineBusinessLicenseModel
    {
        [DataMember]
		public string LegalPerson;
        [DataMember]
		public string Header;
        [DataMember]
		public string QualityHeader;
        [DataMember]
		public string WarehouseAddress;
        [DataMember]
		public string BusinessScope;
        [DataMember]
		public string LicenseContain;
        [DataMember]
		public string DocNumber;
        [DataMember]
		public string memo;
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName;
        [DataMember]
		public string RegAddress;
        [DataMember]
		public string LicenseCode;
        [DataMember]
		public DateTime StartDateFrom;
        [DataMember]
		public DateTime StartDateTo;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public DateTime IssuanceDateFrom;
        [DataMember]
		public DateTime IssuanceDateTo;
        [DataMember]
		public string IssuanceOrg;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom;
        [DataMember]
		public int LicenseTypeValueTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PharmacyFileId;

	}
     
	/// <summary>
    /// 器械经营许可证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryInstrumentsBusinessLicenseModel
    {
        [DataMember]
		public string LegalPerson;
        [DataMember]
		public string Header;
        [DataMember]
		public string QualityHeader;
        [DataMember]
		public string WarehouseAddress;
        [DataMember]
		public string BusinessScope;
        [DataMember]
		public string DocNumber;
        [DataMember]
		public string memo;
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName;
        [DataMember]
		public string RegAddress;
        [DataMember]
		public string LicenseCode;
        [DataMember]
		public DateTime StartDateFrom;
        [DataMember]
		public DateTime StartDateTo;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public DateTime IssuanceDateFrom;
        [DataMember]
		public DateTime IssuanceDateTo;
        [DataMember]
		public string IssuanceOrg;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom;
        [DataMember]
		public int LicenseTypeValueTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PharmacyFileId;

	}
     
	/// <summary>
    /// 器械生产许可证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryInstrumentsProductionLicenseModel
    {
        [DataMember]
		public string LegalPerson;
        [DataMember]
		public string Header;
        [DataMember]
		public string ProductAddress;
        [DataMember]
		public string ProductScope;
        [DataMember]
		public string DocNumber;
        [DataMember]
		public string memo;
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName;
        [DataMember]
		public string RegAddress;
        [DataMember]
		public string LicenseCode;
        [DataMember]
		public DateTime StartDateFrom;
        [DataMember]
		public DateTime StartDateTo;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public DateTime IssuanceDateFrom;
        [DataMember]
		public DateTime IssuanceDateTo;
        [DataMember]
		public string IssuanceOrg;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom;
        [DataMember]
		public int LicenseTypeValueTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PharmacyFileId;

	}
     
	/// <summary>
    /// 组织机构代码证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryOrganizationCodeLicenseModel
    {
        [DataMember]
		public string OrgnizationType;
        [DataMember]
		public string LicenseNo;
        [DataMember]
		public string RegisterNo;
        [DataMember]
		public DateTime IssuanceDateFrom;
        [DataMember]
		public DateTime IssuanceDateTo;
        [DataMember]
		public string IssuanceOrg;
        [DataMember]
		public bool isCheck;
        [DataMember]
		public bool QueryisCheck=false;
        [DataMember]
		public DateTime YearCheckDateFrom;
        [DataMember]
		public DateTime YearCheckDateTo;
        [DataMember]
		public string DocNumber;
        [DataMember]
		public string memo;
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName;
        [DataMember]
		public string RegAddress;
        [DataMember]
		public string LicenseCode;
        [DataMember]
		public DateTime StartDateFrom;
        [DataMember]
		public DateTime StartDateTo;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom;
        [DataMember]
		public int LicenseTypeValueTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PharmacyFileId;

	}
     
	/// <summary>
    /// 食品流通许可证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryFoodCirculateLicenseModel
    {
        [DataMember]
		public string OrgType;
        [DataMember]
		public string RegAddress;
        [DataMember]
		public string LicenseNo;
        [DataMember]
		public string Header;
        [DataMember]
		public DateTime LicenseRangeFrom;
        [DataMember]
		public DateTime LicenseRangeTo;
        [DataMember]
		public string IssuanceOrg;
        [DataMember]
		public string DocNumber;
        [DataMember]
		public string memo;
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName;
        [DataMember]
		public string LicenseCode;
        [DataMember]
		public DateTime StartDateFrom;
        [DataMember]
		public DateTime StartDateTo;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public DateTime IssuanceDateFrom;
        [DataMember]
		public DateTime IssuanceDateTo;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom;
        [DataMember]
		public int LicenseTypeValueTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PharmacyFileId;

	}
     
	/// <summary>
    /// 卫生许可证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryHealthLicenseModel
    {
        [DataMember]
		public string HealthLicenseType;
        [DataMember]
		public string Header;
        [DataMember]
		public DateTime IssuanceDateFrom;
        [DataMember]
		public DateTime IssuanceDateTo;
        [DataMember]
		public string IssuanceOrg;
        [DataMember]
		public string LicenseContent;
        [DataMember]
		public string DocNumber;
        [DataMember]
		public string memo;
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName;
        [DataMember]
		public string RegAddress;
        [DataMember]
		public string LicenseCode;
        [DataMember]
		public DateTime StartDateFrom;
        [DataMember]
		public DateTime StartDateTo;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom;
        [DataMember]
		public int LicenseTypeValueTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PharmacyFileId;

	}
     
	/// <summary>
    /// 税务登记证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryTaxRegisterLicenseModel
    {
        [DataMember]
		public string TaxRegisterLicenseType;
        [DataMember]
		public string taxpayerName;
        [DataMember]
		public string taxpayerNumber;
        [DataMember]
		public string LegalPerson;
        [DataMember]
		public string Address;
        [DataMember]
		public DateTime IssuanceDateFrom;
        [DataMember]
		public DateTime IssuanceDateTo;
        [DataMember]
		public string IssuanceOrg;
        [DataMember]
		public string BusinessScope;
        [DataMember]
		public string DocNumber;
        [DataMember]
		public string memo;
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName;
        [DataMember]
		public string RegAddress;
        [DataMember]
		public string LicenseCode;
        [DataMember]
		public DateTime StartDateFrom;
        [DataMember]
		public DateTime StartDateTo;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom;
        [DataMember]
		public int LicenseTypeValueTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PharmacyFileId;

	}
     
	/// <summary>
    /// 事业单位法人证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryLnstitutionLegalPersonLicenseModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string CertificateName;
        [DataMember]
		public string BussinessRange;
        [DataMember]
		public string LegalPerson;
        [DataMember]
		public string FundsSource;
        [DataMember]
		public string InitiaFund;
        [DataMember]
		public string Address;
        [DataMember]
		public DateTime IssuanceDateFrom;
        [DataMember]
		public DateTime IssuanceDateTo;
        [DataMember]
		public string IssuanceOrg;
        [DataMember]
		public string ManageOrg;
        [DataMember]
		public string UseMedicalScope;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public string DocNumber;
        [DataMember]
		public string memo;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName;
        [DataMember]
		public string RegAddress;
        [DataMember]
		public string LicenseCode;
        [DataMember]
		public DateTime StartDateFrom;
        [DataMember]
		public DateTime StartDateTo;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom;
        [DataMember]
		public int LicenseTypeValueTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PharmacyFileId;

	}
     
	/// <summary>
    /// 医疗机构执业许可证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryMmedicalInstitutionPermitModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string CertificateName;
        [DataMember]
		public string OgnTpye;
        [DataMember]
		public string LegalPerson;
        [DataMember]
		public string RegisterAddress;
        [DataMember]
		public string WarehouseAddress;
        [DataMember]
		public DateTime IssuanceDateFrom;
        [DataMember]
		public DateTime IssuanceDateTo;
        [DataMember]
		public string IssuanceOrg;
        [DataMember]
		public string UseMedicalScope;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public string DocNumber;
        [DataMember]
		public string memo;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName;
        [DataMember]
		public string RegAddress;
        [DataMember]
		public string LicenseCode;
        [DataMember]
		public DateTime StartDateFrom;
        [DataMember]
		public DateTime StartDateTo;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom;
        [DataMember]
		public int LicenseTypeValueTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PharmacyFileId;

	}
     
	/// <summary>
    /// 全国工业产品生产许可证服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryIndustoryProductCertificateModel
    {
        [DataMember]
		public string ProductAddress;
        [DataMember]
		public string CheckMethod;
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string UnitName;
        [DataMember]
		public string RegAddress;
        [DataMember]
		public string LicenseCode;
        [DataMember]
		public DateTime StartDateFrom;
        [DataMember]
		public DateTime StartDateTo;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public DateTime IssuanceDateFrom;
        [DataMember]
		public DateTime IssuanceDateTo;
        [DataMember]
		public string IssuanceOrg;
        [DataMember]
		public string DocNumber;
        [DataMember]
		public string memo;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public int LicenseTypeValueFrom;
        [DataMember]
		public int LicenseTypeValueTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PharmacyFileId;

	}
     
	/// <summary>
    /// 医疗分类服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryMedicalCategoryModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
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
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid MedicalCategoryId;

	}
     
	/// <summary>
    /// 功能模块服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryModuleModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Description;
        [DataMember]
		public string AuthKey;
        [DataMember]
		public int IndexFrom;
        [DataMember]
		public int IndexTo;
        [DataMember]
		public Guid ModuleCatetoryId;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 功能模块分类服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryModuleCatetoryModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Description;
        [DataMember]
		public Guid StoreId;
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
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid ModuleId;
        [DataMember]
		public Guid RoleId;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 文件服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPharmacyFileModel
    {
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public string FileName;
        [DataMember]
		public string Extension;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 采购合同服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseAgreementModel
    {
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 验收记录服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseCheckingOrderModel
    {
        [DataMember]
		public string DocumentNumber;
        [DataMember]
		public DateTime OperateTimeFrom;
        [DataMember]
		public DateTime OperateTimeTo;
        [DataMember]
		public Guid OperateUserId;
        [DataMember]
		public Guid SecondCheckerId;
        [DataMember]
		public string SecondCheckMemo;
        [DataMember]
		public string SecondCheckerName;
        [DataMember]
		public int OrderStatusValueFrom;
        [DataMember]
		public int OrderStatusValueTo;
        [DataMember]
		public string Decription;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PurchaseOrderId;
        [DataMember]
		public Guid RelatedOrderId;
        [DataMember]
		public string RelatedOrderDocumentNumber;
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
		public Guid StoreId;
        [DataMember]
		public Guid DrugInfoId;
        [DataMember]
		public decimal PurchasePriceFrom;
        [DataMember]
		public decimal PurchasePriceTo;
        [DataMember]
		public decimal ArrivalAmountFrom;
        [DataMember]
		public decimal ArrivalAmountTo;
        [DataMember]
		public DateTime ArrivalDateTimeFrom;
        [DataMember]
		public DateTime ArrivalDateTimeTo;
        [DataMember]
		public decimal ReceivedAmountFrom;
        [DataMember]
		public decimal ReceivedAmountTo;
        [DataMember]
		public decimal QualifiedAmountFrom;
        [DataMember]
		public decimal QualifiedAmountTo;
        [DataMember]
		public decimal UnQualifiedAmountFrom;
        [DataMember]
		public decimal UnQualifiedAmountTo;
        [DataMember]
		public int CheckResultFrom;
        [DataMember]
		public int CheckResultTo;
        [DataMember]
		public string Decription;
        [DataMember]
		public string BatchNumber;
        [DataMember]
		public DateTime PruductDateFrom;
        [DataMember]
		public DateTime PruductDateTo;
        [DataMember]
		public DateTime OutValidDateFrom;
        [DataMember]
		public DateTime OutValidDateTo;
        [DataMember]
		public Guid PurchaseCheckingOrderId;

	}
     
	/// <summary>
    /// 库存记录服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseInInventeryOrderModel
    {
        [DataMember]
		public string DocumentNumber;
        [DataMember]
		public DateTime OperateTimeFrom;
        [DataMember]
		public DateTime OperateTimeTo;
        [DataMember]
		public Guid OperateUserId;
        [DataMember]
		public int OrderStatusValueFrom;
        [DataMember]
		public int OrderStatusValueTo;
        [DataMember]
		public string Decription;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PurchaseOrderId;
        [DataMember]
		public Guid RelatedOrderId;
        [DataMember]
		public string RelatedOrderDocumentNumber;
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
		public Guid StoreId;
        [DataMember]
		public Guid DrugInfoId;
        [DataMember]
		public decimal PurchasePriceFrom;
        [DataMember]
		public decimal PurchasePriceTo;
        [DataMember]
		public string BatchNumber;
        [DataMember]
		public DateTime PruductDateFrom;
        [DataMember]
		public DateTime PruductDateTo;
        [DataMember]
		public DateTime OutValidDateFrom;
        [DataMember]
		public DateTime OutValidDateTo;
        [DataMember]
		public decimal ArrivalAmountFrom;
        [DataMember]
		public decimal ArrivalAmountTo;
        [DataMember]
		public DateTime ArrivalDateTimeFrom;
        [DataMember]
		public DateTime ArrivalDateTimeTo;
        [DataMember]
		public Guid WarehouseZoneId;
        [DataMember]
		public string Decription;
        [DataMember]
		public Guid PurchaseInInventeryOrderId;
        [DataMember]
		public Guid WarehouseZonePositionId;

	}
     
	/// <summary>
    /// 管理要求分类服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseManageCategoryModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
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
		public string Name;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid PurchaseManageCategoryId;

	}
     
	/// <summary>
    /// 采购单服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseOrderModel
    {
        [DataMember]
		public string DocumentNumber;
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
		public Guid SupplyUnitAccountExecutiveId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public string Decription;
        [DataMember]
		public Guid ApprovalUserId;
        [DataMember]
		public string ApprovalDecription;
        [DataMember]
		public Guid AmountApprovalUserId;
        [DataMember]
		public string AmountApprovalDecription;
        [DataMember]
		public int OrderStatusValueFrom;
        [DataMember]
		public int OrderStatusValueTo;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public bool DirectMarketing;
        [DataMember]
		public bool QueryDirectMarketing=false;
        [DataMember]
		public string ShippingMethod;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid SupplyUnitId;
        [DataMember]
		public Guid ReleatedPurchaseOrderId;

	}
     
	/// <summary>
    /// 采购明细服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseOrderDetailModel
    {
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public decimal AmountFrom;
        [DataMember]
		public decimal AmountTo;
        [DataMember]
		public decimal PurchasePriceFrom;
        [DataMember]
		public decimal PurchasePriceTo;
        [DataMember]
		public decimal AmountOfTaxFrom;
        [DataMember]
		public decimal AmountOfTaxTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid DrugInfoId;
        [DataMember]
		public Guid PurchaseOrderId;

	}
     
	/// <summary>
    /// 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseOrderReturnModel
    {
        [DataMember]
		public string DocumentNumber;
        [DataMember]
		public Guid CheckerUserId;
        [DataMember]
		public string CheckerSuggest;
        [DataMember]
		public Guid QualityUserId;
        [DataMember]
		public string QualitySuggest;
        [DataMember]
		public Guid GeneralManagerUserId;
        [DataMember]
		public string GeneralManagerSuggest;
        [DataMember]
		public Guid FinanceDepartmentUserId;
        [DataMember]
		public string FinanceDepartmentSuggest;
        [DataMember]
		public int OrderStatusValueFrom;
        [DataMember]
		public int OrderStatusValueTo;
        [DataMember]
		public string Decription;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PurchaseOrderId;
        [DataMember]
		public Guid RelatedOrderId;
        [DataMember]
		public string RelatedOrderDocumentNumber;
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
		public Guid StoreId;
        [DataMember]
		public Guid DrugInfoId;
        [DataMember]
		public string BatchNumber;
        [DataMember]
		public DateTime PruductDateFrom;
        [DataMember]
		public DateTime PruductDateTo;
        [DataMember]
		public DateTime OutValidDateFrom;
        [DataMember]
		public DateTime OutValidDateTo;
        [DataMember]
		public decimal ReturnAmountFrom;
        [DataMember]
		public decimal ReturnAmountTo;
        [DataMember]
		public decimal PurchasePriceFrom;
        [DataMember]
		public decimal PurchasePriceTo;
        [DataMember]
		public string ReturnReason;
        [DataMember]
		public bool IsReissue;
        [DataMember]
		public bool QueryIsReissue=false;
        [DataMember]
		public decimal ReissueAmountFrom;
        [DataMember]
		public decimal ReissueAmountTo;
        [DataMember]
		public Guid PurchaseOrderReturnId;
        [DataMember]
		public int PurchaseReturnSourceValueFrom;
        [DataMember]
		public int PurchaseReturnSourceValueTo;
        [DataMember]
		public Guid RelatedOrderId;
        [DataMember]
		public int ReturnHandledMethodValueFrom;
        [DataMember]
		public int ReturnHandledMethodValueTo;
        [DataMember]
		public string Decription;

	}
     
	/// <summary>
    /// 采购收货单服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseReceivingOrderModel
    {
        [DataMember]
		public string DocumentNumber;
        [DataMember]
		public DateTime OperateTimeFrom;
        [DataMember]
		public DateTime OperateTimeTo;
        [DataMember]
		public DateTime ShippingTimeFrom;
        [DataMember]
		public DateTime ShippingTimeTo;
        [DataMember]
		public string ShippingAdress;
        [DataMember]
		public string ShippingUnit;
        [DataMember]
		public string TransportUnit;
        [DataMember]
		public Guid OperateUserId;
        [DataMember]
		public int OrderStatusValueFrom;
        [DataMember]
		public int OrderStatusValueTo;
        [DataMember]
		public string Decription;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid PurchaseOrderId;
        [DataMember]
		public Guid RelatedOrderId;
        [DataMember]
		public string RelatedOrderDocumentNumber;
        [DataMember]
		public int RelatedOrderTypeValueFrom;
        [DataMember]
		public int RelatedOrderTypeValueTo;

	}
     
	/// <summary>
    /// 采购收货详细单服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseReceivingOrderDetailModel
    {
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public decimal AmountFrom;
        [DataMember]
		public decimal AmountTo;
        [DataMember]
		public decimal PurchasePriceFrom;
        [DataMember]
		public decimal PurchasePriceTo;
        [DataMember]
		public decimal ActualAmountFrom;
        [DataMember]
		public decimal ActualAmountTo;
        [DataMember]
		public decimal ReceiveAmountFrom;
        [DataMember]
		public decimal ReceiveAmountTo;
        [DataMember]
		public decimal RejectAmountFrom;
        [DataMember]
		public decimal RejectAmountTo;
        [DataMember]
		public string RejectReason;
        [DataMember]
		public string RejectTrace;
        [DataMember]
		public bool IsCompanyPurchase;
        [DataMember]
		public bool QueryIsCompanyPurchase=false;
        [DataMember]
		public string TransportMethod;
        [DataMember]
		public bool IsTransportMethod;
        [DataMember]
		public bool QueryIsTransportMethod=false;
        [DataMember]
		public string TransportTemperature;
        [DataMember]
		public string TemperatureStatus;
        [DataMember]
		public bool IsTransportTemperature;
        [DataMember]
		public bool QueryIsTransportTemperature=false;
        [DataMember]
		public int CheckResultFrom;
        [DataMember]
		public int CheckResultTo;
        [DataMember]
		public Guid DrugInfoId;
        [DataMember]
		public Guid PurchaseReceivingOrderId;
        [DataMember]
		public string Decription;

	}
     
	/// <summary>
    /// 购货单位服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseUnitModel
    {
        [DataMember]
		public string DocNumber;
        [DataMember]
		public string PinyinCode;
        [DataMember]
		public string QualityAgreementDetail;
        [DataMember]
		public bool IsQualityAgreementOut;
        [DataMember]
		public bool QueryIsQualityAgreementOut=false;
        [DataMember]
		public Guid QualityAgreementFile;
        [DataMember]
		public DateTime QualityAgreemenStartdateFrom;
        [DataMember]
		public DateTime QualityAgreemenStartdateTo;
        [DataMember]
		public DateTime QualityAgreementOutdateFrom;
        [DataMember]
		public DateTime QualityAgreementOutdateTo;
        [DataMember]
		public string QualityCharger;
        [DataMember]
		public string AttorneyAattorneyDetail;
        [DataMember]
		public Guid PurchaseDelegaterFile;
        [DataMember]
		public string PurchaseDelegater;
        [DataMember]
		public bool IsOutDate;
        [DataMember]
		public bool QueryIsOutDate=false;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public string ValidRemark;
        [DataMember]
		public bool IsLock;
        [DataMember]
		public bool QueryIsLock=false;
        [DataMember]
		public string LockRemark;
        [DataMember]
		public string ReceiveAddress;
        [DataMember]
		public string DetailedAddress;
        [DataMember]
		public Guid FlowID;
        [DataMember]
		public Guid DistrictId;
        [DataMember]
		public string Bank;
        [DataMember]
		public string Name;
        [DataMember]
		public string Code;
        [DataMember]
		public string ContactName;
        [DataMember]
		public string ContactTel;
        [DataMember]
		public string Description;
        [DataMember]
		public string LegalPerson;
        [DataMember]
		public string Header;
        [DataMember]
		public string BusinessScope;
        [DataMember]
		public string SalesAmount;
        [DataMember]
		public string Fax;
        [DataMember]
		public string Email;
        [DataMember]
		public string WebAddress;
        [DataMember]
		public Guid GSPLicenseId;
        [DataMember]
		public bool IsGSPLicenseOutDate;
        [DataMember]
		public bool QueryIsGSPLicenseOutDate=false;
        [DataMember]
		public DateTime GSPLicenseOutDateFrom;
        [DataMember]
		public DateTime GSPLicenseOutDateTo;
        [DataMember]
		public Guid GMPLicenseId;
        [DataMember]
		public bool IsGMPLicenseOutDate;
        [DataMember]
		public bool QueryIsGMPLicenseOutDate=false;
        [DataMember]
		public DateTime GMPLicenseOutDateFrom;
        [DataMember]
		public DateTime GMPLicenseOutDateTo;
        [DataMember]
		public Guid BusinessLicenseId;
        [DataMember]
		public bool IsBusinessLicenseOutDate;
        [DataMember]
		public bool QueryIsBusinessLicenseOutDate=false;
        [DataMember]
		public DateTime BusinessLicenseeOutDateFrom;
        [DataMember]
		public DateTime BusinessLicenseeOutDateTo;
        [DataMember]
		public Guid MedicineProductionLicenseId;
        [DataMember]
		public bool IsMedicineProductionLicenseOutDate;
        [DataMember]
		public bool QueryIsMedicineProductionLicenseOutDate=false;
        [DataMember]
		public DateTime MedicineProductionLicenseOutDateFrom;
        [DataMember]
		public DateTime MedicineProductionLicenseOutDateTo;
        [DataMember]
		public Guid MedicineBusinessLicenseId;
        [DataMember]
		public bool IsMedicineBusinessLicenseOutDate;
        [DataMember]
		public bool QueryIsMedicineBusinessLicenseOutDate=false;
        [DataMember]
		public DateTime MedicineBusinessLicenseOutDateFrom;
        [DataMember]
		public DateTime MedicineBusinessLicenseOutDateTo;
        [DataMember]
		public Guid InstrumentsProductionLicenseId;
        [DataMember]
		public bool IsInstrumentsProductionLicenseOutDate;
        [DataMember]
		public bool QueryIsInstrumentsProductionLicenseOutDate=false;
        [DataMember]
		public DateTime InstrumentsProductionLicenseOutDateFrom;
        [DataMember]
		public DateTime InstrumentsProductionLicenseOutDateTo;
        [DataMember]
		public Guid InstrumentsBusinessLicenseId;
        [DataMember]
		public bool IsInstrumentsBusinessLicenseOutDate;
        [DataMember]
		public bool QueryIsInstrumentsBusinessLicenseOutDate=false;
        [DataMember]
		public DateTime InstrumentsBusinessLicenseOutDateFrom;
        [DataMember]
		public DateTime InstrumentsBusinessLicenseOutDateTo;
        [DataMember]
		public Guid HealthLicenseId;
        [DataMember]
		public bool IsHealthLicenseOutDate;
        [DataMember]
		public bool QueryIsHealthLicenseOutDate=false;
        [DataMember]
		public DateTime HealthLicenseOutDateFrom;
        [DataMember]
		public DateTime HealthLicenseOutDateTo;
        [DataMember]
		public Guid TaxRegisterLicenseId;
        [DataMember]
		public bool IsTaxRegisterLicenseOutDate;
        [DataMember]
		public bool QueryIsTaxRegisterLicenseOutDate=false;
        [DataMember]
		public DateTime TaxRegisterLicenseOutDateFrom;
        [DataMember]
		public DateTime TaxRegisterLicenseOutDateTo;
        [DataMember]
		public Guid OrganizationCodeLicenseId;
        [DataMember]
		public bool IsOrganizationCodeLicenseOutDate;
        [DataMember]
		public bool QueryIsOrganizationCodeLicenseOutDate=false;
        [DataMember]
		public DateTime OrganizationCodeLicenseOutDateFrom;
        [DataMember]
		public DateTime OrganizationCodeLicenseOutDateTo;
        [DataMember]
		public Guid FoodCirculateLicenseId;
        [DataMember]
		public bool IsFoodCirculateLicenseOutDate;
        [DataMember]
		public bool QueryIsFoodCirculateLicenseOutDate=false;
        [DataMember]
		public DateTime FoodCirculateLicenseOutDateFrom;
        [DataMember]
		public DateTime FoodCirculateLicenseOutDateTo;
        [DataMember]
		public Guid MmedicalInstitutionPermitId;
        [DataMember]
		public bool IsMmedicalInstitutionPermitOutDate;
        [DataMember]
		public bool QueryIsMmedicalInstitutionPermitOutDate=false;
        [DataMember]
		public DateTime MmedicalInstitutionPermitOutDateFrom;
        [DataMember]
		public DateTime MmedicalInstitutionPermitOutDateTo;
        [DataMember]
		public Guid LnstitutionLegalPersonLicenseId;
        [DataMember]
		public bool IsLnstitutionLegalPersonLicenseOutDate;
        [DataMember]
		public bool QueryIsLnstitutionLegalPersonLicenseOutDate=false;
        [DataMember]
		public DateTime LnstitutionLegalPersonLicenseOutDateFrom;
        [DataMember]
		public DateTime LnstitutionLegalPersonLicenseOutDateTo;
        [DataMember]
		public string TaxRegistrationCode;
        [DataMember]
		public Guid TaxRegistrationFile;
        [DataMember]
		public Guid AnnualFile;
        [DataMember]
		public DateTime LastAnnualDteFrom;
        [DataMember]
		public DateTime LastAnnualDteTo;
        [DataMember]
		public bool IsApproval;
        [DataMember]
		public bool QueryIsApproval=false;
        [DataMember]
		public int ApprovalStatusValueFrom;
        [DataMember]
		public int ApprovalStatusValueTo;
        [DataMember]
		public Guid UnitTypeId;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public bool Enabled;
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
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public int PurchaseLimitTypeValueFrom;
        [DataMember]
		public int PurchaseLimitTypeValueTo;
        [DataMember]
		public string Name;
        [DataMember]
		public Guid IDFile;
        [DataMember]
		public string IDNumber;
        [DataMember]
		public string Tel;
        [DataMember]
		public string Address;
        [DataMember]
		public DateTime BirthdayFrom;
        [DataMember]
		public DateTime BirthdayTo;
        [DataMember]
		public string Gender;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public bool IsChecked;
        [DataMember]
		public bool QueryIsChecked=false;
        [DataMember]
		public string IDCheckType;
        [DataMember]
		public Guid IDCheckUserId;
        [DataMember]
		public Guid PurchaseUnitId;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 购货单位提货人员服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseUnitDelivererModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string IDFile;
        [DataMember]
		public string IDNumber;
        [DataMember]
		public string Tel;
        [DataMember]
		public string Address;
        [DataMember]
		public DateTime BirthdayFrom;
        [DataMember]
		public DateTime BirthdayTo;
        [DataMember]
		public string Gender;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid PurchaseUnitId;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 购货单位类型服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchaseUnitTypeModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;

	}
     
	/// <summary>
    /// 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryPurchasingPlanModel
    {
        [DataMember]
		public string DocumentNumber;
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
		public Guid SupplyUnitAccountExecutiveId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public string Decription;
        [DataMember]
		public Guid ApprovalUserId;
        [DataMember]
		public string ApprovalDecription;
        [DataMember]
		public Guid AmountApprovalUserId;
        [DataMember]
		public string AmountApprovalDecription;
        [DataMember]
		public int OrderStatusValueFrom;
        [DataMember]
		public int OrderStatusValueTo;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public bool DirectMarketing;
        [DataMember]
		public bool QueryDirectMarketing=false;
        [DataMember]
		public string ShippingMethod;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid SupplyUnitId;
        [DataMember]
		public Guid ReleatedPurchaseOrderId;

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
		public string PinYin;
        [DataMember]
		public string Word;
        [DataMember]
		public string Parts;
        [DataMember]
		public string Code;

	}
     
	/// <summary>
    /// 零售会员服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryRetailMemberModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public int RetailCustomerTypeValueFrom;
        [DataMember]
		public int RetailCustomerTypeValueTo;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryRetailOrderModel
    {
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public string Code;
        [DataMember]
		public string Description;
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
		public Guid StoreId;

	}
     
	/// <summary>
    /// 零售单明细服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryRetailOrderDetailModel
    {
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public int IndexFrom;
        [DataMember]
		public int IndexTo;
        [DataMember]
		public string productName;
        [DataMember]
		public string productCode;
        [DataMember]
		public string BatchNumber;
        [DataMember]
		public decimal AmountFrom;
        [DataMember]
		public decimal AmountTo;
        [DataMember]
		public decimal ReturnAmountFrom;
        [DataMember]
		public decimal ReturnAmountTo;
        [DataMember]
		public bool IsDismanting;
        [DataMember]
		public bool QueryIsDismanting=false;
        [DataMember]
		public decimal DismantingAmountFrom;
        [DataMember]
		public decimal DismantingAmountTo;
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
		public string MeasurementUnit;
        [DataMember]
		public string SpecificationCode;
        [DataMember]
		public DateTime PruductDateFrom;
        [DataMember]
		public DateTime PruductDateTo;
        [DataMember]
		public DateTime OutValidDateFrom;
        [DataMember]
		public DateTime OutValidDateTo;
        [DataMember]
		public string FactoryName;
        [DataMember]
		public string Description;
        [DataMember]
		public bool IsDiscount;
        [DataMember]
		public bool QueryIsDiscount=false;
        [DataMember]
		public decimal DiscountFrom;
        [DataMember]
		public decimal DiscountTo;
        [DataMember]
		public decimal DiscountPriceFrom;
        [DataMember]
		public decimal DiscountPriceTo;
        [DataMember]
		public decimal TotalMoneyFrom;
        [DataMember]
		public decimal TotalMoneyTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid RetailOrderId;
        [DataMember]
		public Guid DrugInventoryRecordID;

	}
     
	/// <summary>
    /// 系统角色服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryRoleModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Code;
        [DataMember]
		public string Description;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 角色与用户的关联服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryRoleWithUserModel
    {
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid RoleId;
        [DataMember]
		public Guid UserId;

	}
     
	/// <summary>
    /// 销售单服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySalesOrderModel
    {
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public string SalerName;
        [DataMember]
		public DateTime SaleDateFrom;
        [DataMember]
		public DateTime SaleDateTo;
        [DataMember]
		public string Description;
        [DataMember]
		public decimal TotalMoneyFrom;
        [DataMember]
		public decimal TotalMoneyTo;
        [DataMember]
		public string OrderCode;
        [DataMember]
		public bool AllDelivered;
        [DataMember]
		public bool QueryAllDelivered=false;
        [DataMember]
		public int SalesDrugTypeValueFrom;
        [DataMember]
		public int SalesDrugTypeValueTo;
        [DataMember]
		public int PickUpGoodTypeValueFrom;
        [DataMember]
		public int PickUpGoodTypeValueTo;
        [DataMember]
		public string PickUpMan;
        [DataMember]
		public string PurchaseUnitMan;
        [DataMember]
		public Guid PurchaseUnitManID;
        [DataMember]
		public int OrderStatusValueFrom;
        [DataMember]
		public int OrderStatusValueTo;
        [DataMember]
		public Guid ApprovalUserId;
        [DataMember]
		public Guid CancelUserID;
        [DataMember]
		public string CancelReason;
        [DataMember]
		public string OrderCancelCode;
        [DataMember]
		public string OrderBalanceCode;
        [DataMember]
		public Guid BalanceUserID;
        [DataMember]
		public string BalanceReason;
        [DataMember]
		public Guid payMentMethodID;
        [DataMember]
		public string OrderOutInventoryCode;
        [DataMember]
		public Guid OrderOutInventoryUserID;
        [DataMember]
		public string OrderOutInventoryCheckCode;
        [DataMember]
		public Guid OrderOutInventoryCheckUserID;
        [DataMember]
		public string OrderReturnCode;
        [DataMember]
		public Guid OrderReturnUserID;
        [DataMember]
		public string OrderReturnReason;
        [DataMember]
		public string OrderReturnCancelCode;
        [DataMember]
		public Guid OrderReturnCancelUserID;
        [DataMember]
		public string OrderReturnCancelReason;
        [DataMember]
		public string OrderReturnCheckCode;
        [DataMember]
		public Guid OrderReturnCheckUserID;
        [DataMember]
		public string OrderReturnInInventoryCode;
        [DataMember]
		public Guid OrderReturnInInventoryUserID;
        [DataMember]
		public string OrderDirectReturnCode;
        [DataMember]
		public Guid OrderDirectReturnUserID;
        [DataMember]
		public Guid OutInventoryId;
        [DataMember]
		public Guid PurchaseUnitId;
        [DataMember]
		public string VATCode;
        [DataMember]
		public string VATNumber;
        [DataMember]
		public decimal VATRateFrom;
        [DataMember]
		public decimal VATRateTo;

	}
     
	/// <summary>
    /// 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySalesOrderDeliverDetailModel
    {
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid SalesOrderDeliverRecordId;
        [DataMember]
		public Guid SalesOrderDetailId;

	}
     
	/// <summary>
    /// 销售发货记录服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySalesOrderDeliverRecordModel
    {
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid ApprovalUserId;
        [DataMember]
		public bool HadDelivered;
        [DataMember]
		public bool QueryHadDelivered=false;
        [DataMember]
		public Guid OutInventoryId;
        [DataMember]
		public Guid SalesOrderId;

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
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public string productName;
        [DataMember]
		public string productCode;
        [DataMember]
		public string BatchNumber;
        [DataMember]
		public decimal AmountFrom;
        [DataMember]
		public decimal AmountTo;
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
		public string MeasurementUnit;
        [DataMember]
		public string SpecificationCode;
        [DataMember]
		public string DictionaryDosageCode;
        [DataMember]
		public string Origin;
        [DataMember]
		public DateTime PruductDateFrom;
        [DataMember]
		public DateTime PruductDateTo;
        [DataMember]
		public DateTime OutValidDateFrom;
        [DataMember]
		public DateTime OutValidDateTo;
        [DataMember]
		public string FactoryName;
        [DataMember]
		public decimal DiscountFrom;
        [DataMember]
		public decimal DiscountTo;
        [DataMember]
		public string Description;
        [DataMember]
		public decimal ReturnAmountFrom;
        [DataMember]
		public decimal ReturnAmountTo;
        [DataMember]
		public decimal ChangeAmountFrom;
        [DataMember]
		public decimal ChangeAmountTo;
        [DataMember]
		public decimal OutAmountFrom;
        [DataMember]
		public decimal OutAmountTo;
        [DataMember]
		public Guid OutInventoryDetailID;
        [DataMember]
		public Guid SalesOrderID;
        [DataMember]
		public Guid DrugInventoryRecordID;

	}
     
	/// <summary>
    /// 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySalesOrderReturnModel
    {
        [DataMember]
		public string OrderReturnCode;
        [DataMember]
		public string OrderReturnReason;
        [DataMember]
		public DateTime OrderReturnTimeFrom;
        [DataMember]
		public DateTime OrderReturnTimeTo;
        [DataMember]
		public bool IsReissue;
        [DataMember]
		public bool QueryIsReissue=false;
        [DataMember]
		public Guid SellerID;
        [DataMember]
		public string SellerMemo;
        [DataMember]
		public DateTime SellerUpdateTimeFrom;
        [DataMember]
		public DateTime SellerUpdateTimeTo;
        [DataMember]
		public Guid TradeUserID;
        [DataMember]
		public string TradeMemo;
        [DataMember]
		public DateTime TradeUpdateTimeFrom;
        [DataMember]
		public DateTime TradeUpdateTimeTo;
        [DataMember]
		public Guid QualityUserID;
        [DataMember]
		public string QualityMemo;
        [DataMember]
		public DateTime QualityUpdateTimeFrom;
        [DataMember]
		public DateTime QualityUpdateTimeTo;
        [DataMember]
		public int OrderReturnStatusValueFrom;
        [DataMember]
		public int OrderReturnStatusValueTo;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public string OrderReturnInInventoryCode;
        [DataMember]
		public Guid OrderReturnInInventoryUserID;
        [DataMember]
		public string OrderReturnCancelCode;
        [DataMember]
		public Guid OrderReturnCancelUserID;
        [DataMember]
		public string OrderReturnCancelReason;
        [DataMember]
		public string OrderReturnCheckCode;
        [DataMember]
		public Guid OrderReturnCheckUserID;
        [DataMember]
		public Guid SalesOrderID;
        [DataMember]
		public Guid OutInventoryID;

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
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public string productName;
        [DataMember]
		public string productCode;
        [DataMember]
		public string BatchNumber;
        [DataMember]
		public decimal OrderAmountFrom;
        [DataMember]
		public decimal OrderAmountTo;
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
		public string MeasurementUnit;
        [DataMember]
		public string SpecificationCode;
        [DataMember]
		public DateTime PruductDateFrom;
        [DataMember]
		public DateTime PruductDateTo;
        [DataMember]
		public DateTime OutValidDateFrom;
        [DataMember]
		public DateTime OutValidDateTo;
        [DataMember]
		public string FactoryName;
        [DataMember]
		public string Description;
        [DataMember]
		public decimal ReturnAmountFrom;
        [DataMember]
		public decimal ReturnAmountTo;
        [DataMember]
		public int ReturnReasonValueFrom;
        [DataMember]
		public int ReturnReasonValueTo;
        [DataMember]
		public string ReturnReasonMemo;
        [DataMember]
		public decimal CanInAmountFrom;
        [DataMember]
		public decimal CanInAmountTo;
        [DataMember]
		public decimal CannotInAmountFrom;
        [DataMember]
		public decimal CannotInAmountTo;
        [DataMember]
		public int ReturnHandledMethodValueFrom;
        [DataMember]
		public int ReturnHandledMethodValueTo;
        [DataMember]
		public string ReturnHandledMethodMemo;
        [DataMember]
		public bool IsReissue;
        [DataMember]
		public bool QueryIsReissue=false;
        [DataMember]
		public decimal ReissueAmountFrom;
        [DataMember]
		public decimal ReissueAmountTo;
        [DataMember]
		public Guid OutInventoryDetailID;
        [DataMember]
		public Guid OrderReturnID;
        [DataMember]
		public Guid SalesOrderDetailID;
        [DataMember]
		public Guid DrugInventoryRecordID;
        [DataMember]
		public string DictionaryDosageCode;
        [DataMember]
		public string Origin;

	}
     
	/// <summary>
    /// 销售出库单服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryOutInventoryModel
    {
        [DataMember]
		public string OutInventoryNumber;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid storekeeperId;
        [DataMember]
		public Guid ReviewerId;
        [DataMember]
		public DateTime OutInventoryDateFrom;
        [DataMember]
		public DateTime OutInventoryDateTo;
        [DataMember]
		public string Description;
        [DataMember]
		public Guid OrderOutInventoryUserID;
        [DataMember]
		public string OrderOutInventoryCheckNumber;
        [DataMember]
		public Guid OrderOutInventoryCheckUserID;
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
		public Guid SalesOrderID;
        [DataMember]
		public string OrderCode;
        [DataMember]
		public Guid SalesOrderReturnID;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid SpecialDrugSecondChecker;
        [DataMember]
		public DateTime SecondCheckDateTimeFrom;
        [DataMember]
		public DateTime SecondCheckDateTimeTo;
        [DataMember]
		public string SecondeCheckMemo;

	}
     
	/// <summary>
    /// 设置重点药品记录表服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySetSpeicalDrugRecordModel
    {
        [DataMember]
		public Guid DrugInventoryId;
        [DataMember]
		public int MaintainDuetimeFrom;
        [DataMember]
		public int MaintainDuetimeTo;
        [DataMember]
		public string Reason;
        [DataMember]
		public string MaintainEmphasis;
        [DataMember]
		public string Memo;

	}
     
	/// <summary>
    /// 特殊管理药物类型服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySpecialDrugCategoryModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
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
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string Address;
        [DataMember]
		public string Tel;
        [DataMember]
		public string Head;
        [DataMember]
		public int StoreTypeValueFrom;
        [DataMember]
		public int StoreTypeValueTo;

	}
     
	/// <summary>
    /// 首营药材供货人管理服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySupplyPersonModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string IDFile;
        [DataMember]
		public string IDNumber;
        [DataMember]
		public string Tel;
        [DataMember]
		public string Address;
        [DataMember]
		public DateTime BirthdayFrom;
        [DataMember]
		public DateTime BirthdayTo;
        [DataMember]
		public string Gender;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 供货单位服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySupplyUnitModel
    {
        [DataMember]
		public string DocNumber;
        [DataMember]
		public string PinyinCode;
        [DataMember]
		public string QualityAgreementDetail;
        [DataMember]
		public bool IsQualityAgreementOut;
        [DataMember]
		public bool QueryIsQualityAgreementOut=false;
        [DataMember]
		public Guid QualityAgreementFile;
        [DataMember]
		public DateTime QualityAgreemenStartdateFrom;
        [DataMember]
		public DateTime QualityAgreemenStartdateTo;
        [DataMember]
		public DateTime QualityAgreementOutdateFrom;
        [DataMember]
		public DateTime QualityAgreementOutdateTo;
        [DataMember]
		public bool IsAttorneyAattorneyOut;
        [DataMember]
		public bool QueryIsAttorneyAattorneyOut=false;
        [DataMember]
		public string AttorneyAattorneyDetail;
        [DataMember]
		public Guid AttorneyAattorneyFile;
        [DataMember]
		public DateTime AttorneyAattorneyOutdateFrom;
        [DataMember]
		public DateTime AttorneyAattorneyOutdateTo;
        [DataMember]
		public DateTime AttorneyAattorneyStartdateFrom;
        [DataMember]
		public DateTime AttorneyAattorneyStartdateTo;
        [DataMember]
		public string SupplyProductClass;
        [DataMember]
		public string QualityCharger;
        [DataMember]
		public bool IsAnnualAudit;
        [DataMember]
		public bool QueryIsAnnualAudit=false;
        [DataMember]
		public bool IsSealFile;
        [DataMember]
		public bool QueryIsSealFile=false;
        [DataMember]
		public Guid SealFile;
        [DataMember]
		public Guid SingleTicketFile;
        [DataMember]
		public bool IsSingleTicketFile;
        [DataMember]
		public bool QueryIsSingleTicketFile=false;
        [DataMember]
		public Guid ProofFile;
        [DataMember]
		public string BankAccountName;
        [DataMember]
		public string Bank;
        [DataMember]
		public string BankAccount;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public string Name;
        [DataMember]
		public string Code;
        [DataMember]
		public string ContactName;
        [DataMember]
		public string ContactTel;
        [DataMember]
		public string Description;
        [DataMember]
		public string LegalPerson;
        [DataMember]
		public string Header;
        [DataMember]
		public string BusinessScope;
        [DataMember]
		public string SalesAmount;
        [DataMember]
		public string Fax;
        [DataMember]
		public string Email;
        [DataMember]
		public string WebAddress;
        [DataMember]
		public string ReceiveAddress;
        [DataMember]
		public string DetailedAddress;
        [DataMember]
		public bool IsOutDate;
        [DataMember]
		public bool QueryIsOutDate=false;
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public Guid GSPLicenseId;
        [DataMember]
		public bool IsGSPLicenseOutDate;
        [DataMember]
		public bool QueryIsGSPLicenseOutDate=false;
        [DataMember]
		public DateTime GSPLicenseOutDateFrom;
        [DataMember]
		public DateTime GSPLicenseOutDateTo;
        [DataMember]
		public Guid GMPLicenseId;
        [DataMember]
		public bool IsGMPLicenseOutDate;
        [DataMember]
		public bool QueryIsGMPLicenseOutDate=false;
        [DataMember]
		public DateTime GMPLicenseOutDateFrom;
        [DataMember]
		public DateTime GMPLicenseOutDateTo;
        [DataMember]
		public Guid BusinessLicenseId;
        [DataMember]
		public bool IsBusinessLicenseOutDate;
        [DataMember]
		public bool QueryIsBusinessLicenseOutDate=false;
        [DataMember]
		public DateTime BusinessLicenseeOutDateFrom;
        [DataMember]
		public DateTime BusinessLicenseeOutDateTo;
        [DataMember]
		public Guid MedicineProductionLicenseId;
        [DataMember]
		public bool IsMedicineProductionLicenseOutDate;
        [DataMember]
		public bool QueryIsMedicineProductionLicenseOutDate=false;
        [DataMember]
		public DateTime MedicineProductionLicenseOutDateFrom;
        [DataMember]
		public DateTime MedicineProductionLicenseOutDateTo;
        [DataMember]
		public Guid MedicineBusinessLicenseId;
        [DataMember]
		public bool IsMedicineBusinessLicenseOutDate;
        [DataMember]
		public bool QueryIsMedicineBusinessLicenseOutDate=false;
        [DataMember]
		public DateTime MedicineBusinessLicenseOutDateFrom;
        [DataMember]
		public DateTime MedicineBusinessLicenseOutDateTo;
        [DataMember]
		public Guid InstrumentsProductionLicenseId;
        [DataMember]
		public bool IsInstrumentsProductionLicenseOutDate;
        [DataMember]
		public bool QueryIsInstrumentsProductionLicenseOutDate=false;
        [DataMember]
		public DateTime InstrumentsProductionLicenseOutDateFrom;
        [DataMember]
		public DateTime InstrumentsProductionLicenseOutDateTo;
        [DataMember]
		public Guid InstrumentsBusinessLicenseId;
        [DataMember]
		public bool IsInstrumentsBusinessLicenseOutDate;
        [DataMember]
		public bool QueryIsInstrumentsBusinessLicenseOutDate=false;
        [DataMember]
		public DateTime InstrumentsBusinessLicenseOutDateFrom;
        [DataMember]
		public DateTime InstrumentsBusinessLicenseOutDateTo;
        [DataMember]
		public Guid HealthLicenseId;
        [DataMember]
		public bool IsHealthLicenseOutDate;
        [DataMember]
		public bool QueryIsHealthLicenseOutDate=false;
        [DataMember]
		public DateTime HealthLicenseOutDateFrom;
        [DataMember]
		public DateTime HealthLicenseOutDateTo;
        [DataMember]
		public Guid TaxRegisterLicenseId;
        [DataMember]
		public bool IsTaxRegisterLicenseOutDate;
        [DataMember]
		public bool QueryIsTaxRegisterLicenseOutDate=false;
        [DataMember]
		public DateTime TaxRegisterLicenseOutDateFrom;
        [DataMember]
		public DateTime TaxRegisterLicenseOutDateTo;
        [DataMember]
		public Guid OrganizationCodeLicenseId;
        [DataMember]
		public bool IsOrganizationCodeLicenseOutDate;
        [DataMember]
		public bool QueryIsOrganizationCodeLicenseOutDate=false;
        [DataMember]
		public DateTime OrganizationCodeLicenseOutDateFrom;
        [DataMember]
		public DateTime OrganizationCodeLicenseOutDateTo;
        [DataMember]
		public Guid FoodCirculateLicenseId;
        [DataMember]
		public bool IsFoodCirculateLicenseOutDate;
        [DataMember]
		public bool QueryIsFoodCirculateLicenseOutDate=false;
        [DataMember]
		public DateTime FoodCirculateLicenseOutDateFrom;
        [DataMember]
		public DateTime FoodCirculateLicenseOutDateTo;
        [DataMember]
		public Guid MmedicalInstitutionPermitId;
        [DataMember]
		public bool IsMmedicalInstitutionPermitOutDate;
        [DataMember]
		public bool QueryIsMmedicalInstitutionPermitOutDate=false;
        [DataMember]
		public DateTime MmedicalInstitutionPermitOutDateFrom;
        [DataMember]
		public DateTime MmedicalInstitutionPermitOutDateTo;
        [DataMember]
		public Guid LnstitutionLegalPersonLicenseId;
        [DataMember]
		public bool IsLnstitutionLegalPersonLicenseOutDate;
        [DataMember]
		public bool QueryIsLnstitutionLegalPersonLicenseOutDate=false;
        [DataMember]
		public DateTime LnstitutionLegalPersonLicenseOutDateFrom;
        [DataMember]
		public DateTime LnstitutionLegalPersonLicenseOutDateTo;
        [DataMember]
		public string TaxRegistrationCode;
        [DataMember]
		public Guid TaxRegistrationFile;
        [DataMember]
		public Guid AnnualFile;
        [DataMember]
		public DateTime LastAnnualDteFrom;
        [DataMember]
		public DateTime LastAnnualDteTo;
        [DataMember]
		public bool IsApproval;
        [DataMember]
		public bool QueryIsApproval=false;
        [DataMember]
		public int ApprovalStatusValueFrom;
        [DataMember]
		public int ApprovalStatusValueTo;
        [DataMember]
		public Guid UnitTypeId;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid FlowID;
        [DataMember]
		public string ValidRemark;
        [DataMember]
		public bool IsLock;
        [DataMember]
		public bool QueryIsLock=false;
        [DataMember]
		public string LockRemark;

	}
     
	/// <summary>
    /// 供货商销售人员服务查询实体
    /// </summary>
	[DataContract]
    public partial class QuerySupplyUnitSalesmanModel
    {
        [DataMember]
		public DateTime OutDateFrom;
        [DataMember]
		public DateTime OutDateTo;
        [DataMember]
		public string Name;
        [DataMember]
		public Guid IDFile;
        [DataMember]
		public string IDNumber;
        [DataMember]
		public string Tel;
        [DataMember]
		public string Address;
        [DataMember]
		public DateTime BirthdayFrom;
        [DataMember]
		public DateTime BirthdayTo;
        [DataMember]
		public string Gender;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public bool Valid;
        [DataMember]
		public bool QueryValid=false;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public bool IsOutDate;
        [DataMember]
		public bool QueryIsOutDate=false;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid AuthorizedDistrictId;
        [DataMember]
		public string BusinessScopes;
        [DataMember]
		public string BusinessScopesMemo;
        [DataMember]
		public bool IsChecked;
        [DataMember]
		public bool QueryIsChecked=false;
        [DataMember]
		public string IDCheckType;
        [DataMember]
		public Guid IDCheckUserId;
        [DataMember]
		public Guid AuthorizationDocId;
        [DataMember]
		public Guid SupplyUnitId;

	}
     
	/// <summary>
    /// 税率服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryTaxRateModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Code;
        [DataMember]
		public bool Enabled;
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
		public string Name;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;

	}
     
	/// <summary>
    /// 数据上传记录服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryUploadRecordModel
    {
        [DataMember]
		public string TableName;
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
		public string Account;
        [DataMember]
		public string Pwd;
        [DataMember]
		public bool IsSpecialPriceAuth;
        [DataMember]
		public bool QueryIsSpecialPriceAuth=false;
        [DataMember]
		public string SpecialPriceAuth;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid EmployeeId;

	}
     
	/// <summary>
    /// 用户日志服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryUserLogModel
    {
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public string Content;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 车辆服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryVehicleModel
    {
        [DataMember]
		public string Type;
        [DataMember]
		public int VehicleCategoryValueFrom;
        [DataMember]
		public int VehicleCategoryValueTo;
        [DataMember]
		public string Cubage;
        [DataMember]
		public string LicensePlate;
        [DataMember]
		public string Rule;
        [DataMember]
		public string Other;
        [DataMember]
		public string Driver;
        [DataMember]
		public bool Status;
        [DataMember]
		public bool QueryStatus=false;
        [DataMember]
		public bool IsOutCheck;
        [DataMember]
		public bool QueryIsOutCheck=false;
        [DataMember]
		public string DelegateMan;
        [DataMember]
		public string DelegateCompany;
        [DataMember]
		public string DelegateTel;
        [DataMember]
		public string LiscenceCode;
        [DataMember]
		public string DelegateAddr;
        [DataMember]
		public string DelegateScope;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 仓库服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryWarehouseModel
    {
        [DataMember]
		public string Name;
        [DataMember]
		public string Code;
        [DataMember]
		public string MnemonicCode;
        [DataMember]
		public string Address;
        [DataMember]
		public string ManagementCompany;
        [DataMember]
		public string Phone;
        [DataMember]
		public string Area;
        [DataMember]
		public string ShadeArea;
        [DataMember]
		public string NormalArea;
        [DataMember]
		public string ColdArea;
        [DataMember]
		public string YPFZArea;
        [DataMember]
		public string YHYSSArea;
        [DataMember]
		public string PHCArea;
        [DataMember]
		public string TYZQArea;
        [DataMember]
		public string DWArea;
        [DataMember]
		public string Decription;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid StoreId;

	}
     
	/// <summary>
    /// 库区服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryWarehouseZoneModel
    {
        [DataMember]
		public int PIndexFrom;
        [DataMember]
		public int PIndexTo;
        [DataMember]
		public string Name;
        [DataMember]
		public string Decription;
        [DataMember]
		public string Code;
        [DataMember]
		public string MnemonicCode;
        [DataMember]
		public string Area;
        [DataMember]
		public bool Enabled;
        [DataMember]
		public bool QueryEnabled=false;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public int WarehouseZoneTypeValueFrom;
        [DataMember]
		public int WarehouseZoneTypeValueTo;
        [DataMember]
		public Guid WarehouseId;
        [DataMember]
		public Guid DictionaryStorageTypeId;
        [DataMember]
		public Guid DictionaryMeasurementUnitId;

	}
     
	/// <summary>
    /// 服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryWarehouseZonePositionModel
    {
        [DataMember]
		public int PIndexFrom;
        [DataMember]
		public int PIndexTo;
        [DataMember]
		public int PIndex2From;
        [DataMember]
		public int PIndex2To;
        [DataMember]
		public string Name;
        [DataMember]
		public decimal CapacityFrom;
        [DataMember]
		public decimal CapacityTo;
        [DataMember]
		public string RowCol;
        [DataMember]
		public string Memo;
        [DataMember]
		public Guid WareHouseZoneId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public Guid CreateUserId;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public Guid UpdateUserId;

	}
     
	/// <summary>
    /// 报警设置服务查询实体
    /// </summary>
	[DataContract]
    public partial class QueryWaringSetModel
    {
        [DataMember]
		public string Code;
        [DataMember]
		public string Name;
        [DataMember]
		public string SetValue;
        [DataMember]
		public Guid StoreId;

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
		public Guid CreateUserId;
        [DataMember]
		public Guid UpdateUserId;
        [DataMember]
		public DateTime CreateTimeFrom;
        [DataMember]
		public DateTime CreateTimeTo;
        [DataMember]
		public DateTime UpdateTimeFrom;
        [DataMember]
		public DateTime UpdateTimeTo;
        [DataMember]
		public string productName;
        [DataMember]
		public string productCode;
        [DataMember]
		public string DictionaryDosageCode;
        [DataMember]
		public string Origin;
        [DataMember]
		public string BatchNumber;
        [DataMember]
		public decimal AmountFrom;
        [DataMember]
		public decimal AmountTo;
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
		public string MeasurementUnit;
        [DataMember]
		public string SpecificationCode;
        [DataMember]
		public DateTime PruductDateFrom;
        [DataMember]
		public DateTime PruductDateTo;
        [DataMember]
		public DateTime OutValidDateFrom;
        [DataMember]
		public DateTime OutValidDateTo;
        [DataMember]
		public string FactoryName;
        [DataMember]
		public string Description;
        [DataMember]
		public decimal OutAmountFrom;
        [DataMember]
		public decimal OutAmountTo;
        [DataMember]
		public string WarehouseCode;
        [DataMember]
		public string WarehouseName;
        [DataMember]
		public string WarehouseZoneCode;
        [DataMember]
		public string WarehouseZoneName;
        [DataMember]
		public decimal CanSaleNumFrom;
        [DataMember]
		public decimal CanSaleNumTo;
        [DataMember]
		public Guid StoreId;
        [DataMember]
		public Guid SalesOrderId;
        [DataMember]
		public Guid SalesOrderDetailId;
        [DataMember]
		public Guid SalesOrderReturnId;
        [DataMember]
		public Guid SalesOrderDetailReturnId;
        [DataMember]
		public Guid DrugInventoryRecordID;
        [DataMember]
		public Guid SalesOutInventoryID;

	}
   
}
 
 