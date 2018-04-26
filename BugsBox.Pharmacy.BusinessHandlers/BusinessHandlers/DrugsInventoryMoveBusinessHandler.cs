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
    partial class DrugsInventoryMoveBusinessHandler
    {
        protected override IQueryable<DrugsInventoryMove> IncludeNavigationProperties(IQueryable<DrugsInventoryMove> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable);
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<DrugsInventoryMove>>(ex.Message, ex);
            }
        }

        public bool AddDrugsInventoryMoveByFlowID(DrugsInventoryMove value, Guid flowTypeID, string changeNote)
        {
            try
            {
                value.createTime = DateTime.Now;
                value.updateTime = DateTime.Now;
                this.Add(value);

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
                this.HandleException("新增移库药品审批流程记录失败", e);
                return false;
            }
        }


        public DrugsInventoryMove GetDrugsInventoryMoveByFlowID(Guid flowID)
        {
            var c = this.Queryable.Where(r => r.flowID == flowID && r.Deleted==false).ToList().FirstOrDefault();
            return c;
        }

        public System.Collections.Generic.IEnumerable<Business.Models.DrugsInventoryMoveRecordModel> GetMoveRecords(Models.DrugsInventoryMove dm)
        {
            if (dm == null) return null;
            var all = this.Queryable;
            if (dm.ApprovalStatusValue > 0)
            {
                all = all.Where(r => r.ApprovalStatusValue == dm.ApprovalStatusValue);
            }
            if (!string.IsNullOrEmpty(dm.drugName))
            {
                all = all.Where(r => r.drugName.Contains(dm.drugName));
            }
            //以models的createtime和updatetime 作为时间查询条件
            all = all.Where(r => r.createTime > dm.createTime && r.createTime < dm.updateTime);

            var result = from i in all
                         join j in RepositoryProvider.Db.DrugInventoryRecords on i.inventoryRecordID equals j.Id
                         join d in RepositoryProvider.Db.DrugInfos on j.DrugInfoId equals d.Id
                         join k in RepositoryProvider.Db.WarehouseZones on i.WareHouseID equals k.Id
                         join l in RepositoryProvider.Db.Warehouses on k.WarehouseId equals l.Id
                         join m in RepositoryProvider.Db.WarehouseZones on i.OriginWareHouseID equals m.Id
                         join n in RepositoryProvider.Db.Warehouses on m.WarehouseId equals n.Id
                         select new Business.Models.DrugsInventoryMoveRecordModel
                         {
                            Amount=i.quantity,
                            BatchNumber=i.batchNo,
                            CreateTime=i.createTime,
                            CanSaleNum=j.CanSaleNum,
                            FactoryName=d.FactoryName,
                            Origin=d.Origin,
                            OriginWarehouseZoneName=k.Name,
                            OutValidDate=j.OutValidDate,
                            Price=j.PurchasePricce,
                            productName=d.ProductGeneralName,
                            PruductDate=j.PruductDate,
                            SpecificationCode=d.DictionarySpecificationCode,
                            Dosage=d.DictionaryDosageCode,
                            Status=i.ApprovalStatusValue,
                            OriginWarehouseName=m.Name,
                            WarehouseName=l.Name,
                            WarehouseZoneName=k.Name
                         };

            

            return result;
        }
    }
}
