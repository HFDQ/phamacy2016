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
    partial class PurchaseInInventeryOrderBusinessHandler
    {
        protected override IQueryable<PurchaseInInventeryOrder> IncludeNavigationProperties(IQueryable<PurchaseInInventeryOrder> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable.Include(r => r.PurchaseOrder.SupplyUnit));
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<PurchaseInInventeryOrder>>(ex.Message, ex);
            }
        }

        #region 已入库采购单列表，用于创建退货单
        public ReturnPurchaseOrderList[] GetInventeryOrderListByReturn(string keyword, string supplyUnitName, string DrugName, string Batch)
        {
            var all = this.Queryable;            
            if (!string.IsNullOrEmpty(keyword))
            {
                all = all.Where(r => r.DocumentNumber.Contains(keyword) || r.PurchaseOrder.DocumentNumber.Contains(keyword));
            }
            if (!string.IsNullOrEmpty(supplyUnitName) && !string.IsNullOrWhiteSpace(supplyUnitName))
            {                
                all = all.Where(r =>r.PurchaseOrder.SupplyUnit.PinyinCode!=null && r.PurchaseOrder.SupplyUnit.PinyinCode.ToUpper().Contains(supplyUnitName.ToUpper()));
            }
            var drugInfoList = RepositoryProvider.Db.DrugInfos.Where(r => r.Deleted == false);
            if (!string.IsNullOrEmpty(DrugName))
            {
                drugInfoList = drugInfoList.Where(r => r.ProductGeneralName.Contains(DrugName) || (r.Pinyin != null && r.Pinyin.ToUpper().Contains(DrugName.ToUpper())));
            }

            var purchaseInInventoryDetails = RepositoryProvider.Db.PurchaseInInventeryOrderDetails.Where(r => r.Deleted == false);
            if (!string.IsNullOrEmpty(Batch))
            {
                purchaseInInventoryDetails = purchaseInInventoryDetails.Where(r => r.BatchNumber.Contains(Batch));
            }

            var list = from i in all
                       join rp in purchaseInInventoryDetails
                       on i.Id equals rp.PurchaseInInventeryOrderId
                       join di in drugInfoList
                       on rp.DrugInfoId equals di.Id
                       select new ReturnPurchaseOrderList
                       {
                           id = i.PurchaseOrderId,
                           InventoryDate = i.OperateTime,
                           PInventoryDocumentNumber = i.DocumentNumber,
                           POrderDocumentNumber = i.PurchaseOrder.DocumentNumber,
                           py = i.PurchaseOrder.SupplyUnit.PinyinCode,
                           SupplyUnitName = i.PurchaseOrder.SupplyUnit.Name
                       };
            
            return list.ToArray();
        }

       

        public PurchaseOrderReturnDetailEntity[] getPurchaseInventoryDetatilEntity(Guid id)
        {
            var pid = this.Queryable;
            var invent = pid.Where(r => r.PurchaseOrderId == id).Include(r => r.PurchaseInInventeryOrderDetails).FirstOrDefault();
            if (invent == null) return null;

            var info = from f in invent.PurchaseInInventeryOrderDetails.OrderBy(r=>r.sequence)
                       join k in RepositoryProvider.Db.DrugInventoryRecords on  new { dinfo = f.DrugInfoId, dbatch = f.BatchNumber} equals new { dinfo=k.DrugInfoId,dbatch=k.BatchNumber}
                       join drug in RepositoryProvider.Db.DrugInfos on k.DrugInfoId equals drug.Id
                       select new
                           PurchaseOrderReturnDetailEntity
                           {
                               DrugInfoId = f.DrugInfoId,
                               BatchNumber = f.BatchNumber,
                               Decription = f.Decription,
                               DictionaryDosageCode = k.DrugInfo.DictionaryDosageCode,
                               DictionaryMeasurementUnitCode = drug.DictionaryMeasurementUnitCode,
                               DictionarySpecificationCode = drug.DictionarySpecificationCode,
                               FactoryName = drug.FactoryName,
                               Id = Guid.NewGuid(),
                               IsReissue = false,
                               LicensePermissionNumber = drug.LicensePermissionNumber,
                               OutValidDate = f.OutValidDate,
                               ProductGeneralName = drug.ProductGeneralName,
                               PruductDate = f.PruductDate,
                               PurchaseOrderReturnId = new Guid(),
                               PurchasePrice = f.PurchasePrice,
                               PurchaseReturnSourceString = "库存",
                               PurchaseReturnSourceValue = 0,
                               ReissueAmount = 0,
                               RelatedOrderId = f.Id,
                               ReturnAmount = f.ArrivalAmount,
                               ReturnHandledMethodValue = 0,
                               ReturnHandledMethodValueString = "",
                               CanReturnNum = k.CanSaleNum,
                               inInventoryNum = f.ArrivalAmount,
                               ReturnReason = ""
                           };
            var c = info.ToArray();
            return c;
        }

        public bool saveDrugInventeryNumberByFinnanceApproval(PurchaseOrderReturnDetail[] prd)
        {
            foreach (var i in prd)
            {

            }
            return false;
        }
        #endregion

        public Models.PurchaseInInventeryOrderDetail[] GetLastInInventoryDetail(System.Guid[] DrugInfoIds)
        {
            if (DrugInfoIds.Count()<0) return null;
            var g = from i in DrugInfoIds.ToArray()
                    join j in RepositoryProvider.Db.PurchaseInInventeryOrderDetails on i equals j.DrugInfoId
                    select j;
            g = g.GroupBy(r => r.DrugInfoId).Select(s => s.OrderByDescending(r => r.ArrivalDateTime).FirstOrDefault());
            return g.ToArray();      
        }
    }

    
}
