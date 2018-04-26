using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Xml.Linq;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Service.Models;

namespace BugsBox.Pharmacy.IServices
{
    /// <summary>
    /// 此处放置客户端服务授权相关对客户端方法 申杭龙
    /// </summary>
    partial interface IPharmacyDatabaseService
    {
        /// <summary>
        /// 此为客户连接步骤一
        /// 客户端授权
        /// 1.客户端程序连接服务后第一个要调用的方法
        /// 2.该方法完成客户端门店信息与服务端门店信息的比对，如果不对,提示"门店信息与服务端门店信息不匹配无法连接"
        /// 3.匹配后则将客户端信息以及暂存服务端
        /// 4.在用户登录成功后，会将客户端登录入的用户信息也暂存服务端也传输给客户端作保持连之用
        /// 5.系统提供心跳机制来检查客户端的连接有效性.
        /// 6.返回值false客户端不允许登录的进行
        /// </summary>
        /// <param name="clientStore"></param>
        /// <returns></returns> 
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool ValidateClientAuth(Store clientStore);
  

        /// <summary>
        /// 保持通信
        /// 传入的Session ID在登录成功能会给客户端
        /// 服务器通过此Session ID检查登录成功的连接是否有效
        /// 客户端定时调用此方法一旦发现返回是false则应该强制弹出提示要求客户端重新登录.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceExceptionDetail))]
        bool KeepConnection(string sessionId);
 
    }
}
