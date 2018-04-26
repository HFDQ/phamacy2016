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
    /// 证照
    /// </summary>
    [Description("证照基类")]
    [DataContract(IsReference = true)]
    public class PharmacyLicense : Entity, IDictionaryType, IStore
    {
        #region Entiy Property

        /// <summary>
        /// 证书名称
        /// </summary>
        [Required]
        [DataMember(Order = 0)]
        [DisplayName(ResourceStrings.Name)]
        public string Name { get; set; }

        /// <summary>
        /// 证书描述
        /// </summary>
        [DataMember(Order = 1)]
        [DisplayName(ResourceStrings.Decription)]
        public string Decription { get; set; }

        /// <summary>
        /// 编号/注册号 非证书号
        /// </summary> 
        [DataMember(Order = 2)]
        [DisplayName(ResourceStrings.Code)]
        public string Code { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [DataMember(Order = 3)]
        [DisplayName(ResourceStrings.Enabled)]
        public bool Enabled { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        [Required]
        [DataMember]
        public string UnitName { get; set; }

        /// <summary>
        /// 注册地址
        /// </summary>
        [Required]
        [DataMember]
        public string RegAddress { get; set; }

        /// <summary>
        /// 证书号
        /// </summary>
        [DataMember]
        [Required]
        public string LicenseCode { get; set; }

        /// <summary>
        /// 生效时间开始
        /// 许可期限
        /// </summary>
        [DataMember]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 过期日期
        /// 许可期限
        /// </summary>
        [DataMember]
        public DateTime OutDate { get; set; }

        /// <summary>
        /// 签发日期
        /// </summary>
        [DataMember]
        public DateTime IssuanceDate { get; set; }

        /// <summary>
        /// 签发机构
        /// </summary>
        [DataMember]
        [Required]
        public string IssuanceOrg { get; set; }

        /// <summary>
        /// 档案号
        /// </summary>
        [DataMember]
        public string DocNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string memo { get; set; }


        /// <summary>
        /// 是否有效
        /// </summary>
        [DataMember]
        public bool Valid { get; set; }

        /// <summary>
        /// 证书类型值
        /// </summary>
        [DataMember]
        public int LicenseTypeValue { get; set; }

        /// <summary>
        /// 证书类型
        /// </summary> 
        public LicenseType LicenseType
        {
            get
            {
                return (LicenseType)LicenseTypeValue;
            }
            set
            {
                LicenseTypeValue = (int)value;
            }
        }

        #endregion

        #region Navigation Property
        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 文件编号
        /// </summary>
        [DataMember]
        public Guid PharmacyFileId { get; set; }

        #endregion


    }

    /// <summary>
    /// GSP是《药品经营质量管理规范》
    /// 由于经营类企业
    /// </summary>
    //[Description("GSP证书")]
    [Description("药品经营许可证")]
    public class GSPLicense : PharmacyLicense
    {

        public GSPLicense()
        {
            var descriptionAttribute = this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() as DescriptionAttribute;
            if (descriptionAttribute != null)
            {
                this.Name = descriptionAttribute.Description;
            }
            this.LicenseType = Models.LicenseType.GSP;
        }

        #region Entiy Property

        /// <summary>
        /// 法定代表人
        /// </summary>
        [Required]
        [DataMember]
        
        public string LegalPerson { get; set; }

        /// <summary>
        /// 企业负责人
        /// </summary>
        [Required]
        [DataMember]
        
        public string Header { get; set; }

        /// <summary>
        /// 质量负责人
        /// </summary>
        [Required]
        [DataMember]
        
        public string QualityHeader { get; set; }

        /// <summary>
        /// 仓库地址
        /// </summary>
        [Required]
        [DataMember]
        public string WarehouseAddress { get; set; }

        //WFZ
        /// <summary>
        /// 变更记录
        /// </summary>
        //[Required]
        [DataMember]
        public string ChangeRecord { get; set; }

        #endregion

        #region Navigation Property

        [DataMember]
        public virtual ICollection<GMSPLicenseBusinessScope> GMSPLicenseBusinessScopes { get; set; }

        [DataMember]
        public Guid BusinessTypeId { get; set; }

        [DataMember]
        public virtual BusinessType BusinessType { get; set; }

        #endregion
    }
    [Description("GMP证书")]
    public class GMPLicense : PharmacyLicense
    {
        public GMPLicense()
        {
            var descriptionAttribute = this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false)
              .FirstOrDefault() as DescriptionAttribute;
            if (descriptionAttribute != null)
            {
                this.Name = descriptionAttribute.Description;
            }
            this.LicenseType = Models.LicenseType.GMP;
        }

        #region Entiy Property

        /// <summary>
        /// 认证范围
        /// </summary>
        [Required]
        [DataMember]
        public string CertificationScope { get; set; }

        #endregion

        #region Navigation Property

        #endregion
    }
    /// <summary>
    /// 营业执照
    /// </summary>
    [Description("营业执照")]
    public class BusinessLicense : PharmacyLicense
    {
        public BusinessLicense()
        {
            var descriptionAttribute = this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false)
              .FirstOrDefault() as DescriptionAttribute;
            if (descriptionAttribute != null)
            {
                this.Name = descriptionAttribute.Description;
            }
            this.LicenseType = Models.LicenseType.BusinessLicense;
        }

        /// <summary>
        /// 注册资本
        /// </summary>
        [DataMember]
        public int RegisteredCapital { get; set; }

        /// <summary>
        /// 实收资本
        /// </summary>
        [DataMember]
        public int PaidinCapital { get; set; }

        /// <summary>
        /// 公司类型
        /// 如有限公司
        /// </summary>
        [DataMember]
        public string CorporateNature { get; set; }

        /// <summary>
        /// 经营范围
        /// </summary>
        [DataMember]
        public string BusinessScope { get; set; }

        /// <summary>
        /// 成立日期
        /// </summary>
        [DataMember]
        public DateTime EstablishmentDate { get; set; }

        /// <summary>
        /// 年检情况
        /// 每年12月5日-12月12日
        /// </summary>
        [DataMember]
        public string InspectionDate { get; set; }

        [DataMember]
        public string DocNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string memo { get; set; }
    }
    /// <summary>
    /// 药品生产许可证
    /// </summary>
    [Description("药品生产许可证")]
    public class MedicineProductionLicense : PharmacyLicense
    {
        public MedicineProductionLicense()
        {
            var descriptionAttribute = this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false)
           .FirstOrDefault() as DescriptionAttribute;
            if (descriptionAttribute != null)
            {
                this.Name = descriptionAttribute.Description;
            }
            this.LicenseType = Models.LicenseType.MedicineProductionLicense;
        }

        #region Entiy Property

        /// <summary>
        /// 法定代表人
        /// </summary>
        [DataMember]
        public string LegalPerson { get; set; }

        /// <summary>
        /// 企业负责人
        /// </summary>
        [DataMember]
        public string Header { get; set; }


        /// <summary>
        /// 生产地址
        /// </summary>
        [DataMember]
        public string ProductAddress { get; set; }

        /// <summary>
        /// 企业类型
        /// 如有限公司
        /// </summary>
        [DataMember]
        public string CorporateNature { get; set; }

        /// <summary>
        ///分类码
        /// </summary> 
        [DataMember]
        public string CategoryCode { get; set; }

        /// <summary>
        /// 生产范围
        /// </summary>
        [DataMember]
        public string ProductScope { get; set; }

        [DataMember]
        public string DocNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string memo { get; set; }

        #endregion

        #region Navigation Property

        #endregion
    }
    /// <summary>
    /// 药品经营许可证许可证
    /// </summary>
    //[Description("药品经营许可证")]
    [Description("GSP证书")]
    public class MedicineBusinessLicense : PharmacyLicense
    {
        public MedicineBusinessLicense()
        {
            var descriptionAttribute = this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false)
         .FirstOrDefault() as DescriptionAttribute;
            if (descriptionAttribute != null)
            {
                this.Name = descriptionAttribute.Description;
            }
            this.LicenseType = Models.LicenseType.MedicineBusinessLicense;
        }


        #region Entiy Property

        /// <summary>
        /// 法定代表人
        /// </summary>
        [Required]
        [DataMember]
        public string LegalPerson { get; set; }

        /// <summary>
        /// 企业负责人
        /// </summary>
        [DataMember]
        public string Header { get; set; }

        /// <summary>
        /// 质量负责人
        /// </summary>
        [DataMember]
        public string QualityHeader { get; set; }

        /// <summary>
        /// 仓库地址
        /// </summary>
        [DataMember]
        public string WarehouseAddress { get; set; }

        /// <summary>
        /// 经营范围
        /// </summary>
        [DataMember]
        public string BusinessScope { get; set; }

        //WFZ
        /// <summary>
        /// 证书内容
        /// </summary>
        [DataMember]
        public string LicenseContain { get; set; }

        [DataMember]
        public string DocNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string memo { get; set; }

        #endregion

    }
    /// <summary>
    /// 器械经营许可证
    /// </summary>
    [Description("器械经营许可证")]
    public class InstrumentsBusinessLicense : PharmacyLicense
    {
        public InstrumentsBusinessLicense()
        {
            var descriptionAttribute = this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false)
            .FirstOrDefault() as DescriptionAttribute;
            if (descriptionAttribute != null)
            {
                this.Name = descriptionAttribute.Description;
            }
            this.LicenseType = Models.LicenseType.InstrumentsBusinessLicense;
        }

        #region Entiy Property

        /// <summary>
        /// 法定代表人
        /// </summary>
        [DataMember]
        public string LegalPerson { get; set; }

        /// <summary>
        /// 企业负责人
        /// </summary>
        [DataMember]
        public string Header { get; set; }

        /// <summary>
        /// 质量负责人
        /// </summary>
        [DataMember]
        public string QualityHeader { get; set; }

        /// <summary>
        /// 仓库地址
        /// </summary>
        [DataMember]
        public string WarehouseAddress { get; set; }

        /// <summary>
        /// 经营范围
        /// </summary>
        [DataMember]
        public string BusinessScope { get; set; }

        [DataMember]
        public string DocNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string memo { get; set; }

        #endregion


    }
    /// <summary>
    /// 器械生产许可证
    /// </summary>
    [Description("器械生产许可证")]
    public class InstrumentsProductionLicense : PharmacyLicense
    {
        public InstrumentsProductionLicense()
        {
            var descriptionAttribute = this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false)
           .FirstOrDefault() as DescriptionAttribute;
            if (descriptionAttribute != null)
            {
                this.Name = descriptionAttribute.Description;
            }
            this.LicenseType = Models.LicenseType.InstrumentsProductionLicense;
        }


        #region Entiy Property

        /// <summary>
        /// 法定代表人
        /// </summary>
        [DataMember]
        public string LegalPerson { get; set; }

        /// <summary>
        /// 企业负责人
        /// </summary>
        [DataMember]
        public string Header { get; set; }

        /// <summary>
        /// 生产地址
        /// </summary>
        [DataMember]
        public string ProductAddress { get; set; }

        /// <summary>
        /// 生产范围
        /// </summary>
        [DataMember]
        public string ProductScope { get; set; }

        [DataMember]
        public string DocNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string memo { get; set; }

        #endregion
    }

    //WFZ
    /// <summary>
    /// 组织机构代码证
    /// </summary>
    [Description("组织机构代码证")]
    public class OrganizationCodeLicense : PharmacyLicense
    {
        public OrganizationCodeLicense()
        {
            var descriptionAttribute = this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false)
           .FirstOrDefault() as DescriptionAttribute;
            if (descriptionAttribute != null)
            {
                this.Name = descriptionAttribute.Description;
            }
            this.LicenseType = Models.LicenseType.OrganizationCodeLicense;
        }


        #region Entiy Property
        /// <summary>
        /// 机构类型
        /// </summary>
        [DataMember]
        public string OrgnizationType { get; set; }

        /// <summary>
        /// 证书号
        /// </summary>
        [DataMember]
        public string LicenseNo { get; set; }

        /// <summary>
        /// 登记号
        /// </summary>
        [DataMember]
        public string RegisterNo { get; set; }

        /// <summary>
        /// 签发日期
        /// </summary>
        [DataMember]
        public DateTime IssuanceDate { get; set; }

        /// <summary>
        /// 颁发机构
        /// </summary>
        [DataMember]
        public string IssuanceOrg { get; set; }

        /// <summary>
        /// 是否年检
        /// </summary>
        [DataMember]
        public bool isCheck { get; set; }

        /// <summary>
        /// 年检时间
        /// </summary>
        [DataMember]
        public DateTime YearCheckDate { get; set; }

        [DataMember]
        public string DocNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string memo { get; set; }

        #endregion

    }

    /// <summary>
    /// 食品流通许可证
    /// </summary>
    [Description("食品流通许可证")]
    public class FoodCirculateLicense : PharmacyLicense
    {
        public FoodCirculateLicense()
        {
            var descriptionAttribute = this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false)
           .FirstOrDefault() as DescriptionAttribute;
            if (descriptionAttribute != null)
            {
                this.Name = descriptionAttribute.Description;
            }
            this.LicenseType = Models.LicenseType.FoodCirculateLicense;
        }


        #region Entiy Property

        /// <summary>
        /// 主体类型
        /// </summary>
        [DataMember]
        public string OrgType { get; set; }

        /// <summary>
        /// 经营场所
        /// </summary>
        [DataMember]
        public string RegAddress { get; set; }

        /// <summary>
        /// 许可证编号
        /// </summary>
        [DataMember]
        public string LicenseNo { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        [DataMember]
        public string Header { get; set; }

        /// <summary>
        /// 许可范围
        /// </summary>
        [DataMember]
        public DateTime LicenseRange { get; set; }

        /// <summary>
        /// 发证机关
        /// </summary>
        [DataMember]
        public string IssuanceOrg { get; set; }

        [DataMember]
        public string DocNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string memo { get; set; }

        #endregion
    }

        /// <summary>
    /// 卫生许可证
    /// </summary>
    [Description("卫生许可证")]
    public class HealthLicense : PharmacyLicense
    {
        public HealthLicense()
        {
            var descriptionAttribute = this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false)
           .FirstOrDefault() as DescriptionAttribute;
            if (descriptionAttribute != null)
            {
                this.Name = descriptionAttribute.Description;
            }
            this.LicenseType = Models.LicenseType.HealthLicense;
        }
        #region Entiy Property

        /// <summary>
        /// 许可类别
        /// </summary>
        [DataMember]
        public string HealthLicenseType { get; set; }

        /// <summary>
        /// 法定代表人
        /// </summary>
        [DataMember]
        public string Header { get; set; }

        /// <summary>
        /// 签发日期
        /// </summary>
        [DataMember]
        public DateTime IssuanceDate { get; set; }

        /// <summary>
        /// 发证机关
        /// </summary>
        [DataMember]
        public string IssuanceOrg { get; set; }

        /// <summary>
        /// 许可项目
        /// </summary>
        [DataMember]
        public string LicenseContent { get; set; }

        /// <summary>
        /// 档案号
        /// </summary>
        [DataMember]
        public string DocNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string memo { get; set; }

        #endregion


    }

    /// <summary>
    /// 税务登记证
    /// </summary>
    [Description("税务登记证")]
    public class TaxRegisterLicense : PharmacyLicense
    {
        public TaxRegisterLicense()
        {
            var descriptionAttribute = this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false)
           .FirstOrDefault() as DescriptionAttribute;
            if (descriptionAttribute != null)
            {
                this.Name = descriptionAttribute.Description;
            }
            this.LicenseType = Models.LicenseType.TaxRegisterLicense;
        }
        #region Entiy Property

        /// <summary>
        /// 许可类别
        /// </summary>
        [DataMember]
        public string TaxRegisterLicenseType { get; set; }

        /// <summary>
        /// 纳税人名称
        /// </summary>
        [DataMember]
        public string taxpayerName { get; set; }

        /// <summary>
        /// 纳税人识别号
        /// </summary>
        [DataMember]
        public string taxpayerNumber { get; set; }

        /// <summary>
        /// 法定代表人
        /// </summary>
        [DataMember]
        public string LegalPerson { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// 签发日期
        /// </summary>
        [DataMember]
        public DateTime IssuanceDate { get; set; }

        /// <summary>
        /// 发证机关
        /// </summary>
        [DataMember]
        [Required]
        public string IssuanceOrg { get; set; }

        /// <summary>
        /// 经营范围
        /// </summary>
        [DataMember]
        public string BusinessScope { get; set; }

        /// <summary>
        /// 档案号
        /// </summary>
        [DataMember]
        public string DocNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string memo { get; set; }


        #endregion


    }

    /// <summary>
    /// 事业单位法人证
    /// </summary>
    [Description("事业单位法人证")]
    public class LnstitutionLegalPersonLicense : PharmacyLicense
    {
        public LnstitutionLegalPersonLicense()
        {
            var descriptionAttribute = this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false)
           .FirstOrDefault() as DescriptionAttribute;
            if (descriptionAttribute != null)
            {
                this.Name = descriptionAttribute.Description;
            }
            this.LicenseType = Models.LicenseType.LnstitutionLegalPersonLicense;
        }
        #region Entiy Property

        /// <summary>
        /// 单位名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 举办单位
        /// </summary>
        [DataMember]
        public string CertificateName { get; set; }

        /// <summary>
        /// 宗旨和业务范围
        /// </summary>
        [DataMember]
        public string BussinessRange { get; set; }

        /// <summary>
        /// 法定代表人
        /// </summary>
        [DataMember]
        public string LegalPerson { get; set; }

        /// <summary>
        /// 经费来源
        /// </summary>
        [DataMember]
        public string FundsSource { get; set; }

        /// <summary>
        /// 开办资金
        /// </summary>
        [DataMember]
        public string InitiaFund { get; set; }

        /// <summary>
        /// 住址
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// 签发日期
        /// </summary>
        [DataMember]
        public DateTime IssuanceDate { get; set; }

        /// <summary>
        /// 发证机关
        /// </summary>
        [DataMember]
        public string IssuanceOrg { get; set; }

        /// <summary>
        /// 登记管理机关
        /// </summary>
        [DataMember]
        public string ManageOrg { get; set; }

        /// <summary>
        /// 用药范围
        /// </summary>
        [DataMember]
        public string UseMedicalScope { get; set; }

        /// <summary>
        /// 有效期至
        /// </summary>
        [DataMember]
        public DateTime OutDate { get; set; }
        #endregion

        [DataMember]
        public string DocNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string memo { get; set; }
    }

        /// <summary>
        /// 医疗机构执业许可证
        /// </summary>
    [Description("医疗机构执业许可证")]
    public class MmedicalInstitutionPermit : PharmacyLicense
    {
        public MmedicalInstitutionPermit()
        {
            var descriptionAttribute = this.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false)
           .FirstOrDefault() as DescriptionAttribute;
            if (descriptionAttribute != null)
            {
                this.Name = descriptionAttribute.Description;
            }
            this.LicenseType = Models.LicenseType.MmedicalInstitutionPermit;
        }
        #region Entiy Property

        /// <summary>
        /// 单位名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 证书号
        /// </summary>
        [DataMember]
        public string CertificateName { get; set; }

        /// <summary>
        /// 机构性质
        /// </summary>
        [DataMember]
        public string OgnTpye { get; set; }

        /// <summary>
        /// 法定代表人
        /// </summary>
        [DataMember]
        public string LegalPerson { get; set; }

        /// <summary>
        /// 注册地址
        /// </summary>
        [DataMember]
        public string RegisterAddress { get; set; }

        /// <summary>
        /// 仓库地址
        /// </summary>
        [DataMember]
        public string WarehouseAddress { get; set; }

        /// <summary>
        /// 签发日期
        /// </summary>
        [DataMember]
        public DateTime IssuanceDate { get; set; }

        /// <summary>
        /// 发证机关
        /// </summary>
        [DataMember]
        public string IssuanceOrg { get; set; }

        /// <summary>
        /// 用药范围
        /// </summary>
        [DataMember]
        public string UseMedicalScope { get; set; }

        /// <summary>
        /// 有效期至
        /// </summary>
        [DataMember]
        public DateTime OutDate { get; set; }

        [DataMember]
        public string DocNumber { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string memo { get; set; }
        #endregion
    }

    /// <summary>
    /// 全国工业产品生产许可证
    /// </summary>
    [Description("全国工业产品生产许可证")]
    [DataContract(IsReference = true)]
    public class IndustoryProductCertificate : PharmacyLicense
    {
        /// <summary>
        /// 生产地址
        /// </summary>
        [DataMember]
        public string ProductAddress { get; set; }

        /// <summary>
        /// 检验方式
        /// </summary>        
        [DataMember]
        public string CheckMethod { get; set; }
    }
}
