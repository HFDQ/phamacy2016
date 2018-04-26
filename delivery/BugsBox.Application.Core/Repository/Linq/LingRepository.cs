using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using Omu.ValueInjecter;

namespace BugsBox.Application.Core.Repository
{
    public class LinqRepository<T> : IRepository<T>
        where T : class, IEntity, new()
    {
        protected readonly Type EType = typeof(T);

        protected readonly DataContext db;

        public LinqRepository(IDbContextFactory dbContextFactory)
        {
            try
            {
                if (dbContextFactory == null)
                {
                    throw new NullReferenceException("dbContextFactory不得为null");
                }
                db = dbContextFactory.GetContext() as DataContext;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(string.Format("创建实体({0})的仓储对象出错", EType.Name), ex);
            }
        }

        public bool Add(T value)
        {
            try
            {
                var dbSet = db.GetTable<T>();
                dbSet.InsertOnSubmit(value);
                return true;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(string.Format("添加实体({0})出错", EType.Name), ex);
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var dbSet = db.GetTable<T>();
                var entity = Get(id);
                if (entity == null)
                {
                    throw new ArgumentException("编号不得为null");
                }
                dbSet.DeleteOnSubmit(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(string.Format("删除实体({0})出错", EType.Name), ex);
            }
        }

        public bool Save(T value)
        {
            try
            {
                if (value == null || value.Id ==default(Guid))
                {
                    throw new ArgumentNullException("db 或者 value不可以为null!或value.Id非法!");
                }
                var originalEntity = Get(value.Id);
                if (originalEntity == null)
                {
                    throw new ArgumentNullException("value 在数据库中不存在!");
                }
                originalEntity.InjectFrom<EntityConventionInjectionForSave>(value);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(string.Format("保存实体({0})出错", EType.Name), ex);
            }
        }

        public bool Save()
        {
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(string.Format("保存出错", EType.Name), ex);
            }
        }

        public T Get(Guid id)
        {
            try
            {
                if (id==default(Guid))
                {
                    throw new ArgumentException("实体编号非法");
                }
                return db.GetTable<T>().FirstOrDefault(t => t.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(string.Format("根据编号获取实体({0})出错", EType.Name), ex);
            }
        }

        public IQueryable<T> AsQueryable()
        {
            try
            {
                return db.GetTable<T>().AsQueryable();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(string.Format("转换实体({0})查询出错", EType.Name), ex);
            }
        }

        public bool Exist(Expression<Func<T, bool>> predicate = null)
        {
            try
            {
                if (predicate == null)
                {
                    predicate = t => true;
                }
                return AsQueryable().Any(predicate);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(string.Format("转换实体({0})查询出错", EType.Name), ex);
            }
        }

        public int Count(Expression<Func<T, bool>> predicate = null)
        {
            try
            {
                if (predicate == null)
                {
                    predicate = t => true;
                }
                return AsQueryable().Count(predicate);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(string.Format("统计实体({0})出错", EType.Name), ex);
            }
        }

        public IRepository<OT> GetRepository<OT>() where OT : class, IEntity, new()
        {
            try
            {
                return IoC.Resolve<IRepository<OT>>();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(string.Format("获取实体({0})的仓储出错", typeof(OT)), ex);
            }
        }

        public IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate)
        {
            return AsQueryable().Where(predicate);
        }

        public IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order)
        {
            var orderable = new Orderable<T>(Fetch(predicate).AsQueryable());
            order(orderable);
            return orderable.Queryable;
        }

        public IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order, int skip, int count)
        {
            return Fetch(predicate, order, skip, count);
        }
    }
}