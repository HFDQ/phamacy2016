using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.CMS.Infra;
using BugsBox.Common;
using BugsBox.Common.Config;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Repository;
using BugsBox.Pharmacy.Config;
using BugsBox.Pharmacy.IServices.Notification;
using BugsBox.Pharmacy.Notification;
using System.Xml;
using System.Text.RegularExpressions;
using System.Configuration;

namespace BugsBox.Pharmacy.Services
{
    /// <summary>
    /// 服务上下文
    /// </summary>
    public partial class ServiceContext
    {
        private static AppDomain appDomain = AppDomain.CurrentDomain;

        #region 服务配置
        public static string LoadServiceHost()
        {
            try
            {
                XmlDocument Doc = new XmlDocument();
                Doc.Load(appDomain.SetupInformation.ConfigurationFile);
                XmlNodeList list = Doc.SelectNodes("/configuration/system.serviceModel/services/service");
                string address = string.Empty; 
                address = list[0].SelectSingleNode("endpoint").Attributes["address"].Value;
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
                XmlNodeList list = Doc.SelectNodes("/configuration/system.serviceModel/services/service");
                list[0].SelectSingleNode("endpoint").Attributes["address"].Value = newaddr;
                list[1].SelectSingleNode("endpoint").Attributes["address"].Value = newaddr1;
                Doc.Save(appDomain.SetupInformation.ConfigurationFile);
                return true;
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
                return false;
            }
        }
        #endregion 

        #region 数据库连接

        public static ConnectionStringSettings LoadConnectionStringSettings()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings["Db"];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool SetConnectionStringSettings(ConnectionStringSettings connectionStringSettings)
        {
            try
            {
                string name = connectionStringSettings.Name;
                string connectionString = connectionStringSettings.ConnectionString;
                string providerName = connectionStringSettings.ProviderName;
                
                XmlDocument Doc = new XmlDocument();
                Doc.Load(appDomain.SetupInformation.ConfigurationFile);
                XmlNodeList list = Doc.SelectNodes("/configuration/connectionStrings/add");
                XmlNode dbXmlNode = null;
                foreach (XmlNode node in list)
                {
                    if (node.Attributes["name"].Value == name)
                    {
                        dbXmlNode = node;
                        break;
                    }
                }
                if (dbXmlNode != null)
                {
                    dbXmlNode.Attributes["providerName"].Value = providerName;
                    dbXmlNode.Attributes["connectionString"].Value = connectionString;
                    Doc.Save(appDomain.SetupInformation.ConfigurationFile);
                    return true;
                } 
                return false;
            }
            catch (Exception ex)
            {
                LoggerHelper.Instance.Error(ex);
                return false;
            }
        }

        #endregion 

        private ServiceContext()
        { 
        } 
        #region 字段 

        /// <summary>
        /// 服务上下文对象
        /// </summary>
        public static readonly ServiceContext Instance = new ServiceContext();
        private ILogger Log = LoggerHelper.Instance;

        /// <summary>
        /// 初始化状态
        /// </summary>
        public bool Inited { get;private set; }
        /// <summary>
        /// 服务状态
        /// </summary>
        public bool ServiceStarted { get; private set; }

        /// <summary>
        /// 数据服务Host
        /// </summary>
        private ServiceHost serviceHostPharmacyService { get; set; }

        /// <summary>
        /// 通知服务Host
        /// </summary>
        private ServiceHost serviceHostNotification { get; set; } 

        #endregion 字段

        #region 内部方法

        private void InitConfigurator()
        {
            try
            {
                //WindsorConfigurator.Configurator = new HandlerWindsorConfigurator();
                //WindsorRegistrar.Register(typeof(IConnectedInfoProvider), typeof(ConnectedInfoProvider));
                //WindsorConfigurator.Configurator.Configure();
                //IoC.Build(); 
                var handler = new NotificationHandler();
                NotificationHandlerFactory.SetNotificationHandler(handler);
                NotificationClientContextManager.NotificationClientContextFactory = 
                    new NotificationClientContextFactory();
                handler.UserOnLined += new EventHandler<EventArgs<User>>(NotificationController.Notification_UserOnLined);
                handler.RoleAuthorityChanged += new EventHandler(NotificationController.OnRoleAuthorityChanged_Handle);
              

            }
            catch (Exception ex)
            { 
                ex=new Exception("注入服务以及服务相关对象失败!",ex);
                Log.Error(ex);
            }
         
        }

        #endregion 内部方法

        #region 对外方法 

        /// <summary>
        /// 初始化服务上下文
        /// 只能调用一次
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool Init(out string message)
        {
            lock (this)
            {
                if (Inited)
                {
                    message = string.Empty;
                    return true;
                }
                Inited = false;
                message = string.Empty;
                try
                {
                    Inited=Db.InitDatabase();  
                }
                catch (Exception ex)
                {
                    ex = new Exception("数据库检查与初始化失败!", ex);
                    message = ex.Message;
                    Log.Error(ex);
                    Inited = false;
                    return Inited;
                } 
                if (!Inited)
                {
                    return false;
                }
                try
                {

                    InitConfigurator();
                    //下面检查配置文件中的门信息与数据库中门店信息是否一致 
                    var configStore = PharmacyServiceConfig.Config.CurrentStore;
                    Log.Warning("服务门店配置信息："+configStore.ToJson());
                    Log.Warning("开始检查门店配置与数据库是否一致!");
                    var storeBusinessHandler = new StoreBusinessHandler(new RepositoryProvider(new Db()), new ConnectedInfoProvider());
                    if (storeBusinessHandler.Count(s => s.Id == configStore.Id) == 1)
                    {
                        Log.Warning("门店配置与数据库一致!");
                        Inited = true;
                    }
                    else
                    {
                        message = "门店配置与数据库不一致";
                        Log.Error("门店配置与数据库不一致!");
                        Inited = false;
                    }
                    storeBusinessHandler.Dispose();
                    storeBusinessHandler = null;
                    return Inited;
                }
                catch (Exception ex)
                {
                    ex = new Exception("注入服务以及服务相关对象失败!", ex);
                    message = ex.Message;
                    Log.Error(ex);
                    Inited = false;
                    return Inited;
                }
                return Inited;
            } 
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="message">出错的情况下为出错的具体描述</param>
        /// <returns>成功与否</returns>
        public bool StartService(out string message)
        {
            bool result=Init(out message);
            if (!result)
            { 
                return result;
            } 
            lock (this)
            {
                if (ServiceStarted || (serviceHostPharmacyService!=null&&serviceHostPharmacyService.State==CommunicationState.Opened))
                {
                    message = "服务已经启动";
                    return true;
                }
                    
                OnPreStartService(EventArgs.Empty);
                Log.Information("开始启动服务.....");
                message = string.Empty;
                try
                {
                    //数据服务启动
                    Log.Information("开始启动[数据服务].....");
                    serviceHostPharmacyService = new ServiceHost(typeof(PharmacyService)); 
                    serviceHostPharmacyService.Closed += new EventHandler(serviceHost_Closed);
                    serviceHostPharmacyService.Faulted += new EventHandler(serviceHost_Faulted);
                    serviceHostPharmacyService.Closing += new EventHandler(serviceHost_Closing);
                    serviceHostPharmacyService.Opened += new EventHandler(serviceHost_Opened);
                    serviceHostPharmacyService.Opening += new EventHandler(serviceHost_Opening);
                    serviceHostPharmacyService.Open();
                    Log.Information("成功启动[数据服务]");

                    //通知服务启动
                    Log.Information("开始启动[通知服务].....");
                    serviceHostNotification = new ServiceHost(typeof(PharmacyNotification));
                    serviceHostNotification.Closed += new EventHandler(serviceHost_Closed);
                    serviceHostNotification.Faulted += new EventHandler(serviceHost_Faulted);
                    serviceHostNotification.Closing += new EventHandler(serviceHost_Closing);
                    serviceHostNotification.Opened += new EventHandler(serviceHost_Opened);
                    serviceHostNotification.Opening += new EventHandler(serviceHost_Opening);
                    serviceHostNotification.Open();
                    ServiceStarted = true;
                    Log.Information("成功启动[通知服务]"); 
                    OnEndStartService(EventArgs.Empty);
                    Log.Information("服务启动成功."); 
                    return ServiceStarted;
                }
                catch (Exception ex)
                {
                    ex = new Exception("启动服务失败！", ex);
                    message = ex.Message;
                    Log.Error(ex);
                    ServiceStarted = false;
                    return ServiceStarted;
                }
                finally
                {
                    Log.Information("结束启动服务.....");
                }
            }
          
        }

        /// <summary>
        /// 正在打开服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void serviceHost_Opening(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 服务打开了。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void serviceHost_Opened(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 服务正在关闭。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void serviceHost_Closing(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 服务关闭了。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void serviceHost_Closed(object sender, EventArgs e)
        {
            //serviceHostPharmacyService = null;
            BusinessHandlerFactory.DisposeBusinessHandlerFactories();
            ServiceStarted = false;
        }

        /// <summary>
        /// 服务出错了。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void serviceHost_Faulted(object sender, EventArgs e)
        {
            Log.Error("服务出错了");
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="message">出错的情况下为出错的具体描述</param>
        /// <returns>成功与否</returns>
        public bool StopService(out string message)
        {
        
            lock (this)
            {
                if (!ServiceStarted || serviceHostPharmacyService == null || serviceHostPharmacyService.State != CommunicationState.Opened)
                {
                    ServiceStarted = false;
                    serviceHostPharmacyService = null;
                    message = "服务已经启动";
                    return true;
                }
                OnPreStopService(EventArgs.Empty);
                Log.Information("开始停止服务.....");
                ServiceStarted = false;
                message = string.Empty;
                try
                {

                    NotificationClientContextManager.Clear();
                    //通知服务 
                    Log.Information("开始停止[通知服务].....");
                    if (serviceHostNotification != null)
                    {
                        serviceHostNotification.Abort();
                        serviceHostNotification.Close();
                    }
                    Log.Information("成功停止[通知服务].....");

                    //数据服务
                    Log.Information("开始停止[数据服务].....");
                    if (serviceHostPharmacyService != null)
                    { 
                        serviceHostPharmacyService.Abort();
                        serviceHostPharmacyService.Close(); 
                    }
                    Log.Information("成功停止[数据服务]"); 

                    OnEndStopService(EventArgs.Empty);
                    ServiceStarted = false;
                    Log.Information("停止服务成功!");
                    return !ServiceStarted;
                }
                catch (Exception ex)
                {
                    ex = new Exception("停止服务失败！", ex);
                    message = ex.Message;
                    Log.Error(ex);
                    return false;
                }
                finally
                {
                    Log.Information("结束停止服务.....");
                }
            }
            
        }

        #endregion 对外方法

        #region 对外事件

        public event EventHandler PreStartService = delegate { };

        protected virtual void OnPreStartService(EventArgs e)
        {
            EventHandler handler = PreStartService;
            if (handler != null) handler(this, e);
        }

        public event EventHandler EndStartService = delegate { };

        protected virtual void OnEndStartService(EventArgs e)
        {
            EventHandler handler = EndStartService;
            if (handler != null) handler(this, e);
        }

        public event EventHandler PreStopService = delegate { };

        protected virtual void OnPreStopService(EventArgs e)
        {
            EventHandler handler = PreStopService;
            if (handler != null) handler(this, e);
        }

        public event EventHandler EndStopService = delegate { };

        protected virtual void OnEndStopService(EventArgs e)
        {
            EventHandler handler = EndStopService;
            if (handler != null) handler(this, e);
        }

        #endregion
    }
}
