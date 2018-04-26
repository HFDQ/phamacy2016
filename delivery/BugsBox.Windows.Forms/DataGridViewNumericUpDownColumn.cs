using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Windows.Forms
{
    public class DataGridViewNumericUpDownColumn : DataGridViewColumn
    {
        public DataGridViewNumericUpDownColumn()
        {
            this.CellTemplate = new DataGridViewNumericUpDownCell();
        }
        public override DataGridViewCell CellTemplate
        {

            get
            {
                return base.CellTemplate;
            }

            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewNumericUpDownCell)))
                {
                    throw new InvalidCastException("Must be a DataGridViewNumericUpDownCell");
                }
                base.CellTemplate = value;
            }

        }

        private DataGridViewNumericUpDownCell DataGridViewNumericUpDownCellTemplate
        {
            get
            {
                return (DataGridViewNumericUpDownCell)this.CellTemplate;
            }
        }

        private int decimalPlaces; 
        
        [Category("NumericUpDown属性")]
        [Description("获取或设置控件获得焦点时的背景色")]
        public int DecimalPlaces
        {
            get
            {
                Trace.WriteLine("Get" + this.GetType() + decimalPlaces);
                return decimalPlaces;
              
            }
            set
            { 
                decimalPlaces = value;
                Trace.WriteLine("Set" + this.GetType() + decimalPlaces);
                if (this.DataGridViewNumericUpDownCellTemplate == null)
                {
                    throw new InvalidOperationException("ImageButtonCellTemplate为空.");
                }
                this.DataGridViewNumericUpDownCellTemplate.DecimalPlaces = decimalPlaces;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        DataGridViewNumericUpDownCell cell = rows.SharedRow(i).Cells[base.Index] as DataGridViewNumericUpDownCell;
                        if (cell != null)
                        {
                            cell.DecimalPlaces = decimalPlaces;
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }

        }


    }
}
