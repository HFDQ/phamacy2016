using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel;

namespace BugsBox.Pharmacy.Business.Models
{
    public class InstrumentsModel
    {
        [DisplayName("标识码")]
        [DataMember]
        public Guid Id { get; set; }

        [DisplayName("名称")]
        [DataMember(Order = 1)]
        public string ProductGeneralName { get; set; }

        [DisplayName("注册证编号或者备案凭证编号")]
        [DataMember(Order = 3)]
        public string LicensePermissionNumber { get; set; }

        [DisplayName("产品技术编号")]
        [DataMember(Order = 4)]
        public string PerformanceStandards { get; set; }

        [DisplayName("生产企业生产企业许可证编号或备案凭证编号")]
        [DataMember(Order = 5)]
        public string InstEntProductLiscencePermitNumber { get; set; }

        [DisplayName("产品编号")]
        [DataMember(Order = 6)]
        public string Code { get; set; }

        [DisplayName("档案编号")]
        [DataMember(Order = 6)]
        public string DocCode { get; set; }

        [DisplayName("拼音码")]
        [DataMember(Order = 7)]
        public string Pinyin { get; set; }

        [DisplayName("条形码")]
        [DataMember(Order = 6)]
        public string BarCode { get; set; }

        [DisplayName("单位")]
        [DataMember(Order = 11)]
        public string DictionaryMeasurementUnitCode { get; set; }

        [DisplayName("产品型号")]
        [DataMember(Order = 12)]
        public string DictionaryDosageCode { get; set; }

        [DisplayName("规格")]
        [DataMember(Order = 13)]
        public string DictionarySpecificationCode { get; set; }

        [DisplayName("厂家全称")]
        [DataMember(Order = 14)]
        public string FactoryName { get; set; }

        /// <summary>
        /// 联系方式-映射到品种信息的厂家简称字段
        /// </summary>
        [DisplayName("联系方式")]
        [DataMember(Order = 14)]
        public string Contact { get; set; }
        
        [DisplayName("经营范围")]
        [DataMember(Order = 16)]
        public string BusinessScopeCode { get; set; }

        [DisplayName("是否审批")]
        [DataMember(Order = 17)]
        public string IsApproval { get; set; }

        [DisplayName("是否人为锁定")]
        [DataMember(Order = 18)]
        public string Locked { get; set; }

        [DisplayName("是否有效")]
        [DataMember(Order = 19)]
        public string Valid { get; set; }

        [DisplayName("无效原因")]
        [DataMember(Order = 19)]
        public string NotValidReason { get; set; }

        [DisplayName("仓库")]
        [DataMember(Order = 20)]
        public string WareHouses { get; set; }

        [DisplayName("库位(货架)")]
        [DataMember(Order = 20)]
        public string WareHouseZone { get; set; }

        [DisplayName("存储方式")]
        [DataMember(Order = 21)]
        public string DrugStorageTypeCode { get; set; }

        [DisplayName("最大库存")]
        [DataMember(Order = 22)]
        public int MaxInventoryCount { get; set; }

        [DisplayName("最小库存")]
        [DataMember(Order = 23)]
        public int MinInventoryCount { get; set; }
                
        #region 价格信息
        [DisplayName("价格")]
        [DataMember(Order = 26)]
        public decimal Price { get; set; }

        [DisplayName("销售价")]
        [DataMember(Order = 27)]
        public decimal SalePrice { get; set; }        

        [DisplayName("最高限价")]
        [DataMember(Order = 30)]
        public decimal LimitedUpPrice { get; set; }

        [DisplayName("最低限价")]
        [DataMember(Order = 31)]
        public decimal LimitedLowPrice { get; set; }

        #endregion
        
        [DisplayName("是否进口")]
        [DataMember(Order = 33)]
        public string IsImport { get; set; }
        
        [DisplayName("有效期")]
        [DataMember(Order = 37)]
        public int ValidPeriod { get; set; }
             

        [DisplayName("管理分类")]
        [DataMember(Order = 44)]
        public string DrugCategoryCode { get; set; }

        [DisplayName("器械分类码")]
        [DataMember(Order = 45)]
        public string StandardCode { get; set; }

        [DisplayName("采购员意见")]
        [DataMember(Order = 46)]
        public string Description { get; set; }

        [DisplayName("创建时间")]
        [DataMember(Order = 48)]
        public DateTime CreateTime { get; set; }

        [DisplayName("创建人")]
        [DataMember(Order = 49)]
        public string CreateUserName { get; set; }
    }
}
