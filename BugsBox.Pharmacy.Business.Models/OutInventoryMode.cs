using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    [DataContract]
    public class OutInventoryMode
    {
        [DataMember]
        public int Index { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        [DataMember]
        public string productCode { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        public string productName { get; set; }
        /// <summary>
        /// 生产批号
        /// </summary>
        [DataMember]
        public string BatchNumber { get; set; }
        /// <summary>
        /// 销售单价
        /// </summary>
        [DataMember]
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        public int Amount { get; set; }
        /// <summary>
        /// 销售金额
        /// </summary>
        [DataMember]
        public decimal Price { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
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
        [DataMember]
        public string FactoryName { get; set; }




        /// <summary>
        /// 仓库名称
        /// </summary>
        [DataMember]
        public string WarehouseName { get; set; }
        /// <summary>
        /// 编码
        /// </summary> 
        [DataMember]
        public string WarehouseCode { get; set; }
        /// <summary>
        /// 库区名称
        /// </summary>
        [DataMember]
        public string WarehouseZoneName { get; set; }
        /// <summary>
        /// 库区编码
        /// </summary>
        [DataMember]
        public string WarehouseZoneCode { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        [DataMember]
        public string Explain { get; set; }


    }
}
