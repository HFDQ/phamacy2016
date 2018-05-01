using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data.Entity;
using BugsBox.Application.Core;
using BugsBox.Common;
using BugsBox.Common.Config;

namespace BugsBox.Pharmacy.Repository
{
    /// <summary>
    /// 数据仓储上下文
    /// </summary>
    public partial class Db : DbContext, IQueryableUnitOfWork
    {
        private ILogger Log = LoggerHelper.Instance;

        public Db()
            : base("Db")
        {
            //Log.Information("Db 创建了...Ioc");
            //启动延时加载模式
            Configuration.LazyLoadingEnabled = true;
            //Log.Warning("LazyLoadingEnabled(延时加载模式)" + Configuration.LazyLoadingEnabled.ToString());
            //启动代理创建模式
            Configuration.ProxyCreationEnabled = false;
            //Log.Warning("ProxyCreationEnabled(代理创建模式)" + Configuration.ProxyCreationEnabled.ToString());
        }

        public static bool InitDatabase()
        {
            try
            {
                if (AppConfig.Config.AutoCreateAndInitDatabase)
                {
                    LoggerHelper.Instance.Information("BEGIND INIT CREATEANDINITDATABASE");
                    Database.SetInitializer<Db>(new DropCreateDatabaseIfModelChanges<Db>());
                    Database.SetInitializer(new DefaultDbInitializer());
                    LoggerHelper.Instance.Information("END INIT CREATEANDINITDATABASE");

                    new Db().Departments.Count();
                    AppConfig.Config.InitDateTime = DateTime.Now;
                    AppConfig.Config.AutoCreateAndInitDatabase = false;
                    ConfigHelper<AppConfig>.SaveConfig();

                }
                return true;
            }
            catch (Exception ex)
            {
                ex = new Exception("数据库初始化失败!", ex);
                LoggerHelper.Instance.Error(ex);
                return false;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//移除复数表名的契约  
            //modelBuilder.Configurations.Add(new GMSPLicenseMap());
            //modelBuilder.Configurations.Add(new InInventoryRecordMap()); 
            var properties = new[]
            {
                modelBuilder.Entity<Models.SalesOrder>().Property(so => so.TotalMoney),
                modelBuilder.Entity<Models.SalesOrderDetail>().Property(sod => sod.Price),
                modelBuilder.Entity<Models.SalesOrderDetail>().Property(sod => sod.ActualUnitPrice),
                modelBuilder.Entity<Models.SalesOrderDetail>().Property(sod => sod.UnitPrice),
                modelBuilder.Entity<Models.SalesOrderReturnDetail>().Property(sord=>sord.ActualUnitPrice),
                modelBuilder.Entity<Models.SalesOrderReturnDetail>().Property(sord=>sord.Price),
                modelBuilder.Entity<Models.SalesOrderReturnDetail>().Property(sord=>sord.UnitPrice),
                modelBuilder.Entity<Models.PurchaseOrder>().Property(p => p.AmountOfTaxMoney),
                modelBuilder.Entity<Models.PurchaseOrder>().Property(p => p.TotalMoney),
                modelBuilder.Entity<Models.PurchaseOrderDetail>().Property(p=>p.AmountOfTax),
                modelBuilder.Entity<Models.PurchaseOrderDetail>().Property(p=>p.PurchasePrice),
                modelBuilder.Entity<Models.PurchaseReceivingOrderDetail>().Property(p => p.PurchasePrice),
                modelBuilder.Entity<Models.PurchaseCheckingOrderDetail>().Property(p => p.PurchasePrice),
                modelBuilder.Entity<Models.PurchaseInInventeryOrderDetail>().Property(p => p.PurchasePrice),
                modelBuilder.Entity<Models.PurchaseOrderReturnDetail>().Property(p => p.PurchasePrice),
                modelBuilder.Entity<Models.PurchasingPlan>().Property(p => p.AmountOfTaxMoney),
                modelBuilder.Entity<Models.PurchasingPlan>().Property(p => p.TotalMoney),
                modelBuilder.Entity<Models.OutInventory>().Property(p => p.TotalMoney),
                modelBuilder.Entity<Models.OutInventory>().Property(p => p.TotalTax),
                modelBuilder.Entity<Models.OutInventoryDetail>().Property(p => p.ActualUnitPrice),
                modelBuilder.Entity<Models.OutInventoryDetail>().Property(p => p.Price),
                modelBuilder.Entity<Models.OutInventoryDetail>().Property(p => p.UnitPrice),
                modelBuilder.Entity<Models.DrugsUnqualificationDestroy>().Property(p => p.price),

                modelBuilder.Entity<Models.DrugsUndeterminate>().Property(p => p.PurchasePrice),
                modelBuilder.Entity<Models.DrugMaintainRecordDetail>().Property(p => p.Price),
                modelBuilder.Entity<Models.DrugInventoryRecord>().Property(p => p.PurchasePricce),
                modelBuilder.Entity<Models.DrugInfo>().Property(p => p.LimitedLowPrice),
                modelBuilder.Entity<Models.DrugInfo>().Property(p => p.LimitedUpPrice),
                modelBuilder.Entity<Models.DrugInfo>().Property(p => p.LowSalePrice),
                modelBuilder.Entity<Models.DrugInfo>().Property(p => p.NationalSalePrice),
                modelBuilder.Entity<Models.DrugInfo>().Property(p => p.Price),
                modelBuilder.Entity<Models.DrugInfo>().Property(p => p.RetailPrice),
                modelBuilder.Entity<Models.DrugInfo>().Property(p => p.SalePrice),
                modelBuilder.Entity<Models.DrugInfo>().Property(p => p.TagPrice),
                modelBuilder.Entity<Models.DrugInfo>().Property(p => p.WholeSalePrice),
                modelBuilder.Entity<Models.DirectSalesOrderDetail>().Property(p=>p.DirectSaleDiff),
                modelBuilder.Entity<Models.DirectSalesOrderDetail>().Property(p=>p.SupplyPrice),
                modelBuilder.Entity<Models.DirectSalesOrderDetail>().Property(p=>p.SalePrice)
        };

            modelBuilder.Entity<Models.DrugInfo>().HasOptional(s => s.GoodsAdditionalProperty).WithRequired(ad => ad.DrugInfo);
            modelBuilder.Entity<Models.GoodsAdditionalProperty>().HasKey(o => o.DrugInfoId);


            properties.ToList().ForEach(property =>
            {
                property.HasPrecision(18, 4);
            });

            var NumQuantityProperties = new[]
            {
                modelBuilder.Entity<Models.DrugInventoryRecord>().Property(so => so.CanSaleNum),
                modelBuilder.Entity<Models.DrugInventoryRecord>().Property(so => so.CurrentInventoryCount),
                modelBuilder.Entity<Models.DrugInventoryRecord>().Property(so => so.DismantingAmount),
                modelBuilder.Entity<Models.DrugInventoryRecord>().Property(so => so.drugsUnqualicationNum),
                modelBuilder.Entity<Models.DrugInventoryRecord>().Property(so => so.InInventoryCount),
                modelBuilder.Entity<Models.DrugInventoryRecord>().Property(so => so.OnRetailCount),
                modelBuilder.Entity<Models.DrugInventoryRecord>().Property(so => so.OnSalesOrderCount),
                modelBuilder.Entity<Models.DrugInventoryRecord>().Property(so => so.PurchaseReturnNumber),
                modelBuilder.Entity<Models.DrugInventoryRecord>().Property(so => so.RetailCount),
                modelBuilder.Entity<Models.DrugInventoryRecord>().Property(so => so.RetailDismantingAmount),
                modelBuilder.Entity<Models.DrugInventoryRecord>().Property(so => so.SalesCount),
                modelBuilder.Entity<Models.DrugMaintainRecordDetail>().Property(so => so.CurrentInventoryCount),
                modelBuilder.Entity<Models.DrugMaintainRecordDetail>().Property(so => so.MaintainCount),
                modelBuilder.Entity<Models.DrugsBreakage>().Property(so => so.quantity),
                modelBuilder.Entity<Models.DrugsInventoryMove>().Property(so => so.quantity),
                modelBuilder.Entity<Models.DrugsUndeterminate>().Property(so => so.QualificationQuantity),
                modelBuilder.Entity<Models.DrugsUndeterminate>().Property(so => so.quantity),
                modelBuilder.Entity<Models.DrugsUnqualication>().Property(so => so.quantity),
                modelBuilder.Entity<Models.DrugsUnqualificationQuery>().Property(so => so.CurrentInventoryCount),
                modelBuilder.Entity<Models.DrugsUnqualificationQuery>().Property(so => so.quantity),
                modelBuilder.Entity<Models.InventoryRecord>().Property(so => so.DismantingAmount),
                modelBuilder.Entity<Models.InventoryRecord>().Property(so => so.MaxInventoryCount),
                modelBuilder.Entity<Models.InventoryRecord>().Property(so => so.MinInventoryCount),
                modelBuilder.Entity<Models.InventoryRecord>().Property(so => so.OnRetailCount),
                modelBuilder.Entity<Models.InventoryRecord>().Property(so => so.OnSalesOrderCount),
                modelBuilder.Entity<Models.InventoryRecord>().Property(so => so.RetailCount),
                modelBuilder.Entity<Models.InventoryRecord>().Property(so => so.RetailDismantingAmount),
                modelBuilder.Entity<Models.InventoryRecord>().Property(so => so.SalesCount),
                modelBuilder.Entity<Models.OutInventoryDetail>().Property(so => so.Amount),
                modelBuilder.Entity<Models.OutInventoryDetail>().Property(so => so.CanSaleNum),
                modelBuilder.Entity<Models.InventoryRecord>().Property(so => so.SalesCount),
                modelBuilder.Entity<Models.PurchaseCheckingOrderDetail>().Property(so => so.QualifiedAmount),
                modelBuilder.Entity<Models.PurchaseCheckingOrderDetail>().Property(so => so.ReceivedAmount),
                modelBuilder.Entity<Models.PurchaseCheckingOrderDetail>().Property(so => so.UnQualifiedAmount),
                modelBuilder.Entity<Models.PurchaseInInventeryOrderDetail>().Property(so => so.ArrivalAmount),
                modelBuilder.Entity<Models.PurchaseOrderDetail>().Property(so => so.Amount),
                modelBuilder.Entity<Models.PurchaseOrderReturnDetail>().Property(so => so.ReissueAmount),
                modelBuilder.Entity<Models.PurchaseReceivingOrderDetail>().Property(so => so.ActualAmount),
                modelBuilder.Entity<Models.PurchaseReceivingOrderDetail>().Property(so => so.Amount),
                modelBuilder.Entity<Models.PurchaseReceivingOrderDetail>().Property(so => so.ReceiveAmount),
                modelBuilder.Entity<Models.PurchaseReceivingOrderDetail>().Property(so => so.RejectAmount),
                modelBuilder.Entity<Models.SalesOrderDetail>().Property(so => so.Amount),
                modelBuilder.Entity<Models.SalesOrderDetail>().Property(so => so.ChangeAmount),
                modelBuilder.Entity<Models.SalesOrderDetail>().Property(so => so.OutAmount),
                modelBuilder.Entity<Models.SalesOrderDetail>().Property(so => so.ReturnAmount),
                modelBuilder.Entity<Models.SalesOrderReturnDetail>().Property(so => so.CanInAmount),
                modelBuilder.Entity<Models.SalesOrderReturnDetail>().Property(so => so.CannotInAmount),
                modelBuilder.Entity<Models.SalesOrderReturnDetail>().Property(so => so.OrderAmount),
                modelBuilder.Entity<Models.SalesOrderReturnDetail>().Property(so => so.ReissueAmount),
                modelBuilder.Entity<Models.SalesOrderReturnDetail>().Property(so => so.ReturnAmount),
                modelBuilder.Entity<Models.RetailOrderDetail>().Property(so => so.Amount),
                modelBuilder.Entity<Models.RetailOrderDetail>().Property(so => so.Discount),
                modelBuilder.Entity<Models.RetailOrderDetail>().Property(so => so.DismantingAmount),
                modelBuilder.Entity<Models.RetailOrderDetail>().Property(so => so.ReturnAmount),
                modelBuilder.Entity<Models.DirectSalesOrderDetail>().Property(p=>p.UnQualityAmount),
                modelBuilder.Entity<Models.DirectSalesOrderDetail>().Property(p=>p.QualityAmount),
                modelBuilder.Entity<Models.DirectSalesOrderDetail>().Property(p=>p.Amount),
            };

            NumQuantityProperties.ToList().ForEach(r => r.HasPrecision(14, 4));

            base.OnModelCreating(modelBuilder);
        }

        public IQueryable<TEntity> CreateQueryable<TEntity>() where TEntity : class, IEntity, new()
        {
            return this.Set<TEntity>();
        }

        public void Attach<TEntity>(TEntity item) where TEntity : class, IEntity, new()
        {
            //attach and set as unchanged
            base.Entry<TEntity>(item).State = EntityState.Unchanged;
        }

        public void SetModified<TEntity>(TEntity item) where TEntity : class, IEntity, new()
        {
            //this operation also attach item in object state manager
            base.Entry<TEntity>(item).State = EntityState.Modified;
        }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class, IEntity, new()
        {
            //if it is not attached, attach original and set current values
            base.Entry<TEntity>(original).CurrentValues.SetValues(current);
        }

        public void Commit()
        {
            string error = string.Empty;
            try
            {
                base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                RollbackChanges();
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        var err = string.Format("实体[{0}]字段: {1} 错误: {2}", validationErrors.Entry.Entity.GetType().Name, validationError.PropertyName,
                                               validationError.ErrorMessage);
                        Log.Error(err);
                        error += err;
                    }
                }
                Exception iex = new Exception(error, dbEx);
                Log.Error(iex);
                throw iex;
            }
            catch (Exception ex)
            {
                ex = new Exception("向数据库提交失败", ex);
                Log.Error(ex);
                throw ex;
            }
        }

        public void CommitAndRefreshChanges()
        {
            DbUpdateConcurrencyException oex = null;
            bool saveFailed = false;
            do
            {
                try
                {
                    base.SaveChanges();
                    saveFailed = false;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    oex = ex;
                    saveFailed = true;

                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });

                }
            } while (saveFailed);
            if (oex != null)
                throw oex;
        }

        public void RollbackChanges()
        {
            // set all entities in change tracker 
            // as 'unchanged state'
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters) where TEntity : class, IEntity, new()
        {
            return base.Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            try
            {
                return base.Database.ExecuteSqlCommand(sqlCommand, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
