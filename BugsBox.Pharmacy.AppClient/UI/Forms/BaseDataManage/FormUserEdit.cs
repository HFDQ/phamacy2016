using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.Common;
using BugsBox.Pharmacy.Business.Models;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormUserEdit : BaseFunctionForm
    {
        private User _user = null;
        private FormOperation _Operation = new FormOperation();
        public FormUserEdit()
        {
            InitializeComponent();
        }

        public FormUserEdit(FormOperation formOperation)
        {
            InitializeComponent();
            _Operation = formOperation;
            this.Text = "用户新增";
        }

         public FormUserEdit(FormOperation formOperation,User user)
        {
            InitializeComponent();
            _Operation = formOperation;
            _user = user;
            this.Text = "用户修改";
        }


        private void FormUserEdit_Load(object sender, EventArgs e)
        {
            if (_Operation == FormOperation.Modify && _user != null)
                InitUserInfo(_user);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Operation != null)
            {
                string msg = string.Empty;
                
                if (_Operation == FormOperation.Modify || _Operation == FormOperation.Add)
                {
                    if (_Operation == FormOperation.Modify)
                    {
                        bool isable = false;

                        if (rdEnableY.Checked)
                            isable = true;

                        _user.Account = txtAccout.Text.Trim();
                        _user.UpdateTime = DateTime.Now;
                        _user.UpdateUserId = AppClientContext.CurrentUser.Id;
                        _user.Enabled = isable;
                        PharmacyDatabaseService.SaveUser(out msg, _user);
                    }
                    else
                    {
                        User user = GetUser();
                        //判断账号存在性
                        User[] exitsArr = PharmacyDatabaseService.GetUserInfo(out msg, user.Account);
                        if (exitsArr != null && exitsArr.Length > 0)
                        {
                            MessageBox.Show(string.Format("账号：{0}已经存在，不能再创建！", user.Account), "系统信息");
                            return;
                        }
                        else
                        {
                            user.StoreId = user.Id = Guid.NewGuid();
                            user.EmployeeId = AppClientContext.CurrentUser.Id;
                         
                           
                            this.PharmacyDatabaseService.AddUser(out msg, user);
                        }

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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        ///  初始化Role information
        /// </summary>
        /// <param name="role"></param>
        private void InitUserInfo(User user)
        {
            txtAccout.Text = user.Account;
            txtPassword.Text = user.Pwd;
            if (user.Enabled)
                rdEnableY.Checked =true;
            else
                rdEableN.Checked =true;
            
        }

        private User GetUser() 
        {
            User user = new User();
            bool isable = false;

            if (rdEnableY.Checked)
                isable = true;

            user.Account = txtAccout.Text.Trim();
            user.CreateTime = DateTime.Now;
            user.CreateUserId = AppClientContext.CurrentUser.Id;
            user.Pwd = txtPassword.Text.Trim();
            user.Enabled = isable;
            user.UpdateTime = DateTime.Now;
            user.UpdateUserId = AppClientContext.CurrentUser.Id;

            return user;
        }

  
    }
}
