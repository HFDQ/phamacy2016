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
    /// 零售单明细
    /// </summary>
    [Description("零售单明细")]
    [DataContract(IsReference = true)]
    public class RetailOrderDetail : Entity, ILEntity, IStore
    {
        #region Entiy Property

        #region ILEntity

        /// <summary>
        /// 营业员编号
        /// </summary>
        [DataMember]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember]
        public DateTime UpdateTime { get; set; }

        #endregion

        #region 零售单明细

        /// <summary>
        /// 明细编号
        /// </summary>
        [DataMember]
        public int Index { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required]
        [DataMember]
        public string productName { get; set; }


        /// <summary>
        /// 商品编号
        /// </summary>
        [Required]
        [DataMember]
        public string productCode { get; set; }


        /// <summary>
        /// 生产批号
        /// </summary>
        [Required]
        [DataMember]
        public string BatchNumber { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        public decimal Amount { get; set; }

        /// <summary>
        /// 退货数量
        /// </summary>
        [DataMember]
        public decimal ReturnAmount { get; set; }

        /// <summary>
        /// 是否拆零
        /// </summary>
        [DataMember]
        public bool IsDismanting { get; set; }

        /// <summary>
        /// 拆零数量
        /// </summary>
        [DataMember]
        public decimal DismantingAmount { get; set; }

        /// <summary>
        /// 价格取药品基本信息的零售价
        /// </summary>
        [DataMember]
        public decimal UnitPrice { get; set; }


        /// <summary>
        /// 药品的拆零单价
        /// </summary>
        [DataMember]
        public decimal DismantingUnitPrice { get; set; }

        /// <summary>
        /// 实际销售单价
        /// </summary>
        [DataMember]
        public decimal ActualUnitPrice { get; set; }

        /// <summary>
        /// 实际拆零单价
        /// </summary>
        [DataMember]
        public decimal ActualDismantingUnitPrice { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        public string MeasurementUnit { get; set; }

        //规格
        [Required]
        [DataMember]
        public string SpecificationCode { get; set; }

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


        //厂家全称
        [Required]
        [DataMember]
        public string FactoryName { get; set; }

        /// <summary>
        /// 描述即备注
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// 是否打折
        /// </summary>
        [DataMember]
        public bool IsDiscount { get; set; }

        /// <summary>
        /// 折扣(1-100)
        /// 未折扣是100
        /// 75折是75
        /// </summary> 
        [DataMember]
        public decimal Discount { get; set; }

        /// <summary>
        /// 折后价=Price*Discount*100
        /// </summary>
        public decimal DiscountPrice { get; set; }

        /// <summary>
        /// 明细小计金额=DiscountPrice*Count
        /// </summary>
        [DataMember]
        public decimal TotalMoney { get; set; }

        #endregion

        #endregion

        #region Navigation Property

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 零售单编号
        /// </summary>
        [DataMember]
        public Guid RetailOrderId { get; set; }

        /// <summary>
        /// 零售单
        /// </summary>
        [DataMember]
        public virtual RetailOrder RetailOrder { get; set; }

        /// <summary>
        /// 药物库存ID
        /// </summary>
        [DataMember(Order = 6)]
        public Guid DrugInventoryRecordID { get; set; }

        #endregion
    }
}
