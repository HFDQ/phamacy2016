using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace BugsBox.Pharmacy.Business.Models
{
    public class DrugQualityTraceModel
    {
        [DataMember]
        [DisplayName("编号")]
        public Guid DrugInfoId { get; set; }

        [DataMember]
        [DisplayName("药品通用名")]
        public string DrugName { get; set; }

        [DataMember]
        [DisplayName("剂型")]
        public string Dosage { get; set; }

        [DataMember]
        [DisplayName("规格")]
        public string Specific { get; set; }

        [DataMember]
        [DisplayName("单位")]
        public string MeasureMent { get; set; }

        [DataMember]
        [DisplayName("经营范围")]
        public string BusinessScope { get; set; }

        [DataMember]
        [DisplayName("生产厂家")]
        public string Factory { get; set; }

        [DataMember]
        [DisplayName("批准文号")]
        public string LiscencePermitNumber { get; set; }

        [DataMember]
        [DisplayName("经营许可有效期")]
        public int OutValidDate { get; set; }

        [DataMember]
        [DisplayName("存储条件")]
        public string StorageCondition { get; set; }

        [DataMember]
        [DisplayName("批号")]
        public string BatchNumber { get; set; }

        [DataMember]
        [DisplayName("数量")]
        public decimal Amount { get; set; }

        [DataMember]
        [DisplayName("处理方式")]
        public string Treatmethod { get; set; }

        [DataMember]
        [DisplayName("发生时间")]
        public DateTime UnQualityDate { get; set; }

        [DataMember]
        [DisplayName("理由")]
        public string UnQualityReason { get; set; }

        [DataMember]
        [DisplayName("供货商")]
        public string Suplyer { get; set; }

        [DataMember]
        [DisplayName("入库时间")]
        public DateTime? InInventoryDate { get; set; }
    }
}
