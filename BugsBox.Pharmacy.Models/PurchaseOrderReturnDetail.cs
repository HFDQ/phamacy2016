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
    /// 采购退货明细
    /// </summary>
    [DataContract(IsReference = true)]
    public class PurchaseOrderReturnDetail : Entity, IStore
    {
        /// <summary>
        /// 门店编号
        /// </summary>
        [DataMember]
        public Guid StoreId { get; set; }

        /// <summary>
        /// 药物编号
        /// </summary>
        [DataMember]
        public Guid DrugInfoId { get; set; }

        /// <summary>
        /// 生产批号
        /// </summary>
        [Required]
        //[MinLength(8)]
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
        /// 退货数量
        /// </summary>
        [Required]
        [DataMember]
        public decimal ReturnAmount { get; set; }

        /// <summary>
        /// 采购价
        /// </summary>
        [DataMember]
        public decimal PurchasePrice { get; set; }

        /// <summary>
        /// 退货原因
        /// </summary>
        [DataMember]
        public string ReturnReason { get; set; }

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
        /// 采购退货单
        /// </summary>
        [DataMember]
        public virtual PurchaseOrderReturn PurchaseOrderReturn { get; set; }

        /// <summary>
        /// 采购退货单ID
        /// </summary>
        [DataMember]
        public Guid PurchaseOrderReturnId { get; set; }

        /// <summary>
        /// 采购退货来源
        /// </summary>
        [DataMember]
        public int PurchaseReturnSourceValue { get; set; }

        /// <summary>
        /// 采购退货来源
        /// </summary>
        [NotMapped]
        public PurchaseReturnSource PurchaseReturnSource
        {
            get
            {
                return (PurchaseReturnSource)PurchaseReturnSourceValue;
            }
            set
            {
                PurchaseReturnSourceValue = (int)value;
            }
        }

        /// <summary>
        /// 采购退货来源关联单号ID
        /// </summary>
        [DataMember]
        public Guid RelatedOrderId { get; set; }

        /// <summary>
        /// 退货处理方式
        /// </summary>
        [DataMember]
        public int ReturnHandledMethodValue { get; set; }

        /// <summary>
        /// 退货处理方式
        /// </summary>
        [DataMember]
        [NotMapped]
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
        /// 备注
        /// </summary>
        [DataMember]
        public string Decription { get; set; }

    }
}

