using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;
using System.Data.Entity;
using BugsBox.Pharmacy.Repository;
using BugsBox.Pharmacy.Notification;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class UserBusinessHandler
    {
        protected override IQueryable<User> IncludeNavigationProperties(IQueryable<User> queryable)
        {
            try
            {
                return base.IncludeNavigationProperties(queryable
                    .Include(u => u.Employee)
                    .Include(u=>u.Employee.Department)
                    );
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("[{0}]导航属性处理出错", EntityName), ex);
                return HandleException<IQueryable<User>>(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取所有有效的用户信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAllUsers()
        {
            return this.Fetch(p => p.Enabled == true).ToList();
        }
        
        /// <summary>
        /// 根据UserId 获取user 
        /// </summary>
        /// <param name="pDepartmentId"></param>
        /// <returns></returns>
        public IEnumerable<User> GetUserInfo(string Account)
        {
            try
            {
                return this.Fetch(d => d.Account == Account).ToList();
            }
            catch (Exception ex)
            { 
                return this.HandleException<IEnumerable<User>>("根据帐号获取用户失败", ex);
            }
        }

        #region 登录相关

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public User UserLogon(string account, string pwd)
        {
            try
            { 
                var logonUser = this.Query(u => u.Account == account && u.Pwd == pwd).FirstOrDefault(); 
                if (logonUser == null)
                {
                    return null;
                }
                else
                {
                    string message = null;
                    //加入登录Session
                    this.ConnectedInfoProvider.User = logonUser;
                    BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog { Content = ConnectedInfoProvider.User.Account + "成功登录系统" });
                    NotificationHandlerFactory.NotificationHandler.OnUserOnLine(logonUser);
                    return logonUser; 
                }
            }
            catch (Exception ex)
            {
                return this.HandleException<User>("登录失败", ex);
            }
        }

        /// <summary>
        /// 用户登出
        /// </summary>
        public string UserLogout(Guid userId)
        {
            try
            {

                if (ConnectedInfoProvider.User!=null)
                {
                    BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog { Content = ConnectedInfoProvider.User.Account + "成功退出系统" });
                }
                ConnectedInfoProvider.User = null; 
                return string.Empty;
            }
            catch (Exception ex)
            {
                ex=new ServerException("登出失败",ex);
                Log.Error(ex);
                return ex.Message;
            }
        }

        /// <summary>
        /// 根据用户ID获取员工信息
        /// </summary>
        public Employee GetEmployeeByUserId(Guid userId)
        {
            try
            {
                var query = from u in BusinessHandlerFactory.RepositoryProvider.Db.Users where u.Id==userId
                        join e in BusinessHandlerFactory.RepositoryProvider.Db.Employees on u.EmployeeId equals e.Id
                        select e;
                
                return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return this.HandleException<Employee>("根据用户编号获取员工信息失败", ex);
            }
        }

        #endregion  
        
        public IEnumerable<Business.Models.AllTax> GetAllTax(System.DateTime dtF,System.DateTime dtT,Guid salerID){
            var c=this.Queryable.Where(r=>r.Deleted==false);
            string uName = string.Empty;
            if(!salerID.Equals(Guid.Empty))
            {
                c = c.Where(r => r.Id == salerID);
                uName = c.First().Employee.Name;
            }
            var p = BusinessHandlerFactory.PurchaseOrderBusinessHandler.GetPurchaseTaxReturn(Guid.Empty, dtF, dtT);
            var s= BusinessHandlerFactory.SalesOrderBusinessHandler.GetSalerTaxManage(dtF,dtT,Guid.Empty,string.Empty);
            var p1=from i in p group i by i.TaxReturnUserName into g
                select new Business.Models.AllTax
                {
                    salerName=g.First().TaxReturnUserName,                                 
                        PNum=g.Count(),
                        PMoney=g.Sum(r=>r.TotalMoney),
                        PPayedMoney=g.Sum(r=>r.PayMoney),
                        PInvoiceMoney=g.Sum(r=>r.InvoiceMoney),
                        PIRate=g.First().Rate,
                        SNum=0,
                        PTax=g.Sum(r=>r.ReturnTax),
                        STax=0m,
                        SaleMoney=0m,
                        ReceivedMoney=0m,
                        Diff=0m,
                        IRateMoney=0m,
                        MRateMoney=0m,
                        tax = g.Sum(r => r.ReturnTax)
                };
            var s1=from i in s group i by i.EmployeeName into g
                   select new Business.Models.AllTax
                   {
                       salerName = g.First().EmployeeName,
                       PNum = 0,
                       SNum = g.Count(),
                       PMoney=0m,
                       PPayedMoney=0,
                       PTax = 0m,
                       STax = g.Sum(r => r.PayedMoney),
                       SaleMoney=g.Sum(r=>r.PayMoney),
                       ReceivedMoney=g.Sum(r=>r.ReceivedMoney),
                       Diff=(Decimal)(g.Sum(r=>r.ReceivedMoney)-g.Sum(r=>r.PayMoney)),
                       IRateMoney = g.Sum(r=>r.InvoiceMoneyR),                        
                       MRateMoney = g.Sum(r=>r.ManageMoneyR),
                       tax = -g.Sum(r => r.PayedMoney)
                   };

            var result = from i in s1.Concat(p1)
                         group i by i.salerName into g
                         select new Business.Models.AllTax
                         {
                            salerName = g.First().salerName,
                            PNum = g.Sum(r=>r.PNum),
                            SNum = g.Sum(r=>r.SNum),
                            PInvoiceMoney=g.Sum(r=>r.PInvoiceMoney),
                            PIRate=g.First().PIRate,
                            PMoney=g.Sum(r=>r.PMoney),
                            PPayedMoney=g.Sum(r=>r.PPayedMoney),
                            PTax = g.Sum(r=>r.PTax),
                            STax = g.Sum(r => r.STax),
                            tax = g.Sum(r => r.tax),
                            Diff=g.Sum(r=>r.Diff),
                            IRateMoney=g.Sum(r=>r.IRateMoney),
                            MRateMoney=g.Sum(r=>r.MRateMoney),
                            ReceivedMoney=g.Sum(r=>r.ReceivedMoney),
                            SaleMoney=g.Sum(r=>r.SaleMoney)
                         };
            return result;
        }

        public System.Collections.Generic.IEnumerable<User> GetUserByPosition(string roleName,string account,string pwd)
        {
            
            var c = this.Queryable.Include(r=>r.Employee);
            if (!string.IsNullOrEmpty(account))
                c = c.Where(u => u.Account == account && u.Pwd == pwd);

            var PosList = RepositoryProvider.Db.Roles.Where(r => r.Name.Contains(roleName));

            var Result = from i in c
                         join j in RepositoryProvider.Db.RoleWithUsers
                         on i.Id equals j.UserId
                         join k in PosList on j.RoleId equals k.Id
                         select i;
            return Result.Include(r=>r.Employee);
        }
    }
}
