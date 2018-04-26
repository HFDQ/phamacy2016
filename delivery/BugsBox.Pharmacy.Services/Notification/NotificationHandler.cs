using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.Notification
{
    class NotificationHandler : INotificationHandler
    {
        #region INotificationHandler Members

        public void OnUserOnLine(Models.User user)
        {
            if (UserOnLined != null)
            {
                var e = new EventArgs<User>(user);
                UserOnLined(this, e);
            }
        }

        public event EventHandler<EventArgs<User>> UserOnLined;

        #endregion

        #region INotificationHandler Members 

        #endregion


        public void OnRoleAuthorityChanged()
        {
            if (RoleAuthorityChanged != null)
            {

                RoleAuthorityChanged(this, new EventArgs());
            }
        }

        public event EventHandler RoleAuthorityChanged;
    }
}
