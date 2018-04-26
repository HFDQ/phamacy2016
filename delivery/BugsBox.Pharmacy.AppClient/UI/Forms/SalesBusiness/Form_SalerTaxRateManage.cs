using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BugsBox.Pharmacy.Models;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class Form_SalerTaxRateManage : BaseFunctionForm
    {
        public List<User> ListUser { get; set; }
        public List<PurchaseUnit> ListPurchaseUnit { get; set; }
        public List<Business.Models.SalesTaxRate> ListSalesTaxRate = new List<Business.Models.SalesTaxRate>();
        Guid pid = Guid.Empty;
        Guid uid = Guid.Empty;

        string msg = string.Empty;
        Business.Models.SalesTaxRate CurrentTaxRate = null;

        public Form_SalerTaxRateManage()
        {
            InitializeComponent();

            ListUser = this.PharmacyDatabaseService.AllUsers(out msg).OrderBy(r => r.Employee.Name).ToList();
            ListPurchaseUnit = this.PharmacyDatabaseService.AllPurchaseUnits(out msg).OrderBy(r => r.Name).ToList();
            
            this.comboBox2.DisplayMember = "Account";
            this.comboBox2.ValueMember = "Id";
            this.comboBox2.DataSource = ListUser;
            
            this.comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;            
            label11.Text = "查询";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox2.Items.Count <= 0) return;
            if (this.comboBox2.SelectedIndex < 0)
            {
                label2.Text = "";
                return;
            }
            Guid gid = (Guid)(this.comboBox2.SelectedValue);
            label3.Text = this.ListUser.Where(r => r.Id == gid).First().Employee.Name;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string qStr = this.textBox3.Text.Trim();
            this.label2.Text = string.Empty;
            var c = this.ListPurchaseUnit.Where(r => r.Name.Contains(qStr) || r.PinyinCode.ToUpper().Contains(qStr.ToUpper())).ToList();
            if (c.Count<=0) return;

            this.comboBox1.DataSource = c;
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.SelectedIndex = 0;
            this.label2.Text = ((PurchaseUnit)this.comboBox1.SelectedItem).Name;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 税费验证
            decimal mRate=0m;
            decimal IRate=0m;

            if(!decimal.TryParse(this.textBox1.Text.Trim(),out mRate))
            {
                MessageBox.Show("管理费率填写错误，请修改！"); return;
            }
            if (!decimal.TryParse(this.textBox2.Text.Trim(), out IRate))
            {
                MessageBox.Show("发票费率填写错误，请修改！"); return;
            }

            if (this.comboBox1.SelectedValue == null)
            {
                MessageBox.Show("供货商没有选择！"); return;
            }

            if (this.comboBox2.SelectedValue == null)
            {
                MessageBox.Show("销售人员没有选择！"); return;
            }

            Guid Pid = (Guid)this.comboBox1.SelectedValue;
            Guid Uid = (Guid)this.comboBox2.SelectedValue;
                        
            #endregion
            #region 新增
            if (this.label11.Text == "新增")
            {
                var c = ListSalesTaxRate.Where(r => r.PurchaseUnitId.Equals(Pid) && r.UserId.Equals(Uid)).FirstOrDefault();
                if (c != null)
                {
                    MessageBox.Show("该用户与购货商的管理费与税票费已配置!"); return;
                }
                TaxRate tr = new TaxRate();
                tr.Id = Guid.NewGuid();
                tr.Enabled = true;
                tr.Deleted = false;
                tr.PurchaseUnitID = (Guid)this.comboBox1.SelectedValue;
                tr.UserID = (Guid)this.comboBox2.SelectedValue;
                tr.MRate = mRate;
                tr.IRate = IRate;
                tr.Code = "无";
                tr.Name = ((User)this.comboBox2.SelectedItem).Employee.Name;
                tr.Decription = string.Empty;
                #region 保存
                if (this.PharmacyDatabaseService.AddTaxRate(out msg, tr))
                {
                    MessageBox.Show("保存成功！");
                    this.search();
                }
                else
                {
                    MessageBox.Show("保存失败！" + msg);
                }
                #endregion
            }
            #endregion
            #region 修改
            if (this.label11.Text == "修改")
            {
                if (this.CurrentTaxRate == null) return;
                TaxRate tr = this.PharmacyDatabaseService.GetTaxRate(out msg, this.CurrentTaxRate.Id);
                tr.PurchaseUnitID = (Guid)this.comboBox1.SelectedValue;
                tr.UserID = (Guid)this.comboBox2.SelectedValue;
                tr.MRate = mRate;
                tr.IRate = IRate;
                if (this.PharmacyDatabaseService.SaveTaxRate(out msg, tr))
                {
                    MessageBox.Show("保存成功！");
                    this.search();
                }
                else
                {
                    MessageBox.Show("保存失败，请联系管理员！");
                }
            }
            #endregion
            this.toolStripButton5.Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            pid = Guid.Empty;
            uid = Guid.Empty;
            this.search();
            this.label11.Text = "查询";
            this.toolStripButton5.Visible = false;
            this.toolStripButton5.Visible = false;
        }

        private void HideGridColumns()
        {
            this.dataGridView1.Columns["id"].Visible = false;
            this.dataGridView1.Columns["userid"].Visible = false;
            this.dataGridView1.Columns["PurchaseUnitId"].Visible = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            uid = this.comboBox2.SelectedValue == null ? Guid.Empty : (Guid)this.comboBox2.SelectedValue;
            pid = this.comboBox1.SelectedValue == null ? Guid.Empty : (Guid)this.comboBox1.SelectedValue;            
            this.search();
            this.label11.Text = "查询";
        }

        private void search()
        {
            this.ListSalesTaxRate = this.PharmacyDatabaseService.GetSalesTaxRate(pid, uid, out msg).ToList();
            this.dataGridView1.DataSource = this.ListSalesTaxRate;
            this.HideGridColumns();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.Items.Count <= 0) return;
            label2.Text = ((PurchaseUnit)this.comboBox1.SelectedItem).Name;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (ListSalesTaxRate == null || ListSalesTaxRate.Count <= 0) return;
            int rdx = e.RowIndex;
            this.dataGridView1.Rows[rdx].Selected = true;
            Guid uid = (Guid)ListSalesTaxRate[rdx].UserId;
            Guid pid = (Guid)ListSalesTaxRate[rdx].PurchaseUnitId;
            this.comboBox2.SelectedValue = uid;
            this.comboBox1.ValueMember = "Id";
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.DataSource = this.ListPurchaseUnit;
            this.comboBox1.SelectedValue = pid;
            this.textBox1.Text = ListSalesTaxRate[rdx].MRate.ToString();
            this.textBox2.Text = ListSalesTaxRate[rdx].IRate.ToString();

            this.CurrentTaxRate = ListSalesTaxRate[rdx];
            this.toolStripButton5.Visible = true;
            this.label11.Text = "修改";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //this.comboBox2.Text = string.Empty;
            //this.comboBox2.SelectedValue = null;
            //this.label2.Text=string.Empty;

            //this.textBox3.Text = string.Empty;
            //this.comboBox1.SelectedValue = null;
            //label3.Text = string.Empty;
            this.label11.Text = "新增";
            this.toolStripButton5.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uid = (Guid)this.comboBox2.SelectedValue;
            pid = Guid.Empty;
            search();
            this.label11.Text = "查询";
            this.toolStripButton5.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.pid = this.comboBox1.SelectedValue == null ? Guid.Empty : (Guid)this.comboBox1.SelectedValue;
            this.uid = Guid.Empty;
            search();
            this.label11.Text = "查询";
            this.toolStripButton5.Visible = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Guid Gid = this.ListSalesTaxRate[this.dataGridView1.CurrentCell.RowIndex].Id;
            Business.Models.SalesTaxRate str=this.ListSalesTaxRate[this.dataGridView1.CurrentCell.RowIndex];

            if (MessageBox.Show("确定要删除该条记录吗？ "+str.EmployeeName+" : "+ str.PurchaseUnitName, "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return;
            if (this.PharmacyDatabaseService.DeleteTaxRate(out msg, Gid))
            {
                MessageBox.Show("删除该条记录成功！");
            }
            else
            {
                MessageBox.Show("删除该条记录失败，请联系管理员！");
            }
            this.toolStripButton5.Visible = false;
            this.search();
        }


    }
}
