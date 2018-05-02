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
    /// 零售会员
    /// </summary>
    [Description("零售会员")]
    [DataContract(IsReference = true)]
    public class RetailMember:Entity,ILEntity,IDictionaryType,IStore
    {
        #region Entiy Property

        #region 顾客会员信息

        [Extend.Required]
        [DataMember(Order = 0)]
        [DisplayName(ResourceStrings.Name)]
        public string Name { get; set; } 
 
        [NotMapped]
        public string Decription { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Extend.Required]
        [DataMember(Order = 2)]
        [DisplayName(ResourceStrings.Code)]
        public string Code { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [DataMember(Order = 3)]
        [DisplayName(ResourceStrings.Enabled)]
        public bool Enabled { get; set; } 

        #endregion 顾客会员信息

        /// <summary>
        /// 会员类型值
        /// </summary>
        [DataMember]
        public int RetailCustomerTypeValue { get; set; }

        /// <summary>
        /// 会员类型
        /// </summary>
        [NotMapped]
        public RetailCustomerType RetailCustomerType
        {
            get
            {
                return (RetailCustomerType) RetailCustomerTypeValue;
            }
            set
            {
                RetailCustomerTypeValue = (int) value;
            }
        }

        #region ILEntity

        /// <summary>
        /// 创建用户编号
        /// </summary>
        [DataMember]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Extend.Required(ErrorMessage = "请输入[创建时间]")]
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Extend.Required]
        [DataMember]
        public DateTime UpdateTime { get; set; }

        #endregion 


        #endregion

        #region Navigation Property

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 零售单s
        /// </summary>
        [DataMember]
        public ICollection<RetailOrder> RetailOrders { get; set; }

        #endregion
    }
}
