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
    /// 管理要求分类详细
    /// </summary>
    [Description("管理要求分类详细")]
    [DataContract(IsReference = true)]
    public class PurchaseManageCategoryDetail : Entity, IDictionaryType
    {

        #region Entiy Property

        [Required]
        [DataMember(Order = 0)]
        [DisplayName(ResourceStrings.Name)]
        public string Name { get; set; }

        [Required]
        [DataMember(Order = 1)]
        [DisplayName(ResourceStrings.Code)]
        public string Code { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [DataMember(Order = 2)]
        [DisplayName(ResourceStrings.Enabled)]
        public bool Enabled { get; set; }

        [NotMapped]
        public string Decription { get; set; }

        #endregion

        #region Navigation Property
        [DataMember]
        public Guid PurchaseManageCategoryId { get; set; }
        [DataMember]
        public virtual PurchaseManageCategory PurchaseManageCategory { get; set; }
        [DataMember]
        public virtual ICollection<BusinessTypeManageCategoryDetail> BusinessTypeManageCategoryDetails { get; set; }

        #endregion
    }
}
