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
    /// 不常用字(生僻字)
    /// Version:2013.07.16.2143
    /// 由谈跃完成
    /// </summary>
    [Description("不常用字(生僻字)")]
    [DataContract(IsReference = true)]
    public class Rareword : Entity, IDictionaryType
    {
        #region Entiy Property

        /// <summary>
        /// 拼音
        /// </summary> 
        [Required(ErrorMessage = "请输入[拼音]")]
        [DataMember(Order = 0)]
        public string PinYin { get; set; }

        /// <summary>
        /// 汉字
        /// </summary>
        [Required(ErrorMessage = "请输入[汉字]")]
        [DataMember(Order = 1)]
        public string Word { get; set; }

        /// <summary>
        /// 汉字拆分 
        /// </summary> 
        [DataMember(Order = 2)]
        public string Parts { get; set; }

        [NotMapped]
        public string Decription { get; set; }

        [Required]
        [DataMember(Order = 2)]
        [DisplayName(ResourceStrings.Code)]
        public string Code { get; set; }


        [NotMapped]
        public string Name { get; set; }

        [NotMapped]
        public bool Enabled { get; set; }

        #endregion

        #region Navigation Property

        #endregion
    }
}

