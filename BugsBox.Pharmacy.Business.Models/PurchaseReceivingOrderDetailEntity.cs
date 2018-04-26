using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    [DataContract]
    public class PurchaseReceivingOrderDetailEntity
    {
        [DataMember]
        public Guid Id { get; set; }
        /// <summary>
        /// 采购数量
        /// </summary>
        [DataMember]
        public decimal Amount { get; set; }

        /// <summary>
        /// 收货数量
        /// </summary>
        [DataMember]
        public decimal ActualAmount { get; set; }

        /// <summary>
        /// 确认为本公司采购
        /// </summary>
        [DataMember]
        public bool IsCompanyPurchase { get; set; }

        /// <summary>
        /// 运输条件
        /// </summary>
        [DataMember]
        public string TransportMethod { get; set; }

        /// <summary>
        /// 产地
        /// </summary>
        [DataMember]
        public string Origin { get; set; }

        /// <summary>
        /// 运输条件是否符合
        /// </summary>
        [DataMember]
        public bool IsTransportMethod { get; set; }

        /// <summary>
        /// 运输温度
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
        /// 药物编号
        /// </summary>
        [DataMember]
        public Guid DrugInfoId { get; set; }

        //药品通用名
        [DataMember]
        public string ProductGeneralName { get; set; }
        //规格
        [DataMember]
        public string DictionarySpecificationCode { get; set; }
        //药品单位
        [DataMember]
        public string DictionaryMeasurementUnitCode { get; set; }
        //剂型
        [DataMember]
        public string DictionaryDosageCode { get; set; }
        //厂家全称
        [DataMember]
        public string FactoryName { get; set; }
        //批准文号
        [DataMember]
        public string LicensePermissionNumber { get; set; }

        [DataMember]
        public bool IsSpecial { get; set; }

        /// <summary>
        /// 采购价
        /// </summary>
        [DataMember]
        public decimal PurchasePrice { get; set; }
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
        /// 收货结果:确认收货/拒收
        /// </summary>
        [DataMember]
        public int CheckResult { get; set; }
        [DataMember]
        public string CheckResultString { get; set; }

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
        /// 顺序
        /// </summary>
        [DataMember(Order = 11)]
        public Decimal? sequence { get; set; }

        [DataMember]
        public string BusinessScopeCode { get; set; }

        [DataMember]
        public int ValidMonth { get; set; }

        [DataMember]
        public Decimal MReceiveNumber { get; set; }

        [DataMember]
        public decimal QualifiedAmount { get; set; }

        [DataMember]
        public decimal UnQualifiedAmount { get; set; }
    }
}
