using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Repository;

namespace BugsBox.Pharmacy.MonitorHandlers
{
    /// <summary>
    /// 药品养护
    /// </summary>
    public class DrugMaintain
    {
        static BusinessHandlerFactory businessHandlerFactory = new BusinessHandlerFactory(new Db(), null);
        /// <summary>
        /// 养护药品记录，品种类型值：0
        /// </summary>
        public static void CreateMaintainRecord()
        {
            try
            {
                List<DrugMaintainRecord> ListM = businessHandlerFactory.DrugMaintainRecordBusinessHandler.Queryable.Where(r => r.DrugMaintainTypeValue == 0).ToList();
                int MCount = ListM.Count;
                ListM = businessHandlerFactory.DrugMaintainRecordBusinessHandler.Queryable.Where(r => r.CreateTime.Month == DateTime.Now.Month && r.CreateTime.Year == DateTime.Now.Year && r.DrugMaintainTypeValue == 0).ToList();
                if (ListM.Count > 0) return;

                DrugMaintainRecord dmr = new DrugMaintainRecord();
                var billcode = new BillDocumentCodeBusinessHandler(businessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.DrugMaintain);
                dmr.BillDocumentNo = billcode.Code;
                dmr.CompleteState = 0;
                dmr.CreateTime = DateTime.Now;
                dmr.CreateUserId = Guid.Empty;
                dmr.DrugMaintainTypeValue = 0;  //养护药品类型？
                dmr.ExpirationDate = DateTime.Now.AddMonths(1);
                dmr.Id = Guid.NewGuid();
                dmr.UpdateTime = DateTime.Now;
                dmr.UpdateUserId = Guid.Empty;
               

                DateTime CDate = DateTime.Now.Date.AddDays(-DateTime.Now.Day + 1).AddMonths(6);

                IEnumerable<DrugInventoryRecord> ListDI = businessHandlerFactory.DrugInventoryRecordBusinessHandler.Queryable.Where(r => r.CanSaleNum > 0 && (r.DrugInfo.IsMainMaintenance == false && r.DrugInfo.IsImport == false && r.DrugInfo.IsSpecialDrugCategory == false && r.OutValidDate > CDate) && !(r.DrugInfo.BusinessScopeCode.Contains("器械")) && !(r.DrugInfo.BusinessScopeCode.Contains("保健食品")) && !(r.DrugInfo.BusinessScopeCode.Contains("中药饮片")) && !(r.DrugInfo.BusinessScopeCode.Contains("中药材"))).OrderBy(r => r.DrugInfo.ProductGeneralName);

                int RCount = MCount % 3;
                if (RCount == 0 || RCount == 1) //第一月和第二月
                {
                    int takeCount = (int)(ListDI.Count() / 3);
                    ListDI = ListDI.Skip(takeCount * RCount).Take(takeCount).ToList();
                }
                if (RCount == 2)//第三月
                {
                    int takeCount = (int)(ListDI.Count() / 3);
                    ListDI = ListDI.Skip(takeCount * RCount).Take(ListDI.Count() - takeCount).ToList();
                }

                IEnumerable<PurchaseInInventeryOrderDetail> ListPIIOD = businessHandlerFactory.PurchaseInInventeryOrderDetailBusinessHandler.Queryable;
                IEnumerable<PurchaseInInventeryOrder> ListPIIO = businessHandlerFactory.PurchaseInInventeryOrderBusinessHandler.Queryable;

                var d = from i in ListDI
                        join p in ListPIIOD on i.PurchaseInInventeryOrderDetailId equals p.Id
                        join piio in ListPIIO on p.PurchaseInInventeryOrderId equals piio.Id
                        where (DateTime.Now - piio.OperateTime).Days > 30
                        select new DrugMaintainRecordDetail
                        {
                            BatchNumber = i.BatchNumber,
                            CheckqualifiedNumber = "0",
                            CurrentInventoryCount = i.CanSaleNum,
                            DictionaryDosageCode = i.DrugInfo.DictionaryDosageCode,
                            DrugInventoryRecordId = i.Id,
                            DictionarySpecificationCode = i.DrugInfo.DictionarySpecificationCode,
                            LicensePermissionNumber = i.DrugInfo.LicensePermissionNumber,
                            MaintainCount = 0,
                            Manufacturer = i.DrugInfo.FactoryName,
                            Origin = i.Decription,
                            OutValidDate = i.OutValidDate,
                            Price = i.PurchasePricce,
                            ProductName = i.DrugInfo.ProductGeneralName,
                            PruductDate = i.PruductDate,
                            Id = Guid.NewGuid(),
                            UserId = Guid.Empty,
                            BillDocumentNo = dmr.BillDocumentNo,
                            DictionaryMeasurementUnitCode = i.DrugInfo.DictionaryMeasurementUnitCode,
                            MaintainResult = string.Empty,
                            QualitySituation = "合格",
                            Deleted = false
                        };
                var dd = from i in ListDI
                         where i.PurchaseInInventeryOrderDetailId.Equals(Guid.Empty)
                         select new DrugMaintainRecordDetail
                         {
                             BatchNumber = i.BatchNumber,
                             CheckqualifiedNumber = "0",
                             CurrentInventoryCount = i.CanSaleNum,
                             DictionaryDosageCode = i.DrugInfo.DictionaryDosageCode,
                             DrugInventoryRecordId = i.Id,
                             DictionarySpecificationCode = i.DrugInfo.DictionarySpecificationCode,
                             LicensePermissionNumber = i.DrugInfo.LicensePermissionNumber,
                             MaintainCount = 0,
                             Manufacturer = i.DrugInfo.FactoryName,
                             Origin = i.Decription,
                             OutValidDate = i.OutValidDate,
                             Price = i.PurchasePricce,
                             ProductName = i.DrugInfo.ProductGeneralName,
                             PruductDate = i.PruductDate,
                             Id = Guid.NewGuid(),
                             UserId = Guid.Empty,
                             BillDocumentNo = dmr.BillDocumentNo,
                             DictionaryMeasurementUnitCode = i.DrugInfo.DictionaryMeasurementUnitCode,
                             MaintainResult = string.Empty,
                             QualitySituation = "合格",
                             Deleted = false
                         };

                var all = d.Concat(dd);
                if (all.Count() > 0)
                {
                    businessHandlerFactory.DrugMaintainRecordBusinessHandler.Add(dmr);
                    businessHandlerFactory.BillDocumentCodeBusinessHandler.Add(billcode);
                    businessHandlerFactory.DrugMaintainRecordDetailBusinessHandler.AddMaintainDetails(all);
                }
                BusinessHandlerFactory.DisposeBusinessHandlerFactory(businessHandlerFactory);
                all = null;
                ListDI = null;
                ListPIIO = null;
                ListPIIOD = null;
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        /// <summary>
        /// 重点养护，品种类型值：1
        /// </summary>
        public static void CreateDrugMantainImpt()
        {
            try
            {
                List<DrugMaintainRecord> ListM = businessHandlerFactory.DrugMaintainRecordBusinessHandler.Queryable.Where(r => r.CreateTime.Month == DateTime.Now.Month && r.CreateTime.Year == DateTime.Now.Year && r.DrugMaintainTypeValue == 1).ToList();
                if (ListM.Count > 0) return;

                DrugMaintainRecord dmr = new DrugMaintainRecord();
                var billcode = new BillDocumentCodeBusinessHandler(businessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.DrugMaintain);

                dmr.BillDocumentNo = billcode.Code;
                dmr.CompleteState = 0;
                dmr.CreateTime = DateTime.Now;
                dmr.CreateUserId = Guid.Empty;
                dmr.DrugMaintainTypeValue = 1;  //养护药品类型？
                dmr.ExpirationDate = DateTime.Now.AddMonths(1);
                dmr.Id = Guid.NewGuid();
                dmr.UpdateTime = DateTime.Now;
                dmr.UpdateUserId = Guid.Empty;                

                DateTime CDate = DateTime.Now.Date.AddDays(-DateTime.Now.Day + 1).AddMonths(6);

                IEnumerable<DrugInventoryRecord> ListDI = businessHandlerFactory.DrugInventoryRecordBusinessHandler.Queryable.Where(r => r.CanSaleNum > 0 && (r.DrugInfo.IsMainMaintenance || r.DrugInfo.IsSpecialDrugCategory || r.DrugInfo.IsImport || r.OutValidDate <= CDate) && !r.DrugInfo.BusinessScopeCode.Contains("器械") && !(r.DrugInfo.BusinessScopeCode.Contains("保健食品")) && !(r.DrugInfo.BusinessScopeCode.Contains("中药饮片")) && !(r.DrugInfo.BusinessScopeCode.Contains("中药材"))).OrderBy(r => r.DrugInfo.ProductGeneralName);
                var d = from i in ListDI
                        select new DrugMaintainRecordDetail
                        {
                            BatchNumber = i.BatchNumber,
                            CheckqualifiedNumber = "0",
                            CurrentInventoryCount = i.CanSaleNum,
                            DictionaryDosageCode = i.DrugInfo.DictionaryDosageCode,
                            DrugInventoryRecordId = i.Id,
                            DictionarySpecificationCode = i.DrugInfo.DictionarySpecificationCode,
                            LicensePermissionNumber = i.DrugInfo.LicensePermissionNumber,
                            MaintainCount = 0,
                            Manufacturer = i.DrugInfo.FactoryName,
                            Origin = i.Decription,
                            OutValidDate = i.OutValidDate,
                            Price = i.PurchasePricce,
                            ProductName = i.DrugInfo.ProductGeneralName,
                            PruductDate = i.PruductDate,
                            Id = Guid.NewGuid(),
                            UserId = Guid.Empty,
                            BillDocumentNo = dmr.BillDocumentNo,
                            DictionaryMeasurementUnitCode = i.DrugInfo.DictionaryMeasurementUnitCode,
                            MaintainResult = string.Empty,
                            QualitySituation = "合格",
                            Deleted = false
                        };
                if (d.Count() > 0)
                {
                    businessHandlerFactory.DrugMaintainRecordBusinessHandler.Add(dmr);
                    businessHandlerFactory.BillDocumentCodeBusinessHandler.Add(billcode);
                    businessHandlerFactory.DrugMaintainRecordDetailBusinessHandler.AddMaintainDetails(d);
                }
                ListDI = null;
                BusinessHandlerFactory.DisposeBusinessHandlerFactory(businessHandlerFactory);
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        /// <summary>
        /// 医疗器械养护，品种类型值：2
        /// </summary>
        public static void CreateDrugMantainInst()
        {
            try
            {
                List<DrugMaintainRecord> ListM = businessHandlerFactory.DrugMaintainRecordBusinessHandler.Queryable.Where(r => r.CreateTime.Month == DateTime.Now.Month && r.CreateTime.Year == DateTime.Now.Year && r.DrugMaintainTypeValue == 2).ToList();
                if (ListM.Count > 0) return;

                DrugMaintainRecord dmr = new DrugMaintainRecord();
                var billcode = new BillDocumentCodeBusinessHandler(businessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.DrugMaintain);
                dmr.BillDocumentNo = billcode.Code;
                dmr.CompleteState = 0;
                dmr.CreateTime = DateTime.Now;
                dmr.CreateUserId = Guid.Empty;
                dmr.DrugMaintainTypeValue = 2;  //养护药品类型？
                dmr.ExpirationDate = DateTime.Now.AddMonths(1);
                dmr.Id = Guid.NewGuid();
                dmr.UpdateTime = DateTime.Now;
                dmr.UpdateUserId = Guid.Empty;
                
                DateTime dt = DateTime.Now.Date.AddDays(-DateTime.Now.Day + 1).AddMonths(6);

                IEnumerable<DrugInventoryRecord> ListDI = businessHandlerFactory.DrugInventoryRecordBusinessHandler.Queryable.Where(r => r.CanSaleNum > 0 && (r.DrugInfo.BusinessScopeCode.Contains("器械"))).OrderBy(r => r.DrugInfo.ProductGeneralName);

                var d = from i in ListDI
                        select new DrugMaintainRecordDetail
                        {
                            BatchNumber = i.BatchNumber,
                            CheckqualifiedNumber = "0",
                            CurrentInventoryCount = i.CanSaleNum,
                            DictionaryDosageCode = i.DrugInfo.DictionaryDosageCode,
                            DrugInventoryRecordId = i.Id,
                            DictionarySpecificationCode = i.DrugInfo.DictionarySpecificationCode,
                            LicensePermissionNumber = i.DrugInfo.LicensePermissionNumber,
                            MaintainCount = 0,
                            Manufacturer = i.DrugInfo.FactoryName,
                            Origin = i.Decription,
                            OutValidDate = i.OutValidDate,
                            Price = i.PurchasePricce,
                            ProductName = i.DrugInfo.ProductGeneralName,
                            PruductDate = i.PruductDate,
                            Id = Guid.NewGuid(),
                            UserId = Guid.Empty,
                            BillDocumentNo = dmr.BillDocumentNo,
                            DictionaryMeasurementUnitCode = i.DrugInfo.DictionaryMeasurementUnitCode,
                            MaintainResult = string.Empty,
                            QualitySituation = "合格",
                            Deleted = false
                        };
                if (d.Count() > 0)
                {
                    businessHandlerFactory.DrugMaintainRecordBusinessHandler.Add(dmr);
                    businessHandlerFactory.BillDocumentCodeBusinessHandler.Add(billcode);
                    businessHandlerFactory.DrugMaintainRecordDetailBusinessHandler.AddMaintainDetails(d);
                }
                ListDI = null;     
                BusinessHandlerFactory.DisposeBusinessHandlerFactory(businessHandlerFactory);
                
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        /// <summary>
        /// 保健食品养护,品种类型值：5
        /// </summary>
        public static void CreateFoodMantainInst()
        {
            try
            {
                List<DrugMaintainRecord> ListM = businessHandlerFactory.DrugMaintainRecordBusinessHandler.Queryable.Where(r => r.CreateTime.Month == DateTime.Now.Month && r.CreateTime.Year == DateTime.Now.Year && r.DrugMaintainTypeValue == 2).ToList();
                if (ListM.Count > 0) return;

                DrugMaintainRecord dmr = new DrugMaintainRecord();
                var billcode = new BillDocumentCodeBusinessHandler(businessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.DrugMaintain);
                dmr.BillDocumentNo = billcode.Code;
                dmr.CompleteState = 0;
                dmr.CreateTime = DateTime.Now;
                dmr.CreateUserId = Guid.Empty;
                dmr.DrugMaintainTypeValue = 5;  //养护药品类型？
                dmr.ExpirationDate = DateTime.Now.AddMonths(1);
                dmr.Id = Guid.NewGuid();
                dmr.UpdateTime = DateTime.Now;
                dmr.UpdateUserId = Guid.Empty;

                DateTime dt = DateTime.Now.Date.AddDays(-DateTime.Now.Day + 1).AddMonths(6);

                IEnumerable<DrugInventoryRecord> ListDI = businessHandlerFactory.DrugInventoryRecordBusinessHandler.Queryable.Where(r => r.CanSaleNum > 0 && (r.DrugInfo.BusinessScopeCode.Contains("保健食品"))).OrderBy(r => r.DrugInfo.ProductGeneralName);

                var d = from i in ListDI
                        select new DrugMaintainRecordDetail
                        {
                            BatchNumber = i.BatchNumber,
                            CheckqualifiedNumber = "0",
                            CurrentInventoryCount = i.CanSaleNum,
                            DictionaryDosageCode = i.DrugInfo.DictionaryDosageCode,
                            DrugInventoryRecordId = i.Id,
                            DictionarySpecificationCode = i.DrugInfo.DictionarySpecificationCode,
                            LicensePermissionNumber = i.DrugInfo.LicensePermissionNumber,
                            MaintainCount = 0,
                            Manufacturer = i.DrugInfo.FactoryName,
                            Origin = i.Decription,
                            OutValidDate = i.OutValidDate,
                            Price = i.PurchasePricce,
                            ProductName = i.DrugInfo.ProductGeneralName,
                            PruductDate = i.PruductDate,
                            Id = Guid.NewGuid(),
                            UserId = Guid.Empty,
                            BillDocumentNo = dmr.BillDocumentNo,
                            DictionaryMeasurementUnitCode = i.DrugInfo.DictionaryMeasurementUnitCode,
                            MaintainResult = string.Empty,
                            QualitySituation = "合格",
                            Deleted = false
                        };
                if (d.Count() > 0)
                {
                    businessHandlerFactory.DrugMaintainRecordBusinessHandler.Add(dmr);
                    businessHandlerFactory.BillDocumentCodeBusinessHandler.Add(billcode);
                    businessHandlerFactory.DrugMaintainRecordDetailBusinessHandler.AddMaintainDetails(d);
                }
                ListDI = null;
                BusinessHandlerFactory.DisposeBusinessHandlerFactory(businessHandlerFactory);

            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        /// <summary>
        /// 中药饮片养护，品种类型值：3
        /// </summary>
        public static void CreateDrugMantainZYYP()
        {
            try
            {
                List<DrugMaintainRecord> ListM = businessHandlerFactory.DrugMaintainRecordBusinessHandler.Queryable.Where(r => r.CreateTime.Month == DateTime.Now.Month && r.CreateTime.Year == DateTime.Now.Year && r.DrugMaintainTypeValue == 3).ToList();
                if (ListM.Count > 0) return;

                DrugMaintainRecord dmr = new DrugMaintainRecord();
                var billcode = new BillDocumentCodeBusinessHandler(businessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.DrugMaintain);
                dmr.BillDocumentNo = billcode.Code;
                dmr.CompleteState = 0;
                dmr.CreateTime = DateTime.Now;
                dmr.CreateUserId = Guid.Empty;
                dmr.DrugMaintainTypeValue = 3;  //养护药品类型？
                dmr.ExpirationDate = DateTime.Now.AddMonths(1);
                dmr.Id = Guid.NewGuid();
                dmr.UpdateTime = DateTime.Now;
                dmr.UpdateUserId = Guid.Empty;
               
                DateTime dt = DateTime.Now.Date.AddDays(-DateTime.Now.Day + 1).AddMonths(6);

                IEnumerable<DrugInventoryRecord> ListDI = businessHandlerFactory.DrugInventoryRecordBusinessHandler.Queryable.Where(r => r.CanSaleNum > 0 && (r.DrugInfo.BusinessScopeCode.Contains("中药饮片"))).OrderBy(r => r.DrugInfo.ProductGeneralName);

                var d = from i in ListDI
                        select new DrugMaintainRecordDetail
                        {
                            BatchNumber = i.BatchNumber,
                            CheckqualifiedNumber = "0",
                            CurrentInventoryCount = i.CanSaleNum,
                            DictionaryDosageCode = i.DrugInfo.DictionaryDosageCode,
                            DrugInventoryRecordId = i.Id,
                            DictionarySpecificationCode = i.DrugInfo.DictionarySpecificationCode,
                            LicensePermissionNumber = i.DrugInfo.LicensePermissionNumber,
                            MaintainCount = 0,
                            Manufacturer = i.DrugInfo.FactoryName,
                            Origin = i.Decription,
                            OutValidDate = i.OutValidDate,
                            Price = i.PurchasePricce,
                            ProductName = i.DrugInfo.ProductGeneralName,
                            PruductDate = i.PruductDate,
                            Id = Guid.NewGuid(),
                            UserId = Guid.Empty,
                            BillDocumentNo = dmr.BillDocumentNo,
                            DictionaryMeasurementUnitCode = i.DrugInfo.DictionaryMeasurementUnitCode,
                            MaintainResult = string.Empty,
                            QualitySituation = "合格",
                            Deleted = false
                        };
                if (d.Count() > 0)
                {
                    businessHandlerFactory.DrugMaintainRecordBusinessHandler.Add(dmr);
                    businessHandlerFactory.BillDocumentCodeBusinessHandler.Add(billcode);
                    businessHandlerFactory.DrugMaintainRecordDetailBusinessHandler.AddMaintainDetails(d);
                }
                ListDI = null;
                BusinessHandlerFactory.DisposeBusinessHandlerFactory(businessHandlerFactory);
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        /// <summary>
        /// 中药材养护，品种类型值：4
        /// </summary>
        public static void CreateDrugMantainZYC()
        {
            try
            {
                List<DrugMaintainRecord> ListM = businessHandlerFactory.DrugMaintainRecordBusinessHandler.Queryable.Where(r => r.CreateTime.Month == DateTime.Now.Month && r.CreateTime.Year == DateTime.Now.Year && r.DrugMaintainTypeValue == 4).ToList();
                if (ListM.Count > 0) return;

                DrugMaintainRecord dmr = new DrugMaintainRecord();
                var billcode = new BillDocumentCodeBusinessHandler(businessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.DrugMaintain);
                dmr.BillDocumentNo = billcode.Code;
                dmr.CompleteState = 0;
                dmr.CreateTime = DateTime.Now;
                dmr.CreateUserId = Guid.Empty;
                dmr.DrugMaintainTypeValue = 4;  //养护药品类型？
                dmr.ExpirationDate = DateTime.Now.AddMonths(1);
                dmr.Id = Guid.NewGuid();
                dmr.UpdateTime = DateTime.Now;
                dmr.UpdateUserId = Guid.Empty;
                
                DateTime dt = DateTime.Now.Date.AddDays(-DateTime.Now.Day + 1).AddMonths(6);

                IEnumerable<DrugInventoryRecord> ListDI = businessHandlerFactory.DrugInventoryRecordBusinessHandler.Queryable.Where(r => r.CanSaleNum > 0 && (r.DrugInfo.BusinessScopeCode.Contains("中药材"))).OrderBy(r => r.DrugInfo.ProductGeneralName);

                var d = from i in ListDI
                        select new DrugMaintainRecordDetail
                        {
                            BatchNumber = i.BatchNumber,
                            CheckqualifiedNumber = "0",
                            CurrentInventoryCount = i.CanSaleNum,
                            DictionaryDosageCode = i.DrugInfo.DictionaryDosageCode,
                            DrugInventoryRecordId = i.Id,
                            DictionarySpecificationCode = i.DrugInfo.DictionarySpecificationCode,
                            LicensePermissionNumber = i.DrugInfo.LicensePermissionNumber,
                            MaintainCount = 0,
                            Manufacturer = i.DrugInfo.FactoryName,
                            Origin = i.Decription,
                            OutValidDate = i.OutValidDate,
                            Price = i.PurchasePricce,
                            ProductName = i.DrugInfo.ProductGeneralName,
                            PruductDate = i.PruductDate,
                            Id = Guid.NewGuid(),
                            UserId = Guid.Empty,
                            BillDocumentNo = dmr.BillDocumentNo,
                            DictionaryMeasurementUnitCode = i.DrugInfo.DictionaryMeasurementUnitCode,
                            MaintainResult = string.Empty,
                            QualitySituation = "合格",
                            Deleted = false
                        };
                if (d.Count() > 0)
                {
                    businessHandlerFactory.DrugMaintainRecordBusinessHandler.Add(dmr);
                    businessHandlerFactory.BillDocumentCodeBusinessHandler.Add(billcode);
                    businessHandlerFactory.DrugMaintainRecordDetailBusinessHandler.AddMaintainDetails(d);
                }
                ListDI = null;
                BusinessHandlerFactory.DisposeBusinessHandlerFactory(businessHandlerFactory);
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        /// <summary>
        /// 品种过期设置
        /// </summary>
        public static void SetDrugInventoryRecordOutValid()
        {
            DateTime dt=DateTime.Now.Date.AddMonths(1).AddDays(-DateTime.Now.Day+1);
            var c = from i in businessHandlerFactory.DrugInventoryRecordBusinessHandler.Queryable.Where(r => r.OutValidDate < dt && r.Valid)
                    join j in businessHandlerFactory.DrugInfoBusinessHandler.Queryable on i.DrugInfoId equals j.Id
                    where !(j.BusinessScopeCode.Contains("器械"))
                    select i;            

            if (c.Count() <= 0) return;
            c.ForEach(r =>
            {
                r.IsOutValidDate = true;
                r.Valid = false;
                businessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(r);
            });
            businessHandlerFactory.DrugInventoryRecordBusinessHandler.Save();
        }
    }
}
