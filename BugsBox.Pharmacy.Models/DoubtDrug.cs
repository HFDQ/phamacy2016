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
    /// 疑问药品
    /// </summary>
    [Description("疑问药品")]
    [DataContract(IsReference = true)]
    public class DoubtDrug : Entity, IStore, ILEntity
    {

        #region Entiy Property

        /// <summary>
        /// 疑问时药物库存信息
        /// 用Json存储
        /// </summary>
        public string JsonDrugInventoryRecord { get; set; }

        /// <summary>
        /// 疑问描述
        /// </summary>
        [Required]
        [DataMember(Order = 1)]
        [DisplayName(ResourceStrings.Decription)]
        public string Decription { get; set; }

        /// <summary>
        /// 否已经处理
        /// </summary>
        [Required]
        [DataMember]
        public bool Handled { get; set; }

        /// <summary>
        /// 疑问处理描述
        /// </summary>
        [DataMember(Order = 1)]
        [DisplayName(ResourceStrings.Decription)]
        public string HandleDecription { get; set; }

        #region ILEntity Members
        /// <summary>
        /// 疑问创建人
        /// </summary>
        [DataMember(Order = 19)]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember(Order = 20)]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 疑问创建时间
        /// </summary>
        [Required(ErrorMessage = "请输入[创建时间]")]
        [DataMember(Order = 21)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 疑问更新时间
        /// </summary>
        [Required]
        [DataMember(Order = 22)]
        public DateTime UpdateTime { get; set; }

        #endregion

        #endregion

        #region Navigation


        /// <summary>
        /// 药物库存编号
        /// </summary>
        [DataMember]
        public Guid DrugInventoryRecordId { get; set; }

        /// <summary>
        /// 药物库存
        /// </summary>
        [DataMember]
        public DrugInventoryRecord DrugInventoryRecord { get; set; }

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        #endregion



    }
}

