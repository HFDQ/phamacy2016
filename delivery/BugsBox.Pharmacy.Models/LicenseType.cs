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
    ///// <summary>
    ///// 证照类型
    ///// </summary>
    //[Description("证照类型")]
    //[DataContract(IsReference = true)]
    //public class LicenseType : Entity, IDictionaryType
    //{
    //    #region Entiy Property


    //    [Required]
    //    [MaxLength(64)]
    //    [MinLength(2)]
    //    [DataMember(Order = 0)]
    //    [DisplayName(ResourceStrings.Name)]
    //    public string Name { get; set; }

    //    [MaxLength(512)]
    //    [DataMember(Order = 1)]
    //    [DisplayName(ResourceStrings.Decription)]
    //    public string Decription { get; set; }

    //    [Required]
    //    [MaxLength(16)]
    //    [MinLength(1)]
    //    [DataMember(Order = 2)]
    //    [DisplayName(ResourceStrings.Code)]
    //    public string Code { get; set; }

    //    /// <summary>
    //    /// 启用
    //    /// </summary>
    //    [DataMember(Order = 3)]
    //    [DisplayName(ResourceStrings.Enabled)]
    //    public bool Enabled { get; set; }

    //    #endregion

    //    #region Navigation Property
    //    [DataMember]
    //    public virtual ICollection<PharmacyLicense> Licenses { get; set; }

    //    #endregion
    //}


}
