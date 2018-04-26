using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace BugsBox.Pharmacy.Business.Models
{
    public class PurchaseOrderReturnModel
    {
        [DisplayName("标识符")]
        [DataMember]
        public Guid id { get; set; }

        [DisplayName("采购单ID")]
        [DataMember]
        public Guid Pid { get; set; }

        [DisplayName("退货单号")]
        [DataMember]
        public string POrderReturnDocumentNumber { get; set; }

        [DisplayName("原采购单号")]
        [DataMember]
        public string POrderDocumentNumber { get; set; }

        [DisplayName("供应商")]
        [DataMember]
        public string SupplyUnitName { get; set; }
        
        [DisplayName("采购数量")]
        [DataMember]
        public Decimal? POrderTotalNum { get; set; }

        [DisplayName("退货数量")]
        [DataMember]
        public decimal POrderReturnTotalNum { get; set; }

        [DisplayName("采购总额")]
        [DataMember]
        public Decimal? POrderTotalMoney { get; set; }

        [DisplayName("退货总额")]
        [DataMember]
        public Decimal? POrderReturnTotalMoney { get; set; }

        [DisplayName("创建人")]
        [DataMember]
        public string POrderCreater { get; set; }

        [DisplayName("创建日期")]
        [DataMember]
        public DateTime? POrderCreateTime { get; set; }

        [DisplayName("质管部意见")]
        [DataMember]
        public string POrderQSuggest { get; set; }

        [DisplayName("审批时间")]
        [DataMember]
        public DateTime? POrderQTime { get; set; }

        [DisplayName("总经理意见")]
        [DataMember]
        public string POrderMSuggest { get; set; }

        [DisplayName("审批时间")]
        [DataMember]
        public DateTime? POrderMTime { get; set; }

        [DisplayName("财务部意见")]
        [DataMember]
        public string POrderFSuggest { get; set; }

        [DisplayName("审批时间")]
        [DataMember]
        public DateTime? POrderFTime { get; set; }

        [DisplayName("复核员")]
        [DataMember]
        public string QualityChecker { get; set; }

        [DisplayName("质量状况")]
        [DataMember]
        public string QualityStatus { get; set; }

        //[DisplayName("当前状态")]
        //[DataMember]
        //public int Statusvalue { get; set; }
    }
}
