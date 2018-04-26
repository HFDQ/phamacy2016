using System;

namespace BugsBox.Application.Core
{
    /// <summary>
    /// 仓储异常
    /// </summary>
    public class RepositoryException : AppException
    {
        public override string Level
        {
            get { return "仓储"; }
        }

        public RepositoryException(string message)
            : base(message)
        {
        }

        public RepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public RepositoryException()
            : base()
        {
        }
    }
}