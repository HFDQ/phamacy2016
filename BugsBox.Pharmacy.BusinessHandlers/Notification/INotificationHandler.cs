using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.Notification
{
    /// <summary>
    /// 通知处理
    ///  NotificationHandlerFactory.NotificationHandler.OnUserOnLine(logonUser);
    /// </summary>
    public interface INotificationHandler
    {
        #region 用户上线事件

        /// <summary>
        /// 触发用户上线事件
        /// </summary>
        /// <param name="user"></param>
        void OnUserOnLine(User user);

        /// <summary>
        /// 用户已经上线事件
        /// </summary>
        event EventHandler<EventArgs<User>> UserOnLined;

        #endregion 

        #region 权限通知
        
        /// <summary>
        /// 触发权限改变事件
        /// </summary>
        /// <param name="role"></param>
        void OnRoleAuthorityChanged();

        /// <summary>
        /// 权限改变事件
        /// </summary>
        event EventHandler RoleAuthorityChanged;


        #endregion
    }
}
