using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace System.Windows.Forms
{
    public static class ControlThreadExtesions
    {
        public static void DoAction(this Control control, Action<Control> action)
        {
            Control invokeCtrl = ControlValidator.GetValidateControl(control);
            if (ControlValidator.IsDisposed(invokeCtrl))
                return;
            if (control.InvokeRequired)
            {
                Action<Control, Action<Control>> innerAction = (c, a) => { DoAction(c, a); };
                control.Invoke(innerAction, control, action);
            }
            else
            {
                action(control);
            }
        }
    }
}
