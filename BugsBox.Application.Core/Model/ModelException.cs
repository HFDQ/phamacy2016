using System;

namespace BugsBox.Application.Core
{
    public class ModelException : AppException
    {
        public override string Level
        {
            get { return "实体"; }
        }

        public ModelException(string message)
            : base(message)
        {
        }

        public ModelException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ModelException()
            : base()
        {
        }
    }
}