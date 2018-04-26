using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.Notification
{
    class DefaultNotificationHandler : INotificationHandler
    {
        #region INotificationHandler Members

        public void OnUserOnLine(Models.User user)
        {
             
        }
 

        #endregion

        #region INotificationHandler Members 

        public event EventHandler<EventArgs<Models.User>> UserOnLined;
        

        #endregion





        public void OnRoleAuthorityChanged()
        {
             
        }

        public event EventHandler RoleAuthorityChanged;
    }
}
