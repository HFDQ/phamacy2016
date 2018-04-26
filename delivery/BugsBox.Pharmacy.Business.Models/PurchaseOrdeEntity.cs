using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    [DataContract]
    public class PurchaseOrdeEntity
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
        /// 发货日期
        /// </summary>
        [DataMember]
        public DateTime? AllReceiptedDate { get; set; }

        [DataMember]
        public DateTime PurchasedDate { get; set; }

        /// <summary>
        /// 供货商销售人员/业务员编号,可以根据供应商找到关联的业务员
        /// </summary>
        [DataMember]
        public Guid SupplyUnitAccountExecutiveId { get; set; }
        [DataMember]
        public String ContactName { get; set; }
        [DataMember]
        public String ContactTel { get; set; }

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
        /// 采购单备注
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// 审批日期
        /// </summary>
        [DataMember]
        public DateTime? ApprovaledTime { get; set; }

        /// <summary>
        /// 审指人ID
        /// </summary>
        [DataMember]
        public Guid ApprovalUserId { get; set; }

        /// <summary>
        /// 审核备注
        /// </summary>
        [DataMember]
        public string ApprovalDecription { get; set; }

        [DataMember]
        public string ApprovalEmployeeName { get; set; }

        /// <summary>
        /// 审批日期 “采购记录”中某种药品的采购数量与到货数量不同，需经过审批修改采购数量（仅数量能修改）
        /// </summary>
        [DataMember]
        public DateTime? AmountApprovaledTime { get; set; }

        /// <summary>
        /// 审指人ID
        /// </summary>
        [DataMember]
        public Guid AmountApprovalUserId { get; set; }

        /// <summary>
        /// 审核备注
        /// </summary>
        [DataMember]
        public string AmountApprovalDecription { get; set; }

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

        /// <summary>
        /// 收货单位
        /// </summary>
        [DataMember]
        public string ReceiveUnit { get; set; }

        /// <summary>
        /// 收货地址
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        ///  是否为直销订单
        /// </summary>
        [DataMember]
        public bool DirectMarketing { get; set; }

        /// <summary>
        /// 纪录总数
        /// </summary>
        [DataMember]
        public int RecordCount { get; set; }

       
        #endregion
    }
}
