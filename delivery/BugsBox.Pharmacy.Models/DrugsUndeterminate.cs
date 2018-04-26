using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    [Description("待处理药品")]
    [DataContract]
    public class DrugsUndeterminate:Entity
    {        
        /// <summary>
        /// 采购单号
        /// </summary>
        [Required]
        [DataMember]
        public System.String OrderDocumentID
        {
            get;
            set;
        }
                
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime createTime
        {
            get;
            set;
        }

        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember]
        public string creater
        {
            get;
            set;
        }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataMember]
        public System.DateTime updateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 药品ID与导航属性
        /// </summary>
        [Required]
        [DataMember]
        public System.Guid DrugInfoID
        {
            get;
            set;
        }
        [DataMember]
        public virtual DrugInfo DrugInfo { get; set; }



        /// <summary>
        /// 待处理药品来源
        /// </summary>
        [DataMember]
        public string Source
        {
            get;
            set;
        }

        /// <summary>
        /// 待处理单号
        /// </summary>
        [DataMember]
        public string DocumentNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 待处理数量
        /// </summary>
        [DataMember]
        public decimal quantity
        {
            get;
            set;
        }

        /// <summary>
        /// 药品名称
        /// </summary>
        [DataMember]
        public string drugName
        {
            get;
            set;
        }


        /// <summary>
        /// 待处理批次号
        /// </summary>
        [DataMember]
        public string BatchNumber
        {
            get;
            set;
        }
        
        /// <summary>
        /// 待处理仓库
        /// </summary>
        [DataMember]
        public string wareHouse
        {
            get;
            set;
        }

        /// <summary>
        /// 复查原因内容
        /// </summary>
        [DataMember]
        public string rsn
        {
            get;
            set;
        }

        /// <summary>
        /// 复查情况内容
        /// </summary>
        [DataMember]
        public string sta
        {
            get;
            set;
        }
        
        /// <summary>
        /// 复查情况签署人
        /// </summary>
        [DataMember]
        public string staSigner
        {
            get;
            set;
        }

        /// <summary>
        /// 复查情况签署日期
        /// </summary>
        [DataMember]
        public DateTime staSignDate
        {
            get;
            set;
        }


        /// <summary>
        /// 复查结论内容
        /// </summary>
        [DataMember]
        public string conclusion
        {
            get;
            set;
        }

        // <summary>
        /// 复查结论签署人
        /// </summary>
        [DataMember]
        public string conclusionSigner
        {
            get;
            set;
        }

        // <summary>
        /// 复查结论签署时间
        /// </summary>
        [DataMember]
        public DateTime conclusionDate
        {
            get;
            set;
        }

        /// <summary>
        /// 复查流程：1、业务员－》2、质管员－》3、质管部意见
        /// </summary>
        [DataMember]
        public int proc
        {
            get;
            set;
        }

        /// <summary>
        /// 合格数量
        /// </summary>
        [DataMember]
        public decimal QualificationQuantity
        {
            get;
            set;
        }


        /// <summary>
        /// 不合格数量
        /// </summary>
        [DataMember]
        public decimal UnqualificationQuantity
        {
            get;
            set;
        }

        /// <summary>
        /// 生产日期
        /// </summary>
        [DataMember]
        public DateTime produceDate
        {
            get;
            set;
        }

        /// <summary>
        /// 有效期至
        /// </summary>
        [DataMember]
        public DateTime ExpireDate
        {
            get;
            set;
        }

        /// <summary>
        /// 供应商名称
        /// </summary>
        [DataMember]
        public string supplyer
        {
            get;
            set;
        }

        /// <summary>
        /// 采购价格
        /// </summary>
        [DataMember]        
        public decimal PurchasePrice
        {
            get;
            set;
        }

        /// <summary>
        /// 库存ID
        /// </summary>
        [DataMember]
        public Guid InventoryID
        {
            get;
            set;
        }

        /// <summary>
        /// 不合格药品审核流程ID
        /// </summary>
        [DataMember]
        public Guid UnqualificationApprovalID
        {
            get;
            set;
        }
        /// <summary>
        /// 门店ID
        /// </summary>
        [DataMember]
        public Guid storeID { get; set; }

        /// <summary>
        /// 采购单ID
        /// </summary>
        [DataMember]
        public Guid? PurchaseOrderID { get; set; }


        //规格
        [DataMember]
        public string Specific
        {
            get;
            set;
        }
        //剂型
        [DataMember]
        public string DosageType
        {
            get;
            set;
        }

        //产地
        [DataMember]
        public string Origin
        {
            get;
            set;
        }
    }
}
