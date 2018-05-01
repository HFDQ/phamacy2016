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
        
        /// <summary>
        /// 价格控制描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 销售单打印控制规则
        /// </summary>
        public EnumSalesOrderPrintRule SalesOrderPrintRuleValue { get; set; }
                
        /// <summary>
        /// 采购税率
        /// </summary>
        public PurchaseOrderTaxRate PurchaseOrderDefaultTaxRate { get; set; }


        /// <summary>
        /// 销售税率
        /// </summary>
        public SalesOrderTaxRate SalesOrderDefaultTaxRate { get; set; }

        /// <summary>
        /// 验收员信息
        /// </summary>
        public SaleChecker SaleChecker { get; set; }

        /// <summary>
        /// 仓库保管员ID
        /// </summary>
        public Guid InventoryKeeperId { get; set; }

        /// <summary>
        /// 仓库保管员
        /// </summary>
        public string InventoryKeeperName { get; set; }

        /// <summary>
        /// 排序规则
        /// </summary>
        public EnumSalesOrderSortWhenPrint EnumSalesOrderSortWhenPrintValue { get; set; }
    }

    /// <summary>
    /// 销售单打印排序方法
    /// </summary>
    public enum EnumSalesOrderSortWhenPrint
    {
        /// <summary>
        /// 按照剂型排序
        /// </summary>
        [Display(Name = "按照剂型排序")]
        按照剂型排序 = 0,
        /// <summary>
        /// 按照品名首字母排序
        /// </summary>
        [Display(Name = " 按照品名首字母排序")]
        按照品名首字母排序 = 1,

        /// <summary>
        /// 按照原排序
        /// </summary>
        [Display(Name = "按开单时排序")]
        按开单时排序 = 2,
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

    /// <summary>
    /// 采购开票时，自动定义的税点
    /// </summary>
    [Serializable]
    public class PurchaseOrderTaxRate
    {
        public decimal DefaultTaxRate { get; set; }
    }
    /// <summary>
    /// 销售开票时，自动定义的税点
    /// </summary>
    [Serializable]
    public class SalesOrderTaxRate
    {
        public decimal DefaultTaxRate { get; set; }
    }
    /// <summary>
    /// 设置复核员，系统
    /// </summary>
    [Serializable]
    public class SaleChecker
    {
        /// <summary>
        /// 普通药品复核员ID
        /// </summary>
        public Guid OrdinaryChecker { get; set; }
        /// <summary>
        /// 普通药品复核员姓名
        /// </summary>
        public string OrdinaryCheckerName { get; set; }
        /// <summary>
        /// 特殊药品第一复核员ID
        /// </summary>
        public Guid SpacialDrugFirstChecker { get; set; }

        /// <summary>
        /// 特药第一复核员姓名
        /// </summary>
        public string SpecialDrugFirstCheckerName { get; set; }

        /// <summary>
        /// 特殊药品第二复核员ID
        /// </summary>
        public Guid SpacialDrugSecondChecker { get; set; }

        /// <summary>
        /// 特邀第二复核员姓名
        /// </summary>
        public string SpacialDrugSecondCheckerName { get; set; }
    }
}
