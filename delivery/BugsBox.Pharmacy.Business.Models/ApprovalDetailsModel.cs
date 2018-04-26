using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Business.Models
{
        [DataContract]
    public class ApprovalDetailsModel
    {
        /// <summary>
        /// 流程提交者Id
        /// </summary>
        [DataMember]
        public Guid ApproveUserId { get; set; }

        /// <summary>
        /// 流程提交者
        /// </summary>
        [DataMember]
        public string ApproveUserName { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public int Status { get; set; }

        /// <summary>
        /// 流程提交时间
        /// </summary>
        [DataMember]
        public DateTime ApproveTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Comment { get; set; }
    }
}
