using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Windows.Forms
{
    public class DataGridViewCalendarColumn : DataGridViewColumn
    { 
        public DataGridViewCalendarColumn(): base(new DataGridViewCalendarCell())
        {

        }
        public override DataGridViewCell CellTemplate
        {

            get
            {

                return base.CellTemplate;

            }

            set
            { 
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewCalendarCell)))
                { 
                    throw new InvalidCastException("Must be a CalendarCell"); 
                } 
                base.CellTemplate = value; 
            }

        }

    }
}
