using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

//此文件放置枚举类型
namespace BugsBox.Pharmacy.Business.Models
{
    [Description("窗体按钮操作类型")]
    public enum OperateType
    {
        Add,
        Edit,
        Browse,
        Search,
        Delete
    }

    [Description("窗体操作类型")]
    public enum FormOperation
    {
        [Display(Name = "缺省状态")]
        Empty,
        [Display(Name = "新增")]
        Add,
        [Display(Name = "修改")]
        Modify,
        [Display(Name = "删除")]
        Delete,
        [Display(Name = "查询")]
        Query
    }


    [Description("记录是否删除")]
    public enum DeleteState
    {
        [Display(Name = "已经删除")]
         Delete,
        [Display(Name = "未删除")]
         Generate
    }


    [Description("销售打印单据")]
    public enum SalesPrintSheet
    {
        [Display(Name = "药品销售清单")]
        SalesOrderList,
        [Display(Name = "药品销售记录表")]
        SalesOrderRecord,
        [Display(Name = "药品销售退回验收入库通知单")]
        SalesReturnInventoryInform,
        [Display(Name = "销后退回验收记录表")]
        SalesReturnCheck,
         [Display(Name = "药品退货通知函")]
        SalesReturnInform,
        [Display(Name = "药品退货申请表")]
        SalesReturnApply,
        [Display(Name = "药品退货审核表")]
        SalesReturnCommit,
        [Display(Name = "销后退回药品台账")]
        SalesReturnList
    }

}
