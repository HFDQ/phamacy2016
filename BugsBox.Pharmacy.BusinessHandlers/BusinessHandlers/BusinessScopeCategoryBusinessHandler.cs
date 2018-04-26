using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using System.Data.Entity;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class BusinessScopeCategoryBusinessHandler
    {
        protected override IQueryable<BusinessScopeCategory> IncludeNavigationProperties(IQueryable<BusinessScopeCategory> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable.Include(bcc => bcc.BusinessScopes)); 
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<BusinessScopeCategory>>(ex.Message, ex);
            } 
          
        }
    }
}
