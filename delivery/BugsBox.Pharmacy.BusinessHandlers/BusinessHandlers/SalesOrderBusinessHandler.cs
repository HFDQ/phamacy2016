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
    partial class SalesOrderBusinessHandler
    {
        public readonly static object LockObj = new object();
        protected override IQueryable<SalesOrder> IncludeNavigationProperties(IQueryable<SalesOrder> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable.Include(u => u.SalesOrderDetails));
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<SalesOrder>>(ex.Message, ex);
            }

        }
        /// <summary>
        /// 根据状态获取订单信息
        /// </summary>
        /// <returns></returns>
        public List<SalesOrder> GetOrderStatusList(List<int> orderStatusList)
        {
            try
            {
                return this.Fetch(p => orderStatusList.Contains(p.OrderStatusValue)).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<SalesOrder>>("根据状态获取订单信息失败", ex);
            }
        }
        /// <summary>
        ///  新增一条订单和订单明细记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public void AddSalesOrderAndDetails(SalesOrder so)
        {
            string outDetail = string.Empty;
            try
            {
                lock (LockObj)
                {
                    //增加销售记录
                    IEnumerable<SalesOrderDetail> sodList = so.SalesOrderDetails;
                    so.CreateTime = DateTime.Now;
                    so.UpdateTime = DateTime.Now;

                    if (so.SaleDate < DateTime.Now.Date)
                    {
                        outDetail = "销售日期错误，小于服务器日期，请调整时间！";
                        throw new Exception("日期错误！");
                    }

                    so.SalesOrderDetails = null;
                    so.OrderCode = BusinessHandlerFactory.BillDocumentCodeBusinessHandler.GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.SalesOrder).Code;
                    this.Add(so);
                    int idx = 1;
                    //增加销售记录明细
                    foreach (SalesOrderDetail sod in sodList)
                    {
                        Guid drugInventoryID = sod.DrugInventoryRecordID;
                        decimal consumeQty = sod.Amount;
                        //获取药物库存实体
                        DrugInventoryRecord drugInventory = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(drugInventoryID);
                        string BatchNumber = drugInventory.BatchNumber.IndexOf("(") < 0 ? drugInventory.BatchNumber : drugInventory.BatchNumber.Substring(0, drugInventory.BatchNumber.LastIndexOf("("));

                        List<DrugInventoryRecord> list = RepositoryProvider.Db.DrugInventoryRecords.Where(r => r.DrugInfoId == drugInventory.DrugInfoId && r.BatchNumber.StartsWith(BatchNumber) && r.Decription == drugInventory.Decription && r.CanSaleNum > 0 && r.PurchasePricce == drugInventory.PurchasePricce).OrderBy(r => r.CanSaleNum).ToList();

                        decimal saleAmount = sod.Amount;

                        SalesOrderDetail sodetail = null;

                        if (saleAmount <= list.Sum(r => r.CanSaleNum))
                        {
                            foreach (var c in list)
                            {
                                decimal cansaleNumb = c.CanSaleNum;
                                decimal onsalec = c.CanSaleNum >= saleAmount ? saleAmount : c.CanSaleNum;
                                c.OnSalesOrderCount += onsalec;
                                c.Valid = c.CanSaleNum > 0;
                                BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(c);

                                sodetail = new SalesOrderDetail();

                                sodetail.Id = Guid.NewGuid();
                                sodetail.Amount = onsalec;
                                sodetail.ActualUnitPrice = sod.ActualUnitPrice;
                                sodetail.BatchNumber = c.BatchNumber;
                                sodetail.ChangeAmount = sod.ChangeAmount;
                                sodetail.CreateTime = DateTime.Now;
                                sodetail.CreateUserId = sod.CreateUserId;
                                sodetail.Deleted = false;
                                sodetail.Description = c.Decription;
                                sodetail.DictionaryDosageCode = sod.DictionaryDosageCode;
                                sodetail.DrugInventoryRecordID = c.Id;
                                sodetail.FactoryName = sod.FactoryName;
                                sodetail.Index = idx;
                                sodetail.MeasurementUnit = sod.MeasurementUnit;
                                sodetail.Origin = sod.Origin;
                                sodetail.OutAmount = 0;
                                sodetail.OutInventoryDetailID = sod.OutInventoryDetailID;
                                sodetail.OutValidDate = c.OutValidDate;
                                sodetail.Price = sodetail.Amount * sodetail.ActualUnitPrice;
                                sodetail.productCode = sod.productCode;
                                sodetail.productName = sod.productName;
                                sodetail.PruductDate = sod.PruductDate;
                                sodetail.ReturnAmount = sod.ReturnAmount;
                                sodetail.SalesOrderID = sod.SalesOrderID;
                                sodetail.SpecificationCode = sod.SpecificationCode;
                                sodetail.StoreId = sod.StoreId;
                                sodetail.UnitPrice = sod.UnitPrice;
                                sodetail.UpdateTime = DateTime.Now;
                                sodetail.UpdateUserId = sod.CreateUserId;

                                idx++;
                                if (sodetail.Amount > 0)
                                    BusinessHandlerFactory.SalesOrderDetailBusinessHandler.Add(sodetail);
                                saleAmount -= cansaleNumb;
                                if (saleAmount <= 0) break;
                            }
                            idx++;
                        }
                        else
                        {
                            outDetail = sod.productName + "( " + sod.FactoryName + ")" + "批号：" + sod.BatchNumber + "库存数量不足，请修改。";
                            throw new Exception(sod.productName + "库存数量不足");
                        }

                    }

                    this.Save();
                }
            }
            catch (Exception ex)
            {
                this.HandleException("新增订单和订单明细出错失败!" + outDetail, ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        /// <summary>
        ///  修改一条订单和订单明细记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public void ModifySalesOrderAndDetails(SalesOrder so)
        {
            string outDetail = string.Empty;
            try
            {
                //增加销售记录
                List<SalesOrderDetail> sodList = so.SalesOrderDetails.ToList();
                so.UpdateTime = DateTime.Now;
                so.SalesOrderDetails = null;
                this.Save(so);
                List<SalesOrderDetail> salesOrderDetailList = this.Get(so.Id).SalesOrderDetails.Where(r => r.Deleted == false).ToList();
                int index = 0;
                //删除记录
                foreach (var c in salesOrderDetailList)
                {
                    var iExist = sodList.FirstOrDefault(r => r.DrugInventoryRecordID == c.DrugInventoryRecordID);
                    if (iExist == null)
                    {
                        BusinessHandlerFactory.SalesOrderDetailBusinessHandler.Delete(c.Id);
                        DrugInventoryRecord dir = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(c.DrugInventoryRecordID);


                        //库存中的onsalecount字段减去

                        dir.OnSalesOrderCount -= c.Amount;


                        dir.Valid = dir.CanSaleNum > 0 ? true : false;//如果库存数量大于0则解锁

                        BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(dir);

                        dir = null;
                    }
                }
                //新增和修改
                foreach (SalesOrderDetail item in sodList)
                {
                    DrugInventoryRecord dir = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(item.DrugInventoryRecordID);

                    var c = sodList.Where(r => r.Id == item.Id).First();
                    var u = salesOrderDetailList.Where(r => r.Id == item.Id).FirstOrDefault();
                    //如果U存在，则表示需要修改记录
                    if (u != null)
                    {
                        //库存中需要修改为当前数量
                        dir.OnSalesOrderCount += item.Amount - u.Amount;

                        u.Amount = c.Amount;
                        u.ActualUnitPrice = c.ActualUnitPrice;
                        u.Price = c.Price;
                        u.ChangeAmount = c.ChangeAmount;
                        index++;
                        BusinessHandlerFactory.SalesOrderDetailBusinessHandler.Save(u);
                    }
                    else
                    {
                        SalesOrderDetail sodetail = new SalesOrderDetail();
                        sodetail.Id = Guid.NewGuid();
                        sodetail.Amount = item.Amount;
                        sodetail.ActualUnitPrice = item.ActualUnitPrice;
                        sodetail.BatchNumber = item.BatchNumber;
                        sodetail.ChangeAmount = item.ChangeAmount;
                        sodetail.CreateTime = DateTime.Now;
                        sodetail.CreateUserId = item.CreateUserId;
                        sodetail.Deleted = item.Deleted;
                        sodetail.Description = item.Description;
                        sodetail.DictionaryDosageCode = item.DictionaryDosageCode;
                        sodetail.DrugInventoryRecordID = item.DrugInventoryRecordID;
                        sodetail.FactoryName = item.FactoryName;
                        sodetail.Index = index;
                        sodetail.MeasurementUnit = item.MeasurementUnit;
                        sodetail.Origin = item.Origin;
                        sodetail.OutAmount = 0;
                        sodetail.OutInventoryDetailID = item.OutInventoryDetailID;
                        sodetail.OutValidDate = item.OutValidDate;
                        sodetail.Price = item.Price;
                        sodetail.productCode = item.productCode;
                        sodetail.productName = item.productName;
                        sodetail.PruductDate = item.PruductDate;
                        sodetail.ReturnAmount = item.ReturnAmount;
                        sodetail.SalesOrderID = item.SalesOrderID;
                        sodetail.SpecificationCode = item.SpecificationCode;
                        sodetail.StoreId = item.StoreId;
                        sodetail.UnitPrice = item.UnitPrice;
                        sodetail.UpdateTime = DateTime.Now;
                        sodetail.UpdateUserId = item.CreateUserId;
                        index++;
                        BusinessHandlerFactory.SalesOrderDetailBusinessHandler.Add(sodetail);

                        dir.OnSalesOrderCount += item.Amount;

                    }
                    if (dir.CanSaleNum < 0)
                    {
                        outDetail = item.productName + "(" + item.FactoryName + ")" + "批号：" + item.BatchNumber;
                        throw new Exception(outDetail + "库存不足，无法修改！");
                    }
                    dir.Valid = dir.CanSaleNum > 0 ? true : false;//如果库存数量大于0则解锁
                    BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(dir);

                    dir = null;

                }

                this.Save();
            }
            catch (Exception ex)
            {
                this.HandleException("修改一条订单和订单明细记录失败", ex);
            }
            finally
            {
                this.Dispose();
            }
        }


        /// <summary>
        ///  删除一条订单和订单明细记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public void DeleteSalesOrderAndDetails(Guid salesOrderID)
        {
            try
            {
                //增加销售记录
                this.Delete(salesOrderID);

                List<SalesOrderDetail> salesOrderDetailList = this.Get(salesOrderID).SalesOrderDetails.ToList();
                foreach (SalesOrderDetail item in salesOrderDetailList)
                {
                    Guid drugInventoryID = item.DrugInventoryRecordID;
                    decimal consumeQty = item.Amount;
                    //获取药物库存实体
                    DrugInventoryRecord drugInventory = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(drugInventoryID);
                    //存库存表的当前可用库存扣掉该订单明细数量
                    //drugInventory.CurrentInventoryCount = drugInventory.CurrentInventoryCount + item.Amount;
                    //在销售单但未出库数量 累计当前订单明细数量
                    drugInventory.OnSalesOrderCount = drugInventory.OnSalesOrderCount - item.Amount;

                    BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(drugInventory);



                    //删除订单明细
                    BusinessHandlerFactory.SalesOrderDetailBusinessHandler.Delete(item.Id);
                }

                this.Save();

            }
            catch (Exception ex)
            {
                this.HandleException("删除一条订单和订单明细记录失败", ex);
            }
        }


        /// <summary>
        ///  根据订单状态返回订单信息
        /// </summary>
        /// <param name="statusValue"></param>
        /// <returns></returns>
        public IEnumerable<SalesOrder> GetSalesOrderByStatus(int statusValue)
        {
            try
            {
                return this.Fetch(p => p.OrderStatusValue == statusValue).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<IEnumerable<SalesOrder>>("方法根据订单状态返回订单信息出错失败", ex);

            }
        }


        /// <summary>
        ///  根据订单号模糊查询返回订单
        /// </summary>
        /// <param name="statusValue"></param>
        /// <returns></returns>
        public IEnumerable<SalesOrder> GetSalesOrderByOrderCode(string code)
        {
            try
            {
                return this.Fetch(p => p.OrderCode.IndexOf(code) >= 0).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<IEnumerable<SalesOrder>>("方法根据订单号模糊查询返回订单失败", ex);

            }
        }

        /// <summary>
        /// 统计销售订单
        /// </summary>
        /// <returns></returns>
        public List<SalesOrderStatisticOutput> AddupSalesOrder(SalesOrderStatisticInput input)
        {
            List<SalesOrderStatisticOutput> result = null;
            var db = Queryable;

            try
            {
                var format = (input.TimeUnit == (int)StatisticTimeUnit.Month) ? "yyyy年MM月" : "yyyy年";

                #region 按销售员
                if (input.StatisticObject == (int)StatisticObject.Seller)
                {
                    var c = from i in this.Queryable
                            where i.BalanceTime != null && i.BalanceTime >= input.FromDate && i.BalanceTime <= input.ToDate && i.Deleted == false && i.OrderStatusValue != 4
                            select new
                            {
                                salerName = i.SalerName,
                                InvoiceMoney = i.SalesOrderDetails.Where(r => r.Deleted == false).Sum(r => r.ActualUnitPrice * r.Amount),
                                unitMoney = i.SalesOrderDetails.Where(r => r.Deleted == false).Sum(r => r.UnitPrice * r.Amount),
                                returnMoney = 0m,
                                returnUnitMoney = 0m,
                                saleDate = (DateTime)i.BalanceTime,
                                saleNum = i.SalesOrderDetails.Sum(r => r.Amount),
                                returnSaleNum = 0m
                            };
                    var cc = from i in RepositoryProvider.Db.SalesOrderReturns
                             where i.OrderReturnStatusValue != 9 && i.OrderReturnCheckTime >= input.FromDate && i.OrderReturnCheckTime <= input.ToDate
                             join j in RepositoryProvider.Db.SalesOrders on i.SalesOrderID equals j.Id
                             select new
                             {
                                 salerName = j.SalerName,
                                 InvoiceMoney = 0m,
                                 unitMoney = 0m,
                                 returnMoney = i.SalesOrderReturnDetails.Sum(r => r.ReturnAmount * r.ActualUnitPrice),
                                 returnUnitMoney = i.SalesOrderReturnDetails.Sum(r => r.ReturnAmount * r.UnitPrice),
                                 saleDate = (DateTime)(i.OrderReturnCheckTime),
                                 saleNum = 0m,
                                 returnSaleNum = i.SalesOrderReturnDetails.Sum(r => r.ReturnAmount)
                             };

                    result = c.ToList().Concat(cc.ToList()).GroupBy(p => p.salerName)
                                .Select(p => new SalesOrderStatisticOutput
                                {
                                    StatisticObject = "销售员",
                                    SalerName = p.Key,
                                    Count = p.Count(),
                                    Sum = p.Sum(r => r.InvoiceMoney),
                                    CostSum = p.Sum(r => r.unitMoney),
                                    ReturnSum = p.Sum(r => r.returnMoney),
                                    ReturnCostSum = p.Sum(r => r.returnUnitMoney),
                                    SaleNum = p.Sum(r => r.saleNum),
                                    ReturnSaleNum = p.Sum(r => r.returnSaleNum),
                                    SaleNumSum = p.Sum(r => r.saleNum) - p.Sum(r => r.returnSaleNum)
                                }).ToList();

                    return result;
                }
                #endregion

                #region 按购货商
                if (input.StatisticObject == (int)StatisticObject.Buyer)
                {
                    var c = from i in this.Queryable
                            where i.BalanceTime != null && i.BalanceTime >= input.FromDate && i.BalanceTime <= input.ToDate && i.Deleted == false && i.OrderStatusValue != 4
                            join j in RepositoryProvider.Db.PurchaseUnits on i.PurchaseUnitId equals j.Id
                            select new
                            {
                                Purchaser = j.Name,
                                InvoiceMoney = i.SalesOrderDetails.Where(r => r.Deleted == false).Sum(r => r.ActualUnitPrice * r.Amount),
                                unitMoney = i.SalesOrderDetails.Where(r => r.Deleted == false).Sum(r => r.UnitPrice * r.Amount),
                                returnMoney = 0m,
                                returnUnitMoney = 0m,
                                saleDate = (DateTime)i.BalanceTime,
                                saleNum = i.SalesOrderDetails.Sum(r => r.Amount),
                                returnSaleNum = 0m
                            };

                    var cc = from i in RepositoryProvider.Db.SalesOrderReturns
                             where i.OrderReturnStatusValue != 9 && i.OrderReturnCheckTime >= input.FromDate && i.OrderReturnCheckTime <= input.ToDate
                             join j in RepositoryProvider.Db.SalesOrders on i.SalesOrderID equals j.Id
                             join k in RepositoryProvider.Db.PurchaseUnits on j.PurchaseUnitId equals k.Id
                             select new
                             {
                                 Purchaser = k.Name,
                                 InvoiceMoney = 0m,
                                 unitMoney = 0m,
                                 returnMoney = i.SalesOrderReturnDetails.Sum(r => r.ReturnAmount * r.ActualUnitPrice),
                                 returnUnitMoney = i.SalesOrderReturnDetails.Sum(r => r.ReturnAmount * r.UnitPrice),
                                 saleDate = (DateTime)(i.OrderReturnCheckTime),
                                 saleNum = 0m,
                                 returnSaleNum = i.SalesOrderReturnDetails.Sum(r => r.ReturnAmount)
                             };

                    result = c.ToList().Concat(cc.ToList()).GroupBy(p => p.Purchaser)
                                .Select(p => new SalesOrderStatisticOutput
                                {
                                    StatisticObject = "购货商",
                                    PurchaseUnitName = p.FirstOrDefault().Purchaser,
                                    Count = p.Count(),
                                    Sum = p.Sum(r => r.InvoiceMoney),
                                    CostSum = p.Sum(r => r.unitMoney),
                                    ReturnSum = p.Sum(r => r.returnMoney),
                                    ReturnCostSum = p.Sum(r => r.returnUnitMoney),
                                    SaleNum = p.Sum(r => r.saleNum),
                                    ReturnSaleNum = p.Sum(r => r.returnSaleNum),
                                    SaleNumSum = p.Sum(r => r.saleNum) - p.Sum(r => r.returnSaleNum)

                                }).ToList();

                    return result;
                }
                #endregion

                #region 按药品
                if (input.StatisticObject == (int)StatisticObject.Drug)
                {
                    var c = from i in this.Queryable
                            where i.BalanceTime != null && i.BalanceTime >= input.FromDate && i.BalanceTime <= input.ToDate && i.Deleted == false && i.OrderStatusValue != 4
                            join sd in RepositoryProvider.Db.SalesOrderDetails.Where(r => r.Deleted == false) on i.Id equals sd.SalesOrderID
                            join di in RepositoryProvider.Db.DrugInventoryRecords on sd.DrugInventoryRecordID equals di.Id
                            join druginfo in RepositoryProvider.Db.DrugInfos on di.DrugInfoId equals druginfo.Id
                            join w in RepositoryProvider.Db.WarehouseZones on di.WarehouseZoneId equals w.Id
                            select new
                            {
                                InvoiceMoney = sd.Amount * sd.ActualUnitPrice,
                                unitMoney = sd.Amount * sd.UnitPrice,
                                saleDate = (DateTime)(i.BalanceTime),
                                wareHouse = w.Name,
                                drugname = druginfo.ProductGeneralName,
                                drugid = druginfo.Id,
                                dosage = druginfo.DictionaryDosageCode,
                                specific = druginfo.DictionarySpecificationCode,
                                businesstype = druginfo.BusinessScopeCode,
                                factoryname = druginfo.FactoryName,
                                Origin = di.Decription == string.Empty ? druginfo.Origin : di.Decription,
                                permitNumber = druginfo.LicensePermissionNumber,
                                returnInvoiceMoney = 0m,
                                returnUnitMoney = 0m,
                                saleNum = sd.Amount,
                                returnSaleNum = 0m
                            };
                    var cc = from i in RepositoryProvider.Db.SalesOrderReturns
                             where i.OrderReturnStatusValue != 9 && i.OrderReturnCheckTime >= input.FromDate && i.OrderReturnCheckTime <= input.ToDate
                             join rd in RepositoryProvider.Db.SalesOrderReturnDetails on i.Id equals rd.OrderReturnID
                             //into left
                             //from j in left.DefaultIfEmpty()
                             join di in RepositoryProvider.Db.DrugInventoryRecords on rd.DrugInventoryRecordID equals di.Id
                             join druginfo in RepositoryProvider.Db.DrugInfos on di.DrugInfoId equals druginfo.Id
                             join w in RepositoryProvider.Db.WarehouseZones on di.WarehouseZoneId equals w.Id
                             select new
                             {
                                 InvoiceMoney = 0m,
                                 unitMoney = 0m,
                                 saleDate = (DateTime)(i.OrderReturnCheckTime),
                                 wareHouse = w.Name,
                                 drugname = druginfo.ProductGeneralName,
                                 drugid = druginfo.Id,
                                 dosage = druginfo.DictionaryDosageCode,
                                 specific = druginfo.DictionarySpecificationCode,
                                 businesstype = druginfo.BusinessScopeCode,
                                 factoryname = druginfo.FactoryName,
                                 Origin = di.Decription == string.Empty ? druginfo.Origin : di.Decription,
                                 permitNumber = druginfo.LicensePermissionNumber,
                                 returnInvoiceMoney = rd.ReturnAmount * rd.ActualUnitPrice,
                                 returnUnitMoney = rd.ReturnAmount * rd.UnitPrice,
                                 saleNum = 0m,
                                 returnSaleNum = rd.ReturnAmount
                             };

                    result = c.ToList().Concat(cc.ToList()).GroupBy(p => p.drugid)
                                .Select(p => new SalesOrderStatisticOutput
                                {
                                    StatisticObject = "品种",
                                    DrugName = p.FirstOrDefault().drugname,
                                    BusinessType = p.FirstOrDefault().businesstype,
                                    Dosage = p.FirstOrDefault().dosage,
                                    FactoryName = p.FirstOrDefault().factoryname,
                                    Origin = p.FirstOrDefault().Origin,
                                    PermitNumber = p.FirstOrDefault().permitNumber,
                                    Specific = p.FirstOrDefault().specific,
                                    WareHouseZone = p.FirstOrDefault().wareHouse,
                                    Count = p.Count(),
                                    Sum = p.Sum(r => r.InvoiceMoney),
                                    CostSum = p.Sum(r => r.unitMoney),
                                    ReturnSum = p.Sum(r => r.returnInvoiceMoney),
                                    ReturnCostSum = p.Sum(r => r.returnUnitMoney),
                                    SaleNum = p.Sum(r => r.saleNum),
                                    ReturnSaleNum = p.Sum(r => r.returnSaleNum),
                                    SaleNumSum = p.Sum(r => r.saleNum) - p.Sum(r => r.returnSaleNum)
                                }).ToList();

                    return result.ToList();
                }
                #endregion
                #region 按仓库库位
                if (input.StatisticObject == (int)StatisticObject.WareHouseZone)
                {
                    var c = from i in this.Queryable
                            where i.BalanceTime != null && i.BalanceTime >= input.FromDate && i.BalanceTime <= input.ToDate && i.Deleted == false && i.OrderStatusValue != 4
                            join sd in RepositoryProvider.Db.SalesOrderDetails.Where(r => r.Deleted == false) on i.Id equals sd.SalesOrderID
                            join di in RepositoryProvider.Db.DrugInventoryRecords on sd.DrugInventoryRecordID equals di.Id
                            join druginfo in RepositoryProvider.Db.DrugInfos on di.DrugInfoId equals druginfo.Id
                            join w in RepositoryProvider.Db.WarehouseZones on di.WarehouseZoneId equals w.Id
                            select new
                            {
                                InvoiceMoney = sd.Amount * sd.ActualUnitPrice,
                                unitMoney = sd.Amount * sd.UnitPrice,
                                saleDate = (DateTime)(i.BalanceTime),
                                wareHouse = w.Name,
                                returnInvoiceMoney = 0m,
                                returnUnitMoney = 0m,
                                saleNum = sd.Amount,
                                returnSaleNum = 0m
                            };
                    var cc = from i in RepositoryProvider.Db.SalesOrderReturns
                             where i.OrderReturnStatusValue != 9 && i.OrderReturnCheckTime >= input.FromDate && i.OrderReturnCheckTime <= input.ToDate
                             join rd in RepositoryProvider.Db.SalesOrderReturnDetails on i.Id equals rd.OrderReturnID

                             join di in RepositoryProvider.Db.DrugInventoryRecords on rd.DrugInventoryRecordID equals di.Id
                             join druginfo in RepositoryProvider.Db.DrugInfos on di.DrugInfoId equals druginfo.Id
                             join w in RepositoryProvider.Db.WarehouseZones on di.WarehouseZoneId equals w.Id
                             select new
                             {
                                 InvoiceMoney = 0m,
                                 unitMoney = 0m,
                                 saleDate = (DateTime)(i.OrderReturnCheckTime),
                                 wareHouse = w.Name,
                                 returnInvoiceMoney = rd.ReturnAmount * rd.ActualUnitPrice,
                                 returnUnitMoney = rd.ReturnAmount * rd.UnitPrice,
                                 saleNum = 0m,
                                 returnSaleNum = rd.ReturnAmount
                             };

                    result = c.ToList().Concat(cc.ToList()).GroupBy(p => p.wareHouse)
                                .Select(p => new SalesOrderStatisticOutput
                                {
                                    StatisticObject = "仓库货位",
                                    WareHouseZone = p.FirstOrDefault().wareHouse,
                                    Count = p.Count(),
                                    Sum = p.Sum(r => r.InvoiceMoney),
                                    CostSum = p.Sum(r => r.unitMoney),
                                    ReturnSum = p.Sum(r => r.returnInvoiceMoney),
                                    ReturnCostSum = p.Sum(r => r.returnUnitMoney),
                                    SaleNum = p.Sum(r => r.saleNum),
                                    ReturnSaleNum = p.Sum(r => r.returnSaleNum),
                                    SaleNumSum = p.Sum(r => r.saleNum) - p.Sum(r => r.returnSaleNum)
                                }).ToList();

                    return result.ToList();
                }
                #endregion

                #region 按经营范围
                if (input.StatisticObject == (int)StatisticObject.BussinessType)
                {
                    var c = from i in this.Queryable
                            where i.BalanceTime != null && i.BalanceTime >= input.FromDate && i.BalanceTime <= input.ToDate && i.Deleted == false && i.OrderStatusValue != 4
                            join sd in RepositoryProvider.Db.SalesOrderDetails.Where(r => r.Deleted == false) on i.Id equals sd.SalesOrderID
                            join di in RepositoryProvider.Db.DrugInventoryRecords on sd.DrugInventoryRecordID equals di.Id
                            join druginfo in RepositoryProvider.Db.DrugInfos on di.DrugInfoId equals druginfo.Id
                            join w in RepositoryProvider.Db.WarehouseZones on di.WarehouseZoneId equals w.Id
                            select new
                            {
                                InvoiceMoney = sd.Amount * sd.ActualUnitPrice,
                                unitMoney = sd.Amount * sd.UnitPrice,
                                saleDate = (DateTime)(i.BalanceTime),
                                wareHouse = w.Name,
                                drugname = druginfo.ProductGeneralName,
                                drugid = druginfo.Id,
                                dosage = druginfo.DictionaryDosageCode,
                                specific = druginfo.DictionarySpecificationCode,
                                businesstype = druginfo.BusinessScopeCode,
                                factoryname = druginfo.FactoryName,
                                Origin = di.Decription == string.Empty ? druginfo.Origin : di.Decription,
                                permitNumber = druginfo.LicensePermissionNumber,
                                returnInvoiceMoney = 0m,
                                returnUnitMoney = 0m,
                                saleNum = sd.Amount,
                                returnSaleNum = 0m
                            };
                    var cc = from i in RepositoryProvider.Db.SalesOrderReturns
                             where i.OrderReturnStatusValue != 9 && i.OrderReturnCheckTime >= input.FromDate && i.OrderReturnCheckTime <= input.ToDate
                             join rd in RepositoryProvider.Db.SalesOrderReturnDetails on i.Id equals rd.OrderReturnID

                             join di in RepositoryProvider.Db.DrugInventoryRecords on rd.DrugInventoryRecordID equals di.Id
                             join druginfo in RepositoryProvider.Db.DrugInfos on di.DrugInfoId equals druginfo.Id
                             join w in RepositoryProvider.Db.WarehouseZones on di.WarehouseZoneId equals w.Id
                             select new
                             {
                                 InvoiceMoney = 0m,
                                 unitMoney = 0m,
                                 saleDate = (DateTime)(i.OrderReturnCheckTime),
                                 wareHouse = w.Name,
                                 drugname = druginfo.ProductGeneralName,
                                 drugid = druginfo.Id,
                                 dosage = druginfo.DictionaryDosageCode,
                                 specific = druginfo.DictionarySpecificationCode,
                                 businesstype = druginfo.BusinessScopeCode,
                                 factoryname = druginfo.FactoryName,
                                 Origin = di.Decription == string.Empty ? druginfo.Origin : di.Decription,
                                 permitNumber = druginfo.LicensePermissionNumber,
                                 returnInvoiceMoney = rd.ReturnAmount * rd.ActualUnitPrice,
                                 returnUnitMoney = rd.ReturnAmount * rd.UnitPrice,
                                 saleNum = 0m,
                                 returnSaleNum = rd.ReturnAmount
                             };

                    result = c.ToList().Concat(cc.ToList()).GroupBy(p => p.businesstype)
                                .Select(p => new SalesOrderStatisticOutput
                                {
                                    StatisticObject = "经营范围",
                                    BusinessType = p.FirstOrDefault().businesstype,
                                    Count = p.Count(),
                                    Sum = p.Sum(r => r.InvoiceMoney),
                                    CostSum = p.Sum(r => r.unitMoney),
                                    ReturnSum = p.Sum(r => r.returnInvoiceMoney),
                                    ReturnCostSum = p.Sum(r => r.returnUnitMoney),
                                    SaleNum = p.Sum(r => r.saleNum),
                                    ReturnSaleNum = p.Sum(r => r.returnSaleNum),
                                    SaleNumSum = p.Sum(r => r.saleNum) - p.Sum(r => r.returnSaleNum)
                                }).ToList();

                    return result.ToList();
                }
                #endregion

                #region 按剂型
                if (input.StatisticObject == (int)StatisticObject.DoSage)
                {
                    var c = from i in this.Queryable
                            where i.BalanceTime != null && i.BalanceTime >= input.FromDate && i.BalanceTime <= input.ToDate && i.Deleted == false && i.OrderStatusValue != 4
                            join sd in RepositoryProvider.Db.SalesOrderDetails.Where(r => r.Deleted == false) on i.Id equals sd.SalesOrderID
                            join di in RepositoryProvider.Db.DrugInventoryRecords on sd.DrugInventoryRecordID equals di.Id
                            join druginfo in RepositoryProvider.Db.DrugInfos on di.DrugInfoId equals druginfo.Id
                            join w in RepositoryProvider.Db.WarehouseZones on di.WarehouseZoneId equals w.Id
                            select new
                            {
                                InvoiceMoney = sd.Amount * sd.ActualUnitPrice,
                                unitMoney = sd.Amount * sd.UnitPrice,
                                saleDate = (DateTime)(i.BalanceTime),
                                wareHouse = w.Name,
                                drugname = druginfo.ProductGeneralName,
                                drugid = druginfo.Id,
                                dosage = druginfo.DictionaryDosageCode,
                                specific = druginfo.DictionarySpecificationCode,
                                businesstype = druginfo.BusinessScopeCode,
                                factoryname = druginfo.FactoryName,
                                Origin = di.Decription == string.Empty ? druginfo.Origin : di.Decription,
                                permitNumber = druginfo.LicensePermissionNumber,
                                returnInvoiceMoney = 0m,
                                returnUnitMoney = 0m,
                                saleNum = sd.Amount,
                                returnSaleNum = 0m
                            };
                    var cc = from i in RepositoryProvider.Db.SalesOrderReturns
                             where i.OrderReturnStatusValue != 9 && i.OrderReturnCheckTime >= input.FromDate && i.OrderReturnCheckTime <= input.ToDate
                             join rd in RepositoryProvider.Db.SalesOrderReturnDetails on i.Id equals rd.OrderReturnID

                             join di in RepositoryProvider.Db.DrugInventoryRecords on rd.DrugInventoryRecordID equals di.Id
                             join druginfo in RepositoryProvider.Db.DrugInfos on di.DrugInfoId equals druginfo.Id
                             join w in RepositoryProvider.Db.WarehouseZones on di.WarehouseZoneId equals w.Id
                             select new
                             {
                                 InvoiceMoney = 0m,
                                 unitMoney = 0m,
                                 saleDate = (DateTime)(i.OrderReturnCheckTime),
                                 wareHouse = w.Name,
                                 drugname = druginfo.ProductGeneralName,
                                 drugid = druginfo.Id,
                                 dosage = druginfo.DictionaryDosageCode,
                                 specific = druginfo.DictionarySpecificationCode,
                                 businesstype = druginfo.BusinessScopeCode,
                                 factoryname = druginfo.FactoryName,
                                 Origin = di.Decription == string.Empty ? druginfo.Origin : di.Decription,
                                 permitNumber = druginfo.LicensePermissionNumber,
                                 returnInvoiceMoney = rd.ReturnAmount * rd.ActualUnitPrice,
                                 returnUnitMoney = rd.ReturnAmount * rd.UnitPrice,
                                 saleNum = 0m,
                                 returnSaleNum = rd.ReturnAmount
                             };

                    result = c.ToList().Concat(cc.ToList()).GroupBy(p => p.dosage)
                                .Select(p => new SalesOrderStatisticOutput
                                {
                                    StatisticObject = "剂型",
                                    Dosage = p.FirstOrDefault().dosage,
                                    Count = p.Count(),
                                    Sum = p.Sum(r => r.InvoiceMoney),
                                    CostSum = p.Sum(r => r.unitMoney),
                                    ReturnSum = p.Sum(r => r.returnInvoiceMoney),
                                    ReturnCostSum = p.Sum(r => r.returnUnitMoney),
                                    SaleNum = p.Sum(r => r.saleNum),
                                    ReturnSaleNum = p.Sum(r => r.returnSaleNum),
                                    SaleNumSum = p.Sum(r => r.saleNum) - p.Sum(r => r.returnSaleNum)
                                }).ToList();

                    return result.ToList();
                }
                #endregion

                #region 按中西药
                if (input.StatisticObject == (int)StatisticObject.ChinesOrWestern)
                {
                    var c = from i in this.Queryable
                            where i.BalanceTime != null && i.BalanceTime >= input.FromDate && i.BalanceTime <= input.ToDate && i.Deleted == false && i.OrderStatusValue != 4
                            join sd in RepositoryProvider.Db.SalesOrderDetails.Where(r => r.Deleted == false) on i.Id equals sd.SalesOrderID
                            join di in RepositoryProvider.Db.DrugInventoryRecords on sd.DrugInventoryRecordID equals di.Id
                            join druginfo in RepositoryProvider.Db.DrugInfos on di.DrugInfoId equals druginfo.Id
                            join w in RepositoryProvider.Db.WarehouseZones on di.WarehouseZoneId equals w.Id
                            select new
                            {
                                InvoiceMoney = sd.Amount * sd.ActualUnitPrice,
                                unitMoney = sd.Amount * sd.UnitPrice,
                                saleDate = (DateTime)(i.BalanceTime),
                                wareHouse = w.Name,
                                drugname = druginfo.ProductGeneralName,
                                drugid = druginfo.Id,
                                dosage = druginfo.DictionaryDosageCode,
                                specific = druginfo.DictionarySpecificationCode,
                                businesstype = druginfo.BusinessScopeCode,
                                factoryname = druginfo.FactoryName,
                                Origin = di.Decription == string.Empty ? druginfo.Origin : di.Decription,
                                permitNumber = druginfo.LicensePermissionNumber,
                                returnInvoiceMoney = 0m,
                                returnUnitMoney = 0m,
                                saleNum = sd.Amount,
                                returnSaleNum = 0m
                            };
                    var cc = from i in RepositoryProvider.Db.SalesOrderReturns
                             where i.OrderReturnStatusValue != 9 && i.OrderReturnCheckTime >= input.FromDate && i.OrderReturnCheckTime <= input.ToDate
                             join rd in RepositoryProvider.Db.SalesOrderReturnDetails on i.Id equals rd.OrderReturnID

                             join di in RepositoryProvider.Db.DrugInventoryRecords on rd.DrugInventoryRecordID equals di.Id
                             join druginfo in RepositoryProvider.Db.DrugInfos on di.DrugInfoId equals druginfo.Id
                             join w in RepositoryProvider.Db.WarehouseZones on di.WarehouseZoneId equals w.Id
                             select new
                             {
                                 InvoiceMoney = 0m,
                                 unitMoney = 0m,
                                 saleDate = (DateTime)(i.OrderReturnCheckTime),
                                 wareHouse = w.Name,
                                 drugname = druginfo.ProductGeneralName,
                                 drugid = druginfo.Id,
                                 dosage = druginfo.DictionaryDosageCode,
                                 specific = druginfo.DictionarySpecificationCode,
                                 businesstype = druginfo.BusinessScopeCode,
                                 factoryname = druginfo.FactoryName,
                                 Origin = di.Decription == string.Empty ? druginfo.Origin : di.Decription,
                                 permitNumber = druginfo.LicensePermissionNumber,
                                 returnInvoiceMoney = rd.ReturnAmount * rd.ActualUnitPrice,
                                 returnUnitMoney = rd.ReturnAmount * rd.UnitPrice,
                                 saleNum = 0m,
                                 returnSaleNum = rd.ReturnAmount
                             };

                    result = c.ToList().Concat(cc.ToList()).GroupBy(p => p.businesstype.Contains("中药"))
                                .Select(p => new SalesOrderStatisticOutput
                                {
                                    StatisticObject = "中西药",
                                    BusinessType = p.FirstOrDefault().businesstype.Contains("中药") ? "中药" : "西药",
                                    Count = p.Count(),
                                    Sum = p.Sum(r => r.InvoiceMoney),
                                    CostSum = p.Sum(r => r.unitMoney),
                                    ReturnSum = p.Sum(r => r.returnInvoiceMoney),
                                    ReturnCostSum = p.Sum(r => r.returnUnitMoney),
                                    SaleNum = p.Sum(r => r.saleNum),
                                    ReturnSaleNum = p.Sum(r => r.returnSaleNum),
                                    SaleNumSum = p.Sum(r => r.saleNum) - p.Sum(r => r.returnSaleNum)
                                }).ToList();

                    return result.ToList();
                }
                #endregion

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            { this.Dispose(); }
        }


        #region 获取订单结算的分页检索列表
        /// <summary>
        ///  获取订单结算的分页检索列表
        /// </summary>
        /// <param name="totalpage"></param>
        /// <param name="searchInput"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        class ListItem { public String Name { get; set; } public Int32 stateValue { get; set; } }
        public IEnumerable<Business.Models.SaleOrderModel> GetSalesOrderBalanceCodePaged(SalesCodeSearchInput searchInput)
        {
            try
            {
                IList<ListItem> lis = new List<ListItem>();
                foreach (var i in typeof(OrderStatus).GetFields())
                {
                    var attr = i.GetCustomAttributes(false);
                    if (attr.Length > 0 && attr[0] as System.ComponentModel.DataAnnotations.DisplayAttribute != null)
                    {
                        var v = typeof(OrderStatus).InvokeMember(i.Name, System.Reflection.BindingFlags.GetField, null, null, null);
                        var n = (attr[0] as System.ComponentModel.DataAnnotations.DisplayAttribute).Name;
                        var li = new ListItem();
                        li.Name = n;
                        li.stateValue = (Int32)v;
                        lis.Add(li);
                    }
                }
                var c = from i in lis select i;

                var varOrderCodeBalance = this.Queryable.Where(r => r.BalanceTime != null);
                if (searchInput.FromDate != null)
                    varOrderCodeBalance = varOrderCodeBalance.Where(p => p.BalanceTime >= searchInput.FromDate);
                if (searchInput.ToDate != null)
                    varOrderCodeBalance = varOrderCodeBalance.Where(p => p.BalanceTime <= searchInput.ToDate);
                if (searchInput.OperatorID != Guid.Empty)
                    varOrderCodeBalance = varOrderCodeBalance.Where(p => p.BalanceUserID == searchInput.OperatorID);
                var result = from li in c
                             join i in varOrderCodeBalance on li.stateValue equals i.OrderStatusValue
                             join k in RepositoryProvider.Db.Users on i.BalanceUserID equals k.Id
                             join l in RepositoryProvider.Db.Employees on k.EmployeeId equals l.Id
                             join m in RepositoryProvider.Db.PurchaseUnits on i.PurchaseUnitId equals m.Id
                             join n in RepositoryProvider.Db.Users on i.CreateUserId equals n.Id
                             join o in RepositoryProvider.Db.Employees on n.EmployeeId equals o.Id

                             select new Business.Models.SaleOrderModel
                             {
                                 BalanceTime = i.BalanceTime,
                                 BalanceUserName = l.Name,
                                 Creater = o.Name,
                                 CreateTime = i.CreateTime,
                                 DrugNum = i.SalesOrderDetails.Sum(r => r.Amount),
                                 Saler = i.SalerName,
                                 Id = i.Id,
                                 SaleOrderDocumentNumber = i.OrderCode,
                                 SaleOrderBalanceDocumentNumber = i.OrderBalanceCode,
                                 TotalPrice = i.SalesOrderDetails.Sum(j => j.Amount * j.ActualUnitPrice),
                                 PurchaseUnitName = m.Name,
                                 PurchaseUnitPinYin = m.PinyinCode,
                                 OrderStatus = li.Name
                             };

                if (!string.IsNullOrEmpty(searchInput.Code))
                {
                    string q = searchInput.Code;
                    result = result.Where(r => r.SaleOrderDocumentNumber.Contains(q) || r.PurchaseUnitName.Contains(q) || r.PurchaseUnitPinYin.ToUpper().Contains(q.ToUpper()));
                }
                return result;
            }
            catch (Exception ex)
            {
                return this.HandleException<IEnumerable<Business.Models.SaleOrderModel>>("获取订单结算的分页检索列表失败", ex);
            }
        }
        #endregion

        #region 获取订单创建的列表
        /// <summary>
        ///  获取订单创建的列表
        /// </summary>
        /// <param name="totalpage"></param>
        /// <param name="searchInput"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerable<Business.Models.SaleOrderModel> GetSalesOrderCodePaged(Business.Models.SalesCodeSearchInput searchInput)
        {
            try
            {
                #region 销售定单状态列表(条件)
                IList<ListItem> lis = new List<ListItem>();
                foreach (var i in typeof(OrderStatus).GetFields())
                {
                    var attr = i.GetCustomAttributes(false);
                    if (attr.Length > 0 && attr[0] as System.ComponentModel.DataAnnotations.DisplayAttribute != null)
                    {
                        var v = typeof(OrderStatus).InvokeMember(i.Name, System.Reflection.BindingFlags.GetField, null, null, null);
                        var n = (attr[0] as System.ComponentModel.DataAnnotations.DisplayAttribute).Name;
                        var li = new ListItem();
                        li.Name = n;
                        li.stateValue = (Int32)v;
                        lis.Add(li);
                    }
                }
                var c = from i in lis select i;


                #endregion

                var varOrderCodeBalance = this.Queryable.Where(r => r.BalanceTime != null && r.Deleted == false);
                if (searchInput.FromDate != null)
                    varOrderCodeBalance = varOrderCodeBalance.Where(p => p.BalanceTime >= searchInput.FromDate);
                if (searchInput.ToDate != null)
                    varOrderCodeBalance = varOrderCodeBalance.Where(p => p.BalanceTime <= searchInput.ToDate);


                if (!string.IsNullOrEmpty(searchInput.salerName))
                {
                    varOrderCodeBalance = varOrderCodeBalance.Where(r => r.SalerName == searchInput.salerName);
                }
                if (!string.IsNullOrEmpty(searchInput.Code))
                {
                    varOrderCodeBalance = varOrderCodeBalance.Where(r => r.OrderCode.Contains(searchInput.Code));
                }
                var usr = RepositoryProvider.Db.Users.Include(r => r.Employee);

                var outInv = from p in RepositoryProvider.Db.OutInventorys
                             join u1 in usr on p.CreateUserId equals u1.Id
                             join u2 in usr on p.ReviewerId equals u2.Id
                             join u3 in usr on p.OrderOutInventoryCheckUserID equals u3.Id into left
                             from k in left.DefaultIfEmpty()
                             select new
                             {
                                 p,
                                 saleorderid = p.SalesOrderID,
                                 PickUsr = u1.Employee.Name,
                                 CheckUsr = u2.Employee.Name,
                                 SecondCheckUsr = k.Employee.Name
                             };
                if (searchInput.purchaseKeyword == null) searchInput.purchaseKeyword = string.Empty;

                //销售客户精确查询
                var purchase = RepositoryProvider.Db.PurchaseUnits.Where(r => !r.Deleted);
                if (searchInput.IsPreciselySearch)
                {
                    purchase = purchase.Where(r => r.Name.Equals(searchInput.purchaseKeyword) || (r.PinyinCode != null && r.PinyinCode.ToUpper().Equals(searchInput.purchaseKeyword.ToUpper())));
                }
                else
                {
                    purchase = purchase.Where(r => r.Name.Contains(searchInput.purchaseKeyword) || (r.PinyinCode != null && r.PinyinCode.ToUpper().Contains(searchInput.purchaseKeyword.ToUpper())));
                }

                var result = from l in lis
                             join i in varOrderCodeBalance on l.stateValue equals i.OrderStatusValue
                             join k in usr on i.BalanceUserID equals k.Id
                             join k1 in usr on i.CreateUserId equals k1.Id
                             join m in purchase on i.PurchaseUnitId equals m.Id
                             join p in outInv on i.Id equals p.p.SalesOrderID into left
                             from b in left.DefaultIfEmpty()
                             select new Business.Models.SaleOrderModel
                             {
                                 Id = i.Id,
                                 Creater = k1.Employee.Name,
                                 CreateTime = i.CreateTime,
                                 SaleOrderDocumentNumber = i.OrderCode,

                                 //Saler = i.SalerName,
                                 OrderStatus = l.Name,

                                 //SaleOrderBalanceDocumentNumber = i.OrderBalanceCode,
                                 //BalanceTime = i.BalanceTime,
                                 //BalanceUserName = k.Employee.Name,
                                 //PaymentMethod = pay.Name,

                                 PickCode = b == null ? "" : b.p.OutInventoryNumber,
                                 PickTime = b == null ? i.BalanceTime : b.p.OutInventoryDate,
                                 PickUserName = b == null ? "" : b.PickUsr,

                                 CheckCode = b == null ? "" : b.p.OrderOutInventoryCheckNumber,
                                 CheckTime = b == null ? i.BalanceTime : b.p.OrderOutInventoryCheckTime,
                                 CheckUserName = b == null ? "" : b.CheckUsr,
                                 CheckUserName2 = b == null ? "" : b.SecondCheckUsr,

                                 //TotalPrice = i.SalesOrderDetails.Where(r => r.Deleted == false).Sum(r => r.Amount * r.ActualUnitPrice),
                                 DrugNum = i.SalesOrderDetails.Sum(r => r.Amount),
                                 PurchaseUnitName = m.Name,
                                 PurchaseUnitPinYin = m.PinyinCode
                             };
                return result.OrderBy(r => r.BalanceTime);
            }
            catch (Exception ex)
            {
                return this.HandleException<IEnumerable<Business.Models.SaleOrderModel>>("获取订单创建的列表失败", ex);
            }
            finally { this.Dispose(); }
        }

        #endregion

        #region 根据订单取消的分页检索列表
        /// <summary>
        ///  根据订单取消的分页检索列表
        /// </summary>
        /// <param name="totalpage"></param>
        /// <param name="searchInput"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public IEnumerable<Business.Models.SaleOrderModel> GetSalesOrderCancelCodePaged(SalesCodeSearchInput searchInput)
        {
            try
            {
                var varOrderCancel = base.Queryable;

                if (searchInput.FromDate != null)
                    varOrderCancel = varOrderCancel.Where(p => p.CancelTime >= searchInput.FromDate);
                if (searchInput.ToDate != null)
                    varOrderCancel = varOrderCancel.Where(p => p.CancelTime <= searchInput.ToDate);
                if (searchInput.OperatorID != Guid.Empty)
                    varOrderCancel = varOrderCancel.Where(p => p.CancelUserID == searchInput.OperatorID);

                var result = from i in varOrderCancel
                             join k in RepositoryProvider.Db.Users on i.CancelUserID equals k.Id
                             join l in RepositoryProvider.Db.Employees on k.EmployeeId equals l.Id
                             join m in RepositoryProvider.Db.PurchaseUnits on i.PurchaseUnitId equals m.Id
                             join n in RepositoryProvider.Db.Users on i.CreateUserId equals n.Id
                             join o in RepositoryProvider.Db.Employees on n.EmployeeId equals o.Id
                             select new Business.Models.SaleOrderModel
                             {
                                 CancelReason = i.CancelReason,
                                 CancelTime = i.CancelTime,
                                 CancelUserName = l.Name,
                                 Creater = o.Name,
                                 CreateTime = i.CreateTime,
                                 DrugNum = i.SalesOrderDetails.Sum(r => r.Amount),
                                 Saler = i.SalerName,
                                 Id = i.Id,
                                 SaleOrderDocumentNumber = i.OrderCode,
                                 SaleOrderCancelDocumentNumber = i.OrderCancelCode,
                                 TotalPrice = i.SalesOrderDetails.Sum(r => r.ActualUnitPrice * r.Amount),
                                 PurchaseUnitName = m.Name,
                                 PurchaseUnitPinYin = m.PinyinCode,
                                 OrderStatus = "单据取消"
                             };

                if (!string.IsNullOrEmpty(searchInput.Code))
                {
                    string q = searchInput.Code;
                    result = result.Where(r => r.SaleOrderDocumentNumber.Contains(q) || r.PurchaseUnitName.Contains(q) || r.PurchaseUnitPinYin.ToUpper().Contains(q.ToUpper()) || r.SaleOrderCancelDocumentNumber.Contains(q));
                }
                return result.OrderBy(r => r.CancelTime);
            }
            catch (Exception ex)
            {
                return this.HandleException<IEnumerable<Business.Models.SaleOrderModel>>("根据订单取消的分页检索列表失败", ex);
            }
        }

        #endregion

        #region 订单创建的用户列表
        /// <summary>
        /// 订单创建的用户列表
        /// </summary>
        /// <returns></returns>
        public List<User> GetSalesOrderOperatorUser()
        {
            try
            {
                var query = from o in BusinessHandlerFactory.RepositoryProvider.Db.SalesOrders
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on o.CreateUserId equals u.Id
                            select new
                            {
                                Id = u.Id,
                                Account = u.Account
                            };
                List<User> listUser = new List<User>();
                query = query.OrderBy(p => p.Account);
                foreach (var item in query)
                {
                    User user = new User();
                    user.Id = item.Id;
                    user.Account = item.Account;
                    listUser.Add(user);
                }
                return listUser;
            }
            catch (Exception ex)
            {
                return this.HandleException<List<User>>(" 订单创建的用户列表", ex);
            }
        }
        #endregion

        #region 订单取消的用户列表
        /// <summary>
        /// 订单取消的用户列表
        /// </summary>
        /// <returns></returns>
        public List<User> GetSalesOrderCancelUser()
        {
            try
            {
                var query = from o in BusinessHandlerFactory.RepositoryProvider.Db.SalesOrders
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on o.CancelUserID equals u.Id

                            select new
                            {
                                Id = u.Id,
                                Account = u.Account
                            };
                List<User> listUser = new List<User>();
                query = query.OrderBy(p => p.Account);
                foreach (var item in query)
                {
                    User user = new User();
                    user.Id = item.Id;
                    user.Account = item.Account;
                    listUser.Add(user);
                }
                return listUser;
            }
            catch (Exception ex)
            {
                return this.HandleException<List<User>>(" 订单取消的用户列表", ex);
            }
        }

        #endregion

        #region 订单结算的用户列表
        /// <summary>
        /// 订单结算的用户列表
        /// </summary>
        /// <returns></returns>
        public List<User> GetSalesOrderBalanceUser()
        {
            try
            {
                var query = from o in BusinessHandlerFactory.RepositoryProvider.Db.SalesOrders
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on o.BalanceUserID equals u.Id

                            select new
                            {
                                Id = u.Id,
                                Account = u.Account
                            };
                List<User> listUser = new List<User>();
                query = query.OrderBy(p => p.Account);
                foreach (var item in query)
                {
                    User user = new User();
                    user.Id = item.Id;
                    user.Account = item.Account;
                    listUser.Add(user);
                }
                return listUser;
            }
            catch (Exception ex)
            {
                return this.HandleException<List<User>>(" 订单结算的用户列表", ex);
            }
        }
        #endregion

        #region 获取销售记录的分页检索列表
        /// <summary>
        ///  获取销售记录的分页检索列表
        /// </summary>
        /// <param name="totalpage"></param>
        /// <param name="searchInput"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public List<SalesOrderRecordOutput> GetSalesOrderRecordPaged(SalesOrderRecordInput searchInput, out PagerInfo pager, int pageindex, int pageSize)
        {
            try
            {
                PagerInfo pageInfo = new PagerInfo();
                pageInfo.Index = pageindex;
                pageInfo.Size = pageSize;

                pageindex = pageindex - 1;
                int skipCount = pageindex * pageSize;
                var varOrderCancel = base.Queryable;

                var sods = this.BusinessHandlerFactory.SalesOrderDetailBusinessHandler.Queryable;
                var saleoders = Queryable.Where(r => r.OrderStatusValue != 4 && r.Deleted == false);
                if (searchInput.SalesFromDate.HasValue)
                {
                    DateTime fromdate = Convert.ToDateTime(searchInput.SalesFromDate);
                    saleoders = saleoders.Where(p => p.SaleDate >= fromdate);
                }
                if (searchInput.SalesToDate.HasValue)
                {
                    DateTime todate = Convert.ToDateTime(searchInput.SalesToDate);
                    saleoders = saleoders.Where(p => p.SaleDate <= todate);
                }
                if (!searchInput.PurchaseUnitID.Equals(Guid.Empty))
                {
                    saleoders = saleoders.Where(p => p.PurchaseUnitId.Equals(searchInput.PurchaseUnitID));
                }
                var dirs = this.BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Queryable;
                if (!string.IsNullOrWhiteSpace(searchInput.BatchNumber))
                {
                    dirs = dirs.Where(p => p.BatchNumber.Contains(searchInput.BatchNumber));
                }
                var drugs = this.BusinessHandlerFactory.DrugInfoBusinessHandler.Queryable;
                if (!string.IsNullOrWhiteSpace(searchInput.productCode))
                {
                    drugs = drugs.Where(p => p.Code.IndexOf(searchInput.productCode) >= 0);
                }
                if (!string.IsNullOrWhiteSpace(searchInput.productName))
                {
                    drugs = drugs.Where(p => p.ProductGeneralName.IndexOf(searchInput.productName) >= 0 || (p.Pinyin != null && p.Pinyin.ToUpper().Contains(searchInput.productName.ToUpper())));
                }

                if (!string.IsNullOrWhiteSpace(searchInput.FactoryName))
                {
                    drugs = drugs.Where(p => p.FactoryName.Contains(searchInput.FactoryName));
                }

                //do 按照经营范围查药品信息
                if (!string.IsNullOrEmpty(searchInput.GoodsTypeValue))
                {
                    drugs = drugs.Where(r => r.BusinessScopeCode.Contains(searchInput.GoodsTypeValue));
                }

                if (searchInput.IsSpecial > 0)//是否特殊管理药品1-是、2-否、0-不查
                {
                    drugs = drugs.Where(r => r.IsSpecialDrugCategory == (searchInput.IsSpecial == 1));
                }

                var drug_dirs = from dir in dirs.AsQueryable()
                                join drug in drugs.AsQueryable() on dir.DrugInfoId equals drug.Id
                                select new { dir, drug };
                var drug_dir_sods = from drug_dir in drug_dirs.AsQueryable()
                                    join sod in sods on drug_dir.dir.Id equals sod.DrugInventoryRecordID
                                    select new { sod, drug_dir.dir, drug_dir.drug };
                var ps = this.BusinessHandlerFactory.PurchaseUnitBusinessHandler.Queryable;
                var so_ps = from so in saleoders
                            join p in ps on so.PurchaseUnitId equals p.Id
                            select new { so, p };
                var result = from so_p in so_ps
                             join drug_dir_sod in drug_dir_sods on so_p.so.Id equals drug_dir_sod.sod.SalesOrderID
                             select new SalesOrderRecordOutput()
                             {
                                 id = drug_dir_sod.sod.Id,
                                 ActualUnitPrice = drug_dir_sod.sod.ActualUnitPrice,
                                 Amount = drug_dir_sod.sod.Amount,
                                 BatchNumber = drug_dir_sod.dir.BatchNumber,
                                 drugType = drug_dir_sod.drug.DictionaryDosageCode,
                                 permitCode = drug_dir_sod.drug.LicensePermissionNumber,
                                 FactoryName = drug_dir_sod.drug.FactoryName,
                                 OutValidDate = drug_dir_sod.dir.OutValidDate,
                                 Price = drug_dir_sod.sod.Price,
                                 productCode = drug_dir_sod.sod.SpecificationCode,
                                 ProductGeneralName = drug_dir_sod.drug.ProductGeneralName,
                                 PruductDate = drug_dir_sod.dir.PruductDate,
                                 PurchaseUnit = so_p.p.Name,
                                 SalesDate = so_p.so.CreateTime,
                                 DrugInventoryRecordID = drug_dir_sod.sod.DrugInventoryRecordID,
                                 SalesOrderCode = so_p.so.OrderCode,
                                 Saler = so_p.so.SalerName,
                                 SalesOrderId = so_p.so.Id
                             };
                //result.ToList();

                pageInfo.RecordCount = result.Count();
                pager = pageInfo;
                result = result.OrderBy(o => o.SalesDate);
                result = (skipCount == 0 ? result.Take(pageSize) : result.Skip(skipCount).Take(pageSize));
                return result.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                pager = null;
                return this.HandleException<List<SalesOrderRecordOutput>>("根据订单取消的分页检索列表失败", ex);
            }
        }

        #endregion


        /// <summary>
        ///  删除一条订单和订单明细记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public void CancelSalesOrder(SalesOrder so)
        {
            try
            {
                //增加销售记录
                this.Save(so);

                List<SalesOrderDetail> salesOrderDetailList = so.SalesOrderDetails.ToList();
                foreach (SalesOrderDetail item in salesOrderDetailList.Where(r => r.Deleted == false))
                {
                    Guid drugInventoryID = item.DrugInventoryRecordID;
                    decimal consumeQty = item.Amount;
                    //获取药物库存实体                    
                    DrugInventoryRecord drugInventory = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(drugInventoryID);
                    //存库存表的当前可用库存扣掉该订单明细数量
                    //drugInventory.CurrentInventoryCount = drugInventory.CurrentInventoryCount + item.Amount;
                    //在销售单但未出库数量 累计当前订单明细数量
                    drugInventory.OnSalesOrderCount = drugInventory.OnSalesOrderCount - item.Amount;
                    drugInventory.Valid = drugInventory.CanSaleNum > 0 ? true : false;
                    BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(drugInventory);

                }
                this.Save();

            }
            catch (Exception ex)
            {
                this.HandleException("删除一条订单和订单明细记录失败", ex);
            }
        }

        public SalesOrder[] GetSaleOrderByPurchaseUnitID(Guid id)
        {
            try
            {
                var all = this.Fetch(r => r.PurchaseUnitId == id);
                return all.OrderByDescending(r => r.BalanceTime).ToArray();
            }
            catch (Exception ex)
            {
                this.HandleException("根据购货商ID获取定单列表失败！", ex);
                return null;
            }
        }
        /// <summary>
        /// 获取药品流向
        /// </summary>
        /// <param name="id">GUID</param>
        /// <param name="pathType">GUID 类型 0-从库存获取；1-从销售单获取；2-从采购单获取;3-从药品信息获取;</param>
        /// <returns></returns>
        public List<Business.Models.DrugPath> GetDrugPath(Business.Models.QueryModelForDrugPath m)
        {
            try
            {
                List<DrugPath> ListPath = new List<DrugPath>();

                switch (m.DrugPathQueryType)
                {
                    case 0:
                        var a = from i in this.Queryable
                                join b in RepositoryProvider.Db.SalesOrderDetails on i.Id equals b.SalesOrderID
                                where i.BalanceTime > m.DTF && i.BalanceTime < m.DTT
                                join cc in RepositoryProvider.Db.DrugInventoryRecords on b.DrugInventoryRecordID equals cc.Id
                                join d in RepositoryProvider.Db.PurchaseUnits on i.PurchaseUnitId equals d.Id
                                where b.DrugInventoryRecordID == m.Id && i.OrderStatusValue != 4 && b.Deleted == false
                                select new DrugPath
                                {
                                    batchNumber = cc.BatchNumber,
                                    cansaleNum = cc.CanSaleNum,
                                    DrugInfoId = cc.DrugInfoId,
                                    drugName = cc.DrugInfo.ProductGeneralName,
                                    factoryName = cc.DrugInfo.FactoryName,
                                    id = new Guid(),
                                    inInventoryDate = null,
                                    invenotryNumber = 0,
                                    InventoryRecordId = cc.Id,
                                    permitNumber = cc.DrugInfo.LicensePermissionNumber,
                                    purchaseOrderID = Guid.Empty,
                                    purchaseUnitId = d.Id,
                                    purchaseUnitName = d.Name,
                                    saleCount = b.Amount,
                                    dosage = cc.DrugInfo.DictionaryDosageCode,
                                    businessman = i.SalerName,
                                    saleOrderCode = i.OrderCode,
                                    salePrice = b.ActualUnitPrice,
                                    saler = i.SalerName,
                                    salesOrderID = i.Id,
                                    specific = cc.DrugInfo.DictionarySpecificationCode,
                                    SupplyUintId = Guid.Empty,
                                    SupplyUnitName = string.Empty,
                                    saleDate = i.CreateTime,
                                    MeasurementUnit = b.MeasurementUnit
                                };
                        ListPath = a.OrderByDescending(r => r.saleDate).ToList();
                        break;
                    case 1:
                        var sod = BusinessHandlerFactory.SalesOrderDetailBusinessHandler.Get(m.Id);
                        var iR = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(sod.DrugInventoryRecordID);
                        var druginfoId = iR.DrugInfoId;

                        var ir2Sods = from s in RepositoryProvider.Db.SalesOrderDetails
                                      join y in RepositoryProvider.Db.SalesOrders on s.SalesOrderID equals y.Id
                                      where y.OrderStatusValue != 4 && y.Deleted == false && y.BalanceTime > m.DTF && y.BalanceTime < m.DTT
                                      join z in RepositoryProvider.Db.PurchaseUnits on y.PurchaseUnitId equals z.Id
                                      join t in RepositoryProvider.Db.DrugInventoryRecords on s.DrugInventoryRecordID equals t.Id
                                      where t.DrugInfoId == druginfoId
                                      join druginfo in RepositoryProvider.Db.DrugInfos on t.DrugInfoId equals druginfo.Id
                                      join u in RepositoryProvider.Db.PurchaseInInventeryOrderDetails on t.PurchaseInInventeryOrderDetailId equals u.Id
                                      into inPiivd
                                      from ii in inPiivd.DefaultIfEmpty()
                                      join v in RepositoryProvider.Db.PurchaseInInventeryOrders on ii.PurchaseInInventeryOrderId equals v.Id into pp
                                      from vv in pp.DefaultIfEmpty()
                                      join w in RepositoryProvider.Db.PurchaseOrders on vv.PurchaseOrderId equals w.Id into po
                                      from ww in po.DefaultIfEmpty()
                                      join x in RepositoryProvider.Db.SupplyUnits on ww.SupplyUnitId equals x.Id into su
                                      from xx in su.DefaultIfEmpty()
                                      select new DrugPath
                                      {
                                          batchNumber = s.BatchNumber,
                                          businessman = y.SalerName,
                                          cansaleNum = t.CanSaleNum,
                                          dosage = s.DictionaryDosageCode,
                                          specific = s.SpecificationCode,
                                          DrugInfo = null,
                                          DrugInfoId = t.DrugInfoId,
                                          drugName = druginfo.ProductGeneralName,
                                          factoryName = druginfo.FactoryName,
                                          id = new Guid(),
                                          inInventoryDate = ii != null ? vv.OperateTime : (DateTime?)null,
                                          invenotryNumber = ii != null ? ii.ArrivalAmount : 0,
                                          InventoryRecordId = t.Id,
                                          permitNumber = druginfo.LicensePermissionNumber,
                                          purchaseOrderID = ii == null ? Guid.Empty : ww.Id,
                                          PurchaseOrderDocumentNumber = ii == null ? "前期库存，无入库单" : ww.DocumentNumber,
                                          SupplyUnitName = ii == null ? "前期库存，无入库单" : xx.Name,
                                          SupplyUintId = ii == null ? Guid.Empty : xx.Id,
                                          purchaseUnitId = z.Id,
                                          purchaseUnitName = z.Name,
                                          saler = y.SalerName,
                                          saleOrderCode = y.OrderCode,
                                          salesOrderID = y.Id,
                                          saleCount = s.Amount,
                                          salePrice = s.ActualUnitPrice,
                                          MeasurementUnit = s.MeasurementUnit,
                                          saleDate = y.CreateTime,
                                      };
                        return ir2Sods.ToList();
                    case 2:
                        var aa = from i in this.Queryable
                                 join b in RepositoryProvider.Db.SalesOrderDetails on i.Id equals b.SalesOrderID
                                 where i.BalanceTime > m.DTF && i.BalanceTime < m.DTT
                                 join cc in RepositoryProvider.Db.DrugInventoryRecords.Where(z => z.DrugInfoId == m.Id) on b.DrugInventoryRecordID equals cc.Id
                                 join d in RepositoryProvider.Db.PurchaseUnits on i.PurchaseUnitId equals d.Id
                                 where cc.DrugInfoId == m.Id && b.Deleted == false && i.OrderStatusValue != 4
                                 select new DrugPath
                                 {
                                     batchNumber = cc.BatchNumber,
                                     cansaleNum = cc.CanSaleNum,
                                     DrugInfoId = cc.DrugInfoId,
                                     drugName = cc.DrugInfo.ProductGeneralName,
                                     factoryName = cc.DrugInfo.FactoryName,
                                     id = new Guid(),
                                     inInventoryDate = null,
                                     invenotryNumber = 0,
                                     InventoryRecordId = cc.Id,
                                     permitNumber = cc.DrugInfo.LicensePermissionNumber,
                                     purchaseOrderID = Guid.Empty,
                                     purchaseUnitId = d.Id,
                                     purchaseUnitName = d.Name,
                                     saleCount = b.Amount,
                                     dosage = cc.DrugInfo.DictionaryDosageCode,
                                     businessman = i.SalerName,
                                     saleOrderCode = i.OrderCode,
                                     salePrice = b.ActualUnitPrice,
                                     saler = i.SalerName,
                                     salesOrderID = i.Id,
                                     specific = cc.DrugInfo.DictionarySpecificationCode,
                                     SupplyUintId = Guid.Empty,
                                     SupplyUnitName = string.Empty,
                                     saleDate = i.CreateTime,
                                     MeasurementUnit = b.MeasurementUnit
                                 };

                        ListPath = aa.OrderByDescending(r => r.saleDate).ToList();
                        break;
                    case 3:
                        var druginfoId3 = m.Id;
                        var ir2Sods3 = from s in RepositoryProvider.Db.SalesOrderDetails
                                       join y in RepositoryProvider.Db.SalesOrders on s.SalesOrderID equals y.Id
                                       where y.OrderStatusValue != 4 && y.Deleted == false && y.CreateTime > m.DTF && y.CreateTime < m.DTT
                                       join z in RepositoryProvider.Db.PurchaseUnits on y.PurchaseUnitId equals z.Id
                                       join t in RepositoryProvider.Db.DrugInventoryRecords on s.DrugInventoryRecordID equals t.Id
                                       where t.DrugInfoId == druginfoId3
                                       join druginfo in RepositoryProvider.Db.DrugInfos on t.DrugInfoId equals druginfo.Id
                                       join u in RepositoryProvider.Db.PurchaseInInventeryOrderDetails on new { t.DrugInfoId, t.BatchNumber } equals new { u.DrugInfoId, u.BatchNumber }
                                       into inPiivd
                                       from ii in inPiivd.DefaultIfEmpty()
                                       join v in RepositoryProvider.Db.PurchaseInInventeryOrders on ii.PurchaseInInventeryOrderId equals v.Id into pp
                                       from vv in pp.DefaultIfEmpty()
                                       join w in RepositoryProvider.Db.PurchaseOrders on vv.PurchaseOrderId equals w.Id into po
                                       from ww in po.DefaultIfEmpty()
                                       join x in RepositoryProvider.Db.SupplyUnits on ww.SupplyUnitId equals x.Id into su
                                       from xx in su.DefaultIfEmpty()
                                       select new DrugPath
                                       {
                                           batchNumber = s.BatchNumber,
                                           businessman = y.SalerName,
                                           cansaleNum = t.CanSaleNum,
                                           dosage = s.DictionaryDosageCode,
                                           specific = s.SpecificationCode,
                                           DrugInfo = null,
                                           DrugInfoId = t.DrugInfoId,
                                           drugName = druginfo.ProductGeneralName,
                                           factoryName = druginfo.FactoryName,
                                           id = new Guid(),
                                           inInventoryDate = ii != null ? vv.OperateTime : (DateTime?)null,
                                           invenotryNumber = ii == null ? 0 : ii.ArrivalAmount,
                                           InventoryRecordId = t.Id,
                                           permitNumber = druginfo.LicensePermissionNumber,
                                           purchaseOrderID = ii == null ? Guid.Empty : ww.Id,
                                           PurchaseOrderDocumentNumber = ii == null ? "前期库存，无入库单" : ww.DocumentNumber,
                                           SupplyUnitName = ii == null ? "前期库存，无入库单" : xx.Name,
                                           SupplyUintId = ii == null ? Guid.Empty : xx.Id,
                                           saleDate = y.CreateTime,
                                           purchaseUnitId = z.Id,
                                           purchaseUnitName = z.Name,
                                           saler = y.SalerName,
                                           saleOrderCode = y.OrderCode,
                                           salesOrderID = y.Id,
                                           saleCount = s.Amount,
                                           salePrice = s.ActualUnitPrice,
                                           MeasurementUnit = s.MeasurementUnit
                                       };

                        return ir2Sods3.ToList();
                }
                return ListPath;
            }
            catch (Exception ex)
            {
                this.HandleException("获取流向失败！", ex);
                return null;
            }
        }

        /// <summary>
        /// 销售费率查询
        /// </summary>
        /// <param name="Pid">购货商ID</param>
        /// <param name="Uid">销售员ID</param>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerable<Business.Models.SalesTaxRate> GetSalesTaxRate(System.Guid Pid, System.Guid Uid)
        {
            var c = RepositoryProvider.Db.TaxRates.Where(r => r.Deleted == false).AsQueryable();
            if (!Pid.Equals(Guid.Empty))
            {
                c = c.Where(r => ((Guid)r.PurchaseUnitID).Equals(Pid));
            }
            if (!Uid.Equals(Guid.Empty))
            {
                c = c.Where(r => ((Guid)r.UserID).Equals(Uid));
            }
            var result = from i in c
                         join j in RepositoryProvider.Db.PurchaseUnits on i.PurchaseUnitID equals j.Id
                         join k in RepositoryProvider.Db.Users on i.UserID equals k.Id
                         join l in RepositoryProvider.Db.Employees on k.EmployeeId equals l.Id
                         select new Business.Models.SalesTaxRate
                         {
                             Id = i.Id,
                             UserId = k.Id,
                             EmployeeName = l.Name,
                             IRate = i.IRate,
                             MRate = i.MRate,
                             PurchaseUnitId = j.Id,
                             PurchaseUnitName = j.Name
                         };

            return result.OrderBy(r => r.EmployeeName).ThenBy(r => r.PurchaseUnitName);
        }

        public IEnumerable<Business.Models.SalerTaxManage> GetSalerTaxManage(System.DateTime dtF, System.DateTime DtT, Guid purchaseUnitId, string SalerName)
        {
            var all = this.Queryable.Where(r => r.OrderStatusValue != 4 && r.ApprovaledTime < DtT && r.ApprovaledTime > dtF && r.Deleted == false);
            if (!purchaseUnitId.Equals(Guid.Empty))
            {
                all = all.Where(r => r.PurchaseUnitId == purchaseUnitId);
            }
            if (!string.IsNullOrEmpty(SalerName))
            {
                all = all.Where(r => r.SalerName == SalerName);
            }

            var u = from i in RepositoryProvider.Db.SalesOrderReturns
                    join j in RepositoryProvider.Db.SalesOrderReturnDetails
                    on i.Id equals j.OrderReturnID
                    where i.OrderReturnStatusValue == 5 && i.Deleted == false
                    join k in RepositoryProvider.Db.SalesOrderDetails
                    on j.SalesOrderDetailID equals k.Id
                    select new
                    {
                        SalesOrderID = i.SalesOrderID,
                        returnId = i.Id,
                        ReturnCode = i.OrderReturnCode,
                        ReturnMoney = j.ReturnAmount * j.ActualUnitPrice,
                        diff = k.ChangeAmount * j.ReturnAmount,
                        createTime = i.CreateTime
                    };
            //产生销退查询记录
            var SaleReturn = from R in u
                             group R by R.SalesOrderID into g
                             select new
                             {
                                 saleOrderId = g.FirstOrDefault().SalesOrderID,
                                 SaleReturnIds = from e in g
                                                 where e.createTime >= dtF && e.createTime <= DtT
                                                 select new ReturnOrderCol
                                                 {
                                                     Gid = e.returnId,
                                                     code = e.ReturnCode
                                                 },
                                 ReturnMoney = g.Where(r => r.createTime <= DtT && r.createTime >= dtF).Sum(r => r.ReturnMoney),
                                 ReturnMoneyHistory = g.Where(r => r.createTime <= DtT).Sum(r => r.ReturnMoney),
                                 diff = g.Where(r => r.createTime <= DtT).Sum(r => r.diff),
                                 flag = g.Where(r => r.createTime <= DtT && r.createTime >= dtF).Count()
                             };//销退分组，一个销售单可能有多个退单，需要累加销退差额u = u.Where(r => r.createTime >= dtF && r.createTime <= DtT);
            SaleReturn = SaleReturn.Where(r => r.flag > 0);

            var SBefore = from i in this.Queryable join j in SaleReturn on i.Id equals j.saleOrderId select i; //求得销退相应的销售记录集
            all = all.Concat(SBefore).Distinct(); //合并并且取缔重复记录.
            var result = from i in all
                         join re in SaleReturn on i.Id equals re.saleOrderId
                         into ReturnList
                         from ret in ReturnList.DefaultIfEmpty()
                         join k in RepositoryProvider.Db.PurchaseUnits on i.PurchaseUnitId equals k.Id
                         join j in RepositoryProvider.Db.TaxRates.Where(r => r.Deleted == false)
                         on new { Saler = i.SalerName, Pid = i.PurchaseUnitId } equals new
                         {
                             Saler = j.Name,
                             Pid = (Guid)j.PurchaseUnitID
                         } into left
                         from l in left.DefaultIfEmpty()
                         select new Business.Models.SalerTaxManage
                         {
                             EmployeeName = i.SalerName,
                             Id = i.Id,
                             SaleOrderDate = i.CreateTime,
                             InvoiceMoney = i.InvoiceMoney,
                             IRate = l.IRate,
                             IsNeedInvoice = i.IsNeedInvoice,
                             IsInvoice = i.IsInvoice,
                             IsPayed = true,
                             MRate = l.MRate,
                             ManageMoneyR = i.CreateTime >= dtF ? (i.TotalMoney - (ret.ReturnMoney == null ? 0m : ret.ReturnMoney)) * (l.MRate ?? 0m) / 100 : -(ret.ReturnMoney) * (l.MRate ?? 0m) / 100,
                             InvoiceMoneyR = i.CreateTime >= dtF ? (i.InvoiceMoney - (ret.ReturnMoney == null ? 0m : ret.ReturnMoney)) * (l.IRate ?? 0m) / 100 : -(ret.ReturnMoney) * (l.IRate ?? 0m) / 100,
                             PayedMoney = i.CreateTime >= dtF ? ((i.InvoiceMoney - (ret.ReturnMoney == null ? 0m : ret.ReturnMoney)) * (l.IRate ?? 0m) / 100) +
                             ((i.TotalMoney - (ret.ReturnMoney == null ? 0m : ret.ReturnMoney)) * (l.MRate ?? 0m) / 100) :
                             -1 * ((ret.ReturnMoney) * (l.IRate ?? 0m) / 100 + (ret.ReturnMoney) * (l.MRate ?? 0m) / 100),
                             PayMoney = i.TotalMoney,
                             SalesReturnMoney = ret.ReturnMoney,
                             ReturnOrderCol = ret.SaleReturnIds.Distinct(),//消除重复销退单号
                             PurchaseUnitId = i.PurchaseUnitId,
                             PurchaseUnitName = k.Name,
                             ReceivedMoney = i.ReceivedMoney == null ? i.TotalMoney : i.ReceivedMoney,
                             Diff = i.ReceivedMoney == null ? 0m : (i.ReceivedMoney ?? 0m) - (i.TotalMoney),
                             ReturnDiff = i.ReceivedMoney == null ? 0m : i.ReceivedMoney - (ret.ReturnMoneyHistory + ret.diff) - i.TotalMoney,
                             ReceiveMoneyAfterReturn = i.ReceivedMoney == null ? 0m : i.ReceivedMoney - (ret.ReturnMoneyHistory + ret.diff),
                             SaleOrderDocumentNumber = i.OrderCode,
                             UserId = l.UserID,
                             IsBalanced = i.OrderStatusValue >= 5 ? "已结算" : "未结算",
                             Description = i.Description
                         };
            return result;
        }

        public bool SaveSaleOrderTaxRate(List<Business.Models.SalerTaxManage> ListST, int locker)
        {
            try
            {
                switch (locker)
                {
                    case 0://管理员保存所有字段
                        foreach (var i in ListST)
                        {
                            SalesOrder so = BusinessHandlerFactory.SalesOrderBusinessHandler.Get(i.Id);
                            so.IsNeedInvoice = i.IsNeedInvoice;
                            so.InvoiceMoney = i.InvoiceMoney;
                            so.IsInvoice = i.IsInvoice;
                            so.IsPayed = i.IsPayed;
                            so.ReceivedMoney = i.ReceivedMoney;
                            so.UpdateTime = DateTime.Now;
                            so.Description = i.Description;
                            this.Save(so);
                        }
                        break;
                    case 1://已收款
                        foreach (var i in ListST)
                        {
                            SalesOrder so = BusinessHandlerFactory.SalesOrderBusinessHandler.Get(i.Id);
                            so.IsPayed = i.IsPayed;
                            so.ReceivedMoney = i.ReceivedMoney;
                            so.UpdateTime = DateTime.Now;
                            so.Description = i.Description;
                            this.Save(so);
                        }
                        break;
                    case 2:
                        foreach (var i in ListST)
                        {
                            SalesOrder so = BusinessHandlerFactory.SalesOrderBusinessHandler.Get(i.Id);
                            so.IsNeedInvoice = i.IsNeedInvoice;
                            so.InvoiceMoney = i.InvoiceMoney;
                            so.IsInvoice = i.IsInvoice;
                            so.UpdateTime = DateTime.Now;
                            so.Description = i.Description;
                            this.Save(so);
                        }
                        break;
                }
                return this.Save();
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Business.Models.SaleOrderModel> GetSaleRefundHistory(SalesCodeSearchInput searchInput)
        {
            var varOrderCodeBalance = this.Queryable.Where(r => r.ReceivedMoney != null && ((decimal)r.ReceivedMoney - r.TotalMoney) != 0m);

            if (searchInput.FromDate != null)
                varOrderCodeBalance = varOrderCodeBalance.Where(p => p.BalanceTime >= searchInput.FromDate);
            if (searchInput.ToDate != null)
                varOrderCodeBalance = varOrderCodeBalance.Where(p => p.BalanceTime <= searchInput.ToDate);

            var result = from i in varOrderCodeBalance
                         join k in RepositoryProvider.Db.Users on i.BalanceUserID equals k.Id
                         join l in RepositoryProvider.Db.Employees on k.EmployeeId equals l.Id
                         join m in RepositoryProvider.Db.PurchaseUnits on i.PurchaseUnitId equals m.Id
                         join n in RepositoryProvider.Db.Users on i.CreateUserId equals n.Id
                         join o in RepositoryProvider.Db.Employees on n.EmployeeId equals o.Id
                         select new Business.Models.SaleOrderModel
                         {
                             BalanceTime = i.BalanceTime,
                             BalanceUserName = l.Name,
                             Creater = o.Name,
                             CreateTime = i.CreateTime,
                             DrugNum = i.SalesOrderDetails.Sum(r => r.Amount),
                             Saler = i.SalerName,
                             Id = i.Id,
                             SaleOrderDocumentNumber = i.OrderCode,
                             SaleOrderBalanceDocumentNumber = i.OrderBalanceCode,
                             TotalPrice = i.SalesOrderDetails.Sum(r => r.Amount * r.ActualUnitPrice),
                             PurchaseUnitName = m.Name,
                             PurchaseUnitPinYin = m.PinyinCode
                         };
            if (!string.IsNullOrEmpty(searchInput.Code))
            {
                string q = searchInput.Code;
                result = result.Where(r => r.SaleOrderDocumentNumber.Contains(q) || r.PurchaseUnitName.Contains(q) || r.PurchaseUnitPinYin.ToUpper().Contains(q.ToUpper()));
            }
            return result;
        }

        public bool SaveSaleRefund(SalesOrder so)
        {

            var c = this.Queryable.Where(r => r.Id == so.Id).FirstOrDefault();
            if (c == null) return false;
            c.ReceivedMoney = so.SalesOrderDetails.Where(r => !r.Deleted).Sum(r => (r.ActualUnitPrice + r.ChangeAmount) * r.Amount);
            foreach (var d in so.SalesOrderDetails)
            {
                var i = c.SalesOrderDetails.Where(r => r.Id == d.Id).FirstOrDefault();
                if (i == null) continue;
                i.ChangeAmount = d.ChangeAmount;
                BusinessHandlerFactory.SalesOrderDetailBusinessHandler.Save(i);
            }
            this.Save(c);
            this.Save();
            return true;
        }

        public System.Collections.Generic.IEnumerable<Business.Models.SalesOrderModelForSalesOrderReturn> GetSalesOrderByOrderModel(Business.Models.SalesOrderQueryModel m)
        {
            var c = this.Queryable.Where(r => !r.Deleted && r.OrderStatusValue == (int)OrderStatus.Delivering);

            if (!string.IsNullOrEmpty(m.OrderCode))
            {
                c = c.Where(r => r.OrderCode.Contains(m.OrderCode));
            }

            if (m.DTT != null || m.DTF != null)
            {
                c = c.Where(r => r.BalanceTime < m.DTT && r.BalanceTime > m.DTF);
            }

            var pu = RepositoryProvider.Db.PurchaseUnits.Where(r => r.PinyinCode != null);

            if (!string.IsNullOrEmpty(m.PurchaseUnitKeyword))
            {
                c = from i in c
                    join j in pu on i.PurchaseUnitId equals j.Id
                    where j.Deleted == false
                    select i;

                c = c.Where(r => r.PurchaseUnit.PinyinCode != null).Where(r => r.PurchaseUnit.PinyinCode.ToUpper().Contains(m.PurchaseUnitKeyword) || r.PurchaseUnit.Name.Contains(m.PurchaseUnitKeyword));
            }

            var users = RepositoryProvider.Db.Users.Include(r => r.Employee);

            var di = RepositoryProvider.Db.DrugInventoryRecords.Include(r => r.DrugInfo);
            if (!string.IsNullOrEmpty(m.Batch))
            {
                di = di.Where(r => r.BatchNumber.Contains(m.Batch));
            }
            if (!string.IsNullOrEmpty(m.DrugInfoKeyword))
            {
                di = di.Where(r => r.DrugInfo.Pinyin != null).Where(r => r.DrugInfo.ProductGeneralName.Contains(m.DrugInfoKeyword) || r.DrugInfo.Pinyin.ToUpper().Contains(m.DrugInfoKeyword.ToUpper()));
            }

            var u = from i in c
                    join j in RepositoryProvider.Db.SalesOrderDetails on i.Id equals j.SalesOrderID
                    join k in di on j.DrugInventoryRecordID equals k.Id
                    select i;

            var re = from i in u
                     join p in pu on i.PurchaseUnitId equals p.Id
                     join u1 in users on i.BalanceUserID equals u1.Id
                     into left
                     from l in left.DefaultIfEmpty()
                     select new Business.Models.SalesOrderModelForSalesOrderReturn
                     {
                         Id = i.Id,
                         BalanceDate = (DateTime)i.BalanceTime,
                         Balancer = l.Employee.Name,
                         OrderCode = i.OrderCode,
                         PurchaseUnitName = p.Name,
                         PurchaseUnitId = i.Id,
                         SalerName = i.SalerName,
                         ApprovalDate = (DateTime)i.ApprovaledTime,
                     };

            var result = from i in re
                         group i by i.Id into g
                         select new Business.Models.SalesOrderModelForSalesOrderReturn
                      {
                          Id = g.FirstOrDefault().Id,
                          BalanceDate = g.FirstOrDefault().BalanceDate,
                          Balancer = g.FirstOrDefault().Balancer,
                          OrderCode = g.FirstOrDefault().OrderCode,
                          PurchaseUnitName = g.FirstOrDefault().PurchaseUnitName,
                          PurchaseUnitId = g.FirstOrDefault().PurchaseUnitId,
                          SalerName = g.FirstOrDefault().SalerName,
                          ApprovalDate = g.FirstOrDefault().ApprovalDate,
                      };

            return result;
        }

        public bool SaveSalePriceControlRules(SalePriceControlRulesModel m)
        {
            return SearialiserHelper<SalePriceControlRulesModel>.SerializeObjToFile(m, "SalePriceControlRulesModel.bin");
        }

        public SalePriceControlRulesModel GetSalePriceControlRules()
        {
            return SearialiserHelper<SalePriceControlRulesModel>.DeSerializeFileToObj("SalePriceControlRulesModel.bin");
        }
    }

}




