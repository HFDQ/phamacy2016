using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;
using BugsBox.Common;

namespace BugsBox.Pharmacy.AppClient.Common
{
    /// <summary>
    /// 客户端上下文
    /// </summary>
    public class AppClientContext
    {

        public static User currentUser = null;

        /// <summary>
        /// 当前用户
        /// </summary>
        public static User CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
                if (currentUser != null)
                {
                    ServicesProvider.Instance.RegisterPharmacyNotificationChannel();
                    ServicesProvider.Instance.PharmacyNotificationChannel.RegisterClientNotification(currentUser); 
                    //设置权限
                    try
                    {
                        List<string> authorityKeys = null;
                        string message;
                        authorityKeys = ServicesProvider.Instance.PharmacyDatabaseService
                            .GetAuthorityKeys(out message, value.Id)
                            .ToList();
                        
                            ServicesProvider.Instance.PharmacyNotificationCallback.AuthorityChanged -= new EventHandler<EventArgs>(PharmacyNotificationCallback_AuthorityChanged);
                      
                        PharmacyAuthorize.SetAuthorityKeys(authorityKeys);
                        ServicesProvider.Instance.PharmacyNotificationCallback.AuthorityChanged += new EventHandler<EventArgs>(PharmacyNotificationCallback_AuthorityChanged);
                    }
                    catch (Exception ex)
                    {
                        LoggerHelper.Instance.Error(ex);
                    }
                }
                else
                {
                    PharmacyAuthorize.SetAuthorityKeys(null);
                }
            }
        }

        static void PharmacyNotificationCallback_AuthorityChanged(object sender, EventArgs e)
        {
            try
            {
                ServicesProvider.Instance.PharmacyNotificationCallback.AuthorityChanged -= new EventHandler<EventArgs>(PharmacyNotificationCallback_AuthorityChanged);
                List<string> authorityKeys = null;
                string message;
                //
               // LoggerHelper.Instance.Warning("接受到权限变更通知");
                authorityKeys = ServicesProvider.Instance.PharmacyDatabaseService
                    .GetAuthorityKeys(out message, currentUser.Id)
                    .ToList();
                PharmacyAuthorize.SetAuthorityKeys(authorityKeys);
                ServicesProvider.Instance.PharmacyNotificationCallback.AuthorityChanged += new EventHandler<EventArgs>(PharmacyNotificationCallback_AuthorityChanged);
            }
            catch (Exception ex)
            {
                ex = new Exception("接受到权限变更通知处理失败");
                LoggerHelper.Instance.Error(ex);
            }
           
        }

        /// <summary>
        /// wcf服务对象
        /// </summary>
        public static IPharmacyDatabaseService PharmacyDatabaseService
        {
            get
            {
                return ServicesProvider.Instance.PharmacyDatabaseService;
            }
        }

        /// <summary>
        /// 客户端配置对象
        /// </summary>
        public static PharmacyClientConfig Config
        {
            get
            {
                return PharmacyClientConfig.Config;
            }
        }

        /// <summary>
        /// 应用配置对象
        /// </summary>
        public static AppConfig ApplicationConfig
        {
            get
            {
                return AppConfig.Config;
            }
        }
 
    }
}
