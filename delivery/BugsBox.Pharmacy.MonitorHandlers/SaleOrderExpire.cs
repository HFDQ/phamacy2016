using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Common;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Pharmacy.Repository;

namespace BugsBox.Pharmacy.MonitorHandlers
{
    public class SaleOrderExpire
    {
        static BusinessHandlerFactory businessHandlerFactory = new BusinessHandlerFactory(new Db(), null);

        public static bool updateExpire()
        {
            //string msg=string.Empty;
            //SalesOrderBusinessHandler saleOrder = businessHandlerFactory.SalesOrderBusinessHandler;
            //var saleorders = saleOrder.Fetch(r => !r.Deleted && r.OrderStatusValue == 1 ).ToList();
            //foreach (var c in saleorders)
            //{
            //    if((DateTime.Now - c.UpdateTime).Days >= 1)
            //        saleOrder.Delete(c.Id, out msg);
            //}
            return true;
        }
    }
}
