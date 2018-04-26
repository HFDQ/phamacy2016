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
    /// 销售退货明细
    /// 暂时不做
    /// </summary>
    [DataContract(IsReference = true)]
    public class SalesOrderReturnDetail : Entity, ILEntity, IStore
    {
        /// <summary>
        /// 行号用于票据打印和显示顺序
        /// 一个销售单-对应的几个此明细要求连续
        /// </summary>
        [DataMember]
        public int Index { get; set; }

        /// <summary>
        /// 创建用户编号
        /// </summary>
        [DataMember]
        public Guid CreateUserId { get; set; }

        /// <summary>
        /// 更新用户编号
        /// </summary>
        [DataMember]
        public Guid UpdateUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DataMember(Order = 2)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Required]
        [DataMember]
        public DateTime UpdateTime { get; set; }

        [DataMember]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [Required]
        [DataMember]
        public string productName { get; set; }


        /// <summary>
        /// 商品编号
        /// </summary>
        [Required]
        [DataMember]
        public string productCode { get; set; }


        /// <summary>
        /// 生产批号
        /// </summary>
        [Required]
        //[MinLength(8)]
        [DataMember]
        public string BatchNumber { get; set; }


        /// <summary>
        /// 订单数量
        /// </summary>
        [DataMember]
        public decimal OrderAmount { get; set; }

        /// <summary>
        /// 销售单价
        /// </summary>
        [DataMember]
        public decimal UnitPrice { get; set; }


        /// <summary>
        /// 实际销售单价
        /// </summary>
        [DataMember]
        public decimal ActualUnitPrice { get; set; }


        /// <summary>
        /// 销售金额
        /// </summary>
        [DataMember]
        public decimal Price { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [DataMember]
        public string MeasurementUnit { get; set; }

        //规格
        [Required]
        [DataMember]
        public string SpecificationCode { get; set; }

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


        //厂家全称
        [Required]
        [DataMember]
        public string FactoryName { get; set; }

        /// <summary>
        /// 描述即备注
        /// </summary>
        [Required]
        [DataMember]
        public string Description { get; set; }

        //退货数量
        [Required]
        [DataMember]
        public decimal ReturnAmount { get; set; }

        //退货理由
        [DataMember]
        public int ReturnReasonValue { get; set; }
        
        /// <summary>
        /// 销退处理状态
        /// </summary>
        public OrderReturnReason ReturnReason
        {
            get
            {
                return (OrderReturnReason)ReturnReasonValue;
            }
            set
            {
                ReturnReasonValue = (int)value;
            }
        }

        //退货理由补足
        [DataMember]
        public string ReturnReasonMemo { get; set; }

        /// <summary>
        /// 可入库数量
        /// </summary>
        [DataMember]
        public decimal CanInAmount { get; set; }

        /// <summary>
        /// 不可入库数量
        /// </summary>
        [DataMember]
        public decimal CannotInAmount { get; set; }

        /// <summary>
        /// 不可入库处理办法
        /// </summary>
        [DataMember]
        public int ReturnHandledMethodValue { get; set; }

        /// <summary>
        /// 销退处理状态
        /// </summary>
        public ReturnHandledMethod ReturnHandledMethod
        {
            get
            {
                return (ReturnHandledMethod)ReturnHandledMethodValue;
            }
            set
            {
                ReturnHandledMethodValue = (int)value;
            }
        }

        /// <summary>
        /// 不可入库处理办法补足
        /// </summary>
        [DataMember]
        public string ReturnHandledMethodMemo { get; set; }

        /// <summary>
        /// 是否补发
        /// </summary>
        [DataMember]
        public bool IsReissue { get; set; }

        /// <summary>
        /// 补发数量
        /// </summary>
        [DataMember]
        public decimal ReissueAmount { get; set; }

        /// <summary>
        /// 出库单明细编号
        /// </summary>
        [DataMember(Order = 6)]
        public Guid OutInventoryDetailID { get; set; }

        /// <summary>
        /// 销退ID
        /// </summary>
        [DataMember]
        public Guid OrderReturnID { get; set; }

        /// <summary>
        /// 销售明细ID
        /// </summary>
        [DataMember(Order = 6)]
        public Guid SalesOrderDetailID { get; set; }

        /// <summary>
        /// 药物库存ID
        /// </summary>
        [DataMember(Order = 6)]
        public Guid DrugInventoryRecordID { get; set; }

        /// <summary>
        /// 剂型
        /// </summary>
        [DataMember]
        public string DictionaryDosageCode { get; set; }

        /// <summary>
        /// 产地
        /// </summary>        
        [DataMember]
        public string Origin { get; set; }

    }
}

