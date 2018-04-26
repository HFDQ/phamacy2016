using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Business.Models;
using System.Data.Entity;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class DeliveryBusinessHandler
    {
        protected override IQueryable<Delivery> IncludeNavigationProperties(IQueryable<Delivery> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable);
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<Delivery>>(ex.Message, ex);
            }
            finally
            {
                this.Dispose();
            }
          
        }

        /// <summary>
        /// 根据条件检索配送记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<Delivery> GetSubmitedDeliveryByCondition(SalesCodeSearchInput condition, int pageindex, int pageSize, out PagerInfo pager)
        {
            try
            {
                PagerInfo pageInfo = new PagerInfo();
                pageInfo.Index = pageindex;
                pageInfo.Size = pageSize;

                pageindex = pageindex - 1;
                int skipCount = pageindex * pageSize;
                var result = this.Queryable;

                if (!string.IsNullOrWhiteSpace(condition.Code))
                    result = result.Where(p => p.AcceptedNo.IndexOf(condition.Code) >= 0);
                if (condition.FromDate != null)
                    result = result.Where(p => p.AcceptedTime >= condition.FromDate);
                if (condition.ToDate != null)
                    result = result.Where(p => p.AcceptedTime <= condition.ToDate);
                if (condition.OperatorID != Guid.Empty)
                    result = result.Where(p => p.AcceptedOperatorId == condition.OperatorID);

                pageInfo.RecordCount = result.Count();
                pager = pageInfo;
                result = result.OrderBy(o => o.CreateTime);
                result = (skipCount == 0 ? result.Take(pageSize) : result.Skip(skipCount).Take(pageSize));
                //BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog { Content = ConnectedInfoProvider.User.Account + "成功获取配送信息" });
                return SetCompanyNameToEntity(result.ToList());
            }
            catch (Exception ex)
            {
                pager = new PagerInfo { RecordCount = 0 };
                return this.HandleException<List<Delivery>>("根据检索条件获取配送情报失败", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        /// <summary>
        /// 根据条件检索配送取消记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<Delivery> GetCanceledDeliveryByCondition(SalesCodeSearchInput condition, int pageindex, int pageSize, out PagerInfo pager)
        {
            try
            {
                PagerInfo pageInfo = new PagerInfo();
                pageInfo.Index = pageindex;
                pageInfo.Size = pageSize;

                pageindex = pageindex - 1;
                int skipCount = pageindex * pageSize;
                var result = this.Queryable;

                if (!string.IsNullOrWhiteSpace(condition.Code))
                    result = result.Where(p => p.CanceledNo.IndexOf(condition.Code) >= 0);
                if (condition.FromDate != null)
                    result = result.Where(p => p.CanceledTime >= condition.FromDate);
                if (condition.ToDate != null)
                    result = result.Where(p => p.CanceledTime <= condition.ToDate);
                if (condition.OperatorID != Guid.Empty)
                    result = result.Where(p => p.CanceledOperatorId == condition.OperatorID);

                pageInfo.RecordCount = result.Count();
                pager = pageInfo;
                result = result.OrderBy(o => o.CreateTime);
                result = (skipCount == 0 ? result.Take(pageSize) : result.Skip(skipCount).Take(pageSize));
                return SetCompanyNameToEntity(result.ToList());
            }
            catch (Exception ex)
            {
                pager = new PagerInfo { RecordCount = 0 };
                return this.HandleException<List<Delivery>>("根据检索条件获取配送情报失败", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        /// <summary>
        /// 根据条件检索配送出库记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<Delivery> GetOutedDeliveryByCondition(SalesCodeSearchInput condition, int pageindex, int pageSize, out PagerInfo pager)
        {
            try
            {
                PagerInfo pageInfo = new PagerInfo();
                pageInfo.Index = pageindex;
                pageInfo.Size = pageSize;

                pageindex = pageindex - 1;
                int skipCount = pageindex * pageSize;
                var result = this.Queryable;

                if (!string.IsNullOrWhiteSpace(condition.Code))
                    result = result.Where(p => p.outedNo.IndexOf(condition.Code) >= 0);
                if (condition.FromDate != null)
                    result = result.Where(p => p.outedTime >= condition.FromDate);
                if (condition.ToDate != null)
                    result = result.Where(p => p.outedTime <= condition.ToDate);
                if (condition.OperatorID != Guid.Empty)
                    result = result.Where(p => p.outedOperatorId == condition.OperatorID);

                pageInfo.RecordCount = result.Count();
                pager = pageInfo;
                result = result.OrderBy(o => o.CreateTime);
                result = (skipCount == 0 ? result.Take(pageSize) : result.Skip(skipCount).Take(pageSize));
                return SetCompanyNameToEntity(result.ToList());
            }
            catch (Exception ex)
            {
                pager = new PagerInfo { RecordCount = 0 };
                return this.HandleException<List<Delivery>>("根据检索条件获取配送情报失败", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        /// <summary>
        /// 根据条件检索配送签收记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<Delivery> GetSignedDeliveryByCondition(SalesCodeSearchInput condition, int pageindex, int pageSize, out PagerInfo pager)
        {
            try
            {
                PagerInfo pageInfo = new PagerInfo();
                pageInfo.Index = pageindex;
                pageInfo.Size = pageSize;

                pageindex = pageindex - 1;
                int skipCount = pageindex * pageSize;
                var result = this.Queryable;

                if (!string.IsNullOrWhiteSpace(condition.Code))
                    result = result.Where(p => p.SignedNo.IndexOf(condition.Code) >= 0);
                if (condition.FromDate != null)
                    result = result.Where(p => p.SignedTime >= condition.FromDate);
                if (condition.ToDate != null)
                    result = result.Where(p => p.SignedTime <= condition.ToDate);
                if (condition.OperatorID != Guid.Empty)
                    result = result.Where(p => p.SignedOperatorId == condition.OperatorID);

                pageInfo.RecordCount = result.Count();
                pager = pageInfo;
                result = result.OrderBy(o => o.CreateTime);
                result = (skipCount == 0 ? result.Take(pageSize) : result.Skip(skipCount).Take(pageSize));
                return SetCompanyNameToEntity(result.ToList());
            }
            catch (Exception ex)
            {
                pager = new PagerInfo { RecordCount = 0 };
                return this.HandleException<List<Delivery>>("根据检索条件获取配送情报失败", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        /// <summary>
        /// 根据条件检索配送销退记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<Delivery> GetReturnedDeliveryByCondition(SalesCodeSearchInput condition, int pageindex, int pageSize, out PagerInfo pager)
        {
            try
            {
                PagerInfo pageInfo = new PagerInfo();
                pageInfo.Index = pageindex;
                pageInfo.Size = pageSize;

                pageindex = pageindex - 1;
                int skipCount = pageindex * pageSize;
                var result = this.Queryable;

                if (!string.IsNullOrWhiteSpace(condition.Code))
                    result = result.Where(p => p.ReturnNo.IndexOf(condition.Code) >= 0);
                if (condition.FromDate != null)
                    result = result.Where(p => p.ReturnTime >= condition.FromDate);
                if (condition.ToDate != null)
                    result = result.Where(p => p.ReturnTime <= condition.ToDate);
                if (condition.OperatorID != Guid.Empty)
                    result = result.Where(p => p.ReturnOperatorId == condition.OperatorID);

                pageInfo.RecordCount = result.Count();
                pager = pageInfo;
                result = result.OrderBy(o => o.CreateTime);
                result = (skipCount == 0 ? result.Take(pageSize) : result.Skip(skipCount).Take(pageSize));
                return SetCompanyNameToEntity(result.ToList());
            }
            catch (Exception ex)
            {
                pager = new PagerInfo { RecordCount = 0 };
                return this.HandleException<List<Delivery>>("根据检索条件获取配送情报失败", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        /// <summary>
        /// 把配送信息里的公司名称补齐
        /// </summary>
        /// <param name="list"></param>
        private List<Delivery> SetCompanyNameToEntity(List<Delivery> list)
        {
            foreach (var item in list)
            {
                var c = this.BusinessHandlerFactory.PurchaseUnitBusinessHandler.Queryable.FirstOrDefault(p=>p.Id == item.ReceivingCompasnyID);
                if(c != null)
                {
                    item.ReceivingCompasnyName = c.Name;
                }
            }
            //BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog { Content = ConnectedInfoProvider.User.Account + "配送公司名称补齐" });

            return list;
        }

        /// <summary>
        /// 根据状态获取配送信息
        /// </summary>
        /// <returns></returns>
        public List<Delivery> GetDeliveryList(PagerInfo pager, DeliveryStatus deliveryStatus)
        {
            try
            {
                int status = (int)deliveryStatus;
                //var list = BusinessHandlerFactory.DeliveryBusinessHandler.Fetch(p => p.DeliveryStatusValue == status,
                //                                                    p => p.Queryable.OrderBy(c => c.CreateTime),
                //                                                    pager);


                var db = BusinessHandlerFactory.RepositoryProvider.Db;
                var list = db.Deliverys.Where(p => p.DeliveryStatusValue == status);

                pager.RecordCount = list.Count();
                pager.Index = pager.Index < 1 ? 1 : pager.Index;
                pager.Size = pager.Size < 1 ? 20 : pager.Size;
                if (pager.RecordCount == 0)
                {
                    pager.Index = 1;
                }
                int skip = pager.Size * (pager.Index - 1);
                int count = pager.Size;

                list = list.OrderBy(p => p.CreateTime).Skip(skip).Take(count);

                var cList = list.Select(p => db.PurchaseUnits.FirstOrDefault(c => c.Id == p.ReceivingCompasnyID).Name).ToList();

                var result = list.ToList();
                int i = 0;
                result.ForEach(p => p.ReceivingCompasnyName = cList[i++]);

                return result;
            }
            catch (Exception ex)
            {
                pager = null;
                return this.HandleException<List<Delivery>>("根据状态获取配送信息失败", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        /// <summary>
        ///  分页检索配送
        /// </summary>
        /// <param name="totalpage"></param>
        /// <param name="deliveryIndexInput"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public IEnumerable<Delivery> GetDeliveryPaged(DeliveryIndexInput deliveryIndexInput, out PagerInfo pager, int pageindex, int pageSize)
        {
            try
            {
                PagerInfo pageInfo = new PagerInfo();
                pageInfo.Index = pageindex;
                pageInfo.Size = pageSize;

                pageindex = pageindex - 1;
                int skipCount = pageindex * pageSize;
                var varDelivery = base.Queryable;
                                
                if (deliveryIndexInput.DeliveryFromDate != null)
                    varDelivery = varDelivery.Where(p => p.DeliveryTime >= deliveryIndexInput.DeliveryFromDate);
                if (deliveryIndexInput.DeliveryToDate != null)
                    varDelivery = varDelivery.Where(p => p.DeliveryTime <= deliveryIndexInput.DeliveryToDate);
                if (deliveryIndexInput.DeliveryMethodValue > -1)
                    varDelivery = varDelivery.Where(p => p.DeliveryMethodValue == deliveryIndexInput.DeliveryMethodValue);
                if (deliveryIndexInput.DeliveryStatusValue > -1)
                    varDelivery = varDelivery.Where(p => p.DeliveryStatusValue == deliveryIndexInput.DeliveryStatusValue);
                if (deliveryIndexInput.ReceivingCompasnyID != Guid.Empty)
                    varDelivery = varDelivery.Where(p => p.ReceivingCompasnyID == deliveryIndexInput.ReceivingCompasnyID);

                #region
                var saleOrders = RepositoryProvider.Db.SalesOrders.AsQueryable();
                if (!string.IsNullOrEmpty(deliveryIndexInput.OrderNumber))
                {
                    saleOrders = saleOrders.Where(r => r.OrderCode.Contains(deliveryIndexInput.OrderNumber));
                }

                var PurchaseUnits = RepositoryProvider.Db.PurchaseUnits.AsQueryable();
                if (!string.IsNullOrEmpty(deliveryIndexInput.ReceivingCompasnyName))
                {
                    PurchaseUnits = PurchaseUnits.Where(r=>r.Name.Contains(deliveryIndexInput.ReceivingCompasnyName)||(r.PinyinCode!=null && r.PinyinCode.ToUpper().Contains(deliveryIndexInput.ReceivingCompasnyName.ToUpper())));
                }

                var SalesInfo = (from i in varDelivery
                        join p in PurchaseUnits on i.ReceivingCompasnyID equals p.Id
                        join so in saleOrders on i.OrderID equals so.Id
                        select new
                        {
                            pid=p.Id,
                            pName=p.Name,
                            soid=so.Id,
                            soCode=so.OrderCode,
                            addr=string.IsNullOrEmpty(p.ReceiveAddress)?p.DetailedAddress:p.ReceiveAddress
                        }).ToList();

                var PurchaseorderReturns = RepositoryProvider.Db.PurchaseOrderReturns.AsQueryable();
                if (!string.IsNullOrEmpty(deliveryIndexInput.OrderNumber))
                {
                    PurchaseorderReturns = PurchaseorderReturns.Where(r => r.DocumentNumber.Contains(deliveryIndexInput.OrderNumber));
                }
                var SupplyUnits = RepositoryProvider.Db.SupplyUnits.AsQueryable();
                if (!string.IsNullOrEmpty(deliveryIndexInput.ReceivingCompasnyName))
                {
                    SupplyUnits = SupplyUnits.Where(r=>r.Name.Contains(deliveryIndexInput.ReceivingCompasnyName)||(r.PinyinCode!=null && r.PinyinCode.ToUpper().Contains(deliveryIndexInput.ReceivingCompasnyName.ToUpper())));
                }

                var SupplyReturnInfo = (from sr in PurchaseorderReturns                                         
                                        join  i in varDelivery on sr.Id equals i.OrderID
                                        join su in SupplyUnits on i.ReceivingCompasnyID equals su.Id
                                        select new
                                        {
                                            pid = su.Id,
                                            pName = su.Name,
                                            soid = sr.Id,
                                            soCode = sr.DocumentNumber,
                                            addr=su.ReceiveAddress==string.Empty?su.DetailedAddress:su.ReceiveAddress
                                        }).ToList();

                SalesInfo = SalesInfo.Concat(SupplyReturnInfo).ToList();

                var ListVarDelivery = varDelivery.ToList();
                foreach(var u in ListVarDelivery)
                {
                    var re = SalesInfo.FirstOrDefault(r => r.pid == u.ReceivingCompasnyID);
                    if(re==null)continue;
                    u.ReceivingCompasnyName =re.pName;

                    var sa=SalesInfo.FirstOrDefault(r => r.soid == u.OrderID);
                    if(sa==null)continue;
                    u.SalesOrder = sa.soCode;
                    
                    var su = SalesInfo.FirstOrDefault(r => r.pid == u.ReceivingCompasnyID);
                    if(su==null)continue;
                    u.DeliveryAddress = su.addr;
                }

                ListVarDelivery = ListVarDelivery.Where(r => !string.IsNullOrEmpty(r.SalesOrder)).ToList();

                varDelivery = null;
                #endregion
                
                pageInfo.RecordCount = ListVarDelivery.Count;
                pager = pageInfo;
                ListVarDelivery = ListVarDelivery.OrderBy(o => o.DeliveryTime).ToList();
                ListVarDelivery = (skipCount == 0 ? ListVarDelivery.Take(pageSize) : ListVarDelivery.Skip(skipCount).Take(pageSize)).ToList();

                return ListVarDelivery.OrderByDescending(r=>r.CreateTime).AsEnumerable();
            }
            catch (Exception ex)
            {
                pager = null;
                return this.HandleException<IEnumerable<Delivery>>("分页检索配送失败", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public System.Collections.Generic.IEnumerable<Business.Models.DeliveryTrasactionModel> GetDeliveryTransactionPaged(Business.Models.DeliveryIndexInput deliveryIndexInput, out BugsBox.Application.Core.PagerInfo pager, int pageindex, int pageSize)
        {
            PagerInfo pageInfo = new PagerInfo();
            pageInfo.Index = pageindex;
            pageInfo.Size = pageSize;

            pageindex = pageindex - 1;
            int skipCount = pageindex * pageSize;
            var varDelivery = base.Queryable;

            if (deliveryIndexInput.DeliveryStatusValue > -1)
                varDelivery = varDelivery.Where(p => p.DeliveryStatusValue == deliveryIndexInput.DeliveryStatusValue);

            var c = from i in varDelivery
                    join s in RepositoryProvider.Db.SalesOrders.Include(r=>r.PurchaseUnit) on i.OrderID equals s.Id
                    join o in RepositoryProvider.Db.OutInventorys.Include(r => r.SalesOutInventoryDetails)
                    on i.OutInventoryID equals o.Id
                    select new Business.Models.DeliveryTrasactionModel
                    {
                        Id=i.Id,
                        OutInvetoryDocumentNumber=o.OrderOutInventoryCheckNumber,
                        OutInvetoryId=o.Id,
                        SalesOrderDocumentNumber = s.OrderCode,
                        ReceivingCompasnyID=s.PurchaseUnitId,
                        OutInventoryNumber=o.SalesOutInventoryDetails.Sum(r=>r.OutAmount),
                        SalesOrderId=s.Id,
                        ReceivingCompasnyName=s.PurchaseUnit.Name,
                        OutInventoryDateTime=i.CreateTime,
                        Status=0,
                    };
            var cc = from i in varDelivery
                     join pr in RepositoryProvider.Db.PurchaseOrderReturns.Include(r=>r.PurchaseOrderReturnDetails) on i.OrderID equals pr.Id
                     join s in RepositoryProvider.Db.PurchaseOrders.Include(r => r.SupplyUnit) on pr.PurchaseOrderId equals s.Id
                     select new Business.Models.DeliveryTrasactionModel
                     {
                         Id = i.Id,
                         OutInvetoryDocumentNumber = pr.DocumentNumber,
                         OutInvetoryId = s.Id,
                         SalesOrderDocumentNumber = pr.DocumentNumber,
                         ReceivingCompasnyID = s.SupplyUnitId,
                         OutInventoryNumber = pr.PurchaseOrderReturnDetails.Sum(r=>r.ReturnAmount),
                         SalesOrderId = s.Id,
                         ReceivingCompasnyName = s.SupplyUnit.Name,
                         OutInventoryDateTime = i.CreateTime,
                         Status = 1,
                     };

            c =cc.Count()>0? c.Concat(cc):c;  //合并采退和销售数据

            if (!string.IsNullOrEmpty(deliveryIndexInput.OrderNumber))
            {
                c = c.Where(r => r.OutInvetoryDocumentNumber.Contains(deliveryIndexInput.OrderNumber)||r.SalesOrderDocumentNumber.Contains(deliveryIndexInput.OrderNumber));
            }

            if (!string.IsNullOrEmpty(deliveryIndexInput.ReceivingCompasnyName))
            {
                c = c.Where(r => r.ReceivingCompasnyName.Contains(deliveryIndexInput.ReceivingCompasnyName));
            }

            pageInfo.RecordCount = c.Count();
            pager = pageInfo;

            c = c.OrderBy(r => r.OutInventoryDateTime);

            c= (skipCount == 0 ? c.Take(pageSize) : c.Skip(skipCount).Take(pageSize));
            return c;
        }

        /// <summary>
        ///  提交配送信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public void SubmitDelivery(Delivery delivery)
        {
            try
            {
                this.Save(delivery);
                //更新车辆信息
                if (delivery.VehicleID != Guid.Empty)
                {
                    var vehicle = BusinessHandlerFactory.VehicleBusinessHandler.Get(delivery.VehicleID);
                    vehicle.Status = true; //设置状态为不可用
                    BusinessHandlerFactory.VehicleBusinessHandler.Save(vehicle);
                }
                this.Save();
            }
            catch (Exception ex)
            {
                this.HandleException(" 提交配送信息处理失败", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        /// <summary>
        ///  更新配送信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public void UpdateDelivery(Delivery delivery)
        {
            try
            {
                //更新配送信息表
                this.Save(delivery);

                if (delivery.DeliveryStatus == DeliveryStatus.Outed)
                {
                    if (delivery.OutInventoryID != Guid.Empty)
                    {
                        OutInventory oi = BusinessHandlerFactory.OutInventoryBusinessHandler.Get(delivery.OutInventoryID);

                        SalesOrder so = BusinessHandlerFactory.SalesOrderBusinessHandler.Get(oi.SalesOrderID);
                        so.OrderStatusValue = OrderStatus.Delivering.GetHashCode();
                        //更新库存信息
                        
                        List<OutInventoryDetail> outInventoryList = BusinessHandlerFactory.OutInventoryDetailBusinessHandler.Fetch(p => p.SalesOutInventoryID == delivery.OutInventoryID).ToList();
                        foreach (OutInventoryDetail item in outInventoryList)
                        {
                            Guid drugInventoryID = item.DrugInventoryRecordID;
                            decimal outQty = item.OutAmount;
                            //获取药物库存实体                    
                            DrugInventoryRecord drugInventory = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(drugInventoryID);
                            //在销售单但未出库数量 累计当前订单明细数量
                            drugInventory.SalesCount += outQty;
                            drugInventory.CurrentInventoryCount -= outQty;
                            drugInventory.OnSalesOrderCount -= outQty;
                            drugInventory.Valid = drugInventory.CanSaleNum > 0;
                            BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(drugInventory);

                            //获取库存实体
                            InventoryRecord inventory = BusinessHandlerFactory.InventoryRecordBusinessHandler.GetInventoryRecordByDrugInfoID(drugInventory.DrugInfoId);
                            if (inventory != null) //应该能为NULL,Debug中却出现了.
                            {
                                //在销售单但未出库数量 累计当前订单明细数量
                                inventory.SalesCount += outQty;
                                inventory.CurrentInventoryCount -= outQty;
                                inventory.OnSalesOrderCount -= outQty;
                                BusinessHandlerFactory.InventoryRecordBusinessHandler.Save(inventory);
                            }
                        }
                    }
                }
                //签收后
                if (delivery.DeliveryStatus == DeliveryStatus.Signed)
                {
                    //更新车辆信息
                    if (delivery.VehicleID != Guid.Empty)
                    {
                        var vehicle = BusinessHandlerFactory.VehicleBusinessHandler.Get(delivery.VehicleID);
                        vehicle.Status = false; //设置状态为可用
                        BusinessHandlerFactory.VehicleBusinessHandler.Save(vehicle);
                    }
                }
                this.Save();
            }
            catch (Exception ex)
            {
                this.HandleException("更新配送信息失败", ex);
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        ///  通过订单表更新库存表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private void UpdateInventoryByOrderInfo(Guid orderID)
        {
            try
            {
                var db = BusinessHandlerFactory.RepositoryProvider.Db;

                //获取订单信息和库存信息的集合
                var list = db.SalesOrderDetails.Where(p => p.Id == orderID)
                                      .Join(db.InventoryRecords,
                                            l => l.DrugInventoryRecordID, r => r.Id,
                                            (l, r) => new { Amount = l.Amount, InvertoryInfo = r }).ToList();

                foreach (var item in list)
                {
                    item.InvertoryInfo.CurrentInventoryCount -= item.Amount;
                    item.InvertoryInfo.OnSalesOrderCount -= item.Amount;
                    item.InvertoryInfo.SalesCount += item.Amount;

                    var drugIn = db.DrugInventoryRecords.First(p => p.DrugInfoId == item.InvertoryInfo.DrugInfoId);
                    drugIn.CurrentInventoryCount -= item.Amount;
                    drugIn.OnSalesOrderCount -= item.Amount;
                    drugIn.SalesCount += item.Amount;
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose();
            }
        }
    }
}

