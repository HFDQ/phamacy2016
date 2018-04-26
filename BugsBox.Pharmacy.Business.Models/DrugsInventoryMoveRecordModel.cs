using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel;

namespace BugsBox.Pharmacy.Business.Models
{
    [DataContract]
    public class DrugsInventoryMoveRecordModel
    {
        [DataMember]
        [DisplayName("序号")]
        public int Index { get; set; }
        
        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        [DisplayName("品名")]
        public string productName { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [DataMember]
        [DisplayName("规格")]
        public string SpecificationCode { get; set; }

        /// <summary>
        /// 剂型
        /// </summary>
        [DataMember]
        [DisplayName("剂型")]
        public string Dosage { get; set; }

        /// <summary>
        /// 厂家全称
        /// </summary>
        [DataMember]
        [DisplayName("生产厂家")]
        public string FactoryName { get; set; }

        /// <summary>
        /// 产地
        /// </summary>
        [DataMember]
        [DisplayName("产地")]
        public string Origin { get; set; }

        /// <summary>
        /// 生产批号
        /// </summary>
        [DataMember]
        [DisplayName("批号")]
        public string BatchNumber { get; set; }
        
        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        [DisplayName("数量")]
        public decimal Amount { get; set; }
        /// <summary>
        /// 现库存数量
        /// </summary>
        [DataMember]
        [DisplayName("当前库存")]
        public decimal CanSaleNum { get; set; }
        /// <summary>
        /// 销售金额
        /// </summary>
        [DataMember]
        public decimal Price { get; set; }
        

        /// <summary>
        /// 生产日期
        /// </summary>
        [DataMember]
        [DisplayName("生产日期")]
        public DateTime PruductDate { get; set; }

        /// <summary>
        /// 有效期至
        /// </summary>
        [DataMember]
        [DisplayName("有效期至")]
        public DateTime OutValidDate { get; set; }

        

        /// <summary>
        /// 现仓库
        /// </summary>
        [DataMember]
        [DisplayName("现仓库")]
        public string WarehouseName { get; set; }

        /// <summary>
        /// 原仓库
        /// </summary>
        [DataMember]
        [DisplayName("原仓库")]
        public string OriginWarehouseName { get; set; }

        /// <summary>
        /// 现库区
        /// </summary>
        [DataMember]
        [DisplayName("现库区")]
        public string WarehouseZoneName { get; set; }
        /// <summary>
        /// 原库区
        /// </summary>
        [DataMember]
        [DisplayName("原库区")]
        public string OriginWarehouseZoneName { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        [DataMember]
        [DisplayName("移库原因")]
        public string Explain { get; set; }

        /// <summary>
        /// 审批状态值
        /// </summary>
        [DataMember]
        public int Status { get; set; }

        /// <summary>
        /// 审批状态
        /// </summary>
        [DataMember]
        [DisplayName("状态")]
        public string StatusStr { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        [DataMember]
        [DisplayName("申请时间")]
        public DateTime CreateTime { get; set; }
    }
}
