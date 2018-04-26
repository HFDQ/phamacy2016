using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using BugsBox.Application.Core.CF;

using BugsBox.Common;

namespace BugsBox.Application.Core
{
    public class Service<T> : IService<T>
       where T : class ,IEntity, new()
    {
        public readonly Type EType = typeof(T);
        public readonly string EntityName = string.Empty;
        // ReSharper disable InconsistentNaming
        public IRepository<T> repository;
        // ReSharper restore InconsistentNaming

        protected static ILogger _Logger = LoggerHelper.Instance;

        public Service(IRepository<T> repository)
        {
            try
            {
               // LoggerHelper.Instance.Warning(string.Format("开始创建[{0}]Service", EntityName));
                EntityName = EntityExtensions.GetDescription(EType);
                this.repository = repository;
                this.repository.Queryable = IncludeNavigationProperties(repository.Queryable)
                    .Where(PreparePredicate(null));
                _UnitOfWork = repository.UnitOfWork as IQueryableUnitOfWork;
               // LoggerHelper.Instance.Warning(string.Format("成功创建[{0}]Service", EntityName));
            }
            catch (Exception ex)
            {
                ex = new BusinessException();
                HandleException(string.Format("创建[{0}]Service出错", EntityName), ex);
            }

        }

        public IQueryableUnitOfWork _UnitOfWork;

        public IUnitOfWork UnitOfWork
        {
            get { return _UnitOfWork; }
        }
        /// <summary>
        /// 查询对象
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> Queryable
        {
            get
            {
                try
                {
                    return repository.Queryable;

                }
                catch (RepositoryException rex)
                {
                    throw rex;
                }
                catch (Exception ex)
                {
                    return HandleException<IQueryable<T>>(string.Format("获取实体({0})查询对象失败错", EntityName), ex);
                }

            }
        }

        protected virtual IQueryable<T> IncludeNavigationProperties(IQueryable<T> queryable)
        {
            try
            {
                return queryable;
            }
            catch (Exception ex)
            {
                return HandleException<IQueryable<T>>(string.Format("处理实体({0})的导航失败", EntityName), ex);
            }

        }

        protected virtual Expression<Func<T, bool>> PreparePredicate(Expression<Func<T, bool>> predicate)
        {

            try
            {

                if (predicate == null)
                {
                    predicate = t => true;
                }
                return predicate;
            }
            catch (Exception ex)
            {
                return HandleException<Expression<Func<T, bool>>>(string.Format("准备查询实体({0})表达式出错", EntityName), ex);
            }

        }

        /// <summary>
        /// 为添加的数据作准备
        /// 目前主要于为店的店实体添加店的Guid
        /// </summary>
        /// <param name="enity"></param>
        /// <returns></returns>
        protected virtual T PrepareEntityForAdd(T enity)
        {
            try
            {
                if (enity.Id == Guid.Empty)
                {
                    enity.Id = Guid.NewGuid();
                }
                return enity;
            }
            catch (Exception ex)
            {
                return this.HandleException<T>(string.Format("为添加实体{0}做准备", EntityName), ex);
            }

        }

        public virtual T Get(Guid id)
        {
            try
            {
                T value = Queryable.FirstOrDefault(t => t.Id == id);
                return value;
            }
            catch (RepositoryException rex)
            {
                throw rex;
            }
            catch (Exception ex)
            {
                return HandleException<T>(string.Format("获取({0})出错", EntityName), ex);
            }
        }


        public virtual IQueryable<T> Fetch(Expression<Func<T, bool>> predicate)
        {
            try
            {
                
                return repository.Fetch(PreparePredicate(predicate));
            }
            catch (Exception ex)
            {
                return HandleException<IQueryable<T>>(string.Format("查询({0})出错", EntityName), ex);
            }
        }

        public virtual IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order)
        {
            try
            {
                return repository.Fetch(PreparePredicate(predicate), order);
            }
            catch (Exception ex)
            {
                return HandleException<IEnumerable<T>>(string.Format("查询并排序({0})出错", EntityName), ex);
            }
        }

        public virtual IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order, PagerInfo pager)
        {
            try
            {
                if (pager == null)
                {
                    throw new NullReferenceException("分页对象不得为null");
                }
                pager.Index = pager.Index < 1 ? 1 : pager.Index;
                pager.RecordCount = this.Count(predicate);
                pager.Size = pager.Size < 1 ? 20 : pager.Size;
                if (pager.RecordCount == 0)
                {
                    pager.Index = 1;
                }
                return Fetch(PreparePredicate(predicate), order, (pager.Index - 1) * pager.Size, pager.Size);
            }
            catch (Exception ex)
            {
                return HandleException<IEnumerable<T>>(string.Format("分页查询排序({0})出错", EntityName), ex);
            }

        }

        #region Data Validate

        protected static Type StringType = typeof(string);
        protected static Type DateTimeType = typeof(DateTime);

        public virtual string ValidateAdd(T value)
        {
            if (value == null) return string.Format("[{0}]不得为Null", EntityName);
            //Fix String Null
            var propertyInfos = EType.GetProperties();
            foreach (var info in propertyInfos)
            {
                if (
                    info.PropertyType == StringType)
                {
                    var pValue = info.GetValue(value, null) as string;
                    if (pValue == null)
                    {
                        info.SetValue(value, string.Empty, null);
                    }

                }
                if (info.PropertyType == DateTimeType)
                {
                    var pValue = (DateTime)info.GetValue(value, null);
                    if (pValue == default(DateTime))
                    {
                        info.SetValue(value, DateTime.Now, null);
                    }
                }
            }

            string result = string.Empty;
            return result;
        }

        public virtual T ValidateDelete(Guid id, out string message)
        {
            if (id == default(Guid))
            {
                message = string.Format("[{0}]的[{1}]不得为默认值", EntityName, EntityExtensions.GetDisplay(EType, "Id"));
                return default(T);
            }
            //if (!this.Exist(e => e.Id == id))
            //{
            //    message = string.Format("编号为[{0}]的[{1}]的数据不存在", id, EntityName);
            //    return default(T);
            //}
            message = string.Empty;
            return this.Get(id);
        }

        public virtual string ValidateSave(T value)
        {
            if (value == null) return string.Format("[{0}]不得为Null", EntityName);
            string result = string.Empty;
            return result;
        }

        /// <summary>
        /// 添加并提交
        /// </summary>
        /// <param name="value"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public virtual bool Add(T value, out string msg)
        {
            msg = string.Empty;
            try
            {
                msg = ValidateAdd(value);
                if (string.IsNullOrWhiteSpace(msg))
                {
                    value = PrepareEntityForAdd(value);
                    repository.Add(value);
                    Save();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                msg = string.Format("添加并提交实体({0})出错" + ex.Message, EntityName);
                return HandleException<bool>(msg, ex);
            }
        }

        /// <summary>
        /// 删除并提交
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public virtual bool Delete(Guid id, out string msg)
        {
            msg = string.Empty;
            try
            {
                T t = ValidateDelete(id, out msg);
                if (string.IsNullOrWhiteSpace(msg))
                {
                    repository.Remove(t);
                    Save();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                msg = string.Format("删除并提交实体({0})出错" + ex.Message, EntityName);
                return HandleException<bool>(msg, ex);
            }
        }

        /// <summary>
        /// 保存并提交
        /// </summary>
        /// <param name="value"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public virtual bool Save(T value, out string msg)
        {
            msg = string.Empty;
            try
            {
                msg = ValidateSave(value);
                if (string.IsNullOrWhiteSpace(msg))
                {
                    var o = this.Get(value.Id);
                    if (o == null)
                    {
                        msg = "实体不存在!";
                        return false;
                    }
                    else
                    {
                        _UnitOfWork.ApplyCurrentValues(o, value);
                    }
                    Save();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                msg = string.Format("保存实体({0})出错" + ex.Message, EntityName);
                return HandleException<bool>(msg, ex);
            }
        }

        #endregion

        /// <summary>
        /// 提交
        /// </summary>
        public virtual bool Save()
        {
            try
            {
                _UnitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return HandleException<bool>(string.Format("提交({0})出错" + ex.Message, EntityName), ex);
            }
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return repository.Fetch(PreparePredicate(predicate));
            }
            catch (Exception ex)
            {
                return HandleException<IQueryable<T>>(string.Format("查询({0})出错", EntityName), ex);
            }
        }

        public virtual bool Exist(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return repository.Exist(PreparePredicate(predicate));
            }
            catch (Exception ex)
            {
                return HandleException<bool>(string.Format("根据表达式检查({0})存在出错", EntityName), ex);
            }
        }

        public virtual bool Exist()
        {
            try
            {
                return repository.Exist(PreparePredicate(null));
            }
            catch (Exception ex)
            {
                return HandleException<bool>(string.Format("检查({0})存在出错", EntityName), ex);
            }
        }

        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return repository.Count(PreparePredicate(predicate));
            }
            catch (Exception ex)
            {
                return HandleException<int>(string.Format("表达式统计实体({0})出错", EntityName), ex);
            }
        }

        public virtual int Count()
        {
            try
            {
                return repository.Count(PreparePredicate(null));
            }
            catch (Exception ex)
            {
                return HandleException<int>(string.Format("统计实体({0})出错", EntityName), ex);
            }
        }


        public virtual IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order, int skip, int count)
        {
            try
            {
                return repository.Fetch(PreparePredicate(predicate), order, skip, count);
            }
            catch (Exception ex)
            {
                return HandleException<IEnumerable<T>>(string.Format("分页并排序查询实体({0})出错", EntityName), ex);
            }
        }

        /// <summary>
        ///  添加不提交
        /// </summary>
        /// <param name="value"></param>
        public virtual void Add(T value)
        {
            try
            {
                string msg = ValidateAdd(value);
                if (string.IsNullOrWhiteSpace(msg))
                {
                    value = PrepareEntityForAdd(value);
                    repository.Add(value);
                }
            }
            catch (Exception ex)
            {
                HandleException(string.Format("添加实体不提交({0})出错", EntityName), ex);
            }
        }

        /// <summary>
        ///  移除不提交
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(Guid id)
        {
            try
            {
                string msg;
                T t = ValidateDelete(id, out msg);
                if (string.IsNullOrWhiteSpace(msg))
                {
                    repository.Remove(t);
                }
            }
            catch (Exception ex)
            {
                HandleException(string.Format("移除实体不提交({0})出错", EntityName), ex);
            }
        }

        /// <summary>
        /// 更新不提交
        /// </summary>
        /// <param name="value"></param>
        public virtual void Save(T value)
        {
            try
            {
                string msg = ValidateAdd(value);
                if (string.IsNullOrWhiteSpace(msg))
                {
                    repository.Modify(value);
                }
            }
            catch (Exception ex)
            {
                HandleException(string.Format("保存实体不提交({0})出错", EntityName), ex);
            }
        }

        public virtual void Dispose()
        {

            try
            {
                //LoggerHelper.Instance.Warning(string.Format("开始销毁[{0}]Service", EntityName));
                if (repository != null)
                {
                    repository.Dispose();
                    repository = null;
                }
                //LoggerHelper.Instance.Warning(string.Format("成功销毁[{0}]Service", EntityName));
            }
            catch (Exception ex)
            {
                HandleException(string.Format("销毁[{0}]Service出错", EntityName), ex);
            }
        }

        #region 异常处理

        public TReturn HandleException<TReturn>(string message = null, Exception ex = null)
        {
            message = (string.IsNullOrWhiteSpace(message)) ? "未知业务逻辑错误" : message.Trim();
            if (ex == null)
            {
                ex = new BusinessException(message);
                _Logger.Error(ex);
                throw ex;
            }
            if (ex is AppException)
            {
                throw ex;
            }
            else
            {
                ex = new BusinessException(message, ex);
                _Logger.Error(ex);
                throw ex;
            }
        }

        public void HandleException(string message = null, Exception ex = null)
        {
            message = (string.IsNullOrWhiteSpace(message)) ? "未知业务逻辑错误" : message.Trim();
            if (ex == null)
            {
                ex = new BusinessException(message);
                _Logger.Error(ex);
                throw ex;
            }
            if (ex is AppException)
            {
                throw ex;
            }
            else
            {
                ex = new BusinessException(message, ex);
                _Logger.Error(ex);
                throw ex;
            }
        }

        #endregion
    }
}