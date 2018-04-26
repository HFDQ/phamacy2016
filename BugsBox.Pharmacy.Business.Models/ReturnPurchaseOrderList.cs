using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Business.Models
{
    public class ReturnPurchaseOrderList
    {
        [DataMember]
        public Guid id { get; set; }
        [DataMember]
        public string POrderDocumentNumber { get; set; }
        [DataMember]
        public string PInventoryDocumentNumber { get; set; }
        [DataMember]
        public DateTime InventoryDate { get; set; }
        [DataMember]
        public string SupplyUnitName { get; set; }
        [DataMember]
        public string py { get; set; }
        
    }
}
