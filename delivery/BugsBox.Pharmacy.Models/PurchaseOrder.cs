using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 采购单
    /// Version:2013.07.16.2143 完成 
    /// </summary>
    [Description("采购单")]
    [DataContract(IsReference = true)]
    public class PurchaseOrder : Entity, ILEntity, IStore
    {
        #region Entiy Property

        /// <summary>
        /// 单据编号
        /// </summary>
        [Required]
        [DataMember]
        public string DocumentNumber { get; set; }


        /// <summary>
        /// 采购总额
        /// </summary>
        [DataMember]
        public decimal TotalMoney { get; set; }

        /// <summary>
        /// 货款合计
        /// </summary>
        [DataMember]
        public decimal PaymentForGoodsMoney { get; set; }

        /// <summary>
        /// 税额合计
        /// </summary>
        [DataMember]
        public decimal AmountOfTaxMoney { get; set; }

        /// <summary>
        /// 付款期限
        /// </summary>
        [DataMember]
        public DateTime? PaymentDate { get; set; }

        /// <summary>
        /// 失效天数
        /// </summary>
        [DataMember]
        public int InValidDays { get; set; }

        /// <summary>
        /// 发货日期
        /// </summary>
        [DataMember]
        public DateTime? AllReceiptedDate { get; set; }

        /// <summary>
        /// 采购日期
        /// </summary>
        [DataMember]
        public DateTime PurchasedDate { get; set; }

        /// <summary>
        /// 供货商销售人员/业务员编号,可以根据供应商找到关联的业务员
        /// </summary>
        [DataMember]
        public Guid SupplyUnitAccountExecutiveId { get; set; }


        /// <summary>
        /// 采购单创建日期
        /// </summary>
        [Required]
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID(采购员)
        /// </summary>
        [DataMember]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 采购单备注
        /// </summary>
        [DataMember]
        public string Decription { get; set; }

        /// <summary>
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
        /// 审批日期 “采购记录”中某种药品的采购数量与到货数量不同，需经过审批修改采购数量（仅数量能修改）
        /// </summary>
        [DataMember]
        public DateTime? AmountApprovaledTime { get; set; }

        /// <summary>
        /// 审指人ID
        /// </summary>
        [DataMember]
        public Guid AmountApprovalUserId { get; set; }

        /// <summary>
        /// 审核备注
        /// </summary>
        [DataMember]
        public string AmountApprovalDecription { get; set; }


        [DataMember]
        public int OrderStatusValue { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        [DataMember]
        public OrderStatus OrderStatus
        {
            get { return (OrderStatus)OrderStatusValue; }
            set { OrderStatusValue = (int)value; }
        }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        ///  是否为直销订单
        /// </summary>
        [DataMember]
        public bool DirectMarketing { get; set; }

        /// <summary>
        /// 运输方式
        /// </summary>
        [DataMember]
        public string ShippingMethod { get; set; }
        #endregion

        #region Navigation Property

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 供应商编号
        /// </summary>
        [DataMember]
        public Guid SupplyUnitId { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        [DataMember]
        public virtual SupplyUnit SupplyUnit { get; set; }

        [DataMember]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        [DataMember]
        public virtual ICollection<PurchaseReceivingOrder> PurchaseReceivingOrders { get; set; }

        [DataMember]
        public virtual ICollection<PurchaseCheckingOrder> PurchaseCheckingOrders { get; set; }

        [DataMember]
        public virtual ICollection<PurchaseInInventeryOrder> PurchaseInInventeryOrders { get; set; }

        [DataMember]
        public virtual ICollection<PurchaseOrderReturn> PurchaseOrderReturns { get; set; }

        /// <summary>
        /// 关联采购单号
        /// </summary>
        [DataMember]
        public Guid ReleatedPurchaseOrderId { get; set; }
        #endregion

        /// <summary>
        /// 返税人
        /// </summary>
        [DataMember]
        public Guid? TaxReturnUserID { get; set; }

        /// <summary>
        /// 发票是否已到
        /// </summary>
        [DataMember]
        public Boolean? IsInvoiceArrival { get; set; }

        /// <summary>
        /// 发票金额
        /// </summary>
        [DataMember]
        public Decimal? InvoiceMoney { get; set; }

        /// <summary>
        /// 是否已打款
        /// </summary>
        [DataMember]
        public Boolean? IsPayed { get; set; }

        /// <summary>
        /// 实际付款金额
        /// </summary>
        [DataMember]
        public Decimal? PayMoney { get; set; }

        /// <summary>
        /// 多次到货，多次发票到货，发票金额需合并
        /// </summary>
        [DataMember]
        public Guid? PurchaseOrderConcatID { get; set; }
    }
}

