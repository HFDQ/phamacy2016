using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Amib.Threading;
using BugsBox.Common;
using BugsBox.Pharmacy.IServices.Notification;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Repository;
using System.Data.Entity;

namespace BugsBox.Pharmacy.Notification
{
    public static class NotificationController
    {

        readonly static SmartThreadPool smartThreadPool = new SmartThreadPool();

        #region 权限变更处理
       
        public static void OnRoleAuthorityChanged_Handle(object sender,EventArgs e)
        {
            try
            {
             
              
                var ClientContextList = NotificationClientContextManager.ListClientContext
                 .Where(c => c.OperationContext != null && c.NotificationCallback != null)
                 .ToList();
                foreach (var clientContext in ClientContextList)
                {
                    try
                    {
                        if (clientContext.OperationContext.Channel != null)
                        { 
                            var callback = clientContext.NotificationCallback;
                            smartThreadPool.QueueWorkItem(callback.RoleAuthorityChanged);
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelper.Instance.Error(ex);
                    }

                }

                    
            }
            catch (Exception ex)
            {
                ex = new Exception("通知角色权限失败", ex);
                LoggerHelper.Instance.Error(ex);
            }
        }

        #endregion 

        /// <summary>
        /// 用户上线的处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Notification_UserOnLined(object sender, EventArgs<User> e)
        {
            try
            {
                //找出已经上线的用户上下文 
                var ClientContextList = NotificationClientContextManager.ListClientContext
                    .Where(c => c.OperationContext!=null&&c.NotificationCallback!=null)
                    .Where(c => c.User.Id!= e.Value.Id&&c.NotificationCallback!=null) 
                    .ToList(); 
                foreach (var clientContext in ClientContextList)
                { 
                    try
                    {
                        if (clientContext.OperationContext.Channel!=null)
                        {
                            LoggerHelper.Instance.Warning("向" + clientContext.User.Account + "发送" + e.Value.Account + "上线通知");
                            var callback = clientContext.NotificationCallback;
                            smartThreadPool.QueueWorkItem(callback.UserOnLine, e.Value);
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelper.Instance.Error(ex);
                    }
                   
                }
                
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        public static void SayHello(string hello)
        {
            try
            {
                //找出已经上线的用户上下文 
                var ClientContextList = NotificationClientContextManager.ListClientContext
                    .Where(c => c.OperationContext!=null&&c.NotificationCallback!=null) 
                    .ToList(); 
                foreach (var clientContext in ClientContextList)
                { 
                    try
                    {
                        if (clientContext.OperationContext.Channel.State == System.ServiceModel.CommunicationState.Opened)
                        {
                            var callback = clientContext.NotificationCallback;
                            //To Do
                            callback.SayHello(hello);
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelper.Instance.Error(ex);
                    }
                   
                }
                
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        public static void DrugLock(int number)
        {
            try
            {
                //找出已经上线的用户上下文 
                var ClientContextList = NotificationClientContextManager.ListClientContext
                    .Where(c => c.OperationContext != null && c.NotificationCallback != null)
                    .ToList();
                foreach (var clientContext in ClientContextList)
                {
                    try
                    {
                        if (clientContext.OperationContext.Channel.State == System.ServiceModel.CommunicationState.Opened)
                        {
                            var callback = clientContext.NotificationCallback;
                            //To Do
                            callback.DrugLock(number);
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelper.Instance.Error(ex);
                    }

                }

            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        public static void DrugOutofStock(int number)
        {
            try
            {
                //找出已经上线的用户上下文 
                var ClientContextList = NotificationClientContextManager.ListClientContext
                    .Where(c => c.OperationContext != null && c.NotificationCallback != null)
                    .ToList();
                foreach (var clientContext in ClientContextList)
                {
                    try
                    {
                        if (clientContext.OperationContext.Channel.State == System.ServiceModel.CommunicationState.Opened)
                        {
                            var callback = clientContext.NotificationCallback;
                            //To Do
                            callback.DrugOutofStock(number);
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelper.Instance.Error(ex);
                    }

                }

            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        public static void SupplyUnitLock(int number)
        {
            try
            {
                //找出已经上线的用户上下文 
                var ClientContextList = NotificationClientContextManager.ListClientContext
                    .Where(c => c.OperationContext != null && c.NotificationCallback != null)
                    .ToList();
                foreach (var clientContext in ClientContextList)
                {
                    try
                    {
                        if (clientContext.OperationContext.Channel.State == System.ServiceModel.CommunicationState.Opened)
                        {
                            var callback = clientContext.NotificationCallback;
                            //To Do
                            callback.SupplyUnitLock(number);
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelper.Instance.Error(ex);
                    }

                }

            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        public static void PurchaseUnitLock(int number)
        {
            try
            {
                //找出已经上线的用户上下文 
                var ClientContextList = NotificationClientContextManager.ListClientContext
                    .Where(c => c.OperationContext != null && c.NotificationCallback != null)
                    .ToList();
                foreach (var clientContext in ClientContextList)
                {
                    try
                    {
                        if (clientContext.OperationContext.Channel.State == System.ServiceModel.CommunicationState.Opened)
                        {
                            var callback = clientContext.NotificationCallback;
                            //To Do
                            callback.PurchaseUnitLock(number);
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelper.Instance.Error(ex);
                    }

                }

            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        public static void NeedApproval(Business.Models.WarningData[] approvals)
        {
            try
            {
                //找出已经上线的用户上下文 
                var ClientContextList = NotificationClientContextManager.ListClientContext
                    .Where(c => c.OperationContext != null && c.NotificationCallback != null)
                    .ToList();
                foreach (var clientContext in ClientContextList)
                {
                    try
                    {
                        if (clientContext.OperationContext.Channel.State == System.ServiceModel.CommunicationState.Opened)
                        {
                            var callback = clientContext.NotificationCallback;
                            //To Do
                            callback.NeedApproval(approvals);
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelper.Instance.Error(ex);
                    }

                }

            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        public static void NeedDrugMaintain(int day)
        {
            try
            {
                //找出已经上线的用户上下文 
                var ClientContextList = NotificationClientContextManager.ListClientContext
                    .Where(c => c.OperationContext != null && c.NotificationCallback != null)
                    .ToList();
                foreach (var clientContext in ClientContextList)
                {
                    try
                    {
                        if (clientContext.OperationContext.Channel.State == System.ServiceModel.CommunicationState.Opened)
                        {
                            var callback = clientContext.NotificationCallback;
                            //To Do
                            callback.NeedDrugMaintain(day);
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelper.Instance.Error(ex);
                    }

                }

            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        public static void NeedHandledDoubtDrug(int number)
        {
            try
            {
                //找出已经上线的用户上下文 
                var ClientContextList = NotificationClientContextManager.ListClientContext
                    .Where(c => c.OperationContext != null && c.NotificationCallback != null)
                    .ToList();
                foreach (var clientContext in ClientContextList)
                {
                    try
                    {
                        if (clientContext.OperationContext.Channel.State == System.ServiceModel.CommunicationState.Opened)
                        {
                            var callback = clientContext.NotificationCallback;
                            //To Do
                            callback.NeedHandledDoubtDrug(number);
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelper.Instance.Error(ex);
                    }

                }

            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        public static void NeedHandleSale(Business.Models.WarningData[] approvals)
        {
            try
            {
                //找出已经上线的用户上下文 
                var ClientContextList = NotificationClientContextManager.ListClientContext
                    .Where(c => c.OperationContext != null && c.NotificationCallback != null)
                    .ToList();
                foreach (var clientContext in ClientContextList)
                {
                    try
                    {
                        if (clientContext.OperationContext.Channel.State == System.ServiceModel.CommunicationState.Opened)
                        {
                            var callback = clientContext.NotificationCallback;
                            //To Do
                            callback.NeedHandleSale(approvals);
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelper.Instance.Error(ex);
                    }

                }

            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        } 

        public static void NeedHandlePurchase(Business.Models.WarningData[] approvals)
        {
            try
            {
                //找出已经上线的用户上下文 
                var ClientContextList = NotificationClientContextManager.ListClientContext
                    .Where(c => c.OperationContext != null && c.NotificationCallback != null)
                    .ToList();
                foreach (var clientContext in ClientContextList)
                {
                    try
                    {
                        if (clientContext.OperationContext.Channel.State == System.ServiceModel.CommunicationState.Opened)
                        {
                            var callback = clientContext.NotificationCallback;
                            //To Do
                            callback.NeedHandlePurchase(approvals);
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelper.Instance.Error(ex);
                    }

                }

            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        public static void NeedApprovalForSales(Business.Models.NotifyData[] SalesApprovalData)
        {
            try
            {
                //找出已经上线的用户上下文 
                var ClientContextList = NotificationClientContextManager.ListClientContext
                    .Where(c => c.OperationContext != null && c.NotificationCallback != null)
                    .ToList();
                foreach (var clientContext in ClientContextList)
                {
                    try
                    {
                        if (clientContext.OperationContext.Channel.State == System.ServiceModel.CommunicationState.Opened)
                        {
                            var callback = clientContext.NotificationCallback;
                            //To Do
                            callback.NeedApprovalForSales(SalesApprovalData);
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerHelper.Instance.Error(ex);
                    }

                }

            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }
    }
}
