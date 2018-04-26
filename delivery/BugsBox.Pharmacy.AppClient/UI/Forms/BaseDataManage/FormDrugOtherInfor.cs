using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using CustomValidatorsLibrary;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.Models;
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Service.Models;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.UI.Forms.Approval;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormDrugOtherInfor : BaseFunctionForm
    {
        private string _searchKeyword = null;
        private DrugInfo entity = new DrugInfo();
        private List<DrugInfo> _listDrugInfo = new List<DrugInfo>();

        BugsBox.Pharmacy.UI.Common.BaseRightMenu brm = null;
        
        private PagerInfo pageInfo = new PagerInfo();     
   
        public FormDrugOtherInfor()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            brm = new Pharmacy.UI.Common.BaseRightMenu(this.dataGridView1);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _searchKeyword = txtSearchKeyword.Text.Trim();
            int pageIndex = 1;
            int pageSize = this.pagerControl1.PageSize;
            GetListDrugInfo(pageIndex, pageSize);
            
            this.pagerControl1.RecordCount = pageInfo.RecordCount;
            this.pagerControl1.PageIndex = 1;
            
        }

        private void GetListDrugInfo(int pageIndex, int pageSize)
        {
            try
            {
                string msg = string.Empty;
                _listDrugInfo = PharmacyDatabaseService.SearchPagedDrugInfosByAllStrings(out pageInfo,
                    out msg, _searchKeyword, pageIndex, pageSize).ToList();
                this.dataGridView1.DataSource = this._listDrugInfo.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK);
                Log.Error(ex);
            }
        }

        

        private void FormDrugOtherInfor_Load(object sender, EventArgs e)
        {
            GetListDrugInfo(1, this.pagerControl1.PageSize);
            this.pagerControl1.RecordCount = pageInfo.RecordCount;
            this.pagerControl1.PageIndex = 1;
            
        }

        private void pagerControl1_DataPaging()
        {
            int pageIndex = this.pagerControl1.PageIndex;
            int pageSize = this.pagerControl1.PageSize;
            GetListDrugInfo(pageIndex, pageSize);            
        }

        private void txtSearchKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                _searchKeyword = txtSearchKeyword.Text.Trim();
                int pageIndex = 1;
                int pageSize = this.pagerControl1.PageSize;
                GetListDrugInfo(pageIndex, pageSize);                
                this.pagerControl1.RecordCount = pageInfo.RecordCount;
                this.pagerControl1.PageIndex = 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string msg = string.Empty;
                DrugInfo drg=_listDrugInfo[dataGridView1.CurrentRow.Index];
                
                if(this.PharmacyDatabaseService.SaveDrugInfo(out msg,drg))
                    this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "修改药品一般信息成功,药品名称"+drg.ProductGeneralName);
                else
                    this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.currentUser.Id, "修改药品一般信息失败,药品名称" + drg.ProductGeneralName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("网络异常，请稍后再提交！\n"+ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _searchKeyword = "";
            int pageIndex = 1;
            int pageSize = this.pagerControl1.PageSize;
            GetListDrugInfo(pageIndex, pageSize);            
            this.pagerControl1.RecordCount = pageInfo.RecordCount;
            this.pagerControl1.PageIndex = 1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _searchKeyword = txtSearchKeyword.Text.Trim();
            int pageIndex = 1;
            int pageSize = this.pagerControl1.PageSize;
            GetListDrugInfo(pageIndex, pageSize);            
            this.pagerControl1.RecordCount = pageInfo.RecordCount;
            this.pagerControl1.PageIndex = 1;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (FormSalePriceControlRules frm = new FormSalePriceControlRules())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }
    }
}
