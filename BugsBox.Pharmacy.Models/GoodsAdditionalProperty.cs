using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 商品附加属性
    /// 主键要求与DrugInfo对应 
    /// </summary>
    [Description("商品附加属性")]
    [DataContract]
    public class GoodsAdditionalProperty : Entity
    {
        #region 8大商品扩展

        /// <summary>
        /// 保健功能
        /// </summary>
        [DataMember]
        [DisplayName("保健功能")]
        public string CareFunction { get; set; }

        /// <summary>
        /// 备案内容
        /// </summary>
        [DataMember]
        [DisplayName("备案内容")]
        public string PutOnRecord { get; set; }

        /// <summary>
        /// 备案日期
        /// </summary>
        [DataMember]
        [DisplayName("备案日期")]
        public DateTime PutOnRecordDate { get; set; }

        /// <summary>
        /// 不适宜人群
        /// </summary>
        [DataMember]
        [DisplayName("不适宜人群")]
        public string NotSuitablePeople { get; set; }

        /// <summary>
        /// 适宜人群
        /// </summary>
        [DataMember]
        [DisplayName("适宜人群")]
        public string SuitablePeople { get; set; }

        /// <summary>
        /// 功效成分/标志性成分含量
        /// </summary>
        [DataMember]
        [DisplayName("功效成分/标志性成分含量")]
        public string LandmarkIngredient { get; set; }

        /// <summary>
        /// 批准日期
        /// </summary>
        [DataMember]
        [DisplayName("批准日期")]
        public DateTime LicensePermissionDate { get; set; }

        /// <summary>
        /// 用法用量
        /// </summary>
        [DataMember]
        [DisplayName("用法用量")]
        public string UsageAndDosage { get; set; }

        /// <summary>
        /// 主要原料
        /// </summary>
        [DataMember]
        [DisplayName("主要原料")]
        public string MainIngredient { get; set; }

        /// <summary>
        /// 生产地址
        /// 生产地址中文
        /// </summary>
        [DataMember]
        [DisplayName("生产地址中文")]
        public string ProductAddress { get; set; }


        /// <summary>
        /// 生产地址英文
        /// 生产地址英文
        /// </summary>
        [DataMember]
        [DisplayName("生产地址英文")]
        public string ProductAddressEnglish { get; set; }

        /// <summary>
        /// 生产国中文
        /// </summary>
        [DataMember]
        [DisplayName("生产国中文")]
        public string ProductCountry { get; set; }

        /// <summary>
        /// 产生国英文
        /// </summary>
        [DataMember]
        [DisplayName("产生国英文")]
        public string ProductCountryEnglish { get; set; }

        /// <summary>
        /// 卫生许可证号
        /// </summary>
        [DataMember]
        [DisplayName("卫生许可证号")]
        public string HealthPermit { get; set; }

        /// <summary>
        /// 注册号
        /// </summary>
        [DataMember]
        [DisplayName("注册号")]
        public string RegCode { get; set; }


        /// <summary>
        /// 注册代理
        /// </summary>
        [DataMember]
        [DisplayName("保健功能")]
        public string RegProxyCompany { get; set; }

        /// <summary>
        /// 生产厂家(商)英文名 
        /// </summary>
        [Required]
        [DataMember]
        [DisplayName("生产厂家(商)英文名 ")]
        public string FactoryNameEnglish { get; set; }

        /// <summary>
        /// 生产厂家(商)地址 中文
        /// </summary>
        [Required]
        [DataMember]
        [DisplayName("生产厂家(商)地址 中文")]
        public string FactoryAddress { get; set; }

        /// <summary>
        /// 生产厂家(商)地址 英文
        /// </summary>
        [Required]
        [DataMember]
        [DisplayName("生产厂家(商)地址 英文")]
        public string FactoryAddressEnglish { get; set; }

        #endregion

        #region 


        public virtual DrugInfo DrugInfo { get; set; }

        /// <summary>
        /// 药品编号 
        /// </summary>
        [DataMember]
        [ForeignKey("DrugInfo")]
        public Guid DrugInfoId { get; set; }


        //[InverseProperty("DrugInfoId")] // <- Navigation property name in EntityA
        //public virtual ICollection<DrugInfo> DrugInfos { get; set; }

        #endregion
    }

    /// <summary>
    /// 商品属性属于谁属性
    /// </summary>
    public class GoodsAdditionalPropertyBelong : Attribute
    {
        /// <summary>
        /// 商品类型
        /// </summary>
        public GoodsType GoodsType { get; set; }

        public GoodsAdditionalPropertyBelong()
        {
        }
    }
}
