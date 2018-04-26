using System;

namespace BugsBox.Application.Core
{
    /// <summary>
    /// 业务逻辑
    /// </summary>
    public class BusinessException : AppException
    {
        public override string Level
        {
            get { return "业务逻辑"; }
        }

        public BusinessException(string message)
            : base(message)
        {
        }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public BusinessException()
            : base()
        {
        }
    }
}