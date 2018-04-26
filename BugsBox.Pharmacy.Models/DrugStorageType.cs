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
    /// 储藏方式 
    /// Version:2013.07.16.2143 已经完成
    /// 由张小艾完成
    /// </summary>
    [Description("储藏方式")]
    [DataContract(IsReference = true)]
    public class DictionaryStorageType:Entity,IDictionaryType
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

        [DataMember(Order = 3)]
        public virtual ICollection<WarehouseZone> WarehouseZone { get; set; }

        #endregion 
    }
}

