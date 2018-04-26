using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Windows.Forms
{
    [ProvideProperty("FocusBackColor", typeof(Control))]
    [ProvideProperty("FocusForeColor", typeof(Control))]
    public class BugsBoxFocusColorProvider : Component, IExtenderProvider
    {
        private IContainer components;
        private Dictionary<Control, FocusColorItemInfo> items;
        private Dictionary<Control, Color> controlsBackColor;
        private Dictionary<Control, Color> controlsForeColor;

        public BugsBoxFocusColorProvider()
        {
            items = new Dictionary<Control, FocusColorItemInfo>();
            controlsBackColor = new Dictionary<Control, Color>();
            controlsForeColor = new Dictionary<Control, Color>();
            this.InitializeComponent();
        }

        public BugsBoxFocusColorProvider(IContainer container)
            : this()
        {
            container.Add(this);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
        }

        public bool CanExtend(object extendee)
        {
            return extendee is TextBox
                || extendee is ComboBox
                || extendee is MaskedTextBox
                || extendee is NumericUpDown
                || extendee is RichTextBox
                || extendee is DateTimePicker;
        }

        private FocusColorItemInfo EnsureControlItem(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }
            FocusColorItemInfo item = null;
            if (!this.items.ContainsKey(control))
            {
                item = new FocusColorItemInfo(this, control);
                controlsBackColor.Add(control, control.BackColor);
                controlsForeColor.Add(control, control.ForeColor);
                InitFocusColorItemInfo(item);
                this.items.Add(control, item);
            }
            item = this.items[control];
            return item;
        }

        private void InitFocusColorItemInfo(FocusColorItemInfo itemInfo)
        {
            itemInfo.Control.GotFocus += new EventHandler(Control_GotFocus);
            itemInfo.Control.LostFocus += new EventHandler(Control_LostFocus);
        }

        void Control_LostFocus(object sender, EventArgs e)
        {
            Control control = sender as Control;
            FocusColorItemInfo item = this.items[control];
            control.BackColor = controlsBackColor[control];
            control.ForeColor = controlsForeColor[control];
        }

        void Control_GotFocus(object sender, EventArgs e)
        {
            Control control = sender as Control;
            FocusColorItemInfo item = this.items[control];
            control.BackColor = item.FocusBackColor;
            control.ForeColor = item.FocusForeColor;
        }

        [Category("BugsBox焦点")]
        [DisplayName("FocusBackColor")]
        [Description("获取或设置控件获得焦点时的背景色")]
        public Color GetFocusBackColor(Control control)
        {
            return this.EnsureControlItem(control).FocusBackColor;
        }


        public void SetFocusBackColor(Control c, Color value)
        {
            this.EnsureControlItem(c).FocusBackColor = value;
        }

        [Category("BugsBox焦点")]
        [DisplayName("FocusForeColor")]
        [Description("获取或设置控件获得焦点时的前景色")]
        public Color GetFocusForeColor(Control control)
        {
            return this.EnsureControlItem(control).FocusForeColor;
        }


        public void SetFocusForeColor(Control c, Color value)
        {
            this.EnsureControlItem(c).FocusForeColor = value;
        }
    }
}
