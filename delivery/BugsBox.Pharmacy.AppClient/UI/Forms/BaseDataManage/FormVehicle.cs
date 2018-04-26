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
using BugsBox.Pharmacy.AppClient.UI.Forms.DataDictionary;
using BugsBox.Pharmacy.Models;


namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class FormVehicle : BaseFunctionForm
    {
        private Vehicle selectVehicle = new Vehicle();
        List<Vehicle> ListV = new List<Vehicle>();
        public FormVehicle()
        {
            InitializeComponent();
            this.toolStripComboBox1.SelectedIndex = 0;
            this.RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            try
            {
                string msg = string.Empty;
                
                ListV = PharmacyDatabaseService.AllVehicles(out msg).OrderBy(r => r.CreateTime).ToList();
                this.dataGridView1.DataSource = ListV;
                ProcessGridViewAppearance();
            }
            catch (Exception ex)
            {
                MessageBox.Show("刷新数据失败！", "系统错误");
                Log.Error(ex);
            }
        }

        private void ProcessGridViewAppearance()
        {
            foreach (DataGridViewColumn clm in this.dataGridView1.Columns)
            {
                switch (clm.Name)
                {
                    case "Type":
                        clm.HeaderText = "工具类型";
                        clm.Visible = true;
                        break;
                    case "Cubage":
                        clm.HeaderText = "容积";
                        clm.Visible = true;
                        break;
                    case "Driver":
                        clm.HeaderText = "运输人";
                        clm.Visible = true;
                        break;
                    case "Rule":
                        clm.HeaderText = "规则";
                        clm.Visible = true;
                        break;
                    case "Status":
                        clm.HeaderText = "状态";
                        clm.Visible = true;
                        break;
                    case "Other":
                        clm.HeaderText = "其他参数";
                        clm.Visible = true;
                        break;
                    case "LicensePlate":
                        clm.HeaderText = "牌号";
                        clm.Visible = true;
                        break;
                    case "Column1":
                        clm.Visible = true;
                        break;
                    default:
                        clm.Visible = false;
                        break;
                }
            }
        }
        
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                this.dataGridView1.Rows[e.RowIndex].HeaderCell.Value = (e.RowIndex + 1).ToString();


                var c = this.dataGridView1.Rows[e.RowIndex].Cells["ApprovalStatusValue"].Value;
                if (c == null)
                    this.dataGridView1.Rows[e.RowIndex].Cells[this.Column1.Name].Value = "自有运输工具，无审批信息";
                else
                {
                    this.dataGridView1.Rows[e.RowIndex].Cells[this.Column1.Name].Value = (int)c == 1 ? "审批中" : (int)c == 2 ? "审批通过" : "审批未通过";
                }

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)//新增
        {
            FormVehicleEdit form = new FormVehicleEdit(null);
            form.ShowDialog();
            if (form.ruslt == System.Windows.Forms.DialogResult.Yes)
            {
                RefreshDataGridView();
                this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, ",新增一条运输工具信息" );
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            selectVehicle = (Vehicle)this.dataGridView1.CurrentRow.DataBoundItem;
            FormVehicleEdit form = new FormVehicleEdit(selectVehicle);
            form.ShowDialog();
            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                RefreshDataGridView();
                this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, ",修改一条运输工具信息:" + selectVehicle.LiscenceCode);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count <= 0)
            {
                MessageBox.Show("请点击列表左侧的灰色固定栏,以选中整条记录,再执行删除操作!"); return;
            }
            var c = this.dataGridView1.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show("确定要删除选中的运输工具记录吗？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string msg = string.Empty;
                PharmacyDatabaseService.DeleteVehicle(out msg, ((Models.Vehicle)c).Id);
                if (string.IsNullOrEmpty(msg))
                {
                    RefreshDataGridView();
                    this.PharmacyDatabaseService.WriteLog(BugsBox.Pharmacy.AppClient.Common.AppClientContext.CurrentUser.Id, ",删除一条运输工具信息:"+((Models.Vehicle)c).LiscenceCode);
                }                
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListV.Count <= 0) return;
            int s = this.toolStripComboBox1.SelectedIndex - 1;
            if (s == -1)
            {
                this.dataGridView1.DataSource = ListV;
            }
            else
            {
                this.dataGridView1.DataSource = ListV.Where(r => r.VehicleCategoryValue == s);
            }
            this.dataGridView1.Refresh();
            ProcessGridViewAppearance();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                string s=this.textBox1.Text.Trim();
                if(string.IsNullOrEmpty(s))return;
                s=s.ToUpper();
                var c= ListV.Where(r => (r.LiscenceCode!=null && r.LiscenceCode.Contains(s)) || r.LicensePlate.ToUpper().Contains(s) || r.Driver.Contains(s) ||(r.DelegateCompany!=null && r.DelegateCompany.Contains(s))).ToList();
                if (c.Count <= 0) return;
                this.dataGridView1.DataSource = c;
                this.dataGridView1.Refresh();
                ProcessGridViewAppearance();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.RefreshDataGridView();
        }
        
    }
}
