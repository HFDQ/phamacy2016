using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.Config;
using System.Data.Entity;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class DirectSalesOrderBusinessHandler
    {

        protected override IQueryable<DirectSalesOrder> IncludeNavigationProperties(IQueryable<DirectSalesOrder> queryable)
        {
            try
            {
                return base.Queryable.Include(r=>r.DirectSalesOrderDetails);
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<DirectSalesOrder>>(ex.Message, ex);
            }
            
        }

        /// <summary>
        /// 新增直调销售表
        /// </summary>
        /// <param name="dso"></param>
        /// <returns></returns>
        public bool AddDirectSalesOrderAndDetail(Models.DirectSalesOrder dso)
        {
            lock (this)
            {
                try
                {
                    dso.CreateTime = DateTime.Now;
                    dso.UpdateTime = DateTime.Now;
                    dso.ApprovalDateTime = DateTime.Now;
                    dso.DocumentNumber = BusinessHandlerFactory.BillDocumentCodeBusinessHandler.GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.DirectSale).Code;
                    this.Add(dso);
                    dso.DirectSalesOrderDetails.ForEach(r =>
                    {
                        RepositoryProvider.DirectSalesOrderDetailRepository.Add(r);
                    });
                    this.Save();
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 删除直调销售表
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteDirectSalesOrderAndDetail(System.Guid Id)
        {
            try
            {
                this.Delete(Id);
                this.Save();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 修改直调销售表
        /// </summary>
        /// <param name="dso"></param>
        /// <returns></returns>
        public bool SaveDirectSalesOrderAndDetail(Models.DirectSalesOrder dso)
        {
            dso.UpdateTime = DateTime.Now;
            this.Save(dso);

            var d = this.Queryable.Where(r => r.Id == dso.Id);
            var details=d.First().DirectSalesOrderDetails;
            details.ForEach(r=>
            {
                r.Deleted=true;
                BusinessHandlerFactory.DirectSalesOrderDetailBusinessHandler.Save(r);
            });

            foreach (var i in dso.DirectSalesOrderDetails.Where(r=>r.Deleted==false))
            {
                if (details.Where(r => r.Id == i.Id).Count() > 0)
                {
                    BusinessHandlerFactory.DirectSalesOrderDetailBusinessHandler.Save(i);
                }
                else
                {
                    BusinessHandlerFactory.DirectSalesOrderDetailBusinessHandler.Add(i);
                }
            }
            this.Save();
            return true;
        }

        public Business.Models.DirectSalesModel[] GetDirectSalesModelByApprovalStatus(Business.Models.DirectSalesQueryModel dsq)
        {
            var c = this.Queryable.Where(r => !r.Deleted );

            //是否验收状态查询
            if (dsq.CheckedStatusValue >=0)
            {
                c = c.Where(r => r.CheckStatusValue == dsq.CheckedStatusValue);
            }
            c = c.Where(r =>dsq.ApprovalStatus.Contains(r.ApprovalStatusValue)).OrderBy(r=>r.DocumentNumber);

            if (dsq.Sdt != null && dsq.Edt != null)//时间查询
            {
                c = c.Where(r => r.CreateTime >= dsq.Sdt.Date && r.CreateTime <= dsq.Edt.Date);
            }

            if (!string.IsNullOrEmpty(dsq.DocumentNumber))//单号查询
            {
                c = c.Where(r => r.DocumentNumber.Contains(dsq.DocumentNumber));
            }

            var result = from i in c
                         join j in RepositoryProvider.Db.PurchaseUnits on i.PurchaseUnitId equals j.Id
                         where j.Deleted==false
                         join k in RepositoryProvider.Db.SupplyUnits on i.SupplyUnitId equals k.Id
                         where k.Deleted==false
                         join u in RepositoryProvider.Db.Users.Include(r => r.Employee) on i.CreateUserId equals u.Id
                         select new Business.Models.DirectSalesModel
                         {
                             ApprovalStatus =i.ApprovalStatusValue ==0?"未提交审批": i.ApprovalStatusValue == 1 ? "待审" : i.ApprovalStatusValue == 2 ? "审核通过" : i.ApprovalStatusValue == 4 ? "审核不通过" : "其他",
                             Checker = i.CheckUserName,
                             CheckMethod = i.CheckUserId == Guid.Empty ? "委托验收" : "派驻验收",
                             Createtime = i.CreateTime,
                             DocumentNumber = i.DocumentNumber,
                             PurchaseUnitName = j.Name,
                             PurchaseUnitPY=j.PinyinCode,
                             SupplyUnitName = k.Name,
                             SupplyUnitPY=k.PinyinCode,
                             Invoicer = u.Employee.Name,
                             ReceivingAddress = j.ReceiveAddress,
                             CheckAddress=i.CheckAddress,
                             DirectSalesOrderId = i.Id,
                             SupplyUnitId=k.Id,
                             PurchaseUnitId=j.Id,
                             Memo=i.Memo,
                             TotalSalePrice=i.DirectSalesOrderDetails.Where(r=>!r.Deleted).Sum(r=>r.Amount*r.SalePrice),
                             TotalSupplyPrice = i.DirectSalesOrderDetails.Where(r => !r.Deleted).Sum(r => r.Amount * r.SupplyPrice),
                             TotalAmount = i.DirectSalesOrderDetails.Where(r => !r.Deleted).Sum(r => r.Amount),
                             CheckStatus=i.CheckStatusValue
                         };

            if (!string.IsNullOrEmpty(dsq.SupplyUnitKW))//供货企业关键字
            {
                result = result.Where(r=>r.SupplyUnitPY!=null).Where(r => r.SupplyUnitName.Contains(dsq.SupplyUnitKW)||r.SupplyUnitPY.ToUpper().Contains(dsq.SupplyUnitKW.ToUpper()));
            }

            if (!string.IsNullOrEmpty(dsq.PurchaseUnitKW))//购货单位关键字
            {
                result = result.Where(r => r.PurchaseUnitPY != null).Where(r => r.PurchaseUnitName.Contains(dsq.PurchaseUnitKW) || r.PurchaseUnitPY.ToUpper().Contains(dsq.PurchaseUnitKW.ToUpper()));
            }

            return result.ToArray();
        }

        /// <summary>
        /// 根据直调单ID获取直调细节信息
        /// </summary>
        /// <param name="DirectSalesId"></param>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerable<DirectSalesOrderDetailModel> GetDirectSalesOrderDetailModelByDirectSalesModel(System.Guid DirectSalesId)
        {
            var c = this.Queryable.Where(r => r.Id == DirectSalesId).FirstOrDefault();

            var re = from de in c.DirectSalesOrderDetails.Where(r=>!r.Deleted)
                      join di in RepositoryProvider.Db.DrugInfos
                      on de.DrugInfoId equals di.Id
                      select new DirectSalesOrderDetailModel
                      {
                          Id=de.Id,
                          Amount = de.Amount,
                          BatchNumber = de.BatchNumber,
                          DirectDiffPrice = de.DirectSaleDiff,
                          Dosage = di.DictionaryDosageCode,
                          DrugInfoId = di.Id,
                          FactoryName = di.FactoryName,
                          MeasurementUnitCode = di.DictionaryMeasurementUnitCode,
                          Origin = de.Origin,
                          PermitNumber = di.LicensePermissionNumber,
                          ProducGeneralName = di.ProductGeneralName,
                          SalePrice = de.SalePrice,
                          SaleWholePrice = de.SalePrice * de.Amount,
                          Specific = di.DictionarySpecificationCode,
                          SupplyPrice = de.SupplyPrice,
                          SupplyWholePrice = de.SupplyPrice * de.Amount,
                          QualityNumber=de.QualityAmount,
                          UnqualityNumber=de.UnQualityAmount,
                          CheckMethod=de.CheckMethod,
                          OutValidDate=de.OutValidDate,
                          ProductDate=de.ProductDate,
                          QualityMemo=de.QualityMemo,
                          UnqualityMemo=de.UnqualityMemo,
                      };
            return re.ToArray();
        }

        /// <summary>
        /// 增加直调销售审批
        /// </summary>
        /// <param name="value"></param>
        /// <param name="approvalFlowTypeID"></param>
        /// <param name="userID"></param>
        /// <param name="changeNote"></param>
        /// <returns></returns>
        public bool AddDirectSaleApproval(Models.DirectSalesOrder value, System.Guid approvalFlowTypeID, System.Guid userID, string changeNote)
        {
            try
            {
                if (value.ApprovalStatusValue != -1)
                {
                    value.UpdateTime = DateTime.Now;
                    this.Save(value);

                    //增加审批流程
                    ApprovalFlow af = BusinessHandlerFactory.ApprovalFlowBusinessHandler.GetApproveFlowInstance(approvalFlowTypeID, value.FlowId, userID, changeNote);
                    BusinessHandlerFactory.ApprovalFlowBusinessHandler.Add(af);

                    //增加审批流程记录
                    ApprovalFlowRecord afr = BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.GetApproveFlowRecordInstance(af, userID, changeNote);
                    BusinessHandlerFactory.ApprovalFlowRecordBusinessHandler.Add(afr);

                    this.Save();                   
                } return true;
            }
            catch (Exception e)
            {
                this.HandleException("新增直调销售审批流程记录失败", e);
                return false;
            }
        }

        public Models.DirectSalesOrder GetDirectSalesOrderByFlowId(System.Guid FlowId)
        {
            var c=this.Queryable.Where(r => r.FlowId == FlowId).FirstOrDefault();
            return c;
        }

    }
}
