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
    partial class OutInventoryBusinessHandler
    {

        object Locker = new object();
        /// <summary>
        /// 获取出库信息的时候,同时获取订单明细
        /// </summary>
        /// <param name="queryable"></param>
        /// <returns></returns>
        protected override IQueryable<OutInventory> IncludeNavigationProperties(IQueryable<OutInventory> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable.Include(u => u.SalesOutInventoryDetails));
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<OutInventory>>(ex.Message, ex);
            }

        }

        /// <summary>
        /// 根据检索条件获取出库记录
        /// </summary>
        /// <returns></returns>
        public List<OutInventory> GetSubmitedOutInventoryByCondition(SalesCodeSearchInput condition, int pageindex, int pageSize, out PagerInfo pager)
        {
            try
            {
                //int iStatus = (int)OutInventoryStatus.Outing;

                PagerInfo pageInfo = new PagerInfo();
                pageInfo.Index = pageindex;
                pageInfo.Size = pageSize;

                pageindex = pageindex - 1;
                int skipCount = pageindex * pageSize;
                var result = this.Queryable;//.Where(p => p.OutInventoryStatusValue == iStatus);

                if (!string.IsNullOrWhiteSpace(condition.Code))
                    result = result.Where(p => p.OutInventoryNumber.IndexOf(condition.Code) >= 0);
                if (condition.FromDate != null)
                    result = result.Where(p => p.OrderOutInventoryTime >= condition.FromDate);
                if (condition.ToDate != null)
                    result = result.Where(p => p.OrderOutInventoryTime <= condition.ToDate);
                if (condition.OperatorID != Guid.Empty)
                    result = result.Where(p => p.OrderOutInventoryUserID == condition.OperatorID);

                pageInfo.RecordCount = result.Count();
                pager = pageInfo;
                result = result.OrderBy(o => o.CreateTime);
                result = (skipCount == 0 ? result.Take(pageSize) : result.Skip(skipCount).Take(pageSize));
                return result.ToList();
            }
            catch (Exception ex)
            {
                pager = new PagerInfo { RecordCount = 0 };
                return this.HandleException<List<OutInventory>>("根据检索条件获取出库情报失败", ex);
            }
        }

        /// <summary>
        /// 根据检索条件获取出库审核记录
        /// </summary>
        /// <returns></returns>
        public List<OutInventory> GetAcceptedOutInventoryByCondition(SalesCodeSearchInput condition, int pageindex, int pageSize, out PagerInfo pager)
        {
            try
            {
                //int iStatus = (int)OutInventoryStatus.Outed;

                PagerInfo pageInfo = new PagerInfo();
                pageInfo.Index = pageindex;
                pageInfo.Size = pageSize;

                pageindex = pageindex - 1;
                int skipCount = pageindex * pageSize;
                var result = this.Queryable;//.Where(p => p.OutInventoryStatusValue == iStatus);

                if (!string.IsNullOrWhiteSpace(condition.Code))
                    result = result.Where(p => p.OrderCode.Contains(condition.Code));
                if (condition.FromDate != null)
                    result = result.Where(p => (DateTime)p.OrderOutInventoryTime >= condition.FromDate);
                if (condition.ToDate != null)
                    result = result.Where(p => (DateTime)p.OrderOutInventoryTime <= condition.ToDate);

                if (condition.isImport == 1)
                {

                    result = from i in result
                             join h in RepositoryProvider.Db.OutInventoryDetails on i.Id equals h.SalesOutInventoryID
                             join j in RepositoryProvider.Db.SalesOrderDetails on h.SalesOrderDetailId equals j.Id
                             join k in RepositoryProvider.Db.DrugInventoryRecords on j.DrugInventoryRecordID equals k.Id
                             join l in RepositoryProvider.Db.DrugInfos on k.DrugInfoId equals l.Id
                             where l.IsMainMaintenance == true
                             select i;
                }

                pageInfo.RecordCount = result.Count();
                pager = pageInfo;
                result = result.OrderByDescending(o => o.CreateTime);
                result = (skipCount == 0 ? result.Take(pageSize) : result.Skip(skipCount).Take(pageSize));
                return result.ToList();
            }
            catch (Exception ex)
            {
                pager = new PagerInfo { RecordCount = 0 };
                return this.HandleException<List<OutInventory>>("根据检索条件获取出库审核记录失败", ex);
            }
        }

        /// <summary>
        /// 根据状态获取出库情报
        /// </summary>
        /// <returns></returns>
        public List<OutInventory> GetOutInventoryByStatus(int iStatus)
        {
            return this.Fetch(p => p.OutInventoryStatusValue == iStatus).ToList();
        }

        /// <summary>
        /// 获取所有未审核的出库信息
        /// </summary>
        /// <returns></returns>
        public List<OutInventory> GetAllNotApprovalOutInventory()
        {
            int status = (int)OutInventoryStatus.Outing;
            return this.Fetch(p => p.OutInventoryStatusValue == status).OrderByDescending(p => p.CreateTime).ToList();
        }

        /// <summary>
        /// 获取订单相关的出库信息(包括详细信息)
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public List<OutInventory> GetOutInventoryByOrderID(Guid orderID)
        {
            var list = this.Fetch(p => p.SalesOrderID == orderID).OrderBy(p => p.CreateTime).ToList();
            //更新详细信息
            if (list.Count > 0) return list;
            list.ForEach(p => p.SalesOutInventoryDetails = BusinessHandlerFactory.OutInventoryDetailBusinessHandler.Fetch(o => o.SalesOutInventoryID == p.Id).ToList());

            var newDetails = GetOutInventoryDetailFromOrderDetail(orderID);
            if (newDetails.Count > 0)
            {
                OutInventory newOut = new OutInventory();
                newOut.OutInventoryStatus = OutInventoryStatus.None;
                newOut.SalesOutInventoryDetails = newDetails;
                list.Add(newOut);
            }

            return list;
        }

        /// <summary>
        /// 保存出库信息
        /// </summary>
        /// <param name="entity"></param>
        public void SubmitOutInventory(OutInventory entity)
        {
            try
            {
                var order = BusinessHandlerFactory.SalesOrderBusinessHandler.Get(entity.SalesOrderID);

                entity.Id = Guid.NewGuid();
                entity.OrderCode = order.OrderCode;
                entity.OutInventoryDate = DateTime.Now;
                entity.CreateTime = DateTime.Now;
                entity.TotalMoney = entity.SalesOutInventoryDetails.Sum(p => p.OutAmount * p.ActualUnitPrice);



                this.Add(entity);

                order.OutInventoryId = entity.Id;
                order.OrderOutInventoryUserID = entity.CreateUserId;
                order.OrderOutInventoryTime = DateTime.Now;
                order.OrderOutInventoryCode = entity.OrderCode;




                foreach (var detail in entity.SalesOutInventoryDetails)
                {
                    var sDetail = BusinessHandlerFactory.SalesOrderDetailBusinessHandler.Get(detail.SalesOrderDetailId);
                    sDetail.OutAmount += detail.OutAmount;//更新到订详细中
                    BusinessHandlerFactory.SalesOrderDetailBusinessHandler.Save(sDetail);

                    detail.Id = Guid.NewGuid();
                    detail.SalesOutInventoryID = entity.Id;
                    detail.CreateTime = DateTime.Now;
                    detail.DrugInventoryRecordID = sDetail.DrugInventoryRecordID;
                    detail.ActualUnitPrice = sDetail.ActualUnitPrice;

                    if (string.IsNullOrEmpty(detail.Description))
                    {
                        detail.Description = "无备注";//必须字段
                    }
                    BusinessHandlerFactory.OutInventoryDetailBusinessHandler.Add(detail);
                }

                this.Save();

                var tmpDetail = BusinessHandlerFactory.SalesOrderDetailBusinessHandler.Fetch(p => p.OutAmount < p.Amount - p.ReturnAmount).FirstOrDefault();

                //有未出库的商品,则此订单为出库中,否则作为配送中...
                order.OrderStatus = (tmpDetail == null) ? OrderStatus.Delivering : OrderStatus.Outing;
                BusinessHandlerFactory.SalesOrderBusinessHandler.Save(order);
                this.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("提交出库信息处理失败!", ex);
            }
        }

        /// <summary>
        /// 同意出库,并添加配送信息
        /// </summary>
        /// <param name="entity"></param>
        public void AcceptOutInverntory(OutInventory entity)
        {
            try
            {
                lock (Locker)
                {
                    entity.UpdateTime = DateTime.Now;
                    entity.OrderOutInventoryCheckTime = DateTime.Now;
                    entity.OrderOutInventoryTime = DateTime.Now;
                    entity.OrderOutInventoryCheckNumber = BusinessHandlerFactory.BillDocumentCodeBusinessHandler.GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.SalesOrderOutInventory).Code;

                    this.Save(entity);

                    var order = BusinessHandlerFactory.SalesOrderBusinessHandler.Get(entity.SalesOrderID);

                    //追加配送表
                    var c = RepositoryProvider.Db.Deliverys.Where(r => r.OutInventoryID == entity.Id).FirstOrDefault();
                    if (c == null && entity.OutInventoryStatusValue == (int)OutInventoryStatus.Outed)
                    {
                        Delivery delivery = new Delivery();
                        delivery.Id = Guid.NewGuid();
                        delivery.DeliveryStatusValue = (int)DeliveryStatus.Reservation;//配送预约
                        delivery.ReceivingCompasnyID = order.PurchaseUnitId;
                        delivery.ShippingAddress = PharmacyFileBusinessHandler.CurrentStore.Address;
                        delivery.DeliveryAddress = BusinessHandlerFactory.PurchaseUnitBusinessHandler.Get(order.PurchaseUnitId).ReceiveAddress;
                        delivery.DrugsCount = entity.SalesOutInventoryDetails.Sum(p => p.OutAmount);
                        delivery.CreateTime = delivery.UpdateTime = DateTime.Now;
                        delivery.CreateUserId = entity.ReviewerId;
                        delivery.UpdateUserId = entity.ReviewerId;
                        delivery.OrderID = order.Id;
                        delivery.OutInventoryID = entity.Id;
                        delivery.outedNo = BusinessHandlerFactory.BillDocumentCodeBusinessHandler.GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.Delivery).Code;
                        delivery.DeliveryMethodValue = order.PickUpGoodTypeValue == 0 ? 1 : order.PickUpGoodTypeValue == 1 ? 0 : (int)DeliveryMethod.Entrust;
                        delivery.Memo = "执行配送，配送单号：" + order.OrderCode;
                        BusinessHandlerFactory.DeliveryBusinessHandler.Add(delivery);
                    }
                    this.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("审核出库单时出错!", ex);
            }
        }
        /// <summary>
        /// 采购退货添加配送信息
        /// </summary>
        /// <param name="por"></param>
        public bool SaveDeliveryByPurchaseReturn(Models.PurchaseOrderReturn por, System.Guid createUid)
        {
            try
            {
                if (por == null) return false;
                por.OrderStatusValue = (int)OrderReturnStatus.Over;
                por.CheckerUserId = createUid;
                por.CheckerUpdateTime = DateTime.Now;
                por.CheckerSuggest = "质量合格，可以采购退货出库";
                BusinessHandlerFactory.PurchaseOrderReturnBusinessHandler.Save(por);
                por.PurchaseOrderReturnDetails = RepositoryProvider.Db.PurchaseOrderReturnDetails.Where(r => r.PurchaseOrderReturnId == por.Id).ToArray();

                Delivery delivery = new Delivery();
                delivery.Id = Guid.NewGuid();
                delivery.DeliveryStatusValue = (int)DeliveryStatus.Reservation;//配送预约

                PurchaseOrder po = BusinessHandlerFactory.PurchaseOrderBusinessHandler.Get(por.PurchaseOrderId);
                SupplyUnit su = BusinessHandlerFactory.SupplyUnitBusinessHandler.Get(po.SupplyUnitId);

                delivery.ReceivingCompasnyID = po.SupplyUnitId;
                delivery.ShippingAddress = PharmacyFileBusinessHandler.CurrentStore.Address;
                delivery.DeliveryAddress = su.ReceiveAddress;

                delivery.DrugsCount = por.PurchaseOrderReturnDetails.Sum(r => r.ReturnAmount);

                delivery.CreateTime = delivery.UpdateTime = DateTime.Now;
                delivery.CreateUserId = createUid;
                delivery.UpdateUserId = createUid;
                delivery.OrderID = por.Id;
                delivery.OutInventoryID = new Guid();
                delivery.Memo = "销退配送";
                delivery.SalesOrder = por.DocumentNumber;
                BusinessHandlerFactory.DeliveryBusinessHandler.Add(delivery);


                this.Save();

                su = null;
                po = null;
                por.PurchaseOrderReturnDetails = null;
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("创建出库配送单失败！", e);
            }
        }

        /// <summary>
        /// 根据销售订单获取获取出库详细
        /// </summary>
        /// <param name="SalesOrderId"></param>
        /// <returns></returns>
        public List<OutInventoryDetail> GetOutInventoryDetailFromOrderDetail(Guid orderID)
        {
            try
            {
                List<SalesOrderDetail> salesOrderDetails = BusinessHandlerFactory.SalesOrderDetailBusinessHandler
                                                                .Fetch(p => p.SalesOrderID == orderID
                                                                        && p.OutAmount < (p.Amount - p.ReturnAmount))//还有未发的货
                                                                .ToList();

                List<OutInventoryDetail> detailList = new List<OutInventoryDetail>();
                foreach (var sDetail in salesOrderDetails)
                {
                    var detail = new OutInventoryDetail();
                    detail.ActualUnitPrice = sDetail.ActualUnitPrice;
                    detail.Index = sDetail.Index;
                    detail.productCode = sDetail.productCode;
                    detail.productName = sDetail.productName;
                    detail.BatchNumber = sDetail.BatchNumber;
                    detail.UnitPrice = sDetail.UnitPrice;
                    detail.Amount = sDetail.Amount - sDetail.OutAmount - sDetail.ReturnAmount;
                    detail.Price = sDetail.Price;
                    detail.DictionaryDosageCode = sDetail.DictionaryDosageCode;
                    detail.SpecificationCode = sDetail.SpecificationCode;
                    detail.PruductDate = sDetail.PruductDate;
                    detail.OutValidDate = sDetail.OutValidDate;
                    detail.FactoryName = sDetail.FactoryName;
                    detail.MeasurementUnit = sDetail.MeasurementUnit;
                    detail.Origin = sDetail.Origin;
                    detail.Description = "数量正确";
                    DrugInventoryRecord drugInventoryRecord = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(sDetail.DrugInventoryRecordID);
                    if (drugInventoryRecord == null)
                    {
                        BusinessHandlerFactory.SalesOrderDetailBusinessHandler.Delete(sDetail.Id);
                        continue;
                    }
                    WarehouseZone warehouseZone = BusinessHandlerFactory.WarehouseZoneBusinessHandler.Get(drugInventoryRecord.WarehouseZoneId);
                    warehouseZone.Warehouse = BusinessHandlerFactory.WarehouseBusinessHandler.Get(warehouseZone.WarehouseId);
                    detail.WarehouseName = warehouseZone.Warehouse.Name;
                    detail.WarehouseCode = warehouseZone.Warehouse.Code;
                    detail.WarehouseZoneCode = warehouseZone.Code;
                    detail.WarehouseZoneName = warehouseZone.Name;
                    detail.CanSaleNum = drugInventoryRecord.CanSaleNum;

                    detail.SalesOrderId = sDetail.SalesOrderID;
                    detail.SalesOrderDetailId = sDetail.Id;

                    detailList.Add(detail);
                }
                return detailList;
            }
            catch (Exception ex)
            {
                return this.HandleException<List<OutInventoryDetail>>("根据销售订单好获取输出订单模型失败", ex);
            }
        }

        public System.Collections.Generic.IEnumerable<Business.Models.OutInventoryMode> GetOutInventorySpecialDrugs(Models.OutInventory outInve)
        {
            string specialDrug = string.Empty;
            var c = from i in outInve.SalesOutInventoryDetails
                    join j in RepositoryProvider.Db.DrugInventoryRecords
                    on i.DrugInventoryRecordID equals j.Id
                    join k in RepositoryProvider.Db.DrugInfos
                    on j.DrugInfoId equals k.Id
                    where k.IsSpecialDrugCategory
                    select new Business.Models.OutInventoryMode
                    {
                        productName = i.productName,
                        BatchNumber = j.BatchNumber,
                        FactoryName = i.FactoryName,
                        SpecificationCode = k.DictionarySpecificationCode
                    };
            return c;
        }

#if false
        /// <summary>
        /// 根据订单获取出库信息
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public OutInventory GetOutInventoryInfoByOrderID(Guid orderID)
        {
            return this.Fetch(p => p.SalesOrderID == orderID).FirstOrDefault();
        }

        /// <summary>
        /// 根据销售订单好获取输出订单模型
        /// </summary>
        /// <param name="SalesOrderId"></param>
        /// <returns></returns>
        public List<OutInventoryMode> GetOutInventoryModesBySalesOrderId(Guid SalesOrderId)
        {
            try
            {
                // SalesOrder SalesOrderrDetail Warehouse WarehouseZone
                SalesOrder salesOrder = BusinessHandlerFactory.SalesOrderBusinessHandler.Get(SalesOrderId);
                List<SalesOrderDetail> salesOrderDetails = salesOrder.SalesOrderDetails.ToList();
                List<OutInventoryMode> outInventoryModelist = new List<OutInventoryMode>();
                OutInventoryMode outInventoryMode;
                WarehouseZone warehouseZone;
                DrugInventoryRecord drugInventoryRecord;
                foreach (var salesOrderDetail in salesOrderDetails)
                {
                    outInventoryMode = new OutInventoryMode();
                    outInventoryMode.Index = salesOrderDetail.Index;
                    outInventoryMode.productCode = salesOrderDetail.productCode;
                    outInventoryMode.productName = salesOrderDetail.productName;
                    outInventoryMode.BatchNumber = salesOrderDetail.BatchNumber;
                    outInventoryMode.UnitPrice = salesOrderDetail.UnitPrice;
                    outInventoryMode.Amount = salesOrderDetail.Amount;
                    outInventoryMode.Price = salesOrderDetail.Price;
                    outInventoryMode.SpecificationCode = salesOrderDetail.SpecificationCode;
                    outInventoryMode.PruductDate = salesOrderDetail.PruductDate;
                    outInventoryMode.OutValidDate = salesOrderDetail.OutValidDate;
                    outInventoryMode.FactoryName = salesOrderDetail.FactoryName;


                    drugInventoryRecord = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(salesOrderDetail.DrugInventoryRecordID);
                    warehouseZone = BusinessHandlerFactory.WarehouseZoneBusinessHandler.Get(drugInventoryRecord.WarehouseZoneId);
                    warehouseZone.Warehouse = BusinessHandlerFactory.WarehouseBusinessHandler.Get(warehouseZone.WarehouseId);
                    outInventoryMode.WarehouseName = warehouseZone.Warehouse.Name;
                    outInventoryMode.WarehouseCode = warehouseZone.Warehouse.Code;
                    outInventoryMode.WarehouseZoneCode = warehouseZone.Code;
                    outInventoryMode.WarehouseZoneName = warehouseZone.Name;

                    outInventoryModelist.Add(outInventoryMode);
                }
                return outInventoryModelist;
            }
            catch (Exception ex)
            {
                return this.HandleException<List<OutInventoryMode>>("根据销售订单好获取输出订单模型", ex);
            }
        }
        /// <summary>
        /// 提交处理
        /// </summary>
        /// <param name="order"></param>
        /// <param name="outInventory"></param>
        public void SaveOutInventoryByOrderOutInventory(SalesOrder order, OutInventory outInventory)
        {
            //1. 更新订单表(）
            //2. 添加出库表
            //3. 添加出库明细表
            SalesOrder neworder = BusinessHandlerFactory.SalesOrderBusinessHandler.Get(order.Id);
            this.BusinessHandlerFactory.SalesOrderBusinessHandler.Save(order);
            outInventory.Id = Guid.NewGuid();
            neworder.OrderOutInventoryCode = outInventory.OutInventoryNumber;
            neworder.OrderOutInventoryTime = outInventory.CreateTime;
            this.Add(outInventory);
            ICollection<OutInventoryDetail> details = outInventory.SalesOutInventoryDetails;
            foreach (OutInventoryDetail detail in details)
            {
                detail.SalesOutInventoryID = outInventory.Id;
                detail.UpdateTime = DateTime.Now;
                detail.CreateTime = DateTime.Now;
                BusinessHandlerFactory.OutInventoryDetailBusinessHandler.Add(detail);
            }
            this.Save();
        }
        /// <summary>
        /// 审批(未使用)
        /// </summary>
        public void AcceptOutInventory(SalesOrder order)
        {    //1. 更新订单表(）
            order.UpdateTime = DateTime.Now;
            order.OrderOutInventoryCheckTime = DateTime.Now;
            order.OrderStatusValue = (int)OrderStatus.Outed;
            this.BusinessHandlerFactory.SalesOrderBusinessHandler.Save(order);
        }
#endif

        public System.Collections.Generic.IEnumerable<Business.Models.WarehouseZonePositionOutInventoryModel> GetWarehouseZonePositionOutInventories(System.Guid SalesOrderId)
        {
            var c = RepositoryProvider.Db.SalesOrders.Where(r => r.Id == SalesOrderId);

            var re = from i in c
                     join d in RepositoryProvider.Db.SalesOrderDetails.Where(r => r.Deleted == false) on i.Id equals d.SalesOrderID
                     join inv in RepositoryProvider.Db.DrugInventoryRecords on d.DrugInventoryRecordID equals inv.Id
                     join wz in RepositoryProvider.Db.WarehouseZones on inv.WarehouseZoneId equals wz.Id
                     join wzp in RepositoryProvider.Db.WarehouseZonePositions on inv.WareHouseZonePositionId equals wzp.Id
                     select new Business.Models.WarehouseZonePositionOutInventoryModel
                     {
                         PIndex = wzp.PIndex,
                         WareHouseZonePIndex = wz.PIndex,
                         OutAmount = d.Amount,
                         OrderNumber = i.OrderCode
                     };
            return re;
        }
    }
}
