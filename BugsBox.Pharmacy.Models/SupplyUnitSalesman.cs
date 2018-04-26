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
    /// 供货商销售人员
    /// Version:2013.07.16.2143
    /// 未完成
    /// </summary>
    [Description("供货商销售人员")]
    [DataContract(IsReference = true)]
    public class SupplyUnitSalesman : Entity, IStore, IEnable, IValidation, ILEntity, IOutDate
    {
        #region Entiy Property

        /// <summary>
        /// 过期日期
        /// </summary>
        [Required]
        [DataMember(Order = 15)]
        public DateTime OutDate { get; set; }

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
        /// 启用
        /// </summary>
        [DataMember(Order = 7)]
        public bool Enabled { get; set; }

        /// <summary>
        /// 有效
        /// </summary>
        [DataMember(Order = 8)]
        public bool Valid { get; set; }

        /// <summary>
        /// 分店编号
        /// </summary>
        [DataMember(Order = 9)]
        public Guid StoreId { get; set; }

        [DataMember(Order = 11)]
        public bool IsOutDate { get; set; }

        /// <summary>
        /// 创建用户编号
        /// </summary>
        [DataMember(Order = 12)]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember(Order = 13)]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DataMember(Order = 14)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember(Order = 15)]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 授权区域
        /// Add By Shen 10.03
        /// </summary>    
        [Required]
        [DataMember(Order = 16)]
        public Guid AuthorizedDistrictId { get; set; }

        /// <summary>
        /// 授权业务范围
        /// </summary> 
        [DataMember(Order = 16)]
        public string BusinessScopes { get; set; }

        //edit by wfz
        /// <summary>
        /// 授权业务范围备注
        /// </summary> 
        [DataMember(Order = 16)]
        public string BusinessScopesMemo { get; set; }

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

        /// <summary>
        /// 授权书编号
        /// </summary>
        [DataMember(Order = 16)]
        public Guid AuthorizationDocId { get; set; }

        /// <summary>
        /// 供货单位编号
        /// </summary>
        [DataMember(Order = 17)]
        public Guid SupplyUnitId { get; set; }

        /// <summary>
        /// 供货单位
        /// </summary>
        [DataMember(Order = 18)]
        public virtual SupplyUnit SupplyUnit { get; set; }

        [DataMember(Order = 19)]
        public ICollection<PurchaseAgreement> PurchaseAgreements { get; set; }

        #endregion

    }
}

