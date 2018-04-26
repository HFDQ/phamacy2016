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
    /// 购货单位
    /// Version:2013.07.16.2143 完成
    /// </summary>
    [Description("购货单位")]
    [DataContract(IsReference = true)]
    public class PurchaseUnit : BaseUnit
    {
        #region Entiy Property

        /// <summary>
        /// 档案号
        /// </summary>
        [DataMember(Order = 5)]
        public string DocNumber { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
        [DataMember]
        public string PinyinCode { get; set; }

        /// <summary>
        ///  质量协议书细节
        /// </summary>
        [DataMember(Order = 4)]
        public string QualityAgreementDetail { get; set; }
        
         //edit by wfz
        #region 质量协议书
        /// <summary>
        /// 质量协议书是否过期
        /// </summary>
        [DataMember(Order = 6)]
        public bool IsQualityAgreementOut
        {
            get
            {
                return false;
            }
            set
            {
                value = false;
            }
        }

        /// <summary>
        ///  质量协议书文件
        /// </summary>
        [DataMember(Order = 7)]
        public Guid QualityAgreementFile
        {
            get { return Guid.Empty; }
            set { value = Guid.Empty; }
        }

        /// <summary>
        /// 质量协议书有效期起
        /// </summary>
        [DataMember(Order = 8)]
        public DateTime QualityAgreemenStartdate { get; set; }

        /// <summary>
        /// 质量协议书有效期止
        /// </summary>
        [DataMember(Order = 9)]
        public DateTime QualityAgreementOutdate { get; set; }
        #endregion

        /// <summary>
        /// 质量负责人
        /// </summary>
        [DataMember(Order = 10)]
        public string QualityCharger { get; set; }

        /// <summary>
        ///  采购委托书细节
        /// </summary>
        [DataMember(Order = 4)]
        public string AttorneyAattorneyDetail { get; set; }

        /// <summary>
        /// 采购委托书文件
        /// </summary>
        [DataMember(Order = 11)]
        public Guid PurchaseDelegaterFile { get; set; }

        /// <summary>
        /// 采购委托书
        /// </summary>
        //[Required]
        //[MaxLength(64)]
        //[MinLength(2)]
        [DataMember(Order = 12)]
        public string PurchaseDelegater { get; set; }

        #region 过期

        /// <summary>
        /// 是否过期
        /// </summary>
        [DataMember(Order = 12)]
        public bool IsOutDate
        {
            get
            {
                //return DateTime.Now.Date > OutDate;
                return (IsGSPLicenseOutDate || IsGMPLicenseOutDate
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
                    || OutDate <= DateTime.Now.Date);
            }
            set
            {
                value = (IsGSPLicenseOutDate || IsGMPLicenseOutDate
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
                    || OutDate<=DateTime.Now.Date
                    );
            }
        }

        /// <summary>
        /// 过期日
        /// </summary>
        [DataMember(Order = 13)]
        public DateTime OutDate
        {
            get;
            set;
        }
        #endregion

        /// <summary>
        /// 有效
        /// </summary>
        [DataMember(Order = 0)]
        public override bool Valid
        {
            get
            {
                return !(!IsApproval || IsOutDate || IsLock
                    || IsGSPLicenseOutDate
                    || IsGMPLicenseOutDate
                    || IsBusinessLicenseOutDate
                    || IsMedicineProductionLicenseOutDate
                    || IsMedicineBusinessLicenseOutDate
                    || IsInstrumentsProductionLicenseOutDate
                    || IsInstrumentsBusinessLicenseOutDate
                    );
            }
            set
            {
                value = !(!IsApproval || IsOutDate || IsLock
                    || IsGSPLicenseOutDate
                    || IsGMPLicenseOutDate
                    || IsBusinessLicenseOutDate
                    || IsMedicineProductionLicenseOutDate
                    || IsMedicineBusinessLicenseOutDate
                    || IsInstrumentsProductionLicenseOutDate
                    || IsInstrumentsBusinessLicenseOutDate
                    );
                if (value)
                {
                    ValidRemark = "[正常]";
                }
                else
                {
                    ValidRemark = "";
                    if (!IsApproval)
                    {
                        ValidRemark += "[审批未通过]";
                    }
                    if (IsOutDate)
                    {
                        ValidRemark += "[过期]";
                    }
                    if (IsLock)
                    {
                        ValidRemark += "[" + LockRemark + "]";
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
        public bool IsLock
        {
            get
            {
                return _IsLock;
            }
            set
            {
                _IsLock = value;
                Valid = true;
            }
        }

        /// <summary>
        /// Lock说明
        /// </summary>
        [DataMember]
        public string LockRemark { get; set; }


        /// <summary>
        /// 收货地址
        /// </summary>
        [DataMember]
        public string ReceiveAddress{ get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [DataMember]
        public string DetailedAddress { get; set; }

        /// <summary>
        /// 审批流程FlowID
        /// </summary>
        [DataMember]
        public Guid FlowID { get; set; } 
        #endregion

        #region Navigation Property




        [DataMember(Order = 1)]
        public Guid DistrictId { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        [DataMember(Order = 2)]
        public virtual District District { get; set; }

        /// <summary>
        /// 销售单
        /// </summary>
        [DataMember(Order = 3)]
        public virtual ICollection<SalesOrder> SalesOrders { set; get; }

        /// <summary>
        /// 购单位货提货人员
        /// </summary>
        [DataMember(Order = 4)]
        public virtual ICollection<PurchaseUnitDeliverer> PurchaseUnitDeliverers { get; set; }


        /// <summary>
        /// 购货单位采购人员
        /// </summary>
        [DataMember(Order = 5)]
        public virtual ICollection<PurchaseUnitBuyer> PurchaseUnitBuyers { get; set; }


        //[DataMember]
        //public Guid GMSPLicenseId { get; set; }

        //[DataMember]
        //public virtual GMSPLicense GMSPLicense { get; set; }


        #endregion


    }
}

