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
    /// 购货单位类型
    /// 分店也是购货单位
    /// 总店的购货单位里面包括分店 已经完成
    /// Version:2013.07.16.2143
    /// </summary>
    [Description("购货单位类型")]
    [DataContract(IsReference = true)]
    public class PurchaseUnitType : Entity, IDictionaryType
    {
        #region Entiy Property

        [Required]
        [DataMember(Order = 0)]
        public string Name { get; set; }

        [Required]
        [DataMember(Order = 1)]
        public string Decription { get; set; }

        [Required]
        [DataMember(Order = 2)]
        public string Code { get; set; }

        [DataMember(Order = 3)]
        public bool Enabled { get; set; }

        #endregion

        #region Navigation Property

        #endregion
    }
}

