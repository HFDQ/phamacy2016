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
        public ReturnPurchaseOrderList[] GetInventeryOrderListByReturn( string keyword,string supplyUnitName )
        {
            var all = this.Queryable;            
            if (!string.IsNullOrEmpty(keyword))
            {
                all = all.Where(r => r.RelatedOrderDocumentNumber.Contains(keyword) || r.DocumentNumber.Contains(keyword));
            }
            if (!string.IsNullOrEmpty(supplyUnitName) && !string.IsNullOrWhiteSpace(supplyUnitName))
            {
                
                all = all.Where(r => r.PurchaseOrder.SupplyUnit.PinyinCode.Contains(supplyUnitName));
            }
            var c = all.ToList();
            ReturnPurchaseOrderList rpol = null;
            List<ReturnPurchaseOrderList> rd = new List<ReturnPurchaseOrderList>();

            foreach (var i in c)
            {
                if (rd.Count(r => r.id == i.PurchaseOrderId)>0) continue;
                rpol = new ReturnPurchaseOrderList();
                rpol.id = i.PurchaseOrderId;
                rpol.PInventoryDocumentNumber = i.DocumentNumber;
                rpol.POrderDocumentNumber = i.PurchaseOrder.DocumentNumber;
                rpol.InventoryDate = i.OperateTime.Date;
                rpol.py = i.PurchaseOrder.SupplyUnit.PinyinCode;
                rpol.SupplyUnitName = i.PurchaseOrder.SupplyUnit.Name;
                rd.Add(rpol);
            }

            return rd.ToArray<ReturnPurchaseOrderList>();
        }

        public PurchaseOrderReturnDetailEntity[] getPurchaseInventoryDetatilEntity(Guid id)
        {
            List<PurchaseOrderReturnDetailEntity> l=new List<PurchaseOrderReturnDetailEntity>();
            PurchaseOrderReturnDetailEntity pord = null;
            var pid = this.Queryable;
            //List<DrugInfo> drugList = RepositoryProvider.Db.DrugInfos.ToList();

            var all = pid.Where(r => r.PurchaseOrderId == id).Include(r => r.PurchaseInInventeryOrderDetails);
            var piio = all.ToList().FirstOrDefault();
            
            var c = RepositoryProvider.Db.PurchaseCheckingOrderDetails.Where(r => r.PurchaseCheckingOrderId == piio.RelatedOrderId).ToList();
            
            foreach (var d in c)
            {
                var f = d;
                var i = piio.PurchaseInInventeryOrderDetails.Where(r => r.DrugInfoId == f.DrugInfoId && r.BatchNumber == f.BatchNumber).ToList().First();
                var h = RepositoryProvider.Db.DrugInfos.Where(r => r.Id == i.DrugInfoId).ToList().First();
                
                pord=new PurchaseOrderReturnDetailEntity();
                pord.DrugInfoId = f.DrugInfoId;
                pord.BatchNumber = f.BatchNumber;
                pord.Decription = f.Decription;
                pord.DictionaryDosageCode = h.DictionaryDosageCode;
                pord.DictionaryMeasurementUnitCode = h.DictionaryMeasurementUnitCode;
                pord.DictionarySpecificationCode = h.DictionarySpecificationCode;
                pord.DrugInfoId = f.DrugInfoId;
                pord.FactoryName = h.FactoryName;
                pord.Id = Guid.NewGuid();
                pord.IsReissue = false;
                pord.LicensePermissionNumber = h.LicensePermissionNumber;
                pord.OutValidDate = f.OutValidDate;
                pord.ProductGeneralName = h.ProductGeneralName;
                pord.PruductDate = f.PruductDate;
                pord.PurchaseOrderReturnId = new Guid();
                pord.PurchasePrice = f.PurchasePrice;
                pord.PurchaseReturnSourceString = "库存";
                pord.PurchaseReturnSourceValue = 0;
                pord.ReissueAmount = 0;
                pord.RelatedOrderId = piio.Id;
                pord.ReturnAmount = 0;
                pord.ReturnHandledMethodValue = 0;
                pord.ReturnHandledMethodValueString = "";
                pord.ReturnReason = "";
                l.Add(pord);
            }
            return l.ToArray();
        }

        public bool saveDrugInventeryNumberByFinnanceApproval(PurchaseOrderReturnDetail[] prd)
        {
            foreach (var i in prd)
            {

            }
            return false;
        }
        #endregion
    }

    
}
