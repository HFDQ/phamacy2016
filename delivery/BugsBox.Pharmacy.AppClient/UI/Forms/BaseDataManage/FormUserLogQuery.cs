using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormUserLogQuery : BaseFunctionForm
    {
        PagerInfo PagerInfo = new PagerInfo();
        string msg = string.Empty;
        public FormUserLogQuery()
        {
            InitializeComponent();
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };

            this.pagerControl1.DataPaging += pagerControl1_DataPaging;

            this.pagerControl1.PageIndex = 1;
        }

        void pagerControl1_DataPaging()
        {
            
            var c = this.PharmacyDatabaseService.GetPagedUserLogs(
                new Business.Models.QueryBusinessUserLogModel
                {
                    DTF = this.dateTimePicker1.Value,
                    DTT = this.dateTimePicker2.Value,
                    Keyword = this.textBox1.Text.Trim()
                }, out this.PagerInfo, this.pagerControl1.PageIndex, this.pagerControl1.PageSize, out msg
            ).ToList();
            this.dataGridView1.DataSource = c;
            this.pagerControl1.RecordCount = PagerInfo.RecordCount;
            this.dataGridView1.Columns["Id"].Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "日志查询列表");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.pagerControl1_DataPaging();
        }
    }
}
