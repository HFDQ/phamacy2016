using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models.QueryModelExtesion
{
    [DataContract]
    public class DecimalRange
    {
        /// <summary>
        /// 最小值
        /// </summary>
        [DataMember]
        public decimal Min { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        [DataMember]
        public decimal Max { get; set; }

    }
}
