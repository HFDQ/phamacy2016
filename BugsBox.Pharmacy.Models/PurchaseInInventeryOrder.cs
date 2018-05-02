using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 库存记录
    /// </summary>
    [Description("库存记录")]
    [DataContract(IsReference = true)]
    public class PurchaseInInventeryOrder : Entity, IStore
    {
        #region Entiy Property

        /// <summary>
        /// 单据编号
        /// </summary>
        [Required]
        [DataMember]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        [DataMember]
        public DateTime OperateTime { get; set; }

        /// <summary>
        /// 库管员ID
        /// </summary>
        [DataMember]
        public Guid OperateUserId { get; set; }

        [DataMember]
        public int OrderStatusValue { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        /// 
        [NotMapped]
        public OrderStatus OrderStatus
        {
            get { return (OrderStatus)OrderStatusValue; }
            set { OrderStatusValue = (int)value; }
        }
        /// <summary>
        /// 入库备注
        /// </summary>
        [DataMember]
        public string Decription { get; set; }

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 采购记录
        /// </summary>
        [DataMember(Order = 9)]
        public virtual PurchaseOrder PurchaseOrder { get; set; }


        /// <summary>
        /// 采购单Id
        /// </summary>
        [DataMember(Order = 10)]
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

        [DataMember(Order = 11)]
        public virtual ICollection<PurchaseInInventeryOrderDetail> PurchaseInInventeryOrderDetails { get; set; }

        #endregion
    }
}
