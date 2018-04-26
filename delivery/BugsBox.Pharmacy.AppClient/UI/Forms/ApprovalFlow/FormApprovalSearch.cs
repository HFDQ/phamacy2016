using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.AppClient.UI.UserControls;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Approval
{
    public partial class FormApprovalSearch : BaseFunctionForm
    {
        private List<Models.ApprovalFlow> _approveFlowList = new List<Models.ApprovalFlow>();
        public FormApprovalSearch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面控件内容的初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormApprovalSearch_Load(object sender, EventArgs e)
        {
            BindApproveFlow();
        }

        /// <summary>
        /// 执行查询并显示结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Guid flowTypeId = Guid.Empty;
            if (cmbApprovalType.SelectedValue != null) 
            {
                flowTypeId = (Guid)cmbApprovalType.SelectedValue;
            }
            string msg = string.Empty;
            string changeNote = this.txtChangeString.Text;
            _approveFlowList = PharmacyDatabaseService.GetApproveFlowsInfo(out msg, flowTypeId, changeNote).ToList() ;
            dgvApprovalList.AutoGenerateColumns = false;
            dgvApprovalList.DataSource = _approveFlowList;
           

        }

        /// <summary>
        /// 绑定审核流程类型
        /// </summary>
        private void BindApproveFlow() 
        {
            string msg = string.Empty;
            List<ApprovalFlowType>  approveFlowList = PharmacyDatabaseService.AllApprovalFlowTypes(out msg).ToList();;
            if (approveFlowList == null)
                throw new Exception(msg);
            else
            {
                this.cmbApprovalType.DataSource = approveFlowList;
                this.cmbApprovalType.DisplayMember = "Name";
                this.cmbApprovalType.ValueMember = "Id";
            }
        }

        /// <summary>
        /// 打开详细的审批对象信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvApprovalList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            //加入详细画面
            //this.plDetailView.Container.Add(UserControl);
            if (dgvApprovalList.Columns[e.ColumnIndex].Name == "查看详细")
            {
                Models.ApprovalFlow flow = dgvApprovalList.Rows[e.RowIndex].DataBoundItem as Models.ApprovalFlow;
                if (flow != null)
                {
                    string msg = string.Empty;
                    ApprovalFlowType flowType = PharmacyDatabaseService.GetApprovalFlowType(out msg, flow.ApprovalFlowTypeId);
                    switch (flowType.ApprovalTypeValue)
                    {
                        case (int)BugsBox.Pharmacy.Models.ApprovalType.SupplyUnitApproval:
                        case (int)BugsBox.Pharmacy.Models.ApprovalType.SupplyUnitEditApproval:
                        case (int)BugsBox.Pharmacy.Models.ApprovalType.SupplyUnitLockApproval:
                            ucSupplyUnit uc = new ucSupplyUnit(flow.FlowId);
                            uc.Name = "DetailView";
                            this.plDetailView.Controls.Add(uc);
                            break;
                        case (int)BugsBox.Pharmacy.Models.ApprovalType.DrugInfoApproval:
                        case (int)BugsBox.Pharmacy.Models.ApprovalType.DrugInfoEditApproval:
                        case (int)BugsBox.Pharmacy.Models.ApprovalType.DrugInfoLockApproval:
                            ucGoodsInfo ucdi = new ucGoodsInfo();
                            ucdi.Name = "DetailView";
                            this.plDetailView.Controls.Add(ucdi);
                            break;
                        case (int)BugsBox.Pharmacy.Models.ApprovalType.PurchaseUnitApproval:
                        case (int)BugsBox.Pharmacy.Models.ApprovalType.PurchaseUnitEditApproval:
                        case (int)BugsBox.Pharmacy.Models.ApprovalType.PurchaseUnitLockApproval:
                            ucPurchaseUnit ucpu = new ucPurchaseUnit(flow.FlowId);
                            ucpu.Name = "DetailView";
                            this.plDetailView.Controls.Add(ucpu);
                            break;

                    }
                }

                //显示详细
                this.plDetailView.BringToFront();
                this.plDetailView.Visible = true;
            }
            else //打开详细流程记录， 审批流程表(上表)里的一条被选中后，把详细审批过程写入审批流程详细表(下表)
            {
                dgvApprovalList_RowEnter(sender, e);
            }
        }

        /// <summary>
        /// 打开详细流程记录， 审批流程表(上表)里的一条被选中后，把详细审批过程写入审批流程详细表(下表)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvApprovalList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string msg = string.Empty;
                Models.ApprovalFlow flow = _approveFlowList[e.RowIndex];

                if (this.dgvApprovalNodeList.Tag == null
                    || flow.Id != (Guid)this.dgvApprovalNodeList.Tag)
                {
                    List<ApprovalFlowRecord> approveList = new List<ApprovalFlowRecord>();
                    approveList = PharmacyDatabaseService.GetFinishApproveFlowsRecord(out msg, flow.FlowId, flow.SubFlowId).OrderBy(p=>p.CreateTime).ToList();
                    this.dgvApprovalNodeList.AutoGenerateColumns = false;
                    this.dgvApprovalNodeList.DataSource = approveList;
                    this.dgvApprovalNodeList.Tag = flow.Id;
                }
            }
        }

        private void dgvApprovalList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string msg = string.Empty;
            if (dgvApprovalList.Columns[e.ColumnIndex].Name.Equals("事件"))
            {
                Guid typeId = Guid.Parse(e.Value.ToString());
                ApprovalFlowType type = PharmacyDatabaseService.GetApprovalFlowType(out msg, typeId);
                e.Value = type.Name;
            }
            else if (dgvApprovalList.Columns[e.ColumnIndex].Name.Equals("状态"))
            {
                BugsBox.Pharmacy.Models.ApprovalStatus status = (BugsBox.Pharmacy.Models.ApprovalStatus)int.Parse(e.Value.ToString());

                var f = typeof(BugsBox.Pharmacy.Models.ApprovalStatus).GetField(status.ToString());

                var attr = f.GetCustomAttributes(false);
                if (attr.Length > 0 && attr[0] as System.ComponentModel.DataAnnotations.DisplayAttribute != null)
                {
                    e.Value = (attr[0] as System.ComponentModel.DataAnnotations.DisplayAttribute).Name;
                }
                else
                {
                    e.Value = "状态异常";
                }
            }
        }

        private void dgvApprovalNodeList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var grid = sender as DataGridView;

            if (grid.Columns[e.ColumnIndex].Name.Equals("审批人"))
            {
                Guid userId = Guid.Parse(e.Value.ToString());
                string msg = string.Empty;
                User user = PharmacyDatabaseService.GetUser(out msg, userId);
                e.Value = user.Account;
            }
            else if (grid.Columns[e.ColumnIndex].Name.Equals("序号"))
            {
                //给序号列添加默认序号
                e.Value = e.RowIndex + 1;
            }
        }

        private void btnCloseDetail_Click(object sender, EventArgs e)
        {
            this.plDetailView.Visible = false;
            this.plDetailView.Controls.RemoveByKey("DetailView");
        }
    }
}
