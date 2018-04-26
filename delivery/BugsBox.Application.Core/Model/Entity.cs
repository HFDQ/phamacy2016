using System;

namespace BugsBox.Application.Core
{
    /// <summary>
    /// 数据库实体类接口
    /// </summary>
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}