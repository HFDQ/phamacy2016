using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Business.Models
{
    public class DrugMaintainModel:BugsBox.Pharmacy.Models.DrugMaintainRecordDetail
    {
        /// <summary>
        /// 经营范围
        /// </summary>
        [DataMember]
        public string DrugScope { get; set; }
    }
}
