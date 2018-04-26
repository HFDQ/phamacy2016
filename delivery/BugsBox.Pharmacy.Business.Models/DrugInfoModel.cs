using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel;

namespace BugsBox.Pharmacy.Business.Models
{
    public class DrugInfoModel
    {
        [DisplayName("标识码")]
        [DataMember]
        public Guid id { get; set; }

        [DisplayName("药品通用名")]
        [DataMember(Order = 1)]
        public string ProductGeneralName { get; set; }

        [DisplayName("许可证号")]
        [DataMember(Order = 2)]
        public string PermitLicenseCode { get; set; }

        [DisplayName("批准文号")]
        [DataMember(Order = 3)]
        public string LicensePermissionNumber { get; set; }

        [DisplayName("执行标准")]
        [DataMember(Order = 4)]
        public string PerformanceStandards { get; set; }

        [DisplayName("编码")]
        [DataMember(Order = 5)]
        public string Code { get; set; }

        [DisplayName("档案号")]
        [DataMember(Order = 6)]
        public string DocCode { get; set; }

        [DisplayName("拼音码")]
        [DataMember(Order = 7)]
        public string Pinyin { get; set; }
        
        [DisplayName("条形码")]
        [DataMember(Order = 8)]
        public string BarCode { get; set; }

        [DisplayName("本位码")]
        [DataMember(Order = 9)]
        public string StandardCode { get; set; }

        [DisplayName("名称")]
        [DataMember(Order = 10)]
        public string ProductName { get; set; }
                
        [DisplayName("单位")]
        [DataMember(Order = 11)]
        public string DictionaryMeasurementUnitCode { get; set; }

        [DisplayName("剂型")]
        [DataMember(Order = 12)]
        public string DictionaryDosageCode { get; set; }

        [DisplayName("规格")]
        [DataMember(Order = 13)]
        public string DictionarySpecificationCode { get; set; }

        [DisplayName("厂家全称")]
        [DataMember(Order = 14)]
        public string FactoryName { get; set; }

        [DisplayName("产地")]
        [DataMember(Order = 15)]
        public string Origin { get; set; }

        [DisplayName("经营范围")]
        [DataMember(Order = 16)]
        public string BusinessScopeCode { get; set; }

        [DisplayName("是否审批")]
        [DataMember(Order = 17)]
        public string IsApproval { get; set; }

        [DisplayName("是否有效")]
        [DataMember(Order = 18)]
        public string Valid { get; set; }

        [DisplayName("仓库")]
        [DataMember(Order = 19)]
        public string WareHouses { get; set; }

        [DisplayName("货架")]
        [DataMember(Order = 20)]
        public string WareHouseZones { get; set; }

        [DisplayName("存储方式")]
        [DataMember(Order = 21)]
        public string DrugStorageTypeCode { get; set; }

        [DisplayName("最大库存")]
        [DataMember(Order = 22)]
        public int MaxInventoryCount { get; set; }

        [DisplayName("最小库存")]
        [DataMember(Order = 23)]
        public int MinInventoryCount { get; set; }        
 
        [DisplayName("拆零规格")]
        [DataMember(Order = 24)]
        public string PiecemealSpecification { get; set; }
     
        [DisplayName("拆零数量")]
        [DataMember(Order = 25)]
        public int PiecemealNumber { get; set; }
        #region 价格信息
        [DisplayName("价格")]
        
        [DataMember(Order = 26)]
        public decimal Price { get; set; }

        [DisplayName("销售价")]
        [DataMember(Order = 27)]
        public decimal SalePrice { get; set; }

        [DisplayName("批发价")]
        [DataMember(Order = 28)]
        public decimal WholeSalePrice { get; set; }

        [DisplayName("零售价")]
        [DataMember(Order = 29)]
        public decimal RetailPrice { get; set; }
        
        [DisplayName("最高限价")]
        [DataMember(Order = 30)]
        public decimal LimitedUpPrice { get; set; }
#endregion
        [DisplayName("是否医保")]
        [DataMember(Order = 31)]
        public string IsMedicalInsurance { get; set; }
                
        [DisplayName("是否处方药")]
        [DataMember(Order = 32)]
        public string IsPrescription { get; set; }

        [DisplayName("是否进口药")]
        [DataMember(Order = 33)]
        public string IsImport { get; set; }

        [DisplayName("是否重点养护")]
        [DataMember(Order = 34)]
        public string IsMainMaintenance { get; set; }

        [DisplayName("是否特殊管理药品")]
        [DataMember(Order = 35)]
        public string IsSpecialDrugCategory { get; set; }

        [DisplayName("特殊管理药品类型")]
        [DataMember(Order = 36)]
        public string SpecialDrugCategoryCode { get; set; }
                
        [DisplayName("保质期")]
        [DataMember(Order = 37)]
        public int ValidPeriod { get; set; }

        [DisplayName("包装")]
        [DataMember(Order = 38)]
        public string Package { get; set; }

        [DisplayName("包装数量")]
        [DataMember(Order = 39)]
        public int PackageAmount { get; set; }
                
        [DisplayName("大包")]
        [DataMember(Order = 40)]
        public decimal BigPackage { get; set; }

        [DisplayName("中包")]
        [DataMember(Order = 41)]
        public decimal MiddlePackage { get; set; }

        [DisplayName("小包")]
        [DataMember(Order = 42)]
        public int SmallPackage { get; set; }

        [DisplayName("药品管理分类详细")]
        [DataMember(Order = 44)]
        public string PurchaseManageCategoryDetailCode { get; set; }

        [DisplayName("药品分类")]
        [DataMember(Order = 44)]
        public string DrugCategoryCode { get; set; }

        [DisplayName("医疗详细分类")]
        [DataMember(Order = 45)]
        public string MedicalCategoryDetailCode { get; set; }

        [DisplayName("临床分类")]
        [DataMember(Order = 46)]
        public string DrugClinicalCategoryCode { get; set; }
            
        [DisplayName("拆零单位")]
        [DataMember(Order = 47)]
        public string DictionaryPiecemealUnitCode { get; set; }

        

        [DisplayName("创建时间")]
        [DataMember(Order = 48)]
        public DateTime CreateTime { get; set; }

        [DisplayName("创建人")]
        [DataMember(Order = 49)]
        public string CreateUserId { get; set; }

        [DisplayName("采购员意见")]
        [DataMember(Order = 50)]
        public string Description { get; set; }
    }
}
