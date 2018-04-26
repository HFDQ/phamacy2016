using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.AppClient.UI.Forms.SalesBusiness
{
    public partial class Form_DrugSelectForSalesOrder : BaseFunctionForm
    {
        public Form_DrugSelectForSalesOrder()
        {
            InitializeComponent();
            this.dataGridView1.RowPostPaint +=(s,e)=> DataGridViewOperator.SetRowNumber(this.dataGridView1, e);
            this.dataGridView2.RowPostPaint += (s, e) => DataGridViewOperator.SetRowNumber(this.dataGridView1, e);
        }

        
    }
}
