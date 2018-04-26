using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;
using System.Data.Entity;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class ApprovalFlowTypeBusinessHandler
    {
        protected override IQueryable<ApprovalFlowType> IncludeNavigationProperties(IQueryable<ApprovalFlowType> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable
                 .Include(t => t.ApprovalFlowNodes)
             );
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<ApprovalFlowType>>(ex.Message, ex);
            }
         
        }

        /// <summary>
        /// 根据业务类型获取可选择的审批流程
        /// </summary>
        /// <param name="approveType"></param>
        /// <returns></returns>
        public IEnumerable<ApprovalFlowType> GetApprovalFlowTypeByBusiness(ApprovalType approveType)
        {
            try
            {
                List<ApprovalFlowType> listApprovalFlowType = new List<ApprovalFlowType>();
                int approveTypeIndex = (int)approveType;
                listApprovalFlowType = this.Fetch(p => p.ApprovalTypeValue == approveTypeIndex).ToList();
                return listApprovalFlowType;
            }
            catch (Exception ex)
            {
                return this.HandleException<IEnumerable<ApprovalFlowType>>("根据业务类型获取可选择的审批流程失败", ex);
            }
        }

        /// <summary>
        /// 根据业务类型数组获取可选择的审批流程
        /// </summary>
        /// <param name="approveType"></param>
        /// <returns></returns>
        public List<ApprovalFlowType> GetApprovalFlowTypeByTypeList(int[] approveTypeList)
        {
            try
            {
              var queryBuilder=QueryBuilder.Create<ApprovalFlowType>()
                 .In(c => c.ApprovalTypeValue, approveTypeList);
              return BusinessHandlerFactory.RepositoryProvider.Db.ApprovalFlowTypes.Where(queryBuilder.Expression).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<ApprovalFlowType>>("根据业务类型数组获取可选择的审批流程失败", ex);
            }
        }
    }
}
