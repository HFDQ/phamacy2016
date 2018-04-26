using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class SupplyUnitSalesmanBusinessHandler
    {
        protected override IQueryable<Models.SupplyUnitSalesman> IncludeNavigationProperties(IQueryable<Models.SupplyUnitSalesman> queryable)
        {
            return base.IncludeNavigationProperties(queryable.Include(t => t.SupplyUnit));
        }

        public List<Models.SupplyUnitSalesman> GetSalesManBySupplyUnitID(Guid SupplyUnitID)
        {
            var all=from i in this.Queryable where i.SupplyUnitId==SupplyUnitID select i;
            return all.ToList();
        }
    }
}
