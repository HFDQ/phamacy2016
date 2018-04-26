using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Sys
{
    public partial class RDLCSet : BaseFunctionForm
    {

        Business.Models.UpdateFiles ServerFile = null;
        Report.DsSalesOrder dsSalesOrder = new Report.DsSalesOrder();
        XDocument XD = null;

        private const int Cm2PixelRate = 30;

        private enum PrintParameters
        {
            ReportTitle
        }

        public RDLCSet()
        {
            InitializeComponent();
            var Files = this.PharmacyDatabaseService.GetUpdateFiles("Reports\\RptSalesOrderList.rdlc");
            if (Files.Count() <= 0)
            {
                MessageBox.Show("警告，服务端报表文件被删除，无法继续，请联系管理员！","警告");
                this.Dispose();
            }

            var RDLCFile=Files.FirstOrDefault();
            System.IO.Stream stream = new System.IO.MemoryStream(RDLCFile.bytes);
            stream.Position = 0;
            XD = XDocument.Load(stream);

            this.Panel1.Width = this.MeasurementTrim(this.GetElementsByTagName("PageWidth").First().Value);
            this.Panel1.Height = this.MeasurementTrim(this.GetElementsByTagName("PageHeight").First().Value);
            this.getParas();
        }

        private void getParas()
        {
            var c=this.GetElementsByTagName("ReportParameter");
            this.listView1.Items.Clear();

            c.ForEach(r=>{
                listView1.Items.Add(r.FirstAttribute.Value);
            });
        }

        public int MeasurementTrim(string value)
        {
            decimal s=decimal.Parse(value.Substring(0,value.Length-2));
            s *= decimal.Round(Cm2PixelRate,0);
            return (int)s;
        }

        private List<XElement> GetElementsByTagName(string TagName)
        {
            System.Xml.Linq.XName TName = System.Xml.Linq.XName.Get(TagName, XD.Root.Name.Namespace.NamespaceName);

            var c = from i in XD.Elements().Descendants().Elements(TName)
                    select i;
            return c.ToList();
        }


        private void RDLCSet_Load(object sender, EventArgs e)
        {
            //this.reportViewer1.RefreshReport();
        }

        

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (XD == null) return;

            System.Xml.XmlDocument xDocument = new System.Xml.XmlDocument();
            using (System.Xml.XmlReader xRead = XD.CreateReader())
            {
                xDocument.Load(xRead);
            }

            System.Xml.Serialization.XmlSerializer xmlSe = new System.Xml.Serialization.XmlSerializer(typeof(System.Xml.XmlDocument));
            byte[] bytes;
            using (System.IO.Stream stream = new System.IO.MemoryStream())
            {
                xmlSe.Serialize(stream, xDocument);
                bytes = new byte[stream.Length];
                stream.Position = 0;
                stream.Read(bytes, 0, bytes.Length);
                stream.Position = 0;
                var c=(System.Xml.XmlDocument)xmlSe.Deserialize(stream);
            }
            //写入RDLC文件
            byte[] b=new byte[bytes.Length];
            using (System.IO.Stream fstream = new System.IO.MemoryStream())
            {
                fstream.Write(bytes,0,b.Length);
                fstream.Position = 0;
                xDocument=(System.Xml.XmlDocument)xmlSe.Deserialize(fstream);
                xDocument.Save("ui\\sale.rdlc");
            }
        }

        private void Panel1_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show(MousePosition.X.ToString());
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
        
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.X>(Panel1.Width-10))Console.WriteLine(e.X);
        }

        private void RDLCSet_Resize(object sender, EventArgs e)
        {
            this.Panel1.Top = 15;
            this.Panel1.Left = Convert.ToInt16((this.Panel1.Parent.Width - this.Panel1.Width) / 2);
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.listView1.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void PageHeader_DragDrop(object sender, DragEventArgs e)
        {
            var c = e.Data.GetData(typeof(ListViewItem));
            if (c == null) return;
            ListViewItem li = (ListViewItem)c;
            TextBox t = new TextBox();
            t.BorderStyle = BorderStyle.FixedSingle;
            t.Text = "@" + li.Text;
            t.Dock = DockStyle.None;
            t.Multiline = true;
            t.Left = e.X;
            t.Top = e.Y;
            e.Effect = DragDropEffects.None;
            this.Panel1.Controls.Add(t);
            t.Left = e.X;
            t.Top = e.Y;
        }

        private void PageHeader_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        
    }
}
