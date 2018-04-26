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
    /// 库区选择
    /// </summary>
    public partial class FormWarehouseZoneSelector : BaseFunctionForm
    {
        /// <summary>
        /// 选中的库区商对象
        /// </summary>
        public WarehouseZone Result { get; private set; }

        private string msg = string.Empty;
        private List<WarehouseZone> warehouseZones = null;

        public FormWarehouseZoneSelector()
        {
            InitializeComponent();
            dgvUserList.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 对库区进行查询
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
                warehouseZones = this.PharmacyDatabaseService.AllWarehouseZones(out msg).ToList();
                if (!string.IsNullOrWhiteSpace(msg))
                {
                    MessageBox.Show(msg);
                }
                dgvUserList.DataSource = warehouseZones;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 选中库区
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
                this.Result = warehouseZones[e.RowIndex];//返回的数据
                this.Close();
            }
        }
    }
}
