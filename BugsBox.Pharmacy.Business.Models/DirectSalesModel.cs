using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Business.Models
{
    public class DirectSalesModel
    {
        [DataMember]
        public Guid DirectSalesOrderId { get; set; }
        [DataMember]
        public string DocumentNumber { get;set;}
        [DataMember]        
        public string SupplyUnitName { get; set; }
        [DataMember]
        public string SupplyUnitPY { get; set; }
        [DataMember]
        public Guid SupplyUnitId { get; set; }
        
        [DataMember]
        public string PurchaseUnitName { get; set; }
        [DataMember]
        public Guid PurchaseUnitId { get; set; }
        [DataMember]
        public string PurchaseUnitPY { get; set; }
        [DataMember]
        public DateTime Createtime { get; set; }
        [DataMember]
        public string Checker { get; set; }
        [DataMember]
        public string CheckMethod { get; set; }
        [DataMember]
        public string CheckAddress { get; set; }
        [DataMember]
        public string ApprovalStatus { get;set;}
        [DataMember]
        public string ReceivingAddress { get; set; }
        [DataMember]
        public string Invoicer { get; set; }
        [DataMember]
        public string Memo { get; set; }
        [DataMember]
        public int CheckStatus { get; set; }

        [DataMember]
        public decimal TotalSupplyPrice { get; set; }
        [DataMember]
        public decimal TotalSalePrice { get; set; }
        [DataMember]
        public decimal TotalDiff
        {
            get { return (TotalSalePrice - TotalSupplyPrice); }
            set { value = (TotalSalePrice - TotalSupplyPrice); }
        }
        [DataMember]
        public decimal TotalAmount
        {
            get;
            set;
        }
        
    }
}
