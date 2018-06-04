using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BugsBox.Application.Core;
using BugsBox.Common;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.AppClient.UI.Forms.Sys;
using System.Configuration;
using System.IO;

namespace BugsBox.Pharmacy.AppClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {



            string mutextName = "qwaaaaaertyuiol,mnbvghyuk,";

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
                MessageBox.Show("医药连锁客户端正在运行！", "医药连锁客户端", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                System.Windows.Forms.Application.Exit();
                return;
            }


            System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

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
                System.Windows.Forms.Application.ApplicationExit += Application_ApplicationExit;
                Form f = new Login();

                BugsBoxApplication.Instance.Init();
                System.Windows.Forms.Application.Run(f);
                InstallGAC();
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
        /// <summary>
        /// 安装GAC程序集
        /// </summary>
        static void InstallGAC()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lib");

            path = Path.Combine(path, "FastReport");

            var destDir = @"C:\Windows\Microsoft.NET\assembly\GAC_MSIL";
            var destFile = "";
            foreach (var file in Directory.GetFiles(path, "FastReport.*", SearchOption.AllDirectories))
            {
                destFile = file.Replace(path, destDir);
                if (!Directory.Exists(Path.GetDirectoryName(destFile)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(destFile));
                }
                if (!File.Exists(destFile))
                {
                    File.Copy(file, destFile, true);
                }
            }

        }
        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            ServicesProvider.Instance.DisconnectServer();
            System.Windows.Forms.Application.ExitThread();
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
                ServicesProvider.Instance.DisconnectServer();
                System.Windows.Forms.Application.Exit();
            }
            catch { }
        }

        public static string Culture { get; set; }

        private static ILogger log = LoggerHelper.Instance;
    }
}
