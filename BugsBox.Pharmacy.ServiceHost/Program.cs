using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BugsBox.Common;
using BugsBox.Pharmacy.Services;

namespace BugsBox.Pharmacy.ServiceHost
{
    static class Program
    {
        static BugsBox.Pharmacy.MonitorHost.Main monitor;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            ////启动监控
            //BugsBox.Pharmacy.MonitorHost.Main monitor = new MonitorHost.Main();
            ////monitor.Start(); 

            string mutextName = "qwertyuiol,mnbvghyuk,";

            var mutextNameFromConfig = System.Configuration.ConfigurationManager.AppSettings["MutexName"];
            if (!string.IsNullOrEmpty(mutextNameFromConfig))
            {
                mutextName = mutextNameFromConfig;
            }

            Mutex mutex = new Mutex(false, mutextName);

            if (!mutex.WaitOne(0, false))
            {
                mutex.Close();
                mutex = null;
            }
            if (mutex == null)
            {
                MessageBox.Show("服务端正在运行！", "医药连锁服务端", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                System.Windows.Forms.Application.Exit();
                return;
            }

            System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            System.Windows.Forms.Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);



            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            //从APP.CONFIG读取当前语言选择，然后设置当前语言 
            String cultureString = Culture;
            try
            {
                if (cultureString != null)
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(cultureString);
                DoStartup(args);
                //Splasher.Close();



            }
            catch (ArgumentException e)
            {
                log.Fatal(e, "Main出现异常");
                return;
            }
            finally
            {
                //NetIOFactory.CloseNetIO();
            }



        }

        static void DoStartup(string[] args)
        {
            try
            {
                System.Windows.Forms.Application.UseWaitCursor = false;
                Form f = new mainForm();
                //注册监控事件
                LoggerHelper.Instance.Warning("开始注册监控");
                ServiceContext.Instance.EndStartService += new EventHandler(Instance_EndStartService);
                ServiceContext.Instance.EndStopService += new EventHandler(Instance_EndStopService);
                LoggerHelper.Instance.Warning("结束注册监控");
                System.Windows.Forms.Application.Run(f);
            }
            catch (Exception err)
            {
                log.Fatal(err, "DoStartup出现异常");
            }
            finally
            {
                log.Information("结束DoStartup");
            }
        }

        static void Instance_EndStopService(object sender, EventArgs e)
        {

        }

        static void Instance_EndStartService(object sender, EventArgs e)
        {
            if (ServiceContext.Instance.ServiceStarted)
            {
                try
                {
                    if (monitor == null)
                    {
                        LoggerHelper.Instance.Warning("开启监控...");
                        monitor = new MonitorHost.Main();
                        monitor.Start();
                        LoggerHelper.Instance.Warning("开启监控成功");
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
            {
                log.Fatal((Exception)e.ExceptionObject, "发生无法捕获的线程异常");
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                log.Fatal(e.Exception, "发生无法捕获的线程异常");
                MessageBox.Show("发生了无法自动恢复的异常，应用程序将退出", "很抱歉", MessageBoxButtons.OK);
                System.Windows.Forms.Application.Exit();
            }
            catch { }
        }

        public static string Culture { get; set; }

        private static ILogger log = LoggerHelper.Instance;
    }
}
