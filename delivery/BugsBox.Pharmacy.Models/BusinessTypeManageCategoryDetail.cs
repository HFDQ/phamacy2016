using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 经营方式的管理要求分类详细
    /// </summary> 
    [Description("经营方式的管理要求分类详细")]
    [DataContract(IsReference = true)]
    public class BusinessTypeManageCategoryDetail : Entity
    {
        #region Entiy Property

        #endregion

        #region Navigation Property

        [DataMember]
        public Guid PurchaseManageCategoryDetailId { get; set; }

        [DataMember]
        public virtual PurchaseManageCategoryDetail PurchaseManageCategoryDetail { get; set; }

        [DataMember]
        public Guid BusinessTypeId { get; set; }

        [DataMember]
        public virtual BusinessType BusinessType { get; set; }



        #endregion
    }
}
