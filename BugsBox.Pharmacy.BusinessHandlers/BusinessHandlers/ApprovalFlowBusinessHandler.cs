using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;
using System.Data.Entity;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class ApprovalFlowBusinessHandler
    {
        protected override IQueryable<ApprovalFlow> IncludeNavigationProperties(IQueryable<ApprovalFlow> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable
               .Include(u => u.ApprovalFlowType)
               );
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错",EntityName), ex);
                return HandleException<IQueryable<ApprovalFlow>>(ex.Message,ex);
            }
           
        }

        /// <summary>
        /// 根据用户ID获取流程集合
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns
        public IEnumerable<ApprovalFlow> GetApproveFlowsByUser(Guid userId)
        {
            try
            {
                List<ApprovalFlow> listApprovalFlow = new List<ApprovalFlow>();
                // 根据用户获取角色
                var roleWithUser =
                    BusinessHandlerFactory.RoleWithUserBusinessHandler.Fetch(
                        r => r.UserId == userId).ToList();

                //根据角色获取节点集合
                if (roleWithUser != null)
                {
                    foreach (var item in roleWithUser)
                    {
                        if (BusinessHandlerFactory.ApprovalFlowNodeBusinessHandler.Exist(e => e.RoleId == item.RoleId))
                        {
                            List<Guid> approveFlowNodeTypeIds = new List<Guid>();
                            approveFlowNodeTypeIds = BusinessHandlerFactory.ApprovalFlowNodeBusinessHandler.Fetch(
                                    p => p.RoleId == item.RoleId).Select(r => r.Id).Distinct().ToList();


                            //根据类型获取流程集合
                            foreach (Guid id in approveFlowNodeTypeIds)
                            {
                                int status = (int)ApprovalStatus.Waitting;
                                listApprovalFlow.AddRange(this.Fetch(r => r.NextNodeID== id && r.Status == status).ToList());
                            }
                        }
                    }
                }
                return listApprovalFlow;
            }
            catch (Exception ex)
            {
                return this.HandleException<IEnumerable<ApprovalFlow>>("根据用户编号获取流程集合失败", ex);
            }
        }

        /// <summary>
        /// 根据用户ID和Type获取流程集合
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns
        public IEnumerable<ApprovalFlow> GetApproveFlowsByUserType(Guid userId, int type)
        {
            try
            {
                var query = from node in BusinessHandlerFactory.RepositoryProvider.Db.ApprovalFlowNodes
                            join role in BusinessHandlerFactory.RepositoryProvider.Db.RoleWithUsers on node.RoleId equals role.Id
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on role.UserId equals u.Id
                            join flow in BusinessHandlerFactory.RepositoryProvider.Db.ApprovalFlows on node.ApprovalFlowTypeId equals flow.ApprovalFlowTypeId
                            join flowtype in BusinessHandlerFactory.RepositoryProvider.Db.ApprovalFlowTypes on flow.ApprovalFlowTypeId equals flowtype.Id
                            where role.UserId == userId && flowtype.ApprovalTypeValue == type
                            select flow;
                return query.ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<IEnumerable<ApprovalFlow>>("根据用户编号获取流程集合失败", ex);
            }
        }
        /// <summary>
        /// GetApproveFlowInstance
        /// </summary>
        /// <param name="flow"></param>
        /// <returns></returns>
        public ApprovalFlow GetApproveFlowInstance(Guid approvalFlowTypeID,Guid flowID, Guid userID, string comment)
        {
            try
            {
                int approveStatus = (int)ApprovalStatus.Waitting;
                ApprovalFlow flow = new ApprovalFlow();
                flow.Id = Guid.NewGuid();
                flow.ApprovalFlowTypeId = approvalFlowTypeID;
                flow.ChangeNote = comment;
                flow.CreateTime = DateTime.Now;
                flow.CreateUserId = userID;
                flow.FlowId = flowID;
                ApprovalFlowNode node = BusinessHandlerFactory.ApprovalFlowNodeBusinessHandler.GetFirstApproveFlowsNode(approvalFlowTypeID);
                if (node != null)
                    flow.NextNodeID = node.Id;
                flow.Status = approveStatus;
                flow.SubFlowId = GetNextSubflowIDByFlowId(flowID);

                return flow;
            }
            catch (Exception ex)
            {
                return this.HandleException<ApprovalFlow>("获取流程结点失败", ex);
            }
        }


        /// <summary>
        /// 根据flowType 和changenote 获取 审批流程集合
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns
        public IEnumerable<ApprovalFlow> GetApproveFlowsInfo(Guid flowTypeId, string changeNote)
        {
            try
            {
                var approvalFlowList = this.Fetch(
                     p => p.ApprovalFlowTypeId == flowTypeId && p.ChangeNote.IndexOf(changeNote) > -1).ToList();

                return approvalFlowList;
            }
            catch (Exception ex)
            {
                return this.HandleException<IEnumerable<ApprovalFlow>>("根据流程以及变化信息获取审批流程的集合失败", ex);
            }
        }


        /// <summary>
        /// 根据Flowid 获取审批流程
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns
        public ApprovalFlow GetApproveFlowsByFlowID(Guid flowId)
        {
            try
            {
                var c = this.Queryable;
                var approvalFlow=c.Where(r=>r.FlowId.Equals(flowId));
                approvalFlow = approvalFlow.OrderBy(r => r.SubFlowId);
                
                return approvalFlow.FirstOrDefault();
            }
            catch (Exception ex)
            { 
               return this.HandleException<ApprovalFlow>("根据流程编号获取审批流程失败", ex);
            }
        }

        //审批详情
        public List<ApprovalDetailsModel> GetApprovalDetails(Guid FlowID, int historyID, List<object> searchConditions)
        {
            try
            {
                List<ApprovalFlowRecord> listApprovalFlowRecord = BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.Fetch(
                           r => r.FlowId == FlowID && r.SubFlowId == historyID).OrderByDescending(p => p.ApproveTime).ToList();

                var queryBuilder = QueryBuilder.Create<ApprovalFlowRecord>()
                .Equals(q => q.FlowId, FlowID)
                .Equals(q => q.SubFlowId, historyID);
                
                var records = BusinessHandlerFactory.RepositoryProvider.Db.ApprovalFlowRecords.Where(queryBuilder.Expression);
                var query = from r in records
                            join f in BusinessHandlerFactory.RepositoryProvider.Db.ApprovalFlows on r.FlowId equals f.FlowId
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on r.ApproveUserId equals u.Id
                            join em in BusinessHandlerFactory.RepositoryProvider.Db.Employees on u.EmployeeId equals em.Id
                            select new ApprovalDetailsModel
                            {
                                ApproveTime = r.ApproveTime,
                                ApproveUserId = r.ApproveUserId,
                                ApproveUserName = em.Name,
                                Comment = r.Comment,
                                Status = f.Status
                            };
                return query.ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<ApprovalDetailsModel>>("根据当前审批流程获得已审批节点记录集合失败", ex);
            }
        }

        /// <summary>
        /// 处理审核流程
        /// </summary>
        /// <param name="flow"></param>
        public void SetApproveAction(ApprovalFlow flow, string action, Guid userID, string comment)
        {
            try
            {
                if (flow.NextNodeID != Guid.Empty)
                {
                    ApprovalFlowType flowType = BusinessHandlerFactory.ApprovalFlowTypeBusinessHandler.Fetch(
                                   f => f.Id == flow.ApprovalFlowTypeId).FirstOrDefault();

                    //准备审批节点记录表,
                    ApprovalFlowRecord record = BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.GetApproveFlowRecordInstance(flow, userID, comment);
                    BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.Add(record);

                    //审批被拒绝
                    if ("REJECT".Equals(action.ToUpper()))
                    {
                        flow.Status = (int)ApprovalStatus.Reject;
                        UpdateEntityByApprovalStatus(flowType.ApprovalTypeValue, flow.FlowId, ApprovalStatus.Reject);
                    }
                    else
                    {
                        //获取当前节点的下一个节点
                        ApprovalFlowNode newNextNode = BusinessHandlerFactory.ApprovalFlowNodeBusinessHandler.GetNextApproveFlowsNode(flowType.Id, flow.NextNodeID);

                        if (newNextNode == null) //审批通过,无下个一节点.审批结束
                        {
                            flow.NextNodeID = Guid.Empty;//审核通过后,下个节点信息保存为空Guid
                            flow.Status = (int)ApprovalStatus.Approvaled;
                            UpdateEntityByApprovalStatus(flowType.ApprovalTypeValue, flow.FlowId, ApprovalStatus.Approvaled);
                        }
                        else //审核通过,更新审核流程的下一个节点信息
                        {
                            flow.NextNodeID = newNextNode.Id;
                            flow.Status = (int)ApprovalStatus.Waitting;
                        }
                    }

                    this.Save(flow);
                    this.Save();
                }
            }
            catch (Exception ex)
            {
                this.HandleException("处理审批流程失败", ex);
            }
        }

        /// <summary>
        /// 根据审核结果更新实体审核信息
        /// 对业务表的操作：审批同意且审批节点流完，需要更新业务表 后者审批拒绝需要更新业务表
        /// </summary>
        /// <param name="flowTypeIndex"></param>
        /// <param name="flowId"></param>
        /// <param name="status"></param>
        private void UpdateEntityByApprovalStatus(int flowTypeIndex, Guid flowId, ApprovalStatus status)
        {
            try
            {
                switch (flowTypeIndex)
                {
                    case (int)ApprovalType.SupplyUnitApproval:
                    case (int)ApprovalType.SupplyUnitEditApproval:
                    case (int)ApprovalType.SupplyUnitLockApproval:
                        SupplyUnit su = new SupplyUnit();
                        su = (SupplyUnit)GetObjectEntityInstance(flowTypeIndex, flowId, status);
                        if (su == null) //测试时可能为NULL
                        {
                            BusinessHandlerFactory.SupplyUnitBusinessHandler.Save(su);
                        }
                        break;
                    case (int)ApprovalType.DrugInfoApproval:
                    case (int)ApprovalType.DrugInfoEditApproval:
                    case (int)ApprovalType.DrugInfoLockApproval:
                        DrugInfo di = new DrugInfo();
                        di = (DrugInfo)GetObjectEntityInstance(flowTypeIndex, flowId, status);
                        if (di == null) //测试时可能为NULL
                        {
                            BusinessHandlerFactory.DrugInfoBusinessHandler.Save(di);
                        }
                        break;
                    case (int)ApprovalType.PurchaseUnitApproval:
                    case (int)ApprovalType.PurchaseUnitEditApproval:
                    case (int)ApprovalType.PurchaseUnitLockApproval:
                        PurchaseUnit pu = new PurchaseUnit();
                        pu = (PurchaseUnit)GetObjectEntityInstance(flowTypeIndex, flowId, status);
                        if (pu == null) //测试时可能为NULL
                        {
                            BusinessHandlerFactory.PurchaseUnitBusinessHandler.Save(pu);
                        }
                        break;
                    case (int)ApprovalType.drugsUnqualityApproval:
                        DrugsUnqualication du = (DrugsUnqualication)GetObjectEntityInstance(flowTypeIndex, flowId, status);
                        BusinessHandlerFactory.DrugsUnqualicationBusinessHandler.Save(du);  
                        break;
                    case (int)ApprovalType.drugsBreakageApproval:
                        DrugsBreakage db = (DrugsBreakage)GetObjectEntityInstance(flowTypeIndex, flowId, status);
                        if (db == null) //测试时可能为NULL
                        {
                            if (status == ApprovalStatus.Reject)
                            {
                                db.Deleted = true;
                                db.DeleteTime = DateTime.Now;
                                db.ApprovalStatus = ApprovalStatus.Reject;
                            }
                            BusinessHandlerFactory.DrugsBreakageBusinessHandler.Save(db);
                        }
                        break;
                    case (int)ApprovalType.drugsInventoryMove:
                        DrugsInventoryMove dim = (DrugsInventoryMove)GetObjectEntityInstance(flowTypeIndex, flowId, status);
                        if (status == ApprovalStatus.Approvaled)
                        {
                            DrugInventoryRecord dir = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(dim.inventoryRecordID);
                            dir.WarehouseZoneId = dim.WareHouseID;
                            BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(dir);
                        }
                        BusinessHandlerFactory.DrugsInventoryMoveBusinessHandler.Save(dim);
                        break;
                    case (int)ApprovalType.VehicleApproval:
                        Vehicle v = (Vehicle)GetObjectEntityInstance(flowTypeIndex, flowId, status);
                        BusinessHandlerFactory.VehicleBusinessHandler.Save(v);
                        break;
                    case (int)ApprovalType.DirectSalesApproval:
                        DirectSalesOrder dso = (Models.DirectSalesOrder)GetObjectEntityInstance(flowTypeIndex, flowId, status);
                        BusinessHandlerFactory.DirectSalesOrderBusinessHandler.Save(dso);
                        break;
                }
            }
            catch (Exception ex)
            {
                this.HandleException("根据审核结果更新实体审核信息失败", ex);
            }
           
        }

        /// <summary>
        /// GetObjectEntityInstance
        /// </summary>
        /// <returns></returns>
        object GetObjectEntityInstance(int ApproveCategory, Guid flowid, ApprovalStatus action)
        {
            string msg = string.Empty;
            switch (ApproveCategory)
            {
                case (int)ApprovalType.SupplyUnitApproval:
                case (int)ApprovalType.SupplyUnitEditApproval:
                case (int)ApprovalType.SupplyUnitLockApproval:
                    SupplyUnit su = BusinessHandlerFactory.SupplyUnitBusinessHandler.GetSupplyUnitByFlowID(flowid);
                    if (su != null)//测试时可能为NULL
                    {
                        su.ApprovalStatus = action;
                    }
                    return su;
                case (int)ApprovalType.DrugInfoApproval:
                case (int)ApprovalType.DrugInfoEditApproval:
                case (int)ApprovalType.DrugInfoLockApproval:
                    DrugInfo di = BusinessHandlerFactory.DrugInfoBusinessHandler.GetDrugInfoByFlowID(flowid);
                    if (di != null)//测试时可能为NULL
                    {
                        di.ApprovalStatus = action;
                    }
                    return di;
                case (int)ApprovalType.PurchaseUnitApproval:
                case (int)ApprovalType.PurchaseUnitEditApproval:
                case (int)ApprovalType.PurchaseUnitLockApproval:
                      PurchaseUnit pu = BusinessHandlerFactory.PurchaseUnitBusinessHandler.GetPurchaseUnitByFlowID(flowid);
                    if (pu != null)//测试时可能为NULL
                    {
                        pu.ApprovalStatus = action;
                    }
                    return pu;
                case (int)ApprovalType.drugsUnqualityApproval:
                    drugsUnqualificationCondition dc = new drugsUnqualificationCondition();
                    dc.FlowID = flowid;
                    dc.dtFrom = DateTime.MinValue;
                    dc.dtTo = DateTime.MaxValue;
                    DrugsUnqualication du = BusinessHandlerFactory.DrugsUnqualicationBusinessHandler.GetDrugsUnqualificationByCondition(dc).FirstOrDefault();
                    if (du != null)
                    {
                        du.ApprovalStatus = action;
                        
                    }
                    return du;
                case (int)ApprovalType.drugsBreakageApproval:
                    DrugsBreakage db = BusinessHandlerFactory.DrugsBreakageBusinessHandler.GetDrugsBreakageByFlowID(flowid);
                    if (db != null)
                    {
                        db.ApprovalStatus = action;
                        if (action == ApprovalStatus.Reject)
                        {
                            var c=BusinessHandlerFactory.DrugsUnqualicationBusinessHandler.Get(db.DrugUnqualityId);
                            if (c != null)
                            {
                                c.unqualificationType = 0;
                                BusinessHandlerFactory.DrugsUnqualicationBusinessHandler.Save(c);
                            }
                        }

                    }
                    return db;
                case (int)ApprovalType.drugsInventoryMove:
                    DrugsInventoryMove dim = BusinessHandlerFactory.DrugsInventoryMoveBusinessHandler.GetDrugsInventoryMoveByFlowID(flowid);
                    if (dim != null)
                    {
                        dim.ApprovalStatus = action;
                    }
                    return dim;
                case (int)ApprovalType.VehicleApproval:
                    Vehicle v = BusinessHandlerFactory.VehicleBusinessHandler.GetVehicleByFlowID(flowid);
                    if (v != null)
                    {
                        v.ApprovalStatusValue = (int)action;
                    }
                    return v;
                case (int)ApprovalType.DirectSalesApproval:
                    Models.DirectSalesOrder dso = BusinessHandlerFactory.DirectSalesOrderBusinessHandler.GetDirectSalesOrderByFlowId(flowid);
                    dso.ApprovalStatusValue = (int)action;
                    return dso;
            }
            return null;
        }


        /// <summary>
        /// GetNextSubflowIDByFlowId
        /// </summary>
        /// <returns></returns>
        public int GetNextSubflowIDByFlowId(Guid flowid)
        { 
            try
            {
                int nextSubFlowID = 0;
                if(this.Exist(p=> p.FlowId ==flowid))
                     nextSubFlowID = this.Fetch(p => p.FlowId == flowid).Select(s => s.SubFlowId).Max() + 1;
                return nextSubFlowID;
            }
            catch (Exception ex)
            {
                return this.HandleException<int>("获取下一个流程失败", ex);
            }
        }

        /// <summary>
        /// 获取需要审核的流程数量
        /// </summary>
        /// <param name="ApprovalTypeId"></param>
        /// <returns></returns>
        public int GetNeedApprovalCount(int approvalTypeValue)
        {
            try
            {
                return this.Count(p => p.Status.Equals(1) && p.ApprovalFlowType.ApprovalTypeValue.Equals(approvalTypeValue));
            }
            catch (Exception ex)
            {
                return this.HandleException<int>("获取需要审批的流程数量失败", ex);
            }
        }
    }
}
