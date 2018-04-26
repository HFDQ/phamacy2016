using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    public class DrugPath
    {
        public Guid id { get; set; }
        public Guid DrugInfoId { get; set; }
        public Pharmacy.Models.DrugInfo DrugInfo { get; set; }
        public string drugName { get; set; }
        public string dosage { get; set; }
        public string specific { get; set; }
        public string MeasurementUnit { get; set; }
        public string factoryName { get; set; }
        public string permitNumber { get; set; }
        public string batchNumber{get;set;}
        public decimal cansaleNum { get; set; }
        public decimal invenotryNumber{get;set;}
        public DateTime? inInventoryDate{get;set;}        

        public Guid purchaseOrderID{get;set;}
        public string PurchaseOrderDocumentNumber { get; set; }
        public Guid SupplyUintId{get;set;}
        public string SupplyUnitName{get;set;}
        public string businessman { get; set; }

        public Guid salesOrderID{get;set;}
        public Guid purchaseUnitId{get;set;}
        public string purchaseUnitName{get;set;}
        public string saleOrderCode { get; set; }
        public string saler { get; set; }
        public decimal saleCount { get; set; }
        public decimal salePrice { get; set; }
        public DateTime? saleDate { get; set; }

        public Guid InventoryRecordId { get; set; }


    }
}
