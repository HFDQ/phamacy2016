
using log4net;
using log4net.Config;
using System;
using System.IO;

namespace MedicalInstruments.Infrastructure.Log
{
    public class Logger
    {
        private static log4net.ILog _log;

        static Logger()
        {
            var logpath = Path.Combine(Environment.CurrentDirectory, "log4net.config");
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(logpath));
            _log = LogManager.GetLogger("MedicalInstruments");
        }

        public static void Fatal(string message)
        {
            DoLog(message, LogMessageType.Fatal);
        }


        public static void Error(string message)
        {
            DoLog(message, LogMessageType.Error);
        }


        public static void Warn(string message)
        {
            DoLog(message, LogMessageType.Warn);
        }


        public static void Debug(string message)
        {
            DoLog(message, LogMessageType.Debug);
        }

        public static void Info(string message)
        {
            DoLog(message, LogMessageType.Info);
        }

        private static void DoLog(string message, LogMessageType messageType)
        {

            Console.WriteLine(message);
            switch (messageType)
            {
                case LogMessageType.Debug:
                    _log.Debug(message);
                    break;
                case LogMessageType.Info:
                    _log.Info(message);
                    break;
                case LogMessageType.Warn:
                    _log.Warn(message);
                    break;
                case LogMessageType.Error:
                    _log.Error(message);
                    break;
                case LogMessageType.Fatal:
                    _log.Fatal(message);
                    break;
            }
        }
    }

}
