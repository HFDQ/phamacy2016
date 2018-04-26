using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    [DataContract]
    public class PurchaseInInventeryOrderDetailEntity
    {
        [DataMember]
        public Guid Id { get; set; }
        /// <summary>
        /// 药物编号
        /// </summary>
        [DataMember]
        public Guid DrugInfoId { get; set; }
        //药品通用名
        [DataMember]
        public string ProductGeneralName { get; set; }
        //规格
        [DataMember]
        public string DictionarySpecificationCode { get; set; }
        //药品单位
        [DataMember]
        public string DictionaryMeasurementUnitCode { get; set; }
        //剂型
        [DataMember]
        public string DictionaryDosageCode { get; set; }
        //厂家全称
        [DataMember]
        public string FactoryName { get; set; }
        //批准文号
        [DataMember]
        public string LicensePermissionNumber { get; set; }
        /// <summary>
        /// 采购价
        /// </summary>
        [DataMember]
        public decimal PurchasePrice { get; set; }
        /// <summary>
        /// 到货数量
        /// </summary>
        [DataMember]
        public decimal ArrivalAmount { get; set; }

        /// <summary>
        /// 到货日期
        /// </summary>
        [DataMember]
        public DateTime ArrivalDateTime { get; set; }

        /// <summary>
        /// 生产批号
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
        /// 库区ID
        /// </summary>
        [DataMember]
        public Guid WarehouseZoneId { get; set; }

        [DataMember]
        public int WarehouseZonePIndex { get; set; }

        /// <summary>
        /// 库区名
        /// </summary>
        [DataMember]
        public String WarehouseZoneName { get; set; }

        /// <summary>
        /// 储藏方式
        /// </summary>
        [DataMember]
        public String DictionaryStorageType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Decription { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        [DataMember]
        public Decimal? sequence { get; set; }

        /// <summary>
        /// 经营范围
        /// </summary>
        [DataMember]
        public string BussinessScopeCode { get; set; }

        [DataMember]
        public Guid WarehouseZonePositionId { get; set; }

        [DataMember]
        public int WarehouseZonePositionPIndex { get; set; }

        [DataMember]
        public string WarehouseZonePositionName { get; set; }

        [DataMember]
        public string WarehouseName { get; set; }

        
    }
}
