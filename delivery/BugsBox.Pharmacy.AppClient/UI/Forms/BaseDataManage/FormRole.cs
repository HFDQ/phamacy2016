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
using BugsBox.Application.Core;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormRole : BaseFunctionForm
    {
        private Role _role = new Role();
        private PagerInfo pageInfo = new PagerInfo();
        private List<Role> _listRole = new List<Role>();
        private string _serachRole = string.Empty;


        public FormRole()
        {
            InitializeComponent();
            DefineGridColumn();
            
        }

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FormRoleEdit formRoleEdit = new FormRoleEdit(FormOperation.Add);
                if (formRoleEdit.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 修改一个角色
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
                        isChecked=Convert.ToBoolean(dgvData.Rows[i].Cells[0].Value.ToString());
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
                        FormRoleEdit formRoleEdit = new FormRoleEdit(FormOperation.Modify, _listRole[listSelected[0]]);
                        if (formRoleEdit.ShowDialog() == DialogResult.OK)
                        {
                            BindGrid();
                        }
                    }
                    else
                        MessageBox.Show("修改操作每次只能选择一条，请重新选择！", "系统提示");
                }
                else
                    MessageBox.Show("没有可以修改的记录，请至少选择一条记录！", "系统提示");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        /// <summary>
        /// 按条件搜索结果根据分页控件显示在grid上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                _serachRole = txtSearchRole.Text.Trim();
                _listRole = PharmacyDatabaseService.QueryPagedRoles(out pageInfo, _serachRole, string.Empty, string.Empty, DateTime.Now, DateTime.Now.AddDays(-1), DateTime.Now, DateTime.Now.AddDays(-1), pcUserMain.PageIndex, pcUserMain.PageSize).ToList();
                pcUserMain.RecordCount = pageInfo.RecordCount;
                this.dgvData.DataSource = _listRole;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        /// <summary>
        /// 删除一个角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        Role role = _listRole[i];
                        if (!PharmacyDatabaseService.DeleteRole(out msg, role.Id))
                        {
                            MessageBox.Show(string.Format("角色：{0}的记录删除失败", role.Name));
                            return;
                        }
                    }
                    BindGrid();

                    MessageBox.Show("用户数据删除成功！", "系统提示");
                }
                else
                    MessageBox.Show("没有可以删除的记录，请至少选择一条记录！", "系统提示");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Form load 加载grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRole_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    _listRole = PharmacyDatabaseService.QueryPagedRoles(out pageInfo, _serachRole, string.Empty, string.Empty, DateTime.Now, DateTime.Now.AddDays(-1), DateTime.Now, DateTime.Now.AddDays(-1), false, false, pcUserMain.PageIndex, pcUserMain.PageSize).ToList();
            //    pcUserMain.RecordCount = pageInfo.RecordCount;
            //    this.dgvData.DataSource = _listRole;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("角色管理窗口启动失败！", "系统错误");
            //    Log.Error("FormRole:FormRole_Load Error:" + ex);
            //}
        }

        /// <summary>
        /// 分页控件的翻页事件
        /// </summary>
        private void pcUserMain_DataPaging()
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
        /// 根据分页控件的页数绑定grid
        /// </summary>
        private void BindGrid()
        {

            _listRole = PharmacyDatabaseService.QueryPagedRoles(out pageInfo, _serachRole, string.Empty, string.Empty, DateTime.Now, DateTime.Now.AddDays(-1), DateTime.Now, DateTime.Now.AddDays(-1), pcUserMain.PageIndex, pcUserMain.PageSize).ToList();
            this.dgvData.DataSource = _listRole;

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
            dicGridViewTilte.Add("Name", "角色名");
            dicGridViewTilte.Add("Code", "角色代码");
            dicGridViewTilte.Add("Description", "角色描述");
            


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

        
    }
}
