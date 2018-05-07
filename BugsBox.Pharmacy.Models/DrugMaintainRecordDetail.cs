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
    /// 药品养护记录明细
    /// </summary>
    [Description("药品养护记录明细")]
    [DataContract]
    public class DrugMaintainRecordDetail : Entity
    {
        /// <summary>
        /// 养护人Id
        /// </summary> 
        [DataMember(Order = 2)]
        public Guid? UserId { get; set; }


        /// <summary>
        /// 养护人
        /// </summary> 
        [DataMember()]
        [NotMapped]
        public string UserName { get; set; }

        /// <summary>
        /// 药物库存Id
        /// </summary> 
        [DataMember(Order = 1)]
        public Guid DrugInventoryRecordId { get; set; }

        //检查日期  
        [DataMember]
        public DateTime? CheckDate { get; set; }

        //单据  
        [DataMember]
        public string BillDocumentNo { get; set; }

        /// <summary>
        /// 品名
        /// </summary> 
        [DataMember(Order = 6)]
        public string ProductName { get; set; }

        /// <summary>
        /// 剂型
        /// </summary>
        [MaxLength(32)]
        [DataMember]
        public string DictionaryDosageCode { get; set; }

        //规格 
        [MaxLength(32)]
        [DataMember]
        public string DictionarySpecificationCode { get; set; }

        /// <summary>
        /// 库存数量 
        /// </summary>
        [DataMember]
        public decimal CurrentInventoryCount { get; set; }

        /// <summary>
        /// 养护数量 
        /// </summary>
        [DataMember]
        public decimal MaintainCount { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        [DataMember]
        public decimal Price { get; set; }

        /// <summary>
        /// 产地
        /// </summary>        
        [DataMember]
        public string Origin { get; set; }


        //批准文号 
        [MaxLength(64)]
        [DataMember]
        public string LicensePermissionNumber { get; set; }

        /// <summary>
        /// 生产批号
        /// </summary>         
        [MaxLength(16)]
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


        //生产厂家   
        [DataMember]
        public string Manufacturer { get; set; }

        //药品单位 
        [MaxLength(32)]
        [DataMember]
        public string DictionaryMeasurementUnitCode { get; set; }

        //质量状况 
        [MaxLength(512)]
        [DataMember]
        public string QualitySituation { get; set; }


        //处理结果 
        [MaxLength(512)]
        [DataMember]
        public string MaintainResult { get; set; }

        //验收合格数量 
        [MaxLength(512)]
        [DataMember]
        public string CheckqualifiedNumber { get; set; }

        //验收结果 
        [MaxLength(512)]
        [DataMember]
        public string CheckResult { get; set; }


    }
}
