using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BugsBox.Pharmacy.Notification;
using BugsBox.Common;

namespace BugsBox.Pharmacy.MonitorHost
{
    class Purchase : BaseMonitor
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
                        key = "采购单审核",
                        value = BugsBox.Pharmacy.MonitorHandlers.Purchase.采购单审核()
                    });
                    wd.Add(new Business.Models.WarningData()
                    {
                        key = "收货",
                        value = BugsBox.Pharmacy.MonitorHandlers.Purchase.收货()
                    });
                    wd.Add(new Business.Models.WarningData()
                    {
                        key = "收货验收",
                        value = BugsBox.Pharmacy.MonitorHandlers.Purchase.收货验收()
                    });
                    wd.Add(new Business.Models.WarningData()
                    {
                        key = "入库",
                        value = BugsBox.Pharmacy.MonitorHandlers.Purchase.入库提醒()
                    });
                    wd.Add(new Business.Models.WarningData()
                    {
                        key = "采购退货质管部审核",
                        value = BugsBox.Pharmacy.MonitorHandlers.Purchase.采购退货质管部审核()
                    });
                    wd.Add(new Business.Models.WarningData()
                    {
                        key = "采购退货总经理审核",
                        value = BugsBox.Pharmacy.MonitorHandlers.Purchase.采购退货总经理审核()
                    });
                    wd.Add(new Business.Models.WarningData()
                    {
                        key = "采购退货财务部审核",
                        value = BugsBox.Pharmacy.MonitorHandlers.Purchase.采购退货财务部审核()
                    });
                    wd.Add(new Business.Models.WarningData()
                    {
                        key = "采购到货数不够",
                        value = BugsBox.Pharmacy.MonitorHandlers.Purchase.采购到货数不够()
                    });


                    if (wd.Where(p => p.value > 0).Count() > 0)
                        NotificationController.NeedHandlePurchase(wd.Where(p => p.value > 0).ToArray());

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
