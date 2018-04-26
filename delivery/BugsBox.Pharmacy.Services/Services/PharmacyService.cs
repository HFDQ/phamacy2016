using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using BugsBox.Application.Core;
using BugsBox.Common;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Pharmacy.IServices;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Repository;
using BugsBox.Pharmacy.Service.Models;


namespace BugsBox.Pharmacy.Services
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession
        ,ConcurrencyMode = ConcurrencyMode.Multiple
        , IncludeExceptionDetailInFaults = true)]
    public partial class PharmacyService : IPharmacyDatabaseService, IDisposable, IHandleException
    {
        private readonly ILogger Log = LoggerHelper.Instance;
        private readonly ServiceContext context = null;

        public BusinessHandlerFactory HandlerFactory { get; protected set; }



        public PharmacyService()
        {
            try
            {
                //LoggerHelper.Instance.Warning(string.Format("开始创建PharmacyService"));
                //Log.Warning(Thread.CurrentThread.ManagedThreadId.ToString());
                //Log.Warning("[SESSION:"+OperationContext.Current.SessionId+"]");
                context = ServiceContext.Instance;
                var conninfo=ConnectedInfoProvider.GetConnectedInfoProvider(OperationContext.Current.SessionId);
                var db = new Db(); 
                this.HandlerFactory = new BusinessHandlerFactory(db, conninfo);
                //Log.Information("PharmacyBusinessServcie创建！");
                // Log.Warning("Session:" + OperationContext.Current.SessionId);
                //LoggerHelper.Instance.Warning(string.Format("成功创建PharmacyService"));
            }
            catch (Exception ex)
            {
                this.HandleException(string.Format("创建PharmacyService出错"), ex);
            }

        }
        public void Dispose()
        {
            try
            {
                //LoggerHelper.Instance.Warning(string.Format("开始销毁PharmacyService"));
                if (HandlerFactory != null)
                {
                    HandlerFactory.Dispose();
                    HandlerFactory = null;
                }
                //LoggerHelper.Instance.Warning(string.Format("成功销毁PharmacyService"));
            }
            catch (Exception ex)
            {
                ex = new BusinessException(string.Format("销毁PharmacyService出错"), ex);
                LoggerHelper.Instance.Error(ex);
            }

        }

        #region 部门相关

        #endregion 部门相关

        public TReturn HandleException<TReturn>(string message = null, Exception ex = null)
        {
            if (!string.IsNullOrWhiteSpace(message) && (ex==null||string.IsNullOrWhiteSpace(ex.Message)))
            {
                return default(TReturn);
            }
            message = (string.IsNullOrWhiteSpace(message)) ? "未知业务逻辑错误" : message.Trim();
            if (ex == null)
            {
                ex = new ServiceException(message);
                Log.Error(ex);
                throw new FaultException<ServiceExceptionDetail>(new ServiceExceptionDetail(ex),
                    new FaultReason(ex.Message));
            }
            if (ex is AppException)
            {
                throw new FaultException<ServiceExceptionDetail>(new ServiceExceptionDetail(ex), new FaultReason(ex.Message));
            }
            else
            {
                ex = new ServiceException(message, ex);
                Log.Error(ex);
                throw new FaultException<ServiceExceptionDetail>(new ServiceExceptionDetail(ex), new FaultReason(ex.Message));
            }

        }

        public void HandleException(string message = null, Exception ex = null)
        {
            if (!string.IsNullOrWhiteSpace(message) && (ex == null || string.IsNullOrWhiteSpace(ex.Message)))
            {
                return;
            }
            message = (string.IsNullOrWhiteSpace(message)) ? "未知业务逻辑错误" : message.Trim();
            if (ex == null)
            {
                ex = new ServiceException(message);
                Log.Error(ex);
                throw new FaultException<ServiceExceptionDetail>(new ServiceExceptionDetail(ex),
                    new FaultReason(ex.Message));
            }
            if (ex is AppException)
            {
                throw new FaultException<ServiceExceptionDetail>(new ServiceExceptionDetail(ex), new FaultReason(ex.Message));
            }
            else
            {
                ex = new ServiceException(message, ex);
                Log.Error(ex);
                throw new FaultException<ServiceExceptionDetail>(new ServiceExceptionDetail(ex), new FaultReason(ex.Message));
            }


        }

        public void ReportHeart()
        {
        }

    }
}
