using BugsBox.Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BugsBox.Pharmacy.AppClient.Common.Commands
{
    [DataContract(Namespace = "http://www.dqinfo.net/2017/dqinfo")]
    public class GetDrugInventoryRecordSelectHisCmd : ServerCommand
    {
        [DataMember]
        public Guid purchaseUnitGuid { get; set; }
        [DataMember]
        public string tym { get; set; }
        [DataMember]
        public string bwm { get; set; }
        [DataMember]
        public string code { get; set; }

    }
}
