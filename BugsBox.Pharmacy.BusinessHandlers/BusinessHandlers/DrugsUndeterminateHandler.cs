using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Business.Models;
using System.Linq.Expressions;
using System.Data.Entity;
using BugsBox.Pharmacy.Repository;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class DrugsUndeterminateBusinessHandler
    {
        protected override IQueryable<DrugsUndeterminate> IncludeNavigationProperties(IQueryable<DrugsUndeterminate> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable.Include(r => r.DrugInfo));
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<DrugsUndeterminate>>(ex.Message, ex);
            }
        }

        public DrugsUndeterminate[] AllDrugsUndeterminate(int state,string source,string keyword)
        {
            var all = this.Queryable;
            all = all.Where(r => r.proc == state);
            if (!source.Equals(string.Empty))
            {
                all = all.Where(r => r.Source.Contains(source));
            }
            if (keyword != "")
            {
                all = all.Where(r=>r.BatchNumber.Contains(keyword)||r.conclusion.Contains(keyword)||r.drugName.Contains(keyword)||r.DocumentNumber.Contains(keyword)||r.supplyer.Contains(keyword));
            }

            
            var records = all.OrderByDescending(p => p.conclusionDate).ToList();
            DrugsUndeterminate[] drugsUnDes = all.ToArray<DrugsUndeterminate>();
            return drugsUnDes;
        }

        public bool SaveToNextProc(DrugsUndeterminate value,Guid userID)
        {
            string msg = string.Empty;
            try
            {
                if (value.proc == 1)
                {
                    this.Save(value, out msg);
                    return true;
                }

                if (value.QualificationQuantity > 0)
                {
                    if (value.Source.Contains("其他") || value.Source.Contains("养护"))
                    {
                        var V = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(value.InventoryID);
                        V.drugsUnqualicationNum -= value.QualificationQuantity;
                        BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(V);
                    }
                    else
                    {
                        var purchaseOrder = BusinessHandlerFactory.RepositoryProvider.Db.PurchaseOrders.Where(r => r.DocumentNumber == value.OrderDocumentID).FirstOrDefault();

                        PurchaseCheckingOrder pco = new PurchaseCheckingOrder();
                        pco.Id = Guid.NewGuid();
                        pco.DocumentNumber = new BillDocumentCodeBusinessHandler(BusinessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.PurchaseCheckingOrder).Code;
                        pco.OperateTime = DateTime.Now;
                        pco.StoreId = BugsBox.Pharmacy.Config.PharmacyServiceConfig.Config.CurrentStore.Id;
                        pco.OperateUserId = userID;
                        pco.OrderStatusValue = 13;
                        pco.PurchaseOrderId = purchaseOrder.Id;
                        pco.Decription = "待处理药品复核验收正常,可入库!";
                        pco.RelatedOrderDocumentNumber = value.DocumentNumber;
                        pco.RelatedOrderId = value.Id;
                        pco.RelatedOrderType = OrderType.Undeterminate;

                        //采购验收单更新
                        purchaseOrder.UpdateTime = DateTime.Now;
                        purchaseOrder.UpdateUserId = userID;
                        purchaseOrder.OrderStatusValue = 13;
                        BusinessHandlerFactory.PurchaseCheckingOrderBusinessHandler.Add(pco);
                        BusinessHandlerFactory.PurchaseOrderBusinessHandler.Save(purchaseOrder);

                        PurchaseCheckingOrderDetail purchaseOrderDetail = new PurchaseCheckingOrderDetail();
                        purchaseOrderDetail.ArrivalAmount = value.QualificationQuantity;
                        purchaseOrderDetail.ArrivalDateTime = pco.OperateTime;
                        purchaseOrderDetail.BatchNumber = value.BatchNumber;
                        purchaseOrderDetail.CheckResult = 0;
                        purchaseOrderDetail.Decription = value.Origin;
                        purchaseOrderDetail.DrugInfoId = value.DrugInfoID;
                        purchaseOrderDetail.OutValidDate = value.ExpireDate;
                        purchaseOrderDetail.PruductDate = value.produceDate;
                        purchaseOrderDetail.QualifiedAmount = value.QualificationQuantity;
                        purchaseOrderDetail.PurchasePrice = value.PurchasePrice;
                        purchaseOrderDetail.PurchaseCheckingOrderId = pco.Id;
                        purchaseOrderDetail.StoreId = pco.StoreId;
                        purchaseOrderDetail.Id = Guid.NewGuid();
                        BusinessHandlerFactory.PurchaseCheckingOrderDetailBusinessHandler.Add(purchaseOrderDetail);
                    }
                }
                //如果不合格药品填写数量不为0，则将其写入不合格药品审批流程
                if (value.UnqualificationQuantity > 0)
                {
                    DrugsUnqualication du = new DrugsUnqualication();
                    du.Id = Guid.NewGuid();
                    du.createTime = DateTime.Now;
                    du.createUID = userID;
                    du.ApprovalStatusValue = -1;
                    du.flowID = Guid.NewGuid();
                    du.Description = "质量部结论：" + value.conclusion;
                    du.quantity = value.UnqualificationQuantity;
                    du.drugName = value.drugName;
                    du.batchNo = value.BatchNumber;
                    du.DrugInventoryRecordID = value.InventoryID;
                    du.DocumentNumber = new BillDocumentCodeBusinessHandler(BusinessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.DrugUnqualification).Code;
                    du.CheckDocumentNumber = value.DocumentNumber;
                    du.source = "质量复核";
                    du.DosageType = value.DosageType;
                    du.Specific = value.Specific;
                    du.produceDate = value.produceDate;
                    du.ExpireDate = value.ExpireDate;
                    du.factoryName = value.DrugInfo.FactoryName;
                    du.PurchasePrice = value.PurchasePrice;
                    du.unqualificationType = -1;   //养护流程不合格
                    du.updateTime = DateTime.Now;
                    du.Deleted = false;
                    du.DrugInfo = value.DrugInfoID;
                    du.Origin = value.Origin;
                    du.Supplyer = value.supplyer;
                    du.PurchaseOrderId = value.PurchaseOrderID==null?Guid.Empty:(Guid)value.PurchaseOrderID;
                    du.PurchaseOrderDocumentNumber = value.OrderDocumentID;
                    BusinessHandlerFactory.DrugsUnqualicationBusinessHandler.EditDrugUnqualification(du,0);
                }

                this.Save(value);
            }
            catch (Exception ex)
            {                
                msg = "保存出错！";
                return false;
            }
            this.Save();
            return true;
        }
    }
}
