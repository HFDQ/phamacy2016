using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.UI.Common.Report
{
    /// <summary>
    /// 打印构建器抽象类 
    /// </summary>
    public abstract class ReportBuilder
    { 
        /// <summary>
        /// Build
        /// </summary>
        /// <returns></returns>
        public abstract object Build(ReportTemplate printTemplate);


    }
}
