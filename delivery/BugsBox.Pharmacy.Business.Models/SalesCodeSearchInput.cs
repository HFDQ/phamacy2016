using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    /// <summary>
    /// 销退单检索条件
    /// </summary>
    [DataContract]
    public class SalesCodeSearchInput
    {
        /// <summary>
        /// 开始日期
        /// </summary>
        [DataMember]
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        [DataMember]
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// 单号
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [DataMember]
        public Guid OperatorID { get; set; }

        /// <summary>
        /// 用户名字
        /// </summary>
        [DataMember]
        public string OperatorName { get; set; }

        [DataMember]
        public int isImport { get; set; }

        [DataMember]
        public string salerName { get; set; }

        [DataMember]
        public string purchaseKeyword { get; set; }

        [DataMember]
        public int OrderStatusValue { get; set; }

        [DataMember]
        public bool IsPreciselySearch { get; set; }
    }


}
