using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    public class ControlActionable:IDisposable
    {
        private Action<Control> endaction = delegate { };
        private Action<Control> _preaction = delegate { };
        private Control control = null;

        /// <summary>
        ///  
        /// </summary>
        /// <param name="control"></param>
        /// <param name="preaction"></param>
        /// <param name="endaction"></param>
        public ControlActionable(Control control, Action<Control> preaction, Action<Control> endaction)
        {
            this.endaction = endaction;
            this._preaction = preaction;
            this.control = control;
            ControlThreadExtesions.DoAction(control, preaction);
        } 

        public void Dispose()
        {
            if (endaction != null && control != null)
             {
                 ControlThreadExtesions.DoAction(control, endaction);
             }
        } 
    }
}
