using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Sys
{
    public partial class FormModuleWithRole : BaseFunctionForm
    {
        public FormModuleWithRole()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 角色列表
        /// </summary>
        protected List<Role> Roles { get; set; }

        /// <summary>
        /// 用户选择的角色
        /// </summary>
        protected Role SelectedRole { get; set; }


        /// <summary>
        /// 模块分类
        /// </summary>
        protected List<ModuleCatetory> ModuleCatetories { get; set; }

        /// <summary>
        /// 用户选择的模块分类
        /// </summary>
        protected ModuleCatetory SelectedModuleCatetory { get; set; }

        /// <summary>
        /// 模块
        /// </summary>
        protected List<Module> Modules { get; set; }

        /// <summary>
        /// 当前用户所选择的角色的所有模块对应的角色
        /// </summary>
        protected List<ModuleWithRole> ModuleWithRoles { get; set; }

        protected bool AuthChanged { get; set; }

        #region 数据获取

        /// <summary>
        /// 从服务器获取所有角色
        /// </summary>
        /// <returns></returns>
        protected bool GetRoles()
        {
            Roles = null;
            try
            {
                string message;
                Roles = PharmacyDatabaseService.AllRoles(out message)
                    .OrderBy(r => r.Name)
                    .OrderBy(r => r.Code)
                    .ToList();
                if (!string.IsNullOrWhiteSpace(message))
                {
                    throw new Exception(message);
                }
                SelectedRole = Roles.FirstOrDefault();//设置选择的默认
                return true;
            }
            catch (Exception ex)
            {
                Roles = null;
                ex = new Exception("从服务器获取所有角色失败", ex);
                Log.Error(ex);
                MessageBox.Show(this.Text+ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        /// <summary>
        /// 从服务器获取所有模块分类
        /// </summary>
        /// <returns></returns>
        protected bool GetModuleCatetories()
        {
            ModuleCatetories = null;
            try
            {
                string message;
                ModuleCatetories = PharmacyDatabaseService.AllModuleCatetorys(out message)
                    .OrderBy(mc => mc.Name)
                    .OrderBy(mc => mc.Index)
                    .ToList();
                if (!string.IsNullOrWhiteSpace(message))
                {
                    throw new Exception(message);
                }
                SelectedModuleCatetory = ModuleCatetories.FirstOrDefault();//设置选择的默认
                return true;
            }
            catch (Exception ex)
            {
                ModuleCatetories = null;
                ex = new Exception("从服务器获取所有模块分类失败", ex);
                Log.Error(ex);
                MessageBox.Show( this.Text+ex.Message,"错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        /// <summary>
        /// 从服务器获取所有模块
        /// </summary>
        /// <returns></returns>
        protected bool GetModules()
        {
            Modules = null;
            try
            {
                string message;
                Modules = PharmacyDatabaseService.AllModules(out message)
                     .OrderBy(m => m.Name)
                    .OrderBy(m => m.Index)
                    .ToList();
                if (!string.IsNullOrWhiteSpace(message))
                {
                    throw new Exception(message);
                }
                return true;
            }
            catch (Exception ex)
            {
                Modules = null;
                ex = new Exception("从服务器获取所有模块失败", ex);
                Log.Error(ex);
                MessageBox.Show(this.Text+ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        /// <summary>
        ///  根据角色编号获取该角色拥有的模块关系
        /// </summary> 
        /// <returns></returns>
        protected bool GetModuleWithRoles()
        {
            try
            {
                if (SelectedRole != null)
                {
                    string message;
                    ModuleWithRoles = PharmacyDatabaseService.GetModuleWithRolesByRoleId(out message, SelectedRole.Id)
                        .ToList();
                    if (!string.IsNullOrWhiteSpace(message))
                    {
                        ModuleWithRoles = null;
                        return false;
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                ModuleWithRoles = null;
                ex = new Exception("根据角色编号获取该角色拥有的模块关系失败", ex);
                Log.Error(ex);
                MessageBox.Show(this.Text+ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        /// <summary>
        /// 获取某模块分类下面的所有模块
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="modules"></param>
        /// <returns></returns>
        protected List<Module> GetModulesByCategoryId(Guid categoryId, List<Module> modules = null)
        {
            try
            {
                if (modules == null)
                {
                    if (Modules == null)
                    {
                        GetModules();
                        modules = Modules;
                    }
                }
                if (Modules == null) return new List<Module>();
                modules = Modules;
                return modules.Where(m => m.ModuleCatetoryId == categoryId)
                    .ToList();
            }
            catch (Exception ex)
            {
                ex = new Exception("获取某模块分类下面的所有模块失败", ex);
                Log.Error(ex);
                MessageBox.Show(this.Text+ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return new List<Module>();
            }
        }

        #endregion 数据获取

        #region 数据To控件操作

        /// <summary>
        /// 绑定角色数据到角色列表
        /// </summary>
        /// <returns></returns>
        protected bool BindRoles()
        {
            try
            {
                if (Roles != null)
                {
                    this.dataGridViewRoleList.DataSource = Roles;
                }
                return true;
            }
            catch (Exception ex)
            {
                ex = new Exception("绑定角色数据到角色列表失败", ex);
                Log.Error(ex);
                MessageBox.Show(this.Text+ex.Message,"错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        /// <summary>
        /// 绑定模块分类数据到块分类列表
        /// </summary>
        /// <returns></returns>
        protected bool BindModuleCatetories()
        {
            try
            {
                if (ModuleCatetories != null)
                {
                    this.dataGridViewModuleCatetoryList.DataSource = ModuleCatetories;
                }
                return true;
            }
            catch (Exception ex)
            {
                ex = new Exception("绑定模块分类数据到块分类列表失败", ex);
                Log.Error(ex);
                MessageBox.Show(this.Text+ex.Message,"错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        /// <summary>
        /// 绑定用户选择的模块分类的模块
        /// </summary>
        /// <returns></returns>
        protected bool BindSelectedModuleCatetorysModules()
        {
            AuthBinded = false;
            if (SelectedModuleCatetory != null)
            {
                this.flowLayoutPanelModules.Controls.Clear();
                List<Module> modules = GetModulesByCategoryId(SelectedModuleCatetory.Id);
                List<CheckBox> checkBoxes = new List<CheckBox>();
                CheckBox checkBox;
                if (modules != null)
                {
                    foreach (var module in modules)
                    {
                        checkBox = CreaCheckBoxByModule(module);
                        if (checkBox != null)
                        {
                            checkBoxes.Add(checkBox);
                        }
                    }
                }
                this.flowLayoutPanelModules.Controls.AddRange(checkBoxes.ToArray());
            }
            return true;
        }

        /// <summary>
        /// 绑定用户选择的模块分类的模块
        /// </summary>
        /// <returns></returns>
        protected bool BindSelectedRolesModules()
        {
            AuthBinded = false;
            if (SelectedRole != null
                && ModuleWithRoles != null && ModuleWithRoles.Count > 0
                && this.flowLayoutPanelModules.Controls.Count > 0)
            {
                Module tagModule;

                foreach (Control control in this.flowLayoutPanelModules.Controls)
                {
                    var checkBox = control as CheckBox;
                    if (checkBox != null && checkBox.Tag != null)
                    {
                        tagModule = checkBox.Tag as Module;
                        if (tagModule != null)
                        {
                            checkBox.Checked = ModuleWithRoles.Any(mwr => mwr.ModuleId == tagModule.Id);
                        }

                    }
                }
            }
            AuthBinded = true;
            return true;
        }



        #endregion 数据To控件操作

        #region 控件To数据操作

        /// <summary>
        /// 保存授权
        /// </summary>
        /// <returns></returns>
        protected bool SaveAuth(bool showMessage = true)
        {
            try
            {
                //输入条件,角色,大分类,,选择的模块们
                if (SelectedRole != null
                     && SelectedModuleCatetory != null
                    )
                {
                    CheckBox checkBox;
                    Module module;
                    List<Guid> authModuleIds = new List<Guid>();
                    //采集用户选择的
                    foreach (Control control in this.flowLayoutPanelModules.Controls)
                    {
                        checkBox = control as CheckBox;
                        if (checkBox != null)
                        {
                            if (checkBox.Checked)
                            {
                                module = checkBox.Tag as Module;
                                if (module != null)
                                {
                                    authModuleIds.Add(module.Id);
                                }
                            }
                        }
                    }
                    string message;
                    bool result = PharmacyDatabaseService.AuthModuleWithRoleCatetoryAuthModuleIds(out message,
                        SelectedRole, SelectedModuleCatetory, authModuleIds.ToArray());
                    if (result && string.IsNullOrWhiteSpace(message))
                    {
                        if (showMessage)
                            MessageBox.Show(this.Text+"保存授权成功", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnCancel_Click(null, null);
                        return true;
                    }
                    else
                    {
                        if (showMessage)
                            MessageBox.Show( this.Text+"保存授权失败","错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
                if (showMessage) MessageBox.Show(this.Text+"保存授权失败","错误" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex)
            {
                ex = new Exception("保存授权失败", ex);
                Log.Error(ex);
                if (showMessage) MessageBox.Show(this.Text+ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            GetModuleWithRoles();
            BindSelectedRolesModules();
            btnCancel_Click(null, null);
        }

        #endregion 控件To数据操作

        #region 控件事件处理

        /// <summary>
        /// 关闭按钮事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
            this.Close();
        }

        /// <summary>
        /// 刷新按钮事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
            InitForm();
        }

        /// <summary>
        /// 保存按钮事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this.Text+"确认保存当前权限变化", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
                DialogResult.OK)
            {
                SaveAuth(true);
                this.PharmacyDatabaseService.WriteLog( BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, "岗位权限设置成功");
            }
            else
            {
                btnCancel_Click(null, e);
            }
        }

        /// <summary>
        /// 取消按钮事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.AuthChanged = false;
            this.btnCancel.Enabled = false;
            this.btnSave.Enabled = false;
        }

        /// <summary>
        /// 用户点击角色列表单元事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewRoleList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (AuthChanged)
            {
                btnSave_Click(null, null);
            }
            try
            {
                var row = this.dataGridViewRoleList.Rows[e.RowIndex];
                SelectedRole = row.DataBoundItem as Role;
                SelectedModuleCatetory = ModuleCatetories.FirstOrDefault();
                BindModuleCatetories();
                SetDataGridViewModuleCatetoryListDefault();
                BindSelectedModuleCatetorysModules();
                GetModuleWithRoles();
                BindSelectedRolesModules();
                btnCancel_Click(null, null);
            }
            catch (Exception ex)
            {
                SelectedRole = null;
                ex = new Exception("用户点击角色列表单元事件处理失败", ex);
                Log.Error(ex);
                MessageBox.Show(this.Text+ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// 用户点击模块分类单元格处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewModuleCatetoryList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (AuthChanged)
            {
                btnSave_Click(null, null);
            }
            try
            {
                var row = this.dataGridViewModuleCatetoryList.Rows[e.RowIndex];
                SelectedModuleCatetory = row.DataBoundItem as ModuleCatetory;
                BindSelectedModuleCatetorysModules();
                GetModuleWithRoles();
                BindSelectedRolesModules();


            }
            catch (Exception ex)
            {
                SelectedModuleCatetory = null;
                ex = new Exception("用户点击模块分类单元格处理失败", ex);
                Log.Error(ex);
                MessageBox.Show(this.Text+ex.Message,"错误" , MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        #endregion

        #region 控件处理

        protected CheckBox CreaCheckBoxByModule(Module module)
        {
            if (module != null)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = module.Name;
                checkBox.Tag = module;
                checkBox.AutoSize = true;
                checkBox.CheckedChanged += checkBox_CheckedChanged;
                return checkBox;
            }
            return null;
        }

        private bool AuthBinded = false;

        void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null && AuthBinded)
            {
                AuthChanged = true;
                this.btnSave.Enabled = true;
                this.btnCancel.Enabled = true;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode)
                return;
            this.dataGridViewRoleList.AutoGenerateColumns = false;
            this.dataGridViewModuleCatetoryList.AutoGenerateColumns = false;
            InitForm();
        }

        private void InitForm()
        {
            GetRoles();
            GetModuleCatetories();
            GetModules();
            BindRoles();
            BindModuleCatetories();
            SetDataGridViewRoleListDefault();
            SetDataGridViewModuleCatetoryListDefault();
            BindSelectedModuleCatetorysModules();
            GetModuleWithRoles();
            BindSelectedRolesModules();
            btnCancel_Click(null, null);
        }

        /// <summary>
        /// 设置默认的角色选择
        /// </summary>
        private void SetDataGridViewRoleListDefault()
        {
            DataGridViewRowCollection rows = this.dataGridViewRoleList.Rows;
            if (rows.Count < 1) return;
            if (SelectedRole == null)
            {
                if (Roles != null)
                {
                    SelectedRole = Roles.FirstOrDefault();
                }
            }
            if (SelectedRole != null)
            {
                Role role;
                foreach (DataGridViewRow row in rows)
                {
                    role = row.DataBoundItem as Role;
                    if (role != null)
                    {
                        if (role.Id == SelectedRole.Id)
                        {
                            dataGridViewRoleList.ClearSelection();
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 设置默认选择的模块分类
        /// </summary>
        protected void SetDataGridViewModuleCatetoryListDefault()
        {
            DataGridViewRowCollection rows = this.dataGridViewModuleCatetoryList.Rows;
            if (rows.Count < 1) return;
            if (SelectedModuleCatetory == null)
            {
                if (ModuleCatetories != null)
                {
                    SelectedModuleCatetory = ModuleCatetories.FirstOrDefault();
                }
            }
            if (SelectedModuleCatetory != null)
            {
                ModuleCatetory catetory;
                foreach (DataGridViewRow row in rows)
                {
                    catetory = row.DataBoundItem as ModuleCatetory;
                    if (catetory != null)
                    {
                        if (catetory.Id == SelectedModuleCatetory.Id)
                        {
                            dataGridViewModuleCatetoryList.ClearSelection();
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
        }

        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (DataGridView dgv = new DataGridView())
            {
                var c = this.PharmacyDatabaseService.GetRolewithModule().OrderBy(r=>r.RoleName);

                var d = from i in c
                        group i by i.RoleName into g
                        let auths = g.Select(r => r.ModuleName)
                        let authkeys = g.Select(r => r.ModuleAuthKey)
                        select new Business.Models.RoleWithModuleModel
                        {
                             ModuleAuthKey=String.Join(",",authkeys),
                              ModuleName=String.Join(",",auths),
                               RoleName=g.FirstOrDefault().RoleName,
                                RoleCode=g.FirstOrDefault().RoleCode,
                                 RoleDescription=g.FirstOrDefault().RoleDescription
                        };

                this.Controls.Add(dgv);
                dgv.Name = "RoleWithModule";
                dgv.DataSource = d.ToList();
                MyExcelUtls.DataGridview2Sheet(dgv, "岗位权限分配表");
            }
        }
    }
}
