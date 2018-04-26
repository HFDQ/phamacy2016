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
    /// 文件
    /// </summary>
    [Description("文件")]
    [DataContract(IsReference = true)]
    public class PharmacyFile : Entity, ILEntity,IStore
    {
        #region Entiy Property

        /// <summary>
        /// 创建用户编号
        /// </summary>
        [DataMember(Order = 0)]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember(Order = 1)]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DataMember(Order = 2)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember(Order = 3)]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 文件名，不包括后缀名
        /// </summary>
        [Required]
        [DisplayName("文件名")]
        [DataMember(Order = 4)]
        public string FileName { get; set; }

        /// <summary>
        /// 后缀名
        /// </summary>
        [Required]
        [DisplayName("后缀名")]
        [DataMember(Order = 5)]
        public string Extension { get; set; }

        /// <summary>
        /// 文件数据
        /// </summary> 
        [Required]
        [DisplayName("文件数据")]
        [DataMember(Order = 6)]
        public byte[] FileStream { get; set; }

        [DataMember(Order = 7)]
        public Guid StoreId { get; set; }

        #endregion

        #region Navigation Property

        #endregion 
    }
}

