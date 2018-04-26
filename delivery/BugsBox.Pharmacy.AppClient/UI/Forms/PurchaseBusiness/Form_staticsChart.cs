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
    public partial class Form_staticsChart : Form
    {
        List<Statics> ListStatics = new List<Statics>();
        public Form_staticsChart(List<object> o )
        {
            InitializeComponent();
            this.toolStripComboBox1.SelectedIndex = 0;
            Statics s = null;
            //foreach (var i in o)
            //{
            //    s = new Statics();
            //    s.saler = ;

            //    ListStatics.Add();
            //}

            this.chart1.Series[0].Points.DataBind(o, "em", "returnTax", string.Empty);
        }

        private void Form_staticsChart_Activated(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.toolStripComboBox1.SelectedIndex)
            {
                case 0:
                    this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    break;
                case 1:
                    this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar100;
                    break;
                case 2:
                    this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    break;
                case 3:
                    this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                    break;
            }
        }
    }

    public class Statics
    {
        public string saler { get; set; }
        public decimal returnTax { get; set; }
    }

}
