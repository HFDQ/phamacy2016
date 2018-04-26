using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.Business.Models
{
    /// <summary>
    /// 人员-业务逻辑
    /// </summary>
    [DataContract]
    public class BusinessPersonModel
    {
        /// <summary>
        /// 编号
        /// </summary>
         [DataMember]
        public Guid Id { get; set; }

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
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [DataMember]
        public string Gender { get; set; }
        /// <summary>
        /// 过期日期
        /// </summary>
        [DataMember]
        public DateTime OutDate { get; set; }

        /// <summary>
        /// 人员类型
        /// </summary>
        [DataMember]
        public int PersonTypeValue { get; set; }

        /// <summary>
        /// 人员类型
        /// </summary>
        public PersonType PersonType
        {
            set
            {
                PersonTypeValue = (int)value;
            }
            get
            {
                return (PersonType)PersonTypeValue;
            }
        }
    }
}
