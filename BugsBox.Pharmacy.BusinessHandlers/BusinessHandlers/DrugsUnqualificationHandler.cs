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
    partial class DrugsUnqualificationHandler
    {
        protected override IQueryable<drugsUnqualication> IncludeNavigationProperties(IQueryable<drugsUnqualication> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable);
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<drugsUnqualication>>(ex.Message, ex);
            }
        }

        public drugsUnqualication GetDrugsUnqualificationByID(Guid ItemGUID)
        {
            try
            {
                drugsUnqualication d=this.Fetch(r => r.Id == ItemGUID).FirstOrDefault();
                
                return d;
            }
            catch (Exception ex)
            {
                return this.HandleException<drugsUnqualication>("获取实体药品不合格信息失败", ex);
            }
        }

        public Business.Models.drugsUnqualificationQuery getDrugsUnqualificationQueryByFlowID(Guid flowID)
        {
            try
            {
                var queryBuilder = QueryBuilder.Create<drugsUnqualication>().Equals(p => p.flowID, flowID)
                    .Equals(p => p.Deleted, false);
                var all = BusinessHandlerFactory.RepositoryProvider.Db.drugsUnqualications.Where(queryBuilder.Expression);
                if (all.Where(r => r.DrugInventoryRecordID.Equals(Guid.Empty)).Count() <= 0)
                {
                    var c = from i in all
                            join u in RepositoryProvider.Db.Users.Include(r => r.Employee) on i.createUID equals u.Id
                            join d in RepositoryProvider.Db.DrugInventoryRecords on i.DrugInventoryRecordID equals d.Id
                            into left
                            from l in left.DefaultIfEmpty()
                            join wz in RepositoryProvider.Db.WarehouseZones on l.WarehouseZoneId equals wz.Id
                            join w in RepositoryProvider.Db.Warehouses on wz.WarehouseId equals w.Id
                            join pid in RepositoryProvider.Db.PurchaseInInventeryOrderDetails on l.PurchaseInInventeryOrderDetailId equals pid.Id into left2
                            from ll in left2.DefaultIfEmpty()
                            select new Business.Models.drugsUnqualificationQuery
                            {
                                batchNo = i.batchNo,
                                Origin = i.Origin,
                                creater = u.Employee.Name,
                                createTime = i.createTime,
                                CurrentInventoryCount = l == null ? 0m : l.CanSaleNum,
                                Description = i.Description,
                                Dosage = i.DosageType,
                                drugName = i.drugName,
                                FactoryName = i.factoryName,
                                id = i.Id,
                                flowID = i.flowID,
                                InInventoryDate = ll == null ? DateTime.Now : ll.ArrivalDateTime,
                                InventoryDate = 0,
                                OutValidDate = i.ExpireDate,
                                PurchaseOrderDocumentNumber = i.PurchaseOrderDocumentNumber,
                                quantity = i.quantity,
                                Specific = i.Specific,
                                SupplyUnitName = i.Supplyer,
                                updateTime = i.updateTime,
                                Warehouse = l == null ? "暂未入库" : w.Name,
                                WarehouseZone = l == null ? "暂未入库" : wz.Name,
                                productDate = i.produceDate,
                                Source = i.source
                            };
                    return c.FirstOrDefault();
                }
                else
                {
                    var c = from i in all
                            join u in RepositoryProvider.Db.Users.Include(r => r.Employee) on i.createUID equals u.Id
                            select new Business.Models.drugsUnqualificationQuery
                            {
                                batchNo = i.batchNo,
                                Origin = i.Origin,
                                creater = u.Employee.Name,
                                createTime = i.createTime,
                                CurrentInventoryCount = 0,
                                Description = i.Description,
                                Dosage = i.DosageType,
                                drugName = i.drugName,
                                FactoryName = i.factoryName,
                                id = i.Id,
                                flowID = i.flowID,
                                InInventoryDate = DateTime.Now,
                                InventoryDate = 0,
                                OutValidDate = i.ExpireDate,
                                PurchaseOrderDocumentNumber = i.PurchaseOrderDocumentNumber,
                                quantity = i.quantity,
                                Specific = i.Specific,
                                SupplyUnitName = i.Supplyer,
                                updateTime = i.updateTime,
                                Warehouse = "验收产生，暂未入库",
                                WarehouseZone = "验收产生，暂未入库",
                                productDate = i.produceDate,
                                Source = i.source
                            };
                    return c.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Business.Models.drugsUnqualificationQuery> GetDrugsUnqualificationQuery(Guid createUID)
        {
            try
            {                
                var queryBuilder = QueryBuilder.Create<drugsUnqualication>().In(p=>p.createUID,createUID)
                    .Equals(p=>p.Deleted,false);                  
                var all = BusinessHandlerFactory.RepositoryProvider.Db.drugsUnqualications.Where(queryBuilder.Expression);
                var query = from i in all
                            join e in BusinessHandlerFactory.RepositoryProvider.Db.Users on i.createUID equals e.Id 
                            join f in BusinessHandlerFactory.RepositoryProvider.Db.Employees on e.EmployeeId equals f.Id
                            join a in BusinessHandlerFactory.RepositoryProvider.Db.ApprovalFlows on i.flowID equals a.FlowId
                            join at in BusinessHandlerFactory.RepositoryProvider.Db.ApprovalFlowTypes on a.ApprovalFlowTypeId equals at.Id
                            select new Business.Models.drugsUnqualificationQuery
                            {
                                id=i.Id,
                                creater=f.Name,                           
                                flowID =i.flowID,
                                drugName = i.drugName,
                                batchNo=i.batchNo,
                                createTime = i.createTime,
                                //unqualificationType = i.unqualificationType,
                                quantity = i.quantity,
                                Description = i.Description,
                                updateTime = i.updateTime,
                                IsApproval = i.ApprovalStatusValue == 2 ? "已审" : i.ApprovalStatusValue == 4 ? "审批未通过" : i.ApprovalStatusValue == 1 ? "待审" :"其他",                                 
                                ApprovalProc = at.Name
                            };
                var records = query.OrderByDescending(p => p.createTime);
                return records.ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<Business.Models.drugsUnqualificationQuery>>("不合格药品查询失败!", ex);
            }
        }

        public List<drugsUnqualication> GetDrugsUnqualificationByCondition(drugsUnqualificationCondition Condition)
        {
            try
            {
                var result = this.Queryable;
                if (!string.IsNullOrWhiteSpace(Condition.drugName))
                {
                    result = result.Where(c => c.drugName.Contains(Condition.drugName));
                }
                if (!string.IsNullOrWhiteSpace(Condition.batchNo))
                {
                    result = result.Where(c => c.batchNo.Contains(Condition.batchNo));
                }
                if (Condition.FlowID != Guid.Empty)
                {
                    result = result.Where(c => c.flowID == Condition.FlowID);
                }

                if (Condition.dtFrom != DateTime.MinValue)
                {
                    Condition.dtFrom = Condition.dtFrom.AddHours(-DateTime.Now.Hour);
                    Condition.dtFrom = Condition.dtFrom.AddMinutes(-DateTime.Now.Minute);
                    Condition.dtFrom = Condition.dtFrom.AddSeconds(-DateTime.Now.Second);
                    result = result.Where(c => c.createTime >= Condition.dtFrom);
                }
                if (Condition.dtTo != DateTime.MaxValue)
                {
                    Condition.dtTo = Condition.dtFrom.AddDays(1);
                    Condition.dtTo = Condition.dtTo.AddHours(-DateTime.Now.Hour);
                    Condition.dtTo = Condition.dtTo.AddMinutes(-DateTime.Now.Minute);
                    Condition.dtTo = Condition.dtTo.AddSeconds(-DateTime.Now.Second);
                    result = result.Where(c => c.createTime <= Condition.dtTo);
                }
                //报损申请查询,不合格审核通过后。
                if (Condition.IsApproval)
                {
                    result = result.Where(c => c.ApprovalStatusValue == (int)ApprovalStatus.Approvaled);                    
                    result = result.Where(c => c.unqualificationType == -1 || c.unqualificationType==0);//表示被提交至待销毁处理 
                }

                var t = from i in result.ToList() where i.Deleted==false
                        join j in RepositoryProvider.Db.DrugInventoryRecords 
                        on i.DrugInventoryRecordID equals j.Id into left
                        from iv in left.DefaultIfEmpty()
                        select new drugsUnqualication
                        {
                            DrugInventoryRecordID=i.DrugInventoryRecordID,
                            quantity=i.quantity,
                            ApprovalStatusValue=i.ApprovalStatusValue,
                            batchNo=i.batchNo,
                            CheckDocumentNumber=i.CheckDocumentNumber,
                            createTime=i.createTime,
                            createUID=i.createUID,
                            Description=i.Description,
                            DocumentNumber=i.DocumentNumber,
                            drugName=i.drugName,
                            DosageType=i.DosageType,
                            ExpireDate=i.ExpireDate,
                            factoryName =i.factoryName,
                            flowID=i.flowID,
                            produceDate=i.produceDate,
                            PurchasePrice=i.PurchasePrice,
                            Id=i.Id,
                            source=i.source,
                            Specific=i.Specific,
                            unqualificationType=i.unqualificationType,
                            updateTime=i.updateTime,
                            Origin=i.Origin,
                            DrugInfo=i.DrugInfo,
                            Supplyer=i.Supplyer,
                            PurchaseOrderDocumentNumber=i.PurchaseOrderDocumentNumber,
                            PurchaseOrderId=i.PurchaseOrderId
                        };

                return t.ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<drugsUnqualication>>("不合格药品查询失败!", ex);
            }
            finally
            {
                this.Dispose();
            }
        }

        public void addDrugsUnqualityApproval(drugsUnqualication value, Guid approvalFlowTypeID, Guid userID,string changeNote)
        {
            try
            {
                if (value.ApprovalStatusValue != -1)
                {
                    value.DocumentNumber = new BillDocumentCodeBusinessHandler(BusinessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.DrugUnqualification).Code;
                    value.updateTime = DateTime.Now;
                    this.Save(value);

                    //增加审批流程
                    ApprovalFlow af = BusinessHandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowInstance(approvalFlowTypeID, value.flowID, userID, changeNote);
                    BusinessHandlerFactory.ApprovalFlowBusinessHandler.Add(af);

                    //增加审批流程记录
                    ApprovalFlowRecord afr = BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.GetApproveFlowRecordInstance(af, userID, changeNote);
                    BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.Add(afr);
                    
                    this.Save();
                }
            }
            catch (Exception e)
            {
                this.HandleException("新增不合格药品审批流程记录失败", e);
            }
        }

        //编辑不合格药品，以标志来区分：0->新增；1->修改；2->删除
        public bool EditDrugUnqualification(Models.drugsUnqualication du,int flag)
        {
            bool b=false;
            switch(flag)
            {
                case 0:
                     b=AddUnq(du);
                break;
                case 1:
                    b = ModUnq(du);
                break;
                case 2:
                    b = delUnq(du);
                break;
            }
            this.Save();
            return b;
        }

        private bool AddUnq(drugsUnqualication du)
        {
            du.createTime = DateTime.Now;
            if(du.DrugInventoryRecordID!=Guid.Empty)
            {
                DrugInventoryRecord dir = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(du.DrugInventoryRecordID);
                if (du.source.Contains("新建"))
                {
                    if (du.quantity > dir.CanSaleNum)
                    {
                        du = null;
                        dir = null;

                        throw new Exception("库存不足，新增失败，请修改不合格数量！");
                    }
                    dir.drugsUnqualicationNum += du.quantity;
                    dir.Valid = dir.CanSaleNum > 0 ? true : false;
                    BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(dir);
                }                
                dir = null;
            }

            du.createTime = DateTime.Now;            
            BusinessHandlerFactory.DrugsUnqualificationHandler.Add(du);
            du = null;
            return true;
        }

        private bool ModUnq(drugsUnqualication du)
        {
            du.updateTime = DateTime.Now;
            if (du.DrugInventoryRecordID != Guid.Empty)
            {
                drugsUnqualication duOld = BusinessHandlerFactory.DrugsUnqualificationHandler.Get(du.Id);
                DrugInventoryRecord dir = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(du.DrugInventoryRecordID);

                if (dir == null)
                {
                    du = null;
                    dir = null;
                    throw new Exception("库存出错，无法保存！");
                }
                dir.drugsUnqualicationNum -= duOld.quantity;
                dir.drugsUnqualicationNum += du.quantity;
                if (dir.CanSaleNum < 0)
                {
                    du = null;
                    dir = null;
                    throw new Exception("库存不足，无法保存！建议修改不合格数量！");
                }
                dir.Valid = dir.CanSaleNum > 0 ? true : false;
                BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(dir);
            }            
            BusinessHandlerFactory.DrugsUnqualificationHandler.Save(du);
            return true;
        }

        private bool delUnq(drugsUnqualication du)
        {
            du.DeleteTime = DateTime.Now;
            if (du.DrugInventoryRecordID != Guid.Empty)
            {
                DrugInventoryRecord dir = BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Get(du.DrugInventoryRecordID);

                if (dir == null)
                {
                    du = null;
                    dir = null;
                    throw new Exception("库存出错，无法保存！");
                }
                dir.drugsUnqualicationNum -= du.quantity;
                dir.Valid = dir.CanSaleNum > 0 ? true : false;

                BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(dir);
            }
            BusinessHandlerFactory.DrugsUnqualificationHandler.Delete(du.Id);
            return true;
        }
    }
}
