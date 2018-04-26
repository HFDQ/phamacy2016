using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Business.Models
{
    public class ServerInfo
    {
        [DataMember]
        public DateTime ServerTime { get; set; }
        [DataMember]
        public string ServerVersion { get; set; }
    }
}
