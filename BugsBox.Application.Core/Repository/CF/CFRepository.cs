using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using Omu.ValueInjecter;
using BugsBox.Common;

namespace BugsBox.Application.Core.CF
{
    public class CFRepository<T> : IRepository<T>
       where T : class ,IEntity, new()
    {
        IQueryableUnitOfWork _UnitOfWork;

        protected readonly Type EType = typeof(T);

        /// <summary>
        /// Create a new instance of repository
        /// </summary>
        /// <param name="unitOfWork">Associated Unit Of Work</param>
        public CFRepository(IQueryableUnitOfWork unitOfWork)
        {
            try
            {
               // LoggerHelper.Instance.Warning(string.Format("开始创建[{0}]Repository", EType.FullName));
                if (unitOfWork == (IUnitOfWork)null)
                    throw new ArgumentNullException("unitOfWork");

                _UnitOfWork = unitOfWork;
                Queryable = _UnitOfWork.CreateQueryable<T>();
                DbSet = _UnitOfWork.CreateQueryable<T>() as DbSet<T>;
                //LoggerHelper.Instance.Warning(string.Format("成功创建[{0}]Repository", EType.FullName));
            }
            catch (Exception ex)
            { 
                LoggerHelper.Instance.Error(ex);
                HandleException(string.Format("创建[{0}]Repository出错", EType.FullName), ex);
            }

        }

        public void Dispose()
        {

            try
            {
               // LoggerHelper.Instance.Warning(string.Format("开始销毁[{0}]Repository", EType.FullName));
                if (_UnitOfWork != null)
                {
                    _UnitOfWork.Dispose();
                }
               // LoggerHelper.Instance.Warning(string.Format("成功销毁[{0}]Repository", EType.FullName));
            }
            catch (Exception ex)
            { 
                HandleException(string.Format("销毁[{0}]Repository出错", EType.FullName), ex);
            } 
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _UnitOfWork; }
        }

        public virtual IQueryable<T> Queryable { get; set; }

        protected virtual DbSet<T> DbSet { get; private set; }



        public void Add(T item)
        {
            try
            {
                if (item != (T)null)
                {
                    DbSet.Add(item);
                }
                else
                {
                    throw new NullReferenceException(string.Format("实体({0})不可为null", EType.Name));
                }
            }
            catch (Exception ex)
            { 
                HandleException(string.Format("添加实体({0})出错", EType.Name), ex);
            }
        }

        public void Remove(T item)
        {
            try
            {
                if (item != (T)null)
                {
                    //attach item if not exist
                    _UnitOfWork.Attach(item);
                    DbSet.Remove(item);
                }
                else
                {
                    throw new NullReferenceException(string.Format("实体({0})不可为null", EType.Name));
                }
            }
            catch (Exception ex)
            { 
                HandleException(string.Format("移除实体({0})出错", EType.Name), ex);
            }
        }

        public void Modify(T item)
        {
            try
            {
                if (item != (T)null)
                {
                    //attach item if not exist
                    _UnitOfWork.ApplyCurrentValues(this.Get(item.Id), item);
                }
                else
                {
                    throw new NullReferenceException(string.Format("实体({0})不可为null", EType.Name));
                }
            }
            catch (Exception ex)
            {
                HandleException(string.Format("设置实体为修改({0})出错", EType.Name), ex);
            }
        }

        public void TrackItem(T item)
        {
            try
            {
                if (item != (T)null)
                {
                    //attach item if not exist
                    _UnitOfWork.Attach<T>(item);
                }
                else
                {
                    throw new NullReferenceException(string.Format("实体({0})不可为null", EType.Name));
                }
            }
            catch (Exception ex)
            { 
                HandleException(string.Format("设置实体为修改({0})出错", EType.Name), ex);
            }
        }

        public void Merge(T persisted, T current)
        {
            try
            {
                _UnitOfWork.ApplyCurrentValues(persisted, current);
            }
            catch (Exception ex)
            { 
                HandleException(string.Format("使提交变更实体({0})出错", EType.Name), ex);
            }

        }

        public T Get(Guid id)
        {
            try
            {
                return DbSet.Find(id);
            }
            catch (Exception ex)
            { 
                return HandleException<T>(string.Format("获取实体({0})出错", EType.Name), ex);
            }
        }


        public bool Exist(Expression<Func<T, bool>> predicate = null)
        {
            try
            {
                if (predicate == null)
                {
                    return Queryable.Any();
                }
                else
                {
                    return Queryable.Any(predicate);
                }
            }
            catch (Exception ex)
            { 
                return HandleException<bool>(string.Format("检查实体({0})存在出错", EType.Name), ex);
            }
        }

        public int Count(Expression<Func<T, bool>> predicate = null)
        {
            try
            {
                if (predicate == null)
                {
                    return Queryable.Count();
                }
                else
                {
                    return Queryable.Count(predicate);
                }
            }
            catch (Exception ex)
            { 
                return HandleException<int>(string.Format("统计实体({0})存在出错", EType.Name), ex);
            }
        }

        public virtual IQueryable<T> Fetch(Expression<Func<T, bool>> predicate)
        {
            try
            {
                if (predicate != null)
                {
                    return Queryable.Where(predicate);
                }
                throw new NullReferenceException("查询表达式不能为空!");
            }
            catch (Exception ex)
            {
                return HandleException<IQueryable<T>>(string.Format("查询实体({0})失败", EType.Name), ex);
            }
        }

        public IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order)
        {
            try
            {
                if (order == null)
                {
                    throw new NullReferenceException("排序不能为空!");
                }
                var orderable = new Orderable<T>(Fetch(predicate));
                order(orderable);
                return orderable.Queryable;
            }
            catch (Exception ex)
            {                
               return HandleException<IEnumerable<T>>(string.Format("查询实体({0})失败", EType.Name), ex);
            }

        }

        public IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order, int skip, int count)
        {
            try
            {
                return Fetch(predicate, order).Skip(skip).Take(count);
            }
            catch (Exception ex)
            {
                return HandleException<IEnumerable<T>>(string.Format("分页查询实体({0})失败", EType.Name), ex);
            }

        }
        #region 异常处理

        ILogger Log = LoggerHelper.Instance; 

        public TReturn HandleException<TReturn>(string message=null, Exception ex=null)
        {
            message =(string.IsNullOrWhiteSpace(message))? "未知仓储错误" : message.Trim();
            ex=(ex==null)?new RepositoryException(message):new RepositoryException(message,ex);
            Log.Error(ex);
            throw ex;
        }

        public void HandleException(string message=null, Exception ex=null)
        {
            message =(string.IsNullOrWhiteSpace(message) )? "未知仓储错误" : message.Trim();
            ex=(ex==null)?new RepositoryException(message):new RepositoryException(message,ex);
            Log.Error(ex);
            throw ex;
        }

        #endregion 
    }
}