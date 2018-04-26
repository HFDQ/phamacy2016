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
    partial class DrugMaintainRecordBusinessHandler
    {
        protected override IQueryable<DrugMaintainRecord> IncludeNavigationProperties(IQueryable<DrugMaintainRecord> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable);
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<DrugMaintainRecord>>(ex.Message, ex);
            } 
        }

        /// <summary>
        /// 获取实体药品养护记录
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="CompleteState"></param>
        /// <param name="DrugMaintainType"></param>
        /// <returns></returns>
        public List<DrugMaintainRecord> GetDrugMaintainRecordByCondition(DateTime StartDate, DateTime EndDate, int? CompleteState, int? DrugMaintainType)
        {
            try
            {

                var all = this.Queryable;
                List<DrugMaintainRecord> list = all.Where(r => r.CreateTime >= StartDate && r.CreateTime <= EndDate).ToList();
                if(CompleteState!=null)
                {
                    int intCompleteState = Convert.ToInt16( CompleteState);
                    list = list.Where(r => r.CompleteState == intCompleteState).ToList();
                }
                if (DrugMaintainType != null)
                {
                    list = list.Where(r => r.DrugMaintainTypeValue == DrugMaintainType).ToList();
                }

                foreach (var c in list)
                {
                    int count = RepositoryProvider.Db.DrugMaintainRecordDetails.Where(r => r.BillDocumentNo == c.BillDocumentNo && c.Deleted!=true).ToList().Count;
                    if (count == 0)
                    {
                        BusinessHandlerFactory.DrugMaintainRecordBusinessHandler.Delete(c.Id);
                    }
                }
                //BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog { Content = ConnectedInfoProvider.User.Account + "成功获取药品养护信息" });


                return list.ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<DrugMaintainRecord>>("获取药品养护记录失败", ex);
            }
        }

        public bool SaveDrugMaintainRecordByBillDocumentNo(string BillDocumentNo, bool IsCompleteState)
        {
            try
            {
                DrugMaintainRecord item = this.Fetch(r => r.BillDocumentNo == BillDocumentNo).FirstOrDefault();
                if (item == null)
                {
                    return false;
                }
                if (IsCompleteState)
                {
                    item.CompleteState = 1;
                }
                else
                {
                    item.CompleteState = 0;
                }
                this.Save();

                //BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog { Content = ConnectedInfoProvider.User.Account + "成功一条保存药品养护信息" });
                return true;
            }
            catch (Exception ex)
            {
                //BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog { Content = ConnectedInfoProvider.User.Account + "药品养护信息更新失败" });
                return this.HandleException<bool>("根据单据号处理养护记录失败", ex);
            }
        }
    }
}
