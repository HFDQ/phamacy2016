using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.UI.Forms.Common;
using BugsBox.Pharmacy.Business.Models;


namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    using RetailPaymentMethod = BugsBox.Pharmacy.Models.RetailPaymentMethod;
    using RetailCustomerType = BugsBox.Pharmacy.Models.RetailCustomerType;
    using BugsBox.Pharmacy.Service.Models;
    using BugsBox.Application.Core;

    public partial class FormDrugInfoUnlock : BaseFunctionForm
    {
        private List<DrugInfo> _listDrugInfos = new List<DrugInfo>();
        private PagerInfo pageInfo = new PagerInfo();
        ContextMenuStrip cms = new ContextMenuStrip();
        string msg = string.Empty;
        
        public FormDrugInfoUnlock()
        {
            try
            {
                InitializeComponent();
                this.RighMenu();
                this.dgvMain.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDrugInfoUnlock_Load(object sender, EventArgs e)
        {
            this.search();
        }

        //查询方法
        private void search()
        {
            try
            {
                int pageIndex = this.pcMain.PageIndex;
                int pageSize = this.pcMain.PageSize;

                string msg = string.Empty;
                var c = this.PharmacyDatabaseService.GetDrugInfoByCondition(string.Empty, pageIndex, pageSize, out pageInfo, true, out msg);
                this.dgvMain.DataSource = c.ToList();
                this.pcMain.RecordCount = pageInfo.RecordCount;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void pcMain_DataPaging()
        {
            this.search();
        }
        
        private void RighMenu()
        {
            cms.Items.Add("查看品种信息", null, delegate(object sender, EventArgs e) { this.GetDrugInfo(0); });
            cms.Items.Add("-");
            cms.Items.Add("查看审批情况", null, delegate(object sender, EventArgs e) { this.GetDrugInfo(1); });            
            cms.Items.Add("-");
            cms.Items.Add("导出品种信息", null, delegate(object sender, EventArgs e) { this.GetDrugInfo(2); });
        }
        //右键菜单事件
        private void GetDrugInfo(int Method)
        {
            if (this.dgvMain.SelectedRows.Count <= 0) return;
            var c = this.dgvMain.SelectedRows[0].DataBoundItem as Business.Models.DrugInfoModel;
            DrugInfo di = this.PharmacyDatabaseService.GetDrugInfo(out msg, c.id);
            if (di == null) return;
            if (Method == 0)
            {
                UI.UserControls.ucGoodsInfo ucControl = new UserControls.ucGoodsInfo(di);
                Form f = new Form();
                f.WindowState = FormWindowState.Normal;
                f.StartPosition = FormStartPosition.CenterScreen;
                f.Text = di.ProductGeneralName;
                f.AutoSize = true;
                f.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                Panel p = new Panel();
                p.AutoSize = true;
                p.Controls.Add(ucControl);
                f.Controls.Add(p);
                SetControls.SetControlReadonly(f, true);
                f.ShowDialog();
            }

            if (Method == 1)
            {
                Forms.Approval.FormApprovalFlowCenter form = new Forms.Approval.FormApprovalFlowCenter(di, di.FlowID, false);
                form.ShowDialog();
            }

            if (Method == 2)
            {
                MyExcelUtls.DataGridview2Sheet(this.dgvMain, "已锁定品种信息查询结果");
            }
        }

        private void dgvMain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            Business.Models.DrugInfoModel dm = this.dgvMain.Rows[e.RowIndex].DataBoundItem as Business.Models.DrugInfoModel;
            if (dm == null) return;
            this.dgvMain.ClearSelection();
            this.dgvMain.Rows[e.RowIndex].Selected = true;
            this.cms.Show(MousePosition.X, MousePosition.Y);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dgvMain, "已锁定品种信息查询结果");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.search();
        }
    }
}
