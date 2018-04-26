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
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.Business.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Approval
{
    public partial class FormApprovalFlowCenter : BaseFunctionForm
    {
        /// <summary>
        /// 具体的审核流程ID
        /// </summary>
        private Guid FlowID { get; set; }

        private List<Models.ApprovalFlow> _approveFlowList = new List<Models.ApprovalFlow>();
        private List<ApprovalType> _disFlowTypeList = new List<ApprovalType>();
        private List<ApprovalFlowType> _approveFlowTypeList = new List<ApprovalFlowType>();
        private Dictionary<string, List<ListItem>> _InitFieldValues = new Dictionary<string, List<ListItem>>();
        private DrugInfo druginfo = null;
        /// <summary>
        /// 
        /// </summary>
        public FormApprovalFlowCenter()
        {
            InitializeComponent();
            dgvApprovalList.AutoGenerateColumns = false;
            this.dgvApprovalList.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };

        }

        /// <summary>
        /// 根据审核流程ID打开审核详细
        /// </summary>
        public FormApprovalFlowCenter(Guid flowID):this()
        {            
            FlowID = flowID;
        }

         /// <summary>
        /// 默认打开当前用户所能操作的未审核项
        /// </summary>
        public FormApprovalFlowCenter(params object[] args):this()
        {
            foreach (var typeValue in args)
            {
                _disFlowTypeList.Add((ApprovalType)Convert.ToInt16(typeValue));
                this.Text += string.Format("[{0}]", Utility.getEnumTypeDisplayName<ApprovalType>(_disFlowTypeList[0]));
            }
        }     

        /// <summary>
        /// 根据审核流程ID打开审核详细
        /// </summary>
        public FormApprovalFlowCenter(object approveFlow,Guid flowID):this()
        {
            FlowID = flowID;
        }

        /// <summary>
        /// 根据审核流程ID打开审核详细
        /// </summary>
        public FormApprovalFlowCenter(object druginfo, Guid flowID,bool isVisible):this()
        {
            FlowID = flowID;
            this.label24.Visible = isVisible;
            this.txtOperatorReason.Visible = isVisible;
            this.btnReject.Visible = isVisible;
            this.btnAccept.Visible = isVisible;
            this.druginfo = druginfo as DrugInfo;
        }


        /// <summary>
        /// 画面显示时需要加载的审核数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormApprovalFlowCenter_Load(object sender, EventArgs e)
        {
            string msg = string.Empty;
            _approveFlowTypeList = PharmacyDatabaseService.AllApprovalFlowTypes(out msg).ToList();
            BindApprovalList();
        }

        /// <summary>
        /// 审批通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (this.dgvApprovalList.Rows.Count <= 0) return;
            try
            {
                btnAccept.Enabled = false;
                if (dgvApprovalList.CurrentRow != null)
                {
                    int currRowIndex = dgvApprovalList.CurrentRow.Cells[0].RowIndex;
                    Models.ApprovalFlow approveFlow = _approveFlowList[currRowIndex];
                    string msg = string.Empty;
                    msg = PharmacyDatabaseService.SetApproveAction(approveFlow, "APPROVE", AppClientContext.CurrentUser.Id, string.IsNullOrWhiteSpace(this.txtOperatorReason.Text) ? "无" : this.txtOperatorReason.Text);
                    if (msg.Length > 0)
                        MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        BindApprovalList();
                        BindApprovalNodeList(approveFlow);
                        this.txtOperatorReason.Text = string.Empty;
                        this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行审批记录通过操作成功:("+approveFlow.ChangeNote+")");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btnAccept.Enabled = true;
        }

        /// <summary>
        /// 拒绝审批
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReject_Click(object sender, EventArgs e)
        {
            if (this.dgvApprovalList.Rows.Count <= 0) return;
            if (MessageBox.Show("确定要拒绝该审批吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.OK) return;
            try
            {
                if (dgvApprovalList.CurrentRow != null)
                {
                    int currRowIndex = dgvApprovalList.CurrentRow.Cells[0].RowIndex;
                    Models.ApprovalFlow approveFlow = _approveFlowList[currRowIndex];
                    string msg = string.Empty;
                    msg = PharmacyDatabaseService.SetApproveAction(approveFlow, "REJECT", AppClientContext.CurrentUser.Id, string.IsNullOrWhiteSpace(this.txtOperatorReason.Text) ? "无" : this.txtOperatorReason.Text);
                    if (msg.Length > 0)
                        MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        BindApprovalList();
                        BindApprovalNodeList(approveFlow);
                        this.txtOperatorReason.Text = string.Empty;
                        this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "执行审批记录拒绝操作成功");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 打开详细的审批对象信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvApprovalList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }

                //加入详细画面
                if (dgvApprovalList.Columns[e.ColumnIndex].Name == "查看详细")
                {
                    if (dgvApprovalList.Rows[e.RowIndex].Cells[4].Value != null)
                    {
                        string msg = string.Empty;
                        Models.ApprovalFlow flow = _approveFlowList[e.RowIndex];
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
                                DrugInfo di = this.PharmacyDatabaseService.GetDrugInfoByFlowID(out msg,flow.FlowId);
                                if (di.BusinessScopeCode.Contains("医疗器械"))
                                {
                                    BaseDataManage.FormInstrument frmInstrument = new BaseDataManage.FormInstrument
                                    {
                                        entity=di,
                                    };
                                    Common.SetControls.SetControlReadonly(frmInstrument, true);
                                    frmInstrument.FSE = FormStatusEnum.Read;
                                    frmInstrument.ShowDialog();                                    
                                    return;
                                }
                                else
                                {
                                    ucGoodsInfo ucdi = new ucGoodsInfo(di);
                                    Common.SetControls.SetControlReadonly(ucdi, true);
                                    ucdi.Name = "DetailView";
                                    this.plDetailView.Controls.Add(ucdi);
                                }
                                break;
                            case (int)BugsBox.Pharmacy.Models.ApprovalType.PurchaseUnitApproval:
                            case (int)BugsBox.Pharmacy.Models.ApprovalType.PurchaseUnitEditApproval:
                            case (int)BugsBox.Pharmacy.Models.ApprovalType.PurchaseUnitLockApproval:
                                ucPurchaseUnit ucpu = new ucPurchaseUnit(flow.FlowId);
                                ucpu.Name = "DetailView";
                                this.plDetailView.Controls.Add(ucpu);
                                break;
                            case (int)BugsBox.Pharmacy.Models.ApprovalType.drugsUnqualityApproval:
                                Business.Models.drugsUnqualificationQuery dq = PharmacyDatabaseService.getDrugsUnqualificationQueryByFlowID(flow.FlowId,out msg);
                                ucDrugsUnqualification ucdu = new ucDrugsUnqualification(dq);
                                ucdu.initApprovalDetail(flow.FlowId);
                                ucdu.Name = "DetailView";
                                this.plDetailView.Controls.Add(ucdu);
                                break;
                            case (int)ApprovalType.drugsBreakageApproval:
                                DrugsBreakage db = PharmacyDatabaseService.GetDrugsBreakageByFlowID(flow.FlowId, out msg);
                                UcDrugBreakage ucdb = new UcDrugBreakage(db,flow);
                                ucdb.Name = "DetailView";
                                this.plDetailView.Controls.Add(ucdb);
                                break;
                            case (int)ApprovalType.VehicleApproval:                                
                                Vehicle v = this.PharmacyDatabaseService.GetVehicleByFlowID( flow.FlowId,out msg);
                                if (v == null) return;
                                DataDictionary.FormVehicleEdit frm = new DataDictionary.FormVehicleEdit(v,true);
                                frm.ShowDialog();
                                return;
                            case (int)ApprovalType.DirectSalesApproval:
                                DirectSalesOrder dso = this.PharmacyDatabaseService.GetDirectSalesOrderByFlowId(flow.FlowId, out msg);
                                UCDirectSales UCDS = new UCDirectSales(dso);
                                UCDS.Name = "DetailView";
                                this.plDetailView.Controls.Add(UCDS);
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
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// //打开详细流程记录， 审批流程表(上表)里的一条被选中后，把详细审批过程写入审批流程详细表(下表)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvApprovalList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }

                string msg = string.Empty;
                Models.ApprovalFlow flow = _approveFlowList[e.RowIndex];

                if (this.dgvApprovalNodeList.Tag == null
                    || flow.Id != (Guid)this.dgvApprovalNodeList.Tag)
                {
                    List<ApprovalDetailsModel> approveList = new List<ApprovalDetailsModel>();
                    approveList = PharmacyDatabaseService.GetApprovalDetails(out msg, flow.FlowId, flow.SubFlowId,new object[]{}).ToList();
                    this.dgvApprovalNodeList.AutoGenerateColumns = false;
                    this.dgvApprovalNodeList.DataSource = approveList;
                    this.dgvApprovalNodeList.Tag = flow.Id;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 关闭审批对象信息画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseDetail_Click(object sender, EventArgs e)
        {
            this.plDetailView.Visible = false;
            this.plDetailView.Controls.RemoveByKey("DetailView");
        }


        /// <summary>
        ///  更改Gridview 单元格显示的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvApprovalList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;
            string columnName = this.dgvApprovalList.Columns[e.ColumnIndex].Name;
            if (_InitFieldValues.ContainsKey(columnName))
            {
                if (_InitFieldValues[columnName].Where(l => l.ID == e.Value.ToString()).FirstOrDefault() != null)
                {
                    e.Value = _InitFieldValues[columnName].Where(l => l.ID == e.Value.ToString()).FirstOrDefault().Name;
                }
            }
        }

        /// <summary>
        ///  更改Gridview 单元格显示的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvApprovalNodeList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string columnName = this.dgvApprovalNodeList.Columns[e.ColumnIndex].Name;
            if (columnName == "Status" && e.Value != null)
            {
                e.Value = EnumHelper<ApprovalStatus>.GetDisplayValue(((ApprovalStatus)(int)e.Value));
            }
        }


        private void BindApprovalList() 
        {
            btnCloseDetail_Click(null, null);
            this.dgvApprovalList.AutoGenerateColumns = false;
            //_approveFlowList.Clear();
            _approveFlowList = new List<Models.ApprovalFlow>();
            //未审核流程列表
            string msg = string.Empty;
            if (this.FlowID == Guid.Empty)
            {
                Guid currentUserID = AppClientContext.CurrentUser.Id;
                var List = PharmacyDatabaseService.GetApproveFlowsByUser(out msg, currentUserID).OrderByDescending(r=>r.CreateTime).ToList();
                foreach (var approveFlow in List) 
                {
                    if (_approveFlowTypeList.Exists(e => e.Id == approveFlow.ApprovalFlowTypeId)) 
                    {
                        _approveFlowList.Add(approveFlow);
                    }
                }

            }
            else //获取FlowID指定的审核流程并打开详细
            {
                var flow = PharmacyDatabaseService.GetApproveFlowsByFlowID(out msg, FlowID);
                if (flow == null)
                {
                    this.dgvApprovalList.DataSource = null;
                    MessageBox.Show("指定的审批流程不存在!");
                    this.Close();
                    return;
                }
                _approveFlowList.Add(flow);
            }
            this.dgvApprovalList.DataSource = _approveFlowList;

            //init
            ApprovalFlowType[] flowType = PharmacyDatabaseService.AllApprovalFlowTypes(out msg);
            List<ListItem> flowTypeItems = new List<ListItem>();
            foreach (var m in flowType)
            {
                flowTypeItems.Add(new ListItem(m.Id.ToString(), m.Name));
            }
            if (!_InitFieldValues.ContainsKey("事件"))
            {
                _InitFieldValues.Add("事件", flowTypeItems);
            }
        }


        private void BindApprovalNodeList(Models.ApprovalFlow approveFlow) 
        {
            string msg = string.Empty;
            List<ApprovalDetailsModel> approveList = new List<ApprovalDetailsModel>();
            approveList = PharmacyDatabaseService.GetApprovalDetails(out msg, approveFlow.FlowId, approveFlow.SubFlowId, new object[] { }).ToList();
            this.dgvApprovalNodeList.AutoGenerateColumns = false;
            this.dgvApprovalNodeList.DataSource = approveList;
            this.dgvApprovalNodeList.Tag = approveFlow.Id;
        }

    }
}
