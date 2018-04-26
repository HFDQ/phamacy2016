using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using BugsBox.Common;
using BugsBox.Pharmacy.IServices;
using BugsBox.Pharmacy.IServices.Notification;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Notification;

namespace BugsBox.Pharmacy.Services
{
    /// <summary>
    /// 通知服务
    /// </summary>
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.PerSession)]
    public class PharmacyNotification : IPharmacyNotification
    { 
        #region IPharmacyNotification Members

        public void RegisterClientNotification(User user)
        {
            try
            {
                NotificationClientContextManager.RegisterNotificationClientContext(user, OperationContext.Current);
            }
            catch (Exception ex)
            {
                ex = new Exception("为用户注册通知服务失败", ex);
                LoggerHelper.Instance.Error(ex);
            }
        }

        public void CloseClientNotification(User user)
        {
            try
            {
                NotificationClientContextManager.RemoveNotification(user);
                NotificationClientContextManager.RemoveNotification(OperationContext.Current);
            }
            catch (Exception ex)
            {
                ex = new Exception("为用户注销通知服务失败", ex);
                LoggerHelper.Instance.Error(ex);
            }
        }

        #endregion
    }

}
