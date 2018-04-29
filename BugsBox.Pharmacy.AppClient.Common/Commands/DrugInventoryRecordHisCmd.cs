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
    public class DrugInventoryRecordHisCmd : ServerCommand
    {
        [DataMember]
        public decimal Diff { get; set; }

        [DataMember]
        public string Operator { get; set; }

        [DataMember]
        public Guid OperatorID { get; set; }


        [DataMember]
        public DrugInventoryRecord DrugInventoryRecord { get; set; }

    }
}
