using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Notification;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class RoleWithUserBusinessHandler
    {
        /// <summary>
        /// 根据UserId 和RoleID 获取RoleWithUser 
        /// </summary>
        /// <param name="pDepartmentId"></param>
        /// <returns></returns>
        public IEnumerable<RoleWithUser> GetRoleWithUserInfo(Guid UserID,Guid RoleId)
        {
            try
            {
                return this.Fetch(d => d.UserId == UserID && d.RoleId == RoleId).ToList();

            }
            catch (Exception ex)
            { 
                return this.HandleException<IEnumerable<RoleWithUser>>("根据UserId 和RoleID获取GetRoleWithUserInfo出错", ex);
            }
        }

        public override void Delete(Guid id)
        {
            try
            {
                var t = this.Get(id);
                if (t != null)
                {
                    repository.Remove(t);
                }
            }
            catch (Exception ex)
            {
                this.HandleException("删除用户对应用角色失败", ex);
            }
            //真删除
        }

        public override void Add(RoleWithUser value)
        {
            try
            {
                base.Add(value);
                NotificationHandlerFactory.NotificationHandler.OnRoleAuthorityChanged();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
           
        }

        public override bool Add(RoleWithUser value, out string msg)
        {
            msg = string.Empty;
            try
            {
                return base.Add(value, out msg);
                NotificationHandlerFactory.NotificationHandler.OnRoleAuthorityChanged();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return false;
            }
        
        }

        public override bool Delete(Guid id, out string msg)
        {
            msg = string.Empty;
            try
            {
              
                var t = this.Get(id);
                if (t != null)
                {
                    repository.Remove(t);
                    this.Save();
                    NotificationHandlerFactory.NotificationHandler.OnRoleAuthorityChanged();
                    return true;
                }
                msg = "用户对应用角色不存在";
                return false;
            }
            catch (Exception ex)
            {
                this.HandleException("删除用户对应用角色失败", ex);
                return false;
            }
            //真删除
        }

        public System.Collections.Generic.IEnumerable<Business.Models.RoleWithModuleModel> GetRolewithModule()
        {
            var m = RepositoryProvider.Db.Modules.Where(r => r.Deleted == false);
            var c = from i in m
                    join j in RepositoryProvider.Db.ModuleWithRoles.Where(r=>r.Deleted==false)
                        on i.Id equals j.ModuleId                        
                    join k in RepositoryProvider.Db.Roles.Where(r=>r.Deleted==false)
                    on j.RoleId equals k.Id
                    where k.Deleted==false
                    select new Business.Models.RoleWithModuleModel
                    {
                        ModuleAuthKey=i.AuthKey,
                        ModuleName=i.Name,
                        RoleCode=k.Code,
                        RoleDescription=k.Description,
                        RoleName=k.Name
                    };
            return c;
        }

        public System.Collections.Generic.IEnumerable<Business.Models.RoleWithUserModel> GetRolewithUser()
        {
            var c = from i in RepositoryProvider.Db.Roles.Where(r=>r.Deleted==false)
                    join j in RepositoryProvider.Db.RoleWithUsers.Where(r=>r.Deleted==false)
                      on i.Id equals j.RoleId                      
                    join k in RepositoryProvider.Db.Users.Where(r=>r.Deleted==false)
                    on j.UserId equals k.Id
                    join l in RepositoryProvider.Db.Employees.Where(r=>r.Deleted==false)
                    on k.EmployeeId equals l.Id
                    select new Business.Models.RoleWithUserModel
                    {
                        EmployeeName=l.Name,
                        Password=k.Pwd,
                        RoleCode=i.Code,
                        RoleDescription=i.Description,
                        RoleName=i.Name,
                        UserAcount=k.Account
                    };
            return c;
        }

    }
}
