using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BugsBox.Windows.Forms
{
    /// <summary>
    /// 进行焦点切换的form类
    /// Enter键跳转到下一个控件；Ctrl+B 回退到上一个控件
    /// 控件切换顺序由TabIndex决定
    /// </summary>
    public partial class FormExtend : Form
    {        
        public FormExtend()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void FormExtend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.B)
            {
                this.SelectNextControl(this.ActiveControl, false, true, true, true);
            }

        }
    }
}
