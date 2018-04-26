using System;

namespace BugsBox.Application.Core
{
    public class AppException : Exception
    {
        public AppException(string message)
            : base(message)
        {
        }

        public AppException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public AppException()
            : base()
        {
        }

        // ReSharper disable InconsistentNaming
        private const string _Level = "应用程序";
        // ReSharper restore InconsistentNaming

        public virtual string Level
        {
            get { return _Level; }
        }

        public override string Message
        {
            get
            {
                string level = Level;
                string msg = base.Message;
                level = level ?? _Level;
                msg = msg ?? "未知";
                return string.Format("{0}:{1}", Level, base.Message);
            }
        }
    }
}