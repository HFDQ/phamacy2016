using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    public class BaseQueryModel
    {
        [DataMember]
        public string Keyword { get; set; }

        [DataMember]
        public DateTime DTF { get; set; }

        [DataMember]
        public DateTime DTT { get; set; }
    }
}
