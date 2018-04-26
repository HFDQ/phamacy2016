using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
namespace BugsBox.Pharmacy.Business.Models
{
    public class SaleOrderModel
    {
        [DisplayName("SaleOrderID")]
        [DataMember]
        public Guid Id { get; set; }

        [DisplayName("配送单号")]
        [DataMember]
        public string SaleOrderDocumentNumber { get; set; }

        #region 结算查询
        [DisplayName("结算单号")]
        [DataMember]
        public string SaleOrderBalanceDocumentNumber { get; set; }

        [DisplayName("结算时间")]
        [DataMember]
        public DateTime? BalanceTime { get; set; }

        [DisplayName("结算人")]
        [DataMember]
        public string BalanceUserName { get; set; }

        [DisplayName("结算方式")]
        [DataMember]
        public string PaymentMethod { get; set; }

        #endregion

        [DisplayName("单据状态")]
        [DataMember]
        public string OrderStatus { get; set; }


        [DisplayName("取消单号")]
        [DataMember]
        public string SaleOrderCancelDocumentNumber { get; set; }

        [DisplayName("收货单位")]
        [DataMember]
        public string PurchaseUnitName { get; set; }

        [DisplayName("购货商拼音")]
        [DataMember]
        public string PurchaseUnitPinYin { get; set; }

        [IgnoreDataMember]
        [DisplayName("销售员")]
        [DataMember]
        public string Saler { get; set; }

        [DisplayName("创建人")]
        [DataMember]
        public string Creater { get; set; }

        [DisplayName("创建时间")]
        [DataMember]
        public DateTime? CreateTime { get; set; }

        [DisplayName("取消时间")]
        [DataMember]
        public DateTime? CancelTime { get; set; }

        [DisplayName("取消者")]
        [DataMember]
        public string CancelUserName { get; set; }

        [DisplayName("取消理由")]
        [DataMember]
        public string CancelReason { get; set; }

        #region 拣货复核数据
        [DisplayName("拣货单号")]
        [DataMember]
        public string PickCode { get; set; }

        [DisplayName("保管员")]
        [DataMember]
        public string PickUserName { get; set; }

        [DisplayName("拣货时间")]
        [DataMember]
        public DateTime? PickTime { get; set; }

        [DisplayName("复核单号")]
        [DataMember]
        public string CheckCode { get; set; }

        [DisplayName("复核员")]
        [DataMember]
        public string CheckUserName { get; set; }

        [DisplayName("复核员2")]
        [DataMember]
        public string CheckUserName2 { get; set; }

        [DisplayName("复核时间")]
        [DataMember]
        public DateTime? CheckTime { get; set; }
        #endregion

        #region 销退数据
        [DisplayName("销退信息")]
        [DataMember]
        public IEnumerable<ReturnOrderCol> ReturnOrderCol { get; set; }

        #endregion

        [DisplayName("药品数量")]
        [DataMember]
        public Decimal? DrugNum { get; set; }

        [DisplayName("药品总价")]
        [DataMember]
        public Decimal? TotalPrice { get; set; }
    }

    /// <summary>
    /// 销售单细节模型
    /// </summary>
    public class SalesOrderDetailModel
    {
        /// <summary>
        /// 药品id
        /// </summary>
        public Guid DrugInfoId { get; set; }

        [DisplayName("品名")]
        public string ProductGeneralName { get; set; }

        [DisplayName("剂型")]
        public string DosageType { get; set; }

        [DisplayName("规格")]
        public string SpecificType { get; set; }

        [DisplayName("计量单位")]
        public string Measurement { get; set; }

        [DisplayName("生产厂家")]
        public string FactoryName { get; set; }

        [DisplayName("产地")]
        public string Origin { get; set; }

        [DisplayName("批准文号")]
        public string LiscencePermissionNumber { get; set; }

        [DisplayName("批号")]
        public string BatchNumber { get; set; }

        [DisplayName("销售价格")]
        public decimal UnitSalePrice { get; set; }

        [DisplayName("销售数量")]
        public decimal Amout { get; set; }

        [DisplayName("销售金额")]
        public decimal Price { get { return UnitSalePrice * Amout; } }

        [DisplayName("进货价")]
        public decimal InventoryPrice { get; set; }

        /// <summary>
        /// 库存ID
        /// </summary>
        public Guid DrugInventoryRecordId { get; set; }
    }
}
