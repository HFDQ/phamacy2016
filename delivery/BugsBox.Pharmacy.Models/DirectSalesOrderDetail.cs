using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BugsBox.Pharmacy.Models
{
    public class DirectSalesOrderDetail:Entity
    {
        /// <summary>
        /// 品种ID
        /// </summary>
        [DataMember]
        public Guid DrugInfoId { get; set; }

        /// <summary>
        /// 销售数量
        /// </summary>
        [DataMember]
        public decimal Amount { get; set; }

        /// <summary>
        /// 批号
        /// </summary>
        [DataMember]
        public string BatchNumber { get; set; }

        /// <summary>
        /// 产地
        /// </summary>
        [DataMember]
        public string Origin { get; set; }
        
        /// <summary>
        /// 生产日期
        /// </summary>
        [DataMember]
        public DateTime ProductDate { get; set; }

        /// <summary>
        /// 过期日
        /// </summary>
        [DataMember]
        public DateTime OutValidDate { get; set; }

        /// <summary>
        /// 合格数量
        /// </summary>
        [DataMember]
        public decimal QualityAmount { get; set; }

        /// <summary>
        /// 合格验收信息
        /// </summary>
        [DataMember]
        public string QualityMemo { get; set; }

        /// <summary>
        /// 不合格数量
        /// </summary>
        [DataMember]
        public decimal UnQualityAmount { get; set; }

        /// <summary>
        /// 不合格处理意见
        /// </summary>
        [DataMember]
        public string UnqualityMemo { get; set; }

        /// <summary>
        /// 验收方法措施
        /// </summary>
        [DataMember]
        public string CheckMethod { get; set; }

        /// <summary>
        /// 主表ID
        /// </summary>
        [DataMember]
        public Guid DirectSalesOrderId { get; set; }

        [DataMember]
        public virtual DirectSalesOrder DirectSalesOrder { get; set; }

        #region 导航属性
        /// <summary>
        /// 品种基础信息
        /// </summary>
        [DataMember]
        public virtual DrugInfo Druginfo { get; set; }

        /// <summary>
        /// 供货单价
        /// </summary>
        [DataMember]
        public decimal SupplyPrice { get; set; }

        /// <summary>
        /// 销售单价
        /// </summary>
        [DataMember]
        public decimal SalePrice { get; set; }

        /// <summary>
        /// 冲差单价
        /// </summary>
        [DataMember]
        public decimal DirectSaleDiff { get; set; }

        [DataMember]
        public int Squence { get; set; }

        #endregion

    }
}
