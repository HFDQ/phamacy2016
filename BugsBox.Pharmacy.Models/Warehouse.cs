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
    /// 仓库
    /// Version:2013.07.16.2143 已经完成
    /// 由谈跃完成 
    /// </summary>
    [Description("仓库")]
    [DataContract(IsReference = true)]
    public class Warehouse : Entity, IDictionaryType, IStore, ILEntity
    {
        #region Entiy Property
        /// <summary>
        /// 仓库名称
        /// </summary>
        [Required]
        [DataMember(Order = 0)]
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Required]
        [DataMember(Order = 1)]
        public string Code { get; set; }

        /// <summary>
        /// 助记码
        /// </summary>
        //[Required]
        //[MinLength(1)]
        [DataMember(Order = 2)]
        public string MnemonicCode { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Required]
        //[MinLength(1)]
        [DataMember(Order = 3)]
        public string Address { get; set; }


        /// <summary>
        /// 管理单位
        /// </summary>
        [DataMember(Order = 4)]
        public string ManagementCompany { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        //[Required]
        //[MinLength(1)]
        [DataMember(Order = 5)]
        public string Phone { get; set; }

        /// <summary>
        /// 租赁单位
        /// </summary>
        //[MaxLength(200)]
        //[DataMember(Order = 6)]
        //public string RentCompany { get; set; }

        /// <summary>
        /// 租赁年限
        /// </summary>
        //[MaxLength(20)]
        //[DataMember(Order = 7)]
        //public string RentYear { get; set; }

        /// <summary>
        /// 租赁开始时间
        /// </summary>
        //[DataMember(Order = 8)]
        //public DateTime? RentStartTime { get; set; }

        /// <summary>
        /// 租赁结束时间
        /// </summary>
        //[DataMember(Order = 9)]
        //public DateTime? RentEndTime { get; set; }

        /// <summary>
        /// 总面积
        /// </summary>
        [DataMember(Order = 10)]
        public string Area { get; set; }

        /// <summary>
        /// 阴凉面积
        /// </summary>
        [DataMember(Order = 11)]
        public string ShadeArea { get; set; }

        /// <summary>
        /// 常温面积
        /// </summary>
        [DataMember(Order = 12)]
        public string NormalArea { get; set; }

        /// <summary>
        /// 冷库面积
        /// </summary>
        [DataMember(Order = 13)]
        public string ColdArea { get; set; }

        /// <summary>
        /// 饮片分装室面积
        /// </summary>
        [DataMember(Order = 14)]
        public string YPFZArea { get; set; }

        /// <summary>
        /// 养护验收室面积
        /// </summary>
        [DataMember(Order = 15)]
        public string YHYSSArea { get; set; }

        /// <summary>
        /// 配货场面积
        /// </summary>
        [DataMember(Order = 16)]
        public string PHCArea { get; set; }

        /// <summary>
        /// 特药专区面积
        /// </summary>
        [DataMember(Order = 17)]
        public string TYZQArea { get; set; }

        /// <summary>
        /// 低温面积
        /// </summary>
        [DataMember(Order = 18)]
        public string DWArea { get; set; }

        //[Required]
        [DataMember(Order = 19)]
        public string Decription { get; set; }

        

        [DataMember(Order = 20)]
        public bool Enabled { get; set; }

        /// <summary>
        /// 创建用户编号
        /// </summary>
        [DataMember(Order = 21)]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember(Order = 22)]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required(ErrorMessage = "请输入[创建时间]")]
        [DataMember(Order = 23)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember(Order = 24)]
        public DateTime UpdateTime { get; set; }

        [DataMember(Order = 25)]
        public Guid StoreId { get; set; }

        #endregion

        #region Navigation Property

        [DataMember(Order = 26)]
        public virtual ICollection<WarehouseZone> WarehouseZones { get; set; }

        #endregion


    }
}

