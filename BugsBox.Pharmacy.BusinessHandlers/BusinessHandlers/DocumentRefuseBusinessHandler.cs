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
    partial class DocumentRefuseBusinessHandler
    {
        protected override IQueryable<DocumentRefuse> IncludeNavigationProperties(IQueryable<DocumentRefuse> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable.Include(r => r.DrugInfo));
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<DocumentRefuse>>(ex.Message, ex);
            }
        }

        public DocumentRefuse[] QueryRefuseDocument( string source,int proc ,string keyword,out string msg )
        {
            msg = string.Empty;
            var all = this.Queryable;
            all = all.Where(r => r.proc == proc);
            if (source != string.Empty)
            {
                all = all.Where(r => r.Source.Contains(source));
            }
            if (keyword != string.Empty)
            {
                all = all.Where(r => r.BatchNumber.Contains(keyword) || r.conclusion.Contains(keyword) || r.conclusionSigner.Contains(keyword) || r.DocumentNumber.Contains(keyword) || r.drugName.Contains(keyword) || r.OrderDocumentID.Contains(keyword) || r.PurchaseUnitName.Contains(keyword));
            }
            return all.ToArray<DocumentRefuse>();
        }

        public bool RefuseNextProc(DocumentRefuse value,Guid UserID,out string msg)
        {
            msg = string.Empty;
            try
            {
                this.Save(value);
                //BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog { Content = ConnectedInfoProvider.User.Account + "成功提交拒收信息信息：" });

                this.Save();
                return true;
            }
            catch (Exception ex)
            {
                msg = "保存失败！";
                return false;
            }
        }
    }
}
