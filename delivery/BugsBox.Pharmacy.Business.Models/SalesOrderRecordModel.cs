using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    /// <summary>
    /// 销售记录检索条件
    /// </summary>
    [DataContract]
    public class SalesOrderRecordInput
    {
        /// <summary>
        /// 开始日期
        /// </summary>
        [DataMember]
        public DateTime? SalesFromDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        [DataMember]
        public DateTime? SalesToDate { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        public string productName { get; set; }


        /// <summary>
        /// 商品编号
        /// </summary>
        [DataMember]
        public string productCode { get; set; }


        /// <summary>
        /// 生产批号
        /// </summary>
        [DataMember]
        public string BatchNumber { get; set; }


        /// <summary>
        /// 销售员
        /// </summary>
        [DataMember]
        public string Seller { get; set; }


        /// <summary>
        /// 药品经营范围
        /// </summary>
        [DataMember]
        public string GoodsTypeValue { get; set; }

        /// <summary>
        /// 采购商
        /// </summary>
        [DataMember]
        public Guid PurchaseUnitID { get; set; }

        /// <summary>
        /// 药品生产商
        /// </summary>
        [DataMember]
        public string FactoryName { get; set; }

        /// <summary>
        /// 是否管理药品0-全部、1-是、2-否
        /// </summary>
        [DataMember]
        public int IsSpecial { get; set; }
    }





    /// <summary>
    /// 销售记录输出结果
    /// </summary>
    [DataContract]
    public class SalesOrderRecordOutput
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public Guid id { get; set; }
        
        /// <summary>
        /// 通用名称
        /// </summary>
        [DataMember]
        public string ProductGeneralName { get; set; }

        [DataMember]
        public Guid SalesOrderId { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [DataMember]
        public string productCode { get; set; }

        /// <summary>
        /// 国药准字号
        /// </summary>
        [DataMember]
        public string permitCode { get; set; }

        /// <summary>
        /// 剂型
        /// </summary>
        [DataMember]
        public string drugType { get; set; }

        /// <summary>
        /// 批号
        /// </summary>
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
        /// 生产厂商
        /// </summary>
        [DataMember]
        public string FactoryName { get; set; }


        /// <summary>
        /// 购货单位
        /// </summary>
        [DataMember]
        public string PurchaseUnit { get; set; }

        /// <summary>
        /// 销售单号
        /// </summary>
        [DataMember]
        public string SalesOrderCode { get; set; }

        /// <summary>
        /// 销售数量
        /// </summary>
        [DataMember]
        public decimal Amount { get; set; }

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
        /// 销售日期
        /// </summary>
        [DataMember]
        public DateTime SalesDate { get; set; }

        /// <summary>
        /// 销售员
        /// </summary>
        [DataMember]
        public string Saler { get; set; }

        [DataMember]
        public Guid DrugInventoryRecordID { get; set; }					
    }
}
