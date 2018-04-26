using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BugsBox.Pharmacy.Notification;
using BugsBox.Common;

namespace BugsBox.Pharmacy.MonitorHost
{
    class Drug : BaseMonitor
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

                    BugsBox.Pharmacy.MonitorHandlers.DrugMaintain.CreateMaintainRecord();
                    BugsBox.Pharmacy.MonitorHandlers.DrugMaintain.CreateDrugMantainImpt();
                    BugsBox.Pharmacy.MonitorHandlers.DrugMaintain.CreateDrugMantainInst();
                    BugsBox.Pharmacy.MonitorHandlers.DrugMaintain.CreateDrugMantainZYYP();
                    BugsBox.Pharmacy.MonitorHandlers.DrugMaintain.CreateDrugMantainZYC();
                    BugsBox.Pharmacy.MonitorHandlers.DrugMaintain.SetDrugInventoryRecordOutValid();

                    IsUpdateOver = true;
                    CallBackDelegate cbd = o as CallBackDelegate;
                    cbd();
                }
                catch (Exception ex)
                {
                    LoggerHelper.Instance.Error(ex);
                    IsUpdateOver = true;
                }
            }
        }

        private void CheckLock(object o)
        {
            lock (this)
            {
                try
                {
                    int num = BugsBox.Pharmacy.MonitorHandlers.Drug.LockCount();
                    if (num > 0)
                    {
                        NotificationController.DrugLock(num);
                    }
                    num = BugsBox.Pharmacy.MonitorHandlers.Drug.GetDrugInfoForOutofStockNumber();
                    if (num > 0)
                    {
                        NotificationController.DrugOutofStock(num);
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
