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
    /// 区域
    /// Version:2013.07.16.2143 已完成
    /// 由谈跃完成
    /// </summary>
    [Description("区域")]
    [DataContract(IsReference = true)]
    public class District : Entity, IDictionaryType, IStore
    {
        #region Entiy Property

        [Required]
        [MinLength(2)]
        [DataMember(Order = 0)]
        public string Name { get; set; }

        [Required]
        [DataMember(Order = 1)]
        public string Decription { get; set; }

        [Required]
        [DataMember(Order = 2)]
        public string Code { get; set; }

        [DataMember(Order = 3)]
        public bool Enabled { get; set; }

        #endregion

        #region Navigation Property

        public Guid StoreId { get; set; }

        /// <summary>
        /// 购货单位
        /// </summary>
        [DataMember]
        public ICollection<PurchaseUnit> PurchaseUnits { get; set; }

        /// <summary>
        /// 授权文书
        /// </summary>
        [DataMember]
        public virtual ICollection<AuthorizationDoc> AuthorizationDocs { get; set; }

        #endregion


    }
}

