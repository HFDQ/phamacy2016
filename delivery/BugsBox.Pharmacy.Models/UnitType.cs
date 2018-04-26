using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using BugsBox.Pharmacy.Models.Config;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 企业类型
    /// </summary>
    [Description("企业类型")]
    [DataContract(IsReference = true)]
    public class UnitType : Entity, IDictionaryType
    {
        [Required]
        [DataMember(Order = 0)]
        [DisplayName(ResourceStrings.Name)]
        public string Name { get; set; }

        [Required]
        [DataMember(Order = 1)]
        [DisplayName(ResourceStrings.Enabled)]
        public bool Enabled { get; set; }

        [DataMember(Order = 1)]
        [DisplayName(ResourceStrings.Decription)]
        public string Decription { get; set; }

        [Required]
        [DataMember(Order = 2)]
        [DisplayName(ResourceStrings.Code)]
        public string Code { get; set; }

        [DataMember]
        public virtual ICollection<SupplyUnit> SupplyUnits { get; set; }
        [DataMember]
        public virtual ICollection<PurchaseUnit> PurchaseUnits { get; set; }

    }
}

