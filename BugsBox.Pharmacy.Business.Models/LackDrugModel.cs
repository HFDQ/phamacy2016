using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    [DataContract]
    public class LackDrugModel
    {
        [DataMember]
        public Guid Id { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }
        /// <summary>
        /// 药品通用名
        /// </summary>
        [DataMember]
        public string ProductGeneralName { get; set; }
        //编码

        [DataMember]
        public string Code { get; set; }
        /// <summary>
        /// 药品本位码
        /// </summary>
        [DataMember]
        public string StandardCode { get; set; }

        /// <summary>
        /// 拼音
        /// </summary>
        [DataMember]
        public string pinyin { get; set; }

        /// <summary>
        /// 拼音
        /// </summary>
        [DataMember]
        public string Origin { get; set; }


        //厂家全称
        [DataMember]
        public string FactoryName { get; set; }

        //采购价
        [DataMember]
        public decimal PurchasePrice { get; set; }

        //规格
        [DataMember]
        public string DictionarySpecificationCode { get; set; }

        //药品单位
        [DataMember]
        public string DictionaryMeasurementUnitCode { get; set; }

        //经营范围
        [DataMember]
        public string BusinessScopeCode { get; set; }

        //剂型
        [DataMember]
        public string DictionaryDosageCode { get; set; }

        //批准文号
        [DataMember]
        public string LicensePermissionNumber { get; set; }

        /// <summary>
        /// 当前库存数量
        /// </summary>
        [DataMember]
        public decimal CurrentInventoryCount { get; set; }

        /// <summary>
        /// 当前可售数量
        /// </summary>
        [DataMember]
        public decimal CurrentCanSaleCount { get; set; }

        /// <summary>
        /// 库存下限
        /// </summary>
        [DataMember]
        public int MinInventoryCount { get; set; }

        /// <summary>
        /// 最近采购时间
        /// </summary>
        [DataMember]
        public DateTime dtime { get; set; }
        /// <summary>
        /// 最近销售时间
        /// </summary>
        [DataMember]
        public string lastsaledate { get; set; }



        /// <summary>
        /// 销量排行
        /// </summary>
        [DataMember]
        public decimal wholeSales { get; set; }

        /// <summary>
        /// 所在仓库
        /// </summary>
        [DataMember]
        public string wareHouse { get; set; }
    }
}
