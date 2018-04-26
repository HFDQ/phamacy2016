using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.BaseDataManage
{
    public partial class Form_QualityFileSetup : Form
    {
        public Form_QualityFileSetup()
        {
            InitializeComponent();

            this.comboBox1.SelectedItem = SerialFile.csf.o.WarningDate.ToString();
            this.comboBox2.SelectedItem = SerialFile.csf.o.PurchaseWarningDate.ToString();
            this.comboBox3.SelectedItem = SerialFile.csf.o.DrugInfoQualityWarningDate.ToString();

            this.comboBox4.SelectedItem = SerialFile.csf.o.DrugWarningDate.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SerialFile.csf.o.WarningDate = int.Parse(this.comboBox1.SelectedItem.ToString());

            SerialFile.csf.o.PurchaseWarningDate = int.Parse(this.comboBox2.SelectedItem.ToString());

            SerialFile.csf.o.DrugInfoQualityWarningDate = int.Parse(this.comboBox3.SelectedItem.ToString());

            SerialFile.csf.o.DrugWarningDate = int.Parse(this.comboBox4.SelectedItem.ToString());

            SerialFile.SaveFile();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
