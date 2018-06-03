using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.Config;
using System.Data.Entity;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class PurchaseOrderBusinessHandler
    {
        public readonly static object LockObj = new object();
        protected override IQueryable<PurchaseOrder> IncludeNavigationProperties(IQueryable<PurchaseOrder> queryable)
        {
            try
            {
                return base.Queryable.Include(r => r.PurchaseOrderDetails);
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<PurchaseOrder>>(ex.Message, ex);
            }
        }

        #region 记录查询
        public List<PurchaseRecord> GetPurchaseRecords(int type, string productGeneralName, DateTime startTime, DateTime endTime, Guid[] purchaseUnits, int index, int size)
        {

            string[] ss = productGeneralName.Split(new String[] { "|&|" }, StringSplitOptions.None);

            productGeneralName = ss[0];
            string specific = ss[1];
            string factoryName = ss[2];
            string origin = ss[3];

            try
            {
                List<PurchaseRecord> records = new List<PurchaseRecord>();
                var queryBuilder = QueryBuilder.Create<PurchaseOrder>()
               .Between(c => c.CreateTime, startTime.AddDays(-1), endTime.AddDays(1))
               .In(c => c.SupplyUnitId, purchaseUnits);

                var purchaseOrder = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders.Where(queryBuilder.Expression);
                // type=0 采购记录,
                // type=1 中药材采购记录,
                // type=2 中药饮片采购记录
                // type=3 随货同行单(票)
                if (type == 0)
                {
                    var query = from purchaseDetail in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrderDetails
                                join purchase in purchaseOrder on purchaseDetail.PurchaseOrderId equals purchase.Id
                                join drup in BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos on purchaseDetail.DrugInfoId equals drup.Id
                                where (drup.ProductGeneralName.Contains(productGeneralName) || drup.Pinyin.Contains(productGeneralName))
                                join story in BusinessHandlerFactory.RepositoryProvider.Db.Stores on purchaseDetail.StoreId equals story.Id
                                join supplyUnit in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on purchase.SupplyUnitId equals supplyUnit.Id
                                select new PurchaseRecord
                                {
                                    DrugInfoId = purchaseDetail.DrugInfoId,
                                    ProductGeneralName = drup.ProductGeneralName,
                                    DictionaryDosageCode = drup.DictionaryDosageCode,
                                    DictionarySpecificationCode = drup.DictionarySpecificationCode,
                                    ReceiveUnit = story.Name,
                                    SuplyUnit = supplyUnit.Name,
                                    Amount = purchaseDetail.Amount,
                                    Price = purchaseDetail.PurchasePrice,
                                    PurchaseDate = purchaseDetail.CreateTime,
                                    Origin = drup.Origin,
                                    FactoryName = drup.FactoryName,
                                    LicensePermissionNumber = drup.LicensePermissionNumber,
                                    Money = decimal.Round(purchaseDetail.PurchasePrice * purchaseDetail.Amount, 4)
                                };
                    records = query.Where(p => p.DictionarySpecificationCode.Contains(specific) && p.FactoryName.Contains(factoryName) && p.Origin.Contains(origin)).OrderByDescending(p => p.PurchaseDate).ToList();
                }
                if (type == 1)
                {
                    var query = from purchaseDetail in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrderDetails
                                join purchase in purchaseOrder on purchaseDetail.PurchaseOrderId equals purchase.Id
                                join drup in BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos on purchaseDetail.DrugInfoId equals drup.Id
                                where (drup.ProductGeneralName.Contains(productGeneralName) || drup.Pinyin.Contains(productGeneralName))
                                join story in BusinessHandlerFactory.RepositoryProvider.Db.Stores on purchaseDetail.StoreId equals story.Id
                                join supplyUnit in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on purchase.SupplyUnitId equals supplyUnit.Id
                                where drup.BusinessScopeCode == "中药材"
                                select new PurchaseRecord
                                {
                                    DrugInfoId = purchaseDetail.DrugInfoId,
                                    ProductGeneralName = drup.ProductGeneralName,
                                    DictionaryDosageCode = drup.DictionaryDosageCode,
                                    DictionarySpecificationCode = drup.DictionarySpecificationCode,
                                    ReceiveUnit = story.Name,
                                    SuplyUnit = supplyUnit.Name,
                                    Amount = purchaseDetail.Amount,
                                    Price = purchaseDetail.PurchasePrice,
                                    PurchaseDate = purchaseDetail.CreateTime,
                                    Origin = drup.Origin,
                                    FactoryName = drup.FactoryName,
                                    LicensePermissionNumber = drup.LicensePermissionNumber,
                                    Money = decimal.Round(purchaseDetail.PurchasePrice * purchaseDetail.Amount, 4)
                                };
                    records = query.Where(p => p.DictionarySpecificationCode.Contains(specific) && p.FactoryName.Contains(factoryName) && p.Origin.Contains(origin)).OrderByDescending(p => p.PurchaseDate).ToList();
                }
                if (type == 2)
                {
                    var query = from purchaseDetail in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrderDetails
                                join purchase in purchaseOrder on purchaseDetail.PurchaseOrderId equals purchase.Id
                                join drup in BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos on purchaseDetail.DrugInfoId equals drup.Id
                                where (drup.ProductGeneralName.Contains(productGeneralName) || drup.Pinyin.Contains(productGeneralName))
                                join story in BusinessHandlerFactory.RepositoryProvider.Db.Stores on purchaseDetail.StoreId equals story.Id
                                join supplyUnit in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on purchase.SupplyUnitId equals supplyUnit.Id
                                where drup.BusinessScopeCode == "中药饮片"
                                select new PurchaseRecord
                                {
                                    DrugInfoId = purchaseDetail.DrugInfoId,
                                    ProductGeneralName = drup.ProductGeneralName,
                                    DictionaryDosageCode = drup.DictionaryDosageCode,
                                    DictionarySpecificationCode = drup.DictionarySpecificationCode,
                                    ReceiveUnit = story.Name,
                                    SuplyUnit = supplyUnit.Name,
                                    Amount = purchaseDetail.Amount,
                                    Price = purchaseDetail.PurchasePrice,
                                    PurchaseDate = purchaseDetail.CreateTime,
                                    Origin = drup.Origin,
                                    FactoryName = drup.FactoryName,
                                    LicensePermissionNumber = drup.LicensePermissionNumber,
                                    Money = decimal.Round(purchaseDetail.PurchasePrice * purchaseDetail.Amount, 4)
                                };
                    records = query.Where(p => p.DictionarySpecificationCode.Contains(specific) && p.FactoryName.Contains(factoryName) && p.Origin.Contains(origin)).OrderByDescending(p => p.PurchaseDate).ToList();
                }
                else if (type == 3)
                {
                    var query = from purchaseDetail in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrderDetails
                                join purchase in purchaseOrder on purchaseDetail.PurchaseOrderId equals purchase.Id
                                join drup in BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos on purchaseDetail.DrugInfoId equals drup.Id
                                where (drup.ProductGeneralName.Contains(productGeneralName) || drup.Pinyin.Contains(productGeneralName))
                                join story in BusinessHandlerFactory.RepositoryProvider.Db.Stores on purchaseDetail.StoreId equals story.Id
                                join supplyUnit in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on purchase.SupplyUnitId equals supplyUnit.Id
                                join receivingOrder in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseReceivingOrders on purchase.Id equals receivingOrder.PurchaseOrderId into receiving
                                from receivingOrder in receiving.DefaultIfEmpty()
                                join checkingOrder in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrders on purchase.Id equals checkingOrder.PurchaseOrderId into checking
                                from checkingOrder in checking.DefaultIfEmpty()
                                join checkingOrderDetail in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrderDetails on checkingOrder.Id equals checkingOrderDetail.PurchaseCheckingOrderId into checkingDetail
                                from checkingOrderDetail in checkingDetail.DefaultIfEmpty()
                                select new PurchaseRecord
                                {
                                    DrugInfoId = purchaseDetail.DrugInfoId,
                                    ProductGeneralName = drup.ProductGeneralName,
                                    DictionaryDosageCode = drup.DictionaryDosageCode,
                                    DictionarySpecificationCode = drup.DictionarySpecificationCode,
                                    ReceiveUnit = story.Name,
                                    SuplyUnit = supplyUnit.Name,
                                    Amount = purchaseDetail.Amount,
                                    Price = purchaseDetail.PurchasePrice,
                                    PurchaseDate = purchaseDetail.CreateTime,
                                    Origin = drup.Origin,
                                    FactoryName = drup.FactoryName,
                                    BatchNumber = checkingOrderDetail != null ? checkingOrderDetail.BatchNumber : "",
                                    ReceiveAddress = story.Address,
                                    ShippingTime = receivingOrder != null ? receivingOrder.ShippingTime : DateTime.MaxValue,
                                    LicensePermissionNumber = drup.LicensePermissionNumber,
                                    Money = decimal.Round(purchaseDetail.PurchasePrice * purchaseDetail.Amount, 4)
                                };
                    records = query.Where(p => p.DictionarySpecificationCode.Contains(specific) && p.FactoryName.Contains(factoryName) && p.Origin.Contains(origin)).OrderByDescending(p => p.PurchaseDate).ToList();
                }

                if (type == (int)PurchaseRecordType.YLQXCGJL)
                {
                    var query = from purchaseDetail in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrderDetails
                                join purchase in purchaseOrder on purchaseDetail.PurchaseOrderId equals purchase.Id
                                join drup in BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos on purchaseDetail.DrugInfoId equals drup.Id
                                where (drup.ProductGeneralName.Contains(productGeneralName) || drup.Pinyin.Contains(productGeneralName))
                                join story in BusinessHandlerFactory.RepositoryProvider.Db.Stores on purchaseDetail.StoreId equals story.Id
                                join supplyUnit in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on purchase.SupplyUnitId equals supplyUnit.Id
                                where drup.BusinessScopeCode == "医疗器械"
                                select new PurchaseRecord
                                {
                                    DrugInfoId = purchaseDetail.DrugInfoId,
                                    ProductGeneralName = drup.ProductGeneralName,
                                    DictionaryDosageCode = drup.DictionaryDosageCode,
                                    DictionarySpecificationCode = drup.DictionarySpecificationCode,
                                    ReceiveUnit = story.Name,
                                    SuplyUnit = supplyUnit.Name,
                                    Amount = purchaseDetail.Amount,
                                    Price = purchaseDetail.PurchasePrice,
                                    PurchaseDate = purchaseDetail.CreateTime,
                                    Origin = drup.Origin,
                                    FactoryName = drup.FactoryName,
                                    LicensePermissionNumber = drup.LicensePermissionNumber,
                                    Money = decimal.Round(purchaseDetail.PurchasePrice * purchaseDetail.Amount, 4)
                                };
                    records = query.Where(p => p.DictionarySpecificationCode.Contains(specific) && p.FactoryName.Contains(factoryName) && p.Origin.Contains(origin)).OrderByDescending(p => p.PurchaseDate).ToList();
                }
                List<PurchaseRecord> outRecord = new List<PurchaseRecord>();
                foreach (var r in records)
                {
                    r.RecordCount = records.Count;
                    outRecord.Add(r);
                }
                return outRecord.Skip((index - 1) * size).Take(size).ToList(); ;
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseRecord>>("查询采购记录失败", ex);
            }
        }
        public List<PurchaseRCRecord> GetPurchaseRCRecords(int type, string productGeneralName, DateTime startTime, DateTime endTime, Guid[] purchaseUnits, int index, int size)
        {
            // type=4 收货记录,
            // type=5 拒收记录,
            // type=6 验收记录
            // type=7 中药材验收记录
            // type=8 中药饮片验收记录

            string[] ss = productGeneralName.Split(new String[] { "|&|" }, StringSplitOptions.None);

            productGeneralName = ss[0];
            string specific = ss[1];
            string factoryName = ss[2];
            string origin = ss[3];

            List<PurchaseRCRecord> records = new List<PurchaseRCRecord>();
            var queryBuilder = QueryBuilder.Create<PurchaseOrder>()
           .Between(c => c.CreateTime, startTime.AddDays(-1), endTime.AddDays(1))
           .In(c => c.SupplyUnitId, purchaseUnits);
            var purchaseOrder = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders.Where(queryBuilder.Expression);
            switch (type)
            {
                case 4:
                    var query = from receivingDetail in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseReceivingOrderDetails
                                join receiving in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseReceivingOrders on receivingDetail.PurchaseReceivingOrderId equals receiving.Id
                                join purchase in purchaseOrder on receiving.PurchaseOrderId equals purchase.Id
                                join drup in BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos on receivingDetail.DrugInfoId equals drup.Id
                                where drup.Pinyin.Contains(productGeneralName) || drup.ProductGeneralName.Contains(productGeneralName)
                                join supplyUnit in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on purchase.SupplyUnitId equals supplyUnit.Id
                                where receivingDetail.CheckResult == 0
                                select new PurchaseRCRecord
                                {
                                    ArrivalAmount = receivingDetail.ActualAmount,
                                    ArrivalDate = receiving.OperateTime,
                                    DictionaryDosageCode = drup.DictionaryDosageCode,
                                    DrugInfoId = drup.Id,
                                    DictionarySpecificationCode = drup.DictionarySpecificationCode,
                                    FactoryName = drup.FactoryName,
                                    LicensePermissionNumber = drup.LicensePermissionNumber,
                                    //Origin = drup.Origin,
                                    Decription = receivingDetail.Decription,
                                    ProductGeneralName = drup.ProductGeneralName,
                                    PurchaseDate = purchase.CreateTime,
                                    SuplyUnit = supplyUnit.Name
                                };
                    records = query.Where(p => p.DictionarySpecificationCode.Contains(specific) && p.FactoryName.Contains(factoryName)).OrderByDescending(p => p.ArrivalDate).ToList();
                    break;
                case 5:
                    query = from receivingDetail in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseReceivingOrderDetails
                            join receiving in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseReceivingOrders on receivingDetail.PurchaseReceivingOrderId equals receiving.Id
                            join purchase in purchaseOrder on receiving.PurchaseOrderId equals purchase.Id
                            join drup in BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos on receivingDetail.DrugInfoId equals drup.Id
                            where drup.Pinyin.Contains(productGeneralName) || drup.ProductGeneralName.Contains(productGeneralName)
                            join supplyUnit in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on purchase.SupplyUnitId equals supplyUnit.Id
                            where receivingDetail.CheckResult == 1
                            select new PurchaseRCRecord
                            {
                                ArrivalAmount = receivingDetail.ActualAmount,
                                ArrivalDate = receiving.OperateTime,
                                DictionaryDosageCode = drup.DictionaryDosageCode,
                                DrugInfoId = drup.Id,
                                DictionarySpecificationCode = drup.DictionarySpecificationCode,
                                FactoryName = drup.FactoryName,
                                LicensePermissionNumber = drup.LicensePermissionNumber,
                                //Origin = drup.Origin,
                                Decription = receivingDetail.Decription,
                                ProductGeneralName = drup.ProductGeneralName,
                                PurchaseDate = purchase.CreateTime,
                                SuplyUnit = supplyUnit.Name
                            };
                    records = query.Where(p => p.DictionarySpecificationCode.Contains(specific) && p.FactoryName.Contains(factoryName)).OrderByDescending(p => p.ArrivalDate).ToList();
                    break;
                case 6:
                    query = from checkingDetail in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrderDetails
                            join checking in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrders on checkingDetail.PurchaseCheckingOrderId equals checking.Id
                            join purchase in purchaseOrder on checking.PurchaseOrderId equals purchase.Id
                            join drup in BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos on checkingDetail.DrugInfoId equals drup.Id
                            where drup.Pinyin.Contains(productGeneralName) || drup.ProductGeneralName.Contains(productGeneralName)
                            join user in BusinessHandlerFactory.RepositoryProvider.Db.Users on checking.OperateUserId equals user.Id
                            join em in BusinessHandlerFactory.RepositoryProvider.Db.Employees on user.EmployeeId equals em.Id
                            join supplyUnit in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on purchase.SupplyUnitId equals supplyUnit.Id
                            select new PurchaseRCRecord
                            {
                                ArrivalAmount = checkingDetail.ArrivalAmount,
                                ArrivalDate = checkingDetail.ArrivalDateTime,
                                DictionaryDosageCode = drup.DictionaryDosageCode,
                                DrugInfoId = drup.Id,
                                DictionarySpecificationCode = drup.DictionarySpecificationCode,
                                FactoryName = drup.FactoryName,
                                LicensePermissionNumber = drup.LicensePermissionNumber,
                                //Origin = drup.Origin,
                                Decription = checkingDetail.Decription,
                                ProductGeneralName = drup.ProductGeneralName,
                                PurchaseDate = purchase.CreateTime,
                                SuplyUnit = supplyUnit.Name,
                                BatchNumber = checkingDetail.BatchNumber,
                                CheckDate = checking.OperateTime,
                                CheckMan = em.Name,
                                SpecialChecker = checking.SecondCheckerName,
                                SpecialCheckMemo = checking.SecondCheckMemo,
                                CheckResult = checkingDetail.CheckResult,
                                OutValidDate = checkingDetail.OutValidDate,
                                PruductDate = checkingDetail.PruductDate,
                                QualifiedAmount = checkingDetail.QualifiedAmount
                            };
                    records = query.Where(p => p.DictionarySpecificationCode.Contains(specific) && p.FactoryName.Contains(factoryName)).OrderByDescending(p => p.CheckDate).ToList();
                    break;
                case 7:
                    query = from checkingDetail in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrderDetails
                            join checking in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrders on checkingDetail.PurchaseCheckingOrderId equals checking.Id
                            join purchase in purchaseOrder on checking.PurchaseOrderId equals purchase.Id
                            join drup in BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos on checkingDetail.DrugInfoId equals drup.Id
                            where drup.Pinyin.Contains(productGeneralName) || drup.ProductGeneralName.Contains(productGeneralName)
                            join user in BusinessHandlerFactory.RepositoryProvider.Db.Users on checking.OperateUserId equals user.Id
                            join em in BusinessHandlerFactory.RepositoryProvider.Db.Employees on user.EmployeeId equals em.Id
                            join supplyUnit in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on purchase.SupplyUnitId equals supplyUnit.Id
                            where drup.BusinessScopeCode == "中药材"
                            select new PurchaseRCRecord
                            {
                                ArrivalAmount = checkingDetail.ArrivalAmount,
                                ArrivalDate = checkingDetail.ArrivalDateTime,
                                DictionaryDosageCode = drup.DictionaryDosageCode,
                                DrugInfoId = drup.Id,
                                DictionarySpecificationCode = drup.DictionarySpecificationCode,
                                FactoryName = drup.FactoryName,
                                LicensePermissionNumber = drup.LicensePermissionNumber,
                                //Origin = drup.Origin,
                                Decription = checkingDetail.Decription,
                                ProductGeneralName = drup.ProductGeneralName,
                                PurchaseDate = purchase.CreateTime,
                                SuplyUnit = supplyUnit.Name,
                                BatchNumber = checkingDetail.BatchNumber,
                                CheckDate = checking.OperateTime,
                                CheckMan = em.Name,
                                SpecialChecker = checking.SecondCheckerName,
                                SpecialCheckMemo = checking.SecondCheckMemo,
                                CheckResult = checkingDetail.CheckResult,
                                OutValidDate = checkingDetail.OutValidDate,
                                PruductDate = checkingDetail.PruductDate,
                                QualifiedAmount = checkingDetail.QualifiedAmount
                            };
                    records = query.Where(p => p.DictionarySpecificationCode.Contains(specific) && p.FactoryName.Contains(factoryName)).OrderByDescending(p => p.CheckDate).ToList();
                    break;
                case 8:
                    query = from checkingDetail in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrderDetails
                            join checking in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrders on checkingDetail.PurchaseCheckingOrderId equals checking.Id
                            join purchase in purchaseOrder on checking.PurchaseOrderId equals purchase.Id
                            join drup in BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos on checkingDetail.DrugInfoId equals drup.Id
                            where drup.Pinyin.Contains(productGeneralName) || drup.ProductGeneralName.Contains(productGeneralName)
                            join user in BusinessHandlerFactory.RepositoryProvider.Db.Users on checking.OperateUserId equals user.Id
                            join em in BusinessHandlerFactory.RepositoryProvider.Db.Employees on user.EmployeeId equals em.Id
                            join supplyUnit in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on purchase.SupplyUnitId equals supplyUnit.Id
                            where drup.BusinessScopeCode == "中药饮片"
                            select new PurchaseRCRecord
                            {
                                ArrivalAmount = checkingDetail.ArrivalAmount,
                                ArrivalDate = checkingDetail.ArrivalDateTime,
                                DictionaryDosageCode = drup.DictionaryDosageCode,
                                DrugInfoId = drup.Id,
                                DictionarySpecificationCode = drup.DictionarySpecificationCode,
                                FactoryName = drup.FactoryName,
                                LicensePermissionNumber = drup.LicensePermissionNumber,
                                //Origin = drup.Origin,
                                Decription = checkingDetail.Decription,
                                ProductGeneralName = drup.ProductGeneralName,
                                PurchaseDate = purchase.CreateTime,
                                SuplyUnit = supplyUnit.Name,
                                BatchNumber = checkingDetail.BatchNumber,
                                CheckDate = checking.OperateTime,
                                CheckMan = em.Name,
                                SpecialChecker = checking.SecondCheckerName,
                                SpecialCheckMemo = checking.SecondCheckMemo,
                                CheckResult = checkingDetail.CheckResult,
                                OutValidDate = checkingDetail.OutValidDate,
                                //PruductDate = checkingDetail.PruductDate,
                                QualifiedAmount = checkingDetail.QualifiedAmount
                            };
                    records = query.Where(p => p.DictionarySpecificationCode.Contains(specific) && p.FactoryName.Contains(factoryName)).OrderByDescending(p => p.CheckDate).ToList();
                    break;
                case 9:
                    query = from checkingDetail in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrderDetails
                            join checking in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrders on checkingDetail.PurchaseCheckingOrderId equals checking.Id
                            join purchase in purchaseOrder on checking.PurchaseOrderId equals purchase.Id
                            join drup in BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos on checkingDetail.DrugInfoId equals drup.Id
                            where drup.Pinyin.Contains(productGeneralName) || drup.ProductGeneralName.Contains(productGeneralName)
                            join user in BusinessHandlerFactory.RepositoryProvider.Db.Users on checking.OperateUserId equals user.Id
                            join em in BusinessHandlerFactory.RepositoryProvider.Db.Employees on user.EmployeeId equals em.Id
                            join supplyUnit in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on purchase.SupplyUnitId equals supplyUnit.Id
                            where drup.BusinessScopeCode == "医疗器械"
                            select new PurchaseRCRecord
                            {
                                ArrivalAmount = checkingDetail.ArrivalAmount,
                                ArrivalDate = checkingDetail.ArrivalDateTime,
                                DictionaryDosageCode = drup.DictionaryDosageCode,
                                DrugInfoId = drup.Id,
                                DictionarySpecificationCode = drup.DictionarySpecificationCode,
                                FactoryName = drup.FactoryName,
                                LicensePermissionNumber = drup.LicensePermissionNumber,
                                //Origin = drup.Origin,
                                Decription = checkingDetail.Decription,
                                ProductGeneralName = drup.ProductGeneralName,
                                PurchaseDate = purchase.CreateTime,
                                SuplyUnit = supplyUnit.Name,
                                BatchNumber = checkingDetail.BatchNumber,
                                CheckDate = checking.OperateTime,
                                CheckMan = em.Name,
                                SpecialChecker = checking.SecondCheckerName,
                                SpecialCheckMemo = checking.SecondCheckMemo,
                                CheckResult = checkingDetail.CheckResult,
                                OutValidDate = checkingDetail.OutValidDate,
                                PruductDate = checkingDetail.PruductDate,
                                QualifiedAmount = checkingDetail.QualifiedAmount
                            };
                    records = query.Where(p => p.DictionarySpecificationCode.Contains(specific) && p.FactoryName.Contains(factoryName)).OrderByDescending(p => p.CheckDate).ToList();
                    break;
            }
            List<PurchaseRCRecord> outRecord = new List<PurchaseRCRecord>();
            foreach (var r in records)
            {
                r.RecordCount = records.Count;
                outRecord.Add(r);
            }
            return outRecord.Skip((index - 1) * size).Take(size).ToList(); ;
        }
        #endregion

        #region 查看药品采购纪录
        /// <summary>
        /// 查看药品采购纪录
        /// </summary>
        /// <returns></returns>
        public List<PurchaseOrderDetailEntity> GetPurchaseHistoryForDrugInfo(Guid drupInfoId)
        {
            try
            {
                var query = from i in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrderDetails
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos on i.DrugInfoId equals d.Id
                            join p in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders on i.PurchaseOrderId equals p.Id
                            join s in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on p.SupplyUnitId equals s.Id
                            where i.DrugInfoId == drupInfoId
                            select new PurchaseOrderDetailEntity
                            {
                                Id = d.Id,
                                ProductGeneralName = d.ProductGeneralName,
                                DictionaryMeasurementUnitCode = d.DictionaryMeasurementUnitCode,
                                DictionarySpecificationCode = d.DictionarySpecificationCode,
                                FactoryName = d.FactoryName,
                                DictionaryDosageCode = d.DictionaryDosageCode,
                                PurchasePrice = i.PurchasePrice,
                                Amount = i.Amount,
                                AmountOfTax = i.AmountOfTax,
                                DrugInfoId = i.DrugInfoId,
                                Price = d.Price,
                                PurchaseOrderId = i.PurchaseOrderId,
                                SupplyUnitId = s.Id,
                                SupplyUnitName = s.Name,
                                SupplyBusinessScope = s.BusinessScope,
                                SupplyContactTel = s.ContactTel,
                                SupplyUnitCode = s.Code,
                                SupplyUnitContactName = s.ContactName,
                                purchaseDate = p.CreateTime
                            };
                return query.OrderByDescending(p => p.PurchasePrice).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseOrderDetailEntity>>("查看药品采购纪录失败", ex);
            }
        }
        #endregion

        #region 采购单
        public PurchaseOrdeEntity GetPurchaseOrderEntity(Guid purchaseOrderId)
        {
            try
            {
                var queryBuilder = QueryBuilder.Create<PurchaseOrder>()
                 .Equals(c => c.Id, purchaseOrderId);

                var purchaseOrders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders.Where(queryBuilder.Expression);
                var query = from i in purchaseOrders
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on i.CreateUserId equals u.Id
                            join em in BusinessHandlerFactory.RepositoryProvider.Db.Employees on u.EmployeeId equals em.Id
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on i.SupplyUnitId equals d.Id
                            join s in BusinessHandlerFactory.RepositoryProvider.Db.Stores on i.StoreId equals s.Id
                            join saleman in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnitSalesmans on i.SupplyUnitId equals saleman.SupplyUnitId into temp
                            from saleman in temp.DefaultIfEmpty()
                            select new PurchaseOrdeEntity
                            {
                                Id = i.Id,
                                DocumentNumber = i.DocumentNumber,
                                EmployeeNumber = em.Number,
                                EmployeeName = em.Name,
                                CreateTime = i.CreateTime,
                                TotalMoney = i.TotalMoney,
                                OrderStatusValue = i.OrderStatusValue,
                                SupplyUnitName = d.Name,
                                SupplyUnitId = d.Id,
                                ReceiveUnit = s.Name,
                                Address = s.Address,
                                AllReceiptedDate = i.AllReceiptedDate,
                                Description = i.Decription,
                                ApprovalDecription = i.ApprovalDecription,
                                ApprovaledTime = i.ApprovaledTime,
                                ApprovalUserId = i.ApprovalUserId,
                                CreateUserId = i.CreateUserId,
                                ContactName = saleman != null ? saleman.Name : null,
                                ContactTel = saleman != null ? saleman.Tel : null,
                                SupplyUnitAccountExecutiveId = saleman != null ? saleman.Id : Guid.Empty,
                                AmountApprovaledTime = i.AmountApprovaledTime,
                                AmountApprovalDecription = i.AmountApprovalDecription,
                                AmountApprovalUserId = i.AmountApprovalUserId,
                                DirectMarketing = i.DirectMarketing,
                                PurchasedDate = i.PurchasedDate,
                                RecordCount = purchaseOrders.Count()
                            };

                return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return this.HandleException<PurchaseOrdeEntity>("根据编号获取采购记录失败", ex);
            }
        }
        //查询采购单
        public List<PurchaseOrdeEntity> GetPurchaseOrders(string documentNumber, DateTime startTime, DateTime endTime, int[] orderStatusValue, Guid[] purchaseUnits, int index, int size)
        {
            try
            {
                if (startTime == null)
                {
                    startTime = DateTime.MinValue;
                }
                if (endTime == null)
                {
                    endTime = DateTime.MaxValue;
                }
                var queryBuilder = QueryBuilder.Create<PurchaseOrder>()
                 .Like(q => q.DocumentNumber, documentNumber)
                 .Between(c => c.CreateTime, startTime.AddDays(-1), endTime.AddDays(1))
                 .In(c => c.SupplyUnitId, purchaseUnits)
                 .Equals(c => c.Deleted, false);
                if (orderStatusValue.Length > 0 && orderStatusValue[0] != -1)
                {
                    queryBuilder = queryBuilder.In(q => q.OrderStatusValue, orderStatusValue);
                }

                var purchaseOrders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders.Where(queryBuilder.Expression);

                var query = from i in purchaseOrders
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on i.CreateUserId equals u.Id
                            join em in BusinessHandlerFactory.RepositoryProvider.Db.Employees on u.EmployeeId equals em.Id
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on i.SupplyUnitId equals d.Id
                            join s in BusinessHandlerFactory.RepositoryProvider.Db.Stores on i.StoreId equals s.Id
                            join saleman in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnitSalesmans on i.SupplyUnitId equals saleman.SupplyUnitId into temp
                            from saleman in temp.DefaultIfEmpty()
                            select new PurchaseOrdeEntity
                            {
                                Id = i.Id,
                                DocumentNumber = i.DocumentNumber,
                                EmployeeNumber = em.Number,
                                EmployeeName = em.Name,
                                CreateTime = i.CreateTime,
                                TotalMoney = i.TotalMoney,
                                OrderStatusValue = i.OrderStatusValue,
                                SupplyUnitName = d.Name,
                                SupplyUnitId = d.Id,
                                ReceiveUnit = s.Name,
                                Address = s.Address,
                                AllReceiptedDate = i.AllReceiptedDate,
                                Description = i.Decription,
                                ApprovalDecription = i.ApprovalDecription,
                                ApprovaledTime = i.ApprovaledTime,
                                ApprovalUserId = i.ApprovalUserId,
                                CreateUserId = i.CreateUserId,
                                ContactName = saleman != null ? saleman.Name : null,
                                ContactTel = saleman != null ? saleman.Tel : null,
                                SupplyUnitAccountExecutiveId = saleman != null ? saleman.Id : Guid.Empty,
                                AmountApprovaledTime = i.AmountApprovaledTime,
                                AmountApprovalDecription = i.AmountApprovalDecription,
                                AmountApprovalUserId = i.AmountApprovalUserId,
                                DirectMarketing = i.DirectMarketing,
                                RecordCount = purchaseOrders.Count()
                            };

                return query.OrderByDescending(p => p.CreateTime).Skip((index - 1) * size).Take(size).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseOrdeEntity>>("查询采购记录失败", ex);
            }
        }
        //采购详细
        public List<PurchaseOrderDetailEntity> GetPurchaseOrderDetails(Guid purchaseOrderId)
        {
            try
            {

                var queryBuilder = QueryBuilder.Create<PurchaseOrderDetail>()
                .Equals(c => c.Deleted, false)
                .In(c => c.PurchaseOrderId, new Guid[] { purchaseOrderId });

                var purchaseOrderDetails = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrderDetails.Where(queryBuilder.Expression).OrderBy(r => r.sequence);
                var query = from i in purchaseOrderDetails
                                //join purchase in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders on i.PurchaseOrderId equals purchase.Id
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos on i.DrugInfoId equals d.Id
                            join s in BusinessHandlerFactory.RepositoryProvider.Db.Stores on i.StoreId equals s.Id
                            //join supply in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on purchase.SupplyUnitId equals supply.Id
                            select new PurchaseOrderDetailEntity
                            {
                                Id = i.Id,
                                Price = d.Price,
                                AmountOfTax = i.AmountOfTax,
                                Amount = i.Amount,
                                DictionaryMeasurementUnitCode = d.DictionaryMeasurementUnitCode,
                                DictionarySpecificationCode = d.DictionarySpecificationCode,
                                FactoryName = d.FactoryName,
                                DictionaryDosageCode = d.DictionaryDosageCode,
                                ProductGeneralName = d.ProductGeneralName,
                                PurchasePrice = i.PurchasePrice,
                                DrugInfoId = i.DrugInfoId,
                                PurchaseOrderId = i.PurchaseOrderId,
                                LicensePermissionNumber = d.LicensePermissionNumber,
                                sequence = i.sequence,
                                SupplyBusinessScope = d.BusinessScopeCode,

                            };

                return query.OrderBy(r => r.sequence).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseOrderDetailEntity>>("根据订单编号获取采购明细失败", ex);
            }
        }
        //创建采购单
        public string CreatePurchaseOrder(PurchaseOrder order, List<PurchaseOrderDetail> orderDetails)
        {
            try
            {
                lock (LockObj)
                {
                    PurchaseOrder existOrder = BusinessHandlerFactory.PurchaseOrderBusinessHandler.Get(order.Id);
                    if (existOrder == null)
                    {
                        order.Id = Guid.NewGuid();
                        order.DocumentNumber = new BillDocumentCodeBusinessHandler(BusinessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.PurchaseOrder).Code; ;
                        order.CreateTime = DateTime.Now;
                        order.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
                        order.UpdateTime = DateTime.Now;
                        order.UpdateUserId = order.CreateUserId;
                        order.PurchasedDate = DateTime.Now.Date;
                        order.PurchaseOrderConcatID = order.Id;
                        var SupplySalesMan = RepositoryProvider.Db.SupplyUnitSalesmans.Where(r => r.SupplyUnitId == order.SupplyUnitId).FirstOrDefault();
                        order.SupplyUnitAccountExecutiveId = SupplySalesMan == null ? Guid.Empty : SupplySalesMan.Id;
                        order.TotalMoney = orderDetails.Sum(r => r.Amount * r.PurchasePrice);
                        BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders.Add(order);
                    }
                    else
                    {
                        existOrder.OrderStatusValue = order.OrderStatusValue;
                        existOrder.UpdateTime = DateTime.Now;
                        existOrder.UpdateUserId = order.CreateUserId;
                        existOrder.Decription = order.Decription;
                        foreach (var i in existOrder.PurchaseOrderDetails.ToList())
                        {
                            RepositoryProvider.Db.PurchaseOrderDetails.Remove(i);
                        }
                        existOrder.TotalMoney = orderDetails.Sum(r => r.Amount * r.PurchasePrice);
                    }

                    foreach (PurchaseOrderDetail d in orderDetails)
                    {
                        d.Id = Guid.NewGuid();
                        d.CreateTime = DateTime.Now;
                        d.CreateUserId = order.CreateUserId;
                        d.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
                        d.UpdateTime = DateTime.Now;
                        d.UpdateUserId = order.UpdateUserId;
                        d.PurchaseOrderId = order.Id;
                        BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrderDetails.Add(d);
                    }

                    BusinessHandlerFactory.RepositoryProvider.Db.Commit();
                    return order.DocumentNumber;
                }
            }
            catch (Exception ex)
            {
                return this.HandleException<string>("创建采购单失败", ex);
            }
        }
        #endregion

        #region 收货

        //“采购记录”中某种药品的采购数量与到货数量不同，需经过审批修改采购数量（仅数量能修改）
        public void HandlePurchaseReceinvingAmountDiff(PurchaseOrder purchaseOrder)
        {
            try
            {
                PurchaseOrder order = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders.FirstOrDefault(p => p.Id == purchaseOrder.Id);
                order.OrderStatusValue = purchaseOrder.OrderStatusValue;
                order.AmountApprovalUserId = purchaseOrder.AmountApprovalUserId;
                order.AmountApprovaledTime = purchaseOrder.AmountApprovaledTime;
                order.AmountApprovalDecription = purchaseOrder.AmountApprovalDecription;
                //PurchaseReceivingOrder receivingOrder = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseReceivingOrders.FirstOrDefault(p => p.PurchaseOrderId == purchaseOrder.Id);
                //if (purchaseOrder.OrderStatusValue == 17)
                //{
                //    var receivingOrderDetails = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseReceivingOrderDetails.Where(p => p.PurchaseReceivingOrderId == receivingOrder.Id).ToList();
                //    var purchaseOrderDetails = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrderDetails.Where(p => p.PurchaseOrderId == purchaseOrder.Id).ToList();
                //    foreach (var o in purchaseOrderDetails)
                //    {
                //        o.Amount = receivingOrderDetails.FirstOrDefault(p => p.DrugInfoId == o.DrugInfoId).ActualAmount;
                //    }
                //}
                string msg = string.Empty;
                BusinessHandlerFactory.PurchaseOrderBusinessHandler.Save(order, out msg);
            }
            catch (Exception ex)
            {
                this.HandleException<bool>("处理收货记录失败", ex);
            }
        }

        //采购收货单据查询
        public List<PurchaseCommonEntity> GetPurchaseReceivingOrdersByPurchaseOrderId(Guid purchaseOrderId)
        {
            try
            {
                var queryBuilder = QueryBuilder.Create<PurchaseReceivingOrder>()
                 .Equals(q => q.PurchaseOrderId, purchaseOrderId).Equals(r => r.Deleted, false);
                var orders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseReceivingOrders.Where(queryBuilder.Expression);

                var query = from o in orders
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on o.OperateUserId equals u.Id
                            join p in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders on o.PurchaseOrderId equals p.Id
                            join em in BusinessHandlerFactory.RepositoryProvider.Db.Employees on u.EmployeeId equals em.Id
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on p.SupplyUnitId equals d.Id
                            select new PurchaseCommonEntity
                            {
                                Id = o.Id,
                                DocumentNumber = o.DocumentNumber,
                                EmployeeNumber = em.Number,
                                EmployeeName = em.Name,
                                OperateTime = o.OperateTime,
                                OperateUserId = o.OperateUserId,
                                OrderStatus = o.OrderStatusValue,
                                PurchaseOrderDocumentNumber = p.DocumentNumber,
                                PurchaseOrderId = p.Id,
                                SupplyUnitId = p.SupplyUnitId,
                                SupplyUnitName = d.Name,
                                ShippingTime = o.ShippingTime,
                                ShippingAdress = o.ShippingAdress,
                                ShippingUnit = o.ShippingUnit,
                                TransportUnit = o.TransportUnit,
                                RelatedOrderDocumentNumber = o.RelatedOrderDocumentNumber,
                                RelatedOrderId = o.RelatedOrderId,
                                RelatedOrderTypeValue = o.RelatedOrderTypeValue,
                                RecordCount = orders.Count(),

                            };
                return query.OrderBy(p => p.OperateTime).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseCommonEntity>>("采购收货单据查询失败", ex);
            }
        }
        //创建收货单通过自定义Model
        public string CreatePurchaseReceivingOrderByEnity(PurchaseCommonEntity order, List<PurchaseReceivingOrderDetailEntity> orderDetails)
        {
            string msg = string.Empty;
            try
            {
                var porStatus = RepositoryProvider.Db.PurchaseOrders.Where(r => r.Id == order.PurchaseOrderId).FirstOrDefault().OrderStatusValue;
                if (porStatus == (int)OrderStatus.PurchaseApprovedReceinvingAmountDiff)
                {
                    var ro = RepositoryProvider.Db.PurchaseReceivingOrders.Where(r => r.PurchaseOrderId == order.PurchaseOrderId).FirstOrDefault();
                    BusinessHandlerFactory.PurchaseReceivingOrderBusinessHandler.Delete(ro.Id, out msg);
                    var rd = RepositoryProvider.Db.PurchaseReceivingOrderDetails.Where(r => r.PurchaseReceivingOrderId == ro.Id).ToList();
                    rd.ForEach(r => { BusinessHandlerFactory.PurchaseReceivingOrderDetailBusinessHandler.Delete(r.Id, out msg); });

                }
                #region 修改多次收货
                var c = RepositoryProvider.Db.PurchaseReceivingOrders.Where(r => r.PurchaseOrderId == order.PurchaseOrderId && r.Deleted == false).FirstOrDefault();
                if (c != null)
                {
                    var n = from i in orderDetails
                            join j in RepositoryProvider.Db.PurchaseReceivingOrderDetails
                            on i.Id equals j.Id
                            where i.MReceiveNumber > 0
                            select new PurchaseReceivingOrderDetail
                            {
                                Id = Guid.NewGuid(),
                                ActualAmount = i.MReceiveNumber,
                                PurchaseReceivingOrderId = j.PurchaseReceivingOrderId,
                                Amount = j.Amount,
                                CheckResult = j.CheckResult,
                                Decription = j.Decription,
                                DrugInfoId = j.DrugInfoId,
                                IsCompanyPurchase = j.IsCompanyPurchase,
                                IsTransportMethod = j.IsTransportMethod,
                                IsTransportTemperature = j.IsTransportTemperature,
                                PurchasePrice = j.PurchasePrice,
                                ReceiveAmount = i.MReceiveNumber,
                                RejectAmount = i.RejectAmount,
                                RejectReason = i.RejectReason,
                                RejectTrace = i.RejectTrace,
                                sequence = i.sequence,
                                StoreId = j.StoreId,
                                TemperatureStatus = j.TemperatureStatus,
                                TransportMethod = j.TransportMethod,
                                TransportTemperature = j.TransportTemperature
                            };
                    foreach (var i in n)
                    {
                        BusinessHandlerFactory.PurchaseReceivingOrderDetailBusinessHandler.Add(i);
                    }
                    c.OrderStatusValue = (int)OrderStatus.PurchaseReceiving;
                    c.OperateTime = DateTime.Now;
                    BusinessHandlerFactory.PurchaseReceivingOrderBusinessHandler.Save(c);
                    var po = this.Queryable.Where(r => r.Id == order.PurchaseOrderId).FirstOrDefault();
                    if (po != null)
                    {
                        po.OrderStatusValue = order.OrderStatus;
                        po.UpdateTime = DateTime.Now;
                        po.UpdateUserId = order.OperateUserId;
                    }
                    this.Save();
                    return order.DocumentNumber;
                }
                #endregion

                PurchaseReceivingOrder purchaseOrder = new PurchaseReceivingOrder();
                List<PurchaseReceivingOrderDetail> purchaseOrderDetails = new List<PurchaseReceivingOrderDetail>();
                purchaseOrder.OperateUserId = order.OperateUserId;
                purchaseOrder.OrderStatusValue = order.OrderStatus;
                purchaseOrder.PurchaseOrderId = order.PurchaseOrderId;
                purchaseOrder.Decription = order.Description;
                purchaseOrder.ShippingTime = order.ShippingTime;
                purchaseOrder.ShippingAdress = order.ShippingAdress;
                purchaseOrder.ShippingUnit = order.ShippingUnit;
                purchaseOrder.TransportUnit = order.TransportUnit;
                purchaseOrder.RelatedOrderDocumentNumber = order.RelatedOrderDocumentNumber;
                purchaseOrder.RelatedOrderId = order.RelatedOrderId;
                purchaseOrder.RelatedOrderTypeValue = order.RelatedOrderTypeValue;

                foreach (var d in orderDetails)
                {
                    //if (d.ActualAmount <= 0) continue;//如果到货数量为0,则继续下一行
                    PurchaseReceivingOrderDetail purchaseOrderDetail = new PurchaseReceivingOrderDetail();
                    purchaseOrderDetail.ActualAmount = d.ActualAmount;
                    purchaseOrderDetail.Amount = d.Amount;
                    purchaseOrderDetail.CheckResult = d.CheckResult;
                    purchaseOrderDetail.Decription = d.Decription;
                    purchaseOrderDetail.DrugInfoId = d.DrugInfoId;
                    purchaseOrderDetail.IsCompanyPurchase = d.IsCompanyPurchase;
                    purchaseOrderDetail.IsTransportMethod = d.IsTransportMethod;
                    purchaseOrderDetail.IsTransportTemperature = d.IsTransportTemperature;
                    purchaseOrderDetail.TransportMethod = d.TransportMethod;
                    purchaseOrderDetail.TransportTemperature = d.TransportTemperature;
                    purchaseOrderDetail.PurchasePrice = d.PurchasePrice;
                    purchaseOrderDetail.ReceiveAmount = d.ReceiveAmount;
                    purchaseOrderDetail.RejectAmount = d.RejectAmount;
                    purchaseOrderDetail.RejectReason = d.RejectReason;
                    purchaseOrderDetail.RejectTrace = d.RejectTrace;
                    purchaseOrderDetail.TemperatureStatus = d.TemperatureStatus;
                    purchaseOrderDetail.sequence = d.sequence;
                    purchaseOrderDetails.Add(purchaseOrderDetail);
                }
                return CreatePurchaseReceivingOrder(purchaseOrder, purchaseOrderDetails);
            }
            catch (Exception ex)
            {
                return this.HandleException<string>("创建收货单失败", ex);
            }
        }

        //创建收货单
        public String CreatePurchaseReceivingOrder(PurchaseReceivingOrder order, List<PurchaseReceivingOrderDetail> orderDetails)
        {
            try
            {
                order.Id = Guid.NewGuid();
                order.DocumentNumber = new BillDocumentCodeBusinessHandler(BusinessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.PurchaseReceivingOrder).Code; ;
                order.OperateTime = DateTime.Now;
                order.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;

                BusinessHandlerFactory.RepositoryProvider.Db.PurchaseReceivingOrders.Add(order);
                DbSet<PurchaseReceivingOrderDetail> dbSet = BusinessHandlerFactory.RepositoryProvider.Db.Set<PurchaseReceivingOrderDetail>();
                Guid supplyUnitAccountExecutiveId = Guid.Empty;

                //拒收
                foreach (var d in orderDetails)
                {
                    d.Id = Guid.NewGuid();
                    d.PurchaseReceivingOrderId = order.Id;
                    d.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
                    dbSet.Add(d);
                    if (d.RejectAmount > 0 && order.OrderStatus != OrderStatus.PurchaseReceinvingAmountDiff)
                    {
                        DocumentRefuse dr = new DocumentRefuse();
                        dr.DocumentNumber = new BillDocumentCodeBusinessHandler(BusinessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.refuseDocument).Code;
                        dr.BatchNumber = "";
                        dr.createTime = DateTime.Now;
                        dr.updateTime = DateTime.Now;
                        dr.conclusionSignDate = DateTime.Now;
                        Models.User usr = RepositoryProvider.UserRepository.Get(order.OperateUserId);
                        dr.Creator = RepositoryProvider.EmployeeRepository.Get(usr.EmployeeId).Name;
                        dr.DrugInfoID = d.DrugInfoId;
                        DrugInfo di = RepositoryProvider.DrugInfoRepository.Get(d.DrugInfoId);
                        dr.drugName = di.ProductName;
                        dr.Id = Guid.NewGuid();
                        dr.OrderDocumentID = order.DocumentNumber;
                        dr.proc = 0;
                        dr.PurchasePrice = d.PurchasePrice;
                        dr.PurchaseUnitName = BusinessHandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseOrderEntity(order.PurchaseOrderId).SupplyUnitName;
                        dr.quantity = d.Amount;
                        dr.ReceiveQuantity = d.ReceiveAmount;
                        dr.RefuseQuantity = d.RejectAmount;
                        dr.rsn = d.RejectReason;
                        dr.Source = "收货";
                        dr.PurchaseOrderId = order.PurchaseOrderId;
                        dr.DosageType = di.DictionaryDosageCode;
                        dr.Specific = di.DictionarySpecificationCode;
                        RepositoryProvider.DocumentRefuseRepository.Add(dr);
                    }
                }
                ////采购单修改
                var purchaseOrders = this.Queryable.FirstOrDefault(p => p.Id == order.PurchaseOrderId);
                purchaseOrders.OrderStatusValue = order.OrderStatusValue;
                purchaseOrders.UpdateTime = DateTime.Now;
                purchaseOrders.UpdateUserId = order.OperateUserId;
                order.OrderStatusValue = (int)OrderStatus.PurchaseReceiving;
                BusinessHandlerFactory.RepositoryProvider.Db.Commit();
                return order.DocumentNumber;
            }
            catch (Exception ex)
            {
                return this.HandleException<string>("创建收货单失败", ex);
            }
        }

        //收货查询单
        public List<PurchaseCommonEntity> GetPurchaseReceivingOrders(string documentNumber, DateTime startTime, DateTime endTime, int[] orderStatusValue, Guid[] purchaseUnits, int index, int size)
        {
            try
            {
                if (startTime == null)
                {
                    startTime = DateTime.MinValue;
                }
                if (endTime == null)
                {
                    endTime = DateTime.MaxValue;
                }
                var queryBuilder = QueryBuilder.Create<PurchaseReceivingOrder>()
                 .Between(c => c.OperateTime, startTime.AddDays(-1), endTime.AddDays(1))
                 .Equals(q => q.Deleted, false);
                if (orderStatusValue.Length > 0 && orderStatusValue[0] != -1)
                {
                    queryBuilder = queryBuilder.In(q => q.OrderStatusValue, orderStatusValue);
                }
                var orders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseReceivingOrders.Where(queryBuilder.Expression).Where(r => r.Deleted == false);

                var query = from o in orders
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on o.OperateUserId equals u.Id
                            join p in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders on o.PurchaseOrderId equals p.Id
                            join em in BusinessHandlerFactory.RepositoryProvider.Db.Employees on u.EmployeeId equals em.Id
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on p.SupplyUnitId equals d.Id
                            select new PurchaseCommonEntity
                            {
                                Id = o.Id,
                                DocumentNumber = o.DocumentNumber,
                                EmployeeNumber = em.Number,
                                EmployeeName = em.Name,
                                OperateTime = o.OperateTime,
                                OperateUserId = o.OperateUserId,
                                OrderStatus = o.OrderStatusValue,
                                PurchaseOrderDocumentNumber = p.DocumentNumber,
                                PurchaseOrderId = p.Id,
                                SupplyUnitId = p.SupplyUnitId,
                                SupplyUnitName = d.Name,
                                ShippingTime = o.ShippingTime,
                                ShippingAdress = o.ShippingAdress,
                                ShippingUnit = o.ShippingUnit,
                                TransportUnit = o.TransportUnit,
                                RelatedOrderDocumentNumber = o.RelatedOrderDocumentNumber,
                                RelatedOrderId = o.RelatedOrderId,
                                RelatedOrderTypeValue = o.RelatedOrderTypeValue,
                                RecordCount = orders.Count()
                            };

                if (purchaseUnits.Length > 0)
                {
                    query = query.Where(p => purchaseUnits.Contains(p.PurchaseOrderId));
                }
                if (!string.IsNullOrEmpty(documentNumber))
                {
                    query = query.Where(r => r.DocumentNumber.Contains(documentNumber) || r.PurchaseOrderDocumentNumber.Contains(documentNumber));
                }

                return query.OrderByDescending(p => p.OperateTime).Skip((index - 1) * size).Take(size).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseCommonEntity>>("收货查询单失败", ex);
            }
        }

        //收货详细
        public List<PurchaseReceivingOrderDetailEntity> GetPurchaseReceivingOrderDetails(Guid orderId)
        {
            try
            {
                var queryBuilder = QueryBuilder.Create<PurchaseReceivingOrderDetail>()
                .Equals(c => c.PurchaseReceivingOrderId, orderId);

                var orderDetails = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseReceivingOrderDetails.Where(queryBuilder.Expression);
                var query = from i in orderDetails
                            join r in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseReceivingOrders on i.PurchaseReceivingOrderId equals r.Id
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos on i.DrugInfoId equals d.Id
                            select new PurchaseReceivingOrderDetailEntity
                            {
                                Id = i.Id,
                                ActualAmount = i.ActualAmount,
                                Decription = i.Decription,
                                IsCompanyPurchase = i.IsCompanyPurchase,
                                IsTransportMethod = i.IsTransportMethod,
                                IsTransportTemperature = i.IsTransportTemperature,
                                PurchaseReceivingOrderId = r.Id,
                                TransportMethod = i.TransportMethod,
                                TransportTemperature = i.TransportTemperature,
                                Amount = i.Amount,
                                DictionaryMeasurementUnitCode = d.DictionaryMeasurementUnitCode,
                                DictionarySpecificationCode = d.DictionarySpecificationCode,
                                FactoryName = d.FactoryName,
                                DictionaryDosageCode = d.DictionaryDosageCode,
                                ProductGeneralName = d.ProductGeneralName,
                                DrugInfoId = i.DrugInfoId,
                                LicensePermissionNumber = d.LicensePermissionNumber,
                                PurchasePrice = i.PurchasePrice,
                                CheckResult = i.CheckResult,
                                CheckResultString = i.Decription,
                                ReceiveAmount = i.ReceiveAmount,
                                RejectAmount = i.RejectAmount,
                                RejectReason = i.RejectReason,
                                RejectTrace = i.RejectTrace,
                                TemperatureStatus = i.TemperatureStatus,
                                sequence = i.sequence,
                                BusinessScopeCode = d.BusinessScopeCode,
                                IsSpecial = d.IsSpecialDrugCategory,
                                ValidMonth = d.ValidPeriod,
                                Origin = d.Origin
                            };

                return query.OrderBy(p => p.sequence).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseReceivingOrderDetailEntity>>("根据订单编号获取收货明细失败", ex);
            }
        }
        #endregion

        #region 验收
        //验收记录据查询
        public List<PurchaseCommonEntity> GetPurchaseCheckingOrdersByPurchaseOrderId(Guid purchaseOrderId)
        {
            try
            {
                var queryBuilder = QueryBuilder.Create<PurchaseCheckingOrder>()
                 .Equals(q => q.PurchaseOrderId, purchaseOrderId)
                 .Equals(q => q.Deleted, false);
                var orders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrders.Where(queryBuilder.Expression);

                var query = from o in orders
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on o.OperateUserId equals u.Id
                            join p in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders on o.PurchaseOrderId equals p.Id
                            join em in BusinessHandlerFactory.RepositoryProvider.Db.Employees on u.EmployeeId equals em.Id
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on p.SupplyUnitId equals d.Id
                            select new PurchaseCommonEntity
                            {
                                Id = o.Id,
                                DocumentNumber = o.DocumentNumber,
                                EmployeeNumber = em.Number,
                                EmployeeName = em.Name,
                                OperateTime = o.OperateTime,
                                OperateUserId = o.OperateUserId,
                                OrderStatus = o.OrderStatusValue,
                                PurchaseOrderDocumentNumber = p.DocumentNumber,
                                PurchaseOrderId = p.Id,
                                SupplyUnitId = p.SupplyUnitId,
                                SupplyUnitName = d.Name,
                                RelatedOrderDocumentNumber = o.RelatedOrderDocumentNumber,
                                RelatedOrderId = o.RelatedOrderId,
                                RelatedOrderTypeValue = o.RelatedOrderTypeValue,
                                RecordCount = orders.Count(),
                                SecondCheckerName = o.SecondCheckerName,
                                SecondCheckMemo = o.SecondCheckMemo
                            };
                return query.OrderByDescending(p => p.OperateTime).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseCommonEntity>>("根据订单编号获取验货详细失败", ex);
            }
        }
        //创建验货单通过自定义Model
        public String CreatePurchaseCheckingOrderByEnity(PurchaseCommonEntity order, List<PurchaseCheckingOrderDetailEntity> orderDetails, List<DrugsUndeterminate> ListUndeterminate)
        {
            try
            {
                PurchaseCheckingOrder po = RepositoryProvider.Db.PurchaseCheckingOrders.Where(r => r.PurchaseOrderId == order.PurchaseOrderId).FirstOrDefault();
                if (po != null)//验货单已存在
                {
                    po.OrderStatusValue = (int)OrderStatus.PurchaseCheck;
                    Guid storeid = PharmacyServiceConfig.Config.CurrentStore.Id;
                    var c = (from i in orderDetails
                             select new PurchaseCheckingOrderDetail
                             {
                                 ArrivalAmount = i.ArrivalAmount,
                                 ArrivalDateTime = i.ArrivalDateTime,
                                 BatchNumber = i.BatchNumber,
                                 CheckResult = i.CheckResult,
                                 Decription = i.Decription,
                                 DrugInfoId = i.DrugInfoId,
                                 Id = Guid.NewGuid(),
                                 OutValidDate = i.OutValidDate,
                                 PruductDate = i.PruductDate,
                                 PurchaseCheckingOrderId = po.Id,
                                 PurchasePrice = i.PurchasePrice,
                                 QualifiedAmount = i.QualifiedAmount,
                                 ReceivedAmount = i.ReceiveAmount,
                                 sequence = i.sequence,
                                 StoreId = storeid,
                                 UnQualifiedAmount = i.UnQualifiedAmount

                             }).ToList();
                    c.ForEach(r => { BusinessHandlerFactory.PurchaseCheckingOrderDetailBusinessHandler.Add(r); });
                    var pro = RepositoryProvider.Db.PurchaseReceivingOrders.Where(r => r.PurchaseOrderId == order.PurchaseOrderId).FirstOrDefault();
                    pro.OrderStatusValue = (int)OrderStatus.PurchaseCheck;
                    this.Save();
                    return po.DocumentNumber;
                }

                PurchaseCheckingOrder purchaseOrder = new PurchaseCheckingOrder();
                List<PurchaseCheckingOrderDetail> purchaseOrderDetails = new List<PurchaseCheckingOrderDetail>();
                purchaseOrder.OperateUserId = order.OperateUserId;
                purchaseOrder.OrderStatusValue = order.OrderStatus;
                purchaseOrder.PurchaseOrderId = order.PurchaseOrderId;
                purchaseOrder.Decription = order.Description;
                purchaseOrder.RelatedOrderDocumentNumber = order.RelatedOrderDocumentNumber;
                purchaseOrder.RelatedOrderId = order.RelatedOrderId;
                purchaseOrder.RelatedOrderTypeValue = order.RelatedOrderTypeValue;
                purchaseOrder.OperateTime = DateTime.Now;
                purchaseOrder.SecondCheckerId = order.SecondCheckerId == null ? Guid.Empty : order.SecondCheckerId;
                purchaseOrder.SecondCheckerName = order.SecondCheckerName;
                purchaseOrder.SecondCheckMemo = order.SecondCheckMemo;
                foreach (var d in orderDetails)
                {
                    PurchaseCheckingOrderDetail purchaseOrderDetail = new PurchaseCheckingOrderDetail();
                    purchaseOrderDetail.ArrivalAmount = d.ArrivalAmount;
                    purchaseOrderDetail.ArrivalDateTime = order.OperateTime;
                    purchaseOrderDetail.BatchNumber = d.BatchNumber;
                    purchaseOrderDetail.CheckResult = d.CheckResult;
                    purchaseOrderDetail.Decription = d.Decription;
                    purchaseOrderDetail.DrugInfoId = d.DrugInfoId;
                    purchaseOrderDetail.OutValidDate = d.OutValidDate;
                    purchaseOrderDetail.PruductDate = d.PruductDate;
                    purchaseOrderDetail.QualifiedAmount = d.QualifiedAmount;
                    purchaseOrderDetail.PurchasePrice = d.PurchasePrice;
                    purchaseOrderDetail.ReceivedAmount = d.ReceiveAmount;
                    purchaseOrderDetail.UnQualifiedAmount = d.UnQualifiedAmount;
                    purchaseOrderDetail.sequence = d.sequence;
                    purchaseOrderDetails.Add(purchaseOrderDetail);
                }
                return CreatePurchaseCheckingOrder(purchaseOrder, purchaseOrderDetails, ListUndeterminate);
            }
            catch (Exception ex)
            {
                return this.HandleException<string>("创建验货单失败", ex);
            }
        }
        //创建验货单
        public string CreatePurchaseCheckingOrder(PurchaseCheckingOrder order, List<PurchaseCheckingOrderDetail> orderDetails, List<DrugsUndeterminate> ListUndeterminate)
        {
            try
            {
                order.Id = Guid.NewGuid();
                order.DocumentNumber = new BillDocumentCodeBusinessHandler(BusinessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.PurchaseCheckingOrder).Code; ;
                order.OperateTime = DateTime.Now;
                order.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
                BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrders.Add(order);

                foreach (DrugsUndeterminate d in ListUndeterminate)
                {
                    d.DocumentNumber = new BillDocumentCodeBusinessHandler(BusinessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.DrugUndeterminate).Code;
                    BusinessHandlerFactory.RepositoryProvider.Db.DrugsUndeterminates.Add(d);
                }

                DbSet<PurchaseCheckingOrderDetail> dbSet = BusinessHandlerFactory.RepositoryProvider.Db.Set<PurchaseCheckingOrderDetail>();
                Guid supplyUnitAccountExecutiveId = Guid.Empty;
                foreach (var d in orderDetails)
                {
                    d.Id = Guid.NewGuid();
                    d.PurchaseCheckingOrderId = order.Id;
                    d.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
                    dbSet.Add(d);
                }
                var purchaseOrders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders.FirstOrDefault(p => p.Id == order.PurchaseOrderId);
                //采购验收
                purchaseOrders.UpdateTime = DateTime.Now;
                purchaseOrders.UpdateUserId = order.OperateUserId;
                purchaseOrders.OrderStatusValue = purchaseOrders.OrderStatusValue == (int)OrderStatus.purchaseMReceiving ? (int)OrderStatus.purchaseMReceiving : order.OrderStatusValue;

                //关联收货单
                var releatedOrders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseReceivingOrders.FirstOrDefault(p => p.Id == order.RelatedOrderId);
                if (releatedOrders != null)
                {
                    releatedOrders.OrderStatusValue = order.OrderStatusValue;
                }

                BusinessHandlerFactory.RepositoryProvider.Db.Commit();
                return order.DocumentNumber;
            }
            catch (Exception ex)
            {
                return this.HandleException<string>("创建验货单失败", ex);
            }
        }
        //验收查询单
        public List<PurchaseCommonEntity> GetPurchaseCheckingOrders(string documentNumber, DateTime startTime, DateTime endTime, int[] orderStatusValue, Guid[] purchaseUnits, int index, int size)
        {
            try
            {
                if (startTime == null)
                {
                    startTime = DateTime.MinValue;
                }
                if (endTime == null)
                {
                    endTime = DateTime.MaxValue;
                }
                var queryBuilder = QueryBuilder.Create<PurchaseCheckingOrder>()
                 .Between(c => c.OperateTime, startTime.AddDays(-1), endTime.AddDays(1))
                 .Equals(q => q.Deleted, false);
                if (orderStatusValue.Length > 0 && orderStatusValue[0] != -1)
                {
                    queryBuilder = queryBuilder.In(q => q.OrderStatusValue, orderStatusValue);
                }
                var orders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrders.Where(queryBuilder.Expression);

                var query = from o in orders
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on o.OperateUserId equals u.Id
                            join p in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders on o.PurchaseOrderId equals p.Id
                            join em in BusinessHandlerFactory.RepositoryProvider.Db.Employees on u.EmployeeId equals em.Id
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on p.SupplyUnitId equals d.Id
                            select new PurchaseCommonEntity
                            {
                                Id = o.Id,
                                DocumentNumber = o.DocumentNumber,
                                EmployeeNumber = em.Number,
                                EmployeeName = em.Name,
                                OperateTime = o.OperateTime,
                                OperateUserId = o.OperateUserId,
                                OrderStatus = o.OrderStatusValue,
                                PurchaseOrderDocumentNumber = p.DocumentNumber,
                                PurchaseOrderId = p.Id,
                                SupplyUnitId = p.SupplyUnitId,
                                SupplyUnitName = d.Name,
                                RelatedOrderDocumentNumber = o.RelatedOrderDocumentNumber,
                                RelatedOrderId = o.RelatedOrderId,
                                RelatedOrderTypeValue = o.RelatedOrderTypeValue,
                                RecordCount = orders.Count(),
                                SecondCheckerName = o.SecondCheckerName,
                                SecondCheckMemo = o.SecondCheckMemo
                            };
                if (!string.IsNullOrEmpty(documentNumber))
                {
                    query = query.Where(r => r.PurchaseOrderDocumentNumber.Contains(documentNumber) || r.DocumentNumber.Contains(documentNumber));
                }

                if (purchaseUnits.Length > 0)
                {
                    query = query.Where(p => purchaseUnits.Contains(p.PurchaseOrderId));
                }
                return query.OrderByDescending(p => p.OperateTime).Skip((index - 1) * size).Take(size).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseCommonEntity>>("查询验收单失败", ex);
            }
        }

        //验货详细
        public List<PurchaseCheckingOrderDetailEntity> GetPurchaseCheckingOrderDetails(Guid orderId)
        {
            try
            {

                var queryBuilder = QueryBuilder.Create<PurchaseCheckingOrderDetail>()
                .Equals(c => c.PurchaseCheckingOrderId, orderId);

                var orderDetails = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrderDetails.Where(queryBuilder.Expression);
                var query = from i in orderDetails
                            join r in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrders on i.PurchaseCheckingOrderId equals r.Id
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos on i.DrugInfoId equals d.Id
                            select new PurchaseCheckingOrderDetailEntity
                            {
                                Id = i.Id,
                                Decription = i.Decription,
                                ArrivalAmount = i.ArrivalAmount,
                                ArrivalDateTime = i.ArrivalDateTime,
                                BatchNumber = i.BatchNumber,
                                CheckResult = i.CheckResult,
                                OutValidDate = i.OutValidDate,
                                PruductDate = i.PruductDate,
                                QualifiedAmount = i.QualifiedAmount,
                                DictionaryMeasurementUnitCode = d.DictionaryMeasurementUnitCode,
                                DictionarySpecificationCode = d.DictionarySpecificationCode,
                                FactoryName = d.FactoryName,
                                DictionaryDosageCode = d.DictionaryDosageCode,
                                ProductGeneralName = d.ProductGeneralName,
                                DrugInfoId = i.DrugInfoId,
                                PurchasePrice = i.PurchasePrice,
                                LicensePermissionNumber = d.LicensePermissionNumber,
                                UnQualifiedAmount = i.UnQualifiedAmount,
                                ReceiveAmount = i.ReceivedAmount,
                                sequence = i.sequence,
                                BusinessScopeCode = d.BusinessScopeCode,
                                IsSpecialCategory = d.IsSpecialDrugCategory,
                                StorageType = d.DrugStorageTypeCode,
                                Origin = d.Origin,
                            };

                return query.OrderBy(p => p.sequence).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseCheckingOrderDetailEntity>>("根据订单号获取验货详细失败", ex);
            }
        }
        #endregion

        #region 入库操作
        //库存记录据查询
        public List<PurchaseCommonEntity> GetPurchaseInInventeryOrdersByPurchaseOrderId(Guid purchaseOrderId)
        {
            try
            {
                var queryBuilder = QueryBuilder.Create<PurchaseInInventeryOrder>()
                 .Equals(q => q.PurchaseOrderId, purchaseOrderId)
                 .Equals(q => q.Deleted, false);
                var orders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseInInventeryOrders.Where(queryBuilder.Expression);

                var query = from o in orders
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on o.OperateUserId equals u.Id
                            join p in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders on o.PurchaseOrderId equals p.Id
                            join em in BusinessHandlerFactory.RepositoryProvider.Db.Employees on u.EmployeeId equals em.Id
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on p.SupplyUnitId equals d.Id
                            select new PurchaseCommonEntity
                            {
                                Id = o.Id,
                                DocumentNumber = o.DocumentNumber,
                                EmployeeNumber = em.Number,
                                EmployeeName = em.Name,
                                OperateTime = o.OperateTime,
                                OperateUserId = o.OperateUserId,
                                OrderStatus = o.OrderStatusValue,
                                PurchaseOrderDocumentNumber = p.DocumentNumber,
                                PurchaseOrderId = p.Id,
                                SupplyUnitId = p.SupplyUnitId,
                                SupplyUnitName = d.Name,
                                RelatedOrderDocumentNumber = o.RelatedOrderDocumentNumber,
                                RelatedOrderId = o.RelatedOrderId,
                                RelatedOrderTypeValue = o.RelatedOrderTypeValue,
                                RecordCount = orders.Count()
                            };
                return query.OrderByDescending(p => p.OperateTime).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseCommonEntity>>("根据订单号查询库存记录失败", ex);
            }
        }
        //创建入库单通过自定义Model
        public string CreatePurchaseInInventeryOrderByEnity(PurchaseCommonEntity order, List<PurchaseInInventeryOrderDetailEntity> orderDetails)
        {
            try
            {
                PurchaseInInventeryOrder pio = RepositoryProvider.Db.PurchaseInInventeryOrders.FirstOrDefault(r => r.PurchaseOrderId == order.PurchaseOrderId);

                #region 多批次入库
                if (pio != null)
                {
                    if (DateTime.Now < pio.OperateTime.AddMinutes(10))
                    {
                        return "系统异常信息：系统判断您在10分钟内多次提交入库操作，请刷新后再执行";
                    }

                    Guid pioId = pio.Id;
                    Guid storeid = PharmacyServiceConfig.Config.CurrentStore.Id;
                    var c = (from i in orderDetails
                             select new PurchaseInInventeryOrderDetail
                             {
                                 ArrivalAmount = i.ArrivalAmount,
                                 ArrivalDateTime = i.ArrivalDateTime,
                                 BatchNumber = i.BatchNumber,
                                 Decription = i.Decription,
                                 DrugInfoId = i.DrugInfoId,
                                 Id = Guid.NewGuid(),
                                 OutValidDate = i.OutValidDate,
                                 PruductDate = i.PruductDate,
                                 PurchaseInInventeryOrderId = pioId,
                                 PurchasePrice = i.PurchasePrice,
                                 sequence = i.sequence,
                                 StoreId = storeid,
                                 WarehouseZoneId = i.WarehouseZoneId,
                                 WarehouseZonePositionId = i.WarehouseZonePositionId
                             }).ToList();
                    foreach (var i in c)
                    {
                        if (i.WarehouseZoneId == Guid.Empty || i.WarehouseZoneId == null)
                        {
                            var u = RepositoryProvider.Db.DrugInfos.Where(r => r.Id == i.DrugInfoId).FirstOrDefault();
                            if (u != null)
                            {
                                i.WarehouseZoneId = Guid.Parse(u.WareHouseZones);
                            }
                        }
                    }

                    c.ToList().ForEach(r => { BusinessHandlerFactory.PurchaseInInventeryOrderDetailBusinessHandler.Add(r); });

                    foreach (var d in c)
                    {
                        d.Id = Guid.NewGuid();

                        DrugInfo drugInfo = BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos.FirstOrDefault(p => p.Id == d.DrugInfoId);

                        var rc = RepositoryProvider.Db.DrugInventoryRecords.Where(r => r.DrugInfoId == d.DrugInfoId && r.BatchNumber.Contains(d.BatchNumber.Trim()) && r.Decription.Equals(d.Decription));
                        int count = rc.Count();

                        DrugInventoryRecord drugInventoryRecord = rc.FirstOrDefault();

                        if (drugInventoryRecord != null)
                        {
                            d.BatchNumber += "(" + (count + 1).ToString() + ")";
                        }

                        {
                            drugInventoryRecord = new DrugInventoryRecord();
                            drugInventoryRecord.Id = Guid.NewGuid();
                            drugInventoryRecord.DrugInfoId = drugInfo.Id;
                            drugInventoryRecord.PurchasePricce = d.PurchasePrice;
                            drugInventoryRecord.BatchNumber = d.BatchNumber;
                            drugInventoryRecord.PruductDate = d.PruductDate;
                            drugInventoryRecord.OutValidDate = d.OutValidDate;
                            drugInventoryRecord.InInventoryCount = d.ArrivalAmount;
                            drugInventoryRecord.DrugInfo = drugInfo;
                            drugInventoryRecord.CurrentInventoryCount = d.ArrivalAmount;
                            drugInventoryRecord.Decription = d.Decription;
                            drugInventoryRecord.DrugInfoId = drugInfo.Id;
                            drugInventoryRecord.WarehouseZoneId = d.WarehouseZoneId;
                            drugInventoryRecord.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
                            drugInventoryRecord.PurchaseInInventeryOrderDetailId = d.Id;
                            drugInventoryRecord.DurgInventoryTypeValue = 0;
                            drugInventoryRecord.Valid = true;
                            drugInventoryRecord.WareHouseZonePositionId = d.WarehouseZonePositionId;
                            BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Add(drugInventoryRecord);

                        }
                    }

                    var purchaseOrders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders.FirstOrDefault(p => p.Id == order.PurchaseOrderId);
                    //采购入库
                    if (purchaseOrders.OrderStatus != OrderStatus.purchaseMReceiving)
                        purchaseOrders.OrderStatusValue = 14;
                    purchaseOrders.UpdateTime = DateTime.Now;
                    purchaseOrders.UpdateUserId = order.OperateUserId;
                    var releatedOrders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrders.FirstOrDefault(p => p.Id == order.RelatedOrderId);
                    if (releatedOrders != null)
                    {
                        releatedOrders.OrderStatusValue = order.OrderStatus;
                    }
                    this.Save();
                    return pio.DocumentNumber;
                }//以上是多批次收货
                #endregion

                #region 单次入库
                PurchaseInInventeryOrder purchaseOrder = new PurchaseInInventeryOrder()
                {
                    OperateUserId = order.OperateUserId,
                    OrderStatusValue = order.OrderStatus,
                    PurchaseOrderId = order.PurchaseOrderId,
                    Decription = order.Description,
                    RelatedOrderDocumentNumber = order.RelatedOrderDocumentNumber,
                    RelatedOrderId = order.RelatedOrderId,
                    RelatedOrderTypeValue = order.RelatedOrderTypeValue,
                    Id = Guid.NewGuid(),
                    Deleted = false,
                    StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                    OperateTime = DateTime.Now,
                    DocumentNumber = new BillDocumentCodeBusinessHandler(BusinessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.PurchaseInInventeryOrder).Code
                };

                List<PurchaseInInventeryOrderDetail> purchaseOrderDetails = new List<PurchaseInInventeryOrderDetail>();

                foreach (var d in orderDetails)
                {
                    PurchaseInInventeryOrderDetail purchaseOrderDetail = new PurchaseInInventeryOrderDetail
                    {
                        sequence = d.sequence,
                        ArrivalAmount = d.ArrivalAmount,
                        ArrivalDateTime = d.ArrivalDateTime,
                        Decription = d.Decription,
                        DrugInfoId = d.DrugInfoId,
                        WarehouseZoneId = d.WarehouseZoneId,
                        BatchNumber = d.BatchNumber,
                        OutValidDate = d.OutValidDate,
                        PruductDate = d.PruductDate,
                        PurchasePrice = d.PurchasePrice,
                        WarehouseZonePositionId = d.WarehouseZonePositionId,
                        Id = Guid.NewGuid(),
                        PurchaseInInventeryOrderId = purchaseOrder.Id,
                        StoreId = purchaseOrder.StoreId,
                        Deleted = false
                    };

                    if (d.WarehouseZoneId == Guid.Empty || d.WarehouseZoneId == null)
                    {
                        Guid drugid = d.DrugInfoId;
                        DrugInfo di = BusinessHandlerFactory.DrugInfoBusinessHandler.Get(drugid);
                        if (di != null)
                            purchaseOrderDetail.WarehouseZoneId = Guid.Parse(di.WareHouseZones);
                        else
                            purchaseOrderDetail.WarehouseZoneId = Guid.Empty;
                    }

                    purchaseOrderDetails.Add(purchaseOrderDetail);
                }
                return CreatePurchaseInInventeryOrder(purchaseOrder, purchaseOrderDetails);
                #endregion
            }
            catch (Exception ex)
            {
                return this.HandleException<string>("创建入库单失败", ex);
            }
        }
        //创建入库单
        public string CreatePurchaseInInventeryOrder(PurchaseInInventeryOrder order, List<PurchaseInInventeryOrderDetail> orderDetails)
        {
            try
            {
                #region 入库单及其细节
                BusinessHandlerFactory.RepositoryProvider.Db.PurchaseInInventeryOrders.Add(order);
                DbSet<PurchaseInInventeryOrderDetail> dbSet = BusinessHandlerFactory.RepositoryProvider.Db.Set<PurchaseInInventeryOrderDetail>();
                #endregion


                DbSet<DrugInventoryRecord> dbSetDrugInventoryRecord = BusinessHandlerFactory.RepositoryProvider.Db.Set<DrugInventoryRecord>();

                Guid supplyUnitAccountExecutiveId = Guid.Empty;

                foreach (var d in orderDetails)
                {
                    dbSet.Add(d);

                    DrugInfo drugInfo = BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos.FirstOrDefault(p => p.Id == d.DrugInfoId);
                    PurchaseOrderDetail purchaseOrderDetail = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrderDetails.FirstOrDefault(p => p.PurchaseOrderId == order.PurchaseOrderId);



                    var rc = dbSetDrugInventoryRecord.Where(r => r.DrugInfoId == d.DrugInfoId && r.BatchNumber.Contains(d.BatchNumber.Trim()) && r.Decription.Equals(d.Decription));
                    int count = rc.Count();
                    DrugInventoryRecord drugInventoryRecord = rc.FirstOrDefault();

                    if (drugInventoryRecord != null)
                    {
                        d.BatchNumber += "(" + (count + 1).ToString() + ")";
                    }

                    drugInventoryRecord = new DrugInventoryRecord()
                    {
                        Id = Guid.NewGuid(),
                        DrugInfoId = drugInfo.Id,
                        PurchasePricce = d.PurchasePrice,
                        BatchNumber = d.BatchNumber,
                        PruductDate = d.PruductDate,
                        OutValidDate = d.OutValidDate,
                        InInventoryCount = d.ArrivalAmount,
                        DrugInfo = drugInfo,
                        CurrentInventoryCount = d.ArrivalAmount,
                        Decription = d.Decription,
                        WarehouseZoneId = d.WarehouseZoneId,
                        StoreId = PharmacyServiceConfig.Config.CurrentStore.Id,
                        PurchaseInInventeryOrderDetailId = d.Id,
                        DurgInventoryTypeValue = 0,
                        Valid = true,
                        WareHouseZonePositionId = d.WarehouseZonePositionId,
                    };
                    dbSetDrugInventoryRecord.Add(drugInventoryRecord);
                }

                #region purchaseorder 状态修改
                var purchaseOrders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders.FirstOrDefault(p => p.Id == order.PurchaseOrderId);
                //采购入库
                if (purchaseOrders.OrderStatus != OrderStatus.purchaseMReceiving)
                    purchaseOrders.OrderStatusValue = 14;
                purchaseOrders.UpdateTime = DateTime.Now;
                purchaseOrders.UpdateUserId = order.OperateUserId;
                var releatedOrders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrders.FirstOrDefault(p => p.Id == order.RelatedOrderId);
                if (releatedOrders != null)
                {
                    releatedOrders.OrderStatusValue = order.OrderStatusValue;
                }
                #endregion

                BusinessHandlerFactory.RepositoryProvider.Db.Commit();
                return order.DocumentNumber;
            }
            catch (Exception ex)
            {
                return this.HandleException<string>("创建入库单失败", ex);
            }
        }

        //入库详细
        public List<PurchaseInInventeryOrderDetailEntity> GetPurchaseInInventeryOrderDetails(Guid orderId)
        {
            try
            {
                var queryBuilder = QueryBuilder.Create<PurchaseInInventeryOrderDetail>()
                .Equals(c => c.PurchaseInInventeryOrderId, orderId);

                var orderDetails = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseInInventeryOrderDetails.Where(queryBuilder.Expression);
                var query = from i in orderDetails
                            join r in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseInInventeryOrders on i.PurchaseInInventeryOrderId equals r.Id
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos on i.DrugInfoId equals d.Id
                            join wz in BusinessHandlerFactory.RepositoryProvider.Db.WarehouseZones on i.WarehouseZoneId equals wz.Id
                            join w in BusinessHandlerFactory.RepositoryProvider.Db.Warehouses on wz.WarehouseId equals w.Id
                            join wzp in BusinessHandlerFactory.RepositoryProvider.Db.WarehouseZonePositions on i.WarehouseZonePositionId equals wzp.Id into left
                            from l in left.DefaultIfEmpty()
                            select new PurchaseInInventeryOrderDetailEntity
                            {
                                Id = i.Id,
                                Decription = i.Decription,
                                ArrivalAmount = i.ArrivalAmount,
                                ArrivalDateTime = i.ArrivalDateTime,
                                DictionaryStorageType = d.DrugStorageTypeCode,
                                WarehouseZoneId = i.WarehouseZoneId,
                                WarehouseZoneName = wz.Name,
                                WarehouseZonePIndex = wz.PIndex,
                                WarehouseZonePositionName = l == null ? "无" : l.Name,
                                WarehouseZonePositionId = l == null ? Guid.Empty : l.Id,
                                WarehouseZonePositionPIndex = l == null ? 0 : l.PIndex,
                                WarehouseName = w.Name,
                                DictionaryMeasurementUnitCode = d.DictionaryMeasurementUnitCode,
                                DictionarySpecificationCode = d.DictionarySpecificationCode,
                                FactoryName = d.FactoryName,
                                DictionaryDosageCode = d.DictionaryDosageCode,
                                ProductGeneralName = d.ProductGeneralName,
                                DrugInfoId = i.DrugInfoId,
                                BatchNumber = i.BatchNumber,
                                OutValidDate = i.OutValidDate,
                                PruductDate = i.PruductDate,
                                LicensePermissionNumber = d.LicensePermissionNumber,
                                PurchasePrice = i.PurchasePrice,
                                sequence = i.sequence,
                                BussinessScopeCode = d.BusinessScopeCode,

                            };
                return query.OrderBy(p => p.sequence).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseInInventeryOrderDetailEntity>>("根据订单号获取入库详细失败", ex);
            }
        }
        //入库查询单
        public List<PurchaseCommonEntity> GetPurchaseInInventeryOrders(string documentNumber, DateTime startTime, DateTime endTime, int[] orderStatusValue, Guid[] purchaseUnits, int index, int size)
        {
            try
            {
                if (startTime == null)
                {
                    startTime = DateTime.MinValue;
                }
                if (endTime == null)
                {
                    endTime = DateTime.MaxValue;
                }
                var queryBuilder = QueryBuilder.Create<PurchaseInInventeryOrder>()
                 .Between(c => c.OperateTime, startTime.AddDays(-1), endTime.AddDays(1))
                 .Equals(q => q.Deleted, false);
                if (orderStatusValue.Length > 0 && orderStatusValue[0] != -1)
                {
                    queryBuilder = queryBuilder.In(q => q.OrderStatusValue, orderStatusValue);
                }
                var orders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseInInventeryOrders.Where(queryBuilder.Expression);

                var query = from o in orders
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on o.OperateUserId equals u.Id
                            join p in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders on o.PurchaseOrderId equals p.Id
                            join em in BusinessHandlerFactory.RepositoryProvider.Db.Employees on u.EmployeeId equals em.Id
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on p.SupplyUnitId equals d.Id
                            select new PurchaseCommonEntity
                            {
                                Id = o.Id,
                                DocumentNumber = o.DocumentNumber,
                                EmployeeNumber = em.Number,
                                EmployeeName = em.Name,
                                OperateTime = o.OperateTime,
                                OperateUserId = o.OperateUserId,
                                OrderStatus = o.OrderStatusValue,
                                PurchaseOrderDocumentNumber = p.DocumentNumber,
                                PurchaseOrderId = p.Id,
                                SupplyUnitId = p.SupplyUnitId,
                                SupplyUnitName = d.Name,
                                RelatedOrderDocumentNumber = o.RelatedOrderDocumentNumber,
                                RelatedOrderId = o.RelatedOrderId,
                                RelatedOrderTypeValue = o.RelatedOrderTypeValue,
                                RecordCount = orders.Count()
                            };
                if (!string.IsNullOrEmpty(documentNumber))
                {
                    query = query.Where(r => r.DocumentNumber.Contains(documentNumber) || r.PurchaseOrderDocumentNumber.Contains(documentNumber));
                }
                if (purchaseUnits.Length > 0)
                {
                    query = query.Where(p => purchaseUnits.Contains(p.PurchaseOrderId));
                }
                return query.OrderByDescending(p => p.OperateTime).Skip((index - 1) * size).Take(size).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseCommonEntity>>("查询入库单失败", ex);
            }
        }

        #endregion

        #region 退货
        //采购退货单据查询
        public List<PurchaseCommonEntity> GetPurchaseOrderReturnsByPurchaseOrderId(Guid purchaseOrderId)
        {
            try
            {
                var queryBuilder = QueryBuilder.Create<PurchaseOrderReturn>()
                 .Equals(q => q.PurchaseOrderId, purchaseOrderId)
                 .Equals(q => q.Deleted, false);
                var orders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrderReturns.Where(queryBuilder.Expression);
                var c = from i in RepositoryProvider.Db.Users join j in RepositoryProvider.Db.Employees on i.EmployeeId equals j.Id select i;
                var query = from o in orders
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on o.CreateUserId equals u.Id
                            join p in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders on o.PurchaseOrderId equals p.Id
                            join em in BusinessHandlerFactory.RepositoryProvider.Db.Employees on u.EmployeeId equals em.Id
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on p.SupplyUnitId equals d.Id
                            join f in c on o.FinanceDepartmentUserId equals f.Id
                            join g in c on o.GeneralManagerUserId equals g.Id
                            join h in c on o.QualityUserId equals h.Id
                            select new PurchaseCommonEntity
                            {
                                Id = o.Id,
                                DocumentNumber = o.DocumentNumber,
                                EmployeeNumber = em.Number,
                                EmployeeName = em.Name,
                                OperateTime = o.CreateTime,
                                OperateUserId = o.CreateUserId,
                                OrderStatus = o.OrderStatusValue,
                                PurchaseOrderDocumentNumber = p.DocumentNumber,
                                PurchaseOrderId = p.Id,
                                SupplyUnitId = p.SupplyUnitId,
                                SupplyUnitName = d.Name,
                                Description = o.Decription,
                                CheckerSuggest = o.CheckerSuggest,
                                CheckerUserId = o.CheckerUserId,
                                CheckerUpdateTime = o.CheckerUpdateTime,
                                FinanceDepartmentSuggest = o.FinanceDepartmentSuggest,
                                FinanceDepartmentUpdateTime = o.FinanceDepartmentUpdateTime,
                                FinanceDepartmentUserId = o.FinanceDepartmentUserId,
                                FinanceDepartmentEmployeeName = f.Employee.Name,
                                FinanceDepartmentEmployeeNumber = f.Employee.Number,
                                GeneralManagerSuggest = o.GeneralManagerSuggest,
                                GeneralManagerUpdateTime = o.GeneralManagerUpdateTime,
                                GeneralManagerUserId = o.GeneralManagerUserId,
                                GeneralManagerEmployeeName = g.Employee.Name,
                                GeneralManagerEmployeeNumber = g.Employee.Number,
                                QualitySuggest = o.QualitySuggest,
                                QualityUpdateTime = o.QualityUpdateTime,
                                QualityUserId = o.QualityUserId,
                                QualityEmployeeName = h.Employee.Name,
                                QualityEmployeeNumber = h.Employee.Number,

                                RelatedOrderDocumentNumber = o.RelatedOrderDocumentNumber,
                                RelatedOrderId = o.RelatedOrderId,
                                RelatedOrderTypeValue = o.RelatedOrderTypeValue,
                                RecordCount = orders.Count()

                            };


                return query.ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseCommonEntity>>("查询采购退货单据失败", ex);
            }
        }
        //创建退货单通过自定义Model
        public String CreatePurchaseOrderReturnByEnity(PurchaseCommonEntity order, List<PurchaseOrderReturnDetailEntity> orderDetails)
        {
            try
            {
                PurchaseOrderReturn purchaseOrder = new PurchaseOrderReturn();
                List<PurchaseOrderReturnDetail> purchaseOrderDetails = new List<PurchaseOrderReturnDetail>();
                purchaseOrder.CreateUserId = order.OperateUserId;
                purchaseOrder.OrderStatusValue = order.OrderStatus;
                purchaseOrder.PurchaseOrderId = order.PurchaseOrderId;
                purchaseOrder.Decription = order.Description;
                purchaseOrder.RelatedOrderDocumentNumber = order.RelatedOrderDocumentNumber;
                purchaseOrder.RelatedOrderId = order.RelatedOrderId;
                purchaseOrder.RelatedOrderTypeValue = order.RelatedOrderTypeValue;
                foreach (var d in orderDetails)
                {
                    PurchaseOrderReturnDetail c = new PurchaseOrderReturnDetail();
                    c.IsReissue = d.IsReissue;
                    c.PurchaseReturnSourceValue = d.PurchaseReturnSourceValue;
                    c.ReissueAmount = d.ReissueAmount;
                    c.ReturnAmount = d.ReturnAmount;
                    c.ReturnHandledMethodValue = d.ReturnHandledMethodValue;
                    c.ReturnReason = d.ReturnReason;
                    c.Decription = d.Decription;
                    c.OutValidDate = d.OutValidDate;
                    c.PruductDate = d.PruductDate;
                    c.DrugInfoId = d.DrugInfoId;
                    c.BatchNumber = d.BatchNumber;
                    c.RelatedOrderId = d.RelatedOrderId;//作为purchaseInInventoryOrderDetail的id
                    c.PurchasePrice = d.PurchasePrice;
                    purchaseOrderDetails.Add(c);
                }
                return CreatePurchaseOrderReturn(purchaseOrder, purchaseOrderDetails);
            }
            catch (Exception ex)
            {
                return this.HandleException<string>("创建退货单失败", ex);
            }
        }
        //创建退货单
        public string CreatePurchaseOrderReturn(PurchaseOrderReturn order, List<PurchaseOrderReturnDetail> orderDetails)
        {
            string outDetail = string.Empty;
            try
            {
                order.Id = Guid.NewGuid();
                order.DocumentNumber = new BillDocumentCodeBusinessHandler(BusinessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.PurchaseOrderReturn).Code; ;
                order.CreateTime = DateTime.Now;
                order.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
                order.UpdateTime = DateTime.Now;
                order.UpdateUserId = order.CreateUserId;
                BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrderReturns.Add(order);

                DbSet<PurchaseOrderReturnDetail> dbSet = BusinessHandlerFactory.RepositoryProvider.Db.Set<PurchaseOrderReturnDetail>();

                Guid supplyUnitAccountExecutiveId = Guid.Empty;
                foreach (var d in orderDetails.Where(r => r.ReturnAmount > 0m))
                {
                    d.Id = Guid.NewGuid();
                    d.PurchaseOrderReturnId = order.Id;
                    d.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
                    //DrugInventoryRecord dr = RepositoryProvider.Db.DrugInventoryRecords.Where(r => r.PurchaseInInventeryOrderDetailId == d.RelatedOrderId || (r.DrugInfoId == d.DrugInfoId && r.BatchNumber == d.BatchNumber)).ToList().First();
                    var dr = RepositoryProvider.Db.DrugInventoryRecords.FirstOrDefault(r => r.PurchaseInInventeryOrderDetailId == d.RelatedOrderId);

                    dr.PurchaseReturnNumber += d.ReturnAmount;
                    dr.Valid = dr.CanSaleNum > 0;

                    if (dr.CanSaleNum < 0)
                    {
                        outDetail = string.Format("批号：{0},采购退货数量超出库存，请重新修改退货数量！", dr.BatchNumber);

                        throw new Exception(d.BatchNumber + "库存数量不足");
                    }

                    BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(dr);
                    dbSet.Add(d);
                }
                BusinessHandlerFactory.RepositoryProvider.Db.Commit();
                return order.DocumentNumber;
            }
            catch (Exception ex)
            {
                return this.HandleException<string>("创建退货单失败," + outDetail, ex);
            }
        }
        //退货查询单
        public List<PurchaseCommonEntity> GetPurchaseOrderReturns(string documentNumber, DateTime startTime, DateTime endTime, int[] orderStatusValue, Guid[] purchaseUnits, int index, int size)
        {
            try
            {
                if (startTime == null)
                {
                    startTime = DateTime.MinValue;
                }
                if (endTime == null)
                {
                    endTime = DateTime.MaxValue;
                }
                var queryBuilder = QueryBuilder.Create<PurchaseOrderReturn>()
                 .Like(q => q.DocumentNumber, documentNumber)
                 .Between(c => c.CreateTime, startTime.AddDays(-1), endTime.AddDays(1))
                 .Equals(q => q.Deleted, false);
                if (orderStatusValue.Length > 0 && orderStatusValue[0] != -1)
                {
                    queryBuilder = queryBuilder.In(q => q.OrderStatusValue, orderStatusValue);
                }
                var orders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrderReturns.Where(queryBuilder.Expression);

                var query = from o in orders
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on o.CreateUserId equals u.Id
                            join p in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders on o.PurchaseOrderId equals p.Id
                            join em in BusinessHandlerFactory.RepositoryProvider.Db.Employees on u.EmployeeId equals em.Id
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on p.SupplyUnitId equals d.Id
                            select new PurchaseCommonEntity
                            {
                                Id = o.Id,
                                DocumentNumber = o.DocumentNumber,
                                EmployeeNumber = em.Number,
                                EmployeeName = em.Name,
                                OperateTime = o.CreateTime,
                                OperateUserId = o.CreateUserId,
                                OrderStatus = o.OrderStatusValue,
                                PurchaseOrderDocumentNumber = p.DocumentNumber,
                                PurchaseOrderId = p.Id,
                                SupplyUnitId = p.SupplyUnitId,
                                SupplyUnitName = d.Name,
                                Description = o.Decription,
                                CheckerSuggest = o.CheckerSuggest,
                                CheckerUserId = o.CheckerUserId,
                                CheckerUpdateTime = o.CheckerUpdateTime,
                                FinanceDepartmentSuggest = o.FinanceDepartmentSuggest,
                                FinanceDepartmentUpdateTime = o.FinanceDepartmentUpdateTime,
                                FinanceDepartmentUserId = o.FinanceDepartmentUserId,
                                GeneralManagerSuggest = o.GeneralManagerSuggest,
                                GeneralManagerUpdateTime = o.GeneralManagerUpdateTime,
                                GeneralManagerUserId = o.GeneralManagerUserId,
                                QualitySuggest = o.QualitySuggest,
                                QualityUpdateTime = o.QualityUpdateTime,
                                QualityUserId = o.QualityUserId,
                                RelatedOrderDocumentNumber = o.RelatedOrderDocumentNumber,
                                RelatedOrderId = o.RelatedOrderId,
                                RelatedOrderTypeValue = o.RelatedOrderTypeValue,
                                RecordCount = orders.Count()
                            };
                if (purchaseUnits.Length > 0)
                {
                    query = query.Where(p => purchaseUnits.Contains(p.PurchaseOrderId));
                }
                List<PurchaseCommonEntity> list = query.OrderByDescending(p => p.OperateTime).Skip((index - 1) * size).Take(size).ToList();
                var employeeQuery = from emp in this.BusinessHandlerFactory.RepositoryProvider.Db.Employees
                                    join user in this.BusinessHandlerFactory.RepositoryProvider.Db.Users on emp.Id equals user.EmployeeId
                                    select new EmployeeModel
                                    {
                                        EmployeeId = emp.Id,
                                        EmployeeName = emp.Name,
                                        EmployeeNumber = emp.Number,
                                        UserId = user.Id
                                    };
                Dictionary<Guid, EmployeeModel> emp1 = new Dictionary<Guid, EmployeeModel>();
                foreach (var e in employeeQuery)
                {
                    emp1.Add(e.UserId, e);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (emp1.ContainsKey(list[i].FinanceDepartmentUserId))
                    {
                        list[i].FinanceDepartmentEmployeeName = emp1[list[i].FinanceDepartmentUserId].EmployeeName;
                        list[i].FinanceDepartmentEmployeeNumber = emp1[list[i].FinanceDepartmentUserId].EmployeeNumber;
                    }
                    if (emp1.ContainsKey(list[i].CheckerUserId))
                    {
                        list[i].CheckerEmployeeName = emp1[list[i].CheckerUserId].EmployeeName;
                        list[i].CheckerEmployeeNumber = emp1[list[i].CheckerUserId].EmployeeNumber;
                    }
                    if (emp1.ContainsKey(list[i].QualityUserId))
                    {
                        list[i].QualityEmployeeName = emp1[list[i].QualityUserId].EmployeeName;
                        list[i].QualityEmployeeNumber = emp1[list[i].QualityUserId].EmployeeNumber;
                    }
                    if (emp1.ContainsKey(list[i].GeneralManagerUserId))
                    {
                        list[i].GeneralManagerEmployeeName = emp1[list[i].GeneralManagerUserId].EmployeeName;
                        list[i].GeneralManagerEmployeeNumber = emp1[list[i].GeneralManagerUserId].EmployeeNumber;
                    }

                }
                return list;
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseCommonEntity>>("查询退货单失败", ex);
            }
        }

        //退货详细
        public List<PurchaseOrderReturnDetailEntity> GetPurchaseOrderReturnDetails(Guid orderId)
        {
            try
            {

                var queryBuilder = QueryBuilder.Create<PurchaseOrderReturnDetail>()
                .Equals(c => c.PurchaseOrderReturnId, orderId);

                var orderDetails = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrderReturnDetails.Where(queryBuilder.Expression);
                var query = from i in orderDetails
                            join r in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrderReturns on i.PurchaseOrderReturnId equals r.Id
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.DrugInfos on i.DrugInfoId equals d.Id
                            join e in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseInInventeryOrderDetails on i.RelatedOrderId equals e.Id
                            select new PurchaseOrderReturnDetailEntity
                            {
                                Id = i.Id,
                                Decription = i.Decription,
                                BatchNumber = i.BatchNumber,
                                OutValidDate = i.OutValidDate,
                                PruductDate = i.PruductDate,
                                DictionaryMeasurementUnitCode = d.DictionaryMeasurementUnitCode,
                                DictionarySpecificationCode = d.DictionarySpecificationCode,
                                FactoryName = d.FactoryName,
                                DictionaryDosageCode = d.DictionaryDosageCode,
                                ProductGeneralName = d.ProductGeneralName,
                                DrugInfoId = i.DrugInfoId,
                                IsReissue = i.IsReissue,
                                LicensePermissionNumber = d.LicensePermissionNumber,
                                PurchaseOrderReturnId = i.PurchaseOrderReturnId,
                                PurchaseReturnSourceValue = i.PurchaseReturnSourceValue,
                                ReissueAmount = i.ReissueAmount,
                                RelatedOrderId = i.RelatedOrderId,
                                ReturnAmount = i.ReturnAmount,
                                ReturnHandledMethodValue = i.ReturnHandledMethodValue,
                                ReturnReason = i.ReturnReason,
                                PurchasePrice = i.PurchasePrice,
                                inInventoryNum = e.ArrivalAmount,
                                Origin = e.Decription
                            };

                return query.OrderByDescending(p => p.ProductGeneralName).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseOrderReturnDetailEntity>>("根据订单号查询退货详细失败", ex);
            }
        }

        public System.Collections.Generic.IEnumerable<Business.Models.PurchaseOrderReturnModel> GetPReturnOrderByQureyModel(Business.Models.PurchaseOrderReturnQueryModel q)
        {
            var all = RepositoryProvider.Db.PurchaseOrderReturns.Where(r => r.CreateTime <= q.dtT && r.CreateTime >= q.dtF);
            if (!string.IsNullOrEmpty(q.Keyword))
            {
                all = all.Where(r => r.DocumentNumber.Contains(q.Keyword));
            }
            var u = from i in RepositoryProvider.Db.Users join j in RepositoryProvider.Db.Employees on i.EmployeeId equals j.Id select i;
            var c = from i in all
                    join j in this.Queryable on i.PurchaseOrderId equals j.Id
                    join k in u on i.CreateUserId equals k.Id
                    join l in RepositoryProvider.Db.PurchaseOrderReturnDetails on i.Id equals l.PurchaseOrderReturnId
                    join m in RepositoryProvider.Db.SupplyUnits on j.SupplyUnitId equals m.Id
                    where m.PinyinCode.ToUpper().Contains(q.SupplyUnitName.ToUpper()) || m.Name.Contains(q.SupplyUnitName)
                    join n in RepositoryProvider.Db.DrugInfos on l.DrugInfoId equals n.Id
                    join o in u on i.CheckerUserId equals o.Id
                    where n.Pinyin.Contains(q.DrugName) || n.ProductGeneralName.Contains(q.DrugName)
                    select new Business.Models.PurchaseOrderReturnModel
                    {
                        id = i.Id,
                        POrderCreater = k.Employee.Name,
                        POrderCreateTime = i.CreateTime,
                        POrderDocumentNumber = j.DocumentNumber,
                        POrderReturnDocumentNumber = i.DocumentNumber,
                        POrderFSuggest = i.FinanceDepartmentSuggest,
                        POrderQSuggest = i.QualitySuggest,
                        POrderQTime = (DateTime)i.QualityUpdateTime,
                        Pid = j.Id,
                        POrderFTime = i.FinanceDepartmentUpdateTime,
                        POrderMSuggest = i.GeneralManagerSuggest,
                        POrderMTime = i.GeneralManagerUpdateTime,
                        POrderReturnTotalMoney = l.ReturnAmount * l.PurchasePrice,
                        POrderReturnTotalNum = l.ReturnAmount,
                        POrderTotalMoney = j.PurchaseOrderDetails.Sum(r => r.Amount * r.PurchasePrice),
                        POrderTotalNum = j.PurchaseOrderDetails.Sum(r => r.Amount),
                        SupplyUnitName = m.Name,
                        QualityChecker = o.Employee.Name,
                        QualityStatus = "合格",
                    };

            return c;
        }

        //取消单据
        public bool CancelPurchaseReturnOrder(System.Guid PurchaseReturnOrderId)
        {
            try
            {
                var PR = RepositoryProvider.Db.PurchaseOrderReturns.Where(r => r.Id == PurchaseReturnOrderId).FirstOrDefault();
                if (PR == null) return false;
                PR.OrderStatus = OrderReturnStatus.Canceled;
                BusinessHandlerFactory.PurchaseOrderReturnBusinessHandler.Save(PR);
                var rd = RepositoryProvider.Db.PurchaseOrderReturnDetails.Where(r => r.PurchaseOrderReturnId == PurchaseReturnOrderId).ToList();
                foreach (var i in rd)
                {
                    var dic = RepositoryProvider.Db.DrugInventoryRecords.Where(r => r.PurchaseInInventeryOrderDetailId == i.RelatedOrderId && r.DrugInfoId == i.DrugInfoId && r.BatchNumber == i.BatchNumber).FirstOrDefault();
                    if (dic == null) continue;
                    dic.PurchaseReturnNumber -= i.ReturnAmount;
                    dic.Valid = dic.CanSaleNum > 0;
                    BusinessHandlerFactory.PurchaseReceivingOrderDetailBusinessHandler.Delete(i.Id);
                    BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(dic);
                }
                this.Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                this.Dispose();
            }
        }

        #endregion

        #region 结算
        //采购结算单据查询
        public List<PurchaseCommonEntity> GetPurchaseCashOrdersByPurchaseOrderId(Guid purchaseOrderId)
        {
            try
            {
                var queryBuilder = QueryBuilder.Create<PurchaseCashOrder>()
                 .Equals(q => q.PurchaseOrderId, purchaseOrderId);
                var orders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCashOrders.Where(queryBuilder.Expression);

                var query = from o in orders
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on o.OperateUserId equals u.Id
                            join p in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders on o.PurchaseOrderId equals p.Id
                            join em in BusinessHandlerFactory.RepositoryProvider.Db.Employees on u.EmployeeId equals em.Id
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on p.SupplyUnitId equals d.Id
                            join payment in BusinessHandlerFactory.RepositoryProvider.Db.PaymentMethods on o.PaymentMethodId equals payment.Id
                            select new PurchaseCommonEntity
                            {
                                Id = o.Id,
                                DocumentNumber = o.DocumentNumber,
                                EmployeeNumber = em.Number,
                                EmployeeName = em.Name,
                                OperateTime = o.OperateTime,
                                OperateUserId = o.OperateUserId,
                                OrderStatus = o.OrderStatusValue,
                                PurchaseOrderDocumentNumber = p.DocumentNumber,
                                PurchaseOrderId = p.Id,
                                SupplyUnitId = p.SupplyUnitId,
                                SupplyUnitName = d.Name,
                                DealerMethodValue = o.DealerMethodValue,
                                Description = o.Decription,
                                PaymentAmount = o.PaymentAmount,
                                PaymentedAmount = o.PaymentedAmount,
                                PaymentingAmount = o.PaymentingAmount,
                                PaymentMethod = payment.Name,
                                PaymentTime = o.PaymentTime,
                                RelatedOrderId = o.RelatedOrderId,
                                TotalAmount = p.TotalMoney,
                                RelatedOrderDocumentNumber = o.RelatedOrderDocumentNumber,
                                RelatedOrderTypeValue = o.RelatedOrderTypeValue,
                                RecordCount = orders.Count()
                            };
                return query.OrderByDescending(p => p.OperateTime).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseCommonEntity>>("查询采购结算单据失败", ex);
            }
        }
        //创建结算单通过自定义Model(弃用)
        public string CreatePurchaseCashOrderByEnity(PurchaseCommonEntity order)
        {
            try
            {
                PurchaseCashOrder purchaseOrder = new PurchaseCashOrder();
                purchaseOrder.OperateUserId = order.OperateUserId;
                purchaseOrder.OrderStatusValue = order.OrderStatus;
                purchaseOrder.PurchaseOrderId = order.PurchaseOrderId;
                purchaseOrder.Decription = order.Description;
                purchaseOrder.PaymentTime = order.PaymentTime;
                purchaseOrder.DealerMethodValue = order.DealerMethodValue;
                purchaseOrder.PaymentAmount = order.PaymentAmount;
                purchaseOrder.PaymentedAmount = order.PaymentedAmount;
                purchaseOrder.PaymentingAmount = order.PaymentingAmount;
                return CreatePurchaseCashOrder(purchaseOrder);
            }
            catch (Exception ex)
            {
                return this.HandleException<string>("创建结算单失败", ex);
            }
        }
        //创建结算单
        public string CreatePurchaseCashOrder(PurchaseCashOrder order)
        {
            try
            {
                order.Id = Guid.NewGuid();
                order.DocumentNumber = new BillDocumentCodeBusinessHandler(BusinessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.PurchaseCashOrder).Code; ;
                order.OperateTime = DateTime.Now;
                order.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
                BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCashOrders.Add(order);
                var purchaseOrders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders.FirstOrDefault(p => p.Id == order.PurchaseOrderId);
                //采购结算
                purchaseOrders.OrderStatusValue = 15;
                purchaseOrders.UpdateTime = DateTime.Now;
                purchaseOrders.UpdateUserId = order.OperateUserId;
                // 1 收货单 2 验收单 3 入库单 5退货单
                if (order.RelatedOrderTypeValue == 1)
                {
                    var releatedOrders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseReceivingOrders.FirstOrDefault(p => p.Id == order.RelatedOrderId);
                    if (releatedOrders != null)
                    {
                        releatedOrders.OrderStatusValue = order.OrderStatusValue;
                    }
                }
                else if (order.RelatedOrderTypeValue == 2)
                {
                    var releatedOrders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCheckingOrders.FirstOrDefault(p => p.Id == order.RelatedOrderId);
                    if (releatedOrders != null)
                    {
                        releatedOrders.OrderStatusValue = order.OrderStatusValue;
                    }
                }
                else if (order.RelatedOrderTypeValue == 3)
                {
                    var releatedOrders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseInInventeryOrders.FirstOrDefault(p => p.Id == order.RelatedOrderId);
                    if (releatedOrders != null)
                    {
                        releatedOrders.OrderStatusValue = order.OrderStatusValue;
                    }
                }
                else if (order.RelatedOrderTypeValue == 5)
                {
                    var releatedOrders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrderReturns.FirstOrDefault(p => p.Id == order.RelatedOrderId);
                    if (releatedOrders != null)
                    {
                        releatedOrders.OrderStatusValue = order.OrderStatusValue;
                    }
                }
                BusinessHandlerFactory.RepositoryProvider.Db.Commit();
                return order.DocumentNumber;
            }
            catch (Exception ex)
            {
                return this.HandleException<string>("创建结算单失败", ex);
            }
        }

        //结算查询单
        public List<PurchaseCommonEntity> GetPurchaseCashOrders(string documentNumber, DateTime startTime, DateTime endTime, int[] orderStatusValue, Guid[] purchaseUnits, int index, int size)
        {
            try
            {
                if (startTime == null)
                {
                    startTime = DateTime.MinValue;
                }
                if (endTime == null)
                {
                    endTime = DateTime.MaxValue;
                }
                var queryBuilder = QueryBuilder.Create<PurchaseCashOrder>()
                 .Like(q => q.DocumentNumber, documentNumber)
                 .Between(c => c.OperateTime, startTime.AddDays(-1), endTime.AddDays(1));
                if (orderStatusValue.Length > 0 && orderStatusValue[0] != -1)
                {
                    queryBuilder = queryBuilder.In(q => q.OrderStatusValue, orderStatusValue);
                }
                var orders = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseCashOrders.Where(queryBuilder.Expression);

                var query = from o in orders
                            join u in BusinessHandlerFactory.RepositoryProvider.Db.Users on o.OperateUserId equals u.Id
                            join p in BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders on o.PurchaseOrderId equals p.Id
                            join em in BusinessHandlerFactory.RepositoryProvider.Db.Employees on u.EmployeeId equals em.Id
                            join d in BusinessHandlerFactory.RepositoryProvider.Db.SupplyUnits on p.SupplyUnitId equals d.Id
                            join payment in BusinessHandlerFactory.RepositoryProvider.Db.PaymentMethods on o.PaymentMethodId equals payment.Id
                            select new PurchaseCommonEntity
                            {
                                Id = o.Id,
                                DocumentNumber = o.DocumentNumber,
                                EmployeeNumber = em.Number,
                                EmployeeName = em.Name,
                                OperateTime = o.OperateTime,
                                OperateUserId = o.OperateUserId,
                                OrderStatus = p.OrderStatusValue,
                                PurchaseOrderDocumentNumber = p.DocumentNumber,
                                PurchaseOrderId = p.Id,
                                SupplyUnitId = p.SupplyUnitId,
                                SupplyUnitName = d.Name,
                                DealerMethodValue = o.DealerMethodValue,
                                Description = o.Decription,
                                PaymentAmount = o.PaymentAmount,
                                PaymentedAmount = o.PaymentedAmount,
                                PaymentingAmount = o.PaymentingAmount,
                                PaymentMethod = payment.Name,
                                PaymentTime = o.PaymentTime,
                                RelatedOrderId = o.RelatedOrderId,
                                TotalAmount = p.TotalMoney,
                                RelatedOrderDocumentNumber = o.RelatedOrderDocumentNumber,
                                RelatedOrderTypeValue = o.RelatedOrderTypeValue,
                                RecordCount = orders.Count()
                            };
                //if (orderStatusValue != -1)
                //{
                //    query = query.Where(p => p.OrderStatus == orderStatusValue);
                //}
                if (purchaseUnits.Length > 0)
                {
                    query = query.Where(p => purchaseUnits.Contains(p.PurchaseOrderId));
                }
                return query.OrderByDescending(p => p.OperateTime).Skip((index - 1) * size).Take(size).ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<PurchaseCommonEntity>>("查询结算单失败", ex);
            }
        }
        #endregion

        /// <summary>
        /// 销售开票时查询供货商信息
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="GType">查询类型0-表示该批次来源；1-表示该药品所有来源</param>
        /// <returns></returns>
        public System.Collections.Generic.List<HistoryPurchase> GetPurchaseHistoryByInInventoryPurchaseID(System.Guid id, int GType)
        {
            List<HistoryPurchase> list = new List<HistoryPurchase>();
            if (GType == 0)
            {
                var pinD = BusinessHandlerFactory.PurchaseInInventeryOrderDetailBusinessHandler.Get(id);
                if (pinD == null) return null;

                var result = from i in RepositoryProvider.Db.PurchaseInInventeryOrderDetails
                             where i.DrugInfoId == pinD.DrugInfoId && i.BatchNumber == pinD.BatchNumber && i.Deleted == false
                             join j in RepositoryProvider.Db.PurchaseInInventeryOrders on i.PurchaseInInventeryOrderId equals j.Id
                             where j.Deleted == false
                             join k in RepositoryProvider.Db.PurchaseOrders on j.PurchaseOrderId equals k.Id
                             where k.Deleted == false && k.OrderStatusValue > 4
                             join d in RepositoryProvider.Db.DrugInfos on i.DrugInfoId equals d.Id
                             where d.Deleted == false
                             join s in RepositoryProvider.Db.SupplyUnits on k.SupplyUnitId equals s.Id
                             where s.Deleted == false
                             select new HistoryPurchase
                             {
                                 inInventoryDate = i.ArrivalDateTime,
                                 productName = d.ProductGeneralName,
                                 BatchNumber = i.BatchNumber,
                                 inInventoryNum = i.ArrivalAmount,
                                 PurchaseOrderDocumentNumber = k.DocumentNumber,
                                 purchasePrice = i.PurchasePrice,
                                 supplyUnit = s.Name,
                             };
                var ListResult = result.OrderByDescending(r => r.inInventoryDate).ToList();
                ListResult.ForEach(r => { r.inInventoryDate = r.inInventoryDate.Date; });
                return ListResult;
            }
            if (GType == 1)
            {
                var result = from i in RepositoryProvider.Db.PurchaseInInventeryOrderDetails
                             where i.DrugInfoId == id && i.Deleted == false
                             join j in RepositoryProvider.Db.PurchaseInInventeryOrders on i.PurchaseInInventeryOrderId equals j.Id
                             where j.Deleted == false
                             join k in RepositoryProvider.Db.PurchaseOrders on j.PurchaseOrderId equals k.Id
                             where k.Deleted == false && k.OrderStatusValue > 4
                             join d in RepositoryProvider.Db.DrugInfos on i.DrugInfoId equals d.Id
                             where d.Deleted == false
                             join s in RepositoryProvider.Db.SupplyUnits on k.SupplyUnitId equals s.Id
                             where s.Deleted == false
                             select new HistoryPurchase
                             {
                                 inInventoryDate = i.ArrivalDateTime,
                                 productName = d.ProductGeneralName,
                                 BatchNumber = i.BatchNumber,
                                 inInventoryNum = i.ArrivalAmount,
                                 PurchaseOrderDocumentNumber = k.DocumentNumber,
                                 purchasePrice = i.PurchasePrice,
                                 supplyUnit = s.Name,
                             };
                var ListResult = result.OrderByDescending(r => r.inInventoryDate).ToList();
                ListResult.ForEach(r => { r.inInventoryDate = r.inInventoryDate.Date; });
                return ListResult;
            }
            return list;
        }

        /// <summary>
        /// 采购税票查询
        /// </summary>
        /// <param name="SuId"></param>
        /// <param name="dtF"></param>
        /// <param name="dtT"></param>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerable<Business.Models.PurchaseTaxReturn> GetPurchaseTaxReturn(System.Guid SuId, DateTime dtF, DateTime dtT)
        {
            var c = this.Queryable.Where(r => r.CreateTime >= dtF && r.CreateTime <= dtT && (r.OrderStatusValue > 4 || r.OrderStatusValue == 2));
            if (!SuId.Equals(Guid.Empty))
                c = c.Where(r => r.SupplyUnitId == SuId);
            var usr = RepositoryProvider.Db.Users.Include(r => r.Employee);

            var all = from i in c
                      join j in RepositoryProvider.Db.SupplyUnits on i.SupplyUnitId equals j.Id
                      join k in usr on (Guid)i.TaxReturnUserID equals k.Id into left
                      from k in left.DefaultIfEmpty()
                      select new PurchaseTaxReturn
                      {
                          CreateTime = i.CreateTime,
                          CreateUserId = i.CreateUserId,
                          DocumentNumber = i.DocumentNumber,
                          EmployeeName = k == null ? "公司" : k.Employee.Name,
                          EmployeeNumber = k == null ? "公司" : k.Employee.Number,
                          Id = i.Id,
                          InvoiceMoney = i.InvoiceMoney,
                          IsInvoiceArrival = i.IsInvoiceArrival,
                          IsPayed = i.IsPayed,
                          OrderStatusValue = i.OrderStatusValue,
                          PayMoney = i.PayMoney,
                          SupplyUnitId = i.SupplyUnitId,
                          SupplyUnitName = j.Name,
                          SupplyUnitBank = j.Bank,
                          TaxReturnUserName = k == null ? "公司" : k.Employee.Name,
                          TaxReturnUserId = k == null ? Guid.Empty : k.Id,
                          TotalMoney = i.TotalMoney,
                          Diff = (bool)i.IsInvoiceArrival ? (decimal)i.PayMoney - (decimal)i.InvoiceMoney : 0m,
                          Rate = k.PurchaseTaxReturn,
                          ReturnTax = (bool)i.IsInvoiceArrival ? (decimal)k.PurchaseTaxReturn * 0.01m * i.InvoiceMoney : 0m,
                          PuchaseOrderConcatID = i.PurchaseOrderConcatID,
                          Decription = i.Decription
                      };
            return all;
        }

        public bool SavePurchaseOrdersByPurchaseTaxReturn(Business.Models.PurchaseTaxReturn[] list)
        {
            try
            {
                foreach (var c in list)
                {
                    var r = BusinessHandlerFactory.PurchaseOrderBusinessHandler.Get(c.Id);
                    r.PurchaseOrderConcatID = c.PuchaseOrderConcatID;
                    r.IsInvoiceArrival = c.IsInvoiceArrival;
                    r.InvoiceMoney = c.InvoiceMoney;
                    r.IsPayed = c.IsPayed;
                    r.PayMoney = c.PayMoney;
                    r.Decription = c.Decription;
                    this.Save(r);
                }
                this.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public System.Collections.Generic.IEnumerable<Business.Models.SupplyUnitHistoryDrugList> GetSupplyUnitHistoryDrugList(string Keyword, string DrugName, Guid SUId, DateTime dtf, DateTime dtt)
        {
            var u = RepositoryProvider.Db.Users.Include(r => r.Employee);
            IEnumerable<SupplyUnit> ListSu = RepositoryProvider.Db.SupplyUnits;

            if (SUId != Guid.Empty)
            {
                ListSu = ListSu.Where(r => r.Id == SUId);
            }
            if (!string.IsNullOrEmpty(Keyword))
            {
                ListSu = ListSu.Where(r => r.Name.Contains(Keyword) || (r.PinyinCode != null && r.PinyinCode.ToUpper().Contains(Keyword.ToUpper())));
            }

            if (dtf == null)
            {
                dtf = DateTime.Now.AddYears(-2).Date;
            }
            if (dtt == null)
            {
                dtt = DateTime.Now.Date;
            }

            var DrugInfo = RepositoryProvider.Db.DrugInfos.AsEnumerable();
            if (!string.IsNullOrEmpty(DrugName))
            {
                DrugInfo = DrugInfo.Where(r => (r.Pinyin != null && r.Pinyin.ToUpper().Contains(DrugName.ToUpper())) || r.ProductGeneralName.Contains(DrugName));
            }

            var c = from j in ListSu
                    join i in this.Queryable on j.Id equals i.SupplyUnitId
                    join u0 in u on i.CreateUserId equals u0.Id
                    where i.ApprovaledTime != null && i.Deleted == false && i.CreateTime > dtf && i.CreateTime < dtt
                    join k in RepositoryProvider.Db.PurchaseReceivingOrders on i.Id equals k.PurchaseOrderId
                    where k.Deleted == false
                    join u3 in u on k.OperateUserId equals u3.Id
                    join l in RepositoryProvider.Db.PurchaseCheckingOrders on i.Id equals l.PurchaseOrderId
                    join u1 in u on l.OperateUserId equals u1.Id
                    join m in RepositoryProvider.Db.PurchaseInInventeryOrders on i.Id equals m.PurchaseOrderId
                    join u2 in u on m.OperateUserId equals u2.Id
                    join d in RepositoryProvider.Db.PurchaseInInventeryOrderDetails on m.Id equals d.PurchaseInInventeryOrderId
                    join di in DrugInfo on d.DrugInfoId equals di.Id
                    join w in RepositoryProvider.Db.WarehouseZones on d.WarehouseZoneId equals w.Id

                    join dir in RepositoryProvider.Db.DrugInventoryRecords on new { dinfo = d.DrugInfoId, dbatch = d.BatchNumber, dOrigin = d.Decription } equals new { dinfo = dir.DrugInfoId, dbatch = dir.BatchNumber, dOrigin = dir.Decription } into left
                    from dir in left.DefaultIfEmpty()
                    select new Business.Models.SupplyUnitHistoryDrugList
                    {
                        batchNumber = d.BatchNumber,
                        Checker = u1 == null ? "暂未验收入库，无验收员" : u1.Employee.Name,
                        CheckTime = l.OperateTime,
                        CreateTime = i.CreateTime,
                        Creator = u0.Employee.Name,
                        dosage = di.DictionaryDosageCode,
                        DrugInfoId = di.Id,
                        drugName = di.ProductGeneralName,
                        factoryName = di.FactoryName,
                        InInventoryMan = u2 == null ? "暂未入库，无保管员" : u2.Employee.Name,
                        InventoryTime = m.OperateTime,
                        permitNumber = di.LicensePermissionNumber,
                        PurchaseOrderDocumentNumber = i.DocumentNumber,
                        purchaseOrderID = i.Id,
                        SupplyUnitName = j.Name,
                        SupplyUnitId = j.Id,
                        Receiver = u3 == null ? "暂未收货，无收货员" : u3.Employee.Name,
                        ReceiveTime = k.OperateTime,
                        specific = di.DictionarySpecificationCode,
                        cansaleNum = dir == null ? 0 : dir.CanSaleNum,
                        InventoryNum = d.ArrivalAmount,
                        InventorySum = d.ArrivalAmount * d.PurchasePrice,
                        Origin = dir == null ? di.Origin : dir.Decription,
                        PurchasePrice = d.PurchasePrice,
                        WareHouseZone = w.Name,
                        outValidDate = d.OutValidDate,
                        SecondChecker = l.SecondCheckerName,
                        SecondCheckerMemo = l.SecondCheckMemo,
                        MeasurmentUnit = di.DictionaryMeasurementUnitCode

                    };
            return c;
        }

        /// <summary>
        /// 以EXCEL形式检查品种是否存在
        /// </summary>
        /// <param name="List"></param>
        /// <returns>没找到的品种信息</returns>
        public System.Collections.Generic.IEnumerable<Business.Models.PurchaseOrderImpt> CheckForPurchaseOrderDetails(System.Collections.Generic.IEnumerable<Business.Models.PurchaseOrderImpt> List)
        {
            foreach (var row in List)
            {
                var b = RepositoryProvider.Db.DrugInfos.FirstOrDefault(r =>
                r.ProductGeneralName == row.ProductGeneralName
                && r.DictionaryDosageCode == row.DosageName
                && r.DictionarySpecificationCode == row.SpecificName
                && r.DictionaryMeasurementUnitCode == row.MeasurementName
                && r.FactoryName == row.FactoryName);

                if (b != null)
                {
                    if (b.BusinessScopeCode.Contains("中药") && b.Origin == row.Origin)
                    {
                        row.DrugInfoId = b.Id;
                    }
                    else
                    {
                        row.DrugInfoId = b.Id;
                    }
                }
            }

            return List;
        }

        /// <summary>
        /// 采购时，选择药品
        /// </summary>
        /// <param name="q">查询参数Model</param>
        /// <returns>DrugInfoForPurchaseSelectorModel列表</returns>
        public System.Collections.Generic.IEnumerable<Business.Models.DrugInfoForPurchaseSelectorModel> GetDrugInfoForpurchaseSelector(DrugInfoForPurchaseSelectorQueryModel q)
        {
            var pu = BusinessHandlerFactory.SupplyUnitBusinessHandler.Get(q.SupplyUnitId);
            var businessScopeName = this.RepositoryProvider.Db.GMSPLicenseBusinessScopes.Where(r => r.GSPLicense.Id == pu.GSPLicenseId).Select(r => r.BusinessScope.Name);

            var druginfoes = this.RepositoryProvider.Db.DrugInfos.Where(r => r.Deleted == false && r.Valid);

            if (!string.IsNullOrEmpty(q.Keyword))
            {
                druginfoes = druginfoes.Where(r => r.ProductGeneralName.Contains(q.Keyword) || r.Pinyin.Contains(q.Keyword.ToUpper()));
            }

            if (!string.IsNullOrEmpty(q.FactoryName))
            {
                druginfoes = druginfoes.Where(r => r.FactoryName.Contains(q.FactoryName));
            }

            var re = from i in druginfoes
                     join j in businessScopeName on i.BusinessScopeCode equals j
                     select new Business.Models.DrugInfoForPurchaseSelectorModel
                     {
                         DosageName = i.DictionaryDosageCode,
                         DrugInfoId = i.Id,
                         FactoryName = i.FactoryName,
                         LiscencePermitNumber = i.LicensePermissionNumber,
                         MeasurementName = i.DictionaryMeasurementUnitCode,
                         Origin = i.Origin,
                         ProductGeneralName = i.ProductGeneralName,
                         SpecificName = i.DictionarySpecificationCode
                     };
            return re.OrderBy(r => r.ProductGeneralName);

        }

        #region 获取最近采购价格
        /// <summary>
        /// 获取最近采购价格
        /// </summary>
        /// <param name="DrugInfoIds">客户端提交的品种id列表</param>
        /// <returns>Business.Models.LastPurchaseUnitPrice模型列表</returns>
        public Business.Models.LastPurchaseUnitPrice[] GetLastPurchaseUnitPrice(System.Guid[] DrugInfoIds)
        {
            if (DrugInfoIds.Count() < 0) return null;
            var g = from i in DrugInfoIds.ToArray()
                    join j in RepositoryProvider.Db.PurchaseInInventeryOrderDetails on i equals j.DrugInfoId
                    select j;
            g = g.GroupBy(r => r.DrugInfoId).Select(s => s.OrderByDescending(r => r.ArrivalDateTime).FirstOrDefault());
            var re = g.Select(r => new Business.Models.LastPurchaseUnitPrice
            {
                DrugInfoId = r.DrugInfoId,
                UnitPrice = r.PurchasePrice
            });
            return re.ToArray();
        }
        #endregion

        //public System.Collections.Generic.IEnumerable<Business.Models.Model_IdName> GetOriginByDrugInfoId(string keyword)
    }
}
