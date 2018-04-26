using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;


namespace BugsBox.Pharmacy.Business.Models
{
    public class SalesTaxRate
    {
        [DisplayName("ID")]
        [DataMember]
        public Guid Id { get; set; }
        [DisplayName("员工姓名")]
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        [DisplayName("购货商")]
        public string PurchaseUnitName { get; set; }
        [DataMember]
        [DisplayName("UID")]
        public Guid? UserId { get; set; }
        [DataMember]
        [DisplayName("PID")]
        public Guid? PurchaseUnitId { get; set; }
        [DataMember]
        [DisplayName("管理费率")]
        public Decimal? MRate { get; set; }
        [DataMember]
        [DisplayName("发票费率")]
        public Decimal? IRate { get; set; }
    }
}
