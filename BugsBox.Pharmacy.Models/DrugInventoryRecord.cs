using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    [Description("药物库存")]
    [DataContract(IsReference = true)]
    public class DrugInventoryRecord : Entity, IStore
    {
        #region Entiy Property

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
                CanSaleNum = 0;
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
                CanSaleNum = 0;
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
                CanSaleNum = 0;
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
            get
            { return CurrentInventoryCount - OnSalesOrderCount - OnRetailCount - drugsUnqualicationNum-PurchaseReturnNumber; }
            set
            {
                value = CurrentInventoryCount - OnSalesOrderCount - OnRetailCount - drugsUnqualicationNum-PurchaseReturnNumber ;
                //if (value <= 0) Valid = false;
            }
        }

        [DataMember]
        public bool Valid
        {
            get;
            set;
            //{
            //    return !IsOutValidDate 
            //        //&& DrugInfo.Valid  延时模式无法使用
            //        // && DrugInfo.Enabled 延时模式无法使用
            //        && CanSaleNum > 0;
            //}
            //set
            //{
            //    value = !IsOutValidDate
            //        //&& DrugInfo.Valid && 延时模式无法使用
            //        // DrugInfo.Enabled 延时模式无法使用
            //        && CanSaleNum > 0;
            //}
        }

        /// <summary>
        /// 入库类型
        /// </summary>
        [DataMember]
        public decimal DurgInventoryTypeValue { get; set; }
        [NotMapped]
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

        [DataMember]
        public Guid PurchaseInInventeryOrderDetailId { get; set; }

        /// <summary>
        /// 入库明细
        /// </summary>
        //[DataMember]
        //public virtual PurchaseInInventeryOrderDetail PurchaseInInventeryOrderDetail { get; set; }

        [DataMember]
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }

        /// <summary>
        /// 库区编号
        /// </summary>
        [DataMember]
        public Guid WarehouseZoneId { get; set; }

        /// <summary>
        /// 库区
        /// </summary>
        [DataMember]
        public virtual WarehouseZone WarehouseZone { get; set; }

        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 疑问信息
        /// </summary>
        [DataMember]
        public virtual ICollection<DoubtDrug> DoubtDrugs { get; set; }

        /// <summary>
        ///  不合格药品信息
        /// </summary>
        [DataMember]
        public Guid drugsUnqualicationID { get; set; }

        [DataMember]
        public decimal drugsUnqualicationNum { get; set; }
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
                CanSaleNum = 0;
            }
        }

        /// <summary>
        /// 所属货位ID
        /// </summary>
        [DataMember]
        public Guid WareHouseZonePositionId { get; set; }

    }
}
