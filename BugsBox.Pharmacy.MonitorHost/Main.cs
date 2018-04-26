using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace BugsBox.Pharmacy.MonitorHost
{
    public class Main
    {
        public void Start()
        {
            //采购商主体监控
            PurchaseUnit pu = new PurchaseUnit();

            //供应商主体监控
            SupplyUnit su = new SupplyUnit();

            Drug dm = new Drug();

            Approval approval = new Approval();

            Sale sale = new Sale();

            Purchase pur = new Purchase();

            SaleOrderExprire soe = new SaleOrderExprire();
        }
        
    }
}
