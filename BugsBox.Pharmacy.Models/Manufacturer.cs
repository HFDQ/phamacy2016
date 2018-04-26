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
    /// <summary>
    /// 生产厂家
    /// 用于录入药品基本信时作为选择
    /// </summary>
    [Description("生产厂家 ")]
    [DataContract(IsReference = true)]
    public class Manufacturer:Entity,IDictionaryType,IStore
    {
        #region Entiy Property

        [Required]
        [DataMember(Order = 0)]
        [DisplayName(ResourceStrings.Name)]
        public string Name { get; set; }

        /// <summary>
        /// 简拼
        /// </summary>
        [Required]
        [DisplayName(ResourceStrings.Decription)]
        [DataMember]
        public string ShortPinYin { get; set; }

        [DataMember(Order = 1)]
        [DisplayName(ResourceStrings.Decription)]
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

        /// <summary>
        /// 地址
        /// </summary>
        [Required]
        [DataMember]
        [DisplayName(ResourceStrings.Decription)]
        public string Address { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [DisplayName(ResourceStrings.Decription)]
        [DataMember]
        [Required]
        public string Tel { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [DisplayName(ResourceStrings.Decription)]
        [DataMember]
        public string Contact{ get; set; }


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
