using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{ 
    /// <summary>
    /// 药品养护设置 
    /// </summary>
    [Description("药品养护设置")]
    [DataContract(IsReference = true)]
    public class DrugWaringSet : Entity 
    {

       
        [Required]
        [DataMember]
        public int DrugMaintenanceTypeValue { get; set; }

        [IgnoreDataMember]
        public DrugMaintenanceType DrugMaintenanceType
        {
            get
            {
                return (DrugMaintenanceType)DrugMaintenanceTypeValue;
            }
            set
            {
                DrugMaintenanceTypeValue = (int)value;
            }
        }



        /// <summary>
        /// 名称
        /// </summary>
        [MaxLength(20)]
        [DataMember(Order = 1)]
        public string Name { get; set; }

        /// <summary>
        /// 养护间隔天数
        /// </summary> 
        [DataMember(Order = 2)]
        public int Day { get; set; }

        /// <summary>
        /// 开始养护的日期
        /// </summary> 
        [DataMember(Order = 2)]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 截止养护的日期
        /// </summary> 
        [DataMember(Order = 2)]
        public DateTime? EndDate { get; set; }
         
    }
}
