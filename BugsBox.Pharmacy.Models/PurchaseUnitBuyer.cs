using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 购货单位采购人员
    /// </summary>
    [Description("购货单位采购人员")]
    [DataContract(IsReference = true)]
    public class PurchaseUnitBuyer : Entity, IStore
    {
        #region Entiy Property

        /// <summary>
        /// 过期日期
        /// </summary>
        [Required]
        [DataMember(Order = 15)]
        public DateTime OutDate { get; set; }


        [Required]
        [DataMember]
        public int PurchaseLimitTypeValue { get; set; }

        public PurchaseLimitType PurchaseLimitType
        {
            get
            {
                return (PurchaseLimitType)PurchaseLimitTypeValue;
            }
            set
            {
                PurchaseLimitTypeValue = (int)value;
            }
        }

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
        public Guid IDFile { get; set; }

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
        //[Required]
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
        [DataMember(Order = 9)]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember(Order = 11)]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DataMember(Order = 12)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember(Order = 13)]
        public DateTime UpdateTime { get; set; }

        [DataMember(Order = 14)]
        public bool Valid { get; set; }

        [DataMember(Order = 15)]
        public bool Enabled { get; set; }

        #region 核实相关

        /// <summary>
        /// 是否核实
        /// </summary>
        [DataMember(Order = 15)]
        public bool IsChecked { get; set; }

        /// <summary>
        /// 身份核实方式
        /// </summary>
        [Required]
        [DataMember(Order = 15)]
        public string IDCheckType { get; set; }

        /// <summary>
        /// 核实经办人
        /// </summary>
        [Required]
        [DataMember(Order = 15)]
        public Guid IDCheckUserId { get; set; }

        #endregion 核实相关

        #endregion

        #region Navigation Property

        [DataMember(Order = 16)]
        public Guid PurchaseUnitId { get; set; }

        [DataMember(Order = 17)]
        public virtual PurchaseUnit PurchaseUnit { get; set; }

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        #endregion

    }
}

