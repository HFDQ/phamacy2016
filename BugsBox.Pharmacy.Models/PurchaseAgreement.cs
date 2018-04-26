using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 采购合同
    /// </summary>
    [Description("采购合同")]
    [DataContract(IsReference = true)]
    public class PurchaseAgreement : Entity,IStore
    {
        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }
    }
}

