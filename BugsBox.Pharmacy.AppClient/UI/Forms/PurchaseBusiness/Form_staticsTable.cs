using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.PurchaseBusiness
{
    public partial class Form_staticsTable : Form
    {
        public Form_staticsTable( object o, int flag=0)
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            
            if (flag == 1)
            {
                this.dataGridView1.Columns[this.Column1.Name].Visible = false;
                this.dataGridView1.Columns[this.Column9.Name].Visible = true;
            }
            this.dataGridView1.DataSource = o;                
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MyExcelUtls.DataGridview2Sheet(this.dataGridView1,"采购税票统计结果");
        }
    }
}
