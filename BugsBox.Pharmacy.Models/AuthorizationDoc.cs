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
    /// 授权书
    /// </summary>
    [Description("授权书")]
    [DataContract(IsReference = true)]
    public class AuthorizationDoc : Entity, IOutDate, IStore,ILEntity
    {
        #region Entiy Property 

        public string DocFile { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 过期日
        /// </summary>
        public DateTime OutDate { get; set; }

        /// <summary>
        /// 有效
        /// </summary>
        public bool Valid { get; set; } 

        /// <summary>
        /// 过期
        /// </summary>
        public bool IsOutDate { get; set; } 

        /// <summary>
        /// 创建用户编号
        /// </summary>
        public Guid CreateUserId { get; set; } 

        /// <summary>
        /// 更新用户编号
        /// </summary>
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DataMember(Order = 0)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember(Order = 1)]
        public DateTime UpdateTime { get; set; }

        #endregion

        #region Navigation Property

        public Guid StoreId { get; set; }

        /// <summary>
        /// 区域编号
        /// </summary>
        public int DistrictId { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public virtual District District { get; set; }

        #endregion





    }
}

