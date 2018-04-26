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
using BugsBox.Pharmacy.Models;
namespace BugsBox.Pharmacy.AppClient.UI.Forms.Sys
{
    public partial class FormDepartmentEdit : BaseFunctionForm
    {
        public FormDepartmentEdit()
        {
            InitializeComponent();
        }
         private Department _dept;
         private FormOperation _Operation = new FormOperation();
         private FormDepartment _deptform;

         public FormDepartmentEdit(FormOperation formOperation,FormDepartment from)
        {
            InitializeComponent();
            this._deptform = from;
            _Operation = formOperation;
            this.Text = "部门新增";

        }

         
         public FormDepartmentEdit(FormOperation formOperation, FormDepartment from,Department dept)
         {
             InitializeComponent();
             this._deptform = from;
             _dept = dept;
             _Operation = formOperation;
             this.Text = "部门修改";
         }

        /// <summary>
        ///  保存信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool isable = false;

                if (rdEnableY.Checked)
                    isable = true;
                if (_Operation == FormOperation.Modify)
                {
                    _dept.Name = txtDepartmentName.Text.Trim();
                    _dept.Code = txtDepartmentCode.Text.Trim();
                    _dept.Decription = rtbDesc.Text.Trim();
                    _dept.Enabled = isable;
                    _deptform.DepartmentInfo = _dept;

                }
                else if (_Operation == FormOperation.Add)
                {
                    Department dept = new Department();
                    dept.Code = txtDepartmentCode.Text.Trim();
                    dept.Decription = rtbDesc.Text.Trim();
                    dept.Name = txtDepartmentName.Text.Trim();
                    dept.Id = dept.StoreId = Guid.NewGuid();
                    dept.Enabled = isable;
                    _deptform.DepartmentInfo = dept;
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                 MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FormDepartmentEdit_Load(object sender, EventArgs e)
        {

            try
            {
                if (_Operation == FormOperation.Modify && _dept != null)
                    InitDepartmentInfo(_dept);
            }
            catch (Exception ex)
            {
                Log.Error("FormRoleEdit:FormRoleEdit_Load Error:" + ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        ///  初始化Department information
        /// </summary>
        /// <param name="role"></param>
        private void InitDepartmentInfo(Department dept)
        {
            txtDepartmentName.Text = dept.Name;
            txtDepartmentName.ReadOnly = false;
            txtDepartmentCode.Text = dept.Code;
            rtbDesc.Text = dept.Decription;
            if (dept.Enabled)
                rdEnableY.Checked = true;
            else
                rdEableN.Checked = true;
        }

       
    }
}
