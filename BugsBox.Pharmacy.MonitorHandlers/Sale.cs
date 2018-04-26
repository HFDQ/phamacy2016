using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Repository;

namespace BugsBox.Pharmacy.MonitorHandlers
{
    /// <summary>
    /// 销售方面监控
    /// </summary>
    public class Sale
    {
        static BusinessHandlerFactory businessHandlerFactory = new BusinessHandlerFactory(new Db(), null);

        /// <summary>
        /// 需要审核的销售单数量
        /// </summary>
        /// <returns></returns>
        public static int GetNeedCheckOrder()
        {
            SalesOrderBusinessHandler suHandler = businessHandlerFactory.SalesOrderBusinessHandler;
            int value = (int)OrderStatus.Waitting;
            return suHandler.Count(p => p.OrderStatusValue == value);
        }

        /// <summary>
        /// 需要拣货的销售单数量
        /// </summary>
        /// <returns></returns>
        public static int GetNeedTake()
        {
            SalesOrderBusinessHandler suHandler = businessHandlerFactory.SalesOrderBusinessHandler;
            int value = (int)OrderStatus.Banlaced;
            return suHandler.Count(p => p.OrderStatusValue == value);
        }

        
        /// <summary>
        /// 需要出库审核的数量
        /// </summary>
        /// <returns></returns>
        public static int GetNeedCheckChuKu()
        {
            OutInventoryBusinessHandler suHandler = businessHandlerFactory.OutInventoryBusinessHandler;
            int value = (int)OutInventoryStatus.Outing;
            return suHandler.Count(p => p.OutInventoryStatusValue == value);
        }


        /// <summary>
        /// 需要配送的数量
        /// </summary>
        /// <returns></returns>
        public static int GetNeedPeiSong()
        {
            DeliveryBusinessHandler suHandler = businessHandlerFactory.DeliveryBusinessHandler;
            int value = (int)DeliveryStatus.Reservation;
            return suHandler.Count(p => p.DeliveryStatusValue == value);
        }

        /// <summary>
        /// 需要销退销售员审核的数量
        /// </summary>
        /// <returns></returns>
        public static int GetNeed_XT_XSY_Check()
        {
            PurchaseOrderReturnBusinessHandler suHandler = businessHandlerFactory.PurchaseOrderReturnBusinessHandler;
            int value = (int)OrderReturnStatus.Waitting;
            return suHandler.Count(p => p.OrderStatusValue == value);
        }


        /// <summary>
        /// 需要销退营业部审核的数量
        /// </summary>
        /// <returns></returns>
        public static int GetNeed_XT_YYB_Check()
        {
            PurchaseOrderReturnBusinessHandler suHandler = businessHandlerFactory.PurchaseOrderReturnBusinessHandler;
            int value = (int)OrderReturnStatus.SellerApproved;
            return suHandler.Count(p => p.OrderStatusValue == value);
        }

        /// <summary>
        /// 需要销退质管部审核的数量
        /// </summary>
        /// <returns></returns>
        public static int GetNeed_XT_ZGB_Check()
        {
            PurchaseOrderReturnBusinessHandler suHandler = businessHandlerFactory.PurchaseOrderReturnBusinessHandler;
            int value = (int)OrderReturnStatus.TradeApproved;
            return suHandler.Count(p => p.OrderStatusValue == value);
        }
    }
}
