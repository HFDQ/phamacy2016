using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.Service.Models
{
    /// <summary>
    /// 服务异常细节
    /// </summary>
    [DataContract]
    public class ServiceExceptionDetail
    {
        private readonly static Type _RepositoryException = typeof(RepositoryException); 
        private readonly static Type _BusinessException = typeof(BusinessException);
        private readonly static Type _ServiceException = typeof(ServiceException);

        public ServiceExceptionDetail(Exception ex)
        {
            Type errorType = ex.GetType();
            ExceptionType = ex.GetType().AssemblyQualifiedName;
            HelpLink = ex.HelpLink;
            StackTrace = ex.StackTrace;
            Message = ex.Message;
            if (ex.InnerException != null)
            {
                InnerException = new ServiceExceptionDetail(ex.InnerException);
            }
            if (errorType == _RepositoryException)
            {
                SourceType = ExceptionSourceType.Resository;
            }
            else if (errorType ==_BusinessException)
            {
                SourceType = ExceptionSourceType.Business;
            }
            else if (errorType == _ServiceException)
            {
                SourceType = ExceptionSourceType.Service;
            } 
            else
            {
                SourceType = ExceptionSourceType.Unkown;
            }
        }

        /// <summary>
        /// 错误来源
        /// </summary> 
        [EnumMember]
        public ExceptionSourceType SourceType;

        /// <summary>
        /// 服务链接
        /// </summary>
        [DataMember]
        public string HelpLink { get; set; }

        /// <summary>
        /// 异常消息用于客户端弹出提示
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// StackTrace
        /// </summary>
        [DataMember]
        public string StackTrace { get; set; }

        /// <summary>
        /// 异常数据类型
        /// </summary>
        [DataMember]
        public string ExceptionType { get; set; }

        /// <summary>
        /// 内部导常细节
        /// </summary>
        [DataMember]
        public ServiceExceptionDetail InnerException { get; set; }

        private string fulldescription = string.Empty;

        /// <summary>
        /// 完整错误描述
        /// 客户端须Log此
        /// </summary>
        [DataMember]
        public string FullDescription
        {
            get
            {
                if (string.IsNullOrWhiteSpace(fulldescription))
                {
                     fulldescription=ToString(); 
                }
                return fulldescription; 
            }
            set { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        { 
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("BugsBox.Pharmacy.ServiceExceptionDetail:{0}", Message);
            sb.AppendLine();
            sb.AppendFormat("ExceptionType:{0}", ExceptionType);
            sb.AppendLine();
            sb.AppendFormat("ExceptionSource:{0}", SourceType.ToString());
            sb.AppendLine(); 
            sb.AppendLine(StackTrace);
            if (InnerException != null)
            {
                sb.AppendLine("--->");
                sb.Append(InnerException.ToString());
            }
            return sb.ToString();
        }
    } 

    public enum ExceptionSourceType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unkown,
        /// <summary>
        /// 数据仓储
        /// </summary>
        Resository,
        /// <summary>
        /// 业务
        /// </summary>
        Business,
        /// <summary>
        /// 服务
        /// </summary>
        Service,
    }
}
