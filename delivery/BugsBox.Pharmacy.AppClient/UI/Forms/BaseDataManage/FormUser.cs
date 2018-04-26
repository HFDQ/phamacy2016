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
    public partial class FormUser : BaseFunctionForm
    {
        private PagerInfo pageInfo = new PagerInfo();
        private List<User> _lstUser = new List<User>();
        private string _searchAccount = string.Empty;
        public FormUser()
        {
            InitializeComponent();
            DefineGridColumn();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FormUserEdit formUserEdit = new FormUserEdit(FormOperation.Add);
                if (formUserEdit.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
            catch (Exception ex)
            { 
                Log.Error(ex);
               MessageBox.Show("角色管理窗口启动失败！", "系统错误");
               
            }
        }

        /// <summary>
        /// 翻页显示User Data
        /// </summary>
        private void pcUserMain_DataPaging()
        {
            try
            {
                BindGrid();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
               MessageBox.Show("用户管理窗口查询翻页失败！", "系统错误");
            }
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            try
            {
                //第一次加载太慢了
                //_lstUser = PharmacyDatabaseService.QueryPagedUsers(out pageInfo, txtSearchUser.Text, string.Empty, txtSearchAccount.Text, string.Empty, string.Empty, DateTime.Now, DateTime.Now.AddDays(-1), string.Empty, string.Empty, string.Empty, DateTime.Now, DateTime.Now.AddDays(-1), DateTime.Now, DateTime.Now.AddDays(-1), false, false, 2, 1, 2, 1, 2, 1, false, false, pcUserMain.PageIndex, pcUserMain.PageSize).ToList();
                //pcUserMain.RecordCount = pageInfo.RecordCount;
                //this.dgvData.DataSource = _lstUser;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("用户管理窗口启动失败！", "系统错误");
                
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
                _searchAccount = txtSearchAccount.Text.Trim();
                _lstUser = PharmacyDatabaseService.QueryPagedUsers(out pageInfo, _searchAccount, string.Empty, DateTime.Now, DateTime.Now.AddDays(-1), DateTime.Now, DateTime.Now.AddDays(-1), false, false, pcUserMain.PageIndex, pcUserMain.PageSize).ToList();
                pcUserMain.RecordCount = pageInfo.RecordCount;
                this.dgvData.DataSource = _lstUser;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                MessageBox.Show("用户查询操作失败！", "系统错误");
            }
            

        }

        /// <summary>
        /// 根据分页控件的页数绑定grid
        /// </summary>
        private void BindGrid()
        {

            _lstUser = PharmacyDatabaseService.QueryPagedUsers(out pageInfo, _searchAccount, string.Empty, DateTime.Now, DateTime.Now.AddDays(-1), DateTime.Now, DateTime.Now.AddDays(-1), false, false, pcUserMain.PageIndex, pcUserMain.PageSize).ToList();
            this.dgvData.DataSource = _lstUser;

        }


        /// <summary>
        ///  Modify User Information
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
                        User updateUser = new User();
                        updateUser = _lstUser[listSelected[0]];
                        FormUserEdit formUserEdit = new FormUserEdit(FormOperation.Modify, updateUser);
                        if (formUserEdit.ShowDialog() == DialogResult.OK)
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
                MessageBox.Show(ex.Message, "系统错误");
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
            dicGridViewTilte.Add("Account", "登陆帐号");
            dicGridViewTilte.Add("Employee", "员工号");
            dicGridViewTilte.Add("CreateUserId", "创建用户编号");
            dicGridViewTilte.Add("CreateTime", "创建时间");
            dicGridViewTilte.Add("UpdateUserId", "更新用户编号");
            dicGridViewTilte.Add("UpdateTime", "更新时间");
            dicGridViewTilte.Add("Enabled", "是否启用");

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
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        List<int> listDelted = new List<int>();
        //        for (int i = 0; i < dgvData.Rows.Count; i++)
        //        {
        //            //判断是否被选中
        //            bool isChecked = false;
        //            if (dgvData.Rows[i].Cells[0].Value != null)
        //                isChecked = Convert.ToBoolean(dgvData.Rows[i].Cells[0].Value.ToString());
        //            else
        //                isChecked = false;
        //            if (isChecked)
        //                listDelted.Add(i);

        //        }
        //        if (listDelted.Count > 0)
        //        {

        //            if (MessageBox.Show("确定要删除" + listDelted.Count + "条数据吗？", "系统提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
        //            {
        //                return;
        //            }

        //            foreach (int i in listDelted)
        //            {
        //                string msg = string.Empty;
        //                User user =  _lstUser[i];
        //                user.Deleted = true;
        //                if (PharmacyDatabaseService.SaveUser(out msg,user))
        //                {
        //                    MessageBox.Show(string.Format("用户：{0}的记录删除失败", user.Account));
        //                    return;
        //                }
        //            }

        //            MessageBox.Show("用户数据删除成功！", "系统提示");
        //        }
        //        else
        //            MessageBox.Show("没有可以删除的记录，请至少选择一条记录！", "系统提示");
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error("FormUser:btnDelete_Click Error:" + ex);
        //    }

        //}
    }
}
