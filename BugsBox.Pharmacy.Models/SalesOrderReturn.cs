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
    /// 销售退货单
    /// </summary>
    [DataContract(IsReference = true)]
    public class SalesOrderReturn: Entity, ILEntity, IStore
    {

        /// <summary>
        /// 销退单号
        /// </summary>
        [DataMember]
        public string OrderReturnCode { get; set; }

        /// <summary>
        /// 销退理由
        /// </summary>
        [DataMember]
        public string OrderReturnReason { get; set; }

        /// <summary>
        /// 销退申请时间
        /// </summary>
        [DataMember]
        public DateTime OrderReturnTime { get; set; }

        /// <summary>
        /// 是否补发
        /// </summary>
        [DataMember]
        public bool IsReissue { get; set; }

        /// <summary>
        /// 销售员
        /// </summary>
        [DataMember]
        public Guid SellerID { get; set; }
        /// <summary>
        /// 销售员意见
        /// </summary>
        [DataMember]
        public string SellerMemo { get; set; }

        /// <summary>
        /// 销售员意见更新时间
        /// </summary>
        [DataMember]
        public DateTime SellerUpdateTime { get; set; }

        /// <summary>
        /// 营业部代表
        /// </summary>
        [DataMember]
        public Guid TradeUserID { get; set; }
        /// <summary>
        /// 营业部意见
        /// </summary>
        [DataMember]
        public string TradeMemo { get; set; }

        /// <summary>
        /// 营业部意见更新时间
        /// </summary>
        [DataMember]
        public DateTime TradeUpdateTime { get; set; }

        /// <summary>
        /// 质量管理部代表
        /// </summary>
        [DataMember]
        public Guid QualityUserID { get; set; }

        /// <summary>
        /// 质量管理部意见
        /// </summary>
        [DataMember]
        public string QualityMemo { get; set; }

        /// <summary>
        /// 质量管理部意见更新时间
        /// </summary>
        [DataMember]
        public DateTime QualityUpdateTime { get; set; }

        /// <summary>
        /// 销退处理状态
        /// </summary>
        [DataMember]
        public int OrderReturnStatusValue { get; set; }

        /// <summary>
        /// 销退处理状态
        /// </summary>
        [NotMapped]
        public OrderReturnStatus OrderReturnStatus
        {
            get
            {
                return (OrderReturnStatus)OrderReturnStatusValue;
            }
            set
            {
                OrderReturnStatusValue = (int)value;
            }
        }

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

        #region 销退取消
        /// <summary>
        /// 销退取消单号
        /// </summary>
        [DataMember]
        public string OrderReturnCancelCode { get; set; }

        /// <summary>
        /// 销退取消时间
        /// </summary>
        [DataMember]
        public DateTime? OrderReturnCancelTime { get; set; }

        /// <summary>
        /// 销退取消用户ID
        /// </summary>
        [DataMember]
        public Guid OrderReturnCancelUserID { get; set; }

        /// <summary>
        /// 销退取消理由
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

        /// <summary>
        /// 销售单编号
        /// </summary>
        [DataMember]
        public Guid SalesOrderID { get; set; }

        /// <summary>
        /// 销售单
        /// </summary>
        [DataMember(Order = 7)]
        public virtual SalesOrder SalesOrder { get; set; }

        /// <summary>
        /// 出库单编号
        /// </summary>
        [DataMember]
        public Guid OutInventoryID { get; set; }

        /// <summary>
        /// 出库单
        /// </summary>
        [DataMember(Order = 7)]
        public virtual OutInventory OutInventory { get; set; }

        /// <summary>
        /// 退库单明细
        /// </summary>
        [DataMember(Order = 14)]
        public virtual ICollection<SalesOrderReturnDetail> SalesOrderReturnDetails { get; set; }
    }
}

