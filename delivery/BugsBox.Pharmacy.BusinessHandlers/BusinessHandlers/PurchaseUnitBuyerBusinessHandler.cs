using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class PurchaseUnitBuyerBusinessHandler
    {
        protected override IQueryable<PurchaseUnitBuyer> IncludeNavigationProperties(IQueryable<PurchaseUnitBuyer> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable
               .Include(u => u.PurchaseUnit)
               );
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<PurchaseUnitBuyer>>(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取客户单位提货人
        /// </summary>
        /// <param name="PId"></param>
        /// <returns></returns>
        public IEnumerable<PurchaseUnitBuyer> GetPurchaseUnitBuyersByPurchaseUnitId(Guid PId)
        {
            var c = RepositoryProvider.Db.PurchaseUnitBuyers.Where(r => r.Deleted == false && r.PurchaseUnitId == PId);
                  
                  return c;
        }

    }
}
