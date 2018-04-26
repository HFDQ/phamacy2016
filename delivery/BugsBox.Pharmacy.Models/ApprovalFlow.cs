using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using BugsBox.Pharmacy.Models.Config;

namespace BugsBox.Pharmacy.Models
{
    ///// <summary>
    ///// 审批流程
    ///// </summary>
    [Description("审批结点")]
    [DataContract(IsReference = true)]
    public class ApprovalFlow : Entity, ILEntity,IStore
    {

        /// <summary>
        /// 审批流程ID
        /// </summary>
        [Required]
        [DataMember]
        public Guid FlowId { get; set; }

        /// <summary>
        /// 审批流程历史序列号
        /// </summary>
        [Required]
        [DataMember]
        public int SubFlowId { get; set; }

        /// <summary>
        /// 审批状态
        /// </summary>
        [Required]
        [DataMember]
        public int Status { get; set; }

        /// <summary>
        /// 变更记录
        /// </summary>
        [Required]
        [DataMember]
        public string ChangeNote { get; set; }
      
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
        [Required(ErrorMessage = "请输入[创建时间]")]
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 流程类别ID
        /// </summary>
        [Required]
        [DataMember]
        public Guid ApprovalFlowTypeId { get; set; }

        public virtual ApprovalFlowType ApprovalFlowType { get; set; }


        /// <summary>
        /// 下一个审批节点
        /// </summary>
        [DataMember]
        public Guid NextNodeID { get; set; }

        [DataMember]
        public Guid StoreId { get; set; }
    }
}
