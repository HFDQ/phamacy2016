using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace BugsBox.Pharmacy.MonitorHost
{
    abstract class BaseMonitor
    {
        public delegate void CallBackDelegate();
        public CallBackDelegate callBackDelegate;
        public System.Timers.Timer aTimer;
        

        public BaseMonitor()
        {
            callBackDelegate = CallBack;            
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(Start);  //到达时间的时候执行事件

            aTimer.Interval =200000;        //轮询时间2个小时

            aTimer.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；             
            aTimer.Enabled = true; //是否执行System.Timers.Timer.Elapsed事件；
        }

        public virtual bool IsOver { get; set; }

        public virtual void Start(object source, System.Timers.ElapsedEventArgs e) { }

        public void CallBack() {
            if (IsOver)
                aTimer.Start();
        }
    }
}
