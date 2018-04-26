using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy
{
    /// <summary>
    /// 登录的客户SessionManage
    /// 从客户端登录进来的用户信息
    /// 用于客户端连接服务端
    /// </summary>
    public class ConnectedInfoProvider : IConnectedInfoProvider
    {
        User user;

        public User User
        {
            
            get{ return user; }
            set
            {
                var temp = value;
                if (temp == null)
                {
                    RemoveSession(OperationContext.Current.SessionId);
                    user = null;
                }
                else
                {
                    user = value;
                }
            }
        }

        public Store Store { get; set; }

        public bool ClientAuthValid { get; set; }

        public bool BranchServerAuthValid { get; set; }

        #region Session管理

        private readonly static Dictionary<string, ConnectedInfoProvider> ProviderDictionary = new Dictionary<string, ConnectedInfoProvider>();

        private readonly static int SessionIdLength = "d8e2b5a4-462b-4db2-87ea-bb6b1027beae".Length;

        public static ConnectedInfoProvider GetConnectedInfoProvider(string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new Exception("服务器不支持Session系统无法正常运行!");
            }
            //uuid:d8e2b5a4-462b-4db2-87ea-bb6b1027beae;id=13
            sessionId = sessionId.ToLower();
            sessionId = sessionId.Replace("uuid:", "");
            sessionId = sessionId.Substring(0, SessionIdLength);
            if (!ProviderDictionary.ContainsKey(sessionId))
            {
                ProviderDictionary.Add(sessionId, new ConnectedInfoProvider());
            }
            return ProviderDictionary[sessionId];
        }

        public static void RemoveSession(string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new Exception("服务器不支持Session系统无法正常运行!");
            }
            //uuid:d8e2b5a4-462b-4db2-87ea-bb6b1027beae;id=13
            sessionId = sessionId.ToLower();
            sessionId = sessionId.Replace("uuid:", "");
            sessionId = sessionId.Substring(0, SessionIdLength);
            if (!ProviderDictionary.ContainsKey(sessionId))
            {
                ProviderDictionary.Remove(sessionId);
            }
        }

        #endregion
    }
}
