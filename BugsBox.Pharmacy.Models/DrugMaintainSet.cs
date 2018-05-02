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
    /// 药品养护设置 
    /// </summary>
    [Description("药品养护设置")]
    [DataContract]
    public class DrugMaintainSet : Entity 
    {
        [Required]
        [DataMember]
        public int DrugMaintainTypeValue { get; set; }

        [IgnoreDataMember]
        [NotMapped]
        public DrugMaintainType DrugMaintainType
        {
            get
            {
                return (DrugMaintainType)DrugMaintainTypeValue;
            }
            set
            {
                DrugMaintainTypeValue = (int)value;
            }
        }



        /// <summary>
        /// 名称
        /// </summary>
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
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 提前多少天提醒
        /// </summary> 
        [DataMember(Order = 2)]
        public int RemindBeforeDay { get; set; }
         
        /// <summary>
        /// 普通药某一批次最少维护百分比
        /// </summary> 
        [DataMember(Order = 2)]
        public int? MinPercent { get; set; }

    }
}
