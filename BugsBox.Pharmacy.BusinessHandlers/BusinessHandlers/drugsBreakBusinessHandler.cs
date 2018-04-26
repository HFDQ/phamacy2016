using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Business.Models;
using System.Linq.Expressions;
using System.Data.Entity;
using BugsBox.Pharmacy.Repository;
namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class DrugsBreakageBusinessHandler
    {
        protected override IQueryable<DrugsBreakage> IncludeNavigationProperties(IQueryable<DrugsBreakage> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable);
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<DrugsBreakage>>(ex.Message, ex);
            }
        }



        public bool AddDrugsBreakageByFlowID(DrugsBreakage value, Guid flowTypeID ,string changeNote)
        {
            try
            {
                var c = RepositoryProvider.Db.drugsUnqualications.Where(r => r.DocumentNumber == value.UnqualificationDocumentNumber);
                var d = c.FirstOrDefault();
                d.unqualificationType = 2;
                d.Specific = value.Specific;
                value.createTime = DateTime.Now;
                value.updateTime = DateTime.Now;
                this.Add(value);
                BusinessHandlerFactory.DrugsUnqualificationHandler.Save(d);

                value.DocumentNumber = new BillDocumentCodeBusinessHandler(BusinessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.DrugBreakage).Code;

                //增加审批流程
                ApprovalFlow af = BusinessHandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowInstance(flowTypeID, value.flowID, value.createUID, changeNote);
                BusinessHandlerFactory.ApprovalFlowBusinessHandler.Add(af);

                //增加审批流程记录
                ApprovalFlowRecord afr = BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.GetApproveFlowRecordInstance(af, value.createUID, changeNote);
                BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.Add(afr);

                this.Save();
                return true;
            }
            catch (Exception e)
            {
                this.HandleException("新增报损药品审批流程记录失败", e);
                return false;
            }
        }


        public DrugsBreakage GetDrugsBreakageByFlowID(Guid flowID)
        {
            var c = RepositoryProvider.Db.DrugsBreakages.AsQueryable();
            DrugsBreakage db=c.Where(r => r.flowID == flowID).ToList().FirstOrDefault();            
            return db;
        }

        public DrugsBreakage[] GetDrugsBreakagesPassed(DrugsBreakage db)
        {
            var c = RepositoryProvider.Db.DrugsBreakages.Where(r => r.ApprovalStatusValue == 2);
            if (db.ApprovalStatusValue != 0)
                c = c.Where(r => r.ApprovalStatusValue == db.ApprovalStatusValue);
            if (db.drugName != null && db.drugName != string.Empty)
                c = c.Where(r => r.drugName.Contains(db.drugName)||r.batchNo.Contains(db.drugName)||r.source.Contains(db.drugName));
            return c.ToArray();
        }
    }

}
