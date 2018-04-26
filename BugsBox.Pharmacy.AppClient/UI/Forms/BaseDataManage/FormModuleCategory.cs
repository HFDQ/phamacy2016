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



namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormModuleCategory : BaseFunctionForm
    {

        private List<ModuleCatetory> _listModuleCategory = new List<ModuleCatetory>();
        public FormModuleCategory()
        {
            InitializeComponent();
            DefineGridColumn();

        }

        /// <summary>
        ///  新增一个功能大类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FormModuleCategoryEdit formRoleEdit = new FormModuleCategoryEdit(FormOperation.Add);
                if (formRoleEdit.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }


        /// <summary>
        /// 选择一个功能类别做修改操作
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
                        //获取选择的一条数据
                        ModuleCatetory category = new ModuleCatetory();
                        category = _listModuleCategory[listSelected[0]];

                        FormModuleCategoryEdit formRoleEdit = new FormModuleCategoryEdit(FormOperation.Modify, category);
                        if (formRoleEdit.ShowDialog() == DialogResult.OK)
                        {
                            BindGrid();
                        }
                    }
                    else
                        MessageBox.Show("只能选择一条数据修改！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        /// <summary>
        /// 选择功能类别删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> listDeleted = new List<int>();
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    //判断是否被选中
                    bool isChecked = false;
                    if (dgvData.Rows[i].Cells[0].Value != null)
                        isChecked = Convert.ToBoolean(dgvData.Rows[i].Cells[0].Value.ToString());
                    else
                        isChecked = false;

                    if (isChecked)
                        listDeleted.Add(i);

                }
                if (listDeleted.Count > 0)
                {

                    if (MessageBox.Show("确定要删除" + listDeleted.Count + "条数据吗？", "系统提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return;
                    }

                    foreach (int i in listDeleted)
                    {
                        string msg = string.Empty;
                        ModuleCatetory category = _listModuleCategory[listDeleted[i]];
                        if (PharmacyDatabaseService.DeleteModuleCatetory(out msg, category.Id))
                        {
                           MessageBox.Show(string.Format("模块大类：{0}的记录删除失败",category.Name), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        /// <summary>
        /// load 事件加载GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormModuleCategory_Load(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex);
            }
        }


        /// <summary>
        /// 定义GRIDView 的显示列
        /// </summary>
        private void DefineGridColumn()
        {
            dgvData.AutoGenerateColumns = false;
            //去掉最左边的空列
            dgvData.RowHeadersVisible = false;

            Dictionary<string, string> dicGridViewTilte = new Dictionary<string, string>();
            dicGridViewTilte.Add("Name", "模块大类");
            dicGridViewTilte.Add("Description", "描述");

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

        /// <summary>
        /// 绑定GridView
        /// </summary>
        public void BindGrid()
        {
            string msg = string.Empty;
            ///Get 所有的Module Category
            _listModuleCategory = PharmacyDatabaseService.AllModuleCatetorys(out msg).ToList();
            dgvData.DataSource = _listModuleCategory;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
