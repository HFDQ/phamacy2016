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
    public class SaveMmedicalInstitutionPermitCmd : Command
    {
        [DataMember]
        public bool IsAdd { get; set; }

        [DataMember]
        public MmedicalInstitutionPermit MmedicalInstitutionPermit { get; set; }

        public override object Execute()
        {
            try
            {


                var db = new Db();
                if (IsAdd)
                {

                    db.MmedicalInstitutionPermits.Add(MmedicalInstitutionPermit);

                }
                else
                {

                    var item = db.MmedicalInstitutionPermits.FirstOrDefault(o => o.Id == MmedicalInstitutionPermit.Id);
                    item.Code = MmedicalInstitutionPermit.Code;
                    item.Decription = MmedicalInstitutionPermit.Decription;
                    item.DocNumber = MmedicalInstitutionPermit.DocNumber;
                    item.Enabled = MmedicalInstitutionPermit.Enabled;
                    item.IssuanceDate = MmedicalInstitutionPermit.IssuanceDate;
                    item.IssuanceOrg = MmedicalInstitutionPermit.IssuanceOrg;
                    item.LegalPerson = MmedicalInstitutionPermit.LegalPerson;
                    item.LicenseCode = MmedicalInstitutionPermit.LicenseCode;
                    item.LicenseTypeValue = MmedicalInstitutionPermit.LicenseTypeValue;
                    item.memo = MmedicalInstitutionPermit.memo;
                    item.Name = MmedicalInstitutionPermit.Name;
                    item.OgnTpye = MmedicalInstitutionPermit.OgnTpye;
                    item.OutDate = MmedicalInstitutionPermit.OutDate;
                    item.RegAddress = MmedicalInstitutionPermit.RegAddress;
                    item.RegisterAddress = MmedicalInstitutionPermit.RegisterAddress;
                    item.StartDate = MmedicalInstitutionPermit.StartDate;
                    item.UnitName = MmedicalInstitutionPermit.UnitName;
                    item.WarehouseAddress = MmedicalInstitutionPermit.WarehouseAddress;
                    item.UseMedicalScope = MmedicalInstitutionPermit.UseMedicalScope;
                
                }



                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
