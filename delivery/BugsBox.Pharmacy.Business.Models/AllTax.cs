using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace BugsBox.Pharmacy.Business.Models
{
    public class AllTax
    {
        [DataMember]
        [DisplayName("销售员")]
        public string salerName { get; set; }

        [DataMember]
        [DisplayName("采购税票返点")]
        public Decimal? PIRate { get; set; }

        [DataMember]
        [DisplayName("采购单数量")]
        public Int32? PNum { get; set; }

        [DataMember]
        [DisplayName("采购单金额")]        
        public Decimal? PMoney { get; set; }
        
        [DataMember]
        [DisplayName("实付单金额")]
        public Decimal? PPayedMoney { get; set; }

        [DataMember]
        [DisplayName("发票金额")]
        public Decimal? PInvoiceMoney { get; set; }

        [DataMember]
        [DisplayName("采购退费")]
        public Decimal? PTax{get;set;}

        [DataMember]
        [DisplayName("销售单数量")]
        public Int32? SNum { get; set; }

        [DataMember]
        [DisplayName("销售金额")]
        public Decimal? SaleMoney { get; set; }

        [DataMember]
        [DisplayName("实收金额")]
        public Decimal? ReceivedMoney { get; set; }

        [DataMember]
        [DisplayName("冲差差额")]
        public Decimal? Diff { get; set; }

        [DataMember]
        [DisplayName("管理费")]
        public Decimal? MRateMoney { get; set; }

        [DataMember]
        [DisplayName("发票费")]
        public Decimal? IRateMoney { get; set; }

        [DataMember]
        [DisplayName("管理与发票费")]
        public Decimal? STax { get; set; }

        [DataMember]
        [DisplayName("合计")]
        public decimal? tax { get; set; }
    }
}
