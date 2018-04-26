using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class SalesOrderReturnDetailBusinessHandler
    {


        /// <summary>
        /// 获取销退明细列表
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public List<SalesOrderReturnDetail> getOrderReturnDetailListByOrderID(Guid orderID)
        {
           return this.Fetch(p => p.OrderReturnID == orderID).ToList();

        }


        /// <summary>
        /// 获取当前销退明细列表
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public List<SalesOrderReturnDetail> GetLastReturnDetailByReturnOrder(Guid orderID)
        {
            try
            {
                List<SalesOrderReturnDetail> listDetail = new List<SalesOrderReturnDetail>();
                var objReturn = BusinessHandlerFactory.SalesOrderReturnBusinessHandler.Fetch(p => p.SalesOrderID == orderID).OrderByDescending(o => o.CreateTime).FirstOrDefault();
                if (objReturn != null)
                    listDetail = objReturn.SalesOrderReturnDetails.ToList();

                return listDetail;
            }
            catch (Exception ex)
            {
                return this.HandleException<List<SalesOrderReturnDetail>>("获取当前销退明细列表失败", ex);
            }
        }

        /// <summary>
        /// 保存销退明细列表
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="detailList"></param>
        public void SaveOrderReturnDetailList(SalesOrder orderInfo, List<SalesOrderReturnDetail> detailList)
        {
            try
            {
                //SalesOrder _orderInfo = this.BusinessHandlerFactory.SalesOrderBusinessHandler.Get(orderInfo.Id);
                //_orderInfo.OrderBalanceCode = orderInfo.OrderBalanceCode;
                ////_orderInfo.* = orderInfo.*;
                orderInfo.OrderReturnTime = orderInfo.UpdateTime = DateTime.Now;
                orderInfo.OrderStatusValue = (int)OrderStatus.Returning;
                this.BusinessHandlerFactory.SalesOrderBusinessHandler.Save(orderInfo);

            foreach (var item in detailList)
            {

                item.CreateTime = DateTime.Now;
                item.UpdateTime = DateTime.Now;
                this.Add(item);
            }
            this.Save();

            }
            catch (Exception ex)
            {
                this.HandleException("保存销退明细列表失败", ex);
            }
     
        }
    }
}
