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
    /// 采购到货验货记录
    /// 针对一条采购单(PurchaseOrder)有多条到货记录
    /// 一次到货记录产生一条入库记录信息 
    /// 入库记录与到货记录是一对一的
    /// </summary>
    [Description("采购到货验收")]
    [DataContract(IsReference = true)]
    public class PurchaseCheckingOrderDetail : Entity, IStore
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
        public decimal PurchasePrice { get; set; }

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
        /// 收货数量
        /// </summary>
        [DataMember(IsRequired = false)]
        public decimal ReceivedAmount { get; set; }

        /// <summary>
        /// 验收合格数量
        /// </summary>
        [Required]
        [DataMember]
        public decimal QualifiedAmount { get; set; }

        /// <summary>
        /// 疑问药品数量
        /// </summary>
        [DataMember(EmitDefaultValue = true, IsRequired = false)]
        public decimal  UnQualifiedAmount { get; set; }

        /// <summary>
        /// 验收结果
        /// </summary>
        [Required]
        [DataMember]
        public int CheckResult { get; set; }

        /// <summary>
        /// 备注(注明不合格事项及处置措施)
        /// </summary>
        [DataMember]
        public string Decription { get; set; }

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
        /// 采购验货单
        /// </summary>
        [DataMember]
        public virtual PurchaseCheckingOrder PurchaseCheckingOrder { get; set; }  

        /// <summary>
        /// 采购验货单ID
        /// </summary>
        [DataMember]
        public Guid PurchaseCheckingOrderId { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        [DataMember(Order = 11)]
        public Decimal? sequence { get; set; }

        #endregion

    }
}

