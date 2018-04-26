using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BugsBox.Pharmacy.Business.Models
{
    /// <summary>
    /// 销售价格控制规则模型
    /// </summary>
    [Serializable]
    public class SalePriceControlRulesModel
    {
        /// <summary>
        /// 销售价格控制id
        /// </summary>
       
        public int RuleType { get; set; }

        /// <summary>
        /// 销售价格控制名称
        /// </summary>
       
        public string RuleName { get; set; }

        /// <summary>
        /// 销售价格控制描述
        /// </summary>
        public decimal RuleRate { get; set; }
        
        public string Description { get; set; }

        /// <summary>
        /// 销售单打印控制规则
        /// </summary>
        public EnumSalesOrderPrintRule SalesOrderPrintRuleValue { get; set; }
    }

    /// <summary>
    /// 销售单打印控制规则枚举
    /// </summary>
    public enum EnumSalesOrderPrintRule
    {
        [Display(Name = "销售单结算后打印")]
        销售单结算后打印=0,
        [Display(Name = "销售单审核后打印")]
        销售单审核后打印=1
    }
}
