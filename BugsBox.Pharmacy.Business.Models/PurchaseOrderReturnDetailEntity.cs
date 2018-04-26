using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    [DataContract]
    public class PurchaseOrderReturnDetailEntity
    {
        [DataMember]
        public Guid Id { get; set; }
        /// <summary>
        /// 药物编号
        /// </summary>
        [DataMember]
        public Guid DrugInfoId { get; set; }
        //药品通用名
        [DataMember]
        public string ProductGeneralName { get; set; }
        //规格
        [DataMember]
        public string DictionarySpecificationCode { get; set; }
        //药品单位
        [DataMember]
        public string DictionaryMeasurementUnitCode { get; set; }
        //剂型
        [DataMember]
        public string DictionaryDosageCode { get; set; }
        //厂家全称
        [DataMember]
        public string FactoryName { get; set; }
        //批准文号
        [DataMember]
        public string LicensePermissionNumber { get; set; }
        //产地
        [DataMember]
        public string Origin { get; set; }
        /// <summary>
        /// 采购价
        /// </summary>
        [DataMember]
        public decimal PurchasePrice { get; set; }
        /// <summary>
        /// 退货数量
        /// </summary>
        [DataMember]
        public decimal ReturnAmount { get; set; }

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
        /// 采购退货单ID
        /// </summary>
        [DataMember]
        public Guid PurchaseOrderReturnId { get; set; }

        /// <summary>
        /// 采购退货来源
        /// </summary>
        [DataMember]
        public int PurchaseReturnSourceValue { get; set; }
        [DataMember]
        public string PurchaseReturnSourceString { get; set; }

        /// <summary>
        /// 采购退货来源关联单号ID
        /// </summary>
        [DataMember]
        public Guid RelatedOrderId { get; set; }

        /// <summary>
        /// 入库单细节ID
        /// </summary>
        [DataMember]
        public Guid PurchaseInInventoryDetailId { get; set; }

        /// <summary>
        /// 退货处理方式
        /// </summary>
        [DataMember]
        public int ReturnHandledMethodValue { get; set; }
        [DataMember]
        public string ReturnHandledMethodValueString { get; set; }

        /// <summary>
        /// 生产批号
        /// </summary>
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
        /// 备注
        /// </summary> 
        [DataMember]
        public string Decription { get; set; }

        [DataMember]
        public decimal CanReturnNum { get; set; }

        [DataMember]
        public decimal inInventoryNum { get; set; }
    }
}
