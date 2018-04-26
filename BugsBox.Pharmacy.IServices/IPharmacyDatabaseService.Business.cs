 
  
  
 
  
 
 
   
   
   
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Xml.Linq;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Service.Models; 
using BugsBox.Pharmacy.Business.Models.QueryModelExtesion; 
namespace BugsBox.Pharmacy.IServices
{ 
		/// <summary>
		/// 系统wcf数据库服务接口IPharmacyDatabaseService
		/// 所有数据库实体业务逻辑 
		/// </summary>  
	partial interface IPharmacyDatabaseService
	{  
		 
		#region 审批结点(ApprovalFlowBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<ApprovalFlow> GetApproveFlowsByUser(Guid userId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<ApprovalFlow> GetApproveFlowsByUserType(Guid userId,int type,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		ApprovalFlow GetApproveFlowInstance(Guid approvalFlowTypeID,Guid flowID,Guid userID,String comment,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<ApprovalFlow> GetApproveFlowsInfo(Guid flowTypeId,String changeNote,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		ApprovalFlow GetApproveFlowsByFlowID(Guid flowId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<ApprovalDetailsModel> GetApprovalDetails(Guid FlowID,int historyID,List<Object> searchConditions,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void SetApproveAction(ApprovalFlow flow,String action,Guid userID,String comment,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		int GetNextSubflowIDByFlowId(Guid flowid,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		int GetNeedApprovalCount(int approvalTypeValue,out string message);
			 
		#endregion 
		 
		#region 审批结点(ApprovalFlowNodeBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<ApprovalFlowNode> GetFinishApproveFlowsNodes(Guid FlowID,int historyID,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		ApprovalFlowNode GetNextApproveFlowsNode(Guid flowTypeId,Guid flowNodeID,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		ApprovalFlowNode GetFirstApproveFlowsNode(Guid flowTypeId,out string message);
			 
		#endregion 
		 
		#region 审批流程类型(ApprovalFlowTypeBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<ApprovalFlowType> GetApprovalFlowTypeByBusiness(ApprovalType approveType,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<ApprovalFlowType> GetApprovalFlowTypeByTypeList(Int32[] approveTypeList,out string message);
			 
		#endregion 
		 
		#region 审批流程记录(ApprovalFlowRecordBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<ApprovalFlowRecord> GetFinishApproveFlowsRecord(Guid FlowID,int historyID,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		ApprovalFlowRecord GetApproveFlowRecordInstance(ApprovalFlow flow,Guid userID,String comment,out string message);
			 
		#endregion 
		 
		#region 单据编号(BillDocumentCodeBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		BillDocumentCode GenerateBillDocumentCodeByTypeValue(int typeValue,out string message);
			 
		#endregion 
		 
		#region 经营范围(BusinessScopeBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 经营范围分类(BusinessScopeCategoryBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 经营方式(BusinessTypeBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 经营方式的管理要求分类详细(BusinessTypeManageCategoryDetailBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 商品附加属性(GoodsAdditionalPropertyBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 采购结算单(PurchaseCashOrderBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 配送信息(DeliveryBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<Delivery> GetSubmitedDeliveryByCondition(SalesCodeSearchInput condition,int pageindex,int pageSize,out PagerInfo pager,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<Delivery> GetCanceledDeliveryByCondition(SalesCodeSearchInput condition,int pageindex,int pageSize,out PagerInfo pager,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<Delivery> GetOutedDeliveryByCondition(SalesCodeSearchInput condition,int pageindex,int pageSize,out PagerInfo pager,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<Delivery> GetSignedDeliveryByCondition(SalesCodeSearchInput condition,int pageindex,int pageSize,out PagerInfo pager,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<Delivery> GetReturnedDeliveryByCondition(SalesCodeSearchInput condition,int pageindex,int pageSize,out PagerInfo pager,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<Delivery> GetDeliveryList(PagerInfo pager,DeliveryStatus deliveryStatus,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<Delivery> GetDeliveryPaged(DeliveryIndexInput deliveryIndexInput,out PagerInfo pager,int pageindex,int pageSize,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void SubmitDelivery(Delivery delivery,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void UpdateDelivery(Delivery delivery,out string message);
			 
		#endregion 
		 
		#region 部门(DepartmentBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<Department> GetSubDepartments(Guid pDepartmentId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		Department GetParentDepartment(Guid id,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		bool DeleteSubDepartment(Guid id,out string message);
			 
		#endregion 
		 
		#region 区域(DistrictBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 疑问药品(DoubtDrugBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<DoubtDrug> QueryPagedDoubtDrugsForManage(String drugInfoName,String batchNumber,DateTimeRange inInventoryDateRange,DateTimeRange productDateRange,DateTimeRange outDataRange,int index,int size,out PagerInfo pager,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		int GetNeedHandledDoubtDrug(out string message);
			 
		#endregion 
		 
		#region 药品批准文号(DrugApprovalNumberBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 药物分类(DrugCategoryBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 药物临床分类(DrugClinicalCategoryBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 剂型(DictionaryDosageBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 药品信息(DrugInfoBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<DrugInfo> GetDrugInfoByPurchaseUnit(Guid purchaseUnitGuid,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<DrugInfo> GetDrugInfoBySupplyUnit(Guid supplyUnitGuid,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		bool IsExistDrugInfo(DrugInfo info,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<DrugInfo> GetDrugInfoForDrugInfoForSalesSelector(Guid purchaseUnitGuid,String tym,String bwm,String code,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<DrugInfo> GetDrugInfoForPurchasing(String productName,String productGeneralName,String code,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<DrugInfo> GetDrugInfoForSupplyUnitWithQueryParas(Guid supplyUnitId,String generalName,String code,String standardCode,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
            IEnumerable<LackDrugModel> GetDrugInfoForOutofStock(out string message, int stockLower);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		DrugInfo GetDrugInfoByFlowID(Guid flowId,out string message);

        //WFZ modified
            [OperationContract]
            [FaultContract(typeof(ServiceExceptionDetail))]
            DrugInfo GetGoodsInfoByFlowID(Guid flowId, out string message);
        //WFZ end
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void AddDrugInfoApproveFlow(DrugInfo su,Guid approvalFlowTypeID,Guid userID,String changeNote,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void ModifyDrugInfoApproveFlow(DrugInfo su,Guid approvalFlowTypeID,Guid userID,String changeNote,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<DrugInfo> GetLockDrugInfo(out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		int GetLockDrugInfoCount(out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<DrugInfo> GetPagedLockDrugInfo(out PagerInfo pager,int pageindex,int pageSize,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<DrugInfo> SearchPagedDrugInfosByAllStrings(out PagerInfo pager,out string message,String keys,int index,int size);
			 
		#endregion 
		 
		#region 药物库存(DrugInventoryRecordBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<DrugInventoryRecord> GetDrugInventoryRecordForDrugInfoForSalesSelector(Guid purchaseUnitGuid,String tym,String bwm,String code,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<DrugInventoryRecord> GetDrugInventoryRecordByCondition(String ProductName,String BatchNumber,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<DrugInventoryRecord> QueryPagedAllDrugInventoryRecordSelector(QueryDrugInventoryRecordBusinessModel queryModel,int index,int size,out PagerInfo pager,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<InventeryModel> StorageQuery(String ProductGeneralName,String StandardCode,String BatchNumber,Guid[] WarehouseZones,int index,int size,List<Object> searchConditions,out string message);
			 
		#endregion 
		 
		#region 药品养护记录(DrugMaintainRecordBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<DrugMaintainRecord> GetDrugMaintainRecordByCondition(DateTime StartDate,DateTime EndDate,Nullable<Int32> CompleteState,Nullable<Int32> DrugMaintainType,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		bool SaveDrugMaintainRecordByBillDocumentNo(String BillDocumentNo,bool IsCompleteState,out string message);
			 
		#endregion 
		 
		#region 药品养护记录明细(DrugMaintainRecordDetailBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<DrugMaintainRecordDetail> GetDrugMaintainRecordDetailByCondition(String BillDocumentNo,Nullable<DateTime> CheckDate,out string message);
			 
		#endregion 
		 
		#region 计量单位(DictionaryMeasurementUnitBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 拆零单位(DictionaryPiecemealUnitBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 药物规格(DictionarySpecificationBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 储藏方式(DictionaryStorageTypeBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 用户自定义药物类型(DictionaryUserDefinedTypeBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 授权书(AuthorizationDocBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 药品养护设置(DrugMaintainSetBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		DrugMaintainSet GetDrugMaintainSetByDrugMaintainTypeValue(int DrugMaintainTypeValue,out string message);
			 
		#endregion 
		 
		#region 员工(EmployeeBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<BusinessPersonModel> QueryBusinessPerson(QueryBusinessPersonModel queryBusinessPersonModel,out string message);
			 
		#endregion 
		 
		#region GMSP证书规定的经营范围(GMSPLicenseBusinessScopeBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 库存(InventoryRecordBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		InventoryRecord GetInventoryRecordByDrugInfoID(Guid drugInfoID,out string message);
			 
		#endregion 
		 
		#region 生产厂家 (ManufacturerBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 包装材质(PackagingMaterialBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 包装(PackagingUnitBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 付款方式(PaymentMethodBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region GSP证书(GSPLicenseBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region GMP证书(GMPLicenseBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 营业执照(BusinessLicenseBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PharmacyLicense> QueryPharmacyLicenseForOutdate(QueryPharmacyLicenseModel queryModel,out string message);
			 
		#endregion 
		 
		#region 药品生产许可证(MedicineProductionLicenseBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 药品经营许可证(MedicineBusinessLicenseBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 器械经营许可证(InstrumentsBusinessLicenseBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 器械生产许可证(InstrumentsProductionLicenseBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 医疗分类(MedicalCategoryBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 医疗详细分类(MedicalCategoryDetailBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 功能模块(ModuleBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<String> GetAuthorityKeys(Guid userId,out string message);
			 
		#endregion 
		 
		#region 功能模块分类(ModuleCatetoryBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 功能模块与角色的关联(ModuleWithRoleBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<ModuleWithRole> GetModuleWithRolesByRoleId(Guid roleId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<ModuleWithRole> GetModuleWithRolesByModuleId(Guid moduleId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		bool AuthModuleWithRoleCatetoryAuthModuleIds(Role role,ModuleCatetory catetory,List<Guid> authModuleIds,out string message);
			 
		#endregion 
		 
		#region 文件(PharmacyFileBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 采购合同(PurchaseAgreementBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 验收记录(PurchaseCheckingOrderBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 采购到货验收(PurchaseCheckingOrderDetailBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 库存记录(PurchaseInInventeryOrderBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 库存记录详细(PurchaseInInventeryOrderDetailBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 管理要求分类(PurchaseManageCategoryBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 管理要求分类详细(PurchaseManageCategoryDetailBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 采购单(PurchaseOrderBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseRecord> GetPurchaseRecords(int type,String productGeneralName,DateTime startTime,DateTime endTime,Guid[] purchaseUnits,int index,int size,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseRCRecord> GetPurchaseRCRecords(int type,String productGeneralName,DateTime startTime,DateTime endTime,Guid[] purchaseUnits,int index,int size,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseOrderDetailEntity> GetPurchaseHistoryForDrugInfo(Guid drupInfoId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		PurchaseOrdeEntity GetPurchaseOrderEntity(Guid purchaseOrderId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseOrdeEntity> GetPurchaseOrders(String documentNumber,DateTime startTime,DateTime endTime,Int32[] orderStatusValue,Guid[] purchaseUnits,int index,int size,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseOrderDetailEntity> GetPurchaseOrderDetails(Guid purchaseOrderId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		String CreatePurchaseOrder(PurchaseOrder order,List<PurchaseOrderDetail> orderDetails,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void HandlePurchaseReceinvingAmountDiff(PurchaseOrder purchaseOrder,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseCommonEntity> GetPurchaseReceivingOrdersByPurchaseOrderId(Guid purchaseOrderId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		String CreatePurchaseReceivingOrderByEnity(PurchaseCommonEntity order,List<PurchaseReceivingOrderDetailEntity> orderDetails,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		String CreatePurchaseReceivingOrder(PurchaseReceivingOrder order,List<PurchaseReceivingOrderDetail> orderDetails,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseCommonEntity> GetPurchaseReceivingOrders(String documentNumber,DateTime startTime,DateTime endTime,Int32[] orderStatusValue,Guid[] purchaseUnits,int index,int size,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseReceivingOrderDetailEntity> GetPurchaseReceivingOrderDetails(Guid orderId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseCommonEntity> GetPurchaseCheckingOrdersByPurchaseOrderId(Guid purchaseOrderId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
            String CreatePurchaseCheckingOrderByEnity(PurchaseCommonEntity order, List<PurchaseCheckingOrderDetailEntity> orderDetails, List<DrugsUndeterminate> ListUndeterminate, out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		String CreatePurchaseCheckingOrder(PurchaseCheckingOrder order,List<PurchaseCheckingOrderDetail> orderDetails,List<DrugsUndeterminate> ListUndeterminate,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseCommonEntity> GetPurchaseCheckingOrders(String documentNumber,DateTime startTime,DateTime endTime,Int32[] orderStatusValue,Guid[] purchaseUnits,int index,int size,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseCheckingOrderDetailEntity> GetPurchaseCheckingOrderDetails(Guid orderId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseCommonEntity> GetPurchaseInInventeryOrdersByPurchaseOrderId(Guid purchaseOrderId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		String CreatePurchaseInInventeryOrderByEnity(PurchaseCommonEntity order,List<PurchaseInInventeryOrderDetailEntity> orderDetails,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		String CreatePurchaseInInventeryOrder(PurchaseInInventeryOrder order,List<PurchaseInInventeryOrderDetail> orderDetails,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseInInventeryOrderDetailEntity> GetPurchaseInInventeryOrderDetails(Guid orderId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseCommonEntity> GetPurchaseInInventeryOrders(String documentNumber,DateTime startTime,DateTime endTime,Int32[] orderStatusValue,Guid[] purchaseUnits,int index,int size,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseCommonEntity> GetPurchaseOrderReturnsByPurchaseOrderId(Guid purchaseOrderId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		String CreatePurchaseOrderReturnByEnity(PurchaseCommonEntity order,List<PurchaseOrderReturnDetailEntity> orderDetails,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		String CreatePurchaseOrderReturn(PurchaseOrderReturn order,List<PurchaseOrderReturnDetail> orderDetails,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseCommonEntity> GetPurchaseOrderReturns(String documentNumber,DateTime startTime,DateTime endTime,Int32[] orderStatusValue,Guid[] purchaseUnits,int index,int size,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseOrderReturnDetailEntity> GetPurchaseOrderReturnDetails(Guid orderId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseCommonEntity> GetPurchaseCashOrdersByPurchaseOrderId(Guid purchaseOrderId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		String CreatePurchaseCashOrderByEnity(PurchaseCommonEntity order,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		String CreatePurchaseCashOrder(PurchaseCashOrder order,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseCommonEntity> GetPurchaseCashOrders(String documentNumber,DateTime startTime,DateTime endTime,Int32[] orderStatusValue,Guid[] purchaseUnits,int index,int size,out string message);
			 
		#endregion 
		 
		#region 采购明细(PurchaseOrderDetailBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<PurchaseOrderDetail> GetPurchaseOrderDetailByOrderId(Guid purchaseOrderId,out string message);
			 
		#endregion 
		 
		#region (PurchaseOrderReturnBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region (PurchaseOrderReturnDetailBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 采购收货单(PurchaseReceivingOrderBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 采购收货详细单(PurchaseReceivingOrderDetailBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 购货单位(PurchaseUnitBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<String> GetBusinessScopeCodesByPurchaseUnitGuid(Guid purchaseUnitGuid,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<String> GetBusinessScopeCodesByPurchaseUnit(PurchaseUnit purchaseUnit,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<String> GetManageCategoryDetailByPurchaseUnitGuid(Guid purchaseUnitGuid,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<String> GetManageCategoryDetailByPurchaseUnit(PurchaseUnit purchaseUnit,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseUnit> GetPurchaseUnitsForSelector(String name,String code,String py,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		bool IsExistPurchaseUnitByName(String name,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		PurchaseUnit GetPurchaseUnitByName(String name,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		bool UpdatePurchaseUnitByName(String name,PurchaseUnit item,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		PurchaseUnit GetPurchaseUnitByFlowID(Guid flowId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void AddPurchaseUnitApproveFlow(PurchaseUnit su,Guid approvalFlowTypeID,Guid userID,String changeNote,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void ModifyPurchaseUnitApproveFlow(PurchaseUnit su,Guid approvalFlowTypeID,Guid userID,String changeNote,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<PurchaseUnit> GetLockPurchaseUnit(out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		int GetLockPurchaseUnitCount(out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<PurchaseUnit> GetPagedLockPurchaseUnit(out PagerInfo pager,int pageindex,int pageSize,out string message);
			 
		#endregion 
		 
		#region 购货单位采购人员(PurchaseUnitBuyerBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 购货单位提货人员(PurchaseUnitDelivererBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 购货单位类型(PurchaseUnitTypeBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region (PurchasingPlanBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region (PurchasingPlanDetailBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 不常用字(生僻字)(RarewordBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 零售会员(RetailMemberBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region (RetailOrderBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<RetailOrder> GetRetailOrderPagedByCode(String orderCode,out PagerInfo pager,int pageindex,int pageSize,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void AddRetailOrderAndDetails(RetailOrder ro,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void DeleteRetailOrderAndDetails(Guid retailOrderID,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void SaveRetailOrderAndDetails(RetailOrder ro,out string message);
			 
		#endregion 
		 
		#region 零售单明细(RetailOrderDetailBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 系统角色(RoleBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 角色与用户的关联(RoleWithUserBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<RoleWithUser> GetRoleWithUserInfo(Guid UserID,Guid RoleId,out string message);
			 
		#endregion 
		 
		#region 销售单(SalesOrderBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<SalesOrder> GetOrderStatusList(List<Int32> orderStatusList,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void AddSalesOrderAndDetails(SalesOrder so,out string message);

            [OperationContract]
            [FaultContract(typeof(ServiceExceptionDetail))]
            System.Collections.Generic.IEnumerable<DrugInventoryRecord> GetDrugInventoryRecordBySalesOrderId(Guid SoId, out string message);

			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void ModifySalesOrderAndDetails(SalesOrder so,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void DeleteSalesOrderAndDetails(Guid salesOrderID,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<SalesOrder> GetSalesOrderByStatus(int statusValue,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<SalesOrder> GetSalesOrderByOrderCode(String code,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<SalesOrderStatisticOutput> AddupSalesOrder(SalesOrderStatisticInput input,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<Business.Models.SaleOrderModel> GetSalesOrderBalanceCodePaged(SalesCodeSearchInput searchInput,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
            System.Collections.Generic.IEnumerable<Business.Models.SaleOrderModel> GetSalesOrderCodePaged(Business.Models.SalesCodeSearchInput searchInput,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
            IEnumerable<Business.Models.SaleOrderModel> GetSalesOrderCancelCodePaged(out string message,SalesCodeSearchInput searchInput);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<User> GetSalesOrderOperatorUser(out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<User> GetSalesOrderCancelUser(out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<User> GetSalesOrderBalanceUser(out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<SalesOrderRecordOutput> GetSalesOrderRecordPaged(SalesOrderRecordInput searchInput,out PagerInfo pager,int pageindex,int pageSize,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void CancelSalesOrder(SalesOrder so,out string message);
			 
		#endregion 
		 
		#region (SalesOrderDeliverDetailBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 销售发货记录(SalesOrderDeliverRecordBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 销售单明细(SalesOrderDetailBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region (SalesOrderReturnBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<SalesOrderReturn> GetAllNoOverOrderReturn(out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<SalesOrderReturn> GetSalesOrderReturnByStatus(List<Int32> listOrderReturnStatus,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		SalesOrderReturn GetLastOrderReturnByReturnOrder(Guid outInventoryID,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void AddSalesOrderReturnAndDetail(SalesOrderReturn sor,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void CancelSalesOrderReturn(SalesOrderReturn sor,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void AcceptSalesOrderReturn(SalesOrderReturn sor,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void SaveReturnOrderInventory(SalesOrderReturn sor,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<SalesOrderReturn> GetReturnOrderCodePaged(SalesCodeSearchInput searchInput,out PagerInfo pager,int pageindex,int pageSize,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
            IEnumerable<Business.Models.SalesOrderReturnModel> GetReturnOrderCheckCodePaged(SalesCodeSearchInput searchInput, out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<SalesOrderReturn> GetReturnOrderInventoryCodePaged(SalesCodeSearchInput searchInput,out PagerInfo pager,int pageindex,int pageSize,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<Business.Models.SalesOrderReturnModel> GetReturnOrderCancelCodePaged(SalesCodeSearchInput searchInput,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void SaveReturnOrderOutventory(SalesOrderReturn sor,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<User> GetSalesReturnOperatorUser(out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<User> GetSalesReturnCheckUser(out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<User> GetSalesReturnInventoryUser(out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<User> GetSalesReturnCancelUser(out string message);
			 
		#endregion 
		 
		#region (SalesOrderReturnDetailBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<SalesOrderReturnDetail> getOrderReturnDetailListByOrderID(Guid orderID,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<SalesOrderReturnDetail> GetLastReturnDetailByReturnOrder(Guid orderID,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void SaveOrderReturnDetailList(SalesOrder orderInfo,List<SalesOrderReturnDetail> detailList,out string message);
			 
		#endregion 
		 
		#region 销售出库单(OutInventoryBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<OutInventory> GetSubmitedOutInventoryByCondition(SalesCodeSearchInput condition,int pageindex,int pageSize,out PagerInfo pager,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<OutInventory> GetAcceptedOutInventoryByCondition(SalesCodeSearchInput condition,int pageindex,int pageSize,out PagerInfo pager,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<OutInventory> GetOutInventoryByStatus(int iStatus,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<OutInventory> GetAllNotApprovalOutInventory(out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<OutInventory> GetOutInventoryByOrderID(Guid orderID,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void SubmitOutInventory(OutInventory entity,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void AcceptOutInverntory(OutInventory entity,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<OutInventoryDetail> GetOutInventoryDetailFromOrderDetail(Guid orderID,out string message);
			 
		#endregion 
		 
		#region 设置重点药品记录表(SetSpeicalDrugRecordBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void CreateSetSpeicalDrugRecords(SetSpeicalDrugRecord item,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<SetSpeicalDrugRecord> GetSetSpeicalDrugRecords(out string message);
			 
		#endregion 
		 
		#region 特殊管理药物类型(SpecialDrugCategoryBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 门店(StoreBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 供货单位(SupplyUnitBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<String> GetBusinessScopeCodesBySupplyUnitGuid(Guid supplyUnitGuid,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<String> GetBusinessScopeCodesBySupplyUnit(SupplyUnit supplyUnit,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<String> GetManageCategoryDetailBySupplyUnitGuid(Guid supplyUnitGuid,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<String> GetManageCategoryDetailBySupplyUnit(SupplyUnit supplyUnit,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		SupplyUnit GetSupplyUnitByFlowID(Guid flowId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void AddSupplyUnitApproveFlow(SupplyUnit su,Guid approvalFlowTypeID,Guid userID,String changeNote,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void ModifySupplyUnitApproveFlow(SupplyUnit su,Guid approvalFlowTypeID,Guid userID,String changeNote,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<SupplyUnit> GetSupplyUnitForSupplyUnitSelector(Guid drugGuid,String name,String pinyin,String[] jyfwcode,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		bool IsExistSupplyUnitByName(String name,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		SupplyUnit GetSupplyUnitByName(String name,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		bool UpdateSupplyUnitByName(String name,SupplyUnit item,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		List<SupplyUnit> GetLockSupplyUnitUnit(out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<SupplyUnit> GetPagedLockSupplyUnitUnit(out PagerInfo pager,int pageindex,int pageSize,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		int GetLockSupplyUnitCount(out string message);
			 
		#endregion 
		 
		#region 供货商销售人员(SupplyUnitSalesmanBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 税率(TaxRateBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 企业类型(UnitTypeBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 数据上传记录(UploadRecordBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 系统用户(UserBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<User> GetAllUsers(out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		IEnumerable<User> GetUserInfo(String Account,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		User UserLogon(String account,String pwd,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		String UserLogout(Guid userId,out string message);
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		Employee GetEmployeeByUserId(Guid userId,out string message);
			 
		#endregion 
		 
		#region 用户日志(UserLogBusinessHandler)的自定义逻辑
			  
			[OperationContract]
	 [FaultContract(typeof(ServiceExceptionDetail))]
		void LogUserLog(UserLog log,out string message);
			 
		#endregion 
		 
		#region 车辆(VehicleBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 仓库(WarehouseBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 库区(WarehouseZoneBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 报警设置(WaringSetBusinessHandler)的自定义逻辑
			 
		#endregion 
		 
		#region 销售出库单(OutInventoryDetailBusinessHandler)的自定义逻辑
			 
		#endregion 

        #region 不合格药品处理
            /// <summary>
            /// 添加药品不合格
            /// </summary>
            /// <param name="value"></param>
            /// <param name="msg"></param>
            /// <returns></returns>
            [OperationContract]
            [FaultContract(typeof(ServiceExceptionDetail))]
            drugsUnqualication GetDrugsUnqualificationByID(Guid ItemID, out string message);

            [OperationContract]
            [FaultContract(typeof(ServiceExceptionDetail))]
            List<Business.Models.drugsUnqualificationQuery> GetDrugsUnqualification(out string message, Guid UID);

            [OperationContract]
            [FaultContract(typeof(ServiceExceptionDetail))]
            List<drugsUnqualication> GetDrugsUnqualificationByCondition(drugsUnqualificationCondition Condition, out string message);

            [OperationContract]
            [FaultContract(typeof(ServiceExceptionDetail))]
            bool addDrugsUnqualityApproval(drugsUnqualication value, Guid approvalFlowTypeID, Guid userID, string changeNote, out string message);

            [OperationContract]
            [FaultContract(typeof(ServiceExceptionDetail))]
            Business.Models.drugsUnqualificationQuery getDrugsUnqualificationQueryByFlowID(Guid FlowID, out string message);

            [OperationContract]
            [FaultContract(typeof(ServiceExceptionDetail))]
            bool EditDrugUnqualification(Models.drugsUnqualication du, int flag,out string message);

            #endregion

        #region salesman实体方法        
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<Models.SupplyUnitSalesman> GetSalesManBySupplyUnitID(Guid SupplyUnitID, out string message);
        #endregion

        #region 不合格药品销毁查询接口2014-2-11
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        DrugsUnqualificationDestroy[] getDrugsUnqualificationDestroysByCondition(DateTime dtFrom,DateTime dtTo,string keyword, out string msg);
        #endregion

        #region 待处理药品按状态查询接口2014-2-11
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        DrugsUndeterminate[] GetDrugsUndeterminate(int state, string source, string keyword, out string msg);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool SaveToNextProc(DrugsUndeterminate value, Guid userID, out string msg);
        #endregion

        #region 拒收单查询接口
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        DocumentRefuse[] QueryRefuseDocument(string source, int proc, string keyword, out string msg);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool RefuseNextProc(DocumentRefuse value,Guid UserID, out string msg);
        #endregion

        #region 健康，培训关键字查询处理逻辑接口
        
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<HealthCheckDocument> SearchPagedHealthCheckDocumentByAllStrings(String keys, int index, int size, out PagerInfo pager, out string message);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<HealthCheckDetail> SearchPagedHealthCheckDetailByAllStrings(String keys, int index, int size, out PagerInfo pager, out string message);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<EduDocument> SearchPagedEduDocumentByAllStrings(String keys, int index, int size, out PagerInfo pager, out string message);

        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<EduDetails> SearchPagedEduDetailsByAllStrings(String keys, int index, int size, out PagerInfo pager, out string message);

        #endregion

        #region
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool AddDrugsBreakageByFlowID(Models.DrugsBreakage value, Guid flowTypeID, string changeNote, out string message);
        #endregion
        
        #region
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        DrugsBreakage GetDrugsBreakageByFlowID(Guid flowID, out string message);
        #endregion

        #region
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool AddDrugsInventoryMoveByFlowID(Models.DrugsInventoryMove value, Guid flowTypeID, string changeNote, out string message);
        #endregion

        #region
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        DrugsInventoryMove GetDrugsInventoryMoveByFlowID(Guid flowID, out string message);
        #endregion
        #region
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        DrugsBreakage[] GetDrugsBreakagesPassed(DrugsBreakage db,out string message);
        #endregion

        #region
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        ReturnPurchaseOrderList[] GetInventeryOrderListByReturn(string keyword, string supplyUnitName, string DrugName, string Batch , out string message);
        #endregion
        #region
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        PurchaseOrderReturnDetailEntity[] getPurchaseInventoryDetatilEntity(Guid id, out string message);
        #endregion

        #region
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        SalesOrder[] GetSaleOrderByPurchaseUnitID(Guid id, out string message);
        #endregion

        #region
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool SaveDrugMaintainDetailAndUndeterminate(Models.DrugMaintainRecordDetail[] dmrds,out string message);
        #endregion
        #region 获取销售单退货统计
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Dictionary<int, decimal> GetSalesReturnSummary(SalesOrder[] so, out string message);
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        SalesOrderReturn[] GetSalesOrderReturnByCreateTime(DateTime dtFrom, DateTime dtTo, out string message);
        #endregion

        #region 销毁报告写入
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool CreateDestroyByDrugsBreakage(Models.DrugsBreakage[] dbs,Models.DrugsUnqualificationDestroy d,out string message);
        #endregion

        #region 冲差价单处理方法
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool SubmitRefunds(PurchasingPlan[] pps, int flag,out string message);
        #endregion

        #region 获取冲差价单
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        IEnumerable<PurchasingPlan> GetPurchaseRefunds(object[] objs, out string message);
        #endregion

        #region 采退配送
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool SaveDeliveryByPurchaseReturn(Models.PurchaseOrderReturn por, System.Guid createUid,out string message);
        #endregion

        #region 药品流向
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<Business.Models.DrugPath> GetDrugPath(Business.Models.QueryModelForDrugPath m, out string message);
        #endregion

        #region 销售开票时查看供货商
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.List<HistoryPurchase> GetPurchaseHistoryByInInventoryPurchaseID(System.Guid id,int type,out string message);
        #endregion

        #region 库存损益读取
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        IEnumerable<DrugInventoryRecord> GetDrugInventoryRecordPL(string kw, int type, out string message);
        #endregion

        #region 库存近效期读取
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        IEnumerable<BugsBox.Pharmacy.Business.Models.DrugInventoryNearExpiration> GetDrugInventoryRecordNearExpirationDate(int Month, string keyword, int MaintainType, out string message);
        #endregion

        #region 记录日志信息
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        void WriteLog(System.Guid Uid, string Content);
        #endregion

        #region 移库记录查询
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.DrugsInventoryMoveRecordModel> GetMoveRecords(Models.DrugsInventoryMove dm, out string message);
        #endregion

        #region 采购税票查询
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.PurchaseTaxReturn> GetPurchaseTaxReturn(System.Guid SuId, DateTime dtF, DateTime dtT,out string message);
        #endregion

        #region 采购单合并
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool SavePurchaseOrdersByPurchaseTaxReturn(Business.Models.PurchaseTaxReturn[] list, out string message);
        #endregion

        #region 销售税率查询
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.SalesTaxRate> GetSalesTaxRate(System.Guid Pid, System.Guid Uid,out string message);
        #endregion

        #region 销售税费查询
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        IEnumerable<Business.Models.SalerTaxManage> GetSalerTaxManage(System.DateTime dtF, System.DateTime DtT, Guid purchaseUnitId, string SalerName, out string message);
        #endregion

        #region 保存销售税费
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool SaveSaleOrderTaxRate(List<Business.Models.SalerTaxManage> ListST,int locker,out string message);
        #endregion

        #region
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        IEnumerable<Business.Models.AllTax> GetAllTax(System.DateTime dtF, System.DateTime dtT, Guid salerID,out string message);
        #endregion

        #region 车辆审批新增
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool AddVehicleToApprovalByFlowID(Models.Vehicle value, System.Guid flowTypeID, string ChangeNote,out string message);
        #endregion

        #region 从审批ID获取车辆信息
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Vehicle GetVehicleByFlowID(System.Guid flowId, out string message);
        #endregion

        #region 采购退货查询
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.PurchaseOrderReturnModel> GetPReturnOrderByQureyModel(Business.Models.PurchaseOrderReturnQueryModel q,out string message);
        #endregion
        
        #region 查询历史销售冲差单
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        IEnumerable<Business.Models.SaleOrderModel> GetSaleRefundHistory(SalesCodeSearchInput searchInput,out string message);
        #endregion

        #region 保存销售冲差单
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool SaveSaleRefund(SalesOrder so,out string message);
        #endregion

        #region 获取出库复核特殊药品信息
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.OutInventoryMode> GetOutInventorySpecialDrugs(Models.OutInventory outInve, out string message);
        #endregion

        #region 分页药品基础信息
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.DrugInfoModel> GetDrugInfoByCondition(string keys, int index, int size, out PagerInfo pager, bool ValidCondition, out string message);
        #endregion

        #region 根据供应商查询供货药品
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.SupplyUnitHistoryDrugList> GetSupplyUnitHistoryDrugList(string Keyword, string DrugName, Guid SUId, DateTime dtf, DateTime dtt,out string message);
        #endregion

        #region 采购退货取消
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool CancelPurchaseReturnOrder(System.Guid PurchaseReturnOrderId,out string message);
        #endregion

        #region 获取服务器信息
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Business.Models.ServerInfo GetServerInfo(out string message);
        #endregion

        #region 获取服务器更新文件
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.UpdateFiles> GetUpdateFiles(string FileName);
        #endregion

        #region 获取角色权限分配表
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.RoleWithModuleModel> GetRolewithModule();
        #endregion

        #region 获取用户权限分配表
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.RoleWithUserModel> GetRolewithUser();
        #endregion

        #region 分经营范围获取品种数量
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        int GetDrugInfoCount(string BusinessScopeType);
        #endregion

        #region 根据用户岗位、账户密码返回用户
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<User> GetUserByPosition(string roleName, string account, string pwd);
#endregion

        #region 最近采购入库记录细节
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Models.PurchaseInInventeryOrderDetail[] GetLastInInventoryDetail(System.Guid[] DrugInfoIds);
        #endregion

        #region 查询配送单
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.DeliveryTrasactionModel> GetDeliveryTransactionPaged(Business.Models.DeliveryIndexInput deliveryIndexInput, out BugsBox.Application.Core.PagerInfo pager, int pageindex, int pageSize);
        #endregion

       #region 新增直调销售表（事务）
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool AddDirectSalesOrderAndDetail(Models.DirectSalesOrder dso, out string message);
        #endregion

        #region 调用根据关键字查找客户
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        PurchaseUnit[] GetPurchaseUnitsByKeywords(string keyword, bool isAccurate, out string message);
        #endregion

        #region 调用根据关键字查找供货商
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Models.SupplyUnit[] GetSupplyUnitsByKeywords(string Keyword, bool IsAccurate, out string message);
        #endregion

        #region 调用直调药品选择
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Models.DrugInfo[] GetDrugInfoByKeyword(Business.Models.DirectSalesQueryModel m, out string message);
        #endregion

        #region 调用根据审核状态获取销售直调单据
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Business.Models.DirectSalesModel[] GetDirectSalesModelByApprovalStatus(Business.Models.DirectSalesQueryModel dsq, out string message);
        #endregion

        #region 调用根据直调单ID获取直调细节信息
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<DirectSalesOrderDetailModel> GetDirectSalesOrderDetailModelByDirectSalesModel(System.Guid DirectSalesId, out string message);
        #endregion

        #region 调用修改直调销售表
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool SaveDirectSalesOrderAndDetail(Models.DirectSalesOrder dso, out string message);
        #endregion

        #region 调用增加直调销售审批
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool AddDirectSaleApproval(Models.DirectSalesOrder value, System.Guid approvalFlowTypeID, System.Guid userID, string changeNote, out string message);
        #endregion

        #region 调用从FLOWID获取直调销售单
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Models.DirectSalesOrder GetDirectSalesOrderByFlowId(System.Guid FlowId, out string message);
        #endregion

        #region 调用根据Business.Models.SalesOrderQueryModelM关键字查询销售单
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.SalesOrderModelForSalesOrderReturn> GetSalesOrderByOrderModel(Business.Models.SalesOrderQueryModel m, out string message);
        #endregion

        #region 调用过期药品不合格查询
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.InventeryModel> GetDrugsInventoryRecordToUnqualification(bool IsOutDate,string DrugPY,string BatchNumber, out string message);
        #endregion

        #region 调用质量追溯查询
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.DrugQualityTraceModel> GetAllDrugUnqualityTrace(Guid DrugInfoId, out string message);
        #endregion

        #region 医疗器械查询
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        IEnumerable<Business.Models.InstrumentsModel> GetInstrumentsByCondition(string keys, int index, int size, out PagerInfo pager, bool ValidCondition);
        #endregion

        #region 调用新增货位信息
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool AddWareHouseZonePositions(IEnumerable<WareHouseZonePosition> ListWareHouseZonePositions, out string message);
        #endregion

        #region 调用修改增货位信息
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool SaveWareHouseZonePosition(IEnumerable<WareHouseZonePosition> ListWareHouseZonePositions, out string message);
        #endregion

        #region 调用修改增货位信息
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool DeleteWareHouseZonePostion(System.Collections.Generic.IEnumerable<Guid> Ids, out string message);
        #endregion

        #region 调用货位信息综合查询
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        IEnumerable<WareHouseZonePositionModel> GetWareHouseZonePositionById(WareHouseZonePositionQueryModel q, out string message);
        #endregion

        #region 调用电子标签点亮显示
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.WarehouseZonePositionOutInventoryModel> GetWarehouseZonePositionOutInventories(System.Guid SalesOrderId, out string message);
        #endregion

        #region 调用根据ID获取货位记录
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Models.WareHouseZonePosition GetWarehouseZonePositionById(Guid Id, out string message);
        #endregion

        #region 调用获得供货企业和销售客户资质的近效期预警信息
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        List<Business.Models.QualityFilesWarningModel> GetQualifyFilesCount(Business.Models.NearExpireDateQualifiedFiles WarningDate, out string message);
        #endregion

        #region 重写的日志查询
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.UserLogModel> GetPagedUserLogs(Business.Models.QueryBusinessUserLogModel m, out BugsBox.Application.Core.PagerInfo pagerInfo, int PageIndex, int PageSize, out string message);
        #endregion

        #region 调用保存销售控制规则
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool SaveSalePriceControlRules(SalePriceControlRulesModel m, out string message);
        #endregion

        #region 调用获取销售控制规则
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        SalePriceControlRulesModel GetSalePriceControlRules(out string message);
        #endregion


        #region 调用获取客户单位提货人
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        IEnumerable<PurchaseUnitBuyer> GetPurchaseUnitBuyersByPurchaseUnitId(Guid PId, out string message);
        #endregion

        #region 调用分页获取保健食品
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.FoodModel> GetFoodByCondition(string keys, int index, int size, out BugsBox.Application.Core.PagerInfo pager, bool ValidCondition, out string message);
        #endregion

        #region 调用检查excel提交的采购单列表
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.PurchaseOrderImpt> CheckForPurchaseOrderDetails(System.Collections.Generic.IEnumerable<Business.Models.PurchaseOrderImpt> List, out string message);
        #endregion

        #region 调用获取供货单位id和名称
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.Model_IdName> GetSuplyUnitIdNamesByQueryModel(Business.Models.BaseQueryModel q, out string message);
        #endregion


        #region 调用获取用户id和姓名
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.Model_IdName> GetUserIdNamesByQueryModel(Business.Models.BaseQueryModel q, out string message);
        #endregion


        #region 调用用于采购时选择药品
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.DrugInfoForPurchaseSelectorModel> GetDrugInfoForpurchaseSelector(DrugInfoForPurchaseSelectorQueryModel q, out string message);
        #endregion

        #region 调用获取品种最近一次采购价格
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Business.Models.LastPurchaseUnitPrice[] GetLastPurchaseUnitPrice(System.Guid[] DrugInfoIds, out string message);
        #endregion


        #region 调用检索系统所有启用的复核员
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.Model_IdName> GetSalesCheckers(string keyword, out string message);
        #endregion
        
        #region 调用根据OutInventory表中的OutInventoryStatus字段状态，读取出库表，用于拣货、复核等操作
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.SalesOrderOutInventoryModel> GetWaitingOutInventoryList(Business.Models.SalesOrderOutInventoryQueryModel q, out string message);
        #endregion

        #region 调用查询药品出库复核结果
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        DrugOutInventoryCheckModel[] GetDrugOutInventoryChecksByQueryModel(Business.Models.DrugOutInventoryCheckQueryModel q, out string message);
        #endregion

        #region 调用检索仓库保管员信息
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        System.Collections.Generic.IEnumerable<Business.Models.Model_IdName> GetInventoryKeepers(string keyword, out string message);
        #endregion

        #region 调用获取销售单For劳务清单
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Business.Models.SalesOrderForVATModel[] GetVATModelsbyQueryModel(Business.Models.SalesOrderForVATQueryModel q, out string message);
        #endregion

        #region 调用保存发票代码和号码
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool SaveVATCode(Guid Id, string VATCode, string VATNumber, decimal VATRate,string Bank, out string message);
        #endregion

        #region 调用根据销售单ID获取VAT劳务清单的细节信息
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Business.Models.SalesOrderDetailForVATModel[] GetSalesOrderDetailForVATModels(System.Guid SalesOrderId, out string message);
        #endregion

        #region 调用销退细节查询
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        Business.Models.SalesOrderReturnDetailModel[] GetSalesOrderReturnDetailModels(Business.Models.SalesOrderReturnDetailQueryModel q, out string message);
        #endregion

        #region 调用保存VAT折扣信息
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool SaveVATForSalesOrderDetails(Business.Models.SalesOrderDetailForVATModel[] list, out string message);
        #endregion
    }

}
