using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Business.Models
{
    public class DirectSalesQueryModel
    {
        [DataMember]
        public string DocumentNumber { get; set; }
        [DataMember]
        public Guid SupplyUnitId { get; set; }
        [DataMember]
        public Guid PurchaseUnitId { get; set; }
        [DataMember]
        public string PurchaseUnitKW{ get; set; }
        [DataMember]
        public string SupplyUnitKW { get; set; }
        [DataMember]
        public string Keyword { get; set; }
        [DataMember]
        public bool IsAccurate { get; set; }
        /// <summary>
        /// 查询时间起
        /// </summary>
        [DataMember]
        public DateTime Sdt { get; set; }
        /// <summary>
        /// 查询时间止
        /// </summary>
        [DataMember]
        public DateTime Edt { get; set; }

        [DataMember]
        public int[] ApprovalStatus { get; set; }

        [DataMember]
        public int CheckedStatusValue { get; set; }
    }
}
