using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using BugsBox.Application.Core;
using System.Data.Entity;
using System.Linq.Expressions;
using BugsBox.Pharmacy.Business.Models;
namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class DrugInventoryRecordBusinessHandler
    {
        protected override IQueryable<DrugInventoryRecord> IncludeNavigationProperties(IQueryable<DrugInventoryRecord> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable
              .Include(d => d.WarehouseZone)//库区
              .Include(d => d.WarehouseZone.Warehouse)//库房
              .Include(d => d.DrugInfo)
              );
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<DrugInventoryRecord>>(ex.Message, ex);
            }
        }
        /// <summary>
        /// 查找库存for药品选择界面
        /// </summary>
        /// <param name="purchaseUnitGuid"></param>
        /// <param name="tym"></param>
        /// <param name="bwm"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public IEnumerable<DrugInventoryRecord> GetDrugInventoryRecordForDrugInfoForSalesSelector(Guid purchaseUnitGuid, string tym, string bwm, string code)
        {
            try
            {
                var all = this.BusinessHandlerFactory.DrugInfoBusinessHandler.GetDrugInfoByPurchaseUnit(purchaseUnitGuid).AsQueryable();

                if (!string.IsNullOrWhiteSpace(tym))
                {
                    all = all.Where(p => p.ProductGeneralName.Contains(tym));
                }
                if (!string.IsNullOrWhiteSpace(bwm))
                {
                    all = all.Where(p => p.StandardCode.Contains(bwm));
                }
                if (!string.IsNullOrWhiteSpace(code))
                {
                    all = all.Where(p => p.Code.Contains(code));
                }

                var diids = all.Select(p => p.Id);

                var result = this.Queryable.Where(p => p.CanSaleNum > 0 && p.Valid && diids.Contains(p.DrugInfoId));

                return result;
            }
            catch (Exception ex)
            {
                return this.HandleException<List<DrugInventoryRecord>>("查找库存失败", ex);
            }
            finally
            {
                this.Dispose();
            }
        }



        /// <summary>
        /// 根据条件查找药品库存信息
        /// </summary>
        /// <param name="ProductName"></param>
        /// <param name="BatchNumber"></param>
        /// <returns></returns>
        public List<DrugInventoryRecord> GetDrugInventoryRecordByCondition(string ProductName, string BatchNumber)
        {
            try
            {
                var all = this.BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Queryable;
                all = all.Where(r => r.Valid == true);
                if (!string.IsNullOrWhiteSpace(ProductName))
                {
                    all = all.Where(p => p.DrugInfo.ProductName.Contains(ProductName));
                }
                if (!string.IsNullOrWhiteSpace(BatchNumber))
                {
                    all = all.Where(p => p.BatchNumber.Contains(BatchNumber));
                }

                //if (!string.IsNullOrEmpty(ProductName))
                //{
                //    all = all.Where(p => p.WarehouseZone.Name.Contains(ProductName));
                //}
                //BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog { Content = ConnectedInfoProvider.User.Account + "成功根据条件获取库存药品信息" });
                return all.ToList();
            }
            catch (Exception ex)
            {
                //BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog { Content = ConnectedInfoProvider.User.Account + "根据条件获取库存药品信息失败" });
                return this.HandleException<List<DrugInventoryRecord>>("根据条件查找药品库存记录失败", ex);
            }
        }

        /// <summary>
        /// 根据零售退货单获取更新后的库存实体
        /// </summary>
        /// <param name="rod"></param>
        /// <returns></returns>
        protected internal DrugInventoryRecord GetRetailReturnLeftDrugInventoryRecord(RetailOrderDetail rod)
        {
            Guid drugInventoryID = rod.DrugInventoryRecordID;
            decimal returnQty = rod.ReturnAmount;

            //获取药物库存实体
            DrugInventoryRecord drugInventory = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(drugInventoryID);

            int piecemealNumber = drugInventory.DrugInfo.PiecemealNumber;
            #region DrugInventoryRecord  药物实体库存处理

            if (rod.IsDismanting)
            {
                //将退库的零售拆零数量累加到药品库存的待售零售拆零数量上
                drugInventory.DismantingAmount += returnQty;

                if (piecemealNumber > 0)
                {
                    //如果待售零售拆零数量大于一个单位，则需要装包
                    if (drugInventory.DismantingAmount >= piecemealNumber)
                    {
                        drugInventory.CurrentInventoryCount += drugInventory.DismantingAmount / piecemealNumber;
                        drugInventory.DismantingAmount = drugInventory.DismantingAmount % piecemealNumber;
                    }
                }

                //将退库的零售拆零数量从已售的拆零零售数量里扣除
                //已售拆零数量是不够扣除拆零退货数量，则从已售零售里拆包
                if (drugInventory.RetailDismantingAmount < returnQty)
                {
                    drugInventory.RetailCount -= 1;
                    drugInventory.RetailDismantingAmount += piecemealNumber;
                }
                drugInventory.RetailDismantingAmount -= returnQty;

            }
            else
            {
                //存库存表的当前可用库存加上改退货数量
                drugInventory.CurrentInventoryCount += returnQty;

                //将已经销售的零售数量累减去退货数量
                drugInventory.RetailCount -= returnQty;
            }

            #endregion
            return drugInventory;
        }

        /// <summary>
        /// 根据零售单获取更新后的库存实体
        /// </summary>
        /// <param name="rod"></param>
        /// <returns></returns>
        protected internal DrugInventoryRecord GetRetailLeftDrugInventoryRecord(RetailOrderDetail rod)
        {
            Guid drugInventoryID = rod.DrugInventoryRecordID;
            decimal consumeQty = rod.Amount;
            //获取药物库存实体
            DrugInventoryRecord drugInventory = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(drugInventoryID);
            int piecemealNumber = drugInventory.DrugInfo.PiecemealNumber;
            #region DrugInventoryRecord  药物实体库存处理
            if (rod.Amount < drugInventory.CurrentInventoryCount)
            {
                if (rod.IsDismanting)
                {
                    //当前拆零数量是否满足该条零售的拆零数量
                    //如果拆零数量不足，则再拆一个单位
                    if (drugInventory.DismantingAmount < rod.DismantingAmount)
                    {
                        drugInventory.CurrentInventoryCount = drugInventory.CurrentInventoryCount - 1;
                        drugInventory.DismantingAmount = drugInventory.DismantingAmount + piecemealNumber;

                    }
                    //存库存表的当前可用拆零数量扣掉该零售拆零数量
                    drugInventory.DismantingAmount = drugInventory.DismantingAmount - rod.DismantingAmount;
                    //将零售拆零数量累加到可用库存的拆零零售数量
                    drugInventory.RetailDismantingAmount = drugInventory.RetailDismantingAmount + rod.DismantingAmount;

                    if (piecemealNumber > 0)
                    {
                        //如果已售的零售数量大于一个单位，则需要装包
                        if (drugInventory.RetailDismantingAmount >= piecemealNumber)
                        {
                            drugInventory.RetailCount = drugInventory.RetailCount + drugInventory.RetailDismantingAmount / piecemealNumber;
                            drugInventory.RetailDismantingAmount = drugInventory.RetailDismantingAmount % piecemealNumber;
                        }
                    }
                }
                else
                {
                    //存库存表的当前可用库存扣掉该零售数量
                    drugInventory.CurrentInventoryCount = drugInventory.CurrentInventoryCount - rod.Amount;
                    //将零售数量累加到可用库存的零售数量
                    drugInventory.RetailCount = drugInventory.RetailCount + rod.Amount;
                }
            }
            else
                throw new Exception("库存数量不足");
            #endregion

            return drugInventory;
        }

        /// <summary>
        /// 分页查询所有的药物库存为选择窗口
        /// </summary>
        /// <returns></returns>
        public List<DrugInventoryRecord> QueryPagedAllDrugInventoryRecordSelector
            (
            QueryDrugInventoryRecordBusinessModel queryModel,
            int index, int size,
            out PagerInfo pager
            )
        {
            pager = PagerInfo.Validate(new PagerInfo { Index = index, Size = size });
            try
            {
                List<DrugInventoryRecord> records = new List<DrugInventoryRecord>();
                var queryBuilder = QueryBuilder.Create<DrugInventoryRecord>();
                Expression<Func<DrugInventoryRecord, bool>> expression = dir => true;
                //处理排序
                var query = this.Queryable;
                query = query.Where(PreparePredicate(queryBuilder.Expression));//过滤一下
                pager.RecordCount = query.Count();  //处理总录条数
                query = query.OrderBy(dir => dir.PruductDate)
                    .OrderBy(dir => dir.OutValidDate)
                    .OrderBy(dir => dir.InInventoryCount)
                    .OrderBy(dir => dir.SalesCount)
                    .OrderBy(dir => dir.RetailCount);
                records = query
                    .Skip((pager.Index - 1) * pager.Size)
                    .Take(pager.Size)
                    .ToList();
                return records;
            }
            catch (Exception ex)
            {
                return this.HandleException<List<DrugInventoryRecord>>("分页查询所有的药物库存失败", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        /// <summary>
        /// 库存查询
        /// </summary>
        /// <param name="ProductGeneralName">药品名称</param>
        /// <param name="StandardCode">该字段表示按生产厂家查询</param>
        /// <param name="BatchNumber">批号</param>
        /// <param name="WarehouseZones">仓库</param>
        /// <param name="index">分页序号</param>
        /// <param name="size">分页记录数量</param>
        /// <param name="searchConditions">查询条件</param>
        /// <returns></returns>
        public List<InventeryModel> StorageQuery(string ProductGeneralName, string StandardCode, string BatchNumber, Guid[] WarehouseZones, int index, int size, List<object> searchConditions)
        {
            try
            {
                var queryBuilder = QueryBuilder.Create<DrugInventoryRecord>()
                   .Like(c => c.BatchNumber, BatchNumber)
                   .In(c => c.WarehouseZoneId, WarehouseZones)
                    .GreaterThan(c => c.CanSaleNum, 0);
                var drugInventoryRecords = BusinessHandlerFactory.RepositoryProvider.Db.DrugInventoryRecords.Where(queryBuilder.Expression);
                var druginfo = BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos.Where(r => r.Deleted == false);
                if (!string.IsNullOrEmpty(ProductGeneralName))
                {
                    druginfo = druginfo.Where(r => r.ProductGeneralName.Contains(ProductGeneralName) || (r.Pinyin != null && r.Pinyin.Contains(ProductGeneralName)));
                }
                if (!string.IsNullOrEmpty(StandardCode))
                {
                    druginfo = druginfo.Where(r => r.FactoryName.Contains(StandardCode));
                }



                var query = from i in drugInventoryRecords
                            join d in druginfo on i.DrugInfoId equals d.Id
                            join w in BusinessHandlerFactory.RepositoryProvider.Db.WarehouseZones on i.WarehouseZoneId equals w.Id

                            join pid in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseInInventeryOrderDetails.Where(r => !r.Deleted) on i.PurchaseInInventeryOrderDetailId equals pid.Id into left
                            from l in left.DefaultIfEmpty()
                            join pi in RepositoryProvider.Db.PurchaseInInventeryOrders on l.PurchaseInInventeryOrderId equals pi.Id into left3
                            from l3 in left3.DefaultIfEmpty()
                            join p in RepositoryProvider.Db.PurchaseOrders on l3.PurchaseOrderId equals p.Id into left2
                            from l2 in left2.DefaultIfEmpty()
                            join s in RepositoryProvider.Db.SupplyUnits on l2.SupplyUnitId equals s.Id into left4
                            from l4 in left4.DefaultIfEmpty()
                            select new InventeryModel
                            {
                                InventoryID = i.Id,
                                DictionaryMeasurementUnitCode = d.DictionaryMeasurementUnitCode,
                                DictionarySpecificationCode = d.DictionarySpecificationCode,
                                FactoryName = d.FactoryName,
                                DictionaryDosageCode = d.DictionaryDosageCode,
                                ProductGeneralName = d.ProductGeneralName,
                                LicensePermissionNumber = d.LicensePermissionNumber,
                                BatchNumber = i.BatchNumber,
                                CurrentInventoryCount = i.CurrentInventoryCount,
                                PurchasePrice = i.PurchasePricce,
                                StandardCode = d.StandardCode,
                                WarehouseZoneName = w.Name,
                                CanSaleNum = i.CanSaleNum,
                                OutValidDate = i.OutValidDate,
                                PruductDate = i.PruductDate,
                                isValid = i.Valid,
                                DismantingAmount = i.DismantingAmount,
                                Origin = i.Decription,
                                DrugInfoId = i.DrugInfoId,
                                SupplyUnitName = l == null ? "前期库存，无入库信息" : l4.Name,
                                PurchaseOrderDocumentNumber = l == null ? "前期库存，无入库信息" : l2.DocumentNumber,
                                PurchaseOrderId = l == null ? Guid.Empty : l2.Id
                            };
                var records = query.OrderByDescending(p => p.CurrentInventoryCount).OrderBy(r => r.OutValidDate).ToList();
                List<InventeryModel> outRecord = new List<InventeryModel>();
                decimal totalQuantityCount = 0;
                decimal totalPriceCount = 0;
                foreach (var r in records)
                {
                    totalQuantityCount += r.CanSaleNum;
                    totalPriceCount += r.CanSaleNum * r.PurchasePrice;
                }

                foreach (var r in records)
                {
                    r.TotalQuantityCount = totalQuantityCount;
                    r.TotalPriceCount = totalPriceCount;
                    r.PriceCount = r.CanSaleNum * r.PurchasePrice;
                    r.RecordCount = records.Count;
                    outRecord.Add(r);
                }

                bool combine = false;
                bool isValid;
                if (searchConditions != null)
                {
                    combine = Convert.ToBoolean(searchConditions.First());

                    //批次锁定查询
                    //if (searchConditions.Count == 2)
                    //{
                    //    if (isValid = Convert.ToBoolean(searchConditions[1]))
                    //    {
                    //        outRecord = outRecord.Where(r => r.CanSaleNum > 0 && !r.isValid).ToList();
                    //    }
                    //}
                }
                if (combine)
                {
                    var comb = from i in outRecord group i by new { i.FactoryName, i.ProductGeneralName, i.DictionarySpecificationCode };
                    List<InventeryModel> list = new List<InventeryModel>();
                    foreach (var c in comb)
                    {
                        var i = c.First();
                        string batch = string.Empty;
                        foreach (var v in c)
                        {
                            batch += "批次号：" + v.BatchNumber + "，可销售数量：" + v.CanSaleNum + "|\n";
                        }
                        i.BatchNumber = batch;
                        i.CanSaleNum = c.Sum(r => r.CanSaleNum);
                        i.PriceCount = c.Sum(r => r.PriceCount);
                        i.CurrentInventoryCount = c.Sum(r => r.CurrentInventoryCount);
                        i.CurrentInventoryCount = c.Sum(r => r.CurrentInventoryCount);
                        list.Add(i);
                    }
                    return list.Skip((index - 1) * size).Take(size).ToList();
                }
                else
                {
                    return outRecord.Skip((index - 1) * size).Take(size).ToList();
                }
            }
            catch (Exception ex)
            {
                return this.HandleException<List<InventeryModel>>("仓储查询失败", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        /// <summary>
        /// 获取库存损益信息
        /// </summary>
        /// <param name="type">type:0-未申报损益库存；1-已申报损益库存；2-近效期查询</param>
        /// <returns>Ienumerable</returns>
        public IEnumerable<DrugInventoryRecord> GetDrugInventoryRecordPL(string kw, int type)
        {
            try
            {
                var c = this.Queryable;
                if (type == 1)
                {
                    c = this.Queryable.Where(r => r.DismantingAmount != 0);
                }
                if (type == 0)
                {
                    c = this.Queryable.Where(r => r.DismantingAmount == 0);
                }

                if (kw != string.Empty)
                {
                    kw = kw.ToUpper();
                    c = c.Where(r => r.DrugInfo.Pinyin.ToUpper().Contains(kw) || r.DrugInfo.ProductGeneralName.ToUpper().Contains(kw));
                }
                return c;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 近效期查询
        /// </summary>
        /// <param name="Month"></param>
        /// <param name="keyword"></param>
        /// <param name="MaintainType">0-全部1-重点2-普通3-医疗器械</param>
        /// <returns></returns>
        public IEnumerable<BugsBox.Pharmacy.Business.Models.DrugInventoryNearExpiration> GetDrugInventoryRecordNearExpirationDate(int Month, string keyword, int MaintainType)
        {
            var all = this.Queryable;
            DateTime dt = DateTime.Now.AddMonths(Month);
            all = all.Where(r => r.OutValidDate <= dt && r.CanSaleNum > 0);
            if (!string.IsNullOrEmpty(keyword))
            {
                all = all.Where(r => r.DrugInfo.Pinyin != null && r.DrugInfo.Pinyin.ToUpper().Contains(keyword.ToUpper()) || r.DrugInfo.ProductGeneralName.Contains(keyword));
            }

            if (MaintainType == 1)
            {
                all = all.Where(r => r.DrugInfo.IsMainMaintenance);
            }

            if (MaintainType == 2)
            {
                all = all.Where(r => r.DrugInfo.IsMainMaintenance == false);
            }

            if (MaintainType == 3)
            {
                all = all.Where(r => r.DrugInfo.BusinessScopeCode.Contains("器械"));
            }

            var u = from i in all
                    join j in RepositoryProvider.Db.PurchaseInInventeryOrderDetails on
                    i.PurchaseInInventeryOrderDetailId equals j.Id into left
                    from le in left.DefaultIfEmpty()
                    select new BugsBox.Pharmacy.Business.Models.DrugInventoryNearExpiration
                    {
                        canSaleNum = i.CanSaleNum,
                        DrugInfoId = i.DrugInfoId,
                        dosage = i.DrugInfo.DictionaryDosageCode,
                        factoryName = i.DrugInfo.FactoryName,
                        id = i.Id,
                        invalidDate = i.OutValidDate,
                        isMaitain = i.DrugInfo.IsMainMaintenance ? "是" : "否",
                        permitionCode = i.DrugInfo.LicensePermissionNumber,
                        productGeneralName = i.DrugInfo.ProductGeneralName,
                        shelf = i.WarehouseZone.Name,
                        specific = i.DrugInfo.DictionarySpecificationCode,
                        Origin = i.Decription == null ? i.DrugInfo.Origin : i.Decription,
                        batchNumber = i.BatchNumber,
                        ArrivalDate = le == null ? DateTime.Now : le.ArrivalDateTime,

                    };
            return u;
        }

        public bool CheckSpecial(OutInventory oi)
        {
            bool b = false;
            foreach (var o in oi.SalesOutInventoryDetails)
            {
                return false;
            }
            return true;
        }

        public System.Collections.Generic.IEnumerable<DrugInventoryRecord> GetDrugInventoryRecordBySalesOrderId(Guid SoId)
        {
            if (SoId == null || SoId == Guid.Empty) return null;
            var c = BusinessHandlerFactory.SalesOrderBusinessHandler.Get(SoId);
            if (c == null) return null;

            var result = from i in c.SalesOrderDetails.Where(r => !r.Deleted)
                         join d in this.Queryable.Where(r => !r.Deleted)
                         on i.DrugInventoryRecordID equals d.Id
                         select d;
            return result;
        }


        public System.Collections.Generic.IEnumerable<Business.Models.InventeryModel> GetDrugsInventoryRecordToUnqualification(bool IsOutDate, string DrugPY, string BatchNumber)
        {
            DateTime FirstDaterOfTheNextMonth = DateTime.Now.Date.AddMonths(1).AddDays(-DateTime.Now.Day + 1);
            var c = this.Queryable.Where(r => r.CanSaleNum > 0 && r.Deleted == false);
            if (!string.IsNullOrEmpty(BatchNumber))
            {
                c = c.Where(r => r.BatchNumber.Contains(BatchNumber));
            }

            if (IsOutDate)
            {
                c = c.Where(r => r.OutValidDate <= FirstDaterOfTheNextMonth);
            }

            var DrugInfos = RepositoryProvider.Db.DrugInfos.AsQueryable();

            if (!string.IsNullOrEmpty(DrugPY))
            {
                DrugInfos = DrugInfos.Where(r => r.Pinyin.Contains(DrugPY));
            }

            var result = from i in c
                         join j in DrugInfos on i.DrugInfoId equals j.Id
                         join w in RepositoryProvider.Db.WarehouseZones on i.WarehouseZoneId equals w.Id
                         join k in RepositoryProvider.Db.PurchaseInInventeryOrderDetails on i.PurchaseInInventeryOrderDetailId equals k.Id into left
                         from l in left.DefaultIfEmpty()
                         join m in RepositoryProvider.Db.PurchaseInInventeryOrders on l.PurchaseInInventeryOrderId equals m.Id into left1
                         from l1 in left1.DefaultIfEmpty()
                         join p in RepositoryProvider.Db.PurchaseOrders on l1.PurchaseOrderId equals p.Id into left2
                         from l2 in left2.DefaultIfEmpty()
                         join s in RepositoryProvider.Db.SupplyUnits on l2.SupplyUnitId equals s.Id into left3
                         from l3 in left3.DefaultIfEmpty()
                         select new Business.Models.InventeryModel
                         {
                             InventoryID = i.Id,
                             BatchNumber = i.BatchNumber,
                             CanSaleNum = i.CanSaleNum,
                             CurrentInventoryCount = i.CurrentInventoryCount,
                             DictionaryDosageCode = j.DictionaryDosageCode,
                             DictionaryMeasurementUnitCode = j.DictionaryMeasurementUnitCode,
                             DictionarySpecificationCode = j.DictionarySpecificationCode,
                             DrugInfoId = i.DrugInfoId,
                             FactoryName = j.FactoryName,
                             isValid = i.Valid,
                             LicensePermissionNumber = j.LicensePermissionNumber,
                             Origin = i.Decription,
                             OutValidDate = i.OutValidDate,
                             ProductGeneralName = j.ProductGeneralName,
                             PruductDate = i.PruductDate,
                             PurchaseOrderDocumentNumber = l == null ? "历史库存" : l2.DocumentNumber,
                             PurchaseOrderId = l == null ? Guid.Empty : l2.Id,
                             PurchasePrice = i.PurchasePricce,
                             StandardCode = j.StandardCode,
                             SupplyUnitName = l == null ? "历史库存，无入库信息" : l3.Name,
                             WarehouseZoneName = w.Name,
                             IsOutDate = i.OutValidDate < FirstDaterOfTheNextMonth ? "已过期" : "未过期"
                         };
            return result;
        }

        /// <summary>
        /// 品种质量追溯
        /// </summary>
        /// <param name="DrugInfoId"></param>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerable<Business.Models.DrugQualityTraceModel> GetAllDrugUnqualityTrace(Guid DrugInfoId)
        {
            var c = this.Queryable.Where(r => r.DrugInfoId == DrugInfoId && r.drugsUnqualicationNum > 0 && r.PurchaseInInventeryOrderDetailId != Guid.Empty);

            if (c.Count() <= 0) return null;

            var re = from i in c
                     join d in RepositoryProvider.Db.DrugsUnqualications on
                     i.Id equals d.DrugInventoryRecordID
                     join pid in RepositoryProvider.Db.PurchaseInInventeryOrderDetails.Where(r => !r.Deleted)
                     on i.PurchaseInInventeryOrderDetailId equals pid.Id
                     join pi in RepositoryProvider.Db.PurchaseInInventeryOrders.Where(r => !r.Deleted)
                     on pid.PurchaseInInventeryOrderId equals pi.Id
                     join po in RepositoryProvider.Db.PurchaseOrders on pi.PurchaseOrderId equals po.Id
                     join s in RepositoryProvider.Db.SupplyUnits on po.SupplyUnitId equals s.Id
                     select new Business.Models.DrugQualityTraceModel
                     {
                         Amount = d.quantity,
                         BatchNumber = i.BatchNumber,
                         BusinessScope = i.DrugInfo.BusinessScopeCode,
                         Dosage = i.DrugInfo.DictionaryDosageCode,
                         DrugInfoId = i.DrugInfoId,
                         DrugName = i.DrugInfo.ProductGeneralName,
                         Factory = i.DrugInfo.FactoryName,
                         LiscencePermitNumber = i.DrugInfo.LicensePermissionNumber,
                         MeasureMent = i.DrugInfo.DictionaryMeasurementUnitCode,
                         OutValidDate = i.DrugInfo.ValidPeriod,
                         Specific = i.DrugInfo.DictionarySpecificationCode,
                         StorageCondition = i.DrugInfo.DrugStorageTypeCode,
                         Treatmethod = "不合格处理",
                         UnQualityDate = d.createTime,
                         UnQualityReason = d.Description,
                         Suplyer = s.Name,
                         InInventoryDate = pi.OperateTime
                     };

            return re;
        }

        //public System.Collections.Generic.IEnumerable<Business.Models.DrugQualityTraceModel> GetAllDrugUnqualityTraceBySupplyUnitId(Guid SupplyUnitId)
        //{



        //    var c = this.Queryable.Where(r => r.DrugInfoId == DrugInfoId && r.drugsUnqualicationNum > 0 && r.PurchaseInInventeryOrderDetailId != Guid.Empty);

        //    if (c.Count() <= 0) return null;

        //    var re = from i in c
        //             join d in RepositoryProvider.Db.drugsUnqualications on
        //             i.Id equals d.DrugInventoryRecordID
        //             join pid in RepositoryProvider.Db.PurchaseInInventeryOrderDetails.Where(r => !r.Deleted)
        //             on i.PurchaseInInventeryOrderDetailId equals pid.Id
        //             join pi in RepositoryProvider.Db.PurchaseInInventeryOrders.Where(r => !r.Deleted)
        //             on pid.PurchaseInInventeryOrderId equals pi.Id
        //             join po in RepositoryProvider.Db.PurchaseOrders on pi.PurchaseOrderId equals po.Id
        //             join s in RepositoryProvider.Db.SupplyUnits on po.SupplyUnitId equals s.Id
        //             select new Business.Models.DrugQualityTraceModel
        //             {
        //                 Amount = d.quantity,
        //                 BatchNumber = i.BatchNumber,
        //                 BusinessScope = i.DrugInfo.BusinessScopeCode,
        //                 Dosage = i.DrugInfo.DictionaryDosageCode,
        //                 DrugInfoId = i.DrugInfoId,
        //                 DrugName = i.DrugInfo.ProductGeneralName,
        //                 Factory = i.DrugInfo.FactoryName,
        //                 LiscencePermitNumber = i.DrugInfo.LicensePermissionNumber,
        //                 MeasureMent = i.DrugInfo.DictionaryMeasurementUnitCode,
        //                 OutValidDate = i.DrugInfo.ValidPeriod,
        //                 Specific = i.DrugInfo.DictionarySpecificationCode,
        //                 StorageCondition = i.DrugInfo.DrugStorageTypeCode,
        //                 Treatmethod = "不合格处理",
        //                 UnQualityDate = d.createTime,
        //                 UnQualityReason = d.Description,
        //                 Suplyer = s.Name,
        //                 InInventoryDate = pi.OperateTime
        //             };

        //    return re;
        //}

        //public System.Collections.Generic.IEnumerable<Business.Models.QualityEvaluationBySupplyer> GetQualityEvaluation()
        //{
        //    var c=RepositoryProvider.Db.drugsUnqualications.Where(r=>r.Supplyer)
        //}
    }
}
