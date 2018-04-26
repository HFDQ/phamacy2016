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
    partial class DrugsUnqualificationDestroyHandler
    {
        protected override IQueryable<DrugsUnqualificationDestroy> IncludeNavigationProperties(IQueryable<DrugsUnqualificationDestroy> queryable)
        {
            try
            {
                return base.Queryable;
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<DrugsUnqualificationDestroy>>(ex.Message, ex);
            }
        }


        public DrugsUnqualificationDestroy[] getDrugsUnqualificationDestroysByCondition(DateTime dtFrom,DateTime dtTo,string keyword)
        {
            var all = this.Queryable;
            if (dtFrom != DateTime.MinValue)
            {
                all = all.Where(c => c.DestroyTime >= dtFrom);
            }
            if (dtTo != DateTime.MaxValue)
            {                
                all = all.Where(c => c.DestroyTime <= dtTo);
            }
            if (!keyword.IsNullOrTrimEmpty())
            {
                all = all.Where(c => c.drugName.Contains(keyword)||c.batchNo.Contains(keyword)||c.DestroyMan.Contains(keyword)||c.DestroyPlace.Contains(keyword)||c.wareHouseZone.Contains(keyword));
            }

            return all.ToArray();
        }

        public bool CreateDestroyByDrugsBreakage(Models.DrugsBreakage[] dbs,Models.DrugsUnqualificationDestroy d)
        {
            string msg = string.Empty;
            try
            {                
                foreach (var c in dbs)
                {
                    c.ApprovalStatusValue = 32;
                    BusinessHandlerFactory.DrugsBreakageBusinessHandler.Save(c);

                    DrugsUnqualificationDestroy dud = new DrugsUnqualificationDestroy();
                    dud.batchNo = c.batchNo;
                    dud.createTime = DateTime.Now;
                    dud.createUID = d.createUID;
                    dud.Deleted = false;
                    dud.DestroyCargo = d.DestroyCargo;
                    dud.Destroyer = d.Destroyer;
                    dud.DestroyMan = d.DestroyMan;
                    dud.DestroyMethod = d.DestroyMethod;
                    dud.DestroyPlace = d.DestroyPlace;
                    dud.DestroyReason = d.DestroyReason;
                    dud.DestroyState = d.DestroyState;
                    dud.DestroyTime = d.DestroyTime;
                    dud.DosageType = c.DosageType;
                    dud.drugName = c.drugName;
                    dud.DrugsUnqualicationID = c.Id;
                    dud.ExpireDate = c.ExpireDate;
                    dud.Id = Guid.NewGuid();                    
                    dud.price = c.quantity * c.PurchasePrice;
                    dud.produceDate = c.produceDate;
                    dud.Specific = c.Specific;
                    dud.SupervisorOpinion = d.SupervisorOpinion;
                    dud.updateTime = DateTime.Now;
                    dud.wareHouseZone = "不合格区";
                    BusinessHandlerFactory.DrugsUnqualificationDestroyHandler.Add(dud);
                }
                
                this.Save();
                
                return true;
            }
            catch (Exception ex)
            {                
                msg = "销毁报告写入失败！";
                return false;
            }
            finally
            {
                this.Dispose();
            }
        }
    }
}
