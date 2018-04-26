using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;
namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class PurchaseManageCategoryBusinessHandler
    {
        protected override IQueryable<Models.PurchaseManageCategory> IncludeNavigationProperties(IQueryable<Models.PurchaseManageCategory> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable
    .Include(t => t.PurchaseManageCategoryDetails)
    );
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<PurchaseManageCategory>>(ex.Message, ex);
            } 

        }
    }
}
