using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Business.Models.QueryModelExtesion
{
    /// <summary>
    /// 布尔值查询
    /// </summary>
    [DataContract]
    public class BooleanExp
    {
        public BooleanExp()
        {
            Query = false;
        }

        [DataMember]
        public bool Query { get; set; }
        [DataMember]
        public bool Value { get; set; }
    }
}
