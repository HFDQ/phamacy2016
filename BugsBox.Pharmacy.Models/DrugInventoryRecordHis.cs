using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    /// <summary>
    /// 药物库存
    /// 记录药物存放在哪个库区
    /// 加入药物生产附加信息() 
    /// 一条药物库记录由一次采购到货记录产生
    /// 一条药物库存或提供给多个销售单明细，要检查药物库存数量
    /// 可销售可零售数量=CurrentInventoryCount-OnSalesOrderCount-OnRetailCount- drugsUnqualicationNum
    /// </summary>
    [Description("药物库存变动历史")]
    [DataContract(IsReference = true)]
    public class DrugInventoryRecordHis : Entity, IStore
    {
        #region Entiy Property



        [DisplayName("库存ID")]
        public Guid DrugInventoryRecordId { get; set; }

        public Guid OperatorId { get; set; }


        public string Operator { get; set; }

        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 采购价或成本价
        /// 从对采购单-采购明细中取
        /// </summary>
        [DataMember]
        public decimal PurchasePricce { get; set; }

        /// <summary>
        /// 生产批号
        /// </summary>
        [Required]

        [DataMember]
        public string BatchNumber { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        [DataMember]
        public DateTime PruductDate { get; set; }

        /// <summary>
        /// 有效期至
        /// </summary>
        [DataMember]
        public DateTime OutValidDate { get; set; }

        /// <summary>
        /// 是否过期
        /// </summary>
        [DataMember(Order = 14)]
        public bool IsOutValidDate
        {
            get
            {
                return DateTime.Now.Date > OutValidDate;
            }
            set
            {
                value = DateTime.Now.Date > OutValidDate;
            }
        }

        /// <summary>
        /// 入库时数量
        /// </summary>
        [DataMember]
        public decimal InInventoryCount { get; set; }

        /// <summary>
        /// 已经销售并出库数量
        /// </summary>
        [DataMember]
        public decimal SalesCount { get; set; }

        private decimal _OnSalesOrderCount;
        /// <summary>
        /// 在销售单但未出库数量
        /// </summary>
        [DataMember]
        public decimal OnSalesOrderCount
        {
            get
            {
                return _OnSalesOrderCount;
            }
            set
            {
                _OnSalesOrderCount = value;
            }
        }

        private decimal _CurrentInventoryCount;
        /// <summary>
        /// 当前库存数量(在库)
        /// </summary>
        [DataMember]
        public decimal CurrentInventoryCount
        {
            get
            {
                return _CurrentInventoryCount;
            }
            set
            {
                _CurrentInventoryCount = value;
            }
        }

        /// <summary>
        /// 已经零售且已经卖出的数量
        /// </summary>
        [DataMember]
        public decimal RetailCount { get; set; }

        /// <summary>
        /// 待售拆零数量
        /// </summary>
        [DataMember]
        public decimal DismantingAmount { get; set; }

        /// <summary>
        /// 变动数量
        /// </summary>
        [DataMember]
        public decimal ChangeAmount { get; set; }


        /// <summary>
        /// 已售拆零数量
        /// </summary>
        [DataMember]
        public decimal RetailDismantingAmount { get; set; }


        private decimal _OnRetailCount;

        /// <summary>
        /// 被零售客户端加入零售明细的数量（暂时不用）
        /// </summary>
        [DataMember]
        public decimal OnRetailCount
        {
            get
            {
                return _OnRetailCount;
            }
            set
            {
                _OnRetailCount = value;
            }
        }

        /// <summary>
        /// 描述即备注
        /// </summary>

        [DataMember(Order = 7)]
        public string Decription { get; set; }

        #endregion
        /// <summary>
        /// 可卖数量
        /// </summary>
        [DataMember]
        public decimal CanSaleNum
        {
            get;set;
        }

        [DataMember]
        public bool Valid
        {
            get;
            set;
        }

        /// <summary>
        /// 入库类型
        /// </summary>
        [DataMember]
        public decimal DurgInventoryTypeValue { get; set; }

        /// <summary>
        /// 入库类型
        /// </summary>
        public DurgInventoryType DurgInventoryType
        {
            get
            {
                return (DurgInventoryType)DurgInventoryTypeValue;
            }
            set
            {
                DurgInventoryTypeValue = (int)value;
            }
        }

        #region Navigation Property
        [DataMember]
        public Guid DrugInfoId { get; set; }
        [DataMember]
        public virtual DrugInfo DrugInfo { get; set; }

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        #endregion

        //采购退货数量
        [DataMember]
        decimal _PurchaseReturnNumber;
        public decimal PurchaseReturnNumber
        {
            get
            {
                return _PurchaseReturnNumber;
            }
            set
            {
                _PurchaseReturnNumber = value;
            }
        }



    }
}
