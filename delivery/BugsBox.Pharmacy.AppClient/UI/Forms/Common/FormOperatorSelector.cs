using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.AppClient.PS;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.Common
{
    public partial class FormOperatorSelector : Form
    {

        /// <summary>
        /// 选中的用户对象
        /// </summary>
        public User Result { get; private set; }

        public FormOperatorSelector()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 执行检索操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 选中的User情报返回到主画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;
            if (e.RowIndex < 0 || grid == null)
            {
                return;
            }

            //点击选择按钮
            if ("选择".Equals(grid.Columns[e.ColumnIndex].Name))
            {
                this.DialogResult = DialogResult.OK;
                this.Result = null;//返回的数据
                this.Close();
            }
        }
    }
}
