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
    /// <summary>
    /// 采购商选择
    /// </summary>
    public partial class FormPurchaseSelector : BaseFunctionForm
    {
        /// <summary>
        /// 选中的采购商对象
        /// </summary>
        public PurchaseUnit Result { get; private set; }

        private string msg = string.Empty;
        private List<PurchaseUnit> purchaseunits = null;

        public FormPurchaseSelector()
        {
            InitializeComponent();
            dgvUserList.AutoGenerateColumns = false;
        }

        public FormPurchaseSelector(string Keyword):this()
        {
            if (string.IsNullOrEmpty(Keyword))
            {
                this.getData();
                return;
            }
            if ((int)Keyword[0] > 127)
            {
                this.txtName.Text = Keyword;
            }
            else
            {
                this.txtPy.Text = Keyword;
            }
            this.getData();
        }

        /// <summary>
        /// 对采购商进行查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void getData()
        {
            try
            {
                purchaseunits = this.PharmacyDatabaseService.GetPurchaseUnitsForSelector(out msg, txtName.Text.Trim(), txtCode.Text, txtPy.Text).ToList();
                if (!string.IsNullOrWhiteSpace(msg))
                {
                    MessageBox.Show(msg);
                }
                dgvUserList.DataSource = purchaseunits;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 选中采购商
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
                this.Result = purchaseunits[e.RowIndex];//返回的数据
                this.Close();
            }
        }

        private void FormPurchaseSelector_Activated(object sender, EventArgs e)
        {
            this.txtPy.Focus();
        }

        private void txtPy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                getData();
                this.dgvUserList.Focus();
            }
            
            if(this.dgvUserList.Rows.Count>0)
            {
                this.dgvUserList.CurrentCell = dgvUserList.Rows[0].Cells[0];  
            }
        }

        private void dgvUserList_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvUserList.CurrentRow == null) return;
            if (e.KeyCode == Keys.Return)
            {
                this.DialogResult = DialogResult.OK;
                this.Result = purchaseunits[this.dgvUserList.CurrentRow.Index];//返回的数据
                this.Close();
            }
        }
    }
}
