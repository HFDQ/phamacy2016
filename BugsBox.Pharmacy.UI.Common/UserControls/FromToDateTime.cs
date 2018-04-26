using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Pharmacy.UI.Common.UserControls
{
    public partial class FromToDateTime : UserControl
    {
        public FromToDateTime()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now.AddDays(-1);
        }

        [Browsable(true), Description("开始时间"), Category("自定义")]
        public DateTime StartTime
        {

            get
            {
                return dateTimePicker1.Value;
            }
            set
            {
                dateTimePicker1.Value = value;
            }
        }

        [Browsable(true), Description("结束时间"), Category("自定义")]
        public DateTime EndTime
        {

            get
            {
                return dateTimePicker2.Value;
            }
            set
            {
                dateTimePicker2.Value = value;
            }
        }

        [Browsable(true), Description("标签名"), Category("自定义")]
        public String LabelName
        {

            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }
    }
}
