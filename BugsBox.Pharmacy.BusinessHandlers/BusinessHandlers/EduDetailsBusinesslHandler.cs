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

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class EduDetailsBusinessHandler
    {
        protected override IQueryable<EduDetails> IncludeNavigationProperties(IQueryable<EduDetails> queryable)
        {

            try
            {
                return base.IncludeNavigationProperties(queryable);
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<EduDetails>>(ex.Message, ex);
            }
        }

        public List<EduDetails> SearchPagedEduDetailsByAllStrings(string keys, int index, int size, out PagerInfo pager)
        {
            pager = PagerInfo.Validate(new PagerInfo { Index = index, Size = size });
            try
            {
                List<EduDetails> records = new List<EduDetails>();
                var queryBuilder = QueryBuilder.Create<EduDetails>();
                Expression<Func<EduDetails, bool>> expression = dir => true;
                //处理排序
                var query = this.Queryable;
                query = query.Where(PreparePredicate(queryBuilder.Expression));//过滤一下 
                if (!string.IsNullOrWhiteSpace(keys))
                {
                    query = query.Where(d => false
                         || (d.Employee.Name != null && d.Employee.Name.Contains(keys))
                        );
                }
                pager.RecordCount = query.Count();  //处理总录条数
                query = query.OrderBy(d => d.Employee.Name);
                records = query
                    .Skip((pager.Index - 1) * pager.Size)
                    .Take(pager.Size)
                    .ToList();
                return records;

            }
            catch (Exception ex)
            {
                return this.HandleException<List<EduDetails>>("根据字符串查询基础信息失败", ex);
            }
        }
    }
}
