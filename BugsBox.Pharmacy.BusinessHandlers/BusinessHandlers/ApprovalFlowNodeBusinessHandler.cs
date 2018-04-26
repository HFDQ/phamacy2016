using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;
using System.Data.Entity;
namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class ApprovalFlowNodeBusinessHandler
    {
        protected override IQueryable<ApprovalFlowNode> IncludeNavigationProperties(IQueryable<ApprovalFlowNode> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable
               .Include(t => t.ApprovalFlowType)
               );
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<ApprovalFlowNode>>(ex.Message, ex);
            }
           
        }
        /// <summary>
        /// 根据当前审批流程获得已审批节点记录集合
        /// </summary>
        /// <param name="FlowID"></param>
        /// <param name="historyID"></param>
        /// <returns></returns>
        public IEnumerable<ApprovalFlowNode> GetFinishApproveFlowsNodes(Guid FlowID,int historyID)
        {
            try
            {
                
                List<ApprovalFlowNode> listNodes = new List<ApprovalFlowNode>();

                List<ApprovalFlowRecord> listApprovalFlowRecord= BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.Fetch(
                           r => r.FlowId == FlowID && r.SubFlowId == historyID).OrderByDescending(p =>p.ApproveTime).ToList();
               
                foreach (ApprovalFlowRecord item in listApprovalFlowRecord)
                {
                    ApprovalFlowNode af = new ApprovalFlowNode();
                    listNodes.Add(this.Fetch(r => r.Id==item.ApprovalFlowNodeId).FirstOrDefault());
                }
                return listNodes;
            }
            catch (Exception ex)
            {
                return this.HandleException<IEnumerable<ApprovalFlowNode>>("根据当前审批流程获得已审批节点记录集合失败", ex);
            }
        }


        /// <summary>
        /// 根据当前flowtypeID 和节点ID获取下一个审批节点
        /// </summary>
        /// <param name="FlowID"></param>
        /// <param name="historyID"></param>
        /// <returns></returns>
        public ApprovalFlowNode GetNextApproveFlowsNode(Guid flowTypeId,Guid flowNodeID)
        {
            try
            {
                //int maxOrder = this.Fetch(n => n.ApprovalFlowTypeId == flowTypeId).Select(s => s.Order).Max();
                //ApprovalFlowNode node= this.Fetch(p => p.Id == flowNodeID && p.ApprovalFlowTypeId == flowNodeID).FirstOrDefault();
                //if (maxOrder == node.Order)
                //    return node;
                //else
                //    return this.Fetch(m => m.ApprovalFlowTypeId == flowTypeId && m.Order > node.Order).OrderBy(o => o.Order).FirstOrDefault();

                var nodelist = this.Fetch(p => p.ApprovalFlowTypeId == flowTypeId).OrderBy(p => p.Order).ToList();
                int currentIndex = nodelist.FindIndex(p => p.Id == flowNodeID);

                if (currentIndex == nodelist.Count - 1)
                {
                    return null;//审批流程结束,不存在下一个节点
                }
                else
                {
                    return nodelist[currentIndex + 1];
                }
            }
            catch (Exception ex)
            { 
                return this.HandleException<ApprovalFlowNode>("获取下一个审批结点失败", ex);
            }
        }


        /// <summary>
        /// 根据当前flowtypeID 取得第一个节点
        /// </summary>
        /// <param name="FlowID"></param>
        /// <param name="historyID"></param>
        /// <returns></returns>
        public ApprovalFlowNode GetFirstApproveFlowsNode(Guid flowTypeId)
        {
            try
            {
                ApprovalFlowNode node = this.Fetch(n => n.ApprovalFlowTypeId == flowTypeId).OrderBy(o => o.Order).FirstOrDefault();
                return node;
            }
            catch (Exception ex)
            {               
                return this.HandleException<ApprovalFlowNode>("获取第一个流程结点失败", ex);
            }
        }
    
    }
}
