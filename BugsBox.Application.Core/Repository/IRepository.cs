using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BugsBox.Application.Core
{
    /// <summary>
    /// 仓储操作接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IDisposable, IHandleException
        where T : class,IEntity, new()
    {

        /// <summary>
        /// 数据库上下文
        /// </summary>
        IUnitOfWork UnitOfWork { get; }


        /// <summary>
        /// 获取查询
        /// </summary>
        IQueryable<T> Queryable { get; set; }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="item">Item to add to repository</param>
        void Add(T item);

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Remove(T item);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="item">Item to modify</param>
        void Modify(T item);

        /// <summary>
        /// 附加实体
        /// </summary>
        /// <param name="item">Item to attach</param>
        void TrackItem(T item);

        /// <summary>
        /// 实体信息合并
        /// </summary>
        /// <param name="persisted">The persisted item</param>
        /// <param name="current">The current item</param>
        void Merge(T persisted, T current);

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="id">Entity key value</param>
        /// <returns></returns>
        T Get(Guid id); 

        /// <summary>
        /// 检查存在是否
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Exist(Expression<Func<T, bool>> predicate = null);

        /// <summary>
        /// 统计
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> predicate = null);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns></returns>
        IQueryable<T> Fetch(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <param name="order">排序</param>
        /// <returns>查询结果集</returns>
        IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <param name="order">排序</param>
        /// <param name="skip">跳过条数</param>
        /// <param name="count">取条数</param>
        /// <returns>查询结果集</returns>
        IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order, int skip, int count); 
       
    }
}