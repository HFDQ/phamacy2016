using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    public class DirectSalesOrder : Entity, ILEntity, IStore
    {
        [DataMember]
        [DisplayName("创建人")] 
        public Guid CreateUserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [DataMember]
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [DataMember]
        public Guid UpdateUserId { get; set; } 

        /// <summary>
        /// 直调单号
        /// </summary>
        [DataMember]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// 供货商ID
        /// </summary>
        [DataMember]
        public Guid SupplyUnitId { get; set; }

        /// <summary>
        /// 购货商ID
        /// </summary>
        [DataMember]
        public Guid PurchaseUnitId { get; set; }

        /// <summary>
        /// 审核状态值
        /// </summary>
        [DataMember]
        public int ApprovalStatusValue { get; set; }

        /// <summary>
        /// 审核ID
        /// </summary>
        [DataMember]
        public Guid FlowId { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        [DataMember]
        public DateTime ApprovalDateTime { get; set; }

        /// <summary>
        /// 审核人ID
        /// </summary>
        [DataMember]
        public Guid ApprovalUserId { get; set; }

        /// <summary>
        /// 直调派驻验收人ID
        /// </summary>
        [DataMember]
        public Guid CheckUserId { get; set; }

        /// <summary>
        /// 直调派驻、委托验收人姓名
        /// </summary>
        [DataMember]
        public string CheckUserName { get; set; }

        /// <summary>
        /// 验收时间
        /// </summary>
        [DataMember]
        public DateTime CheckTime { get; set; }
        
        /// <summary>
        /// 验收地址
        /// </summary>
        [DataMember]
        public string CheckAddress { get; set; }

        /// <summary>
        /// 验收结论
        /// </summary>
        [DataMember]
        public string CheckResulty { get; set; }

        /// <summary>
        /// 验收状态
        /// </summary>
        [DataMember]
        public int CheckStatusValue { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        [DataMember]
        public Guid StoreId { get;set;}
        [DataMember]
        public string Memo { get; set; }

        #region 导航属性
        [DataMember]
        public ICollection<DirectSalesOrderDetail> DirectSalesOrderDetails { get; set; }
        #endregion
    }
}
