using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel;

namespace BugsBox.Pharmacy.Business.Models
{
    public class DeliveryModel
    {
        /// <summary>
        /// id
        /// </summary>
        [DataMember]
        public Guid ID { get; set; }

        /// <summary>
        /// 货单号
        /// </summary>
        [DisplayName("单据号")]
        [DataMember]
        public string SalesOrderNumber { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
        [DisplayName("单据类型")]
        [DataMember]
        public string OrderType
        {
            get { return this.SalesOrderNumber.Contains("TH") ? "采退" : "配送"; }
            set { value = this.SalesOrderNumber.Contains("TH") ? "采退" : "配送"; }
        }

        /// <summary>
        /// 订单ID
        /// </summary>
        [DataMember]
        public Guid SalesOrderID { get; set; }

        /// <summary>
        /// 药品件数
        /// </summary>
        [DisplayName("药品件数")]
        [DataMember]
        public decimal DrugsCount { get; set; }

        /// <summary>
        /// 药品总价
        /// </summary>
        [DisplayName("药品总价")]
        [DataMember]
        public decimal DrugsPrice { get; set; }

        /// <summary>
        /// 发货地址
        /// </summary>
        [DisplayName("发货地址")]
        [DataMember]
        public string ShippingAddress { get; set; }

        /// <summary>
        /// 收货公司id
        /// </summary>
        [DataMember]
        public Guid ReceivingCompasnyID { get; set; }

        /// <summary>
        /// 收货公司
        /// </summary>
        [DisplayName("收货公司")]
        [DataMember]
        public string ReceivingCompasnyName { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        [DisplayName("收货地址")]
        [DataMember]
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// 配送方式
        /// </summary>
        [DataMember]
        [DisplayName("配送方式")]
        public string DeliveryMethod { get; set; }

        /// <summary>
        /// 配送状态
        /// </summary>
        [DisplayName("配送状态")]
        [DataMember]
        public string DeliveryStatus { get; set; }

        /// <summary>
        /// 运输方式
        /// </summary>
        [DisplayName("运输方式")]
        [DataMember]
        public string TransportMethod { get; set; }

        /// <summary>
        /// 受理人
        /// </summary>
        [DisplayName("受理操作员")]
        [DataMember]
        public string AcceptedOperator { get; set; }

        /// <summary>
        /// 受理时间
        /// </summary>
        [DisplayName("受理时间")]
        [DataMember]
        public DateTime AcceptedTime { get; set; }

        /// <summary>
        /// 出库操作员
        /// </summary>
        [DisplayName("出库操作员")]
        [DataMember]
        public string outedOperator { get; set; }

        /// <summary>
        /// 出库时间
        /// </summary>
        [DisplayName("出库时间")]
        [DataMember]
        public DateTime outedTime { get; set; }

        /// <summary>
        /// 签收操作员
        /// </summary>
        [DisplayName("签收操作员")]
        [DataMember]
        public string SignedOperator { get; set; }

        /// <summary>
        /// 签收时间
        /// </summary>
        [DisplayName("签收时间")]
        [DataMember]
        public DateTime SignedTime { get; set; }

        /// <summary>
        /// 委托人
        /// </summary>
        [DisplayName("委托人")]
        [DataMember]
        public string Principal { get; set; }

        /// <summary>
        /// 委托人电话
        /// </summary>
        [DisplayName("委托人电话")]
        [DataMember]
        public string PrincipalPhone { get; set; }

        /// <summary>
        /// 运输公司
        /// </summary>
        [DisplayName("运输公司")]
        [DataMember]
        public string TransportCompany { get; set; }

        /// <summary>
        /// 运输工具
        /// </summary>
        [DisplayName("运输工具")]
        [DataMember]
        public string VehicleInfo { get; set; }

        [DisplayName("配送备注")]
        [DataMember]
        public string Memo { get; set; }

    }
}
