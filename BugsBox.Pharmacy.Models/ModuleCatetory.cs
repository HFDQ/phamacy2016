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
    /// 功能模块分类
    /// Version:2013.07.16.2143 已完成
    /// 由曹晓红完成
    /// </summary>
    [Description("功能模块分类")]
    [DataContract(IsReference = true)]
    public class ModuleCatetory : Entity, IStore
    {
        #region Entiy Property

        [Required(ErrorMessage = "请输入[功能模块分类]")]
        [DataMember(Order = 0)]
        [DisplayName(ResourceStrings.Name)]
        public string Name { get; set; }

        [Required(ErrorMessage = "请输入[描述]")]
        [DataMember(Order = 1)]
        [DisplayName(ResourceStrings.Decription)]
        public string Description { get; set; }

        [DataMember(Order = 2)]
        public Guid StoreId { get; set; }

        
        /// <summary>
        /// 显示顺序
        /// </summary>
        [DataMember]
        public int Index { get; set; }

        #endregion

        #region Navigation Property
        [DataMember(Order = 3)]
        public virtual ICollection<Module> Modules { get; set; }

        #endregion


    }
}

