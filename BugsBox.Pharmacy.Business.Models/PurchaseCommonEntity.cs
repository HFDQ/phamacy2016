using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    [DataContract]
    public class PurchaseCommonEntity
    {
        [DataMember]
        public Guid Id { get; set; }

        /// <summary>
        /// 单据编号
        /// </summary>
        [DataMember]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// 单据状态
        /// </summary>  
        [DataMember]
        public int OrderStatus { get; set; }
        public string OrderStatusValue { get; set; }
        /// <summary>
        /// 操作日期
        /// </summary>
        [DataMember]
        public DateTime OperateTime { get; set; }

        /// <summary>
        /// 操作员ID
        /// </summary>
        [DataMember]
        public Guid OperateUserId { get; set; }
        [DataMember]
        public string EmployeeNumber { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }

        /// <summary>
        /// 第二验收人ID
        /// </summary>
        [DataMember]
        public Guid SecondCheckerId { get; set; }

        /// <summary>
        /// 第二验收人意见
        /// </summary>
        [DataMember]
        public string SecondCheckMemo { get; set; }
        /// <summary>
        /// 第二验收人姓名
        /// </summary>
        [DataMember]
        public string SecondCheckerName { get; set; }

        /// <summary>
        /// 操作备注
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// 采购单Id
        /// </summary>
        [DataMember]
        public Guid PurchaseOrderId { get; set; }

        /// <summary>
        /// 采购单编号
        /// </summary>
        [DataMember]
        public string PurchaseOrderDocumentNumber { get; set; }

        /// <summary>
        /// 审批日期
        /// </summary>
        [DataMember]
        public DateTime? ApprovaledTime { get; set; }

        /// <summary>
        /// 审指人ID
        /// </summary>
        [DataMember]
        public Guid ApprovalEmployeeName { get; set; }

        /// <summary>
        /// 审核备注
        /// </summary>
        [DataMember]
        public string ApprovalDecription { get; set; }

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

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 纪录总数
        /// </summary>
        [DataMember]
        public int RecordCount { get; set; }

        /// <summary>
        /// 关联单号
        /// </summary>
        [DataMember]
        public Guid RelatedOrderId { get; set; }
        [DataMember]
        public string RelatedOrderDocumentNumber { get; set; }
        [DataMember]
        public int RelatedOrderTypeValue { get; set; }

        #region for退货流程
        /// <summary>
        /// 检验员意见(过程检验员/进货检验员)
        /// </summary>
        [DataMember]
        public string CheckerSuggest { get; set; }

        /// <summary>
        /// 检验员意见更新时间
        /// </summary>
        [DataMember]
        public DateTime? CheckerUpdateTime { get; set; }
        [DataMember]
        public string CheckerEmployeeNumber { get; set; }
        [DataMember]
        public string CheckerEmployeeName { get; set; }

        /// <summary>
        /// 质量管理部意见
        /// </summary>
        [DataMember]
        public string QualitySuggest { get; set; }

        /// <summary>
        /// 质量管理部意见更新时间
        /// </summary>
        [DataMember]
        public DateTime? QualityUpdateTime { get; set; }
        [DataMember]
        public string QualityEmployeeNumber { get; set; }
        [DataMember]
        public string QualityEmployeeName { get; set; }

        /// <summary>
        /// 总经理意见
        /// </summary>
        [DataMember]
        public string GeneralManagerSuggest { get; set; }

        /// <summary>
        /// 总经理意见更新时间
        /// </summary>
        [DataMember]
        public DateTime? GeneralManagerUpdateTime { get; set; }
        [DataMember]
        public string GeneralManagerEmployeeNumber { get; set; }
        [DataMember]
        public string GeneralManagerEmployeeName { get; set; }

        /// <summary>
        /// 财务部意见
        /// </summary>
        [DataMember]
        public string FinanceDepartmentSuggest { get; set; }

        /// <summary>
        /// 财务部意见更新时间
        /// </summary>
        [DataMember]
        public DateTime? FinanceDepartmentUpdateTime { get; set; }
        [DataMember]
        public string FinanceDepartmentEmployeeNumber { get; set; }
        [DataMember]
        public string FinanceDepartmentEmployeeName { get; set; }

        [DataMember]
        public Guid CheckerUserId { get; set; }
        [DataMember]
        public Guid QualityUserId { get; set; }
        [DataMember]
        public Guid GeneralManagerUserId { get; set; }
        [DataMember]
        public Guid FinanceDepartmentUserId { get; set; }
        #endregion

        #region for结算流程
        /// <summary>
        /// 付款日期
        /// </summary>
        [DataMember]
        public DateTime PaymentTime { get; set; }

        /// <summary>
        /// 结算方式
        /// </summary>
        [DataMember]
        public string PaymentMethod { get; set; }

        //单据金额
        [DataMember]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 已付金额
        /// </summary>
        [DataMember]
        public decimal PaymentedAmount { get; set; }

        /// <summary>
        /// 本次应付金额
        /// </summary>
        [DataMember]
        public decimal PaymentingAmount { get; set; }

        /// <summary>
        /// 本次付款金额
        /// </summary>
        [DataMember]
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// 经销方式(采购入库,采购退货)
        /// </summary>
        [DataMember]
        public int DealerMethodValue { get; set; }

        #endregion

        #region for 收货
        /// <summary>
        /// 发货日期
        /// </summary>
        [DataMember]
        public DateTime ShippingTime { get; set; }

        /// <summary>
        /// 发货地点
        /// </summary>
        [DataMember]
        public string ShippingAdress { get; set; }

        /// <summary>
        /// 发货单位
        /// </summary>
        [DataMember]
        public string ShippingUnit { get; set; }

        /// <summary>
        /// 运输单位
        /// </summary>
        [DataMember]
        public string TransportUnit { get; set; }
        #endregion
    }
}
