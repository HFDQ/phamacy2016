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
    /// 出库明细
    /// 针对销售单的出库明细
    /// 涉及的药物库存 由销售单明细(SalesOrderDetail)所指明的药物库存记录处理
    /// </summary>
    [Description("销售出库单")]
    [DataContract(IsReference = true)]
    public class OutInventoryDetail:Entity,IStore
    {
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
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember]
        public DateTime UpdateTime { get; set; }

        #region 订单信息拷贝
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
        [Required]
        [DataMember]
        public string Description { get; set; }
        #endregion

        /// <summary>
        /// 出库数量(可编辑,考虑到多次出库)
        /// </summary>
        [Required]
        [DataMember]
        public decimal OutAmount { get; set; }

        /// <summary>
        ///  仓库编号
        /// </summary>
        [Required]
        [DataMember]
        public string WarehouseCode { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        [Required]
        [DataMember]
        public string WarehouseName { get; set; }

        /// <summary>
        /// 库区编码(货架编号)
        /// </summary>
        [DataMember]
        public string WarehouseZoneCode { get; set; }

        /// <summary>
        /// 库区名称(货架名称)
        /// </summary>
        [DataMember]
        public string WarehouseZoneName { get; set; }

        /// <summary>
        /// 当时的可卖数量
        /// </summary>
        [DataMember]
        public decimal CanSaleNum { get; set; }

        #region Navigation Property

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 订单ID
        /// </summary>
        [DataMember]
        public Guid SalesOrderId { get; set; }
        /// <summary>
        /// 订单详细ID
        /// </summary>
        [DataMember]
        public Guid SalesOrderDetailId { get; set; }
        /// <summary>
        /// 销退ID
        /// </summary>
        [DataMember]
        public Guid SalesOrderReturnId { get; set; }
        /// <summary>
        /// 销退详细ID
        /// </summary>
        [DataMember]
        public Guid SalesOrderDetailReturnId { get; set; }

        /// <summary>
        /// 药物库存ID
        /// </summary>
        [DataMember(Order = 6)]
        public Guid DrugInventoryRecordID { get; set; }

        /// <summary>
        /// 出库ID
        /// </summary>
        [DataMember(Order = 7)]
        public Guid SalesOutInventoryID { get; set; }

        /// <summary>
        /// 出库单
        /// </summary>
        [DataMember]
        public virtual OutInventory SalesOutInventory { get; set; }
   
        #endregion
    }
}
