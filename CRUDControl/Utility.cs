using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace CRUDControl
{
    public class Utility
    {
        public static void AssignValueToControl(DataGridViewRow dr, Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (!string.IsNullOrEmpty(c.Name) && dr.Cells[c.Name].Value != null)
                {
                    switch (c.GetType().Name)
                    {
                        case "TextBox":
                            ((TextBox)c).Text = dr.Cells[c.Name].Value.ToString();
                            break;
                        case "CheckBox":
                            ((CheckBox)c).Checked = (Boolean)dr.Cells[c.Name].Value;
                            break;
                        case "DateTimePicker":
                            ((DateTimePicker)c).Value = (DateTime)dr.Cells[c.Name].Value;
                            break;
                        case "ComboBox":
                            ((ComboBox)c).SelectedValue = dr.Cells[c.Name].Value;
                            break;
                    }
                }
            }
        }
        public static void Generate_Controls(DataGridView dataGridView, Control control)
        {
            // top of textboxes
            int current_top = 10;
            int current_left = 50;

            // index used to match between each textbox and the properate column in grid
            int my_index = -1;

            // iterate the grid and create textbox for each column
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                my_index++;

                // generate textboxes only for visible columns
                if (col.Visible == true)
                {
                    // increase the top each time for space between textboxes
                    current_top += 40;

                    //// create a second column of textboxes (not all of them in 1 long column)
                    if (my_index == 6) { current_top = 50; current_left = 450; }


                    Control c;
                    switch (col.ValueType.ToString())
                    {
                        case "System.String":
                            c = new TextBox();
                            break;
                        case "System.Boolean":
                            c = new CheckBox();
                            break;
                        case "System.DateTime":
                        case "System.Nullable`1[System.DateTime]":
                            c = new DateTimePicker();
                            break;
                        case "System.Guid":
                            c = new ComboBox();
                            break;
                        default:
                            c = new TextBox();
                            break;
                    }

                    switch (col.Name)
                    {
                        case "StoreTypeValue":
                            c = new ComboBox();
                            
                            
                            break;
                    }
                    c.Top = current_top;
                    c.Left = current_left + 100;
                    c.Width = 170;
                    c.Name = col.Name;
                    Label l = new Label();
                    l.Text = col.HeaderCell.Value.ToString() + ":";
                    l.Top = current_top;
                    l.Left = current_left;

                    control.Controls.Add(l);
                    control.Controls.Add(c);
                }
            }
        }
    }
}
