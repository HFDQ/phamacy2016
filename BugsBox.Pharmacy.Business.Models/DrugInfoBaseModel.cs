using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    public class DrugInfoBaseModel
    {
        [DisplayName("ID")]
        [DataMember(Order = 0)]
        public Guid DrugInfoId { get; set; }

        [DisplayName("药品通用名")]
        [DataMember(Order = 1)]
        public string ProductGeneralName { get; set; }
        
        [DisplayName("批准文号")]
        [DataMember(Order = 3)]
        public string LicensePermissionNumber { get; set; }

        [DisplayName("剂型")]
        [DataMember(Order = 4)]
        public string DictionaryDosageCode { get; set; }

        [DisplayName("规格")]
        [DataMember(Order = 5)]
        public string DictionarySpecificationCode { get; set; }

        [DisplayName("单位")]
        [DataMember(Order = 6)]
        public string DictionaryMeasurementUnitCode { get; set; }

        [DisplayName("生产厂家")]
        [DataMember(Order = 7)]
        public string FactoryName { get; set; }

        [DisplayName("产地")]
        [DataMember(Order = 8)]
        public string Origin { get; set; }
    }
}
