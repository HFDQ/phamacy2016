using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Business.Models
{
    public class SalesOrderModelForSalesOrderReturn
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string OrderCode { get; set; }
        [DataMember]
        public string SalerName { get; set; }
        [DataMember]
        public string Balancer { get; set; }
        [DataMember]
        public string Creator { get; set; }
        [DataMember]
        public DateTime BalanceDate { get; set; }
        [DataMember]
        public DateTime ApprovalDate { get; set; }
        [DataMember]
        public string PurchaseUnitName { get; set; }
        [DataMember]
        public Guid PurchaseUnitId { get; set; }
    }
}
