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


namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormModuleCategoryEdit : BaseFunctionForm
    {
        private ModuleCatetory _moduleCategory = null;
        private FormOperation _Operation = new FormOperation();
        public FormModuleCategoryEdit()
        {
            InitializeComponent();
        }

        public FormModuleCategoryEdit(FormOperation formOperation)
        {
            InitializeComponent();
            _Operation = formOperation;
            _moduleCategory = new ModuleCatetory();
            this.Text = "功能模块大类新增";
        }

        public FormModuleCategoryEdit(FormOperation formOperation, ModuleCatetory moduleCategory)
        {
            InitializeComponent();
            _Operation = formOperation;
            _moduleCategory = moduleCategory;
            this.Text = "功能模块大类修改";

        }


        /// <summary>
        /// form load 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRoleEdit_Load(object sender, EventArgs e)
        {
            try
            {
                if (_Operation == FormOperation.Modify && _moduleCategory != null)
                    InitModuleCategory(_moduleCategory);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 修改删除数据保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Operation != null)
            {
                try
                {
                    if (_Operation == FormOperation.Modify || _Operation == FormOperation.Add)
                    {
                        string msg = string.Empty;
                        if (_Operation == FormOperation.Modify)
                        {


                            _moduleCategory.Name = txtModuleCategoryName.Text;
                            _moduleCategory.Description = rtbDesc.Text;
                            this.PharmacyDatabaseService.SaveModuleCatetory(out msg, _moduleCategory);
                        }
                        else
                        {
                            ModuleCatetory moduleCategory = new ModuleCatetory();
                            moduleCategory.Id = moduleCategory.StoreId = Guid.NewGuid();
                            moduleCategory.Name = txtModuleCategoryName.Text;
                            moduleCategory.Description = rtbDesc.Text;

                            this.PharmacyDatabaseService.AddModuleCatetory(out msg, moduleCategory);
                            

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
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Error(ex);
                }
            }
        }

        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        ///  初始化Module Category information
        /// </summary>
        /// <param name="moduleCategory"></param>
        private void InitModuleCategory(ModuleCatetory moduleCategory)
        {
            this.txtModuleCategoryName.Text = moduleCategory.Name;
            this.rtbDesc.Text = moduleCategory.Description;
       
        }


    }
}
