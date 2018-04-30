using BugsBox.Application.Core;
using BugsBox.Application.Core.CF;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Commands
{
    [DataContract(Namespace = "http://www.dqinfo.net/2017/dqinfo")]
    public class DrugInventoryRecordHisCmd : Command
    {
        [DataMember]
        public decimal Diff { get; set; }


        [DataMember]
        public string Operator { get; set; }

        [DataMember]
        public Guid OperatorID { get; set; }

        [DataMember]
        public DrugInventoryRecord DrugInventoryRecord { get; set; }
        public override object Execute()
        {
            Console.WriteLine(DrugInventoryRecord.BatchNumber);
            var db = new Db();


            var recordhis = new DrugInventoryRecordHis
            {
                Id = Guid.NewGuid(),
                ChangeAmount = Diff,
                OperatorId = OperatorID,
                OperatorName = Operator,
                DrugInventoryRecordId = DrugInventoryRecord.Id,
                BatchNumber = DrugInventoryRecord.BatchNumber,
                DrugInfoId = DrugInventoryRecord.DrugInfoId,
                CanSaleNum = DrugInventoryRecord.CanSaleNum,
                CurrentInventoryCount = DrugInventoryRecord.CurrentInventoryCount,
                DismantingAmount = DrugInventoryRecord.DismantingAmount,
                DurgInventoryType = DrugInventoryRecord.DurgInventoryType,
                DurgInventoryTypeValue = DrugInventoryRecord.DurgInventoryTypeValue,
                InInventoryCount = DrugInventoryRecord.InInventoryCount,
                IsOutValidDate = DrugInventoryRecord.IsOutValidDate,
                OnRetailCount = DrugInventoryRecord.OnRetailCount,
                OnSalesOrderCount = DrugInventoryRecord.OnSalesOrderCount,
                OutValidDate = DrugInventoryRecord.OutValidDate,
                PruductDate = DrugInventoryRecord.PruductDate,
                PurchasePricce = DrugInventoryRecord.PurchasePricce,
                PurchaseReturnNumber = DrugInventoryRecord.PurchaseReturnNumber,
                RetailCount = DrugInventoryRecord.RetailCount,
                RetailDismantingAmount = DrugInventoryRecord.RetailDismantingAmount,
                SalesCount = DrugInventoryRecord.SalesCount,
                StoreId = DrugInventoryRecord.StoreId,
                Valid = DrugInventoryRecord.Valid,
                CreateDate = DateTime.Now
            };
            db.DrugInventoryRecordHiss.Add(recordhis);

            db.SaveChanges();

            return "";

        }
    }
}
