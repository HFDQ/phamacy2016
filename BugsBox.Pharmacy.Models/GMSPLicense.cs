using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    ///// <summary>
    ///// GMSP证书
    ///// 会保存证书上文字信息
    ///// </summary>
    //[DataContract(IsReference = true)]
    //public class GMSPLicense : Entity,IStore
    //{
    //    #region Entiy Property

    //    /// <summary>
    //    /// 证书名称
    //    /// 由于各省证书名称不一样
    //    /// 故保留证书名称
    //    /// </summary>
    //    [Required]
    //    [DataMember]
    //    [MaxLength(64)]
    //    public string Name { get; set; }

    //    /// <summary>
    //    /// 企业名称
    //    /// </summary>
    //    [Required]
    //    [DataMember]
    //    [MaxLength(64)]
    //    public string UnitName { get; set; }


    //    /// <summary>
    //    /// 注册地址
    //    /// </summary>
    //    [Required]
    //    [DataMember]
    //    [MaxLength(200)]
    //    public string RegAddress { get; set; }

    //    /// <summary>
    //    /// 法人
    //    /// </summary>
    //    [DataMember]
    //    [MaxLength(16)]
    //    public string LegalPerson { get; set; }

    //    /// <summary>
    //    /// 企业负责人
    //    /// </summary>
    //    [DataMember]
    //    [MaxLength(16)]
    //    public string Header { get; set; }

    //    /// <summary>
    //    /// 质量负责人
    //    /// </summary>
    //    [DataMember] 
    //    [MaxLength(16)]
    //    public string QualityHeader { get; set; }

    //    /// <summary>
    //    /// 仓库地址
    //    /// </summary>
    //    [DataMember] 
    //    [MaxLength(200)]
    //    public string WarehouseAddress { get; set; }

    //    /// <summary>
    //    /// 证书号
    //    /// </summary>
    //    [DataMember]
    //    [Required]
    //    [MaxLength(16)]
    //    public string LicenseCode { get; set; }

    //    /// <summary>
    //    /// 过期日期
    //    /// </summary>
    //    [DataMember]
    //    public DateTime OutDate { get; set; }

    //    /// <summary>
    //    /// 签发日期
    //    /// </summary>
    //    [DataMember]
    //    public DateTime IssuanceDate  { get; set; }

    //    /// <summary>
    //    /// 签发机构
    //    /// </summary>
    //    [DataMember]
    //    [MaxLength(200)]
    //    [Required]
    //    public string IssuanceOrg { get; set; }

    //    /// <summary>
    //    /// 认证范围
    //    /// </summary>
    //    [DataMember]
    //    [MaxLength(200)] 
    //    public string CertificationScope { get; set; }

    //    #endregion

    //    #region Navigation Property

    //    /// <summary>
    //    /// 上传的GSP图片编号
    //    /// </summary>
    //    [DataMember]
    //    public Guid GSPPharmacyFileId { get; set; }

    //    /// <summary>
    //    /// 上传的GMP图片编号
    //    /// </summary>
    //    [DataMember]
    //    public Guid GMPPharmacyFileId { get; set; }

    //    [DataMember]
    //    public Guid PurchaseUnitId { get; set; }

    //    //[DataMember]
    //    //public virtual PurchaseUnit PurchaseUnit { get; set; }

    //    [DataMember]
    //    public Guid SupplyUnitId { get; set; }

    //    //[DataMember]
    //    //public virtual SupplyUnit SupplyUnit { get; set; }

    //    [DataMember]
    //    public virtual ICollection<GMSPLicenseBusinessScope> GMSPLicenseBusinessScopes { get; set; }

    //    [DataMember]
    //    public Guid BusinessTypeId { get; set; }

    //    [DataMember]
    //    public virtual BusinessType BusinessType { get; set; }

    //    /// <summary>
    //    /// 门店编号
    //    /// </summary>
    //    [DataMember]
    //    public Guid StoreId { get; set; }


    //    #endregion
    //}
}
