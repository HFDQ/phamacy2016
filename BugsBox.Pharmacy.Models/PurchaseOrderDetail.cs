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
    /// 采购明细
    /// </summary>
    [Description("采购明细")]
    [DataContract(IsReference = true)]
    public class PurchaseOrderDetail : Entity, IStore
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

        /// <summary>
        /// 数量
        /// </summary>
        [DataMember(Order = 5)]
        public decimal Amount { get; set; }

        /// <summary>
        /// 采购价
        /// </summary>
        [DataMember(Order = 6)]
        public decimal PurchasePrice { get; set; }

        /// <summary>
        /// 税额
        /// </summary>
        [DataMember(Order = 7)]
        public decimal AmountOfTax { get; set; }
        #endregion

        #region Navigation Property

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 药物编号
        /// </summary>
        [DataMember(Order = 8)]
        public Guid DrugInfoId { get; set; }

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

        [DataMember(Order = 11)]
        public Decimal? sequence { get;set;}
        #endregion
    }
}

