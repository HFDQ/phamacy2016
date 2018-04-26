using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using BugsBox.Common;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Pharmacy.IServices;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.Notification
{
    class NotificationClientContext : INotificationClientContext
    {
        public NotificationClientContext()
        {
           
        }

        #region INotificationClientContext Members

        public User User { get; set; }

        public List<string> AuthoritedKeys { get; set; }

        public OperationContext OperationContext { get; set; }

        private IPharmacyNotificationCallback notificationCallback;

        public IPharmacyNotificationCallback NotificationCallback 
        {
            get
            {
                if(OperationContext==null)return null;
                if (notificationCallback == null)
                {
                    notificationCallback = OperationContext.GetCallbackChannel<IPharmacyNotificationCallback>();
                }
                return notificationCallback; 
            }
            set
            {
                notificationCallback = value;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                if (OperationContext != null && OperationContext.Channel!=null)
                { 
                    OperationContext.Channel.Close();
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
            
        }

        #endregion 
 
    }

    public class NotificationClientContextFactory : INotificationClientContextFactory
    {
        #region INotificationClientContextFactory Members

        public INotificationClientContext Create()
        {
            try
            {
                INotificationClientContext context = new NotificationClientContext();
                return context;
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
                return default(INotificationClientContext);
            }
        }

        #endregion
    }
}
