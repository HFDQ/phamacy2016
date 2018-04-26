using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Business.Models.QueryModelExtesion;
using BugsBox.Application.Core;
using System.Linq.Expressions;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class DoubtDrugBusinessHandler
    {
        protected override IQueryable<DoubtDrug> IncludeNavigationProperties(IQueryable<DoubtDrug> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable
              .Include(e => e.DrugInventoryRecord)
              .Include(e => e.DrugInventoryRecord.DrugInfo)
              .Include(e => e.DrugInventoryRecord.WarehouseZone)
              .Include(e => e.DrugInventoryRecord.WarehouseZone.Warehouse)
              );

            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<DoubtDrug>>(ex.Message, ex);
            }

        }

        /// <summary>
        /// 分页查询疑问记录为疑问管理
        /// </summary>
        /// <param name="drugInfoName"></param>
        /// <param name="batchNumber"></param>
        /// <param name="inInventoryDateRange"></param>
        /// <param name="productDateRange"></param>
        /// <param name="outDataRange"></param>
        /// <returns></returns>
        public List<DoubtDrug> QueryPagedDoubtDrugsForManage(string drugInfoName
            , string batchNumber
            , DateTimeRange inInventoryDateRange
            , DateTimeRange productDateRange
            , DateTimeRange outDataRange
            , int index, int size,
            out PagerInfo pager
            )
        {
            pager = PagerInfo.Validate(new PagerInfo { Index = index, Size = size });
            try
            {
                List<DoubtDrug> records = new List<DoubtDrug>();
                var queryBuilder = QueryBuilder.Create<DoubtDrug>();
                var query = this.Queryable; 
                //过滤 
                //药物名称
                if (!string.IsNullOrWhiteSpace(drugInfoName))
                {
                    query=query.Where(dd=>dd.DrugInventoryRecord.DrugInfo.ProductName.Contains(drugInfoName));
                }
                //生产批号
                if (!string.IsNullOrWhiteSpace(batchNumber))
                {
                    query = query.Where(dd => dd.DrugInventoryRecord.BatchNumber.Contains(batchNumber));
                }
                //入库日期 
                //生产日期
                if (productDateRange != null)
                {
                    if (productDateRange.Max != default(DateTime))
                    {
                        query = query.Where(dd => dd.DrugInventoryRecord.PruductDate <= productDateRange.Max);
                    }
                    if (productDateRange.Min != default(DateTime))
                    {
                        query = query.Where(dd => dd.DrugInventoryRecord.PruductDate >=productDateRange.Min);
                    }
                }
                //过期日期
                if (outDataRange != null)
                {
                    if (outDataRange.Max != default(DateTime))
                    {
                        query = query.Where(dd => dd.DrugInventoryRecord.OutValidDate <= outDataRange.Max);
                    }
                    if (outDataRange.Min != default(DateTime))
                    {
                        query = query.Where(dd => dd.DrugInventoryRecord.OutValidDate >= outDataRange.Min);
                    }
                }
                //以上To Do
                query = query.Where(PreparePredicate(dd=>true));//过滤一下
                pager.RecordCount = query.Count();  //处理总录条数
                //处理排序
                query = query
                    .OrderByDescending(dd => dd.CreateTime)
                    .OrderByDescending(dd => dd.UpdateTime)
                    .OrderBy(dd => dd.Handled); 
                records = query
                    .Skip((pager.Index - 1) * pager.Size)
                    .Take(pager.Size)
                    .ToList();
                return records; 
            }
            catch (Exception ex)
            {
                return this.HandleException<List<DoubtDrug>>("分页查询疑问记录为疑问管理失败", ex);
            }
        }

        /// <summary>
        /// 查询需要处理的疑问药品数
        /// </summary>
        /// <returns></returns>
        public int GetNeedHandledDoubtDrug()
        {
            try
            {
                return this.Count(p => !p.Handled);
            }
            catch (Exception ex)
            {
                return this.HandleException<int>("查询需要处理的疑问药品数失败", ex);
            }
        }

    }
}
