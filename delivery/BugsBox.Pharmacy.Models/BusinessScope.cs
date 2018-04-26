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
    /// 经营范围
    /// </summary>
    [Description("经营范围")]
    [DataContract(IsReference = true)]
    public class BusinessScope : Entity, IDictionaryType
    {
        #region Entiy Property

        [Required]
        
        [MinLength(1)]
        [DataMember(Order = 0)]
        [DisplayName(ResourceStrings.Name)]
        public string Name { get; set; }

        
        [DataMember(Order = 1)]
        [DisplayName(ResourceStrings.Decription)]
        public string Decription { get; set; }

        [Required]
        
        [MinLength(1)]
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

        [DataMember]
        public Guid BusinessScopeCategoryId { get; set; }
        [DataMember]
        public virtual BusinessScopeCategory BusinessScopeCategory { get; set; }

        #endregion
    }
}
