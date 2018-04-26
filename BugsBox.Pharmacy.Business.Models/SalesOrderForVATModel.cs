using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    public class SalesOrderForVATModel
    {
        [DisplayName("SaleOrderID")]
        [DataMember]
        public Guid Id { get; set; }

        [DisplayName("销售单号")]
        [DataMember(Order =1)]
        public string SaleOrderDocumentNumber { get; set; }

        [DisplayName("销售方名称")]
        [DataMember(Order = 2)]
        public string StoreName { get; set; }

        [DisplayName("购买方名称")]
        [DataMember(Order = 3)]
        public string PurchaseUnitName { get; set; }

        [DisplayName("购买方Id")]
        [DataMember(Order = 4)]
        public Guid PurchaseUnitId { get; set; }

        [DisplayName("所属增值税专用发票代码")]
        [DataMember(Order = 5)]
        public string VATCode { get; set; }

        [DisplayName("号码")]
        [DataMember(Order = 6)]
        public string VATNumber { get; set; }

        [DisplayName("税率")]
        [DataMember(Order = 7)]
        public decimal VATRate { get; set; }
    }

    public class SalesOrderDetailForVATModel
    {
        [DataMember(Order = 1)]
        [DisplayName("销售单据编号")]
        public string OrderCode { get; set; }

        [DataMember(Order = 2)]
        [DisplayName("购方名称")]
        public string PurchaseUnitName { get; set; }

        [DataMember(Order = 3)]
        [DisplayName("购方税号")]
        public string TaxNumber { get; set; }

        [DataMember(Order = 4)]
        [DisplayName("购方地址电话")]
        public string AddAndTel { get; set; }

        [DataMember(Order = 5)]
        [DisplayName("购方银行账号")]
        public string BankAccount { get; set; }

        [DataMember(Order = 6)]
        [DisplayName("备注")]
        public string Memo { get; set; }

        [DataMember(Order = 7)]
        public Guid SalesOrderId { get; set; }

        [DataMember(Order = 8)]
        public Guid SalesOrderDetailId { get; set; }

        [DataMember(Order = 9)]
        [DisplayName("货物名称")]
        public string ProductGeneralName { get; set; }

        [DataMember]
        [DisplayName("规格")]
        public string SpecificName { get; set; }

        [DataMember]
        [DisplayName("计量单位")]
        public string MeasurementName { get; set; }

        [DataMember]
        [DisplayName("单价")]
        public decimal UnitPrice { get; set; }

        [DataMember]
        [DisplayName("数量")]
        public decimal Amount { get; set; }
        
        [DataMember]
        [DisplayName("金额")]
        public decimal Price { get => this.Amount * this.UnitPrice; }

        [DataMember]
        [DisplayName("税率")]
        public decimal VATRate { get; set; }

        [DataMember]
        [DisplayName("税额")]
        public decimal VAT { get => decimal.Round(this.VATRate * this.Price/100,4); }

        [DataMember]
        [DisplayName("折扣金额")]
        public decimal Discount { get; set; }
    }

    public class SalesOrderForVATQueryModel:BaseQueryModel
    {
        public string PurchaseUnitName { get; set; }
    }
}
