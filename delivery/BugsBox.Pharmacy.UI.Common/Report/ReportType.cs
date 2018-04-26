using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.UI.Common.Report
{ 
    /// <summary>
    /// 打印(预览,导出类型)
    /// </summary>
    public enum ReportType
    {
        /// <summary>
        /// 打印
        /// </summary>
        Print=1,

        /// <summary>
        ///  导出
        /// </summary>
        Export=2,

        /// <summary>
        /// 预览
        /// </summary>
        Preview=8
    }
}
