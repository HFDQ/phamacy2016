using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Business.Models;
using System.Linq.Expressions;
using BugsBox.Pharmacy.Repository;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class DrugMaintainSetBusinessHandler
    {
        protected override IQueryable<DrugMaintainSet> IncludeNavigationProperties(IQueryable<DrugMaintainSet> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable);
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<DrugMaintainSet>>(ex.Message, ex);
            } 
         
        }

        /// <summary>
        /// 获取实体药品养护设置信息
        /// </summary>
        /// <param name="DrugMaintenanceTypeValue"></param>
        /// <param name="message"></param>
        /// <returns></returns> 
        public DrugMaintainSet GetDrugMaintainSetByDrugMaintainTypeValue(int DrugMaintainTypeValue)
        {
            try
            {
                return this.Fetch(r => r.DrugMaintainTypeValue == DrugMaintainTypeValue).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return this.HandleException<DrugMaintainSet>("获取实体药品养护设置信息失败", ex);
            }
        }


        ///// <summary>
        ///// 添加药品养护设置信息
        ///// </summary>
        ///// <param name="value"></param>
        ///// <param name="msg"></param>
        ///// <returns></returns>
        //public bool AddDrugWaringSet(DrugWaringSet value, out string msg)
        //{
        //    try
        //    {
        //        return HandlerFactory.DrugWaringSetBusinessHandler.Add(value, out msg);
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = "调用药品养护设置信息业务逻辑:添加实体(药品养护设置信息)失败";
        //        return this.HandleException<bool>(msg, ex);
        //    }
        //}




        ///// <summary>
        ///// 保存药品养护设置信息
        ///// </summary>
        ///// <param name="value"></param>
        ///// <param name="msg"></param>
        ///// <returns></returns>
        //public bool SaveDrugWaringSet(DrugWaringSet value, out string msg)
        //{
        //    try
        //    {
        //        return HandlerFactory.DrugWaringSetBusinessHandler.Save(value, out msg);
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = "调用药品养护设置信息业务逻辑:保存实体(药品养护设置信息)失败";
        //        return this.HandleException<bool>(msg, ex);
        //    }
        //}

    }
}
