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
    /// 经营方式
    /// 由曹晓红完成
    /// </summary>
    [Description("经营方式")]
    [DataContract(IsReference = true)]
    public class BusinessType : Entity, IDictionaryType
    {
        
        [DataMember(Order = 1)]
        [DisplayName(ResourceStrings.Decription)]
        public string Decription { get; set; }

        [Required]
        
        [MinLength(1)]
        [DataMember(Order = 2)]
        [DisplayName(ResourceStrings.Code)]
        public string Code { get; set; }


        [Required]
        [DataMember(Order = 0)]
        [DisplayName(ResourceStrings.Name)]
        public string Name { get; set; }

        [Required]
        [DataMember(Order = 1)]
        [DisplayName(ResourceStrings.Enabled)]
        public bool Enabled { get; set; }

        /// <summary>
        /// GSP
        /// </summary>
        [DataMember]
        public virtual ICollection<GSPLicense> GSPLicenses { get; set; }

        [DataMember]
        public ICollection<BusinessTypeManageCategoryDetail> BusinessTypeManageCategoryDetails { get; set; }



    }
}

