using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.Notification
{
    public static class NotificationHandlerFactory
    {
        private static readonly INotificationHandler defaultNotificationHandler = 
            new DefaultNotificationHandler();

        private static INotificationHandler notificationHandler;

        public static INotificationHandler NotificationHandler
        {
            get
            {
                if (notificationHandler == null)
                {
                    return defaultNotificationHandler;
                }
                return notificationHandler;
            }
        }

        public static void SetNotificationHandler(INotificationHandler Handler)
        {
            notificationHandler = Handler;
        }
    }
}
