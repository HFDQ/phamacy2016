using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;


namespace BugsBox.Pharmacy.Business.Models
{
    public class PurchaseOrderReturnQueryModel
    {
        [DataMember]
        public string Keyword { get; set; }

        [DataMember]
        public DateTime dtF { get; set; }

        [DataMember]
        public DateTime dtT { get; set; }

        [DataMember]
        public Guid CreaterID { get; set; }

        [DataMember]
        public string DrugName { get; set; }

        [DataMember]
        public string SupplyUnitName { get; set; }
    }
}
