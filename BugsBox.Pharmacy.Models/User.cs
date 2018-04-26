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
    /// 系统用户
    /// Version:2013.07.16.2143已经完成
    /// 由曹晓红完成
    /// 修改Gender为String
    /// </summary>
    [Description("系统用户")]
    [DataContract(IsReference = true)]
    public class User : Entity, IEnable, IStore, ILEntity
    {
        public User()
        {
         
        }

        #region Entiy Property
        
        [Required(ErrorMessage = "请输入[登录账户]")]
        [DataMember(Order = 0)]
        public string Account { get; set; }

        [Required(ErrorMessage = "请输入[密码]")]
        [DataMember(Order = 1)]
        public string Pwd { get; set; }

        /// <summary>
        /// 是否有特价销售权限
        /// </summary>
        [DataMember(Order = 2)]
        public Boolean IsSpecialPriceAuth { get; set; }

        /// <summary>
        /// 特价销售权限
        /// </summary>
        [DataMember(Order = 2)]
        public string SpecialPriceAuth { get; set; }

        /// <summary>
        /// 创建用户编号
        /// </summary>
        [DataMember(Order = 3)]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember(Order = 4)]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required(ErrorMessage = "请输入[创建时间]")]
        [DataMember(Order = 5)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember(Order = 6)]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 启用禁用
        /// </summary>
        [Required(ErrorMessage = "请确认是否[启用]")]
        [DataMember(Order = 7)]
        public bool Enabled { get; set; }
         
        [DataMember(Order = 8)]
        public Guid StoreId { get; set; }

        #endregion

        #region Navigation Property

        [DataMember(Order = 9)]
        public Guid EmployeeId { get; set; }

        [DataMember(Order = 10)]
        public virtual Employee Employee { get; set; }

        [DataMember(Order = 11)]
        public ICollection<RoleWithUser> RoleWithUser { get; set; }

        #endregion

        public override bool Equals(object obj)
        {
            User oUser = obj as User;
            if (oUser == null) return false;
            return oUser.Id == this.Id;
        }

        /// <summary>
        /// 采购返税点
        /// </summary>
        [DataMember]
        [System.ComponentModel.DisplayName("税票费率%")]
        public Decimal? PurchaseTaxReturn { get; set; }

        /// <summary>
        /// 销售管理费
        /// </summary>
        [DataMember]
        [System.ComponentModel.DisplayName("管理费率%")]
        public decimal? SalesManageFee { get; set; }
    }
}

