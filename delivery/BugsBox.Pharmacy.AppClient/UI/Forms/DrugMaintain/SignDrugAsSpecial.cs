using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.DrugMaintain
{
    public partial class SignDrugAsSpecial : BaseFunctionForm
    {

        string msg = string.Empty;
        List<Business.Models.DrugInventoryNearExpiration> ListDrugExpire = null;

        BaseForm.BasicInfoRightMenu cms=null;

        int WarningDate = SerialFile.csf.o.DrugWarningDate;

        public SignDrugAsSpecial()
        {
            InitializeComponent();

            this.toolStripComboBox1.SelectedIndex = 0;
            this.toolStripComboBox2.SelectedIndex = this.toolStripComboBox2.Items.Count -1;

            cms = new BaseForm.BasicInfoRightMenu(this.dataGridView1);

            this.dataGridView1.RowPostPaint += delegate(object o, DataGridViewRowPostPaintEventArgs ex) { DataGridViewOperator.SetRowNumber((DataGridView)o, ex); };

            this.toolStripComboBox2.SelectedItem = this.WarningDate.ToString();
        }

        private void SignDrugAsSpecial_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.toolStripTextBox1.Focus();

            this.toolStripButton1_Click(null, null);
            setDgvColor();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int month = this.toolStripComboBox2.SelectedIndex + 1;
            int maintainType = this.toolStripComboBox1.ComboBox.SelectedIndex;
            this.ListDrugExpire = this.PharmacyDatabaseService.GetDrugInventoryRecordNearExpirationDate(month, this.toolStripTextBox1.Text.Trim(), maintainType, out msg).OrderBy(r => r.invalidDate).ToList();

            this.dataGridView1.DataSource = new BindingCollection<Business.Models.DrugInventoryNearExpiration>( this.ListDrugExpire);
            dataGridView1.ClearSelection();
            setDgvColor();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int month=this.toolStripComboBox2.SelectedIndex+1;
            int maintainType=this.toolStripComboBox1.SelectedIndex;
            this.ListDrugExpire = this.PharmacyDatabaseService.GetDrugInventoryRecordNearExpirationDate(month, this.toolStripTextBox1.Text.Trim(), maintainType, out msg).OrderBy(r => r.invalidDate).ToList();
            this.dataGridView1.DataSource = new BindingCollection<Business.Models.DrugInventoryNearExpiration>( this.ListDrugExpire);
            dataGridView1.ClearSelection();
            setDgvColor();
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.toolStripButton1_Click(sender, e);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1, "近效期药品");
        }

        private void setDgvColor()
        {
            if (this.dataGridView1.Rows.Count <= 0) return;
            foreach (DataGridViewRow r in this.dataGridView1.Rows)
            {
                if (Convert.ToDateTime(r.Cells["Column5"].Value)<= DateTime.Now.AddMonths(6))
                {
                    r.DefaultCellStyle.BackColor = Color.GreenYellow;
                }
                if (Convert.ToDateTime(r.Cells["Column5"].Value) <= DateTime.Now.AddMonths(3))
                {
                    r.DefaultCellStyle.BackColor = Color.Yellow;
                }
                if (Convert.ToDateTime(r.Cells["Column5"].Value) <= DateTime.Now.AddMonths(2))
                {
                    r.DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            SerialFile.csf.o.DrugWarningDate = int.Parse(this.toolStripComboBox2.SelectedItem.ToString());
            SerialFile.SaveFile();
        }
    }
}
