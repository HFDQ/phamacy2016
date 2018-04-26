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
    /// 购货单位提货人员
    /// Version:2013.07.16.2143 已经完成
    /// </summary>
    [Description("购货单位提货人员")]
    [DataContract(IsReference = true)]
    public class PurchaseUnitDeliverer : Entity, IStore, IValidation, ILEntity, IEnable
    {
        #region Entiy Property

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [DataMember(Order = 0)]
        public string Name { get; set; }

        /// <summary>
        /// 身份证复印件
        /// </summary>
        [DataMember(Order = 1)]
        public string IDFile { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        [Required]
        [DataMember(Order = 2)]
        public string IDNumber { get; set; }

        /// <summary>
        /// 电话 
        /// </summary>
        //[Required]
        //[MinLength(8)]
        [DataMember(Order = 3)]
        public string Tel { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Required]
        [DataMember(Order = 4)]
        public string Address { get; set; }

        /// <summary>
        /// 出生年月
        /// </summary>
        [Required]
        [DataMember(Order = 5)]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 性别
        /// </summary> 
        [DataMember(Order = 6)]
        public string Gender { get; set; } 

        /// <summary>
        /// 创建用户编号
        /// </summary>
        [DataMember(Order = 8)]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember(Order = 9)]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DataMember(Order = 10)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember(Order = 11)]
        public DateTime UpdateTime { get; set; }

        [DataMember(Order = 12)]
        public bool Valid { get; set; }

        [DataMember(Order = 13)]
        public bool Enabled { get; set; }

        #endregion

        #region Navigation Property

        [DataMember(Order = 14)]
        public Guid PurchaseUnitId { get; set; }

        [DataMember(Order = 15)]
        public virtual PurchaseUnit PurchaseUnit { get; set; }


        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        #endregion
    }
}

