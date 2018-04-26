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
    ///  税率
    /// </summary>
    [Description("税率")]
    [DataContract(IsReference = true)]
    public class TaxRate:Entity,IDictionaryType
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
        
        /// <summary>
        /// 销售员ID
        /// </summary>
        [DataMember]
        public Guid? UserID { get; set; }

        /// <summary>
        /// 购货商ID
        /// </summary>
        [DataMember]
        public Guid? PurchaseUnitID { get; set; }

        /// <summary>
        /// 供货商ID
        /// </summary>
        [DataMember]
        public Guid? SupplyUnitID { get; set; }

        [DataMember]
        public Decimal? MRate { get; set; }

        [DataMember]
        public Decimal? IRate { get; set; }
    }
}
