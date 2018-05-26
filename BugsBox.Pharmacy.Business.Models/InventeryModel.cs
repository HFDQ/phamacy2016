using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Business.Models
{
    //库存查询
    public class InventeryModel
    {
        [DataMember]
        public Guid InventoryID { get; set; }
        //药品通用名
        [DataMember]
        public string ProductGeneralName { get; set; }

        //规格
        [DataMember]
        public string DictionarySpecificationCode { get; set; }

        //药品单位
        [DataMember]
        public string DictionaryMeasurementUnitCode { get; set; }

        //厂家全称
        [DataMember]
        public string FactoryName { get; set; }

        //产地
        [DataMember]
        public string Origin { get; set; }

        //剂型
        [DataMember]
        public string DictionaryDosageCode { get; set; }

        //批准文号
        [DataMember]
        public string LicensePermissionNumber { get; set; }

        // 药品本位码
        [DataMember]
        public string StandardCode { get; set; } 

        // 采购价
        [DataMember]
        public decimal PurchasePrice { get; set; }

        // 供应商名称
        [DataMember]
        public string SupplyUnitName { get; set; }

        // 生产批号
        [DataMember]
        public string BatchNumber { get; set; }

        // 生产日期
        [DataMember]
        public DateTime PruductDate { get; set; }

        // 有效期至
        [DataMember]
        public DateTime OutValidDate { get; set; }

        // 有效期至
        [DataMember]
        public string OutValidDateStr { get { return OutValidDate.Year==2050?"无": OutValidDate.ToLongDateString(); } }

        // 库区名
        [DataMember]
        public String WarehouseZoneName { get; set; }

        // 现有库存
        [DataMember]
        public decimal CurrentInventoryCount { get; set; }

        // 可用库存
        [DataMember]
        public decimal CanSaleNum { get; set; }

        // 记录数
        [DataMember]
        public int RecordCount { get; set; }

        // 总数
        [DataMember]
        public decimal TotalQuantityCount { get; set; }

        // 总价值
        [DataMember]
        public decimal TotalPriceCount { get; set; }

        // 价值
        [DataMember]
        public decimal PriceCount { get; set; }

        //是否被锁
        [DataMember]
        public bool isValid { get; set; }

        //是否过期
        [DataMember]
        public string IsOutDate { get; set; }

        //实盘数据
        [DataMember]
        public decimal Realamount { get; set; }

        //报损报溢数量
        [DataMember]
        public decimal DismantingAmount { get; set; }

        //品种ID
        [DataMember]
        public Guid DrugInfoId { get; set; }

        [DataMember]
        public string PurchaseOrderDocumentNumber { get; set; }

        [DataMember]
        public string WarehouseName { get; set; }

        [DataMember]
        public Guid PurchaseOrderId { get; set; }
    }
}
