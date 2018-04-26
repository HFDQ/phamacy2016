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
    /// 供货单位
    /// Version:2013.07.16.2143 未完成
    /// </summary>
    [Description("供货单位")]
    [DataContract(IsReference = true)]
    public class SupplyUnit : BaseUnit
    {
        #region Entiy Property

        /// <summary>
        /// 档案号
        /// </summary>
        [DataMember(Order = 20)]
        public string DocNumber { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
        [DataMember]
        public string PinyinCode { get; set; }
        
        #region 质量协议书
        /// <summary>
        ///  质量协议书细节
        /// </summary>
        [DataMember(Order = 4)]
        public string QualityAgreementDetail { get; set; }

        /// <summary>
        /// 质量协议书是否过期
        /// </summary>
        [DataMember(Order = 0)]
        public bool IsQualityAgreementOut
        {
            get
            {
                return DateTime.Now.Date > QualityAgreementOutdate;
            }
            set
            {
                value = DateTime.Now.Date > QualityAgreementOutdate;
            }
        }

        /// <summary>
        ///  质量协议书文件
        /// </summary>
        [DataMember(Order = 1)]
        public Guid QualityAgreementFile { get; set; }

        /// <summary>
        /// 质量协议书有效期起
        /// </summary>
        [DataMember(Order = 2)]
        public DateTime QualityAgreemenStartdate { get; set; }

        /// <summary>
        /// 质量协议书有效期止
        /// </summary>
        [DataMember(Order = 3)]
        public DateTime QualityAgreementOutdate { get; set; }
        #endregion

        #region 法人委托书

        /// <summary>
        /// 法人委托书是否过期
        /// </summary>
        [DataMember(Order = 3)]
        public bool IsAttorneyAattorneyOut
        {
            get
            {
                return DateTime.Now.Date > AttorneyAattorneyOutdate;
            }
            set
            {
                value = DateTime.Now.Date > AttorneyAattorneyOutdate;
            }
        }

        /// <summary>
        ///  法人委托书细节
        /// </summary>
        [DataMember(Order = 4)]
        public string AttorneyAattorneyDetail { get; set; }

        /// <summary>
        ///  法人委托书文件
        /// </summary>
        [DataMember(Order = 4)]
        public Guid AttorneyAattorneyFile { get; set; }

        /// <summary>
        /// 法人委托书有效期止
        /// </summary>
        [DataMember(Order = 5)]
        public DateTime AttorneyAattorneyOutdate { get; set; }

        /// <summary>
        /// 法人委托书有效期起
        /// </summary>
        [DataMember(Order = 6)]
        public DateTime AttorneyAattorneyStartdate { get; set; }
        #endregion

        /// <summary>
        /// 拟供品种
        /// </summary>
        [DataMember(Order = 7)]
        public string SupplyProductClass { get; set; }

        /// <summary>
        /// 质量负责人
        /// </summary>
        [DataMember(Order = 8)]
        public string QualityCharger { get; set; }

        /// <summary>
        /// 是否年审
        /// </summary>
        [DataMember(Order = 9)]
        public bool IsAnnualAudit { get; set; }

        /// <summary>
        /// 是否有印章样式文件
        /// </summary>
        [DataMember(Order = 10)]
        public bool IsSealFile { get; set; }

        /// <summary>
        /// 印章样式文件
        /// </summary>
        [DataMember(Order = 11)]
        public Guid SealFile { get; set; }

        /// <summary>
        /// 行单票样式文件
        /// </summary>
        [DataMember(Order = 12)]
        public Guid SingleTicketFile { get; set; }

        /// <summary>
        /// 是否有行单票样式文件
        /// </summary>
        [DataMember(Order = 13)]
        public bool IsSingleTicketFile { get; set; }

        /// <summary>
        /// 证明文件
        /// </summary>
        [DataMember(Order = 14)]
        public Guid ProofFile { get; set; }

        #region 银行账户
        /// <summary>
        /// 开户户名
        /// </summary>
        [DataMember(Order = 15)]
        public string BankAccountName { get; set; }

        /// <summary>
        /// 银行
        /// </summary>
        [DataMember(Order = 13)]
        public string Bank { get; set; }

        /// <summary>
        /// 银行帐号
        /// </summary>
        [DataMember(Order = 16)]
        public string BankAccount { get; set; }
        #endregion

        /// <summary>
        /// 有效
        /// </summary>
        [DataMember(Order = 17)]
        public override bool Valid
        {
            get
            {
                return !(!IsApproval || IsOutDate || IsLock
                    || IsQualityAgreementOut
                    || IsAttorneyAattorneyOut 
                    || IsGSPLicenseOutDate
                    || IsGMPLicenseOutDate
                    || IsBusinessLicenseOutDate
                    || IsMedicineProductionLicenseOutDate
                    || IsMedicineBusinessLicenseOutDate
                    || IsInstrumentsProductionLicenseOutDate
                    || IsInstrumentsBusinessLicenseOutDate
                    || IsFoodCirculateLicenseOutDate
                    || IsHealthLicenseOutDate
                    || IsOrganizationCodeLicenseOutDate
                    || IsLnstitutionLegalPersonLicenseOutDate
                    || IsTaxRegisterLicenseOutDate
                    || IsMmedicalInstitutionPermitOutDate
                    );
            }
            set
            {
                value = !(!IsApproval || IsOutDate || IsLock
                    || IsQualityAgreementOut
                    || IsAttorneyAattorneyOut
                    || IsGSPLicenseOutDate
                    || IsGMPLicenseOutDate
                    || IsBusinessLicenseOutDate
                    || IsMedicineProductionLicenseOutDate
                    || IsMedicineBusinessLicenseOutDate
                    || IsInstrumentsProductionLicenseOutDate
                    || IsInstrumentsBusinessLicenseOutDate
                    || IsFoodCirculateLicenseOutDate
                    || IsHealthLicenseOutDate
                    || IsOrganizationCodeLicenseOutDate
                    || IsLnstitutionLegalPersonLicenseOutDate
                    || IsTaxRegisterLicenseOutDate
                    || IsMmedicalInstitutionPermitOutDate
                    );
                if (value)
                {
                    ValidRemark = "[正常]";
                }
                else
                {
                    ValidRemark = "**************";
                    if (!IsApproval)
                    {
                        ValidRemark += "[审核未通过]";
                    }
                    if (IsOutDate)
                    {
                        ValidRemark += "[过期]";
                    }
                    if (IsQualityAgreementOut)
                    {
                        ValidRemark += "[质量协议书过期]";
                    }
                    if (IsAttorneyAattorneyOut)
                    {
                        ValidRemark += "[法人委托书过期]";
                    }
                    if (IsLock)
                    {
                        ValidRemark += "[" + LockRemark + "]";
                    }
                }
            }
        }



        #endregion

        #region Navigation Property  


        /// <summary>
        /// 供货单位销售人员
        /// </summary>
        [DataMember(Order = 18)]
        public virtual ICollection<SupplyUnitSalesman> SupplyUnitSalesmans { get; set; }

        [DataMember(Order = 19)]
        public virtual ICollection<PurchaseAgreement> PurchaseAgreements { get; set; }

        //[DataMember]
        //public Guid GMSPLicenseId { get; set; }

        //[DataMember]
        //public virtual GMSPLicense GMSPLicense { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }

        #endregion

    }
}

