using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Business.Models
{
    public class DirectSalesOrderDetailModel
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public Guid DrugInfoId { get; set; }
        [DataMember]
        public string ProducGeneralName { get; set; }
        [DataMember]
        public string PermitNumber { get; set; }
        [DataMember]
        public string Dosage { get; set; }
        [DataMember]
        public string Specific { get; set; }
        [DataMember]
        public string FactoryName { get; set; }
        [DataMember]
        public string BatchNumber { get; set; }
        [DataMember]
        public string Origin { get; set; }
        [DataMember]
        public string MeasurementUnitCode { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public decimal SupplyPrice { get; set; }
        [DataMember]
        public decimal SupplyWholePrice { get; set; }
        [DataMember]
        public decimal SalePrice { get; set; }
        [DataMember]
        public decimal SaleWholePrice { get; set; }
        [DataMember]
        public decimal DirectDiffPrice { get; set; }
        [DataMember]
        public decimal QualityNumber { get; set; }
        [DataMember]
        public decimal UnqualityNumber { get; set; }
        [DataMember]
        public string CheckMethod { get; set; }
        [DataMember]
        public DateTime ProductDate { get; set; }
        [DataMember]
        public DateTime OutValidDate { get; set; }
        [DataMember]
        public string UnqualityMemo { get;set;}
        [DataMember]
        public string QualityMemo { get; set; }
        [DataMember]
        public int Sequence { get; set; }
    }
}
