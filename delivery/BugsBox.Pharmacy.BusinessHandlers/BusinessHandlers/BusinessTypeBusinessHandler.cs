using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class BusinessTypeBusinessHandler
    {
        protected override IQueryable<BusinessType> IncludeNavigationProperties(IQueryable<BusinessType> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable
              .Include(bt => bt.BusinessTypeManageCategoryDetails)
                    //.Include(bt=>bt.GMSPLicenses)
              .Include(bt => bt.GSPLicenses)
              );
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<BusinessType>>(ex.Message, ex);
            } 
          
        }
    }
}
