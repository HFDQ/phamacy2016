using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 采购收货单
    /// </summary>
    [Description("采购收货单")]
    [DataContract(IsReference = true)]
    public class PurchaseReceivingOrder : Entity, IStore
    {
        #region Entiy Property

        /// <summary>
        /// 单据编号
        /// </summary>
        [Required]
        [DataMember]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// 收货日期
        /// </summary>
        [DataMember]
        public DateTime OperateTime { get; set; }

        /// <summary>
        /// 发货日期
        /// </summary>
        [DataMember]
        public DateTime ShippingTime { get; set; }

        /// <summary>
        /// 发货地点
        /// </summary>
        [DataMember]
        public string ShippingAdress { get; set; }

        /// <summary>
        /// 发货单位
        /// </summary>
        [DataMember]
        public string ShippingUnit { get; set; }

        /// <summary>
        /// 运输单位
        /// </summary>
        [DataMember]
        public string TransportUnit { get; set; }

        /// <summary>
        /// 收货员ID
        /// </summary>
        [DataMember]
        public Guid OperateUserId { get; set; }

        [DataMember]
        public int OrderStatusValue { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus OrderStatus
        {
            get { return (OrderStatus)OrderStatusValue; }
            set { OrderStatusValue = (int)value; }
        }

        /// <summary>
        /// 收货备注
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

        [DataMember(Order = 11)]
        public virtual ICollection<PurchaseReceivingOrderDetail> PurchaseReceivingOrderDetails { get; set; }


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
        public OrderType RelatedOrderType
        {
            get { return (OrderType)RelatedOrderTypeValue; }
            set { RelatedOrderTypeValue = (int)value; }
        }
        #endregion
    }
}
