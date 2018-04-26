using BugsBox.Pharmacy.Models;
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
    public partial class AddSpecial : BaseFunctionForm
    {
        public static Guid DrugInventoryId;
        public AddSpecial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrugSearch ds = new DrugSearch();
            ds.ShowDialog();

            string msg;
            DrugInventoryRecord item = PharmacyDatabaseService.GetDrugInventoryRecord(out msg, DrugInventoryId);
           txtProductName.Text = item.DrugInfo.ProductName;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (DrugInventoryId == null)
            {
                MessageBox.Show("请选择药品","提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            SetSpeicalDrugRecord ssdr = new SetSpeicalDrugRecord();
            ssdr.DrugInventoryId = DrugInventoryId;
            ssdr.MaintainDuetime = Convert.ToInt32(txtMaintainDuetime.Value);
            ssdr.MaintainEmphasis = txtMaintainEmphasis.Text.Trim();
            ssdr.Reason =txtReason.Text.Trim();
            ssdr.Memo = txtMemo.Text.Trim();
            PharmacyDatabaseService.CreateSetSpeicalDrugRecords(ssdr);
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
