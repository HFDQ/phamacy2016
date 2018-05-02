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
    /// 门店总店也算作门店
    /// Version:2013.07.16.2143 已经完成
    /// 由谈跃完成
    /// </summary>
    [Description("门店")]
    [DataContract(IsReference = true)]
    public class Store : Entity, IDictionaryType
    {
        #region Entiy Property

        [Required]
        [DataMember(Order = 0)]
        [DisplayName(ResourceStrings.Name)]
        public string Name { get; set; }

        [Required]
        [DataMember(Order = 1)]
        [DisplayName(ResourceStrings.Decription)]
        public string Decription { get; set; }

        [Required]
        [DataMember(Order = 2)]
        [DisplayName("编码")]
        public string Code { get; set; }

        [DataMember(Order = 3)]
        [DisplayName(ResourceStrings.Enabled)]
        [Browsable(false)]
        public bool Enabled { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Required]
        [DataMember(Order = 4)]
        [DisplayName(ResourceStrings.Address)]
        public string Address { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Required]
        [DataMember(Order = 5)]
        [DisplayName(ResourceStrings.Tel)]
        public string Tel { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        [Required]
        [DataMember(Order = 6)]
        [DisplayName(ResourceStrings.Store_Head)]
        public string Head { get; set; }

        /// <summary>
        /// 门店类型值
        /// </summary>
        [DataMember(Order = 7)]
        [DisplayName(ResourceStrings.Store_Type)]
        [Browsable(false)]
        public int StoreTypeValue { get; set; }

        /// <summary>
        /// 门店类型
        /// 不参与序列化
        /// </summary> 
        [NotMapped]
        public StoreType StoreType
        {
            get { return (StoreType)StoreTypeValue; }
            set { StoreTypeValue = (int)value; }
        }

        #endregion

        #region Navigation Property

        #endregion
    }
}

