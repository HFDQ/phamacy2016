using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Common;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Pharmacy.Repository;

namespace BugsBox.Pharmacy.MonitorHandlers
{
    /// <summary>
    /// 药品监控
    /// </summary>
    public class Drug
    {
        static BusinessHandlerFactory businessHandlerFactory = new BusinessHandlerFactory(new Db(), null);

        /// <summary>
        /// 更新状态
        /// </summary>
        public static void UpdateValid()
        {
            //try
            //{

            //    DrugInfoBusinessHandler handler = businessHandlerFactory.DrugInfoBusinessHandler;

            //    foreach (BugsBox.Pharmacy.Models.DrugInfo item in handler.Queryable)
            //    {
            //        item.Valid = false;
            //        handler.Save(item);
            //    }
            //    handler.Save();
            //}
            //catch (Exception ex)
            //{
            //    LoggerHelper.Instance.Error(ex);
            //}
        }


        /// <summary>
        /// 更新过期状态
        /// </summary>
        public static void UpdateOutValidDate()
        {
            try
            {
                DrugInventoryRecordBusinessHandler handler = businessHandlerFactory.DrugInventoryRecordBusinessHandler;

                foreach (BugsBox.Pharmacy.Models.DrugInventoryRecord item in handler.Queryable)
                {
                    item.IsOutValidDate = false;
                    handler.Save(item);
                }
                handler.Save();
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        /// <summary>
        /// 失效的数量(某种药)
        /// </summary>
        /// <returns></returns>
        public static int NotValid()
        {
            try
            {
                DrugInfoBusinessHandler handler = businessHandlerFactory.DrugInfoBusinessHandler;
                return handler.Count(p => !p.Valid && p.Enabled);
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
                return -1;
            }
        }

        /// <summary>
        /// 批次过期数
        /// </summary>
        /// <returns></returns>
        public static int OutValidDate()
        {
            try
            {
                DrugInventoryRecordBusinessHandler handler = businessHandlerFactory.DrugInventoryRecordBusinessHandler;

                return handler.Count(p => p.IsOutValidDate);
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
                return -1;
            }
        }

        public static int LockCount()
        {
            DrugInfoBusinessHandler handler = businessHandlerFactory.DrugInfoBusinessHandler;
            return handler.GetLockDrugInfoCount();
        }

        public static int GetNeedHandledDoubtDrug()
        {
            DoubtDrugBusinessHandler hander = businessHandlerFactory.DoubtDrugBusinessHandler;
            return hander.GetNeedHandledDoubtDrug();
        }

        /// <summary>
        /// 缺货药品数
        /// </summary>
        /// <returns></returns>
        public static int GetDrugInfoForOutofStockNumber()
        {
            DrugInfoBusinessHandler hander = businessHandlerFactory.DrugInfoBusinessHandler;
            return hander.GetDrugInfoForOutofStock().Count();
        }
    }
}
