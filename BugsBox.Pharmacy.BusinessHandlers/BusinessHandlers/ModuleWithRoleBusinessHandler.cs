using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using Omu.ValueInjecter;
using BugsBox.Pharmacy.Notification;
namespace BugsBox.Pharmacy.BusinessHandlers
{
    partial class ModuleWithRoleBusinessHandler
    {
        /// <summary>
        /// 根据角色编号获取该角色对应的模块与角色的映射
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<ModuleWithRole> GetModuleWithRolesByRoleId(Guid roleId)
        {
            try
            {
                return this.Fetch(mwr => mwr.RoleId == roleId)
                    .ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<ModuleWithRole>>("根据角色编号获取该角色对应的模块与角色的映射失败", ex);
            }
        }

        /// <summary>
        ///  根据模块编号获取该模块对应的模块与角色的映射
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public List<ModuleWithRole> GetModuleWithRolesByModuleId(Guid moduleId)
        {
            try
            {
                return this.Fetch(mwr => mwr.ModuleId == moduleId)
                    .ToList();
            }
            catch (Exception ex)
            {
                return this.HandleException<List<ModuleWithRole>>("根据模块编号获取该模块对应的模块与角色的映射失败", ex);
            }
        }

        /// <summary>
        /// 根据角色,模块分类,要授权的模块编号位对角色进行模块授权
        /// </summary>
        /// <returns></returns>
        public bool AuthModuleWithRoleCatetoryAuthModuleIds(Role role, ModuleCatetory catetory, List<Guid> authModuleIds)
        {
            try
            {
                if (role == null)
                {
                    throw new NullReferenceException("角色不可为空");
                }
                if (catetory == null)
                {
                    throw new NullReferenceException("模块分类不可为空");
                }
                if (authModuleIds == null)
                {
                    throw new NullReferenceException("要授权的模块编号不可为空");
                }
                var currentModuleWithRole =
                    this.Fetch(mwr => mwr.RoleId == role.Id && mwr.Module.ModuleCatetoryId == catetory.Id)
                    .ToList();
                foreach (var moduleWithRole in currentModuleWithRole)
                {
                    this.Delete(moduleWithRole.Id); 
                }
                this.Save();//提交变更 
                foreach (var moduleId in authModuleIds)
                {
                    this.Add(new ModuleWithRole
                    {
                        ModuleId = moduleId
                        ,RoleId=role.Id
                    });
                }
                this.Save();//提交变更                
                NotificationHandlerFactory.NotificationHandler.OnRoleAuthorityChanged();
                return true;
            }
            catch (Exception ex)
            {
                return this.HandleException<bool>("根据角色,模块分类,要授权的模块编号位对角色进行模块授权失败", ex);
            }
        }


    }
}
