using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class VehicleBusinessHandler
    {
        public bool AddVehicleToApprovalByFlowID(Models.Vehicle value, System.Guid flowTypeID, string ChangeNote)
        {
            try
            {
                value.CreateTime = DateTime.Now;

                this.Add(value);
                ApprovalFlow af = BusinessHandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowInstance(flowTypeID, (Guid)value.FlowID, (Guid)value.createUID, ChangeNote);
                BusinessHandlerFactory.ApprovalFlowBusinessHandler.Add(af);

                //增加审批流程记录
                ApprovalFlowRecord afr = BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.GetApproveFlowRecordInstance(af, (Guid)value.createUID, ChangeNote);
                BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.Add(afr);

                this.Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Vehicle GetVehicleByFlowID(System.Guid flowId)
        {
            return this.Queryable.Where(r => r.Deleted == false && r.FlowID == flowId).FirstOrDefault();
        }

    }
}
