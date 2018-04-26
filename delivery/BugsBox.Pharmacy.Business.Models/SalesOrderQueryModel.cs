using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Business.Models
{
    public class SalesOrderQueryModel
    {
        [DataMember]
        public string PurchaseUnitKeyword { get; set; }

        [DataMember]
        public string DrugInfoKeyword { get; set; }

        [DataMember]
        public DateTime? DTF { get; set; }
        [DataMember]
        public DateTime? DTT { get; set; }

        [DataMember]
        public string OrderCode { get;set;}

        [DataMember]
        public string Batch { get; set; }
    }
}
