using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// GMSP证书规定的经营范围
    /// </summary>
    [Description("GMSP证书规定的经营范围")]
    [DataContract(IsReference = true)]
    public class GMSPLicenseBusinessScope : Entity,IStore
    {
        #region Entiy Property

        #endregion

        #region Navigation Property

        /// <summary>
        ///  GMSPLicenseId
        /// </summary>
        [DataMember]
        public Guid LicenseId { get; set; }

        /// <summary>
        /// 业务范围编号
        /// </summary>
        [DataMember]
        public Guid BusinessScopeId { get; set; }

        /// <summary>
        /// 业务范围
        /// </summary>
        [DataMember]
        public virtual BusinessScope BusinessScope { get; set; }

        /// <summary>
        /// GSP证书
        /// </summary>
        [DataMember]
        public Guid GSPLicenseId { get; set; }

        /// <summary>
        /// GSPLicense
        /// </summary>
        [DataMember]
        public virtual GSPLicense GSPLicense { get; set; }

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        #endregion
    }
}
