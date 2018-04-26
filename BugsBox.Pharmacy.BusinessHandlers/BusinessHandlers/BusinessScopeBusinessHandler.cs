using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using System.Data.Entity;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class BusinessScopeBusinessHandler
    {
        protected override IQueryable<BusinessScope> IncludeNavigationProperties(IQueryable<BusinessScope> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable
              .Include(bc => bc.BusinessScopeCategory)
              ); 
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<BusinessScope>>(ex.Message, ex);
            } 
          
        }
    }
}
