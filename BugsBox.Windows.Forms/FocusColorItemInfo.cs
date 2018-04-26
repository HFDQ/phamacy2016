using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Windows.Forms
{
    public class FocusColorItemInfo
    {
        private Control control;

        public Control Control
        {
            get { return control; }
            set { control = value; }
        } 
        private BugsBoxFocusColorProvider provider;

        public FocusColorItemInfo(BugsBoxFocusColorProvider provider, Control control)
        { 
            this.control = control;
            this.provider = provider;
        }

        public Color FocusBackColor = Color.LightSkyBlue;
        public Color FocusForeColor = Color.White;
    }
}
