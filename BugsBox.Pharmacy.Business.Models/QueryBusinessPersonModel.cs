using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using BugsBox.Pharmacy.Business.Models.QueryModelExtesion;

namespace BugsBox.Pharmacy.Business.Models
{
    /// <summary>
    /// 查询对象作为条件
    /// </summary>
    [DataContract]
    public class QueryBusinessPersonModel
    {
        public QueryBusinessPersonModel()
        {
            Birthday = new DateTimeRange();
            OutDate = new DateTimeRange();
        }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        [DataMember]
        public string IDNumber { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [DataMember]
        public string Tel { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [DataMember]
        public DateTimeRange Birthday { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [DataMember]
        public string Gender { get; set; }
        /// <summary>
        /// 过期日期
        /// </summary>
        [DataMember]
        public DateTimeRange OutDate { get; set; }

        /// <summary>
        /// 人员类型
        /// </summary>
        [DataMember]
        public int PersonTypeValue { get; set; } 
    }
}
