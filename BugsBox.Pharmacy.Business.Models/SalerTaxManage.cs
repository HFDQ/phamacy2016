using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace BugsBox.Pharmacy.Business.Models
{
    public class SalerTaxManage
    {
        [DisplayName("SaleOrderID")]
        [DataMember]
        public Guid Id { get; set; }

        [DisplayName("销售单号")]
        [DataMember]
        public string SaleOrderDocumentNumber { get; set; }

        [DisplayName("销售日期")]
        [DataMember]
        public DateTime SaleOrderDate { get; set; }

        [DisplayName("销售员")]
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        [DisplayName("购货商")]
        public string PurchaseUnitName { get; set; }

        [DataMember]
        [DisplayName("管理费率")]
        public Decimal? MRate { get; set; }

        [DataMember]
        [DisplayName("发票费率")]
        public Decimal? IRate { get; set; }

        [DataMember]
        [DisplayName("UID")]
        public Guid? UserId { get; set; }
        [DataMember]
        [DisplayName("PID")]
        public Guid? PurchaseUnitId { get; set; }

        [DisplayName("应付金额")]
        [DataMember]
        public Decimal? PayMoney { get; set; }

        [DisplayName("是否已付款")]
        [DataMember]
        public Boolean? IsPayed { get; set; }

        [DisplayName("实付金额")]
        [DataMember]
        public Decimal? ReceivedMoney { get; set; }

        [DataMember]
        [DisplayName("差价")]
        public Decimal? Diff { get; set; }

        [DisplayName("销退金额")]
        [DataMember]
        public Decimal? SalesReturnMoney { get; set; }

        [DisplayName("销退后差额")]
        [DataMember]
        public Decimal? ReturnDiff { get; set; }

        [DisplayName("销退后实收金额")]
        [DataMember]
        public Decimal? ReceiveMoneyAfterReturn { get; set; }
        
        [DisplayName("销退单号")]
        [DataMember]
        public IEnumerable<ReturnOrderCol> ReturnOrderCol { get; set; }

        [DisplayName("历史销退金额")]
        [DataMember]
        public Decimal? ReturnHistoryMoney { get; set; }

        [DisplayName("需要发票")]
        [DataMember]
        public Boolean? IsNeedInvoice { get; set; }

        [DisplayName("发票已开")]
        [DataMember]
        public Boolean? IsInvoice { get; set; }

        [DisplayName("发票金额")]
        [DataMember]
        public Decimal? InvoiceMoney { get; set; }

        [DisplayName("是否结算")]
        [DataMember]
        public string IsBalanced { get; set; }

        [DisplayName("管理费用")]
        [DataMember]
        public Decimal? ManageMoneyR { get; set; }

        [DisplayName("发票费用")]
        [DataMember]
        public Decimal? InvoiceMoneyR { get; set; }

        [DisplayName("应收费用")]
        [DataMember]
        public Decimal? PayedMoney { get; set; }
        
        [DisplayName("总收费用")]
        [DataMember]
        public Decimal? Money { get; set; }

        [DisplayName("描述")]
        [DataMember]
        public string Description { get; set; }
    }

    public class ReturnOrderCol { public Guid Gid { get; set; } public string code { get; set; } }
}
