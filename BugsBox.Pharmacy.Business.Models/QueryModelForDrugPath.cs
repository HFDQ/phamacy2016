using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Business.Models
{
    public class QueryModelForDrugPath
    {
        [DataMember]
        public string Keywords { get;set;}
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public DateTime DTF { get; set; }
        [DataMember]
        public DateTime DTT { get; set; }
        [DataMember]
        public int DrugPathQueryType { get; set; }
    }
}
