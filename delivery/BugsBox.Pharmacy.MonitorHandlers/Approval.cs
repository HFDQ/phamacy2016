using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Common;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Pharmacy.Repository;

namespace BugsBox.Pharmacy.MonitorHandlers
{
    public class Approval
    {
        static BusinessHandlerFactory businessHandlerFactory = new BusinessHandlerFactory(new Db(), null);

        public static int GetNeedApprovalNumber(int ApprovalTypeId)
        {
            try
            {
                ApprovalFlowBusinessHandler handler = businessHandlerFactory.ApprovalFlowBusinessHandler;
                return handler.GetNeedApprovalCount(ApprovalTypeId);
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
                return -1;
            }
           
        }
    }
}
