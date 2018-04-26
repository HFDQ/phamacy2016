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
    /// 销售发货记录
    /// 一个销售单可分多次发货记录但一条订单明细只能发一次且全发因为生成订单明细时已经指定了药物库存
    /// 一次发货产生一次出库单，销售的出库单在产生发货记录时产生时产生，当然出库是要审的
    /// 针对发货也是要审的
    /// 提货时销售发货记录必须审核且通过,出库单也必须审核且通过。
    /// 提货时须装发货记录标为已经发货状态,出库单也须标识为已出库此时要处理相关库存的数量
    /// </summary>
    [Description("销售发货记录")]
    [DataContract(IsReference = true)]
    public class SalesOrderDeliverRecord : Entity, ILEntity, IStore
    {
        #region Entiy Property


        /// <summary>
        /// 创建用户编号
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


        [Required]
        public ApprovalStatus ApprovalStatus { get; set; }


        [DataMember(Order = 5)]
        public DateTime? ApprovaledTime { get; set; }

        /// <summary>
        /// 审批用户编号
        /// </summary>
        [DataMember(Order = 6)]
        public Guid ApprovalUserId { get; set; }

        /// <summary>
        /// 已经发货
        /// </summary>
        [DataMember(Order = 7)]
        public bool HadDelivered { get; set; }

        /// <summary>
        /// 发货日期
        /// </summary>
        [DataMember(Order = 8)]
        public DateTime? DeliverTime { get; set; }

        #endregion

        #region Navigation Property

        /// <summary>
        /// 出库记录
        /// </summary>
        [DataMember(Order = 9)]
        public Guid OutInventoryId { get; set; }

        /// <summary>
        /// 所属订单编号
        /// </summary>
        [DataMember(Order = 10)]
        public Guid SalesOrderId { get; set; }

        /// <summary>
        /// 针对哪个订单
        /// </summary>
        [DataMember(Order = 11)]
        public virtual SalesOrder SalesOrder { get; set; }

        [DataMember]
        public virtual ICollection<SalesOrderDeliverDetail> SalesOrderDeliverDetails { get; set; }


        #endregion
    }
}

