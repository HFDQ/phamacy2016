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
    /// 角色与用户的关联
    /// Version:2013.07.16.2143 已经完成
    /// 由曹晓红完成
    /// </summary>
    [Description("角色与用户的关联")]
    [DataContract(IsReference = true)]
    public class RoleWithUser : Entity, ILEntity, IStore
    {
        #region Entiy Property

        [DataMember(Order = 0)]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 创建用户编号
        /// </summary>
        [DataMember(Order = 1)]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember(Order = 2)]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DataMember(Order = 3)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember(Order = 4)]
        public DateTime UpdateTime { get; set; }

        #endregion

        #region Navigation Property

        [Required]
        [DataMember(Order = 5)]
        public Guid RoleId { get; set; }
        [DataMember(Order = 6)]
        public virtual Role Role { get; set; }

        [Required]
        [DataMember(Order = 7)]
        public Guid UserId { get; set; }

        [DataMember(Order = 8)]
        public virtual User User { get; set; }

        #endregion


    }
}

