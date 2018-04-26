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
    /// 验收记录
    /// </summary>
    [Description("验收记录")]
    [DataContract(IsReference = true)]
    public class PurchaseCheckingOrder : Entity, IStore
    {
        #region Entiy Property

        /// <summary>
        /// 单据编号
        /// </summary>
        [Required]
        [DataMember]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// 验收日期
        /// </summary>
        [DataMember]
        public DateTime OperateTime { get; set; }

        /// <summary>
        /// 验收员ID
        /// </summary>
        [DataMember]
        public Guid OperateUserId { get; set; }

        /// <summary>
        /// 第二验收人ID
        /// </summary>
        [DataMember]
        public Guid SecondCheckerId { get; set; }

        /// <summary>
        /// 第二验收人意见
        /// </summary>
        [DataMember]
        public string SecondCheckMemo { get; set; }
        /// <summary>
        /// 第二验收人姓名
        /// </summary>
        [DataMember]
        public string SecondCheckerName { get; set; }

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
        /// 验收备注
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
        public OrderType RelatedOrderType
        {
            get { return (OrderType)RelatedOrderTypeValue; }
            set { RelatedOrderTypeValue = (int)value; }
        }

        #endregion
    }
}
