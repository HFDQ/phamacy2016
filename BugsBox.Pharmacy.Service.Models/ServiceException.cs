using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.Service.Models
{
    /// <summary>
    /// wcf服务异常
    /// </summary>
    public class ServiceException : AppException
    {
        public override string Level
        {
            get { return "服务异常"; }
        }

        public ServiceException(string message)
            : base(message)
        {
        }

        public ServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ServiceException()
            : base()
        {
        }
    }
}
