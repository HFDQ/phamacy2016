using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Business.Models
{
    public class drugsUnqualificationCondition
    {
        
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime createTime
        {
            get;
            set;
        }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataMember]
        public System.DateTime updateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 是否通过审核
        /// </summary>
        [DataMember]
        public bool IsApproval
        {
            get;
            set;
        }


        /// <summary>
        /// 不合格描述
        /// </summary>
        [DataMember]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 审核ID
        /// </summary>
        [DataMember]
        public Guid FlowID
        {
            get;
            set;
        }

        /// <summary>
        /// 不合格处理类型
        /// 0表示未提交
        /// 1表示已提交不合格药品报损
        /// </summary>
        [DataMember]
        public int unqualificationType
        {
            get;
            set;
        }

        /// <summary>
        /// 不合格数量
        /// </summary>
        public int number
        {
            get;
            set;
        }


        /// <summary>
        /// 药品名称
        /// </summary>
        [DataMember]
        public string drugName
        {
            get;
            set;
        }

        /// <summary>
        /// 药品名称
        /// </summary>
        [DataMember]
        public string batchNo
        {
            get;
            set;
        }

        [DataMember]
        public DateTime dtFrom
        {
            get;
            set;
        }
        [DataMember]
        public DateTime dtTo
        {
            get;
            set;
        }
    }
}
