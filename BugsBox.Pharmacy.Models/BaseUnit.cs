using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using BugsBox.Application.Core;


namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 企业单位的基类
    /// </summary>
    [DataContract(IsReference = true)]
    public abstract class BaseUnit : Entity, ILEntity, IStore, IEnable
    {
        #region 基本信息
        /// <summary>
        /// 单位名称
        /// </summary>
        [DataMember(Order = 0)]
        public string Name { get; set; }

        /// <summary>
        /// 唯一编码
        /// </summary>
        [DataMember(Order = 1)]
        public string Code { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
        [DataMember(Order = 2)]
        public string PinyinCode { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember(Order = 3)]
        public string ContactName { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [DataMember(Order = 4)]
        public string ContactTel { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [DataMember(Order = 5)]
        public string Description { get; set; }

        /// <summary>
        /// 法定代表人
        /// </summary>
        [DataMember(Order = 6)]
        public string LegalPerson { get; set; }

        /// <summary>
        /// 企业负责人
        /// </summary>
        [DataMember]
        [MaxLength(16)]
        public string Header { get; set; }

        /// <summary>
        /// 生产经营范围
        /// </summary>
        [DataMember(Order = 7)]
        public string BusinessScope { get; set; }

        /// <summary>
        /// 年销售额
        /// </summary>
        [DataMember(Order = 8)]
        public string SalesAmount { get; set; }


        /// <summary>
        /// 传真
        /// </summary> 
        [MaxLength(64)]
        [DataMember(Order = 9)]
        public string Fax { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(128)]
        [DataMember(Order = 10)]
        public string Email { get; set; }

        /// <summary>
        /// 网站
        /// </summary>
        [MaxLength(128)]
        [DataMember(Order = 11)]
        public string WebAddress { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        [DataMember]
        public string ReceiveAddress { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [DataMember]
        public string DetailedAddress { get; set; }

        #region 过期

        /// <summary>
        /// 是否过期
        /// </summary>
        [DataMember(Order = 12)]
        public bool IsOutDate
        {
            get
            {
                return DateTime.Now.Date > OutDate;
            }
            set
            {
                value = DateTime.Now.Date > OutDate;
            }
        }

        /// <summary>
        /// 过期日
        /// </summary>
        [DataMember(Order = 13)]
        public DateTime OutDate { get; set; }
        #endregion

        #endregion

        #region GSP证书

        /// <summary>
        ///  GSP证书
        /// </summary>
        [DataMember]
        public Guid GSPLicenseId { get; set; }

        /// <summary>
        ///  GSP证书是否过期
        /// </summary>
        [DataMember]
        public bool IsGSPLicenseOutDate
        {
            get { return GSPLicenseId != Guid.Empty && DateTime.Now.Date > GSPLicenseOutDate; }
            set { value = GSPLicenseId != Guid.Empty && DateTime.Now.Date > GSPLicenseOutDate; }
        }

        /// <summary>
        /// GSP证书过期日
        /// </summary>
        [DataMember]
        public DateTime GSPLicenseOutDate { get; set; }

        #endregion

        #region GMP证书
        /// <summary>
        /// GMP证书
        /// </summary>
        [DataMember]
        public Guid GMPLicenseId { get; set; }

        /// <summary>
        ///   GMP证书是否过期
        /// </summary>
        [DataMember]
        public bool IsGMPLicenseOutDate
        {
            get { return GMPLicenseId != Guid.Empty && DateTime.Now.Date > GMPLicenseOutDate; }
            set { value = GMPLicenseId != Guid.Empty && DateTime.Now.Date > GMPLicenseOutDate; }
        }

        /// <summary>
        ///  GMP证书过期日
        /// </summary>
        [DataMember]
        public DateTime GMPLicenseOutDate { get; set; }

        #endregion

        #region 营业执照

        [DataMember]
        public Guid BusinessLicenseId { get; set; }

        /// <summary>
        ///  营业执照是否过期
        /// </summary>
        [DataMember]
        public bool IsBusinessLicenseOutDate
        {
            get { return BusinessLicenseId != Guid.Empty && DateTime.Now.Date > BusinessLicenseeOutDate; }
            set { value = BusinessLicenseId != Guid.Empty && DateTime.Now.Date > BusinessLicenseeOutDate; }
        }

        /// <summary>
        /// 营业执照期日
        /// </summary>
        [DataMember]
        public DateTime BusinessLicenseeOutDate { get; set; }



        #endregion

        #region 药品生产许可证

        /// <summary>
        /// 药品生产许可证
        /// </summary>
        [DataMember]
        public Guid MedicineProductionLicenseId { get; set; }

        /// <summary>
        /// 药品生产许可证是否过期
        /// </summary>
        [DataMember]
        public bool IsMedicineProductionLicenseOutDate
        {
            get { return MedicineProductionLicenseId != Guid.Empty && DateTime.Now.Date > MedicineProductionLicenseOutDate; }
            set { value = MedicineProductionLicenseId != Guid.Empty && DateTime.Now.Date > MedicineProductionLicenseOutDate; }
        }

        /// <summary>
        ///药品生产许可证过期日
        /// </summary>
        [DataMember]
        public DateTime MedicineProductionLicenseOutDate { get; set; }

        #endregion 药品生产许可证

        #region 药品经营许可证

        /// <summary>
        /// 药品经营许可证
        /// </summary>
        [DataMember]
        public Guid MedicineBusinessLicenseId { get; set; }

        /// <summary>
        /// 药品经营许可证是否过期
        /// </summary>
        [DataMember]
        public bool IsMedicineBusinessLicenseOutDate
        {
            get { return MedicineBusinessLicenseId != Guid.Empty && DateTime.Now.Date > MedicineBusinessLicenseOutDate; }
            set { value = MedicineBusinessLicenseId != Guid.Empty && DateTime.Now.Date > MedicineBusinessLicenseOutDate; }
        }

        /// <summary>
        ///药品经营许可证过期日
        /// </summary>
        [DataMember]
        public DateTime MedicineBusinessLicenseOutDate { get; set; }

        #endregion 药品经营许可证 

        #region 器械生产许可证

        /// <summary>
        /// 器械生产许可证
        /// </summary>
        [DataMember]
        public Guid InstrumentsProductionLicenseId { get; set; }

        /// <summary>
        /// 器械生产许可证是否过期
        /// </summary>
        [DataMember]
        public bool IsInstrumentsProductionLicenseOutDate
        {
            get { return InstrumentsProductionLicenseId != Guid.Empty && DateTime.Now.Date > InstrumentsProductionLicenseOutDate; }
            set { value = InstrumentsProductionLicenseId != Guid.Empty && DateTime.Now.Date > InstrumentsProductionLicenseOutDate; }
        }

        /// <summary>
        ///药品经营许可证过期日
        /// </summary>
        [DataMember]
        public DateTime InstrumentsProductionLicenseOutDate { get; set; }

        #endregion

        #region 器械经营许可证

        /// <summary>
        /// 器械经营许可证
        /// </summary>
        [DataMember]
        public Guid InstrumentsBusinessLicenseId { get; set; }

        /// <summary>
        /// 器械经营许可证是否过期
        /// </summary>
        [DataMember]
        public bool IsInstrumentsBusinessLicenseOutDate
        {
            get { return InstrumentsBusinessLicenseId != Guid.Empty && DateTime.Now.Date > InstrumentsBusinessLicenseOutDate; }
            set { value = InstrumentsBusinessLicenseId != Guid.Empty && DateTime.Now.Date > InstrumentsBusinessLicenseOutDate; }
        }

        /// <summary>
        ///器械经营许可证过期日
        /// </summary>
        [DataMember]
        public DateTime InstrumentsBusinessLicenseOutDate { get; set; }

        #endregion 器械经营许可证

        #region 卫生许可证

        /// <summary>
        /// 卫生许可证
        /// </summary>
        [DataMember]
        public Guid HealthLicenseId { get; set; }

        /// <summary>
        ///  卫生许可证是否过期
        /// </summary>
        [DataMember]
        public bool IsHealthLicenseOutDate
        {
            get { return HealthLicenseId != Guid.Empty && DateTime.Now.Date > HealthLicenseOutDate; }
            set { value = HealthLicenseId != Guid.Empty && DateTime.Now.Date > HealthLicenseOutDate; }
        }

        /// <summary>
        /// 卫生许可证过期日
        /// </summary>
        [DataMember]
        public DateTime HealthLicenseOutDate { get; set; }

        #endregion

        #region 税务登记证
        /// <summary>
        /// 税务登记证
        /// </summary>
        [DataMember]
        public Guid TaxRegisterLicenseId { get; set; }
        /// <summary>
        ///  税务登记证是否过期
        /// </summary>
        [DataMember]
        public bool IsTaxRegisterLicenseOutDate
        {
            get { return TaxRegisterLicenseId != Guid.Empty && DateTime.Now.Date > TaxRegisterLicenseOutDate; }
            set { value = TaxRegisterLicenseId != Guid.Empty && DateTime.Now.Date > TaxRegisterLicenseOutDate; }
        }
        /// <summary>
        /// 税务登记证过期日
        /// </summary>
        [DataMember]
        public DateTime TaxRegisterLicenseOutDate { get; set; }
        #endregion

        #region 组织机构代码证
        /// <summary>
        /// 组织机构代码证
        /// </summary>
        [DataMember]
        public Guid OrganizationCodeLicenseId { get; set; }
        /// <summary>
        ///  组织机构代码证是否过期
        /// </summary>
        [DataMember]
        public bool IsOrganizationCodeLicenseOutDate
        {
            get { return OrganizationCodeLicenseId != Guid.Empty && DateTime.Now.Date > OrganizationCodeLicenseOutDate; }
            set { value = OrganizationCodeLicenseId != Guid.Empty && DateTime.Now.Date > OrganizationCodeLicenseOutDate; }
        }
        /// <summary>
        /// 组织机构代码证过期日
        /// </summary>
        [DataMember]
        public DateTime OrganizationCodeLicenseOutDate { get; set; }
        #endregion

        #region 食品流通许可证
        /// <summary>
        /// 食品流通许可证
        /// </summary>
        [DataMember]
        public Guid FoodCirculateLicenseId { get; set; }
        /// <summary>
        ///  食品流通许可证是否过期
        /// </summary>
        [DataMember]
        public bool IsFoodCirculateLicenseOutDate
        {
            get { return FoodCirculateLicenseId != Guid.Empty && DateTime.Now.Date > FoodCirculateLicenseOutDate; }
            set { value = FoodCirculateLicenseId != Guid.Empty && DateTime.Now.Date > FoodCirculateLicenseOutDate; }
        }
        /// <summary>
        /// 食品流通许可证过期日
        /// </summary>
        [DataMember]
        public DateTime FoodCirculateLicenseOutDate { get; set; }
        #endregion

        #region 医疗机构执业许可证
        /// <summary>
        /// 医疗机构执业许可证
        /// </summary>
        [DataMember]
        public Guid MmedicalInstitutionPermitId { get; set; }
        /// <summary>
        ///  医疗机构执业许可证是否过期
        /// </summary>
        [DataMember]
        public bool IsMmedicalInstitutionPermitOutDate
        {
            get { return MmedicalInstitutionPermitId != Guid.Empty && DateTime.Now.Date > MmedicalInstitutionPermitOutDate; }
            set { value = MmedicalInstitutionPermitId != Guid.Empty && DateTime.Now.Date > MmedicalInstitutionPermitOutDate; }
        }
        /// <summary>
        /// 医疗机构执业许可证过期日
        /// </summary>
        [DataMember]
        public DateTime MmedicalInstitutionPermitOutDate { get; set; }
        #endregion

        #region 事业单位法人证
        /// <summary>
        /// 事业单位法人证
        /// </summary>
        [DataMember]
        public Guid LnstitutionLegalPersonLicenseId { get; set; }
        /// <summary>
        ///  事业单位法人证是否过期
        /// </summary>
        [DataMember]
        public bool IsLnstitutionLegalPersonLicenseOutDate
        {
            get { return LnstitutionLegalPersonLicenseId != Guid.Empty && DateTime.Now.Date > LnstitutionLegalPersonLicenseOutDate; }
            set { value = LnstitutionLegalPersonLicenseId != Guid.Empty && DateTime.Now.Date > LnstitutionLegalPersonLicenseOutDate; }
        }
        /// <summary>
        /// 事业单位法人证过期日
        /// </summary>
        [DataMember]
        public DateTime LnstitutionLegalPersonLicenseOutDate { get; set; }
        #endregion

        #region 税务登记

        /// <summary>
        /// 税务登记号
        /// </summary>
        [DataMember(Order = 26)]
        public string TaxRegistrationCode { get; set; }

        /// <summary>
        /// 税务登记文件
        /// </summary>
        [DataMember(Order = 27)]
        public Guid TaxRegistrationFile { get; set; }

        #endregion

        #region 年检文件
        /// <summary>
        /// 年检文件
        /// </summary>
        [DataMember(Order = 28)]
        public Guid AnnualFile { get; set; }

        /// <summary>
        /// 最新年检日期
        /// </summary>
        [DataMember(Order = 29)]
        public DateTime LastAnnualDte { get; set; }
        #endregion

        #region 审批状态

        [DataMember(Order = 30)]
        public int ApprovalStatusValue { get; set; }

        [NotMapped]
        [DataMember(Order = 31)]
        public ApprovalStatus ApprovalStatus
        {
            get { return (ApprovalStatus)ApprovalStatusValue; }
            set { ApprovalStatusValue = (int)value; }
        }


        /// <summary>
        /// 是否审批通过
        /// </summary>
        [DataMember(Order = 32)]
        public bool IsApproval
        {
            get
            {
                return this.ApprovalStatus.Equals(ApprovalStatus.Approvaled);
            }
            set
            {
                value = this.ApprovalStatus.Equals(ApprovalStatus.Approvaled);
            }
        }




        #endregion

        /// <summary>
        /// 企业类型编号
        /// </summary>
        [DataMember]
        public Guid UnitTypeId { get; set; }

        /// <summary>
        /// 企业类型
        /// </summary>
        [DataMember]
        public virtual UnitType UnitType { get; set; }

        #region ILEntity

        /// <summary>
        /// 创建用户编号
        /// </summary>
        [DataMember(Order = 33)]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember(Order = 34)]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DataMember(Order = 35)]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember(Order = 36)]
        public DateTime UpdateTime { get; set; }

        #endregion

        #region IStore
        [DataMember(Order = 37)]
        public Guid StoreId { get; set; }
        #endregion

        #region IEnable
        [DataMember(Order = 38)]
        public bool Enabled { get; set; }
        #endregion 

        /// <summary>
        /// 审批流程FlowID
        /// </summary>
        [DataMember]
        public Guid FlowID { get; set; }

        /// <summary>
        /// 有效
        /// </summary>
        [DataMember(Order = 14)]
        public virtual bool Valid
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
                    ValidRemark = "";
                    //if (!IsApproval)
                    //{
                    //    ValidRemark += "[审核未通过]";
                    //}
                    if (IsOutDate)
                    {
                        ValidRemark += "[过期]";
                    }
                    //if (IsQualityAgreementOut)
                    //{
                    //    ValidRemark += "[质量协议书过期]";
                    //}
                    //if (IsAttorneyAattorneyOut)
                    //{
                    //    ValidRemark += "[法人委托书过期]";
                    //}
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
        public bool IsLock { get; set; }


        /// <summary>
        /// Lock说明
        /// </summary>
        [DataMember]
        public string LockRemark { get; set; }

    }
}

