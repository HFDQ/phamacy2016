using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using BugsBox.Application.Core;
using BugsBox.Common;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Pharmacy.Config;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Repository;
using Omu.ValueInjecter;
using BugsBox.Pharmacy.Config;

namespace BugsBox.Pharmacy.BusinessHandlers
{
    public abstract class BaseBusinessHandler<T> : Service<T>
         where T : Entity,new()
    {
        // ReSharper disable StaticFieldInGenericType
        /// <summary>
        /// 日志对象
        /// </summary>
        private readonly static ILogger log = LoggerHelper.Instance;
        // ReSharper restore StaticFieldInGenericType

        /// <summary>
        /// 业务逻辑工厂对象
        /// </summary>
        public BusinessHandlerFactory BusinessHandlerFactory { get; private set; }

        /// <summary>
        /// 设置业务逻辑对象工厂对象
        /// </summary>
        public void SetBusinessHandlerFactory(BusinessHandlerFactory businessHandlerFactory)
        {
            this.BusinessHandlerFactory = businessHandlerFactory;
            businessHandlerFactory.Dispose();
        }

        /// <summary>
        /// 仓储工厂对象
        /// </summary>
        public RepositoryProvider RepositoryProvider { get; protected set; }


        /// <summary>
        /// 日志操作对象
        /// </summary>
        public ILogger Log
        {
            get { return log; }
        }

        /// <summary>
        /// 实体对象类型
        /// </summary>
        public static Type StoreInterfaceType = typeof(IStore);

        /// <summary>
        /// 构造函数
        /// </summary>
        static BaseBusinessHandler()
        {
            CurrentStore = PharmacyServiceConfig.Config.CurrentStore;
            CurrentSystemType = CurrentStore.StoreType; 
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseBusinessHandler(IRepository<T> repository, RepositoryProvider repositoryProvider, IConnectedInfoProvider connectedInfoProvider)
            : base(repository)
        {
            try
            {
                //LoggerHelper.Instance.Warning(string.Format("开始创建[{0}]BusinessHandler", EntityName));
                IsStoreEntity = EType.GetInterfaces().Any(t => t == StoreInterfaceType);
                //log.Information(string.Format("检查实体[{0}]是否为门店相关实体：{1}", EntityName, IsStoreEntity));
                //BusinessHandlerFactory = businessHandlerFactory; 
                RepositoryProvider = repositoryProvider;
                ConnectedInfoProvider = connectedInfoProvider;
                repository.Queryable = this.IncludeNavigationProperties(repository.Queryable);
               // LoggerHelper.Instance.Warning(string.Format("成功创建[{0}]BusinessHandler", EntityName));
            }
            catch (Exception ex)
            {              
                this.HandleException(string.Format("创建[{0}]BusinessHandler出错", EntityName), ex);
            }
           
        } 

        /// <summary>
        /// 当前系统的门店信息
        /// 系统初始化的
        /// </summary>
        public static Store CurrentStore { get; private set; } 

        /// <summary>
        /// 系统类型
        /// 系统初始化的
        /// </summary>
        public static StoreType CurrentSystemType { get; private set; }

        /// <summary>
        /// 客户端连接信息
        /// </summary>
        public IConnectedInfoProvider ConnectedInfoProvider { get;protected set; }

        /// <summary>
        /// 连接进总店服务端的分店服务端的分店信息提供者
        /// 由于分店服务端连接进总店服务端
        /// 根据Session ID获取的
        /// </summary>
        public Store ConnectedStore
        {
            get
            {
                if (ConnectedInfoProvider != null) return ConnectedInfoProvider.Store;
                return null;
            }
        } 
 

        /// <summary>
        /// 从客户端登录进来的用户信息
        /// 根据Session ID获取的
        /// 用于客户端连接服务端
        /// </summary>
        public  User ConnectedUser
        {
            get
            {
                if (ConnectedInfoProvider != null) return ConnectedInfoProvider.User;
                return null;
            }
        }

        /// <summary>
        /// 当前会话中的用户编号
        /// </summary>
        protected Guid ConnectedUserId
        {
            get
            {
                if (ConnectedUser != null)
                {
                    return ConnectedUser.Id;
                }
                return Guid.Empty;
            }
        }


        #region 重写IService方法

        /// <summary>
        /// 保存对象不提交
        /// </summary>
        public override void Save(T value)
        {
            try
            {
                if (value != null)
                {
                    Guid userId = ConnectedUserId;
                    ILEntity lEntity = value as ILEntity;
                    if (lEntity != null)
                    {
                        var now = DateTime.Now;
                        lEntity.UpdateTime = now;
                        lEntity.UpdateUserId = userId == Guid.Empty ? CurrentStore.Id : userId;
                        lEntity.UpdateTime = now;
                    }
                    //FixTime
                    var propertyInfos = typeof(T).GetProperties().Where(t => t.PropertyType == typeof(DateTime));
                    foreach (var propertyInfo in propertyInfos)
                    {
                        var obj = propertyInfo.GetValue(value,null);
                        bool needTime = false;
                        if (obj != null)
                        {
                            var oldTime = (DateTime)obj;
                            needTime = (oldTime == default(DateTime));
                        }
                        if (needTime)
                        {
                            propertyInfo.SetValue(value, DateTime.Now, null);
                            log.Warning(string.Format("FixTime:{0}.{1}", typeof(T).FullName, propertyInfo.Name));
                        }
                    } 
                    //FixTime
                    base.Save(value);
                    //if (!(value is UserLog))
                    //{
                    //    BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog
                    //    {
                    //        Content = string.Format("编号为{0}的用户修改数据[{1}]:{2}", userId, value.Id, value.ToJson())
                    //    });
                    //} 
                }
            }            
            catch (Exception ex)
            { 
                this.HandleException(string.Format("保存实体{0}不提交出错", EntityName), ex);
            }
           
        }

        /// <summary>
        /// 保存并提交
        /// </summary>
        public override bool Save(T value, out string msg)
        {
            try
            {
                msg = string.Empty;
                if (value != null)
                {
                    ILEntity lEntity = value as ILEntity;
                    Guid userId = ConnectedUserId;
                    if (lEntity != null)
                    {
                        var now = DateTime.Now;
                        lEntity.UpdateTime = now;
                        lEntity.UpdateUserId = userId == Guid.Empty ? CurrentStore.Id : userId;
                    }
                    //FixTime
                    var propertyInfos = typeof(T).GetProperties().Where(t => t.PropertyType == typeof(DateTime));
                    foreach (var propertyInfo in propertyInfos)
                    {
                        var obj = propertyInfo.GetValue(value, null);
                        bool needTime = false;
                        if (obj != null)
                        {
                            var oldTime = (DateTime)obj;
                            needTime = (oldTime == default(DateTime));
                        }
                        if (needTime)
                        {
                            propertyInfo.SetValue(value, DateTime.Now, null);
                            log.Warning(string.Format("FixTime:{0}.{1}", typeof(T).FullName, propertyInfo.Name));
                        }
                    }
                    //FixTime
                    bool addOK = base.Save(value, out msg);
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        log.Warning(msg);
                    }
                    //if (!(value is UserLog))
                    //{
                    //    //加条日志
                    //    BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog
                    //    {
                    //        Content = string.Format("编号为{0}的用户修改[{1}]并提交[{2}].{3}", userId, value.Id, value.ToJson(), addOK)
                    //    });
                    //}
                    return addOK;
                }
                else
                {

                    msg = string.Format("添加的实体[{0}]不可为null", EntityName);
                    Log.Warning(msg);
                    return false;
                }
            } 
            catch (Exception ex)
            {
                msg=string.Format("保存实体{0}并提交出错", EntityName);
                return this.HandleException<bool>(msg, ex);
            }
           
        }

        /// <summary>
        /// 重载此方法加入添加日志
        /// </summary>
        /// <param name="value"></param>
        public override void Add(T value)
        {
            try
            {
                if (value != null)
                {
                    Guid userId = ConnectedUserId;
                    List<User> userList = RepositoryProvider.Db.Users.ToList();
                    Guid roleGuid = RepositoryProvider.Db.Roles.Where(r => r.Name.Contains("SystemRole")).FirstOrDefault().Id;
                    List<RoleWithUser> RoleWList = RepositoryProvider.Db.RoleWithUsers.Where(r => r.RoleId.Equals(roleGuid)).ToList();
                    var u = from i in RoleWList join k in userList on i.UserId equals k.Id select k;
                    userList = u.ToList();

                    Guid SysRoleId = userList.First().Id;

                    ILEntity lEntity = value as ILEntity;
                    if (lEntity != null)
                    {
                        var now = DateTime.Now;
                        lEntity.CreateTime = now;
                        lEntity.CreateUserId = lEntity.CreateUserId == Guid.Empty ? SysRoleId : lEntity.CreateUserId;
                        lEntity.UpdateTime = now;
                        lEntity.UpdateUserId = lEntity.CreateUserId == Guid.Empty ? SysRoleId : lEntity.CreateUserId;
                    }
                    //FixTime
                    var propertyInfos = typeof(T).GetProperties().Where(t => t.PropertyType == typeof(DateTime));
                    foreach (var propertyInfo in propertyInfos)
                    {
                        var obj = propertyInfo.GetValue(value, null);
                        bool needTime = false;
                        if (obj != null)
                        {
                            var oldTime = (DateTime)obj;
                            needTime = (oldTime == default(DateTime));
                        }
                        if (needTime)
                        {
                            propertyInfo.SetValue(value, DateTime.Now, null);
                            log.Warning(string.Format("FixTime:{0}.{1}", typeof(T).FullName, propertyInfo.Name));
                        }
                    }
                    //FixTime
                    base.Add(value);
                    //if (!(value is UserLog))
                    //{
                    //    BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog
                    //    {
                    //        Content = string.Format("编号为{0}的用户添加[{1}].", userId, value.ToJson())
                    //    });
                    //} 
                }
            }
            catch (Exception ex)
            {
                this.HandleException(string.Format("添加实体{0}不提交出错", EntityName), ex);
            }
            
        }

        /// <summary>
        /// 重载此方法加入添加日志
        /// </summary>
        /// <param name="value"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public override bool Add(T value, out string msg)
        {
            try
            {
                msg = string.Empty;
                if (value != null)
                {
                    ILEntity lEntity = value as ILEntity;
                    Guid userId = ConnectedUserId;
                    if (lEntity != null)
                    {
                        var now = DateTime.Now;
                        lEntity.CreateTime = now;
                        lEntity.CreateUserId = userId == Guid.Empty ? CurrentStore.Id : userId;
                        lEntity.UpdateTime = now;
                        lEntity.UpdateUserId = lEntity.CreateUserId;
                    }
                    //FixTime
                    var propertyInfos = typeof(T).GetProperties().Where(t => t.PropertyType == typeof(DateTime));
                    foreach (var propertyInfo in propertyInfos)
                    {
                        var obj = propertyInfo.GetValue(value, null);
                        bool needTime = false;
                        if (obj != null)
                        {
                            var oldTime = (DateTime)obj;
                            needTime = (oldTime == default(DateTime));
                        }
                        if (needTime)
                        {
                            propertyInfo.SetValue(value, DateTime.Now, null);
                            log.Warning(string.Format("FixTime:{0}.{1}", typeof(T).FullName, propertyInfo.Name));
                        }
                    }
                    //FixTime
                    bool addOK = base.Add(value, out msg);
                    // if (!(value is UserLog))
                    //{
                    //    //加条日志
                    //    BusinessHandlerFactory.UserLogBusinessHandler.LogUserLog(new UserLog
                    //    {
                    //        Content = string.Format("编号为{0}的用户添加并提交[{1}]:{2}", userId, value.ToJson(), addOK)
                    //    });
                    //} 
                    return addOK;
                }
                else
                {

                    msg = string.Format("添加的实体[{0}]不可为null", EntityName);
                    Log.Warning(msg);
                    return false;
                }
            }
            catch (Exception ex)
            {
                msg = string.Format("添加实体{0}并提交出错", EntityName);
                return this.HandleException<bool>(msg, ex);
            }
          
        }

        /// <summary>
        /// 删除不提交
        /// </summary>
        public override void Delete(Guid id)
        {
            try
            {
                string message = string.Empty;
                T t = ValidateDelete(id, out message);
                if (string.IsNullOrWhiteSpace(message))
                {
                    if (t != null)
                    {
                        t.Deleted = true;
                        t.DeleteTime = DateTime.Now;
                    }
                }
                else
                {
                    Log.Warning(message);
                }
            }
            catch (Exception ex)
            {
                this.HandleException(string.Format("删除实体{0}不提交出错", EntityName), ex);
            }

        }

        /// <summary>
        /// 删除提交
        /// </summary>
        public override bool Delete(Guid id, out string msg)
        {
            try
            {
                msg = string.Empty;
                if (id == Guid.Empty)
                {
                    msg = string.Format("{0}的ID不合法", EntityName);
                    Log.Warning(msg);
                    return false;
                }
                string message = string.Empty;
                T t = ValidateDelete(id, out message);
                if (t == null)
                {
                    msg = string.Format("编号为{0}的{1}不存在", id, EntityName);
                    Log.Warning(msg);
                    return false;
                }
                if (!string.IsNullOrWhiteSpace(message))
                {
                    msg = string.Format("编号为{0}的{1}删除失败！", id, EntityName);
                    Log.Warning(msg);
                    return false;
                }
                t.Deleted = true;
                t.DeleteTime = DateTime.Now;
                bool success = base.Save();
                if (!success)
                {
                    msg = EntityName + "删除失败!";
                    Log.Warning(msg);
                }
                return success;
            }
            catch (Exception ex)
            {
                msg = string.Format("删除实体{0}并提交出错", EntityName);
                return this.HandleException<bool>(msg, ex);
            }
           
        }

         

        /// <summary>
        /// 查询前的准备
        /// </summary>
        protected override Expression<Func<T, bool>> PreparePredicate(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var queryBuilder = QueryBuilder.Create<T>();
                predicate = base.PreparePredicate(predicate);
                Expression<Func<T, bool>> filterDelete = t => !t.Deleted;//加入删除条件
                //queryBuilder.AppendExpression(filterDelete);
                return ExpressionBuilder.And(predicate, filterDelete);
                if (!IsStoreEntity) return predicate;//非门店数据不参与添加门店限制条件

                queryBuilder.AppendExpression(predicate);

                if (CurrentSystemType == StoreType.Branch)
                {
                    //如果是门店客户端连门店服务 加门店条件 
                    Expression<Func<IStore, bool>> appendExpression = t => t.StoreId == ConnectedStore.Id;
                    queryBuilder.AppendExpression(appendExpression);
                }
                else if (ConnectedStore.StoreType == StoreType.Branch && CurrentSystemType == StoreType.Main)
                {
                    //如果是门店客户端连总店服务 加本门点条件
                    Expression<Func<IStore, bool>> appendExpression = t => t.StoreId == ConnectedStore.Id;
                    queryBuilder.AppendExpression(appendExpression);
                }
                //如果是总店客户端连总店服务 不加门店条件
                return base.PreparePredicate(queryBuilder.Expression);
            }
            catch (Exception ex)
            {
                return this.HandleException<Expression<Func<T, bool>>>(string.Format("准备实体{0}查询表达式", EntityName), ex);
            }
           
        }

        /// <summary>
        /// 添加前的准备
        /// </summary>
        protected override T PrepareEntityForAdd(T enity)
        {
            try
            {
                //如果是店的实体
                if (IsStoreEntity)
                {
                    //如果是分店连接分店服务
                    if (CurrentSystemType == StoreType.Branch)
                    {
                        //为分店实现强制加上StoreId 
                        IStore store = enity as IStore;
                        store.StoreId = CurrentStore.Id;
                    }
                    else if (CurrentSystemType == StoreType.Main)
                    {
                        //连进来的不是客户端的服务哦
                        if (ConnectedStore == null)
                        {
                            IStore store = enity as IStore;
                            store.StoreId = CurrentStore.Id;
                        }
                    }
                    return enity;
                }
                return base.PrepareEntityForAdd(enity);
            }
            catch (Exception ex)
            {
                return this.HandleException<T>(string.Format("为添加实体{0}做准备", EntityName), ex);
            }
           
        }

        /// <summary>
        /// 检查是否门店对象实体
        /// </summary>
        protected bool IsStoreEntity { get; private set; }

        #endregion

        /// <summary>
        /// 销毁
        /// </summary>
        public override void Dispose()
        {
            try
            {
               // LoggerHelper.Instance.Warning(string.Format("开始销毁[{0}]BusinessHandler", EntityName));
                //if (BusinessHandlerFactory!=null) BusinessHandlerFactory.Dispose();
               // LoggerHelper.Instance.Warning(string.Format("成功销毁[{0}]BusinessHandler", EntityName));
                //if (BusinessHandlerFactory != null) BusinessHandlerFactory.Dispose();
            }
            catch (Exception ex)
            { 
               this.HandleException(string.Format("销毁[{0}]BusinessHandler出错", EntityName), ex);
            }
          
        }

    } 

    /// <summary>
    /// 连接进总店服务端的分店服务端的分店信息提供者
    /// 用于分店服务端连接总店服务端
    /// </summary>
    public interface IConnectedStoreProvider
    {
        /// <summary>
        /// 连接进服务的门店信息获取
        /// </summary>
        Store Store { get; set; }

        /// <summary>
        /// 分店服务端连接授权通过是否
        /// </summary>
        bool BranchServerAuthValid { get; set; }
    }

    /// <summary>
    /// 从客户端登录进来的用户信息
    /// 用于客户端连接服务端
    /// </summary>
    public interface IConnectedUserProvider
    {
        /// <summary>
        /// 客户端连接授权通过是否
        /// </summary>
        bool ClientAuthValid { get; set; }
        /// <summary>
        /// 登录进来的
        /// </summary>
        User User { get; set; }

    }

    public interface IConnectedInfoProvider : IConnectedUserProvider, IConnectedStoreProvider
    {
        
    }

    public abstract class BaseBusinessHandler
    {
        private readonly static ILogger log = LoggerHelper.Instance;
        public ILogger Log
        {
            get { return log; }
        }
    }
}
