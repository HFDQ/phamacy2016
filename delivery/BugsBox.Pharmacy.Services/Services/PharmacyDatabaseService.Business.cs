 
  
  
 
  
 
 
   
   
   
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Xml.Linq;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.Business.Models.QueryModelExtesion; 
namespace BugsBox.Pharmacy.Services
{ 
		/// <summary>
		/// 系统wcf数据库服务接口IPharmacyDatabaseService实现
		/// 所有数据库实体业务逻辑 
		/// </summary>  
    partial class PharmacyService
    {

        #region 审批结点(ApprovalFlowBusinessHandler)的自定义逻辑


        public IEnumerable<ApprovalFlow> GetApproveFlowsByUser(Guid userId, out string message)
        {
            //Log.Warning("客户端开始调用GetApproveFlowsByUser");
            message = string.Empty;
            try
            {
                return HandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowsByUser(userId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<ApprovalFlow>>("服务调用业务逻辑方法：GetApproveFlowsByUser", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public IEnumerable<ApprovalFlow> GetApproveFlowsByUserType(Guid userId, int type, out string message)
        {
            //Log.Warning("客户端开始调用GetApproveFlowsByUserType");
            message = string.Empty;
            try
            {
                return HandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowsByUserType(userId, type);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<ApprovalFlow>>("服务调用业务逻辑方法：GetApproveFlowsByUserType", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public ApprovalFlow GetApproveFlowInstance(Guid approvalFlowTypeID, Guid flowID, Guid userID, String comment, out string message)
        {
            //Log.Warning("客户端开始调用GetApproveFlowInstance");
            message = string.Empty;
            try
            {
                return HandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowInstance(approvalFlowTypeID, flowID, userID, comment);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<ApprovalFlow>("服务调用业务逻辑方法：GetApproveFlowInstance", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public IEnumerable<ApprovalFlow> GetApproveFlowsInfo(Guid flowTypeId, String changeNote, out string message)
        {
            //Log.Warning("客户端开始调用GetApproveFlowsInfo");
            message = string.Empty;
            try
            {
                return HandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowsInfo(flowTypeId, changeNote);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<ApprovalFlow>>("服务调用业务逻辑方法：GetApproveFlowsInfo", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public ApprovalFlow GetApproveFlowsByFlowID(Guid flowId, out string message)
        {
            //Log.Warning("客户端开始调用GetApproveFlowsByFlowID");
            message = string.Empty;
            try
            {
                return HandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowsByFlowID(flowId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<ApprovalFlow>("服务调用业务逻辑方法：GetApproveFlowsByFlowID", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<ApprovalDetailsModel> GetApprovalDetails(Guid FlowID, int historyID, List<Object> searchConditions, out string message)
        {
            //Log.Warning("客户端开始调用GetApprovalDetails");
            message = string.Empty;
            try
            {
                return HandlerFactory.ApprovalFlowBusinessHandler.GetApprovalDetails(FlowID, historyID, searchConditions);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<ApprovalDetailsModel>>("服务调用业务逻辑方法：GetApprovalDetails", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void SetApproveAction(ApprovalFlow flow, String action, Guid userID, String comment, out string message)
        {
            //Log.Warning("客户端开始调用SetApproveAction");
            message = string.Empty;
            try
            {
                HandlerFactory.ApprovalFlowBusinessHandler.SetApproveAction(flow, action, userID, comment);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：SetApproveAction", ex);
            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public int GetNextSubflowIDByFlowId(Guid flowid, out string message)
        {
            //Log.Warning("客户端开始调用GetNextSubflowIDByFlowId");
            message = string.Empty;
            try
            {
                return HandlerFactory.ApprovalFlowBusinessHandler.GetNextSubflowIDByFlowId(flowid);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<int>("服务调用业务逻辑方法：GetNextSubflowIDByFlowId", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public int GetNeedApprovalCount(int approvalTypeValue, out string message)
        {
            //Log.Warning("客户端开始调用GetNeedApprovalCount");
            message = string.Empty;
            try
            {
                return HandlerFactory.ApprovalFlowBusinessHandler.GetNeedApprovalCount(approvalTypeValue);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<int>("服务调用业务逻辑方法：GetNeedApprovalCount", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

        #endregion

        #region 审批结点(ApprovalFlowNodeBusinessHandler)的自定义逻辑


        public IEnumerable<ApprovalFlowNode> GetFinishApproveFlowsNodes(Guid FlowID, int historyID, out string message)
        {
            //Log.Warning("客户端开始调用GetFinishApproveFlowsNodes");
            message = string.Empty;
            try
            {
                return HandlerFactory.ApprovalFlowNodeBusinessHandler.GetFinishApproveFlowsNodes(FlowID, historyID);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<ApprovalFlowNode>>("服务调用业务逻辑方法：GetFinishApproveFlowsNodes", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public ApprovalFlowNode GetNextApproveFlowsNode(Guid flowTypeId, Guid flowNodeID, out string message)
        {
            //Log.Warning("客户端开始调用GetNextApproveFlowsNode");
            message = string.Empty;
            try
            {
                return HandlerFactory.ApprovalFlowNodeBusinessHandler.GetNextApproveFlowsNode(flowTypeId, flowNodeID);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<ApprovalFlowNode>("服务调用业务逻辑方法：GetNextApproveFlowsNode", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public ApprovalFlowNode GetFirstApproveFlowsNode(Guid flowTypeId, out string message)
        {
            //Log.Warning("客户端开始调用GetFirstApproveFlowsNode");
            message = string.Empty;
            try
            {
                return HandlerFactory.ApprovalFlowNodeBusinessHandler.GetFirstApproveFlowsNode(flowTypeId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<ApprovalFlowNode>("服务调用业务逻辑方法：GetFirstApproveFlowsNode", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

        #endregion

        #region 审批流程类型(ApprovalFlowTypeBusinessHandler)的自定义逻辑


        public IEnumerable<ApprovalFlowType> GetApprovalFlowTypeByBusiness(ApprovalType approveType, out string message)
        {
            //Log.Warning("客户端开始调用GetApprovalFlowTypeByBusiness");
            message = string.Empty;
            try
            {
                return HandlerFactory.ApprovalFlowTypeBusinessHandler.GetApprovalFlowTypeByBusiness(approveType);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<ApprovalFlowType>>("服务调用业务逻辑方法：GetApprovalFlowTypeByBusiness", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<ApprovalFlowType> GetApprovalFlowTypeByTypeList(Int32[] approveTypeList, out string message)
        {
            //Log.Warning("客户端开始调用GetApprovalFlowTypeByTypeList");
            message = string.Empty;
            try
            {
                return HandlerFactory.ApprovalFlowTypeBusinessHandler.GetApprovalFlowTypeByTypeList(approveTypeList);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<ApprovalFlowType>>("服务调用业务逻辑方法：GetApprovalFlowTypeByTypeList", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

        #endregion

        #region 审批流程记录(ApprovalFlowRecordBusinessHandler)的自定义逻辑


        public IEnumerable<ApprovalFlowRecord> GetFinishApproveFlowsRecord(Guid FlowID, int historyID, out string message)
        {
            //Log.Warning("客户端开始调用GetFinishApproveFlowsRecord");
            message = string.Empty;
            try
            {
                return HandlerFactory.ApprovalFlowRecordBusinessHandler.GetFinishApproveFlowsRecord(FlowID, historyID);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<ApprovalFlowRecord>>("服务调用业务逻辑方法：GetFinishApproveFlowsRecord", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public ApprovalFlowRecord GetApproveFlowRecordInstance(ApprovalFlow flow, Guid userID, String comment, out string message)
        {
            //Log.Warning("客户端开始调用GetApproveFlowRecordInstance");
            message = string.Empty;
            try
            {
                return HandlerFactory.ApprovalFlowRecordBusinessHandler.GetApproveFlowRecordInstance(flow, userID, comment);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<ApprovalFlowRecord>("服务调用业务逻辑方法：GetApproveFlowRecordInstance", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

        #endregion

        #region 单据编号(BillDocumentCodeBusinessHandler)的自定义逻辑


        public BillDocumentCode GenerateBillDocumentCodeByTypeValue(int typeValue, out string message)
        {
            //Log.Warning("客户端开始调用GenerateBillDocumentCodeByTypeValue");
            message = string.Empty;
            try
            {
                return HandlerFactory.BillDocumentCodeBusinessHandler.GenerateBillDocumentCodeByTypeValue(typeValue);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<BillDocumentCode>("服务调用业务逻辑方法：GenerateBillDocumentCodeByTypeValue", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

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


        public List<Delivery> GetSubmitedDeliveryByCondition(SalesCodeSearchInput condition, int pageindex, int pageSize, out PagerInfo pager, out string message)
        {
            //Log.Warning("客户端开始调用GetSubmitedDeliveryByCondition");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.DeliveryBusinessHandler.GetSubmitedDeliveryByCondition(condition, pageindex, pageSize, out pager);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<Delivery>>("服务调用业务逻辑方法：GetSubmitedDeliveryByCondition", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<Delivery> GetCanceledDeliveryByCondition(SalesCodeSearchInput condition, int pageindex, int pageSize, out PagerInfo pager, out string message)
        {
            //Log.Warning("客户端开始调用GetCanceledDeliveryByCondition");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.DeliveryBusinessHandler.GetCanceledDeliveryByCondition(condition, pageindex, pageSize, out pager);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<Delivery>>("服务调用业务逻辑方法：GetCanceledDeliveryByCondition", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<Delivery> GetOutedDeliveryByCondition(SalesCodeSearchInput condition, int pageindex, int pageSize, out PagerInfo pager, out string message)
        {
            //Log.Warning("客户端开始调用GetOutedDeliveryByCondition");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.DeliveryBusinessHandler.GetOutedDeliveryByCondition(condition, pageindex, pageSize, out pager);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<Delivery>>("服务调用业务逻辑方法：GetOutedDeliveryByCondition", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<Delivery> GetSignedDeliveryByCondition(SalesCodeSearchInput condition, int pageindex, int pageSize, out PagerInfo pager, out string message)
        {
            //Log.Warning("客户端开始调用GetSignedDeliveryByCondition");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.DeliveryBusinessHandler.GetSignedDeliveryByCondition(condition, pageindex, pageSize, out pager);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<Delivery>>("服务调用业务逻辑方法：GetSignedDeliveryByCondition", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<Delivery> GetReturnedDeliveryByCondition(SalesCodeSearchInput condition, int pageindex, int pageSize, out PagerInfo pager, out string message)
        {
            //Log.Warning("客户端开始调用GetReturnedDeliveryByCondition");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.DeliveryBusinessHandler.GetReturnedDeliveryByCondition(condition, pageindex, pageSize, out pager);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<Delivery>>("服务调用业务逻辑方法：GetReturnedDeliveryByCondition", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<Delivery> GetDeliveryList(PagerInfo pager, DeliveryStatus deliveryStatus, out string message)
        {
            //Log.Warning("客户端开始调用GetDeliveryList");
            message = string.Empty;
            try
            {
                return HandlerFactory.DeliveryBusinessHandler.GetDeliveryList(pager, deliveryStatus);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<Delivery>>("服务调用业务逻辑方法：GetDeliveryList", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public IEnumerable<Delivery> GetDeliveryPaged(DeliveryIndexInput deliveryIndexInput, out PagerInfo pager, int pageindex, int pageSize, out string message)
        {
            //Log.Warning("客户端开始调用GetDeliveryPaged");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.DeliveryBusinessHandler.GetDeliveryPaged(deliveryIndexInput, out pager, pageindex, pageSize);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<Delivery>>("服务调用业务逻辑方法：GetDeliveryPaged", ex);

            }
            finally
            {
                this.Dispose();
            }
        }


        public void SubmitDelivery(Delivery delivery, out string message)
        {
            //Log.Warning("客户端开始调用SubmitDelivery");
            message = string.Empty;
            try
            {
                HandlerFactory.DeliveryBusinessHandler.SubmitDelivery(delivery);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：SubmitDelivery", ex);
            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void UpdateDelivery(Delivery delivery, out string message)
        {
            //Log.Warning("客户端开始调用UpdateDelivery");
            message = string.Empty;
            try
            {
                HandlerFactory.DeliveryBusinessHandler.UpdateDelivery(delivery);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：UpdateDelivery", ex);
            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

        #endregion

        #region 部门(DepartmentBusinessHandler)的自定义逻辑


        public IEnumerable<Department> GetSubDepartments(Guid pDepartmentId, out string message)
        {
            //Log.Warning("客户端开始调用GetSubDepartments");
            message = string.Empty;
            try
            {
                return HandlerFactory.DepartmentBusinessHandler.GetSubDepartments(pDepartmentId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<Department>>("服务调用业务逻辑方法：GetSubDepartments", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public Department GetParentDepartment(Guid id, out string message)
        {
            //Log.Warning("客户端开始调用GetParentDepartment");
            message = string.Empty;
            try
            {
                return HandlerFactory.DepartmentBusinessHandler.GetParentDepartment(id);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<Department>("服务调用业务逻辑方法：GetParentDepartment", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }   //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            
        }


        public bool DeleteSubDepartment(Guid id, out string message)
        {
            //Log.Warning("客户端开始调用DeleteSubDepartment");
            message = string.Empty;
            try
            {
                return HandlerFactory.DepartmentBusinessHandler.DeleteSubDepartment(id);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<bool>("服务调用业务逻辑方法：DeleteSubDepartment", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

        #endregion

        #region 区域(DistrictBusinessHandler)的自定义逻辑

        #endregion

        #region 疑问药品(DoubtDrugBusinessHandler)的自定义逻辑


        public List<DoubtDrug> QueryPagedDoubtDrugsForManage(String drugInfoName, String batchNumber, DateTimeRange inInventoryDateRange, DateTimeRange productDateRange, DateTimeRange outDataRange, int index, int size, out PagerInfo pager, out string message)
        {
            //Log.Warning("客户端开始调用QueryPagedDoubtDrugsForManage");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.DoubtDrugBusinessHandler.QueryPagedDoubtDrugsForManage(drugInfoName, batchNumber, inInventoryDateRange, productDateRange, outDataRange, index, size, out pager);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<DoubtDrug>>("服务调用业务逻辑方法：QueryPagedDoubtDrugsForManage", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public int GetNeedHandledDoubtDrug(out string message)
        {
            //Log.Warning("客户端开始调用GetNeedHandledDoubtDrug");
            message = string.Empty;
            try
            {
                return HandlerFactory.DoubtDrugBusinessHandler.GetNeedHandledDoubtDrug();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<int>("服务调用业务逻辑方法：GetNeedHandledDoubtDrug", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

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


        public IEnumerable<DrugInfo> GetDrugInfoByPurchaseUnit(Guid purchaseUnitGuid, out string message)
        {
            //Log.Warning("客户端开始调用GetDrugInfoByPurchaseUnit");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.GetDrugInfoByPurchaseUnit(purchaseUnitGuid);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<DrugInfo>>("服务调用业务逻辑方法：GetDrugInfoByPurchaseUnit", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public IEnumerable<DrugInfo> GetDrugInfoBySupplyUnit(Guid supplyUnitGuid, out string message)
        {
            //Log.Warning("客户端开始调用GetDrugInfoBySupplyUnit");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.GetDrugInfoBySupplyUnit(supplyUnitGuid);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<DrugInfo>>("服务调用业务逻辑方法：GetDrugInfoBySupplyUnit", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public bool IsExistDrugInfo(DrugInfo info, out string message)
        {
            //Log.Warning("客户端开始调用IsExistDrugInfo");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.IsExistDrugInfo(info);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<bool>("服务调用业务逻辑方法：IsExistDrugInfo", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<DrugInfo> GetDrugInfoForDrugInfoForSalesSelector(Guid purchaseUnitGuid, String tym, String bwm, String code, out string message)
        {
            //Log.Warning("客户端开始调用GetDrugInfoForDrugInfoForSalesSelector");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.GetDrugInfoForDrugInfoForSalesSelector(purchaseUnitGuid, tym, bwm, code);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<DrugInfo>>("服务调用业务逻辑方法：GetDrugInfoForDrugInfoForSalesSelector", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<DrugInfo> GetDrugInfoForPurchasing(String productName, String productGeneralName, String code, out string message)
        {
            //Log.Warning("客户端开始调用GetDrugInfoForPurchasing");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.GetDrugInfoForPurchasing(productName, productGeneralName, code);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<DrugInfo>>("服务调用业务逻辑方法：GetDrugInfoForPurchasing", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<DrugInfo> GetDrugInfoForSupplyUnitWithQueryParas(Guid supplyUnitId, String generalName, String code, String standardCode, out string message)
        {
            //Log.Warning("客户端开始调用GetDrugInfoForSupplyUnitWithQueryParas");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.GetDrugInfoForSupplyUnitWithQueryParas(supplyUnitId, generalName, code, standardCode);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<DrugInfo>>("服务调用业务逻辑方法：GetDrugInfoForSupplyUnitWithQueryParas", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public IEnumerable<LackDrugModel> GetDrugInfoForOutofStock(out string message)
        {
            //Log.Warning("客户端开始调用GetDrugInfoForOutofStock");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.GetDrugInfoForOutofStock();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<LackDrugModel>>("服务调用业务逻辑方法：GetDrugInfoForOutofStock", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public DrugInfo GetDrugInfoByFlowID(Guid flowId, out string message)
        {
            //Log.Warning("客户端开始调用GetDrugInfoByFlowID");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.GetDrugInfoByFlowID(flowId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<DrugInfo>("服务调用业务逻辑方法：GetDrugInfoByFlowID", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

        //WFZ mmodified
        public DrugInfo GetGoodsInfoByFlowID(Guid flowId, out string message)
        {
            //Log.Warning("客户端开始调用GetGoodsInfoByFlowID");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.GetGoodsInfoByFlowID(flowId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<DrugInfo>("服务调用业务逻辑方法：GetGoodsInfoByFlowID", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }
        //end


        public void AddDrugInfoApproveFlow(DrugInfo su, Guid approvalFlowTypeID, Guid userID, String changeNote, out string message)
        {
            //Log.Warning("客户端开始调用AddDrugInfoApproveFlow");
            message = string.Empty;
            try
            {
                HandlerFactory.DrugInfoBusinessHandler.AddDrugInfoApproveFlow(su, approvalFlowTypeID, userID, changeNote);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：AddDrugInfoApproveFlow", ex);
            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void ModifyDrugInfoApproveFlow(DrugInfo su, Guid approvalFlowTypeID, Guid userID, String changeNote, out string message)
        {
            //Log.Warning("客户端开始调用ModifyDrugInfoApproveFlow");
            message = string.Empty;
            try
            {
                HandlerFactory.DrugInfoBusinessHandler.ModifyDrugInfoApproveFlow(su, approvalFlowTypeID, userID, changeNote);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：ModifyDrugInfoApproveFlow", ex);
            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<DrugInfo> GetLockDrugInfo(out string message)
        {
            //Log.Warning("客户端开始调用GetLockDrugInfo");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.GetLockDrugInfo();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<DrugInfo>>("服务调用业务逻辑方法：GetLockDrugInfo", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public int GetLockDrugInfoCount(out string message)
        {
            //Log.Warning("客户端开始调用GetLockDrugInfoCount");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.GetLockDrugInfoCount();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<int>("服务调用业务逻辑方法：GetLockDrugInfoCount", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public IEnumerable<DrugInfo> GetPagedLockDrugInfo(out PagerInfo pager, int pageindex, int pageSize, out string message)
        {
            //Log.Warning("客户端开始调用GetPagedLockDrugInfo");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.GetPagedLockDrugInfo(out pager, pageindex, pageSize);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<DrugInfo>>("服务调用业务逻辑方法：GetPagedLockDrugInfo", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<DrugInfo> SearchPagedDrugInfosByAllStrings(out PagerInfo pager, out string message,String keys, int index, int size )
        {
            //Log.Warning("客户端开始调用SearchPagedDrugInfosByAllStrings");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.SearchPagedDrugInfosByAllStrings(keys, index, size, out pager);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<DrugInfo>>("服务调用业务逻辑方法：SearchPagedDrugInfosByAllStrings", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }

        #endregion

        #region 药物库存(DrugInventoryRecordBusinessHandler)的自定义逻辑


        public IEnumerable<DrugInventoryRecord> GetDrugInventoryRecordForDrugInfoForSalesSelector(Guid purchaseUnitGuid, String tym, String bwm, String code, out string message)
        {
            //Log.Warning("客户端开始调用GetDrugInventoryRecordForDrugInfoForSalesSelector");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInventoryRecordBusinessHandler.GetDrugInventoryRecordForDrugInfoForSalesSelector(purchaseUnitGuid, tym, bwm, code);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<DrugInventoryRecord>>("服务调用业务逻辑方法：GetDrugInventoryRecordForDrugInfoForSalesSelector", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<DrugInventoryRecord> GetDrugInventoryRecordByCondition(String ProductName, String BatchNumber, out string message)
        {
            //Log.Warning("客户端开始调用GetDrugInventoryRecordByCondition");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInventoryRecordBusinessHandler.GetDrugInventoryRecordByCondition(ProductName, BatchNumber);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<DrugInventoryRecord>>("服务调用业务逻辑方法：GetDrugInventoryRecordByCondition", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<DrugInventoryRecord> QueryPagedAllDrugInventoryRecordSelector(QueryDrugInventoryRecordBusinessModel queryModel, int index, int size, out PagerInfo pager, out string message)
        {
            //Log.Warning("客户端开始调用QueryPagedAllDrugInventoryRecordSelector");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.DrugInventoryRecordBusinessHandler.QueryPagedAllDrugInventoryRecordSelector(queryModel, index, size, out pager);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<DrugInventoryRecord>>("服务调用业务逻辑方法：QueryPagedAllDrugInventoryRecordSelector", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<InventeryModel> StorageQuery(String ProductGeneralName, String StandardCode, String BatchNumber, Guid[] WarehouseZones, int index, int size, List<Object> searchConditions, out string message)
        {
            //Log.Warning("客户端开始调用StorageQuery");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInventoryRecordBusinessHandler.StorageQuery(ProductGeneralName, StandardCode, BatchNumber, WarehouseZones, index, size, searchConditions);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<InventeryModel>>("服务调用业务逻辑方法：StorageQuery", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }

        #endregion

        #region 药品养护记录(DrugMaintainRecordBusinessHandler)的自定义逻辑


        public List<DrugMaintainRecord> GetDrugMaintainRecordByCondition(DateTime StartDate, DateTime EndDate, Nullable<Int32> CompleteState, Nullable<Int32> DrugMaintainType, out string message)
        {
            //Log.Warning("客户端开始调用GetDrugMaintainRecordByCondition");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugMaintainRecordBusinessHandler.GetDrugMaintainRecordByCondition(StartDate, EndDate, CompleteState, DrugMaintainType);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<DrugMaintainRecord>>("服务调用业务逻辑方法：GetDrugMaintainRecordByCondition", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public bool SaveDrugMaintainRecordByBillDocumentNo(String BillDocumentNo, bool IsCompleteState, out string message)
        {
            //Log.Warning("客户端开始调用SaveDrugMaintainRecordByBillDocumentNo");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugMaintainRecordBusinessHandler.SaveDrugMaintainRecordByBillDocumentNo(BillDocumentNo, IsCompleteState);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<bool>("服务调用业务逻辑方法：SaveDrugMaintainRecordByBillDocumentNo", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

        #endregion

        #region 药品养护记录明细(DrugMaintainRecordDetailBusinessHandler)的自定义逻辑


        public List<DrugMaintainRecordDetail> GetDrugMaintainRecordDetailByCondition(String BillDocumentNo, Nullable<DateTime> CheckDate, out string message)
        {
            //Log.Warning("客户端开始调用GetDrugMaintainRecordDetailByCondition");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugMaintainRecordDetailBusinessHandler.GetDrugMaintainRecordDetailByCondition(BillDocumentNo, CheckDate);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<DrugMaintainRecordDetail>>("服务调用业务逻辑方法：GetDrugMaintainRecordDetailByCondition", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

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


        public DrugMaintainSet GetDrugMaintainSetByDrugMaintainTypeValue(int DrugMaintainTypeValue, out string message)
        {
            //Log.Warning("客户端开始调用GetDrugMaintainSetByDrugMaintainTypeValue");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugMaintainSetBusinessHandler.GetDrugMaintainSetByDrugMaintainTypeValue(DrugMaintainTypeValue);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<DrugMaintainSet>("服务调用业务逻辑方法：GetDrugMaintainSetByDrugMaintainTypeValue", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

        #endregion

        #region 员工(EmployeeBusinessHandler)的自定义逻辑


        public List<BusinessPersonModel> QueryBusinessPerson(QueryBusinessPersonModel queryBusinessPersonModel, out string message)
        {
            //Log.Warning("客户端开始调用QueryBusinessPerson");
            message = string.Empty;
            try
            {
                return HandlerFactory.EmployeeBusinessHandler.QueryBusinessPerson(queryBusinessPersonModel);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<BusinessPersonModel>>("服务调用业务逻辑方法：QueryBusinessPerson", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

        #endregion

        #region GMSP证书规定的经营范围(GMSPLicenseBusinessScopeBusinessHandler)的自定义逻辑

        #endregion

        #region 库存(InventoryRecordBusinessHandler)的自定义逻辑


        public InventoryRecord GetInventoryRecordByDrugInfoID(Guid drugInfoID, out string message)
        {
            //Log.Warning("客户端开始调用GetInventoryRecordByDrugInfoID");
            message = string.Empty;
            try
            {
                return HandlerFactory.InventoryRecordBusinessHandler.GetInventoryRecordByDrugInfoID(drugInfoID);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<InventoryRecord>("服务调用业务逻辑方法：GetInventoryRecordByDrugInfoID", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }

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


        public List<PharmacyLicense> QueryPharmacyLicenseForOutdate(QueryPharmacyLicenseModel queryModel, out string message)
        {
            //Log.Warning("客户端开始调用QueryPharmacyLicenseForOutdate");
            message = string.Empty;
            try
            {
                return HandlerFactory.BusinessLicenseBusinessHandler.QueryPharmacyLicenseForOutdate(queryModel);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PharmacyLicense>>("服务调用业务逻辑方法：QueryPharmacyLicenseForOutdate", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

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


        public IEnumerable<String> GetAuthorityKeys(Guid userId, out string message)
        {
            //Log.Warning("客户端开始调用GetAuthorityKeys");
            message = string.Empty;
            try
            {
                return HandlerFactory.ModuleBusinessHandler.GetAuthorityKeys(userId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<String>>("服务调用业务逻辑方法：GetAuthorityKeys", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

        #endregion

        #region 功能模块分类(ModuleCatetoryBusinessHandler)的自定义逻辑

        #endregion

        #region 功能模块与角色的关联(ModuleWithRoleBusinessHandler)的自定义逻辑


        public List<ModuleWithRole> GetModuleWithRolesByRoleId(Guid roleId, out string message)
        {
            //Log.Warning("客户端开始调用GetModuleWithRolesByRoleId");
            message = string.Empty;
            try
            {
                return HandlerFactory.ModuleWithRoleBusinessHandler.GetModuleWithRolesByRoleId(roleId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<ModuleWithRole>>("服务调用业务逻辑方法：GetModuleWithRolesByRoleId", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<ModuleWithRole> GetModuleWithRolesByModuleId(Guid moduleId, out string message)
        {
            //Log.Warning("客户端开始调用GetModuleWithRolesByModuleId");
            message = string.Empty;
            try
            {
                return HandlerFactory.ModuleWithRoleBusinessHandler.GetModuleWithRolesByModuleId(moduleId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<ModuleWithRole>>("服务调用业务逻辑方法：GetModuleWithRolesByModuleId", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public bool AuthModuleWithRoleCatetoryAuthModuleIds(Role role, ModuleCatetory catetory, List<Guid> authModuleIds, out string message)
        {
            //Log.Warning("客户端开始调用AuthModuleWithRoleCatetoryAuthModuleIds");
            message = string.Empty;
            try
            {
                return HandlerFactory.ModuleWithRoleBusinessHandler.AuthModuleWithRoleCatetoryAuthModuleIds(role, catetory, authModuleIds);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<bool>("服务调用业务逻辑方法：AuthModuleWithRoleCatetoryAuthModuleIds", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

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


        public List<PurchaseRecord> GetPurchaseRecords(int type, String productGeneralName, DateTime startTime, DateTime endTime, Guid[] purchaseUnits, int index, int size, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseRecords");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseRecords(type, productGeneralName, startTime, endTime, purchaseUnits, index, size);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseRecord>>("服务调用业务逻辑方法：GetPurchaseRecords", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<PurchaseRCRecord> GetPurchaseRCRecords(int type, String productGeneralName, DateTime startTime, DateTime endTime, Guid[] purchaseUnits, int index, int size, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseRCRecords");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseRCRecords(type, productGeneralName, startTime, endTime, purchaseUnits, index, size);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseRCRecord>>("服务调用业务逻辑方法：GetPurchaseRCRecords", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<PurchaseOrderDetailEntity> GetPurchaseHistoryForDrugInfo(Guid drupInfoId, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseHistoryForDrugInfo");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseHistoryForDrugInfo(drupInfoId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseOrderDetailEntity>>("服务调用业务逻辑方法：GetPurchaseHistoryForDrugInfo", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public PurchaseOrdeEntity GetPurchaseOrderEntity(Guid purchaseOrderId, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseOrderEntity");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseOrderEntity(purchaseOrderId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<PurchaseOrdeEntity>("服务调用业务逻辑方法：GetPurchaseOrderEntity", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<PurchaseOrdeEntity> GetPurchaseOrders(String documentNumber, DateTime startTime, DateTime endTime, Int32[] orderStatusValue, Guid[] purchaseUnits, int index, int size, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseOrders");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseOrders(documentNumber, startTime, endTime, orderStatusValue, purchaseUnits, index, size);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseOrdeEntity>>("服务调用业务逻辑方法：GetPurchaseOrders", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<PurchaseOrderDetailEntity> GetPurchaseOrderDetails(Guid purchaseOrderId, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseOrderDetails");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseOrderDetails(purchaseOrderId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseOrderDetailEntity>>("服务调用业务逻辑方法：GetPurchaseOrderDetails", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public String CreatePurchaseOrder(PurchaseOrder order, List<PurchaseOrderDetail> orderDetails, out string message)
        {
            //Log.Warning("客户端开始调用CreatePurchaseOrder");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.CreatePurchaseOrder(order, orderDetails);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<String>("服务调用业务逻辑方法：CreatePurchaseOrder", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void HandlePurchaseReceinvingAmountDiff(PurchaseOrder purchaseOrder, out string message)
        {
            //Log.Warning("客户端开始调用HandlePurchaseReceinvingAmountDiff");
            message = string.Empty;
            try
            {
                HandlerFactory.PurchaseOrderBusinessHandler.HandlePurchaseReceinvingAmountDiff(purchaseOrder);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：HandlePurchaseReceinvingAmountDiff", ex);
            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<PurchaseCommonEntity> GetPurchaseReceivingOrdersByPurchaseOrderId(Guid purchaseOrderId, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseReceivingOrdersByPurchaseOrderId");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseReceivingOrdersByPurchaseOrderId(purchaseOrderId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseCommonEntity>>("服务调用业务逻辑方法：GetPurchaseReceivingOrdersByPurchaseOrderId", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public String CreatePurchaseReceivingOrderByEnity(PurchaseCommonEntity order, List<PurchaseReceivingOrderDetailEntity> orderDetails, out string message)
        {
            //Log.Warning("客户端开始调用CreatePurchaseReceivingOrderByEnity");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.CreatePurchaseReceivingOrderByEnity(order, orderDetails);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<String>("服务调用业务逻辑方法：CreatePurchaseReceivingOrderByEnity", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public String CreatePurchaseReceivingOrder(PurchaseReceivingOrder order, List<PurchaseReceivingOrderDetail> orderDetails, out string message)
        {
            //Log.Warning("客户端开始调用CreatePurchaseReceivingOrder");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.CreatePurchaseReceivingOrder(order, orderDetails);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<String>("服务调用业务逻辑方法：CreatePurchaseReceivingOrder", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<PurchaseCommonEntity> GetPurchaseReceivingOrders(String documentNumber, DateTime startTime, DateTime endTime, Int32[] orderStatusValue, Guid[] purchaseUnits, int index, int size, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseReceivingOrders");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseReceivingOrders(documentNumber, startTime, endTime, orderStatusValue, purchaseUnits, index, size);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseCommonEntity>>("服务调用业务逻辑方法：GetPurchaseReceivingOrders", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<PurchaseReceivingOrderDetailEntity> GetPurchaseReceivingOrderDetails(Guid orderId, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseReceivingOrderDetails");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseReceivingOrderDetails(orderId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseReceivingOrderDetailEntity>>("服务调用业务逻辑方法：GetPurchaseReceivingOrderDetails", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<PurchaseCommonEntity> GetPurchaseCheckingOrdersByPurchaseOrderId(Guid purchaseOrderId, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseCheckingOrdersByPurchaseOrderId");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseCheckingOrdersByPurchaseOrderId(purchaseOrderId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseCommonEntity>>("服务调用业务逻辑方法：GetPurchaseCheckingOrdersByPurchaseOrderId", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public String CreatePurchaseCheckingOrderByEnity(PurchaseCommonEntity order, List<PurchaseCheckingOrderDetailEntity> orderDetails, List<DrugsUndeterminate> ListUndeterminate, out string message)
        {
            //Log.Warning("客户端开始调用CreatePurchaseCheckingOrderByEnity");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.CreatePurchaseCheckingOrderByEnity(order, orderDetails, ListUndeterminate);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<String>("服务调用业务逻辑方法：CreatePurchaseCheckingOrderByEnity", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public String CreatePurchaseCheckingOrder(PurchaseCheckingOrder order, List<PurchaseCheckingOrderDetail> orderDetails, List<DrugsUndeterminate> ListUndeterminate, out string message)
        {
            //Log.Warning("客户端开始调用CreatePurchaseCheckingOrder");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.CreatePurchaseCheckingOrder(order, orderDetails, ListUndeterminate);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<String>("服务调用业务逻辑方法：CreatePurchaseCheckingOrder", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<PurchaseCommonEntity> GetPurchaseCheckingOrders(String documentNumber, DateTime startTime, DateTime endTime, Int32[] orderStatusValue, Guid[] purchaseUnits, int index, int size, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseCheckingOrders");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseCheckingOrders(documentNumber, startTime, endTime, orderStatusValue, purchaseUnits, index, size);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseCommonEntity>>("服务调用业务逻辑方法：GetPurchaseCheckingOrders", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<PurchaseCheckingOrderDetailEntity> GetPurchaseCheckingOrderDetails(Guid orderId, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseCheckingOrderDetails");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseCheckingOrderDetails(orderId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseCheckingOrderDetailEntity>>("服务调用业务逻辑方法：GetPurchaseCheckingOrderDetails", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<PurchaseCommonEntity> GetPurchaseInInventeryOrdersByPurchaseOrderId(Guid purchaseOrderId, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseInInventeryOrdersByPurchaseOrderId");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseInInventeryOrdersByPurchaseOrderId(purchaseOrderId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseCommonEntity>>("服务调用业务逻辑方法：GetPurchaseInInventeryOrdersByPurchaseOrderId", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public String CreatePurchaseInInventeryOrderByEnity(PurchaseCommonEntity order, List<PurchaseInInventeryOrderDetailEntity> orderDetails, out string message)
        {
            //Log.Warning("客户端开始调用CreatePurchaseInInventeryOrderByEnity");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.CreatePurchaseInInventeryOrderByEnity(order, orderDetails);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<String>("服务调用业务逻辑方法：CreatePurchaseInInventeryOrderByEnity", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public String CreatePurchaseInInventeryOrder(PurchaseInInventeryOrder order, List<PurchaseInInventeryOrderDetail> orderDetails, out string message)
        {
            //Log.Warning("客户端开始调用CreatePurchaseInInventeryOrder");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.CreatePurchaseInInventeryOrder(order, orderDetails);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<String>("服务调用业务逻辑方法：CreatePurchaseInInventeryOrder", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<PurchaseInInventeryOrderDetailEntity> GetPurchaseInInventeryOrderDetails(Guid orderId, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseInInventeryOrderDetails");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseInInventeryOrderDetails(orderId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseInInventeryOrderDetailEntity>>("服务调用业务逻辑方法：GetPurchaseInInventeryOrderDetails", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<PurchaseCommonEntity> GetPurchaseInInventeryOrders(String documentNumber, DateTime startTime, DateTime endTime, Int32[] orderStatusValue, Guid[] purchaseUnits, int index, int size, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseInInventeryOrders");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseInInventeryOrders(documentNumber, startTime, endTime, orderStatusValue, purchaseUnits, index, size);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseCommonEntity>>("服务调用业务逻辑方法：GetPurchaseInInventeryOrders", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<PurchaseCommonEntity> GetPurchaseOrderReturnsByPurchaseOrderId(Guid purchaseOrderId, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseOrderReturnsByPurchaseOrderId");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseOrderReturnsByPurchaseOrderId(purchaseOrderId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseCommonEntity>>("服务调用业务逻辑方法：GetPurchaseOrderReturnsByPurchaseOrderId", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public String CreatePurchaseOrderReturnByEnity(PurchaseCommonEntity order, List<PurchaseOrderReturnDetailEntity> orderDetails, out string message)
        {
            //Log.Warning("客户端开始调用CreatePurchaseOrderReturnByEnity");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.CreatePurchaseOrderReturnByEnity(order, orderDetails);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<String>("服务调用业务逻辑方法：CreatePurchaseOrderReturnByEnity", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public String CreatePurchaseOrderReturn(PurchaseOrderReturn order, List<PurchaseOrderReturnDetail> orderDetails, out string message)
        {
            //Log.Warning("客户端开始调用CreatePurchaseOrderReturn");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.CreatePurchaseOrderReturn(order, orderDetails);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<String>("服务调用业务逻辑方法：CreatePurchaseOrderReturn", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<PurchaseCommonEntity> GetPurchaseOrderReturns(String documentNumber, DateTime startTime, DateTime endTime, Int32[] orderStatusValue, Guid[] purchaseUnits, int index, int size, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseOrderReturns");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseOrderReturns(documentNumber, startTime, endTime, orderStatusValue, purchaseUnits, index, size);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseCommonEntity>>("服务调用业务逻辑方法：GetPurchaseOrderReturns", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<PurchaseOrderReturnDetailEntity> GetPurchaseOrderReturnDetails(Guid orderId, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseOrderReturnDetails");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseOrderReturnDetails(orderId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseOrderReturnDetailEntity>>("服务调用业务逻辑方法：GetPurchaseOrderReturnDetails", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<PurchaseCommonEntity> GetPurchaseCashOrdersByPurchaseOrderId(Guid purchaseOrderId, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseCashOrdersByPurchaseOrderId");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseCashOrdersByPurchaseOrderId(purchaseOrderId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseCommonEntity>>("服务调用业务逻辑方法：GetPurchaseCashOrdersByPurchaseOrderId", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public String CreatePurchaseCashOrderByEnity(PurchaseCommonEntity order, out string message)
        {
            //Log.Warning("客户端开始调用CreatePurchaseCashOrderByEnity");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.CreatePurchaseCashOrderByEnity(order);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<String>("服务调用业务逻辑方法：CreatePurchaseCashOrderByEnity", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public String CreatePurchaseCashOrder(PurchaseCashOrder order, out string message)
        {
            //Log.Warning("客户端开始调用CreatePurchaseCashOrder");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.CreatePurchaseCashOrder(order);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<String>("服务调用业务逻辑方法：CreatePurchaseCashOrder", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<PurchaseCommonEntity> GetPurchaseCashOrders(String documentNumber, DateTime startTime, DateTime endTime, Int32[] orderStatusValue, Guid[] purchaseUnits, int index, int size, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseCashOrders");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseCashOrders(documentNumber, startTime, endTime, orderStatusValue, purchaseUnits, index, size);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseCommonEntity>>("服务调用业务逻辑方法：GetPurchaseCashOrders", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }

        #endregion

        #region 采购明细(PurchaseOrderDetailBusinessHandler)的自定义逻辑


        public IEnumerable<PurchaseOrderDetail> GetPurchaseOrderDetailByOrderId(Guid purchaseOrderId, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseOrderDetailByOrderId");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderDetailBusinessHandler.GetPurchaseOrderDetailByOrderId(purchaseOrderId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<PurchaseOrderDetail>>("服务调用业务逻辑方法：GetPurchaseOrderDetailByOrderId", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }

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


        public List<String> GetBusinessScopeCodesByPurchaseUnitGuid(Guid purchaseUnitGuid, out string message)
        {
            //Log.Warning("客户端开始调用GetBusinessScopeCodesByPurchaseUnitGuid");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseUnitBusinessHandler.GetBusinessScopeCodesByPurchaseUnitGuid(purchaseUnitGuid);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<String>>("服务调用业务逻辑方法：GetBusinessScopeCodesByPurchaseUnitGuid", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<String> GetBusinessScopeCodesByPurchaseUnit(PurchaseUnit purchaseUnit, out string message)
        {
            //Log.Warning("客户端开始调用GetBusinessScopeCodesByPurchaseUnit");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseUnitBusinessHandler.GetBusinessScopeCodesByPurchaseUnit(purchaseUnit);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<String>>("服务调用业务逻辑方法：GetBusinessScopeCodesByPurchaseUnit", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<String> GetManageCategoryDetailByPurchaseUnitGuid(Guid purchaseUnitGuid, out string message)
        {
            //Log.Warning("客户端开始调用GetManageCategoryDetailByPurchaseUnitGuid");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseUnitBusinessHandler.GetManageCategoryDetailByPurchaseUnitGuid(purchaseUnitGuid);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<String>>("服务调用业务逻辑方法：GetManageCategoryDetailByPurchaseUnitGuid", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<String> GetManageCategoryDetailByPurchaseUnit(PurchaseUnit purchaseUnit, out string message)
        {
            //Log.Warning("客户端开始调用GetManageCategoryDetailByPurchaseUnit");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseUnitBusinessHandler.GetManageCategoryDetailByPurchaseUnit(purchaseUnit);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<String>>("服务调用业务逻辑方法：GetManageCategoryDetailByPurchaseUnit", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<PurchaseUnit> GetPurchaseUnitsForSelector(String name, String code, String py, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseUnitsForSelector");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseUnitBusinessHandler.GetPurchaseUnitsForSelector(name, code, py);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseUnit>>("服务调用业务逻辑方法：GetPurchaseUnitsForSelector", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public bool IsExistPurchaseUnitByName(String name, out string message)
        {
            //Log.Warning("客户端开始调用IsExistPurchaseUnitByName");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseUnitBusinessHandler.IsExistPurchaseUnitByName(name);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<bool>("服务调用业务逻辑方法：IsExistPurchaseUnitByName", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public PurchaseUnit GetPurchaseUnitByName(String name, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseUnitByName");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseUnitBusinessHandler.GetPurchaseUnitByName(name);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<PurchaseUnit>("服务调用业务逻辑方法：GetPurchaseUnitByName", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public bool UpdatePurchaseUnitByName(String name, PurchaseUnit item, out string message)
        {
            //Log.Warning("客户端开始调用UpdatePurchaseUnitByName");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseUnitBusinessHandler.UpdatePurchaseUnitByName(name, item);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<bool>("服务调用业务逻辑方法：UpdatePurchaseUnitByName", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public PurchaseUnit GetPurchaseUnitByFlowID(Guid flowId, out string message)
        {
            //Log.Warning("客户端开始调用GetPurchaseUnitByFlowID");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseUnitBusinessHandler.GetPurchaseUnitByFlowID(flowId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<PurchaseUnit>("服务调用业务逻辑方法：GetPurchaseUnitByFlowID", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void AddPurchaseUnitApproveFlow(PurchaseUnit su, Guid approvalFlowTypeID, Guid userID, String changeNote, out string message)
        {
            //Log.Warning("客户端开始调用AddPurchaseUnitApproveFlow");
            message = string.Empty;
            try
            {
                HandlerFactory.PurchaseUnitBusinessHandler.AddPurchaseUnitApproveFlow(su, approvalFlowTypeID, userID, changeNote);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：AddPurchaseUnitApproveFlow", ex);
            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void ModifyPurchaseUnitApproveFlow(PurchaseUnit su, Guid approvalFlowTypeID, Guid userID, String changeNote, out string message)
        {
            //Log.Warning("客户端开始调用ModifyPurchaseUnitApproveFlow");
            message = string.Empty;
            try
            {
                HandlerFactory.PurchaseUnitBusinessHandler.ModifyPurchaseUnitApproveFlow(su, approvalFlowTypeID, userID, changeNote);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：ModifyPurchaseUnitApproveFlow", ex);
            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<PurchaseUnit> GetLockPurchaseUnit(out string message)
        {
            //Log.Warning("客户端开始调用GetLockPurchaseUnit");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseUnitBusinessHandler.GetLockPurchaseUnit();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<PurchaseUnit>>("服务调用业务逻辑方法：GetLockPurchaseUnit", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public int GetLockPurchaseUnitCount(out string message)
        {
            //Log.Warning("客户端开始调用GetLockPurchaseUnitCount");
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseUnitBusinessHandler.GetLockPurchaseUnitCount();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<int>("服务调用业务逻辑方法：GetLockPurchaseUnitCount", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public IEnumerable<PurchaseUnit> GetPagedLockPurchaseUnit(out PagerInfo pager, int pageindex, int pageSize, out string message)
        {
            //Log.Warning("客户端开始调用GetPagedLockPurchaseUnit");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.PurchaseUnitBusinessHandler.GetPagedLockPurchaseUnit(out pager, pageindex, pageSize);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<PurchaseUnit>>("服务调用业务逻辑方法：GetPagedLockPurchaseUnit", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

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


        public IEnumerable<RetailOrder> GetRetailOrderPagedByCode(String orderCode, out PagerInfo pager, int pageindex, int pageSize, out string message)
        {
            //Log.Warning("客户端开始调用GetRetailOrderPagedByCode");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.RetailOrderBusinessHandler.GetRetailOrderPagedByCode(orderCode, out pager, pageindex, pageSize);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<RetailOrder>>("服务调用业务逻辑方法：GetRetailOrderPagedByCode", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void AddRetailOrderAndDetails(RetailOrder ro, out string message)
        {
            //Log.Warning("客户端开始调用AddRetailOrderAndDetails");
            message = string.Empty;
            try
            {
                HandlerFactory.RetailOrderBusinessHandler.AddRetailOrderAndDetails(ro);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：AddRetailOrderAndDetails", ex);
            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void DeleteRetailOrderAndDetails(Guid retailOrderID, out string message)
        {
            //Log.Warning("客户端开始调用DeleteRetailOrderAndDetails");
            message = string.Empty;
            try
            {
                HandlerFactory.RetailOrderBusinessHandler.DeleteRetailOrderAndDetails(retailOrderID);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：DeleteRetailOrderAndDetails", ex);
            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void SaveRetailOrderAndDetails(RetailOrder ro, out string message)
        {
            //Log.Warning("客户端开始调用SaveRetailOrderAndDetails");
            message = string.Empty;
            try
            {
                HandlerFactory.RetailOrderBusinessHandler.SaveRetailOrderAndDetails(ro);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：SaveRetailOrderAndDetails", ex);
            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

        #endregion

        #region 零售单明细(RetailOrderDetailBusinessHandler)的自定义逻辑

        #endregion

        #region 系统角色(RoleBusinessHandler)的自定义逻辑

        #endregion

        #region 角色与用户的关联(RoleWithUserBusinessHandler)的自定义逻辑


        public IEnumerable<RoleWithUser> GetRoleWithUserInfo(Guid UserID, Guid RoleId, out string message)
        {
            //Log.Warning("客户端开始调用GetRoleWithUserInfo");
            message = string.Empty;
            try
            {
                return HandlerFactory.RoleWithUserBusinessHandler.GetRoleWithUserInfo(UserID, RoleId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<RoleWithUser>>("服务调用业务逻辑方法：GetRoleWithUserInfo", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

        #endregion

        #region 销售单(SalesOrderBusinessHandler)的自定义逻辑


        public List<SalesOrder> GetOrderStatusList(List<Int32> orderStatusList, out string message)
        {
            //Log.Warning("客户端开始调用GetOrderStatusList");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.GetOrderStatusList(orderStatusList);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<SalesOrder>>("服务调用业务逻辑方法：GetOrderStatusList", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public void AddSalesOrderAndDetails(SalesOrder so, out string message)
        {
            //Log.Warning("客户端开始调用AddSalesOrderAndDetails");
            message = string.Empty;
            try
            {
                HandlerFactory.SalesOrderBusinessHandler.AddSalesOrderAndDetails(so);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：AddSalesOrderAndDetails", ex);
            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void ModifySalesOrderAndDetails(SalesOrder so, out string message)
        {
            //Log.Warning("客户端开始调用ModifySalesOrderAndDetails");
            message = string.Empty;
            try
            {
                HandlerFactory.SalesOrderBusinessHandler.ModifySalesOrderAndDetails(so);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：ModifySalesOrderAndDetails", ex);
            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void DeleteSalesOrderAndDetails(Guid salesOrderID, out string message)
        {
            //Log.Warning("客户端开始调用DeleteSalesOrderAndDetails");
            message = string.Empty;
            try
            {
                HandlerFactory.SalesOrderBusinessHandler.DeleteSalesOrderAndDetails(salesOrderID);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：DeleteSalesOrderAndDetails", ex);
            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public IEnumerable<SalesOrder> GetSalesOrderByStatus(int statusValue, out string message)
        {
            //Log.Warning("客户端开始调用GetSalesOrderByStatus");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.GetSalesOrderByStatus(statusValue);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<SalesOrder>>("服务调用业务逻辑方法：GetSalesOrderByStatus", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public IEnumerable<SalesOrder> GetSalesOrderByOrderCode(String code, out string message)
        {
            //Log.Warning("客户端开始调用GetSalesOrderByOrderCode");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.GetSalesOrderByOrderCode(code);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<SalesOrder>>("服务调用业务逻辑方法：GetSalesOrderByOrderCode", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<SalesOrderStatisticOutput> AddupSalesOrder(SalesOrderStatisticInput input, out string message)
        {
            //Log.Warning("客户端开始调用AddupSalesOrder");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.AddupSalesOrder(input);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<SalesOrderStatisticOutput>>("服务调用业务逻辑方法：AddupSalesOrder", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public IEnumerable<Business.Models.SaleOrderModel> GetSalesOrderBalanceCodePaged(SalesCodeSearchInput searchInput, out string message)
        {
            //Log.Warning("客户端开始调用GetSalesOrderBalanceCodePaged");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.GetSalesOrderBalanceCodePaged(searchInput);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<Business.Models.SaleOrderModel>>("服务调用业务逻辑方法：GetSalesOrderBalanceCodePaged", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public System.Collections.Generic.IEnumerable<Business.Models.SaleOrderModel> GetSalesOrderCodePaged(Business.Models.SalesCodeSearchInput searchInput, out string message)
        {
            //Log.Warning("客户端开始调用GetSalesOrderCodePaged");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.GetSalesOrderCodePaged(searchInput);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<Business.Models.SaleOrderModel>>("服务调用业务逻辑方法：GetSalesOrderCodePaged", ex);
            }
            finally
            {
                this.Dispose();
            }
        }


        public IEnumerable<Business.Models.SaleOrderModel> GetSalesOrderCancelCodePaged(out string message,SalesCodeSearchInput searchInput)
        {
            //Log.Warning("客户端开始调用GetSalesOrderCancelCodePaged");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.GetSalesOrderCancelCodePaged(searchInput);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<Business.Models.SaleOrderModel>>("服务调用业务逻辑方法：GetSalesOrderCancelCodePaged", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<User> GetSalesOrderOperatorUser(out string message)
        {
            //Log.Warning("客户端开始调用GetSalesOrderOperatorUser");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.GetSalesOrderOperatorUser();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<User>>("服务调用业务逻辑方法：GetSalesOrderOperatorUser", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<User> GetSalesOrderCancelUser(out string message)
        {
            //Log.Warning("客户端开始调用GetSalesOrderCancelUser");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.GetSalesOrderCancelUser();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<User>>("服务调用业务逻辑方法：GetSalesOrderCancelUser", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<User> GetSalesOrderBalanceUser(out string message)
        {
            //Log.Warning("客户端开始调用GetSalesOrderBalanceUser");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.GetSalesOrderBalanceUser();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<User>>("服务调用业务逻辑方法：GetSalesOrderBalanceUser", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<SalesOrderRecordOutput> GetSalesOrderRecordPaged(SalesOrderRecordInput searchInput, out PagerInfo pager, int pageindex, int pageSize, out string message)
        {
            //Log.Warning("客户端开始调用GetSalesOrderRecordPaged");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.GetSalesOrderRecordPaged(searchInput, out pager, pageindex, pageSize);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<SalesOrderRecordOutput>>("服务调用业务逻辑方法：GetSalesOrderRecordPaged", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public void CancelSalesOrder(SalesOrder so, out string message)
        {
            //Log.Warning("客户端开始调用CancelSalesOrder");
            message = string.Empty;
            try
            {
                HandlerFactory.SalesOrderBusinessHandler.CancelSalesOrder(so);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：CancelSalesOrder", ex);
            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }

        #endregion

        #region (SalesOrderDeliverDetailBusinessHandler)的自定义逻辑

        #endregion

        #region 销售发货记录(SalesOrderDeliverRecordBusinessHandler)的自定义逻辑

        #endregion

        #region 销售单明细(SalesOrderDetailBusinessHandler)的自定义逻辑

        #endregion

        #region (SalesOrderReturnBusinessHandler)的自定义逻辑


        public List<SalesOrderReturn> GetAllNoOverOrderReturn(out string message)
        {
            //Log.Warning("客户端开始调用GetAllNoOverOrderReturn");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderReturnBusinessHandler.GetAllNoOverOrderReturn();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<SalesOrderReturn>>("服务调用业务逻辑方法：GetAllNoOverOrderReturn", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<SalesOrderReturn> GetSalesOrderReturnByStatus(List<Int32> listOrderReturnStatus, out string message)
        {
            //Log.Warning("客户端开始调用GetSalesOrderReturnByStatus");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderReturnBusinessHandler.GetSalesOrderReturnByStatus(listOrderReturnStatus);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<SalesOrderReturn>>("服务调用业务逻辑方法：GetSalesOrderReturnByStatus", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public SalesOrderReturn GetLastOrderReturnByReturnOrder(Guid outInventoryID, out string message)
        {
            //Log.Warning("客户端开始调用GetLastOrderReturnByReturnOrder");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderReturnBusinessHandler.GetLastOrderReturnByReturnOrder(outInventoryID);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<SalesOrderReturn>("服务调用业务逻辑方法：GetLastOrderReturnByReturnOrder", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void AddSalesOrderReturnAndDetail(SalesOrderReturn sor, out string message)
        {
            //Log.Warning("客户端开始调用AddSalesOrderReturnAndDetail");
            message = string.Empty;
            try
            {
                HandlerFactory.SalesOrderReturnBusinessHandler.AddSalesOrderReturnAndDetail(sor);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：AddSalesOrderReturnAndDetail", ex);
            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void CancelSalesOrderReturn(SalesOrderReturn sor, out string message)
        {
            //Log.Warning("客户端开始调用CancelSalesOrderReturn");
            message = string.Empty;
            try
            {
                HandlerFactory.SalesOrderReturnBusinessHandler.CancelSalesOrderReturn(sor);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：CancelSalesOrderReturn", ex);
            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void AcceptSalesOrderReturn(SalesOrderReturn sor, out string message)
        {
            //Log.Warning("客户端开始调用AcceptSalesOrderReturn");
            message = string.Empty;
            try
            {
                HandlerFactory.SalesOrderReturnBusinessHandler.AcceptSalesOrderReturn(sor);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：AcceptSalesOrderReturn", ex);
            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void SaveReturnOrderInventory(SalesOrderReturn sor, out string message)
        {
            //Log.Warning("客户端开始调用SaveReturnOrderInventory");
            message = string.Empty;
            try
            {
                HandlerFactory.SalesOrderReturnBusinessHandler.SaveReturnOrderInventory(sor);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：SaveReturnOrderInventory", ex);
            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public IEnumerable<SalesOrderReturn> GetReturnOrderCodePaged(SalesCodeSearchInput searchInput, out PagerInfo pager, int pageindex, int pageSize, out string message)
        {
            //Log.Warning("客户端开始调用GetReturnOrderCodePaged");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.SalesOrderReturnBusinessHandler.GetReturnOrderCodePaged(searchInput, out pager, pageindex, pageSize);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<SalesOrderReturn>>("服务调用业务逻辑方法：GetReturnOrderCodePaged", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public IEnumerable<Business.Models.SalesOrderReturnModel> GetReturnOrderCheckCodePaged(SalesCodeSearchInput searchInput, out string message)
        {
            //Log.Warning("客户端开始调用GetReturnOrderCheckCodePaged");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderReturnBusinessHandler.GetReturnOrderCheckCodePaged(searchInput);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<Business.Models.SalesOrderReturnModel>>("服务调用业务逻辑方法：GetReturnOrderCheckCodePaged", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public IEnumerable<SalesOrderReturn> GetReturnOrderInventoryCodePaged(SalesCodeSearchInput searchInput, out PagerInfo pager, int pageindex, int pageSize, out string message)
        {
            //Log.Warning("客户端开始调用GetReturnOrderInventoryCodePaged");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.SalesOrderReturnBusinessHandler.GetReturnOrderInventoryCodePaged(searchInput, out pager, pageindex, pageSize);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<SalesOrderReturn>>("服务调用业务逻辑方法：GetReturnOrderInventoryCodePaged", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public IEnumerable<Business.Models.SalesOrderReturnModel> GetReturnOrderCancelCodePaged(SalesCodeSearchInput searchInput, out string message)
        {
            //Log.Warning("客户端开始调用GetReturnOrderCancelCodePaged");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderReturnBusinessHandler.GetReturnOrderCancelCodePaged(searchInput);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<Business.Models.SalesOrderReturnModel>>("服务调用业务逻辑方法：GetReturnOrderCancelCodePaged", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void SaveReturnOrderOutventory(SalesOrderReturn sor, out string message)
        {
            //Log.Warning("客户端开始调用SaveReturnOrderOutventory");
            message = string.Empty;
            try
            {
                HandlerFactory.SalesOrderReturnBusinessHandler.SaveReturnOrderOutventory(sor);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：SaveReturnOrderOutventory", ex);
            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<User> GetSalesReturnOperatorUser(out string message)
        {
            //Log.Warning("客户端开始调用GetSalesReturnOperatorUser");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderReturnBusinessHandler.GetSalesReturnOperatorUser();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<User>>("服务调用业务逻辑方法：GetSalesReturnOperatorUser", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<User> GetSalesReturnCheckUser(out string message)
        {
            //Log.Warning("客户端开始调用GetSalesReturnCheckUser");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderReturnBusinessHandler.GetSalesReturnCheckUser();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<User>>("服务调用业务逻辑方法：GetSalesReturnCheckUser", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<User> GetSalesReturnInventoryUser(out string message)
        {
            //Log.Warning("客户端开始调用GetSalesReturnInventoryUser");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderReturnBusinessHandler.GetSalesReturnInventoryUser();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<User>>("服务调用业务逻辑方法：GetSalesReturnInventoryUser", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<User> GetSalesReturnCancelUser(out string message)
        {
            //Log.Warning("客户端开始调用GetSalesReturnCancelUser");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderReturnBusinessHandler.GetSalesReturnCancelUser();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<User>>("服务调用业务逻辑方法：GetSalesReturnCancelUser", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

        #endregion

        #region (SalesOrderReturnDetailBusinessHandler)的自定义逻辑


        public List<SalesOrderReturnDetail> getOrderReturnDetailListByOrderID(Guid orderID, out string message)
        {
            //Log.Warning("客户端开始调用getOrderReturnDetailListByOrderID");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderReturnDetailBusinessHandler.getOrderReturnDetailListByOrderID(orderID);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<SalesOrderReturnDetail>>("服务调用业务逻辑方法：getOrderReturnDetailListByOrderID", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<SalesOrderReturnDetail> GetLastReturnDetailByReturnOrder(Guid orderID, out string message)
        {
            //Log.Warning("客户端开始调用GetLastReturnDetailByReturnOrder");
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderReturnDetailBusinessHandler.GetLastReturnDetailByReturnOrder(orderID);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<SalesOrderReturnDetail>>("服务调用业务逻辑方法：GetLastReturnDetailByReturnOrder", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void SaveOrderReturnDetailList(SalesOrder orderInfo, List<SalesOrderReturnDetail> detailList, out string message)
        {
            //Log.Warning("客户端开始调用SaveOrderReturnDetailList");
            message = string.Empty;
            try
            {
                HandlerFactory.SalesOrderReturnDetailBusinessHandler.SaveOrderReturnDetailList(orderInfo, detailList);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：SaveOrderReturnDetailList", ex);
            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

        #endregion

        #region 销售出库单(OutInventoryBusinessHandler)的自定义逻辑


        public List<OutInventory> GetSubmitedOutInventoryByCondition(SalesCodeSearchInput condition, int pageindex, int pageSize, out PagerInfo pager, out string message)
        {
            //Log.Warning("客户端开始调用GetSubmitedOutInventoryByCondition");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.OutInventoryBusinessHandler.GetSubmitedOutInventoryByCondition(condition, pageindex, pageSize, out pager);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<OutInventory>>("服务调用业务逻辑方法：GetSubmitedOutInventoryByCondition", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<OutInventory> GetAcceptedOutInventoryByCondition(SalesCodeSearchInput condition, int pageindex, int pageSize, out PagerInfo pager, out string message)
        {
            //Log.Warning("客户端开始调用GetAcceptedOutInventoryByCondition");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.OutInventoryBusinessHandler.GetAcceptedOutInventoryByCondition(condition, pageindex, pageSize, out pager);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<OutInventory>>("服务调用业务逻辑方法：GetAcceptedOutInventoryByCondition", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<OutInventory> GetOutInventoryByStatus(int iStatus, out string message)
        {
            //Log.Warning("客户端开始调用GetOutInventoryByStatus");
            message = string.Empty;
            try
            {
                return HandlerFactory.OutInventoryBusinessHandler.GetOutInventoryByStatus(iStatus);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<OutInventory>>("服务调用业务逻辑方法：GetOutInventoryByStatus", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<OutInventory> GetAllNotApprovalOutInventory(out string message)
        {
            //Log.Warning("客户端开始调用GetAllNotApprovalOutInventory");
            message = string.Empty;
            try
            {
                return HandlerFactory.OutInventoryBusinessHandler.GetAllNotApprovalOutInventory();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<OutInventory>>("服务调用业务逻辑方法：GetAllNotApprovalOutInventory", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }


        public List<OutInventory> GetOutInventoryByOrderID(Guid orderID, out string message)
        {
            //Log.Warning("客户端开始调用GetOutInventoryByOrderID");
            message = string.Empty;
            try
            {
                return HandlerFactory.OutInventoryBusinessHandler.GetOutInventoryByOrderID(orderID);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<OutInventory>>("服务调用业务逻辑方法：GetOutInventoryByOrderID", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void SubmitOutInventory(OutInventory entity, out string message)
        {
            //Log.Warning("客户端开始调用SubmitOutInventory");
            message = string.Empty;
            try
            {
                HandlerFactory.OutInventoryBusinessHandler.SubmitOutInventory(entity);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：SubmitOutInventory", ex);
            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void AcceptOutInverntory(OutInventory entity, out string message)
        {
            //Log.Warning("客户端开始调用AcceptOutInverntory");
            message = string.Empty;
            try
            {
                HandlerFactory.OutInventoryBusinessHandler.AcceptOutInverntory(entity);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：AcceptOutInverntory", ex);
            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<OutInventoryDetail> GetOutInventoryDetailFromOrderDetail(Guid orderID, out string message)
        {
            //Log.Warning("客户端开始调用GetOutInventoryDetailFromOrderDetail");
            message = string.Empty;
            try
            {
                return HandlerFactory.OutInventoryBusinessHandler.GetOutInventoryDetailFromOrderDetail(orderID);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<OutInventoryDetail>>("服务调用业务逻辑方法：GetOutInventoryDetailFromOrderDetail", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }

        #endregion

        #region 设置重点药品记录表(SetSpeicalDrugRecordBusinessHandler)的自定义逻辑


        public void CreateSetSpeicalDrugRecords(SetSpeicalDrugRecord item, out string message)
        {
            //Log.Warning("客户端开始调用CreateSetSpeicalDrugRecords");
            message = string.Empty;
            try
            {
                HandlerFactory.SetSpeicalDrugRecordBusinessHandler.CreateSetSpeicalDrugRecords(item);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：CreateSetSpeicalDrugRecords", ex);
            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<SetSpeicalDrugRecord> GetSetSpeicalDrugRecords(out string message)
        {
            //Log.Warning("客户端开始调用GetSetSpeicalDrugRecords");
            message = string.Empty;
            try
            {
                return HandlerFactory.SetSpeicalDrugRecordBusinessHandler.GetSetSpeicalDrugRecords();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<SetSpeicalDrugRecord>>("服务调用业务逻辑方法：GetSetSpeicalDrugRecords", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

        #endregion

        #region 特殊管理药物类型(SpecialDrugCategoryBusinessHandler)的自定义逻辑

        #endregion

        #region 门店(StoreBusinessHandler)的自定义逻辑

        #endregion

        #region 供货单位(SupplyUnitBusinessHandler)的自定义逻辑


        public List<String> GetBusinessScopeCodesBySupplyUnitGuid(Guid supplyUnitGuid, out string message)
        {
            //Log.Warning("客户端开始调用GetBusinessScopeCodesBySupplyUnitGuid");
            message = string.Empty;
            try
            {
                return HandlerFactory.SupplyUnitBusinessHandler.GetBusinessScopeCodesBySupplyUnitGuid(supplyUnitGuid);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<String>>("服务调用业务逻辑方法：GetBusinessScopeCodesBySupplyUnitGuid", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<String> GetBusinessScopeCodesBySupplyUnit(SupplyUnit supplyUnit, out string message)
        {
            //Log.Warning("客户端开始调用GetBusinessScopeCodesBySupplyUnit");
            message = string.Empty;
            try
            {
                return HandlerFactory.SupplyUnitBusinessHandler.GetBusinessScopeCodesBySupplyUnit(supplyUnit);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<String>>("服务调用业务逻辑方法：GetBusinessScopeCodesBySupplyUnit", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<String> GetManageCategoryDetailBySupplyUnitGuid(Guid supplyUnitGuid, out string message)
        {
            //Log.Warning("客户端开始调用GetManageCategoryDetailBySupplyUnitGuid");
            message = string.Empty;
            try
            {
                return HandlerFactory.SupplyUnitBusinessHandler.GetManageCategoryDetailBySupplyUnitGuid(supplyUnitGuid);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<String>>("服务调用业务逻辑方法：GetManageCategoryDetailBySupplyUnitGuid", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<String> GetManageCategoryDetailBySupplyUnit(SupplyUnit supplyUnit, out string message)
        {
            //Log.Warning("客户端开始调用GetManageCategoryDetailBySupplyUnit");
            message = string.Empty;
            try
            {
                return HandlerFactory.SupplyUnitBusinessHandler.GetManageCategoryDetailBySupplyUnit(supplyUnit);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<String>>("服务调用业务逻辑方法：GetManageCategoryDetailBySupplyUnit", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public SupplyUnit GetSupplyUnitByFlowID(Guid flowId, out string message)
        {
            //Log.Warning("客户端开始调用GetSupplyUnitByFlowID");
            message = string.Empty;
            try
            {
                return HandlerFactory.SupplyUnitBusinessHandler.GetSupplyUnitByFlowID(flowId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<SupplyUnit>("服务调用业务逻辑方法：GetSupplyUnitByFlowID", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void AddSupplyUnitApproveFlow(SupplyUnit su, Guid approvalFlowTypeID, Guid userID, String changeNote, out string message)
        {
            //Log.Warning("客户端开始调用AddSupplyUnitApproveFlow");
            message = string.Empty;
            try
            {
                HandlerFactory.SupplyUnitBusinessHandler.AddSupplyUnitApproveFlow(su, approvalFlowTypeID, userID, changeNote);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：AddSupplyUnitApproveFlow", ex);
            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public void ModifySupplyUnitApproveFlow(SupplyUnit su, Guid approvalFlowTypeID, Guid userID, String changeNote, out string message)
        {
            //Log.Warning("客户端开始调用ModifySupplyUnitApproveFlow");
            message = string.Empty;
            try
            {
                HandlerFactory.SupplyUnitBusinessHandler.ModifySupplyUnitApproveFlow(su, approvalFlowTypeID, userID, changeNote);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：ModifySupplyUnitApproveFlow", ex);
            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<SupplyUnit> GetSupplyUnitForSupplyUnitSelector(Guid drugGuid, String name, String pinyin, String[] jyfwcode, out string message)
        {
            //Log.Warning("客户端开始调用GetSupplyUnitForSupplyUnitSelector");
            message = string.Empty;
            try
            {
                return HandlerFactory.SupplyUnitBusinessHandler.GetSupplyUnitForSupplyUnitSelector(drugGuid, name, pinyin, jyfwcode);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<SupplyUnit>>("服务调用业务逻辑方法：GetSupplyUnitForSupplyUnitSelector", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public bool IsExistSupplyUnitByName(String name, out string message)
        {
            //Log.Warning("客户端开始调用IsExistSupplyUnitByName");
            message = string.Empty;
            try
            {
                return HandlerFactory.SupplyUnitBusinessHandler.IsExistSupplyUnitByName(name);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<bool>("服务调用业务逻辑方法：IsExistSupplyUnitByName", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public SupplyUnit GetSupplyUnitByName(String name, out string message)
        {
            //Log.Warning("客户端开始调用GetSupplyUnitByName");
            message = string.Empty;
            try
            {
                return HandlerFactory.SupplyUnitBusinessHandler.GetSupplyUnitByName(name);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<SupplyUnit>("服务调用业务逻辑方法：GetSupplyUnitByName", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public bool UpdateSupplyUnitByName(String name, SupplyUnit item, out string message)
        {
            //Log.Warning("客户端开始调用UpdateSupplyUnitByName");
            message = string.Empty;
            try
            {
                return HandlerFactory.SupplyUnitBusinessHandler.UpdateSupplyUnitByName(name, item);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<bool>("服务调用业务逻辑方法：UpdateSupplyUnitByName", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public List<SupplyUnit> GetLockSupplyUnitUnit(out string message)
        {
            //Log.Warning("客户端开始调用GetLockSupplyUnitUnit");
            message = string.Empty;
            try
            {
                return HandlerFactory.SupplyUnitBusinessHandler.GetLockSupplyUnitUnit();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<SupplyUnit>>("服务调用业务逻辑方法：GetLockSupplyUnitUnit", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public IEnumerable<SupplyUnit> GetPagedLockSupplyUnitUnit(out PagerInfo pager, int pageindex, int pageSize, out string message)
        {
            //Log.Warning("客户端开始调用GetPagedLockSupplyUnitUnit");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.SupplyUnitBusinessHandler.GetPagedLockSupplyUnitUnit(out pager, pageindex, pageSize);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<SupplyUnit>>("服务调用业务逻辑方法：GetPagedLockSupplyUnitUnit", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public int GetLockSupplyUnitCount(out string message)
        {
            //Log.Warning("客户端开始调用GetLockSupplyUnitCount");
            message = string.Empty;
            try
            {
                return HandlerFactory.SupplyUnitBusinessHandler.GetLockSupplyUnitCount();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<int>("服务调用业务逻辑方法：GetLockSupplyUnitCount", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

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


        public IEnumerable<User> GetAllUsers(out string message)
        {
            //Log.Warning("客户端开始调用GetAllUsers");
            message = string.Empty;
            try
            {
                return HandlerFactory.UserBusinessHandler.GetAllUsers();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<User>>("服务调用业务逻辑方法：GetAllUsers", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public IEnumerable<User> GetUserInfo(String Account, out string message)
        {
            //Log.Warning("客户端开始调用GetUserInfo");
            message = string.Empty;
            try
            {
                return HandlerFactory.UserBusinessHandler.GetUserInfo(Account);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<IEnumerable<User>>("服务调用业务逻辑方法：GetUserInfo", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public User UserLogon(String account, String pwd, out string message)
        {
            //Log.Warning("客户端开始调用UserLogon");
            message = string.Empty;
            try
            {
                return HandlerFactory.UserBusinessHandler.UserLogon(account, pwd);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<User>("服务调用业务逻辑方法：UserLogon", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public String UserLogout(Guid userId, out string message)
        {
            //Log.Warning("客户端开始调用UserLogout");
            message = string.Empty;
            try
            {
                return HandlerFactory.UserBusinessHandler.UserLogout(userId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<String>("服务调用业务逻辑方法：UserLogout", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }


        public Employee GetEmployeeByUserId(Guid userId, out string message)
        {
            //Log.Warning("客户端开始调用GetEmployeeByUserId");
            message = string.Empty;
            try
            {
                return HandlerFactory.UserBusinessHandler.GetEmployeeByUserId(userId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<Employee>("服务调用业务逻辑方法：GetEmployeeByUserId", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

        #endregion

        #region 用户日志(UserLogBusinessHandler)的自定义逻辑


        public void LogUserLog(UserLog log, out string message)
        {
            //Log.Warning("客户端开始调用LogUserLog");
            message = string.Empty;
            try
            {
                HandlerFactory.UserLogBusinessHandler.LogUserLog(log);
            }
            catch (Exception ex)
            {
                message = ex.Message; this.HandleException("服务调用业务逻辑方法：LogUserLog", ex);
            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
            }
        }

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

        #region 药品不合格
        public List<Business.Models.drugsUnqualificationQuery> GetDrugsUnqualification(out string message, Guid UID)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugsUnqualificationHandler.GetDrugsUnqualificationQuery(UID);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<Business.Models.drugsUnqualificationQuery>>("服务调用业务逻辑方法：GetDrugMaintainRecordByCondition", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetDrugsUnqualificationQuery");
                this.Dispose();
            }
        }

        public drugsUnqualication GetDrugsUnqualificationByID(Guid ItemID, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugsUnqualificationHandler.GetDrugsUnqualificationByID(ItemID);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<drugsUnqualication>("服务调用业务逻辑方法：GetDrugsUnqualificationByID", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetDrugsUnqualificationByID");
                this.Dispose();
            }
        }
        public List<drugsUnqualication> GetDrugsUnqualificationByCondition(drugsUnqualificationCondition Condition, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugsUnqualificationHandler.GetDrugsUnqualificationByCondition(Condition);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<drugsUnqualication>>("服务调用业务逻辑方法：GetDrugsUnqualificationByCondition", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用GetDrugsUnqualificationByID");
                this.Dispose();
            }
        }

        public bool addDrugsUnqualityApproval(drugsUnqualication value, Guid approvalFlowTypeID, Guid userID, string changeNote, out string message)
        {
            //Log.Warning("客户端开始调用StorageQuery");
            message = string.Empty;
            try
            {
                HandlerFactory.DrugsUnqualificationHandler.addDrugsUnqualityApproval(value, approvalFlowTypeID, userID, changeNote);
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }

        public bool EditDrugUnqualification(Models.drugsUnqualication du, int flag,out string message)
        {
            message = string.Empty;
            try
            {
                HandlerFactory.DrugsUnqualificationHandler.EditDrugUnqualification(du,flag);
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;

            }
            finally
            {
                //Log.Warning("客户端结束调用EditDrugUnqualification");
                this.Dispose();
            }
        }

        public Business.Models.drugsUnqualificationQuery getDrugsUnqualificationQueryByFlowID(Guid FlowID, out string message)
        {
            //Log.Warning("客户端开始调用StorageQuery");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugsUnqualificationHandler.getDrugsUnqualificationQueryByFlowID(FlowID);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;

            }
            finally
            {
                //Log.Warning("客户端结束调用GetApproveFlowsInfo");
                this.Dispose();
            }
        }

        #endregion

        #region 获取salesman实体方法
        public List<Models.SupplyUnitSalesman> GetSalesManBySupplyUnitID(Guid SupplyUnitID, out string message)
        {
            //Log.Warning("客户端开始调用GetSalesManBySupplyUnitID");
            message = string.Empty;
            try
            {
                return HandlerFactory.SupplyUnitSalesmanBusinessHandler.GetSalesManBySupplyUnitID(SupplyUnitID);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用GetSalesManBySupplyUnitID");
            }
        }
        #endregion

        #region 不合格药品销毁实体查询方法 2014-2-11
        public DrugsUnqualificationDestroy[] getDrugsUnqualificationDestroysByCondition(DateTime dtFrom, DateTime dtTo, string keyword, out string msg)
        {
            //Log.Warning("客户端开始调用getDrugsUnqualificationDestroysByCondition");
            msg = string.Empty;
            try
            {
                return HandlerFactory.DrugsUnqualificationDestroyHandler.getDrugsUnqualificationDestroysByCondition(dtFrom, dtTo, keyword);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return null;

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用getDrugsUnqualificationDestroysByCondition");
            }
        }
        #endregion
        #region 待处理信息查询 2014-3-10
        public DrugsUndeterminate[] GetDrugsUndeterminate(int state, string source, string keyword, out string msg)
        {
            msg = string.Empty;
            try
            {
                return HandlerFactory.DrugsUndeterminateHandler.AllDrugsUndeterminate(state, source, keyword);
            }
            catch (Exception ex)
            {
                msg = "调用不合格药品处理逻辑:查询实体(待处理信息)失败";
                return null;
            }
            finally
            {
                this.Dispose();
            }
        }

        public bool SaveToNextProc(DrugsUndeterminate value, Guid userID, out string msg)
        {
            msg = string.Empty;
            try
            {
                return HandlerFactory.DrugsUndeterminateHandler.SaveToNextProc(value, userID);
            }
            catch (Exception ex)
            {
                msg = "调用不合格药品处理逻辑:查询实体(待处理信息)失败";
                return false;
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 拒收单处理实现
        public DocumentRefuse[] QueryRefuseDocument(string source, int proc, string keyword, out string msg)
        {
            msg = string.Empty;
            try
            {
                return HandlerFactory.DocumentRefuseHandler.QueryRefuseDocument(source, proc, keyword, out msg);
            }
            catch (Exception ex)
            {
                msg = "调用拒收单处理逻辑:查询实体(待处理信息)失败";
                return null;
            }
            finally
            {
                this.Dispose();
            }
        }
        public bool RefuseNextProc(DocumentRefuse value,Guid UserID, out string msg)
        {
            msg = string.Empty;
            try
            {
                return HandlerFactory.DocumentRefuseHandler.RefuseNextProc(value, UserID,out msg);
            }
            catch (Exception ex)
            {
                msg = "调用拒收单处理逻辑:实体(更新)失败";
                return false;
            }
            finally
            {
                this.Dispose();
            }
        }

        #endregion

        //健康，培训关键字查询处理逻辑
        public List<HealthCheckDocument> SearchPagedHealthCheckDocumentByAllStrings(String keys, int index, int size, out PagerInfo pager, out string message)
        {
            //Log.Warning("客户端开始调用SearchPagedHealthCheckDocumentByAllStrings");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.HealthCheckDocumentHandler.SearchPagedHealthCheckDocumentByAllStrings(keys, index, size, out pager);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<HealthCheckDocument>>("服务调用业务逻辑方法：SearchPagedHealthCheckDocumentByAllStrings", ex);

            }
            finally
            {
                this.Dispose();
            }
        }

        public List<HealthCheckDetail> SearchPagedHealthCheckDetailByAllStrings(String keys, int index, int size, out PagerInfo pager, out string message)
        {
            //Log.Warning("客户端开始调用SearchPagedHealthCheckDetailByAllStrings");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.HealthCheckDetailHandler.SearchPagedHealthCheckDetailByAllStrings(keys, index, size, out pager);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<HealthCheckDetail>>("服务调用业务逻辑方法：SearchPagedHealthCheckDetailByAllStrings", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用SearchPagedHealthCheckDocumentByAllStrings");
            }
        }

        public List<EduDocument> SearchPagedEduDocumentByAllStrings(String keys, int index, int size, out PagerInfo pager, out string message)
        {
            //Log.Warning("客户端开始调用SearchPagedEduDocumentByAllStrings");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.EduDocumentHandler.SearchPagedEduDocumentByAllStrings(keys, index, size, out pager);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<EduDocument>>("服务调用业务逻辑方法：SearchPagedEduDocumentByAllStrings", ex);

            }
            finally
            {
                this.Dispose();
                //Log.Warning("客户端结束调用SearchPagedHealthCheckDocumentByAllStrings");
            }
        }

        public List<EduDetails> SearchPagedEduDetailsByAllStrings(String keys, int index, int size, out PagerInfo pager, out string message)
        {
            //Log.Warning("客户端开始调用SearchPagedEduDetailsByAllStrings");
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.EduDetailslHandler.SearchPagedEduDetailsByAllStrings(keys, index, size, out pager);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return this.HandleException<List<EduDetails>>("服务调用业务逻辑方法：SearchPagedEduDetailsByAllStrings", ex);

            }
            finally
            {
                //Log.Warning("客户端结束调用SearchPagedHealthCheckDocumentByAllStrings");
                this.Dispose();
            }
        }


        #region  报损
        public bool AddDrugsBreakageByFlowID(Models.DrugsBreakage value, Guid flowTypeID, string changeNote, out string message)
        {
            //Log.Warning("客户端开始调用SearchPagedEduDetailsByAllStrings");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugsBreakageBusinessHandler.AddDrugsBreakageByFlowID(value,flowTypeID,changeNote);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
            finally
            {
                //Log.Warning("客户端结束调用SearchPagedHealthCheckDocumentByAllStrings");
                this.Dispose();
            }
        }

        public DrugsBreakage GetDrugsBreakageByFlowID(Guid flowID, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugsBreakageBusinessHandler.GetDrugsBreakageByFlowID(flowID);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;
            }
            finally
            {
                //Log.Warning("客户端结束调用SearchPagedHealthCheckDocumentByAllStrings");
                this.Dispose();
            }
        }
        #endregion

        #region 移库
        public bool AddDrugsInventoryMoveByFlowID(Models.DrugsInventoryMove value, Guid flowTypeID, string changeNote, out string message)
        {
            //Log.Warning("客户端开始调用SearchPagedEduDetailsByAllStrings");
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugsInventoryMoveBusinessHandler.AddDrugsInventoryMoveByFlowID(value, flowTypeID, changeNote);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
            finally
            {
                //Log.Warning("客户端结束调用SearchPagedHealthCheckDocumentByAllStrings");
                this.Dispose();
            }
        }

        public DrugsInventoryMove GetDrugsInventoryMoveByFlowID(Guid flowID, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugsInventoryMoveBusinessHandler.GetDrugsInventoryMoveByFlowID(flowID);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;
            }
            finally
            {
                //Log.Warning("客户端结束调用SearchPagedHealthCheckDocumentByAllStrings");
                this.Dispose();
            }
        }

        #endregion


        #region 采购定单申请退货列表
        public ReturnPurchaseOrderList[] GetInventeryOrderListByReturn(string keyword, string supplyUnitName , string DrugName, string Batch, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseInInventeryOrderBusinessHandler.GetInventeryOrderListByReturn(keyword,supplyUnitName, DrugName,Batch);
            }
            catch (Exception ex)
            {
                message = "获取采购定单申请退货列表";
                return null;
            }
            finally
            {
                //Log.Warning("客户端结束调用SearchPagedHealthCheckDocumentByAllStrings");
                this.Dispose();
            }
        }

        public PurchaseOrderReturnDetailEntity[] getPurchaseInventoryDetatilEntity(Guid id, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseInInventeryOrderBusinessHandler.getPurchaseInventoryDetatilEntity(id);
            }
            catch (Exception ex)
            {
                message = "获取采购定单申请退货列表";
                return null;
            }
            finally
            {
                //Log.Warning("客户端结束调用SearchPagedHealthCheckDocumentByAllStrings");
                this.Dispose();
            }
        }

        #endregion

        #region 根据购货商id获取销售单列表
        public SalesOrder[] GetSaleOrderByPurchaseUnitID(Guid id, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.GetSaleOrderByPurchaseUnitID(id);
            }
            catch (Exception ex)
            {
                message = "根据购货商id获取销售单列表失败！";
                return null;
            }
            finally
            {
                //Log.Warning("客户端结束调用SearchPagedHealthCheckDocumentByAllStrings");
                this.Dispose();
            }
        }
        #endregion

        #region 养护细节、待处理药品列表存储过程
        public bool SaveDrugMaintainDetailAndUndeterminate(Models.DrugMaintainRecordDetail[] dmrds, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugMaintainRecordDetailBusinessHandler.SaveDrugMaintainDetailAndUndeterminate(dmrds);
            }
            catch (Exception ex)
            {
                message = "养护细节、待处理药品列表存储过程失败！\n"+ex.Message;
                return false;
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 获取销售退货单统计
        public Dictionary<int, decimal> GetSalesReturnSummary(SalesOrder[] so, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderReturnBusinessHandler.GetSalesReturnSummary(so);
            }
            catch (Exception ex)
            {
                message = "获取销售退货单统计过程失败！";
                return null;
            }
            finally
            {
                this.Dispose();
            }
        }
        public SalesOrderReturn[] GetSalesOrderReturnByCreateTime(DateTime dtFrom, DateTime dtTo,out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderReturnBusinessHandler.GetSalesOrderReturnByCreateTime(dtFrom,dtTo);
            }
            catch (Exception ex)
            {
                message = "根据销退单创建日期获取销售退货单统计过程失败！";
                return null;
            }
            finally
            {
                this.Dispose();
            }
        }

        #endregion

        #region 冲差价单处理方法        
        public bool SubmitRefunds(PurchasingPlan[] pps, int flag, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchasingPlanBusinessHandler.SubmitRefunds(pps,flag);
            }
            catch (Exception ex)
            {
                message = "根据冲差价单过程失败！";
                return false;
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 获取冲差价单        
        public IEnumerable<PurchasingPlan> GetPurchaseRefunds(object[] objs, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchasingPlanBusinessHandler.GetPurchaseRefunds(objs);
            }
            catch (Exception ex)
            {
                message = "根据冲差价单过程失败！";
                return this.HandleException<IEnumerable<PurchasingPlan>>("服务调用业务逻辑方法：GetPurchaseRefunds", ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 采退配送
        public bool SaveDeliveryByPurchaseReturn(Models.PurchaseOrderReturn por, System.Guid createUid,out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.OutInventoryBusinessHandler.SaveDeliveryByPurchaseReturn(por,createUid);
            }
            catch (Exception ex)
            {
                message = "采退配送保存失败！";
                return false;
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 药品流向
        public List<Business.Models.DrugPath> GetDrugPath(Business.Models.QueryModelForDrugPath m, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.GetDrugPath(m);
            }
            catch (Exception ex)
            {
                message = "药品供货商获取失败！";
                return this.HandleException<List<Business.Models.DrugPath>>("服务调用业务逻辑方法：GetDrugPath", ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 采购开票时获取供货商
        public System.Collections.Generic.List<HistoryPurchase> GetPurchaseHistoryByInInventoryPurchaseID(System.Guid id,int type, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseHistoryByInInventoryPurchaseID(id, type); 
            }
            catch (Exception ex)
            {
                message = "药品供货商获取失败！";
                return this.HandleException<List<Business.Models.HistoryPurchase>>("服务调用业务逻辑方法：GetPurchaseHistoryByInInventoryPurchaseID", ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region
        public IEnumerable<DrugInventoryRecord> GetDrugInventoryRecordPL(string kw, int type,out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInventoryRecordBusinessHandler.GetDrugInventoryRecordPL(kw, type);
            }
            catch (Exception ex)
            {
                message = "药品供货商获取失败！";
                return this.HandleException<IEnumerable<Models.DrugInventoryRecord>>("服务调用业务逻辑方法：GetDrugInventoryRecordPL", ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 库存近效期读取
        public IEnumerable<BugsBox.Pharmacy.Business.Models.DrugInventoryNearExpiration> GetDrugInventoryRecordNearExpirationDate(int Month, string keyword, int MaintainType, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInventoryRecordBusinessHandler.GetDrugInventoryRecordNearExpirationDate(Month, keyword, MaintainType);
            }
            catch (Exception ex)
            {
                message = "库存近效期读取失败！";
                return this.HandleException<IEnumerable<BugsBox.Pharmacy.Business.Models.DrugInventoryNearExpiration>>("服务调用业务逻辑方法：GetDrugInventoryRecordNearExpirationDate", ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 日志信息
        public void WriteLog(Guid Uid, string Content)
        {
            try
            {
                HandlerFactory.UserLogBusinessHandler.WriteLog(Uid, Content);
            }
            catch (Exception e)
            {
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion


        #region 移库记录查询
        public System.Collections.Generic.IEnumerable<Business.Models.DrugsInventoryMoveRecordModel> GetMoveRecords(Models.DrugsInventoryMove dm, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugsInventoryMoveBusinessHandler.GetMoveRecords(dm);
            }
            catch (Exception ex)
            {
                message = "库存近效期读取失败！";
                return this.HandleException<IEnumerable<BugsBox.Pharmacy.Business.Models.DrugsInventoryMoveRecordModel>>("服务调用业务逻辑方法：DrugsInventoryMoveRecordModel", ex);
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 采购税票查询
        public System.Collections.Generic.IEnumerable<Business.Models.PurchaseTaxReturn> GetPurchaseTaxReturn(System.Guid SuId, DateTime dtF, DateTime dtT, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseTaxReturn(SuId,dtF,dtT);
            }
            catch (Exception ex)
            {
                message = "采购税票查询失败！";
                return this.HandleException<IEnumerable<Business.Models.PurchaseTaxReturn>>("服务调用业务逻辑方法：GetPurchaseTaxReturn", ex);
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 采购单合并
        public bool SavePurchaseOrdersByPurchaseTaxReturn(Business.Models.PurchaseTaxReturn[] list, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.SavePurchaseOrdersByPurchaseTaxReturn(list);
            }
            catch (Exception ex)
            {
                message = "采购单合并失败！";
                return false;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 销售税率查询
        public System.Collections.Generic.IEnumerable<Business.Models.SalesTaxRate> GetSalesTaxRate(System.Guid Pid, System.Guid Uid, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.GetSalesTaxRate(Pid, Uid);
            }
            catch (Exception ex)
            {
                message = "销售税率查询失败！";
                return this.HandleException<IEnumerable<Business.Models.SalesTaxRate>>("服务调用业务逻辑方法：GetSalesTaxRate", ex);
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 销售税费查询
        public IEnumerable<Business.Models.SalerTaxManage> GetSalerTaxManage(System.DateTime dtF, System.DateTime DtT, Guid purchaseUnitId, string SalerName, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.GetSalerTaxManage(dtF,DtT,purchaseUnitId,SalerName);
            }
            catch (Exception ex)
            {
                message = "销售税费查询失败！";
                return this.HandleException<IEnumerable<Business.Models.SalerTaxManage>>("服务调用业务逻辑方法：GetSalerTaxManage", ex);
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 销售税费保存
        public bool SaveSaleOrderTaxRate(List<Business.Models.SalerTaxManage> ListST, int locker, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.SaveSaleOrderTaxRate(ListST,locker);
            }
            catch (Exception ex)
            {
                message = "保存销售税费失败！";
                return false;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 税费综合查询
        public IEnumerable<Business.Models.AllTax> GetAllTax(System.DateTime dtF, System.DateTime dtT, Guid salerID, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.UserBusinessHandler.GetAllTax(dtF, dtT, salerID);
            }
            catch (Exception ex)
            {
                message = "税费综合查询失败!";
                return null;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 车辆审批新增
        public bool AddVehicleToApprovalByFlowID(Models.Vehicle value, System.Guid flowTypeID, string ChangeNote,out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.VehicleBusinessHandler.AddVehicleToApprovalByFlowID(value, flowTypeID, ChangeNote);
            }
            catch (Exception ex)
            {
                message = "车辆审批新增失败!";
                return false;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 从审批ID获取车辆信息        
        public Vehicle GetVehicleByFlowID(System.Guid flowId, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.VehicleBusinessHandler.GetVehicleByFlowID(flowId);
            }
            catch (Exception ex)
            {
                message = "车辆审批新增失败!";
                return null;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 采购退货查询
        public System.Collections.Generic.IEnumerable<Business.Models.PurchaseOrderReturnModel> GetPReturnOrderByQureyModel(Business.Models.PurchaseOrderReturnQueryModel q, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetPReturnOrderByQureyModel(q);
            }
            catch (Exception ex)
            {
                message = "采购退货查询!";
                return null;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 销售历史冲差单查询
        public IEnumerable<Business.Models.SaleOrderModel> GetSaleRefundHistory(Business.Models.SalesCodeSearchInput searchInput, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.GetSaleRefundHistory(searchInput);
            }
            catch (Exception ex)
            {
                message = "销售历史冲差单查询失败!";
                return null;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 保存冲差单
        public bool SaveSaleRefund(SalesOrder so, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.SaveSaleRefund(so);
            }
            catch (Exception ex)
            {
                message = "保存销售冲差失败！";
                return false;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 获取出库复核特殊药品信息
        public System.Collections.Generic.IEnumerable<Business.Models.OutInventoryMode> GetOutInventorySpecialDrugs(Models.OutInventory outInve, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.OutInventoryBusinessHandler.GetOutInventorySpecialDrugs(outInve);
            }
            catch (Exception ex)
            {
                message = "获取出库复核特殊药品信息失败！";
                return null;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 分页药品基础信息
        public System.Collections.Generic.IEnumerable<Business.Models.DrugInfoModel> GetDrugInfoByCondition(string keys, int index, int size, out PagerInfo pager, bool ValidCondition, out string message)
        {
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.GetDrugInfoByCondition(keys, index, size, out pager, ValidCondition);
            }
            catch (Exception ex)
            {
                message = "获取分页药品基础信息失败！";
                return null;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 根据供应商查询供货药品
        public System.Collections.Generic.IEnumerable<Business.Models.SupplyUnitHistoryDrugList> GetSupplyUnitHistoryDrugList(string Keyword, string DrugName, Guid SUId, DateTime dtf, DateTime dtt, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.GetSupplyUnitHistoryDrugList(Keyword,DrugName, SUId, dtf, dtt);
            }
            catch (Exception ex)
            {
                message = "获取供应商查询供货药品信息失败！";
                return null;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 采购退货取消
        public bool CancelPurchaseReturnOrder(System.Guid PurchaseReturnOrderId, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseOrderBusinessHandler.CancelPurchaseReturnOrder(PurchaseReturnOrderId);
            }
            catch (Exception ex)
            {
                message = "采购退货取消失败！";
                return false;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 获取服务器信息
        public Business.Models.ServerInfo GetServerInfo(out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.UserLogBusinessHandler.GetServerInfo();
            }
            catch (Exception ex)
            {                
                return null;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 获取服务器更新文件
        public System.Collections.Generic.IEnumerable<Business.Models.UpdateFiles> GetUpdateFiles(string FileName)
        {
            try
            {
                return HandlerFactory.UserLogBusinessHandler.GetUpdateFiles(FileName);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 获取角色权限分配表
        public System.Collections.Generic.IEnumerable<Business.Models.RoleWithModuleModel> GetRolewithModule()
        {
            try
            {
                return HandlerFactory.RoleWithUserBusinessHandler.GetRolewithModule();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 获取用户权限分配表
        public System.Collections.Generic.IEnumerable<Business.Models.RoleWithUserModel> GetRolewithUser()
        {
            try
            {
                return HandlerFactory.RoleWithUserBusinessHandler.GetRolewithUser();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 通过销售细节获取库存记录
        public System.Collections.Generic.IEnumerable<DrugInventoryRecord> GetDrugInventoryRecordBySalesOrderId(Guid SoId, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInventoryRecordBusinessHandler.GetDrugInventoryRecordBySalesOrderId(SoId);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 分经营范围获取品种数量
        public int GetDrugInfoCount(string BusinessScopeType)
        {
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.GetDrugInfoCount(BusinessScopeType);
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 根据用户岗位返回用户
        public System.Collections.Generic.IEnumerable<User> GetUserByPosition(string roleName, string account, string pwd)
        {
            try
            {
                return HandlerFactory.UserBusinessHandler.GetUserByPosition(roleName, account, pwd);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally { this.Dispose(); }
        }
        #endregion

        #region 最近采购记录细节
        public Models.PurchaseInInventeryOrderDetail[] GetLastInInventoryDetail(System.Guid[] DrugInfoIds)
        {
            try
            {
                return HandlerFactory.PurchaseInInventeryOrderBusinessHandler.GetLastInInventoryDetail(DrugInfoIds);
            }
            catch
            {
                return null;
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 查询配送单
        public System.Collections.Generic.IEnumerable<Business.Models.DeliveryTrasactionModel> GetDeliveryTransactionPaged(Business.Models.DeliveryIndexInput deliveryIndexInput, out BugsBox.Application.Core.PagerInfo pager, int pageindex, int pageSize)
        {
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.DeliveryBusinessHandler.GetDeliveryTransactionPaged(deliveryIndexInput,out pager, pageindex, pageSize);
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 新增直调销售表（事务）
        public bool AddDirectSalesOrderAndDetail(Models.DirectSalesOrder dso, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DirectSalesOrderBusinessHandler.AddDirectSalesOrderAndDetail(dso);
            }
            catch (Exception ex)
            {
                message = "调用新增销售表（事务）失败";
                return this.HandleException<bool>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 根据关键字查找客户
        public Models.PurchaseUnit[] GetPurchaseUnitsByKeywords(string keyword, bool isAccurate, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseUnitBusinessHandler.GetPurchaseUnitsByKeywords(keyword, isAccurate);
            }
            catch (Exception ex)
            {
                message = "调用根据关键字查找供货商失败";
                return this.HandleException<Models.PurchaseUnit[]>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 根据关键字查找供货商
        public Models.SupplyUnit[] GetSupplyUnitsByKeywords(string Keyword, bool IsAccurate, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.SupplyUnitBusinessHandler.GetSupplyUnitsByKeywords(Keyword, IsAccurate);
            }
            catch (Exception ex)
            {
                message = "调用根据关键字查找供货商失败";
                return this.HandleException<Models.SupplyUnit[]>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 直调药品选择
        public Models.DrugInfo[] GetDrugInfoByKeyword(Business.Models.DirectSalesQueryModel m, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.GetDrugInfoByKeyword(m);
            }
            catch (Exception ex)
            {
                message = "调用直调药品选择失败";
                return this.HandleException<Models.DrugInfo[]>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 根据审核状态获取销售直调单据
        public Business.Models.DirectSalesModel[] GetDirectSalesModelByApprovalStatus(Business.Models.DirectSalesQueryModel dsq, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DirectSalesOrderBusinessHandler.GetDirectSalesModelByApprovalStatus(dsq);
            }
            catch (Exception ex)
            {
                message = "调用根据审核状态获取销售直调单据失败";
                return this.HandleException<Business.Models.DirectSalesModel[]>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 根据直调单ID获取直调细节信息
        public System.Collections.Generic.IEnumerable<DirectSalesOrderDetailModel> GetDirectSalesOrderDetailModelByDirectSalesModel(System.Guid DirectSalesId, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DirectSalesOrderBusinessHandler.GetDirectSalesOrderDetailModelByDirectSalesModel(DirectSalesId);
            }
            catch (Exception ex)
            {
                message = "调用根据直调单ID获取直调细节信息失败";
                return this.HandleException<System.Collections.Generic.IEnumerable<DirectSalesOrderDetailModel>>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion
        
        #region 修改直调销售表
        public bool SaveDirectSalesOrderAndDetail(Models.DirectSalesOrder dso, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DirectSalesOrderBusinessHandler.SaveDirectSalesOrderAndDetail(dso);
            }
            catch (Exception ex)
            {
                message = "调用修改直调销售表失败";
                return this.HandleException<bool>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 增加直调销售审批
        public bool AddDirectSaleApproval(Models.DirectSalesOrder value, System.Guid approvalFlowTypeID, System.Guid userID, string changeNote, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DirectSalesOrderBusinessHandler.AddDirectSaleApproval(value, approvalFlowTypeID, userID, changeNote);
            }
            catch (Exception ex)
            {
                message = "调用增加直调销售审批失败";
                return this.HandleException<bool>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 从FLOWID获取直调销售单
        public Models.DirectSalesOrder GetDirectSalesOrderByFlowId(System.Guid FlowId, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DirectSalesOrderBusinessHandler.GetDirectSalesOrderByFlowId(FlowId);
            }
            catch (Exception ex)
            {
                message = "调用从FLOWID获取直调销售单失败";
                return this.HandleException<Models.DirectSalesOrder>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 根据Business.Models.SalesOrderQueryModelM关键字查询销售单
        public System.Collections.Generic.IEnumerable<Business.Models.SalesOrderModelForSalesOrderReturn> GetSalesOrderByOrderModel(Business.Models.SalesOrderQueryModel m, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.GetSalesOrderByOrderModel(m);
            }
            catch (Exception ex)
            {
                message = "调用根据Business.Models.SalesOrderQueryModelM关键字查询销售单失败";
                return this.HandleException<System.Collections.Generic.IEnumerable<Business.Models.SalesOrderModelForSalesOrderReturn>>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 过期药品不合格查询
        public System.Collections.Generic.IEnumerable<Business.Models.InventeryModel> GetDrugsInventoryRecordToUnqualification(bool IsOutDate, string DrugPY, string BatchNumber, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInventoryRecordBusinessHandler.GetDrugsInventoryRecordToUnqualification(IsOutDate,DrugPY,BatchNumber);
            }
            catch (Exception ex)
            {
                message = "调用过期药品不合格查询失败";
                return this.HandleException<System.Collections.Generic.IEnumerable<Business.Models.InventeryModel>>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 质量追溯查询
        public System.Collections.Generic.IEnumerable<Business.Models.DrugQualityTraceModel> GetAllDrugUnqualityTrace(Guid DrugInfoId, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.DrugInventoryRecordBusinessHandler.GetAllDrugUnqualityTrace(DrugInfoId);
            }
            catch (Exception ex)
            {
                message = "调用质量追溯查询失败";
                return this.HandleException<System.Collections.Generic.IEnumerable<Business.Models.DrugQualityTraceModel>>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 医疗器械查询
        public IEnumerable<Business.Models.InstrumentsModel> GetInstrumentsByCondition(string keys, int index, int size, out PagerInfo pager, bool ValidCondition)
        {
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.GetInstrumentsByCondition(keys,index,size,out pager,ValidCondition);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 新增货位信息
        public bool AddWareHouseZonePositions(IEnumerable<WareHouseZonePosition> ListWareHouseZonePositions, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.WareHouseZonePostionBusinessHandler.AddWareHouseZonePositions(ListWareHouseZonePositions);
            }
            catch (Exception ex)
            {
                message = "调用新增货位信息失败";
                return this.HandleException<bool>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 修改增货位信息
        public bool SaveWareHouseZonePosition(System.Collections.Generic.IEnumerable<Models.WareHouseZonePosition> ListWareHouseZonePositions, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.WareHouseZonePostionBusinessHandler.SaveWareHouseZonePosition(ListWareHouseZonePositions);
            }
            catch (Exception ex)
            {
                message = "调用修改增货位信息失败";
                return this.HandleException<bool>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 修改货位信息
        public bool DeleteWareHouseZonePostion(System.Collections.Generic.IEnumerable<System.Guid> Ids, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.WareHouseZonePostionBusinessHandler.DeleteWareHouseZonePostion(Ids);
            }
            catch (Exception ex)
            {
                message = "调用修改增货位信息失败";
                return this.HandleException<bool>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 货位信息综合查询
        public IEnumerable<WareHouseZonePositionModel> GetWareHouseZonePositionById(WareHouseZonePositionQueryModel q, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.WareHouseZonePostionBusinessHandler.GetWareHouseZonePositionById(q);
            }
            catch (Exception ex)
            {
                message = "调用货位信息综合查询失败";
                return this.HandleException<IEnumerable<WareHouseZonePositionModel>>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 电子标签点亮显示
        public System.Collections.Generic.IEnumerable<Business.Models.WarehouseZonePositionOutInventoryModel> GetWarehouseZonePositionOutInventories(System.Guid SalesOrderId, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.OutInventoryBusinessHandler.GetWarehouseZonePositionOutInventories(SalesOrderId);
            }
            catch (Exception ex)
            {
                message = "调用电子标签点亮显示失败";
                return this.HandleException<System.Collections.Generic.IEnumerable<Business.Models.WarehouseZonePositionOutInventoryModel>>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 根据ID获取货位记录
        public Models.WareHouseZonePosition GetWarehouseZonePositionById(System.Guid Id, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.WareHouseZonePostionBusinessHandler.GetWarehouseZonePositionById(Id);
            }
            catch (Exception ex)
            {
                message = "调用根据ID获取货位记录失败";
                return this.HandleException<Models.WareHouseZonePosition>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 获得供货企业和销售客户资质的近效期预警信息
        public List<Business.Models.QualityFilesWarningModel> GetQualifyFilesCount(Business.Models.NearExpireDateQualifiedFiles WarningDate, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.UserLogBusinessHandler.GetQualifyFilesCount(WarningDate);
            }
            catch (Exception ex)
            {
                message = "调用获得供货企业和销售客户资质的近效期预警信息失败";
                return this.HandleException<List<Business.Models.QualityFilesWarningModel>>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 重写的日志查询
        public System.Collections.Generic.IEnumerable<Business.Models.UserLogModel> GetPagedUserLogs(Business.Models.QueryBusinessUserLogModel m, out BugsBox.Application.Core.PagerInfo pagerInfo, int PageIndex, int PageSize, out string message)
        {
            message = string.Empty;
            pagerInfo = default(PagerInfo);
            try
            {
                return HandlerFactory.UserLogBusinessHandler.GetPagedUserLogs(m,out pagerInfo, PageIndex, PageSize);
            }
            catch (Exception ex)
            {
                message = "调用重写的日志查询失败";
                return this.HandleException<System.Collections.Generic.IEnumerable<Business.Models.UserLogModel>>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        #endregion


        

        #region 保存销售控制规则
        public bool SaveSalePriceControlRules(SalePriceControlRulesModel m, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.SaveSalePriceControlRules(m);
            }
            catch (Exception ex)
            {
                message = "调用保存销售控制规则失败";
                return this.HandleException<bool>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 获取销售控制规则
        public SalePriceControlRulesModel GetSalePriceControlRules(out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.SalesOrderBusinessHandler.GetSalePriceControlRules();
            }
            catch (Exception ex)
            {
                message = "调用获取销售控制规则失败";
                return this.HandleException<SalePriceControlRulesModel>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 获取客户单位提货人
        public IEnumerable<PurchaseUnitBuyer> GetPurchaseUnitBuyersByPurchaseUnitId(Guid PId, out string message)
        {
            message = string.Empty;
            try
            {
                return HandlerFactory.PurchaseUnitBuyerBusinessHandler.GetPurchaseUnitBuyersByPurchaseUnitId(PId);
            }
            catch (Exception ex)
            {
                message = "调用获取客户单位提货人失败";
                return this.HandleException<IEnumerable<PurchaseUnitBuyer>>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion

        #region 分页获取保健食品
        public System.Collections.Generic.IEnumerable<Business.Models.FoodModel> GetFoodByCondition(string keys, int index, int size, out BugsBox.Application.Core.PagerInfo pager, bool ValidCondition, out string message)
        {
            message = string.Empty;
            pager = default(PagerInfo);
            try
            {
                return HandlerFactory.DrugInfoBusinessHandler.GetFoodByCondition(keys, index, size,out pager, ValidCondition);
            }
            catch (Exception ex)
            {
                message = "调用分页获取保健食品失败";
                return this.HandleException<System.Collections.Generic.IEnumerable<Business.Models.FoodModel>>(message, ex);
            }
            finally
            {
                this.Dispose();
            }
        }
        #endregion
    }
}
