using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Repository;

namespace BugsBox.Pharmacy.MonitorHandlers
{
    public class Purchase
    {
        static BusinessHandlerFactory businessHandlerFactory = new BusinessHandlerFactory(new Db(), null);

        /// <summary>
        /// 采购单审核
        /// </summary>
        /// <returns></returns>
        public static int 采购单审核()
        {
            PurchaseOrderBusinessHandler suHandler = businessHandlerFactory.PurchaseOrderBusinessHandler;
            int value = (int)OrderStatus.Waitting;
            return suHandler.Count(p => p.OrderStatusValue == value);
        }

        /// <summary>
        /// 收货
        /// </summary>
        /// <returns></returns>
        public static int 收货()
        {

            PurchaseOrderBusinessHandler suHandler = businessHandlerFactory.PurchaseOrderBusinessHandler;
            int value = (int)OrderStatus.Approved;
            DateTime nowday = DateTime.Now.Date;
            return suHandler.Count(p => p.OrderStatusValue == value && p.AllReceiptedDate.HasValue && p.AllReceiptedDate > nowday);
        }

        /// <summary>
        /// 收货验收
        /// </summary>
        /// <returns></returns>
        public static int 收货验收()
        {

            PurchaseReceivingOrderBusinessHandler suHandler = businessHandlerFactory.PurchaseReceivingOrderBusinessHandler;
            int value = (int)OrderStatus.PurchaseReceiving;
            return suHandler.Count(p => p.OrderStatusValue == value);
        }

        public static int 入库提醒()
        {

            PurchaseCheckingOrderBusinessHandler suHandler = businessHandlerFactory.PurchaseCheckingOrderBusinessHandler;
            int value = (int)OrderStatus.PurchaseCheck;
            return suHandler.Count(p => p.OrderStatusValue == value);
        }

        public static int 采购退货质管部审核()
        {

            PurchaseOrderReturnBusinessHandler suHandler = businessHandlerFactory.PurchaseOrderReturnBusinessHandler;
            int value = (int)OrderReturnStatus.Waitting;
            return suHandler.Count(p => p.OrderStatusValue == value);
        }

        public static int 采购退货总经理审核()
        {

            PurchaseOrderReturnBusinessHandler suHandler = businessHandlerFactory.PurchaseOrderReturnBusinessHandler;
            int value = (int)OrderReturnStatus.QualityApproved;
            return suHandler.Count(p => p.OrderStatusValue == value);
        }

        public static int 采购退货财务部审核()
        {

            PurchaseOrderReturnBusinessHandler suHandler = businessHandlerFactory.PurchaseOrderReturnBusinessHandler;
            int value = (int)OrderReturnStatus.GeneralManagerApproved;
            return suHandler.Count(p => p.OrderStatusValue == value);
        }

        public static int 采购到货数不够()
        {
            
                PurchaseOrderBusinessHandler suHandler = businessHandlerFactory.PurchaseOrderBusinessHandler;
                int value = (int)OrderStatus.PurchaseApplyReceinvingAmountDiff;
                return suHandler.Count(p => p.OrderStatusValue == value);
           

           
        }
    }
}
