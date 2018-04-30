using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BugsBox.Pharmacy.Models
{
    public class DrugsUnqualificationQuery
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
        [Display(Name = "姓名")]
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
        public drugsUnqualificationType unqualificationType
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
    }
}
