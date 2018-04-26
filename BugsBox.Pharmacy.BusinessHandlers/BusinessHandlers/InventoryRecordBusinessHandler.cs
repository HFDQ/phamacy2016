using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;
using System.Data.Entity;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class InventoryRecordBusinessHandler
    {
        protected override IQueryable<InventoryRecord> IncludeNavigationProperties(IQueryable<InventoryRecord> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable);
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<InventoryRecord>>(ex.Message, ex);
            } 
          
        }
        /// <summary>
        ///  根据药品信息ID获取库存表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns
        public InventoryRecord GetInventoryRecordByDrugInfoID(Guid drugInfoID)
        {
            try
            {
                return this.Fetch(p => p.DrugInfoId == drugInfoID).FirstOrDefault();

            }
            catch (Exception ex)
            {
                return this.HandleException<InventoryRecord>("根据编号获取库存失败", ex);
            }
        }


        /// <summary>
        /// 根据零售退货单获取更新后的库存实体
        /// </summary>
        /// <param name="rod"></param>
        /// <returns></returns>
        protected internal InventoryRecord GetRetailReturnLeftDrugInventoryRecord(RetailOrderDetail rod, Guid drugInfoID, int piecemealNumber)
        {
            Guid drugInventoryID = rod.DrugInventoryRecordID;
            decimal returnQty = rod.ReturnAmount;

            //获取药物库存实体

            InventoryRecord Inventory = this.Get(drugInventoryID);
            if (Inventory != null)
            {
                #region DrugInventoryRecord  药物实体库存处理

                if (rod.IsDismanting)
                {
                    //将退库的零售拆零数量累加到药品库存的待售零售拆零数量上
                    Inventory.DismantingAmount += returnQty;

                    if (piecemealNumber > 0)
                    {
                        //如果待售零售拆零数量大于一个单位，则需要装包
                        if (Inventory.DismantingAmount >= piecemealNumber)
                        {
                            Inventory.CurrentInventoryCount += Inventory.DismantingAmount / piecemealNumber;
                            Inventory.DismantingAmount = Inventory.DismantingAmount % piecemealNumber;
                        }
                    }

                    //将退库的零售拆零数量从已售的拆零零售数量里扣除
                    //已售拆零数量是不够扣除拆零退货数量，则从已售零售里拆包
                    if (Inventory.RetailDismantingAmount < returnQty)
                    {
                        Inventory.RetailCount -= 1;
                        Inventory.RetailDismantingAmount += piecemealNumber;
                    }
                    Inventory.RetailDismantingAmount -= returnQty;

                }
                else
                {
                    //存库存表的当前可用库存加上改退货数量
                    Inventory.CurrentInventoryCount += returnQty;

                    //将已经销售的零售数量累减去退货数量
                    Inventory.RetailCount -= returnQty;
                }

                #endregion
            }
            return Inventory;
        }

        /// <summary>
        /// 根据零售单获取更新后的库存实体
        /// </summary>
        /// <param name="rod"></param>
        /// <returns></returns>
        protected internal InventoryRecord GetRetailLeftDrugInventoryRecord(RetailOrderDetail rod, Guid drugInfoID, int piecemealNumber)
        {
            //获取库存实体                  
            InventoryRecord Inventory = BusinessHandlerFactory.InventoryRecordBusinessHandler.GetInventoryRecordByDrugInfoID(drugInfoID);
            if (Inventory != null)
            {
                if (Inventory.CurrentInventoryCount < rod.Amount)
                {
                    if (rod.IsDismanting)
                    {
                        //当前拆零数量是否满足该条零售的拆零数量
                        //如果拆零数量不足，则再拆一个单位
                        if (Inventory.DismantingAmount < rod.DismantingAmount)
                        {
                            Inventory.CurrentInventoryCount = Inventory.CurrentInventoryCount - 1;
                            Inventory.DismantingAmount = Inventory.DismantingAmount + piecemealNumber;

                        }
                        //存库存表的当前可用拆零数量扣掉该零售拆零数量
                        Inventory.DismantingAmount = Inventory.DismantingAmount - rod.DismantingAmount;
                        //将零售拆零数量累加到可用库存的拆零零售数量
                        Inventory.RetailDismantingAmount = Inventory.RetailDismantingAmount + rod.DismantingAmount;

                        if (piecemealNumber > 0)
                        {
                            //如果已售的零售数量大于一个单位，则需要装包
                            if (Inventory.RetailDismantingAmount >= piecemealNumber)
                            {
                                Inventory.RetailCount = Inventory.RetailCount + Inventory.RetailDismantingAmount / piecemealNumber;
                                Inventory.RetailDismantingAmount = Inventory.RetailDismantingAmount % piecemealNumber;
                            }
                        }
                    }
                    else
                    {
                        //存库存表的当前可用库存扣掉该零售数量
                        Inventory.CurrentInventoryCount = Inventory.CurrentInventoryCount - rod.Amount;
                        //将零售数量累加到可用库存的零售数量
                        Inventory.RetailCount = Inventory.RetailCount + rod.Amount;
                    }
                }
                return Inventory;

            }
            else
            {
                return null;
                throw new Exception("库存数量不足");

            }
        }

        
    }
}
