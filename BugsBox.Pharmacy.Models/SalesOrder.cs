using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 销售单
    /// 一个销售单可以分多次发货
    /// 销售单新增销售单明细的时候应该针对药物库存选择药物检查药物库存量
    /// </summary>
    [Description("销售单")]
    [DataContract(IsReference = true)]
    public class SalesOrder : Entity, IStore, ILEntity
    {
        #region Entiy Property  
       
        /// <summary>
        /// 创建用户编号
        /// 此表为销售人员编号
        /// </summary>
        [DataMember(Order = 0)]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember(Order = 1)]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DataMember(Order = 2)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember(Order = 3)]
        public DateTime UpdateTime { get; set; }

        [DataMember(Order = 4)]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 销售人员
        /// </summary>
        [Required]
        [DataMember(Order = 5)]
        public string SalerName { get; set; }

        /// <summary>
        /// 销售日期
        /// </summary>
        [DataMember(Order = 6)]
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// 描述即备注
        /// </summary>
        [DataMember(Order = 7)]
        public string Description { get; set; }

        /// <summary>
        /// 销售总额（金额合计）
        /// </summary>
        [DataMember(Order = 8)]
        public decimal TotalMoney { get; set; }

        /// <summary>
        /// 销售单号
        /// </summary>
        [Required]
        [DataMember(Order = 9)]
        public string OrderCode { get; set; }

        /// <summary>
        /// 已经全部发货
        /// </summary>
        [DataMember(Order = 10)]
        public bool AllDelivered { get; set; }

        /// <summary>
        /// 全部发货日期
        /// </summary>
        [DataMember(Order = 11)]
        public DateTime? AllDeliverTime { get; set; }


        /// <summary>
        /// 药品销售类型值
        /// </summary>
        [DataMember]
        public int SalesDrugTypeValue { get; set; }

        /// <summary>
        /// 药品销售类型
        /// </summary>
        public SalesDrugType SalesDrugType
        {
            get { return (SalesDrugType)SalesDrugTypeValue; }
            set { SalesDrugTypeValue = (int)value; }
        }

        /// <summary>
        /// 提货方式值
        /// </summary>
        [DataMember]
        public int PickUpGoodTypeValue { get; set; }

        /// <summary>
        /// 提货方式
        /// </summary>
        [DataMember]
        public PickUpGoodType PickUpGoodType
        {
            get { return (PickUpGoodType)PickUpGoodTypeValue; }
            set { PickUpGoodTypeValue = (int)value; }
        }

        /// <summary>
        /// 提货人员
        /// </summary>
        [DataMember]
        public string PickUpMan 
        {
            get;
            set; 
        }

        /// <summary>
        /// 客户采购员
        /// </summary>
        [DataMember]
        public string PurchaseUnitMan
        {
            get;
            set;
        }

        /// <summary>
        /// 客户采购员ID
        /// </summary>
        [DataMember]
        public Guid PurchaseUnitManID
        {
            get;
            set;
        }



        #region 流程相关

       /// <summary>
        /// 订单状态
       /// </summary>
       [DataMember]
        public OrderStatus OrderStatus 
        {
            get
            {
                return (OrderStatus) OrderStatusValue;
            }
            set
            {
                OrderStatusValue = (int)value;
            }
        }

         /// <summary>
         /// 订单类型值
         /// </summary>
        [DataMember]
        public int OrderStatusValue { get; set; }

        #region 审核
        /// <summary>
        /// 审核通过时间
        /// </summary>
        [DataMember]
        public DateTime? ApprovaledTime { get; set; }

        /// <summary>
        /// 审核通过者
        /// </summary>
        [DataMember]
        public Guid ApprovalUserId { get; set; } 
        #endregion

        #region 取消

        /// <summary>
        /// 取消时间
        /// </summary>
        [DataMember]
        public DateTime? CancelTime { get; set; }

        /// <summary>
        /// 取消用户ID
        /// </summary>
        [DataMember]
        public Guid CancelUserID { get; set; }

        /// <summary>
        /// 取消理由
        /// </summary>
        [DataMember]
        public string CancelReason { get; set; }

        /// <summary>
        /// 取消单号
        /// </summary>
        [DataMember]
        public string OrderCancelCode { get; set; }
        
        #endregion

        #region 结算
        /// <summary>
        /// 结算单号
        /// </summary>
        [DataMember]
        public string OrderBalanceCode { get; set; }

        /// <summary>
        /// 结算时间
        /// </summary>
        [DataMember]
        public DateTime? BalanceTime { get; set; }

        /// <summary>
        /// 结算用户ID
        /// </summary>
        [DataMember]
        public Guid BalanceUserID { get; set; }

        /// <summary>
        /// 结算理由
        /// </summary>
        [DataMember]
        public string BalanceReason { get; set; }

        /// <summary>
        /// 结算方式
        /// </summary>
        [DataMember]
        public Guid payMentMethodID { get; set; } 
        #endregion

        #region 销售出库

        /// <summary>
        /// 销售出库单号
        /// </summary>
        [DataMember]
        public string OrderOutInventoryCode { get; set; }

        /// <summary>
        /// 销售出库用户ID
        /// </summary>
        [DataMember]
        public Guid OrderOutInventoryUserID { get; set; }

        /// <summary>
        ///  销售出库时间
        /// </summary>
        [DataMember]
        public DateTime? OrderOutInventoryTime { get; set; }
        #endregion

        #region 销售出库审核

        /// <summary>
        /// 销售出库单号
        /// </summary>
        [DataMember]
        public string OrderOutInventoryCheckCode { get; set; }

        /// <summary>
        /// 销售出库审核用户ID
        /// </summary>
        [DataMember]
        public Guid OrderOutInventoryCheckUserID { get; set; }

        /// <summary>
        ///  销售出库审核时间
        /// </summary>
        [DataMember]
        public DateTime? OrderOutInventoryCheckTime { get; set; }
        #endregion

        #region 销退申请
        /// <summary>
        /// 销退单号
        /// </summary>
        [DataMember]
        public string OrderReturnCode { get; set; }

        /// <summary>
        /// 销退时间
        /// </summary>
        [DataMember]
        public DateTime? OrderReturnTime { get; set; }

        /// <summary>
        /// 销退用户ID
        /// </summary>
        [DataMember]
        public Guid OrderReturnUserID { get; set; }

        /// <summary>
        /// 销退理由
        /// </summary>
        [DataMember]
        public string OrderReturnReason { get; set; }

        #endregion

        #region 销退取消
        /// <summary>
        /// 销退取消单号
        /// </summary>
        [DataMember]
        public string OrderReturnCancelCode { get; set; }

        /// <summary>
        /// 销退时间
        /// </summary>
        [DataMember]
        public DateTime? OrderReturnCancelTime { get; set; }

        /// <summary>
        /// 销退用户ID
        /// </summary>
        [DataMember]
        public Guid OrderReturnCancelUserID { get; set; }

        /// <summary>
        /// 销退理由
        /// </summary>
        [DataMember]
        public string OrderReturnCancelReason { get; set; }

        #endregion

        #region 销退验收
        /// <summary>
        /// 销退验收单号
        /// </summary>
        [DataMember]
        public string OrderReturnCheckCode { get; set; }

        /// <summary>
        /// 销退验收时间
        /// </summary>
        [DataMember]
        public DateTime? OrderReturnCheckTime { get; set; }

        /// <summary>
        /// 销退验收ID
        /// </summary>
        [DataMember]
        public Guid OrderReturnCheckUserID { get; set; }

        #endregion

        #region 销退入库
        /// <summary>
        /// 销退入库单号
        /// </summary>
        [DataMember]
        public string OrderReturnInInventoryCode { get; set; }

        /// <summary>
        /// 销退入库时间
        /// </summary>
        [DataMember]
        public DateTime? OrderReturnInInventoryTime { get; set; }

        /// <summary>
        /// 销退入库用户ID
        /// </summary>
        [DataMember]
        public Guid OrderReturnInInventoryUserID { get; set; }

        #endregion

        #region 直接销退
        /// <summary>
        /// 直接销退单号
        /// </summary>
        [DataMember]
        public string OrderDirectReturnCode { get; set; }

        /// <summary>
        /// 直接销退时间
        /// </summary>
        [DataMember]
        public DateTime? OrderDirectReturnTime { get; set; }

        /// <summary>
        /// 直接销退用户ID
        /// </summary>
        [DataMember]
        public Guid OrderDirectReturnUserID { get; set; }

        #endregion

        #region 



        #endregion

        #endregion



        /// <summary>
        /// 是否需要发票
        /// </summary>
        [DataMember]
        public Boolean? IsNeedInvoice { get; set; }

        /// <summary>
        /// 是否已开发票
        /// </summary>
        [DataMember]
        public Boolean? IsInvoice { get; set; }

        /// <summary>
        /// 实收金额
        /// </summary>
        [DataMember]
        public Decimal? ReceivedMoney { get; set; }

        /// <summary>
        /// 发票金额
        /// </summary>
        [DataMember]
        public Decimal? InvoiceMoney { get; set; }

        /// <summary>
        /// 是否已付款
        /// </summary>
        [DataMember]
        public Boolean? IsPayed { get; set; }



        #endregion

        #region Navigation Property

        /// <summary>
        /// 出库编号ID
        /// </summary>
        [DataMember(Order = 12)]
        public Guid OutInventoryId { get; set; }


        /// <summary>
        /// 购货单位编号
        /// </summary>
        [DataMember(Order = 12)]
        public Guid PurchaseUnitId { get; set; }

        /// <summary>
        /// 购货单位 
        /// </summary>
        [DataMember(Order = 13)]
        public virtual PurchaseUnit PurchaseUnit { get; set; }

        /// <summary>
        /// 销售明细
        /// </summary>
        [DataMember(Order = 14)]
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }

        /// <summary>
        /// 发货记录
        /// </summary>
        [DataMember(Order = 15)]
        public virtual ICollection<SalesOrderDeliverRecord> SalesOrderDeliverRecords { get; set; }

        #endregion


        #region 增值税代码和号码
        /// <summary>
        /// 增值税代码
        /// </summary>
        [DataMember]
        public string VATCode { get; set; }

        /// <summary>
        /// 增值税号码
        /// </summary>
        [DataMember]
        public string VATNumber { get; set; }

        /// <summary>
        /// 这个单据的统一税率
        /// </summary>
        [DataMember]
        public decimal VATRate { get; set; }
        #endregion
    }
}

