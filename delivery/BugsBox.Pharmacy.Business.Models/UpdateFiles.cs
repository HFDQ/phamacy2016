using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    public class UpdateFiles
    {
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public byte[] bytes { get; set; }
    }
}
