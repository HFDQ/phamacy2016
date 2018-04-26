using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace BugsBox.Pharmacy.Business.Models
{
    public class QualityEvaluationBySupplyer
    {
        [DataMember]
        [DisplayName("编号")]
        public Guid SupplyUnitId { get; set; }

        [DataMember]
        [DisplayName("单位名称")]
        public String SupplyUnitName { get; set; }

        [DataMember]
        [DisplayName("业务起始日期")]
        public DateTime CreateDate { get; set; }

        [DataMember]
        [DisplayName("供货次数")]
        public int PurchaseFrequency { get; set; }

        [DataMember]
        [DisplayName("供货品种数量")]
        public int DrugType { get; set; }

        [DataMember]
        [DisplayName("供货数量总计")]
        public decimal SupplyAmount { get; set; }

        [DataMember]
        [DisplayName("质量问题次数")]
        public int UnqualityFrequency { get; set; }


    }
}
