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
    /// 库区
    /// </summary>
    [Description("库区")]
    [DataContract(IsReference = true)]
    public class WarehouseZone : Entity, IDictionaryType, IStore, ILEntity
    {
        #region Entiy Property

        /// <summary>
        /// 所在仓库序号
        /// </summary>
        [DataMember]
        [DisplayName("标签序号")]
        public int PIndex { get; set; }

        [Required]
        [DataMember(Order = 0)]
        public string Name { get; set; }

        [Required]
        [DataMember(Order = 1)]
        public string Decription { get; set; }

        [Required]
        [DataMember(Order = 2)]
        public string Code { get; set; }

        /// <summary>
        /// 助记码
        /// </summary>
        //[Required]
        
        [DataMember(Order = 3)]
        public string MnemonicCode { get; set; }

        /// <summary>
        /// 总面积
        /// </summary>
        [DataMember(Order = 4)]
        public string Area { get; set; }

        [DataMember(Order = 5)]
        public bool Enabled { get; set; }

        /// <summary>
        /// 创建用户编号
        /// </summary>
        [DataMember(Order = 6)]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember(Order = 7)]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required(ErrorMessage = "请输入[创建时间]")]
        [DataMember(Order = 8)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember(Order = 9)]
        public DateTime UpdateTime { get; set; }

        [DataMember(Order = 10)]
        public Guid StoreId { get; set; }

        [DataMember(Order = 11)]
        public int WarehouseZoneTypeValue { get; set; }


        public WarehouseZoneType WarehouseZoneType
        {
            get { return (WarehouseZoneType)WarehouseZoneTypeValue; }
            set { WarehouseZoneTypeValue = (int)value; }
        }

        #endregion

        #region Navigation Property

        /// <summary>
        /// 仓库编号
        /// </summary>
        [DataMember(Order = 12)]
        [Required]
        public Guid WarehouseId { get; set; }

        /// <summary>
        /// 所属仓库
        /// </summary>
        [DataMember(Order = 13)]
        public virtual Warehouse Warehouse { get; set; }


        /// <summary>
        /// 储藏方式id
        /// </summary>
        [DataMember(Order = 14)]
        [Required]
        public Guid DictionaryStorageTypeId { get; set; }

        /// <summary>
        /// 储藏方式
        /// </summary>
        [DataMember(Order = 15)]
        public virtual DictionaryStorageType DictionaryStorageType { get; set; }

        /// <summary>
        /// 专属存储单位id
        /// </summary>
        [DataMember(Order = 16)]
        public Guid DictionaryMeasurementUnitId { get; set; }

        /// <summary>
        /// 专属存储单位
        /// </summary>
        [DataMember(Order = 17)]
        public virtual DictionaryMeasurementUnit DictionaryMeasurementUnit { get; set; }

        ///// <summary>
        ///// 药物库存
        ///// </summary>
        //[DataMember]
        //public virtual ICollection<DrugInventoryRecord> DrugInventoryRecords { get; set; }

        #endregion


    }
}

