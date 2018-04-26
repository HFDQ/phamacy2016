using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models.QueryModelExtesion
{
    /// <summary>
    /// 时间范围
    /// </summary>
    [DataContract]
    public class DateTimeRange
    {

        public DateTimeRange()
        {
            Min = DateTime.Parse("1971-12-24");
            Max = DateTime.Parse("2049-12-24");
            QueryMin = false;
            QueryMax = false;
        }

        /// <summary>
        /// 最小值
        /// </summary>
        [DataMember]
        public DateTime Min { get; set; }

        [DataMember]
        public bool QueryMin { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        [DataMember]
        public DateTime Max { get; set; } 

        [DataMember]
        public bool QueryMax { get; set; }

    }
}
