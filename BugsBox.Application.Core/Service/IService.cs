using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BugsBox.Application.Core
{
    /// <summary>
    /// 逻辑接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IService<T> : IDisposable, IHandleException
        where T : class, IEntity, new()
    {
        /// <summary>
        /// Get the unit of work in this repository
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        bool Save();

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(Guid id);

        IQueryable<T> Queryable { get;}

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<T> Query(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 存在
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Exist(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 存在
        /// </summary>
        /// <returns></returns>
        bool Exist();

        /// <summary>
        /// 统计条数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 统计
        /// </summary>
        /// <returns></returns>
        int Count(); 

        /// <summary>
        /// 查询并排序
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="order"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order, PagerInfo pager);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="order"></param>
        /// <param name="skip"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        IEnumerable<T> Fetch(Expression<Func<T, bool>> predicate, Action<Orderable<T>> order, int skip, int count);

        #region Data Validate

        /// <summary>
        /// 验证添加实体对象
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string ValidateAdd(T value);

        /// <summary>
        /// 验证删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T ValidateDelete(Guid id,out string message);

        /// <summary>
        /// 验证保存
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string ValidateSave(T value);
        /// <summary>
        /// 添加并提交
        /// </summary>
        /// <param name="value"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool Add(T value,out string msg);

        /// <summary>
        /// 删除并提交
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool Delete(Guid id, out string msg);

        /// <summary>
        /// 保存并提交
        /// </summary>
        /// <param name="value"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool Save(T value, out string msg);


        /// <summary>
        /// 添加不提交
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        void Add(T value);

        /// <summary>
        /// 删除不提交
        /// </summary>
        /// <param name="id"></param> 
        /// <returns></returns>
        void Delete(Guid id);

        /// <summary>
        /// 保存不提交
        /// </summary>
        /// <param name="value"></param> 
        /// <returns></returns>
        void Save(T value);



        #endregion

    }
}