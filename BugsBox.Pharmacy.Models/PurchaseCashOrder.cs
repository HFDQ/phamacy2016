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
    /// 采购结算单
    /// </summary>
    [Description("采购结算单")]
    [DataContract(IsReference = true)]
    public class PurchaseCashOrder : Entity, IStore
    {
        #region Entiy Property

        /// <summary>
        /// 单据编号
        /// </summary>
        [Required]
        [DataMember]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// 结算单创建日期
        /// </summary>
        [DataMember]
        public DateTime OperateTime { get; set; }

        /// <summary>
        /// 经办人ID
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
        /// 审批日期
        /// </summary>
        [DataMember]
        public DateTime? ApprovaledTime { get; set; }

        /// <summary>
        /// 审指人ID
        /// </summary>
        [DataMember]
        public Guid ApprovalUserId { get; set; }

        /// <summary>
        /// 审核备注
        /// </summary>
        [DataMember]
        public string ApprovalDecription { get; set; }


        /// <summary>
        /// 付款日期
        /// </summary>
        [DataMember]
        public DateTime PaymentTime { get; set; }

        /// <summary>
        /// 结算方式
        /// </summary>
        [DataMember]
        public virtual PaymentMethod PaymentMethod { get; set; }


        /// <summary>
        /// 结算方式
        /// </summary>
        [DataMember]
        public Guid PaymentMethodId { get; set; }


        //单据金额

        /// <summary>
        /// 已付金额
        /// </summary>
        [DataMember]
        public decimal PaymentedAmount { get; set; }

        /// <summary>
        /// 本次应付金额
        /// </summary>
        [DataMember]
        public decimal PaymentingAmount { get; set; }

        /// <summary>
        /// 本次付款金额
        /// </summary>
        [DataMember]
        public decimal PaymentAmount { get; set; }

        [DataMember]
        public int DealerMethodValue { get; set; }

        /// <summary>
        /// 经销方式(采购入库,采购退货)
        /// </summary>
        public DealerMethod DealerMethod
        {
            get { return (DealerMethod)DealerMethodValue; }
            set { DealerMethodValue = (int)value; }
        }

        /// <summary>
        /// 结算备注
        /// </summary>
        [DataMember]
        public string Decription { get; set; }

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

        #endregion
    }
}
