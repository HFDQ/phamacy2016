using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;


namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class ApprovalFlowRecordBusinessHandler
    {
        protected override IQueryable<ApprovalFlowRecord> IncludeNavigationProperties(IQueryable<ApprovalFlowRecord> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable
             );
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<ApprovalFlowRecord>>(ex.Message, ex);
            }
         
        }

        /// <summary>
        /// 根据当前审批流程获得已审批节点记录集合
        /// </summary>
        /// <param name="FlowID"></param>
        /// <param name="historyID"></param>
        /// <returns></returns>
        public IEnumerable<ApprovalFlowRecord> GetFinishApproveFlowsRecord(Guid FlowID, int historyID)
        {
            try
            {

                List<ApprovalFlowNode> listNodes = new List<ApprovalFlowNode>();

                List<ApprovalFlowRecord> listApprovalFlowRecord = BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.Fetch(
                           r => r.FlowId == FlowID && r.SubFlowId == historyID).OrderByDescending(p => p.ApproveTime).ToList();
                return listApprovalFlowRecord;
            }
            catch (Exception ex)
            {
                return this.HandleException<IEnumerable<ApprovalFlowRecord>>("根据当前审批流程获得已审批节点记录集合失败", ex);
            }
        }


        /// <summary>
        /// GetApproveFlowRecordInstance
        /// </summary>
        /// <param name="flow"></param>
        /// <returns></returns>
        public ApprovalFlowRecord GetApproveFlowRecordInstance(ApprovalFlow flow, Guid userID, string comment)
        {
            try
            {
                ApprovalFlowRecord record = new ApprovalFlowRecord();
                record.Id = Guid.NewGuid();
                record.FlowId = flow.FlowId;
                record.SubFlowId = flow.SubFlowId;
                record.ApprovalFlowNodeId = flow.NextNodeID;
                record.ApproveTime = DateTime.Now;
                record.ApproveUserId = userID;
                record.Comment = comment;
                return record;
            }
            catch (Exception ex)
            { 
                return this.HandleException<ApprovalFlowRecord>("获取审批流程记录失败", ex);
            }
        }
    }
}
