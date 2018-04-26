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
    /// 包装
    /// </summary>
    [Description("包装")]
    [DataContract(IsReference = true)]
    public class PackagingUnit : Entity, IDictionaryType
    {

        #region Entiy Property

        [Extend.Required]
        [DataMember(Order = 0)]
        [DisplayName(ResourceStrings.Name)]
        public string Name { get; set; }

        [IgnoreDataMember]
        [NotMapped]
        public string Decription { get; set; }

        [Extend.Required]
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
