using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    [Description("移库")]
    [DataContract]
    public class DrugsInventoryMove : Entity
    {
        /// <summary>
        /// 创建人
        /// </summary>
        [Required]
        [DataMember]
        public System.Guid createUID
        {
            get;
            set;
        }

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
        public int ApprovalStatusValue { get; set; }
        [NotMapped]
        public ApprovalStatus ApprovalStatus
        {
            get { return (ApprovalStatus)ApprovalStatusValue; }
            set
            {
                ApprovalStatusValue = (int)value;
            }
        }


        /// <summary>
        /// 审核ID
        /// </summary>
        [DataMember]
        public System.Guid flowID
        {
            get;
            set;
        }

        /// <summary>
        /// 移库说明
        /// </summary>
        [DataMember]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 原库位ID
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public Guid OriginWareHouseID
        {
            get;
            set;
        }

        /// <summary>
        /// 现库位ID
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public Guid WareHouseID
        {
            get;
            set;
        }

        /// <summary>
        /// 移库数量
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public decimal quantity
        {
            get;
            set;
        }

        /// <summary>
        /// 药品名称
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public string drugName
        {
            get;
            set;
        }

        /// <summary>
        /// 药品批次号
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public string batchNo
        {
            get;
            set;
        }

        /// <summary>
        /// 移库单
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public Guid inventoryRecordID
        {
            get;
            set;
        }


    }
}
