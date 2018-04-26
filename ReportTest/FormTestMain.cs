using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportTest
{
    public partial class FormTestMain : Form
    {
        public FormTestMain()
        {
            InitializeComponent();
        }

        

        private void viewWordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new FormViewWord();
            form.Show();
        }

        private void printWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormPrintWord();
            form.Show();
        }

        private void exportWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormExportWord();
            form.Show();
        }
    }
}
