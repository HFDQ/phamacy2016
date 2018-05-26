using BugsBox.Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models.DTO
{
    [DataContract]
    public class InventoryRecordItem
    {
        [DataMember]
        public DrugInventoryRecord Record { get; set; }
        [DataMember]
        public Warehouse Warehouse { get; set; }

        [DataMember]
        public DrugInfo DrugInfo { get; set; }
    }
}
