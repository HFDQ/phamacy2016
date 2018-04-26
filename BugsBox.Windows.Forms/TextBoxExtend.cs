using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugsBox.Windows.Forms
{
    /// <summary>
    /// 文本框扩展控件
    /// 当文本框获得焦点时，文本框背景色为亮黄色；当文本框失去焦点时，背景色还原。
    /// </summary>
    public class TextBoxExtend:System.Windows.Forms.TextBox
    {
        private System.Drawing.Color _backColor; //初始背景色
        public TextBoxExtend()
        {
            _backColor = BackColor;
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (Focused)
            {
                BackColor = System.Drawing.Color.LightYellow;

            }
            else
            {
                BackColor = _backColor;

            }


        }
    }
}
