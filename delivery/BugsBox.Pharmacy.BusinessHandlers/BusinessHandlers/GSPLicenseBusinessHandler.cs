using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class GSPLicenseBusinessHandler
    {
        protected override System.Linq.IQueryable<BugsBox.Pharmacy.Models.GSPLicense> IncludeNavigationProperties(System.Linq.IQueryable<BugsBox.Pharmacy.Models.GSPLicense> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable
               .Include(l => l.GMSPLicenseBusinessScopes)
               );
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<GSPLicense>>(ex.Message, ex);
            } 
           
        }
    }
}
