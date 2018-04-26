using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using BugsBox.Pharmacy.Business.Models.QueryModelExtesion;

namespace BugsBox.Pharmacy.Business.Models
{
    /// <summary>
    /// 证书查询模型
    /// </summary>
    [DataContract]
    public class QueryPharmacyLicenseModel
    {
        public QueryPharmacyLicenseModel()
        {
            Enabled = new BooleanExp();
            StartDate = new DateTimeRange();
            OutDate = new DateTimeRange();
            IssuanceDate = new DateTimeRange();
            Valid = new BooleanExp();
            LicenseTypeValue = -1;
        }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public BooleanExp Enabled { get; set; }
        [DataMember]
        public string UnitName { get; set; }
        [DataMember]
        public string RegAddress { get; set; }
        [DataMember]
        public string LicenseCode { get; set; }
        [DataMember]
        public DateTimeRange StartDate { get; set; }
        [DataMember]
        public DateTimeRange OutDate { get; set; }
        [DataMember]
        public DateTimeRange IssuanceDate { get; set; }
        [DataMember]
        public string IssuanceOrg { get; set; }
        [DataMember]
        public BooleanExp Valid { get; set; }
        [DataMember]
        public int LicenseTypeValue { get; set; }
    }
}
