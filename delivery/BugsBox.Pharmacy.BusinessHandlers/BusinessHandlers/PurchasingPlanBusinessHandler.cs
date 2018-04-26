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
using BugsBox.Pharmacy.Config;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class PurchasingPlanBusinessHandler
    {
        protected override IQueryable<PurchasingPlan> IncludeNavigationProperties(IQueryable<PurchasingPlan> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(this.Queryable.Include(r => r.SupplyUnit));
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<PurchasingPlan>>(ex.Message, ex);
            }
        }

        public bool SubmitRefunds(PurchasingPlan[] pps,int flag)
        {
            try
            {
                switch(flag)
                {
                    case 0:
                        foreach (var c in pps)
                        {
                            c.CreateTime = DateTime.Now;
                            c.UpdateTime = DateTime.Now;
                            c.StoreId = PharmacyServiceConfig.Config.CurrentStore.Id;
                            c.DocumentNumber = new BillDocumentCodeBusinessHandler(BusinessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.PurchaseRefund).Code;
                            this.Add(c);
                        }
                        break;
                    case 1:
                        foreach (var c in pps)
                        {
                            c.UpdateTime = DateTime.Now;
                            this.Save(c);
                        }
                        break;
                    case 2:
                        foreach (var c in pps)
                        {
                            this.Delete(c.Id);
                        }
                        break;
                }

                this.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                this.Dispose();
            }
        }

        public IEnumerable<PurchasingPlan> GetPurchaseRefunds(object[] objs)
        {
            try
            {
                var all = this.Queryable;
                if (objs[0] != null)
                {
                    Guid id = Guid.Parse(objs[0].ToString());
                    all = all.Where(r => r.ReleatedPurchaseOrderId == id);
                }
                if (objs[1] != null)
                {
                    DateTime dtF = Convert.ToDateTime((objs[1]));
                    dtF = dtF.AddHours(-dtF.Hour);
                    dtF = dtF.AddMinutes(-dtF.Minute);
                    DateTime dtT = Convert.ToDateTime((objs[2]));
                    dtT = dtT.AddDays(1);
                    dtT = dtT.AddHours(-dtT.Hour);
                    dtT = dtT.AddMinutes(-dtT.Minute);
                    all = all.Where(r => r.CreateTime >= dtF && r.CreateTime <= dtT);
                }

                return all;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this.Dispose();
            }
        }

    }
}
