using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// 异常处理接口
    /// </summary>
    public interface IHandleException
    {
         /// <summary>
        /// 处理异常
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        TReturn HandleException<TReturn>(string message=null, Exception ex=null);

        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        void HandleException(string message=null, Exception ex=null);
    }
}
