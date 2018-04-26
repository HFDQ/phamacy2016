using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace BugsBox.Pharmacy.Business.Models
{
    //收货与验收记录
    [DataContract]
    public class PurchaseRCRecord
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

        [DisplayName("供货单位/退货单位")]
        [DataMember]
        public string SuplyUnit { get; set; }

        [DisplayName("购货日期/退货日期")]
        [DataMember]
        public DateTime PurchaseDate { get; set; }

        [DisplayName("产地")]
        [DataMember]
        public string Decription { get; set; }

        [DisplayName("批准文号")]
        [DataMember]
        public string LicensePermissionNumber { get; set; }

        [DisplayName("批号")]
        [DataMember]
        public string BatchNumber { get; set; }

        [DisplayName("生产日期")]
        [DataMember]
        public DateTime PruductDate { get; set; }

        [DisplayName("有效期至")]
        [DataMember]
        public DateTime OutValidDate { get; set; }

        [DisplayName("有效期至")]
        [DataMember]
        public string OutValidDateStr { get; set; }

        [DisplayName("生产厂商")]
        [DataMember]
        public string FactoryName { get; set; }

        [DisplayName("到货数量")]
        [DataMember]
        public decimal ArrivalAmount { get; set; }

        [DisplayName("到货日期")]
        [DataMember]
        public DateTime ArrivalDate { get; set; }

        [DisplayName("验收合格数量")]
        [DataMember]
        public decimal QualifiedAmount { get; set; }

        [DisplayName("验收结果")]
        [DataMember]
        public int CheckResult { get; set; }

        [DisplayName("验收人员")]
        [DataMember]
        public string CheckMan { get; set; }

        [DisplayName("验收员2")]
        [DataMember]
        public string SpecialChecker { get; set; }

        [DisplayName("验收意见")]
        [DataMember]
        public string SpecialCheckMemo { get; set; }


        [DisplayName("验收日期")]
        [DataMember]
        public DateTime CheckDate { get; set; }

        /// <summary>
        /// 纪录总数
        /// </summary>
        [DataMember]
        public int RecordCount { get; set; }
    }
}
