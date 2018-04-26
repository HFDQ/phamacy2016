using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Storage
{
    public partial class FormHisInventeryChecking : BaseFunctionForm
    {
        private string addr = string.Empty;
        private string dbname = string.Empty;
        private string user = string.Empty;
        private string pw = string.Empty;
        System.Data.SqlClient.SqlConnection oleConnection = null;
        string sql = null;
        DataSet dsw = new DataSet();
        DataTable dtn;
        public string docnum = null;
        List<HisCheckInv> list = new List<HisCheckInv>();

        public FormHisInventeryChecking()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;

            XmlDocument doc = new XmlDocument();
            string xmlFile = AppDomain.CurrentDomain.BaseDirectory + "BugsBox.Pharmacy.AppClient.SalePriceType.xml";
            doc.Load(xmlFile);
            XmlNodeList nodeList = doc.SelectNodes("/SalePriceType/photo");
            addr = nodeList[0].Attributes["Address"].Value.ToString();
            dbname = nodeList[0].Attributes["database"].Value.ToString();
            user = nodeList[0].Attributes["user"].Value.ToString();
            pw = nodeList[0].Attributes["pw"].Value.ToString();
            sql = "Data Source=" + addr + ";Initial Catalog=" + dbname + ";User ID=" + user + ";Password=" + pw + ";Min Pool Size=1";
            Search();
        }

        private void Search()
        {

            List<object> list = new List<object>();
            string DocNum = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();

            System.Data.SqlClient.SqlConnection oleConnection = new System.Data.SqlClient.SqlConnection(sql);
            oleConnection.Open();
            DataSet dsSql = new DataSet();
            System.Data.SqlClient.SqlDataAdapter oa = new System.Data.SqlClient.SqlDataAdapter("select * from StorageChecking", oleConnection);

            oa.Fill(dsSql);
            System.Data.SqlClient.SqlCommandBuilder scb = new System.Data.SqlClient.SqlCommandBuilder(oa);

            dtn = dsSql.Tables[0];
            DateTime date = DateTime.Now;
            int j = dtn.Rows.Count;

            var dtnGroup = from i in dtn.AsEnumerable()
                           group i by new { t1 = i.Field<string>("DocumentNum") } into g
                           select new HisCheckInv
                           {
                               operationtime=g.FirstOrDefault().Field<DateTime>("operationTime"),
                               TotalRecord = g.Count(),
                               TotalPrice = g.Sum(p=>p.Field<decimal>("pricecount")),
                               operationuser = g.FirstOrDefault().Field<string>("operationUser"),
                               DocumentNum = g.FirstOrDefault().Field<string>("DocumentNum").ToString()
                           };
            if (dtnGroup != null)
            {
                dataGridView1.DataSource = dtnGroup.ToList();
            }
            oleConnection.Close();
        }

        private class HisCheckInv
        {
            public DateTime? operationtime { get; set; }
            public string DocumentNum { get; set; }
            public decimal TotalPrice { get; set; }
            public decimal TotalRecord { get; set; }
            public string operationuser { get; set; }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                return;
            }
            docnum = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            FormStorageChecking frm = (FormStorageChecking)this.Owner;
            frm.StrValue = docnum;
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PCDSearch();
            }

        }

        private void PCDSearch()
        {
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                return;
            }
            System.Data.SqlClient.SqlConnection oleConnection = new System.Data.SqlClient.SqlConnection(sql);
            oleConnection.Open();
            DataSet dsSql = new DataSet();
            System.Data.SqlClient.SqlDataAdapter oa = new System.Data.SqlClient.SqlDataAdapter("select * from StorageChecking where DocumentNum like '%" + textBox1.Text.Trim()+ "%'", oleConnection);

            oa.Fill(dsSql);
            System.Data.SqlClient.SqlCommandBuilder scb = new System.Data.SqlClient.SqlCommandBuilder(oa);

            dtn = dsSql.Tables[0];
            DateTime date = DateTime.Now;
            var dtnGroup = from i in dtn.AsEnumerable()
                           group i by new { t1 = i.Field<string>("DocumentNum") } into g
                           select new HisCheckInv
                           {
                               operationtime = g.FirstOrDefault().Field<DateTime>("operationTime"),
                               TotalRecord = g.Count(),
                               TotalPrice = g.Sum(p => p.Field<decimal>("pricecount")),
                               operationuser = g.FirstOrDefault().Field<string>("operationUser"),
                               DocumentNum = g.FirstOrDefault().Field<string>("DocumentNum").ToString()
                           };
            if (dtnGroup != null)
            {
                dataGridView1.DataSource = dtnGroup.ToList();
            }
            oleConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                return;
            }
            PCDSearch();
        }

    }
}
