using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.UI.Common.Report.Word
{
    class WordExportReportor : IReportor
    {
        public string Report(ReportBuilder reportBuilder, ReportTemplate reportTemplate,object dataSource, string fileName = null)
        {
            throw new NotImplementedException();
        }

        public ReportType Type
        {
            get { throw new NotImplementedException(); }
        }
    }
}
