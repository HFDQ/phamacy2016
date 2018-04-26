using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 库存记录详细
    /// </summary>
    [Description("库存记录详细")]
    [DataContract(IsReference = true)]
    public class PurchaseInInventeryOrderDetail : Entity, IStore
    {

        #region Entiy Property

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
        [DataMember]
        public Guid DrugInfoId { get; set; }

        /// <summary>
        /// 采购价
        /// </summary>
        [DataMember]
        public decimal PurchasePrice { get; set; }

        /// <summary>
        /// 生产批号
        /// </summary>
        [Required]
        //[MinLength(8)]
        [DataMember]
        public string BatchNumber { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        [DataMember]
        public DateTime PruductDate { get; set; }

        /// <summary>
        /// 有效期至
        /// </summary>
        [DataMember]
        public DateTime OutValidDate { get; set; }

        /// <summary>
        /// 到货数量
        /// </summary>
        [Required]
        [DataMember]
        public decimal ArrivalAmount { get; set; }

        /// <summary>
        /// 到货日期
        /// </summary>
        [Required]
        [DataMember]
        public DateTime ArrivalDateTime { get; set; }

        /// <summary>
        /// 库区编号
        /// </summary>
        [DataMember]
        public Guid WarehouseZoneId { get; set; }

        ///// <summary>
        ///// 库区
        ///// </summary>
        //[DataMember]
        //public virtual WarehouseZone WarehouseZone { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Decription { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        [DataMember(Order = 11)]
        public Decimal? sequence { get; set; }

        /// <summary>
        /// 库存记录
        /// </summary>
        [DataMember]
        public virtual PurchaseInInventeryOrder PurchaseInInventeryOrder { get; set; }

        /// <summary>
        /// 库存记录ID
        /// </summary>
        [DataMember]
        public Guid PurchaseInInventeryOrderId { get; set; }

        /// <summary>
        /// 货位存储ID
        /// </summary>
        [DataMember]
        public Guid WarehouseZonePositionId { get; set; }

        #endregion

    }
}

