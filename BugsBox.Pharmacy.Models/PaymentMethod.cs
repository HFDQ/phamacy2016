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
    /// 付款方式
    /// </summary>
    [Description("付款方式")]
    [DataContract(IsReference = true)]
    public class PaymentMethod:Entity,IDictionaryType
    {
        #region Entiy Property

        [Required]
        [MinLength(2)]
        [DataMember(Order = 0)]
        [DisplayName(ResourceStrings.Name)]
        public string Name { get; set; } 

        [IgnoreDataMember]
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
