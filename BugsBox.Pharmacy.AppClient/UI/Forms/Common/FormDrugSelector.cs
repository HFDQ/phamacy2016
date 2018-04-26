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
    public partial class FormDrugSelector : Form
    {
        /// <summary>
        /// 选中的商品对象
        /// </summary>
        public DrugInfo Result { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public FormDrugSelector()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 根据商品名称或者商品编号模糊查询商品列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.dvgDrugDetailList.Rows.Add();
        }

        /// <summary>
        /// 选中某一个商品并返回到主画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dvgDrugDetailList_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
