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
    /// 医疗分类
    /// </summary>
    [Description("医疗分类")]
    [DataContract(IsReference = true)]
    public class MedicalCategory : Entity, IDictionaryType
    {
        #region Entiy Property

        [Required]
        [DataMember(Order = 0)]
        [DisplayName(ResourceStrings.Name)]
        public string Name { get; set; }

        [DataMember(Order = 1)]
        [DisplayName(ResourceStrings.Decription)]
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

        [DataMember]
        public virtual ICollection<MedicalCategoryDetail> MedicalCategories { get; set; }

        #endregion
    }
}
