using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 药品批准文号
    /// Version:2013.07.16.2143 已经完成 
    /// </summary>
    [Description("药品批准文号")]
    [DataContract(IsReference = true)]
    public class DrugApprovalNumber : Entity,IDictionaryType,IStore
    {
        #region Entiy Property

        [Required]
        [MaxLength(64)]
        [MinLength(2)]
        public string Name { get; set; }

        [NotMapped]
        public string Code { get; set; }

        [NotMapped]
        public string Decription { get; set; }

        public bool Enabled { get; set; }

        #endregion

        #region Navigation Property

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        #endregion 
       
    }
}

