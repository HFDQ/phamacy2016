using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using BugsBox.Pharmacy.IServices;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.Notification
{
    /// <summary>
    /// 通知的客户端上下文接口
    /// </summary>
    public interface INotificationClientContext:IDisposable
    {
        /// <summary>
        /// 客户端用户
        /// </summary>
        User User { get; set; }

        /// <summary>
        /// 授的权限Keys
        /// </summary>
        List<string> AuthoritedKeys { get; set; }

        /// <summary>
        /// Wcf上下文
        /// </summary>
        OperationContext OperationContext { get; set; }

        /// <summary>
        /// 回调对象
        /// </summary>
        IPharmacyNotificationCallback NotificationCallback { get;}
     }

    /// <summary>
    /// 通知的客户端上下文对象的创建工厂
    /// </summary>
    public interface INotificationClientContextFactory
    {
        INotificationClientContext Create();
    }
}
