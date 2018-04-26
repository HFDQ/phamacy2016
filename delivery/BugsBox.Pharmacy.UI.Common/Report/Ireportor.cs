using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.UI.Common.Report
{
    
    /// <summary>
    /// 报表(导出,预览)接口
    /// </summary>
    public interface IReportor
    {
        ReportType Type { get;}  

        /// <summary>
        /// 报表(导出,预览),失败返回失败信息
        /// </summary>
        /// <param name="reportBuilder"></param>
        /// <param name="dataSource"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        string Report(ReportBuilder reportBuilder, ReportTemplate reportTemplate,object dataSource, string fileName = null); 

    }
 
}
