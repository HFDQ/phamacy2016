using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models.QueryModelExtesion
{
    /// <summary>
    /// 整数范围
    /// </summary>
    [DataContract]
    public class IntRange
    {
        /// <summary>
        /// 最小值
        /// </summary>
        [DataMember]
        public int Min { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        [DataMember]
        public int Max { get; set; }

    }
}
