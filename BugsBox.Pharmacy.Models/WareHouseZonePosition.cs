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
    public class WareHouseZonePosition:Entity,ILEntity
    {
        /// <summary>
        /// 货位顺序号
        /// </summary>
        [DataMember]
        [DisplayName("序号")]
        public int PIndex { get; set; }

        /// <summary>
        /// 货位顺序号2
        /// </summary>
        [DataMember]
        [DisplayName("序号2")]
        public int PIndex2 { get; set; }

        /// <summary>
        /// 货位名称
        /// </summary>
        [DataMember]
        [DisplayName("名称")]        
        public string Name { get; set; }

        /// <summary>
        /// 货位容量
        /// </summary>
        [DataMember]
        [DisplayName("容量")]
        public decimal Capacity { get; set; }

        /// <summary>
        /// 货位行列
        /// </summary>
        [DataMember]
        [DisplayName("行列")]
        public string RowCol { get; set; }

        /// <summary>
        /// 货位说明
        /// </summary>
        [DataMember]
        [DisplayName("备注")]
        public string Memo { get; set; }

        /// <summary>
        /// 所属货架ID
        /// </summary>
        [DataMember]        
        public Guid WareHouseZoneId { get; set; }

        [DataMember] 
        public DateTime CreateTime { get; set; }

        [DataMember] 
        public Guid CreateUserId { get; set; }

        [DataMember] 
        public DateTime UpdateTime { get; set; }

        [DataMember] 
        public Guid UpdateUserId { get; set; } 

    }
}
