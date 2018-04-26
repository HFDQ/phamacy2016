using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    public class SupplyUnitHistoryDrugList
    {
        public Guid purchaseOrderID { get; set; }
        public string SupplyUnitName { get; set; }
        public Guid SupplyUnitId { get; set; }
        public string PurchaseOrderDocumentNumber { get; set; }
        public IEnumerable<PurchaseID2DocumentNumber> PurchaseID2DocumentNumber { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ReceiveTime { get; set; }
        public string Receiver { get; set; }
        public DateTime? CheckTime { get; set; }
        public string Checker { get; set; }

        public string SecondChecker { get; set; }
        public string SecondCheckerMemo { get; set; }

        public DateTime? InventoryTime { get; set; }
        public string InInventoryMan { get; set; }

        public Guid DrugInfoId { get; set; }
        public Pharmacy.Models.DrugInfo DrugInfo { get; set; }
        public string drugName { get; set; }
        public string dosage { get; set; }
        public string MeasurmentUnit { get; set; }
        public string specific { get; set; }
        public string factoryName { get; set; }
        public string permitNumber { get; set; }
        public string batchNumber { get; set; }
        public string Origin { get; set; }

        public decimal InventoryNum { get; set; }
        public decimal InventorySum { get; set; }
        public decimal PurchaseNum { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PurchaseSum { get; set; }
        public DateTime outValidDate { get; set; }
        public decimal cansaleNum { get; set; }
        public string WareHouseZone{get;set;}
    }

    public class PurchaseID2DocumentNumber 
    {
        public Guid Id { get; set; }
        public string DocumentNumber { get; set; }
    }
}
