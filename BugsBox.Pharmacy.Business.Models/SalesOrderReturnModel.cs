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

    /// <summary>
    /// 退货品种的信息
    /// </summary>
    public class SalesOrderReturnDetailModel:DrugInfoBaseModel
    {
        [DataMember(Order = 18)]
        [DisplayName("ID")]
        public Guid Id { get; set; }

        /// <summary>
        /// 销售记录ID
        /// </summary>
        [DataMember(Order = 19)]
        public Guid SalesOrderId { get; set; }

        [DataMember(Order = 9)]
        [DisplayName("批号")]
        public string BatchNumber { get; set; }

        [DataMember(Order = 10)]
        [DisplayName("退货数量")]
        public decimal ReturnAmount { get; set; }
        [DataMember(Order = 11)]
        [DisplayName("单价")]
        public decimal UnitPrice { get; set; }
        [DataMember(Order = 12)]
        [DisplayName("金额")]
        public decimal Price { get; set; }

        [DataMember(Order = 13)]
        [DisplayName("所属销售单号")]
        public string SalesOrderCode { get; set; }

        [DataMember(Order = 13)]
        [DisplayName("销退客户")]
        public string PurchaseUnitName { get; set; }

        /// <summary>
        /// 销退单记录ID
        /// </summary>
        [DataMember]
        public Guid SalesOrderReturnId { get; set; }
        [DataMember(Order = 14)]
        [DisplayName("退单号")]
        public string SalesOrderReturnCode { get; set; }
        
        [DataMember]
        [DisplayName("退单人")]
        public string ReturnEmName { get; set; }
        [DataMember(Order = 15)]
        [DisplayName("销售员")]
        public string SalerName { get; set; }

        [DataMember(Order = 16)]
        [DisplayName("建单时间")]
        public DateTime CreateTime { get; set; }

        [DataMember(Order = 17)]
        [DisplayName("建单时间")]
        public string CreateTimeStr { get => this.CreateTime.ToString("yyyy-MM-dd HH:mm"); }
    }

    public class SalesOrderReturnDetailQueryModel:BaseQueryModel
    {
        /// <summary>
        /// 销售单号
        /// </summary>
        [DataMember]
        public string SalesOrderCode { get; set; }

        /// <summary>
        /// 销退单号
        /// </summary>
        [DataMember]
        public string SalesOrderReturnCode { get; set; }

        /// <summary>
        /// 批号
        /// </summary>
        [DataMember]
        public string BatchNumber { get; set; }

        /// <summary>
        /// 退货单位
        /// </summary>
        [DataMember]
        public string ReturnPurchaseUnitName { get; set; }
    }
}
