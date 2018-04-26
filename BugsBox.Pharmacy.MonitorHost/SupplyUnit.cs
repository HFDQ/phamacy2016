using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BugsBox.Pharmacy.Notification;
using BugsBox.Common;

namespace BugsBox.Pharmacy.MonitorHost
{
    class SupplyUnit : BaseMonitor
    {
        public override bool IsOver
        {
            get
            {
                return IsUpdateOver && IsCheckLockOver;
            }
            set
            {
                value = IsUpdateOver && IsCheckLockOver;
            }
        }

        private bool IsUpdateOver { get; set; }
        private bool IsCheckLockOver { get; set; }

        public override void Start(object source, System.Timers.ElapsedEventArgs e)
        {
            aTimer.Stop();

            IsUpdateOver = false;
            IsCheckLockOver = false;
            Thread t_update = new Thread(Update);
            t_update.Start(callBackDelegate);

            Thread t_checklock = new Thread(CheckLock);
            t_checklock.Start(callBackDelegate);
        }

        private void Update(object o)
        {
            lock (this)
            {
                try
                {
                    DateTime thisTime = DateTime.Now;
                    //0点0分
                    //if (thisTime.Hour == 0 && thisTime.Minute == 0)
                    //{
                    BugsBox.Pharmacy.MonitorHandlers.SupplyUnit.UpdateValid();
                    //}

                    IsUpdateOver = true;
                    CallBackDelegate cbd = o as CallBackDelegate;
                    cbd();
                }
                catch (Exception ex)
                {
                    IsUpdateOver = true;
                    LoggerHelper.Instance.Error(ex);
                }
            }
        }

        private void CheckLock(object o)
        {
            lock (this)
            {
                try
                {
                    int num = BugsBox.Pharmacy.MonitorHandlers.SupplyUnit.LockCount();
                    if (num > 0)
                    {
                        NotificationController.SupplyUnitLock(num);
                    }
                    IsCheckLockOver = true;
                    CallBackDelegate cbd = o as CallBackDelegate;
                    cbd();
                }
                catch(Exception ex)
                {
                    IsCheckLockOver = true;
                    LoggerHelper.Instance.Error(ex);
                }
            }
        }
    }
}
