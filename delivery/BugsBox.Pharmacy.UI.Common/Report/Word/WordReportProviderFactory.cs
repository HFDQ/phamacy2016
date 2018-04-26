using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.UI.Common.Report.Word
{
    public class WordReportProviderFactory : ReportProviderFactory
    {
        private ReportBuilder builder = null;
        public override ReportBuilder CreateReportBuilder()
        {
            lock (this)
            {
                if (builder == null)
                {
                    builder = new WordReportBuilder();
                }
                return builder;
            }
        }

        public override ReportTemplate CreateReportTemplate()
        {
            return new WordReportTemplate();
        } 

        public override IReportor CreateReportor(ReportType type)
        {
            IReportor innterreportor = null;
            switch (type)
            {
                case ReportType.Export:
                    innterreportor = CreateExportReportor();
                    break;
                case ReportType.Preview:
                    innterreportor = CreatePreviewReportor();
                    break;
                case ReportType.Print:
                    innterreportor = CreatePrintReportor();
                    break; 
            }
            return innterreportor;
        }  

        IReportor reportorExport = null;

        public override IReportor CreateExportReportor()
        {
            lock (this)
            {
                if (reportorExport == null)
                {
                    reportorExport = new WordExportReportor();
                }
                return reportorExport;
            }
        }

        IReportor reportorPrint = null;
        public override IReportor CreatePrintReportor()
        {
            lock (this)
            {
                if (reportorPrint == null)
                {
                    reportorPrint = new WordPrintReportor();
                }
                return reportorPrint;
            }
        }

        IReportor reportorPreview = null;

        public override IReportor CreatePreviewReportor()
        {
            lock (this)
            {
                if (reportorPreview == null)
                {
                    reportorPreview = new WordPrintReportor();
                }
                return reportorPreview;
            }
        }
    }
}
