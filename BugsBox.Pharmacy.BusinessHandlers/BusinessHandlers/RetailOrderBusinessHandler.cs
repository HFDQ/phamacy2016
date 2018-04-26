using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;
using System.Data.Entity;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class RetailOrderBusinessHandler
    {
        protected override IQueryable<RetailOrder> IncludeNavigationProperties(IQueryable<RetailOrder> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable.Include(u => u.RetailOrderDetails));
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<RetailOrder>>(ex.Message, ex);
            }
        
        }

        /// <summary>
        ///  分页检索零售
        /// </summary>
        /// <param name="totalpage"></param>
        /// <param name="deliveryIndexInput"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public IEnumerable<RetailOrder> GetRetailOrderPagedByCode(string orderCode, out PagerInfo pager, int pageindex, int pageSize)
        {
            try
            {
                PagerInfo pageInfo = new PagerInfo();
                pageInfo.Index = pageindex;
                pageInfo.Size = pageSize;

                pageindex = pageindex - 1;
                int skipCount = pageindex * pageSize;
                var varOrderRetail = base.Queryable;
                if (!string.IsNullOrWhiteSpace(orderCode))
                    varOrderRetail = varOrderRetail.Where(p => p.Code.IndexOf(orderCode) >= 0);
              

                pageInfo.RecordCount = varOrderRetail.Count();
                pager = pageInfo;
                varOrderRetail = varOrderRetail.OrderByDescending(o => o.CreateTime);
                varOrderRetail = (skipCount == 0 ? varOrderRetail.Take(pageSize) : varOrderRetail.Skip(skipCount).Take(pageSize));
                return varOrderRetail.AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                pager = null;
                return this.HandleException<IEnumerable<RetailOrder>>("分页检索零售失败", ex);
            }
        }

        /// <summary>
        ///  新增一条零售和零售明细记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns
        public void AddRetailOrderAndDetails(RetailOrder ro)
        {
            try
            {
                //增加零售记录
                List<RetailOrderDetail> rodList = ro.RetailOrderDetails.ToList();
                this.Add(ro);


                //增加零售记录明细
                foreach (RetailOrderDetail rod in rodList)
                {
                    //处理药物库存实体
                    DrugInventoryRecord drugInventory = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.GetRetailLeftDrugInventoryRecord(rod);
                    BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(drugInventory);

                    int piecemealNumber = drugInventory.DrugInfo.PiecemealNumber;


                    //处理库存实体                  
                    InventoryRecord Inventory = BusinessHandlerFactory.InventoryRecordBusinessHandler.GetRetailLeftDrugInventoryRecord(rod, drugInventory.DrugInfoId, piecemealNumber);
                 
                    BusinessHandlerFactory.InventoryRecordBusinessHandler.Save(Inventory);

                    rod.RetailOrderId = ro.Id;
                    BusinessHandlerFactory.RetailOrderDetailBusinessHandler.Add(rod);
                }

                this.Save();

            }
            catch (Exception ex)
            {
                this.HandleException("新增一条零售和零售明细记录失败", ex);
            }
        }



        /// <summary>
        ///  删除一条零售和零售明细记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns
        public void DeleteRetailOrderAndDetails(Guid retailOrderID)
        {
            try
            {
                //增加销售记录
                this.Delete(retailOrderID);

                List<RetailOrderDetail> retailOrderDetailList = this.Get(retailOrderID).RetailOrderDetails.ToList();
                foreach (RetailOrderDetail item in retailOrderDetailList)
                {
                    Guid drugInventoryID = item.DrugInventoryRecordID;
                    decimal consumeQty = item.Amount;
                    //获取药物库存实体                    
                    DrugInventoryRecord drugInventory = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(drugInventoryID);
                    //存库存表的当前可用库存扣掉该订单明细数量
                    drugInventory.CurrentInventoryCount = drugInventory.CurrentInventoryCount + item.Amount;
                    //在销售单但未出库数量 累计当前订单明细数量
                    drugInventory.OnSalesOrderCount = drugInventory.OnSalesOrderCount - item.Amount;
                    BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(drugInventory);


                    //获取库存实体
                    InventoryRecord Inventory = BusinessHandlerFactory.InventoryRecordBusinessHandler.GetInventoryRecordByDrugInfoID(drugInventory.DrugInfoId);
                    //存库存表的当前可用库存扣掉该订单明细数量
                    Inventory.CurrentInventoryCount = Inventory.CurrentInventoryCount + item.Amount;
                    //在销售单但未出库数量 累计当前订单明细数量
                    Inventory.OnSalesOrderCount = Inventory.OnSalesOrderCount - item.Amount;
                    BusinessHandlerFactory.InventoryRecordBusinessHandler.Save(Inventory);

                    //删除订单明细
                    BusinessHandlerFactory.RetailOrderDetailBusinessHandler.Delete(item.Id);
                }

                this.Save();

            }
            catch (Exception ex)
            {
                this.HandleException("删除一条订单和订单明细记录失败", ex);
            }
        }



        /// <summary>
        ///  零售退货处理
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns
        public void SaveRetailOrderAndDetails(RetailOrder ro)
        {
            try
            {
                //更新零售记录
                 List<RetailOrderDetail> rodList = ro.RetailOrderDetails.ToList();
                this.Save(ro);


                //更新零售记录明细
                foreach (RetailOrderDetail rod in rodList)
                {

                    //处理药物库存实体
                    DrugInventoryRecord drugInventory = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.GetRetailReturnLeftDrugInventoryRecord(rod);
                    BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(drugInventory);

                    int piecemealNumber = drugInventory.DrugInfo.PiecemealNumber;


                    //处理库存实体                  
                    InventoryRecord Inventory = BusinessHandlerFactory.InventoryRecordBusinessHandler.GetRetailReturnLeftDrugInventoryRecord(rod, drugInventory.DrugInfoId, piecemealNumber);
                    BusinessHandlerFactory.InventoryRecordBusinessHandler.Save(Inventory);

                    BusinessHandlerFactory.RetailOrderDetailBusinessHandler.Save(rod);
                }

                this.Save();

            }
            catch (Exception ex)
            {
                this.HandleException(" 零售退货处理失败", ex);
            }
        }


    }
}
