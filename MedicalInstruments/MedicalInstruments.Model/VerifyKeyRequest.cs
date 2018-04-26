using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalInstruments.Model
{
    public class VerifyKeyRequest
    {
        public string CPUSerialNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string ProductKey { get; set; }
    }
}
