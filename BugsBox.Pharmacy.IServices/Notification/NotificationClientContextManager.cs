using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using BugsBox.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Notification;

namespace BugsBox.Pharmacy.IServices.Notification
{
    /// <summary>
    /// 通知客户端的上下文管理
    /// 静态类
    /// </summary>
    public static class NotificationClientContextManager
    {
        public static INotificationClientContextFactory NotificationClientContextFactory { get; set; }

        public static readonly List<INotificationClientContext> ListClientContext = new List<INotificationClientContext>();

        /// <summary>
        /// 为某用户注册上下文
        /// </summary>
        /// <param name="user"></param>
        /// <param name="perationContext"></param>
        public static void RegisterNotificationClientContext(User user, OperationContext perationContext)
        {
            try
            {
                RemoveNotification(user);
                if (NotificationClientContextFactory== null)
                {
                    throw new ArgumentNullException("通知的客户端上下文对象的创建工厂对象不可为空");
                }
                var clientContext = NotificationClientContextFactory.Create();
                clientContext.OperationContext = perationContext; 
                clientContext.User = user;                
                ListClientContext.Add(clientContext);
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        static void Channel_Closed(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 移除上下文
        /// </summary>
        /// <param name="user"></param>
        public static void RemoveNotification(User user)
        {
            try
            {
                if (user != null && user.Id != Guid.Empty)
                {
                    var context = ListClientContext.FirstOrDefault(c => c.User.Id == user.Id);
                    if (context != null)
                    {
                        context.Dispose();
                    }
                    ListClientContext.Remove(context);
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        /// <summary>
        /// 关闭OperationContext
        /// </summary>
        /// <param name="context"></param>
        private static void Close(OperationContext context)
        {
            try
            {

                if (context != null)
                {
                    context.Channel.Close();
                    context = null;
                }

            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        /// <summary>
        /// 移除上下文
        /// </summary> 
        /// <param name="perationContext"></param>
        public static void RemoveNotification(OperationContext perationContext)
        {
            try
            {
                if (perationContext != null)
                {
                    var context = ListClientContext.FirstOrDefault(c => c.OperationContext == perationContext);
                    if (context != null)
                    {
                        context.Dispose();
                    }
                    Close(perationContext);
                    ListClientContext.Remove(context);
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        /// <summary>
        /// 清除所有Context
        /// </summary>
        public static void Clear()
        {
            try
            {
                foreach (var item in ListClientContext)
                {
                    try
                    {
                        item.Dispose();
                    }
                    catch (Exception ex)
                    {
                        LoggerHelper.Instance.Error(ex);
                    }
                }
                ListClientContext.Clear();
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }
    }
}
