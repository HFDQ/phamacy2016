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
using BugsBox.Pharmacy.Models;
using BugsBox.Application.Core;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormModule : BaseFunctionForm
    {
        private List<Module> _lstModule = new List<Module>();
        private PagerInfo pageInfo = new PagerInfo();
        private List<ModuleCatetory> _lstModuleCategory = new List<ModuleCatetory>();
        Dictionary<string, string> dicGridViewTilte = new Dictionary<string, string>();
        private string  _module = string.Empty;

        public FormModule()
        {
            InitializeComponent();
            DefineGridColumn();

        }

        /// <summary>
        /// 功能模块新增操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FormModuleEdit formModuleEdit = new FormModuleEdit(FormOperation.Add);
                if (formModuleEdit.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error( ex);
            }

        }
        
        /// <summary>
        ///  功能模块修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> listSelected = new List<int>();
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    //判断是否被选中
                    bool isChecked = false;
                    if (dgvData.Rows[i].Cells[0].Value != null)
                        isChecked = Convert.ToBoolean(dgvData.Rows[i].Cells[0].Value.ToString());
                    else
                        isChecked = false;
                    if (isChecked)
                        listSelected.Add(i);

                }
                int selectCount = listSelected.Count;
                if (selectCount > 0)
                {
                    if (selectCount == 1)
                    {
                        Module module = _lstModule[listSelected[0]];
                        FormModuleEdit formModuleEdit = new FormModuleEdit(FormOperation.Modify, module);
                        if (formModuleEdit.ShowDialog() == DialogResult.OK)
                        {
                            BindGrid();
                        }
                    }
                    else
                        MessageBox.Show("修改操作每次只能选择一条，请重新选择！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                      MessageBox.Show("没有可以修改的记录，请至少选择一条记录！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> listDelted = new List<int>();
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    //判断是否被选中

                    bool isChecked = false;
                    if (dgvData.Rows[i].Cells[0].Value != null)
                        isChecked = Convert.ToBoolean(dgvData.Rows[i].Cells[0].Value.ToString());
                    else
                        isChecked = false;
                    if (isChecked)
                        listDelted.Add(i);

                }
                if (listDelted.Count > 0)
                {

                    if (MessageBox.Show("确定要删除" + listDelted.Count + "条数据吗？", "系统提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return;
                    }

                    foreach (int i in listDelted)
                    {
                        string msg = string.Empty;
                        Module module = _lstModule[listDelted[i]];
                        if (!PharmacyDatabaseService.DeleteModule (out msg, module.Id))
                        {
                            MessageBox.Show("功能模块：{0}的记录删除失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    BindGrid();

                    MessageBox.Show("用户数据删除成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("没有可以删除的记录，请至少选择一条记录！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }

        private void pcUserMain_DataPaging()
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("用户管理窗口查询翻页失败！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 根据分页控件的页数绑定grid
        /// </summary>
        private void BindGrid()
        {

            //_lstModule = PharmacyDatabaseService.QueryPagedModules(out pageInfo, _module, string.Empty, string.Empty,pcUserMain.PageIndex, pcUserMain.PageSize).ToList();
            //this.dgvData.DataSource = _lstModule;
            

        }

        /// <summary>
        /// 定义GRIDView 的显示列
        /// </summary>
        private void DefineGridColumn()
        {
            dgvData.AutoGenerateColumns = false;
            //去掉最左边的空列
            dgvData.RowHeadersVisible = false;           
            dicGridViewTilte.Add("Name", "模块名称");
            //dicGridViewTilte.Add("ModuleCatetory", "模块大类");
            dicGridViewTilte.Add("Description", "模块描述");
            dicGridViewTilte.Add("AuthKey", "授权Key");
        

            //根据字典构造DataGridView 列
            foreach (KeyValuePair<string, string> kv in dicGridViewTilte)
            {
                DataGridViewTextBoxColumn dgvtb = new DataGridViewTextBoxColumn();
                dgvtb.DataPropertyName = kv.Key;
                dgvtb.HeaderText = kv.Value;
                this.dgvData.Columns.Add(dgvtb);
            }

            //增加一列checkbox 列
            dgvData.Columns.Insert(0, new DataGridViewCheckBoxColumn(false));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    _module = txtModule.Text.Trim();

            //    _lstModule = PharmacyDatabaseService.QueryPagedModules(out pageInfo, _module, string.Empty, string.Empty, pcUserMain.PageIndex, pcUserMain.PageSize).ToList();
            //    pcUserMain.RecordCount = pageInfo.RecordCount;
            //    this.dgvData.DataSource = _lstModule;
            //}
            //catch (Exception ex)
            //{
            //    Log.Error(ex);
            //   MessageBox.Show("用户查询操作失败！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        /// <summary>
        /// load 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormModule_Load(object sender, EventArgs e)
        {
            ////BindModuleCategory();
            //try
            //{
            //    _lstModule = PharmacyDatabaseService.QueryPagedModules(out pageInfo, string.Empty, string.Empty, string.Empty, false, true, pcUserMain.PageIndex, pcUserMain.PageSize).ToList();
            //    pcUserMain.RecordCount = pageInfo.RecordCount;
            //    this.dgvData.DataSource = _lstModule;
            //}
            //catch (Exception ex)
            //{
            //    Log.Error("FormModule:FormUser_Load Error:" + ex);
            //    MessageBox.Show("功能模块窗口启动失败！", "系统错误");

            //}
        }

    }
}
