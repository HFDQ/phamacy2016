using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    [DataContract]
    public class PurchaseOrderDetailEntity
    {
        [DataMember]
        public Guid Id { get; set; }

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
        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        public decimal Amount { get; set; }

        /// <summary>
        /// 采购价
        /// </summary>
        [DataMember]
        public decimal PurchasePrice { get; set; }

        //价格
        [DataMember]
        public decimal Price { get; set; }

        /// <summary>
        /// 税额
        /// </summary>
        [DataMember]
        public decimal AmountOfTax { get; set; }

        /// <summary>
        /// 药物编号
        /// </summary>
        [DataMember]
        public Guid DrugInfoId { get; set; }

        /// <summary>
        /// 采购单Id
        /// </summary>
        [DataMember]
        public Guid PurchaseOrderId { get; set; }

        /// <summary>
        /// 供应商编号
        /// </summary>
        [DataMember]
        public Guid SupplyUnitId { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        [DataMember]
        public string SupplyUnitName { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        [DataMember]
        public string SupplyUnitCode { get; set; }

        /// <summary>
        /// 供应商联系人
        /// </summary>
        [DataMember]
        public string SupplyUnitContactName { get; set; }

        /// <summary>
        /// 供应商联系电话
        /// </summary>
        [DataMember]
        public string SupplyContactTel { get; set; }

        /// <summary>
        /// 供应商生产经营范围
        /// </summary>
        [DataMember]
        public string SupplyBusinessScope { get; set; }

        [DataMember]
        public bool isdeleted { get; set; }

        [DataMember]
        public DateTime purchaseDate { get; set; }

        [DataMember]
        public Decimal? sequence { get;set;}

    }
}
