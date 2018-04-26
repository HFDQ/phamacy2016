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
    /// <summary>
    /// 审批流程类型
    /// </summary>
    [Description("审批流程类型")]
    [DataContract(IsReference = true)]
    public class ApprovalFlowType:Entity,ILEntity,IStore
    {
        #region Entiy Property 
 
        /// <summary>
        /// 类型名称
        /// </summary>
        [Required]
        
        [DataMember(Order = 1)]
        public string Name { get; set; }

        /// <summary>
        /// 审批类型描述
        /// </summary>
        [DataMember(Order = 1)]
        [DisplayName(ResourceStrings.Decription)]
        public string Decription { get; set; }

        /// <summary>
        /// 审批类型
        /// </summary>
        [DataMember]
        public int ApprovalTypeValue { get; set; }

        public ApprovalType ApprovalType 
        {
            get { return (ApprovalType) ApprovalTypeValue; }
        }

        /// <summary>
        /// 创建用户编号
        /// </summary>
        [DataMember(Order = 19)]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember(Order = 20)]
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
        [DataMember(Order = 22)]
        public DateTime UpdateTime { get; set; }

        #endregion

        #region Navigation Property

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        [DataMember]
        public virtual ICollection<ApprovalFlowNode> ApprovalFlowNodes { get; set; }
        #endregion
    }
}
