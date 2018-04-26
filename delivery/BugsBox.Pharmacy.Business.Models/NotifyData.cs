using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace BugsBox.Pharmacy.Business.Models
{
    public class NotifyData
    {
        [DataMember]
        [DisplayName("ID")]
        public Guid Id { get; set; }

        [DataMember]
        [DisplayName("单号")]
        public string DocumentNumber { get; set; }

        [DataMember]
        [DisplayName("企业")]
        public string UnitName { get; set; }


    }
}
