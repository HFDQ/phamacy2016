using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.UI.Common.Report
{
    /// <summary>
    /// 打印对象提供者抽象工厂
    /// </summary>
    public abstract class ReportProviderFactory
    {
        /// <summary>
        /// 创建ReportBuilder
        /// </summary>
        /// <returns></returns>
        public abstract ReportBuilder CreateReportBuilder();
        /// <summary>
        /// 创建ReportTemplate
        /// </summary>
        /// <returns></returns>
        public abstract ReportTemplate CreateReportTemplate();
        /// <summary>
        /// 创建CreateReportor
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract IReportor CreateReportor(ReportType type);
        /// <summary>
        /// 创建CreateReportor 导出
        /// </summary>
        /// <returns></returns>
        public abstract IReportor CreateExportReportor();
        /// <summary>
        /// 创建CreateReportor 打印
        /// </summary>
        /// <returns></returns>
        public abstract IReportor CreatePrintReportor();
        /// <summary>
        /// 创建CreateReportor 预览
        /// </summary>
        /// <returns></returns>
        public abstract IReportor CreatePreviewReportor();
    }
}
