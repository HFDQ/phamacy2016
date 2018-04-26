using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Windows.Forms
{
    public class DataGridViewCalendarCell : DataGridViewTextBoxCell
    {

        public DataGridViewCalendarCell()
            : base()
        {
            this.Style.Format = "d";
        }
        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {

            base.InitializeEditingControl(rowIndex, initialFormattedValue,dataGridViewCellStyle);
            CalendarEditingControl ctl =DataGridView.EditingControl as CalendarEditingControl;
            try
            {
                ctl.Value = (DateTime)this.Value;
            }
            catch { }
        }
        public override Type EditType
        {
            get
            {
                return typeof(CalendarEditingControl);
            }

        }

        public override Type ValueType
        {
            get
            {
                return typeof(DateTime);
            }
        }



        public override object DefaultNewRowValue
        {
            get
            {
                return DateTime.Now;
            }

        }

    }
}
