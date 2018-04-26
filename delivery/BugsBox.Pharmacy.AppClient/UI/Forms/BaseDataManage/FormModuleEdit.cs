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
    public partial class FormModuleEdit : BaseFunctionForm
    {
        private Module _Module = null;
        private FormOperation _Operation = new FormOperation();
        private List<ModuleCatetory> _listModuleCategory = new List<ModuleCatetory>();

        public FormModuleEdit()
        {
            InitializeComponent();
        }

        public FormModuleEdit(FormOperation formOperation)
        {
            InitializeComponent();
            _Operation = formOperation;
            this.Text = "功能模块增加";
        }

        public FormModuleEdit(FormOperation formOperation, Module module)
        {
            InitializeComponent();
            _Operation = formOperation;
            _Module = module;
            this.Text = "功能模块修改";
        }


        private void FormRoleEdit_Load(object sender, EventArgs e)
        {
            try
            {
                GetModuleCategory();
                if (_Operation == FormOperation.Modify && _Module != null)
                    InitModuleInfo(_Module);
                if (_Operation == FormOperation.Add)
                {
                    cmbCategory.DataSource = _listModuleCategory;
                    cmbCategory.DisplayMember = "Name";
                    cmbCategory.ValueMember = "ID";
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
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

                    if (_Operation == FormOperation.Modify || _Operation == FormOperation.Add)
                    {
                        if (_Operation == FormOperation.Modify)
                        {

                            _Module.Name = txtModule.Text.Trim();
                            _Module.Description = rtbDesc.Text.Trim();
                            _Module.AuthKey = txtPriKey.Text.Trim();
                            if (cmbCategory.SelectedValue != null)
                                _Module.ModuleCatetoryId = Guid.Parse(cmbCategory.SelectedValue.ToString());
                            else
                                _Module.ModuleCatetoryId = Guid.Empty;
                            PharmacyDatabaseService.SaveModule(out msg, _Module);
                        }
                        else
                        {
                            Module module = new Module();
                            module.Name = txtModule.Text.Trim();
                            module.Description = rtbDesc.Text.Trim();
                            module.AuthKey = txtPriKey.Text.Trim();
                            if (cmbCategory.SelectedValue != null)
                                module.ModuleCatetoryId = Guid.Parse(cmbCategory.SelectedValue.ToString());
                            else
                                module.ModuleCatetoryId = Guid.Empty;

                            module.Id = module.StoreId = Guid.NewGuid();
                            this.PharmacyDatabaseService.AddModule(out msg, module);

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
            catch (Exception ex)
            {
                Log.Error(ex);
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
        private void InitModuleInfo(Module module)
        {
            if (_Module != null)
            {
                txtModule.Text = _Module.Name;
                rtbDesc.Text = _Module.Description;

                ///绑定模块大类
                cmbCategory.DataSource = _listModuleCategory;
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "ID";
                //将当前的Module的categoryid 设为默认。
                cmbCategory.SelectedValue = _Module.Id;
            }
        }

        /// <summary>
        ///  //Get Module Category
        /// </summary>
        private void GetModuleCategory()
        {
            string msg = string.Empty;
            _listModuleCategory = PharmacyDatabaseService.AllModuleCatetorys(out msg).ToList();

        }

    }
}
