using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// Version:2013.07.16.2143 未完成
    /// </summary>
    [Description("药品信息")]
    [DataContract(IsReference = true)]
    public class DrugInfo : Entity, ILEntity, IValidation, IEnable
    {
        #region 基本信息

        /// <summary>
        /// 许可证号
        /// </summary>
        [DataMember]
        public string PermitLicenseCode { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// 档案号
        /// </summary>
        [DataMember]
        public string DocCode { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
        [DataMember(Order = 2)]
        public string Pinyin { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// 条形码
        /// </summary> 
        [DataMember]
        public string BarCode { get; set; }

        /// <summary>
        /// 药品本位码
        /// </summary>
        [DataMember]
        public string StandardCode { get; set; }

        /// <summary>
        /// 药品名称
        /// 产品名称
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// 产品英文名称
        /// </summary>
        [DataMember]
        public string ProductEnglishName { get; set; }

        /// <summary>
        /// 药品通用名
        /// </summary>
        [Required]
        [DataMember]
        public string ProductGeneralName { get; set; }


        //药品其他名称
        [DataMember]
        public string ProductOtherName { get; set; }

        /// <summary>
        /// 厂家全称
        /// 生产企业中文名称
        /// </summary>
        [DataMember]
        public string FactoryName { get; set; }

        /// <summary>
        /// 厂家简称
        /// </summary>
        [DataMember]
        public string FactoryNameAbbreviation { get; set; }

        /// <summary>
        /// 拆零规格
        /// </summary>
        [DataMember]
        public string PiecemealSpecification { get; set; }


        /// <summary>
        /// 拆零数量      
        /// </summary>
        [DataMember]
        public int PiecemealNumber { get; set; }


        /// <summary>
        /// 价格
        /// </summary>
        [DataMember]
        public decimal Price { get; set; }

        /// <summary>
        /// 国家零售价，指导售价
        /// </summary>
        [DataMember]
        public decimal NationalSalePrice { get; set; }

        /// <summary>
        /// 采购价
        /// </summary>
        [DataMember]
        public decimal PurchasePrice { get; set; }

        /// <summary>
        /// 销售价  
        /// </summary>
        [DataMember]
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 批发价
        /// </summary>
        [DataMember]
        public decimal WholeSalePrice { get; set; }

        /// <summary>
        /// 零售价
        /// </summary>
        [DataMember]
        public decimal RetailPrice { get; set; }

        /// <summary>
        /// 挂价
        /// </summary>
        [DataMember]
        public decimal TagPrice { get; set; }

        /// <summary>
        /// 最低售价
        /// </summary>
        [DataMember]
        public decimal LowSalePrice { get; set; }

        /// <summary>
        /// 最低限价
        /// </summary>
        [DataMember]
        public decimal LimitedLowPrice { get; set; }

        /// <summary>
        /// 最高限价
        /// </summary>
        [DataMember]
        public decimal LimitedUpPrice { get; set; }


        /// <summary>
        /// 是否医保
        /// </summary>
        [DataMember]
        public bool IsMedicalInsurance { get; set; }

        /// <summary>
        /// 是否处方药
        /// </summary>
        [DataMember]
        public bool IsPrescription { get; set; }

        /// <summary>
        /// 是否进口药
        /// </summary>
        [DataMember]
        public bool IsImport { get; set; }

        /// <summary>
        /// 是否重点养护
        /// </summary>
        [DataMember]
        public bool IsMainMaintenance { get; set; }

        /// <summary>
        /// 是否特殊管理药品
        /// </summary>
        [DataMember]
        public bool IsSpecialDrugCategory { get; set; }

        /// <summary>
        /// 特殊管理药品类型
        /// </summary>
        [DataMember]
        public string SpecialDrugCategoryCode { get; set; }

        /// <summary>
        /// 有效期，**月
        /// 保质期
        /// </summary>
        [DataMember]
        public int ValidPeriod { get; set; }

        /// <summary>
        /// 批准文号
        /// </summary>
        [DataMember]
        public string LicensePermissionNumber { get; set; }

        /// <summary>
        /// 执行标准
        /// </summary>
        [DataMember]
        public string PerformanceStandards { get; set; }

        /// <summary>
        /// 包装
        /// </summary>
        [DataMember]
        public string Package { get; set; }

        /// <summary>
        /// 包装数量
        /// </summary>
        [DataMember]
        public int PackageAmount { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        [DataMember]
        public Guid WareHouses { get; set; }

        /// <summary>
        /// 库区
        /// </summary>
        [DataMember]
        public string WareHouseZones { get; set; }

        /// <summary>
        /// 大包
        /// </summary>
        [DataMember]
        public decimal BigPackage { get; set; }

        /// <summary>
        /// 中包
        /// </summary>
        [DataMember]
        public decimal MiddlePackage { get; set; }

        /// <summary>
        /// 小包
        /// </summary>
        [DataMember]
        public int SmallPackage { get; set; }

        #region 关于可经营状态
        /// <summary>
        /// 审批状态
        /// </summary>
        [DataMember]
        public bool IsApproval
        {
            get
            {
                return this.ApprovalStatus.Equals(ApprovalStatus.Approvaled);
            }
            set
            {

            }
        }

        /// <summary>
        /// 可以经营
        /// </summary>
        [DataMember]
        public bool Valid
        {
            get
            {
                return IsApproval && !IsLock && Enabled && DateTime.Now < PermitOutDate.Date;
            }
            set
            {
                value = IsApproval && !IsLock && Enabled && DateTime.Now < PermitOutDate.Date;
                if (value)
                {
                    ValidRemark = "[正常]";
                }
                else
                {
                    ValidRemark = "";
                    if (!IsApproval)
                    {
                        ValidRemark = ValidRemark + "[审核未通过]";
                    }
                    if (IsLock)
                    {
                        ValidRemark = ValidRemark + "[" + LockRemark + "]";
                    }
                }
            }
        }

        /// <summary>
        /// valid说明
        /// </summary>
        [DataMember]
        public string ValidRemark { get; set; }


        private bool _IsLock;
        /// <summary>
        /// 是否锁定
        /// </summary>
        [DataMember]
        public bool IsLock { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        [DataMember]
        public bool Enabled { get; set; }

        /// <summary>
        /// Lock说明
        /// </summary>
        [DataMember]
        public string LockRemark { get; set; }

        /// <summary>
        /// 许可证开始时间
        /// </summary>
        [DataMember]
        public DateTime PermitDate { get; set; }

        /// <summary>
        /// 许可证结束时间
        /// </summary>
        [DataMember]
        public DateTime PermitOutDate { get; set; }

        /// <summary>
        /// 审批日期
        /// </summary>
        [DataMember]
        public DateTime ApprovalDate { get; set; }

        #endregion

        /// <summary>
        /// 最大库存报警
        /// </summary>
        [DataMember]
        public int MaxInventoryCount { get; set; }


        /// <summary>
        /// 最小库存报警
        /// </summary>        
        [DataMember]
        public int MinInventoryCount { get; set; }

        /// <summary>
        /// 产地
        /// </summary>        
        [DataMember]
        public string Origin { get; set; }

        #endregion

        #region Entiy Property

        #region ILEntity
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [Required]
        [DataMember]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataMember]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 更新人编号
        /// </summary>
        [DataMember]
        public Guid UpdateUserId { get; set; }

        #endregion

        #region IValidation



        #endregion

        #region IEnable

        #endregion

        #endregion

        #region Navigation Property

        /// <summary>
        /// 经营范围
        /// </summary>
        [Required]

        [DataMember]
        public string BusinessScopeCode { get; set; }

        /// <summary>
        /// 药品管理分类详细(与经营范围相关)
        /// </summary>
        [Required]

        [DataMember]
        public string PurchaseManageCategoryDetailCode { get; set; }

        /// <summary>
        /// 药品分类 
        /// </summary>
        [Required]

        [DataMember]
        public string DrugCategoryCode { get; set; }

        /// <summary>
        /// 医疗详细分类
        /// </summary>
        [Required]

        [DataMember]
        public string MedicalCategoryDetailCode { get; set; }

        /// <summary>
        /// 临床分类
        /// </summary>
        [Required]

        [DataMember]
        public string DrugClinicalCategoryCode { get; set; }

        /// <summary>
        /// 自定义类型 
        /// </summary>
        [Required]

        [DataMember]
        public string DictionaryUserDefinedTypeCode { get; set; }

        /// <summary>
        /// 存储方式
        /// </summary>
        [Required]

        [DataMember]
        public string DrugStorageTypeCode { get; set; }

        /// <summary>
        /// 药品单位
        /// </summary>
        [Required]

        [DataMember]
        public string DictionaryMeasurementUnitCode { get; set; }

        /// <summary>
        /// 剂型
        /// </summary>

        [DataMember]
        public string DictionaryDosageCode { get; set; }

        /// <summary>
        /// 规格
        /// 产品规格
        /// </summary>
        [Required]

        [DataMember]
        public string DictionarySpecificationCode { get; set; }

        /// <summary>
        /// 拆零单位  
        /// </summary>

        [DataMember]
        public string DictionaryPiecemealUnitCode { get; set; }

        #endregion

        /// <summary>
        /// 入库记录
        /// </summary>
        [DataMember]
        public virtual ICollection<DrugInventoryRecord> DrugInventoryRecords { get; set; }


        /// <summary>
        /// 审批流程FlowID
        /// </summary>
        [DataMember]
        public Guid FlowID { get; set; }

        /// <summary>
        /// 商品类型值
        /// </summary>
        [DataMember]
        public int GoodsTypeValue { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        public GoodsType GoodsType
        {
            get
            {
                return (GoodsType)GoodsTypeValue;
            }
            set
            {
                GoodsTypeValue = (int)value;
            }
        }

        [DataMember]
        public int ApprovalStatusValue { get; set; }

        public ApprovalStatus ApprovalStatus
        {
            get { return (ApprovalStatus)ApprovalStatusValue; }
            set
            {
                ApprovalStatusValue = (int)value;
                IsApproval = false;
            }
        }

        [DataMember]
        [NotMapped]
        public virtual GoodsAdditionalProperty GoodsAdditionalProperty
        {
            get;
            set;
        }

        #region 保健食品
        /// <summary>
        /// 保健功能
        /// </summary>
        [DataMember]
        public string Function { get; set; }

        /// <summary>
        /// 成分
        /// </summary>
        [DataMember]
        public string Ingredient { get; set; }

        /// <summary>
        /// 适用人群
        /// </summary>
        [DataMember]
        public string CommendedUser { get; set; }
        #endregion

        /// <summary>
        /// 生产企业的生产企业许可证编号（或备案凭证号）
        /// </summary>
        [DataMember]
        public string InstEntProductLiscencePermitNumber { get; set; }
    }
}

