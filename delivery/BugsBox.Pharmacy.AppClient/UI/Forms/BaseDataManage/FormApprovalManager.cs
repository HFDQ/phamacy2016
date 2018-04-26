using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.UI.Common.Helper;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormApprovalManager : BaseFunctionForm
    {
        private ComponentResourceManager Resource = new ComponentResourceManager(typeof(FormApprovalManager));
        public FormApprovalManager()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 画面初始化jiijooo
        /// <param name="e"></param>
        private void FormApprovalManager_Load(object sender, EventArgs e)
        {
            initForm();
        }

        /// <summary>
        /// 刷新画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            initForm();
        }

        /// <summary>
        /// 审批流程分类变化时的处理（供应商，采购商，药品）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void cmbApprovalFlowCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            initApprovalFlowTypeListBox(cmbApprovalFlowCat.SelectedValue);
        }

        /// <summary>
        /// 审批流程类型变更时，获取流程节点等信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbApprovalFlowType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbApprovalFlowType.SelectedValue == null)
            {
                this.txtDecription.Text = "";
                this.dgvApprovalNodeList.DataSource = null;
                return;
            }

            var flowTypeID = (Guid)lbApprovalFlowType.SelectedValue;
            refreshApprovalFlowTypeInfo(flowTypeID);
        }

        /// <summary>
        /// 增加节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.lbApprovalFlowType.SelectedValue != null)
            {
                var nodelist = this.dgvApprovalNodeList.DataSource as List<ApprovalFlowNode>;
                if (nodelist == null || nodelist.Count == 0)
                {
                    nodelist = new List<ApprovalFlowNode>();
                }
                nodelist.Add(new ApprovalFlowNode
                {
                    Id = Guid.Empty,
                    Order = nodelist.Count + 1,
                    ApprovalFlowTypeId = (Guid)this.lbApprovalFlowType.SelectedValue,
                    Name = "",
                    Decription = ""
                });
                this.dgvApprovalNodeList.DataSource = null;
                this.dgvApprovalNodeList.DataSource = nodelist;
            }
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvApprovalNodeList.SelectedRows.Count > 0)
            {
                var nodelist = this.dgvApprovalNodeList.DataSource as List<ApprovalFlowNode>;

                foreach(DataGridViewRow row in this.dgvApprovalNodeList.SelectedRows){
                    var node = row.DataBoundItem as ApprovalFlowNode;
                    if (node != null)
                    {
                        nodelist.Remove(node);
                    }
                }
                
                this.dgvApprovalNodeList.DataSource = null;

                int i = 1;
                nodelist.ForEach(p => p.Order = i++);
                this.dgvApprovalNodeList.DataSource = nodelist;
            }
        }

        /// <summary>
        /// 保存更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //强制表格更新数据。
            this.dgvApprovalNodeList.EndEdit();

            //获取审批流程ID
            var flowTypeID = (Guid)lbApprovalFlowType.SelectedValue;

            var nodelist = this.dgvApprovalNodeList.DataSource as List<ApprovalFlowNode>;
            if (nodelist.Count == 0)
            {
                MessageBox.Show("不能删除所有的节点!");
                return;
            }
            else
            {
                foreach (var node in nodelist)
                {
                    if (string.IsNullOrWhiteSpace(node.Name))
                    {
                        MessageBox.Show("节点名字为必须字段!");
                        return;
                    }
                    if(node.RoleId == Guid.Empty){
                        MessageBox.Show("节点的权限为必须字段!");
                        return;
                    }
                }
            }

            //删除丢弃的节点信息
            string message;
            foreach (var node in PharmacyDatabaseService.AllApprovalFlowNodes(out message).Where(p => p.ApprovalFlowTypeId == flowTypeID).ToList())
            {
                //已经被删掉了的话,则删除
                if (nodelist.FirstOrDefault(p => p.Id == node.Id) == null)
                {
                    if (!PharmacyDatabaseService.DeleteApprovalFlowNode(out message, node.Id))
                    {
                        MessageBox.Show("保存失败!" + Environment.NewLine + message);
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, node.Name + "审批流程删除成功！");
                }
            }

            foreach (var node in nodelist)
            {
                node.UpdateUserId = AppClientContext.CurrentUser.Id;
                node.UpdateTime = DateTime.Now;
                //说明是新增的数据
                if (node.Id == Guid.Empty)
                {
                    node.Id = Guid.NewGuid();
                    node.CreateTime = DateTime.Now;
                    node.CreateUserId = AppClientContext.CurrentUser.Id;
                    if (!PharmacyDatabaseService.AddApprovalFlowNode(out message, node))
                    {
                        MessageBox.Show("保存失败!" + Environment.NewLine + message);
                        return;
                    }
                    this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, node.Name+"审批流程设置成功！");
                }
                else
                {
                    //更新序号
                    if (!PharmacyDatabaseService.SaveApprovalFlowNode(out message, node))
                    {
                        MessageBox.Show("保存失败!" + Environment.NewLine + message);
                        return;
                    }
                }
            }

            MessageBox.Show("保存成功!");
        }

        /// <summary>
        /// 
        /// </summary>
        private void gotoServerToSave(Guid flowTypeID, List<ApprovalFlowNode> nodeList)
        {
            string message;
            ApprovalFlowType flowType = PharmacyDatabaseService.GetApprovalFlowType(out message, flowTypeID);
            flowType.ApprovalFlowNodes = nodeList.ToArray();

        }

        /// <summary>
        /// 放弃变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            var flowTypeID = (Guid)lbApprovalFlowType.SelectedValue;
            refreshApprovalFlowTypeInfo(flowTypeID);
        }

        /// <summary>
        /// 
        /// </summary>
        private void initForm()
        {
            //审批流程分类初始化
            var list = Utility.CreateComboboxList<BugsBox.Pharmacy.Models.ApprovalType>();
            list.Insert(0, new ListItem(null, "所有审批流程"));
            this.cmbApprovalFlowCat.DisplayMember = "Name";
            this.cmbApprovalFlowCat.ValueMember = "ID";
            this.cmbApprovalFlowCat.DataSource = list;

            //审批流程类型初始化
            initApprovalFlowTypeListBox(null);

            //审批人角色下拉框初始化
            string message;
            var roles = PharmacyDatabaseService.AllRoles(out message).ToList();

            //增加一个空节点
            roles.Insert(0, new Role {
                Id = Guid.Empty,
                Name = ""
            });
            this.roleBindingSource.DataSource = roles;
            this.审批人角色.DisplayMember = "Name";
            this.审批人角色.ValueMember = "Id";
        }

        /// <summary>
        /// 初始化审批流程类型的listbox数据
        /// </summary>
        /// <param name="type"></param>
        private void initApprovalFlowTypeListBox(object type)
        {
            //审批流程类型初始化
            string resultMsg;
            var list2 = PharmacyDatabaseService.AllApprovalFlowTypes(out resultMsg).OrderBy(r=>r.Name).ToArray();
            if (type != null)
            {
                int iType = int.Parse(type.ToString());
                list2 = list2.Where(p => p.ApprovalTypeValue == iType).OrderBy(r=>r.Name).ToArray();
            }
            this.lbApprovalFlowType.DisplayMember = "Name";
            this.lbApprovalFlowType.ValueMember = "Id";
            this.lbApprovalFlowType.DataSource = list2.ToList();
        }

        /// <summary>
        /// 获取审批流程最新情报并更新到画面
        /// </summary>
        /// <param name="flowTypeID"></param>
        private void refreshApprovalFlowTypeInfo(Guid flowTypeID)
        {
            string message;
            //获取描述信息
            var desp = PharmacyDatabaseService.GetApprovalFlowType(out message, flowTypeID).Decription;
            this.txtDecription.Text = desp;

            //获取节点信息
            var nodelist = PharmacyDatabaseService.AllApprovalFlowNodes(out message).Where(p => p.ApprovalFlowTypeId == flowTypeID).OrderBy(p => p.Order).ToList();
            if (nodelist != null)
            {
                this.dgvApprovalNodeList.AutoGenerateColumns = false;
                this.dgvApprovalNodeList.DataSource = nodelist;
            }
        }
    }
}
