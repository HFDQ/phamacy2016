using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using BugsBox.Pharmacy.Models.Config;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 计量单位
    /// Version:2013.07.16.2143 已经完成
    /// 由张小艾完成
    /// </summary>
    [Description("计量单位")]
    [DataContract(IsReference = true)]
    public class DictionaryMeasurementUnit : Entity,IDictionaryType
    {
        #region Entiy Property

        [Required]
        [DataMember(Order = 0)]
        [DisplayName(ResourceStrings.Name)]
        public string Name { get; set; }

       [NotMapped]
       public string Decription { get; set; }

       [Required]
       [DataMember(Order = 2)]
       [DisplayName(ResourceStrings.Code)]
       public string Code { get; set; } 

        /// <summary>
        /// 启用
        /// </summary>
        [DataMember(Order = 3)]
        [DisplayName(ResourceStrings.Enabled)]
        public bool Enabled { get; set; }


        #endregion

        #region Navigation Property

        #endregion
    }
}

