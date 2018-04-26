using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.UI.Common.Helper;
using BugsBox.Pharmacy.Models;
using BugsBox.Pharmacy.AppClient.PS;

namespace BugsBox.Pharmacy.UI.Common.UserControls
{
    public partial class PurchaseOrderUserControl : BaseFunctionUserControl
    {
        private bool _isGeneated = false;
        private OperateType _TYPE = OperateType.Browse;
       
        private enum OperateType
        {
            Add,
            Edit,
            Browse,
            Search,
            Delete
        }
        public PurchaseOrderUserControl()
        {
            InitializeComponent();
        }

        //新增操作
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _TYPE = OperateType.Add;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            _TYPE = OperateType.Edit;
            if (dataGridView1.CurrentRow != null)
            {

            }
            else
                MessageBox.Show("没有选择要修改的记录!");

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            _TYPE = OperateType.Browse;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
