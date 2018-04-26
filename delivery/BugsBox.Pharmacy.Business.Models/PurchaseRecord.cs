using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace BugsBox.Pharmacy.Business.Models
{
    [DataContract]
    public class PurchaseRecord
    {
        [DataMember]
        public Guid DrugInfoId { get; set; }

        [DisplayName("通用名称")]
        [DataMember]
        public string ProductGeneralName { get; set; }

        [DisplayName("剂型")]
        [DataMember]
        public string DictionaryDosageCode { get; set; }

        [DisplayName("规格")]
        [DataMember]
        public string DictionarySpecificationCode { get; set; }

        [DisplayName("批准文号")]
        [DataMember]
        public string LicensePermissionNumber { get; set; }


        [DisplayName("收货单位")]
        [DataMember]
        public string ReceiveUnit { get; set; }

        [DisplayName("供货单位")]
        [DataMember]
        public string SuplyUnit { get; set; }

        [DisplayName("数量")]
        [DataMember]
        public decimal Amount { get; set; }

        [DisplayName("价格")]
        [DataMember]
        public decimal Price { get; set; }

        [DisplayName("购货日期")]
        [DataMember]
        public DateTime PurchaseDate { get; set; }

        [DisplayName("产地")]
        [DataMember]
        public string Origin { get; set; }

        [DisplayName("批号")]
        [DataMember]
        public string BatchNumber { get; set; }

        [DisplayName("生产厂商")]
        [DataMember]
        public string FactoryName { get; set; }

        [DisplayName("收货地址")]
        [DataMember]
        public string ReceiveAddress { get; set; }

        [DisplayName("发货日期")]
        [DataMember]
        public DateTime ShippingTime { get; set; }

        /// <summary>
        /// 纪录总数
        /// </summary>
        [DataMember]
        public int RecordCount { get; set; }
    }
}
