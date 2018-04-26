using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    public class PurchaseTaxReturn
    {
        #region Entiy Property
        [DataMember]
        public Guid Id { get; set; }

        /// <summary>
        /// 单据编号
        /// </summary>
        [DataMember]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// 采购总额
        /// </summary>
        [DataMember]
        public decimal TotalMoney { get; set; }
        
        /// <summary>
        /// 采购单创建日期
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建用户ID(采购员)
        /// 采购员姓名
        /// 采购员姓名
        /// </summary>
        [DataMember]
        public Guid CreateUserId { get; set; }
        [DataMember]
        public string EmployeeNumber { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        
        /// <summary>
        /// 订单状态
        /// </summary>
        [DataMember]
        public int OrderStatusValue { get; set; }

        /// <summary>
        /// 供应商编号
        /// </summary>
        [DataMember]
        public Guid SupplyUnitId { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        [DataMember]
        public string SupplyUnitName { get; set; }

        [DataMember]
        public string SupplyUnitBank { get; set; }

        /// <summary>
        /// 纪录总数
        /// </summary>
        [DataMember]
        public int RecordCount { get; set; }

        /// <summary>
        /// 返税人
        /// </summary>
        [DataMember]
        public string TaxReturnUserName { get; set; }

        /// <summary>
        /// 返税人ID
        /// </summary>
        [DataMember]
        public Guid TaxReturnUserId { get; set; }

        /// <summary>
        /// 发票是否已到
        /// </summary>
        [DataMember]
        public Boolean? IsInvoiceArrival { get; set; }

        /// <summary>
        /// 发票金额
        /// </summary>
        [DataMember]
        public Decimal? InvoiceMoney { get; set; }

        /// <summary>
        /// 是否已打款
        /// </summary>
        [DataMember]
        public Boolean? IsPayed { get; set; }

        /// <summary>
        /// 实际付款金额
        /// </summary>
        [DataMember]
        public Decimal? PayMoney { get; set; }

        /// <summary>
        /// 票面与实付金额的差额
        /// </summary>
        [DataMember]
        public decimal? Diff { get; set; }

        /// <summary>
        /// 返税点
        /// </summary>
        [DataMember]
        public decimal? Rate { get; set; }

        /// <summary>
        /// 返税额
        /// </summary>
        [DataMember]
        public decimal? ReturnTax { get; set; }

        [DataMember]
        public Guid? PuchaseOrderConcatID { get; set; }


        [DataMember]
        public string Decription { get; set; }
        #endregion
    }
}
