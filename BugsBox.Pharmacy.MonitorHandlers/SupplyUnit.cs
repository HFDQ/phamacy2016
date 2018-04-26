using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Common;
using BugsBox.Pharmacy.Repository;

namespace BugsBox.Pharmacy.MonitorHandlers
{
    /// <summary>
    /// 供应商监控
    /// </summary>
    public class SupplyUnit
    {
        static BusinessHandlerFactory businessHandlerFactory = new BusinessHandlerFactory(new Db(), null);

        /// <summary>
        /// 更新状态
        /// </summary>
        public static void UpdateValid()
        {
            try
            {
                SupplyUnitBusinessHandler suHandler = businessHandlerFactory.SupplyUnitBusinessHandler;

                foreach (BugsBox.Pharmacy.Models.SupplyUnit su in suHandler.Queryable)
                {
                    su.Valid = false;
                    suHandler.Save(su);
                }
                suHandler.Save();
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        /// <summary>
        /// 失效的数量
        /// </summary>
        /// <returns></returns>
        public static int NotValid()
        {
            try
            {
                SupplyUnitBusinessHandler suHandler = businessHandlerFactory.SupplyUnitBusinessHandler;
                
                return suHandler.Count(p => !p.Valid && p.Enabled);
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
                return -1;
            }
        }

        public static int LockCount()
        {
            SupplyUnitBusinessHandler handler = businessHandlerFactory.SupplyUnitBusinessHandler;
            return handler.GetLockSupplyUnitCount();
        }
    }
}
