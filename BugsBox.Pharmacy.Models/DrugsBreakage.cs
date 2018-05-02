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
    [Description("报损药品")]
    [DataContract]
    public class DrugsBreakage : Entity
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
        /// 不合格描述
        /// </summary>
        [DataMember]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 不合格类型
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
        [DataMember]
        public decimal quantity
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
        /// 药品批次号
        /// </summary>
        [DataMember]
        public string batchNo
        {
            get;
            set;
        }

        /// <summary>
        /// 药品库存ID
        /// </summary>
        [DataMember]
        public Guid DrugInventoryRecordID { get; set; }

        /// <summary>
        /// 报损单号
        /// </summary>
        [DataMember]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// 不合格单号
        /// </summary>
        [DataMember]
        public string UnqualificationDocumentNumber { get; set; }

        /// <summary>
        /// 来源 质量复核流程
        /// </summary>
        [DataMember]
        public string source { get; set; }

        //规格
        [DataMember]
        public string Specific
        {
            get;
            set;
        }
        //剂型
        [DataMember]
        public string DosageType
        {
            get;
            set;
        }

        /// <summary>
        /// 生产日期
        /// </summary>
        [DataMember]
        public DateTime produceDate
        {
            get;
            set;
        }

        /// <summary>
        /// 失效期
        /// </summary>
        [DataMember]
        public DateTime ExpireDate
        {
            get;
            set;
        }

        /// <summary>
        /// 品种ID
        /// </summary>
        [DataMember]
        public Guid DrugInfoId
        {
            get;
            set;
        }

        /// <summary>
        /// 产地
        /// </summary>
        [DataMember]
        public string Origin
        {
            get;
            set;
        }

        /// <summary>
        /// 购进价格
        /// </summary>
        [DataMember]
        public decimal PurchasePrice { get; set; }

        /// <summary>
        /// 不合格ID
        /// </summary>
        [DataMember]
        public Guid DrugUnqualityId { get; set; }

        /// <summary>
        /// 生产厂家
        /// </summary>
        [DataMember]
        public string FactoryName { get;set; }

        /// <summary>
        /// 供货商
        /// </summary>
        [DataMember]
        public string Supplyer { get; set; }

        /// <summary>
        /// 采购单号
        /// </summary>
        [DataMember]
        public string PurchaseOrderDocumentNumber { get; set; }

        /// <summary>
        /// 采购单ID
        /// </summary>
        [DataMember]
        public Guid PurchaseOrderId { get; set; }

    }
}
