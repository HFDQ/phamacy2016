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
    /// 功能模块与角色的关联
    /// Version:2013.07.16.2143
    /// </summary>
    [Description("功能模块与角色的关联")]
    [DataContract(IsReference = true)]
    public class ModuleWithRole : Entity, ILEntity, IStore
    {

        #region Entiy Property

        /// <summary>
        /// 创建用户编号
        /// </summary>
        [DataMember]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DataMember(Order = 0)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember(Order = 1)]
        public DateTime UpdateTime { get; set; }

        #endregion

        #region Navigation Property

        [DataMember]
        public Guid ModuleId { get; set; }
        [DataMember]
        public virtual Module Module { get; set; }
        [DataMember]
        public Guid RoleId { get; set; }
        [DataMember]
        public virtual Role Role { get; set; }
        [DataMember]
        public Guid StoreId { get; set; }


        #endregion


    }
}

