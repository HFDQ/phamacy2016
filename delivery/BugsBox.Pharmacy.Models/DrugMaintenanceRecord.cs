using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{ /// <summary>
    /// 药品养护记录
    /// </summary>
    [Description("药品养护记录")]
    [DataContract(IsReference = true)]
    public class DrugMaintenanceRecord  :Entity
    { 
        /// <summary>
        /// 药物库存Id
        /// </summary> 
        [DataMember(Order = 1)]
        public Guid DrugInventoryRecordId { get; set; }

        /// <summary>
        /// 养护人Id
        /// </summary> 
        [DataMember(Order = 2)]
        public Guid UserId { get; set; }

        /// <summary>
        /// 本次养护日期
        /// </summary> 
        [DataMember(Order = 3)]
        public DateTime MaintenanceTime { get; set; }

        /// <summary>
        /// 上次养护人Id
        /// </summary> 
        [DataMember(Order = 4)]
        public Guid LastUserId { get; set; }

        /// <summary>
        /// 上次养护日期
        /// </summary> 
        [DataMember(Order = 5)]
        public DateTime LastMaintenanceTime { get; set; }
         
        /// <summary>
        /// 备注
        /// </summary> 
        [Required]
        [MaxLength(512)]
        [DataMember(Order = 6)]
        public string Memo { get; set; }
    }
}
