using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 用户日志
    /// Version:2013.07.16.2143 已经完成
    /// </summary>
    [Description("用户日志")]
    [DataContract(IsReference = true)]
    public class UserLog : Entity, ILEntity, IStore
    {

        #region Entiy Property 

        /// <summary>
        /// 创建用户编号
        /// </summary>
        [DataMember(Order = 0)]
        public Guid CreateUserId { get; set; } 

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember(Order = 1)]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DataMember(Order = 2)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember(Order = 3)]
        public DateTime UpdateTime { get; set; }

        [Required]
        [DataMember(Order = 4)]
        public string Content { get; set; }


        [DataMember(Order = 5)]
        public Guid StoreId { get; set; }

        #endregion

        #region Navigation Property

        #endregion

    }
}

