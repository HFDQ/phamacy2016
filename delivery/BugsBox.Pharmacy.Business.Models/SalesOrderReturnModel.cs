using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace BugsBox.Pharmacy.Business.Models
{
    public class SalesOrderReturnModel
    {
        [DisplayName("SaleOrderReturnID")]
        [DataMember]
        public Guid Id { get; set; }

        [DisplayName("销退单号")]
        [DataMember]
        public string SaleOrderReturnDocumentNumber { get; set; }

        [DisplayName("原销售单号")]
        [DataMember]
        public string SaleOrderDocumentNumber { get; set; }

        /// <summary>
        /// 退单相应销售单ID号
        /// </summary>
        [DataMember]
        public Guid SalesOrderId { get; set; }

        [DisplayName("购货商")]
        [DataMember]
        public string PurchaseUnitName { get; set; }

        [DisplayName("购货商拼音")]
        [DataMember]
        public string PurchaseUnitPinYin { get; set; }

        [DisplayName("销售员")]
        [DataMember]
        public string Saler { get; set; }

        [DisplayName("创建人")]
        [DataMember]
        public string Creater { get; set; }

        [DisplayName("创建时间")]
        [DataMember]
        public DateTime? CreateTime { get; set; }

        #region 销退验收
        [DisplayName("销退验收单")]
        [DataMember]
        public string SaleOrderReturnCheckDocumentNumber { get; set; }

        [DisplayName("销退验收员")]
        [DataMember]
        public string SaleOrderReturnChecker { get; set; }

        [DisplayName("验收时间")]
        [DataMember]
        public DateTime? SaleOrderReturnCheckTime { get; set; }
        #endregion

        #region 销退入库
        [DisplayName("销退入库单")]
        [DataMember]
        public string SaleOrderReturnINvDocumentNumber { get; set; }

        [DisplayName("入库保管员")]
        [DataMember]
        public string SaleOrderReturnInver { get; set; }

        [DisplayName("入库时间")]
        [DataMember]
        public DateTime? SaleOrderReturnInvTime { get; set; }
        #endregion

        #region 销退取消
        [DisplayName("销退取消单")]
        [DataMember]
        public string SaleOrderReturnCancelDocumentNumber { get; set; }

        [DisplayName("取消人")]
        [DataMember]
        public string SaleOrderReturnCanceler { get; set; }

        [DisplayName("取消时间")]
        [DataMember]
        public DateTime? SaleOrderReturnCancelTime { get; set; }

        [DisplayName("取消理由")]
        [DataMember]
        public string SaleOrderReturnCancelReason { get; set; }
        #endregion

        [DisplayName("药品数量")]
        [DataMember]
        public Decimal? DrugNum { get; set; }

        [DisplayName("药品总价")]
        [DataMember]
        public Decimal? TotalPrice { get; set; }

        
    }
}
