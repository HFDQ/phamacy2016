using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using BugsBox.Pharmacy.Models;
using System.Windows.Forms;
using System.Xml;
using BugsBox.Pharmacy.AppClient.Common;
using FastReport;
namespace BugsBox.Pharmacy.AppClient.UI.Report
{
    /// <summary>
    ///  Common Print Helper For Print Specified RDLC File
    /// </summary>
    public class PrintHelper : IDisposable
    {
        private LocalReport localReport = new LocalReport();
        private PrintDialog printDialog = new PrintDialog();
        private PrintDocument printDocument = new PrintDocument();
        private PageSetupDialog PageSetupDialog = new System.Windows.Forms.PageSetupDialog();

        private PrintPreviewDialog printPreview = new PrintPreviewDialog();


        private int pageIndex = 0;
        private List<Stream> pageStreams = new List<Stream>();

        private bool disposed = false;

        DataSet FDataSet = new DataSet();
        private FastReport.Report report = new FastReport.Report();

        public PrintHelper(string reportName, DataSet reportData)
        {
            this.localReport = new LocalReport();
            this.localReport.ReportPath = System.IO.Directory.GetCurrentDirectory() + "\\" + reportName;
            if (reportData != null && reportData.ExtendedProperties.Count > 0)
            {
                List<ReportParameter> rps = new List<ReportParameter>();
                DataTable maindt = new DataTable();

                foreach (string key in reportData.ExtendedProperties.Keys)
                {
                    maindt.Columns.Add(key);
                }
                var newrow = maindt.NewRow();
                foreach (string key in reportData.ExtendedProperties.Keys)
                {
                    ReportParameter rp = new ReportParameter(key, reportData.ExtendedProperties[key].ToString());
                    rps.Add(rp);

                    newrow[key] = reportData.ExtendedProperties[key].ToString();
                }
                maindt.Rows.Add(newrow);
                FDataSet.Tables.Add(maindt);
                this.localReport.SetParameters(rps);
            }
            if (reportData != null && reportData.Tables.Count > 0)
            {
                this.localReport.DataSources.Clear();

                string dsName = reportData.DataSetName;

                foreach (DataTable table in reportData.Tables)
                {
                    ReportDataSource rds = new ReportDataSource(string.Format("{0}_{1}", dsName, table.TableName), table);

                    this.localReport.DataSources.Add(rds);
                    FDataSet.Tables.Add(table);
                }
            }
            this.localReport.Refresh();
            printDialog.Document = this.printDocument;
            this.printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        public PrintHelper(string reportName, List<object> reportData, List<ReportParameter> Rps)
        {
            this.localReport.ReportPath = System.IO.Directory.GetCurrentDirectory() + "\\" + reportName;

            string storeName = PharmacyClientConfig.Config.Store.Name;
            ReportParameter rp = new ReportParameter("ReportTitle", storeName);
            Rps.Add(rp);

            this.localReport.SetParameters(Rps);
            this.localReport.DataSources.Clear();
            int i = 0;
            foreach (var data in reportData)
            {
                string name = "";
                name = "DSOrder";
                if (i == 1)
                {
                    name = "DSOrderDetail";
                }

                ReportDataSource rds = new ReportDataSource(name, data);
                this.localReport.DataSources.Add(rds);
                i++;
            }
            this.localReport.Refresh();
            printDialog.Document = this.printDocument;
            this.printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        //传参数构造函数
        public PrintHelper(string reportName, List<ReportParameter> rps, List<object> reportData)
        {
            try
            {
                Pharmacy.UI.Common.BaseFunctionUserControl c = new Pharmacy.UI.Common.BaseFunctionUserControl();
                this.localReport.ReportPath = System.IO.Directory.GetCurrentDirectory() + "\\" + reportName;

                string storeName = PharmacyClientConfig.Config.Store.Name;
                ReportParameter rp = new ReportParameter("ReportTitle", storeName);
                rps.Add(rp);
                this.localReport.SetParameters(rps);
                this.localReport.DataSources.Clear();
                int i = 0;
                foreach (var data in reportData)
                {
                    string name = "";
                    name = "DSOrder";
                    if (i == 1)
                    {
                        name = "DSOrderDetail";
                    }
                    ReportDataSource rds = new ReportDataSource(name, data);
                    this.localReport.DataSources.Add(rds);
                    i++;
                }
                this.localReport.Refresh();
                printDialog.Document = this.printDocument;
                this.printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印参数传递有误，请联系系统管理员！");
            }
        }

        ~PrintHelper()
        {
            Dispose(false);
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (this.pageIndex < this.pageStreams.Count)
            {
                Stream pageStream = this.pageStreams[this.pageIndex];
                {
                    pageStream.Position = 0;
                    using (Metafile pageImage = new Metafile(pageStream))
                    {
                        e.Graphics.DrawImage(pageImage, e.PageBounds);

                        this.pageIndex++;

                        e.HasMorePages = (this.pageIndex < this.pageStreams.Count);
                        if (!e.HasMorePages) pageIndex = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Create Specified Print Page Stream By CreateStreamCallback Function
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="fileNameExtension"></param>
        /// <param name="encoding"></param>
        /// <param name="mimeType"></param>
        /// <param name="willSeek"></param>
        /// <returns></returns>
        private Stream CreatePrintPageStream(string filename, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            //string filePath = string.Format(@"{0}\{1}.{2}", Application.StartupPath, filename, fileNameExtension);

            //Stream pageStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.Delete);

            Stream pageStream = new MemoryStream();

            this.pageStreams.Add(pageStream);

            return pageStream;
        }

        /// <summary>
        /// Print RDLC File
        /// </summary>
        /// <returns></returns>
        public bool Print()
        {
            this.pageIndex = 0;

            this.pageStreams.Clear();


            ReportPageSettings rps = this.localReport.GetDefaultPageSettings();

            float pageWidth = 0f;
            float pageHeight = 0f;
            float marginTop = rps.Margins.Top / 100f;
            float marginLeft = rps.Margins.Left / 100f;
            float marginRight = rps.Margins.Right / 100f;
            float marginBottom = rps.Margins.Bottom / 100f;

            bool landscape = false;

            if (rps.PaperSize.Width > rps.PaperSize.Height)
            {
                pageWidth = rps.PaperSize.Width / 100f;
                pageHeight = rps.PaperSize.Height / 100f;

                landscape = false;
            }
            else
            {
                pageWidth = rps.PaperSize.Height / 100f;
                pageHeight = rps.PaperSize.Width / 100f;

                landscape = true;
            }
            string ImageDeviceInfo = string.Format(@"<DeviceInfo>
                                                        <OutputFormat>EMF</OutputFormat>
                                                        <PageWidth>{0}in</PageWidth>
                                                        <PageHeight>{1}in</PageHeight>
                                                        <MarginTop>{2}in</MarginTop>
                                                        <MarginLeft>{3}in</MarginLeft>
                                                        <MarginRight>{4}in</MarginRight>
                                                        <MarginBottom>{5}in</MarginBottom>
                                                     </DeviceInfo>",
                                                                   pageWidth, pageHeight, marginTop, marginLeft, marginRight, marginBottom);

            Warning[] warnings = null;
            try
            {
                this.localReport.Render("Image", ImageDeviceInfo, CreatePrintPageStream, out warnings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (warnings != null && warnings.Length > 0)
            {
                string warnMsg = string.Empty;

                foreach (Warning warning in warnings)
                {
                    warnMsg += string.Format("WarningCode: {0} WarningMessage: {1}\r\n", warning.Code, warning.Message);
                }

                throw new Exception(warnMsg);
            }

            if (this.pageStreams == null || this.pageStreams.Count == 0)
            {
                return false;
            }

            try
            {
                PageSetupDialog psd = new PageSetupDialog();
                PrinterSettings printset = new PrinterSettings();

                XmlDocument doc = new XmlDocument();
                string xmlFile = AppDomain.CurrentDomain.BaseDirectory + "BugsBox.Pharmacy.AppClient.printSet.xml";
                doc.Load(xmlFile);
                string s = System.Environment.CurrentDirectory;

                XmlNodeList nodelist = doc.SelectNodes("/printsets/pageset");

                int wt = Convert.ToInt16(nodelist[0].Attributes["width"].Value);
                int ht = Convert.ToInt16(nodelist[1].Attributes["height"].Value);
                PaperSize pse = new PaperSize("Custom", wt, ht);
                PageSettings pageset = new PageSettings();

                int Bottom = Convert.ToInt16(nodelist[2].Attributes["top"].Value);
                int Top = Convert.ToInt16(nodelist[3].Attributes["left"].Value);
                int Left = Convert.ToInt16(nodelist[4].Attributes["right"].Value);
                int Right = Convert.ToInt16(nodelist[5].Attributes["bottom"].Value);
                Margins margin = new Margins(Left, Right, Top, Bottom);
                pageset.Margins = margin;

                pageset.PaperSize = pse;

                printset.DefaultPageSettings.PaperSize = pse;
                psd.PrinterSettings = printset;
                psd.PageSettings = pageset;
                psd.PageSettings.PaperSize = pse;
                this.printDocument.PrinterSettings = psd.PrinterSettings;

                this.printPreview.Document = this.printDocument;
                this.printPreview.ShowDialog();
                //使用image输出到文件后，可能会改变应用程序默认路径，所以。。。。。。。。
                if (System.Environment.CurrentDirectory != s)
                    System.Environment.CurrentDirectory = s;
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印配置文件丢失，请检查！\n" + ex.Message);
            }
            return true;
        }


        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    #region Dispose Managed Resources

                    #endregion
                }

                #region Dispose Unmanaged Resources

                if (this.localReport != null)
                {
                    this.localReport.Dispose();
                    this.localReport = null;
                }

                if (this.printDialog != null)
                {
                    this.printDialog.Dispose();
                    this.printDialog = null;
                }

                if (this.printDocument != null)
                {
                    this.printDocument.Dispose();
                    this.printDocument = null;
                }

                if (this.pageStreams != null)
                {
                    if (this.pageStreams.Count > 0)
                    {
                        foreach (Stream pageStream in pageStreams)
                        {
                            pageStream.Dispose();
                        }

                        this.pageStreams.Clear();
                    }

                    this.pageStreams = null;
                }

                #endregion

                this.disposed = true;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

