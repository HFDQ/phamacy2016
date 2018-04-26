using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class PurchaseOrderDetailBusinessHandler
    {
        /// <summary>
        /// 根据采购单id查询采购单明细信息
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <returns></returns>
        public IEnumerable<PurchaseOrderDetail> GetPurchaseOrderDetailByOrderId(Guid purchaseOrderId)
        {
            try
            {
                return this.Fetch(p => p.PurchaseOrderId == purchaseOrderId).ToList();

            }
            catch (Exception ex)
            {
                return this.HandleException<IEnumerable<PurchaseOrderDetail>>("根据采购单编号查询采购单明细信息失败", ex);
            }
        }

        //public override void Delete(Guid id)
        //{
        //    var m = this.RepositoryProvider.Db.PurchaseOrderDetails.FirstOrDefault(r => r.Id == id);
        //    this.RepositoryProvider.Db.PurchaseOrderDetails.Remove(m);
        //}
    }
}
