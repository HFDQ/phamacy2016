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
    /// <summary>
    ///  采购退货单/购进退出
    /// </summary>
    [DataContract(IsReference = true)]
    public class PurchaseOrderReturn : Entity, ILEntity, IStore
    {

        /// <summary>
        /// 单据编号
        /// </summary>
        [Required]
        [DataMember]
        public string DocumentNumber { get; set; }

        [DataMember]
        public Guid CheckerUserId { get; set; }

        /// <summary>
        /// 检验员意见(过程检验员/进货检验员)
        /// </summary>
        [DataMember]
        public string CheckerSuggest { get; set; }

        /// <summary>
        /// 检验员意见更新时间
        /// </summary>
        [DataMember]
        public DateTime? CheckerUpdateTime { get; set; }

        [DataMember]
        public Guid QualityUserId { get; set; }

        /// <summary>
        /// 质量管理部意见
        /// </summary>
        [DataMember]
        public string QualitySuggest { get; set; }

        /// <summary>
        /// 质量管理部意见更新时间
        /// </summary>
        [DataMember]
        public DateTime? QualityUpdateTime { get; set; }

        [DataMember]
        public Guid GeneralManagerUserId { get; set; }

        /// <summary>
        /// 总经理意见
        /// </summary>
        [DataMember]
        public string GeneralManagerSuggest { get; set; }

        /// <summary>
        /// 总经理意见更新时间
        /// </summary>
        [DataMember]
        public DateTime? GeneralManagerUpdateTime { get; set; }

        [DataMember]
        public Guid FinanceDepartmentUserId { get; set; }
         /// <summary>
        /// 财务部意见
        /// </summary>
        [DataMember]
        public string FinanceDepartmentSuggest { get; set; }

        /// <summary>
        /// 财务部意见更新时间
        /// </summary>
        [DataMember]
        public DateTime? FinanceDepartmentUpdateTime { get; set; }

        /// <summary>
        /// 销退处理状态
        /// </summary>
        [DataMember]
        public int OrderStatusValue { get; set; }

        /// <summary>
        /// 销退处理状态
        /// </summary>
        [NotMapped]
        public OrderReturnStatus OrderStatus
        {
            get
            {
                return (OrderReturnStatus)OrderStatusValue;
            }
            set
            {
                OrderStatusValue = (int)value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Decription { get; set; }

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
        [DataMember]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember]
        public DateTime UpdateTime { get; set; }

        [DataMember]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 采购记录
        /// </summary>
        [DataMember]
        public virtual PurchaseOrder PurchaseOrder { get; set; }

        /// <summary>
        /// 采购单Id
        /// </summary>
        [DataMember]
        public Guid PurchaseOrderId { get; set; }

        /// <summary>
        /// 关联单号
        /// </summary>
        [DataMember]
        public Guid RelatedOrderId { get; set; }
        [DataMember]
        public string RelatedOrderDocumentNumber { get; set; }
        [DataMember]
        public int RelatedOrderTypeValue { get; set; }
        [NotMapped]

        public OrderType RelatedOrderType
        {
            get { return (OrderType)RelatedOrderTypeValue; }
            set { RelatedOrderTypeValue = (int)value; }
        }

        [DataMember]
        public virtual ICollection<PurchaseOrderReturnDetail> PurchaseOrderReturnDetails { get; set; }
    }
}

