using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormRoleEdit : BaseFunctionForm
    {
        private Role _role = null;
        private FormOperation _Operation = new FormOperation();
        public FormRoleEdit()
        {
            InitializeComponent();
        }

        public FormRoleEdit(FormOperation formOperation)
        {
            InitializeComponent();
            _Operation = formOperation;
            this.Text = "角色新增";
        }

        public FormRoleEdit(FormOperation formOperation, Role role)
        {
            InitializeComponent();
            _Operation = formOperation;
            _role = role;
            this.Text = "角色修改";
        }


        private void FormRoleEdit_Load(object sender, EventArgs e)
        {
            try
            {
                if (_Operation == FormOperation.Modify && _role != null)
                    InitRoleInfo(_role);
            }
            catch (Exception ex)
            {
                Log.Error( ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Operation != null)
                {
                    string msg = string.Empty;
                    if (_Operation == FormOperation.Modify)
                    {


                        _role.Name = txtRoleName.Text.Trim();
                        _role.Code = txtRoleCode.Text.Trim();
                        _role.Description = rtbDesc.Text;
                        _role.UpdateTime = DateTime.Now;
                        _role.UpdateUserId = AppClientContext.CurrentUser.Id;
                        this.PharmacyDatabaseService.SaveRole(out msg, _role);
                    }
                    else
                    {
                        #region new Role Object and init role
                        Role role = new Role();
                        role.Code = txtRoleCode.Text.Trim();

                        role.Name = txtRoleName.Text.Trim();
                        role.Description = rtbDesc.Text.Trim();
                        role.CreateTime = DateTime.Now;
                        role.Id = role.StoreId = Guid.NewGuid();

                        #endregion
                        this.PharmacyDatabaseService.AddRole(out msg, role);


                    }

                    if (msg.Length == 0)
                    {
                        MessageBox.Show("数据保存成功！", "系统信息");
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                        MessageBox.Show("数据保存失败！", "系统信息");
                }
                
            }
            catch (Exception ex)
            {
                Log.Error( ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        ///  初始化Role information
        /// </summary>
        /// <param name="role"></param>
        private void InitRoleInfo(Role role)
        {
            txtRoleName.Text = role.Name;
            txtRoleCode.Text = role.Code;
            rtbDesc.Text = role.Description;
        }


    }
}
