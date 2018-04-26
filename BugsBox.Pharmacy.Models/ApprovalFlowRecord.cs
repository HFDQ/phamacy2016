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
    ///// 审批流程记录
    ///// </summary>
    [Description("审批流程记录")]
    [DataContract(IsReference = true)]
    public class ApprovalFlowRecord : Entity, ILEntity,IStore
    {

        /// <summary>
        /// 审批流程ID
        /// </summary>
        [Required]
        [DataMember(Order = 20)]
        public Guid FlowId { get; set; }

        /// <summary>
        /// 审批流程历史序列号
        /// </summary>
        [Required]
        [DataMember(Order = 20)]
        public int SubFlowId { get; set; }


        /// <summary>
        /// 流程提交者
        /// </summary>
        [Required]
        [DataMember]
        public Guid ApproveUserId { get; set; }

        /// <summary>
        /// 流程提交时间
        /// </summary>
        [Required(ErrorMessage = "请输入[流程提交时间]")]
        [DataMember(Order = 21)]
        public DateTime ApproveTime { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        [Required(ErrorMessage = "请输入[备注]")]
        
        [DataMember]
        public string Comment { get; set; }

        /// <summary>
        /// 创建用户编号
        /// </summary>
        [Required]
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
        [DataMember(Order = 21)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 流程节点ID
        /// </summary>
        [Required]
        [DataMember]
        public Guid ApprovalFlowNodeId { get; set; }
        //public virtual ApprovalFlowNode ApprovalFlowNode { get; set; }

        public Guid ApprovalFlowId{ get; set; } 

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }
    }
}
