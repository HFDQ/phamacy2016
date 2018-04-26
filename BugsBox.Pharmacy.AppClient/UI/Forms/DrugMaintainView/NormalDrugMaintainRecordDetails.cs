using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugMaintainView
{
    public partial class NormalDrugMaintainRecordDetails : BaseFunctionForm
    {
        public NormalDrugMaintainRecordDetails()
        {
            InitializeComponent();
        }
        public static string BillDocumentNo;
        public static Guid DrugMaintainRecordDetailId;

        private void DrugMaintainRecordDetails_Load(object sender, EventArgs e)
        { 
            txtBillDocumentNo.Text = BillDocumentNo;
            dataGridView1.AutoGenerateColumns = false;
            BindData();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            DrugMaintainRecordDetailId = Guid.Parse( dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            NormalDrugMaintainRecordDetailEdit.IsEdit = true;
            NormalDrugMaintainRecordDetailEdit item = new NormalDrugMaintainRecordDetailEdit();
            item.ShowDialog();
            BindData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            string msg;

            DateTime? Checkdate = null ;
            if (cbCheckDate.Checked)
            {
                Checkdate = Convert.ToDateTime(txtCheckDate.Value);
            }

            List<DrugMaintainRecordDetail> detail = PharmacyDatabaseService.GetDrugMaintainRecordDetailByCondition(out msg,
                  BillDocumentNo, Checkdate).ToList();

            dataGridView1.DataSource = detail; 
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 10 )
            {
                e.Value = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd");
            }
            if (e.ColumnIndex == 11)
            {
                e.Value = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd");
            }
            if (e.ColumnIndex == 16)
            {
                if (e.Value != null)
                {
                    e.Value = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd");
                }
            }
            if (e.ColumnIndex == 15)
            {
                string msg;
                if (e.Value != null)
                {
                    User user = PharmacyDatabaseService.GetUser(out msg, Guid.Parse(e.Value.ToString()));
                    if (user != null)
                    {
                        e.Value = user.Account;
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DrugMaintainRecordDetailId = Guid.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            NormalDrugMaintainRecordDetailEdit.IsEdit = false;
            NormalDrugMaintainRecordDetailEdit item = new NormalDrugMaintainRecordDetailEdit();
            item.ShowDialog();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("您输入的数据格式不正确，请修改！");
        }
    }
}
