using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Business.Models
{
    public class drugsUnqualificationQuery
    {
        /// <summary>
        /// 编号
        /// </summary>
        
        [DataMember(Name = "ID")]
        public Guid id
        {
            get;
            set;
        }
        /// <summary>
        /// 创建人
        /// </summary>
        [Required]
        [DataMember]
        [Display(Name = "创建人")]
        public string creater
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>

        [DataMember(Name = "创建时间")]
        public DateTime createTime
        {
            get;
            set;
        }

        /// <summary>
        /// 更新时间
        /// </summary>
       
        [DataMember(Name = "更新时间")]
        public System.DateTime updateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 审核状态
        /// </summary>
        
        [Display(Name="审核状态")]
        public string IsApproval
        {
            get;
            set;
        }

        /// <summary>
        /// 审核ID
        /// </summary>
        [Display(Name = "审核ID")]
        [DataMember]
        public System.Guid flowID
        {
            get;
            set;
        }

        /// <summary>
        /// 不合格描述
        /// </summary>
        [DataMember]
        [Display(Name = "不合格描述")]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 不合格类型
        /// </summary>
        [Display(Name = "不合格类型")]
        [DataMember]
        public int unqualificationType
        {
            get;
            set;
        }

        /// <summary>
        /// 不合格数量
        /// </summary>
        [Display(Name = "不合格数量")]
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
        [Display(Name = "药品名称")]
        public string drugName
        {
            get;
            set;
        }

        /// <summary>
        /// 批次号
        /// </summary>
        [DataMember]
        [Display(Name = "批次号")]
        public string batchNo
        {
            get;
            set;
        }

        /// <summary>
        /// 剂型
        /// </summary>
        [DataMember]
        [Display(Name = "剂型")]
        public string Dosage
        {
            get;
            set;
        }

        /// <summary>
        /// 规格
        /// </summary>
        [DataMember]
        [Display(Name = "规格")]
        public string Specific
        {
            get;
            set;
        }

        /// <summary>
        /// 有效期至
        /// </summary>
        [DataMember]
        [Display(Name = "有效期至")]
        public DateTime OutValidDate
        {
            get;
            set;
        }

        /// <summary>
        /// 生产厂家
        /// </summary>
        [DataMember]
        [Display(Name = "生产厂家")]
        public string FactoryName
        {
            get;
            set;
        }

        /// <summary>
        /// 入库日期
        /// </summary>
        [DataMember]
        [Display(Name = "入库日期")]
        public DateTime InInventoryDate
        {
            get;
            set;
        }

        /// <summary>
        /// 存库时间
        /// </summary>
        [DataMember]
        [Display(Name = "存库时间")]
        public int InventoryDate
        {
            get { return Convert.ToInt16((DateTime.Now - InInventoryDate).TotalDays); }
            set { value = Convert.ToInt16((DateTime.Now - InInventoryDate).TotalDays); }
        }

        /// <summary>
        /// 供货单位
        /// </summary>
        [DataMember]
        [Display(Name = "供货单位")]
        public string SupplyUnitName
        {
            get;
            set;
        }


        /// <summary>
        /// 当前库存
        /// </summary>
        [DataMember]
        [Display(Name = "当前库存")]
        public decimal CurrentInventoryCount
        {
            get;
            set;
        }

        /// <summary>
        /// 存放库区
        /// </summary>
        [DataMember]
        [Display(Name = "存放库区")]
        public string WarehouseZone
        {
            get;
            set;
        }

        /// <summary>
        /// 存放仓库
        /// </summary>
        [DataMember]
        [Display(Name = "存放仓库")]
        public string Warehouse
        {
            get;
            set;
        }

        /// <summary>
        /// 审核流程
        /// </summary>
        [DataMember]
        [Display(Name = "审核流程")]
        public string ApprovalProc
        {
            get;
            set;
        }

        [DataMember]
        [Display(Name = "产地")]
        public string Origin
        {
            get;
            set;
        }

        [DataMember]
        [Display(Name = "采购单号")]
        public string PurchaseOrderDocumentNumber { get; set; }

        [DataMember]
        [DisplayName("来源")]
        public string Source { get; set; }

        [DataMember]
        [DisplayName("生产日期")]
        public DateTime productDate { get; set; }
    }
}
