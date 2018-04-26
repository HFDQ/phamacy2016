using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace BugsBox.Pharmacy.AppClient.UI
{
    public class PrintHelperExtention
    {
        LocalReport report = new LocalReport();
        private PrintDocument printDocument=new PrintDocument();
        private PrintDialog printDialog = new PrintDialog();
        private bool disposed = false;
        private int pageIndex;
        private List<Stream> pageStreams = new List<Stream>();
        private PrintPreviewDialog printPreview = new PrintPreviewDialog();

        ~PrintHelperExtention()
        {

        }

        public PrintHelperExtention(string reportName,DataSet ds)
        {
            this.report.ReportPath = System.IO.Directory.GetCurrentDirectory() + "\\" + reportName;
            List<ReportParameter> rps = new List<ReportParameter>();
            foreach (string i in ds.ExtendedProperties.Keys)
            {
                ReportParameter rp = new ReportParameter(i, ds.ExtendedProperties[i].ToString());
                rps.Add(rp);
            }
            this.report.SetParameters(rps);

            ReportDataSource rds = new ReportDataSource(string.Format("{0}_{1}", ds.DataSetName, ds.Tables[0].TableName), ds.Tables[0]);
            report.DataSources.Add(rds);
            report.Refresh();

            printDialog.Document = this.printDocument;
            this.printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
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

        public bool Print()
        {
            
            this.pageIndex = 0;

            this.pageStreams.Clear();


            ReportPageSettings rps = this.report.GetDefaultPageSettings();

            float pageWidth = 0f;
            float pageHeight = 0f;
            float marginTop = rps.Margins.Top ;
            float marginLeft = rps.Margins.Left;
            float marginRight = rps.Margins.Right ;
            float marginBottom = rps.Margins.Bottom;

            bool landscape = false;

            
                pageWidth = rps.PaperSize.Height ;
                pageHeight = rps.PaperSize.Width ;

               
            
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
                this.report.Render("Image", ImageDeviceInfo, CreatePrintPageStream, out warnings);
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

                psd.Document = this.printDocument;
                psd.AllowMargins = true;
                psd.AllowPrinter = true;
                psd.AllowPaper = true;
                psd.AllowOrientation = true;
                psd.ShowDialog();
                
                //PrinterSettings printset = new PrinterSettings();

                string s = System.Environment.CurrentDirectory;

                //XmlDocument doc = new XmlDocument();
                //string xmlFile = AppDomain.CurrentDomain.BaseDirectory + "BugsBox.Pharmacy.AppClient.printSet.xml";
                //doc.Load(xmlFile);
                //string s = System.Environment.CurrentDirectory;

                //XmlNodeList nodelist = doc.SelectNodes("/printsets/pageset");

                //int wt = Convert.ToInt16(nodelist[0].Attributes["width"].Value);
                //int ht = Convert.ToInt16(nodelist[1].Attributes["height"].Value);
                //PaperSize pse = new PaperSize();
                //pse.PaperName = "A4";
                //PageSettings pageset = new PageSettings();
                
                //pageset.PaperSize = pse;

                //printset.DefaultPageSettings.PaperSize = pse;
                //psd.PrinterSettings = printset;
                //psd.PageSettings = pageset;
                //psd.PageSettings.PaperSize = pse;
                this.printDocument.PrinterSettings = psd.PrinterSettings;

                this.printDocument.DefaultPageSettings = psd.PageSettings;

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



        private Stream CreatePrintPageStream(string filename, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            //string filePath = string.Format(@"{0}\{1}.{2}", Application.StartupPath, filename, fileNameExtension);

            //Stream pageStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.Delete);

            Stream pageStream = new MemoryStream();

            this.pageStreams.Add(pageStream);

            return pageStream;
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

                if (this.report != null)
                {
                    this.report.Dispose();
                    this.report = null;
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
