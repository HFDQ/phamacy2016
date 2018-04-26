using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    [Description("收货拒收单")]
    [DataContract]
    public class DocumentRefuse : Entity
    {
        /// <summary>
        ///采购单号
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
        /// 申请人
        /// </summary>
        [DataMember]
        public string Creator { get; set; }
        
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
        public Guid DrugInfoID
        {
            get;
            set;
        }

        [DataMember]
        public virtual DrugInfo DrugInfo { get; set; }



        /// <summary>
        /// 待处理药品来源 正常渠道、销退渠道
        /// </summary>
        [DataMember]
        public string Source
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
        /// 拒收单号
        /// </summary>
        [DataMember]
        public string DocumentNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 拒收数量
        /// </summary>
        [DataMember]
        public decimal quantity
        {
            get;
            set;
        }

        /// <summary>
        /// 拒收批次号
        /// </summary>
        [DataMember]
        public string BatchNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 拒收原因内容填写，收货员
        /// </summary>
        [DataMember]
        public string rsn
        {
            get;
            set;
        }
       
        /// <summary>
        /// 拒收复查结论内容
        /// </summary>
        [DataMember]
        public string conclusion
        {
            get;
            set;
        }

        /// <summary>
        /// 复查结论时间
        /// </summary>
        [DataMember]
        public DateTime conclusionSignDate
        {
            get;
            set;
        }

        /// <summary>
        /// 复查结论签署人
        /// </summary>
        [DataMember]
        public string conclusionSigner
        {
            get;
            set;
        }

        /// <summary>
        /// 拒收流程 1、收货员填写 －》2、质管部
        /// </summary>        
        [DataMember]
        public int proc
        {
            get;
            set;
        }

        /// <summary>
        /// 拒收数量
        /// </summary>
        [DataMember]
        public decimal RefuseQuantity
        {
            get;
            set;
        }


        /// <summary>
        /// 收货数量
        /// </summary>
        [DataMember]
        public decimal ReceiveQuantity
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
        /// 采购商
        /// </summary>
        [DataMember]
        public string PurchaseUnitName
        {
            get;
            set;
        }
        //采购单细节ID
        [DataMember]
        public Guid PurchaseOrderId
        {
            get;
            set;
        }

        //失效期
        [DataMember]
        public DateTime? OutValidDate
        {
            get;
            set;
        }

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
    }
}
