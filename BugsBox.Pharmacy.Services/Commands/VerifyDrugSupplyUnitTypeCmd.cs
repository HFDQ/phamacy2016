using BugsBox.Application.Core;
using BugsBox.Application.Core.CF;
using BugsBox.Pharmacy.BusinessHandlers;
using BugsBox.Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.Commands
{
    public class VerifyDrugSupplyUnitTypeCmd : Command
    {
        public List<Guid> DrugInfoIds { get; set; }

        public override object Execute()
        {

            // var  db = new Service<DrugInfo>();
            //DrugInventoryRecordBusinessHandler
        

            throw new NotImplementedException();
        }
    }
}
