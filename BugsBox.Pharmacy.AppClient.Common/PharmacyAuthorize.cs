using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.AppClient.Common
{
    /// <summary>
    /// 客户端授权
    /// </summary>
    public static class PharmacyAuthorize
    {
        private static readonly List<string> authorityKeys = new List<string>();

        public static List<string> AuthorityKeys
        {
            get { return authorityKeys; }
        }

        /// <summary>
        /// 设置此客户端当前的授权Keys
        /// 在登录成功后根据用户编号去服务器端获取并调用此函数设置
        /// </summary>
        /// <param name="authorityModulesKeys"></param>
        public static void SetAuthorityKeys(List<string> authorityModulesKeys)
        {
            lock (authorityKeys)
            {
                authorityKeys.Clear();
                if (authorityModulesKeys != null)
                {
                    authorityKeys.AddRange(authorityModulesKeys);
                }
            }
        }

        /// <summary>
        /// 根据权限键进行检查权限
        /// Demo PharmacyAuthorize.ValidateAuthorize(ModuleKeys.FORM_DrugInfoImport);
        /// </summary>
        /// <param name="moduleKey"></param>
        /// <returns></returns>
        public static bool ValidateAuthorize(string moduleKey)
        {
            lock (authorityKeys)
            {
                if (AuthorityKeys == null)
                    return false;
                return AuthorityKeys.Contains(moduleKey);
            }
        }
    }
}
