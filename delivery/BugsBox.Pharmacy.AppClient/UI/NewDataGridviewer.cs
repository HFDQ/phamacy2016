using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace BugsBox.Pharmacy.AppClient.UI
{
    class NewDataGridviewer : DataGridView
    {
        protected override bool ProcessDialogKey(Keys keyData)
        {
            Keys key = (keyData & Keys.KeyCode);
            if (key == Keys.Enter)
            {
                return this.ProcessRightKey(keyData);
            }
            if (key == Keys.F3)
            {
                return this.ProcessRightKey(keyData);
            }
            return base.ProcessDialogKey(keyData);
        }

        public new bool ProcessRightKey(Keys keyData)
        {
            Keys key = (keyData & Keys.KeyCode);
            if (key == Keys.Enter)
            {
                if ((base.CurrentCell.ColumnIndex == (base.ColumnCount - 1)) && (base.CurrentCell.RowIndex < (base.RowCount - 1)))
                {
                    base.CurrentCell = base.Rows[base.CurrentCell.RowIndex + 1].Cells[0];
                    this.BeginEdit(true);
                    return true;
                }
                return base.ProcessRightKey(keyData);
            }
            if (key == Keys.F3)
            {
                if (base.Rows.Count > 1)
                {
                    if (MessageBox.Show("确定要删除该行吗？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        base.Rows.Remove(base.CurrentRow);
                        return true;
                    }
                }
                return base.ProcessRightKey(keyData);
            }
            return base.ProcessRightKey(keyData);
        }

        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                return this.ProcessRightKey(e.KeyData);
            }
            return base.ProcessDataGridViewKey(e);
        }
    }
}



