using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Reports
{
    public partial class FormPurchaseOrderReport : BaseFunctionForm
    {
        public FormPurchaseOrderReport()
        {
            InitializeComponent();
        }

        private void FormPurchaseOrderReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
