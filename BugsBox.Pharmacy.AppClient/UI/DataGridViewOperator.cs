using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Pharmacy.AppClient.UI
{
    class DataGridViewOperator
    {
        public DataGridViewOperator()
        {            
        }

        public static void SetRowNumber(System.Windows.Forms.DataGridView dgv, System.Windows.Forms.DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgv.RowHeadersWidth - 4, e.RowBounds.Height);
            System.Windows.Forms.TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            dgv.RowHeadersDefaultCellStyle.Font, rectangle,
            dgv.RowHeadersDefaultCellStyle.ForeColor,
            System.Windows.Forms.TextFormatFlags.VerticalCenter | System.Windows.Forms.TextFormatFlags.Right); 
        }
    }
}
