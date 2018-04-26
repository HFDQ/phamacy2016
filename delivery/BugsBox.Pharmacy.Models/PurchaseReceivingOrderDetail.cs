using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 采购收货详细单
    /// </summary>
    [Description("采购收货详细单")]
    [DataContract(IsReference = true)]
    public class PurchaseReceivingOrderDetail : Entity, IStore
    {
        [DataMember]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 采购数量
        /// </summary>
        [DataMember]
        public decimal Amount { get; set; }

        /// <summary>
        /// 采购价
        /// </summary>
        public decimal PurchasePrice { get; set; }

        /// <summary>
        /// 收货数量
        /// </summary>
        [DataMember]
        public decimal ActualAmount { get; set; }

        /// <summary>
        /// 实收数量
        /// </summary>
        [DataMember]
        public decimal ReceiveAmount { get; set; }

        /// <summary>
        /// 拒收数量
        /// </summary>
        [DataMember]
        public decimal RejectAmount { get; set; }

        /// <summary>
        /// 拒收原因
        /// </summary>
        [DataMember]
        public string RejectReason { get; set; }

        /// <summary>
        /// 拒收去向
        /// </summary>
        [DataMember]
        public string RejectTrace { get; set; }

        /// <summary>
        /// 确认为本公司采购
        /// </summary>
        [DataMember]
        public bool IsCompanyPurchase { get; set; }

        /// <summary>
        /// 运输方式
        /// </summary>
        [DataMember]
        public string TransportMethod { get; set; }

        /// <summary>
        /// 运输条件是否符合
        /// </summary>
        [DataMember]
        public bool IsTransportMethod { get; set; }

        /// <summary>
        /// 温控方式
        /// </summary>
        [DataMember]
        public string TransportTemperature { get; set; }

        /// <summary>
        /// 温控状况
        /// </summary>
        [DataMember]
        public string TemperatureStatus { get; set; }

        /// <summary>
        /// 运输温度是否符合
        /// </summary>
        [DataMember]
        public bool IsTransportTemperature { get; set; }

        /// <summary>
        /// 收货结果:确认收货/拒收
        /// </summary>
        [Required]
        [DataMember]
        public int CheckResult { get; set; }

        /// <summary>
        /// 药物编号
        /// </summary>
        [DataMember]
        public Guid DrugInfoId { get; set; }

        /// <summary>
        /// 采购收货单
        /// </summary>
        [DataMember]
        public virtual PurchaseReceivingOrder PurchaseReceivingOrder { get; set; }

        /// <summary>
        /// 采购收货单ID
        /// </summary>
        [DataMember]
        public Guid PurchaseReceivingOrderId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Decription { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        [DataMember(Order = 11)]
        public Decimal? sequence { get; set; }
    }
}
