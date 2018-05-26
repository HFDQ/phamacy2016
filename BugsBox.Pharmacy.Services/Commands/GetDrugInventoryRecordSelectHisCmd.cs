using BugsBox.Application.Core;
using BugsBox.Application.Core.CF;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.Business.Models.DTO;
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
    public class GetDrugInventoryRecordSelectHisCmd : Command
    {
        [DataMember]
        public Guid purchaseUnitGuid { get; set; }
        [DataMember]
        public string tym { get; set; }
        [DataMember]
        public string bwm { get; set; }
        [DataMember]
        public string code { get; set; }

        public override object Execute()
        {
            using (var db = new Db())
            {

                var purchaseUnit = db.PurchaseUnits.FirstOrDefault(o => o.Id == purchaseUnitGuid);

                if (purchaseUnit == null)
                {
                    throw new Exception("采购商不存在");
                }
                if (!purchaseUnit.Enabled)
                {
                    throw new Exception("采购商没开启");
                }
                if (!purchaseUnit.Valid)
                {
                    throw new Exception("采购商被锁定");
                }

                var all = db.DrugInfos.Where(o => o.Valid && o.Enabled);
                if (!string.IsNullOrWhiteSpace(tym))
                {
                    all = all.Where(p => p.ProductGeneralName.Contains(tym));
                }
                if (!string.IsNullOrWhiteSpace(bwm))
                {
                    all = all.Where(p => p.StandardCode.Contains(bwm));
                }
                if (!string.IsNullOrWhiteSpace(code))
                {
                    all = all.Where(p => p.Code.Contains(code));
                }

                var result = (from record in db.DrugInventoryRecords
                              join drug in all on record.DrugInfoId equals drug.Id
                              join wz in db.WarehouseZones on record.WarehouseZoneId equals wz.Id
                              join w in db.Warehouses on wz.WarehouseId equals w.Id
                              where record.CanSaleNum > 0 && record.Valid
                              select new InventoryRecordItem
                              {
                                  Record = record,
                                  Warehouse = w,
                                  DrugInfo = drug
                              }).ToArray();


                return result;
            }
        }
    }
}
