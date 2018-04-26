using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Config;

namespace BugsBox.Pharmacy.Services
{

    partial class PharmacyService
	{
        /// <summary>
        /// 此为客户连接步骤一
        /// 客户端授权
        /// 1.客户端程序连接服务后第一个要调用的方法
        /// 2.该方法完成客户端门店信息与服务端门店信息的比对，如果不对,提示"门店信息与服务端门店信息不匹配无法连接"
        /// 3.匹配后则将客户端信息以及暂存服务端
        /// 4.在用户登录成功后，会将客户端登录入的用户信息也暂存服务端
        /// 5.系统提供心跳机制来检查客户端的连接有效性.
        /// </summary>
        /// <param name="clientStore"></param>
        /// <returns></returns> 
        public bool ValidateClientAuth(Store clientStore)
        {
            try
            {
                if (clientStore == null)
                {
                    Log.Error("客户端授权的门店对象不得为null!");
                    return false;
                }
                if (PharmacyServiceConfig.Config.CurrentStore.Id == clientStore.Id)
                {
                    if (HandlerFactory.StoreBusinessHandler.Count(s => s.Id == clientStore.Id) != 1)
                    {
                        Log.Warning(string.Format("服务端尚未对门店信息{0}初始化,授权失败", clientStore.ToJson()));
                        return false;
                    }
                    else
                    {
                        HandlerFactory.ConnectedInfoProvider.ClientAuthValid = true; 
                        Log.Warning(string.Format("对门店客户端{0}的登录授权成功!", clientStore.ToJson()));
                        return true;
                    }

                }
                else
                {
                    Log.Warning(string.Format("对门店客户端{0}的登录授权失败!", clientStore.ToJson()));
                    return false;
                }
            }
            catch (Exception ex)
            {
                return this.HandleException<bool>("门店客户端授权验证失败", ex);
            }
            
           
        } 

        /// <summary>
        /// 保持通信
        /// 传入的Session ID在登录成功能会给客户端
        /// 服务器通过此Session ID检查登录成功的连接是否有效
        /// 客户端定时调用此方法一旦发现返回是false则应该强制弹出提示要求客户端重新登录.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public bool KeepConnection(string sessionId)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                return this.HandleException<bool>("保持通信失败", ex);
            }
           
        } 

        /// <summary>
        /// 服务端验证客户端登录的有效性
        /// 如果不成功则是所有DatabaseService的方法均不能执行有out message的在message中传回客户端
        /// 没有outmessage的则抛出异常
        /// 日后会抛出客户端未登录异常
        /// </summary>
        /// <returns></returns>
        private bool ValidateClientLogon()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                return this.HandleException<bool>("服务端验证客户端登录的有效性", ex);
            }
           
        }
	}
}
