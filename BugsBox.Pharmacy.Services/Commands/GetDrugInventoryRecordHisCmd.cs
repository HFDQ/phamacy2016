using BugsBox.Application.Core;
using BugsBox.Application.Core.CF;
using BugsBox.Pharmacy.Business.Models;
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
    public class GetDrugInventoryRecordHisCmd : Command
    {

        [DataMember]
        public DateTime BeginDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public string Keyword { get; set; }

        public override object Execute()
        {
            var db = new Db();

            var q = (from m in db.DrugInventoryRecordHiss
                     join d in db.DrugInfos on m.DrugInfoId equals d.Id
                     where d.ProductGeneralName.Contains(Keyword) && m.CreateDate >= BeginDate && m.CreateDate <= EndDate
                     select new InventeryChangeModel
                     {
                         ProductGeneralName = d.ProductGeneralName,
                         BatchNumber = m.BatchNumber,
                         ChangeAmount = m.ChangeAmount,
                         CanSaleNum = m.CanSaleNum,
                         CreateDate = m.CreateDate,
                         Operator = m.OperatorName
                     }).ToArray();

            return q;

        }
    }
}
