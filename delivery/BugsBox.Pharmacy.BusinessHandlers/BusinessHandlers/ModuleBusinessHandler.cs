using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Repository;
using System.Data.Entity;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class ModuleBusinessHandler
    {

        #region 权限检测相关

        /// <summary>
        /// 获取对应用户编号的权限Keys
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<string> GetAuthorityKeys(Guid userId)
        {
            try
            {  
               var rIds=
                   BusinessHandlerFactory.RoleWithUserBusinessHandler.Fetch(
                        r => r.UserId == userId)
                        .Select(r=>r.RoleId)
                        .ToList(); //找出用户的角色们
                var moduleWithRoles = BusinessHandlerFactory.ModuleWithRoleBusinessHandler
                    .Fetch(mwr => rIds.Any(rid=>rid==mwr.RoleId))
                    .Select(mwr=>mwr.ModuleId)
                    .ToList();//找出角色位对应的模块与角色映射
                List<string> keys =
                    this.Fetch(m => moduleWithRoles.Contains(m.Id))
                        .Select(mwr => mwr.AuthKey)
                        .ToList();
                return keys;
            }
            catch (Exception ex)
            {
                return this.HandleException<IEnumerable<string>>("获取对应用户编号的权限键失败", ex);
            }
        }

        #endregion 
    }
}
