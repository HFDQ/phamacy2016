using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace System.Windows.Forms
{
    public class ControlValidator
    {
        public static bool IsHandleCreated(Control control)
        {
            if (IsDisposed(control))
            {
                return false;
            }
            return control.IsHandleCreated;
        }

        public static bool IsDisposed(Control control)
        {
            if (control == null)
                return true;
            if (control.IsDisposed)
                return true;
            return false;
        }

        public static bool IsDisposed(Component component)
        {
            return component == null;
        }

        public static Control GetValidateControl(Control control)
        {
            if (IsDisposed(control))
            {
                return null;
            } 
            //while (!IsHandleCreated(control))
            //{
            //    GetValidateControl(control.Parent);
            //}
            return control;
        }
    }
}
