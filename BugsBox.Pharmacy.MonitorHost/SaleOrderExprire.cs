using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BugsBox.Pharmacy.Notification;
using BugsBox.Common;

namespace BugsBox.Pharmacy.MonitorHost
{
    class SaleOrderExprire:BaseMonitor
    {
        public override bool IsOver
        {
            get
            {
                return IsDoOver;
            }
            set
            {
                value = IsDoOver;
            }
        }

        private bool IsDoOver { get; set; }

        public override void Start(object source, System.Timers.ElapsedEventArgs e)
        {
            aTimer.Stop();

            IsDoOver = false;

            Thread t_update = new Thread(Do);
            t_update.Start(callBackDelegate);
        }

        private void Do(object o)
        {
            lock (this)
            {
                try
                {
                    BugsBox.Pharmacy.MonitorHandlers.SaleOrderExpire.updateExpire();
                    CallBackDelegate cbd = o as CallBackDelegate;
                    cbd();
                }
                catch (Exception ex)
                {
                    LoggerHelper.Instance.Error(ex);
                    IsDoOver = true;
                }
            }
        }
    }
}
