using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using BugsBox.Pharmacy.Business.Models.QueryModelExtesion;

namespace BugsBox.Pharmacy.Business.Models
{
    /// <summary>
    /// 药物库存逻辑查询实体
    /// </summary>
    [DataContract]
    [KnownType(typeof(DateTimeRange))]
    public class QueryDrugInventoryRecordBusinessModel
    {
        /// <summary>
        /// 药物本位码
        /// </summary>
        [DataMember]
        public string StandardCode { get; set; }

        /// <summary>
        /// 药物名称
        /// </summary>
        [DataMember]
        public string DrugInfoName { get; set; }

        /// <summary>
        /// 生产批号
        /// </summary>
        [DataMember]
        public string BatchNumber { get; set; }

        /// <summary>
        /// 入库时间范围
        /// ArrivalDateTime
        /// </summary>  
        [DataMember]
        public DateTimeRange ArrivalDateTime { get; set; }

        /// <summary>
        /// 生产日期范围
        /// ArrivalDateTime
        /// </summary>  
        [DataMember]
        public DateTimeRange PruductDate { get; set; }

        /// <summary>
        /// 过期日期范围
        /// ArrivalDateTime
        /// </summary>  
        [DataMember]
        public DateTimeRange OutValidDate { get; set; }

        /// <summary>
        ///存放库区名称
        /// </summary>
        [DataMember]
        public string WarehouseZonesName { get; set; }
    }
}
