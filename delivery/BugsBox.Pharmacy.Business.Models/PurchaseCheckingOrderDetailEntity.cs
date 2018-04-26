using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Business.Models
{
    [DataContract]
    public class PurchaseCheckingOrderDetailEntity
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
        /// <summary>
        /// 采购价
        /// </summary>
        [DataMember]
        public decimal PurchasePrice { get; set; }
        /// <summary>
        /// 到货数量
        /// </summary>
        [DataMember]
        public decimal ArrivalAmount { get; set; }

        /// <summary>
        /// 收货日期
        /// </summary>
        [DataMember]
        public DateTime ArrivalDateTime { get; set; }

        /// <summary>
        /// 收货数量
        /// </summary>
        [DataMember]
        public decimal ReceiveAmount { get; set; }

        /// <summary>
        /// 验收合格数量
        /// </summary>
        [DataMember]
        public decimal QualifiedAmount { get; set; }

        /// <summary>
        /// 验收不合格数量
        /// </summary>
        [DataMember]
        public decimal UnQualifiedAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 存储方式
        /// </summary>
        [DataMember]
        public string StorageType
        {
            get;
            set;
        }

        /// <summary>
        /// 验收结果
        /// </summary>
        [DataMember]
        public int CheckResult { get; set; }

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
        /// 备注(注明不合格事项及处置措施)
        /// </summary> 
        [DataMember]
        public string Decription { get; set; }

        [DataMember]
        public Decimal? sequence { get; set; }
        [DataMember]
        public string BusinessScopeCode { get; set; }
        [DataMember]
        public bool IsSpecialCategory{get;set;}
    }
}
