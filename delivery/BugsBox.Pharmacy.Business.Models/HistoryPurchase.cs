using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    public class HistoryPurchase
    {
        public string productName { get; set; }
        public DateTime inInventoryDate { get; set; }
        public string supplyUnit { get; set; }
        public decimal inInventoryNum { get; set; }
        public decimal purchasePrice { get; set; }
        public string PurchaseOrderDocumentNumber { get; set; }
        public string BatchNumber { get; set; }
    }
}
