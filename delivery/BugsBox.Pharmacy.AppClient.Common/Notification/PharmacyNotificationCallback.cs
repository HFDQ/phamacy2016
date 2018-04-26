using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Amib.Threading;
using BugsBox.Common;
using BugsBox.Pharmacy.AppClient.NS;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.Common.Notification
{
    public class PharmacyNotificationCallback : IPharmacyNotificationCallback
    {
        readonly static SmartThreadPool smartThreadPool = new SmartThreadPool();
        #region IPharmacyNotificationCallback Members

        public void UserOnLine(User user)
        {
            LoggerHelper.Instance.Warning(user.Account + "上线了");
            try
            {
                smartThreadPool.QueueWorkItem(OnUserOnLined, new EventArgs<User>(user)); 
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
           
        }

        public event EventHandler<EventArgs<User>> UserOnLined;

        /// <summary>
        /// 触发用户上线事件
        /// </summary>
        /// <param name="e"></param>
        protected void OnUserOnLined(EventArgs<User> e)
        {
            try
            {
                if (UserOnLined != null)
                {
                    UserOnLined(this, e);
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }

        }

        #endregion

        public void test(string a)
        {
            
        }

        public void SayHello(string hello)
        {
            if (SayedHello != null)
            {
                SayedHello(this,new EventArgs<string>(hello));
                LoggerHelper.Instance.Warning(hello);
            }
        }

        public event EventHandler<EventArgs<string>> SayedHello;


        public void DrugLock(int number)
        {
            if (DrugLocked != null)
            {
                DrugLocked(this, new EventArgs<int>(number));
            }
        }
        public event EventHandler<EventArgs<int>> DrugLocked;

        public void SupplyUnitLock(int number)
        {
            if (SupplyUnitLocked != null)
            {
                SupplyUnitLocked(this, new EventArgs<int>(number));
            }
        }
        public event EventHandler<EventArgs<int>> SupplyUnitLocked;
        public void PurchaseUnitLock(int number)
        {
            if (PurchaseUnitLocked != null)
            {
                PurchaseUnitLocked(this, new EventArgs<int>(number));
            }
        }
        public event EventHandler<EventArgs<int>> PurchaseUnitLocked;
        

        public void NeedApproval(Business.Models.WarningData[] approvals)
        {
            if (NeedApprovaled != null)
            {
                NeedApprovaled(this, new EventArgs<Business.Models.WarningData[]>(approvals));
            }
        }
        public event EventHandler<EventArgs<Business.Models.WarningData[]>> NeedApprovaled;
        public void NeedDrugMaintain(int day)
        {
            if (NeedDrugMaintained != null)
            {
                NeedDrugMaintained(this, new EventArgs<int>(day));
            }
        }
        public event EventHandler<EventArgs<int>> NeedDrugMaintained;




        public void NeedHandledDoubtDrug(int number)
        {
            if (NeedHandledDoubtDruged != null)
            {
                NeedHandledDoubtDruged(this, new EventArgs<int>(number));
            }
        }
        public event EventHandler<EventArgs<int>> NeedHandledDoubtDruged;


        public void NeedHandleSale(Business.Models.WarningData[] approvals)
        {
            if (NeedHandleSaleed != null)
            {
                NeedHandleSaleed(this, new EventArgs<Business.Models.WarningData[]>(approvals));
            }
        }

        public event EventHandler<EventArgs<Business.Models.WarningData[]>> NeedHandleSaleed;


        public void NeedHandlePurchase(Business.Models.WarningData[] approvals)
        {
            if (NeedHandlePurchaseed != null)
            {
                NeedHandlePurchaseed(this, new EventArgs<Business.Models.WarningData[]>(approvals));
            }
        }
        public event EventHandler<EventArgs<Business.Models.WarningData[]>> NeedHandlePurchaseed;


        public void DrugOutofStock(int number)
        {
            if (DrugOutofStocked != null)
            {
                DrugOutofStocked(this, new EventArgs<int>(number));
            }
        }
        public event EventHandler<EventArgs<int>> DrugOutofStocked;

        public event EventHandler<EventArgs> AuthorityChanged = delegate { };

        public void RoleAuthorityChanged()
        {
            if (AuthorityChanged != null)
            {
                AuthorityChanged(this, new EventArgs());
            }
        }
    }
}
