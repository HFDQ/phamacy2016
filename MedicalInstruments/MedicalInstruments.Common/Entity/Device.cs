using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInstruments.Infrastructure.Entity
{
    public class Device : BaseEntity
    {
        public string Name { get; set; }
        public string CPUSerialNumber { get; set; }
        public string ComputerName { get; set; }
        public string MACAddress { get; set; }
        public string SystemType { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string ProductKey { get; set; }

        public DateTime UpdateOn { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
