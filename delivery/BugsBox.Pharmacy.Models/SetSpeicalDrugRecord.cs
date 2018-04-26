using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace BugsBox.Pharmacy.Models
{
    [Description("设置重点药品记录表")]
    public class SetSpeicalDrugRecord : Entity
    {
        [DataMember]
        public Guid DrugInventoryId { get; set; }

        /// <summary>
        /// 养护期限
        /// </summary>
        [DataMember]
        public int MaintainDuetime { get; set; }

        /// <summary>
        /// 确认理由
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 养护重点
        /// </summary>
        public string MaintainEmphasis { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }
    }
}
