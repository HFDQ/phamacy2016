using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 销售单明细
    /// 销售单新增销售单明细的时候应该针对药物库存选择药物检查药物库存量
    /// 一条销售明细，只能(一药物库存记录+数量)
    /// 销售单明细产生时要处理药物库存的销售数量(此时还未出库)(以便下个销售单明细时确认可销售数量)
    /// 一个销售单对应多个销售单明细
    /// </summary>
    [Description("销售单明细")]
    [DataContract(IsReference = true)]
    public class SalesOrderDetail : Entity, ILEntity, IStore
    {
        #region Entiy Property

        /// <summary>
        /// 行号用于票据打印和显示顺序
        /// 一个销售单-对应的几个此明细要求连续
        /// </summary>
        [DataMember]
        public int Index { get; set; }

        /// <summary>
        /// 创建用户编号
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
        [DataMember(Order = 2)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember]
        public DateTime UpdateTime { get; set; }

        [DataMember]
        public Guid StoreId { get; set; }

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
        /// 销售单价
        /// </summary>
        [DataMember]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 实际销售单价
        /// </summary>
        [DataMember]
        public decimal ActualUnitPrice { get; set; }

        /// <summary>
        /// 销售金额
        /// </summary>
        [DataMember]
        public decimal Price { get; set; }

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
        /// 剂型
        /// </summary>
        
        [DataMember]
        public string DictionaryDosageCode { get; set; }

        /// <summary>
        /// 产地
        /// </summary>        
        [DataMember]
        public string Origin { get; set; }

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
        /// 折扣
        /// </summary>
        [DataMember]
        public decimal Discount { get; set; }

        /// <summary>
        /// 描述即备注
        /// </summary>
        
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public decimal PurchasePrice { get; set; }
        #endregion

        #region
        /// <summary>
        /// 退货数量
        /// </summary>
        [DataMember]
        public decimal ReturnAmount { get; set; }
        /// <summary>
        /// 冲差单价
        /// </summary>
        [DataMember]
        public decimal ChangeAmount { get; set; }
        /// <summary>
        /// 已出库数量
        /// </summary>
        [DataMember]
        public decimal OutAmount { get; set; }
        #endregion

        #region Navigation Property

        /// <summary>
        /// 出库单明细编号
        /// </summary>
        [DataMember(Order = 6)]
        public Guid OutInventoryDetailID { get; set; }
        

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
        /// 药物库存ID
        /// </summary>
        [DataMember(Order = 6)]
        public Guid DrugInventoryRecordID { get; set; }

        #endregion

    }
}

