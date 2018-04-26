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
    /// 角色
    /// Version:2013.07.16.2143 已经完成
    /// 由曹晓红完成
    /// </summary> 
    [Description("系统角色")]
    [DataContract(IsReference = true)]
    public class Role : Entity, ILEntity, IStore
    {
        #region Entiy Property

        [Required(ErrorMessage = "请输入[角色名]")]
        [DataMember(Order = 0)]
        public string Name { get; set; }

        [Required(ErrorMessage = "请输入[角色代码]")]
        [DataMember(Order = 1)]
        public string Code { get; set; }

        [Required(ErrorMessage = "请输入[描述信息]")]
        [DataMember(Order = 2)]
        public string Description { get; set; }

        /// <summary>
        /// 创建用户编号
        /// </summary>
        [DataMember(Order = 3)]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember(Order = 4)]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required(ErrorMessage = "[创建时间]不能为空")]
        [DataMember(Order = 5)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember(Order = 6)]
        public DateTime UpdateTime { get; set; }

        [DataMember(Order = 7)]
        public Guid StoreId { get; set; }

        #endregion

        #region Navigation Property 
        [DataMember(Order = 8)]
        public virtual ICollection<RoleWithUser>  RoleWithUsers {get;set;}

        public virtual ICollection<ApprovalFlowNode> ApprovalFlowNodes { get; set; }
        #endregion 

    }
}

