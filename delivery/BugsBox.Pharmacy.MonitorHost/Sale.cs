using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BugsBox.Pharmacy.Notification;
using BugsBox.Common;

namespace BugsBox.Pharmacy.MonitorHost
{
    class Sale : BaseMonitor
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
                    List<Business.Models.WarningData> wd = new List<Business.Models.WarningData>();
                    wd.Add(new Business.Models.WarningData()
                    {
                        key = "销售单审核",
                        value = BugsBox.Pharmacy.MonitorHandlers.Sale.GetNeedCheckOrder()
                    });
                    wd.Add(new Business.Models.WarningData()
                    {
                        key = "拣货",
                        value = BugsBox.Pharmacy.MonitorHandlers.Sale.GetNeedTake()
                    });

                    wd.Add(new Business.Models.WarningData()
                    {
                        key = "拣货核查",
                        value = BugsBox.Pharmacy.MonitorHandlers.Sale.GetNeedCheckChuKu()
                    });
                    wd.Add(new Business.Models.WarningData()
                    {
                        key = "配送",
                        value = BugsBox.Pharmacy.MonitorHandlers.Sale.GetNeedPeiSong()
                    });
                    wd.Add(new Business.Models.WarningData()
                    {
                        key = "销退销售员审核",
                        value = BugsBox.Pharmacy.MonitorHandlers.Sale.GetNeed_XT_XSY_Check()
                    });
                    wd.Add(new Business.Models.WarningData()
                    {
                        key = "销退营业部审核",
                        value = BugsBox.Pharmacy.MonitorHandlers.Sale.GetNeed_XT_YYB_Check()
                    });
                    wd.Add(new Business.Models.WarningData()
                    {
                        key = "销退质管部审核",
                        value = BugsBox.Pharmacy.MonitorHandlers.Sale.GetNeed_XT_ZGB_Check()
                    });

                    if (wd.Where(p => p.value > 0).Count() > 0)
                        NotificationController.NeedHandleSale(wd.Where(p => p.value > 0).ToArray());

                    IsDoOver = true;
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
