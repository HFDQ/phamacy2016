using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.UI.Common;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Models;


namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormRoleWithUser : BaseFunctionForm
    {
        public FormRoleWithUser()
        {
            InitializeComponent();
        }

        private List<User> UserList { get; set; }
        private List<Role> RoleList { get; set; }
        List<RoleWithUser> SelectedUsersRoles { get; set; }
        private User SelectedUser { get; set; }
        private bool UsersRolesSetted { get; set; }

        private void LoadSelectedUsersRoles()
        {
            if (SelectedUser == null) return;
            SelectedUsersRoles = null;
            try
            {
                string message = string.Empty;
                SelectedUsersRoles = PharmacyDatabaseService
                    .AllRoleWithUsers(out message)
                    .Where(rwu => rwu.UserId == SelectedUser.Id)
                    .ToList();

            }
            catch (Exception ex)
            {
                SelectedUsersRoles = null;
                ex = new Exception("获取用户或角色数据失败!", ex);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void LoadInitDataFromServer()
        {
            try
            {
                string message = string.Empty;
                UserList = PharmacyDatabaseService.AllUsers(out message).OrderBy(r=>r.Employee.Name).ToList();
                RoleList = PharmacyDatabaseService.AllRoles(out message).ToList();
                SelectedUser = UserList.FirstOrDefault();//给个默认
            }
            catch (Exception ex)
            {
                ex = new Exception("获取用户或角色数据失败!", ex);
                Log.Error(ex);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BindUserList()
        {
            if (UserList == null) return;
            try
            {
                this.dataGridViewUserList.AutoGenerateColumns = false;
                this.dataGridViewUserList.DataSource = UserList;
            }
            catch (Exception ex)
            {
                ex = new Exception("绑定用户信息失败!", ex);
                Log.Error(ex);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BindRoleList()
        {
            if (RoleList == null) return;
            try
            {
                flowLayoutPanel1.Controls.Clear();
                foreach (var role in RoleList)
                {
                    CheckBox checkBox = CreateRoleCheckBox(role);
                    if (checkBox != null)
                    {
                        flowLayoutPanel1.Controls.Add(checkBox);
                    }

                }
            }
            catch (Exception ex)
            {
                ex = new Exception("绑定用户信息失败!", ex);
                Log.Error(ex);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private CheckBox CreateRoleCheckBox(Role role)
        {
            if (role == null) return null;
            CheckBox checkBox = new CheckBox();
            checkBox.Text = role.Name;
            checkBox.Tag = role;
            checkBox.CheckedChanged += new EventHandler(checkBox_CheckedChanged);
            return checkBox;
        }

        void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!UsersRolesSetted) return;
            if (SelectedUsersRoles == null) return;
            CheckBox checkBox = sender as CheckBox;
            string message = string.Empty;
            if (checkBox != null)
            {
                Role role = checkBox.Tag as Role;
                if (checkBox.Checked)
                {
                    //选中了
                    if (!SelectedUsersRoles.Any(ur => ur.RoleId == role.Id && ur.Id == SelectedUser.Id))
                    {
                        //原来没有则添加
                        RoleWithUser rwu = new RoleWithUser();
                        rwu.Id = Guid.NewGuid();
                        rwu.RoleId = role.Id;
                        rwu.UserId = SelectedUser.Id;
                        PharmacyDatabaseService.AddRoleWithUser(out message, rwu);
                        this.PharmacyDatabaseService.WriteLog(AppClientContext.CurrentUser.Id, "员工岗位信息设置成功！");
                    }
                }
                else
                {
                    //没选
                    RoleWithUser rwu = SelectedUsersRoles.FirstOrDefault(ur => ur.RoleId == role.Id && ur.UserId == SelectedUser.Id);
                    if (rwu != null)
                    {
                        PharmacyDatabaseService.DeleteRoleWithUser(out message, rwu.Id);
                    }
                }
                LoadSelectedUsersRoles();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadInitDataFromServer();
            BindUserList();
            BindRoleList();
            LoadSelectedUsersRoles();
            SetUserWithRoles();
        }

        private void SetUserWithRoles()
        {
            UsersRolesSetted = false;
            if (SelectedUser == null) return;
            if (SelectedUsersRoles == null) return;
            try
            {
                foreach (CheckBox checkBox in flowLayoutPanel1.Controls)
                {
                    Role role = checkBox.Tag as Role;
                    checkBox.Checked = role != null && SelectedUsersRoles.Any(ur => ur.RoleId == role.Id);
                }
            }
            catch (Exception ex)
            {
                ex = new Exception("设置用户关联的角失败!", ex);
                Log.Error(ex);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            UsersRolesSetted = true;
        }
 
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            LoadInitDataFromServer();
            BindUserList();
            BindRoleList();
            LoadSelectedUsersRoles();
            SetUserWithRoles();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                DataGridViewRow currentRow = this.dataGridViewUserList.Rows[e.RowIndex];
                User user = currentRow.DataBoundItem as User;
                if (user != null)
                {
                    SelectedUser = user;
                    LoadSelectedUsersRoles();
                    SetUserWithRoles();
                }

            }
            catch (Exception ex)
            {
                ex = new Exception("列表单击处理失败!", ex);
                Log.Error(ex);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void dataGridViewUserList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return; 
            try
            {
                DataGridViewRow currentRow = this.dataGridViewUserList.Rows[e.RowIndex];
                User user = currentRow.DataBoundItem as User;
                if (user != null)
                {
                    DataGridViewTextBoxCell employeeCell = currentRow.Cells[colEmployeeInfo.Name] as DataGridViewTextBoxCell;
                    if (employeeCell != null && user.Employee != null)
                    {
                        employeeCell.Value = string.Format("{0}(部门:{1})", user.Employee.Name, user.Employee.Department.Name);
                    }
                    DataGridViewTextBoxCell statusCell = currentRow.Cells[colStatus.Name] as DataGridViewTextBoxCell;
                    if (statusCell != null)
                    {
                        statusCell.Value = user.Enabled ? "正常" : "禁用";
                    }
                }

            }
            catch (Exception ex)
            {
                ex = new Exception("绘制行数据失败!", ex);
                Log.Error(ex); 
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            

            using (DataGridView dgv = new DataGridView())
            {
                this.Controls.Add(dgv);
                var c = this.PharmacyDatabaseService.GetRolewithUser().OrderBy(r => r.EmployeeName);

                var d = from i in c
                        group i by i.EmployeeName into g
                        let roles = g.Select(r => r.RoleName)
                        let rolecode=g.Select(r=>r.RoleCode)
                        select new Business.Models.RoleWithUserModel
                        {
                             RoleName=String.Join(",",roles),
                              EmployeeName=g.FirstOrDefault().EmployeeName,
                               Password=g.FirstOrDefault().Password,
                                RoleCode=String.Join(",",rolecode),
                                 RoleDescription=string.Empty,
                                  UserAcount=g.FirstOrDefault().UserAcount
                        };
                      

                dgv.DataSource = d.OrderBy(r=>r.EmployeeName).ToList();
                dgv.AutoGenerateColumns = false;
                MyExcelUtls.DataGridview2Sheet(dgv, "员工岗位分配表");
            }
        }
    }
}
