using System;
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using BugsBox.Application.Core;
using System.ComponentModel;


namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 实体基类
    /// </summary>
    [DataContract(IsReference = true)]
    public abstract class Entity : IEntity
    {  
         
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// 主键
        /// </summary>  
        [Key]  
        [DataMember(Order = 0)]
        [DisplayName("编号 ")]
        public Guid Id { get; set; }

        /// <summary>
        /// 已经删除
        /// </summary>
        [DataMember(Order = 1)] 
        [Browsable(false)]
        public bool Deleted { get; set; }

        /// <summary>
        /// 删除日期
        /// </summary>
        [DataMember(Order = 2)]
        [Browsable(false)]
        public DateTime? DeleteTime { get; set; }

        #region Entiy Property 
 
        #endregion

        #region Navigation Property 

        #endregion 
    } 

    /// <summary> 
    /// 带操作信息的约束
    /// </summary>
    public interface ILEntity
    {  
        DateTime CreateTime { get; set; } 

        Guid CreateUserId { get; set; }

        DateTime UpdateTime { get; set; } 

        Guid UpdateUserId { get; set; } 
    }

    /// <summary>
    /// 字典数据接口
    /// 由系统初化默认
    /// </summary>
    internal interface IDictionaryType:IEnable
    {
        string Name { get; set; }
        string Decription { get; set; }
        string Code { get; set; }
       
    }

    internal interface IEnable
    {
        bool Enabled { get; set; }
    }

    /// <summary>
    /// 审批接口
    /// </summary>
    internal interface IApproval
    {
        ApprovalStatus ApprovalStatus { get; set; }
        DateTime? ApprovaledTime { get; set; } 
        Guid ApprovalUserId { get; set; }
    }

    /// <summary>
    /// 门店接口主要规范门店编号
    /// </summary>
    public interface IStore
    {
        Guid StoreId { get; set; }
    }

    /// <summary>
    /// 有效性约束
    /// </summary>
    public interface IValidation
    {
        /// <summary>
        /// 有效
        /// </summary>
        bool Valid { get; set; } 
    }

    /// <summary>
    /// 过期性约束
    /// </summary>
    public interface IOutDate
    {
        /// <summary>
        /// 有效
        /// </summary>
        bool IsOutDate { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        DateTime OutDate { get; set; }
    } 
 
}

