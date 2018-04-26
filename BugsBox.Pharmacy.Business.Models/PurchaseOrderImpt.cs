using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    /// <summary>
    /// 用于EXCEL导入采购单细节
    /// </summary>
    public class PurchaseOrderImpt
    {
        [DataMember(Order =1)]
        public Guid DrugInfoId { get; set; }

        [DisplayName("品名")]
        [DataMember(Order = 2)]
        public string ProductGeneralName { get; set; }

        [DisplayName("剂型")]
        [DataMember(Order = 3)]
        public string DosageName { get; set; }

        [DisplayName("规格")]
        [DataMember(Order = 3)]
        public string SpecificName { get; set; }

        [DisplayName("单位")]
        [DataMember(Order = 5)]
        public string MeasurementName { get; set; }

        [DisplayName("生产厂家")]
        [DataMember(Order = 6)]
        public string FactoryName { get; set; }

        [DisplayName("产地")]
        [DataMember(Order = 6)]
        public string Origin { get; set; }

        [DisplayName("数量")]
        [DataMember(Order = 7)]
        public decimal Amount { get; set; }

        [DisplayName("单价")]
        [DataMember(Order = 8)]
        public decimal UnitPrice { get; set; }

        [DisplayName("金额")]
        [DataMember(Order = 9)]
        public decimal Price { get => this.UnitPrice * this.Amount; }
        
        [DisplayName("税率%")]
        [DataMember(Order = 10)]
        public decimal TaxRate { get; set; }
    }

    /// <summary>
    /// 药品采购时选择药品的MODEL
    /// </summary>
    public class DrugInfoForPurchaseSelectorModel
    {
        public Guid DrugInfoId { get; set; }

        [DisplayName("品名")]
        [DataMember]
        public string ProductGeneralName { get; set; }

        [DisplayName("剂型")]
        [DataMember]
        public string DosageName { get; set; }

        [DisplayName("规格")]
        [DataMember]
        public string SpecificName { get; set; }

        [DisplayName("单位")]
        [DataMember]
        public string MeasurementName { get; set; }

        [DisplayName("生产厂家")]
        [DataMember]
        public string FactoryName { get; set; }

        [DisplayName("产地")]
        [DataMember]
        public string Origin { get; set; }


        [DisplayName("批准文号")]
        [DataMember]
        public string LiscencePermitNumber { get; set; }
        
    }


    public class DrugInfoForPurchaseSelectorQueryModel : BaseQueryModel
    {
        /// <summary>
        /// 供货单位Id
        /// </summary>
        public Guid SupplyUnitId { get; set; }

        /// <summary>
        /// 生产厂家
        /// </summary>
        public string FactoryName { get; set; }
    }

    /// <summary>
    /// 获取最近一次的采购价格返回模型
    /// </summary>
    public class LastPurchaseUnitPrice
    {
        /// <summary>
        /// 品种ID
        /// </summary>
        [DataMember]
        public Guid DrugInfoId { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [DataMember]
        public decimal UnitPrice { get; set; }
    }
}
