using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Notification;
using BugsBox.Common;

namespace BugsBox.Pharmacy.MonitorHost
{
    class Approval : BaseMonitor
    {
        public override bool IsOver
        {
            get
            {
                return IsNeedApproval && IsCheckLockOver;
            }
            set
            {
                value = IsNeedApproval && IsCheckLockOver;
            }
        }

        private bool IsNeedApproval { get; set; }
        private bool IsCheckLockOver { get; set; }

        public override void Start(object source, System.Timers.ElapsedEventArgs e)
        {
            aTimer.Stop();

            IsNeedApproval = false;
            IsCheckLockOver = true;
            Thread thread1 = new Thread(NeedApproval);
            thread1.Start(callBackDelegate);

            //Thread t_checklock = new Thread(CheckLock);
            //t_checklock.Start(callBackDelegate);
        }

        private void NeedApproval(object o)
        {
            lock (this)
            {
                try
                {
                    List<Business.Models.WarningData> needApproval = new List<Business.Models.WarningData>();
                    needApproval.Add(new Business.Models.WarningData() { key = ApprovalType.DrugInfoApproval.ToString(), value = BugsBox.Pharmacy.MonitorHandlers.Approval.GetNeedApprovalNumber((int)ApprovalType.DrugInfoApproval) });
                    needApproval.Add(new Business.Models.WarningData() { key = ApprovalType.DrugInfoEditApproval.ToString(), value = BugsBox.Pharmacy.MonitorHandlers.Approval.GetNeedApprovalNumber((int)ApprovalType.DrugInfoEditApproval) });

                    needApproval.Add(new Business.Models.WarningData() { key = ApprovalType.DrugInfoLockApproval.ToString(), value = BugsBox.Pharmacy.MonitorHandlers.Approval.GetNeedApprovalNumber((int)ApprovalType.DrugInfoLockApproval) });

                    needApproval.Add(new Business.Models.WarningData() { key = ApprovalType.PurchaseUnitApproval.ToString(), value = BugsBox.Pharmacy.MonitorHandlers.Approval.GetNeedApprovalNumber((int)ApprovalType.PurchaseUnitApproval) });

                    needApproval.Add(new Business.Models.WarningData() { key = ApprovalType.PurchaseUnitEditApproval.ToString(), value = BugsBox.Pharmacy.MonitorHandlers.Approval.GetNeedApprovalNumber((int)ApprovalType.PurchaseUnitEditApproval) });

                    needApproval.Add(new Business.Models.WarningData() { key = ApprovalType.PurchaseUnitLockApproval.ToString(), value = BugsBox.Pharmacy.MonitorHandlers.Approval.GetNeedApprovalNumber((int)ApprovalType.PurchaseUnitLockApproval) });

                    needApproval.Add(new Business.Models.WarningData() { key = ApprovalType.SupplyUnitApproval.ToString(), value = BugsBox.Pharmacy.MonitorHandlers.Approval.GetNeedApprovalNumber((int)ApprovalType.SupplyUnitApproval) });

                    needApproval.Add(new Business.Models.WarningData() { key = ApprovalType.SupplyUnitEditApproval.ToString(), value = BugsBox.Pharmacy.MonitorHandlers.Approval.GetNeedApprovalNumber((int)ApprovalType.SupplyUnitEditApproval) });

                    needApproval.Add(new Business.Models.WarningData() { key = ApprovalType.SupplyUnitLockApproval.ToString(), value = BugsBox.Pharmacy.MonitorHandlers.Approval.GetNeedApprovalNumber((int)ApprovalType.SupplyUnitLockApproval) });

                    if (needApproval.Where(p => p.value > 0).Count() > 0)
                        NotificationController.NeedApproval(needApproval.Where(p => p.value > 0).ToArray());

                    IsNeedApproval = true;
                    CallBackDelegate cbd = o as CallBackDelegate;
                    cbd();
                }
                catch (Exception ex)
                {
                    IsNeedApproval = true;
                    LoggerHelper.Instance.Error(ex);
                }
            }
        }
    }
}
