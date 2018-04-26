using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportTest
{
    public partial class FormViewWord : Form
    {
        public FormViewWord()
        {
            InitializeComponent();
        }

        private string file { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK
                && string.IsNullOrWhiteSpace(this.openFileDialog1.FileName)
                && File.Exists(this.openFileDialog1.FileName)
                )
            {
                file = this.openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
    }
}
