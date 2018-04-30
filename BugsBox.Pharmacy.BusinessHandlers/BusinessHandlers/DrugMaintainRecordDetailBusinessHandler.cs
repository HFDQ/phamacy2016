using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Business.Models;
using System.Linq.Expressions;
using BugsBox.Pharmacy.Repository;
using System.Data.Entity;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class DrugMaintainRecordDetailBusinessHandler
    {
        object locker=new object();
        protected override IQueryable<DrugMaintainRecordDetail> IncludeNavigationProperties(IQueryable<DrugMaintainRecordDetail> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable);
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<DrugMaintainRecordDetail>>(ex.Message, ex);
            }
        }

        public bool SaveDrugMaintainDetailAndUndeterminate(Models.DrugMaintainRecordDetail[] dmrds)
        {
            lock (locker)
            {
                string outDetail = string.Empty;
                try
                {
                    foreach (DrugMaintainRecordDetail dmrd in dmrds)
                    {
                        dmrd.CheckDate = DateTime.Now;
                        this.Save(dmrd);

                        decimal UndeNum = dmrd.MaintainCount - Convert.ToDecimal(dmrd.CheckqualifiedNumber);

                        if (UndeNum > 0)
                        {
                            DrugsUndeterminate du = RepositoryProvider.Db.DrugsUndeterminates.Where(r => r.UnqualificationApprovalID == dmrd.Id).ToList().FirstOrDefault();

                            if (du == null)
                            {
                                du = new DrugsUndeterminate();
                                du.BatchNumber = dmrd.BatchNumber;
                                du.conclusionDate = DateTime.Now;
                                Guid emId = RepositoryProvider.Db.Users.Where(r => r.Id == dmrd.UserId).ToList().FirstOrDefault().EmployeeId;
                                du.creater = RepositoryProvider.Db.Employees.Where(r => r.Id == emId).FirstOrDefault().Name;
                                du.createTime = DateTime.Now;
                                du.DosageType = dmrd.DictionaryDosageCode;

                                DrugInventoryRecord dir = RepositoryProvider.Db.DrugInventoryRecords.Where(r => r.Id == dmrd.DrugInventoryRecordId).ToList().First();
                                du.DrugInfoID = dir.DrugInfoId;
                                du.drugName = dmrd.ProductName;
                                du.ExpireDate = dmrd.OutValidDate;
                                du.Id = Guid.NewGuid();
                                du.InventoryID = dmrd.DrugInventoryRecordId;
                                if (!dir.PurchaseInInventeryOrderDetailId.Equals(Guid.Empty))
                                {
                                    PurchaseInInventeryOrderDetail piio = RepositoryProvider.Db.PurchaseInInventeryOrderDetails.Where(r => r.Id == dir.PurchaseInInventeryOrderDetailId).FirstOrDefault();
                                    PurchaseInInventeryOrder pi = RepositoryProvider.Db.PurchaseInInventeryOrders.Where(r => r.Id == piio.PurchaseInInventeryOrderId).FirstOrDefault();
                                    Guid orderId = pi.PurchaseOrderId;
                                    PurchaseOrder po = RepositoryProvider.Db.PurchaseOrders.Where(r => r.Id == orderId).ToList().First();
                                    du.OrderDocumentID = po.DocumentNumber;
                                    du.PurchaseOrderID = pi.Id;
                                    du.supplyer = RepositoryProvider.Db.SupplyUnits.Where(r => r.Id == po.SupplyUnitId).ToList().First().Name;
                                }
                                else
                                {
                                    du.OrderDocumentID = "前期库存,无入库单号";
                                    du.PurchaseOrderID = Guid.Empty;
                                    du.supplyer = "无";
                                }
                                du.proc = 0;
                                du.produceDate = dmrd.PruductDate;
                                du.DocumentNumber = new BillDocumentCodeBusinessHandler(BusinessHandlerFactory.RepositoryProvider, null).GenerateBillDocumentCodeByTypeValue((int)BillDocumentType.DrugUndeterminate).Code;
                                du.PurchasePrice = dir.PurchasePricce;
                                du.QualificationQuantity = Convert.ToDecimal(dmrd.CheckqualifiedNumber);
                                du.quantity = UndeNum;
                                du.rsn = "养护疑问药品复查";
                                du.Source = "养护";
                                du.Specific = dmrd.DictionarySpecificationCode;
                                du.sta = string.Empty;
                                du.staSignDate = DateTime.Now;
                                du.staSigner = string.Empty;
                                du.storeID = dir.StoreId;
                                du.UnqualificationApprovalID = dmrd.Id; //该字段临时作为质量复查单的id。
                                du.UnqualificationQuantity = 0;
                                du.updateTime = DateTime.Now;
                                du.wareHouse = RepositoryProvider.Db.WarehouseZones.Where(r => r.Id == dir.WarehouseZoneId).First().Name;
                                du.Origin = dir.Decription;
                                BusinessHandlerFactory.DrugsUndeterminateBusinessHandler.Add(du);
                                decimal cansaleNum = dir.CanSaleNum;

                                dir.drugsUnqualicationNum += UndeNum;//库存记录中加上质量复查数量，然后保存。
                                if (dir.CanSaleNum < 0)
                                {
                                    outDetail = "养护品种细节数据在当月1日自动完成，库存数量发生变化，" + du.drugName + "当前库存数量为：" + cansaleNum + "，提交养护疑问药品数量不正确。";
                                    throw new Exception("养护品种细节数据在当月1日自动完成，库存数量发生变化，"+du.drugName+"当前库存数量为："+cansaleNum+"，提交养护疑问药品数量不正确。");
                                }
                                dir.Valid = dir.CanSaleNum > 0 ? true : false;
                                BusinessHandlerFactory.DrugInventoryRecordBusinessHandler.Save(dir);
                            }
                        }
                    }
                    this.Save();

                    string documentNumber = dmrds.FirstOrDefault().BillDocumentNo;

                    var re = RepositoryProvider.Db.DrugMaintainRecordDetails.Where(r => r.CheckDate == null && r.BillDocumentNo == documentNumber && r.Deleted==false).FirstOrDefault();
                    if (re == null)
                    {

                        var c = RepositoryProvider.Db.DrugMaintainRecords.Where(r => r.BillDocumentNo == documentNumber).FirstOrDefault();
                        if (c == null) return false;

                        c.CompleteState = 1;
                        this.Save();
                    }                    
                    return true;
                }
                catch (Exception e)
                {
                    this.HandleException("养护细节提交失败!" + outDetail, e);
                    return false;
                }
            }
        }

        /// <summary>
        /// 获取实体药品养护详细记录
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="CompleteState"></param>
        /// <param name="DrugMaintainType"></param>
        /// <returns></returns>
        public List<DrugMaintainRecordDetail> GetDrugMaintainRecordDetailByCondition(string BillDocumentNo, DateTime? CheckDate)
        {
            try
            {
                List<DrugMaintainRecordDetail> list = this.Fetch(r => r.BillDocumentNo == BillDocumentNo).ToList();
                
                if (list != null)
                {
                    if (CheckDate != null)
                    {
                        DateTime strCheckDate = Convert.ToDateTime(CheckDate).Date;
                        DateTime strCheckDate2 = Convert.ToDateTime(CheckDate).Date.AddDays(1);
                        list = list.Where(r => r.CheckDate >= strCheckDate && r.CheckDate < strCheckDate2).ToList();
                    }
                    return list.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return this.HandleException<List<DrugMaintainRecordDetail>>("获取药品养护详细记录失败", ex);
            }
        }

        public bool AddMaintainDetails(IEnumerable<DrugMaintainRecordDetail> details)
        {
            foreach (var i in details)
            {
                RepositoryProvider.Db.DrugMaintainRecordDetails.Add(i);
            }
            this.Save();
                return true;
        }
    }
}
