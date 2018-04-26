using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.ServiceModel;
using System.Text;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.IServices
{
    /// <summary>
    /// 通知服务接口
    /// </summary>
    [ServiceContract(Namespace = "http://www.bugsbox.bugsbox/PharmacyNotification"
        , SessionMode = SessionMode.Required
        , CallbackContract = typeof(IPharmacyNotificationCallback))]
    public interface IPharmacyNotification
    {
        /// <summary>
        /// 注册客户端通知回调
        /// 由客户端登录并获取用户可调用
        /// </summary>
        /// <param name="user"></param>
        [OperationContract(IsOneWay = true)]
        void RegisterClientNotification(User user);

        /// <summary>
        /// 关闭客户端通知回调
        /// 由客户端注销或程序关闭调用
        /// </summary>
        /// <param name="user"></param>
        [OperationContract(IsOneWay = true)]
        void CloseClientNotification(User user);
    }
}
