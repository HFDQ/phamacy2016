using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using BugsBox.Common;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.AppClient.Common.Notification;
using BugsBox.Pharmacy.AppClient.NS;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;
using System.Xml;
using System.Text.RegularExpressions;

namespace BugsBox.Pharmacy.AppClient
{
    /// <summary>
    /// wcf服务提供者
    /// </summary>
    public class ServicesProvider
    {
        private static AppDomain appDomain = AppDomain.CurrentDomain;

        public static bool TestServiceConnection(string host)
        {
            try
            {
                NetTcpBinding binding = new NetTcpBinding("NetTcpBinding_IPharmacyDatabaseService");
                EndpointAddress remoteAddress = new EndpointAddress(string.Format("net.tcp://{0}:5561/PharmacyDatabaseService", host));
                new PharmacyDatabaseServiceClient(binding, remoteAddress).ReportHeart();
                return true;
            }
            catch (Exception exception)
            {
                LoggerHelper.Instance.Error(exception);
                return false;
            }

        }

        public static string LoadServiceHost()
        {
            try
            { 
                XmlDocument Doc = new XmlDocument();
                Doc.Load(appDomain.SetupInformation.ConfigurationFile);
                string address = Doc.SelectSingleNode("/configuration/system.serviceModel/client/endpoint").Attributes["address"].Value;
                Regex regPid = new Regex(@"net.tcp://(.*):5561/PharmacyDatabaseService", RegexOptions.IgnoreCase);
                Match matches = regPid.Match(address);
                if (matches.Success)
                {
                    return matches.Groups[1].ToString();
                }
                else
                {
                    return "";
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static bool SetServiceHost(string host)
        {
            try
            {
                string newaddr = "net.tcp://" + host + ":5561/PharmacyDatabaseService";
                string newaddr1 = "net.tcp://" + host + ":5571/PharmacyNotificationService";
                XmlDocument Doc = new XmlDocument();
                Doc.Load(appDomain.SetupInformation.ConfigurationFile);
                XmlNodeList list = Doc.SelectNodes("/configuration/system.serviceModel/client/endpoint");
                list[0].Attributes["address"].Value = newaddr;
                list[1].Attributes["address"].Value = newaddr1;
                Doc.Save(appDomain.SetupInformation.ConfigurationFile); 
                return true;
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
                return false;
            }
        }

        /// <summary>
        /// wcf服务对象
        /// </summary>
        public IPharmacyDatabaseService PharmacyDatabaseService { get; private set; }

        public readonly static ServicesProvider Instance = new ServicesProvider();

        private ServicesProvider()
        { 
            //BugsBox.Pharmacy.AppClient.PS.PharmacyDatabaseService
            PharmacyDatabaseService =
                   Activator.CreateInstance(Type.GetType("BugsBox.Pharmacy.AppClient.PS.PharmacyDatabaseService")) as IPharmacyDatabaseService;
        }

        public IPharmacyNotificationChannel PharmacyNotificationChannel { get; private set; }

        private ChannelFactory<IPharmacyNotificationChannel> factoryPharmacyNotificationChannel = null;
        private InstanceContext instanceContext = null;
        public PharmacyNotificationCallback PharmacyNotificationCallback { get; private set; }

        public void RegisterPharmacyNotificationChannel()
        {
            try
            {
                if (PharmacyNotificationCallback == null)
                {
                    PharmacyNotificationCallback = new PharmacyNotificationCallback();
                }
                if (instanceContext == null)
                {
                    instanceContext = new InstanceContext(PharmacyNotificationCallback);
                }
                 if (factoryPharmacyNotificationChannel == null)
                {
                    factoryPharmacyNotificationChannel = new DuplexChannelFactory<IPharmacyNotificationChannel>(instanceContext,"NetTcpBinding_IPharmacyNotification");
                }
                if (PharmacyNotificationChannel == null)
                {
                    PharmacyNotificationChannel = factoryPharmacyNotificationChannel.CreateChannel();
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }

        public void DisconnectServer()
        {
            try
            {
                string message;
                try
                {
                    if (AppClientContext.CurrentUser != null)
                    {
                        ServicesProvider.Instance.PharmacyDatabaseService.UserLogout(out message, Guid.Empty);
                    }
                    if (ServicesProvider.Instance.PharmacyNotificationCallback != null)
                    {
                        var user = AppClientContext.CurrentUser;
                        if (user != null)
                        {
                            ServicesProvider.Instance
                                .PharmacyNotificationChannel.CloseClientNotification(new User { Id = user.Id });
                        }
                    }
                }
                catch (Exception ex)
                {
                    LoggerHelper.Instance.Error(ex);
                } 
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
            }
        }
    }
}
