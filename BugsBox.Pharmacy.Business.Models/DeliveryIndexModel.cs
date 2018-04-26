using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    /// <summary>
    /// 销售订单统计检索条件
    /// </summary>
    [DataContract]
    public class DeliveryIndexInput
    {
        /// <summary>
        /// 开始日期
        /// </summary>
        [DataMember]
        public DateTime DeliveryFromDate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        [DataMember]
        public DateTime DeliveryToDate { get; set; }

        /// <summary>
        /// 货单号
        /// </summary>
        [DataMember]
        public string ManifestNumber { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [DataMember]
        public string OrderNumber { get; set; }

        /// <summary>
        /// 收货公司
        /// </summary>
        [DataMember]
        public Guid ReceivingCompasnyID { get; set; }

        /// <summary>
        /// 收货公司名称
        /// </summary>
        [DataMember]
        public string ReceivingCompasnyName { get; set; }

        /// <summary>
        /// 运输公司
        /// </summary>
        [DataMember]
        public string TransportCompany { get; set; }

        /// <summary>
        /// 运输方式值
        /// </summary>
        [DataMember]
        public int TransportMethodValue { get; set; }

        /// <summary>
        /// 配送方式值
        /// </summary>
        [DataMember]
        public int DeliveryMethodValue { get; set; }

        /// <summary>
        /// 配送状态值
        /// </summary>
        [DataMember]
        public int DeliveryStatusValue { get; set; }

        /// <summary>
        /// 车辆信息
        /// </summary>
        [DataMember]
        public string VehicleInfo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Memo { get; set; }
    }
}
