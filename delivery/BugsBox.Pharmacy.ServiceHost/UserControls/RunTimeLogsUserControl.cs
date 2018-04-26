using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Common;
 

namespace BugsBox.Pharmacy.ServiceHost.UserControls
{
    /// <summary>
    /// 系统运行时日志
    /// </summary>
    public partial class RunTimeLogsUserControl : UserControl, ILogger
    {
        public RunTimeLogsUserControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;
            LoggerHelper.Instance.LoggerList.Add(this); //To Do改写Bugsbox.Common中的logs
        }

        public bool IsEnabled(LogLevel level)
        {
            return ControlValidator.IsHandleCreated(this.textBoxLogs) && !ControlValidator.IsDisposed(this.textBoxLogs);
        }
        private string GetExceptionString(Exception ex)
        {
            if (ex != null)
            {
                string exstr = "";
                exstr = string.Format("{0}.{1}.{2},\r\n", ex.Message, ex.Source, ex.StackTrace) + GetExceptionString(ex.InnerException);
                return exstr;
            }
            return ".";
        }



        public void PrintMessage(string msg)
        {
            lock (this)
            {
                Action<Control> printMessageHandler = (c) =>
                {
                    if (this.textBoxLogs.Lines.Count() > 200)
                        this.textBoxLogs.Text = string.Empty;
                    this.textBoxLogs.AppendText(msg + Environment.NewLine);
                };
                this.textBoxLogs.DoAction(printMessageHandler);
            }
           
        }

        public void Log(LogLevel level, Exception exception, string format, params object[] args)
        {
            if (DesignMode)
                return;
            if (IsEnabled(level))
            {
                string message = string.Empty;
                if (args == null || args.Length == 0)
                {
                    message = format;
                }
                else
                {
                    message = string.Format(format, args);
                }
                switch (level)
                {
                    case LogLevel.Debug:
                        if (exception == null)
                        {
                            PrintMessage(string.Format("{0}@{1},Debug:{2}.", Tag, DateTime.Now, message));
                        }
                        else
                        {
                            PrintMessage(string.Format("{0}@{1},Debug:{2},{3}", Tag, DateTime.Now, message, GetExceptionString(exception)));
                        }
                        break;
                    case LogLevel.Error:
                        if (exception == null)
                        {
                            PrintMessage(string.Format("{0}@{1},Error:{2}.", Tag, DateTime.Now, message));
                        }
                        else
                        {
                            PrintMessage(string.Format("{0}@{1},Error:{2},{3}", Tag, DateTime.Now, message, GetExceptionString(exception)));
                        }
                        break;
                    case LogLevel.Fatal:
                        if (exception == null)
                        {
                            PrintMessage(string.Format("{0}@{1},Fatal:{2}.", Tag, DateTime.Now, message));
                        }
                        else
                        {
                            PrintMessage(string.Format("{0}@{1},Fatal:{2},{3}", Tag, DateTime.Now, message, GetExceptionString(exception)));
                        }
                        break;
                    case LogLevel.Information:
                        if (exception == null)
                        {
                            PrintMessage(string.Format("{0}@{1},Info:{2}.", Tag, DateTime.Now, message));
                        }
                        else
                        {
                            PrintMessage(string.Format("{0}@{1},Info:{2},{3}", Tag, DateTime.Now, message, GetExceptionString(exception)));
                        }
                        break;
                    case LogLevel.Warning:
                        if (exception == null)
                        {
                            PrintMessage(string.Format("{0}@{1},Warning:{2}.", Tag, DateTime.Now, message));
                        }
                        else
                        {
                            PrintMessage(string.Format("{0}@{1},Warning:{2},{3}", Tag, DateTime.Now, message, GetExceptionString(exception)));
                        }
                        break;
                }
            }
        }

    }
}
