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
    /// 功能模块
    /// Version:2013.07.16.2143 已经完成
    /// 由曹晓红完成
    /// </summary>
    [Description("功能模块")]
    [DataContract(IsReference = true)]
    public class Module : Entity,IStore
    {
        #region Entiy Property

        /// <summary>
        /// 功能模块为枚举的Display
        /// </summary>
        [Required(ErrorMessage = "请输入[功能模块]")]
        [DataMember(Order = 0)]
        [DisplayName(ResourceStrings.Name)]
        public string Name { get; set; }

        /// <summary>
        /// 功能模块描述为枚举的Display
        /// </summary>
        [Required(ErrorMessage = "请输入[功能模块描述]")]
        [DataMember(Order = 1)]
        [DisplayName(ResourceStrings.Decription)]
        public string Description { get; set; }

        /// <summary>
        /// 授权Key
        /// 此为枚举ToString()
        /// </summary>
        [Required(ErrorMessage = "请输入[授权Key]")]
        [DataMember(Order = 2)]
        public string AuthKey { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        [DataMember]
        public int Index { get; set; }

        #endregion

        #region Navigation Property

        [DataMember(Order = 3)]
        public Guid ModuleCatetoryId { get; set; }

        [DataMember(Order = 4)]
        public virtual ModuleCatetory ModuleCatetory { get; set; }

        [DataMember(Order = 5)]
        public ICollection<ModuleWithRole> ModuleWithRoles { get; set; }

        [DataMember(Order = 6)]
        public Guid StoreId { get; set; }

        #endregion


    }
}

