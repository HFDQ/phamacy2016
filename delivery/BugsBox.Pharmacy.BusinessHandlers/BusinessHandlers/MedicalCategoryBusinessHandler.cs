using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;
namespace BugsBox.Pharmacy.BusinessHandlers
{
     partial class MedicalCategoryBusinessHandler
    {
         protected override IQueryable<Models.MedicalCategory> IncludeNavigationProperties(IQueryable<Models.MedicalCategory> queryable)
         {
             try
             {
                 return base.IncludeNavigationProperties(queryable
                  .Include(t => t.MedicalCategories)
                  );
             }
             catch (Exception ex)
             {
                 ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                 return HandleException<IQueryable<MedicalCategory>>(ex.Message, ex);
             } 
              
         }
    }
}
