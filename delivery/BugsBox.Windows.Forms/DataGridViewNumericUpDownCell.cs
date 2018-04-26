using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Windows.Forms
{
    public class DataGridViewNumericUpDownCell : DataGridViewTextBoxCell
    {

        public DataGridViewNumericUpDownCell()
            : base()
        {
           // this.Style.Format = "n";
        }

        public override object Clone()
        {
            DataGridViewNumericUpDownCell cell = base.Clone() as DataGridViewNumericUpDownCell; 
            cell.DecimalPlaces = this.DecimalPlaces; 
            return cell;
        }


        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {

            base.InitializeEditingControl(rowIndex,
                initialFormattedValue, dataGridViewCellStyle);

            NumericUpDownEditingControl NumBox =
                this.DataGridView.EditingControl as
                NumericUpDownEditingControl;
            if (NumBox != null)
            {
                Trace.WriteLine("InitializeEditingControl" + this.GetType() + DecimalPlaces);
                NumBox.DecimalPlaces = DecimalPlaces;
                if ((this.RowIndex < 0) || (this.ColumnIndex < 0))
                    return;

                NumBox.Text =
                    this.Value != null ? this.Value.ToString() : "1";
            }

        }

        public override Type EditType
        {
            get
            {
                return typeof(NumericUpDownEditingControl);
            }

        }

        public override Type ValueType
        {
            get
            {
                return typeof(object);
            }
        }



        public override object DefaultNewRowValue
        {
            get
            {
                return default(decimal);
            }

        }

        #region  扩展属性

        public int decimalPlaces = 0; 

        public int DecimalPlaces
        {
            get
            {
                Trace.WriteLine("Get"+this.GetType() + decimalPlaces);
                return decimalPlaces;
            }
            set
            { 
                decimalPlaces=value;
                Trace.WriteLine("Set" + this.GetType() + decimalPlaces);
            }
        }
        #endregion
    }
}
